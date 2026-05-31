namespace MBColumn.Application.Reports.Models;

public sealed record RebarContributionRow(
    int Index,
    string XMm,
    string YMm,
    string DMm,
    string EpsilonS,
    string FsMpa,
    string AsMm2,
    string FsKn,
    string FsYKnm,
    string FsXKnm);
