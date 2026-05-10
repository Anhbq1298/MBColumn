using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A68 RID: 2664
	public sealed class VisibilityToGridLengthConverter : IValueConverter
	{
		// Token: 0x0600574D RID: 22349 RVA: 0x00048066 File Offset: 0x00046266
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return ((Visibility)value == Visibility.Visible) ? new GridLength(1.0, GridUnitType.Star) : GridLength.Auto;
		}

		// Token: 0x0600574E RID: 22350 RVA: 0x001668A8 File Offset: 0x00164AA8
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (((GridLength)value).GridUnitType == GridUnitType.Auto) ? Visibility.Collapsed : Visibility.Visible;
		}
	}
}
