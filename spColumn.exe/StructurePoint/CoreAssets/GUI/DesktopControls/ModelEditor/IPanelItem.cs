using System;
using System.Windows;
using System.Windows.Media;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor
{
	// Token: 0x02000929 RID: 2345
	public interface IPanelItem
	{
		// Token: 0x1700163B RID: 5691
		// (get) Token: 0x06004C68 RID: 19560
		// (set) Token: 0x06004C69 RID: 19561
		string Header { get; set; }

		// Token: 0x1700163C RID: 5692
		// (get) Token: 0x06004C6A RID: 19562
		// (set) Token: 0x06004C6B RID: 19563
		HorizontalAlignment HorizontalAlignment { get; set; }

		// Token: 0x1700163D RID: 5693
		// (get) Token: 0x06004C6C RID: 19564
		// (set) Token: 0x06004C6D RID: 19565
		object Content { get; set; }

		// Token: 0x1700163E RID: 5694
		// (get) Token: 0x06004C6E RID: 19566
		// (set) Token: 0x06004C6F RID: 19567
		Visibility Visibility { get; set; }

		// Token: 0x1700163F RID: 5695
		// (get) Token: 0x06004C70 RID: 19568
		// (set) Token: 0x06004C71 RID: 19569
		Thickness Margin { get; set; }

		// Token: 0x17001640 RID: 5696
		// (get) Token: 0x06004C72 RID: 19570
		// (set) Token: 0x06004C73 RID: 19571
		Thickness BorderThickness { get; set; }

		// Token: 0x17001641 RID: 5697
		// (get) Token: 0x06004C74 RID: 19572
		// (set) Token: 0x06004C75 RID: 19573
		Brush BorderBrush { get; set; }
	}
}
