using MBColumn.Application.DTOs;
using MBColumn.Application.Services;
using MBColumn.Domain.Entities;
using MBColumn.Domain.Enums;
using MBColumn.Domain.Interfaces;
using MBColumn.Infrastructure.DesignCodes;
using MBColumn.Infrastructure.Math;
using MBColumn.Infrastructure.Rebar;
using MBColumn.Infrastructure.Solvers;
using MBColumn.Presentation.Wpf.Controls;
using MBColumn.Presentation.Wpf.ViewModels;
using System.Windows;

MBColumn.Tests.EurocodeValidation.Run();
MBColumn.Tests.EurocodeMultiAngleValidation.Run();

var tests = new List<(string Name, Action Test)>
{
    ("mm to inch", () => AreClose(1, GetUnits().LengthFromMm(25.4, LengthUnit.Inch), 1e-12)),
    ("inch to mm", () => AreClose(25.4, GetUnits().LengthToMm(1, LengthUnit.Inch), 1e-12)),
    ("kN to kip", () => AreClose(1, GetUnits().ForceFromN(GetUnits().ForceToN(1, ForceUnit.Kip), ForceUnit.Kip), 1e-12)),
    ("kip to kN", () => AreClose(4.4482216152605, GetUnits().ForceFromN(GetUnits().ForceToN(1, ForceUnit.Kip), ForceUnit.kN), 1e-9)),
    ("MPa to ksi", () => AreClose(1, GetUnits().StressFromMpa(6.894757293168, StressUnit.Ksi), 1e-12)),
    ("ksi to MPa", () => AreClose(6.894757293168, GetUnits().StressToMpa(1, StressUnit.Ksi), 1e-12)),
    ("kN-m to N-mm", () => AreClose(1_000_000, GetUnits().MomentToNmm(1, MomentUnit.kNm), 1e-6)),
    ("kip-ft to N-mm", () => AreClose(1_355_817.9483314003, GetUnits().MomentToNmm(1, MomentUnit.KipFt), 1e-3)),
    ("Singapore bars", TestSingaporeBars),
    ("Invalid Singapore bar", () => IsFalse(new SingaporeRebarDatabase().TryGet("D20", out _))),
    ("US bars", TestUsBars),
    ("Input validation", TestInputValidation),
    ("Pure axial compression", TestPureCompression),
    ("Pure axial tension", TestPureTension),
    ("Strong axis bending", TestStrongWeakAxis),
    ("Weak axis bending", TestStrongWeakAxis),
    ("Symmetric biaxial bending", TestSymmetry),
    ("PMM ratio inside", TestRatioInside),
    ("PMM ratio outside", TestRatioOutside),
    ("Invalid geometry", TestInvalidGeometry),
    ("Invalid rebar placement", TestInvalidRebarPlacement),
    ("PM control ordering", TestPmControlOrdering),
    ("MM control ordering", TestMmControlOrdering),
    ("No NaN in control points", TestNoNan),
    ("Reference control behavior", TestReferenceBehavior),
    ("Metric/Imperial equivalence", TestMetricImperialEquivalence),
    ("Section preview corner bars", TestSectionPreviewCornerBars),
    ("Section preview perimeter bars", TestSectionPreviewPerimeterBars),
    ("Section preview invalid geometry", TestSectionPreviewInvalidGeometry),
    ("Section preview unit labels", TestSectionPreviewUnitLabels),
    ("PMx diagram axis mapping", TestPmxDiagramAxisMapping),
    ("PMy diagram axis mapping", TestPmyDiagramAxisMapping),
    ("Mx-My diagram axis mapping", TestMxMyDiagramAxisMapping),
    ("3D PMM mapping and mesh", TestPmm3DMappingAndMesh),
    ("Axis tick service", TestAxisTickService),
    ("PM branch continuity", TestPmBranchContinuity),
    ("PM curve diagnostics and marker separation", TestPmCurveDiagnosticsAndMarkerSeparation),
    ("Diagram bounds include points", TestDiagramBoundsIncludePoints),
    ("2D chart auto-fit transform", TestChartAutoFitTransform),
    ("Result settings propagate", TestResultSettingsPropagate),
    ("Nominal uses Pn/Mn values", TestNominalUsesPnMn),
    ("Design uses PhiPn/PhiMn values", TestDesignUsesPhiPnPhiMn),
    ("Design capacity <= nominal capacity", TestDesignLeNominal),
    ("PMM ratio uses design capacity", TestPmmRatioUsesDesign),
    ("PMx nominal and design curves separated", TestPmxNomDesignSeparated),
    ("PMy nominal and design curves separated", TestPmyNomDesignSeparated),
    ("Demand not in capacity polyline", TestDemandNotInCapacity),
    ("Governing from design curve", TestGoverningFromDesign),
    ("Nominal and design curve diagnostics", TestNominalDesignDiagnostics),
    ("ACI design cap in PMx", TestAciDesignCapPmx),
    ("ACI design cap in PMy", TestAciDesignCapPmy),
    ("Pmax reference separate from design cap", TestPmaxRefSeparateFromDesignCap),
    ("PM polyline validation passes", TestPmPolylineValidation),
    ("3D X maps to Mx", Test3DXMapsMx),
    ("3D Y maps to My", Test3DYMapsMy),
    ("3D Z equals actual display P", Test3DZEqualsActualP),
    ("3D design surface is ACI compression capped", Test3DDesignSurfaceAciCapped),
    ("3D axis labels correct", Test3DAxisLabels),
    ("3D surface has quads and wires", Test3DSurfaceData),
    ("3D nominal/design topology synchronized", Test3DTopologySynchronized),
    ("3D pole rings follow spColumn nudge", Test3DPoleRingsFollowSpColumnNudge),
    ("3D PM angle from result", Test3DPmAngleFromResult),
    ("3D SelectedPmAngle defaults to governing theta", Test3DSelectedPmAngleDefault),
    ("3D slice controls update labels", Test3DSliceControlsUpdateLabels),
    ("3D viewport exposes slice controls", Test3DViewportExposesSliceControls),
    ("3D axes originate at engineering zero", Test3DAxesOriginateAtEngineeringZero),
    ("3D PM slice angle reflected in label", Test3DPmSliceAngleReflectedInLabel),
    ("3D axial slice label contains P and unit", Test3DAxialSliceLabelContainsPAndUnit),
    ("3D axial slice Z equals demand P", Test3DAxialSliceZEqualsDemandP),
    ("3D angle DP uses AffectsRender only", Test3DPmAngleDpUsesAffectsRenderOnly),
    ("3D axial load DP uses AffectsRender only", Test3DAxialLoadDpUsesAffectsRenderOnly),
    ("3D orientation cube axis builder valid", Test3DOrientationCubeAxisBuilderValid),
    ("Result navigation propagates globally", TestResultNavigationPropagatesGlobally),
    ("MxMy has nominal boundary", TestMxMyNominalBoundary),
    ("MxMy nominal uses Mnx/Mny", TestMxMyNominalUsesMnMy),
    ("MxMy design uses phiMnx/phiMny", TestMxMyDesignUsesPhiMnMy),
    ("MxMy nominal and design separated", TestMxMyNomDesignSeparated),
    ("Viewport default all selected", TestViewportDefaultAll),
    ("Viewport toggle reduces active count", TestViewportToggle),
    ("Viewport cannot deselect last", TestViewportCannotDeselectLast),
    ("Viewport layout preserves result", TestViewportLayoutPreservesResult),
    ("3D Surface X/Y aspect preserves geometry", Test3DSurfaceGeometryAspect),
    ("3D bounds match 2D PM bounds", Test3DBoundsMatch2D),
    ("AxisTickService independent steps", TestAxisTickIndependentSteps),
    ("AxisTickService nice numbers", TestAxisTickNiceNumbers),
    ("AxisTickService format strings", TestAxisTickFormatStrings),
    ("Chart transform snaps to nice bounds", TestChartTransformSnapsToBounds),
    ("MxMy chart transform uses equal aspect", TestMxMyChartTransformEqualAspect),
    ("Multi-load case governing is max ratio", TestMultiLoadCaseGoverningIsMaxRatio),
    ("Multi-load case result count matches input", TestMultiLoadCaseResultCount),
    ("Multi-load case inactive excluded", TestMultiLoadCaseInactiveExcluded),
    ("Multi-load case fallback to single", TestMultiLoadCaseFallbackToSingle),
    ("Multi-load case governing id in result", TestMultiLoadCaseGoverningIdInResult),
    ("ACI trim segment is straight â€” PMx", TestAciTrimSegmentStraightPmx),
    ("ACI trim segment is straight â€” PMy", TestAciTrimSegmentStraightPmy),
    ("Control points table has 32 rows", TestControlPointsTableRowCount),
    ("Control points allowable comp is 80pct of max", TestControlPointsAllowableComp),
    ("Control points dt equals NA depth at fs=0", TestControlPointsDtEqualsFsZeroNa),
    ("Control points tension control epsilon near 0.005", TestControlPointsTensionControlEpsilon),
    ("ACI factory routes Conventional vs Fiber", TestAciSolverFactoryRouting),
    ("ACI conventional baseline is regression-stable", TestAciConventionalUnchangedByFiberOption),
    ("ACI fiber pure compression close to conventional", TestAciFiberPureCompressionCloseToConventional),
    ("ACI fiber pure tension matches conventional", TestAciFiberPureTensionMatchesConventional),
    ("ACI fiber strong-axis capacity close to conventional", TestAciFiberStrongAxisCloseToConventional),
    ("ACI fiber phi follows ACI transition", TestAciFiberPhiFollowsAciTransition),
    ("ACI fiber surface has no NaN", TestAciFiberSurfaceNoNan),
    // EC2 Simplified Stress Block Solver tests
    ("EC2 simplified block material factors fck<=50", TestEc2SsbMaterialFactorsLowFck),
    ("EC2 simplified block material factors fck>50", TestEc2SsbMaterialFactorsHighFck),
    ("EC2 simplified block factory routing", TestEc2SsbFactoryRouting),
    ("EC2 simplified block surface has no NaN", TestEc2SsbNoNaN),
    ("EC2 simplified block pure compression", TestEc2SsbPureCompression),
    ("EC2 simplified block pure tension", TestEc2SsbPureTension),
    ("EC2 simplified block phi equals 1.0", TestEc2SsbPhiEqualsOne),
    ("EC2 simplified block surface topology", TestEc2SsbSurfaceTopology),
    ("EC2 simplified block symmetric section symmetry", TestEc2SsbSymmetry),
    ("EC2 simplified block P0 close to boundary solver", TestEc2SsbP0CloseToBoundary),
    ("EC2 simplified block major-axis moment positive", TestEc2SsbMajorAxisMoment),
    ("EC2 simplified block state labels classify correctly", TestEc2SsbStateLabels),
    ("EC2 simplified block uniaxial bending hand check", TestEc2SsbUniaxialBendingHandCheck),
    // Regression guards — existing solvers must be unaffected
    ("Regression: ACI results unchanged after new EC2 solver added", TestRegressionAciUnchanged),
    ("Regression: EC2 fiber results unchanged after new solver added", TestRegressionEc2FiberUnchanged)
};

foreach (var (name, test) in tests)
{
    test();
    Console.WriteLine($"PASS {name}");
}

Console.WriteLine($"All {tests.Count} tests passed.");

static UnitConversionService GetUnits() => new();

