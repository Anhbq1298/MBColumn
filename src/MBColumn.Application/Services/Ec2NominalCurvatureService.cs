using MBColumn.Application.DTOs;
using MBColumn.Domain.Entities;
using MBColumn.Domain.Interfaces;

namespace MBColumn.Application.Services;

public interface IEc2NominalCurvatureService
{
    Ec2SlendernessBatchResultDto Calculate(
        ColumnSection section,
        Ec2ConcreteMaterialDto concrete,
        SteelMaterial steel,
        MemberGeometryInputDto memberGeometry,
        Ec2SlendernessSettingsDto settings,
        IReadOnlyList<LoadCaseDto> loadCases);
}

public sealed class Ec2NominalCurvatureService(IUnitConversionService units) : IEc2NominalCurvatureService
{
    private const double GammaS = 1.15;
    private const double Nbal = 0.4;
    private const double CurvatureShapeFactor = 10.0;
    private const double Tolerance = 1e-9;

    public Ec2SlendernessBatchResultDto Calculate(
        ColumnSection section,
        Ec2ConcreteMaterialDto concrete,
        SteelMaterial steel,
        MemberGeometryInputDto memberGeometry,
        Ec2SlendernessSettingsDto settings,
        IReadOnlyList<LoadCaseDto> loadCases)
    {
        var warnings = new List<string>();
        if (!settings.IncludeEc2Slenderness)
        {
            return Ec2SlendernessBatchResultDto.Empty;
        }

        if (section is IrregularSection)
        {
            return Ec2SlendernessBatchResultDto.Empty;
        }

        if (memberGeometry.LengthL is not > 0)
        {
            warnings.Add("Column length L is missing in Section & Rebar.");
        }

        if (settings.Kx is not > 0)
        {
            warnings.Add("kx must be greater than zero.");
        }

        if (settings.Ky is not > 0)
        {
            warnings.Add("ky must be greater than zero.");
        }

        if (settings.PhiEff is < 0)
        {
            warnings.Add("Effective creep ratio phiEff must be zero or greater.");
        }

        var sectionValues = ExtractSectionValues(section, concrete, steel);
        double? l0x = memberGeometry.LengthL is > 0 && settings.Kx is > 0
            ? settings.Kx.Value * memberGeometry.LengthL.Value
            : null;
        double? l0y = memberGeometry.LengthL is > 0 && settings.Ky is > 0
            ? settings.Ky.Value * memberGeometry.LengthL.Value
            : null;

        var results = new List<Ec2SlendernessLoadCaseResultDto>();
        foreach (var loadCase in loadCases.Where(lc => lc.IsActive))
        {
            double? caseL0x = l0x;
            double? caseL0y = l0y;
            if (loadCase.MemberLengthOverrideMm is > 0)
            {
                caseL0x = settings.Kx is > 0 ? settings.Kx.Value * loadCase.MemberLengthOverrideMm.Value : null;
                caseL0y = settings.Ky is > 0 ? settings.Ky.Value * loadCase.MemberLengthOverrideMm.Value : null;
            }
            results.Add(CalculateLoadCase(section, sectionValues, concrete, steel, loadCase, caseL0x, caseL0y, settings));
        }

        warnings.AddRange(results.SelectMany(r => r.Warnings));
        return new Ec2SlendernessBatchResultDto(results, sectionValues, l0x, l0y, warnings.Distinct().ToList());
    }

