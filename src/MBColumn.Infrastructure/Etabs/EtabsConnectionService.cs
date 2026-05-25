using ETABSv1;
using MBColumn.Application.DTOs.Etabs;
using MBColumn.Application.Services.Etabs;

namespace MBColumn.Infrastructure.Etabs;

public sealed class EtabsConnectionService : IEtabsConnectionService
{
    private cOAPI? etabsObject;
    private cSapModel? model;

    public bool IsConnected => model != null;
    internal cSapModel? Model => model;

    public EtabsConnectionResultDto ConnectToRunningEtabs()
    {
        try
        {
            cHelper helper = new Helper();
            etabsObject = helper.GetObject("CSI.ETABS.API.ETABSObject");
            if (etabsObject == null)
            {
                return new EtabsConnectionResultDto(false, "Could not get ETABS object. Is ETABS running?", null);
            }

            model = etabsObject.SapModel;

            var filePath = model.GetModelFilepath();
            var modelName = model.GetModelFilename(false);
            var units = model.GetPresentUnits();

            int storyCount = 0;
            string[] storyNames = [];
            model.Story.GetNameList(ref storyCount, ref storyNames);

            int pierCount = 0;
            string[] pierNames = [];
            model.PierLabel.GetNameList(ref pierCount, ref pierNames);

            int frameCount = 0;
            string[] frameNames = [];
            model.FrameObj.GetNameList(ref frameCount, ref frameNames);

            var modelInfo = new EtabsModelInfoDto(
                modelName,
                filePath,
                UnitsToString(units),
                storyCount,
                pierCount,
                frameCount);

            return new EtabsConnectionResultDto(true, "Connected to ETABS.", modelInfo);
        }
        catch (Exception ex)
        {
            model = null;
            etabsObject = null;
            return new EtabsConnectionResultDto(
                false,
                $"Could not connect to ETABS: {ex.Message} — Make sure ETABS is open with a model loaded.",
                null);
        }
    }

    public void Disconnect()
    {
        model = null;
        etabsObject = null;
    }

    internal static string UnitsToString(eUnits units) => units switch
    {
        eUnits.kN_mm_C => "kN, mm, C",
        eUnits.kN_m_C => "kN, m, C",
        eUnits.kN_cm_C => "kN, cm, C",
        eUnits.N_mm_C => "N, mm, C",
        eUnits.N_m_C => "N, m, C",
        eUnits.N_cm_C => "N, cm, C",
        eUnits.kgf_mm_C => "kgf, mm, C",
        eUnits.kgf_m_C => "kgf, m, C",
        eUnits.kgf_cm_C => "kgf, cm, C",
        eUnits.Ton_mm_C => "Ton, mm, C",
        eUnits.Ton_m_C => "Ton, m, C",
        eUnits.Ton_cm_C => "Ton, cm, C",
        eUnits.kip_in_F => "kip, in, F",
        eUnits.kip_ft_F => "kip, ft, F",
        eUnits.lb_in_F => "lb, in, F",
        eUnits.lb_ft_F => "lb, ft, F",
        _ => units.ToString()
    };

    internal static (double ForceFactor, double LengthFactor) GetConversionFactors(eUnits units, MBColumn.Domain.Enums.UnitSystem targetSystem)
    {
        var (forceToKn, lengthToMm) = GetMetricConversionFactors(units);
        
        if (targetSystem == MBColumn.Domain.Enums.UnitSystem.Metric)
        {
            return (forceToKn, lengthToMm);
        }

        // Convert from Metric (kN, mm) to Imperial (kip, in)
        return (forceToKn / 4.44822, lengthToMm / 25.4);
    }

    /// <summary>
    /// Computes the correct Moment multiplier based on the Force and Length multipliers.
    /// ETABS Moment is (EtabsForce * EtabsLength).
    /// MBColumn Moment expects (TargetForce * TargetMomentLength).
    /// TargetMomentLength is 'm' for Metric (1/1000 of mm) and 'ft' for Imperial (1/12 of in).
    /// </summary>
    internal static double GetMomentFactor(double forceFactor, double lengthFactor, MBColumn.Domain.Enums.UnitSystem targetSystem)
    {
        double geometryLengthToMomentLength = targetSystem == MBColumn.Domain.Enums.UnitSystem.Metric ? 1.0 / 1000.0 : 1.0 / 12.0;
        return forceFactor * lengthFactor * geometryLengthToMomentLength;
    }

    /// <summary>
    /// Returns the target ETABS standard unit preset and explicit conversion factors 
    /// to get forces to (kN / kip), lengths to (mm / in), and moments to (kNm / kip-ft).
    /// </summary>
    internal static (ETABSv1.eUnits TargetUnits, double ForceFactor, double LengthFactor, double MomentFactor) GetSyncUnitFactors(MBColumn.Domain.Enums.UnitSystem targetSystem)
    {
        if (targetSystem == MBColumn.Domain.Enums.UnitSystem.Metric)
        {
            var mFactor = GetMomentFactor(1.0, 1.0, targetSystem);
            return (ETABSv1.eUnits.kN_mm_C, 1.0, 1.0, mFactor);
        }

        var impFactor = GetMomentFactor(1.0, 1.0, targetSystem);
        return (ETABSv1.eUnits.kip_in_F, 1.0, 1.0, impFactor);
    }

    private static (double ForceToKn, double LengthToMm) GetMetricConversionFactors(eUnits units) => units switch
    {
        eUnits.kN_mm_C => (1.0, 1.0),
        eUnits.kN_m_C => (1.0, 1000.0),
        eUnits.kN_cm_C => (1.0, 10.0),
        eUnits.N_mm_C => (0.001, 1.0),
        eUnits.N_m_C => (0.001, 1000.0),
        eUnits.N_cm_C => (0.001, 10.0),
        eUnits.kgf_mm_C => (0.00980665, 1.0),
        eUnits.kgf_m_C => (0.00980665, 1000.0),
        eUnits.kgf_cm_C => (0.00980665, 10.0),
        eUnits.Ton_mm_C => (9.80665, 1.0),
        eUnits.Ton_m_C => (9.80665, 1000.0),
        eUnits.Ton_cm_C => (9.80665, 10.0),
        eUnits.kip_in_F => (4.44822, 25.4),
        eUnits.kip_ft_F => (4.44822, 304.8),
        eUnits.lb_in_F => (0.00444822, 25.4),
        eUnits.lb_ft_F => (0.00444822, 304.8),
        _ => (1.0, 1.0)
    };
}
