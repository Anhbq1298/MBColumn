using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A36 RID: 2614
	public sealed class AreEqualToVisibilityConverter : IValueConverter
	{
		// Token: 0x060056A1 RID: 22177 RVA: 0x00047C08 File Offset: 0x00045E08
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return object.Equals(value, parameter) ? Visibility.Visible : Visibility.Collapsed;
		}

		// Token: 0x060056A2 RID: 22178 RVA: 0x00003909 File Offset: 0x00001B09
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
