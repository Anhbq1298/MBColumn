using System;

namespace #6vi
{
	// Token: 0x020007A7 RID: 1959
	internal static class #yWg
	{
		// Token: 0x06003EE4 RID: 16100 RVA: 0x0003578D File Offset: 0x0003398D
		public static bool #vWg(this float #f, float #wWg, float #cmc)
		{
			return Math.Abs(#f - #wWg) < #cmc;
		}

		// Token: 0x06003EE5 RID: 16101 RVA: 0x0003579A File Offset: 0x0003399A
		public static bool #vWg(this float #f, float #wWg, int #JBe)
		{
			return #f.#vWg(#wWg, (float)Math.Pow(1.0, (double)(-(double)#JBe)));
		}

		// Token: 0x06003EE6 RID: 16102 RVA: 0x000357B5 File Offset: 0x000339B5
		public static bool #xWg(this float #f, float #cmc)
		{
			return Math.Abs(#f) < #cmc;
		}

		// Token: 0x06003EE7 RID: 16103 RVA: 0x000357C0 File Offset: 0x000339C0
		public static bool #xWg(this float #f, int #JBe)
		{
			return #f.#vWg(0f, (float)Math.Pow(1.0, (double)(-(double)#JBe)));
		}

		// Token: 0x04001CA7 RID: 7335
		public const float #a = 1E-10f;
	}
}
