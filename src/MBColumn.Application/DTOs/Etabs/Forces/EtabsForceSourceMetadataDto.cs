namespace MBColumn.Application.DTOs.Etabs.Forces;

/// <summary>
/// Metadata attached to each demand case that records exactly where its forces came from.
/// Stored alongside DemandCase so force refresh can detect what changed.
/// </summary>
public sealed record EtabsForceSourceMetadataDto(
    EtabsForceSourceType SourceType,
    string? SourceTableKey,
    string? SourceCombination,
    string? SourceLocation,
    string? SourceObjectName,
    string? SourceStory,
    DateTime ImportedAt);
