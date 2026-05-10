using System;
using System.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000AC6 RID: 2758
	public interface IRichComboBoxItemData
	{
		// Token: 0x1700195B RID: 6491
		// (get) Token: 0x060059CB RID: 22987
		// (set) Token: 0x060059CC RID: 22988
		string Header { get; set; }

		// Token: 0x1700195C RID: 6492
		// (get) Token: 0x060059CD RID: 22989
		// (set) Token: 0x060059CE RID: 22990
		string Description { get; set; }

		// Token: 0x1700195D RID: 6493
		// (get) Token: 0x060059CF RID: 22991
		// (set) Token: 0x060059D0 RID: 22992
		Image Image { get; set; }
	}
}
