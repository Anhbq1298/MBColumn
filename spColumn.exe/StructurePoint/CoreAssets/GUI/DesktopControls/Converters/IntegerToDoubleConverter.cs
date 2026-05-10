using System;
using System.Globalization;
using System.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A49 RID: 2633
	public sealed class IntegerToDoubleConverter : IValueConverter
	{
		// Token: 0x060056EA RID: 22250 RVA: 0x00047E36 File Offset: 0x00046036
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
			{
				return null;
			}
			return (double)((int)value);
		}

		// Token: 0x060056EB RID: 22251 RVA: 0x00047E1B File Offset: 0x0004601B
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
			{
				return null;
			}
			return (int)((double)value);
		}
	}
}
