using System;
using System.Globalization;
using System.Windows.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A3E RID: 2622
	public sealed class CompactPathConverter : IValueConverter
	{
		// Token: 0x060056C5 RID: 22213 RVA: 0x00165E70 File Offset: 0x00164070
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			int num = System.Convert.ToInt32(parameter);
			string text = value as string;
			if (string.IsNullOrWhiteSpace(text) || text.Length <= num)
			{
				return text;
			}
			object result;
			try
			{
				result = LayoutHelper.CompactPath(text, num);
			}
			catch
			{
				result = text;
			}
			return result;
		}

		// Token: 0x060056C6 RID: 22214 RVA: 0x000143CE File Offset: 0x000125CE
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value;
		}
	}
}
