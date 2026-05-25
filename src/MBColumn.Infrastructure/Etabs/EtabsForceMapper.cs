using MBColumn.Application.DTOs.Etabs;
using MBColumn.Application.DTOs.Persistence;
using MBColumn.Application.Services.Etabs;
using MBColumn.Domain.Enums;
using static System.Math;

namespace MBColumn.Infrastructure.Etabs;

public sealed class EtabsForceMapper : IEtabsForceMapper
{
    public IReadOnlyList<MbColumnMappedForceRow> MapColumnForces(
        string sectionName,
        IReadOnlyList<EtabsForceResultDto> forces,
        MbColumnForceSourceMode forceSource,
        UnitSystem unitSystem)
    {
        var rows = new List<MbColumnMappedForceRow>(forces.Count);
        foreach (var f in forces)
        {
            var location = NormalizeStation(f.Station, f.Status);
            rows.Add(new MbColumnMappedForceRow
            {
                MbColumnSectionName = sectionName,
                LoadCaseName = BuildColumnLoadCaseName(f.LoadCombination, f.StoryName, f.Label, location),
                ObjectType = EtabsImportedObjectType.Column,
                Story = f.StoryName,
                Label = f.Label,
                LoadCombo = f.LoadCombination,
                Location = location,
                P = MapAxialForce(f.P, forceSource),
                Mx = f.M2,
                My = f.M3
            });
        }
        return rows;
    }

    public IReadOnlyList<MbColumnMappedForceRow> MapPierForces(
        string sectionName,
        IReadOnlyList<EtabsForceResultDto> forces,
        MbColumnForceSourceMode forceSource,
        UnitSystem unitSystem)
    {
        var rows = new List<MbColumnMappedForceRow>(forces.Count);
        foreach (var f in forces)
        {
            var location = NormalizeStation(f.Station, f.Status);
            var pierLabel = string.IsNullOrWhiteSpace(f.PierName) ? f.Label : f.PierName;
            rows.Add(new MbColumnMappedForceRow
            {
                MbColumnSectionName = sectionName,
                LoadCaseName = BuildPierLoadCaseName(f.LoadCombination, f.StoryName, pierLabel, location),
                ObjectType = EtabsImportedObjectType.Pier,
                Story = f.StoryName,
                Label = pierLabel,
                LoadCombo = f.LoadCombination,
                Location = location,
                P = MapAxialForce(f.P, forceSource),
                Mx = f.M2,
                My = f.M3
            });
        }
        return rows;
    }

    public IReadOnlyList<SnapshotLoadCase> ToLoadCases(IReadOnlyList<MbColumnMappedForceRow> rows)
    {
        return rows.Select((r, i) => new SnapshotLoadCase
        {
            Id = $"etabs_{i + 1}",
            Label = r.LoadCaseName,
            OriginalLoadCaseName = r.LoadCombo,
            SourceObjectName = r.Label,
            SourceObjectLabel = r.Label,
            Story = r.Story,
            Station = r.Location,
            Source = "ETABS",
            Pu = r.P,
            Mux = r.Mx,
            Muy = r.My,
            IsActive = true
        }).ToList();
    }

    private static double MapAxialForce(double etabsP, MbColumnForceSourceMode forceSource)
        => forceSource switch
        {
            MbColumnForceSourceMode.DesignForces => etabsP,
            MbColumnForceSourceMode.ElementForces => -etabsP,
            _ => throw new InvalidOperationException($"Unsupported force source: {forceSource}")
        };

    private static string BuildColumnLoadCaseName(string combo, string story, string label, string location)
        => $"{combo}_{story}_{label}_{location}";

    private static string BuildPierLoadCaseName(string combo, string story, string pierName, string location)
        => $"{combo}_{story}_{pierName}_{location}";

    private static string NormalizeStation(string station, string status)
    {
        if (string.IsNullOrWhiteSpace(station)) return status;
        var s = station.Trim();
        if (s.Equals("Top", StringComparison.OrdinalIgnoreCase)) return "Top";
        if (s.Equals("Bottom", StringComparison.OrdinalIgnoreCase) || s.Equals("Bot", StringComparison.OrdinalIgnoreCase)) return "Bottom";
        if (s.Equals("Mid", StringComparison.OrdinalIgnoreCase) || s.Equals("Middle", StringComparison.OrdinalIgnoreCase)) return "Mid";
        return s;
    }
}
