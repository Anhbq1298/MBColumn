using ColumnDesigner.Domain.Enums;
using ColumnDesigner.Domain.Interfaces;

namespace ColumnDesigner.Infrastructure.Math;

public sealed class UnitConversionService : IUnitConversionService
{
    private const double MmPerInch = 25.4;
    private const double NPerKip = 4448.2216152605;
    private const double MpaPerKsi = 6.894757293168;

    public double LengthToMm(double value, LengthUnit unit) => unit == LengthUnit.Inch ? value * MmPerInch : value;
    public double LengthFromMm(double valueMm, LengthUnit unit) => unit == LengthUnit.Inch ? valueMm / MmPerInch : valueMm;
    public double ForceToN(double value, ForceUnit unit) => unit switch { ForceUnit.N => value, ForceUnit.kN => value * 1000.0, ForceUnit.Kip => value * NPerKip, _ => value };
    public double ForceFromN(double valueN, ForceUnit unit) => unit switch { ForceUnit.N => valueN, ForceUnit.kN => valueN / 1000.0, ForceUnit.Kip => valueN / NPerKip, _ => valueN };
    public double MomentToNmm(double value, MomentUnit unit) => unit switch { MomentUnit.Nmm => value, MomentUnit.kNm => value * 1_000_000.0, MomentUnit.KipFt => value * NPerKip * 304.8, MomentUnit.KipIn => value * NPerKip * MmPerInch, _ => value };
    public double MomentFromNmm(double valueNmm, MomentUnit unit) => unit switch { MomentUnit.Nmm => valueNmm, MomentUnit.kNm => valueNmm / 1_000_000.0, MomentUnit.KipFt => valueNmm / (NPerKip * 304.8), MomentUnit.KipIn => valueNmm / (NPerKip * MmPerInch), _ => valueNmm };
    public double StressToMpa(double value, StressUnit unit) => unit switch { StressUnit.MPa => value, StressUnit.Ksi => value * MpaPerKsi, StressUnit.Psi => value * MpaPerKsi / 1000.0, _ => value };
    public double StressFromMpa(double valueMpa, StressUnit unit) => unit switch { StressUnit.MPa => valueMpa, StressUnit.Ksi => valueMpa / MpaPerKsi, StressUnit.Psi => valueMpa / MpaPerKsi * 1000.0, _ => valueMpa };
}
