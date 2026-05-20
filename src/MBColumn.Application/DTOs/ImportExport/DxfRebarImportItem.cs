using MBColumn.Domain.Entities;

namespace MBColumn.Application.DTOs.ImportExport;

public sealed record DxfRebarImportItem(Point2D Center, double Radius, double AreaMm2);
