using System.Globalization;

namespace MBColumn.Tests.Verification;

public sealed class PmmStressBlockDiagnostic
{
    private readonly PmmPointMatcher matcher = new(new PmmDifferenceCalculator(), new PmmStatisticsCalculator());

    public IReadOnlyList<PmmStressBlockDiagnosticRow> Run(string docxPath)
    {
        var reference = new DocxPmmReferenceReader().Read(docxPath);
        var mapped = new PmmReferenceMapper().Map(reference);
        var runner = new MbColumnPmmRunner();
        var options = new PmmComparisonOptions();
        var rows = new List<PmmStressBlockDiagnosticRow>();

        foreach (var variant in Variants())
        {
            var runOptions = new PmmRunOptions(
                NeutralAxisSamples: 100,
                AngleStepDegrees: 1,
                SolverKind: variant.Kind);

            var raw = runner.Run(mapped, runOptions);
            var bestVariantRows = MomentSignModes()
                .Select(signMode => BuildRow(reference.ReferencePoints, options, variant, raw, signMode))
                .OrderBy(row => row.Theta153MeanAbsDiffM)
                .ThenBy(row => row.OverallMeanAbsDiffM)
                .ThenBy(row => row.TotalFailedPoints)
                .ToList();

            rows.Add(bestVariantRows[0]);
        }

        return rows
            .OrderBy(row => row.Theta153MeanAbsDiffM)
            .ThenBy(row => row.Theta153MaxAbsDiffM)
            .ThenBy(row => row.TotalFailedPoints)
            .ToList();
    }

    public static void Print(IReadOnlyList<PmmStressBlockDiagnosticRow> rows)
    {
        Console.WriteLine();
        Console.WriteLine("=== EC2 strain-domain and stress-block diagnostic ===");
        Console.WriteLine("All cases use the same DOCX section, material, rebar, ref+90 theta map, 100 PM samples, and reference-axis moment projection.");
        Console.WriteLine();
        Console.WriteLine("Variant assumptions:");
        foreach (var row in rows)
        {
            Console.WriteLine($"- {row.SolverName}:");
            Console.WriteLine($"  strain domain: {row.StrainDomain}");
            Console.WriteLine($"  concrete stress: {row.ConcreteStressModel}");
            Console.WriteLine($"  NA sweep: {row.NeutralAxisSweep}");
            Console.WriteLine($"  best Mx/My sign normalization: {row.MomentComponentSign}");
        }

        Console.WriteLine();
        Console.WriteLine("Comparison summary, sorted by theta153 mean |DiffM|:");
        foreach (var row in rows)
        {
            Console.WriteLine(
                $"{row.SolverName,-28} | " +
                $"total fail={row.TotalFailedPoints,4}, " +
                $"max |dP|={Format(row.MaxAbsDiffP),9} kN, " +
                $"max |dM|={Format(row.MaxAbsDiffM),9} kNm, " +
                $"all mean |dM|={Format(row.OverallMeanAbsDiffM),9} kNm");
            Console.WriteLine(
                $"{"",-28} | " +
                $"theta153 fail={row.Theta153FailedPoints,3}, " +
                $"mean |dM|={Format(row.Theta153MeanAbsDiffM),9} kNm, " +
                $"max |dM|={Format(row.Theta153MaxAbsDiffM),9} kNm, " +
                $"M@P~0={Format(row.Theta153ZeroAxialMoment),9} kNm");
            Console.WriteLine(
                $"{"",-28} | " +
                $"theta207 fail={row.Theta207FailedPoints,3}, " +
                $"mean |dM|={Format(row.Theta207MeanAbsDiffM),9} kNm, " +
                $"max |dM|={Format(row.Theta207MaxAbsDiffM),9} kNm, " +
                $"M@P~0={Format(row.Theta207ZeroAxialMoment),9} kNm");
            Console.WriteLine(
                $"{"",-28} | calc P range: {Format(row.MinCalcP),9} to {Format(row.MaxCalcP),9} kN");
        }

        Console.WriteLine();
        Console.WriteLine("Interpretation hints:");
        Console.WriteLine("- If parabolic variants cluster together, the theta153 issue is not mainly concrete stress-block shape.");
        Console.WriteLine("- If simplified stress block moves theta153 strongly, check whether the reference used EC2 3.1.7 rectangular block instead of parabolic-rectangular integration.");
        Console.WriteLine("- If all variants remain similarly high at theta153/207, convention, projection axis, or reference point generation is more likely than strain/stress law.");
    }

