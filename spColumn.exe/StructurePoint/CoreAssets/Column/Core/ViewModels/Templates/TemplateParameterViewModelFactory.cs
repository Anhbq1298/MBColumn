using System;
using #A9d;
using StructurePoint.CoreAssets.AppManager.Column.Templates;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Engine;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Engine.Runtime;
using StructurePoint.CoreAssets.Column.Core.ViewModels.Templates.Parameters;
using StructurePoint.CoreAssets.Units;
using StructurePoint.CoreAssets.Units.Formatters;

namespace StructurePoint.CoreAssets.Column.Core.ViewModels.Templates
{
	// Token: 0x0200082B RID: 2091
	public static class TemplateParameterViewModelFactory
	{
		// Token: 0x060042FB RID: 17147 RVA: 0x00137120 File Offset: 0x00135320
		public static TemplateParameterViewModelBase Create(TemplateEngine engine, ParameterRuntime parameter)
		{
			switch (parameter.Definition.Type)
			{
			case TemplateParameterType.Integer:
				return new IntegerTemplateParameterViewModel(parameter, engine);
			case TemplateParameterType.Double:
				return new DoubleTemplateParameterViewModel(parameter, engine)
				{
					Unit = ((engine.Model.UnitSystem == UnitSystem.SIMetric) ? new #wae(LengthUnit.Millimeter, new FloatingPointUnitValueFormatter(0)) : new #wae(LengthUnit.Inch, new FloatingPointUnitValueFormatter(3)))
				};
			case TemplateParameterType.Boolean:
				return new BooleanTemplateParameterViewModel(parameter, engine);
			case TemplateParameterType.BarSize:
				return new BarSizeTemplateParameterViewModel(parameter, engine);
			case TemplateParameterType.IntegerList:
				return new IntegerListTemplateParameterViewModel(parameter, engine);
			case TemplateParameterType.DoubleList:
				return new DoubleListTemplateParameterViewModel(parameter, engine);
			case TemplateParameterType.List:
				return new GenericListTemplateParameterViewModel(parameter, engine);
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}
}
