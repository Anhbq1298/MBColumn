using System;
using #wUe;
using #y6e;

namespace #gMe
{
	// Token: 0x020012C6 RID: 4806
	internal static class #NRe
	{
		// Token: 0x0600A0E5 RID: 41189 RVA: 0x002243D0 File Offset: 0x002225D0
		public static #L6e #KRe(int[] #LRe)
		{
			#L6e #L6e = #NRe.#MRe(#LRe[0]);
			#L6e #L6e2 = #NRe.#MRe(#LRe[1]);
			return #L6e | #L6e2;
		}

		// Token: 0x0600A0E6 RID: 41190 RVA: 0x0007E3C6 File Offset: 0x0007C5C6
		private static #L6e #MRe(int #FY)
		{
			if (#xke.#dke(#FY & 8192))
			{
				return #L6e.#h;
			}
			return #L6e.#a;
		}

		// Token: 0x04004664 RID: 18020
		public const int #a = 8192;
	}
}
