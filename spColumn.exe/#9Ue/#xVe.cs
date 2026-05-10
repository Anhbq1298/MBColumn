using System;

namespace #9Ue
{
	// Token: 0x020012ED RID: 4845
	internal interface #xVe
	{
		// Token: 0x17002E7C RID: 11900
		// (get) Token: 0x0600A1DB RID: 41435
		int Index { get; }

		// Token: 0x17002E7D RID: 11901
		// (get) Token: 0x0600A1DC RID: 41436
		float MomentX { get; }

		// Token: 0x17002E7E RID: 11902
		// (get) Token: 0x0600A1DD RID: 41437
		float MomentY { get; }

		// Token: 0x17002E7F RID: 11903
		// (get) Token: 0x0600A1DE RID: 41438
		float AxialLoad { get; }

		// Token: 0x17002E80 RID: 11904
		// (get) Token: 0x0600A1DF RID: 41439
		// (set) Token: 0x0600A1E0 RID: 41440
		float? PhiPn { get; set; }

		// Token: 0x17002E81 RID: 11905
		// (get) Token: 0x0600A1E1 RID: 41441
		// (set) Token: 0x0600A1E2 RID: 41442
		float? PhiMn { get; set; }

		// Token: 0x17002E82 RID: 11906
		// (get) Token: 0x0600A1E3 RID: 41443
		// (set) Token: 0x0600A1E4 RID: 41444
		float? Usf { get; set; }

		// Token: 0x17002E83 RID: 11907
		// (get) Token: 0x0600A1E5 RID: 41445
		// (set) Token: 0x0600A1E6 RID: 41446
		float? Nadepth { get; set; }

		// Token: 0x17002E84 RID: 11908
		// (get) Token: 0x0600A1E7 RID: 41447
		// (set) Token: 0x0600A1E8 RID: 41448
		float? Dt { get; set; }

		// Token: 0x17002E85 RID: 11909
		// (get) Token: 0x0600A1E9 RID: 41449
		// (set) Token: 0x0600A1EA RID: 41450
		float? Eps { get; set; }

		// Token: 0x17002E86 RID: 11910
		// (get) Token: 0x0600A1EB RID: 41451
		// (set) Token: 0x0600A1EC RID: 41452
		float? Phi { get; set; }

		// Token: 0x17002E87 RID: 11911
		// (get) Token: 0x0600A1ED RID: 41453
		// (set) Token: 0x0600A1EE RID: 41454
		bool IsLoadCapacityExceeded { get; set; }

		// Token: 0x17002E88 RID: 11912
		// (get) Token: 0x0600A1EF RID: 41455
		// (set) Token: 0x0600A1F0 RID: 41456
		#FVe Flags { get; set; }
	}
}
