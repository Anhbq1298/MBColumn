using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A64 RID: 2660
	public sealed class OrToVisibilityMultiValueConverter : IMultiValueConverter
	{
		// Token: 0x06005741 RID: 22337 RVA: 0x001667C4 File Offset: 0x001649C4
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			if (values == null)
			{
				return Visibility.Collapsed;
			}
			List<bool> source = values.OfType<bool>().ToList<bool>();
			if (!source.Any<bool>())
			{
				return Visibility.Collapsed;
			}
			return source.Any((bool item) => item) ? Visibility.Visible : Visibility.Collapsed;
		}

		// Token: 0x06005742 RID: 22338 RVA: 0x00008FC0 File Offset: 0x000071C0
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}
