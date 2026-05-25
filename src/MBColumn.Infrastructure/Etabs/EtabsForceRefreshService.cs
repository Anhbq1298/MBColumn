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
        var currentColumns = forceImportService.GetForces([], [], unitSystem);

        // Validate bindings against current model state
        var validation = reconciliationService.ValidateBindings(
            request.Bindings,
            modelInfo.ModelPath,
            modelInfo.ModelName,
            [],
            [],
            [],
            currentCombos);

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

        foreach (var binding in request.Bindings)
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
                newRows = [];
            }
            else
            {
                newRows = PullForcesForBinding(binding, request, unitSystem);
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
            LoadCombinationsSelected = request.SelectedLoadCombinations.Count,
            ExistingLoadRows = totalOldRows,
            NewLoadRows = totalNewRows,
            ChangedRows = totalChanged,
            AddedRows = totalAdded,
            RemovedRows = totalRemoved,
            MissingObjects = totalMissing,
            MissingCombos = validation.MissingCombinations.Count,
            RemapRequired = remapNeeded,
            SectionSummaries = sectionSummaries,
            ValidationResult = validation
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
                : $"Forces refreshed. {appliedCount} section(s) updated.",
            Preview = preview,
            UpdatedLoadCasesBySection = updatedBySection
        };
    }

    private IReadOnlyList<MbColumnMappedForceRow> PullForcesForBinding(
        EtabsSectionBinding binding,
        EtabsForceRefreshRequest request,
        UnitSystem unitSystem)
    {
        var combos = request.SelectedLoadCombinations;
        var rows = new List<MbColumnMappedForceRow>();

        if (binding.ObjectType == EtabsImportedObjectType.Column && binding.ColumnObjects.Count > 0)
        {
            var columnDtos = binding.ColumnObjects.Select(col => new EtabsColumnImportDto(
                col.Key, "", col.Story, col.Label, col.Key, col.Label,
                "", Domain.Enums.SectionShapeType.Rectangular, 0, 0, 0, 0, "", "Ready")).ToList();

            IReadOnlyList<EtabsForceResultDto> forces;
            if (request.ForceSource == MbColumnForceSourceMode.ElementForces)
                forces = forceImportService.GetElementForces(columnDtos, combos, unitSystem);
            else
                forces = forceImportService.GetForces(columnDtos, combos, unitSystem);

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

    private static IReadOnlyList<EtabsForceResultDto> FilterByLocation(
        IReadOnlyList<EtabsForceResultDto> forces,
        EtabsForceRefreshRequest request)
    {
        if (request.ImportTop && request.ImportBottom)
            return forces;

        return forces.Where(f =>
        {
            var station = f.Station.Trim();
            if (request.ImportTop && (station.Equals("Top", StringComparison.OrdinalIgnoreCase))) return true;
            if (request.ImportBottom && (station.Equals("Bottom", StringComparison.OrdinalIgnoreCase) || station.Equals("Bot", StringComparison.OrdinalIgnoreCase))) return true;
            return false;
        }).ToList();
    }

    private void SelectOutputCombinations(IReadOnlyList<string> combos)
    {
        // Would call SapModel.Results.Setup.DeselectAllCasesAndCombosForOutput()
        // then SetComboSelectedForOutput for each selected combo.
        // Implementation depends on COM interop availability at this layer.
        // Kept as no-op here; the force import service handles the actual retrieval.
    }
}
