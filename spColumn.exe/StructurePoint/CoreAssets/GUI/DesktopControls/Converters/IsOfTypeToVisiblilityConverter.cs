using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A5D RID: 2653
	public sealed class IsOfTypeToVisiblilityConverter : IValueConverter
	{
		// Token: 0x0600572A RID: 22314 RVA: 0x001665D8 File Offset: 0x001647D8
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			Type type = parameter as Type;
			if (type == null || value == null)
			{
				return Visibility.Collapsed;
			}
			return type.IsInstanceOfType(value) ? Visibility.Visible : Visibility.Collapsed;
		}

		// Token: 0x0600572B RID: 22315 RVA: 0x00047C65 File Offset: 0x00045E65
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Binding.DoNothing;
		}
	}
}
