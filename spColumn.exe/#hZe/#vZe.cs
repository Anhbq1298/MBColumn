using System;
using System.Runtime.CompilerServices;

namespace #hZe
{
	// Token: 0x02001320 RID: 4896
	internal sealed class #vZe
	{
		// Token: 0x0600A377 RID: 41847 RVA: 0x000035C3 File Offset: 0x000017C3
		public #vZe()
		{
		}

		// Token: 0x0600A378 RID: 41848 RVA: 0x0007FB15 File Offset: 0x0007DD15
		public #vZe(float #wZe, float #xZe)
		{
			this.Maximum = #wZe;
			this.Minimum = #xZe;
		}

		// Token: 0x17002ED7 RID: 11991
		// (get) Token: 0x0600A379 RID: 41849 RVA: 0x0007FB2B File Offset: 0x0007DD2B
		// (set) Token: 0x0600A37A RID: 41850 RVA: 0x0007FB33 File Offset: 0x0007DD33
		public float Maximum { get; private set; }

		// Token: 0x17002ED8 RID: 11992
		// (get) Token: 0x0600A37B RID: 41851 RVA: 0x0007FB3C File Offset: 0x0007DD3C
		// (set) Token: 0x0600A37C RID: 41852 RVA: 0x0007FB44 File Offset: 0x0007DD44
		public float Minimum { get; private set; }

		// Token: 0x0600A37D RID: 41853 RVA: 0x0007FB4D File Offset: 0x0007DD4D
		public void #tZe(#vZe #uZe)
		{
			this.Maximum = #uZe.Maximum;
			this.Minimum = #uZe.Minimum;
		}

		// Token: 0x040047A1 RID: 18337
		[CompilerGenerated]
		private float #a;

		// Token: 0x040047A2 RID: 18338
		[CompilerGenerated]
		private float #b;
	}
}
