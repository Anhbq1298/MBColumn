using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A3C RID: 2620
	public sealed class BoolToVisibilityCollapsedConverter : IValueConverter
	{
		// Token: 0x060056BF RID: 22207 RVA: 0x00047D89 File Offset: 0x00045F89
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return ((bool)value) ? Visibility.Visible : Visibility.Collapsed;
		}

		// Token: 0x060056C0 RID: 22208 RVA: 0x00003909 File Offset: 0x00001B09
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
