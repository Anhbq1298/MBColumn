using System;
using System.Globalization;
using System.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A43 RID: 2627
	public sealed class DebuggerValueConverter : IValueConverter
	{
		// Token: 0x060056D8 RID: 22232 RVA: 0x000143CE File Offset: 0x000125CE
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value;
		}

		// Token: 0x060056D9 RID: 22233 RVA: 0x000143CE File Offset: 0x000125CE
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value;
		}
	}
}
