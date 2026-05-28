using MBColumn.Application.DTOs;
using MBColumn.Domain.Enums;

namespace MBColumn.Application.Validators;

public sealed class ColumnInputValidator
{
    public ValidationResultDto Validate(ColumnInputDto input)
    {
        var errors = new List<string>();

        if (input.SectionShape == SectionShapeType.Irregular)
        {
            if (input.Irregular is null || input.Irregular.BoundaryPoints.Count < 3)
            {
                errors.Add("Irregular section requires at least 3 boundary points.");
            }
            if (input.Cover <= 0) errors.Add("Concrete cover must be positive.");
            if (input.Irregular is { Rebars.Count: 0 })
            {
                errors.Add("Irregular section requires at least one rebar.");
            }
        }
        else if (input.SectionShape == SectionShapeType.Circular)
        {
            if (input.Diameter <= 0) errors.Add("Section diameter must be positive.");
            if (input.Cover <= 0) errors.Add("Concrete cover must be positive.");
            if (input.Diameter > 0 && input.Cover >= input.Diameter / 2.0)
                errors.Add("Cover must be less than the section radius (D/2).");
            if (input.RebarCoordinates is { Count: > 0 })
            {
                ValidateCustomRebarCoordinates(input.RebarCoordinates, errors);
            }
            else
            {
                if (input.BarCount < 4) errors.Add("Circular sections require at least 4 longitudinal bars.");
                if (string.IsNullOrWhiteSpace(input.BarSize)) errors.Add("A rebar size is required.");
            }
        }
        else
        {
            if (input.Width <= 0) errors.Add("Section width must be positive.");
            if (input.Height <= 0) errors.Add("Section height must be positive.");
            if (input.Cover <= 0) errors.Add("Concrete cover must be positive.");
            if (input.Cover * 2 >= Math.Min(input.Width, input.Height)) errors.Add("Cover places bars outside the section.");
            if (input.RebarCoordinates is { Count: > 0 })
            {
                ValidateCustomRebarCoordinates(input.RebarCoordinates, errors);
            }
            else if (input.RebarLayoutType == RebarLayoutType.AllSidesEqual)
            {
                if (input.BarCount < 4) errors.Add("Total bars must be at least 4.");
                if (input.BarCount % 4 != 0) errors.Add("Total bars must be divisible by 4 for All Sides Equal layout.");
            }
            else
            {
                var sides = new[]
                {
                    input.TopRebarSide?.BarCount ?? 0,
                    input.BottomRebarSide?.BarCount ?? 0,
                    input.LeftRebarSide?.BarCount ?? 0,
                    input.RightRebarSide?.BarCount ?? 0
                };
                if (sides.Any(count => count < 0)) errors.Add("Side bar counts must be non-negative.");
                if (sides.Sum() == 0) errors.Add("At least one side must contain bars.");
            }
            if (input.RebarCoordinates is not { Count: > 0 } && string.IsNullOrWhiteSpace(input.BarSize)) errors.Add("A rebar size is required.");
        }

        if (input.Fc <= 0) errors.Add("Concrete strength must be positive.");
        if (input.Fy <= 0) errors.Add("Steel yield strength must be positive.");
        if (input.Es <= 0) errors.Add("Steel modulus must be positive.");
        if (input.GammaC <= 0) errors.Add("γc must be positive.");

        ValidateLoadCases(input, errors);

        return errors.Count == 0 ? ValidationResultDto.Valid : new ValidationResultDto(false, errors);
    }

    private static void ValidateLoadCases(ColumnInputDto input, List<string> errors)
    {
        var activeCases = (input.LoadCases?.Where(lc => lc.IsActive).ToList()) ?? [];
        if (activeCases.Count == 0)
        {
            activeCases = [new LoadCaseDto("default", "LC1", input.Pu, input.Mux, input.Muy, true, input.ForceUnit, input.MomentUnit)];
        }

        if (input.IncludeEc2Slenderness)
        {
            if (input.MemberLengthL is not > 0) errors.Add("Column length L is required when EC2 slenderness amplification is enabled.");
            if (input.Kx is not > 0) errors.Add("kx must be greater than zero.");
            if (input.Ky is not > 0) errors.Add("ky must be greater than zero.");
            if (input.PhiEff is < 0) errors.Add("Effective creep ratio phiEff must be zero or greater.");

            foreach (var lc in activeCases)
            {
                if (!double.IsFinite(lc.Pu)) errors.Add($"{lc.Name}: NEd is required.");
                if (lc.Pu <= 0) errors.Add($"{lc.Name}: NEd must be compression for EC2 column slenderness.");
                if (lc.MxTop is null) errors.Add($"{lc.Name}: Mx Top is required when EC2 slenderness amplification is enabled.");
                if (lc.MxBottom is null) errors.Add($"{lc.Name}: Mx Bottom is required when EC2 slenderness amplification is enabled.");
                if (lc.MyTop is null) errors.Add($"{lc.Name}: My Top is required when EC2 slenderness amplification is enabled.");
                if (lc.MyBottom is null) errors.Add($"{lc.Name}: My Bottom is required when EC2 slenderness amplification is enabled.");
            }

            return;
        }

        foreach (var lc in activeCases)
        {
            if (!double.IsFinite(lc.Pu)) errors.Add($"{lc.Name}: NEd is required.");
            if (!double.IsFinite(lc.Mux)) errors.Add($"{lc.Name}: Mx is required.");
            if (!double.IsFinite(lc.Muy)) errors.Add($"{lc.Name}: My is required.");
        }
    }

    private static void ValidateCustomRebarCoordinates(IReadOnlyList<RebarCoordinateDto> coordinates, List<string> errors)
    {
        if (coordinates.Count == 0)
        {
            errors.Add("At least one custom rebar coordinate is required.");
            return;
        }

        for (int i = 0; i < coordinates.Count; i++)
        {
            var row = coordinates[i];
            if (!double.IsFinite(row.X) || !double.IsFinite(row.Y))
            {
                errors.Add($"Custom rebar row {i + 1} has invalid coordinates.");
            }
            if (row.Area <= 0.0 || row.Diameter <= 0.0)
            {
                errors.Add($"Custom rebar row {i + 1} must provide positive area and diameter.");
            }
        }
    }
}
