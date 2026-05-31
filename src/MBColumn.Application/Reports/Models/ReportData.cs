using MBColumn.Application.DTOs;
using MBColumn.Domain.Enums;

namespace MBColumn.Application.Reports.Models;

public sealed record ReportData
{
    // ── Project metadata ───────────────────────────────────────────────────────
    public string ProjectName { get; init; } = "";
    public string GroupName { get; init; } = "";
    public string DesignTierName { get; init; } = "";
    public DateTime GeneratedAt { get; init; } = DateTime.Now;

    // ── Design context ─────────────────────────────────────────────────────────
    public DesignCodeType DesignCode { get; init; }
    public UnitSystem UnitSystem { get; init; }
    public SectionShapeType SectionShape { get; init; }

    // ── Unit labels ────────────────────────────────────────────────────────────
    public string ForceUnitLabel { get; init; } = "kN";
    public string MomentUnitLabel { get; init; } = "kNm";
    public string LengthUnitLabel { get; init; } = "mm";
    public string StressUnitLabel { get; init; } = "MPa";

    // ── Geometry (mm) ─────────────────────────────────────────────────────────
    public double WidthMm { get; init; }
    public double HeightMm { get; init; }
    public double DiameterMm { get; init; }
    public double CoverMm { get; init; }

    // ── Material (MPa) ────────────────────────────────────────────────────────
    public double FcMpa { get; init; }
    public double FyMpa { get; init; }
    public double EsMpa { get; init; }
    public double AlphaCc { get; init; } = 0.85;

    // ── Reinforcement ─────────────────────────────────────────────────────────
    public IReadOnlyList<RebarCoordinateDto> Rebars { get; init; } = [];
    public IReadOnlyList<InsetPointDto> IrregularSectionBoundaryPoints { get; init; } = [];
    public string BarSize { get; init; } = "";
    public int BarCount { get; init; }

    // ── PMM governing result ───────────────────────────────────────────────────
    public double GoverningPmmRatio { get; init; }
    public string GoverningLoadCaseName { get; init; } = "";
    public double GoverningThetaDeg { get; init; }
    public double GoverningNaDepthMm { get; init; }
    public double GoverningCapPDisplay { get; init; }
    public double GoverningCapMxDisplay { get; init; }
    public double GoverningCapMyDisplay { get; init; }
    public bool IsPass => GoverningPmmRatio <= 1.0;

    // ── Applied demands ────────────────────────────────────────────────────────
    public IReadOnlyList<LoadCaseResultDto> DemandCases { get; init; } = [];

    // ── 7-point verification ───────────────────────────────────────────────────
    public HandCalcValidationReport? VerificationTheta0 { get; init; }
    public HandCalcValidationReport? VerificationTheta90 { get; init; }

    // ── PMM sweep rows ─────────────────────────────────────────────────────────
    public IReadOnlyList<SevenPointValidationRowDto> PmmSevenPointRows { get; init; } = [];

    // ── Generated SVG graphics ─────────────────────────────────────────────────
    public string? SectionGeometrySvg { get; init; }
    public string? RebarLayoutSvg { get; init; }
    public string? PmDiagramSvg { get; init; }
    public string? MmDiagramSvg { get; init; }

    // ── Interaction diagram data (preferred over SVG — rendered via DiagramCanvas2D) ──
    public DiagramBlock? PmDiagram { get; init; }
    public DiagramBlock? MmDiagram { get; init; }

    // ── Shear check result (null when not checked or not applicable) ───────────
    public ShearResultDto? GoverningShearResult { get; init; }

    // ── Rebar code-compliance (EC2 §9.5 / ACI §10.6) ──────────────────────────
    public RebarComplianceResult? RebarCompliance { get; init; }

    // ── Pre-built report sections ──────────────────────────────────────────────
    public IReadOnlyList<ReportSection> Sections { get; init; } = [];
}
