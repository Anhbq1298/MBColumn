using System;
using StructurePoint.Products.Column.Model.Entities;

namespace #n8
{
	// Token: 0x020003C5 RID: 965
	internal interface #z8
	{
		// Token: 0x17000B78 RID: 2936
		// (get) Token: 0x060020FF RID: 8447
		// (set) Token: 0x06002100 RID: 8448
		int MinTopBottomNumberOfBars { get; set; }

		// Token: 0x17000B79 RID: 2937
		// (get) Token: 0x06002101 RID: 8449
		// (set) Token: 0x06002102 RID: 8450
		int MaxTopBottomNumberOfBars { get; set; }

		// Token: 0x17000B7A RID: 2938
		// (get) Token: 0x06002103 RID: 8451
		// (set) Token: 0x06002104 RID: 8452
		int MinLeftRightNumberOfBars { get; set; }

		// Token: 0x17000B7B RID: 2939
		// (get) Token: 0x06002105 RID: 8453
		// (set) Token: 0x06002106 RID: 8454
		int MaxLeftRightNumberOfBars { get; set; }

		// Token: 0x17000B7C RID: 2940
		// (get) Token: 0x06002107 RID: 8455
		// (set) Token: 0x06002108 RID: 8456
		StandardBar MinTopBottomBar { get; set; }

		// Token: 0x17000B7D RID: 2941
		// (get) Token: 0x06002109 RID: 8457
		// (set) Token: 0x0600210A RID: 8458
		StandardBar MaxTopBottomBar { get; set; }

		// Token: 0x17000B7E RID: 2942
		// (get) Token: 0x0600210B RID: 8459
		// (set) Token: 0x0600210C RID: 8460
		StandardBar MinLeftRightBar { get; set; }

		// Token: 0x17000B7F RID: 2943
		// (get) Token: 0x0600210D RID: 8461
		// (set) Token: 0x0600210E RID: 8462
		StandardBar MaxLeftRightBar { get; set; }

		// Token: 0x17000B80 RID: 2944
		// (get) Token: 0x0600210F RID: 8463
		// (set) Token: 0x06002110 RID: 8464
		float TopBottomClearCover { get; set; }

		// Token: 0x17000B81 RID: 2945
		// (get) Token: 0x06002111 RID: 8465
		// (set) Token: 0x06002112 RID: 8466
		float LeftRightClearCover { get; set; }
	}
}
