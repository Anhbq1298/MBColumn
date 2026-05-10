using System;
using #hZe;
using #wUe;
using #X7e;
using #z5e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;

namespace #gMe
{
	// Token: 0x020012C4 RID: 4804
	internal static class #vRe
	{
		// Token: 0x0600A0D9 RID: 41177 RVA: 0x00223EF0 File Offset: 0x002220F0
		public static void #6Qe(int #7Qe, float #Tdb, float #8Qe, float #9Qe, float #aRe, float #bRe, float #cRe, int #nQe, #Lce #Zpe, float #IPe, #X3 #Nwb, InputModel #hMe, #38e #jMe)
		{
			float #mRe = 0f;
			float num = 1f;
			float num2 = 1f;
			float num3 = #xke.#hke(#cRe * #Tdb);
			float #pRe = 0f;
			int num4 = 0;
			float[] array = new float[]
			{
				#8Qe,
				#9Qe
			};
			float[] array2 = new float[]
			{
				#aRe,
				#bRe
			};
			float[] array3 = new float[]
			{
				#8Qe + #aRe,
				#9Qe + #bRe
			};
			float[] array4 = new float[]
			{
				array3[0],
				array3[1]
			};
			float[] array5 = new float[]
			{
				array4[0],
				array4[1]
			};
			float[] array6 = new float[]
			{
				1f,
				1f
			};
			int[] array7 = new int[2];
			bool flag = #xke.#dke(#7Qe) && #Tdb > 0f;
			bool flag2 = !#Nwb.IsBraced;
			if (flag)
			{
				if (!#Nwb.IsBraced)
				{
					num2 = #JRe.#wRe(#Tdb, #Zpe.Pcs[#nQe], #hMe.StiffnessReductionFactorPhi, #Nwb);
					for (int i = 0; i <= 1; i++)
					{
						array4[i] = array[i] + num2 * array2[i];
						array5[i] = array4[i];
					}
					flag2 = #jMe.#C7e(#Tdb, #IPe, #Nwb, #hMe, ref #pRe, ref num4);
					if (flag2)
					{
						num4 |= 1024;
					}
				}
				if (#Nwb.IsBraced || flag2)
				{
					#mRe = #JRe.#CRe(flag2 ? array4 : array3, #jMe, array4, num3);
					num = #JRe.#DRe(#Tdb, #Zpe.Pcb[#nQe], #mRe, #hMe.StiffnessReductionFactorPhi);
					num4 |= 2048;
					for (int j = 0; j <= 1; j++)
					{
						if (#vRe.#dRe(num4, array4, j, num3))
						{
							array5[j] = num * #xke.#vke(array4[j]) * num3;
							array7[j] |= 16384;
						}
						else
						{
							array5[j] = num * array4[j];
						}
					}
				}
				for (int k = 0; k <= 1; k++)
				{
					array6[k] = #vRe.#hRe(num4, array3[k], num3, array5[k]);
					array7[k] |= #jMe.#A7e(array6[k]);
				}
			}
			else
			{
				num4 = 4096;
			}
			#vRe.#lRe(#Tdb, #nQe, #Zpe, #mRe, num, num2, num3, #pRe, num4);
			#vRe.#qRe(#nQe, #Zpe, array6, array, array2, array3, array4, array5, array7, 0);
			#vRe.#qRe(#nQe, #Zpe, array6, array, array2, array3, array4, array5, array7, 1);
		}

		// Token: 0x0600A0DA RID: 41178 RVA: 0x0007E377 File Offset: 0x0007C577
		private static bool #dRe(int #ri, float[] #eRe, int #fRe, float #gRe)
		{
			return #xke.#dke(#ri & 2048) && #xke.#hke(#eRe[#fRe]) < #gRe;
		}

		// Token: 0x0600A0DB RID: 41179 RVA: 0x00224160 File Offset: 0x00222360
		private static float #hRe(int #ri, float #iRe, float #gRe, float #jRe)
		{
			return #URe.#JPe(#vRe.#kRe(#ri, #iRe, #gRe, #jRe), #jRe);
		}

		// Token: 0x0600A0DC RID: 41180 RVA: 0x0007E394 File Offset: 0x0007C594
		private static float #kRe(int #ri, float #iRe, float #gRe, float #jRe)
		{
			if (!#xke.#dke(#ri & 2048) || #xke.#hke(#iRe) >= #gRe)
			{
				return #iRe;
			}
			return #xke.#vke(#jRe) * #gRe;
		}

		// Token: 0x0600A0DD RID: 41181 RVA: 0x00224180 File Offset: 0x00222380
		private static void #lRe(float #JMe, int #nQe, #Lce #Zpe, float #mRe, float #nRe, float #oRe, float #gRe, float #pRe, int #ri)
		{
			#Zpe.FactorCm[#nQe] = #mRe;
			#Zpe.DeltaB[#nQe] = #nRe;
			#Zpe.DeltaS[#nQe] = #oRe;
			#Zpe.MinMoment[#nQe] = #gRe;
			#Zpe.UltimateAxialLoad[#nQe] = #JMe;
			#Zpe.Kplur[#nQe] = #pRe;
			#Zpe.Flags[#nQe] = #ri;
		}

		// Token: 0x0600A0DE RID: 41182 RVA: 0x002241D4 File Offset: 0x002223D4
		private static void #qRe(int #nQe, #Lce #Zpe, float[] #rRe, float[] #sRe, float[] #tRe, float[] #iRe, float[] #eRe, float[] #jRe, int[] #uRe, int #4jb)
		{
			#Zpe.Du[#nQe][#4jb] = #rRe[#4jb];
			#Zpe.UltimateMomentsBraced[#nQe][#4jb] = #sRe[#4jb];
			#Zpe.UltimateMomentsSway[#nQe][#4jb] = #tRe[#4jb];
			#Zpe.Mu[#nQe][#4jb] = #iRe[#4jb];
			#Zpe.Mi[#nQe][#4jb] = #eRe[#4jb];
			#Zpe.Mc[#nQe][#4jb] = #jRe[#4jb];
			#Zpe.EndFlags[#nQe][#4jb] = #uRe[#4jb];
			#Zpe.Du0[#nQe][#4jb] = 0f;
			#Zpe.Mc0[#nQe][#4jb] = 0f;
		}

		// Token: 0x04004661 RID: 18017
		public const int #a = 1024;

		// Token: 0x04004662 RID: 18018
		public const int #b = 2048;

		// Token: 0x04004663 RID: 18019
		public const int #c = 512;
	}
}
