using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A6C RID: 2668
	public sealed class BoolToVisibilityConverter : IValueConverter
	{
		// Token: 0x06005759 RID: 22361 RVA: 0x000480B7 File Offset: 0x000462B7
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return ((bool)value) ? Visibility.Visible : Visibility.Hidden;
		}

		// Token: 0x0600575A RID: 22362 RVA: 0x00003909 File Offset: 0x00001B09
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
