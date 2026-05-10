using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using #owe;
using #P6e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Model;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;

namespace #wqe
{
	// Token: 0x0200115A RID: 4442
	internal sealed class #Hqe
	{
		// Token: 0x06009651 RID: 38481 RVA: 0x00077D44 File Offset: 0x00075F44
		public #Hqe(ColumnStorageModel #Od, DesignEngine #rj, #uwe #mA)
		{
			this.Model = #Od;
			this.DesignEngine = #rj;
			this.Options = #mA;
		}

		// Token: 0x17002B7E RID: 11134
		// (get) Token: 0x06009652 RID: 38482 RVA: 0x00077D6C File Offset: 0x00075F6C
		// (set) Token: 0x06009653 RID: 38483 RVA: 0x00077D74 File Offset: 0x00075F74
		public ColumnStorageModel Model { get; set; }

		// Token: 0x17002B7F RID: 11135
		// (get) Token: 0x06009654 RID: 38484 RVA: 0x00077D7D File Offset: 0x00075F7D
		// (set) Token: 0x06009655 RID: 38485 RVA: 0x00077D85 File Offset: 0x00075F85
		public DesignEngine DesignEngine { get; set; }

		// Token: 0x17002B80 RID: 11136
		// (get) Token: 0x06009656 RID: 38486 RVA: 0x00077D8E File Offset: 0x00075F8E
		// (set) Token: 0x06009657 RID: 38487 RVA: 0x00077D96 File Offset: 0x00075F96
		public #uwe Options { get; set; }

		// Token: 0x17002B81 RID: 11137
		// (get) Token: 0x06009658 RID: 38488 RVA: 0x00077D9F File Offset: 0x00075F9F
		// (set) Token: 0x06009659 RID: 38489 RVA: 0x00077DA7 File Offset: 0x00075FA7
		public bool CreateDiagrams { get; set; }

		// Token: 0x17002B82 RID: 11138
		// (get) Token: 0x0600965A RID: 38490 RVA: 0x00077DB0 File Offset: 0x00075FB0
		// (set) Token: 0x0600965B RID: 38491 RVA: 0x00077DB8 File Offset: 0x00075FB8
		public bool ForcePlaceReinforcement { get; set; }

		// Token: 0x17002B83 RID: 11139
		// (get) Token: 0x0600965C RID: 38492 RVA: 0x00077DC1 File Offset: 0x00075FC1
		// (set) Token: 0x0600965D RID: 38493 RVA: 0x00077DC9 File Offset: 0x00075FC9
		public #Q6e Configuration { get; set; }

		// Token: 0x17002B84 RID: 11140
		// (get) Token: 0x0600965E RID: 38494 RVA: 0x00077DD2 File Offset: 0x00075FD2
		// (set) Token: 0x0600965F RID: 38495 RVA: 0x00077DDA File Offset: 0x00075FDA
		public List<ReporterImage> UserImages { get; set; } = new List<ReporterImage>();

		// Token: 0x17002B85 RID: 11141
		// (get) Token: 0x06009660 RID: 38496 RVA: 0x00077DE3 File Offset: 0x00075FE3
		// (set) Token: 0x06009661 RID: 38497 RVA: 0x00077DEB File Offset: 0x00075FEB
		public bool ModelHasValidationErrors { get; set; }

		// Token: 0x17002B86 RID: 11142
		// (get) Token: 0x06009662 RID: 38498 RVA: 0x00077DF4 File Offset: 0x00075FF4
		// (set) Token: 0x06009663 RID: 38499 RVA: 0x00077DFC File Offset: 0x00075FFC
		public bool TestMode { get; set; }

		// Token: 0x17002B87 RID: 11143
		// (get) Token: 0x06009664 RID: 38500 RVA: 0x00077E05 File Offset: 0x00076005
		// (set) Token: 0x06009665 RID: 38501 RVA: 0x00077E0D File Offset: 0x0007600D
		public LoadType OriginalLoadType { get; set; }

		// Token: 0x04004069 RID: 16489
		[CompilerGenerated]
		private ColumnStorageModel #a;

		// Token: 0x0400406A RID: 16490
		[CompilerGenerated]
		private DesignEngine #b;

		// Token: 0x0400406B RID: 16491
		[CompilerGenerated]
		private #uwe #c;

		// Token: 0x0400406C RID: 16492
		[CompilerGenerated]
		private bool #d;

		// Token: 0x0400406D RID: 16493
		[CompilerGenerated]
		private bool #e;

		// Token: 0x0400406E RID: 16494
		[CompilerGenerated]
		private #Q6e #f;

		// Token: 0x0400406F RID: 16495
		[CompilerGenerated]
		private List<ReporterImage> #g;

		// Token: 0x04004070 RID: 16496
		[CompilerGenerated]
		private bool #h;

		// Token: 0x04004071 RID: 16497
		[CompilerGenerated]
		private bool #i;

		// Token: 0x04004072 RID: 16498
		[CompilerGenerated]
		private LoadType #j;
	}
}
