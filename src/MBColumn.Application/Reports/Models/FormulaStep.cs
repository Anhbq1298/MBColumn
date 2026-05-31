namespace MBColumn.Application.Reports.Models;

public sealed record FormulaStep(
    string Title,
    string LatexFormula,
    string SubstitutionText,
    string ResultText);
