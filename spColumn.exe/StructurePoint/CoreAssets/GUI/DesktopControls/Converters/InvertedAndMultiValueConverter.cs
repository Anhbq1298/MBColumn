using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A4A RID: 2634
	public sealed class InvertedAndMultiValueConverter : IMultiValueConverter
	{
		// Token: 0x060056ED RID: 22253 RVA: 0x00166254 File Offset: 0x00164454
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
			return !source.All((bool item) => item);
		}

		// Token: 0x060056EE RID: 22254 RVA: 0x00008FC0 File Offset: 0x000071C0
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}
