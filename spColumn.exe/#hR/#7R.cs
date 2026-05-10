using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.Geometry.Data;

namespace #hR
{
	// Token: 0x020002E7 RID: 743
	internal sealed class #7R
	{
		// Token: 0x17000980 RID: 2432
		// (get) Token: 0x060019AC RID: 6572 RVA: 0x000199AA File Offset: 0x00017BAA
		// (set) Token: 0x060019AD RID: 6573 RVA: 0x000199B6 File Offset: 0x00017BB6
		public BoundingBoxData ModelBoundingBox { get; set; }

		// Token: 0x17000981 RID: 2433
		// (get) Token: 0x060019AE RID: 6574 RVA: 0x000199C7 File Offset: 0x00017BC7
		// (set) Token: 0x060019AF RID: 6575 RVA: 0x000199D3 File Offset: 0x00017BD3
		public Color TextColor { get; set; }

		// Token: 0x17000982 RID: 2434
		// (get) Token: 0x060019B0 RID: 6576 RVA: 0x000199E4 File Offset: 0x00017BE4
		// (set) Token: 0x060019B1 RID: 6577 RVA: 0x000199F0 File Offset: 0x00017BF0
		public int TextSize { get; set; }

		// Token: 0x17000983 RID: 2435
		// (get) Token: 0x060019B2 RID: 6578 RVA: 0x00019A01 File Offset: 0x00017C01
		// (set) Token: 0x060019B3 RID: 6579 RVA: 0x00019A0D File Offset: 0x00017C0D
		public Color DimensionsColor { get; set; }

		// Token: 0x17000984 RID: 2436
		// (get) Token: 0x060019B4 RID: 6580 RVA: 0x00019A1E File Offset: 0x00017C1E
		// (set) Token: 0x060019B5 RID: 6581 RVA: 0x00019A2A File Offset: 0x00017C2A
		public string VerticalLabel { get; set; }

		// Token: 0x17000985 RID: 2437
		// (get) Token: 0x060019B6 RID: 6582 RVA: 0x00019A3B File Offset: 0x00017C3B
		// (set) Token: 0x060019B7 RID: 6583 RVA: 0x00019A47 File Offset: 0x00017C47
		public string HorizontalLabel { get; set; }

		// Token: 0x060019B8 RID: 6584 RVA: 0x00019A58 File Offset: 0x00017C58
		public void #yl()
		{
			this.VerticalLabel = null;
			this.HorizontalLabel = null;
			this.ModelBoundingBox = null;
		}

		// Token: 0x040009D0 RID: 2512
		[CompilerGenerated]
		private BoundingBoxData #a;

		// Token: 0x040009D1 RID: 2513
		[CompilerGenerated]
		private Color #b;

		// Token: 0x040009D2 RID: 2514
		[CompilerGenerated]
		private int #c;

		// Token: 0x040009D3 RID: 2515
		[CompilerGenerated]
		private Color #d;

		// Token: 0x040009D4 RID: 2516
		[CompilerGenerated]
		private string #e;

		// Token: 0x040009D5 RID: 2517
		[CompilerGenerated]
		private string #f;
	}
}
