using MBColumn.Domain.Enums;
using static System.Math;

namespace MBColumn.Application.RebarSuggestion;

public sealed class RebarCodeValidator : IRebarCandidateValidator
{
    public void Validate(
        RebarSuggestionCandidate candidate,
        RebarSuggestionInput input,
        CandidateValidationContext context)
    {
        var dto         = input.BaseInput;
        var constraints = input.Constraints;
        double db       = candidate.Bar.DiameterMm;
        double agMm2    = dto.Width * dto.Height;
        double fyMpa    = dto.Fy;
        double totalAs  = candidate.TotalSteelAreaMm2;
        double rho      = candidate.ReinforcementRatio;

        // ── Reinforcement ratio checks ─────────────────────────────────────────
        if (constraints.CheckReinforcementRatio)
        {
            // EC2 §9.5.2(1): As ≥ max(0.002 Ag, 0.1 NEd / 0.87 fyk)
            // For suggestion engine, use conservative 0.002 Ag as minimum (NEd unknown at this stage)
            double rhoMin = 0.002;
            double rhoMax = 0.04;

            if (rho < rhoMin - 1e-6)
            {
                context.Fail(RebarSuggestionWarningType.ReinforcementRatioTooLow,
                    $"Steel ratio ρ = {rho * 100:F2}% is below EC2 minimum of {rhoMin * 100:F2}%.");
                return;
            }

            if (rho > rhoMax + 1e-6)
            {
                context.Fail(RebarSuggestionWarningType.ReinforcementRatioTooHigh,
                    $"Steel ratio ρ = {rho * 100:F2}% exceeds EC2 maximum of {rhoMax * 100:F2}%.");
                return;
            }

            // Preferred range warning
            if (constraints.MinimumPreferredReinforcementRatio.HasValue &&
                rho < constraints.MinimumPreferredReinforcementRatio.Value)
            {
                context.Warn(RebarSuggestionWarningType.ReinforcementRatioOutsidePreferredRange,
                    $"ρ = {rho * 100:F2}% is below preferred minimum of {constraints.MinimumPreferredReinforcementRatio.Value * 100:F2}%.");
            }

            if (constraints.MaximumPreferredReinforcementRatio.HasValue &&
                rho > constraints.MaximumPreferredReinforcementRatio.Value)
            {
                context.Warn(RebarSuggestionWarningType.ReinforcementRatioOutsidePreferredRange,
                    $"ρ = {rho * 100:F2}% exceeds preferred maximum of {constraints.MaximumPreferredReinforcementRatio.Value * 100:F2}%.");
            }
        }

        // ── Clear spacing checks ───────────────────────────────────────────────
        if (constraints.CheckClearSpacing)
        {
            int nx = candidate.BarsOnTopBottomFace;
            int ny = candidate.BarsOnLeftRightFace;
            double linkDia = dto.LinkDiameterMm > 0 ? dto.LinkDiameterMm : 10.0;
            double cover   = dto.Cover;

            // Effective span for top/bottom and left/right faces
            double spanX = dto.Width  - 2.0 * (cover + linkDia + db / 2.0) * 1.0;  // center-to-center span
            double spanY = dto.Height - 2.0 * (cover + linkDia + db / 2.0) * 1.0;

            // Recalculate as actual span between outermost bar centroids
            double xL = -dto.Width  / 2.0 + cover + linkDia + db / 2.0;
            double xR =  dto.Width  / 2.0 - cover - linkDia - db / 2.0;
            double yB = -dto.Height / 2.0 + cover + linkDia + db / 2.0;
            double yT =  dto.Height / 2.0 - cover - linkDia - db / 2.0;

            double clearX = nx > 1 ? (xR - xL) / (nx - 1) - db : double.PositiveInfinity;
            double clearY = ny > 1 ? (yT - yB) / (ny - 1) - db : double.PositiveInfinity;

            // EC2 §8.2: min clear spacing = max(db, 20 mm, 1.2 × aggregate)
            double minClear = Max(db, Max(20.0, 1.2 * constraints.AggregateSizeMm));
            double minClearWithTol = minClear * 0.95; // 5% tolerance for warning

            double minActual = Min(clearX, clearY);

            if (minActual < minClear - 1e-3)
            {
                context.Fail(RebarSuggestionWarningType.ClearSpacingFailed,
                    $"Clear spacing {minActual:F1} mm < minimum {minClear:F1} mm (EC2 §8.2).");
                return;
            }

            if (minActual < minClearWithTol + minClear * 0.1)
            {
                context.Warn(RebarSuggestionWarningType.ClearSpacingTight,
                    $"Clear spacing {minActual:F1} mm is close to minimum {minClear:F1} mm.");
            }
        }

        // ── Tie compatibility (basic checks) ──────────────────────────────────
        if (constraints.CheckTieCompatibility && dto.LinkDiameterMm > 0)
        {
            double dsw   = dto.LinkDiameterMm;
            double dsMax = candidate.Bar.DiameterMm;
            double dswMin = Max(6.0, 0.25 * dsMax);

            if (dsw < dswMin - 0.01)
            {
                context.Warn(RebarSuggestionWarningType.TieCompatibilityIssue,
                    $"Link diameter {dsw:F0} mm < EC2 minimum {dswMin:F1} mm for {dsMax:F0} mm bars.");
            }

            // Warn if internal links may be required (if ny > 4, every 2nd intermediate bar
            // on left/right face needs a lateral restraint — simplified rule)
            int ny = candidate.BarsOnLeftRightFace;
            if (ny > 4)
            {
                context.Warn(RebarSuggestionWarningType.InternalLinksRequired,
                    $"With {ny} bars on left/right face, internal links may be required (EC2 §9.5.3(6)).");
            }
        }
    }
}
