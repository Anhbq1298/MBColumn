using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.PanelBar
{
	// Token: 0x020008B2 RID: 2226
	public interface IPanelBarControlItem
	{
		// Token: 0x17001486 RID: 5254
		// (get) Token: 0x0600461C RID: 17948
		// (set) Token: 0x0600461D RID: 17949
		string Header { get; set; }

		// Token: 0x17001487 RID: 5255
		// (get) Token: 0x0600461E RID: 17950
		// (set) Token: 0x0600461F RID: 17951
		ICommand Command { get; set; }

		// Token: 0x17001488 RID: 5256
		// (get) Token: 0x06004620 RID: 17952
		// (set) Token: 0x06004621 RID: 17953
		object CommandParameter { get; set; }

		// Token: 0x17001489 RID: 5257
		// (get) Token: 0x06004622 RID: 17954
		ICollection<IPanelBarControlItem> Items { get; }

		// Token: 0x1700148A RID: 5258
		// (get) Token: 0x06004623 RID: 17955
		// (set) Token: 0x06004624 RID: 17956
		bool IsExpanded { get; set; }

		// Token: 0x1700148B RID: 5259
		// (get) Token: 0x06004625 RID: 17957
		// (set) Token: 0x06004626 RID: 17958
		bool IsSelected { get; set; }
	}
}
