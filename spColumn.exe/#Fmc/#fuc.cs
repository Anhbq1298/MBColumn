using System;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace #Fmc
{
	// Token: 0x020007FB RID: 2043
	internal sealed class #fuc
	{
		// Token: 0x060041A9 RID: 16809 RVA: 0x000371C0 File Offset: 0x000353C0
		public #fuc(SegmentData #PP, Point #Ng, #iuc #uqc)
		{
			this.Segment = #PP;
			this.Point = #Ng;
			this.SnapToEdgeOrigin = #uqc;
		}

		// Token: 0x060041AA RID: 16810 RVA: 0x000371DD File Offset: 0x000353DD
		public #fuc(SegmentData #PP, Point #Ng, #iuc #uqc, string #guc) : this(#PP, #Ng, #uqc)
		{
			this.SnapToEdgeOriginInfo = #guc;
		}

		// Token: 0x1700136E RID: 4974
		// (get) Token: 0x060041AB RID: 16811 RVA: 0x000371F0 File Offset: 0x000353F0
		// (set) Token: 0x060041AC RID: 16812 RVA: 0x000371FC File Offset: 0x000353FC
		public SegmentData Segment { get; private set; }

		// Token: 0x1700136F RID: 4975
		// (get) Token: 0x060041AD RID: 16813 RVA: 0x0003720D File Offset: 0x0003540D
		// (set) Token: 0x060041AE RID: 16814 RVA: 0x00037219 File Offset: 0x00035419
		public Point Point { get; private set; }

		// Token: 0x17001370 RID: 4976
		// (get) Token: 0x060041AF RID: 16815 RVA: 0x0003722A File Offset: 0x0003542A
		// (set) Token: 0x060041B0 RID: 16816 RVA: 0x00037236 File Offset: 0x00035436
		public #iuc SnapToEdgeOrigin { get; internal set; }

		// Token: 0x17001371 RID: 4977
		// (get) Token: 0x060041B1 RID: 16817 RVA: 0x00037247 File Offset: 0x00035447
		// (set) Token: 0x060041B2 RID: 16818 RVA: 0x00037253 File Offset: 0x00035453
		public string SnapToEdgeOriginInfo { get; private set; }

		// Token: 0x04001D82 RID: 7554
		[CompilerGenerated]
		private SegmentData #a;

		// Token: 0x04001D83 RID: 7555
		[CompilerGenerated]
		private Point #b;

		// Token: 0x04001D84 RID: 7556
		[CompilerGenerated]
		private #iuc #c;

		// Token: 0x04001D85 RID: 7557
		[CompilerGenerated]
		private string #d;
	}
}
