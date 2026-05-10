using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A38 RID: 2616
	public sealed class AreNotEqualToVisibilityConverter : IValueConverter
	{
		// Token: 0x060056A7 RID: 22183 RVA: 0x00047C45 File Offset: 0x00045E45
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (!object.Equals(value, parameter)) ? Visibility.Visible : Visibility.Collapsed;
		}

		// Token: 0x060056A8 RID: 22184 RVA: 0x00047C65 File Offset: 0x00045E65
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Binding.DoNothing;
		}
	}
}
