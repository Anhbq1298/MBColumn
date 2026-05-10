using System;
using System.Globalization;
using System.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A46 RID: 2630
	public sealed class GreaterThanToBooleanConverter : IValueConverter
	{
		// Token: 0x060056E1 RID: 22241 RVA: 0x001661E8 File Offset: 0x001643E8
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null || parameter == null)
			{
				return false;
			}
			string s = value.ToString();
			string s2 = parameter.ToString();
			double num;
			double num2;
			if (double.TryParse(s, NumberStyles.Any, CultureInfo.CurrentCulture, out num) && double.TryParse(s2, NumberStyles.Any, CultureInfo.CurrentCulture, out num2))
			{
				return num > num2;
			}
			return false;
		}

		// Token: 0x060056E2 RID: 22242 RVA: 0x00047C65 File Offset: 0x00045E65
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Binding.DoNothing;
		}
	}
}
