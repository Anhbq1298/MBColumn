using System;
using #ezc;
using StructurePoint.CoreAssets.GUI.DesktopControls;

namespace #YKc
{
	// Token: 0x02000B77 RID: 2935
	internal interface #9Kc : #QBc, #SBc
	{
		// Token: 0x17001B2E RID: 6958
		// (get) Token: 0x06005FCF RID: 24527
		// (set) Token: 0x06005FD0 RID: 24528
		object DataContext { get; set; }

		// Token: 0x17001B2F RID: 6959
		// (get) Token: 0x06005FD1 RID: 24529
		// (set) Token: 0x06005FD2 RID: 24530
		HelpID HelpId { get; set; }

		// Token: 0x06005FD3 RID: 24531
		void RefreshLayout();
	}
}
