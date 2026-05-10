using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.RibbonToolbar
{
	// Token: 0x02000904 RID: 2308
	internal sealed class OrientationToStyleConverter : IValueConverter
	{
		// Token: 0x1700158E RID: 5518
		// (get) Token: 0x0600498B RID: 18827 RVA: 0x0003E0BD File Offset: 0x0003C2BD
		// (set) Token: 0x0600498C RID: 18828 RVA: 0x0003E0C9 File Offset: 0x0003C2C9
		public Style HorizontalStyle { get; set; }

		// Token: 0x1700158F RID: 5519
		// (get) Token: 0x0600498D RID: 18829 RVA: 0x0003E0DA File Offset: 0x0003C2DA
		// (set) Token: 0x0600498E RID: 18830 RVA: 0x0003E0E6 File Offset: 0x0003C2E6
		public Style VerticalStyle { get; set; }

		// Token: 0x0600498F RID: 18831 RVA: 0x001450A4 File Offset: 0x001432A4
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			Orientation? orientation = value as Orientation?;
			if (orientation != null && orientation.Value == Orientation.Vertical)
			{
				return this.VerticalStyle;
			}
			return this.HorizontalStyle;
		}

		// Token: 0x06004990 RID: 18832 RVA: 0x00008FC0 File Offset: 0x000071C0
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}
