using MBColumn.Application.DTOs;
using MBColumn.Application.Services;
using MBColumn.Domain.Enums;
using MBColumn.Infrastructure.DesignCodes;
using MBColumn.Infrastructure.Rebar;
using MBColumn.Infrastructure.Solvers;
using MBColumn.Infrastructure.Solvers.StrainPoints;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MBColumn.Tests.Baseline;

/// <summary>
/// Runs fixed benchmark cases, exports JSON snapshots to approved-results/, and
/// compares future results against those snapshots to catch solver regressions.
///
/// First run: approved-results/*.json files do not exist — they are generated.
/// Subsequent runs: results are compared against the saved snapshots.
///
/// Run with --generate-baselines to regenerate all approved results unconditionally.
/// </summary>
internal static class BaselineCaseRunner
{
    private static readonly JsonSerializerOptions JsonOpts = new()
    {
        WriteIndented = true,
        Converters = { new JsonStringEnumConverter() }
    };

    private static readonly string ApprovedResultsDir = Path.Combine(
        LocateRepositoryRoot(),
        "tests", "MBColumn.Tests", "Baseline", "approved-results");

    // ── Tolerances ───────────────────────────────────────────────────────────

    private const double ForceTolerance = 0.005;   // 0.5 %
    private const double MomentTolerance = 0.005;  // 0.5 %
    private const double RatioTolerance = 0.010;   // 1.0 %

    // ── Benchmark Inputs ─────────────────────────────────────────────────────

    public static readonly (string Name, ColumnInputDto Input)[] BenchmarkCases =
    [
        (
            "EC2_Rectangular_650x650_20T25",
            new ColumnInputDto(
                UnitSystem.Metric, 650, 650, 55, "T25", 20,
                "Perimeter bars", 35, 500, 200000,
                3000, 280, 200,
                ForceUnit.kN, LengthUnit.Millimeter, MomentUnit.kNm, StressUnit.MPa,
                0, 0)
            {
                DesignCode = DesignCodeType.Ec2
            }
        ),
        (
            "ACI_Rectangular_700x700_28T25",
            new ColumnInputDto(
                UnitSystem.Metric, 700, 700, 55, "T25", 28,
                "Perimeter bars", 28, 420, 200000,
                2500, 250, 180,
                ForceUnit.kN, LengthUnit.Millimeter, MomentUnit.kNm, StressUnit.MPa,
                0, 0)
            {
                DesignCode = DesignCodeType.Aci318Style
            }
        ),
        (
            "EC2_Circular_D600_16T25",
            new ColumnInputDto(
                UnitSystem.Metric, 600, 600, 55, "T25", 16,
                "Equal spacing", 35, 500, 200000,
                2500, 250, 180,
                ForceUnit.kN, LengthUnit.Millimeter, MomentUnit.kNm, StressUnit.MPa,
                0, 0)
            {
                DesignCode = DesignCodeType.Ec2,
                SectionShape = SectionShapeType.Circular,
                Diameter = 600
            }
        )
    ];

    // ── Snapshot Record ───────────────────────────────────────────────────────

    public sealed record BaselineSnapshot(
        string CaseName,
        string GeneratedAt,
        double MaxNominalCompressionKN,
        double MinNominalTensionKN,
        double MaxDesignCompressionKN,
        double MinDesignTensionKN,
        double MaxNominalMnxKNm,
        double MaxNominalMnyKNm,
        double SampleRatio,
        int SurfaceAngleCount,
        int SurfaceDepthCount,
        int PmSurfacePointCount
    );

    // ── Public API ─────────────────────────────────────────────────────────────

    public static void RunAndApprove(string caseName, ColumnInputDto input, bool forceRegenerate = false)
    {
        var svc = BuildService();
        var result = svc.Calculate(input);

        ValidateNoNaN(caseName, result);

        var snapshot = ExtractSnapshot(caseName, result);
        var filePath = Path.Combine(ApprovedResultsDir, $"{caseName}.json");

        if (!File.Exists(filePath) || forceRegenerate)
        {
            Directory.CreateDirectory(ApprovedResultsDir);
            File.WriteAllText(filePath, JsonSerializer.Serialize(snapshot, JsonOpts));
            Console.WriteLine($"  [BASELINE GENERATED] {caseName}.json");
            return;
        }

        var approved = JsonSerializer.Deserialize<BaselineSnapshot>(
            File.ReadAllText(filePath), JsonOpts)!;

        CompareSnapshots(caseName, approved, snapshot);
    }

    public static void GenerateAll()
    {
        foreach (var (name, input) in BenchmarkCases)
            RunAndApprove(name, input, forceRegenerate: true);
    }

    // ── Private Helpers ───────────────────────────────────────────────────────

