namespace MBColumn.Application.DTOs;

public sealed record ControlPointValidationRow(
    string ControlPointId,
    string ControlPointName,
    string Assumption,
    bool IsSupported,
    IReadOnlyList<ReportFormulaBlock> FormulaBlocks,
    double HandPnDisplay,
    double HandMxDisplay,
    double HandMyDisplay,
    double SolverPnDisplay,
    double SolverMxDisplay,
    double SolverMyDisplay,
    double DifferencePPercent,
    double DifferenceMPercent,
    string Status,
    string ForceUnitLabel,
    string MomentUnitLabel);
