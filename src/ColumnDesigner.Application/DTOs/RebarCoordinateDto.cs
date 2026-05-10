namespace ColumnDesigner.Application.DTOs;

public sealed record RebarCoordinateDto(
    string Id,
    double X,
    double Y,
    double Diameter,
    double Area,
    string BarSizeLabel,
    string SourceSide);
