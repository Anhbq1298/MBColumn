using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A6A RID: 2666
	public sealed class NullableColorToBrushConverter : IValueConverter
	{
		// Token: 0x06005753 RID: 22355 RVA: 0x001668DC File Offset: 0x00164ADC
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			Color? color = (Color?)value;
			if (value != null)
			{
				return new SolidColorBrush(color.Value);
			}
			return null;
		}

		// Token: 0x06005754 RID: 22356 RVA: 0x00008FC0 File Offset: 0x000071C0
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}
