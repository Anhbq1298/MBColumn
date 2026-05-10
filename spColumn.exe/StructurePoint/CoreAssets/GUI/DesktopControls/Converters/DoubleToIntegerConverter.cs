using System;
using System.Globalization;
using System.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A44 RID: 2628
	public sealed class DoubleToIntegerConverter : IValueConverter
	{
		// Token: 0x060056DB RID: 22235 RVA: 0x00047E1B File Offset: 0x0004601B
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
			{
				return null;
			}
			return (int)((double)value);
		}

		// Token: 0x060056DC RID: 22236 RVA: 0x00047E36 File Offset: 0x00046036
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
			{
				return null;
			}
			return (double)((int)value);
		}
	}
}
