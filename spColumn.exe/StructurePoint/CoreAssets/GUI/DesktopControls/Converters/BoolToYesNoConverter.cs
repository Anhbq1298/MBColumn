using System;
using System.Globalization;
using System.Windows.Data;
using #7hc;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A3D RID: 2621
	public sealed class BoolToYesNoConverter : IValueConverter
	{
		// Token: 0x060056C2 RID: 22210 RVA: 0x00047DA0 File Offset: 0x00045FA0
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null || !(bool)value)
			{
				return #Phc.#3hc(107429108);
			}
			return #Phc.#3hc(107429071);
		}

		// Token: 0x060056C3 RID: 22211 RVA: 0x00003909 File Offset: 0x00001B09
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
