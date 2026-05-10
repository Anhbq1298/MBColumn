using System;
using System.Globalization;
using System.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A56 RID: 2646
	public sealed class IsCollapsedToRibbonHeightConverter : IValueConverter
	{
		// Token: 0x170018F3 RID: 6387
		// (get) Token: 0x06005711 RID: 22289 RVA: 0x00047F1F File Offset: 0x0004611F
		// (set) Token: 0x06005712 RID: 22290 RVA: 0x00047F2B File Offset: 0x0004612B
		public int ExpandedHeight { get; set; }

		// Token: 0x170018F4 RID: 6388
		// (get) Token: 0x06005713 RID: 22291 RVA: 0x00047F3C File Offset: 0x0004613C
		// (set) Token: 0x06005714 RID: 22292 RVA: 0x00047F48 File Offset: 0x00046148
		public int CollapsedHeight { get; set; }

		// Token: 0x06005715 RID: 22293 RVA: 0x00047F59 File Offset: 0x00046159
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return ((bool)value) ? this.CollapsedHeight : this.ExpandedHeight;
		}

		// Token: 0x06005716 RID: 22294 RVA: 0x00003909 File Offset: 0x00001B09
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
