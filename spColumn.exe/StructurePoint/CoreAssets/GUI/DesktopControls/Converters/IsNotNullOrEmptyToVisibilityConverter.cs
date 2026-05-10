using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A5A RID: 2650
	public sealed class IsNotNullOrEmptyToVisibilityConverter : IValueConverter
	{
		// Token: 0x06005721 RID: 22305 RVA: 0x00166590 File Offset: 0x00164790
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
			{
				return Visibility.Collapsed;
			}
			string text = value as string;
			if (text != null)
			{
				return string.IsNullOrWhiteSpace(text) ? Visibility.Collapsed : Visibility.Visible;
			}
			return Visibility.Collapsed;
		}

		// Token: 0x06005722 RID: 22306 RVA: 0x00008FC0 File Offset: 0x000071C0
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}
