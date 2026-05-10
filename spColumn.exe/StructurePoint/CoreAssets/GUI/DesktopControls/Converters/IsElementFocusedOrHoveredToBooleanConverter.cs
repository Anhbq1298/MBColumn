using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A59 RID: 2649
	public sealed class IsElementFocusedOrHoveredToBooleanConverter : IValueConverter
	{
		// Token: 0x0600571E RID: 22302 RVA: 0x00166550 File Offset: 0x00164750
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			UIElement uielement = value as UIElement;
			UIElement uielement2;
			if (!false)
			{
				uielement2 = uielement;
			}
			return uielement2 != null && (uielement2.IsFocused || uielement2.IsMouseDirectlyOver);
		}

		// Token: 0x0600571F RID: 22303 RVA: 0x00047C65 File Offset: 0x00045E65
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Binding.DoNothing;
		}
	}
}
