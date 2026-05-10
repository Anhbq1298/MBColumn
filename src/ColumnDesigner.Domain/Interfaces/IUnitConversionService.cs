using ColumnDesigner.Domain.Enums;

namespace ColumnDesigner.Domain.Interfaces;

public interface IUnitConversionService
{
    double LengthToMm(double value, LengthUnit unit);
    double LengthFromMm(double valueMm, LengthUnit unit);
    double ForceToN(double value, ForceUnit unit);
    double ForceFromN(double valueN, ForceUnit unit);
    double MomentToNmm(double value, MomentUnit unit);
    double MomentFromNmm(double valueNmm, MomentUnit unit);
    double StressToMpa(double value, StressUnit unit);
    double StressFromMpa(double valueMpa, StressUnit unit);
}
