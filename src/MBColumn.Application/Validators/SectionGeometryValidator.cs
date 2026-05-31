using MBColumn.Application.DTOs;
using MBColumn.Domain.Enums;

namespace MBColumn.Application.Validators;

internal static class SectionGeometryValidator
{
    public static void Validate(ColumnInputDto input, ValidationContext ctx)
    {
        switch (input.SectionShape)
        {
            case SectionShapeType.Irregular:
                if (input.Irregular is null || input.Irregular.BoundaryPoints.Count < 3)
                    ctx.Error("Irregular section requires at least 3 boundary points.", "BoundaryPoints");
                if (input.Cover <= 0)
                    ctx.Error("Concrete cover must be positive.", "Cover");
                break;

            case SectionShapeType.Circular:
                if (input.Diameter <= 0)
                    ctx.Error("Section diameter must be positive.", "Diameter");
                if (input.Cover <= 0)
                    ctx.Error("Concrete cover must be positive.", "Cover");
                if (input.Diameter > 0 && input.Cover >= input.Diameter / 2.0)
                    ctx.Error("Cover must be less than the section radius (D/2).", "Cover");
                break;

            default:
                if (input.Width <= 0)
                    ctx.Error("Section width must be positive.", "Width");
                if (input.Height <= 0)
                    ctx.Error("Section height must be positive.", "Height");
                if (input.Cover <= 0)
                    ctx.Error("Concrete cover must be positive.", "Cover");
                if (input.Cover * 2 >= Math.Min(input.Width, input.Height))
                    ctx.Error("Cover places bars outside the section.", "Cover");
                break;
        }
    }
}
