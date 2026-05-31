using MBColumn.Application.DTOs;
using MBColumn.Domain.Enums;

namespace MBColumn.Application.Validators;

internal static class RebarValidator
{
    public static void Validate(ColumnInputDto input, ValidationContext ctx)
    {
        switch (input.SectionShape)
        {
            case SectionShapeType.Irregular:
                if (input.Irregular is { Rebars.Count: 0 })
                    ctx.Error("Irregular section requires at least one rebar.", "Rebars");
                break;

            case SectionShapeType.Circular:
                if (input.RebarCoordinates is { Count: > 0 })
                    ValidateCustomCoordinates(input.RebarCoordinates, ctx);
                else
                {
                    if (input.BarCount < 4)
                        ctx.Error("Circular sections require at least 4 longitudinal bars.", "BarCount");
                    if (string.IsNullOrWhiteSpace(input.BarSize))
                        ctx.Error("A rebar size is required.", "BarSize");
                }
                break;

            default:
                if (input.RebarCoordinates is { Count: > 0 })
                {
                    ValidateCustomCoordinates(input.RebarCoordinates, ctx);
                }
                else if (input.RebarLayoutType == RebarLayoutType.AllSidesEqual)
                {
                    if (input.BarCount < 4)
                        ctx.Error("Total bars must be at least 4.", "BarCount");
                    if (input.BarCount % 4 != 0)
                        ctx.Error("Total bars must be divisible by 4 for All Sides Equal layout.", "BarCount");
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
                    if (sides.Any(c => c < 0))
                        ctx.Error("Side bar counts must be non-negative.", "RebarSides");
                    if (sides.Sum() == 0)
                        ctx.Error("At least one side must contain bars.", "RebarSides");
                }
                if (input.RebarCoordinates is not { Count: > 0 } && string.IsNullOrWhiteSpace(input.BarSize))
                    ctx.Error("A rebar size is required.", "BarSize");
                break;
        }
    }

    private static void ValidateCustomCoordinates(IReadOnlyList<RebarCoordinateDto> coordinates, ValidationContext ctx)
    {
        if (coordinates.Count == 0)
        {
            ctx.Error("At least one custom rebar coordinate is required.", "RebarCoordinates");
            return;
        }
        for (int i = 0; i < coordinates.Count; i++)
        {
            var row = coordinates[i];
            if (!double.IsFinite(row.X) || !double.IsFinite(row.Y))
                ctx.Error($"Custom rebar row {i + 1} has invalid coordinates.", "RebarCoordinates", i);
            if (row.Area <= 0.0 || row.Diameter <= 0.0)
                ctx.Error($"Custom rebar row {i + 1} must provide positive area and diameter.", "RebarCoordinates", i);
        }
    }
}