    private static IReadOnlyList<SolverVariant> Variants()
        => new[]
        {
            new SolverVariant(
                "Analytic parabolic fiber",
                PmmVerificationSolverKind.AnalyticParabolicFiber,
                "strain endpoints: eps_top=0.0035 for first 80%, eps_bottom -0.050 to 0.000; final 20% transitions toward eps_c2=0.002 uniform compression",
                "EC2 parabolic-rectangular, eps_c2=0.002, eps_cu2=0.0035, n=2, fcd=alpha_cc*fck/gamma_c",
                "direct strain endpoint sweep over full projected section depth"),
            new SolverVariant(
                "Grid parabolic fiber",
                PmmVerificationSolverKind.GridParabolicFiber,
                "EC2 neutral-axis depth c sweep with pivot-C branch when c exceeds projected section depth",
                "EC2 parabolic-rectangular fiber grid, eps_c2=0.002, eps_cu2=0.0035, n=2, fcd=alpha_cc*fck/gamma_c",
                "logarithmic c sweep from 5 mm to 20D plus pure compression pole"),
            new SolverVariant(
                "Boundary parabolic",
                PmmVerificationSolverKind.BoundaryParabolic,
                "EC2 neutral-axis depth c sweep with pivot-C branch when c exceeds projected section depth",
                "EC2 parabolic-rectangular integrated over clipped compressed polygon slices",
                "linear c sweep from 5 mm to 3D plus pure compression pole"),
            new SolverVariant(
                "Simplified stress block",
                PmmVerificationSolverKind.SimplifiedStressBlock,
                "linear strain profile using eps_cu3=0.0035 and pure compression eps_c3=0.00175",
                "EC2 3.1.7 rectangular block: lambda=0.8 and eta=1.0 for fck <= 50 MPa",
                "linear c sweep from 5 mm to 3D plus pure compression pole")
        };

    private PmmStressBlockDiagnosticRow BuildRow(
        IReadOnlyList<PmmReferencePoint> referencePoints,
        PmmComparisonOptions options,
        SolverVariant variant,
        IReadOnlyList<PmmCalculatedPoint> raw,
        MomentSignMode signMode)
    {
        var projected = raw.Select(point => ProjectMomentToReferenceAxis(point, signMode)).ToList();
        var comparisons = matcher.Match(referencePoints, projected, options);
        var theta153 = FindTheta(comparisons, 153);
        var theta207 = FindTheta(comparisons, 207);

        return new PmmStressBlockDiagnosticRow(
            variant.Name,
            variant.StrainDomain,
            variant.ConcreteStressModel,
            variant.NeutralAxisSweep,
            signMode.Name,
            comparisons.Sum(comparison => comparison.Statistics.FailCount),
            comparisons.Max(comparison => comparison.Statistics.MaxAbsDiffP),
            comparisons.Max(comparison => comparison.Statistics.MaxAbsDiffM),
            MeanAbsDiffM(comparisons),
            theta153.Statistics.FailCount,
            theta153.Statistics.MaxAbsDiffM,
            MeanAbsDiffM(theta153),
            theta207.Statistics.FailCount,
            theta207.Statistics.MaxAbsDiffM,
            MeanAbsDiffM(theta207),
            projected.Min(point => point.CalcP),
            projected.Max(point => point.CalcP),
            ZeroAxialMoment(theta153),
            ZeroAxialMoment(theta207));
    }

    private static IReadOnlyList<MomentSignMode> MomentSignModes()
        => new[]
        {
            new MomentSignMode("+Mx,+My", 1.0, 1.0),
            new MomentSignMode("-Mx,+My", -1.0, 1.0),
            new MomentSignMode("+Mx,-My", 1.0, -1.0),
            new MomentSignMode("-Mx,-My", -1.0, -1.0)
        };

    private static PmmCalculatedPoint ProjectMomentToReferenceAxis(PmmCalculatedPoint point, MomentSignMode signMode)
    {
        double theta = point.ThetaDegrees * Math.PI / 180.0;
        double mx = signMode.MxSign * point.CalcMx;
        double my = signMode.MySign * point.CalcMy;
        double projectedMoment = Math.Abs(mx * Math.Cos(theta) + my * Math.Sin(theta));
        return point with { CalcMx = projectedMoment, CalcMy = 0.0 };
    }

    private static PmmThetaComparison FindTheta(IReadOnlyList<PmmThetaComparison> comparisons, int theta)
        => comparisons.Single(comparison => comparison.ThetaDegrees == theta);

    private static double MeanAbsDiffM(IReadOnlyList<PmmThetaComparison> comparisons)
        => comparisons
            .SelectMany(comparison => comparison.Rows)
            .DefaultIfEmpty()
            .Average(row => row is null ? 0.0 : Math.Abs(row.DiffM));

    private static double MeanAbsDiffM(PmmThetaComparison comparison)
        => comparison.Rows.Count == 0 ? 0.0 : comparison.Rows.Average(row => Math.Abs(row.DiffM));

    private static double ZeroAxialMoment(PmmThetaComparison comparison)
        => comparison.Rows.Count == 0
            ? 0.0
            : comparison.Rows.OrderBy(row => Math.Abs(row.RefP)).First().CalcM;

    private static string Format(double value)
        => value.ToString("F3", CultureInfo.InvariantCulture);

    private sealed record SolverVariant(
        string Name,
        PmmVerificationSolverKind Kind,
        string StrainDomain,
        string ConcreteStressModel,
        string NeutralAxisSweep);

    private sealed record MomentSignMode(string Name, double MxSign, double MySign);
}

public sealed record PmmStressBlockDiagnosticRow(
    string SolverName,
    string StrainDomain,
    string ConcreteStressModel,
    string NeutralAxisSweep,
    string MomentComponentSign,
    int TotalFailedPoints,
    double MaxAbsDiffP,
    double MaxAbsDiffM,
    double OverallMeanAbsDiffM,
    int Theta153FailedPoints,
    double Theta153MaxAbsDiffM,
    double Theta153MeanAbsDiffM,
    int Theta207FailedPoints,
    double Theta207MaxAbsDiffM,
    double Theta207MeanAbsDiffM,
    double MinCalcP,
    double MaxCalcP,
    double Theta153ZeroAxialMoment,
    double Theta207ZeroAxialMoment);
