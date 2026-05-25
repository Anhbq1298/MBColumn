using MBColumn.Application.DTOs.Etabs;
using MBColumn.Application.DTOs.Persistence;
using MBColumn.Domain.Enums;

namespace MBColumn.Application.Services.Etabs;

public interface IEtabsForceMapper
{
    IReadOnlyList<MbColumnMappedForceRow> MapColumnForces(
        string sectionName,
        IReadOnlyList<EtabsForceResultDto> forces,
        MbColumnForceSourceMode forceSource,
        UnitSystem unitSystem);

    IReadOnlyList<MbColumnMappedForceRow> MapPierForces(
        string sectionName,
        IReadOnlyList<EtabsForceResultDto> forces,
        MbColumnForceSourceMode forceSource,
        UnitSystem unitSystem);

    IReadOnlyList<SnapshotLoadCase> ToLoadCases(IReadOnlyList<MbColumnMappedForceRow> rows);
}
