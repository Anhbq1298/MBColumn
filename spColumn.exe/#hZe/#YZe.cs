using System;
using System.Runtime.CompilerServices;

namespace #hZe
{
	// Token: 0x02001325 RID: 4901
	internal sealed class #YZe
	{
		// Token: 0x0600A3A6 RID: 41894 RVA: 0x000035C3 File Offset: 0x000017C3
		public #YZe()
		{
		}

		// Token: 0x0600A3A7 RID: 41895 RVA: 0x0007FD6C File Offset: 0x0007DF6C
		public #YZe(float #yMe, float #Tdb, float #CWe)
		{
			this.DepthOfNeutralAxis = #yMe;
			this.AxialLoad = #Tdb;
			this.AbsoluteMomentMagnitude = #CWe;
		}

		// Token: 0x17002EED RID: 12013
		// (get) Token: 0x0600A3A8 RID: 41896 RVA: 0x0007FD89 File Offset: 0x0007DF89
		// (set) Token: 0x0600A3A9 RID: 41897 RVA: 0x0007FD91 File Offset: 0x0007DF91
		public float DepthOfNeutralAxis { get; set; }

		// Token: 0x17002EEE RID: 12014
		// (get) Token: 0x0600A3AA RID: 41898 RVA: 0x0007FD9A File Offset: 0x0007DF9A
		// (set) Token: 0x0600A3AB RID: 41899 RVA: 0x0007FDA2 File Offset: 0x0007DFA2
		public float AxialLoad { get; set; }

		// Token: 0x17002EEF RID: 12015
		// (get) Token: 0x0600A3AC RID: 41900 RVA: 0x0007FDAB File Offset: 0x0007DFAB
		// (set) Token: 0x0600A3AD RID: 41901 RVA: 0x0007FDB3 File Offset: 0x0007DFB3
		public float AbsoluteMomentMagnitude { get; set; }

		// Token: 0x0600A3AE RID: 41902 RVA: 0x0007FDBC File Offset: 0x0007DFBC
		public void #Yfd(#YZe #L0)
		{
			this.DepthOfNeutralAxis = #L0.DepthOfNeutralAxis;
			this.AxialLoad = #L0.AxialLoad;
			this.AbsoluteMomentMagnitude = #L0.AbsoluteMomentMagnitude;
		}

		// Token: 0x040047B6 RID: 18358
		[CompilerGenerated]
		private float #a;

		// Token: 0x040047B7 RID: 18359
		[CompilerGenerated]
		private float #b;

		// Token: 0x040047B8 RID: 18360
		[CompilerGenerated]
		private float #c;
	}
}
