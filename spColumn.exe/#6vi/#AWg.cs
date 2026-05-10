using System;

namespace #6vi
{
	// Token: 0x020007A8 RID: 1960
	internal static class #AWg
	{
		// Token: 0x06003EE8 RID: 16104 RVA: 0x000357DF File Offset: 0x000339DF
		public static bool #vWg(this double #f, double #wWg, double #cmc)
		{
			return Math.Abs(#f - #wWg) < #cmc;
		}

		// Token: 0x06003EE9 RID: 16105 RVA: 0x000357EC File Offset: 0x000339EC
		public static bool #vWg(this double #f, double #wWg, int #JBe)
		{
			return #f.#vWg(#wWg, Math.Pow(1.0, (double)(-(double)#JBe)));
		}

		// Token: 0x06003EEA RID: 16106 RVA: 0x00035806 File Offset: 0x00033A06
		public static bool #xWg(this double #f, double #cmc)
		{
			return Math.Abs(#f) < #cmc;
		}

		// Token: 0x06003EEB RID: 16107 RVA: 0x00035811 File Offset: 0x00033A11
		public static bool #xWg(this double #f, int #JBe)
		{
			return #f.#vWg(0.0, Math.Pow(1.0, (double)(-(double)#JBe)));
		}

		// Token: 0x04001CA8 RID: 7336
		public const double #a = 1E-10;
	}
}
