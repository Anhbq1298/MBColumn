using MBColumn.Application.Reports.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MBColumn.Presentation.Wpf.Controls;

/// <summary>
/// Renders a <see cref="TableBlock"/> (string[][] rows) as a WPF Grid with headers and data rows.
/// </summary>
public sealed class ReportTableControl : FrameworkElement
{
    private static readonly SolidColorBrush NavyBrush  = new(Color.FromRgb(0x1A, 0x3A, 0x5C));
    private static readonly SolidColorBrush AltBrush   = new(Color.FromRgb(0xF5, 0xF7, 0xFA));
    private static readonly SolidColorBrush BorderBrush = new(Color.FromRgb(0xDD, 0xDD, 0xDD));

    public static readonly DependencyProperty BlockProperty = DependencyProperty.Register(
        nameof(Block), typeof(TableBlock), typeof(ReportTableControl),
        new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure, OnBlockChanged));

    public TableBlock? Block
    {
        get => (TableBlock?)GetValue(BlockProperty);
        set => SetValue(BlockProperty, value);
    }

    private readonly Grid _grid = new();

    public ReportTableControl()
    {
        AddVisualChild(_grid);
        AddLogicalChild(_grid);
    }

    protected override int VisualChildrenCount => 1;
    protected override Visual GetVisualChild(int index) => _grid;

    protected override Size MeasureOverride(Size constraint)
    {
        _grid.Measure(constraint);
        return _grid.DesiredSize;
    }

    protected override Size ArrangeOverride(Size finalSize)
    {
        _grid.Arrange(new Rect(finalSize));
        return finalSize;
    }

    private static void OnBlockChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        => ((ReportTableControl)d).Rebuild();

    private void Rebuild()
    {
        _grid.Children.Clear();
        _grid.RowDefinitions.Clear();
        _grid.ColumnDefinitions.Clear();

        var block = Block;
        if (block is null || block.Headers.Length == 0) return;

        int colCount = block.Headers.Length;

        for (int c = 0; c < colCount; c++)
            _grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

        // Header row
        _grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
        for (int c = 0; c < colCount; c++)
            AddCell(0, c, block.Headers[c], isHeader: true, isAlt: false);

        // Data rows
        for (int r = 0; r < block.Rows.Length; r++)
        {
            _grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            var row = block.Rows[r];
            bool isAlt = r % 2 != 0;
            for (int c = 0; c < Math.Min(row.Length, colCount); c++)
                AddCell(r + 1, c, row[c], isHeader: false, isAlt: isAlt);
        }
    }

    private void AddCell(int row, int col, string text, bool isHeader, bool isAlt)
    {
        var tb = new TextBlock
        {
            Text = text,
            FontSize = 10,
            TextWrapping = TextWrapping.Wrap,
            Padding = new Thickness(4, 2, 4, 2),
            Foreground = isHeader ? Brushes.White : Brushes.Black,
            FontWeight = isHeader ? FontWeights.SemiBold : FontWeights.Normal,
            VerticalAlignment = VerticalAlignment.Center,
        };

        var border = new Border
        {
            Background = isHeader ? NavyBrush : (isAlt ? AltBrush : Brushes.White),
            BorderBrush = BorderBrush,
            BorderThickness = new Thickness(0, 0, 0, 1),
            Child = tb,
        };

        Grid.SetRow(border, row);
        Grid.SetColumn(border, col);
        _grid.Children.Add(border);
    }
}
