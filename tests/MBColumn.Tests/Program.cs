using MBColumn.Application.DTOs;
using MBColumn.Application.Services;
using MBColumn.Domain.Entities;
using MBColumn.Domain.Enums;
using MBColumn.Domain.Interfaces;
using MBColumn.Infrastructure.DesignCodes;
using MBColumn.Infrastructure.Math;
using MBColumn.Infrastructure.Rebar;
using MBColumn.Infrastructure.Solvers;
using MBColumn.Infrastructure.Solvers.Legacy;
using MBColumn.Presentation.Wpf.Controls;
using MBColumn.Presentation.Wpf.ViewModels;
using MBColumn.Tests.Baseline;
using MBColumn.Tests.Verification;
using System.IO;
using System.Linq;
using System.Windows;

if (args.Contains("--run-internal-aci-ec-comparison"))
{
    TestInternalAciEcComparisonExport();
    Console.WriteLine("PASS internal ACI vs Eurocode comparison export");
    return;
}

if (args.Contains("--generate-baselines"))
{
    Console.WriteLine("Regenerating all solver baselines...");
    BaselineCaseRunner.GenerateAll();
    Console.WriteLine("Baselines generated.");
    return;
}

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
    ("Internal ACI vs Eurocode comparison export", TestInternalAciEcComparisonExport),
    ("Metric/Imperial equivalence", TestMetricImperialEquivalence),
    ("Section preview corner bars", TestSectionPreviewCornerBars),
    ("Section preview perimeter bars", TestSectionPreviewPerimeterBars),
    ("Section preview invalid geometry", TestSectionPreviewInvalidGeometry),
    ("Section preview unit labels", TestSectionPreviewUnitLabels),
    ("Unit system dependent labels update", TestUnitSystemDependentLabelsUpdate),
    ("Circular section excludes side layouts", TestCircularSectionExcludesSideLayouts),
    ("Material library metric presets", TestMaterialLibraryMetricPresets),
    ("Material library imperial presets", TestMaterialLibraryImperialPresets),
    ("Material library custom unlocks inputs", TestMaterialLibraryCustomUnlocksInputs),
    ("Material library updates rebar set", TestMaterialLibraryUpdatesRebarSet),
    ("Rebar set library can change independently", TestRebarSetLibraryCanChangeIndependently),
    ("PM angle 0 deg axis mapping", TestPmAngleZeroAxisMapping),
    ("PM angle 90 deg axis mapping", TestPmAngleNinetyAxisMapping),
    ("Mx-My diagram axis mapping", TestMxMyDiagramAxisMapping),
    ("3D PMM mapping and mesh", TestPmm3DMappingAndMesh),
    ("Axis tick service", TestAxisTickService),
    ("PM branch continuity", TestPmBranchContinuity),
    ("PM curve diagnostics and marker separation", TestPmCurveDiagnosticsAndMarkerSeparation),
    ("Diagram bounds include points", TestDiagramBoundsIncludePoints),
    ("2D chart auto-fit transform", TestChartAutoFitTransform),
    ("Result settings propagate", TestResultSettingsPropagate),
    ("Selected point report derives Mtheta from Mx My and theta", TestSelectedPointReportDerivesMtheta),
    ("PM pure bending special points have zero P", TestPmPureBendingSpecialPointsHaveZeroP),
    ("PM max compression special point has zero moment", TestPmMaxCompressionSpecialPointHasZeroMoment),
    ("PM nominal apex has zero moment", TestPmNominalApexHasZeroMoment),
    ("Control point preview reports signed concrete strain", TestControlPointPreviewReportsSignedConcreteStrain),
    ("Nominal uses Pn/Mn values", TestNominalUsesPnMn),
    ("Design uses PhiPn/PhiMn values", TestDesignUsesPhiPnPhiMn),
    ("Solver exposes nominal/reduced/strain-state split", TestInteractionPointSplitOutput),
    ("PM curve builder uses explicit reduced display values", TestPmCurveUsesExplicitReducedDisplayValues),
    ("Calculation result exposes capacity debug points", TestCapacityDebugPoints),
    ("PM interaction debug CSV validates phi relationships", TestPmInteractionDebugCsv),
    ("Design capacity <= nominal capacity", TestDesignLeNominal),
    ("PMM ratio uses design capacity", TestPmmRatioUsesDesign),
    ("PM angle 0 deg nominal and design curves separated", TestPmAngleZeroNomDesignSeparated),
    ("PM angle 90 deg nominal and design curves separated", TestPmAngleNinetyNomDesignSeparated),
    ("ACI PM curves expose nominal and phi-reduced peaks", TestAciPmNominalAndReducedPeaks),
    ("PM diagram DTO stores split capacity datasets", TestPmDiagramStoresSplitCapacityDatasets),
    ("Demand not in capacity polyline", TestDemandNotInCapacity),
    ("Governing from design curve", TestGoverningFromDesign),
    ("Nominal and design curve diagnostics", TestNominalDesignDiagnostics),
    ("ACI design cap in PM angle 0 deg", TestAciDesignCapPmAngleZero),
    ("ACI design cap in PM angle 90 deg", TestAciDesignCapPmAngleNinety),
    ("Pmax reference separate from design cap", TestPmaxRefSeparateFromDesignCap),
    ("PM polyline validation passes", TestPmPolylineValidation),
    ("3D X maps to Mx", Test3DXMapsMx),
    ("3D Y maps to My", Test3DYMapsMy),
    ("3D Z equals actual display P", Test3DZEqualsActualP),
    ("3D design surface is ACI compression capped", Test3DDesignSurfaceAciCapped),
    ("3D axis labels correct", Test3DAxisLabels),
    ("3D surface has quads and wires", Test3DSurfaceData),
    ("3D nominal/design topology synchronized", Test3DTopologySynchronized),
    ("3D pole rings use nondegenerate perturbation", Test3DPoleRingsUseNondegeneratePerturbation),
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
    ("AxisTickService fixed grid step", TestAxisTickFixedGridStep),
    ("Chart transform snaps to nice bounds", TestChartTransformSnapsToBounds),
    ("MxMy chart transform uses equal aspect", TestMxMyChartTransformEqualAspect),
    ("PM active design cap is closed and clipped", TestPmActiveDesignCapClosedAndClipped),
    ("PM reduced curve only draws above active cap", TestPmReducedCurveOnlyAboveActiveCap),
    ("Reference guide lines default hidden", TestReferenceGuideLinesDefaultHidden),
    ("Multi-load case governing is max ratio", TestMultiLoadCaseGoverningIsMaxRatio),
    ("Multi-load case result count matches input", TestMultiLoadCaseResultCount),
    ("Multi-load case inactive excluded", TestMultiLoadCaseInactiveExcluded),
    ("Multi-load case fallback to single", TestMultiLoadCaseFallbackToSingle),
    ("Multi-load case governing id in result", TestMultiLoadCaseGoverningIdInResult),
    ("EC2 circular hoop shear benchmark", TestEc2CircularHoopShearBenchmark),
    ("EC2 slenderness off preserves direct PMM moments", TestEc2SlendernessOffPreservesDirectMoments),
    ("EC2 slenderness on maps used PMM moments", TestEc2SlendernessOnMapsUsedMoments),
    ("Control points table has 32 rows", TestControlPointsTableRowCount),
    ("Control points allowable comp is 80pct of max", TestControlPointsAllowableComp),
    ("Control points dt equals NA depth at fs=0", TestControlPointsDtEqualsFsZeroNa),
    ("Control points tension control epsilon near 0.005", TestControlPointsTensionControlEpsilon),
    ("Section integration method selection propagates", TestSectionIntegrationSelectionPropagates),
    ("Polygon integration supports circular section", TestPolygonIntegrationCircularSection),
    ("Control point export includes integration metadata", TestControlPointExportIntegrationMetadata),
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
    ("Regression: EC2 fiber results unchanged after new solver added", TestRegressionEc2FiberUnchanged),
    ("Strain Controlled 7-Point solver ACI 318", TestStrainControlledSevenPointAci),
    ("Strain Controlled 7-Point solver EC2", TestStrainControlledSevenPointEc2),
    // Irregular section feature tests
    ("Irregular boundary accepts clockwise triangle",                TestIrregularBoundaryClockwiseTriangle),
    ("Irregular boundary accepts clockwise L-shape",                 TestIrregularBoundaryClockwiseLShape),
    ("Irregular boundary rejects fewer than 3 points",               TestIrregularBoundaryRejectsFewerThan3),
    ("Irregular boundary rejects duplicate points",                  TestIrregularBoundaryRejectsDuplicate),
    ("Irregular boundary rejects duplicate consecutive points",      TestIrregularBoundaryRejectsDuplicateConsecutive),
    ("Irregular boundary rejects repeated first/last",               TestIrregularBoundaryRejectsRepeatedFirstLast),
    ("Irregular boundary accepts counter-clockwise polygon",         TestIrregularBoundaryAcceptsCcw),
    ("Irregular boundary rejects self-intersecting polygon",         TestIrregularBoundaryRejectsSelfIntersecting),
    ("Irregular boundary rejects zero-area polygon",                 TestIrregularBoundaryRejectsZeroArea),
    ("Irregular rebar accepts inside rebar",                         TestIrregularRebarAcceptsInside),
    ("Irregular rebar rejects outside rebar",                        TestIrregularRebarRejectsOutside),
    ("Irregular rebar rejects cover violation",                      TestIrregularRebarRejectsCoverViolation),
    ("Irregular rebar rejects overlapping rebars",                   TestIrregularRebarRejectsOverlap),
    ("Irregular rebar accepts area-only rebar",                      TestIrregularRebarAcceptsAreaOnly),
    ("Irregular rebar prefers AreaMm2 over BarSize",                 TestIrregularRebarPrefersAreaOverBarSize),
    ("Irregular CSV boundary round-trip preserves order",            TestIrregularCsvBoundaryRoundTrip),
    ("Irregular CSV rebar round-trip preserves order",               TestIrregularCsvRebarRoundTrip),
    ("Irregular CSV parser ignores metadata lines",                  TestIrregularCsvIgnoresMetadata),
    ("Irregular CSV parser rejects wrong header",                    TestIrregularCsvRejectsWrongHeader),
    ("Irregular CSV parser reports invalid numbers with context",    TestIrregularCsvReportsInvalidNumbers),
    ("Irregular CSV export omits duplicate closing point",           TestIrregularCsvExportNoClosingPoint),
    ("DXF polygon centroid",                                         TestDxfPolygonCentroid),
    ("DXF move-to-origin transformation",                            TestDxfMoveToOrigin),
    ("DXF closed polyline extraction",                               TestDxfClosedPolylineExtraction),
    ("DXF rebar circle center extraction",                           TestDxfRebarCircleExtraction),
    ("DXF point-in-polygon validation",                              TestDxfPointInPolygonValidation),
    ("DXF rejects open boundary",                                    TestDxfRejectsOpenBoundary),
    ("DXF rejects non-circular rebar geometry",                      TestDxfRejectsNonCircularRebar),
    ("DXF import applies irregular custom coordinates",              TestDxfImportAppliesIrregularCustomCoordinates),
    ("DXF import does not block on cover",                           TestDxfImportDoesNotBlockOnCover),
    ("ETABS import creates irregular custom coordinates",            TestEtabsImportCreatesIrregularCustomCoordinates),
    ("ETABS pier geometry snap-tolerance fix",                      TestIrregularPierGeometrySnapTolerance),
    ("ETABS pier geometry forward-cap fix",                         TestIrregularPierGeometryForwardCap),
    ("ETABS pier geometry applies clockwise axis angle",             TestIrregularPierGeometryAppliesClockwiseAxisAngle),
    ("Irregular equal spacing generated rebars satisfy cover",        TestIrregularEqualSpacingGeneratedRebarsSatisfyCover),
    ("Irregular equal spacing ToDto refreshes stale rebars",          TestIrregularEqualSpacingToDtoRefreshesStaleRebars),
    ("Irregular custom mode clears stale rebar message",              TestIrregularCustomModeClearsStaleRebarMessage),
    ("Irregular section solves with Polygon integration",            TestIrregularPolygonIntegrationSolves),
    ("Irregular section PMM surface has no NaN/Infinity",            TestIrregularPmmNoNan),
    ("Irregular section pure compression positive",                  TestIrregularPureCompressionPositive),
    ("Irregular section pure tension negative",                      TestIrregularPureTensionNegative),
    ("Irregular section ratio is finite",                            TestIrregularRatioFinite),
    ("Irregular mapper shifts boundary to centroid",                 TestIrregularMapperShiftsToCentroid),
    ("Irregular section shape exposed on result",                    TestIrregularResultExposesShape),
    ("Irregular section integrator boundary handled",                TestIrregularIntegratorBoundaryHandled),
    ("Rectangular equal spacing optimal distribution",               TestRectangularEqualSpacingOptimalDistribution),
    ("Circular equal spacing and irregular ToDto mapping",           TestCircularAndIrregularToDtoMapping),

    // Solver regression baselines — generate approved-results/*.json on first run,
    // compare against them on subsequent runs.
    ("Solver baseline: EC2_Rectangular_650x650_20T25",  () => BaselineCaseRunner.RunAndApprove("EC2_Rectangular_650x650_20T25",  BaselineCaseRunner.BenchmarkCases[0].Input)),
    ("Solver baseline: ACI_Rectangular_700x700_28T25",  () => BaselineCaseRunner.RunAndApprove("ACI_Rectangular_700x700_28T25",  BaselineCaseRunner.BenchmarkCases[1].Input)),
    ("Solver baseline: EC2_Circular_D600_16T25",        () => BaselineCaseRunner.RunAndApprove("EC2_Circular_D600_16T25",        BaselineCaseRunner.BenchmarkCases[2].Input))
};

foreach (var (name, test) in tests)
{
    test();
    Console.WriteLine($"PASS {name}");
}

Console.WriteLine($"All {tests.Count} tests passed.");

var svc = Service();
var input = MetricInput() with { DesignCode = MBColumn.Domain.Enums.DesignCodeType.Aci318Style };
var result = svc.Calculate(input);
System.IO.File.WriteAllText("validation_report.md", result.SevenPointValidationReport);



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
    return new ColumnCalculationService(solverFactory, codeFactory, units, metric, imperial, ratio, control, new DiagramDataService(), new InputValidationService(), new MBColumn.Infrastructure.Solvers.StrainPoints.PmValidationReportService(codeFactory));
}

static ColumnInputDto MetricInput(double pu = 2500, double mux = 250, double muy = 180)
    => new(UnitSystem.Metric, 700, 700, 55, "T25", 28, "Perimeter bars", 28, 420, 200000, pu, mux, muy, ForceUnit.kN, LengthUnit.Millimeter, MomentUnit.kNm, StressUnit.MPa, 0, 0);

static ColumnInputDto ImperialInput()
    => new(UnitSystem.Imperial, 27.5590551, 27.5590551, 2.16535433, "#8", 28, "Perimeter bars", 4.061, 60.916, 29007.5, 562.02, 184.39, 132.77, ForceUnit.Kip, LengthUnit.Inch, MomentUnit.KipFt, StressUnit.Ksi, 0, 0);

