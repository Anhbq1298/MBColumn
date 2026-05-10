using System;
using System.Globalization;
using System.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A67 RID: 2663
	public sealed class PopupHorizontalCenterOffsetConverter : IMultiValueConverter
	{
		// Token: 0x0600574A RID: 22346 RVA: 0x00166834 File Offset: 0x00164A34
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			if (values != null && values.Length == 2)
			{
				object obj = values[0];
				if (obj is double)
				{
					double num = (double)obj;
					obj = values[1];
					if (obj is double)
					{
						double num2 = (double)obj;
						return -(num2 / 2.0) + num / 2.0;
					}
				}
			}
			return 0.0;
		}

		// Token: 0x0600574B RID: 22347 RVA: 0x00008FC0 File Offset: 0x000071C0
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}
