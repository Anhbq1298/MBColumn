using MBColumn.Application.DTOs;
using System.Linq;

namespace MBColumn.Presentation.Wpf.ViewModels;

// ── Unit conversion ────────────────────────────────────────────────────────

public static class ReportUnitConverter
{
    private const double DipPerInch = 96.0;
    private const double MmPerInch  = 25.4;

    public static double MmToDip(double mm)   => mm / MmPerInch * DipPerInch;
    public static double InchToDip(double inch) => inch * DipPerInch;
}

// ── Block model ───────────────────────────────────────────────────────────

public sealed class ReportBlockViewModel
{
    public string BlockType  { get; set; } = string.Empty;
    public string Title      { get; set; } = string.Empty;
    public double EstimatedHeightMm  { get; set; }
    public bool   KeepTogether       { get; set; } = true;
    public bool   ForcePageBreakBefore { get; set; } = false;
    public bool   CanSplitByRows     { get; set; } = false;
    public object? Content           { get; set; }
}

// ── Page model ─────────────────────────────────────────────────────────────

public sealed class A4ReportPageViewModel
{
    public int    PageNumber     { get; set; }
    public double PageWidthMm   { get; set; } = 210.0;
    public double PageHeightMm  { get; set; } = 297.0;
    public double MarginMm      { get; set; } = 12.7;   // 0.5 inch

    public double ContentWidthMm  => PageWidthMm  - 2.0 * MarginMm;
    public double ContentHeightMm => PageHeightMm - 2.0 * MarginMm;

    public double UsedHeightMm      { get; set; }
    public double RemainingHeightMm => ContentHeightMm - UsedHeightMm;

    public List<ReportBlockViewModel> Blocks { get; } = [];

    // WPF display helpers
    public double PageWidthDip   => ReportUnitConverter.MmToDip(PageWidthMm);
    public double PageHeightDip  => ReportUnitConverter.MmToDip(PageHeightMm);
    public double MarginDip      => ReportUnitConverter.InchToDip(0.5);
}

// ── Paginator ──────────────────────────────────────────────────────────────

public sealed class ReportPaginatorService
{
    public IReadOnlyList<A4ReportPageViewModel> Paginate(
        IReadOnlyList<ReportBlockViewModel> blocks)
    {
        var pages = new List<A4ReportPageViewModel>();
        var current = NewPage(1);
        pages.Add(current);

        foreach (var block in blocks)
        {
            if (block.ForcePageBreakBefore && current.Blocks.Count > 0)
            {
                current = NewPage(pages.Count + 1);
                pages.Add(current);
            }

            if (block.KeepTogether
                && block.EstimatedHeightMm > current.RemainingHeightMm
                && current.Blocks.Count > 0)
            {
                current = NewPage(pages.Count + 1);
                pages.Add(current);
            }

            current.Blocks.Add(block);
            current.UsedHeightMm += block.EstimatedHeightMm;
        }

        return pages;
    }

    private static A4ReportPageViewModel NewPage(int number)
        => new() { PageNumber = number };
}

// ── Governing chart ViewModel ──────────────────────────────────────────────

public sealed class GoverningChartPreviewViewModel
{
    public double? CriticalThetaDeg  { get; set; }
    public double? UtilizationRatio  { get; set; }

    public double? DemandP  { get; set; }
    public double? DemandMx { get; set; }
    public double? DemandMy { get; set; }

    public string LoadCaseName     { get; set; } = string.Empty;
    public string LoadCombination  { get; set; } = string.Empty;

    public IReadOnlyList<ControlPointDto> PmChartPoints  { get; set; } = [];
    public IReadOnlyList<ChartReferenceLineDto> PmReferenceLines { get; set; } = [];
    public IReadOnlyList<ControlPointDto> MmChartPoints  { get; set; } = [];
    public IReadOnlyList<ChartReferenceLineDto> MmReferenceLines { get; set; } = [];

    public ControlPointDto? PmDemandPoint  { get; set; }
    public ControlPointDto? MmDemandPoint  { get; set; }
    public double? DemandMtheta { get; set; }

    public bool   HasDemandPoint       => PmDemandPoint is not null;
    public string DemandPDisplay       => Fmt(DemandP);
    public string DemandMthetaDisplay  => Fmt(DemandMtheta);
    public string DemandMxDisplay      => Fmt(DemandMx);
    public string DemandMyDisplay      => Fmt(DemandMy);

    private static string Fmt(double? v)
        => v.HasValue && double.IsFinite(v.Value) ? v.Value.ToString("0.##") : "—";

    public IReadOnlyList<ControlPointDto> PmAllPoints =>
        PmDemandPoint is null ? PmChartPoints
            : PmChartPoints.Append(PmDemandPoint).ToList();

    public IReadOnlyList<ControlPointDto> MmAllPoints =>
        MmDemandPoint is null ? MmChartPoints
            : MmChartPoints.Append(MmDemandPoint).ToList();

    public string PUnit { get; set; } = "";
    public string MUnit { get; set; } = "";

    public bool HasPmChart => PmChartPoints.Count > 0;
    public bool HasMmChart => MmChartPoints.Count > 0;
    public bool IsAvailable => HasPmChart || HasMmChart;

    public string PmXAxisLabel => string.IsNullOrEmpty(MUnit) ? "Mθ" : $"Mθ ({MUnit})";
    public string PmYAxisLabel => string.IsNullOrEmpty(PUnit) ? "P"  : $"P ({PUnit})";
    public string MmXAxisLabel => string.IsNullOrEmpty(MUnit) ? "Mx" : $"Mx ({MUnit})";
    public string MmYAxisLabel => string.IsNullOrEmpty(MUnit) ? "My" : $"My ({MUnit})";

    public string Caption
    {
        get
        {
            if (CriticalThetaDeg is null || UtilizationRatio is null)
                return "Governing utilization result not available.";
            return $"Governing utilization ratio UR = {UtilizationRatio:0.###} at θ = {CriticalThetaDeg:0.#}°. " +
                   "Charts show the corresponding 2D P-M slice and M-M contour.";
        }
    }
}

// ── PM 7 row ViewModel ─────────────────────────────────────────────────────

public sealed class ReportPm7RowViewModel
{
    public int    Index     { get; set; }
    public string PointCode { get; set; } = "";
    public string PointName { get; set; } = "";
    public string StrainDescription { get; set; } = "";

    public string HandCalcPDisplay { get; set; } = "N/A";
    public string HandCalcMDisplay { get; set; } = "N/A";
    public string SolverPDisplay   { get; set; } = "N/A";
    public string SolverMDisplay   { get; set; } = "N/A";
    public string DeviationPDisplay { get; set; } = "N/A";
    public string DeviationMDisplay { get; set; } = "N/A";
}
