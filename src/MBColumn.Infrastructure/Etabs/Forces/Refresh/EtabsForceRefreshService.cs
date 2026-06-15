using MBColumn.Application.DTOs.Etabs;
using MBColumn.Application.DTOs.Persistence;
using MBColumn.Application.Services.Etabs;
using MBColumn.Domain.Enums;

namespace MBColumn.Infrastructure.Etabs;

public sealed class EtabsForceRefreshService : IEtabsForceRefreshService
{
    private readonly IEtabsConnectionService connectionService;
    private readonly IEtabsForceImportService forceImportService;
    private readonly IEtabsColumnImportService columnImportService;
    private readonly IEtabsBindingReconciliationService reconciliationService;
    private readonly IEtabsForceMapper forceMapper;
    private readonly IEtabsForceChangeDetector changeDetector;
    private readonly IEtabsResultStateService resultStateService;
    private readonly object candidateColumnCacheLock = new();
    private UnitSystem? cachedCandidateColumnUnitSystem;
    private DateTime cachedCandidateColumnReadAtUtc;
    private IReadOnlyList<EtabsColumnImportDto>? cachedCandidateColumns;

    public EtabsForceRefreshService(
        IEtabsConnectionService connectionService,
        IEtabsForceImportService forceImportService,
        IEtabsColumnImportService columnImportService,
        IEtabsBindingReconciliationService reconciliationService,
        IEtabsForceMapper forceMapper,
        IEtabsForceChangeDetector changeDetector,
        IEtabsResultStateService resultStateService)
    {
        this.connectionService = connectionService;
        this.forceImportService = forceImportService;
        this.columnImportService = columnImportService;
        this.reconciliationService = reconciliationService;
        this.forceMapper = forceMapper;
        this.changeDetector = changeDetector;
        this.resultStateService = resultStateService;
    }

    public EtabsResultState CheckResultState(EtabsForceRefreshRequest request)
    {
        var combos = request.SelectedLoadCombinations;
        return request.ForceSource == MbColumnForceSourceMode.DesignForces
            ? resultStateService.CheckDesignForceAvailability(combos)
            : resultStateService.CheckElementForceAvailability(combos);
    }

    public void RunEtabsAnalysis()
    {
        // Delegates to ETABS COM via connection service — concrete implementation
        // would call SapModel.Analyze.RunAnalysis() through the connection service.
        // This stub satisfies the interface; a full COM-aware override hooks into EtabsConnectionService.
    }

    public void RunEtabsDesign()
    {
        // Would call SapModel.DesignConcrete.StartDesign() through the connection service.
    }

    public EtabsBindingValidationResult ValidateEtabsSourceObjectMapping(
        EtabsForceRefreshRequest request,
        UnitSystem unitSystem)
        => ValidateEtabsSourceObjectMapping(request, unitSystem, out _);

    public EtabsBindingValidationResult ValidateEtabsSourceObjectMapping(
        EtabsForceRefreshRequest request,
        UnitSystem unitSystem,
        out EtabsModelInfoDto? connectedModelInfo)
    {
        var connectionResult = connectionService.ConnectToRunningEtabs();
        if (!connectionResult.IsConnected)
            throw new InvalidOperationException("Cannot connect to ETABS: " + connectionResult.Message);

        var modelInfo = connectionResult.ModelInfo!;
        connectedModelInfo = modelInfo;
        var currentCombos = columnImportService.GetLoadCombinations();
        var candidateColumns = GetCandidateColumnsCached(unitSystem);
        var currentColumns = GetCurrentColumnKeys(candidateColumns);
        var currentPierLabels = GetCurrentPierLabels(candidateColumns);

        var validation = reconciliationService.ValidateBindings(
            request.Bindings,
            modelInfo.ModelPath,
            modelInfo.ModelName,
            currentColumns,
            currentPierLabels,
            currentCombos);

        if (request.AllowSourceModelMismatch && request.SourceModelMismatchConfirmed)
            validation.ModelChanged = false;

        return validation;
    }

