using MBColumn.Domain.Enums;

namespace MBColumn.Domain.Interfaces;

public interface IDesignCodeServiceFactory
{
    IDesignCodeService Get(DesignCodeType code);
}

