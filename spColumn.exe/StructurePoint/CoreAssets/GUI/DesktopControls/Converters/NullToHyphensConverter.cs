using System;
using System.Globalization;
using System.Windows.Data;
using #7hc;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A61 RID: 2657
	public sealed class NullToHyphensConverter : IValueConverter
	{
		// Token: 0x06005738 RID: 22328 RVA: 0x00048006 File Offset: 0x00046206
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
			{
				return #Phc.#3hc(107361293);
			}
			return value;
		}

		// Token: 0x06005739 RID: 22329 RVA: 0x00047C65 File Offset: 0x00045E65
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Binding.DoNothing;
		}
	}
}