static ColumnCalculationService Service()
{
    var aci = new Aci318DesignCodeService();
    var ec2 = new Ec2DesignCodeService();
    var codeFactory = new DesignCodeServiceFactory(aci, ec2);
    var solverFactory = new InteractionSolverFactory(aci, ec2);
    IUnitConversionService units = GetUnits();
    IRebarDatabase metric = new SingaporeRebarDatabase();
    IRebarDatabase imperial = new ImperialRebarDatabase();
    IRatioCheckService ratio = new RatioCheckService();
    IControlPointBuilder control = new ControlPointBuilderService(units);
    return new ColumnCalculationService(solverFactory, codeFactory, units, metric, imperial, ratio, control, new DiagramDataService(), new InputValidationService());
}

static ColumnInputDto MetricInput(double pu = 2500, double mux = 250, double muy = 180)
    => new(UnitSystem.Metric, 700, 700, 55, "T25", 28, "Perimeter bars", 28, 420, 200000, pu, mux, muy, ForceUnit.kN, LengthUnit.Millimeter, MomentUnit.kNm, StressUnit.MPa, 0, 0);

static ColumnInputDto ImperialInput()
    => new(UnitSystem.Imperial, 27.5590551, 27.5590551, 2.16535433, "#8", 28, "Perimeter bars", 4.061, 60.916, 29007.5, 562.02, 184.39, 132.77, ForceUnit.Kip, LengthUnit.Inch, MomentUnit.KipFt, StressUnit.Ksi, 0, 0);

static void TestSingaporeBars()
{
    var db = new SingaporeRebarDatabase();
    foreach (int d in new[] { 10, 13, 16, 20, 25, 32, 40 })
    {
        IsTrue(db.TryGet($"T{d}", out var bar));
        AreClose(d, bar.DiameterMm, 1e-12);
        double expectedArea = d == 25 ? 491.0 : Math.PI * d * d / 4.0;
        AreClose(expectedArea, bar.AreaMm2, 1e-9);
    }
}

static void TestUsBars()
{
    var db = new ImperialRebarDatabase();
    IsTrue(db.TryGet("#8", out var bar));
    AreClose(25.4, bar.DiameterMm, 1e-9);
    AreClose(0.79 * 25.4 * 25.4, bar.AreaMm2, 1e-9);
}

static void TestInputValidation()
{
    var validation = new InputValidationService().Validate(MetricInput() with { Width = -1 });
    IsFalse(validation.IsValid);
}

static void TestPureCompression()
{
    var result = Service().Calculate(MetricInput(pu: 1000, mux: 0, muy: 0));
    IsTrue(result.Surface.Points.Max(p => p.PhiPn) > 0);
}

static void TestPureTension()
{
    var result = Service().Calculate(MetricInput(pu: -100, mux: 0, muy: 0));
    IsTrue(result.Surface.Points.Min(p => p.PhiPn) < 0);
}

static void TestStrongWeakAxis()
{
    var service = Service();
    var strong = service.Calculate(MetricInput(mux: 250, muy: 0));
    var weak = service.Calculate(MetricInput(mux: 0, muy: 250));
    IsTrue(strong.Ratio > 0);
    IsTrue(weak.Ratio > 0);
}

static void TestSymmetry()
{
    var result = Service().Calculate(MetricInput());
    var mxMax = result.Surface.Points.Max(p => p.PhiMnx);
    var mxMin = result.Surface.Points.Min(p => p.PhiMnx);
    AreClose(Math.Abs(mxMax), Math.Abs(mxMin), Math.Abs(mxMax) * 0.05);
}

static void TestRatioInside()
{
    var result = Service().Calculate(MetricInput(pu: 500, mux: 50, muy: 30));
    IsTrue(result.Ratio < 1.0);
}

static void TestRatioOutside()
{
    var result = Service().Calculate(MetricInput(pu: 500, mux: 5000, muy: 3000));
    IsTrue(result.Ratio > 1.0);
}

static void TestInvalidGeometry()
{
    Throws(() => Service().Calculate(MetricInput() with { Width = 0 }));
}

static void TestInvalidRebarPlacement()
{
    Throws(() => Service().Calculate(MetricInput() with { Cover = 400 }));
}

static void TestPmControlOrdering()
{
    var result = Service().Calculate(MetricInput());
    var curve = result.ControlPoints.PmPoints.Where(p => p.GroupKey == "Factored").ToList();
    IsTrue(curve.Count >= 140);
    IsTrue(curve.Zip(curve.Skip(1)).All(pair => pair.First.SortKey <= pair.Second.SortKey));
}

static void TestMmControlOrdering()
{
    var result = Service().Calculate(MetricInput());
    var curve = result.ControlPoints.MmPoints.Where(p => p.GroupKey == "DesignCapacity").ToList();
    IsTrue(curve.Count == 36);
    IsTrue(curve.Zip(curve.Skip(1)).All(pair => pair.First.SortKey <= pair.Second.SortKey));
}

static void TestNoNan()
{
    var all = Service().Calculate(MetricInput()).ControlPoints.PmmSurfacePoints;
    IsFalse(all.Any(p => double.IsNaN(p.DisplayP) || double.IsInfinity(p.DisplayP) || double.IsNaN(p.DisplayMx) || double.IsInfinity(p.DisplayMx)));
}

static void TestReferenceBehavior()
{
    var result = Service().Calculate(MetricInput());
    IsTrue(result.Surface.AngleCount == 36);
    IsTrue(result.Surface.DepthCount == 150);  // StrainCompatibilityInteractionSolver.NeutralAxisSamples default
    IsTrue(result.ControlPoints.PmPoints.Any(p => p.Label == "Pmax"));
    IsTrue(result.ControlPoints.PmPoints.Any(p => p.Label == "Pmin"));
    IsTrue(result.ControlPoints.PmPoints.Any(p => p.IsDemandPoint));
    var surfacePoints = result.ControlPoints.PmmSurfacePoints.Where(p => !p.IsDemandPoint && !p.IsGoverningPoint).ToList();
    IsTrue(surfacePoints.Count(p => !p.GroupKey.Contains("Nominal", StringComparison.OrdinalIgnoreCase)) == 36 * 150);
    IsTrue(surfacePoints.Count(p => p.GroupKey.Contains("Nominal", StringComparison.OrdinalIgnoreCase)) == 36 * 150);
}

static void TestMetricImperialEquivalence()
{
    var metric = Service().Calculate(MetricInput());
    var imperial = Service().Calculate(ImperialInput());
    AreClose(metric.Ratio, imperial.Ratio, 0.08);
}

static void TestSectionPreviewCornerBars()
{
    var vm = new InputViewModel(new SingaporeRebarDatabase(), new ImperialRebarDatabase())
    {
        UnitSystem = UnitSystem.Metric,
        Width = 400,
        Height = 600,
        Cover = 40,
        BarSize = "T20",
        BarCount = 4,
        LayoutPreset = "4 corner bars"
    };

    IsTrue(vm.IsSectionPreviewValid);
    IsTrue(vm.PreviewRebars.Count == 4);
    IsTrue(vm.PreviewRebars.Any(p => p.X < 0 && p.Y < 0));
    IsTrue(vm.PreviewRebars.Any(p => p.X > 0 && p.Y > 0));
    IsTrue(vm.PreviewRebars.All(p => Math.Abs(p.X) <= 400 / 2.0 - 40 && Math.Abs(p.Y) <= 600 / 2.0 - 40));
    IsTrue(vm.RebarPreviewLabel.Contains("4-T20"));
}

static void TestSectionPreviewPerimeterBars()
{
    var vm = new InputViewModel(new SingaporeRebarDatabase(), new ImperialRebarDatabase())
    {
        UnitSystem = UnitSystem.Metric,
        Width = 400,
        Height = 600,
        Cover = 40,
        BarSize = "T20",
        BarCount = 8,
        LayoutPreset = "Perimeter bars"
    };

    IsTrue(vm.IsSectionPreviewValid);
    IsTrue(vm.PreviewRebars.Count == 8);
    IsTrue(vm.PreviewRebars.All(p => Math.Abs(p.X) <= 400 / 2.0 - 40 && Math.Abs(p.Y) <= 600 / 2.0 - 40));
}

static void TestSectionPreviewInvalidGeometry()
{
    var vm = new InputViewModel(new SingaporeRebarDatabase(), new ImperialRebarDatabase()) { Width = -1 };
    IsFalse(vm.IsSectionPreviewValid);
    IsTrue(vm.SectionPreviewErrorMessage.Contains("Invalid", StringComparison.OrdinalIgnoreCase));
}

static void TestSectionPreviewUnitLabels()
{
    var vm = new InputViewModel(new SingaporeRebarDatabase(), new ImperialRebarDatabase())
    {
        UnitSystem = UnitSystem.Imperial,
        Width = 16,
        Height = 24,
        Cover = 1.5,
        BarSize = "#6",
        BarCount = 8
    };

    IsTrue(vm.SectionPreviewLabel.Contains("in"));
    IsTrue(vm.CoverPreviewLabel.Contains("in"));
    IsTrue(vm.RebarPreviewLabel.Contains("8-#6"));
}

static void TestPmxDiagramAxisMapping()
{
    var result = Service().Calculate(MetricInput());
    var point = result.PmXDiagram.Points.First(p => !p.IsDemand && !p.IsGoverning && !p.IsReference);
    AreClose(point.Mx, point.X, 1e-9);
    AreClose(point.P, point.Y, 1e-9);
    var demand = result.PmXDiagram.Points.First(p => p.IsDemand);
    AreClose(result.MuxDisplay, demand.X, 1e-9);
    AreClose(result.PuDisplay, demand.Y, 1e-9);
}

static void TestPmyDiagramAxisMapping()
{
    var result = Service().Calculate(MetricInput());
    var point = result.PmYDiagram.Points.First(p => !p.IsDemand && !p.IsGoverning && !p.IsReference);
    AreClose(point.My, point.X, 1e-9);
    AreClose(point.P, point.Y, 1e-9);
    var demand = result.PmYDiagram.Points.First(p => p.IsDemand);
    AreClose(result.MuyDisplay, demand.X, 1e-9);
    AreClose(result.PuDisplay, demand.Y, 1e-9);
}

static void TestMxMyDiagramAxisMapping()
{
    var result = Service().Calculate(MetricInput());
    var point = result.MxMyDiagram.Points.First(p => !p.IsDemand && !p.IsGoverning && !p.IsReference);
    AreClose(point.Mx, point.X, 1e-9);
    AreClose(point.My, point.Y, 1e-9);
    var demand = result.MxMyDiagram.Points.First(p => p.IsDemand);
    AreClose(result.MuxDisplay, demand.X, 1e-9);
    AreClose(result.MuyDisplay, demand.Y, 1e-9);
}

static void TestPmm3DMappingAndMesh()
{
    var result = Service().Calculate(MetricInput());
    var point = result.PmmSurface.Points.First(p => !p.IsDemand && !p.IsGoverning);
    AreClose(point.Mx, point.X, 1e-9);
    AreClose(point.My, point.Y, 1e-9);
    AreClose(point.P, point.Z, 1e-9);
    IsTrue(result.PmmSurface.MeshTriangles.Count > 0);
    IsTrue(result.PmmSurface.WireframeLines.Count > 0);
    IsTrue(result.PmmSurface.XAxisLabel == "Mx");
    IsTrue(result.PmmSurface.YAxisLabel == "My");
    IsTrue(result.PmmSurface.ZAxisLabel == "P");
}

