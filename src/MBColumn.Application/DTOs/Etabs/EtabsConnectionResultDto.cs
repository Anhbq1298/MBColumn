namespace MBColumn.Application.DTOs.Etabs;

public sealed record EtabsConnectionResultDto(
    bool IsConnected,
    string Message,
    EtabsModelInfoDto? ModelInfo);
