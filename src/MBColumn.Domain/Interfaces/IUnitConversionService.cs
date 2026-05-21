using MBColumn.Domain.Enums;

namespace MBColumn.Domain.Interfaces;

public interface IUnitConversionService
{
    double LengthToMm(double value, LengthUnit unit);
    double LengthFromMm(double valueMm, LengthUnit unit);
    double ConvertLength(double value, LengthUnit fromUnit, LengthUnit toUnit);
    double ForceToN(double value, ForceUnit unit);
    double ForceFromN(double valueN, ForceUnit unit);
    double ConvertForce(double value, ForceUnit fromUnit, ForceUnit toUnit);
    double MomentToNmm(double value, MomentUnit unit);
    double MomentFromNmm(double valueNmm, MomentUnit unit);
    double ConvertMoment(
        double value,
        ForceUnit fromForceUnit,
        LengthUnit fromLengthUnit,
        ForceUnit toForceUnit,
        LengthUnit toLengthUnit);
    double StressToMpa(double value, StressUnit unit);
    double StressFromMpa(double valueMpa, StressUnit unit);
}

