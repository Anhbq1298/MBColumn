using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using StructurePoint.Products.Column.Services.Rendering;

namespace #hR
{
	// Token: 0x020002EA RID: 746
	internal sealed class #tS
	{
		// Token: 0x1700098A RID: 2442
		// (get) Token: 0x060019C4 RID: 6596 RVA: 0x00019B22 File Offset: 0x00017D22
		// (set) Token: 0x060019C5 RID: 6597 RVA: 0x00019B2E File Offset: 0x00017D2E
		public bool UseGlobalSettings { get; set; }

		// Token: 0x1700098B RID: 2443
		// (get) Token: 0x060019C6 RID: 6598 RVA: 0x00019B3F File Offset: 0x00017D3F
		// (set) Token: 0x060019C7 RID: 6599 RVA: 0x00019B4B File Offset: 0x00017D4B
		public bool ShowCover { get; set; }

		// Token: 0x1700098C RID: 2444
		// (get) Token: 0x060019C8 RID: 6600 RVA: 0x00019B5C File Offset: 0x00017D5C
		// (set) Token: 0x060019C9 RID: 6601 RVA: 0x00019B68 File Offset: 0x00017D68
		public bool ShowCoordinateSign { get; set; }

		// Token: 0x1700098D RID: 2445
		// (get) Token: 0x060019CA RID: 6602 RVA: 0x00019B79 File Offset: 0x00017D79
		// (set) Token: 0x060019CB RID: 6603 RVA: 0x00019B85 File Offset: 0x00017D85
		public bool ShowCentroid { get; set; }

		// Token: 0x1700098E RID: 2446
		// (get) Token: 0x060019CC RID: 6604 RVA: 0x00019B96 File Offset: 0x00017D96
		// (set) Token: 0x060019CD RID: 6605 RVA: 0x00019BA2 File Offset: 0x00017DA2
		public bool ShowDimensions { get; set; }

		// Token: 0x1700098F RID: 2447
		// (get) Token: 0x060019CE RID: 6606 RVA: 0x00019BB3 File Offset: 0x00017DB3
		// (set) Token: 0x060019CF RID: 6607 RVA: 0x00019BBF File Offset: 0x00017DBF
		public bool ShowAnnotations { get; set; }

		// Token: 0x17000990 RID: 2448
		// (get) Token: 0x060019D0 RID: 6608 RVA: 0x00019BD0 File Offset: 0x00017DD0
		// (set) Token: 0x060019D1 RID: 6609 RVA: 0x00019BDC File Offset: 0x00017DDC
		public bool ShowDxfImportNote { get; set; }

		// Token: 0x17000991 RID: 2449
		// (get) Token: 0x060019D2 RID: 6610 RVA: 0x00019BED File Offset: 0x00017DED
		// (set) Token: 0x060019D3 RID: 6611 RVA: 0x00019BF9 File Offset: 0x00017DF9
		public string DxfImportNote { get; set; }

		// Token: 0x17000992 RID: 2450
		// (get) Token: 0x060019D4 RID: 6612 RVA: 0x00019C0A File Offset: 0x00017E0A
		// (set) Token: 0x060019D5 RID: 6613 RVA: 0x00019C16 File Offset: 0x00017E16
		public List<#fS> Centroids { get; set; }

		// Token: 0x17000993 RID: 2451
		// (get) Token: 0x060019D6 RID: 6614 RVA: 0x00019C27 File Offset: 0x00017E27
		// (set) Token: 0x060019D7 RID: 6615 RVA: 0x00019C33 File Offset: 0x00017E33
		public List<BillboardLabel> Labels { get; set; }

		// Token: 0x17000994 RID: 2452
		// (get) Token: 0x060019D8 RID: 6616 RVA: 0x00019C44 File Offset: 0x00017E44
		public #7R Dimensions { get; }

		// Token: 0x17000995 RID: 2453
		// (get) Token: 0x060019D9 RID: 6617 RVA: 0x00019C50 File Offset: 0x00017E50
		public #7R SelectionDimensions { get; }

		// Token: 0x060019DA RID: 6618 RVA: 0x00019C5C File Offset: 0x00017E5C
		public void #yl()
		{
			this.Centroids.Clear();
			this.Labels.Clear();
			this.Dimensions.#yl();
			this.SelectionDimensions.#yl();
		}

		// Token: 0x040009DD RID: 2525
		[CompilerGenerated]
		private bool #a = true;

		// Token: 0x040009DE RID: 2526
		[CompilerGenerated]
		private bool #b;

		// Token: 0x040009DF RID: 2527
		[CompilerGenerated]
		private bool #c;

		// Token: 0x040009E0 RID: 2528
		[CompilerGenerated]
		private bool #d;

		// Token: 0x040009E1 RID: 2529
		[CompilerGenerated]
		private bool #e;

		// Token: 0x040009E2 RID: 2530
		[CompilerGenerated]
		private bool #f;

		// Token: 0x040009E3 RID: 2531
		[CompilerGenerated]
		private bool #g;

		// Token: 0x040009E4 RID: 2532
		[CompilerGenerated]
		private string #h;

		// Token: 0x040009E5 RID: 2533
		[CompilerGenerated]
		private List<#fS> #i = new List<#fS>();

		// Token: 0x040009E6 RID: 2534
		[CompilerGenerated]
		private List<BillboardLabel> #j = new List<BillboardLabel>();

		// Token: 0x040009E7 RID: 2535
		[CompilerGenerated]
		private readonly #7R #k = new #7R();

		// Token: 0x040009E8 RID: 2536
		[CompilerGenerated]
		private readonly #7R #l = new #7R();
	}
}
