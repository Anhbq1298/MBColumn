using System;
using System.Globalization;
using System.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.ViewControlsPanel
{
	// Token: 0x0200094C RID: 2380
	public sealed class SliderToDisplayConverter : IValueConverter
	{
		// Token: 0x06004D83 RID: 19843 RVA: 0x0014EE08 File Offset: 0x0014D008
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			double num = (double)value;
			LinearEquation linearEquation = parameter as LinearEquation;
			if (linearEquation != null)
			{
				linearEquation.CalculateFunctionValue(num);
			}
			return num / ModelEditorParametersStorage.OneHundredPercentDistance;
		}

		// Token: 0x06004D84 RID: 19844 RVA: 0x0014EE48 File Offset: 0x0014D048
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			double num = (double)value;
			LinearEquation linearEquation = parameter as LinearEquation;
			if (linearEquation != null)
			{
				linearEquation.CalculateFunctionArgument(num);
			}
			return ModelEditorParametersStorage.OneHundredPercentDistance * num;
		}
	}
}
