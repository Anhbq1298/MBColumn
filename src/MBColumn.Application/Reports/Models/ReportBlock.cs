using MBColumn.Application.DTOs;

namespace MBColumn.Application.Reports.Models;

public abstract record ReportBlock
{
    public bool KeepTogether { get; init; } = true;
    public bool CanSplitByRows { get; init; } = false;
    public double EstimatedHeight { get; init; } = 40;
}

public sealed record HeadingBlock(string Text, int Level) : ReportBlock;

public sealed record ParagraphBlock(string Text) : ReportBlock;

public sealed record NoteBlock(string Text) : ReportBlock;

public sealed record FormulaBlock(
    string Title,
    string LatexFormula,
    string SubstitutionText,
    string ResultText) : ReportBlock;

public sealed record TableBlock(
    string[] Headers,
    string[][] Rows,
    bool RepeatHeaderOnNewPage = true) : ReportBlock
{
    public TableBlock() : this([], [], true) { }
}

public sealed record SteelTableBlock(
    IReadOnlyList<RebarContributionRow> Rows,
    string SumFs,
    string SumFsY,
    string SumFsX) : ReportBlock
{
    public SteelTableBlock() : this([], "", "", "") { }
}

public sealed record ImageBlock(
    string SvgContent,
    double WidthPct = 60,
    string Caption = "") : ReportBlock;

public sealed record DiagramBlock(
    IReadOnlyList<ControlPointDto> Points,
    IReadOnlyList<ChartReferenceLineDto> ReferenceLines,
    string XAxisLabel,
    string YAxisLabel,
    double Ratio,
    bool UseEqualAspect = false,
    double WidthPct = 90,
    string Caption = "",
    string SvgContent = "",
    string PngDataUri = "") : ReportBlock;

public sealed record DividerBlock() : ReportBlock;

public sealed record PageBreakBlock() : ReportBlock;

public sealed record SummaryBoxBlock(string Label, string Value, bool IsPass = true) : ReportBlock;
