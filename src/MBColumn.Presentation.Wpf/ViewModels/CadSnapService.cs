namespace MBColumn.Presentation.Wpf.ViewModels;

public sealed class CadSnapService
{
    private const double TolerancePx = 8.0;

    public SnapResult Snap(
        double modelX, double modelY,
        bool snapToMidpoint, bool snapToGrid,
        double gridSpacing, double scale,
        IEnumerable<(double X1, double Y1, double X2, double Y2)> segments)
    {
        if (snapToMidpoint)
        {
            var toleranceModel = TolerancePx / Math.Max(scale, 0.001);
            foreach (var (x1, y1, x2, y2) in segments)
            {
                var midX = (x1 + x2) / 2.0;
                var midY = (y1 + y2) / 2.0;
                var dist = Math.Sqrt(Math.Pow(modelX - midX, 2) + Math.Pow(modelY - midY, 2));
                if (dist <= toleranceModel)
                    return new SnapResult { X = midX, Y = midY, Kind = SnapKind.Midpoint };
            }
        }

        if (snapToGrid && gridSpacing > 0)
        {
            return new SnapResult
            {
                X = Math.Round(modelX / gridSpacing) * gridSpacing,
                Y = Math.Round(modelY / gridSpacing) * gridSpacing,
                Kind = SnapKind.Grid
            };
        }

        return new SnapResult { X = modelX, Y = modelY, Kind = SnapKind.None };
    }
}