    private Ec2SlendernessLoadCaseResultDto CalculateLoadCase(
        ColumnSection section,
        Ec2SlendernessSectionValuesDto sectionValues,
        Ec2ConcreteMaterialDto concrete,
        SteelMaterial steel,
        LoadCaseDto loadCase,
        double? l0x,
        double? l0y,
        Ec2SlendernessSettingsDto settings)
    {
        var warnings = new List<string>();

        double nEdN = units.ForceToN(loadCase.Pu, loadCase.ForceUnit);
        if (nEdN <= 0)
        {
            warnings.Add($"{loadCase.Name}: NEd is tensile or zero; EC2 column slenderness check is not applicable.");
            return new(loadCase.Id, loadCase.Name, null, null, "Invalid NEd", warnings);
        }

        Ec2SlendernessAxisResultDto? x = null;
        Ec2SlendernessAxisResultDto? y = null;

        if (l0x is null || loadCase.MxTop is null || loadCase.MxBottom is null)
        {
            warnings.Add($"{loadCase.Name}: Mx Top and Mx Bottom are required because slenderness is enabled.");
        }
        else
        {
            x = CalculateAxis(
                concrete,
                steel,
                sectionValues,
                nEdN,
                units.MomentToNmm(loadCase.MxTop.Value, loadCase.MomentUnit),
                units.MomentToNmm(loadCase.MxBottom.Value, loadCase.MomentUnit),
                l0x.Value,
                sectionValues.IxMm,
                sectionValues.DxMm,
                section.HeightMm,
                settings);
        }

        if (l0y is null || loadCase.MyTop is null || loadCase.MyBottom is null)
        {
            warnings.Add($"{loadCase.Name}: My Top and My Bottom are required because slenderness is enabled.");
        }
        else
        {
            y = CalculateAxis(
                concrete,
                steel,
                sectionValues,
                nEdN,
                units.MomentToNmm(loadCase.MyTop.Value, loadCase.MomentUnit),
                units.MomentToNmm(loadCase.MyBottom.Value, loadCase.MomentUnit),
                l0y.Value,
                sectionValues.IyMm,
                sectionValues.DyMm,
                section.WidthMm,
                settings);
        }

        string status = (x, y) switch
        {
            (null, _) or (_, null) => "Missing Input",
            ({ IsSlender: true }, { IsSlender: true }) => "Slender X + Y",
            ({ IsSlender: true }, _) => "Slender X",
            (_, { IsSlender: true }) => "Slender Y",
            _ => "Stocky"
        };

        return new(loadCase.Id, loadCase.Name, x, y, status, warnings);
    }

    private static Ec2SlendernessAxisResultDto CalculateAxis(
        Ec2ConcreteMaterialDto concrete,
        SteelMaterial steel,
        Ec2SlendernessSectionValuesDto sectionValues,
        double nEdN,
        double mTopNmm,
        double mBottomNmm,
        double l0Mm,
        double radiusOfGyrationMm,
        double effectiveDepthMm,
        double sectionDimensionMm,
        Ec2SlendernessSettingsDto settings)
    {
        var warnings = new List<string>();
        if (radiusOfGyrationMm <= Tolerance)
        {
            warnings.Add("Radius of gyration is invalid.");
            return new(0, 0, false, 0, 0.7, 1, 1.7, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1.0, 1.0, 0, 0, warnings);
        }

        double lambda = l0Mm / radiusOfGyrationMm;
        double eiMm = l0Mm / 400.0;
        double e0Mm = Math.Max(sectionDimensionMm / 30.0, 20.0);
        double imperfectionMomentNmm = nEdN * eiMm;

        // PD 6687: M02 = Max{|Mtop|,|Mbot|} + Mi, M01 = Min{|Mtop|,|Mbot|} + Mi (both unsigned)
        // rm = M01/M02 in (0,1]. Sign of MEd follows the larger original end moment.
        double mAbsTop = Math.Abs(mTopNmm);
        double mAbsBot = Math.Abs(mBottomNmm);
        double m02 = Math.Max(mAbsTop, mAbsBot) + imperfectionMomentNmm;
        double m01 = Math.Min(mAbsTop, mAbsBot) + imperfectionMomentNmm;
        double sign = mAbsTop >= mAbsBot
            ? (mTopNmm >= 0 ? 1.0 : -1.0)
            : (mBottomNmm >= 0 ? 1.0 : -1.0);
        double rm = m02 > Tolerance ? m01 / m02 : 1.0;
        double n = nEdN / (sectionValues.AcMm2 * sectionValues.FcdMpa);
        double a = settings.PhiEff.HasValue
            ? 1.0 / (1.0 + 0.2 * settings.PhiEff.Value)
            : settings.UseDefaultAWhenPhiEffUnknown ? 0.7 : 1.0;
        double b = Math.Sqrt(Math.Max(0, 1.0 + 2.0 * sectionValues.Omega));
        double c = 1.7 - rm;
        double lambdaLimit = n > 0
            ? 20.0 * a * b * c / Math.Sqrt(n)
            : 0.0;

        double minimumMomentNmm = nEdN * e0Mm;
        bool isSlender = lambda >= lambdaLimit;
        if (!isSlender)
        {
            double used = sign * Math.Max(m02, minimumMomentNmm);
            return new(lambda, lambdaLimit, false, n, a, b, c, m01, m02, rm, 0, 0, 0, 0, minimumMomentNmm, used, 1.0, 1.0, 0, 0, warnings);
        }

        double m0e = Math.Max(0.6 * m02 + 0.4 * m01, 0.4 * m02);
        double vu = 1.0 + sectionValues.Omega;
        double krDenominator = vu - Nbal;
        double kr = krDenominator > Tolerance
            ? (vu - n) / krDenominator
            : 1.0;
        kr = Math.Clamp(kr, 0.0, 1.0);

        double phiEff = settings.PhiEff ?? 0.0;
        double beta = 0.35 + concrete.Fck / 200.0 - lambda / 150.0;
        double kPhi = Math.Max(1.0, 1.0 + beta * phiEff);
        double epsilonYd = sectionValues.FydMpa / steel.EsMpa;
        double depth = Math.Max(effectiveDepthMm, Tolerance);
        double basicCurvature = epsilonYd / (0.45 * depth);
        double nominalCurvature = kr * kPhi * basicCurvature;
        double e2Mm = nominalCurvature * l0Mm * l0Mm / CurvatureShapeFactor;
        double m2 = nEdN * e2Mm;
        double usedMagnitude = Math.Max(Math.Max(m02, m0e + m2), Math.Max(m01 + 0.5 * m2, minimumMomentNmm));

        return new(lambda, lambdaLimit, true, n, a, b, c, m01, m02, rm, sign * m0e, nominalCurvature, e2Mm, m2, minimumMomentNmm, sign * usedMagnitude, kr, kPhi, beta, phiEff, warnings);
    }

