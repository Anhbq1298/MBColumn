using MBColumn.Domain.Enums;

namespace MBColumn.Application.DTOs;

/// <summary>
/// A single pass/fail code-compliance check item.
/// </summary>
public sealed record ComplianceCheck(
    string Reference,       // e.g. "EC2 §9.5.2(1)"
    string Description,     // short label
    string Requirement,     // formula / rule text
    string Provided,        // what the section has
    string Limit,           // what the code requires
    bool Pass);

/// <summary>
/// Collected reinforcement code-compliance check results for one column section.
/// Covers longitudinal reinforcement (§9.5.1-9.5.2) and transverse links (§9.5.3).
/// </summary>
public sealed record RebarComplianceResult(
    DesignCodeType DesignCode,
    SectionShapeType SectionShape,
    IReadOnlyList<ComplianceCheck> Checks)
{
    public bool AllPass => Checks.All(c => c.Pass);
    public int FailCount => Checks.Count(c => !c.Pass);
}
