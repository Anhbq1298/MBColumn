using System;
using System.Globalization;
using System.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A42 RID: 2626
	public sealed class CustomInvertedBooleanConverter : IValueConverter
	{
		// Token: 0x060056D5 RID: 22229 RVA: 0x00166148 File Offset: 0x00164348
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
			{
				return false;
			}
			return !(value as bool?).GetValueOrDefault();
		}

		// Token: 0x060056D6 RID: 22230 RVA: 0x00008FC0 File Offset: 0x000071C0
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}
