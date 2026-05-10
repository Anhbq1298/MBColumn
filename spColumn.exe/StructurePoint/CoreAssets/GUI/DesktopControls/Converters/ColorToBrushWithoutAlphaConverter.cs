using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A6D RID: 2669
	public sealed class ColorToBrushWithoutAlphaConverter : IValueConverter
	{
		// Token: 0x0600575C RID: 22364 RVA: 0x00166990 File Offset: 0x00164B90
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is Color)
			{
				Color color = (Color)value;
				return new SolidColorBrush(Color.FromRgb(color.R, color.G, color.B));
			}
			return null;
		}

		// Token: 0x0600575D RID: 22365 RVA: 0x00008FC0 File Offset: 0x000071C0
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}
