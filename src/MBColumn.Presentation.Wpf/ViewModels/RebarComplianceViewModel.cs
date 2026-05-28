using MBColumn.Application.DTOs;

namespace MBColumn.Presentation.Wpf.ViewModels;

/// <summary>
/// Exposes the rebar code-compliance check results for the Results tab sidebar panel.
/// </summary>
public sealed class RebarComplianceViewModel : ViewModelBase
{
    private RebarComplianceResult? result;

    public void Load(RebarComplianceResult? r)
    {
        result = r;
        Raise(string.Empty);
    }

    public bool HasResult => result is not null;
    public bool AllPass   => result?.AllPass ?? true;
    public bool HasFails  => result?.FailCount > 0;
    public string StatusText  => result is null ? "—" : result.AllPass ? "PASS" : "FAIL";
    public string FailCountText => result?.FailCount is { } n and > 0 ? $"{n} item(s) non-conforming" : "";
    public string CodeRef => result?.DesignCode == Domain.Enums.DesignCodeType.Ec2 ? "EC2 §9.5" : "ACI §10.6 / §25.7";

    public IReadOnlyList<ComplianceCheckRowViewModel> Checks =>
        result?.Checks.Select(c => new ComplianceCheckRowViewModel(c)).ToList()
        ?? [];
}

public sealed record ComplianceCheckRowViewModel(ComplianceCheck Check)
{
    public string Reference   => Check.Reference;
    public string Description => Check.Description;
    public string Provided    => Check.Provided;
    public string Limit       => Check.Limit;
    public string StatusText  => Check.Pass ? "✓" : "✗";
    public bool   Pass        => Check.Pass;
    public bool   Fail        => !Check.Pass;
}
