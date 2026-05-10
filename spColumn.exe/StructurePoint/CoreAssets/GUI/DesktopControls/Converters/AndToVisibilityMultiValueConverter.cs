using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A33 RID: 2611
	[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Multi")]
	public sealed class AndToVisibilityMultiValueConverter : IMultiValueConverter
	{
		// Token: 0x06005696 RID: 22166 RVA: 0x00165D10 File Offset: 0x00163F10
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			if (values == null)
			{
				return Visibility.Collapsed;
			}
			List<bool?> source = (from value in values.Select(delegate(object item)
			{
				if (item is Visibility)
				{
					Visibility visibility = (Visibility)item;
					return new bool?(visibility == Visibility.Visible);
				}
				if (item is bool)
				{
					bool value = (bool)item;
					return new bool?(value);
				}
				return null;
			})
			where value != null
			select value).ToList<bool?>();
			if (!source.Any<bool?>())
			{
				return Visibility.Collapsed;
			}
			return source.All((bool? item) => item.GetValueOrDefault()) ? Visibility.Visible : Visibility.Collapsed;
		}

		// Token: 0x06005697 RID: 22167 RVA: 0x00008FC0 File Offset: 0x000071C0
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}
