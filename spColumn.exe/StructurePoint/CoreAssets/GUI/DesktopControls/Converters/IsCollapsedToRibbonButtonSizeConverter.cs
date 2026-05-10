using System;
using System.Globalization;
using System.Windows.Data;
using Telerik.Windows.Controls.RibbonView;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A55 RID: 2645
	public sealed class IsCollapsedToRibbonButtonSizeConverter : IValueConverter
	{
		// Token: 0x0600570E RID: 22286 RVA: 0x00047F08 File Offset: 0x00046108
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return ((bool)value) ? ButtonSize.Small : ButtonSize.Large;
		}

		// Token: 0x0600570F RID: 22287 RVA: 0x00003909 File Offset: 0x00001B09
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
