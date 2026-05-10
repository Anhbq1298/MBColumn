using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A73 RID: 2675
	public sealed class NumberToVisibilityConverter : IValueConverter
	{
		// Token: 0x0600576E RID: 22382 RVA: 0x00048149 File Offset: 0x00046349
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
			{
				return Visibility.Collapsed;
			}
			return (long.Parse(value.ToString(), CultureInfo.InvariantCulture) > 0L) ? Visibility.Visible : Visibility.Collapsed;
		}

		// Token: 0x0600576F RID: 22383 RVA: 0x0001233F File Offset: 0x0001053F
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return null;
		}
	}
}
