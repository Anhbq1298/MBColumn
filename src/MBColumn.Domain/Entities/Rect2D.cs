namespace MBColumn.Domain.Entities;

public readonly record struct Rect2D(double MinX, double MinY, double MaxX, double MaxY)
{
    public double Width => MaxX - MinX;
    public double Height => MaxY - MinY;
    public double MaxDimension => System.Math.Max(Width, Height);
    public double CenterX => 0.5 * (MinX + MaxX);
    public double CenterY => 0.5 * (MinY + MaxY);
}
