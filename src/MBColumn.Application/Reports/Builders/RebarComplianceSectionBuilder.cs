using MBColumn.Application.DTOs;
using MBColumn.Application.Reports.Models;
using MBColumn.Domain.Enums;

namespace MBColumn.Application.Reports.Builders;

/// <summary>
/// Builds Section 3 — "Reinforcement Code Compliance" — covering:
///   EC2 EN 1992-1-1:2004 §9.5.1/9.5.2  — longitudinal reinforcement limits
///   EC2 EN 1992-1-1:2004 §9.5.3        — transverse link detailing
///   ACI 318-19 §10.6/§25.7.2           — stub (TODO)
/// </summary>
internal static class RebarComplianceSectionBuilder
{
    public static ReportSection Build(ReportData d)
    {
        var blocks = new List<ReportBlock>();

        if (d.RebarCompliance is not { } rc)
        {
            blocks.Add(new NoteBlock("Reinforcement code-compliance check could not be completed."));
            return new("3", "Reinforcement Code Compliance", blocks);
        }

        // ── Overall banner ────────────────────────────────────────────────────
        bool allPass = rc.AllPass;
        string banner = allPass
            ? "All reinforcement code-compliance checks PASS."
            : $"{rc.FailCount} check(s) FAIL — review the table below.";
        blocks.Add(new SummaryBoxBlock(banner, "", allPass) { EstimatedHeight = 50 });

        // ── Scope note ────────────────────────────────────────────────────────
        string codeRef = rc.DesignCode == DesignCodeType.Ec2
            ? "EC2 EN 1992-1-1:2004 §9.5 (columns)"
            : "ACI 318-19 §10.6, §10.7, §25.7";
        blocks.Add(new ParagraphBlock(
            $"The following checks verify that the reinforcement configuration conforms to {codeRef}. " +
            "These are detailing requirements independent of the PMM capacity check and the shear check. " +
            (rc.DesignCode == DesignCodeType.Aci318Style
                ? "ACI checks are currently stub items — full implementation pending."
                : "Longitudinal checks cover minimum and maximum reinforcement areas and bar count. " +
                  "Transverse checks cover link diameter, spacing, and bar restraint spacing (§9.5.3). " +
                  "The effective concrete cover assumed for the bar-restraint gap calculation " +
                  "matches the value entered in the input form.")));

        // ── Check table ───────────────────────────────────────────────────────
        var rows = rc.Checks.Select(c => new[]
        {
            c.Reference,
            c.Description,
            c.Requirement,
            c.Provided,
            c.Limit,
            c.Pass ? "PASS" : "FAIL"
        }).ToArray();

        blocks.Add(new TableBlock(
            ["Clause", "Check", "Rule", "Provided", "Limit / Required", "Status"],
            rows)
        { CanSplitByRows = true });

        // ── Failed check call-outs ────────────────────────────────────────────
        var failed = rc.Checks.Where(c => !c.Pass).ToList();
        if (failed.Count > 0)
        {
            blocks.Add(new HeadingBlock("Non-Conforming Items", 3));
            foreach (var f in failed)
            {
                blocks.Add(new NoteBlock(
                    $"{f.Reference} — {f.Description}: {f.Provided} does not meet {f.Limit}."));
            }
        }

        return new("3", "Reinforcement Code Compliance", blocks);
    }
}
