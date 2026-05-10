using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using devDept.Geometry;

namespace StructurePoint.Products.Column.Services.Rendering
{
	// Token: 0x020002E5 RID: 741
	internal sealed class BillboardLabel
	{
		// Token: 0x17000978 RID: 2424
		// (get) Token: 0x06001999 RID: 6553 RVA: 0x000198C2 File Offset: 0x00017AC2
		// (set) Token: 0x0600199A RID: 6554 RVA: 0x000198CE File Offset: 0x00017ACE
		public string Label { get; set; }

		// Token: 0x17000979 RID: 2425
		// (get) Token: 0x0600199B RID: 6555 RVA: 0x000198DF File Offset: 0x00017ADF
		// (set) Token: 0x0600199C RID: 6556 RVA: 0x000198EB File Offset: 0x00017AEB
		public Point3D Position { get; set; }

		// Token: 0x1700097A RID: 2426
		// (get) Token: 0x0600199D RID: 6557 RVA: 0x000198FC File Offset: 0x00017AFC
		// (set) Token: 0x0600199E RID: 6558 RVA: 0x00019908 File Offset: 0x00017B08
		public float TextSize { get; set; }

		// Token: 0x1700097B RID: 2427
		// (get) Token: 0x0600199F RID: 6559 RVA: 0x00019919 File Offset: 0x00017B19
		// (set) Token: 0x060019A0 RID: 6560 RVA: 0x00019925 File Offset: 0x00017B25
		public ContentAlignment Alignment { get; set; }

		// Token: 0x1700097C RID: 2428
		// (get) Token: 0x060019A1 RID: 6561 RVA: 0x00019936 File Offset: 0x00017B36
		// (set) Token: 0x060019A2 RID: 6562 RVA: 0x00019942 File Offset: 0x00017B42
		public Color Color { get; set; }

		// Token: 0x1700097D RID: 2429
		// (get) Token: 0x060019A3 RID: 6563 RVA: 0x00019953 File Offset: 0x00017B53
		// (set) Token: 0x060019A4 RID: 6564 RVA: 0x0001995F File Offset: 0x00017B5F
		public Point3D PointPosition { get; set; }

		// Token: 0x1700097E RID: 2430
		// (get) Token: 0x060019A5 RID: 6565 RVA: 0x00019970 File Offset: 0x00017B70
		// (set) Token: 0x060019A6 RID: 6566 RVA: 0x0001997C File Offset: 0x00017B7C
		public bool IsLeft { get; set; }

		// Token: 0x1700097F RID: 2431
		// (get) Token: 0x060019A7 RID: 6567 RVA: 0x0001998D File Offset: 0x00017B8D
		// (set) Token: 0x060019A8 RID: 6568 RVA: 0x00019999 File Offset: 0x00017B99
		public Point3D BoundingBoxIntersection { get; set; }

		// Token: 0x040009C8 RID: 2504
		[CompilerGenerated]
		private string #a;

		// Token: 0x040009C9 RID: 2505
		[CompilerGenerated]
		private Point3D #b;

		// Token: 0x040009CA RID: 2506
		[CompilerGenerated]
		private float #c;

		// Token: 0x040009CB RID: 2507
		[CompilerGenerated]
		private ContentAlignment #d;

		// Token: 0x040009CC RID: 2508
		[CompilerGenerated]
		private Color #e;

		// Token: 0x040009CD RID: 2509
		[CompilerGenerated]
		private Point3D #f;

		// Token: 0x040009CE RID: 2510
		[CompilerGenerated]
		private bool #g;

		// Token: 0x040009CF RID: 2511
		[CompilerGenerated]
		private Point3D #h;
	}
}
