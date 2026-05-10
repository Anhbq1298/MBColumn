using ColumnDesigner.Domain.Enums;
using ColumnDesigner.Domain.Interfaces;

namespace ColumnDesigner.Infrastructure.DesignCodes;

public sealed class DesignCodeServiceFactory(
    IDesignCodeService aci,
    IDesignCodeService ec2) : IDesignCodeServiceFactory
{
    public IDesignCodeService Get(DesignCodeType code) => code switch
    {
        DesignCodeType.Ec2 => ec2,
        _                  => aci
    };
}
