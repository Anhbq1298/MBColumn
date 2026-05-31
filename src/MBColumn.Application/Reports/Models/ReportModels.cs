using MBColumn.Application.DTOs;

namespace MBColumn.Application.Reports.Models;

// ── Block base ────────────────────────────────────────────────────────────────

public abstract record ReportBlock;

// ── Concrete block types ──────────────────────────────────────────────────────

public sealed record HeadingBlock(string Text, int Level = 1) : ReportBlock;

public sealed record ParagraphBlock(string Text) : ReportBlock;

public sealed record NoteBlock(string Text) : ReportBlock;

public sealed record FormulaBlock(
    string Title,
    string LatexFormula,
    string SubstitutionLatex,
    string ResultLatex) : ReportBlock;

public sealed record TableBlock(
    string Caption,
    string[] Headers,
    string[][] Rows) : ReportBlock;

public sealed record SteelTableBlock(
    string Caption,
    string[] Headers,
    string[][] Rows) : ReportBlock;

public sealed record ImageBlock(string SvgContent, string Caption = "") : ReportBlock;

public sealed record DiagramBlock(
    IReadOnlyList<ControlPointDto> Points,
    IReadOnlyList<ChartReferenceLineDto> ReferenceLines,
    string XLabel,
    string YLabel,
    double Ratio,
    bool UseEqualAspect = false,
    int WidthPct = 90,
    string Caption = "") : ReportBlock;

public sealed record DividerBlock : ReportBlock;

public sealed record PageBreakBlock : ReportBlock;

public sealed record SummaryBoxBlock(
    string Title,
    string Status,
    double Ratio,
    IReadOnlyList<(string Label, string Value)> Entries) : ReportBlock;

public sealed record SectionPreviewBlock(string SvgContent, double WidthMm, double HeightMm) : ReportBlock;

// ── Section and report ─────────────────────────────────────────────────────────

public sealed class ReportSection
{
    public string Number { get; }
    public string Title { get; }
    public IReadOnlyList<ReportBlock> Blocks { get; }

    public ReportSection(string number, string title, IReadOnlyList<ReportBlock> blocks)
    {
        Number = number;
        Title = title;
        Blocks = blocks;
    }
}

public sealed class ReportData
{
    public string ProjectName { get; init; } = "";
    public string GroupName { get; init; } = "";
    public string DesignTierName { get; init; } = "";
    public string GeneratedAt { get; init; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
    public IReadOnlyList<ReportSection> Sections { get; init; } = [];
}
