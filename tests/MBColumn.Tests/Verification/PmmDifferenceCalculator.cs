namespace MBColumn.Tests.Verification;

public sealed class PmmDifferenceCalculator
{
    public PmmComparisonRow Calculate(PmmReferencePoint reference, PmmCalculatedPoint calculated, PmmComparisonOptions options)
    {
        double diffP = calculated.CalcP - reference.RefP;
        double diffM = calculated.CalcM - reference.RefM;
        bool refPIsZero = Math.Abs(reference.RefP) <= options.ZeroReferenceThreshold;
        bool refMIsZero = Math.Abs(reference.RefM) <= options.ZeroReferenceThreshold;

        double? percentDiffP = refPIsZero ? null : diffP / reference.RefP * 100.0;
        double? percentDiffM = refMIsZero ? null : diffM / reference.RefM * 100.0;

        bool pPass = refPIsZero
            ? Math.Abs(diffP) <= options.AbsoluteAxialTolerance
            : Math.Abs(percentDiffP!.Value) <= options.PercentTolerance || Math.Abs(diffP) <= options.AbsoluteAxialTolerance;

        bool mPass = refMIsZero
            ? Math.Abs(diffM) <= options.AbsoluteMomentTolerance
            : Math.Abs(percentDiffM!.Value) <= options.PercentTolerance || Math.Abs(diffM) <= options.AbsoluteMomentTolerance;

        string pStatus = pPass ? "PASS" : "FAIL";
        string mStatus = mPass ? "PASS" : "FAIL";
        bool overallPass = pPass && mPass;
        string overallStatus = overallPass ? "PASS" : "FAIL";

        return new PmmComparisonRow(
            reference.PointIndex,
            reference.ThetaDegrees,
            reference.RefP,
            calculated.CalcP,
            diffP,
            percentDiffP,
            reference.RefM,
            calculated.CalcM,
            diffM,
            percentDiffM,
            pPass,
            mPass,
            overallPass,
            pStatus,
            mStatus,
            overallStatus,
            "");
    }
}
