using MBColumn.Application.DTOs;
using MBColumn.Application.Services;

namespace MBColumn.Application.RebarSuggestion;

public sealed class ExistingSolverRebarCandidateEvaluator(ColumnCalculationService calculationService)
    : IRebarCandidateEvaluator
{
    public CandidateEvaluationResult Evaluate(RebarSuggestionCandidate candidate, RebarSuggestionInput input)
    {
        try
        {
            var candidateInput = input.BaseInput with
            {
                RebarCoordinates   = candidate.Coordinates,
                RebarLayoutType    = RebarLayoutType.CustomCoordinates,
                BarSize            = candidate.Bar.Name,
                BarCount           = candidate.TotalBarCount,
                RebarLayoutPreset  = "Auto Design"
            };

            var result = calculationService.Calculate(candidateInput);

            double maxPmm   = result.Ratio;
            string govLcName = result.LoadCaseResults
                .OrderByDescending(r => r.PmmRatio)
                .Select(r => r.LoadCaseName)
                .FirstOrDefault() ?? string.Empty;

            double? maxShear = null;
            double? vx       = null;
            double? vy       = null;

            if (result.GoverningShearResult is { } shear)
            {
                maxShear = shear.GoverningUtilisation;
                vx       = shear.UtilisationX;
                vy       = shear.UtilisationY;
            }

            return new CandidateEvaluationResult(
                MaxPmmUtilization:    maxPmm,
                MaxShearUtilization:  maxShear,
                VxUtilization:        vx,
                VyUtilization:        vy,
                GoverningLoadCaseName: govLcName,
                EvaluationFailed:     false,
                EvaluationError:      null);
        }
        catch (Exception ex)
        {
            return new CandidateEvaluationResult(
                MaxPmmUtilization:    0,
                MaxShearUtilization:  null,
                VxUtilization:        null,
                VyUtilization:        null,
                GoverningLoadCaseName: string.Empty,
                EvaluationFailed:     true,
                EvaluationError:      ex.Message);
        }
    }
}
