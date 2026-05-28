using MBColumn.Domain.Enums;

namespace MBColumn.Domain.Interfaces;

/// <summary>
/// Returns the code-specific <see cref="IShearDesignService"/> for a given design code.
/// Returns null when the code's shear check is not yet implemented.
/// </summary>
public interface IShearDesignServiceFactory
{
    IShearDesignService? Get(DesignCodeType code);
}
