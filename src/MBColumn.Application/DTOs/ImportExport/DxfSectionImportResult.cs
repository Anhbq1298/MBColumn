using MBColumn.Domain.Entities;

namespace MBColumn.Application.DTOs.ImportExport;

public sealed class DxfSectionImportResult
{
    public List<Point2D> BoundaryVertices { get; } = [];
    public List<DxfRebarImportItem> Rebars { get; } = [];
    public List<string> Warnings { get; } = [];
    public List<string> Errors { get; } = [];

    public double OriginalCentroidX { get; set; }
    public double OriginalCentroidY { get; set; }
    public double Area { get; set; }
    public int BoundaryPolylineCount { get; set; }
    public int BoundaryVertexCount { get; set; }
    public int RebarCircleCount { get; set; }

    public IReadOnlyList<Point2D> RebarCenters => Rebars.Select(r => r.Center).ToList();
    public bool IsSuccess => Errors.Count == 0;
}
