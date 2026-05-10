using System;
using StructurePoint.CoreAssets.GUI.DesktopControls.Tree;
using StructurePoint.CoreAssets.GUI.Framework.Collections;

namespace #LQc
{
	// Token: 0x02000C3A RID: 3130
	internal interface #DRc
	{
		// Token: 0x17001C4E RID: 7246
		// (get) Token: 0x0600657E RID: 25982
		CustomObservableCollection<ITreeItemData> GlobalContextMenuItems { get; }

		// Token: 0x17001C4F RID: 7247
		// (get) Token: 0x0600657F RID: 25983
		CustomObservableCollection<ITreeItemData> LocalContextMenuItems { get; }
	}
}
