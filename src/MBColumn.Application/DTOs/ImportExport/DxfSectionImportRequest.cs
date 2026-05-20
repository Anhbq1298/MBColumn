namespace MBColumn.Application.DTOs.ImportExport;

public sealed record DxfSectionImportRequest(
    string FilePath,
    string BoundaryLayerName,
    string RebarLayerName,
    double ScaleFactor,
    double? OverrideRebarDiameterMm = null);