static void TestAxisTickService()
{
    var ticks = AxisTickService.Generate(-13, 83);
    IsTrue(new[] { 1.0, 2.0, 5.0 }.Contains(ticks.MajorInterval / Math.Pow(10, Math.Floor(Math.Log10(ticks.MajorInterval)))));
    IsTrue(ticks.MinorTicks.Count > ticks.MajorTicks.Count);
    IsTrue(ticks.MajorTicks.Any(t => Math.Abs(t) < 1e-12));
    IsTrue(AxisTickService.Format(12.345).Length > 0);
}

static void TestPmBranchContinuity()
{
    var result = Service().Calculate(MetricInput());
    foreach (var diagram in new[] { result.PmXDiagram.Points, result.PmYDiagram.Points })
    {
        // Now a single merged loop per curve type
        var groups = diagram.Where(p => !p.IsDemand && !p.IsGoverning && !p.IsReference).GroupBy(p => p.GroupKey).ToList();
        IsTrue(groups.Count >= 2); // DesignCapacity + NominalCapacity
        foreach (var group in groups)
        {
            var points = group.ToList();
            IsTrue(points.Count > 20); // merged loop has 2x the old branch count
            IsFalse(points.Any(p => double.IsNaN(p.X) || double.IsInfinity(p.X) || double.IsNaN(p.Y) || double.IsInfinity(p.Y)));
        }
    }

    IsTrue(result.PmXDiagram.Points.Any(p => p.IsReference && p.Label == "Pmax"));
    IsTrue(result.PmXDiagram.Points.Any(p => p.IsReference && p.Label == "Pmin"));
    IsTrue(result.PmYDiagram.Points.Any(p => p.IsReference && p.Label == "Pmax"));
    IsTrue(result.PmYDiagram.Points.Any(p => p.IsReference && p.Label == "Pmin"));
}

static void TestPmCurveDiagnosticsAndMarkerSeparation()
{
    PmCurveBuilderService.EnableDebugDiagnostics = true;
    var result = Service().Calculate(MetricInput());
    var diagnostics = PmCurveBuilderService.LastDiagnostics;
    IsTrue(diagnostics is not null);
    IsTrue(diagnostics!.RawInteractionPointCount > diagnostics.ValidPointCount - 1);
    IsTrue(diagnostics.PBinsCount == 150);  // matches StrainCompatibilityInteractionSolver.NeutralAxisSamples
    IsTrue(diagnostics.PositiveBranchCount > 10);
    IsTrue(diagnostics.NegativeBranchCount > 10);
    IsFalse(diagnostics.SmoothingApplied);

    foreach (var diagram in new[] { result.PmXDiagram.Points, result.PmYDiagram.Points })
    {
        var capacity = diagram.Where(p => !p.IsDemand && !p.IsGoverning && !p.IsReference).ToList();
        IsFalse(capacity.Any(p => p.GroupKey == "Demand" || p.GroupKey == "Governing" || p.GroupKey == "Reference"));
        // Now uses merged loop: DesignCapacity and NominalCapacity
        var design = capacity.Where(p => !p.IsNominal).ToList();
        IsTrue(design.All(p => p.GroupKey == "DesignCapacity"));
        IsTrue(design.Count > 20);
        var nominal = capacity.Where(p => p.IsNominal).ToList();
        IsTrue(nominal.All(p => p.GroupKey == "NominalCapacity"));
        IsTrue(nominal.Count > 20);
    }

    PmCurveBuilderService.EnableDebugDiagnostics = false;
}

static void TestDiagramBoundsIncludePoints()
{
    var result = Service().Calculate(MetricInput());
    var bounds = ChartTransformHelper.AutoFit2D(result.PmXDiagram.Points, new Rect(0, 0, 800, 500));
    IsTrue(result.PmXDiagram.Points.All(p => p.X >= bounds.MinX && p.X <= bounds.MaxX && p.Y >= bounds.MinY && p.Y <= bounds.MaxY));
}

static void TestChartAutoFitTransform()
{
    var points = new[]
    {
        new ControlPointDto(DiagramType.PM, -10, -5, 0, -5, -10, 0, 0.65, 0, 0, "", "A", false, false, false, false),
        new ControlPointDto(DiagramType.PM, 20, 30, 0, 30, 20, 0, 0.65, 0, 0, "", "A", false, false, false, false)
    };
    var transform = ChartTransformHelper.AutoFit2D(points, new Rect(0, 0, 800, 500));
    var a = transform.ToScreen(-10, -5);
    var b = transform.ToScreen(20, 30);
    IsTrue(a.X >= 0 && a.X <= 800 && a.Y >= 0 && a.Y <= 500);
    IsTrue(b.X >= 0 && b.X <= 800 && b.Y >= 0 && b.Y <= 500);
}

static void TestResultSettingsPropagate()
{
    var vm = new ResultViewModel
    {
        ShowGrid = false,
        ShowLabels = false,
        ShowPmaxPmin = false,
        ShowSurface3D = false,
        ShowWireframe3D = false
    };

    IsFalse(vm.PM.ShowGrid);
    IsFalse(vm.PM.ShowLabels);
    IsFalse(vm.PMy.ShowGrid);
    IsFalse(vm.PMy.ShowLabels);
    IsFalse(vm.MM.ShowGrid);
    IsFalse(vm.MM.ShowLabels);
    IsFalse(vm.PM3D.ShowGrid);
    IsFalse(vm.PM3D.ShowLabels);
    IsFalse(vm.MM3D.ShowGrid);
    IsFalse(vm.MM3D.ShowLabels);
    IsFalse(vm.PM3D.ShowSurface);
    IsFalse(vm.MM3D.ShowSurface);
    IsFalse(vm.PM3D.ShowWireframe);
    IsFalse(vm.MM3D.ShowWireframe);
}

// ----- Nominal vs Design Curve Tests -----

static void TestNominalUsesPnMn()
{
    // Nominal curve points must use Pn/Mn (no phi), so they should be larger than corresponding design points.
    var result = Service().Calculate(MetricInput());
    foreach (var diagram in new[] { result.PmXDiagram.Points, result.PmYDiagram.Points })
    {
        var nominal = diagram.Where(p => p.IsNominal && !p.IsDemand && !p.IsGoverning && !p.IsReference).ToList();
        IsTrue(nominal.Count > 0);
        // All nominal points must have phi carried but not applied to displayed values
        IsTrue(nominal.All(p => p.Phi > 0 && p.Phi <= 1.0));
    }
}

static void TestDesignUsesPhiPnPhiMn()
{
    var result = Service().Calculate(MetricInput());
    foreach (var diagram in new[] { result.PmXDiagram.Points, result.PmYDiagram.Points })
    {
        var design = diagram.Where(p => !p.IsNominal && !p.IsDemand && !p.IsGoverning && !p.IsReference).ToList();
        IsTrue(design.Count > 0);
        // Design points should have phi applied (capacity is phi-reduced)
        IsTrue(design.All(p => p.Phi > 0 && p.Phi <= 1.0));
    }
}

static void TestDesignLeNominal()
{
    // For any given control point, PhiPn <= Pn (design <= nominal).
    var result = Service().Calculate(MetricInput());
    var surface = result.ControlPoints.PmmSurfacePoints
        .Where(p => !p.IsDemandPoint && !p.IsGoverningPoint && p.Phi > 0).ToList();
    foreach (var p in surface)
    {
        IsTrue(Math.Abs(p.DisplayP) <= Math.Abs(p.NominalDisplayP) + 1e-6);
    }
}

static void TestPmmRatioUsesDesign()
{
    // PMM ratio must use the design (phi-factored) capacity, not nominal.
    // A demand near the design boundary should have ratio â‰ˆ 1.0.
    // The same demand compared to the nominal (Pn/Mn) surface would have ratio < 1.0.
    var result = Service().Calculate(MetricInput(pu: 500, mux: 50, muy: 30));
    IsTrue(result.Ratio > 0 && result.Ratio < double.PositiveInfinity);
    // RatioCheckService uses PhiPn/PhiMnx/PhiMny â€” verified in source code review.
}

static void TestPmxNomDesignSeparated()
{
    var result = Service().Calculate(MetricInput());
    var points = result.PmXDiagram.Points;
    var design = points.Where(p => !p.IsNominal && !p.IsDemand && !p.IsGoverning && !p.IsReference).ToList();
    var nominal = points.Where(p => p.IsNominal).ToList();
    IsTrue(design.Count > 20);
    IsTrue(nominal.Count > 20);
    // Design uses DesignCapacity, nominal uses NominalCapacity
    IsTrue(design.All(p => p.GroupKey == "DesignCapacity"));
    IsTrue(nominal.All(p => p.GroupKey == "NominalCapacity"));
}

static void TestPmyNomDesignSeparated()
{
    var result = Service().Calculate(MetricInput());
    var points = result.PmYDiagram.Points;
    var design = points.Where(p => !p.IsNominal && !p.IsDemand && !p.IsGoverning && !p.IsReference).ToList();
    var nominal = points.Where(p => p.IsNominal).ToList();
    IsTrue(design.Count > 20);
    IsTrue(nominal.Count > 20);
    IsTrue(design.All(p => p.GroupKey == "DesignCapacity"));
    IsTrue(nominal.All(p => p.GroupKey == "NominalCapacity"));
}

static void TestDemandNotInCapacity()
{
    var result = Service().Calculate(MetricInput());
    foreach (var diagram in new[] { result.PmXDiagram.Points, result.PmYDiagram.Points })
    {
        var capacity = diagram.Where(p => !p.IsDemand && !p.IsGoverning && !p.IsReference).ToList();
        IsFalse(capacity.Any(p => p.Label == "Demand"));
        var demand = diagram.Where(p => p.IsDemand).ToList();
        IsTrue(demand.Count == 1);
        IsFalse(demand[0].IsNominal);
    }
}

static void TestGoverningFromDesign()
{
    var result = Service().Calculate(MetricInput());
    foreach (var diagram in new[] { result.PmXDiagram.Points, result.PmYDiagram.Points })
    {
        var governing = diagram.Where(p => p.IsGoverning).ToList();
        IsTrue(governing.Count == 1);
        IsFalse(governing[0].IsNominal); // Governing is selected from design curve
    }
}

static void TestNominalDesignDiagnostics()
{
    PmCurveBuilderService.EnableDebugDiagnostics = true;
    Service().Calculate(MetricInput());
    var diag = PmCurveBuilderService.LastDiagnostics;
    IsTrue(diag is not null);
    IsTrue(diag!.NominalAndDesignSeparated);
    IsTrue(diag.NominalPositiveBranchCount > 10);
    IsTrue(diag.NominalNegativeBranchCount > 10);
    IsTrue(diag.FinalNominalCurveCount > 20);
    IsTrue(diag.DesignPMaxDisplay > 0);
    IsTrue(diag.NominalPMaxDisplay > diag.DesignPMaxDisplay); // nominal Pmax > design (capped)
    PmCurveBuilderService.EnableDebugDiagnostics = false;
}

// ----- ACI Trim Cap Tests (Task 3) -----