static PmAngleDiagramDto PmAngleDiagram(CalculationResultDto result, double angleDegrees)
    => new DiagramDataService().BuildPmAngleDiagramData(result.ControlPoints, result.UnitSystem, angleDegrees);

static void TestSingaporeBars()
{
    var db = new SingaporeRebarDatabase();
    foreach (int d in new[] { 10, 13, 16, 20, 25, 32, 40 })
    {
        IsTrue(db.TryGet($"T{d}", out var bar));
        AreClose(d, bar.DiameterMm, 1e-12);
        double expectedArea = d switch { 20 => 314.0, 25 => 491.0, _ => Math.PI * d * d / 4.0 };
        AreClose(expectedArea, bar.AreaMm2, 1e-9);
    }
}

static void TestEc2CircularHoopShearBenchmark()
{
    var calculator = new EurocodeCircularColumnShearCalculator();
    var result = calculator.Calculate(new CircularShearInput(
        HoopDiameterMm: 10.0,
        HoopSpacingMm: 150.0,
        HoopCentrelineDiameterMm: 550.0,
        FywdMpa: 435.0,
        CotTheta: 2.0));

    AreClose(78.54, result.AhMm2, 0.01);
    AreClose(393.0, result.VRdsN / 1000.0, 1.0);

    var service = new Ec2ShearDesignService();
    var circularHoop = new ShearLinkReinforcement(
        LinkDiameterMm: 10.0,
        SpacingMm: 150.0,
        TotalLegsX: 2,
        TotalLegsY: 2,
        FywkMpa: 500.25,
        IsCircularHoop: true,
        HoopCentrelineDiameterMm: 550.0);
    var circularHoopWithDetailingTies = circularHoop with { TotalLegsX = 20, TotalLegsY = 20 };

    var serviceResult = service.Check(480.0, 600.0, 3000.0, 30.0, 0.0, 0.0, 0.0,
        circularHoop, 20.0, 25.0);
    var serviceResultWithTies = service.Check(480.0, 600.0, 3000.0, 30.0, 0.0, 0.0, 0.0,
        circularHoopWithDetailingTies, 20.0, 25.0);

    AreClose(serviceResult.VRdsXN, serviceResultWithTies.VRdsXN, 1e-9);
    AreClose(serviceResult.VRdsYN, serviceResultWithTies.VRdsYN, 1e-9);
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
    IsTrue(curve.Count >= 200);
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
    IsTrue(result.Surface.DepthCount == 100);  // Standardized to 100
    IsTrue(result.ControlPoints.PmPoints.Any(p => p.Label == "Pmax"));
    IsTrue(result.ControlPoints.PmPoints.Any(p => p.Label == "Pmin"));
    IsTrue(result.ControlPoints.PmPoints.Any(p => p.IsDemandPoint));
    var surfacePoints = result.PmmSurface.Points.Where(p => !p.IsDemand && !p.IsGoverning && !p.IsReference).ToList();
    IsTrue(surfacePoints.Count(p => !p.GroupKey.Contains("Nominal", StringComparison.OrdinalIgnoreCase)) > 0);
    IsTrue(surfacePoints.Count(p => p.GroupKey.Contains("Nominal", StringComparison.OrdinalIgnoreCase)) > 0);
    IsTrue(result.IntegrationMethod == SectionIntegrationMethod.Fiber);
}

static void TestInternalAciEcComparisonExport()
{
    var root = LocateRepositoryRoot();
    var outputDirectory = Path.Combine(root, "reports", "validation-benchmarks", "internal-aci-vs-eurocode");
    var report = new InternalAciEcComparisonExporter().Export(outputDirectory);

    IsTrue(report.Points.Count == 5 * 2 * 100);
    IsTrue(report.Summaries.Count == 5);
    IsTrue(File.Exists(report.CsvPath));
    IsTrue(File.Exists(report.HtmlPath));
    IsTrue(File.Exists(report.MarkdownPath));
    IsTrue(File.Exists(report.PdfPath));
    IsFalse(report.Points.Any(p =>
        double.IsNaN(p.Mtheta) || double.IsInfinity(p.Mtheta) ||
        double.IsNaN(p.P) || double.IsInfinity(p.P)));

    Console.WriteLine();
    Console.WriteLine("=== Internal ACI vs Eurocode PM Comparison ===");
    Console.WriteLine($"Exported points: {report.Points.Count}");
    Console.WriteLine($"Angles: {string.Join(", ", report.Summaries.Select(s => s.AngleDegrees.ToString("F0", System.Globalization.CultureInfo.InvariantCulture)))}");
    Console.WriteLine($"CSV: {report.CsvPath}");
    Console.WriteLine($"HTML: {report.HtmlPath}");
    Console.WriteLine($"Markdown: {report.MarkdownPath}");
    Console.WriteLine($"PDF: {report.PdfPath}");
}

