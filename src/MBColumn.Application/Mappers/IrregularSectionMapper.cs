using MBColumn.Application.DTOs;
using MBColumn.Application.Services;
using MBColumn.Application.Services.Geometry;
using MBColumn.Domain.Entities;
using SMath = System.Math;

namespace MBColumn.Application.Mappers;

// Maps user-coordinate irregular section inputs to a solver-ready IrregularSection
// with rebar layout. Solver coordinates are centroid-shifted; original user
// coordinates are preserved for UI/export.
public sealed class IrregularSectionMapper
{
    private readonly IrregularSectionValidationService validation;

    public IrregularSectionMapper(IrregularSectionValidationService validation)
    {
        this.validation = validation;
    }

    public IrregularSectionValidationResult ValidateAndMap(
        IrregularSectionInputDto input,
        out IrregularSection? section,
        out IReadOnlyList<IrregularRebarCoordinateDto> rebarCoordinates,
        string defaultBarPreset = "Custom")
    {
        section = null;
        rebarCoordinates = Array.Empty<IrregularRebarCoordinateDto>();

        var boundaryUser = input.BoundaryPoints.Select(p => new Point2D(p.X, p.Y)).ToList();
        var boundaryResult = validation.ValidateBoundary(boundaryUser);
        if (!boundaryResult.IsValid)
        {
            return boundaryResult;
        }

        var rebarResult = validation.ValidateRebars(boundaryUser, input.Rebars, input.CoverMm);
        if (!rebarResult.IsValid)
        {
            return rebarResult;
        }

        var centroidUser = PolygonGeometry.Centroid(boundaryUser);
        var boundaryCentroid = boundaryUser
            .Select(p => new Point2D(p.X - centroidUser.X, p.Y - centroidUser.Y))
            .ToList();

        double area = PolygonGeometry.Area(boundaryCentroid);
        var bbox = PolygonGeometry.BoundingBox(boundaryCentroid);

        var bars = new List<Rebar>(input.Rebars.Count);
        var coordinateDtos = new List<IrregularRebarCoordinateDto>(input.Rebars.Count);
        foreach (var bar in input.Rebars)
        {
            if (!validation.TryResolveDiameter(bar, out double diameter, out _))
            {
                continue;
            }
            double areaMm2 = bar.AreaMm2 ?? (SMath.PI * diameter * diameter / 4.0);
            double cx = bar.X - centroidUser.X;
            double cy = bar.Y - centroidUser.Y;
            string label = bar.BarSize ?? $"A={areaMm2:F0}";
            bars.Add(new Rebar(label, diameter, areaMm2, cx, cy));
            coordinateDtos.Add(new IrregularRebarCoordinateDto(
                bar.RebarIndex,
                bar.X,
                bar.Y,
                bar.BarSize,
                areaMm2));
        }

        var layout = new RebarLayout(defaultBarPreset, "", input.CoverMm, bars);
        section = new IrregularSection(
            BoundaryPoints: boundaryCentroid,
            BoundaryPointsOriginalMm: boundaryUser,
            CentroidOriginalMm: centroidUser,
            BoundingBoxMm: bbox,
            ComputedAreaMm2: area,
            Layout: layout);
        rebarCoordinates = coordinateDtos;
        return IrregularSectionValidationResult.Valid;
    }
}