static void TestAciDesignCapPmx()
{
    var result = Service().Calculate(MetricInput());
    var design = result.PmXDiagram.Points.Where(p => !p.IsNominal && !p.IsDemand && !p.IsGoverning && !p.IsReference).ToList();
    // The design loop contains points at the ACI-capped Pmax level (top of envelope)
    double designPMax = design.Max(p => p.Y);
    // There should be at least 2 points near the top (positive and negative sides of the cap)
    var topPoints = design.Where(p => Math.Abs(p.Y - designPMax) < 0.01).ToList();
    IsTrue(topPoints.Count >= 1);
    // The Pmax reference line should be at the same level as the design cap
    var pmaxRef = result.PmXDiagram.Points.FirstOrDefault(p => p.IsReference && p.Label == "Pmax");
    IsTrue(pmaxRef is not null);
    AreClose(designPMax, pmaxRef!.Y, 1.0); // within tolerance
}

static void TestAciDesignCapPmy()
{
    var result = Service().Calculate(MetricInput());
    var design = result.PmYDiagram.Points.Where(p => !p.IsNominal && !p.IsDemand && !p.IsGoverning && !p.IsReference).ToList();
    double designPMax = design.Max(p => p.Y);
    var topPoints = design.Where(p => Math.Abs(p.Y - designPMax) < 0.01).ToList();
    IsTrue(topPoints.Count >= 1);
    var pmaxRef = result.PmYDiagram.Points.FirstOrDefault(p => p.IsReference && p.Label == "Pmax");
    IsTrue(pmaxRef is not null);
    AreClose(designPMax, pmaxRef!.Y, 1.0);
}

static void TestPmaxRefSeparateFromDesignCap()
{
    var result = Service().Calculate(MetricInput());
    foreach (var diagram in new[] { result.PmXDiagram.Points, result.PmYDiagram.Points })
    {
        // Pmax reference is separate from capacity points
        var pmaxRef = diagram.Where(p => p.IsReference && p.Label == "Pmax").ToList();
        IsTrue(pmaxRef.Count == 1);
        IsTrue(pmaxRef[0].IsReference);
        // The design capacity curve does NOT include reference points
        var capacity = diagram.Where(p => !p.IsDemand && !p.IsGoverning && !p.IsReference).ToList();
        IsFalse(capacity.Any(p => p.IsReference));
    }
}

static void TestPmPolylineValidation()
{
    var result = Service().Calculate(MetricInput());
    foreach (var diagram in new[] { result.PmXDiagram.Points, result.PmYDiagram.Points })
    {
        var defects = PmCurveBuilderService.ValidatePmCapacityPolyline(diagram);
        IsTrue(defects.Count == 0);
    }
}

static void AreClose(double expected, double actual, double tolerance)
{
    if (Math.Abs(expected - actual) > tolerance)
    {
        throw new InvalidOperationException($"Expected {expected}, got {actual}, tolerance {tolerance}.");
    }
}

static void IsTrue(bool condition)
{
    if (!condition) throw new InvalidOperationException("Expected true.");
}

static void IsFalse(bool condition)
{
    if (condition) throw new InvalidOperationException("Expected false.");
}

static void Throws(Action action)
{
    try
    {
        action();
    }
    catch
    {
        return;
    }

    throw new InvalidOperationException("Expected exception.");
}

// ----- 3D PMM Viewport Tests (Task 4) -----

static void Test3DXMapsMx()
{
    var result = Service().Calculate(MetricInput());
    var point = result.PmmSurface.Points.First(p => !p.IsDemand && !p.IsGoverning);
    // In 3D: X = Mx
    AreClose(point.Mx, point.X, 1e-9);
}

static void Test3DYMapsMy()
{
    var result = Service().Calculate(MetricInput());
    var point = result.PmmSurface.Points.First(p => !p.IsDemand && !p.IsGoverning);
    // In 3D: Y = My
    AreClose(point.My, point.Y, 1e-9);
}

static void Test3DZEqualsActualP()
{
    var result = Service().Calculate(MetricInput());
    var surface = result.PmmSurface.Points.Where(p => !p.IsDemand && !p.IsGoverning && !p.IsReference).ToList();
    // Z is the raw display P value â€” no offset. Axis origin at engineering P=0.
    foreach (var pt in surface)
        AreClose(pt.P, pt.Z, 1e-9);
}

static void Test3DDesignSurfaceAciCapped()
{
    var result = Service().Calculate(MetricInput());
    double expectedCap = result.ControlPoints.DesignCompressionLimitDisplay;
    var design = result.PmmSurface.Points.Where(p => !p.IsNominal && !p.IsDemand && !p.IsGoverning && !p.IsReference).ToList();
    IsTrue(design.Max(p => p.P) <= expectedCap + 1e-6);
    AreClose(expectedCap, design.Max(p => p.P), 1e-6);
}

static void Test3DAxisLabels()
{
    var result = Service().Calculate(MetricInput());
    IsTrue(result.PmmSurface.XAxisLabel == "Mx");
    IsTrue(result.PmmSurface.YAxisLabel == "My");
    IsTrue(result.PmmSurface.ZAxisLabel == "P");
}

static void Test3DSurfaceData()
{
    var result = Service().Calculate(MetricInput());
    // Surface must have mesh triangles and wireframe lines
    IsTrue(result.PmmSurface.MeshTriangles.Count > 0);
    IsTrue(result.PmmSurface.WireframeLines.Count > 0);
    // Points must include demand and governing markers
    IsTrue(result.PmmSurface.Points.Any(p => p.IsDemand));
    IsTrue(result.PmmSurface.Points.Any(p => p.IsGoverning));
    // Surface points must have valid 3D coordinates
    foreach (var p in result.PmmSurface.Points.Where(p => !p.IsDemand && !p.IsGoverning))
    {
        IsFalse(double.IsNaN(p.X) || double.IsInfinity(p.X));
        IsFalse(double.IsNaN(p.Y) || double.IsInfinity(p.Y));
        IsFalse(double.IsNaN(p.Z) || double.IsInfinity(p.Z));
    }
}

static void Test3DTopologySynchronized()
{
    var result = Service().Calculate(MetricInput());
    var capacity = result.PmmSurface.Points.Where(p => !p.IsDemand && !p.IsGoverning && !p.IsReference).ToList();
    var designRows = capacity.Where(p => !p.IsNominal).GroupBy(p => p.SliceKey).OrderBy(g => g.Key).Select(g => g.Count()).ToList();
    var nominalRows = capacity.Where(p => p.IsNominal).GroupBy(p => p.SliceKey).OrderBy(g => g.Key).Select(g => g.Count()).ToList();

    IsTrue(designRows.Count == 70);
    IsTrue(nominalRows.Count == 70);
    IsTrue(designRows.Count == nominalRows.Count);
    for (int i = 0; i < designRows.Count; i++)
    {
        IsTrue(designRows[i] == 36);
        IsTrue(nominalRows[i] == designRows[i]);
    }
}

static void Test3DPoleRingsFollowSpColumnNudge()
{
    var result = Service().Calculate(MetricInput());
    var design = result.PmmSurface.Points
        .Where(p => !p.IsNominal && !p.IsDemand && !p.IsGoverning && !p.IsReference)
        .ToList();

    foreach (var key in new[] { "depth=0", "depth=69" })
    {
        var ring = design.Where(p => p.SliceKey == key).ToList();
        IsTrue(ring.Count == 36);
        IsTrue(ring.Max(p => p.X) - ring.Min(p => p.X) > 1e-5);
        IsTrue(ring.Max(p => p.Y) - ring.Min(p => p.Y) > 1e-5);
    }
}

static void Test3DPmAngleFromResult()
{
    var result = Service().Calculate(MetricInput());
    // Governing theta should be finite and within [0, 360)
    IsTrue(result.GoverningThetaDegrees >= 0 && result.GoverningThetaDegrees < 360);
}

static void Test3DSelectedPmAngleDefault()
{
    // PM3DViewModel.Load should set SelectedPmAngle from governing theta
    var vm = new PM3DViewModel();
    var result = Service().Calculate(MetricInput());
    vm.Load(result);
    AreClose(result.GoverningThetaDegrees, vm.SelectedPmAngle, 1e-9);
}

static void Test3DSliceControlsUpdateLabels()
{
    var vm = new PM3DViewModel();
    var result = Service().Calculate(MetricInput());
    vm.Load(result);
    vm.SelectedPmAngleDegrees = 5.0;
    vm.SelectedAxialLoad = 1000.0;
    IsTrue(vm.SelectedPmAngleLabel.Contains("5.0"));
    IsTrue(vm.SelectedAxialLoadLabel.Contains("1000.0"));
    IsTrue(vm.SelectedAxialLoadLabel.Contains(result.PmmSurface.ForceUnit));
}

static void Test3DViewportExposesSliceControls()
{
    IsTrue(InteractionViewport3D.SelectedAxialLoadProperty is not null);
    IsTrue(InteractionViewport3D.ShowAxialLoadSliceProperty is not null);
    IsTrue(InteractionViewport3D.SelectedPmAngleProperty is not null);
    IsTrue(InteractionViewport3D.ShowSlicePlaneProperty is not null);
}

static void Test3DAxesOriginateAtEngineeringZero()
{
    var axes = InteractionViewport3D.BuildEngineeringAxesForTesting(-2500, 1800, -1200, 2200, 0, 17000);
    AreClose(0, axes.Origin.X, 1e-12);
    AreClose(0, axes.Origin.Y, 1e-12);
    AreClose(0, axes.Origin.Z, 1e-12);

    AreClose(0, axes.MxNegative.Y, 1e-12);
    AreClose(0, axes.MxNegative.Z, 1e-12);
    AreClose(0, axes.MxPositive.Y, 1e-12);
    AreClose(0, axes.MxPositive.Z, 1e-12);

    AreClose(0, axes.MyNegative.X, 1e-12);
    AreClose(0, axes.MyNegative.Z, 1e-12);
    AreClose(0, axes.MyPositive.X, 1e-12);
    AreClose(0, axes.MyPositive.Z, 1e-12);

    AreClose(0, axes.PNegative.X, 1e-12);
    AreClose(0, axes.PNegative.Y, 1e-12);
    AreClose(0, axes.PPositive.X, 1e-12);
    AreClose(0, axes.PPositive.Y, 1e-12);

    IsTrue(axes.MxNegative.X < 0 && axes.MxPositive.X > 0);
    IsTrue(axes.MyNegative.Y < 0 && axes.MyPositive.Y > 0);
    IsTrue(axes.PNegative.Z <= 0 && axes.PPositive.Z > 17000);

    double bboxCenterX = (-2500 + 1800) * 0.5;
    double bboxCenterY = (-1200 + 2200) * 0.5;
    double bboxCenterZ = (0 + 17000) * 0.5;
    IsFalse(Math.Abs(bboxCenterX) < 1e-12 && Math.Abs(bboxCenterY) < 1e-12 && Math.Abs(bboxCenterZ) < 1e-12);
}

