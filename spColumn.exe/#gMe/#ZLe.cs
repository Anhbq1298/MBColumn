using System;
using #wUe;
using #X7e;
using #y6e;

namespace #gMe
{
	// Token: 0x020012D4 RID: 4820
	internal static class #ZLe
	{
		// Token: 0x0600A13F RID: 41279 RVA: 0x00226844 File Offset: 0x00224A44
		public static bool #qTe(bool #hW, float #rTe, #z6e #kce, float #sTe)
		{
			float num = (#kce == #z6e.#a) ? 1f : #sTe;
			return !#hW || Math.Abs((double)#rTe - -0.5) < 1E-07 || ((double)Math.Abs(#rTe - -1f) >= 1E-07 && #xke.#hke(#rTe) > num - 0.0001f);
		}

		// Token: 0x0600A140 RID: 41280 RVA: 0x002268AC File Offset: 0x00224AAC
		public static #L6e #tTe(#38e #jMe, float #uTe, float #vTe, float #wTe)
		{
			float num = #jMe.#r8e();
			if (#uTe < #xke.#ske(#vTe, num * #wTe))
			{
				return #L6e.#d;
			}
			return #L6e.#a;
		}
	}
}
