using System;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities
{
	// Token: 0x0200033F RID: 831
	public interface IDesignReinforcementSidesDifferent
	{
		// Token: 0x17000A07 RID: 2567
		// (get) Token: 0x06001C9D RID: 7325
		// (set) Token: 0x06001C9E RID: 7326
		int MinTopBottomNumberOfBars { get; set; }

		// Token: 0x17000A08 RID: 2568
		// (get) Token: 0x06001C9F RID: 7327
		// (set) Token: 0x06001CA0 RID: 7328
		int MaxTopBottomNumberOfBars { get; set; }

		// Token: 0x17000A09 RID: 2569
		// (get) Token: 0x06001CA1 RID: 7329
		// (set) Token: 0x06001CA2 RID: 7330
		int MinLeftRightNumberOfBars { get; set; }

		// Token: 0x17000A0A RID: 2570
		// (get) Token: 0x06001CA3 RID: 7331
		// (set) Token: 0x06001CA4 RID: 7332
		int MaxLeftRightNumberOfBars { get; set; }

		// Token: 0x17000A0B RID: 2571
		// (get) Token: 0x06001CA5 RID: 7333
		// (set) Token: 0x06001CA6 RID: 7334
		int MinTopBottomBarSize { get; set; }

		// Token: 0x17000A0C RID: 2572
		// (get) Token: 0x06001CA7 RID: 7335
		// (set) Token: 0x06001CA8 RID: 7336
		int MaxTopBottomBarSize { get; set; }

		// Token: 0x17000A0D RID: 2573
		// (get) Token: 0x06001CA9 RID: 7337
		// (set) Token: 0x06001CAA RID: 7338
		int MinLeftRightBarSize { get; set; }

		// Token: 0x17000A0E RID: 2574
		// (get) Token: 0x06001CAB RID: 7339
		// (set) Token: 0x06001CAC RID: 7340
		int MaxLeftRightBarSize { get; set; }

		// Token: 0x17000A0F RID: 2575
		// (get) Token: 0x06001CAD RID: 7341
		// (set) Token: 0x06001CAE RID: 7342
		float TopBottomClearCover { get; set; }

		// Token: 0x17000A10 RID: 2576
		// (get) Token: 0x06001CAF RID: 7343
		// (set) Token: 0x06001CB0 RID: 7344
		float LeftRightClearCover { get; set; }
	}
}
