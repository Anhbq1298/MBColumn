using ColumnDesigner.Domain.Entities;
using ColumnDesigner.Domain.Enums;

namespace ColumnDesigner.Domain.Interfaces;

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
