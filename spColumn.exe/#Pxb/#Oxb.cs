using System;
using System.ComponentModel;
using #cMb;

namespace #Pxb
{
	// Token: 0x020004C2 RID: 1218
	internal interface #Oxb : INotifyPropertyChanged, #DNb
	{
		// Token: 0x17000EEF RID: 3823
		// (get) Token: 0x06002C88 RID: 11400
		// (set) Token: 0x06002C89 RID: 11401
		bool MirrorHorizontal { get; set; }

		// Token: 0x17000EF0 RID: 3824
		// (get) Token: 0x06002C8A RID: 11402
		// (set) Token: 0x06002C8B RID: 11403
		bool MirrorVertical { get; set; }

		// Token: 0x17000EF1 RID: 3825
		// (get) Token: 0x06002C8C RID: 11404
		// (set) Token: 0x06002C8D RID: 11405
		bool RotateLeft { get; set; }

		// Token: 0x17000EF2 RID: 3826
		// (get) Token: 0x06002C8E RID: 11406
		// (set) Token: 0x06002C8F RID: 11407
		bool RotateRight { get; set; }

		// Token: 0x17000EF3 RID: 3827
		// (get) Token: 0x06002C90 RID: 11408
		// (set) Token: 0x06002C91 RID: 11409
		bool Rotate45Deg { get; set; }

		// Token: 0x17000EF4 RID: 3828
		// (get) Token: 0x06002C92 RID: 11410
		// (set) Token: 0x06002C93 RID: 11411
		bool ShowColoredZones { get; set; }

		// Token: 0x17000EF5 RID: 3829
		// (get) Token: 0x06002C94 RID: 11412
		// (set) Token: 0x06002C95 RID: 11413
		bool ShowParameters { get; set; }
	}
}