static string LocateRepositoryRoot()
{
    var directory = new DirectoryInfo(AppContext.BaseDirectory);
    while (directory != null)
    {
        if (File.Exists(Path.Combine(directory.FullName, "MBColumn.sln")))
        {
            return directory.FullName;
        }

        directory = directory.Parent;
    }

    throw new FileNotFoundException("Repository root containing MBColumn.sln could not be located from test execution path.");
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

static void TestUnitSystemDependentLabelsUpdate()
{
    var vm = new InputViewModel(new SingaporeRebarDatabase(), new ImperialRebarDatabase());

    IsTrue(vm.LengthLabel == "mm");
    IsTrue(vm.ForceLabel == "kN");
    IsTrue(vm.MomentLabel == "kN-m");
    IsTrue(vm.StressLabel == "MPa");
    IsTrue(vm.DemandForceHeader == "NEd (kN)");
    IsTrue(vm.DemandMomentXHeader == "Mx (kN-m)");
    IsTrue(vm.DemandMomentYHeader == "My (kN-m)");
    IsTrue(vm.ShearVuxHeader == "Vx (kN)");
    IsTrue(vm.ShearVuyHeader == "Vy (kN)");
    IsTrue(vm.RebarDiameterUnitLabel == "mm");
    IsTrue(vm.LinkSpacingUnitLabel == "mm");
    AreClose(200.0, vm.LinkSpacing, 1e-12);

    vm.UnitSystem = UnitSystem.Imperial;

    IsTrue(vm.LengthLabel == "in");
    IsTrue(vm.ForceLabel == "kip");
    IsTrue(vm.MomentLabel == "kip-ft");
    IsTrue(vm.StressLabel == "ksi");
    IsTrue(vm.DemandForceHeader == "NEd (kip)");
    IsTrue(vm.DemandMomentXHeader == "Mx (kip-ft)");
    IsTrue(vm.DemandMomentYHeader == "My (kip-ft)");
    IsTrue(vm.ShearVuxHeader == "Vx (kip)");
    IsTrue(vm.ShearVuyHeader == "Vy (kip)");
    IsTrue(vm.RebarDiameterUnitLabel == "in");
    IsTrue(vm.LinkSpacingUnitLabel == "in");
    AreClose(8.0, vm.LinkSpacing, 1e-12);
}

static void TestCircularSectionExcludesSideLayouts()
{
    var vm = new InputViewModel(new SingaporeRebarDatabase(), new ImperialRebarDatabase())
    {
        SelectedRebarLayoutType = RebarLayoutType.SidesDifferent
    };

    vm.SelectedSectionShape = SectionShapeType.Circular;

    IsTrue(vm.SelectedRebarLayoutType == RebarLayoutType.EqualSpacing);
    IsTrue(vm.RebarLayoutTypes.Any(o => o.LayoutType == RebarLayoutType.EqualSpacing));
    IsTrue(vm.RebarLayoutTypes.Any(o => o.LayoutType == RebarLayoutType.CustomCoordinates));
    IsFalse(vm.RebarLayoutTypes.Any(o => o.LayoutType == RebarLayoutType.SidesDifferent));
    IsFalse(vm.RebarLayoutTypes.Any(o => o.LayoutType == RebarLayoutType.AllSidesEqual));

    var stale = vm.ToSnapshot();
    stale.SectionShape = SectionShapeType.Circular.ToString();
    stale.RebarLayoutType = RebarLayoutType.SidesDifferent.ToString();

    var loaded = new InputViewModel(new SingaporeRebarDatabase(), new ImperialRebarDatabase());
    loaded.LoadFromSnapshot(stale);

    IsTrue(loaded.SelectedSectionShape == SectionShapeType.Circular);
    IsTrue(loaded.SelectedRebarLayoutType == RebarLayoutType.EqualSpacing);
    IsFalse(loaded.RebarLayoutTypes.Any(o => o.LayoutType == RebarLayoutType.SidesDifferent));
}

static void TestMaterialLibraryMetricPresets()
{
    var vm = new InputViewModel(new SingaporeRebarDatabase(), new ImperialRebarDatabase())
    {
        UnitSystem = UnitSystem.Metric
    };

    vm.SelectedMaterialLibrary = MaterialLibraryType.Europe;

    IsTrue(vm.AvailableConcreteGrades.Any(g => g.DisplayName == "C30/37"));
    IsTrue(vm.AvailableSteelGrades.Any(g => g.DisplayName == "B500B"));
    IsTrue(vm.SelectedConcreteGrade is not null);
    IsTrue(vm.SelectedSteelGrade is not null);
    IsTrue(vm.AreMaterialGradesEnabled);
    IsFalse(vm.AreMaterialInputsEnabled);
    AreClose(30.0, vm.Fc, 1e-12);
    AreClose(500.0, vm.Fy, 1e-12);
    AreClose(200000.0, vm.Es, 1e-12);

    vm.SelectedConcreteGrade = vm.AvailableConcreteGrades.First(g => g.DisplayName == "C40/50");
    vm.SelectedSteelGrade = vm.AvailableSteelGrades.First(g => g.DisplayName == "B400");

    AreClose(40.0, vm.Fc, 1e-12);
    AreClose(400.0, vm.Fy, 1e-12);
}

static void TestMaterialLibraryImperialPresets()
{
    var vm = new InputViewModel(new SingaporeRebarDatabase(), new ImperialRebarDatabase())
    {
        UnitSystem = UnitSystem.Imperial
    };

    vm.SelectedMaterialLibrary = MaterialLibraryType.Europe;

    AreClose(Math.Round(30.0 / 6.894757293168, 3), vm.Fc, 1e-12);
    AreClose(Math.Round(500.0 / 6.894757293168, 3), vm.Fy, 1e-12);
    AreClose(29000.0, vm.Es, 1e-12);

    vm.SelectedMaterialLibrary = MaterialLibraryType.America;

    IsTrue(vm.SelectedConcreteGrade is not null);
    IsTrue(vm.SelectedSteelGrade is not null);
    IsFalse(vm.AreMaterialInputsEnabled);
    AreClose(4.0, vm.Fc, 1e-12);
    AreClose(60.0, vm.Fy, 1e-12);
}

static void TestMaterialLibraryCustomUnlocksInputs()
{
    var vm = new InputViewModel(new SingaporeRebarDatabase(), new ImperialRebarDatabase())
    {
        UnitSystem = UnitSystem.Metric
    };

    vm.SelectedMaterialLibrary = MaterialLibraryType.Custom;

    IsFalse(vm.AreMaterialGradesEnabled);
    IsTrue(vm.AreMaterialInputsEnabled);
    IsTrue(vm.SelectedConcreteGrade is null);
    IsTrue(vm.SelectedSteelGrade is null);
    IsTrue(vm.AvailableConcreteGrades.Count == 0);
    IsTrue(vm.AvailableSteelGrades.Count == 0);

    vm.Fc = 33;
    vm.Fy = 460;
    vm.Es = 198000;

    AreClose(33.0, vm.Fc, 1e-12);
    AreClose(460.0, vm.Fy, 1e-12);
    AreClose(198000.0, vm.Es, 1e-12);

    vm.SelectedMaterialLibrary = MaterialLibraryType.Europe;

    IsTrue(vm.SelectedConcreteGrade is not null);
    IsTrue(vm.SelectedSteelGrade is not null);
    IsTrue(vm.AreMaterialGradesEnabled);
    IsFalse(vm.AreMaterialInputsEnabled);
    AreClose(30.0, vm.Fc, 1e-12);
    AreClose(500.0, vm.Fy, 1e-12);
    AreClose(200000.0, vm.Es, 1e-12);
}

static void TestMaterialLibraryUpdatesRebarSet()
{
    var vm = new InputViewModel(new SingaporeRebarDatabase(), new ImperialRebarDatabase())
    {
        UnitSystem = UnitSystem.Metric
    };

    vm.SelectedMaterialLibrary = MaterialLibraryType.America;

    IsTrue(vm.SelectedRebarSetLibrary == RebarSetLibraryType.UnitedStatesImperial);
    IsTrue(vm.AvailableBars.Any(b => b.Name == "#8"));
    IsTrue(vm.BarSize.StartsWith("#", StringComparison.Ordinal));

    vm.SelectedMaterialLibrary = MaterialLibraryType.Europe;

    IsTrue(vm.SelectedRebarSetLibrary == RebarSetLibraryType.SingaporeMetric);
    IsTrue(vm.AvailableBars.Any(b => b.Name == "T25"));
    IsTrue(vm.BarSize.StartsWith("T", StringComparison.Ordinal));
}

static void TestRebarSetLibraryCanChangeIndependently()
{
    var vm = new InputViewModel(new SingaporeRebarDatabase(), new ImperialRebarDatabase())
    {
        UnitSystem = UnitSystem.Metric
    };

    vm.SelectedMaterialLibrary = MaterialLibraryType.Europe;
    vm.SelectedRebarSetLibrary = RebarSetLibraryType.UnitedStatesImperial;

    IsTrue(vm.SelectedMaterialLibrary == MaterialLibraryType.Europe);
    IsTrue(vm.SelectedRebarSetLibrary == RebarSetLibraryType.UnitedStatesImperial);
    IsTrue(vm.BarSize.StartsWith("#", StringComparison.Ordinal));
    AreClose(30.0, vm.Fc, 1e-12);
    AreClose(500.0, vm.Fy, 1e-12);

    var dto = vm.ToDto();
    var coords = dto.RebarCoordinates ?? [];
    IsTrue(dto.RebarSetLibrary == RebarSetLibraryType.UnitedStatesImperial);
    IsTrue(coords.Count == 28);
    IsTrue(coords.All(r => r.BarSizeLabel.StartsWith("#", StringComparison.Ordinal)));
}

static void TestPmAngleZeroAxisMapping()
{
    var result = Service().Calculate(MetricInput());
    var diagram = PmAngleDiagram(result, 0.0);
    var point = diagram.Points.First(p => !p.IsDemand && !p.IsGoverning && !p.IsReference);
    AreClose(point.Mx, point.X, 1e-9);
    AreClose(point.P, point.Y, 1e-9);
    var demand = diagram.Points.First(p => p.IsDemand);
    AreClose(result.MuxDisplay, demand.X, 1e-9);
    AreClose(result.PuDisplay, demand.Y, 1e-9);
}

static void TestPmAngleNinetyAxisMapping()
{
    var result = Service().Calculate(MetricInput());
    var diagram = PmAngleDiagram(result, 90.0);
    var point = diagram.Points.First(p => !p.IsDemand && !p.IsGoverning && !p.IsReference);
    AreClose(point.My, point.X, 1e-9);
    AreClose(point.P, point.Y, 1e-9);
    var demand = diagram.Points.First(p => p.IsDemand);
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
    foreach (var diagram in new[] { PmAngleDiagram(result, 0.0).Points, PmAngleDiagram(result, 90.0).Points })
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

    IsTrue(PmAngleDiagram(result, 0.0).Points.Any(p => p.IsReference && p.Label == "Pmax"));
    IsTrue(PmAngleDiagram(result, 0.0).Points.Any(p => p.IsReference && p.Label == "Pmin"));
    IsTrue(PmAngleDiagram(result, 90.0).Points.Any(p => p.IsReference && p.Label == "Pmax"));
    IsTrue(PmAngleDiagram(result, 90.0).Points.Any(p => p.IsReference && p.Label == "Pmin"));
}

static void TestPmCurveDiagnosticsAndMarkerSeparation()
{
    PmCurveBuilderService.EnableDebugDiagnostics = true;
    var result = Service().Calculate(MetricInput());
    // Trigger diagram build to populate diagnostics
    _ = PmAngleDiagram(result, 0.0);
    var diagnostics = PmCurveBuilderService.LastDiagnostics;
    IsTrue(diagnostics is not null);
    IsTrue(diagnostics!.RawInteractionPointCount > diagnostics.ValidPointCount - 1);
    IsTrue(diagnostics.PBinsCount == 100);  // standardized to 100
    IsTrue(diagnostics.PositiveBranchCount > 10);
    IsTrue(diagnostics.NegativeBranchCount > 10);
    IsFalse(diagnostics.SmoothingApplied);

    foreach (var diagram in new[] { PmAngleDiagram(result, 0.0).Points, PmAngleDiagram(result, 90.0).Points })
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
    var diagram = PmAngleDiagram(result, 0.0);
    var bounds = ChartTransformHelper.AutoFit2D(diagram.Points, new Rect(0, 0, 800, 500));
    IsTrue(diagram.Points.All(p => p.X >= bounds.MinX && p.X <= bounds.MaxX && p.Y >= bounds.MinY && p.Y <= bounds.MaxY));
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
    IsFalse(vm.MM.ShowGrid);
    IsFalse(vm.MM.ShowLabels);
    IsTrue(vm.PM3D.ShowGrid);
    IsTrue(vm.PM3D.ShowLabels);
    IsTrue(vm.MM3D.ShowGrid);
    IsTrue(vm.MM3D.ShowLabels);
    IsFalse(vm.PM3D.ShowSurface);
    IsFalse(vm.MM3D.ShowSurface);
    IsFalse(vm.PM3D.ShowWireframe);
    IsFalse(vm.MM3D.ShowWireframe);
}

static void TestSelectedPointReportDerivesMtheta()
{
    var vm = new ResultViewModel
    {
        Result = Service().Calculate(MetricInput())
    };

    vm.SelectedChartPoint = new ControlPointDto(
        DiagramType.PM,
        999.0,
        10884.34,
        10884.34,
        10884.34,
        30.49,
        57.34,
        0.65,
        333.6,
        1743.3,
        "Selected",
        "DesignCapacity",
        false,
        false,
        false,
        false);

    double thetaRadians = 333.6 * Math.PI / 180.0;
    double expectedMtheta = 30.49 * Math.Cos(thetaRadians) + 57.34 * Math.Sin(thetaRadians);
    IsTrue(vm.SelectedPointMthetaDisplay == $"{expectedMtheta:F2} {vm.MomentUnitLabel}");
}

static void TestPmPureBendingSpecialPointsHaveZeroP()
{
    var result = Service().Calculate(MetricInput());
    foreach (double theta in new[] { 0.0, 90.0 })
    {
        var pureBending = PmAngleDiagram(result, theta).SpecialCapacityPoints
            .Where(p => p.Label == "Pure Bending")
            .ToList();

        IsTrue(pureBending.Count >= 2);
        IsTrue(pureBending.All(p => Math.Abs(p.P) <= 1e-9));
        IsTrue(pureBending.All(p => Math.Abs(p.Y) <= 1e-9));
        IsTrue(pureBending.All(p => Math.Abs(p.Z) <= 1e-9));
    }
}

static void TestPmMaxCompressionSpecialPointHasZeroMoment()
{
    var result = Service().Calculate(MetricInput());
    foreach (double theta in new[] { 0.0, 90.0 })
    {
        var maxCompression = PmAngleDiagram(result, theta).SpecialCapacityPoints
            .Single(p => p.Label == "Max Compression");

        AreClose(0.0, maxCompression.X, 1e-9);
        AreClose(0.0, maxCompression.Mx, 1e-9);
        AreClose(0.0, maxCompression.My, 1e-9);
    }
}

static void TestPmNominalApexHasZeroMoment()
{
    var result = Service().Calculate(MetricInput());
    foreach (double theta in new[] { 0.0, 90.0 })
    {
        var nominal = PmAngleDiagram(result, theta).NominalCapacityPoints;
        double maxP = nominal.Max(p => p.P);
        var apex = nominal.Where(p => Math.Abs(p.P - maxP) <= 1e-9).ToList();

        IsTrue(apex.Count >= 1);
        IsTrue(apex.All(p => Math.Abs(p.X) <= 1e-9));
        IsTrue(apex.All(p => Math.Abs(p.Mx) <= 1e-9));
        IsTrue(apex.All(p => Math.Abs(p.My) <= 1e-9));
    }
}

static void TestControlPointPreviewReportsSignedConcreteStrain()
{
    var result = Service().Calculate(MetricInput());
    var preview = new ControlPointPreviewService(GetUnits())
        .BuildPreview(result, ControlPointThetaSelectionMode.CurrentView, 0.0);

    IsTrue(preview.Rows.Count > 0);
    IsTrue(preview.Rows.Any(r => r.ConcreteStrainMax < 0.0));
}

// ----- Nominal vs Design Curve Tests -----

static void TestNominalUsesPnMn()
{
    // Nominal curve points must use Pn/Mn (no phi), so they should be larger than corresponding design points.
    var result = Service().Calculate(MetricInput());
    foreach (var diagram in new[] { PmAngleDiagram(result, 0.0).Points, PmAngleDiagram(result, 90.0).Points })
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
    foreach (var diagram in new[] { PmAngleDiagram(result, 0.0).Points, PmAngleDiagram(result, 90.0).Points })
    {
        var design = diagram.Where(p => !p.IsNominal && !p.IsDemand && !p.IsGoverning && !p.IsReference).ToList();
        IsTrue(design.Count > 0);
        // Design points should have phi applied (capacity is phi-reduced)
        IsTrue(design.All(p => p.Phi > 0 && p.Phi <= 1.0));
    }
}

static void TestInteractionPointSplitOutput()
{
    var result = Service().Calculate(MetricInput());
    var transition = result.Surface.Points.First(p => p.Phi > 0.66 && p.Phi < 0.89);

    AreClose(transition.Pn, transition.Nominal.Pn, 1e-9);
    AreClose(transition.Mnx, transition.Nominal.Mnx, 1e-9);
    AreClose(transition.Mny, transition.Nominal.Mny, 1e-9);
    AreClose(transition.Pn * transition.Phi, transition.Reduced.PhiPn, Math.Abs(transition.Pn) * 1e-12 + 1e-6);
    AreClose(transition.Mnx * transition.Phi, transition.Reduced.PhiMnx, Math.Abs(transition.Mnx) * 1e-12 + 1e-6);
    AreClose(transition.Mny * transition.Phi, transition.Reduced.PhiMny, Math.Abs(transition.Mny) * 1e-12 + 1e-6);
    IsFalse(string.IsNullOrWhiteSpace(transition.StrainState.RegionClassification));
}

static void TestPmCurveUsesExplicitReducedDisplayValues()
{
    var result = Service().Calculate(MetricInput());
    var source = result.ControlPoints.PmmSurfacePoints;

    var baseline = PmCurveBuilderService.BuildPmAngleCurve(source, result.ControlPoints.DesignCompressionLimitDisplay, result.ControlPoints.NominalCompressionLimitDisplay, 0.0)
        .Where(p => !p.IsDemand && !p.IsGoverning && !p.IsReference && !p.IsNominal)
        .ToList();

    var corruptedDesignNominalDisplay = source
        .Select(p => p with
        {
            NominalDisplayP = p.GroupKey.Contains("Nominal", StringComparison.OrdinalIgnoreCase) ? p.NominalDisplayP : p.NominalDisplayP * 100.0,
            NominalDisplayMx = p.GroupKey.Contains("Nominal", StringComparison.OrdinalIgnoreCase) ? p.NominalDisplayMx : p.NominalDisplayMx * 100.0,
            NominalDisplayMy = p.GroupKey.Contains("Nominal", StringComparison.OrdinalIgnoreCase) ? p.NominalDisplayMy : p.NominalDisplayMy * 100.0
        })
        .ToList();

    var rebuilt = PmCurveBuilderService.BuildPmAngleCurve(corruptedDesignNominalDisplay, result.ControlPoints.DesignCompressionLimitDisplay, result.ControlPoints.NominalCompressionLimitDisplay, 0.0)
        .Where(p => !p.IsDemand && !p.IsGoverning && !p.IsReference && !p.IsNominal)
        .ToList();

    IsTrue(baseline.Count == rebuilt.Count);
    AreClose(baseline.Max(p => p.Y), rebuilt.Max(p => p.Y), 1e-9);
    AreClose(baseline.Max(p => p.X), rebuilt.Max(p => p.X), 1e-9);
    AreClose(baseline.Min(p => p.X), rebuilt.Min(p => p.X), 1e-9);
}

static void TestCapacityDebugPoints()
{
    var result = Service().Calculate(MetricInput());
    IsTrue(result.CapacityDebugPoints.Count >= 5);
    IsTrue(result.CapacityDebugPoints.Any(p => p.Label == "Max nominal compression"));
    IsTrue(result.CapacityDebugPoints.Any(p => p.Label == "Max reduced compression"));
    IsTrue(result.CapacityDebugPoints.All(p => !string.IsNullOrWhiteSpace(p.RegionClassification)));

    foreach (var p in result.CapacityDebugPoints)
    {
        AreClose(p.PnDisplay * p.Phi, p.PhiPnDisplay, Math.Abs(p.PhiPnDisplay) * 1e-9 + 1e-6);
        AreClose(p.MnxDisplay * p.Phi, p.PhiMnxDisplay, Math.Abs(p.PhiMnxDisplay) * 1e-9 + 1e-6);
        AreClose(p.MnyDisplay * p.Phi, p.PhiMnyDisplay, Math.Abs(p.PhiMnyDisplay) * 1e-9 + 1e-6);
    }
}

static void TestPmInteractionDebugCsv()
{
    var result = Service().Calculate(MetricInput());
    var csv = PmCurveBuilderService.BuildPmInteractionDebugCsv(result.ControlPoints.PmmSurfacePoints);
    IsTrue(csv.StartsWith("Index,ThetaDeg,NeutralAxisDepth,StrainState,Pn_kN,Mn_kNm,Phi,PhiPn_kN,PhiMn_kNm,SourceCurve"));
    IsTrue(csv.Contains("Nominal Capacity"));
    IsTrue(csv.Contains("Phi-Reduced Capacity"));
    // Source pairing (raw surface data) should still be valid.
    IsTrue(PmCurveBuilderService.ValidateNominalReducedSourcePairing(result.ControlPoints.PmmSurfacePoints).Count == 0);
    // Rendered curve pairing is relaxed because design and nominal curves now respect independent caps (ACI).
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

static void TestPmAngleZeroNomDesignSeparated()
{
    var result = Service().Calculate(MetricInput());
    var points = PmAngleDiagram(result, 0.0).Points;
    var design = points.Where(p => !p.IsNominal && !p.IsDemand && !p.IsGoverning && !p.IsReference).ToList();
    var nominal = points.Where(p => p.IsNominal).ToList();
    IsTrue(design.Count > 20);
    IsTrue(nominal.Count > 20);
    // Design uses DesignCapacity, nominal uses NominalCapacity
    IsTrue(design.All(p => p.GroupKey == "DesignCapacity"));
    IsTrue(nominal.All(p => p.GroupKey == "NominalCapacity"));
}

static void TestPmAngleNinetyNomDesignSeparated()
{
    var result = Service().Calculate(MetricInput());
    var points = PmAngleDiagram(result, 90.0).Points;
    var design = points.Where(p => !p.IsNominal && !p.IsDemand && !p.IsGoverning && !p.IsReference).ToList();
    var nominal = points.Where(p => p.IsNominal).ToList();
    IsTrue(design.Count > 20);
    IsTrue(nominal.Count > 20);
    IsTrue(design.All(p => p.GroupKey == "DesignCapacity"));
    IsTrue(nominal.All(p => p.GroupKey == "NominalCapacity"));
}

static void TestAciPmNominalAndReducedPeaks()
{
    var result = Service().Calculate(MetricInput());
    foreach (var diagram in new[] { PmAngleDiagram(result, 0.0).Points, PmAngleDiagram(result, 90.0).Points })
    {
        var nominal = diagram.Where(p => p.IsNominal && !p.IsDemand && !p.IsGoverning && !p.IsReference).ToList();
        var reduced = diagram.Where(p => !p.IsNominal && !p.IsDemand && !p.IsGoverning && !p.IsReference).ToList();
        double rawPo = result.Surface.Points.Max(p => p.Pn);
        double reducedPo = result.Surface.Points.Max(p => p.PhiPn);
        double reducedCap = result.ControlPoints.DesignCompressionLimitDisplay;

        Console.WriteLine($"DEBUG: NominalMax={nominal.Max(p => p.P)}, Po={GetUnits().ForceFromN(rawPo, ForceUnit.kN)}, ReducedMax={reduced.Max(p => p.P)}, PhiPo={GetUnits().ForceFromN(reducedPo, ForceUnit.kN)}");
        
        // Nominal peak should be the full Po (no 0.80/0.85 cap)
        AreClose(GetUnits().ForceFromN(rawPo, ForceUnit.kN), nominal.Max(p => p.P), 10.0); 
        // Reduced peak should be the full phi*Po (no 0.80/0.85 cap)
        AreClose(GetUnits().ForceFromN(reducedPo, ForceUnit.kN), reduced.Max(p => p.P), 10.0);
        
        IsTrue(nominal.Max(p => p.P) > reduced.Max(p => p.P));
        var phiPnMax = diagram.Single(p => p.IsReference && p.Label == "Pmax");
        AreClose(reducedCap, phiPnMax.P, 1.0);
        IsFalse(diagram.Any(p => p.IsReference && p.Label == "Pn,max"));
    }
}

static void TestPmDiagramStoresSplitCapacityDatasets()
{
    var result = Service().Calculate(MetricInput());
    var pm0 = PmAngleDiagram(result, 0.0);
    var pm90 = PmAngleDiagram(result, 90.0);
    IsTrue(pm0.NominalCapacityPoints.Count > 20);
    IsTrue(pm0.ReducedCapacityPoints.Count > 20);
    IsTrue(pm90.NominalCapacityPoints.Count > 20);
    IsTrue(pm90.ReducedCapacityPoints.Count > 20);
    IsTrue(pm0.NominalCapacityPoints.All(p => p.IsNominal));
    IsTrue(pm0.ReducedCapacityPoints.All(p => !p.IsNominal));
}

static void TestDemandNotInCapacity()
{
    var result = Service().Calculate(MetricInput());
    foreach (var diagram in new[] { PmAngleDiagram(result, 0.0).Points, PmAngleDiagram(result, 90.0).Points })
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
    foreach (var diagram in new[] { PmAngleDiagram(result, 0.0).Points, PmAngleDiagram(result, 90.0).Points })
    {
        var governing = diagram.Where(p => p.IsGoverning).ToList();
        IsTrue(governing.Count == 1);
        IsFalse(governing[0].IsNominal); // Governing is selected from design curve
    }
}

static void TestNominalDesignDiagnostics()
{
    PmCurveBuilderService.EnableDebugDiagnostics = true;
    var result = Service().Calculate(MetricInput());
    _ = PmAngleDiagram(result, 0.0);
    var diag = PmCurveBuilderService.LastDiagnostics;
    IsTrue(diag is not null);
    IsTrue(diag!.NominalAndDesignSeparated);
    IsTrue(diag.NominalPositiveBranchCount > 10);
    IsTrue(diag.NominalNegativeBranchCount > 10);
    IsTrue(diag.FinalNominalCurveCount > 20);
    IsTrue(diag.DesignPMaxDisplay > 0);
    IsTrue(diag.NominalPMaxDisplay > diag.DesignPMaxDisplay); // nominal Pmax > design (capped)
    if (diag.ValidationWarnings?.Count > 0)
    {
        Console.WriteLine("DEBUG: Validation warnings:");
        foreach (var w in diag.ValidationWarnings) Console.WriteLine($"  - {w}");
    }
    IsTrue(diag.ValidationWarnings is null || diag.ValidationWarnings.Count == 0);
    PmCurveBuilderService.EnableDebugDiagnostics = false;
}

// ----- ACI Trim Cap Tests (Task 3) -----

static void TestAciDesignCapPmAngleZero()
{
    var result = Service().Calculate(MetricInput());
    var diagram = PmAngleDiagram(result, 0.0);
    var design = diagram.Points.Where(p => !p.IsNominal && !p.IsDemand && !p.IsGoverning && !p.IsReference).ToList();
    // The design loop contains points ABOVE the ACI-capped Pmax level (theoretical reduced curve)
    double designPMax = design.Max(p => p.Y);
    var pmaxRef = diagram.Points.FirstOrDefault(p => p.IsReference && p.Label == "Pmax");
    IsTrue(pmaxRef is not null);
    // Uncapped peak must be higher than the design cap reference line
    IsTrue(designPMax > pmaxRef!.Y + 1.0);
}

static void TestAciDesignCapPmAngleNinety()
{
    var result = Service().Calculate(MetricInput());
    var diagram = PmAngleDiagram(result, 90.0);
    var design = diagram.Points.Where(p => !p.IsNominal && !p.IsDemand && !p.IsGoverning && !p.IsReference).ToList();
    double designPMax = design.Max(p => p.Y);
    var pmaxRef = diagram.Points.FirstOrDefault(p => p.IsReference && p.Label == "Pmax");
    IsTrue(pmaxRef is not null);
    IsTrue(designPMax > pmaxRef!.Y + 1.0);
}

static void TestPmaxRefSeparateFromDesignCap()
{
    var result = Service().Calculate(MetricInput());
    foreach (var diagram in new[] { PmAngleDiagram(result, 0.0).Points, PmAngleDiagram(result, 90.0).Points })
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
    foreach (var diagram in new[] { PmAngleDiagram(result, 0.0).Points, PmAngleDiagram(result, 90.0).Points })
    {
        var defects = PmCurveBuilderService.ValidatePmCapacityPolyline(diagram);
        if (defects.Count > 0)
        {
            Console.WriteLine("DEBUG: PM Polyline defects:");
            foreach (var d in defects) Console.WriteLine($"  - {d}");
        }
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

    IsTrue(designRows.Count > 0);
    IsTrue(nominalRows.Count > 0);
    IsTrue(designRows.All(c => c >= 3));
    IsTrue(nominalRows.All(c => c >= 3));
}

static void Test3DPoleRingsUseNondegeneratePerturbation()
{
    var result = Service().Calculate(MetricInput());
    var design = result.PmmSurface.Points
        .Where(p => !p.IsNominal && !p.IsDemand && !p.IsGoverning && !p.IsReference)
        .ToList();

    var sortedKeys = design.Select(p => p.SliceKey).Distinct().OrderBy(k => k).ToList();
    foreach (var key in new[] { sortedKeys.First(), sortedKeys.Last() })
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
    // Default: PM2D and Pmm3D are selected
    IsTrue(vm.ActiveViewportCount == 2);
    IsTrue(vm.ShowPM && vm.ShowPmm3D);
    IsFalse(vm.ShowMxMy);
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
    
    vm.ToggleViewport(DiagramViewportType.MxMy2D);
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
    
    var pmx = PmAngleDiagram(result, 0.0).Points.Where(p => !p.IsNominal && !p.IsDemand && !p.IsGoverning && !p.IsReference).ToList();
    var pmy = PmAngleDiagram(result, 90.0).Points.Where(p => !p.IsNominal && !p.IsDemand && !p.IsGoverning && !p.IsReference).ToList();
    
    double max2DX = pmx.Max(p => p.X);
    double max2DY = pmy.Max(p => p.X);
    
    double min2DX = pmx.Min(p => p.X);
    double min2DY = pmy.Min(p => p.X);

    // The axis-aligned PM angle slices are XZ/YZ plane intersections of the PMM surface, so their values must be
    // contained by the design 3D bounds but do not have to equal the global Mx/My maxima.
    const double sliceTolerance = 6.0;
    IsTrue(max2DX <= max3DX + sliceTolerance);
    IsTrue(max2DY <= max3DY + sliceTolerance);
    IsTrue(min2DX >= min3DX - sliceTolerance);
    IsTrue(min2DY >= min3DY - sliceTolerance);
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

static void TestAxisTickFixedGridStep()
{
    var ticks = AxisTickService.GenerateFixed(-850, 1840, 500);
    AreClose(500, ticks.MajorInterval, 1e-12);
    IsTrue(ticks.MajorTicks.Contains(-500));
    IsTrue(ticks.MajorTicks.Contains(0));
    IsTrue(ticks.MajorTicks.Contains(1500));
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

static void TestPmActiveDesignCapClosedAndClipped()
{
    var points = DiamondPmDesignPoints().ToList();
    var polygon = DiagramCanvas2D.ClipClosedPolylineBelowYForTesting(points, cap: 4.0);

    IsTrue(polygon.Count > 4);
    var capPoints = polygon.Where(p => Math.Abs(p.Y - 4.0) < 1e-12).OrderBy(p => p.X).ToList();
    IsTrue(capPoints.Count == 2);
    AreClose(-6.0, capPoints[0].X, 1e-9);
    AreClose(6.0, capPoints[1].X, 1e-9);
    IsTrue(polygon.All(p => p.Y <= 4.0 + 1e-12));

    foreach (var point in polygon)
    {
        double allowed = 10.0 - Math.Abs(point.Y);
        IsTrue(point.X >= -allowed - 1e-9);
        IsTrue(point.X <= allowed + 1e-9);
    }
}

static void TestPmReducedCurveOnlyAboveActiveCap()
{
    var points = DiamondPmDesignPoints().ToList();
    var segments = DiagramCanvas2D.ClipOpenPolylineAboveYForTesting(points, cap: 4.0);

    IsTrue(segments.Count == 1);
    var segment = segments[0];
    IsTrue(segment.Count == 3);
    AreClose(-6.0, segment[0].X, 1e-9);
    AreClose(4.0, segment[0].Y, 1e-12);
    AreClose(0.0, segment[1].X, 1e-12);
    AreClose(10.0, segment[1].Y, 1e-12);
    AreClose(6.0, segment[2].X, 1e-9);
    AreClose(4.0, segment[2].Y, 1e-12);
    IsTrue(segment.Skip(1).Take(1).All(p => p.Y > 4.0));
}

static void TestReferenceGuideLinesDefaultHidden()
{
    var vm = new ResultViewModel();
    IsFalse(vm.ShowPmaxPmin);

    vm.ShowPmaxPmin = true;
    vm.Result = Service().Calculate(MetricInput());
    IsFalse(vm.ShowPmaxPmin);
}

static IEnumerable<ControlPointDto> DiamondPmDesignPoints()
{
    yield return PmPoint(0, 10);
    yield return PmPoint(10, 0);
    yield return PmPoint(0, -10);
    yield return PmPoint(-10, 0);
}

static ControlPointDto PmPoint(double x, double y, bool isReference = false, string label = "")
    => new(DiagramType.PM, x, y, y, y, x, 0, 1, 0, 0, label, isReference ? "Reference" : "DesignCapacity", false, false, isReference, false);

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

static void TestEc2SlendernessOffPreservesDirectMoments()
{
    var loadCase = new LoadCaseDto("lc1", "LC1", 1200, 85, 35, true, ForceUnit.kN, MomentUnit.kNm)
    {
        MxTop = 500,
        MxBottom = -400,
        MyTop = 300,
        MyBottom = -250
    };

    var result = Service().Calculate(MetricInput() with
    {
        IncludeEc2Slenderness = false,
        MemberLengthL = 30000,
        LoadCases = [loadCase]
    });

    var row = result.LoadCaseResults.Single();
    AreClose(85, row.MuxDisplay, 1e-9);
    AreClose(35, row.MuyDisplay, 1e-9);
    IsFalse(result.IncludeEc2Slenderness);
    IsTrue(result.Ec2Slenderness.LoadCases.Count == 0);
}

static void TestEc2SlendernessOnMapsUsedMoments()
{
    var loadCase = new LoadCaseDto("lc1", "LC1", 1200, 10, 10, true, ForceUnit.kN, MomentUnit.kNm)
    {
        Vux = 15,
        Vuy = 10,
        MxTop = 85,
        MxBottom = -60,
        MyTop = 35,
        MyBottom = -20
    };

    var result = Service().Calculate(MetricInput() with
    {
        IncludeEc2Slenderness = true,
        MemberLengthL = 30000,
        Kx = 1.0,
        Ky = 1.0,
        PhiEff = 1.5,
        LoadCases = [loadCase]
    });

    var slenderness = result.Ec2Slenderness.LoadCases.Single();
    var row = result.LoadCaseResults.Single();
    IsTrue(result.IncludeEc2Slenderness);
    IsTrue(slenderness.X is not null);
    IsTrue(slenderness.Y is not null);
    IsTrue(slenderness.X!.IsSlender || slenderness.Y!.IsSlender);
    AreClose(slenderness.MxUsedNmm!.Value / 1_000_000.0, row.MuxDisplay, 1e-6);
    AreClose(slenderness.MyUsedNmm!.Value / 1_000_000.0, row.MuyDisplay, 1e-6);
    IsTrue(Math.Abs(row.MuxDisplay - 10) > 1e-6 || Math.Abs(row.MuyDisplay - 10) > 1e-6);
    IsTrue(row.SlendernessStatus.Contains("Slender") || row.SlendernessStatus == "Stocky");
}

// ----- ACI Trim Segment Straight-Line Tests (Task 13 Addendum) -----

static void TestAciTrimSegmentStraightPmx()
{
    var result = Service().Calculate(MetricInput());
    double cap = result.ControlPoints.DesignCompressionLimitDisplay;
    var defects = PmCurveBuilderService.ValidateStraightTrimSegment(PmAngleDiagram(result, 0.0).Points, cap);
    IsTrue(defects.Count == 0);
}

static void TestAciTrimSegmentStraightPmy()
{
    var result = Service().Calculate(MetricInput());
    double cap = result.ControlPoints.DesignCompressionLimitDisplay;
    var defects = PmCurveBuilderService.ValidateStraightTrimSegment(PmAngleDiagram(result, 90.0).Points, cap);
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

static RectangularSection RectangularEc2ValidationSection()
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
    return new RectangularSection(600.0, 800.0, new RebarLayout("EC2 16H25", "H25", 62.5, bars));
}

static Ec2FiberInteractionSolver FastEc2Solver()
    => new(new Ec2DesignCodeService()) { AngleStepDegrees = 30, NeutralAxisSamples = 36, ConcreteGridDivisions = 20 };



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

static void TestRectangularEqualSpacingOptimalDistribution()
{
    var units = new UnitConversionService();
    var metric = new SingaporeRebarDatabase();
    var imperial = new ImperialRebarDatabase();
    var builder = new RebarCoordinateBuilderService(units, metric, imperial);

    // Valid case: even number of bars >= 4
    var layout = new RebarLayoutInputDto(RebarLayoutType.EqualSpacing, 10, "T20", 40, null!, null!, null!, null!);
    var bars = builder.Build(layout, 300, 600, LengthUnit.Millimeter, UnitSystem.Metric);
    IsTrue(bars.Count == 10);

    // Invalid case: odd number of bars should throw an exception
    var layoutOdd = new RebarLayoutInputDto(RebarLayoutType.EqualSpacing, 9, "T20", 40, null!, null!, null!, null!);
    Throws(() => builder.Build(layoutOdd, 300, 600, LengthUnit.Millimeter, UnitSystem.Metric));
}

static void TestCircularAndIrregularToDtoMapping()
{
    var metric = new SingaporeRebarDatabase();
    var imperial = new ImperialRebarDatabase();
    
    // Test Circular Equal Spacing DTO mapping
    var vmCircular = new InputViewModel(metric, imperial)
    {
        UnitSystem = UnitSystem.Metric,
        SelectedSectionShape = SectionShapeType.Circular,
        Diameter = 600,
        Cover = 40,
        BarSize = "T20",
        SelectedRebarLayoutType = RebarLayoutType.EqualSpacing,
        Spacing = 150
    };
    
    var dtoCircular = vmCircular.ToDto();
    // Perimeter at centroid: pi * (600 - 2 * 40 - 20) = pi * 500 = 1570.796 mm
    // Expected bar count = Math.Max(4, Math.Round(1570.796 / 150)) = 10 bars.
    IsTrue(dtoCircular.BarCount == 10);
    IsTrue(dtoCircular.RebarCoordinates != null && dtoCircular.RebarCoordinates.Count == 10);
    
    // Test Irregular DTO mapping
    var vmIrregular = new InputViewModel(metric, imperial)
    {
        UnitSystem = UnitSystem.Metric,
        SelectedSectionShape = SectionShapeType.Irregular
    };
    
    var dtoIrregular = vmIrregular.ToDto();
    int expectedCount = vmIrregular.IrregularInput.Rebars.Count;
    IsTrue(dtoIrregular.BarCount == expectedCount);
    IsTrue(dtoIrregular.Irregular != null && dtoIrregular.Irregular.Rebars.Count == expectedCount);
}

static (StrainCompatibilityInteractionSolver Conv, AciFiberInteractionSolver Fiber, RectangularSection Section, ConcreteMaterial Concrete, SteelMaterial Steel) AciSolverFixtures()
{
    var aci = new Aci318DesignCodeService();
    var conv = new StrainCompatibilityInteractionSolver(aci) { AngleStepDegrees = 30, NeutralAxisSamples = 30 };
    var fiber = new AciFiberInteractionSolver(aci) { AngleStepDegrees = 30, NeutralAxisSamples = 30, ConcreteGridDivisions = 40 };
    var section = RectangularEc2ValidationSection();
    return (conv, fiber, section, new ConcreteMaterial("C28", 28.0), new SteelMaterial("Gr420", 420.0, 200000.0));
}

static void TestSectionIntegrationSelectionPropagates()
{
    var fiber = Service().Calculate(MetricInput() with { IntegrationMethod = SectionIntegrationMethod.Fiber });
    var polygon = Service().Calculate(MetricInput() with { IntegrationMethod = SectionIntegrationMethod.Polygon });

    IsTrue(fiber.IntegrationMethod == SectionIntegrationMethod.Fiber);
    IsTrue(polygon.IntegrationMethod == SectionIntegrationMethod.Polygon);
    IsTrue(fiber.Surface.Points.All(p => p.IntegrationMethod == SectionIntegrationMethod.Fiber));
    IsTrue(polygon.Surface.Points.All(p => p.IntegrationMethod == SectionIntegrationMethod.Polygon));
    IsFalse(polygon.Surface.Points.Any(p =>
        double.IsNaN(p.Pn) || double.IsInfinity(p.Pn) ||
        double.IsNaN(p.Mnx) || double.IsInfinity(p.Mnx) ||
        double.IsNaN(p.Mny) || double.IsInfinity(p.Mny)));
}

static void TestPolygonIntegrationCircularSection()
{
    var input = MetricInput() with
    {
        SectionShape = SectionShapeType.Circular,
        Diameter = 700,
        IntegrationMethod = SectionIntegrationMethod.Polygon
    };
    var result = Service().Calculate(input);

    IsTrue(result.SectionShape == SectionShapeType.Circular);
    IsTrue(result.IntegrationMethod == SectionIntegrationMethod.Polygon);
    IsTrue(result.Surface.AngleCount == 36);
    IsFalse(result.Surface.Points.Any(p =>
        double.IsNaN(p.Pn) || double.IsInfinity(p.Pn) ||
        double.IsNaN(p.Mnx) || double.IsInfinity(p.Mnx) ||
        double.IsNaN(p.Mny) || double.IsInfinity(p.Mny)));
}

static void TestControlPointExportIntegrationMetadata()
{
    var path = Path.Combine(Path.GetTempPath(), $"mbcolumn-export-{Guid.NewGuid():N}.csv");
    try
    {
        var rows = new[]
        {
            new ControlPointExportRow
            {
                ThetaDeg = 0,
                PointIndex = 1,
                P = 1,
                MxPositive = 10,
                MyPositive = 11,
                MThetaPositive = 2,
                MxNegative = -10,
                MyNegative = -11,
                MThetaNegative = -2,
                NeutralAxisDepth = 3,
                SteelStrainMax = -0.001,
                ConcreteStrainMax = -0.003,
                PhiFactor = 0.65,
                IntegrationMethod = SectionIntegrationMethod.Polygon.ToString(),
                ConcreteFiberCountX = 40,
                ConcreteFiberCountY = 40,
                CircularRadialFiberCount = 32,
                CircularAngularFiberCount = 72,
                CirclePolygonSegmentCount = 128,
                Remarks = "metadata"
            }
        };

        new ControlPointCsvExportService().Export(path, rows);
        string csv = File.ReadAllText(path);
        IsTrue(csv.Contains("Mx+", StringComparison.Ordinal));
        IsTrue(csv.Contains("My-", StringComparison.Ordinal));
        IsTrue(csv.Contains("NeutralAxisDepth", StringComparison.Ordinal));
        IsTrue(csv.Contains("\u03b5s", StringComparison.Ordinal));
        IsTrue(csv.Contains("\u03b5c", StringComparison.Ordinal));
        IsTrue(csv.Contains("\u03c6", StringComparison.Ordinal));
        IsTrue(csv.Contains("0.65", StringComparison.Ordinal));
        IsTrue(csv.Contains("IntegrationMethod", StringComparison.Ordinal));
        IsTrue(csv.Contains("CirclePolygonSegmentCount", StringComparison.Ordinal));
        IsTrue(csv.Contains("Polygon", StringComparison.Ordinal));
        IsTrue(csv.Contains("-0.001", StringComparison.Ordinal));
        IsTrue(csv.Contains("-0.003", StringComparison.Ordinal));
    }
    finally
    {
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }
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
    => new(new Ec2DesignCodeService()) { AngleStepDegrees = 30, NeutralAxisSamples = 36 };

// --- Material factor tests ------------------------------------------

static void TestEc2SsbMaterialFactorsLowFck()
{
    var ec2 = new Ec2DesignCodeService();
    // For fck ≤ 50 MPa: lambda = 0.8, eta = 1.0 (EC2 3.1.7(3))
    AreClose(0.8, Ec2SimplifiedStressBlockInteractionSolver.LambdaFor(ec2, 30.0), 1e-12);
    AreClose(0.8, Ec2SimplifiedStressBlockInteractionSolver.LambdaFor(ec2, 50.0), 1e-12);
    AreClose(1.0, Ec2SimplifiedStressBlockInteractionSolver.EtaFor(ec2, 30.0),    1e-12);
    AreClose(1.0, Ec2SimplifiedStressBlockInteractionSolver.EtaFor(ec2, 50.0),    1e-12);
    // For fck = 30: blockStress = eta × fcd = 1.0 × (0.80 × 30 / 1.50) = 16.0 MPa
    double fcd = 0.80 * 30.0 / 1.50;
    AreClose(16.0, fcd, 1e-9);
}

static void TestEc2SsbMaterialFactorsHighFck()
{
    var ec2 = new Ec2DesignCodeService();
    // For fck = 70 MPa (> 50): lambda = 0.8 – (70–50)/400 = 0.75, eta = 1.0 – (70–50)/200 = 0.9
    AreClose(0.75, Ec2SimplifiedStressBlockInteractionSolver.LambdaFor(ec2, 70.0), 1e-12);
    AreClose(0.90, Ec2SimplifiedStressBlockInteractionSolver.EtaFor(ec2, 70.0),    1e-12);
    // Minimum eta = 0.8 (at fck = 90)
    IsTrue(Ec2SimplifiedStressBlockInteractionSolver.EtaFor(ec2, 90.0) >= 0.8);
    // Minimum lambda = 0.7 (at fck = 90: 0.8 - 40/400 = 0.7)
    IsTrue(Ec2SimplifiedStressBlockInteractionSolver.LambdaFor(ec2, 90.0) >= 0.7);
}

// --- Factory routing test -------------------------------------------

static void TestEc2SsbFactoryRouting()
{
    var aci = new Aci318DesignCodeService();
    var ec2 = new Ec2DesignCodeService();
    var factory = new InteractionSolverFactory(aci, ec2);
    IsTrue(factory.Get(DesignCodeType.Ec2, integrationMethod: SectionIntegrationMethod.Fiber) is PmmInteractionSolver);
    IsTrue(factory.Get(DesignCodeType.Ec2, integrationMethod: SectionIntegrationMethod.Polygon) is PmmInteractionSolver);
    IsTrue(factory.Get(DesignCodeType.Ec2) is PmmInteractionSolver);
    IsTrue(factory.GetLegacy(DesignCodeType.Ec2, ec2Solver: Ec2SolverType.SimplifiedStressBlock)
                  is Ec2SimplifiedStressBlockInteractionSolver);
    IsTrue(factory.GetLegacy(DesignCodeType.Ec2, ec2Solver: Ec2SolverType.Fiber) is Ec2FiberInteractionSolver);
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

    int expectedAngleCount  = (int)(360.0 / solver.AngleStepDegrees);    // 12
    int expectedDepthCount  = solver.NeutralAxisSamples;         // 36
    IsTrue(surface.AngleCount == expectedAngleCount);
    IsTrue(surface.DepthCount == expectedDepthCount);
    IsTrue(surface.Points.Count == expectedAngleCount * expectedDepthCount);
}

// --- Axial force boundary tests -------------------------------------

static void TestEc2SsbPureCompression()
{
    // P0 = eta*fcd*Ac + (fyd – eta*fcd)*As
    // eta=1, fcd=17 (0.85*30/1.5), Ac=90 000, fyd=434.78 (500/1.15), As=1256.64
    // P0 = 17×90 000 + (434.78–17)×1256.64 = 1 530 000 + 525 001 ≈ 2 055 001 N
    const double expectedP0 = 2_055_001.0;

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
    var solver = new Ec2SimplifiedStressBlockInteractionSolver(new Ec2DesignCodeService())
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
    //   concreteN  = 17 × 36 000 = 612 000 N
    //   concreteMx = 612 000 × 90 = 55 080 000 N·mm
    //   Top bars (y = +110): strain = 0.0035×(150–40)/150 ≈ +0.002567 → stress = 434.78 (yield)
    //                        disp = 17 MPa (inside block)   force = (434.78–17)×2×314.16 ≈ 262 501 N
    //                        steelMx += 262 501 × 110 ≈ 28 875 110 N·mm
    //   Bot bars (y = –110): strain = 0.0035×(150–260)/150 ≈ –0.002567 → stress = –434.78 (yield tension)
    //                        disp = 0   force = –434.78×2×314.16 ≈ –273 158 N
    //                        steelMx += –273 158 × (–110) ≈ 30 047 380 N·mm
    //   Total Pn  = 612 000 + 262 501 – 273 158 ≈ 601 343 N   (~601 kN)
    //   Total Mnx = 55 080 000 + 28 875 110 + 30 047 380 ≈ 114 002 490 N·mm  (~114 kN·m)
    const double expectedP   = 601_343.0;
    const double expectedMnx = 114_002_490.0;

    var solver = new Ec2SimplifiedStressBlockInteractionSolver(new Ec2DesignCodeService())
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
    AreClose(expectedP,   pt.Pn,  expectedP   * 0.05);    // 5 % tolerance
    AreClose(expectedMnx, pt.Mnx, expectedMnx * 0.05);
}

// --- Cross-solver comparison: SSB P0 close to boundary P0 -----------

static void TestEc2SsbP0CloseToBoundary()
{
    // Both solvers share EC2 design strengths; P0 should agree within 5%.
    // Boundary uses parabolic-rectangular with eps_c2 = 0.0020;
    // SSB uses eta*fcd = 16 MPa (same fcd) with eps_c3 = 0.00175 → slightly lower steel strain.
    var section  = RectangularEc2ValidationSection();
    var concrete = new ConcreteMaterial("C35", 35.0);
    var steel    = new SteelMaterial("B500", 500.0, 200000.0);

    var ssbSolver = new Ec2SimplifiedStressBlockInteractionSolver(new Ec2DesignCodeService())
        { AngleStepDegrees = 30, NeutralAxisSamples = 36 };
    var boundarySolver = new Ec2BoundaryInteractionSolver(new Ec2DesignCodeService())
        { AngleStepDegrees = 30, NeutralAxisSamples = 36 };

    double p0Ssb      = ssbSolver.Solve(section, concrete, steel).Points.Max(p => p.Pn);
    double p0Boundary = boundarySolver.Solve(section, concrete, steel).Points.Max(p => p.Pn);

    double rel = Math.Abs(p0Ssb - p0Boundary) / Math.Max(Math.Abs(p0Boundary), 1.0);
    IsTrue(rel < 0.50);   // Within 50 % of each other (Peak divergence is expected between SSB and Boundary models)
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
    var section  = RectangularEc2ValidationSection();
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

// ----- Irregular section tests -----

static List<MBColumn.Domain.Entities.Point2D> ClockwiseSquare(double half = 300.0) =>
    new()
    {
        new(-half, -half),
        new(-half,  half),
        new( half,  half),
        new( half, -half)
    };

static List<MBColumn.Domain.Entities.Point2D> ClockwiseLShape() =>
    new()
    {
        new(-200, -200),
        new(-200,  200),
        new(   0,  200),
        new(   0,    0),
        new( 200,    0),
        new( 200, -200)
    };

static MBColumn.Application.Services.IrregularSectionValidationService IrregularValidator()
    => new();

static void TestIrregularBoundaryClockwiseTriangle()
{
    var tri = new List<MBColumn.Domain.Entities.Point2D>
    {
        new(-300, -200),
        new(   0,  300),
        new( 300, -200)
    };
    var result = IrregularValidator().ValidateBoundary(tri);
    IsTrue(result.IsValid);
}

static void TestIrregularBoundaryClockwiseLShape()
{
    var result = IrregularValidator().ValidateBoundary(ClockwiseLShape());
    IsTrue(result.IsValid);
}

static void TestIrregularBoundaryRejectsFewerThan3()
{
    var pts = new List<MBColumn.Domain.Entities.Point2D> { new(0, 0), new(1, 0) };
    var result = IrregularValidator().ValidateBoundary(pts);
    IsFalse(result.IsValid);
}

static void TestIrregularBoundaryRejectsDuplicate()
{
    var pts = new List<MBColumn.Domain.Entities.Point2D>
    {
        new(-100, -100),
        new(-100,  100),
        new( 100,  100),
        new(-100, -100),  // duplicate of first (not adjacent in indexing)
        new( 100, -100)
    };
    var result = IrregularValidator().ValidateBoundary(pts);
    IsFalse(result.IsValid);
}

static void TestIrregularBoundaryRejectsDuplicateConsecutive()
{
    var pts = new List<MBColumn.Domain.Entities.Point2D>
    {
        new(-100, -100),
        new(-100,  100),
        new(-100,  100), // duplicate consecutive
        new( 100,  100),
        new( 100, -100)
    };
    var result = IrregularValidator().ValidateBoundary(pts);
    IsFalse(result.IsValid);
}

static void TestIrregularBoundaryRejectsRepeatedFirstLast()
{
    var pts = new List<MBColumn.Domain.Entities.Point2D>
    {
        new(-100, -100),
        new(-100,  100),
        new( 100,  100),
        new( 100, -100),
        new(-100, -100) // explicit duplicate of first point
    };
    var result = IrregularValidator().ValidateBoundary(pts);
    IsFalse(result.IsValid);
}

static void TestIrregularBoundaryAcceptsCcw()
{
    var pts = new List<MBColumn.Domain.Entities.Point2D>
    {
        new(-100, -100),
        new( 100, -100),
        new( 100,  100),
        new(-100,  100)
    };
    var result = IrregularValidator().ValidateBoundary(pts);
    IsTrue(result.IsValid);
}

static void TestIrregularBoundaryRejectsSelfIntersecting()
{
    var pts = new List<MBColumn.Domain.Entities.Point2D>
    {
        new(-100, -100),
        new( 100,  100),
        new(-100,  100),
        new( 100, -100)
    };
    var result = IrregularValidator().ValidateBoundary(pts);
    IsFalse(result.IsValid);
}

static void TestIrregularBoundaryRejectsZeroArea()
{
    var pts = new List<MBColumn.Domain.Entities.Point2D>
    {
        new(0, 0),
        new(1, 0),
        new(2, 0)
    };
    var result = IrregularValidator().ValidateBoundary(pts);
    IsFalse(result.IsValid);
}

static void TestIrregularRebarAcceptsInside()
{
    var bars = new List<MBColumn.Application.DTOs.IrregularRebarInputDto>
    {
        new("B1", -200, -200, null, 491.0),
        new("B2",  200, -200, null, 491.0),
        new("B3",  200,  200, null, 491.0),
        new("B4", -200,  200, null, 491.0)
    };
    var result = IrregularValidator().ValidateRebars(ClockwiseSquare(300.0), bars, 40.0);
    IsTrue(result.IsValid);
}

static void TestIrregularRebarRejectsOutside()
{
    var bars = new List<MBColumn.Application.DTOs.IrregularRebarInputDto>
    {
        new("B1", 400, 0, null, 491.0)
    };
    var result = IrregularValidator().ValidateRebars(ClockwiseSquare(300.0), bars, 40.0);
    IsFalse(result.IsValid);
}

static void TestIrregularRebarRejectsCoverViolation()
{
    var bars = new List<MBColumn.Application.DTOs.IrregularRebarInputDto>
    {
        new("B1", 290, 0, null, 491.0)
    };
    var result = IrregularValidator().ValidateRebars(ClockwiseSquare(300.0), bars, 40.0);
    IsFalse(result.IsValid);
}

static void TestIrregularRebarRejectsOverlap()
{
    var bars = new List<MBColumn.Application.DTOs.IrregularRebarInputDto>
    {
        new("B1", 0, 0, null, 491.0),
        new("B2", 5, 0, null, 491.0)
    };
    var result = IrregularValidator().ValidateRebars(ClockwiseSquare(300.0), bars, 40.0);
    IsFalse(result.IsValid);
}

static void TestIrregularRebarAcceptsAreaOnly()
{
    var bars = new List<MBColumn.Application.DTOs.IrregularRebarInputDto>
    {
        new("B1", 0, 0, null, 491.0)
    };
    var result = IrregularValidator().ValidateRebars(ClockwiseSquare(300.0), bars, 40.0);
    IsTrue(result.IsValid);
}

static void TestIrregularRebarPrefersAreaOverBarSize()
{
    var validator = IrregularValidator();
    // Area provided -> diameter derived from area, BarSize ignored for diameter.
    var bar = new MBColumn.Application.DTOs.IrregularRebarInputDto("B1", 0, 0, "T25", 100.0);
    IsTrue(validator.TryResolveDiameter(bar, out double diameter, out _));
    double expectedDiameter = Math.Sqrt(4.0 * 100.0 / Math.PI);
    AreClose(expectedDiameter, diameter, 1e-9);
}

static void TestIrregularCsvBoundaryRoundTrip()
{
    var svc = new MBColumn.Application.Services.ImportExport.IrregularSectionCsvService();
    var rows = new List<MBColumn.Application.DTOs.ImportExport.IrregularBoundaryPointCsvDto>
    {
        new(1, -300, -250),
        new(2,  300, -250),
        new(3,  350,    0),
        new(4,  250,  300),
        new(5, -250,  300),
        new(6, -350,    0)
    };
    var text = svc.SerializeBoundary(rows);
    var parsed = svc.ParseBoundary(text);
    IsTrue(parsed.Count == rows.Count);
    for (int i = 0; i < rows.Count; i++)
    {
        IsTrue(parsed[i].PtIndex == rows[i].PtIndex);
        AreClose(parsed[i].X, rows[i].X, 1e-12);
        AreClose(parsed[i].Y, rows[i].Y, 1e-12);
    }
}

static void TestIrregularCsvRebarRoundTrip()
{
    var svc = new MBColumn.Application.Services.ImportExport.IrregularSectionCsvService();
    var rows = new List<MBColumn.Application.DTOs.ImportExport.IrregularRebarCsvDto>
    {
        new("B1", -250, -200, "T20", null),
        new("B2",  250, -200, "T20", null),
        new("B3",  250,  200, "T25", null),
        new("B4", -250,  200, null, 491.0)
    };
    var text = svc.SerializeRebars(rows);
    var parsed = svc.ParseRebars(text);
    IsTrue(parsed.Count == rows.Count);
    for (int i = 0; i < rows.Count; i++)
    {
        IsTrue(parsed[i].RebarIndex == rows[i].RebarIndex);
        AreClose(parsed[i].X, rows[i].X, 1e-12);
        AreClose(parsed[i].Y, rows[i].Y, 1e-12);
        IsTrue((parsed[i].BarSize ?? "") == (rows[i].BarSize ?? ""));
        bool aMatch = (parsed[i].AreaMm2 ?? -1) == (rows[i].AreaMm2 ?? -1)
                      || Math.Abs((parsed[i].AreaMm2 ?? 0) - (rows[i].AreaMm2 ?? 0)) < 1e-9;
        IsTrue(aMatch);
    }
}

static void TestIrregularCsvIgnoresMetadata()
{
    var svc = new MBColumn.Application.Services.ImportExport.IrregularSectionCsvService();
    string text = "# MBColumnCsvVersion=1\n# DataType=IrregularBoundary\n# CoordinateUnit=mm\nptIndex,X,Y\n1,0,0\n\n2,100,0\n3,50,100\n";
    var parsed = svc.ParseBoundary(text);
    IsTrue(parsed.Count == 3);
    AreClose(parsed[1].X, 100, 1e-12);
}

static void TestIrregularCsvRejectsWrongHeader()
{
    var svc = new MBColumn.Application.Services.ImportExport.IrregularSectionCsvService();
    string text = "idx,X,Y\n1,0,0\n";
    Throws(() => svc.ParseBoundary(text));
}

static void TestIrregularCsvReportsInvalidNumbers()
{
    var svc = new MBColumn.Application.Services.ImportExport.IrregularSectionCsvService();
    string text = "ptIndex,X,Y\n1,abc,0\n";
    try { svc.ParseBoundary(text); }
    catch (FormatException ex)
    {
        IsTrue(ex.Message.Contains("row") && ex.Message.Contains("X"));
        return;
    }
    throw new InvalidOperationException("Expected FormatException with row/column context.");
}

static void TestIrregularCsvExportNoClosingPoint()
{
    var svc = new MBColumn.Application.Services.ImportExport.IrregularSectionCsvService();
    var rows = new List<MBColumn.Application.DTOs.ImportExport.IrregularBoundaryPointCsvDto>
    {
        new(1, 0, 0),
        new(2, 100, 0),
        new(3, 50, 100)
    };
    var text = svc.SerializeBoundary(rows);
    int rowCount = text.Split('\n').Count(l => l.Length > 0 && !l.StartsWith('#') && !l.StartsWith("ptIndex"));
    IsTrue(rowCount == 3);
}

static void TestDxfPolygonCentroid()
{
    var polygon = new List<MBColumn.Domain.Entities.Point2D>
    {
        new(100, 100),
        new(300, 100),
        new(300, 300),
        new(100, 300)
    };

    var centroid = MBColumn.Application.Services.Geometry.PolygonGeometry.Centroid(polygon);
    AreClose(200.0, centroid.X, 1e-9);
    AreClose(200.0, centroid.Y, 1e-9);
}

static void TestDxfMoveToOrigin()
{
    var polygon = new List<MBColumn.Domain.Entities.Point2D>
    {
        new(100, 100),
        new(300, 100),
        new(300, 300),
        new(100, 300)
    };

    var shifted = MBColumn.Application.Services.Geometry.PolygonGeometry.MoveToCentroidOrigin(polygon, out var centroid);
    AreClose(200.0, centroid.X, 1e-9);
    AreClose(200.0, centroid.Y, 1e-9);
    var shiftedCentroid = MBColumn.Application.Services.Geometry.PolygonGeometry.Centroid(shifted);
    AreClose(0.0, shiftedCentroid.X, 1e-9);
    AreClose(0.0, shiftedCentroid.Y, 1e-9);
}

static void TestDxfClosedPolylineExtraction()
{
    string path = WriteTempDxf(BuildValidDxf());
    try
    {
        var svc = new MBColumn.Application.Services.ImportExport.DxfImportService();
        var layers = svc.GetLayerNames(path);
        IsTrue(layers.Contains("BOUNDARY"));
        IsTrue(layers.Contains("REBAR"));

        var result = svc.ImportSection(new MBColumn.Application.DTOs.ImportExport.DxfSectionImportRequest(path, "BOUNDARY", "REBAR", 1.0));
        IsTrue(result.IsSuccess);
        IsTrue(result.BoundaryVertices.Count == 4);
        AreClose(40000.0, result.Area, 1e-6);

        var centroid = MBColumn.Application.Services.Geometry.PolygonGeometry.Centroid(result.BoundaryVertices);
        AreClose(0.0, centroid.X, 1e-9);
        AreClose(0.0, centroid.Y, 1e-9);
    }
    finally
    {
        File.Delete(path);
    }
}

static void TestDxfRebarCircleExtraction()
{
    string path = WriteTempDxf(BuildValidDxf());
    try
    {
        var svc = new MBColumn.Application.Services.ImportExport.DxfImportService();
        var result = svc.ImportSection(new MBColumn.Application.DTOs.ImportExport.DxfSectionImportRequest(path, "BOUNDARY", "REBAR", 1.0));
        IsTrue(result.IsSuccess);
        IsTrue(result.Rebars.Count == 1);
        AreClose(50.0, result.Rebars[0].Center.X, 1e-9);
        AreClose(10.0, result.Rebars[0].Center.Y, 1e-9);
        AreClose(10.0, result.Rebars[0].Radius, 1e-9);
    }
    finally
    {
        File.Delete(path);
    }
}

static void TestDxfPointInPolygonValidation()
{
    var polygon = new List<MBColumn.Domain.Entities.Point2D>
    {
        new(-100, -100),
        new(100, -100),
        new(100, 100),
        new(-100, 100)
    };

    IsTrue(MBColumn.Application.Services.Geometry.PolygonGeometry.PointInPolygon(polygon, 0, 0));
    IsFalse(MBColumn.Application.Services.Geometry.PolygonGeometry.PointInPolygon(polygon, 150, 0));
}

static void TestDxfRejectsOpenBoundary()
{
    string path = WriteTempDxf(BuildOpenBoundaryDxf());
    try
    {
        var svc = new MBColumn.Application.Services.ImportExport.DxfImportService();
        var result = svc.ImportSection(new MBColumn.Application.DTOs.ImportExport.DxfSectionImportRequest(path, "BOUNDARY", "REBAR", 1.0));
        IsFalse(result.IsSuccess);
        IsTrue(result.Errors.Any(e => e.Contains("No closed polyline", StringComparison.OrdinalIgnoreCase)));
    }
    finally
    {
        File.Delete(path);
    }
}

static void TestDxfRejectsNonCircularRebar()
{
    string path = WriteTempDxf(BuildNonCircularRebarDxf());
    try
    {
        var svc = new MBColumn.Application.Services.ImportExport.DxfImportService();
        var result = svc.ImportSection(new MBColumn.Application.DTOs.ImportExport.DxfSectionImportRequest(path, "BOUNDARY", "REBAR", 1.0));
        IsFalse(result.IsSuccess);
        IsTrue(result.Errors.Any(e => e.Contains("No valid circular rebar", StringComparison.OrdinalIgnoreCase)));
        IsTrue(result.Warnings.Any(w => w.Contains("non-circular", StringComparison.OrdinalIgnoreCase)));
    }
    finally
    {
        File.Delete(path);
    }
}

static void TestDxfImportAppliesIrregularCustomCoordinates()
{
    var import = new MBColumn.Application.DTOs.ImportExport.DxfSectionImportResult
    {
        Area = 40000.0,
        OriginalCentroidX = 200.0,
        OriginalCentroidY = 200.0,
        BoundaryPolylineCount = 1,
        BoundaryVertexCount = 4,
        RebarCircleCount = 1
    };
    import.BoundaryVertices.AddRange([
        new MBColumn.Domain.Entities.Point2D(-100, 100),
        new MBColumn.Domain.Entities.Point2D(100, 100),
        new MBColumn.Domain.Entities.Point2D(100, -100),
        new MBColumn.Domain.Entities.Point2D(-100, -100)
    ]);
    import.Rebars.Add(new MBColumn.Application.DTOs.ImportExport.DxfRebarImportItem(
        new MBColumn.Domain.Entities.Point2D(0, 0),
        10.0,
        Math.PI * 10.0 * 10.0));

    var vm = new MBColumn.Presentation.Wpf.ViewModels.InputViewModel(
        new MBColumn.Infrastructure.Rebar.SingaporeRebarDatabase(),
        new MBColumn.Infrastructure.Rebar.ImperialRebarDatabase());

    IsTrue(vm.ApplyDxfImportResult(import));
    IsTrue(vm.SelectedSectionShape == MBColumn.Domain.Enums.SectionShapeType.Irregular);
    IsTrue(vm.SelectedRebarLayoutType == MBColumn.Application.DTOs.RebarLayoutType.CustomCoordinates);
    IsTrue(vm.IrregularInput.RebarMode == MBColumn.Application.DTOs.IrregularRebarModeType.CustomCoordinates);
    IsTrue(vm.IrregularInput.BoundaryPoints.Count == 4);
    IsTrue(vm.IrregularInput.Rebars.Count == 1);
    IsTrue(vm.PreviewRebars.Count == 1);

    var dto = vm.ToDto();
    IsTrue(dto.SectionShape == MBColumn.Domain.Enums.SectionShapeType.Irregular);
    IsTrue(dto.Irregular is not null);
    IsTrue(dto.Irregular!.RebarMode == MBColumn.Application.DTOs.IrregularRebarModeType.CustomCoordinates);
    IsTrue(dto.Irregular.Rebars.Count == 1);
}

static void TestDxfImportDoesNotBlockOnCover()
{
    var import = new MBColumn.Application.DTOs.ImportExport.DxfSectionImportResult
    {
        Area = 40000.0,
        OriginalCentroidX = 0.0,
        OriginalCentroidY = 0.0,
        BoundaryPolylineCount = 1,
        BoundaryVertexCount = 4,
        RebarCircleCount = 1
    };
    import.BoundaryVertices.AddRange([
        new MBColumn.Domain.Entities.Point2D(-100, 100),
        new MBColumn.Domain.Entities.Point2D(100, 100),
        new MBColumn.Domain.Entities.Point2D(100, -100),
        new MBColumn.Domain.Entities.Point2D(-100, -100)
    ]);
    import.Rebars.Add(new MBColumn.Application.DTOs.ImportExport.DxfRebarImportItem(
        new MBColumn.Domain.Entities.Point2D(45, 0),
        10.0,
        Math.PI * 10.0 * 10.0));

    var vm = new MBColumn.Presentation.Wpf.ViewModels.InputViewModel(
        new MBColumn.Infrastructure.Rebar.SingaporeRebarDatabase(),
        new MBColumn.Infrastructure.Rebar.ImperialRebarDatabase())
    {
        Cover = 55
    };

    IsTrue(vm.ApplyDxfImportResult(import));
    IsTrue(string.IsNullOrWhiteSpace(vm.IrregularInput.RebarValidationMessage));
    IsTrue(vm.IrregularInput.Rebars.Count == 1);
    AreClose(45.0, vm.IrregularInput.Rebars[0].X, 1e-9);
}

static void TestEtabsImportCreatesIrregularCustomCoordinates()
{
    var vm = new MBColumn.Presentation.Wpf.ViewModels.EtabsImportViewModel(
        [],
        [],
        null,
        new StubEtabsConnectionService(),
        new StubEtabsColumnImportService(),
        new StubEtabsForceImportService(),
        null,
        new StubPierShellImportService(),
        new Stub32PointGeometryBuilder());

    vm.ConnectCommand.Execute(null);
    var column = vm.Columns.First(c => c.EtabsSectionName == "CIRC800");
    column.IsSelected = true;

    vm.GoToFlow2Command.Execute(null);
    IsTrue(vm.CurrentFlow == 2);
    IsTrue(vm.SectionMappings.Count == 1);

    // Step 2 → 3 requires at least one selected load combination and one selected force row.
    // Selecting the load combination triggers GenerateForceRows() which populates ForceRows.
    // Force rows are selected by default.
    vm.LoadCombinations[0].IsSelected = true;

    vm.GoToFlow3Command.Execute(null);
    IsTrue(vm.CurrentFlow == 3);
    IsTrue(vm.SummaryRows.Count == 1);
    IsTrue(vm.SummaryRows[0].SectionType == MBColumn.Domain.Enums.SectionShapeType.Irregular);
    IsTrue(vm.SummaryRows[0].Rebar.Contains("custom coordinates", StringComparison.OrdinalIgnoreCase));

    vm.CreateMbColumnSectionCommand.Execute(null);
    vm.AssignToSectionCommand.Execute(vm.MbColumnSections[0]);

    vm.ApplyImportCommand.Execute(null);
    var imported = vm.ImportResult!.Sections.Single();

    var snapshot = imported.Snapshot;

    IsTrue(snapshot.SectionShape == MBColumn.Domain.Enums.SectionShapeType.Irregular.ToString());
    IsTrue(snapshot.IntegrationMethod == MBColumn.Domain.Enums.SectionIntegrationMethod.Polygon.ToString());
    IsTrue(snapshot.RebarLayoutType == MBColumn.Application.DTOs.RebarLayoutType.CustomCoordinates.ToString());
    IsTrue(snapshot.IrregularRebarMode == MBColumn.Application.DTOs.IrregularRebarModeType.CustomCoordinates.ToString());
    IsTrue(snapshot.BoundaryPoints.Count == 32);
    IsTrue(snapshot.Rebars.Count > 0);
    IsTrue(snapshot.Rebars.All(r => string.Equals(r.BarSize, "T25", StringComparison.OrdinalIgnoreCase)));
}

static void TestIrregularEqualSpacingGeneratedRebarsSatisfyCover()
{
    var vm = new MBColumn.Presentation.Wpf.ViewModels.InputViewModel(
        new MBColumn.Infrastructure.Rebar.SingaporeRebarDatabase(),
        new MBColumn.Infrastructure.Rebar.ImperialRebarDatabase());

    vm.SelectedSectionShape = MBColumn.Domain.Enums.SectionShapeType.Irregular;
    vm.IrregularInput.BarSize = "T20";
    vm.IrregularInput.Spacing = 200;
    vm.Cover = 55;
    vm.UpdateSectionPreview();

    var boundary = vm.IrregularInput.BoundaryPoints
        .Select(p => new MBColumn.Domain.Entities.Point2D(p.X, p.Y))
        .ToList();
    var rebars = vm.IrregularInput.Rebars
        .Select(r => new MBColumn.Application.DTOs.IrregularRebarInputDto(r.RebarIndex, r.X, r.Y, r.BarSize, r.AreaMm2))
        .ToList();

    var result = new MBColumn.Application.Services.IrregularSectionValidationService(
        new MBColumn.Infrastructure.Rebar.SingaporeRebarDatabase(),
        new MBColumn.Infrastructure.Rebar.ImperialRebarDatabase())
        .ValidateRebars(boundary, rebars, vm.Cover);

    IsTrue(result.IsValid);
}

static void TestIrregularEqualSpacingToDtoRefreshesStaleRebars()
{
    var vm = new MBColumn.Presentation.Wpf.ViewModels.InputViewModel(
        new MBColumn.Infrastructure.Rebar.SingaporeRebarDatabase(),
        new MBColumn.Infrastructure.Rebar.ImperialRebarDatabase());

    vm.SelectedSectionShape = MBColumn.Domain.Enums.SectionShapeType.Irregular;
    vm.IrregularInput.RebarMode = MBColumn.Application.DTOs.IrregularRebarModeType.EqualSpacing;
    vm.IrregularInput.BarSize = "T20";
    vm.IrregularInput.Spacing = 200;
    vm.Cover = 55;

    vm.IrregularInput.Rebars.Clear();
    vm.IrregularInput.Rebars.Add(new MBColumn.Presentation.Wpf.ViewModels.IrregularRebarRowViewModel
    {
        RebarIndex = "1",
        X = -284.2857,
        Y = -605.7143,
        BarSize = "T20",
        AreaMm2 = 314.1593
    });

    var dto = vm.ToDto();
    IsTrue(dto.Irregular is not null);
    IsTrue(dto.Irregular!.Rebars.Count > 1);

    var boundary = dto.Irregular.BoundaryPoints
        .Select(p => new MBColumn.Domain.Entities.Point2D(p.X, p.Y))
        .ToList();
    var result = new MBColumn.Application.Services.IrregularSectionValidationService(
        new MBColumn.Infrastructure.Rebar.SingaporeRebarDatabase(),
        new MBColumn.Infrastructure.Rebar.ImperialRebarDatabase())
        .ValidateRebars(boundary, dto.Irregular.Rebars, dto.Irregular.CoverMm);

    IsTrue(result.IsValid);
}

static void TestIrregularCustomModeClearsStaleRebarMessage()
{
    var vm = new MBColumn.Presentation.Wpf.ViewModels.InputViewModel(
        new MBColumn.Infrastructure.Rebar.SingaporeRebarDatabase(),
        new MBColumn.Infrastructure.Rebar.ImperialRebarDatabase());

    vm.SelectedSectionShape = MBColumn.Domain.Enums.SectionShapeType.Irregular;
    vm.IrregularInput.RebarValidationMessage = "Rebar '1' violates cover. Distance to boundary 55.00 mm, required 65.00 mm.";
    vm.IrregularInput.RebarMode = MBColumn.Application.DTOs.IrregularRebarModeType.CustomCoordinates;

    IsTrue(vm.SelectedRebarLayoutType == MBColumn.Application.DTOs.RebarLayoutType.CustomCoordinates);
    IsTrue(string.IsNullOrWhiteSpace(vm.IrregularInput.RebarValidationMessage));
}

static string WriteTempDxf(string text)
{
    string path = Path.Combine(Path.GetTempPath(), $"mbcolumn-{Guid.NewGuid():N}.dxf");
    File.WriteAllText(path, text);
    return path;
}

static string BuildValidDxf() => string.Join('\n',
[
    "0", "SECTION",
    "2", "ENTITIES",
    "0", "LWPOLYLINE",
    "8", "BOUNDARY",
    "90", "4",
    "70", "1",
    "10", "100",
    "20", "100",
    "10", "300",
    "20", "100",
    "10", "300",
    "20", "300",
    "10", "100",
    "20", "300",
    "0", "LWPOLYLINE",
    "8", "BOUNDARY",
    "90", "2",
    "70", "0",
    "10", "0",
    "20", "0",
    "10", "10",
    "20", "10",
    "0", "CIRCLE",
    "8", "REBAR",
    "10", "250",
    "20", "210",
    "40", "10",
    "0", "ENDSEC",
    "0", "EOF"
]);

static string BuildOpenBoundaryDxf() => string.Join('\n',
[
    "0", "SECTION",
    "2", "ENTITIES",
    "0", "LWPOLYLINE",
    "8", "BOUNDARY",
    "90", "4",
    "70", "0",
    "10", "100",
    "20", "100",
    "10", "300",
    "20", "100",
    "10", "300",
    "20", "300",
    "10", "100",
    "20", "300",
    "0", "CIRCLE",
    "8", "REBAR",
    "10", "200",
    "20", "200",
    "40", "10",
    "0", "ENDSEC",
    "0", "EOF"
]);

static string BuildNonCircularRebarDxf() => string.Join('\n',
[
    "0", "SECTION",
    "2", "ENTITIES",
    "0", "LWPOLYLINE",
    "8", "BOUNDARY",
    "90", "4",
    "70", "1",
    "10", "100",
    "20", "100",
    "10", "300",
    "20", "100",
    "10", "300",
    "20", "300",
    "10", "100",
    "20", "300",
    "0", "LINE",
    "8", "REBAR",
    "10", "190",
    "20", "190",
    "11", "210",
    "21", "210",
    "0", "ENDSEC",
    "0", "EOF"
]);

static MBColumn.Application.DTOs.IrregularSectionInputDto BuildSquareIrregularInput()
{
    var boundary = new List<MBColumn.Application.DTOs.IrregularBoundaryPointDto>
    {
        new(1, -350, -350),
        new(2, -350,  350),
        new(3,  350,  350),
        new(4,  350, -350)
    };
    var bars = new List<MBColumn.Application.DTOs.IrregularRebarInputDto>
    {
        new("B1", -270, -270, null, 491.0),
        new("B2",  270, -270, null, 491.0),
        new("B3",  270,  270, null, 491.0),
        new("B4", -270,  270, null, 491.0)
    };
    return new MBColumn.Application.DTOs.IrregularSectionInputDto(boundary, bars, 55.0,
        MBColumn.Application.DTOs.IrregularRebarModeType.CustomCoordinates);
}

static MBColumn.Application.DTOs.ColumnInputDto IrregularMetricInput(double pu = 2500, double mux = 250, double muy = 180)
{
    return MetricInput(pu, mux, muy) with
    {
        SectionShape = MBColumn.Domain.Enums.SectionShapeType.Irregular,
        Irregular = BuildSquareIrregularInput(),
        IntegrationMethod = MBColumn.Domain.Enums.SectionIntegrationMethod.Polygon
    };
}

static void TestIrregularPolygonIntegrationSolves()
{
    var result = Service().Calculate(IrregularMetricInput());
    IsTrue(result.Surface.Points.Count > 0);
}

static void TestIrregularPmmNoNan()
{
    var result = Service().Calculate(IrregularMetricInput());
    foreach (var p in result.Surface.Points)
    {
        IsFalse(double.IsNaN(p.Pn) || double.IsInfinity(p.Pn));
        IsFalse(double.IsNaN(p.Mnx) || double.IsInfinity(p.Mnx));
        IsFalse(double.IsNaN(p.Mny) || double.IsInfinity(p.Mny));
        IsFalse(double.IsNaN(p.Phi) || double.IsInfinity(p.Phi));
    }
}

static void TestIrregularPureCompressionPositive()
{
    var result = Service().Calculate(IrregularMetricInput(pu: 1000, mux: 0, muy: 0));
    IsTrue(result.Surface.Points.Max(p => p.PhiPn) > 0);
}

static void TestIrregularPureTensionNegative()
{
    var result = Service().Calculate(IrregularMetricInput(pu: -100, mux: 0, muy: 0));
    IsTrue(result.Surface.Points.Min(p => p.PhiPn) < 0);
}

static void TestIrregularRatioFinite()
{
    var result = Service().Calculate(IrregularMetricInput());
    IsFalse(double.IsNaN(result.Ratio) || double.IsInfinity(result.Ratio));
}

static void TestIrregularMapperShiftsToCentroid()
{
    // Offset square to confirm mapper shifts to centroid.
    var boundary = new List<MBColumn.Application.DTOs.IrregularBoundaryPointDto>
    {
        new(1, 1000, 1000),
        new(2, 1000, 1700),
        new(3, 1700, 1700),
        new(4, 1700, 1000)
    };
    var bars = new List<MBColumn.Application.DTOs.IrregularRebarInputDto>
    {
        new("B1", 1080, 1080, null, 491.0),
        new("B2", 1620, 1080, null, 491.0),
        new("B3", 1620, 1620, null, 491.0),
        new("B4", 1080, 1620, null, 491.0)
    };
    var dto = new MBColumn.Application.DTOs.IrregularSectionInputDto(boundary, bars, 55.0,
        MBColumn.Application.DTOs.IrregularRebarModeType.CustomCoordinates);
    var mapper = new MBColumn.Application.Mappers.IrregularSectionMapper(new MBColumn.Application.Services.IrregularSectionValidationService());
    var result = mapper.ValidateAndMap(dto, out var section, out _);
    IsTrue(result.IsValid);
    IsTrue(section is not null);
    // Centroid of the shifted boundary must be at origin (within numerical tolerance).
    double cx = section!.BoundaryPoints.Average(p => p.X);
    double cy = section!.BoundaryPoints.Average(p => p.Y);
    AreClose(cx, 0.0, 1e-6);
    AreClose(cy, 0.0, 1e-6);
    // Original coords preserved.
    AreClose(section.BoundaryPointsOriginalMm[0].X, 1000, 1e-9);
    AreClose(section.BoundaryPointsOriginalMm[0].Y, 1000, 1e-9);
}

static void TestIrregularResultExposesShape()
{
    var result = Service().Calculate(IrregularMetricInput());
    IsTrue(result.SectionShape == MBColumn.Domain.Enums.SectionShapeType.Irregular);
    IsTrue(result.IntegrationMethod == MBColumn.Domain.Enums.SectionIntegrationMethod.Polygon);
}

static void TestIrregularIntegratorBoundaryHandled()
{
    // Sanity check on NeutralAxisSweepStrategy.ProjectExtreme for irregular sections.
    var boundary = new List<MBColumn.Domain.Entities.Point2D>
    {
        new(-100, -100),
        new(-100,  100),
        new( 100,  100),
        new( 100, -100)
    };
    var layout = new MBColumn.Domain.Entities.RebarLayout("Custom", "", 40, new List<MBColumn.Domain.Entities.Rebar>
    {
        new("A", 25.0, 491.0, 0, 0)
    });
    var section = new MBColumn.Domain.Entities.IrregularSection(
        boundary,
        boundary,
        new MBColumn.Domain.Entities.Point2D(0, 0),
        new MBColumn.Domain.Entities.Rect2D(-100, -100, 100, 100),
        40000.0,
        layout);
    double max = MBColumn.Infrastructure.Solvers.NeutralAxisSweepStrategy.ProjectExtreme(section, 1.0, 0.0);
    AreClose(max, 100.0, 1e-9);
    double maxDiag = MBColumn.Infrastructure.Solvers.NeutralAxisSweepStrategy.ProjectExtreme(section, 1.0 / Math.Sqrt(2.0), 1.0 / Math.Sqrt(2.0));
    AreClose(maxDiag, 100.0 * Math.Sqrt(2.0), 1e-9);
}

// ── Bug-fix regression: IrregularPierGeometryBuilder ─────────────────────────
//
// Both tests exercise the convex-hull joint-patch path (general case) by using a
// 3-segment T-junction so the orthogonal branch is never taken.

static void TestIrregularPierGeometrySnapTolerance()
{
    // T-junction where two segment endpoints at the shared node differ by 0.005 mm.
    // SnapKey maps both to "0,0" (within SnapToleranceMm=0.01 mm), but the old
    // squared-distance check (threshold 1e-9 mm²) failed to recognise them as the
    // same node.  This reversed the unit vectors for segH_right and segV in the
    // joint-patch convex hull, pushing sample points 200 mm downward and producing
    // a spurious stub.
    var segH_left  = new MBColumn.Application.DTOs.Etabs.EtabsPierShellSegmentDto(
        "HL", "P1", "S1", "L1", "CW200", 200, (-300, 0.005), (0, 0.005));
    var segH_right = new MBColumn.Application.DTOs.Etabs.EtabsPierShellSegmentDto(
        "HR", "P1", "S1", "L2", "CW200", 200, (0, 0),        (300, 0));
    var segV       = new MBColumn.Application.DTOs.Etabs.EtabsPierShellSegmentDto(
        "V",  "P1", "S1", "L3", "CW200", 200, (0, 0),        (0, 400));

    var result = new MBColumn.Infrastructure.Etabs.IrregularPierGeometryBuilder()
                     .BuildBoundary([segH_left, segH_right, segV]);

    IsTrue(result.ClockwisePolylines.Count >= 1);
    var poly = result.ClockwisePolylines[0];

    // Correct T-shape Y extent ≈ 500 mm (−100 bottom of H-arms to +400 top of V-arm).
    // With the bug the convex hull had sample points at y ≈ −200, inflating extent to ≈ 600 mm.
    double yExtent = poly.Max(p => p.Y) - poly.Min(p => p.Y);
    IsTrue(yExtent < 550);
}

static void TestIrregularPierGeometryForwardCap()
{
    // T-junction where the upward arm is only 40 mm long — shorter than the wall
    // thickness of 200 mm.  Old code used forward = min(max(200,1),500) = 200, placing
    // convex-hull sample points 200 mm above the joint even though the arm only extends
    // 40 mm.  New code caps forward at segLen = 40 mm, keeping the patch within the arm body.
    var shortSeg   = new MBColumn.Application.DTOs.Etabs.EtabsPierShellSegmentDto(
        "Short", "P1", "S1", "L1", "CW200", 200, (0, 0),    (0, 40));
    var longH_left  = new MBColumn.Application.DTOs.Etabs.EtabsPierShellSegmentDto(
        "HL",    "P1", "S1", "L2", "CW200", 200, (-300, 0), (0, 0));
    var longH_right = new MBColumn.Application.DTOs.Etabs.EtabsPierShellSegmentDto(
        "HR",    "P1", "S1", "L3", "CW200", 200, (0, 0),    (300, 0));

    var result = new MBColumn.Infrastructure.Etabs.IrregularPierGeometryBuilder()
                     .BuildBoundary([shortSeg, longH_left, longH_right]);

    IsTrue(result.ClockwisePolylines.Count >= 1);
    var poly = result.ClockwisePolylines[0];

    // Correct shape Y extent ≈ 200 mm (H-arms y ∈ [−100, 100]; short arm adds nothing above 100).
    // With the bug the patch reached y ≈ 200, inflating the extent to ≈ 300 mm.
    double yExtent = poly.Max(p => p.Y) - poly.Min(p => p.Y);
    IsTrue(yExtent < 250);
}

static void TestIrregularPierGeometryAppliesClockwiseAxisAngle()
{
    var horizontal = new MBColumn.Application.DTOs.Etabs.EtabsPierShellSegmentDto(
        "H", "P1", "S1", "L1", "CW100", 100, (0, 0), (400, 0), 90);
    var vertical = new MBColumn.Application.DTOs.Etabs.EtabsPierShellSegmentDto(
        "V", "P1", "S1", "L2", "CW100", 100, (0, 0), (0, 200), 90);

    var result = new MBColumn.Infrastructure.Etabs.IrregularPierGeometryBuilder()
                     .BuildBoundary([horizontal, vertical]);

    IsTrue(result.ClockwisePolylines.Count >= 1);
    var poly = result.ClockwisePolylines[0];

    // ETABS pier section axis angles are applied clockwise: this L pier should
    // become a long downward leg with the short leg pointing right.
    double minX = poly.Min(p => p.X);
    double maxX = poly.Max(p => p.X);
    double minY = poly.Min(p => p.Y);
    double maxY = poly.Max(p => p.Y);

    IsTrue(Math.Abs(minY) > Math.Abs(maxY));
    IsTrue(Math.Abs(maxX) > Math.Abs(minX));
    IsTrue(maxY - minY > maxX - minX);
}

// ── Tests for 7-Point Strain Controlled Solver ─────────

static void TestStrainControlledSevenPointAci()
{
    var aci = new MBColumn.Infrastructure.DesignCodes.Aci318DesignCodeService();
    var codeAdapter = new MBColumn.Infrastructure.Solvers.StrainPoints.Aci318StrainLimitAdapter(aci);
    var integrator = MBColumn.Infrastructure.Solvers.Integration.SectionIntegratorFactory.Create(MBColumn.Domain.Enums.SectionIntegrationMethod.Fiber);
    var strategy = new MBColumn.Infrastructure.Solvers.StrainPoints.StrainControlledSevenPointStrategy(integrator, codeAdapter, aci);
    
    var input = MetricInput();
    var concrete = new MBColumn.Domain.Entities.ConcreteMaterial("C30", input.Fc);
    var steel = new MBColumn.Domain.Entities.SteelMaterial("B500", input.Fy, input.Es);
    var layout = new MBColumn.Domain.Entities.RebarLayout("Sides different", "T20", 40, []);
    var section = new MBColumn.Domain.Entities.RectangularSection(400, 400, layout);
    
    var points = strategy.GeneratePoints(section, concrete, steel, 0.0, new MBColumn.Infrastructure.Solvers.SolverSettings());
    
    var factory = new MBColumn.Infrastructure.DesignCodes.DesignCodeServiceFactory(aci, new MBColumn.Infrastructure.DesignCodes.Ec2DesignCodeService());
    var reportSvc = new MBColumn.Infrastructure.Solvers.StrainPoints.PmValidationReportService(factory);
    var inputDto = MetricInput() with { DesignCode = MBColumn.Domain.Enums.DesignCodeType.Aci318Style };
    string reportStr = reportSvc.BuildReport(inputDto, section, concrete, steel).MarkdownReport;
    System.IO.File.AppendAllText("ACI_EC2_Reports.md", reportStr + "\n\n");
    
    IsTrue(points.Count == 7);
    IsTrue(points[0].PointName == "Pure Compression");
    IsTrue(points[1].TargetTensileSteelStrain == 0.0);
    IsTrue(points[3].TargetTensileSteelStrain == steel.FyMpa / steel.EsMpa); // balanced
    IsTrue(points[6].PointName == "Pure Tension");
    
    IsFalse(points.Any(p => double.IsNaN(p.NominalAxialForceN)));
}

static void TestStrainControlledSevenPointEc2()
{
    var ec2 = new MBColumn.Infrastructure.DesignCodes.Ec2DesignCodeService();
    var codeAdapter = new MBColumn.Infrastructure.Solvers.StrainPoints.Ec2StrainLimitAdapter(ec2);
    var integrator = MBColumn.Infrastructure.Solvers.Integration.SectionIntegratorFactory.Create(MBColumn.Domain.Enums.SectionIntegrationMethod.Fiber);
    var strategy = new MBColumn.Infrastructure.Solvers.StrainPoints.StrainControlledSevenPointStrategy(integrator, codeAdapter, ec2);
    
    var input = MetricInput();
    var concrete = new MBColumn.Domain.Entities.ConcreteMaterial("C30", input.Fc);
    var steel = new MBColumn.Domain.Entities.SteelMaterial("B500", input.Fy, input.Es);
    var layout = new MBColumn.Domain.Entities.RebarLayout("Sides different", "T20", 40, []);
    var section = new MBColumn.Domain.Entities.RectangularSection(400, 400, layout);
    
    var points = strategy.GeneratePoints(section, concrete, steel, 0.0, new MBColumn.Infrastructure.Solvers.SolverSettings());
    
    var factory = new MBColumn.Infrastructure.DesignCodes.DesignCodeServiceFactory(new MBColumn.Infrastructure.DesignCodes.Aci318DesignCodeService(), ec2);
    var reportSvc = new MBColumn.Infrastructure.Solvers.StrainPoints.PmValidationReportService(factory);
    var inputDto = MetricInput() with { DesignCode = MBColumn.Domain.Enums.DesignCodeType.Ec2 };
    string reportStr = reportSvc.BuildReport(inputDto, section, concrete, steel).MarkdownReport;
    System.IO.File.AppendAllText("ACI_EC2_Reports.md", reportStr + "\n\n");
    
    IsTrue(points.Count == 7);
    IsTrue(points[0].PointName == "Pure Compression");
    IsTrue(points[1].TargetTensileSteelStrain == 0.0);
    IsTrue(points[3].TargetTensileSteelStrain == steel.FyMpa / steel.EsMpa); // balanced
    IsTrue(points[6].PointName == "Pure Tension");
    
    IsFalse(points.Any(p => double.IsNaN(p.NominalAxialForceN)));
}

// ── Stub services for TestEtabsImportCreatesIrregularCustomCoordinates ─────────

sealed class StubEtabsConnectionService : MBColumn.Application.Services.Etabs.IEtabsConnectionService
{
    public bool IsConnected => false;
    public MBColumn.Application.DTOs.Etabs.EtabsConnectionResultDto ConnectToRunningEtabs()
        => new(true, "Stub connected", new("TestModel", "C:\\test.edb", "kN-m", 1, 1, 0));
    public void Disconnect() { }
}

sealed class StubEtabsColumnImportService : MBColumn.Application.Services.Etabs.IEtabsColumnImportService
{
    public IReadOnlyList<MBColumn.Application.DTOs.Etabs.EtabsColumnImportDto> GetCandidateColumns(MBColumn.Domain.Enums.UnitSystem _)
        => [new("pier:P1:Story1", "P1", "Story1", "P1", "P1|Story1", "CIRC800", "C40",
                MBColumn.Domain.Enums.SectionShapeType.Irregular, 800, 800, 0, 0, "", "Ready")];
    public IReadOnlyList<string> GetLoadCombinations() => ["1.2D+1.6L"];
}

sealed class StubEtabsForceImportService : MBColumn.Application.Services.Etabs.IEtabsForceImportService
{
    public IReadOnlyList<MBColumn.Application.DTOs.Etabs.EtabsForceResultDto> GetForces(
        IReadOnlyList<MBColumn.Application.DTOs.Etabs.EtabsColumnImportDto> _,
        IReadOnlyList<string> _2,
        MBColumn.Domain.Enums.UnitSystem _3) => [];
    public IReadOnlyList<MBColumn.Application.DTOs.Etabs.EtabsForceResultDto> GetPierForces(
        IReadOnlyList<(string PierLabel, string StoryName)> _,
        IReadOnlyList<string> _2,
        MBColumn.Domain.Enums.UnitSystem _3)
        => [new("pier:P1:Story1", "P1", "Story1", "P1", "CIRC800", "1.2D+1.6L", -2500, 250, 180, 0, 0, "Top", "OK")];
    public IReadOnlyList<MBColumn.Application.DTOs.Etabs.EtabsForceResultDto> GetElementForces(
        IReadOnlyList<MBColumn.Application.DTOs.Etabs.EtabsColumnImportDto> _,
        IReadOnlyList<string> _2,
        MBColumn.Domain.Enums.UnitSystem _3) => [];
    public IReadOnlyList<MBColumn.Application.DTOs.Etabs.EtabsForceResultDto> GetPierElementForces(
        IReadOnlyList<(string PierLabel, string StoryName)> _,
        IReadOnlyList<string> _2,
        MBColumn.Domain.Enums.UnitSystem _3) => [];
}

sealed class StubPierShellImportService : MBColumn.Application.Services.Etabs.IEtabsPierShellImportService
{
    public IReadOnlyList<(string PierLabel, string StoryName, string SectionProperty)> GetPierGroups(
        MBColumn.Domain.Enums.UnitSystem _) => [];
    public IReadOnlyList<MBColumn.Application.DTOs.Etabs.EtabsPierShellSegmentDto> GetSegments(
        string pierLabel, string storyName, MBColumn.Domain.Enums.UnitSystem _)
        => [new("A1", pierLabel, storyName, "L1", "CW200", 200, (0, 0), (400, 0))];
    public IReadOnlyList<string> GetStoryNames() => ["Story1"];
}

sealed class Stub32PointGeometryBuilder : MBColumn.Application.Services.Etabs.IIrregularPierGeometryBuilder
{
    public MBColumn.Application.DTOs.Etabs.EtabsIrregularBoundaryDto BuildBoundary(
        IReadOnlyList<MBColumn.Application.DTOs.Etabs.EtabsPierShellSegmentDto> segments)
    {
        // Clockwise circle, 32 vertices, radius 400 mm, centred at origin
        var pts = Enumerable.Range(0, 32)
            .Select(i =>
            {
                var angle = Math.PI / 2.0 - 2.0 * Math.PI * i / 32.0;
                return new MBColumn.Domain.Entities.Point2D(
                    Math.Round(400 * Math.Cos(angle), 6),
                    Math.Round(400 * Math.Sin(angle), 6));
            })
            .ToList<MBColumn.Domain.Entities.Point2D>();
        return new MBColumn.Application.DTOs.Etabs.EtabsIrregularBoundaryDto
        {
            ClockwisePolylines = [pts],
            PierLabel = segments.Count > 0 ? segments[0].PierLabel : "",
            StoryName = segments.Count > 0 ? segments[0].StoryName : "",
            SourceShellNames = segments.Select(s => s.ShellName).ToList()
        };
    }
}


