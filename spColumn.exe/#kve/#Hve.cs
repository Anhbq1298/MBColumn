using System;
using #FCd;
using #VEd;

namespace #kve
{
	// Token: 0x0200118A RID: 4490
	internal sealed class #Hve : #qFd
	{
		// Token: 0x06009834 RID: 38964 RVA: 0x00078D50 File Offset: 0x00076F50
		public #Hve(#4Ed #ib, double #Cvb) : base(#ib)
		{
			this.#a = #ib;
			this.#b = #Cvb;
		}

		// Token: 0x06009835 RID: 38965 RVA: 0x00078D67 File Offset: 0x00076F67
		public override #5Dd #ul(int #Jhd, params double[] #Zpb)
		{
			return new #Gve(this.#a, this.#b, #Jhd, #Zpb);
		}

		// Token: 0x0400417B RID: 16763
		private readonly #4Ed #a;

		// Token: 0x0400417C RID: 16764
		private readonly double #b;
	}
}
