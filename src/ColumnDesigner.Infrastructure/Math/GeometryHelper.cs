namespace ColumnDesigner.Infrastructure.Math;

public static class GeometryHelper
{
    public static double DegreesToRadians(double degrees) => degrees * System.Math.PI / 180.0;
    public static double MomentMagnitude(double mx, double my) => System.Math.Sqrt(mx * mx + my * my);
}
