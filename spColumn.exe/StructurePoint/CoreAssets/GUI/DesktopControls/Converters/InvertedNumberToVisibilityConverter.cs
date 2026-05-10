using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A6F RID: 2671
	public sealed class InvertedNumberToVisibilityConverter : IValueConverter
	{
		// Token: 0x06005762 RID: 22370 RVA: 0x000480CE File Offset: 0x000462CE
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
			{
				return Visibility.Visible;
			}
			return (long.Parse(value.ToString(), CultureInfo.InvariantCulture) <= 0L) ? Visibility.Visible : Visibility.Collapsed;
		}

		// Token: 0x06005763 RID: 22371 RVA: 0x0001233F File Offset: 0x0001053F
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return null;
		}
	}
}