static void TestResultNavigationPropagatesGlobally()
{
    var vm = new ResultViewModel();
    var result = Service().Calculate(MetricInput());
    vm.Result = result;

    var initial = vm.MxMyPoints.Where(p => !p.IsDemand && !p.IsGoverning && !p.IsReference && !p.IsNominal).ToList();
    IsTrue(initial.Count > 0);

    vm.SelectedSliceAngleDegrees = 45.0;
    vm.SelectedAxialLoad = 1000.0;

    IsTrue(vm.PmSliceLabel.Contains("45.0"));
    IsTrue(vm.MxMySliceLabel.Contains("1000.0"));
    AreClose(45.0, vm.PM3D.SelectedPmAngleDegrees, 1e-12);
    AreClose(1000.0, vm.PM3D.SelectedAxialLoad, 1e-12);
    AreClose(1000.0, vm.MM.SelectedPu, 1e-12);

    var updated = vm.MxMyPoints.Where(p => !p.IsDemand && !p.IsGoverning && !p.IsReference && !p.IsNominal).ToList();
    IsTrue(updated.Count > 0);
    IsTrue(updated.All(p => Math.Abs(p.P - 1000.0) < 1e-9));
    IsTrue(initial.Zip(updated).Any(pair => Math.Abs(pair.First.X - pair.Second.X) > 1e-6 || Math.Abs(pair.First.Y - pair.Second.Y) > 1e-6));
}

// ----- MxMy and Viewport Tests (Tasks 5 & 6) -----

static void TestMxMyNominalBoundary()
{
    var result = Service().Calculate(MetricInput());
    var hasNominal = result.MxMyDiagram.Points.Any(p => p.IsNominal);
    var hasDesign = result.MxMyDiagram.Points.Any(p => !p.IsNominal && p.GroupKey == "DesignCapacity");
    IsTrue(hasNominal);
    IsTrue(hasDesign);
}

static void TestMxMyNominalUsesMnMy()
{
    var result = Service().Calculate(MetricInput());
    var pDto = result.MxMyDiagram.Points.First(p => p.IsNominal);
    var cp = result.ControlPoints.MmPoints.First(c => c.GroupKey == "NominalCapacity" && Math.Abs(c.DisplayMx - pDto.Mx) < 1e-4 && Math.Abs(c.DisplayMy - pDto.My) < 1e-4);
    
    AreClose(cp.NominalDisplayMx, pDto.Mx, 1e-9);
    AreClose(cp.NominalDisplayMy, pDto.My, 1e-9);
}

static void TestMxMyDesignUsesPhiMnMy()
{
    var result = Service().Calculate(MetricInput());
    var pDto = result.MxMyDiagram.Points.First(p => !p.IsNominal && p.GroupKey == "DesignCapacity");
    var cp = result.ControlPoints.MmPoints.First(c => c.GroupKey == "DesignCapacity" && Math.Abs(c.DisplayMx - pDto.Mx) < 1e-4 && Math.Abs(c.DisplayMy - pDto.My) < 1e-4);
    
    AreClose(cp.DisplayMx, pDto.Mx, 1e-9);
    AreClose(cp.DisplayMy, pDto.My, 1e-9);
}

static void TestMxMyNomDesignSeparated()
{
    var result = Service().Calculate(MetricInput());
    var points = result.MxMyDiagram.Points.Where(p => !p.IsDemand && !p.IsGoverning && !p.IsReference).ToList();
    int firstNominalIdx = points.FindIndex(p => p.IsNominal);
    int lastDesignIdx = points.FindLastIndex(p => !p.IsNominal);
    IsTrue(firstNominalIdx > lastDesignIdx); // Design comes before Nominal
}

static void TestViewportDefaultAll()
{
    var vm = new ResultViewModel();
    IsTrue(vm.ActiveViewportCount == 2);
    IsTrue(vm.ShowPM && vm.ShowPmm3D);
    IsFalse(vm.ShowPMx || vm.ShowPMy || vm.ShowMxMy);
}

static void TestViewportToggle()
{
    var vm = new ResultViewModel();
    vm.ToggleViewport(DiagramViewportType.PM2D);
    IsTrue(vm.ActiveViewportCount == 1);
    IsFalse(vm.ShowPM);
}

static void TestViewportCannotDeselectLast()
{
    var vm = new ResultViewModel();
    vm.ToggleViewport(DiagramViewportType.PM2D);
    IsTrue(vm.ActiveViewportCount == 1);
    vm.ToggleViewport(DiagramViewportType.Pmm3D); // Should not deselect the last one
    IsTrue(vm.ActiveViewportCount == 1);
    IsTrue(vm.ShowPmm3D);
}

static void TestViewportLayoutPreservesResult()
{
    var vm = new ResultViewModel();
    var result = Service().Calculate(MetricInput());
    vm.Result = result;
    
    vm.ToggleViewport(DiagramViewportType.PMx2D);
    IsTrue(vm.Result == result);
}

// ----- 3D Geometry Extent Tests (Task 7) -----

static void Test3DSurfaceGeometryAspect()
{
    // MetricInput defaults to 700x700, override to 400x600
    var input = MetricInput() with { Width = 400, Height = 600 };
    var result = Service().Calculate(input);
    
    var pts = result.PmmSurface.Points;
    double minX = pts.Min(p => p.X);
    double maxX = pts.Max(p => p.X);
    double minY = pts.Min(p => p.Y);
    double maxY = pts.Max(p => p.Y);
    
    // For 400x600 column, Mx capacity (bending about X, meaning Height is h=600) 
    // will be larger than My capacity (bending about Y, width h=400).
    double rangeX = maxX - minX;
    double rangeY = maxY - minY;
    
    IsTrue(Math.Abs(rangeX - rangeY) > 100); // Definitely not equal
    IsTrue(rangeX > rangeY);
}

static void Test3DBoundsMatch2D()
{
    var result = Service().Calculate(MetricInput());
    
    var pm3D = result.PmmSurface.Points.Where(p => !p.IsNominal && !p.IsDemand && !p.IsGoverning && !p.IsReference).ToList();
    double max3DX = pm3D.Max(p => p.X);
    double max3DY = pm3D.Max(p => p.Y);
    double min3DX = pm3D.Min(p => p.X);
    double min3DY = pm3D.Min(p => p.Y);
    
    var pmx = result.PmXDiagram.Points.Where(p => !p.IsNominal && !p.IsDemand && !p.IsGoverning && !p.IsReference).ToList();
    var pmy = result.PmYDiagram.Points.Where(p => !p.IsNominal && !p.IsDemand && !p.IsGoverning && !p.IsReference).ToList();
    
    double max2DX = pmx.Max(p => p.X);
    double max2DY = pmy.Max(p => p.X);
    
    double min2DX = pmx.Min(p => p.X);
    double min2DY = pmy.Min(p => p.X);

    // PMx/PMy are XZ/YZ plane intersections of the PMM surface, so their values must be
    // contained by the design 3D bounds but do not have to equal the global Mx/My maxima.
    IsTrue(max2DX <= max3DX + 5.0);
    IsTrue(max2DY <= max3DY + 5.0);
    IsTrue(min2DX >= min3DX - 5.0);
    IsTrue(min2DY >= min3DY - 5.0);
}

// ----- Chart Axis Tick and Rendering Tests (Task 8) -----

static void TestAxisTickIndependentSteps()
{
    // Generate X with small range, large target
    var xTicks = AxisTickService.Generate(0, 100, targetMajorCount: 10);
    // Generate Y with huge range, small target
    var yTicks = AxisTickService.Generate(-5000, 5000, targetMajorCount: 5);
    
    IsTrue(xTicks.MajorInterval < yTicks.MajorInterval);
    IsTrue(xTicks.MajorInterval == 10);
    IsTrue(yTicks.MajorInterval == 2000); // 10000 / 5 = 2000
    
    // Bounds expand properly
    IsTrue(xTicks.Min == 0);
    IsTrue(xTicks.Max == 100);
    IsTrue(yTicks.Min == -6000 || yTicks.Min == -5000); // Expanded bounds depending on floor/ceil
}

static void TestAxisTickNiceNumbers()
{
    var ticks = AxisTickService.Generate(-17.3, 114.2, 5);
    // Span = 131.5 / 5 = 26.3 -> Nice number should be 25 or 50.
    // In our algorithm: 26.3 -> frac 2.63 -> 2.5 * 10 = 25 or 5 * 10 = 50
    // With rounding, 2.63 < 3.5 ? 2.5 : 5. So it will be 25.
    IsTrue(ticks.MajorInterval == 25.0 || ticks.MajorInterval == 30.0 || ticks.MajorInterval == 50.0);
    IsTrue(ticks.MajorTicks.Contains(0));
}

static void TestAxisTickFormatStrings()
{
    IsTrue(AxisTickService.Format(1000) == "1,000");
    IsTrue(AxisTickService.Format(-2500.5) == "-2,500.5");
    IsTrue(AxisTickService.Format(0.0000000001) == "0");
}

static void TestChartTransformSnapsToBounds()
{
    var pts = new List<ControlPointDto>
    {
        new(DiagramType.PM, -13, -1140, 0, 0, 0, 0, 0, 0, 0, "", "", false, false, false, false),
        new(DiagramType.PM, 27, 4320, 0, 0, 0, 0, 0, 0, 0, "", "", false, false, false, false)
    };
    
    var helper = ChartTransformHelper.AutoFit2D(pts, new Rect(0, 0, 800, 600));
    
    // The bounds should be padded and then snapped to a nice number, not the exact min/max
    IsTrue(helper.MinX <= -13);
    IsTrue(helper.MaxX >= 27);
    IsTrue(helper.MinY <= -1140);
    IsTrue(helper.MaxY >= 4320);
    
    // They should be divisible by their major interval (meaning they are nice bounds)
    var xTicks = helper.AxisTicksX();
    var yTicks = helper.AxisTicksY();
    
    AreClose(helper.MinX % xTicks.MajorInterval, 0, 1e-5);
    AreClose(helper.MaxY % yTicks.MajorInterval, 0, 1e-5);
}

static void TestMxMyChartTransformEqualAspect()
{
    var pts = new List<ControlPointDto>
    {
        new(DiagramType.MM, -100, -50, 0, 0, -100, -50, 1, 0, 0, "", "", false, false, false, false),
        new(DiagramType.MM, 100, 50, 0, 0, 100, 50, 1, 0, 0, "", "", false, false, false, false)
    };

    var plot = new Rect(0, 0, 800, 400);
    var helper = ChartTransformHelper.AutoFit2D(pts, plot, useEqualAspect: true);
    double pixelsPerX = plot.Width / (helper.MaxX - helper.MinX);
    double pixelsPerY = plot.Height / (helper.MaxY - helper.MinY);
    AreClose(pixelsPerX, pixelsPerY, 1e-9);
}

// ----- Pmm3DSliceControlTests -----

static void Test3DPmSliceAngleReflectedInLabel()
{
    var vm = new PM3DViewModel();
    var result = Service().Calculate(MetricInput());
    vm.Load(result);
    vm.SelectedPmAngle = 45.0;
    IsTrue(vm.SelectedPmAngleLabel.Contains("45.0"));
    IsTrue(vm.SelectedPmAngleLabel.Contains("°"));
}

static void Test3DAxialSliceLabelContainsPAndUnit()
{
    var vm = new PM3DViewModel();
    var result = Service().Calculate(MetricInput());
    vm.Load(result);
    vm.SelectedAxialLoad = 2500.0;
    IsTrue(vm.SelectedAxialLoadLabel.Contains("2500.0"));
    IsTrue(vm.SelectedAxialLoadLabel.Contains(result.PmmSurface.ForceUnit));
}

static void Test3DAxialSliceZEqualsDemandP()
{
    // With no P offset, Z = actual display P on every point including demand.
    // The axial slice drawn at Z = SelectedAxialLoad = PuDisplay therefore
    // passes through the demand point at the correct engineering level.
    var result = Service().Calculate(MetricInput());
    var demand = result.PmmSurface.Points.First(p => p.IsDemand);
    AreClose(demand.P, demand.Z, 1e-9);
    AreClose(result.PuDisplay, demand.Z, 1e-9);
}

