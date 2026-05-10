using System;
using #wUe;
using #X7e;
using #y6e;
using #z5e;

namespace #gMe
{
	// Token: 0x020012C5 RID: 4805
	internal static class #JRe
	{
		// Token: 0x0600A0DF RID: 41183 RVA: 0x00224270 File Offset: 0x00222470
		public static float #wRe(float #xRe, float #yRe, float #BQe, #X3 #Nwb)
		{
			if (#Nwb.IsBraced)
			{
				return 1f;
			}
			float num = 1f / (1f - #Nwb.SumPu * #xRe / (#BQe * #Nwb.SumPc * #yRe));
			if (num >= 1f)
			{
				return num;
			}
			return 1f;
		}

		// Token: 0x0600A0E0 RID: 41184 RVA: 0x002242BC File Offset: 0x002224BC
		public static float #zRe(float #ivb, float #3Q, float #cpb, bool #uQe, float #YW, #D6e #6jb)
		{
			if (#uQe || #ivb <= 0f)
			{
				return 0f;
			}
			float num = #3Q * #cpb;
			if (#xke.#dke(num))
			{
				return #YW * #xke.#eke(((#6jb == #D6e.#b) ? 1000f : 1f) * #ivb / num) * ((#6jb != #D6e.#b) ? 12f : 1000f);
			}
			return num;
		}

		// Token: 0x0600A0E1 RID: 41185 RVA: 0x0007E3BC File Offset: 0x0007C5BC
		public static bool #ARe(float #BRe)
		{
			return #BRe > 35f;
		}

		// Token: 0x0600A0E2 RID: 41186 RVA: 0x00224318 File Offset: 0x00222518
		public static float #CRe(float[] #uye, #38e #jMe, float[] #eRe, float #gRe)
		{
			float num = #JRe.#GRe(#uye[0], #uye[1]);
			float #mRe = 0.6f + 0.4f * num;
			return #jMe.#E7e(#mRe, #eRe, #gRe);
		}

		// Token: 0x0600A0E3 RID: 41187 RVA: 0x0022434C File Offset: 0x0022254C
		public static float #DRe(float #xRe, float #ERe, float #mRe, float #FRe)
		{
			float num = #mRe / (1f - #xRe / (#FRe * #ERe));
			if (num >= 1f)
			{
				return num;
			}
			return 1f;
		}

		// Token: 0x0600A0E4 RID: 41188 RVA: 0x00224378 File Offset: 0x00222578
		private static float #GRe(float #HRe, float #IRe)
		{
			float num;
			if (#xke.#U3(#HRe) && #xke.#U3(#IRe))
			{
				num = 1f;
			}
			else if (#xke.#U3(#HRe) || #xke.#U3(#IRe))
			{
				num = 0f;
			}
			else
			{
				num = #HRe / #IRe;
			}
			if (#xke.#hke(num) > 1f)
			{
				return 1f / num;
			}
			return num;
		}
	}
}
