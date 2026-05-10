using MBColumn.Domain.Entities;
using MBColumn.Domain.Enums;

namespace MBColumn.Domain.Interfaces;

public interface IControlPointBuilder
{
    DiagramControlPointSet Build(
        InteractionSurface surface,
        LoadDemand demand,
        double selectedPmAngleDegrees,
        double selectedAxialLoadN,
        UnitSystem unitSystem,
        RatioResult ratioResult,
        IDesignCodeService code);
}

