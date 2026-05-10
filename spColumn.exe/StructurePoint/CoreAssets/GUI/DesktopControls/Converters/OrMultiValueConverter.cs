using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A62 RID: 2658
	[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Multi")]
	public sealed class OrMultiValueConverter : IMultiValueConverter
	{
		// Token: 0x0600573B RID: 22331 RVA: 0x0016675C File Offset: 0x0016495C
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
			return source.Any((bool item) => item);
		}

		// Token: 0x0600573C RID: 22332 RVA: 0x00008FC0 File Offset: 0x000071C0
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}
