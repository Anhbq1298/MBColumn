using MBColumn.Application.DTOs;
using MBColumn.Application.Reports.Models;
using MBColumn.Domain.Enums;

namespace MBColumn.Application.Reports.Builders;

internal static class AnnexBTheorySectionBuilder
{
    internal static ReportSection Build(CalculationResultDto r)
    {
        var blocks = new List<ReportBlock>
        {
            new HeadingBlock("Overview", 2),
            new ParagraphBlock(
                "MB Column determines the three-dimensional P-M-M interaction surface by sweeping " +
                "the neutral axis orientation theta from 0 deg to 360 deg and, for each angle, " +
                "iterating the neutral axis depth c to trace the full interaction curve. For biaxial " +
                "bending, c is the perpendicular distance from the neutral axis to the extreme " +
                "compression fibre, not a global vertical section depth."),

            new HeadingBlock("Strain Compatibility", 2),
            new ParagraphBlock(
                "For a given neutral axis angle theta and depth c, the strain at any point (x, y) " +
                "in the cross-section is determined by a planar strain distribution. Plane sections " +
                "remain plane, tensile concrete is neglected at ULS, reinforcement contributes in " +
                "tension and compression, and the neutral axis may rotate to any orientation during " +
                "the PMM sweep."),

            new FormulaBlock("Strain at distance d from the neutral axis",
                @"\varepsilon_i = \varepsilon_{cu}\left(\frac{d_i}{c}\right)",
                @"d_i = 0\ \text{at NA},\quad d_i=c\ \text{at the extreme compression fibre},\quad d_i<0\ \text{on the tension side}",
                ConcreteStrainReference(r)),
        };

        blocks.AddRange(BuildIntegrationBlocks(r));
        blocks.AddRange(BuildCodeSpecificBlocks(r));

        blocks.AddRange(new ReportBlock[]
        {
            new HeadingBlock("PMM Utilization Ratio", 2),
            new ParagraphBlock(
                "For each demand point (N, Mx, My), the governing utilization ratio is found by " +
                "intersecting the proportional loading ray with the design interaction surface and " +
                "maximizing the ratio over all neutral axis orientations theta."),

            new FormulaBlock("Utilization ratio",
                @"\mathrm{UR} = \frac{\lVert (N_u,\,M_{u,x},\,M_{u,y}) \rVert}{\lVert (N_R,\,M_{R,x},\,M_{R,y}) \rVert}\Bigg|_{\theta = \theta_{gov}}",
                @"\mathrm{UR} \leq 1.0 \implies \text{section adequate}",
                ""),

            new NoteBlock(
                "The governing angle theta_gov is the neutral axis orientation that maximizes UR. " +
                "The reported capacity is the intersection of the proportional loading ray with " +
                "the design interaction surface."),
        });

        return new("Annex B", "MB Column PMM Sweeping Theory", blocks);
    }

    private static IReadOnlyList<ReportBlock> BuildIntegrationBlocks(CalculationResultDto r)
    {
        if (r.IntegrationMethod == SectionIntegrationMethod.Fiber)
        {
            return
            [
                new HeadingBlock("Section Integration (Fibre Method)", 2),
                new ParagraphBlock(
                    $"{ShapeDescription(r.SectionShape)} is discretized into concrete fibres inside the actual " +
                    "section boundary. Each fibre strain is determined from its signed perpendicular distance " +
                    "to the neutral axis. Concrete fibres in compression contribute according to the active " +
                    "design-code stress-strain model, while tensile concrete is ignored. Reinforcement bars " +
                    "are integrated as discrete steel fibres."),

                new ImageBlock(AnnexBIllustrations.GoverningFibreMethodSvg(r), WidthPct: 82,
                    Caption: "Figure B.1 - Fibre discretization of an arbitrary RC section under biaxial bending. Fibre strains are computed from the signed perpendicular distance to the neutral axis assuming a linear strain distribution. Concrete tension is neglected at ULS."),

                new FormulaBlock("Concrete compression criterion",
                    @"C = \{\,j : 0 \leq d_j \leq c\,\}",
                    @"d_j = \text{signed perpendicular distance from the neutral axis toward compression}",
                    @"\sigma_{c,j}=0\quad\text{for tensile concrete }(d_j < 0)"),

                new FormulaBlock("Internal forces (discrete fibre sum)",
                    @"N_R = \sum_{j \in C} \sigma_{c,j}\,A_j + \sum_i \sigma_{s,i}\,A_{s,i}",
                    @"A_j = \text{concrete fibre area},\quad F_{s,i}=A_{s,i}\sigma_{s,i}",
                    SteelStressFormula(r)),

                new FormulaBlock("Bending moments about section centroid",
                    @"M_{R,x} = \sum F_k\,y_k,\qquad M_{R,y} = \sum F_k\,x_k",
                    @"F_k = \text{concrete or reinforcement fibre force, signed by stress}",
                    "Centroid-based coordinates are used for rectangular, circular, and irregular sections."),

                new NoteBlock(
                    r.SectionShape is SectionShapeType.Circular or SectionShapeType.Irregular
                        ? "For circular and irregular sections, MB Column uses fibre integration only. Polygon integration is intentionally unavailable for these shapes."
                        : "For rectangular sections, fibre and polygon integration can both be used for comparison when enabled."),
            ];
        }

        return
        [
            new HeadingBlock("Section Integration (Polygon Method)", 2),
            new ParagraphBlock(
                "For rectangular sections, the compression zone boundary may be obtained by geometric " +
                "clipping of the section polygon against the neutral axis. The compression polygon Pc " +
                "is then integrated as a geometric area plus discrete reinforcement forces."),

            new ImageBlock(AnnexBIllustrations.PolygonMethodSvg(),
                Caption: "Figure B.1 - Polygon clipping for a rectangular section: the compression zone is the polygon Pc bounded by the section edges and the neutral axis"),

            new FormulaBlock("Compression polygon",
                @"P_c = \text{section polygon} \cap \{\,(x,y) : \varepsilon(x,y) \geq 0\,\}",
                @"A_c = \tfrac{1}{2}\left|\sum_{k=1}^{n}(x_k\,y_{k+1} - x_{k+1}\,y_k)\right|",
                @"(x_k,y_k) = \text{vertices of } P_c \text{ after clipping}"),

            new FormulaBlock("Concrete resultant",
                @"N_c = \int_{P_c}\sigma_c(\varepsilon)\,dA",
                @"M_{c,x}=\int_{P_c}\sigma_c(\varepsilon)y\,dA,\quad M_{c,y}=\int_{P_c}\sigma_c(\varepsilon)x\,dA",
                "Steel bar forces are added separately as discrete reinforcement forces."),

            new NoteBlock(
                "Polygon integration is limited to polygonal stress-block comparison. Circular and " +
                "irregular section calculations are reported with fibre integration."),
        ];
    }

