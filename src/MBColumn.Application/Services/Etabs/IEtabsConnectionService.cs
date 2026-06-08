using MBColumn.Application.DTOs.Etabs;

namespace MBColumn.Application.Services.Etabs;

public interface IEtabsConnectionService
{
    bool IsConnected { get; }
    EtabsConnectionResultDto ConnectToRunningEtabs(MBColumn.Domain.Enums.UnitSystem targetSystem = MBColumn.Domain.Enums.UnitSystem.Metric);
    void Disconnect();
}
