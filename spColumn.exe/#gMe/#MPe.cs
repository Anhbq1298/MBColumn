using System;
using #wUe;
using #z5e;

namespace #gMe
{
	// Token: 0x020012B8 RID: 4792
	internal static class #MPe
	{
		// Token: 0x0600A06B RID: 41067 RVA: 0x0007DE8A File Offset: 0x0007C08A
		public static float #HPe(float #6Q, float #5Q, float #IPe)
		{
			if (#xke.#U3(#6Q) && #xke.#U3(#5Q))
			{
				return #IPe;
			}
			return #MPe.#LPe(#6Q, #5Q);
		}

		// Token: 0x0600A06C RID: 41068 RVA: 0x0007DEA5 File Offset: 0x0007C0A5
		public static float #JPe(#X3 #Nwb, float #KPe)
		{
			return (#Nwb.IsBraced ? #Nwb.Kbraced : #Nwb.Ksway) * #Nwb.Height / #KPe;
		}

		// Token: 0x0600A06D RID: 41069 RVA: 0x0007DEC6 File Offset: 0x0007C0C6
		public static float #LPe(float #6Q, float #5Q)
		{
			if (#xke.#dke(#5Q))
			{
				return #6Q * #5Q * #5Q * #5Q / 12f;
			}
			return 0.049087387f * #6Q * #6Q * #6Q * #6Q;
		}
	}
}
