using MBColumn.Domain.Entities;
using MBColumn.Domain.Enums;
using SMath = System.Math;

namespace MBColumn.Infrastructure.Solvers;

public sealed class Aci318DesignAdapter : IDesignCodeAdapter
{
    public DesignCapacityPoint ApplyDesignRules(
        PmmInput input,
        NeutralAxisState neutralAxis,
        SectionIntegrationResult nominalResult)
    {
        double phi = input.DesignCode.Phi(
            nominalResult.MaxTensionSteelStrain,
            input.Steel.FyMpa,
            input.Steel.EsMpa);

        return new DesignCapacityPoint(ToInteractionPoint(input, neutralAxis, nominalResult, phi, ClassifyAci(nominalResult, input.Steel)));
    }

    private static string ClassifyAci(SectionIntegrationResult result, SteelMaterial steel)
    {
        if (!result.HasConcreteCompression) return "Pure tension";
        double yieldStrain = steel.FyMpa / steel.EsMpa;
        if (result.MaxTensionSteelStrain <= yieldStrain) return "Compression controlled";
        if (result.MaxTensionSteelStrain >= yieldStrain + 0.003) return "Tension controlled";
        return "Transition";
    }

    internal static InteractionPoint ToInteractionPoint(
        PmmInput input,
        NeutralAxisState neutralAxis,
        SectionIntegrationResult result,
        double phi,
        string stateLabel)
        => new(
            neutralAxis.DepthIndex,
            neutralAxis.AngleIndex,
            neutralAxis.ThetaRad * 180.0 / SMath.PI,
            neutralAxis.NeutralAxisDepth,
            result.NominalP,
            result.NominalMx,
            result.NominalMy,
            phi,
            result.MaxTensionSteelStrain,
            result.ConcreteForce,
            result.SteelForce,
            result.ConcreteMx,
            result.ConcreteMy,
            result.SteelMx,
            result.SteelMy,
            result.MaxConcreteStrain,
            result.MinConcreteStrain,
            result.MaxSteelStrain,
            result.MinSteelStrain,
            stateLabel)
        {
            IntegrationMethod = input.Settings.IntegrationMethod,
            ThetaRad = neutralAxis.ThetaRad,
            IsSpecialPoint = neutralAxis.IsSpecialState,
            SpecialPointType = neutralAxis.SpecialStateType
        };
}

public sealed class Eurocode2DesignAdapter : IDesignCodeAdapter
{
    public DesignCapacityPoint ApplyDesignRules(
        PmmInput input,
        NeutralAxisState neutralAxis,
        SectionIntegrationResult nominalResult)
    {
        double phi = input.DesignCode.Phi(
            nominalResult.MaxTensionSteelStrain,
            input.Steel.FyMpa,
            input.Steel.EsMpa);

        return new DesignCapacityPoint(Aci318DesignAdapter.ToInteractionPoint(
            input,
            neutralAxis,
            nominalResult,
            phi,
            ClassifyEc2(nominalResult)));
    }

    private static string ClassifyEc2(SectionIntegrationResult result)
    {
        if (!result.HasConcreteCompression) return "Pure tension";
        if (result.MaxTensionSteelStrain >= 0.005) return "Tension controlled";
        return "Compression controlled";
    }
}

public static class DesignCodeAdapterFactory
{
    public static IDesignCodeAdapter Create(DesignCodeType code)
        => code == DesignCodeType.Ec2
            ? new Eurocode2DesignAdapter()
            : new Aci318DesignAdapter();
}
