namespace MBColumn.Application.DTOs;

public sealed record SevenPointValidationRowDto(
    string PointName,
    string HandCalcState,
    double HandCalcC,
    double HandCalcPn,
    double HandCalcMn,
    double SolverPn,
    double SolverMn,
    double PnDeviationPercent,
    double MnDeviationPercent
);
