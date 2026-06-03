using MBColumn.Domain.Enums;

namespace MBColumn.Domain.Units;

public sealed record UnitProfile(
    UnitSystem UnitSystem,
    LengthUnit SectionSizeUnit,
    LengthUnit MemberLengthUnit,
    ForceUnit ForceUnit,
    MomentUnit MomentUnit,
    StressUnit StressUnit)
{
    public static UnitProfile Metric { get; } = new(
        UnitSystem.Metric,
        LengthUnit.Millimeter,
        LengthUnit.Meter,
        ForceUnit.kN,
        MomentUnit.kNm,
        StressUnit.MPa);

    public static UnitProfile Imperial { get; } = new(
        UnitSystem.Imperial,
        LengthUnit.Inch,
        LengthUnit.Foot,
        ForceUnit.Kip,
        MomentUnit.KipFt,
        StressUnit.Ksi);

    public string SectionSizeLabel => Label(SectionSizeUnit);
    public string MemberLengthLabel => Label(MemberLengthUnit);
    public string ForceLabel => Label(ForceUnit);
    public string MomentLabel => Label(MomentUnit);
    public string StressLabel => Label(StressUnit);
    public string SectionAreaLabel => AreaLabel(SectionSizeUnit);
    public string RebarAreaLabel => AreaLabel(SectionSizeUnit);
    public string SectionInertiaLabel => InertiaLabel(SectionSizeUnit);
    public string LinearWeightLabel => UnitSystem == UnitSystem.Metric ? "kg/m" : "lb/ft";

    public static UnitProfile For(UnitSystem unitSystem)
        => unitSystem == UnitSystem.Metric ? Metric : Imperial;

    public string Label(EngineeringUnitCategory category)
        => category switch
        {
            EngineeringUnitCategory.SectionSize => SectionSizeLabel,
            EngineeringUnitCategory.MemberLength => MemberLengthLabel,
            EngineeringUnitCategory.RebarDiameter => SectionSizeLabel,
            EngineeringUnitCategory.SectionArea => SectionAreaLabel,
            EngineeringUnitCategory.RebarArea => RebarAreaLabel,
            EngineeringUnitCategory.SectionInertia => SectionInertiaLabel,
            EngineeringUnitCategory.Force => ForceLabel,
            EngineeringUnitCategory.Moment => MomentLabel,
            EngineeringUnitCategory.Stress => StressLabel,
            EngineeringUnitCategory.LinearWeight => LinearWeightLabel,
            _ => ""
        };

    public string LatexLabel(EngineeringUnitCategory category)
        => category switch
        {
            EngineeringUnitCategory.SectionSize => LatexLabel(SectionSizeUnit),
            EngineeringUnitCategory.MemberLength => LatexLabel(MemberLengthUnit),
            EngineeringUnitCategory.Force => LatexLabel(ForceUnit),
            EngineeringUnitCategory.Moment => LatexLabel(MomentUnit),
            EngineeringUnitCategory.Stress => LatexLabel(StressUnit),
            _ => Label(category)
        };

    public static string Label(LengthUnit unit)
        => unit switch
        {
            LengthUnit.Millimeter => "mm",
            LengthUnit.Meter => "m",
            LengthUnit.Inch => "in",
            LengthUnit.Foot => "ft",
            _ => unit.ToString()
        };

    public static string Label(ForceUnit unit)
        => unit switch
        {
            ForceUnit.N => "N",
            ForceUnit.kN => "kN",
            ForceUnit.Kip => "kip",
            _ => unit.ToString()
        };

    public static string Label(MomentUnit unit)
        => unit switch
        {
            MomentUnit.Nmm => "N-mm",
            MomentUnit.kNm => "kN-m",
            MomentUnit.KipFt => "kip-ft",
            MomentUnit.KipIn => "kip-in",
            _ => unit.ToString()
        };

    public static string Label(StressUnit unit)
        => unit switch
        {
            StressUnit.MPa => "MPa",
            StressUnit.Ksi => "ksi",
            StressUnit.Psi => "psi",
            _ => unit.ToString()
        };

    public static string LatexLabel(LengthUnit unit)
        => unit switch
        {
            LengthUnit.Millimeter => @"\text{mm}",
            LengthUnit.Meter => @"\text{m}",
            LengthUnit.Inch => @"\text{in}",
            LengthUnit.Foot => @"\text{ft}",
            _ => unit.ToString()
        };

    public static string LatexLabel(ForceUnit unit)
        => unit switch
        {
            ForceUnit.N => @"\mathrm{N}",
            ForceUnit.kN => @"\mathrm{kN}",
            ForceUnit.Kip => @"\mathrm{kip}",
            _ => unit.ToString()
        };

    public static string LatexLabel(MomentUnit unit)
        => unit switch
        {
            MomentUnit.Nmm => @"\mathrm{N\cdot mm}",
            MomentUnit.kNm => @"\mathrm{kN\cdot m}",
            MomentUnit.KipFt => @"\mathrm{kip\cdot ft}",
            MomentUnit.KipIn => @"\mathrm{kip\cdot in}",
            _ => unit.ToString()
        };

    public static string LatexLabel(StressUnit unit)
        => unit switch
        {
            StressUnit.MPa => @"\mathrm{MPa}",
            StressUnit.Ksi => @"\mathrm{ksi}",
            StressUnit.Psi => @"\mathrm{psi}",
            _ => unit.ToString()
        };

    private static string AreaLabel(LengthUnit unit)
        => unit switch
        {
            LengthUnit.Millimeter => "mm²",
            LengthUnit.Meter => "m²",
            LengthUnit.Inch => "in²",
            LengthUnit.Foot => "ft²",
            _ => $"{Label(unit)}²"
        };

    private static string InertiaLabel(LengthUnit unit)
        => unit switch
        {
            LengthUnit.Millimeter => "mm⁴",
            LengthUnit.Meter => "m⁴",
            LengthUnit.Inch => "in⁴",
            LengthUnit.Foot => "ft⁴",
            _ => $"{Label(unit)}⁴"
        };
}
