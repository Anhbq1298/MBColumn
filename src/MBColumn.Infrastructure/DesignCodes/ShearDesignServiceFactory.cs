using MBColumn.Domain.Enums;
using MBColumn.Domain.Interfaces;

namespace MBColumn.Infrastructure.DesignCodes;

public sealed class ShearDesignServiceFactory(
    IShearDesignService ec2Shear) : IShearDesignServiceFactory
{
    public IShearDesignService? Get(DesignCodeType code) => code switch
    {
        DesignCodeType.Ec2 => ec2Shear,
        // TODO: return Aci318ShearDesignService once implemented.
        _ => null
    };
}
