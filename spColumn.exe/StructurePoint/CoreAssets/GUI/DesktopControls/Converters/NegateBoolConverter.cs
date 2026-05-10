using System;
using System.Globalization;
using System.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A72 RID: 2674
	public sealed class NegateBoolConverter : IValueConverter
	{
		// Token: 0x0600576B RID: 22379 RVA: 0x00048127 File Offset: 0x00046327
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is bool)
			{
				return !(bool)value;
			}
			return null;
		}

		// Token: 0x0600576C RID: 22380 RVA: 0x00048127 File Offset: 0x00046327
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is bool)
			{
				return !(bool)value;
			}
			return null;
		}
	}
}
