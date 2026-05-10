using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A52 RID: 2642
	public sealed class InvertedOrToVisibilityMultiValueConverter : IMultiValueConverter
	{
		// Token: 0x06005705 RID: 22277 RVA: 0x001663DC File Offset: 0x001645DC
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
			return source.Any((bool item) => item) ? Visibility.Collapsed : Visibility.Visible;
		}

		// Token: 0x06005706 RID: 22278 RVA: 0x00008FC0 File Offset: 0x000071C0
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}
