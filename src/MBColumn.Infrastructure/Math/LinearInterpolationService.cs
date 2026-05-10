namespace MBColumn.Infrastructure.Math;

public static class LinearInterpolationService
{
    public static double Lerp(double a, double b, double t) => a + (b - a) * t;
}

