using System;
using System.Runtime.CompilerServices;
using #2be;

namespace #ede
{
	// Token: 0x02001047 RID: 4167
	internal sealed class #ode
	{
		// Token: 0x17002972 RID: 10610
		// (get) Token: 0x06008EB0 RID: 36528 RVA: 0x00073963 File Offset: 0x00071B63
		// (set) Token: 0x06008EB1 RID: 36529 RVA: 0x0007396B File Offset: 0x00071B6B
		public #6ce DesignDimension { get; set; }

		// Token: 0x17002973 RID: 10611
		// (get) Token: 0x06008EB2 RID: 36530 RVA: 0x00073974 File Offset: 0x00071B74
		// (set) Token: 0x06008EB3 RID: 36531 RVA: 0x0007397C File Offset: 0x00071B7C
		public #6ce InvestigationDimensions { get; set; }

		// Token: 0x17002974 RID: 10612
		// (get) Token: 0x06008EB4 RID: 36532 RVA: 0x00073985 File Offset: 0x00071B85
		// (set) Token: 0x06008EB5 RID: 36533 RVA: 0x0007398D File Offset: 0x00071B8D
		public #6ce ModelCoordinate { get; set; }

		// Token: 0x17002975 RID: 10613
		// (get) Token: 0x06008EB6 RID: 36534 RVA: 0x00073996 File Offset: 0x00071B96
		public int MaximalBarsCount
		{
			get
			{
				return #dde.Instance.TotalBars;
			}
		}

		// Token: 0x17002976 RID: 10614
		// (get) Token: 0x06008EB7 RID: 36535 RVA: 0x000739A2 File Offset: 0x00071BA2
		// (set) Token: 0x06008EB8 RID: 36536 RVA: 0x000739AA File Offset: 0x00071BAA
		public #9ce SectionPolygonPointsNumber { get; set; }

		// Token: 0x17002977 RID: 10615
		// (get) Token: 0x06008EB9 RID: 36537 RVA: 0x000739B3 File Offset: 0x00071BB3
		// (set) Token: 0x06008EBA RID: 36538 RVA: 0x000739BB File Offset: 0x00071BBB
		public #6ce TotalSectionDimension { get; set; }

		// Token: 0x04003BCB RID: 15307
		[CompilerGenerated]
		private #6ce #a;

		// Token: 0x04003BCC RID: 15308
		[CompilerGenerated]
		private #6ce #b;

		// Token: 0x04003BCD RID: 15309
		[CompilerGenerated]
		private #6ce #c;

		// Token: 0x04003BCE RID: 15310
		[CompilerGenerated]
		private #9ce #d;

		// Token: 0x04003BCF RID: 15311
		[CompilerGenerated]
		private #6ce #e;
	}
}
