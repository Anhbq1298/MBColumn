using System;
using System.Globalization;
using System.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A4D RID: 2637
	public sealed class InvertedBoolToOpacityConverter : IValueConverter
	{
		// Token: 0x060056F6 RID: 22262 RVA: 0x0016630C File Offset: 0x0016450C
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			double num = 0.2;
			if (parameter != null)
			{
				string text = parameter as string;
				if (text != null)
				{
					num = double.Parse(text, NumberStyles.Any, CultureInfo.InvariantCulture);
				}
				else
				{
					num = (double)parameter;
				}
			}
			return (!(bool)value) ? num : 1.0;
		}

		// Token: 0x060056F7 RID: 22263 RVA: 0x00047C65 File Offset: 0x00045E65
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Binding.DoNothing;
		}
	}
}
