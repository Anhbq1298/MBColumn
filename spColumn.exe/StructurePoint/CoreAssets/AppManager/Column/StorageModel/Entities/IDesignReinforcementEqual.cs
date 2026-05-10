using System;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities
{
	// Token: 0x02000342 RID: 834
	public interface IDesignReinforcementEqual
	{
		// Token: 0x17000A11 RID: 2577
		// (get) Token: 0x06001CB3 RID: 7347
		// (set) Token: 0x06001CB4 RID: 7348
		int MinNumberOfBars { get; set; }

		// Token: 0x17000A12 RID: 2578
		// (get) Token: 0x06001CB5 RID: 7349
		// (set) Token: 0x06001CB6 RID: 7350
		int MinBarSize { get; set; }

		// Token: 0x17000A13 RID: 2579
		// (get) Token: 0x06001CB7 RID: 7351
		// (set) Token: 0x06001CB8 RID: 7352
		int MaxNumberOfBars { get; set; }

		// Token: 0x17000A14 RID: 2580
		// (get) Token: 0x06001CB9 RID: 7353
		// (set) Token: 0x06001CBA RID: 7354
		int MaxBarSize { get; set; }

		// Token: 0x17000A15 RID: 2581
		// (get) Token: 0x06001CBB RID: 7355
		// (set) Token: 0x06001CBC RID: 7356
		float ClearCover { get; set; }
	}
}
