using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A3F RID: 2623
	public sealed class DataSourceToLastItemConverter : IValueConverter
	{
		// Token: 0x060056C8 RID: 22216 RVA: 0x00165ECC File Offset: 0x001640CC
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			IEnumerable<object> enumerable = value as IEnumerable<object>;
			if (enumerable != null)
			{
				return enumerable.LastOrDefault<object>();
			}
			return Binding.DoNothing;
		}

		// Token: 0x060056C9 RID: 22217 RVA: 0x00003909 File Offset: 0x00001B09
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
