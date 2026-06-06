using MBColumn.Domain.Entities;

namespace MBColumn.Application.DTOs;

public sealed record Ec2SlendernessSettingsDto(
    bool IncludeEc2Slenderness,
    double? Kx,
    double? Ky,
    double? PhiEff,
    bool UseDefaultAWhenPhiEffUnknown = true);

public sealed record MemberGeometryInputDto(double? LengthL);

public sealed record Ec2ConcreteMaterialDto(
    double Fck,
    double GammaC,
    double AlphaCc)
{
    public double Fcd => AlphaCc * Fck / GammaC;
    public double Fcm => Fck + 8.0;
    public double Ecm => 22000.0 * Math.Pow(Fcm / 10.0, 0.3);
}

public sealed record Ec2SlendernessSectionValuesDto(
    double AcMm2,
    double IxxMm4,
    double IyyMm4,
    double IxMm,
    double IyMm,
    double AsTotalMm2,
    double FcdMpa,
    double FydMpa,
    double EsMpa,
    double EcmMpa,
    double DxMm,
    double DyMm,
    double Omega);

public sealed record Ec2SlendernessAxisResultDto(
    double Lambda,
    double LambdaLimit,
    bool IsSlender,
    double FactorN,
    double FactorA,
    double FactorB,
    double FactorC,
    double M01Nmm,
    double M02Nmm,
    double Rm,
    double M0eNmm,
    double NominalCurvature1PerMm,
    double E2Mm,
    double M2Nmm,
    double MUsedNmm,
    double Kr,
    double KPhi,
    double Beta,
    double PhiEff,
    IReadOnlyList<string> Warnings);

public sealed record Ec2SlendernessLoadCaseResultDto(
    string LoadCaseId,
    string CaseName,
    Ec2SlendernessAxisResultDto? X,
    Ec2SlendernessAxisResultDto? Y,
    string Status,
    IReadOnlyList<string> Warnings)
{
    public double? MxUsedNmm => X?.MUsedNmm;
    public double? MyUsedNmm => Y?.MUsedNmm;
}

public sealed record Ec2SlendernessBatchResultDto(
    IReadOnlyList<Ec2SlendernessLoadCaseResultDto> LoadCases,
    Ec2SlendernessSectionValuesDto? SectionValues,
    double? L0xMm,
    double? L0yMm,
    IReadOnlyList<string> Warnings)
{
    public static Ec2SlendernessBatchResultDto Empty { get; } = new([], null, null, null, []);
}
