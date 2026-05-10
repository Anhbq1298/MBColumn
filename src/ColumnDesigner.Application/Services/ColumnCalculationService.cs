using ColumnDesigner.Application.DTOs;
using ColumnDesigner.Domain.Entities;
using ColumnDesigner.Domain.Enums;
using ColumnDesigner.Domain.Interfaces;

namespace ColumnDesigner.Application.Services;

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
        var solver = solverFactory.Get(input.DesignCode);

        double widthMm = units.LengthToMm(input.Width, input.LengthUnit);
        double heightMm = units.LengthToMm(input.Height, input.LengthUnit);
        double coverMm = units.LengthToMm(input.Cover, input.LengthUnit);
        double fcMpa = units.StressToMpa(input.Fc, input.StressUnit);
        double fyMpa = units.StressToMpa(input.Fy, input.StressUnit);
        double esMpa = units.StressToMpa(input.Es, input.StressUnit);

        var coordinateList = input.RebarCoordinates ?? rebarCoordinates.Build(CreateLayoutInput(input), input.Width, input.Height, input.LengthUnit, input.UnitSystem);
        var bars = coordinateList
            .Select(b => new Rebar(b.BarSizeLabel, b.Diameter, b.Area, b.X, b.Y))
            .ToList();
        var layout = new RebarLayout(input.RebarLayoutPreset, input.BarSize, coverMm, bars);
        var section = new RectangularSection(widthMm, heightMm, layout);
        var surface = solver.Solve(section, new ConcreteMaterial($"fc {fcMpa:F1}", fcMpa), new SteelMaterial($"fy {fyMpa:F1}", fyMpa, esMpa));

        // Determine active load cases: use LoadCases list when provided; fall back to single (Pu, Mux, Muy)
        var activeCases = (input.LoadCases?.Where(lc => lc.IsActive).ToList()) ?? [];
        if (activeCases.Count == 0)
        {
            activeCases = [new LoadCaseDto("default", "LC1", input.Pu, input.Mux, input.Muy, true, input.ForceUnit, input.MomentUnit)];
        }

        // Check every load case against the surface
        var caseResults = new List<(LoadCaseDto Case, LoadDemand Demand, RatioResult Ratio)>();
        foreach (var lc in activeCases)
        {
            var lcDemand = new LoadDemand(
                units.ForceToN(lc.Pu, lc.ForceUnit),
                units.MomentToNmm(lc.Mux, lc.MomentUnit),
                units.MomentToNmm(lc.Muy, lc.MomentUnit));
            var lcRatio = ratioCheck.Check(surface, lcDemand);
            caseResults.Add((lc, lcDemand, lcRatio));
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
                govPt.NeutralAxisDepthMm);
        }).ToList();

        var cpTable = ControlPointTableBuilderService.Build(surface, section, fyMpa, esMpa, input.UnitSystem, units, codeService);

        return new CalculationResultDto(
            input.UnitSystem,
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
            diagramData.BuildPmXDiagramData(pointSet, input.UnitSystem),
            diagramData.BuildPmYDiagramData(pointSet, input.UnitSystem),
            diagramData.BuildMxMyDiagramData(pointSet, input.UnitSystem),
            diagramData.BuildPm(pointSet, input.UnitSystem),
            diagramData.BuildMm(pointSet, input.UnitSystem),
            diagramData.BuildSurface(pointSet.PmmSurfacePoints, input.UnitSystem),
            diagramData.BuildMmSliceRenderData(pointSet.MmSlicePoints, input.UnitSystem),
            surface,
            pointSet)
        {
            LoadCaseResults = lcResultDtos,
            GoverningLoadCaseId = govLc.Id,
            ControlPointTable = cpTable,
            SectionWidthMm = widthMm,
            SectionHeightMm = heightMm,
            CoverMm = coverMm,
            RebarCoordinates = coordinateList
        };
    }

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
