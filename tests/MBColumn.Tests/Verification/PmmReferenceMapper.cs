using MBColumn.Application.DTOs;
using MBColumn.Domain.Enums;

namespace MBColumn.Tests.Verification;

public sealed class PmmReferenceMapper
{
    public PmmMappedReferenceModel Map(DocxPmmReferenceData reference)
    {
        if (!reference.DesignCode.Contains("EN 1992", StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException($"Unsupported design code in DOCX reference: {reference.DesignCode}.");
        }

        if (!reference.SectionShape.Contains("Rectangular", StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException($"Unsupported section shape in DOCX reference: {reference.SectionShape}.");
        }

        double alphaCc = reference.DesignCode.Contains("UK Annex", StringComparison.OrdinalIgnoreCase) ? 0.80 : 0.85;
        double linkDiameter = reference.LinkDiameterMm ?? 0.0;
        double barCentroidCoverMm = reference.ClearCoverMm + linkDiameter + reference.BarDiameterMm / 2.0;
        double barAreaMm2 = reference.TotalRebarAreaMm2 > 0.0
            ? reference.TotalRebarAreaMm2 / reference.BarCount
            : Math.PI * reference.BarDiameterMm * reference.BarDiameterMm / 4.0;

        var coordinates = BuildPerimeterCoordinates(reference, barCentroidCoverMm, barAreaMm2);
        var thetaMap = reference.ThetaDegrees.ToDictionary(theta => theta, theta => NormalizeTheta(theta + 90));

        var input = new ColumnInputDto(
            UnitSystem.Metric,
            reference.WidthMm,
            reference.HeightMm,
            reference.ClearCoverMm,
            reference.BarSize,
            reference.BarCount,
            "All sides equal",
            reference.ConcreteStrengthMpa,
            reference.SteelYieldStrengthMpa,
            reference.SteelElasticModulusMpa,
            0.0,
            0.0,
            0.0,
            ForceUnit.kN,
            LengthUnit.Millimeter,
            MomentUnit.kNm,
            StressUnit.MPa,
            0.0,
            0.0)
        {
            DesignCode = DesignCodeType.Ec2,
            Ec2Solver = Ec2SolverType.Fiber,
            AlphaCc = alphaCc,
            RebarLayoutType = RebarLayoutType.AllSidesEqual,
            RebarCoordinates = coordinates
        };

        var notes = new List<string>
        {
            "DOCX units verified as metric: section in mm, stresses in MPa, reference P in kN, reference M in kNm.",
            "Reference axial compression is negative; MBColumn internal compression-positive Pn is converted with CalcP = -Pn / 1000.",
            "Reference M is treated as the N-vs-M moment on the reported theta axis; MBColumn Mx/My components are projected onto that axis in the comparison runner.",
            "Reference theta is treated as the N-vs-M moment-axis angle; MBColumn neutral-axis/compression-normal theta is mapped with MBTheta = normalize(ReferenceTheta + 90).",
            "Reinforcement is mapped as MBColumn AllSidesEqual layout: 5 bars on top, 5 bars on bottom, and 3 intermediate bars on each vertical side, sharing corner bars for 16 physical bars.",
            $"UK Annex detected; AlphaCc is set to {alphaCc:F2} for the existing EC2 design-code service.",
            $"Bar centroid cover is derived from clear cover + link diameter + half main-bar diameter = {barCentroidCoverMm:F3} mm."
        };

        if (!reference.LinkDiameterMm.HasValue)
        {
            notes.Add("No link diameter was parsed; bar centroid cover used clear cover + half main-bar diameter.");
        }

        return new PmmMappedReferenceModel(
            reference,
            input,
            coordinates,
            barCentroidCoverMm,
            alphaCc,
            thetaMap,
            notes);
    }

    private static IReadOnlyList<RebarCoordinateDto> BuildPerimeterCoordinates(
        DocxPmmReferenceData reference,
        double barCentroidCoverMm,
        double barAreaMm2)
    {
        if (reference.BarCount < 4 || (reference.BarCount - 4) % 4 != 0)
        {
            throw new InvalidOperationException(
                $"Cannot derive an all-sides perimeter layout from {reference.BarCount} bars. Expected totalBars = 4 + 4n.");
        }

        double xMax = reference.WidthMm / 2.0 - barCentroidCoverMm;
        double yMax = reference.HeightMm / 2.0 - barCentroidCoverMm;
        if (xMax <= 0.0 || yMax <= 0.0)
        {
            throw new InvalidOperationException("Derived bar centroid cover places reinforcement outside the concrete section.");
        }

        int intermediatePerSide = (reference.BarCount - 4) / 4;
        int topBottomCount = intermediatePerSide + 2;
        var bars = new List<RebarCoordinateDto>();

        AddSide(bars, "Top", topBottomCount, -xMax, yMax, xMax, yMax, reference, barAreaMm2);
        AddSide(bars, "Bottom", topBottomCount, -xMax, -yMax, xMax, -yMax, reference, barAreaMm2);
        AddIntermediateSide(bars, "Left", intermediatePerSide, -xMax, -yMax, -xMax, yMax, reference, barAreaMm2);
        AddIntermediateSide(bars, "Right", intermediatePerSide, xMax, -yMax, xMax, yMax, reference, barAreaMm2);

        return bars;
    }

    private static void AddSide(
        List<RebarCoordinateDto> bars,
        string side,
        int count,
        double x0,
        double y0,
        double x1,
        double y1,
        DocxPmmReferenceData reference,
        double barAreaMm2)
    {
        for (int i = 0; i < count; i++)
        {
            double t = count == 1 ? 0.5 : (double)i / (count - 1);
            AddUnique(bars, side, x0 + (x1 - x0) * t, y0 + (y1 - y0) * t, reference, barAreaMm2);
        }
    }

    private static void AddIntermediateSide(
        List<RebarCoordinateDto> bars,
        string side,
        int count,
        double x0,
        double y0,
        double x1,
        double y1,
        DocxPmmReferenceData reference,
        double barAreaMm2)
    {
        for (int i = 1; i <= count; i++)
        {
            double t = (double)i / (count + 1);
            AddUnique(bars, side, x0 + (x1 - x0) * t, y0 + (y1 - y0) * t, reference, barAreaMm2);
        }
    }

    private static void AddUnique(
        List<RebarCoordinateDto> bars,
        string side,
        double x,
        double y,
        DocxPmmReferenceData reference,
        double barAreaMm2)
    {
        if (bars.Any(b => Math.Abs(b.X - x) <= 1e-9 && Math.Abs(b.Y - y) <= 1e-9))
        {
            return;
        }

        bars.Add(new RebarCoordinateDto(
            $"B{bars.Count + 1}",
            x,
            y,
            reference.BarDiameterMm,
            barAreaMm2,
            reference.BarSize,
            side));
    }

    private static int NormalizeTheta(int theta)
    {
        int normalized = theta % 360;
        return normalized < 0 ? normalized + 360 : normalized;
    }
}
