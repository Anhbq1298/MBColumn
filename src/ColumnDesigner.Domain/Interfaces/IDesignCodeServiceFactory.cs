using ColumnDesigner.Domain.Enums;

namespace ColumnDesigner.Domain.Interfaces;

public interface IDesignCodeServiceFactory
{
    IDesignCodeService Get(DesignCodeType code);
}
