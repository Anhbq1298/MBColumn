using System;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities
{
	// Token: 0x0200014C RID: 332
	public interface ISlendernessOfDesignedColumn
	{
		// Token: 0x17000451 RID: 1105
		// (get) Token: 0x06000A8D RID: 2701
		// (set) Token: 0x06000A8E RID: 2702
		float Height { get; set; }

		// Token: 0x17000452 RID: 1106
		// (get) Token: 0x06000A8F RID: 2703
		// (set) Token: 0x06000A90 RID: 2704
		float Kbraced { get; set; }

		// Token: 0x17000453 RID: 1107
		// (get) Token: 0x06000A91 RID: 2705
		// (set) Token: 0x06000A92 RID: 2706
		float Ksway { get; set; }

		// Token: 0x17000454 RID: 1108
		// (get) Token: 0x06000A93 RID: 2707
		// (set) Token: 0x06000A94 RID: 2708
		bool IsBraced { get; set; }

		// Token: 0x17000455 RID: 1109
		// (get) Token: 0x06000A95 RID: 2709
		// (set) Token: 0x06000A96 RID: 2710
		bool CheckSwayAtEndsOnly { get; set; }

		// Token: 0x17000456 RID: 1110
		// (get) Token: 0x06000A97 RID: 2711
		// (set) Token: 0x06000A98 RID: 2712
		Kmode Kmode { get; set; }

		// Token: 0x17000457 RID: 1111
		// (get) Token: 0x06000A99 RID: 2713
		// (set) Token: 0x06000A9A RID: 2714
		float SumPc { get; set; }

		// Token: 0x17000458 RID: 1112
		// (get) Token: 0x06000A9B RID: 2715
		// (set) Token: 0x06000A9C RID: 2716
		float SumPu { get; set; }

		// Token: 0x17000459 RID: 1113
		// (get) Token: 0x06000A9D RID: 2717
		// (set) Token: 0x06000A9E RID: 2718
		EndConditionType EndCondition { get; set; }
	}
}
