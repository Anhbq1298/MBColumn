using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace StructurePoint.CoreAssets.Licensing.UI.Views
{
	// Token: 0x02000729 RID: 1833
	internal sealed class OrToVisibilityMultiValueConverter : IMultiValueConverter
	{
		// Token: 0x06003C5A RID: 15450 RVA: 0x001196A4 File Offset: 0x001178A4
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			int num2;
			List<bool> source;
			if (4 != 0)
			{
				if (values == null)
				{
					if (false)
					{
						goto IL_35;
					}
					int num = num2 = 2;
					if (num != 0)
					{
						return (Visibility)num;
					}
					goto IL_2F;
				}
				else
				{
					source = values.OfType<bool>().ToList<bool>();
				}
			}
			if (source.Any<bool>() || 2 == 0)
			{
				goto IL_35;
			}
			num2 = 2;
			IL_2F:
			return (Visibility)num2;
			IL_35:
			Visibility visibility;
			if (!false)
			{
				if (!source.Any((bool item) => item))
				{
					visibility = Visibility.Collapsed;
					goto IL_61;
				}
			}
			visibility = Visibility.Visible;
			IL_61:
			return visibility;
		}

		// Token: 0x06003C5B RID: 15451 RVA: 0x00008FC0 File Offset: 0x000071C0
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}
