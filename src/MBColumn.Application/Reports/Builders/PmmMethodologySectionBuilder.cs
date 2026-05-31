using MBColumn.Application.Reports.Models;
using MBColumn.Domain.Enums;

namespace MBColumn.Application.Reports.Builders;

internal static class PmmMethodologySectionBuilder
{
    public static ReportSection Build(ReportData d)
    {
        bool isAci = d.DesignCode == DesignCodeType.Aci318Style;

        var blocks = new List<ReportBlock>
        {
            new HeadingBlock("5.1  Theoretical Framework", 2),
            new ParagraphBlock(
                "The PMM interaction surface is constructed using strain-compatibility analysis. " +
                "The fundamental assumption is that plane sections remain plane after bending. " +
                "Concrete tensile strength is neglected. The neutral axis is swept through the " +
                "section at each bending angle θ, and the strain distribution is determined by " +
                "the concrete ultimate compressive strain at the extreme compression fibre."),

            new HeadingBlock("5.2  Design Code Assumptions", 2),
        };

        if (isAci)
        {
            blocks.Add(new TableBlock(["Parameter", "Value / Reference"],
            [
                ["Concrete model", "Whitney equivalent rectangular stress block"],
                ["Ultimate concrete strain εcu", "0.003 (ACI 318 §22.2.2.1)"],
                ["Stress block factor β₁", "ACI 318 Table 22.2.2.4.3 (fc-dependent)"],
                ["Block stress intensity", "0.85 f'c"],
                ["Steel model", "Elastic-perfectly-plastic"],
                ["Reduction factor φ (compression)", "0.65 (tied, ACI §21.2.2)"],
                ["Reduction factor φ (tension)", "0.90 (ACI §21.2.2)"],
                ["Tied column cap", "α = 0.80 (ACI §22.4.2.1)"],
            ]));
        }
        else
        {
            blocks.Add(new TableBlock(["Parameter", "Value / Reference"],
            [
                ["Concrete model", "EC2 simplified rectangular stress block"],
                ["Ultimate concrete strain εcu", "εcu2 per EC2 Table 3.1"],
                ["Block depth factor λ", "EC2 Table 3.1 (fck-dependent)"],
                ["Block stress factor η", "EC2 Table 3.1 (fck-dependent)"],
                ["Design concrete strength", $"fcd = αcc fck / γc  (αcc = {d.AlphaCc:F2}, γc = 1.50)"],
                ["Design steel strength", "fyd = fyk / γs  (γs = 1.15)"],
                ["Partial factor γM", "γc = 1.50, γs = 1.15 (EC2 Table 2.1N)"],
            ]));
        }

        blocks.AddRange(new ReportBlock[]
        {
            new HeadingBlock("5.3  Coordinate Rotation for Biaxial Bending", 2),
            new ParagraphBlock(
                "For a general bending angle θ, section coordinates are rotated so that the " +
                "neutral axis always lies perpendicular to the applied moment direction:"),
            new FormulaBlock(
                "Rotated x-coordinate",
                @"x' = x \cos\theta + y \sin\theta",
                "", ""),
            new FormulaBlock(
                "Rotated y-coordinate",
                @"y' = -x \sin\theta + y \cos\theta",
                "", ""),

            new HeadingBlock("5.4  Strain Compatibility", 2),
            new FormulaBlock(
                "Steel bar strain at position di from compression face",
                @"\varepsilon_{s,i} = \varepsilon_{cu} \frac{c - d_i}{c}",
                "where c = neutral axis depth, di = distance from compression face to bar centroid", ""),
            new FormulaBlock(
                "Steel bar stress (limited to design yield strength)",
                isAci
                    ? @"-f_y \leq f_{s,i} = E_s \varepsilon_{s,i} \leq +f_y"
                    : @"-f_{yd} \leq f_{s,i} = E_s \varepsilon_{s,i} \leq +f_{yd}",
                "Steel stress is limited to the design yield strength.", ""),

            new HeadingBlock("5.5  Force and Moment Summation", 2),
            new FormulaBlock(
                "Nominal axial force",
                @"P_n = C_c + \sum F_{s,i}",
                "where Cc = concrete compression block force, Fsi = Asi × fsi", ""),
            new FormulaBlock(
                "Nominal moment about X-axis",
                @"M_x = C_c \bar{y}_c + \sum F_{s,i} y_i",
                "ȳc = centroid of concrete compression zone, yi = bar y-coordinate from section centroid", ""),
            new FormulaBlock(
                "Nominal moment about Y-axis",
                @"M_y = C_c \bar{x}_c + \sum F_{s,i} x_i",
                "", ""),
            new FormulaBlock(
                "Moment at bending angle θ",
                @"M_\theta = M_x \cos\theta + M_y \sin\theta",
                "", ""),

            new HeadingBlock("5.6  Scope of Verification", 2),
            new NoteBlock(
                "θ = 0° and θ = 90° are presented separately because they represent the principal " +
                "bending axes and allow transparent hand-verifiable calculations. Intermediate biaxial " +
                "bending angles require a more general numerical strain-compatibility procedure and are " +
                "summarised numerically in this report."),
        });

        return new("7", "MB Column PMM Methodology", blocks);
    }
}
