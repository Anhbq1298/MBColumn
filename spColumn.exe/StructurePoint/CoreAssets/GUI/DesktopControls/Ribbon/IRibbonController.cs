using System;
using System.Collections.Generic;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Ribbon
{
	// Token: 0x0200089F RID: 2207
	public interface IRibbonController
	{
		// Token: 0x17001445 RID: 5189
		// (get) Token: 0x0600457F RID: 17791
		IList<RibbonTab> Tabs { get; }

		// Token: 0x17001446 RID: 5190
		// (get) Token: 0x06004580 RID: 17792
		IList<RibbonButton> QuickAccessItems { get; }

		// Token: 0x17001447 RID: 5191
		// (get) Token: 0x06004581 RID: 17793
		IList<RibbonBackstageButton> ApplicationMenuItems { get; }

		// Token: 0x17001448 RID: 5192
		// (get) Token: 0x06004582 RID: 17794
		// (set) Token: 0x06004583 RID: 17795
		RibbonTab SelectedTab { get; set; }

		// Token: 0x17001449 RID: 5193
		// (get) Token: 0x06004584 RID: 17796
		// (set) Token: 0x06004585 RID: 17797
		string Title { get; set; }

		// Token: 0x1700144A RID: 5194
		// (get) Token: 0x06004586 RID: 17798
		// (set) Token: 0x06004587 RID: 17799
		string AppName { get; set; }

		// Token: 0x1700144B RID: 5195
		// (get) Token: 0x06004588 RID: 17800
		// (set) Token: 0x06004589 RID: 17801
		bool IsBackstageOpened { get; set; }
	}
}