    private static BaselineSnapshot ExtractSnapshot(string caseName, CalculationResultDto result)
    {
        var pts = result.Surface.Points;
        var units = new MBColumn.Infrastructure.Math.UnitConversionService();

        double maxNomKN = pts.Max(p => p.Pn) / 1000.0;
        double minNomKN = pts.Min(p => p.Pn) / 1000.0;
        double maxDesKN = pts.Max(p => p.PhiPn) / 1000.0;
        double minDesKN = pts.Min(p => p.PhiPn) / 1000.0;
        double maxMnxKNm = pts.Max(p => Math.Abs(p.Mnx)) / 1_000_000.0;
        double maxMnyKNm = pts.Max(p => Math.Abs(p.Mny)) / 1_000_000.0;

        return new BaselineSnapshot(
            CaseName: caseName,
            GeneratedAt: DateTime.UtcNow.ToString("yyyy-MM-dd"),
            MaxNominalCompressionKN: Math.Round(maxNomKN, 2),
            MinNominalTensionKN: Math.Round(minNomKN, 2),
            MaxDesignCompressionKN: Math.Round(maxDesKN, 2),
            MinDesignTensionKN: Math.Round(minDesKN, 2),
            MaxNominalMnxKNm: Math.Round(maxMnxKNm, 2),
            MaxNominalMnyKNm: Math.Round(maxMnyKNm, 2),
            SampleRatio: Math.Round(result.Ratio, 4),
            SurfaceAngleCount: result.Surface.AngleCount,
            SurfaceDepthCount: result.Surface.DepthCount,
            PmSurfacePointCount: result.ControlPoints.PmmSurfacePoints.Count
        );
    }

    private static void CompareSnapshots(string caseName, BaselineSnapshot approved, BaselineSnapshot actual)
    {
        AssertClose(caseName, "MaxNominalCompressionKN",
            approved.MaxNominalCompressionKN, actual.MaxNominalCompressionKN, ForceTolerance);
        AssertClose(caseName, "MinNominalTensionKN",
            approved.MinNominalTensionKN, actual.MinNominalTensionKN, ForceTolerance);
        AssertClose(caseName, "MaxDesignCompressionKN",
            approved.MaxDesignCompressionKN, actual.MaxDesignCompressionKN, ForceTolerance);
        AssertClose(caseName, "MinDesignTensionKN",
            approved.MinDesignTensionKN, actual.MinDesignTensionKN, ForceTolerance);
        AssertClose(caseName, "MaxNominalMnxKNm",
            approved.MaxNominalMnxKNm, actual.MaxNominalMnxKNm, MomentTolerance);
        AssertClose(caseName, "MaxNominalMnyKNm",
            approved.MaxNominalMnyKNm, actual.MaxNominalMnyKNm, MomentTolerance);
        AssertClose(caseName, "SampleRatio",
            approved.SampleRatio, actual.SampleRatio, RatioTolerance);

        if (approved.SurfaceAngleCount != actual.SurfaceAngleCount)
            throw new InvalidOperationException(
                $"[{caseName}] SurfaceAngleCount changed: expected {approved.SurfaceAngleCount}, got {actual.SurfaceAngleCount}.");

        if (approved.SurfaceDepthCount != actual.SurfaceDepthCount)
            throw new InvalidOperationException(
                $"[{caseName}] SurfaceDepthCount changed: expected {approved.SurfaceDepthCount}, got {actual.SurfaceDepthCount}.");

        if (approved.PmSurfacePointCount != actual.PmSurfacePointCount)
            throw new InvalidOperationException(
                $"[{caseName}] PmSurfacePointCount changed: expected {approved.PmSurfacePointCount}, got {actual.PmSurfacePointCount}.");
    }

    private static void AssertClose(
        string caseName, string field, double expected, double actual, double relativeTolerance)
    {
        double diff = Math.Abs(expected - actual);
        double allowed = Math.Abs(expected) * relativeTolerance + 1e-6;
        if (diff > allowed)
            throw new InvalidOperationException(
                $"[{caseName}] {field} regression: expected {expected:F4}, got {actual:F4}, " +
                $"diff {diff:F6} > tolerance {allowed:F6}.");
    }

    private static void ValidateNoNaN(string caseName, CalculationResultDto result)
    {
        foreach (var p in result.Surface.Points)
        {
            if (double.IsNaN(p.Pn) || double.IsInfinity(p.Pn))
                throw new InvalidOperationException($"[{caseName}] NaN/Infinity in Pn.");
            if (double.IsNaN(p.Mnx) || double.IsInfinity(p.Mnx))
                throw new InvalidOperationException($"[{caseName}] NaN/Infinity in Mnx.");
            if (double.IsNaN(p.Mny) || double.IsInfinity(p.Mny))
                throw new InvalidOperationException($"[{caseName}] NaN/Infinity in Mny.");
        }
    }

    private static ColumnCalculationService BuildService()
    {
        var aci = new Aci318DesignCodeService();
        var ec2 = new Ec2DesignCodeService();
        var codeFactory = new DesignCodeServiceFactory(aci, ec2);
        var solverFactory = new InteractionSolverFactory(aci, ec2);
        var units = new MBColumn.Infrastructure.Math.UnitConversionService();
        return new ColumnCalculationService(
            solverFactory, codeFactory, units,
            new SingaporeRebarDatabase(), new ImperialRebarDatabase(),
            new RatioCheckService(),
            new ControlPointBuilderService(units),
            new DiagramDataService(),
            new InputValidationService(),
            new PmValidationReportService(codeFactory));
    }

    private static string LocateRepositoryRoot()
    {
        var dir = new DirectoryInfo(AppContext.BaseDirectory);
        while (dir != null)
        {
            if (File.Exists(Path.Combine(dir.FullName, "MBColumn.sln")))
                return dir.FullName;
            dir = dir.Parent;
        }
        throw new FileNotFoundException(
            "Repository root containing MBColumn.sln could not be located.");
    }
}
