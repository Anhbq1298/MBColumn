using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace StructurePoint.CoreAssets.Licensing.UI.Views
{
	// Token: 0x02000727 RID: 1831
	internal sealed class AreEqualToVisibilityConverter : IValueConverter
	{
		// Token: 0x06003C52 RID: 15442 RVA: 0x000341DB File Offset: 0x000323DB
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return \u0091.\u0012\u0003(value, parameter) ? Visibility.Visible : Visibility.Collapsed;
		}

		// Token: 0x06003C53 RID: 15443 RVA: 0x00003909 File Offset: 0x00001B09
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
