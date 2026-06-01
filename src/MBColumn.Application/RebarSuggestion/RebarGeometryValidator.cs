using MBColumn.Domain.Enums;

namespace MBColumn.Application.RebarSuggestion;

public sealed class RebarGeometryValidator : IRebarCandidateValidator
{
    public void Validate(
        RebarSuggestionCandidate candidate,
        RebarSuggestionInput input,
        CandidateValidationContext context)
    {
        var dto = input.BaseInput;
        double widthMm  = dto.Width;
        double heightMm = dto.Height;
        double coverMm  = dto.Cover;
        double linkDia  = dto.LinkDiameterMm > 0 ? dto.LinkDiameterMm : 10.0;
        double db       = candidate.Bar.DiameterMm;

        double xInnerLeft   = -widthMm  / 2.0 + coverMm + linkDia;
        double xInnerRight  =  widthMm  / 2.0 - coverMm - linkDia;
        double yInnerBottom = -heightMm / 2.0 + coverMm + linkDia;
        double yInnerTop    =  heightMm / 2.0 - coverMm - linkDia;

        var coords = candidate.Coordinates;

        // All bars inside link boundary (bar centroid ± db/2 must be inside inner boundary)
        foreach (var bar in coords)
        {
            if (bar.X - db / 2.0 < xInnerLeft   - 1e-3 ||
                bar.X + db / 2.0 > xInnerRight   + 1e-3 ||
                bar.Y - db / 2.0 < yInnerBottom  - 1e-3 ||
                bar.Y + db / 2.0 > yInnerTop     + 1e-3)
            {
                context.Fail(RebarSuggestionWarningType.BarOutsideLinkBoundary,
                    $"Bar at ({bar.X:F1}, {bar.Y:F1}) is outside the link boundary.");
                return;
            }
        }

        // Corner bars required: must have bars near each of the 4 corners
        if (input.Constraints.RequireCornerBars)
        {
            double xL = -widthMm  / 2.0 + coverMm + linkDia + db / 2.0;
            double xR =  widthMm  / 2.0 - coverMm - linkDia - db / 2.0;
            double yB = -heightMm / 2.0 + coverMm + linkDia + db / 2.0;
            double yT =  heightMm / 2.0 - coverMm - linkDia - db / 2.0;
            double tol = db;

            bool hasTopLeft     = coords.Any(b => Math.Abs(b.X - xL) < tol && Math.Abs(b.Y - yT) < tol);
            bool hasTopRight    = coords.Any(b => Math.Abs(b.X - xR) < tol && Math.Abs(b.Y - yT) < tol);
            bool hasBottomLeft  = coords.Any(b => Math.Abs(b.X - xL) < tol && Math.Abs(b.Y - yB) < tol);
            bool hasBottomRight = coords.Any(b => Math.Abs(b.X - xR) < tol && Math.Abs(b.Y - yB) < tol);

            if (!hasTopLeft || !hasTopRight || !hasBottomLeft || !hasBottomRight)
            {
                context.Fail(RebarSuggestionWarningType.MissingCornerBar,
                    "Corner bars are missing from one or more corners.");
                return;
            }
        }

        // Symmetric about X axis (top/bottom) and Y axis (left/right)
        if (input.Constraints.RequireSymmetricLayout)
        {
            if (!IsSymmetric(coords, widthMm, heightMm))
            {
                context.Fail(RebarSuggestionWarningType.CoordinateGenerationFailed,
                    "Rebar layout is not symmetric about section axes.");
                return;
            }
        }
    }

    private static bool IsSymmetric(
        IReadOnlyList<MBColumn.Application.DTOs.RebarCoordinateDto> coords,
        double widthMm, double heightMm)
    {
        const double tol = 1.0;
        foreach (var bar in coords)
        {
            bool mirrorXExists = coords.Any(b =>
                Math.Abs(b.X - bar.X)  < tol &&
                Math.Abs(b.Y + bar.Y)  < tol);
            bool mirrorYExists = coords.Any(b =>
                Math.Abs(b.X + bar.X)  < tol &&
                Math.Abs(b.Y - bar.Y)  < tol);

            if (!mirrorXExists || !mirrorYExists) return false;
        }
        return true;
    }
}
