using System;
using System.Globalization;
using System.Windows.Data;
using #7hc;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A48 RID: 2632
	public sealed class HyphenDividedTextMultiConverter : IMultiValueConverter
	{
		// Token: 0x060056E7 RID: 22247 RVA: 0x00047E6F File Offset: 0x0004606F
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			return string.Join(#Phc.#3hc(107382888), values);
		}

		// Token: 0x060056E8 RID: 22248 RVA: 0x00003909 File Offset: 0x00001B09
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
