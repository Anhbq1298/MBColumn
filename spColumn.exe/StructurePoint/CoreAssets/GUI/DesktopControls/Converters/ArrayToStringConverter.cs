using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using #7hc;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A39 RID: 2617
	public sealed class ArrayToStringConverter : IMultiValueConverter
	{
		// Token: 0x060056AA RID: 22186 RVA: 0x00047C6C File Offset: 0x00045E6C
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			if (values == null || !values.Any<object>())
			{
				return #Phc.#3hc(107429093);
			}
			return string.Join(Environment.NewLine, values);
		}

		// Token: 0x060056AB RID: 22187 RVA: 0x00008FC0 File Offset: 0x000071C0
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}