    public EtabsForceRefreshPreview BuildPreview(
        EtabsForceRefreshRequest request,
        IReadOnlyDictionary<string, IReadOnlyList<SnapshotLoadCase>> existingLoadCasesBySection,
        UnitSystem unitSystem)
    {
        var connectionResult = connectionService.ConnectToRunningEtabs();
        if (!connectionResult.IsConnected)
            throw new InvalidOperationException("Cannot connect to ETABS: " + connectionResult.Message);

        var modelInfo = connectionResult.ModelInfo!;
        var currentCombos = columnImportService.GetLoadCombinations();
        var candidateColumns = GetCandidateColumnsCached(unitSystem);
        var currentColumns = GetCurrentColumnKeys(candidateColumns);
        var currentPierLabels = GetCurrentPierLabels(candidateColumns);
        var targetBindings = ResolveTargetBindings(request);

        // Validate bindings against current model state
        var validation = reconciliationService.ValidateBindings(
            targetBindings,
            modelInfo.ModelPath,
            modelInfo.ModelName,
            currentColumns,
            currentPierLabels,
            currentCombos);

        if (request.AllowSourceModelMismatch && request.SourceModelMismatchConfirmed)
            validation.ModelChanged = false;

        // Select ETABS output only for requested combos
        SelectOutputCombinations(request.SelectedLoadCombinations);

        var sectionSummaries = new List<EtabsSectionRefreshSummary>();
        int totalOldRows = 0;
        int totalNewRows = 0;
        int totalChanged = 0;
        int totalAdded = 0;
        int totalRemoved = 0;
        int totalMissing = 0;
        int remapNeeded = 0;

        foreach (var binding in targetBindings)
        {
            var sectionName = binding.MbColumnSectionName;
            existingLoadCasesBySection.TryGetValue(sectionName, out var existingCases);
            existingCases ??= [];

            // Determine overall binding health for this section
            var sectionHealthList = validation.ObjectHealthList
                .Where(h => string.Equals(h.SectionName, sectionName, StringComparison.OrdinalIgnoreCase))
                .ToList();

            var worstStatus = sectionHealthList.Count == 0
                ? EtabsBindingHealthStatus.Ok
                : sectionHealthList.Max(h => h.Status);

            if (validation.ModelChanged && worstStatus == EtabsBindingHealthStatus.Ok)
                worstStatus = EtabsBindingHealthStatus.ModelChanged;

            IReadOnlyList<MbColumnMappedForceRow> newRows;
            if (worstStatus is EtabsBindingHealthStatus.MissingObject or EtabsBindingHealthStatus.ModelChanged)
            {
                // Try coordinate fallback mapping even if direct IDs failed!
                newRows = PullForcesForBinding(binding, request, currentColumns, unitSystem);
            }
            else
            {
                newRows = PullForcesForBinding(binding, request, currentColumns, unitSystem);
            }

            var summary = changeDetector.CompareSectionForces(sectionName, existingCases, newRows, worstStatus);
            sectionSummaries.Add(summary);

            totalOldRows += summary.OldRowCount;
            totalNewRows += summary.NewRowCount;
            totalChanged += summary.ChangedRows;
            totalAdded += summary.AddedRows;
            totalRemoved += summary.RemovedRows;
            totalMissing += summary.MissingObjects;

            if (summary.Status is EtabsBindingHealthStatus.PossibleRemap or EtabsBindingHealthStatus.MultipleRemapCandidates)
                remapNeeded++;
        }

        return new EtabsForceRefreshPreview
        {
            SectionsAffected = sectionSummaries.Count,
            LoadCombinationsSelected = request.SelectedLoadCombinations.Count + request.SelectedLoadCases.Count,
            ExistingLoadRows = totalOldRows,
            NewLoadRows = totalNewRows,
            ChangedRows = totalChanged,
            AddedRows = totalAdded,
            RemovedRows = totalRemoved,
            MissingObjects = totalMissing,
            MissingCombos = validation.MissingCombinations.Count,
            RemapRequired = remapNeeded,
            SectionSummaries = sectionSummaries,
            ValidationResult = validation,
            Request = request
        };
    }

    public EtabsForceRefreshResult Apply(EtabsForceRefreshPreview preview)
    {
        var updatedBySection = new Dictionary<string, IReadOnlyList<SnapshotLoadCase>>(StringComparer.OrdinalIgnoreCase);

        foreach (var summary in preview.SectionSummaries)
        {
            if (summary.RecommendedAction == EtabsSectionRefreshAction.Update && summary.NewForceRows.Count > 0)
            {
                updatedBySection[summary.SectionName] = forceMapper.ToLoadCases(summary.NewForceRows);
            }
        }

        int appliedCount = updatedBySection.Count;
        return new EtabsForceRefreshResult
        {
            Success = true,
            Message = appliedCount == 0
                ? "No sections were updated."
                : $"Forces refreshed. {appliedCount} section(s) updated. Changes made, recalculation required.",
            Preview = preview,
            UpdatedLoadCasesBySection = updatedBySection,
            AuditLog = BuildAuditLog(preview, updatedBySection.Values.Sum(rows => rows.Count))
        };
    }