    private static IReadOnlyList<ReportBlock> BuildCodeSpecificBlocks(CalculationResultDto r)
        => r.DesignCode == DesignCodeType.Ec2 ? BuildEc2Blocks(r) : BuildAciBlocks();

    private static IReadOnlyList<ReportBlock> BuildEc2Blocks(CalculationResultDto r)
        =>
        [
            new HeadingBlock("EC2 Material Partial Factors", 2),
            new ParagraphBlock(
                "EC2 applies material partial factors to characteristic strengths rather than a " +
                "member-level strength reduction factor. The design strengths fcd and fyd are used " +
                "directly in the section analysis."),

            new FormulaBlock("Design concrete strength",
                @"f_{cd} = \frac{\alpha_{cc} \, f_{ck}}{\gamma_c}",
                $@"\alpha_{{cc}} = {r.AlphaCc:0.###},\quad \gamma_c = {r.GammaC:0.###}",
                ""),

            new FormulaBlock("Design steel strength",
                @"f_{yd} = \frac{f_{yk}}{\gamma_s}",
                @"\gamma_s = 1.15",
                ""),
        ];

    private static IReadOnlyList<ReportBlock> BuildAciBlocks()
        =>
        [
            new HeadingBlock("ACI Strength Reduction", 2),
            new ParagraphBlock(
                "ACI nominal section strength is reduced by the strength reduction factor phi. " +
                "The value of phi is selected from the controlling tensile steel strain state, " +
                "with compression-controlled and tension-controlled limits following ACI 318."),

            new FormulaBlock("Concrete compression stress",
                @"\sigma_c = 0.85 f'_c \quad \text{for the equivalent compression block}",
                @"f'_c = \text{specified concrete compressive strength}",
                ""),

            new FormulaBlock("Strength reduction factor",
                @"\phi = \begin{cases} 0.65 & \varepsilon_t \leq \varepsilon_y \\ 0.65 + 0.25\,\dfrac{\varepsilon_t - \varepsilon_y}{0.003} & \varepsilon_y < \varepsilon_t < \varepsilon_y + 0.003 \\ 0.90 & \varepsilon_t \geq \varepsilon_y + 0.003 \end{cases}",
                @"\varepsilon_t = \text{net tensile strain in extreme tension steel}",
                @"\phi P_n,\ \phi M_{n,x},\ \phi M_{n,y} \text{ form the design surface}"),
        ];

    private static string ConcreteStrainReference(CalculationResultDto r)
        => r.DesignCode == DesignCodeType.Ec2
            ? (r.EurocodeConcreteStrainProfile == EurocodeConcreteStrainProfile.Ec3
                ? @"\varepsilon_{cu}=\varepsilon_{cu3},\quad \varepsilon_{c,peak}=\varepsilon_{c3}"
                : @"\varepsilon_{cu}=\varepsilon_{cu2},\quad \varepsilon_{c,peak}=\varepsilon_{c2}")
            : @"\varepsilon_{cu}=0.003";

    private static string SteelStressFormula(CalculationResultDto r)
        => r.DesignCode == DesignCodeType.Ec2
            ? @"\sigma_{s,i}=\operatorname{clamp}(E_s\varepsilon_{s,i},-f_{yd},f_{yd})"
            : @"\sigma_{s,i}=\operatorname{clamp}(E_s\varepsilon_{s,i},-f_y,f_y)";

    private static string ShapeDescription(SectionShapeType shape)
        => shape switch
        {
            SectionShapeType.Circular => "The circular section",
            SectionShapeType.Irregular => "The irregular section boundary",
            _ => "The rectangular section",
        };
}
