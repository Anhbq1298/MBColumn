using System;
using System.Runtime.CompilerServices;
using #P6e;

namespace #qJ
{
	// Token: 0x0200029B RID: 667
	internal sealed class #EJ : #Q6e
	{
		// Token: 0x060015CD RID: 5581 RVA: 0x00016D00 File Offset: 0x00014F00
		public #EJ(bool #FJ, bool #GJ, bool #HJ, bool #IJ, float #1Ti = 1f)
		{
			this.#a = #FJ;
			this.#b = #GJ;
			this.#c = #HJ;
			this.#d = #IJ;
			this.DiagramInterpolationConvergenceEpsilonPercentage = #1Ti;
		}

		// Token: 0x170007B6 RID: 1974
		// (get) Token: 0x060015CE RID: 5582 RVA: 0x00016D2D File Offset: 0x00014F2D
		// (set) Token: 0x060015CF RID: 5583 RVA: 0x00016D39 File Offset: 0x00014F39
		public float DiagramInterpolationConvergenceEpsilonPercentage { get; set; }

		// Token: 0x060015D0 RID: 5584 RVA: 0x00016D4A File Offset: 0x00014F4A
		public bool #hp()
		{
			return this.#a;
		}

		// Token: 0x060015D1 RID: 5585 RVA: 0x00016D56 File Offset: 0x00014F56
		public bool #ip()
		{
			return this.#b;
		}

		// Token: 0x060015D2 RID: 5586 RVA: 0x00016D62 File Offset: 0x00014F62
		public bool #jp()
		{
			return this.#c;
		}

		// Token: 0x060015D3 RID: 5587 RVA: 0x00016D6E File Offset: 0x00014F6E
		public bool #kp()
		{
			return this.#d;
		}

		// Token: 0x040008B7 RID: 2231
		private readonly bool #a;

		// Token: 0x040008B8 RID: 2232
		private readonly bool #b;

		// Token: 0x040008B9 RID: 2233
		private readonly bool #c;

		// Token: 0x040008BA RID: 2234
		private readonly bool #d;

		// Token: 0x040008BB RID: 2235
		[CompilerGenerated]
		private float #e;
	}
}
