using System;
using System.Globalization;
using System.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A5B RID: 2651
	public sealed class IsNotNullToBooleanConverter : IValueConverter
	{
		// Token: 0x06005724 RID: 22308 RVA: 0x00047F82 File Offset: 0x00046182
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value != null;
		}

		// Token: 0x06005725 RID: 22309 RVA: 0x00008FC0 File Offset: 0x000071C0
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}
