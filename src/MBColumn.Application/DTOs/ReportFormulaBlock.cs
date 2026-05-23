namespace MBColumn.Application.DTOs;

public sealed record ReportFormulaBlock(
    string Title,
    string LatexFormula,
    string SubstitutionLatex,
    string ResultLatex);
