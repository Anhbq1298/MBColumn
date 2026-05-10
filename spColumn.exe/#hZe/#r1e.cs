using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace #hZe
{
	// Token: 0x02001333 RID: 4915
	[DebuggerDisplay("EpsT= {BarUltimateStrainEpsilon}, NaDepth={DepthOfNeutralAxisC}, Load={ColumnLoad}")]
	internal sealed class #r1e
	{
		// Token: 0x0600A437 RID: 42039 RVA: 0x000803FF File Offset: 0x0007E5FF
		public #r1e(float #cmc, float #uYb, #TZe #s1e)
		{
			this.BarUltimateStrainEpsilon = #cmc;
			this.DepthOfNeutralAxisC = #uYb;
			this.ColumnLoad = #s1e;
		}

		// Token: 0x17002F2B RID: 12075
		// (get) Token: 0x0600A438 RID: 42040 RVA: 0x0008041C File Offset: 0x0007E61C
		// (set) Token: 0x0600A439 RID: 42041 RVA: 0x00080424 File Offset: 0x0007E624
		public float BarUltimateStrainEpsilon { get; private set; }

		// Token: 0x17002F2C RID: 12076
		// (get) Token: 0x0600A43A RID: 42042 RVA: 0x0008042D File Offset: 0x0007E62D
		// (set) Token: 0x0600A43B RID: 42043 RVA: 0x00080435 File Offset: 0x0007E635
		public float DepthOfNeutralAxisC { get; private set; }

		// Token: 0x17002F2D RID: 12077
		// (get) Token: 0x0600A43C RID: 42044 RVA: 0x0008043E File Offset: 0x0007E63E
		// (set) Token: 0x0600A43D RID: 42045 RVA: 0x00080446 File Offset: 0x0007E646
		public #TZe ColumnLoad { get; private set; }

		// Token: 0x040047FA RID: 18426
		[CompilerGenerated]
		private float #a;

		// Token: 0x040047FB RID: 18427
		[CompilerGenerated]
		private float #b;

		// Token: 0x040047FC RID: 18428
		[CompilerGenerated]
		private #TZe #c;
	}
}
