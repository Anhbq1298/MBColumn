using System;
using System.Globalization;
using System.Windows.Data;
using #7hc;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A47 RID: 2631
	public sealed class CommaSeparatedTextMultiConverter : IMultiValueConverter
	{
		// Token: 0x060056E4 RID: 22244 RVA: 0x00047E51 File Offset: 0x00046051
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			return string.Join(#Phc.#3hc(107376612), values);
		}

		// Token: 0x060056E5 RID: 22245 RVA: 0x00003909 File Offset: 0x00001B09
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
