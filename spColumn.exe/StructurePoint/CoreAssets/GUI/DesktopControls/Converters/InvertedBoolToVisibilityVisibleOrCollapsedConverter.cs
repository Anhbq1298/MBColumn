using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A4F RID: 2639
	public sealed class InvertedBoolToVisibilityVisibleOrCollapsedConverter : IValueConverter
	{
		// Token: 0x060056FC RID: 22268 RVA: 0x00047EB7 File Offset: 0x000460B7
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (!(bool)value) ? Visibility.Visible : Visibility.Collapsed;
		}

		// Token: 0x060056FD RID: 22269 RVA: 0x00003909 File Offset: 0x00001B09
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
