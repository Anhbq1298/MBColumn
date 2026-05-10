using System;
using #hg;

namespace #Xc
{
	// Token: 0x020000A5 RID: 165
	internal interface #vd
	{
		// Token: 0x1400001D RID: 29
		// (add) Token: 0x06000567 RID: 1383
		// (remove) Token: 0x06000568 RID: 1384
		event EventHandler ActiveDockingChanged;

		// Token: 0x170002AE RID: 686
		// (get) Token: 0x06000569 RID: 1385
		// (set) Token: 0x0600056A RID: 1386
		#ud DiagramsViewports { get; set; }

		// Token: 0x170002AF RID: 687
		// (get) Token: 0x0600056B RID: 1387
		// (set) Token: 0x0600056C RID: 1388
		#jg EditorViewports { get; set; }

		// Token: 0x170002B0 RID: 688
		// (get) Token: 0x0600056D RID: 1389
		bool IsChangingArrangement { get; }

		// Token: 0x0600056E RID: 1390
		void #jd();

		// Token: 0x0600056F RID: 1391
		void #kd();
	}
}
