using MBColumn.Application.DTOs.Etabs;

namespace MBColumn.Application.Services.Etabs;

public interface IEtabsConnectionService
{
    bool IsConnected { get; }
    EtabsConnectionResultDto ConnectToRunningEtabs();
    void Disconnect();
}
