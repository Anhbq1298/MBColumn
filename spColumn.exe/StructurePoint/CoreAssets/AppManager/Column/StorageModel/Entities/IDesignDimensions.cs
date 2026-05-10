using System;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities
{
	// Token: 0x0200034F RID: 847
	public interface IDesignDimensions
	{
		// Token: 0x17000A29 RID: 2601
		// (get) Token: 0x06001CEB RID: 7403
		// (set) Token: 0x06001CEC RID: 7404
		float MinWidth { get; set; }

		// Token: 0x17000A2A RID: 2602
		// (get) Token: 0x06001CED RID: 7405
		// (set) Token: 0x06001CEE RID: 7406
		float MaxWidth { get; set; }

		// Token: 0x17000A2B RID: 2603
		// (get) Token: 0x06001CEF RID: 7407
		// (set) Token: 0x06001CF0 RID: 7408
		float WidthIncrement { get; set; }

		// Token: 0x17000A2C RID: 2604
		// (get) Token: 0x06001CF1 RID: 7409
		// (set) Token: 0x06001CF2 RID: 7410
		float MinHeight { get; set; }

		// Token: 0x17000A2D RID: 2605
		// (get) Token: 0x06001CF3 RID: 7411
		// (set) Token: 0x06001CF4 RID: 7412
		float MaxHeight { get; set; }

		// Token: 0x17000A2E RID: 2606
		// (get) Token: 0x06001CF5 RID: 7413
		// (set) Token: 0x06001CF6 RID: 7414
		float HeightIncrement { get; set; }
	}
}
