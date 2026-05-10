using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A4E RID: 2638
	public sealed class InvertedBoolToVisibilityConverter : IValueConverter
	{
		// Token: 0x060056F9 RID: 22265 RVA: 0x00047E9D File Offset: 0x0004609D
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (!(bool)value) ? Visibility.Visible : Visibility.Hidden;
		}

		// Token: 0x060056FA RID: 22266 RVA: 0x00003909 File Offset: 0x00001B09
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