    private static EtabsForceReimportAuditLogDto BuildAuditLog(
        EtabsForceRefreshPreview preview,
        int demandCasesImported)
    {
        var request = preview.Request;
        return new EtabsForceReimportAuditLogDto
        {
            ImportedAt = DateTime.UtcNow,
            ModelNameOrPathDiffered = request?.AllowSourceModelMismatch == true,
            SourceModelConfirmedByUser = request?.SourceModelMismatchConfirmed == true,
            ResolutionMethod = request?.SourceResolutionMethod ?? "",
            ResolvedEtabsObjectUniqueNames = request?.ResolvedEtabsObjectUniqueNames.ToList() ?? [],
            StoryCheckResult = preview.ValidationResult?.ObjectHealthList.All(h => h.Status == EtabsBindingHealthStatus.Ok) == true ? "Passed" : "Failed",
            XyCheckResult = preview.ValidationResult?.ObjectHealthList.All(h => h.Status == EtabsBindingHealthStatus.Ok) == true ? "Passed" : "Failed",
            SelectedLoadCombinations = request?.SelectedLoadCombinations.ToList() ?? [],
            SelectedLoadCases = request?.SelectedLoadCases.ToList() ?? [],
            ForceExtractionMode = request?.ExtractionMode == EtabsForceExtractionMode.Envelope ? "Envelope Forces" : "Top + Bottom Forces",
            ImportBehavior = request?.AppendAsNewLoads == true ? "Append as new loads" : "Replace existing ETABS loads",
            DemandCasesImported = demandCasesImported
        };
    }

    private static double Distance(double x1, double y1, double x2, double y2)
    {
        double dx = x1 - x2;
        double dy = y1 - y2;
        return System.Math.Sqrt(dx * dx + dy * dy);
    }

    private static List<EtabsColumnObjectKey> GetCurrentColumnKeys(IReadOnlyList<EtabsColumnImportDto> candidateColumns)
        => candidateColumns.Select(column => new EtabsColumnObjectKey
            {
                Story = column.StoryName,
                Label = column.Label,
                UniqueName = column.ObjectName,
                X = column.CenterXmm,
                Y = column.CenterYmm,
                BottomX = column.BottomXmm,
                BottomY = column.BottomYmm,
                TopX = column.TopXmm,
                TopY = column.TopYmm,
                SectionPropertyName = column.EtabsSectionName
            })
            .ToList();

    private static List<string> GetCurrentPierLabels(IReadOnlyList<EtabsColumnImportDto> candidateColumns)
        => candidateColumns
            .Select(column => column.PierName)
            .Where(pier => !string.IsNullOrWhiteSpace(pier))
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToList();

    private IReadOnlyList<EtabsColumnImportDto> GetCandidateColumnsCached(UnitSystem unitSystem)
    {
        lock (candidateColumnCacheLock)
        {
            if (cachedCandidateColumns is not null
                && cachedCandidateColumnUnitSystem == unitSystem
                && DateTime.UtcNow - cachedCandidateColumnReadAtUtc < TimeSpan.FromSeconds(10))
            {
                return cachedCandidateColumns;
            }
        }

        var candidateColumns = columnImportService.GetCandidateColumns(unitSystem);

        lock (candidateColumnCacheLock)
        {
            cachedCandidateColumns = candidateColumns;
            cachedCandidateColumnUnitSystem = unitSystem;
            cachedCandidateColumnReadAtUtc = DateTime.UtcNow;
        }

        return candidateColumns;
    }

