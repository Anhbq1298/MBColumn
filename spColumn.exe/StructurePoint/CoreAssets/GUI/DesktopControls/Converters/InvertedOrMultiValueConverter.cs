using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A50 RID: 2640
	public sealed class InvertedOrMultiValueConverter : IMultiValueConverter
	{
		// Token: 0x060056FF RID: 22271 RVA: 0x00166370 File Offset: 0x00164570
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			if (values == null)
			{
				return false;
			}
			List<bool> source = values.OfType<bool>().ToList<bool>();
			if (!source.Any<bool>())
			{
				return false;
			}
			return !source.Any((bool item) => item);
		}

		// Token: 0x06005700 RID: 22272 RVA: 0x00008FC0 File Offset: 0x000071C0
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}
