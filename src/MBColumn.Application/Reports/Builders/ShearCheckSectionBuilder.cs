using MBColumn.Application.DTOs;
using MBColumn.Application.Reports.Models;
using MBColumn.Domain.Enums;
using System.Globalization;

namespace MBColumn.Application.Reports.Builders;

/// <summary>
/// Builds Section 6 — "Shear Check (EC2 §6.2)" — following the two-step flow
/// from the EC2 column design procedure (analogous to ACI §22.5 / §22.6).
/// </summary>
internal static class ShearCheckSectionBuilder
{
    private static string F(double v, int dp = 2) =>
        v.ToString($"F{dp}", CultureInfo.InvariantCulture);

    public static ReportSection Build(ReportData d)
    {
        var blocks = new List<ReportBlock>();

        if (d.GoverningShearResult is not { } sr)
        {
            string reason = d.DesignCode == DesignCodeType.Aci318Style
                ? "ACI 318-19 shear check (§22.5/22.6) is not yet implemented."
                : d.SectionShape == SectionShapeType.Irregular
                    ? "Shear check is not performed for irregular cross-sections."
                    : "Shear check could not be computed for this configuration.";
            blocks.Add(new NoteBlock(reason));
            return new("6", "Shear Check", blocks);
        }

        bool noDemand = !sr.HasDemand;

        // ── Overall status banner ─────────────────────────────────────────────
        if (noDemand)
        {
            blocks.Add(new NoteBlock(
                "No shear demand (Vux = Vuy = 0) was specified. " +
                "Section shear capacity shown for reference only. " +
                "Enter Vux / Vuy in the load case table to perform a utilisation check."));
        }
        else
        {
            bool allPass = sr.GoverningStatus == CapacityStatus.Pass
                       && sr.AswSMinPassX && sr.AswSMinPassY;
            string banner = allPass
                ? $"Shear check PASS — Governing UR = {F(sr.GoverningUtilisation, 3)}"
                : $"Shear check FAIL — Governing UR = {F(sr.GoverningUtilisation, 3)}";
            blocks.Add(new SummaryBoxBlock(banner, "", allPass) { EstimatedHeight = 50 });

            // Fix 4 — strut-crushing call-out (distinct from ordinary FAIL)
            if (sr.AnyStruttingCritical)
                blocks.Add(new NoteBlock(
                    "STRUT CRUSHING GOVERNS in one or more directions — VEd exceeds VRd,max " +
                    "at the steepest allowed strut angle (θ = 45°). Increasing shear link " +
                    "area will NOT resolve this failure. Action required: increase bw (section " +
                    "width), increase concrete grade fck, or reduce VEd."));
        }

        // ── Introduction ─────────────────────────────────────────────────────
        bool isCircular = d.SectionShape == SectionShapeType.Circular;
        string circularNote = isCircular
            ? " For circular sections: bw = 0.8 D (EC2 §6.2.2(5) note)." : "";
        blocks.Add(new ParagraphBlock(
            "Shear resistance is assessed per EC2 EN 1992-1-1:2004 §6.2, following a two-step " +
            "procedure analogous to ACI 318-19 §22.5/22.6. Both principal directions (X and Y) " +
            "are checked independently. γc = 1.50, γs = 1.15 (Table 2.1N)." + circularNote));

        // ── Section properties for shear ─────────────────────────────────────
        blocks.Add(new HeadingBlock("Section Properties for Shear", 3));
        blocks.Add(new ParagraphBlock(
            "d_eff = section dimension − cover_nominal − link_diameter − main_bar_dia/2  " +
            "(Fix 1: computed from actual bar geometry). " +
            "For shear in X: bw = h, d = b − cover_eff. " +
            "For shear in Y: bw = b, d = h − cover_eff. " +
            "ρl = Asl/(bw·d) ≤ 0.02 (total longitudinal area — conservative for columns). " +
            "σcp = NEd/Ac (compressive +ve) ≤ 0.2 fcd."));

        blocks.Add(new TableBlock(
            ["Parameter", "X direction", "Y direction"],
            [
                ["Web width bw (mm)",          F(sr.BwXMm, 0),    F(sr.BwYMm, 0)],
                ["Effective depth d (mm)",      F(sr.DEffXMm, 0),  F(sr.DEffYMm, 0)],
                ["Size effect k = 1+√(200/d)", F(sr.KFactorX, 3), F(sr.KFactorY, 3)],
                ["Long. ratio ρl",             F(sr.RhoLX, 5),    F(sr.RhoLY, 5)],
                ["Axial stress σcp (MPa)",      F(sr.SigCpMpa, 3), "← same"],
            ])
        { CanSplitByRows = false });

        // ═══════════════════════════════════════════════════════════════════
        // STEP 1 — Concrete capacity without links (§6.2.2 / ACI §22.5)
        // ═══════════════════════════════════════════════════════════════════
        blocks.Add(new HeadingBlock("Step 1 — Concrete Shear Capacity Without Links (§6.2.2)", 3));
        blocks.Add(new ParagraphBlock(
            "VRd,c is analogous to ACI §22.5 Vc. If VEd ≤ VRd,c no shear reinforcement " +
            "is required by analysis; minimum detailing links per EC2 §9.5.3 still apply."));

        blocks.Add(new FormulaBlock(
            "Concrete shear resistance",
            @"V_{Rd,c} = \left[C_{Rd,c}\,k\,(100\,\rho_l\,f_{ck})^{1/3} + k_1\,\sigma_{cp}\right] b_w\,d",
            "CRd,c = 0.12;  k₁ = 0.15;  vmin = 0.035 k^1.5 fck^0.5",
            "VRd,c = max(formula, (vmin + k₁ σcp) bw d)"));

        blocks.Add(new TableBlock(
            ["Result", "X direction", "Y direction"],
            [
                [$"VEd ({sr.ForceUnit})",
                    noDemand ? "0 (not entered)" : F(sr.VEdXDisplay),
                    noDemand ? "0 (not entered)" : F(sr.VEdYDisplay)],
                [$"VRd,c ({sr.ForceUnit})", F(sr.VRdcXDisplay), F(sr.VRdcYDisplay)],
                ["Links required?",
                    sr.LinksRequiredX ? "YES ↑ see Step 2" : "No",
                    sr.LinksRequiredY ? "YES ↑ see Step 2" : "No"],
            ])
        { CanSplitByRows = false });

        // ═══════════════════════════════════════════════════════════════════
        // STEP 2 — Capacity with links (§6.2.3 / ACI §22.6)
        // ═══════════════════════════════════════════════════════════════════
        blocks.Add(new HeadingBlock("Step 2 — Shear Capacity With Links (§6.2.3)", 3));

        if (!sr.HasLinks)
        {
            blocks.Add(new NoteBlock(
                "No shear link data was provided (link diameter or spacing = 0). " +
                "Enter link bar size, spacing, and number of legs to compute VRd,s and VRd,max."));
        }
        else
        {
            blocks.Add(new ParagraphBlock(
                "EC2 §6.2.3 uses a variable-angle truss model. Unlike ACI (Vc + Vs additive), " +
                "EC2 uses link capacity alone (VRd,s) against the strut limit (VRd,max). " +
                "The optimal cot θ ∈ [1.0, 2.5] (θ ∈ [21.8°, 45°]) maximises min(VRd,s, VRd,max)."));

            blocks.Add(new FormulaBlock(
                "Link and strut capacities",
                @"V_{Rd,s} = \tfrac{A_{sw}}{s}\,z\,f_{ywd}\cot\theta\quad" +
                @"V_{Rd,max} = \tfrac{\alpha_{cw}\,b_w\,z\,\nu_1\,f_{cd}}{\cot\theta+\tan\theta}",
                "z = 0.9 d;  ν₁ = 0.6(1 − fck/250);  αcw = 1.0;  fywd = fywk/γs",
                "VRd = min(VRd,s, VRd,max) at the governing angle θ"));

            string CotStr(double c) => c > 0 ? $"cot θ = {F(c, 2)}" : "—";

            blocks.Add(new TableBlock(
                ["Parameter", "X direction", "Y direction"],
                [
                    ["Asw/s  (mm²/mm)",              F(sr.AswSX, 4),      F(sr.AswSY, 4)],
                    ["Lever arm z (mm)",              F(sr.ZXMm, 0),       F(sr.ZYMm, 0)],
                    ["fywd (MPa)",                    F(sr.FywdMpa, 1),    "← same"],
                    ["Governing cot θ",               CotStr(sr.CotThetaX), CotStr(sr.CotThetaY)],
                    [$"VRd,s ({sr.ForceUnit})",        F(sr.VRdsXDisplay),  F(sr.VRdsYDisplay)],
                    [$"VRd,max ({sr.ForceUnit})",      F(sr.VRdMaxXDisplay),F(sr.VRdMaxYDisplay)],
                    [$"VRd ({sr.ForceUnit})",          F(sr.VRdXDisplay),   F(sr.VRdYDisplay)],
                    ["Strut crushing critical?",
                        sr.IsStruttingCriticalX ? "YES — see note" : "No",
                        sr.IsStruttingCriticalY ? "YES — see note" : "No"],
                ])
            { CanSplitByRows = false });

            // Fix 3 — §9.2.2(5) minimum shear reinforcement check
            blocks.Add(new HeadingBlock("Minimum Shear Reinforcement — §9.2.2(5)", 3));
            blocks.Add(new ParagraphBlock(
                "When shear reinforcement is provided, the minimum reinforcement ratio must " +
                "satisfy: ρw ≥ ρw,min = 0.08 √fck / fywk. In terms of Asw/s: " +
                "Asw/s ≥ ρw,min × bw  [mm²/mm]."));

            bool minPassX = sr.AswSMinPassX, minPassY = sr.AswSMinPassY;
            blocks.Add(new TableBlock(
                ["§9.2.2(5) check", "X direction", "Y direction"],
                [
                    ["Asw/s provided (mm²/mm)",     F(sr.AswSX, 4),          F(sr.AswSY, 4)],
                    ["Asw/s minimum (mm²/mm)",      F(sr.AswSMinRequiredX, 4), F(sr.AswSMinRequiredY, 4)],
                    ["Status",
                        minPassX ? "PASS" : "FAIL — increase Asw/s",
                        minPassY ? "PASS" : "FAIL — increase Asw/s"],
                ])
            { CanSplitByRows = false });
        }

        // ── Utilisation summary ───────────────────────────────────────────────
        if (!noDemand)
        {
            blocks.Add(new HeadingBlock("Utilisation Summary", 3));
            string StatusStr(CapacityStatus s) => s == CapacityStatus.Pass ? "PASS" : "FAIL";
            string URStr(double u) => u >= 99 ? ">99" : F(u, 3);

            blocks.Add(new TableBlock(
                ["Parameter", "X direction", "Y direction"],
                [
                    [$"VEd ({sr.ForceUnit})",   F(sr.VEdXDisplay),   F(sr.VEdYDisplay)],
                    [$"VRd ({sr.ForceUnit})",   F(sr.VRdXDisplay),   F(sr.VRdYDisplay)],
                    ["UR = VEd / VRd",         URStr(sr.UtilisationX), URStr(sr.UtilisationY)],
                    ["Status",                 StatusStr(sr.StatusX),  StatusStr(sr.StatusY)],
                ])
            { CanSplitByRows = false });
        }

        return new("6", "Shear Check (EC2 §6.2)", blocks);
    }
}