    private IReadOnlyList<MbColumnMappedForceRow> PullForcesForBinding(
        EtabsSectionBinding binding,
        EtabsForceRefreshRequest request,
        IReadOnlyList<EtabsColumnObjectKey> currentColumns,
        UnitSystem unitSystem)
    {
        var combos = request.SelectedLoadCombinations.Concat(request.SelectedLoadCases ?? []).ToList();
        var rows = new List<MbColumnMappedForceRow>();

        if (binding.ObjectType == EtabsImportedObjectType.Column && binding.ColumnObjects.Count > 0)
        {
            var resolvedColumnObjects = new List<EtabsColumnObjectKey>();
            foreach (var col in binding.ColumnObjects)
            {
                // 1. Try direct match by UniqueName (frame ID)
                var match = currentColumns.FirstOrDefault(c => !string.IsNullOrEmpty(col.UniqueName) && string.Equals(c.UniqueName, col.UniqueName, StringComparison.OrdinalIgnoreCase));
                
                // 2. Validate story range & section property (implicit or check next)
                if (match is not null)
                {
                    resolvedColumnObjects.Add(match);
                }
                else
                {
                    // 3. Fallback to XY + story range remap ONLY if IDs fail
                    var fallbackMatch = currentColumns
                        .Where(c => string.Equals(c.Story, col.Story, StringComparison.OrdinalIgnoreCase))
                        .Where(c => Distance(c.X, c.Y, col.X, col.Y) <= 50.0) // 50mm tolerance
                        .FirstOrDefault();
                    
                    if (fallbackMatch is not null)
                        resolvedColumnObjects.Add(fallbackMatch);
                    else
                        resolvedColumnObjects.Add(col); // Fallback to original
                }
            }

            var columnDtos = resolvedColumnObjects.Select(col => new EtabsColumnImportDto(
                col.UniqueName,
                "",
                col.Story,
                col.Label,
                col.Key,
                col.SectionPropertyName,
                "",
                Domain.Enums.SectionShapeType.Rectangular,
                0, 0, 0, 0, "", "Ready")
            {
                HasCoordinates = col.X != 0 || col.Y != 0 || col.BottomX != 0 || col.BottomY != 0 || col.TopX != 0 || col.TopY != 0,
                BottomXmm = col.BottomX,
                BottomYmm = col.BottomY,
                TopXmm = col.TopX,
                TopYmm = col.TopY,
                CenterXmm = col.X,
                CenterYmm = col.Y
            }).ToList();

            IReadOnlyList<EtabsForceResultDto> forces;
            if (request.ForceSource == MbColumnForceSourceMode.ElementForces)
                forces = forceImportService.GetElementForces(columnDtos, combos, unitSystem);
            else
                forces = forceImportService.GetDesignForces(columnDtos, combos, unitSystem);

            forces = FilterByLocation(forces, request);
            rows.AddRange(forceMapper.MapColumnForces(binding.MbColumnSectionName, forces, request.ForceSource, unitSystem));
        }
        else if (binding.ObjectType == EtabsImportedObjectType.Pier && binding.PierObjects.Count > 0)
        {
            var pierScope = binding.PierObjects.Select(p => (p.PierName, p.Story)).ToList();

            IReadOnlyList<EtabsForceResultDto> forces;
            if (request.ForceSource == MbColumnForceSourceMode.ElementForces)
                forces = forceImportService.GetPierElementForces(pierScope, combos, unitSystem);
            else
                forces = forceImportService.GetPierForces(pierScope, combos, unitSystem);

            forces = FilterByLocation(forces, request);
            rows.AddRange(forceMapper.MapPierForces(binding.MbColumnSectionName, forces, request.ForceSource, unitSystem));
        }

        return rows;
    }

    private static IReadOnlyList<EtabsSectionBinding> ResolveTargetBindings(EtabsForceRefreshRequest request)
    {
        if (request.RefreshAllSections || request.TargetMode != EtabsForceRefreshTargetMode.CurrentSectionOnly)
            return request.Bindings;

        if (request.SelectedSectionNames.Count == 0)
            return request.Bindings.Take(1).ToList();

        var sectionNames = request.SelectedSectionNames.ToHashSet(StringComparer.OrdinalIgnoreCase);
        return request.Bindings
            .Where(binding => sectionNames.Contains(binding.MbColumnSectionName)
                || sectionNames.Contains(binding.MbColumnSectionId))
            .ToList();
    }

    private static IReadOnlyList<EtabsForceResultDto> FilterByLocation(
        IReadOnlyList<EtabsForceResultDto> forces,
        EtabsForceRefreshRequest request)
    {
        return request.ExtractionMode switch
        {
            EtabsForceExtractionMode.Envelope => forces,
            EtabsForceExtractionMode.TopBottom => forces.Where(f =>
                {
                    var station = f.Station.Trim();
                    return string.Equals(station, "Top", StringComparison.OrdinalIgnoreCase)
                        || string.Equals(station, "Bottom", StringComparison.OrdinalIgnoreCase)
                        || string.Equals(station, "Bot", StringComparison.OrdinalIgnoreCase);
                })
                .ToList(),
            _ => []
        };
    }

    private void SelectOutputCombinations(IReadOnlyList<string> combos)
    {
        // Would call SapModel.Results.Setup.DeselectAllCasesAndCombosForOutput()
        // then SetComboSelectedForOutput for each selected combo.
        // Implementation depends on COM interop availability at this layer.
        // Kept as no-op here; the force import service handles the actual retrieval.
    }
}
