using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace StructurePoint.CoreAssets.Column.Core.Resources
{
	// Token: 0x0200086E RID: 2158
	public sealed class ParameterStyleConverter : IValueConverter
	{
		// Token: 0x17001422 RID: 5154
		// (get) Token: 0x0600448D RID: 17549 RVA: 0x000392D3 File Offset: 0x000374D3
		// (set) Token: 0x0600448E RID: 17550 RVA: 0x000392DB File Offset: 0x000374DB
		public Style LeftTopColumnBorderStyle { get; set; }

		// Token: 0x17001423 RID: 5155
		// (get) Token: 0x0600448F RID: 17551 RVA: 0x000392E4 File Offset: 0x000374E4
		// (set) Token: 0x06004490 RID: 17552 RVA: 0x000392EC File Offset: 0x000374EC
		public Style CenterRightTopColumnBorderStyle { get; set; }

		// Token: 0x17001424 RID: 5156
		// (get) Token: 0x06004491 RID: 17553 RVA: 0x000392F5 File Offset: 0x000374F5
		// (set) Token: 0x06004492 RID: 17554 RVA: 0x000392FD File Offset: 0x000374FD
		public Style LeftColumnBorderStyle { get; set; }

		// Token: 0x17001425 RID: 5157
		// (get) Token: 0x06004493 RID: 17555 RVA: 0x00039306 File Offset: 0x00037506
		// (set) Token: 0x06004494 RID: 17556 RVA: 0x0003930E File Offset: 0x0003750E
		public Style CenterRightColumnBorderStyle { get; set; }

		// Token: 0x06004495 RID: 17557 RVA: 0x0013BDCC File Offset: 0x00139FCC
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			bool flag = (bool)value;
			StyleType styleType = (StyleType)((int)parameter);
			if (styleType != StyleType.Left)
			{
				if (styleType - StyleType.Center > 1)
				{
					throw new ArgumentOutOfRangeException();
				}
				if (!flag)
				{
					return this.CenterRightColumnBorderStyle;
				}
				return this.CenterRightTopColumnBorderStyle;
			}
			else
			{
				if (!flag)
				{
					return this.LeftColumnBorderStyle;
				}
				return this.LeftTopColumnBorderStyle;
			}
		}

		// Token: 0x06004496 RID: 17558 RVA: 0x0001233F File Offset: 0x0001053F
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return null;
		}
	}
}
