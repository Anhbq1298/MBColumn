using System;
using System.Globalization;
using System.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A66 RID: 2662
	public sealed class InvertedRadioBooleanToEnumConverter : IValueConverter
	{
		// Token: 0x06005747 RID: 22343 RVA: 0x00048043 File Offset: 0x00046243
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value != null && !value.Equals(parameter);
		}

		// Token: 0x06005748 RID: 22344 RVA: 0x00008FC0 File Offset: 0x000071C0
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}
