using System;
using System.Globalization;
using System.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A5C RID: 2652
	public sealed class IsNullToBooleanConverter : IValueConverter
	{
		// Token: 0x06005727 RID: 22311 RVA: 0x00047F91 File Offset: 0x00046191
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value == null;
		}

		// Token: 0x06005728 RID: 22312 RVA: 0x00008FC0 File Offset: 0x000071C0
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}
