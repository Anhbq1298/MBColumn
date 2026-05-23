using MBColumn.Application.DTOs;
using MBColumn.Application.Mappers;
using MBColumn.Domain.Entities;
using MBColumn.Domain.Enums;
using MBColumn.Domain.Interfaces;

namespace MBColumn.Application.Services;

public sealed class ColumnCalculationService(
    IInteractionSolverFactory solverFactory,
    IDesignCodeServiceFactory codeFactory,
    IUnitConversionService units,
    IRatioCheckService ratioCheck,
    IControlPointBuilder controlPoints,
    DiagramDataService diagramData,
    InputValidationService validation,
    IRebarCoordinateBuilderService rebarCoordinates)
{
    public ColumnCalculationService(
        IInteractionSolverFactory solverFactory,
        IDesignCodeServiceFactory codeFactory,
        IUnitConversionService units,
        IRebarDatabase metricBars,
        IRebarDatabase imperialBars,
        IRatioCheckService ratioCheck,
        IControlPointBuilder controlPoints,
        DiagramDataService diagramData,
        InputValidationService validation)
        : this(
            solverFactory,
            codeFactory,
            units,
            ratioCheck,
            controlPoints,
            diagramData,
            validation,
            new RebarCoordinateBuilderService(units, metricBars, imperialBars))
    {
    }

    public CalculationResultDto Calculate(ColumnInputDto input)
    {
        var validationResult = validation.Validate(input);
        if (!validationResult.IsValid)
        {
            throw new InvalidOperationException(string.Join(Environment.NewLine, validationResult.Errors));
        }

        var codeService = codeFactory.Get(input.DesignCode);
        codeService.AlphaCc = input.AlphaCc;

        double coverMm = units.LengthToMm(input.Cover, input.LengthUnit);
        double fcMpa = units.StressToMpa(input.Fc, input.StressUnit);
        double fyMpa = units.StressToMpa(input.Fy, input.StressUnit);
        double esMpa = units.StressToMpa(input.Es, input.StressUnit);
        var concrete = new ConcreteMaterial($"fc {fcMpa:F1}", fcMpa);
        var steel = new SteelMaterial($"fy {fyMpa:F1}", fyMpa, esMpa);

        ColumnSection section;
        InteractionSurface surface;

        if (input.SectionShape == SectionShapeType.Irregular)
        {
            if (input.Irregular is null)
            {
                throw new InvalidOperationException("Irregular section requires an Irregular block.");
            }

            var mapper = new IrregularSectionMapper(new IrregularSectionValidationService());
            var mapResult = mapper.ValidateAndMap(input.Irregular, out var irregular, out var rebarCoords);
            if (!mapResult.IsValid || irregular is null)
            {
                var msg = string.Join(Environment.NewLine,
                    mapResult.Issues.Select(i => i.Message));
                throw new InvalidOperationException(msg);
            }

            // Irregular section currently only supports polygon integration.
            var irregularSolver = solverFactory.GetIrregular(input.DesignCode, SectionIntegrationMethod.Polygon);
            section = irregular;
            surface = irregularSolver.Solve(irregular, concrete, steel);
            // Use centroid-shifted coordinates from the solver layout so that the inset
            // figure renders rebars consistently with the centroid-based boundary polygon.
            var rebarDtoList = irregular.Layout.Bars
                .Select((b, i) => new RebarCoordinateDto(
                    (i + 1).ToString(),
                    b.XMm,
                    b.YMm,
                    b.DiameterMm,
                    b.AreaMm2,
                    b.Name,
                    "Irregular"))
                .ToList();
            var irregularBoundary = irregular.BoundaryPoints
                .Select(p => new InsetPointDto(p.X, p.Y))
                .ToList();
            double widthMm = irregular.BoundingBoxMm.Width;
            double heightMm = irregular.BoundingBoxMm.Height;
            return BuildResult(input, section, surface, rebarDtoList, widthMm, heightMm, fcMpa, fyMpa, esMpa, codeService)
                with { IrregularSectionBoundaryPoints = irregularBoundary };
        }
        else if (input.SectionShape == SectionShapeType.Circular)
        {
            double diameterMm = units.LengthToMm(input.Diameter, input.LengthUnit);
            var coordinateList = input.RebarCoordinates
                ?? rebarCoordinates.BuildCircular(input.Diameter, input.Cover, input.BarCount, input.BarSize, input.LengthUnit, input.UnitSystem);
            var bars = coordinateList.Select(b => new Rebar(b.BarSizeLabel, b.Diameter, b.Area, b.X, b.Y)).ToList();
            var layout = new RebarLayout(input.RebarLayoutPreset, input.BarSize, coverMm, bars);
            section = new CircularSection(diameterMm, layout);
            var circularSolver = solverFactory.GetCircular(input.DesignCode, input.IntegrationMethod);
            surface = circularSolver.Solve((CircularSection)section, concrete, steel);

            return BuildResult(input, section, surface, coordinateList, diameterMm, diameterMm, fcMpa, fyMpa, esMpa, codeService);
        }
        else
        {
            double widthMm = units.LengthToMm(input.Width, input.LengthUnit);
            double heightMm = units.LengthToMm(input.Height, input.LengthUnit);
            var coordinateList = input.RebarCoordinates
                ?? rebarCoordinates.Build(CreateLayoutInput(input), input.Width, input.Height, input.LengthUnit, input.UnitSystem);
            var bars = coordinateList.Select(b => new Rebar(b.BarSizeLabel, b.Diameter, b.Area, b.X, b.Y)).ToList();
            var layout = new RebarLayout(input.RebarLayoutPreset, input.BarSize, coverMm, bars);
            section = new RectangularSection(widthMm, heightMm, layout);
            var solver = solverFactory.Get(input.DesignCode, input.Ec2Solver, input.IntegrationMethod);
            surface = solver.Solve((RectangularSection)section, concrete, steel);

            return BuildResult(input, section, surface, coordinateList, widthMm, heightMm, fcMpa, fyMpa, esMpa, codeService);
        }
    }

    private CalculationResultDto BuildResult(
        ColumnInputDto input,
        ColumnSection section,
        InteractionSurface surface,
        IReadOnlyList<RebarCoordinateDto> coordinateList,
        double sectionWidthMm,
        double sectionHeightMm,
        double fcMpa,
        double fyMpa,
        double esMpa,
        IDesignCodeService codeService)
    {
        // Determine active load cases: use LoadCases list when provided; fall back to single (Pu, Mux, Muy)
        var activeCases = (input.LoadCases?.Where(lc => lc.IsActive).ToList()) ?? [];
        if (activeCases.Count == 0)
        {
            activeCases = [new LoadCaseDto("default", "LC1", input.Pu, input.Mux, input.Muy, true, input.ForceUnit, input.MomentUnit)];
        }

        // Check every load case against the surface using batch processing
        var demands = activeCases.Select(lc => new LoadDemand(
            units.ForceToN(lc.Pu, lc.ForceUnit),
            units.MomentToNmm(lc.Mux, lc.MomentUnit),
            units.MomentToNmm(lc.Muy, lc.MomentUnit))).ToList();

        var batchRatios = ratioCheck.CheckBatch(surface, demands);

        var caseResults = new List<(LoadCaseDto Case, LoadDemand Demand, RatioResult Ratio)>(activeCases.Count);
        for (int i = 0; i < activeCases.Count; i++)
        {
            caseResults.Add((activeCases[i], demands[i], batchRatios[i]));
        }

        // Governing = highest demand/capacity ratio
        var governing = caseResults.MaxBy(r => r.Ratio.Ratio);
        var govDemand = governing.Demand;
        var govRatio = governing.Ratio;
        var govLc = governing.Case;

        double selectedAxial = units.ForceToN(input.SelectedAxialLoad, input.ForceUnit);
        var pointSet = controlPoints.Build(surface, govDemand, input.SelectedPmAngleDegrees, selectedAxial, input.UnitSystem, govRatio, codeService);
        var govPoint = govRatio.GoverningPoint ?? surface.Points.OrderByDescending(p => p.PhiPn).First();

        // Build per-case result DTOs
        var lcResultDtos = caseResults.Select(r =>
        {
            var govPt = r.Ratio.GoverningPoint ?? surface.Points.OrderByDescending(p => p.PhiPn).First();
            return new LoadCaseResultDto(
                r.Case.Id,
                r.Case.Name,
                units.ForceFromN(r.Demand.PuN, input.ForceUnit),
                units.MomentFromNmm(r.Demand.MuxNmm, input.MomentUnit),
                units.MomentFromNmm(r.Demand.MuyNmm, input.MomentUnit),
                r.Ratio.Ratio,
                r.Ratio.Status,
                govPt.Phi,
                govPt.ThetaDegrees,
                govPt.NeutralAxisDepthMm)
            {
                CapacityPDisplay = units.ForceFromN(r.Ratio.CapacityPn, input.ForceUnit),
                CapacityMxDisplay = units.MomentFromNmm(r.Ratio.CapacityMnx, input.MomentUnit),
                CapacityMyDisplay = units.MomentFromNmm(r.Ratio.CapacityMny, input.MomentUnit)
            };
        }).ToList();

        var specialEntries = SpecialCapacityPointsService.Build(surface, section, fyMpa, esMpa, fcMpa, codeService);
        var specialControlPoints = specialEntries.Select(e => SpecialEntryToControlPoint(e, input.UnitSystem)).ToList();
        pointSet = pointSet with { SpecialCapacityPoints = specialControlPoints };

        var pmmSurface = diagramData.BuildSurface(pointSet.PmmSurfacePoints, input.UnitSystem);
        var special3dDtos = specialControlPoints
            .Select(cp => new ControlPointDto(
                DiagramType.Pm3D, cp.DisplayMx, cp.DisplayMy, cp.DisplayP,
                cp.DisplayP, cp.DisplayMx, cp.DisplayMy, cp.Phi,
                cp.ThetaDegrees, cp.NeutralAxisDepth, cp.Label, cp.GroupKey,
                false, false, false, false, 0, "special")
            { IsSpecialPoint = true })
            .ToList();
        pmmSurface = pmmSurface with { SpecialCapacityPoints = special3dDtos };

        var cpTable = ControlPointTableBuilderService.Build(surface, section, fyMpa, esMpa, fcMpa, input.UnitSystem, units, codeService);
        var debugPoints = BuildCapacityDebugPoints(surface, govPoint, input);

        return new CalculationResultDto(
            input.UnitSystem,
            input.DesignCode,
            govRatio.Ratio,
            govRatio.Status,
            units.ForceFromN(govDemand.PuN, input.ForceUnit),
            units.MomentFromNmm(govDemand.MuxNmm, input.MomentUnit),
            units.MomentFromNmm(govDemand.MuyNmm, input.MomentUnit),
            govPoint.Phi,
            govPoint.ThetaDegrees,
            govPoint.NeutralAxisDepthMm,
            units.ForceFromN(govPoint.Pn, input.ForceUnit),
            units.ForceFromN(govPoint.PhiPn, input.ForceUnit),
            units.MomentFromNmm(govPoint.Mnx, input.MomentUnit),
            units.MomentFromNmm(govPoint.Mny, input.MomentUnit),
            units.MomentFromNmm(govPoint.PhiMnx, input.MomentUnit),
            units.MomentFromNmm(govPoint.PhiMny, input.MomentUnit),
            diagramData.BuildMxMyDiagramData(pointSet, input.UnitSystem),
            diagramData.BuildMm(pointSet, input.UnitSystem),
            pmmSurface,
            diagramData.BuildMmSliceRenderData(pointSet.MmSlicePoints, input.UnitSystem),
            surface,
            pointSet)
        {
            LoadCaseResults = lcResultDtos,
            GoverningLoadCaseId = govLc.Id,
            ControlPointTable = cpTable,
            SectionShape = section.Shape,
            IntegrationMethod = input.IntegrationMethod,
            SectionWidthMm = sectionWidthMm,
            SectionHeightMm = sectionHeightMm,
            CoverMm = units.LengthToMm(input.Cover, input.LengthUnit),
            RebarCoordinates = coordinateList,
            CapacityDebugPoints = debugPoints,
            HandCalcValidation = ReportHandCalcService.Build(
                section.Shape,
                sectionWidthMm,
                sectionHeightMm,
                fcMpa,
                fyMpa,
                esMpa,
                coordinateList,
                cpTable,
                codeService,
                units,
                input.UnitSystem,
                input.DesignCode)
        };
    }

    private ControlPoint SpecialEntryToControlPoint(SpecialCapacityEntry entry, UnitSystem unitSystem)
    {
        var src = entry.Source;
        var fu = unitSystem == UnitSystem.Metric ? ForceUnit.kN : ForceUnit.Kip;
        var mu = unitSystem == UnitSystem.Metric ? MomentUnit.kNm : MomentUnit.KipFt;
        double displayP = units.ForceFromN(src.PhiPn, fu);
        double displayMx = units.MomentFromNmm(src.PhiMnx, mu);
        double displayMy = units.MomentFromNmm(src.PhiMny, mu);
        double nomP = units.ForceFromN(src.Pn, fu);
        double nomMx = units.MomentFromNmm(src.Mnx, mu);
        double nomMy = units.MomentFromNmm(src.Mny, mu);
        string groupKey = $"SpecialCapacity|{entry.Label.Replace(" ", "")}";
        return new ControlPoint(
            Id: $"Special-{entry.Label}-{entry.AngleIndex}",
            DiagramType: DiagramType.Pm3D,
            Pn: src.Pn,
            Mnx: src.Mnx,
            Mny: src.Mny,
            Phi: src.Phi,
            PhiPn: src.PhiPn,
            PhiMnx: src.PhiMnx,
            PhiMny: src.PhiMny,
            DisplayP: displayP,
            DisplayMx: displayMx,
            DisplayMy: displayMy,
            NominalDisplayP: nomP,
            NominalDisplayMx: nomMx,
            NominalDisplayMy: nomMy,
            ThetaDegrees: entry.ThetaDegrees,
            NeutralAxisDepth: src.NeutralAxisDepthMm,
            IsDemandPoint: false,
            IsGoverningPoint: false,
            IsReferencePoint: false,
            Label: entry.Label,
            SortKey: 0,
            GroupKey: groupKey,
            SliceKey: "special")
        { IsSpecialPoint = true };
    }

    private IReadOnlyList<CapacityDebugPointDto> BuildCapacityDebugPoints(InteractionSurface surface, InteractionPoint governingPoint, ColumnInputDto input)
    {
        var selected = new List<(string Label, InteractionPoint Point)>();

        void Add(string label, InteractionPoint? point)
        {
            if (point is null) return;
            selected.Add((label, point));
        }

        Add("Max nominal compression", surface.Points.MaxBy(p => p.Nominal.Pn));
        Add("Max reduced compression", surface.Points.MaxBy(p => p.Reduced.PhiPn));
        Add("Pure tension", surface.Points.MinBy(p => p.Nominal.Pn));
        Add("Max +Mnx nominal", surface.Points.MaxBy(p => p.Nominal.Mnx));
        Add("Max -Mnx nominal", surface.Points.MinBy(p => p.Nominal.Mnx));
        Add("Max +Mny nominal", surface.Points.MaxBy(p => p.Nominal.Mny));
        Add("Max -Mny nominal", surface.Points.MinBy(p => p.Nominal.Mny));
        Add("Governing", governingPoint);

        return selected.Select(p => ToCapacityDebugPoint(p.Label, p.Point, input)).ToList();
    }

    private CapacityDebugPointDto ToCapacityDebugPoint(string label, InteractionPoint point, ColumnInputDto input)
        => new(
            label,
            point.ThetaDegrees,
            point.NeutralAxisDepthMm,
            point.StrainState.MaxTensionSteelStrain,
            point.Reduced.Phi,
            units.ForceFromN(point.Nominal.Pn, input.ForceUnit),
            units.ForceFromN(point.Reduced.PhiPn, input.ForceUnit),
            units.MomentFromNmm(point.Nominal.Mnx, input.MomentUnit),
            units.MomentFromNmm(point.Reduced.PhiMnx, input.MomentUnit),
            units.MomentFromNmm(point.Nominal.Mny, input.MomentUnit),
            units.MomentFromNmm(point.Reduced.PhiMny, input.MomentUnit),
            units.ForceFromN(point.ConcretePn, input.ForceUnit),
            units.ForceFromN(point.SteelPn, input.ForceUnit),
            point.StrainState.RegionClassification);

    private static RebarLayoutInputDto CreateLayoutInput(ColumnInputDto input)
        => new(
            input.RebarLayoutType,
            input.BarCount,
            input.BarSize,
            input.Cover,
            input.TopRebarSide ?? new RebarSideInputDto(input.BarCount / 4, input.BarSize, input.Cover),
            input.BottomRebarSide ?? new RebarSideInputDto(input.BarCount / 4, input.BarSize, input.Cover),
            input.LeftRebarSide ?? new RebarSideInputDto(input.BarCount / 4, input.BarSize, input.Cover),
            input.RightRebarSide ?? new RebarSideInputDto(input.BarCount / 4, input.BarSize, input.Cover));
}
