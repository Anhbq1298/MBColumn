using System;
using #wUe;

namespace #gMe
{
	// Token: 0x020012C7 RID: 4807
	internal static class #URe
	{
		// Token: 0x0600A0E7 RID: 41191 RVA: 0x0007E3DD File Offset: 0x0007C5DD
		public static float #JPe(float #ORe, float #PRe)
		{
			if (#xke.#hke(#ORe) > 0.0001f)
			{
				return #PRe / #ORe;
			}
			if (#xke.#hke(#PRe) > 0.0001f)
			{
				return #xke.#vke(#PRe) * 9999.999f;
			}
			return 1f;
		}

		// Token: 0x0600A0E8 RID: 41192 RVA: 0x0007E40F File Offset: 0x0007C60F
		public static float #QRe(float #sQe, float #tQe)
		{
			return #URe.#SRe(#URe.#RRe(#sQe, #tQe));
		}

		// Token: 0x0600A0E9 RID: 41193 RVA: 0x0007E41D File Offset: 0x0007C61D
		private static float #RRe(float #ZW, float #0W)
		{
			if (#xke.#U3(#ZW) && #xke.#U3(#0W))
			{
				return 1f;
			}
			if (#xke.#U3(#ZW) || #xke.#U3(#0W))
			{
				return 0f;
			}
			return #ZW / #0W;
		}

		// Token: 0x0600A0EA RID: 41194 RVA: 0x0007E44E File Offset: 0x0007C64E
		private static float #SRe(float #TRe)
		{
			if (#xke.#hke(#TRe) > 1f)
			{
				#TRe = 1f / #TRe;
			}
			if (#TRe < -0.5f)
			{
				return -0.5f;
			}
			return #TRe;
		}

		// Token: 0x04004665 RID: 18021
		private const float #a = 9999.999f;
	}
}