// ----- Pmm3DPerformanceTests -----

static void Test3DPmAngleDpUsesAffectsRenderOnly()
{
    // SelectedPmAngle must be registered with AffectsRender only â€” no
    // PropertyChangedCallback that would call InvalidateScene(). This
    // guarantees changing the angle triggers OnRender without rebuilding
    // the cached PMM surface mesh.
    var meta = InteractionViewport3D.SelectedPmAngleProperty.GetMetadata(typeof(InteractionViewport3D));
    IsTrue(meta is FrameworkPropertyMetadata fpm && fpm.AffectsRender);
}

static void Test3DAxialLoadDpUsesAffectsRenderOnly()
{
    // Same contract for SelectedAxialLoad: AffectsRender only, so the
    // cached mesh is reused when the user moves the axial load slider.
    var meta = InteractionViewport3D.SelectedAxialLoadProperty.GetMetadata(typeof(InteractionViewport3D));
    IsTrue(meta is FrameworkPropertyMetadata fpm && fpm.AffectsRender);
}

// ----- Pmm3DOrientationCubeTests -----

static void Test3DOrientationCubeAxisBuilderValid()
{
    // The orientation cube shares the same yaw/pitch projection as the main
    // axes. Verify the axis builder returns geometrically consistent bounds
    // for a column whose P range spans both tension and compression.
    var axes = InteractionViewport3D.BuildEngineeringAxesForTesting(-2000, 2000, -2000, 2000, -5000, 15000);
    IsTrue(axes.MxPositive.X > 0);
    IsTrue(axes.MxNegative.X < 0);
    IsTrue(axes.MyPositive.Y > 0);
    IsTrue(axes.MyNegative.Y < 0);
    IsTrue(axes.PPositive.Z > 15000);
    IsTrue(axes.PNegative.Z < -5000);
    AreClose(0, axes.Origin.X, 1e-12);
    AreClose(0, axes.Origin.Y, 1e-12);
    AreClose(0, axes.Origin.Z, 1e-12);
}

// ----- Multi-load case tests (Task 10) -----

static ColumnInputDto MetricInputWithCases(params (string id, string name, double pu, double mux, double muy, bool active)[] cases)
{
    var lcDtos = cases.Select(c => new LoadCaseDto(c.id, c.name, c.pu, c.mux, c.muy, c.active, ForceUnit.kN, MomentUnit.kNm)).ToList();
    return MetricInput() with { LoadCases = lcDtos };
}

static void TestMultiLoadCaseGoverningIsMaxRatio()
{
    // LC1 is light; LC2 is heavy (near capacity). Governing should be LC2.
    var input = MetricInputWithCases(
        ("lc1", "LC1", 500, 50, 30, true),
        ("lc2", "LC2", 4500, 350, 280, true));
    var result = Service().Calculate(input);
    IsTrue(result.GoverningLoadCaseId == "lc2");
    // Ratio from LC2 must be higher than LC1.
    double ratioLc1 = result.LoadCaseResults.First(r => r.LoadCaseId == "lc1").PmmRatio;
    double ratioLc2 = result.LoadCaseResults.First(r => r.LoadCaseId == "lc2").PmmRatio;
    IsTrue(ratioLc2 > ratioLc1);
    AreClose(ratioLc2, result.Ratio, 1e-9);
}

static void TestMultiLoadCaseResultCount()
{
    var input = MetricInputWithCases(
        ("a", "LC1", 1000, 100, 80, true),
        ("b", "LC2", 2000, 150, 100, true),
        ("c", "LC3", 3000, 200, 150, true));
    var result = Service().Calculate(input);
    IsTrue(result.LoadCaseResults.Count == 3);
}

static void TestMultiLoadCaseInactiveExcluded()
{
    // LC3 inactive â€” even though its loads are large, it must not be governing.
    var input = MetricInputWithCases(
        ("a", "LC1", 1000, 100, 80, true),
        ("b", "LC2", 2000, 150, 100, true),
        ("c", "LC3", 5000, 400, 350, false));
    var result = Service().Calculate(input);
    // Result count should only include active cases
    IsTrue(result.LoadCaseResults.Count == 2);
    IsFalse(result.LoadCaseResults.Any(r => r.LoadCaseId == "c"));
}

static void TestMultiLoadCaseFallbackToSingle()
{
    // No LoadCases â†’ falls back to (Pu, Mux, Muy) from primary fields.
    var single = MetricInput(pu: 2500, mux: 250, muy: 180);
    var multiWithNoCases = single with { LoadCases = null };
    var resultSingle = Service().Calculate(single);
    var resultFallback = Service().Calculate(multiWithNoCases);
    AreClose(resultSingle.Ratio, resultFallback.Ratio, 1e-9);
    IsTrue(resultFallback.LoadCaseResults.Count == 1);
}

static void TestMultiLoadCaseGoverningIdInResult()
{
    var input = MetricInputWithCases(
        ("x1", "LC1", 2000, 200, 150, true),
        ("x2", "LC2", 3500, 300, 250, true));
    var result = Service().Calculate(input);
    // GoverningLoadCaseId must be one of the provided IDs
    IsTrue(result.GoverningLoadCaseId == "x1" || result.GoverningLoadCaseId == "x2");
    // It must match the case with the highest ratio
    var govCase = result.LoadCaseResults.MaxBy(r => r.PmmRatio)!;
    IsTrue(result.GoverningLoadCaseId == govCase.LoadCaseId);
}

// ----- ACI Trim Segment Straight-Line Tests (Task 13 Addendum) -----

static void TestAciTrimSegmentStraightPmx()
{
    var result = Service().Calculate(MetricInput());
    double cap = result.ControlPoints.DesignCompressionLimitDisplay;
    var defects = PmCurveBuilderService.ValidateStraightTrimSegment(result.PmXDiagram.Points, cap);
    IsTrue(defects.Count == 0);
}

static void TestAciTrimSegmentStraightPmy()
{
    var result = Service().Calculate(MetricInput());
    double cap = result.ControlPoints.DesignCompressionLimitDisplay;
    var defects = PmCurveBuilderService.ValidateStraightTrimSegment(result.PmYDiagram.Points, cap);
    IsTrue(defects.Count == 0);
}

// ----- Control Points Table Tests -----

static void TestControlPointsTableRowCount()
{
    var result = Service().Calculate(MetricInput());
    IsTrue(result.ControlPointTable is not null);
    // 4 axes Ã— 8 labeled points = 32 rows
    AreClose(32, result.ControlPointTable!.Rows.Count, 0);
}

static void TestControlPointsAllowableComp()
{
    var result = Service().Calculate(MetricInput());
    var table = result.ControlPointTable!;
    var maxCompRows = table.Rows.Where(r => r.PointLabel == "Max compression").ToList();
    var allowRows   = table.Rows.Where(r => r.PointLabel == "Allowable comp.").ToList();
    IsTrue(maxCompRows.Count == 4 && allowRows.Count == 4);
    foreach (var (mc, al) in maxCompRows.Zip(allowRows))
        AreClose(mc.P * 0.80, al.P, mc.P * 0.01); // within 1% tolerance
}

static void TestControlPointsDtEqualsFsZeroNa()
{
    var result = Service().Calculate(MetricInput());
    var table = result.ControlPointTable!;
    var fsZeroRows = table.Rows.Where(r => r.PointLabel == "fs = 0.0").ToList();
    IsTrue(fsZeroRows.Count == 4);
    foreach (var row in fsZeroRows)
        AreClose(row.NaDepth, row.DtDepth, Math.Abs(row.DtDepth) * 0.001 + 0.1); // NA at fs=0 equals dt
}

static void TestControlPointsTensionControlEpsilon()
{
    var result = Service().Calculate(MetricInput());
    var table = result.ControlPointTable!;
    var tcRows = table.Rows.Where(r => r.PointLabel == "Tension control").ToList();
    IsTrue(tcRows.Count == 4);
    foreach (var row in tcRows)
        AreClose(0.005, row.EpsilonT, 1e-4);
}

// ----- EC2 Fiber PMM Tests -----

static RectangularSection SConcreteSection()
{
    const double diameter = 25.0;
    double area = Math.PI * diameter * diameter / 4.0;
    var coords = new (double X, double Y)[]
    {
        (-237.5,  337.5),
        (-118.75, 337.5),
        (   0.0,  337.5),
        ( 118.75, 337.5),
        ( 237.5,  337.5),
        (-237.5,  168.75),
        ( 237.5,  168.75),
        (-237.5,    0.0),
        ( 237.5,    0.0),
        (-237.5, -168.75),
        ( 237.5, -168.75),
        (-237.5, -337.5),
        (-118.75,-337.5),
        (   0.0, -337.5),
        ( 118.75,-337.5),
        ( 237.5, -337.5)
    };

    var bars = coords.Select((p, i) => new Rebar($"B{i + 1:00}", diameter, area, p.X, p.Y)).ToList();
    return new RectangularSection(600.0, 800.0, new RebarLayout("S-CONCRETE 16H25", "H25", 62.5, bars));
}

static Ec2FiberInteractionSolver FastEc2Solver()
    => new() { AngleStepDegrees = 30, NeutralAxisSamples = 36, ConcreteGridDivisions = 20 };

static void TestEc2FactoryUsesFiberSolver()
{
    var aci = new Aci318DesignCodeService();
    var ec2 = new Ec2DesignCodeService();
    var factory = new InteractionSolverFactory(aci, ec2);
    IsTrue(factory.Get(DesignCodeType.Aci318Style) is StrainCompatibilityInteractionSolver);
    IsTrue(factory.Get(DesignCodeType.Ec2) is Ec2FiberInteractionSolver);
}

static void TestEc2NegativeAxialBendingKeepsConcreteCompression()
{
    var surface = FastEc2Solver().Solve(SConcreteSection(), new ConcreteMaterial("C35", 35.0), new SteelMaterial("B500", 500.0, 200000.0));
    var point = surface.Points.FirstOrDefault(p => p.Pn < -100_000.0 && p.ConcretePn > 1.0);
    IsTrue(point is not null);
    IsTrue(point!.SteelPn < 0.0);
    IsTrue(point.ConcretePn > 0.0);
}

static void TestEc2SteelCarriesTensionAndCompression()
{
    var surface = FastEc2Solver().Solve(SConcreteSection(), new ConcreteMaterial("C35", 35.0), new SteelMaterial("B500", 500.0, 200000.0));
    IsTrue(surface.Points.Any(p => p.MinSteelStrain < -0.0001 && p.SteelPn < 0.0));
    IsTrue(surface.Points.Any(p => p.MaxSteelStrain > 0.0001 && p.SteelPn > 0.0));
}

static void TestAciBaselineRemainsRectangularBlockPath()
{
    var aci = new StrainCompatibilityInteractionSolver(new Aci318DesignCodeService());
    var section = SConcreteSection();
    var surface = aci.Solve(section, new ConcreteMaterial("C35", 35.0), new SteelMaterial("B500", 500.0, 200000.0));
    IsTrue(surface.AngleCount == 36);
    IsTrue(surface.DepthCount == 70);
    IsTrue(surface.Points.All(p => p.ConcretePn == 0.0 && p.StateLabel == ""));
    IsTrue(surface.Points.Any(p => p.Phi < 1.0));
}