    private static Ec2SlendernessSectionValuesDto ExtractSectionValues(
        ColumnSection section,
        Ec2ConcreteMaterialDto concrete,
        SteelMaterial steel)
    {
        (double ixx, double iyy) = section switch
        {
            RectangularSection rectangular => (
                rectangular.Bmm * Math.Pow(rectangular.Hmm, 3) / 12.0,
                rectangular.Hmm * Math.Pow(rectangular.Bmm, 3) / 12.0),
            CircularSection circular => (
                Math.PI * Math.Pow(circular.DiameterMm, 4) / 64.0,
                Math.PI * Math.Pow(circular.DiameterMm, 4) / 64.0),
            _ => (0.0, 0.0)
        };

        double area = Math.Max(section.AreaMm2, Tolerance);
        double ix = Math.Sqrt(Math.Max(ixx, 0.0) / area);
        double iy = Math.Sqrt(Math.Max(iyy, 0.0) / area);
        double asTotal = section.RebarLayout.Bars.Sum(b => b.AreaMm2);
        double fyd = steel.FyMpa / GammaS;
        double omega = concrete.Fcd > Tolerance
            ? asTotal * fyd / (area * concrete.Fcd)
            : 0.0;

        double dx, dy;
        if (section is CircularSection circ)
        {
            // For circular sections dx = dy: use actual rebar cage radius so that
            // the result is the same regardless of bar angular positions.
            double rCage = section.RebarLayout.Bars.Count > 0
                ? section.RebarLayout.Bars.Max(b => Math.Sqrt(b.XMm * b.XMm + b.YMm * b.YMm))
                : 0.8 * circ.RadiusMm;
            double d = circ.RadiusMm + rCage;
            dx = d;
            dy = d;
        }
        else
        {
            double spreadY = RebarSpread(section.RebarLayout.Bars.Select(b => b.YMm), 0.8 * section.HeightMm);
            dx = (section.HeightMm / 2.0) + (spreadY / 2.0);

            double spreadX = RebarSpread(section.RebarLayout.Bars.Select(b => b.XMm), 0.8 * section.WidthMm);
            dy = (section.WidthMm / 2.0) + (spreadX / 2.0);
        }

        return new(
            area,
            ixx,
            iyy,
            ix,
            iy,
            asTotal,
            concrete.Fcd,
            fyd,
            steel.EsMpa,
            concrete.Ecm,
            dx,
            dy,
            omega);
    }

    private static double RebarSpread(IEnumerable<double> values, double fallback)
    {
        var list = values.ToList();
        if (list.Count < 2)
        {
            return Math.Max(fallback, Tolerance);
        }

        double spread = list.Max() - list.Min();
        return spread > Tolerance ? spread : Math.Max(fallback, Tolerance);
    }

}
