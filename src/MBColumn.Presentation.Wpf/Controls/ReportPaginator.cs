using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace MBColumn.Presentation.Wpf.Controls;

/// <summary>
/// Paginates a FrameworkElement across multiple printed pages by slicing it
/// vertically after scaling to fit the page width.
/// </summary>
internal sealed class ReportPaginator : DocumentPaginator
{
    private readonly FrameworkElement _element;
    private readonly Size _pageSize;
    private readonly double _scale;
    private readonly int _pageCount;

    public ReportPaginator(FrameworkElement element, Size pageSize)
    {
        _element  = element;
        _pageSize = pageSize;

        // Scale uniformly so the element width fits the page; never enlarge.
        _scale = Math.Min(pageSize.Width / Math.Max(element.ActualWidth, 1.0), 1.0);

        double scaledHeight = element.ActualHeight * _scale;
        _pageCount = Math.Max(1, (int)Math.Ceiling(scaledHeight / pageSize.Height));
    }

    public override DocumentPage GetPage(int pageNumber)
    {
        // How far into the element (in element coords) this page starts
        double pageY = pageNumber * (_pageSize.Height / _scale);

        var visual = new DrawingVisual();
        using (var dc = visual.RenderOpen())
        {
            // 1. Clip to the physical page rectangle
            dc.PushClip(new RectangleGeometry(new Rect(_pageSize)));

            // 2. Scale content to fit page width and shift the correct slice into view
            dc.PushTransform(new MatrixTransform(_scale, 0, 0, _scale, 0, -pageY * _scale));

            // 3. Render the element via VisualBrush (reads its current visual tree)
            var brush = new VisualBrush(_element) { Stretch = Stretch.None };
            dc.DrawRectangle(brush, null,
                new Rect(0, 0, _element.ActualWidth, _element.ActualHeight));

            dc.Pop(); // transform
            dc.Pop(); // clip
        }

        return new DocumentPage(visual, _pageSize, new Rect(_pageSize), new Rect(_pageSize));
    }

    public override bool IsPageCountValid => true;
    public override int PageCount => _pageCount;
    public override Size PageSize { get => _pageSize; set { } }
    public override IDocumentPaginatorSource Source => null!;
}