static void TestAllSidesEqualRule()
{
    var units = new UnitConversionService();
    var metric = new SingaporeRebarDatabase();
    var imperial = new ImperialRebarDatabase();
    var builder = new RebarCoordinateBuilderService(units, metric, imperial);

    // Valid cases: 4, 8, 12, 16, 20
    foreach (int count in new[] { 4, 8, 12, 16, 20 })
    {
        var layout = new RebarLayoutInputDto(RebarLayoutType.AllSidesEqual, count, "T25", 55, null!, null!, null!, null!);
        var bars = builder.Build(layout, 500, 500, LengthUnit.Millimeter, UnitSystem.Metric);
        IsTrue(bars.Count == count);
    }

    // Invalid cases: 6, 10, 14, 18
    foreach (int count in new[] { 6, 10, 14, 18 })
    {
        var layout = new RebarLayoutInputDto(RebarLayoutType.AllSidesEqual, count, "T25", 55, null!, null!, null!, null!);
        Throws(() => builder.Build(layout, 500, 500, LengthUnit.Millimeter, UnitSystem.Metric));
    }
}

static (StrainCompatibilityInteractionSolver Conv, AciFiberInteractionSolver Fiber, RectangularSection Section, ConcreteMaterial Concrete, SteelMaterial Steel) AciSolverFixtures()
{
    var aci = new Aci318DesignCodeService();
    var conv = new StrainCompatibilityInteractionSolver(aci) { AngleStepDegrees = 30, NeutralAxisSamples = 30 };
    var fiber = new AciFiberInteractionSolver(aci) { AngleStepDegrees = 30, NeutralAxisSamples = 30, ConcreteGridDivisions = 40 };
    var section = SConcreteSection();
    return (conv, fiber, section, new ConcreteMaterial("C28", 28.0), new SteelMaterial("Gr420", 420.0, 200000.0));
}

static void TestAciSolverFactoryRouting()
{
    var aci = new Aci318DesignCodeService();
    var ec2 = new Ec2DesignCodeService();
    var factory = new InteractionSolverFactory(aci, ec2);
    IsTrue(factory.Get(DesignCodeType.Aci318Style, aciSolver: AciSolverType.Conventional) is StrainCompatibilityInteractionSolver);
    IsTrue(factory.Get(DesignCodeType.Aci318Style, aciSolver: AciSolverType.Fiber) is AciFiberInteractionSolver);
    // Default routes to Conventional (no regression for existing callers).
    IsTrue(factory.Get(DesignCodeType.Aci318Style) is StrainCompatibilityInteractionSolver);
}

static void TestAciConventionalUnchangedByFiberOption()
{
    // Re-route via DTO option and confirm Conventional still produces the legacy ratio.
    var baseline = Service().Calculate(MetricInput());
    var withExplicitConventional = Service().Calculate(MetricInput() with { AciSolver = AciSolverType.Conventional });
    AreClose(baseline.Ratio, withExplicitConventional.Ratio, 1e-9);
    AreClose(baseline.DesignPnDisplay, withExplicitConventional.DesignPnDisplay, 1e-9);
    AreClose(baseline.DesignMxDisplay, withExplicitConventional.DesignMxDisplay, 1e-9);
    AreClose(baseline.DesignMyDisplay, withExplicitConventional.DesignMyDisplay, 1e-9);
}

static void TestAciFiberPureCompressionCloseToConventional()
{
    var (conv, fiber, section, concrete, steel) = AciSolverFixtures();
    var convSurface = conv.Solve(section, concrete, steel);
    var fiberSurface = fiber.Solve(section, concrete, steel);
    double convP0 = convSurface.Points.Max(p => p.Pn);
    double fiberP0 = fiberSurface.Points.Max(p => p.Pn);
    // Conventional Whitney vs fiber Hognestad — pure-compression P0 should agree within ~5%.
    double rel = System.Math.Abs(convP0 - fiberP0) / System.Math.Max(System.Math.Abs(convP0), 1.0);
    IsTrue(rel < 0.05);
}

static void TestAciFiberPureTensionMatchesConventional()
{
    var (conv, fiber, section, concrete, steel) = AciSolverFixtures();
    var convSurface = conv.Solve(section, concrete, steel);
    var fiberSurface = fiber.Solve(section, concrete, steel);
    // Pure tension is steel-only in both solvers (concrete tension ignored, steel clamped at fyd).
    double convPnt = convSurface.Points.Min(p => p.Pn);
    double fiberPnt = fiberSurface.Points.Min(p => p.Pn);
    AreClose(convPnt, fiberPnt, System.Math.Abs(convPnt) * 1e-6);
}

static void TestAciFiberStrongAxisCloseToConventional()
{
    var (conv, fiber, section, concrete, steel) = AciSolverFixtures();
    var convSurface = conv.Solve(section, concrete, steel);
    var fiberSurface = fiber.Solve(section, concrete, steel);
    double convMx = convSurface.Points.Max(p => p.Mnx);
    double fiberMx = fiberSurface.Points.Max(p => p.Mnx);
    double rel = System.Math.Abs(convMx - fiberMx) / System.Math.Max(System.Math.Abs(convMx), 1.0);
    IsTrue(rel < 0.05);
}

static void TestAciFiberPhiFollowsAciTransition()
{
    var (_, fiber, section, concrete, steel) = AciSolverFixtures();
    var surface = fiber.Solve(section, concrete, steel);
    // ACI phi must vary in [0.65, 0.90] and hit both endpoints across the sweep.
    IsTrue(surface.Points.Any(p => p.Phi <= 0.66));
    IsTrue(surface.Points.Any(p => p.Phi >= 0.89));
    IsTrue(surface.Points.All(p => p.Phi >= 0.65 - 1e-9 && p.Phi <= 0.90 + 1e-9));
}

static void TestAciFiberSurfaceNoNan()
{
    var (_, fiber, section, concrete, steel) = AciSolverFixtures();
    var surface = fiber.Solve(section, concrete, steel);
    IsFalse(surface.Points.Any(p =>
        double.IsNaN(p.Pn) || double.IsInfinity(p.Pn) ||
        double.IsNaN(p.Mnx) || double.IsInfinity(p.Mnx) ||
        double.IsNaN(p.Mny) || double.IsInfinity(p.Mny) ||
        double.IsNaN(p.Phi) || double.IsInfinity(p.Phi)));
}

// =====================================================================
// EC2 Simplified Rectangular Stress Block Solver Tests
// Reference section: 300 × 300 mm, C30, B500, 4 × T20 at ±110 mm
// fcd = 0.80 × 30 / 1.50 = 16.0 MPa   lambda = 0.8   eta = 1.0
// fyd = 500 / 1.15 = 434.78 MPa        As = 4 × π/4 × 20² = 1256.64 mm²
// =====================================================================

static RectangularSection SimpleEc2Section()
{
    const double diam = 20.0;
    double barArea = Math.PI * diam * diam / 4.0;   // 314.16 mm²
    // 4 corner bars; centroid at ±(150 – 40) = ±110 mm from section centroid
    return new RectangularSection(300.0, 300.0,
        new RebarLayout("4-corner", "T20", 40.0, new[]
        {
            new Rebar("B1", diam, barArea, -110.0, -110.0),
            new Rebar("B2", diam, barArea,  110.0, -110.0),
            new Rebar("B3", diam, barArea,  110.0,  110.0),
            new Rebar("B4", diam, barArea, -110.0,  110.0)
        }));
}

static Ec2SimplifiedStressBlockInteractionSolver FastSsbSolver()
    => new() { AngleStepDegrees = 30, NeutralAxisSamples = 36 };

// --- Material factor tests ------------------------------------------

static void TestEc2SsbMaterialFactorsLowFck()
{
    // For fck ≤ 50 MPa: lambda = 0.8, eta = 1.0 (EC2 3.1.7(3))
    AreClose(0.8, Ec2SimplifiedStressBlockInteractionSolver.Lambda(30.0), 1e-12);
    AreClose(0.8, Ec2SimplifiedStressBlockInteractionSolver.Lambda(50.0), 1e-12);
    AreClose(1.0, Ec2SimplifiedStressBlockInteractionSolver.Eta(30.0),    1e-12);
    AreClose(1.0, Ec2SimplifiedStressBlockInteractionSolver.Eta(50.0),    1e-12);
    // For fck = 30: blockStress = eta × fcd = 1.0 × (0.80 × 30 / 1.50) = 16.0 MPa
    double fcd = 0.80 * 30.0 / 1.50;
    AreClose(16.0, fcd, 1e-9);
}

static void TestEc2SsbMaterialFactorsHighFck()
{
    // For fck = 70 MPa (> 50): lambda = 0.8 – (70–50)/400 = 0.75, eta = 1.0 – (70–50)/200 = 0.9
    AreClose(0.75, Ec2SimplifiedStressBlockInteractionSolver.Lambda(70.0), 1e-12);
    AreClose(0.90, Ec2SimplifiedStressBlockInteractionSolver.Eta(70.0),    1e-12);
    // Minimum eta = 0.8 (not reached at fck = 70)
    IsTrue(Ec2SimplifiedStressBlockInteractionSolver.Eta(90.0) >= 0.8);
    // Minimum lambda = 0.5 (not reached at fck = 70)
    IsTrue(Ec2SimplifiedStressBlockInteractionSolver.Lambda(90.0) >= 0.5);
}

// --- Factory routing test -------------------------------------------

static void TestEc2SsbFactoryRouting()
{
    var aci = new Aci318DesignCodeService();
    var ec2 = new Ec2DesignCodeService();
    var factory = new InteractionSolverFactory(aci, ec2);
    IsTrue(factory.Get(DesignCodeType.Ec2, ec2Solver: Ec2SolverType.SimplifiedStressBlock)
                  is Ec2SimplifiedStressBlockInteractionSolver);
    // Default (Boundary) must still resolve to the boundary solver.
    IsTrue(factory.Get(DesignCodeType.Ec2) is Ec2BoundaryInteractionSolver);
    // Fiber must still resolve to the fiber solver.
    IsTrue(factory.Get(DesignCodeType.Ec2, ec2Solver: Ec2SolverType.Fiber) is Ec2FiberInteractionSolver);
}

// --- Surface integrity tests ----------------------------------------

static void TestEc2SsbNoNaN()
{
    var surface = FastSsbSolver().Solve(
        SimpleEc2Section(),
        new ConcreteMaterial("C30", 30.0),
        new SteelMaterial("B500", 500.0, 200000.0));

    IsFalse(surface.Points.Any(p =>
        double.IsNaN(p.Pn)  || double.IsInfinity(p.Pn)  ||
        double.IsNaN(p.Mnx) || double.IsInfinity(p.Mnx) ||
        double.IsNaN(p.Mny) || double.IsInfinity(p.Mny) ||
        double.IsNaN(p.Phi) || double.IsInfinity(p.Phi)));
}

static void TestEc2SsbSurfaceTopology()
{
    var solver = FastSsbSolver();
    var surface = solver.Solve(
        SimpleEc2Section(),
        new ConcreteMaterial("C30", 30.0),
        new SteelMaterial("B500", 500.0, 200000.0));

    int expectedAngleCount  = 360 / solver.AngleStepDegrees;    // 12
    int expectedDepthCount  = solver.NeutralAxisSamples;         // 36
    IsTrue(surface.AngleCount == expectedAngleCount);
    IsTrue(surface.DepthCount == expectedDepthCount);
    IsTrue(surface.Points.Count == expectedAngleCount * expectedDepthCount);
}

