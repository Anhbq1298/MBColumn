using ETABSv1;
using MBColumn.Application.DTOs.Etabs;
using MBColumn.Application.Services.Etabs;
using MBColumn.Domain.Enums;

namespace MBColumn.Infrastructure.Etabs;

public sealed class EtabsColumnImportService : IEtabsColumnImportService
{
    private readonly EtabsConnectionService connection;

    public EtabsColumnImportService(EtabsConnectionService connection)
    {
        this.connection = connection;
    }

    public IReadOnlyList<EtabsColumnImportDto> GetCandidateColumns()
    {
        var model = connection.Model
            ?? throw new InvalidOperationException("Not connected to ETABS.");

        var units = model.GetPresentUnits();
        var (_, lengthToMm) = EtabsConnectionService.GetConversionFactors(units);

        int count = 0;
        string[] names = [];
        string[] labels = [];
        string[] stories = [];
        model.FrameObj.GetLabelNameList(ref count, ref names, ref labels, ref stories);

        var columns = new List<EtabsColumnImportDto>();
        for (var i = 0; i < count; i++)
        {
            var orientation = eFrameDesignOrientation.Null;
            var ret = model.FrameObj.GetDesignOrientation(names[i], ref orientation);
            if (ret != 0 || orientation != eFrameDesignOrientation.Column)
                continue;

            var sectionName = "";
            var sAuto = "";
            model.FrameObj.GetSection(names[i], ref sectionName, ref sAuto);

            var pierName = "";
            model.FrameObj.GetPier(names[i], ref pierName);

            var sectionType = ResolveSectionDimensions(
                model, sectionName, lengthToMm,
                out var width, out var height, out var diameter, out var material);

            var uniqueSection = BuildUniqueSectionKey(sectionName, sectionType, width, height, diameter);

            columns.Add(new EtabsColumnImportDto(
                names[i],
                pierName ?? "",
                stories[i] ?? "",
                labels[i] ?? "",
                uniqueSection,
                sectionName,
                material,
                sectionType,
                width,
                height,
                diameter,
                "",
                "Ready"));
        }

        return columns;
    }

    public IReadOnlyList<string> GetLoadCombinations()
    {
        var model = connection.Model
            ?? throw new InvalidOperationException("Not connected to ETABS.");

        int count = 0;
        string[] names = [];
        model.RespCombo.GetNameList(ref count, ref names);
        return names ?? [];
    }

    private static SectionShapeType ResolveSectionDimensions(
        cSapModel model,
        string sectionName,
        double lengthToMm,
        out double width,
        out double height,
        out double diameter,
        out string material)
    {
        width = 0;
        height = 0;
        diameter = 0;
        material = "";

        if (string.IsNullOrEmpty(sectionName))
            return SectionShapeType.Rectangular;

        var propType = eFramePropType.Rectangular;
        model.PropFrame.GetTypeOAPI(sectionName, ref propType);

        string fileName = "", matProp = "", notes = "", guid = "";
        int color = 0;

        switch (propType)
        {
            case eFramePropType.Rectangular:
            {
                double t3 = 0, t2 = 0;
                model.PropFrame.GetRectangle(sectionName, ref fileName, ref matProp, ref t3, ref t2, ref color, ref notes, ref guid);
                width = t2 * lengthToMm;
                height = t3 * lengthToMm;
                material = matProp;
                return SectionShapeType.Rectangular;
            }
            case eFramePropType.Circle:
            {
                double t3 = 0;
                model.PropFrame.GetCircle(sectionName, ref fileName, ref matProp, ref t3, ref color, ref notes, ref guid);
                diameter = t3 * lengthToMm;
                material = matProp;
                return SectionShapeType.Circular;
            }
            case eFramePropType.ConcretePipe:
            {
                double diam = 0, tw = 0;
                model.PropFrame.GetConcretePipe(sectionName, ref fileName, ref matProp, ref diam, ref tw, ref color, ref notes, ref guid);
                diameter = diam * lengthToMm;
                material = matProp;
                return SectionShapeType.Circular;
            }
            case eFramePropType.Pipe:
            {
                double t3 = 0, tw = 0;
                model.PropFrame.GetPipe(sectionName, ref fileName, ref matProp, ref t3, ref tw, ref color, ref notes, ref guid);
                diameter = t3 * lengthToMm;
                material = matProp;
                return SectionShapeType.Circular;
            }
            default:
            {
                model.PropFrame.GetMaterial(sectionName, ref matProp);
                material = matProp;
                return SectionShapeType.Rectangular;
            }
        }
    }

    private static string BuildUniqueSectionKey(
        string sectionName, SectionShapeType type, double width, double height, double diameter)
    {
        if (type == SectionShapeType.Circular)
        {
            return $"{sectionName} (D{diameter:0.#})";
        }

        return $"{sectionName} ({width:0.#}x{height:0.#})";
    }
}
