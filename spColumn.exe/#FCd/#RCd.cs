using System;
using #5Fd;
using #7hc;

namespace #FCd
{
	// Token: 0x02000D5D RID: 3421
	internal sealed class #RCd : #6Dd
	{
		// Token: 0x06007C4D RID: 31821 RVA: 0x00064EFA File Offset: 0x000630FA
		public #RCd(#7Fd #QCd)
		{
			if (#QCd == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107251213));
			}
			this.#a = #QCd;
		}

		// Token: 0x06007C4E RID: 31822 RVA: 0x00064F1C File Offset: 0x0006311C
		public #5Dd #ul(int #Jhd, params double[] #Zpb)
		{
			return new #PCd(this.#a, #Jhd, #Zpb);
		}

		// Token: 0x040032F2 RID: 13042
		private readonly #7Fd #a;
	}
}