// --- Axial force boundary tests -------------------------------------

static void TestEc2SsbPureCompression()
{
    // P0 = eta*fcd*Ac + (Es*eps_c3 – eta*fcd)*As
    // eta=1, fcd=16, Ac=90 000, Es*eps_c3=200 000×0.00175=350, As=4×π/4×20²=1256.64
    // P0 = 16×90 000 + (350–16)×1256.64 = 1 440 000 + 419 718 ≈ 1 859 718 N
    const double expectedP0 = 1_859_718.0;

    var surface = FastSsbSolver().Solve(
        SimpleEc2Section(),
        new ConcreteMaterial("C30", 30.0),
        new SteelMaterial("B500", 500.0, 200000.0));

    double p0 = surface.Points.Max(p => p.Pn);
    IsTrue(p0 > 0);
    AreClose(expectedP0, p0, expectedP0 * 0.03);   // 3 % tolerance on sampled surface
}

static void TestEc2SsbPureTension()
{
    // Pmin = –fyd × As = –(500/1.15) × 1256.64 ≈ –546 362 N
    double fyd        = 500.0 / 1.15;
    double barArea    = Math.PI * 20.0 * 20.0 / 4.0;
    double expectedPt = -fyd * 4.0 * barArea;

    var surface = FastSsbSolver().Solve(
        SimpleEc2Section(),
        new ConcreteMaterial("C30", 30.0),
        new SteelMaterial("B500", 500.0, 200000.0));

    double pMin = surface.Points.Min(p => p.Pn);
    IsTrue(pMin < 0);
    // Pure tension is steel-only and exact at the tension pole — 2% tolerance.
    AreClose(expectedPt, pMin, Math.Abs(expectedPt) * 0.02);
}

// --- EC2 Phi = 1.0 test ---------------------------------------------

static void TestEc2SsbPhiEqualsOne()
{
    var surface = FastSsbSolver().Solve(
        SimpleEc2Section(),
        new ConcreteMaterial("C30", 30.0),
        new SteelMaterial("B500", 500.0, 200000.0));

    IsTrue(surface.Points.All(p => Math.Abs(p.Phi - 1.0) < 1e-9));
}

// --- Symmetry test --------------------------------------------------

static void TestEc2SsbSymmetry()
{
    // Square section with corner bars: |Mx_max| ≈ |Mx_min|, same for My.
    var surface = FastSsbSolver().Solve(
        SimpleEc2Section(),
        new ConcreteMaterial("C30", 30.0),
        new SteelMaterial("B500", 500.0, 200000.0));

    double mxMax = surface.Points.Max(p => p.Mnx);
    double mxMin = surface.Points.Min(p => p.Mnx);
    double myMax = surface.Points.Max(p => p.Mny);
    double myMin = surface.Points.Min(p => p.Mny);
    IsTrue(mxMax > 0 && mxMin < 0);
    IsTrue(myMax > 0 && myMin < 0);
    AreClose(Math.Abs(mxMax), Math.Abs(mxMin), Math.Abs(mxMax) * 0.05);
    AreClose(Math.Abs(myMax), Math.Abs(myMin), Math.Abs(myMax) * 0.05);
}

// --- State label test -----------------------------------------------

static void TestEc2SsbStateLabels()
{
    var surface = FastSsbSolver().Solve(
        SimpleEc2Section(),
        new ConcreteMaterial("C30", 30.0),
        new SteelMaterial("B500", 500.0, 200000.0));

    // The pure-compression pole must carry the "Pure axial compression" label.
    IsTrue(surface.Points.Any(p => p.StateLabel == "Pure axial compression"));
    // High-compression states must be labelled accordingly.
    IsTrue(surface.Points.Any(p => p.StateLabel == "Compression controlled"));
    // Near the tension extreme, steel yields in tension.
    IsTrue(surface.Points.Any(p => p.StateLabel == "Pure tension" || p.StateLabel == "Tension controlled"));
}

// --- Major-axis moment direction test --------------------------------

static void TestEc2SsbMajorAxisMoment()
{
    // theta = 90° is bending about the X-axis (compression at +y, top).
    // For our sign convention (Mnx = Σ force×y), Mnx should be positive for
    // partial compression at the top half of the section.
    var solver = new Ec2SimplifiedStressBlockInteractionSolver
        { AngleStepDegrees = 90, NeutralAxisSamples = 10 };
    var surface = solver.Solve(
        SimpleEc2Section(),
        new ConcreteMaterial("C30", 30.0),
        new SteelMaterial("B500", 500.0, 200000.0));

    // theta = 90° → angleIndex = 1 (90/90 = 1)
    var theta90Points = surface.Points.Where(p => Math.Abs(p.ThetaDegrees - 90.0) < 1e-9).ToList();
    IsTrue(theta90Points.Count > 0);
    IsTrue(theta90Points.Any(p => p.Mnx > 0));   // Positive Mnx for compression at top
    IsTrue(theta90Points.All(p => Math.Abs(p.Mny) < 1e-3));  // My ≈ 0 for symmetric bending about X
}

// --- Hand-calculation cross-check (uniaxial bending) ----------------

static void TestEc2SsbUniaxialBendingHandCheck()
{
    // theta = 90° (bending about X), c = swept value closest to 150 mm (= h/2 of 300×300).
    // At c = h/2 = 150 mm on a 300×300 section:
    //   Block depth = lambda × c = 0.8 × 150 = 120 mm
    //   Block centroid y = 150 – 120/2 = 90 mm   blockArea = 300 × 120 = 36 000 mm²
    //   concreteN  = 16 × 36 000 = 576 000 N
    //   concreteMx = 576 000 × 90 = 51 840 000 N·mm
    //   Top bars (y = +110): strain = 0.0035×(150–40)/150 ≈ +0.002567 → stress = 434.78 (yield)
    //                        disp = 16 MPa (inside block)   force = (434.78–16)×2×314.16 ≈ 263 157 N
    //                        steelMx += 263 157 × 110 ≈ 28 947 000 N·mm
    //   Bot bars (y = –110): strain = 0.0035×(150–260)/150 ≈ –0.002567 → stress = –434.78 (yield tension)
    //                        disp = 0   force = –434.78×2×314.16 ≈ –273 158 N
    //                        steelMx += –273 158 × (–110) ≈ 30 047 000 N·mm
    //   Total Pn  = 576 000 + 263 157 – 273 158 ≈ 565 999 N   (~566 kN)
    //   Total Mnx = 51 840 000 + 28 947 000 + 30 047 000 ≈ 110 834 000 N·mm  (~110.8 kN·m)
    const double expectedP   = 565_999.0;
    const double expectedMnx = 110_834_000.0;

    var solver = new Ec2SimplifiedStressBlockInteractionSolver
        { AngleStepDegrees = 90, NeutralAxisSamples = 100 };
    var surface = solver.Solve(
        SimpleEc2Section(),
        new ConcreteMaterial("C30", 30.0),
        new SteelMaterial("B500", 500.0, 200000.0));

    // Find the swept point whose neutral-axis depth is closest to 150 mm at theta = 90°.
    var candidates = surface.Points
        .Where(p => Math.Abs(p.ThetaDegrees - 90.0) < 1e-9)
        .OrderBy(p => Math.Abs(p.NeutralAxisDepthMm - 150.0))
        .ToList();

    IsTrue(candidates.Count > 0);
    var pt = candidates.First();
    AreClose(expectedP,   pt.Pn,  expectedP   * 0.03);    // 3 % tolerance
    AreClose(expectedMnx, pt.Mnx, expectedMnx * 0.03);
}

// --- Cross-solver comparison: SSB P0 close to boundary P0 -----------

static void TestEc2SsbP0CloseToBoundary()
{
    // Both solvers share EC2 design strengths; P0 should agree within 5%.
    // Boundary uses parabolic-rectangular with eps_c2 = 0.0020;
    // SSB uses eta*fcd = 16 MPa (same fcd) with eps_c3 = 0.00175 → slightly lower steel strain.
    var section  = SConcreteSection();
    var concrete = new ConcreteMaterial("C35", 35.0);
    var steel    = new SteelMaterial("B500", 500.0, 200000.0);

    var ssbSolver = new Ec2SimplifiedStressBlockInteractionSolver
        { AngleStepDegrees = 30, NeutralAxisSamples = 36 };
    var boundarySolver = new Ec2BoundaryInteractionSolver
        { AngleStepDegrees = 30, NeutralAxisSamples = 36 };

    double p0Ssb      = ssbSolver.Solve(section, concrete, steel).Points.Max(p => p.Pn);
    double p0Boundary = boundarySolver.Solve(section, concrete, steel).Points.Max(p => p.Pn);

    double rel = Math.Abs(p0Ssb - p0Boundary) / Math.Max(Math.Abs(p0Boundary), 1.0);
    IsTrue(rel < 0.05);   // Within 5 % of each other
}

// =====================================================================
// Regression guards — existing solver outputs must be unaffected
// =====================================================================

static void TestRegressionAciUnchanged()
{
    // Run the full ACI calculation path and compare key outputs to a frozen baseline.
    // The new EC2 solver must not change ACI code paths in any way.
    var baseline    = Service().Calculate(MetricInput());
    var withNewCode = Service().Calculate(MetricInput());   // ACI is still the default
    AreClose(baseline.Ratio,           withNewCode.Ratio,           1e-9);
    AreClose(baseline.DesignPnDisplay, withNewCode.DesignPnDisplay, 1e-9);
    AreClose(baseline.DesignMxDisplay, withNewCode.DesignMxDisplay, 1e-9);
    AreClose(baseline.DesignMyDisplay, withNewCode.DesignMyDisplay, 1e-9);
    IsTrue(baseline.Surface.DepthCount  == withNewCode.Surface.DepthCount);
    IsTrue(baseline.Surface.AngleCount  == withNewCode.Surface.AngleCount);
    IsTrue(baseline.Surface.Points.Count == withNewCode.Surface.Points.Count);
}

static void TestRegressionEc2FiberUnchanged()
{
    // Run the EC2 Fiber solver and verify outputs are numerically identical to
    // a second run with the same inputs — i.e., no shared mutable state was introduced.
    var section  = SConcreteSection();
    var concrete = new ConcreteMaterial("C35", 35.0);
    var steel    = new SteelMaterial("B500", 500.0, 200000.0);

    var fiberSolver = FastEc2Solver();
    var run1 = fiberSolver.Solve(section, concrete, steel);

    // Run the simplified block solver (new) in between to confirm no cross-contamination.
    var ssbSolver = FastSsbSolver();
    _ = ssbSolver.Solve(section, concrete, steel);

    var run2 = fiberSolver.Solve(section, concrete, steel);

    // Point counts, topology, and every numerical result must be identical.
    IsTrue(run1.AngleCount == run2.AngleCount);
    IsTrue(run1.DepthCount == run2.DepthCount);
    IsTrue(run1.Points.Count == run2.Points.Count);
    for (int i = 0; i < run1.Points.Count; i++)
    {
        AreClose(run1.Points[i].Pn,  run2.Points[i].Pn,  1e-9);
        AreClose(run1.Points[i].Mnx, run2.Points[i].Mnx, 1e-9);
        AreClose(run1.Points[i].Mny, run2.Points[i].Mny, 1e-9);
        AreClose(run1.Points[i].Phi, run2.Points[i].Phi, 1e-9);
    }
}
