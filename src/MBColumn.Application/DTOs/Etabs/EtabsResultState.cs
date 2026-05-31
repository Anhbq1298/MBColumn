namespace MBColumn.Application.DTOs.Etabs;

/// <summary>
/// Describes why a section result is outdated or unavailable, giving the UI
/// enough context to show a specific message rather than a generic "Outdated" label.
/// </summary>
public enum EtabsResultState
{
    /// <summary>Result is current and valid.</summary>
    Current,

    /// <summary>Input geometry or material was changed after last calculation.</summary>
    OutdatedInput,

    /// <summary>Element forces were refreshed and the result needs recalculation.</summary>
    OutdatedElementForces,

    /// <summary>Design forces were refreshed and the result needs recalculation.</summary>
    OutdatedDesignForces,

    /// <summary>The ETABS model file cannot be found or opened.</summary>
    EtabsModelMissing,

    /// <summary>The bound ETABS object no longer exists in the model.</summary>
    EtabsObjectMissing,

    /// <summary>The ETABS model fingerprint changed since the last import.</summary>
    EtabsMappingChanged,

    /// <summary>Calculation threw an exception.</summary>
    CalculationError,

    // Legacy states kept for backward compatibility with existing code
    Ready = Current,
    AnalysisRequired = OutdatedInput,
    DesignRequired = OutdatedDesignForces,
    AnalysisAndDesignRequired = OutdatedElementForces
}
