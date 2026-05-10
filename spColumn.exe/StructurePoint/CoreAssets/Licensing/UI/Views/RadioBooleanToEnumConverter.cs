using System;
using System.Globalization;
using System.Windows.Data;

namespace StructurePoint.CoreAssets.Licensing.UI.Views
{
	// Token: 0x0200072B RID: 1835
	internal sealed class RadioBooleanToEnumConverter : IValueConverter
	{
		// Token: 0x06003C60 RID: 15456 RVA: 0x00034210 File Offset: 0x00032410
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value != null && \u0092.~\u0013\u0003(value, parameter);
		}

		// Token: 0x06003C61 RID: 15457 RVA: 0x00034239 File Offset: 0x00032439
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null || !\u0092.~\u0013\u0003(value, true))
			{
				return Binding.DoNothing;
			}
			return parameter;
		}
	}
}
