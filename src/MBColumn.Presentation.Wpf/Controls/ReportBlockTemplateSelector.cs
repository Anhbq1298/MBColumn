using MBColumn.Application.Reports.Models;
using System.Windows;
using System.Windows.Controls;

namespace MBColumn.Presentation.Wpf.Controls;

public sealed class ReportBlockTemplateSelector : DataTemplateSelector
{
    public DataTemplate? HeadingTemplate    { get; set; }
    public DataTemplate? ParagraphTemplate  { get; set; }
    public DataTemplate? NoteTemplate       { get; set; }
    public DataTemplate? FormulaTemplate    { get; set; }
    public DataTemplate? TableTemplate      { get; set; }
    public DataTemplate? SteelTableTemplate { get; set; }
    public DataTemplate? ImageTemplate      { get; set; }
    public DataTemplate? DividerTemplate    { get; set; }
    public DataTemplate? PageBreakTemplate  { get; set; }
    public DataTemplate? SummaryBoxTemplate { get; set; }

    public override DataTemplate? SelectTemplate(object item, DependencyObject container) => item switch
    {
        HeadingBlock    => HeadingTemplate,
        ParagraphBlock  => ParagraphTemplate,
        NoteBlock       => NoteTemplate,
        FormulaBlock    => FormulaTemplate,
        TableBlock      => TableTemplate,
        SteelTableBlock => SteelTableTemplate,
        ImageBlock      => ImageTemplate,
        DividerBlock    => DividerTemplate,
        PageBreakBlock  => PageBreakTemplate,
        SummaryBoxBlock => SummaryBoxTemplate,
        _               => base.SelectTemplate(item, container),
    };
}
