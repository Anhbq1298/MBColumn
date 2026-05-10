using System;

namespace StructurePoint.CoreAssets.GUI.DesktopControls
{
	// Token: 0x02000898 RID: 2200
	public interface IContextMenuItemBase
	{
		// Token: 0x17001438 RID: 5176
		// (get) Token: 0x06004561 RID: 17761
		// (set) Token: 0x06004562 RID: 17762
		string Header { get; set; }

		// Token: 0x17001439 RID: 5177
		// (get) Token: 0x06004563 RID: 17763
		// (set) Token: 0x06004564 RID: 17764
		object CommandParameter { get; set; }

		// Token: 0x1700143A RID: 5178
		// (get) Token: 0x06004565 RID: 17765
		// (set) Token: 0x06004566 RID: 17766
		object Icon { get; set; }
	}
}
