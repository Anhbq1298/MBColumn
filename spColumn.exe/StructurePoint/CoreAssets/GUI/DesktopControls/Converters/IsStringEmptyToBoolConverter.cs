using System;
using System.Globalization;
using System.Windows.Data;
using #7hc;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A5E RID: 2654
	public sealed class IsStringEmptyToBoolConverter : IValueConverter
	{
		// Token: 0x0600572D RID: 22317 RVA: 0x00047FA0 File Offset: 0x000461A0
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
			{
				return true;
			}
			return value.ToString().Equals(#Phc.#3hc(107381628));
		}

		// Token: 0x0600572E RID: 22318 RVA: 0x00003909 File Offset: 0x00001B09
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
