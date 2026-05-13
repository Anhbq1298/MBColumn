namespace MBColumn.Tests.Verification;

public static class GeminiComparisonRunner
{
    public static PmmDocxComparisonResult RunDocxComparison(
        string docxPath,
        string csvOutputPath,
        PmmComparisonOptions? options = null)
        => new GeminiDocxPmmVerificationRunner().Run(docxPath, csvOutputPath, options);

    public static void PrintComparisonReport(PmmDocxComparisonResult result)
        => GeminiDocxPmmVerificationRunner.PrintDebugOutput(result);
}
