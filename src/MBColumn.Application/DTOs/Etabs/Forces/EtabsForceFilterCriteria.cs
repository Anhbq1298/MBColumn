namespace MBColumn.Application.DTOs.Etabs.Forces;

/// <summary>
/// User-selected filter criteria applied after the full ETABS force table has been
/// loaded into memory. Empty sets mean "no filter" (all values accepted).
/// </summary>
public sealed class EtabsForceFilterCriteria
{
    /// <summary>Story names to include. Empty = all stories.</summary>
    public HashSet<string> SelectedStories { get; set; } = new(StringComparer.OrdinalIgnoreCase);

    /// <summary>Column/pier labels to include. Empty = all labels.</summary>
    public HashSet<string> SelectedLabels { get; set; } = new(StringComparer.OrdinalIgnoreCase);

    /// <summary>ETABS UniqueNames to include. Empty = all objects.</summary>
    public HashSet<string> SelectedUniqueNames { get; set; } = new(StringComparer.OrdinalIgnoreCase);

    /// <summary>Output case / combination names to include. Empty = all cases.</summary>
    public HashSet<string> SelectedOutputCases { get; set; } = new(StringComparer.OrdinalIgnoreCase);

    /// <summary>
    /// When true (default), only the minimum-station (Bottom) and maximum-station (Top)
    /// rows are imported per group. Intermediate stations are discarded.
    /// </summary>
    public bool UseOnlyEndStations { get; set; } = true;

    /// <summary>
    /// When true, all stations are imported including intermediate ones.
    /// Overrides <see cref="UseOnlyEndStations"/>.
    /// </summary>
    public bool ImportAllStations { get; set; } = false;
}
