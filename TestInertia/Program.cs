using System;

class Program
{
    static void Main()
    {
        double[] x = { 0, 0, 1000, 1000, 200, 200 };
        double[] y = { 1000, 0, 0, 200, 200, 1000 };

        double area = 0;
        double cx = 0, cy = 0;
        double ixx = 0, iyy = 0;

        for (int i = 0; i < 6; i++)
        {
            double x1 = x[i];
            double y1 = y[i];
            double x2 = x[(i + 1) % 6];
            double y2 = y[(i + 1) % 6];

            double cross = x1 * y2 - x2 * y1;
            area += cross;
            cx += (x1 + x2) * cross;
            cy += (y1 + y2) * cross;

            ixx += (y1 * y1 + y1 * y2 + y2 * y2) * cross;
            iyy += (x1 * x1 + x1 * x2 + x2 * x2) * cross;
        }

        area /= 2.0;
        cx /= (6.0 * area);
        cy /= (6.0 * area);

        ixx /= 12.0;
        iyy /= 12.0;

        double ixxC = Math.Abs(ixx - area * cy * cy);
        double iyyC = Math.Abs(iyy - area * cx * cx);

        Console.WriteLine($"Area: {Math.Abs(area)}");
        Console.WriteLine($"cx: {cx}, cy: {cy}");
        Console.WriteLine($"Ixx_origin: {Math.Abs(ixx)}");
        Console.WriteLine($"Iyy_origin: {Math.Abs(iyy)}");
        Console.WriteLine($"IxxC: {ixxC}");
        Console.WriteLine($"IyyC: {iyyC}");
        Console.WriteLine($"rx: {Math.Sqrt(ixxC / Math.Abs(area))}");
    }
}
