using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A69 RID: 2665
	public sealed class NotEmptyStringToVisibilityConverter : IValueConverter
	{
		// Token: 0x06005750 RID: 22352 RVA: 0x00048097 File Offset: 0x00046297
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return string.IsNullOrWhiteSpace(value as string) ? Visibility.Collapsed : Visibility.Visible;
		}

		// Token: 0x06005751 RID: 22353 RVA: 0x00008FC0 File Offset: 0x000071C0
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}
