using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A31 RID: 2609
	[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Multi")]
	public sealed class AndMultiValueConverter : IMultiValueConverter
	{
		// Token: 0x06005690 RID: 22160 RVA: 0x00165CA8 File Offset: 0x00163EA8
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
			return source.All((bool item) => item);
		}

		// Token: 0x06005691 RID: 22161 RVA: 0x00008FC0 File Offset: 0x000071C0
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}
