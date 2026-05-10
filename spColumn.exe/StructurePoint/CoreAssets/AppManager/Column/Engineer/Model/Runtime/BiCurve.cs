using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime
{
	// Token: 0x02001322 RID: 4898
	[DebuggerDisplay("P= {AxialLoad}")]
	public sealed class BiCurve
	{
		// Token: 0x0600A386 RID: 41862 RVA: 0x0022EB8C File Offset: 0x0022CD8C
		public BiCurve()
		{
			this.MomentX = new float[36];
			this.MomentY = new float[36];
			this.DepthOfNeutralAxisC = new float[36];
			this.AngleOfNeutralAxisC = new float[36];
			this.BarMaximumStrainEps = new float[36];
			this.PhiFactor = new float[36];
			this.Dt = new float[36];
		}

		// Token: 0x17002EDF RID: 11999
		// (get) Token: 0x0600A387 RID: 41863 RVA: 0x0007FC00 File Offset: 0x0007DE00
		// (set) Token: 0x0600A388 RID: 41864 RVA: 0x0007FC08 File Offset: 0x0007DE08
		public float AxialLoad { get; set; }

		// Token: 0x17002EE0 RID: 12000
		// (get) Token: 0x0600A389 RID: 41865 RVA: 0x0007FC11 File Offset: 0x0007DE11
		public float[] MomentX { get; }

		// Token: 0x17002EE1 RID: 12001
		// (get) Token: 0x0600A38A RID: 41866 RVA: 0x0007FC19 File Offset: 0x0007DE19
		public float[] MomentY { get; }

		// Token: 0x17002EE2 RID: 12002
		// (get) Token: 0x0600A38B RID: 41867 RVA: 0x0007FC21 File Offset: 0x0007DE21
		public float[] DepthOfNeutralAxisC { get; }

		// Token: 0x17002EE3 RID: 12003
		// (get) Token: 0x0600A38C RID: 41868 RVA: 0x0007FC29 File Offset: 0x0007DE29
		public float[] AngleOfNeutralAxisC { get; }

		// Token: 0x17002EE4 RID: 12004
		// (get) Token: 0x0600A38D RID: 41869 RVA: 0x0007FC31 File Offset: 0x0007DE31
		public float[] BarMaximumStrainEps { get; }

		// Token: 0x17002EE5 RID: 12005
		// (get) Token: 0x0600A38E RID: 41870 RVA: 0x0007FC39 File Offset: 0x0007DE39
		public float[] PhiFactor { get; }

		// Token: 0x17002EE6 RID: 12006
		// (get) Token: 0x0600A38F RID: 41871 RVA: 0x0007FC41 File Offset: 0x0007DE41
		public float[] Dt { get; }

		// Token: 0x040047A8 RID: 18344
		[CompilerGenerated]
		private float #a;

		// Token: 0x040047A9 RID: 18345
		[CompilerGenerated]
		private readonly float[] #b;

		// Token: 0x040047AA RID: 18346
		[CompilerGenerated]
		private readonly float[] #c;

		// Token: 0x040047AB RID: 18347
		[CompilerGenerated]
		private readonly float[] #d;

		// Token: 0x040047AC RID: 18348
		[CompilerGenerated]
		private readonly float[] #e;

		// Token: 0x040047AD RID: 18349
		[CompilerGenerated]
		private readonly float[] #f;

		// Token: 0x040047AE RID: 18350
		[CompilerGenerated]
		private readonly float[] #g;

		// Token: 0x040047AF RID: 18351
		[CompilerGenerated]
		private readonly float[] #h;
	}
}
