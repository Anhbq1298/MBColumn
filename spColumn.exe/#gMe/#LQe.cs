using System;
using #hZe;
using #X7e;
using #y6e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #gMe
{
	// Token: 0x020012BC RID: 4796
	internal static class #LQe
	{
		// Token: 0x0600A0A5 RID: 41125 RVA: 0x002236B0 File Offset: 0x002218B0
		public static float #kQe(int #6gb, int #Bkb, bool #lQe, float[] #LF, float[] #RC)
		{
			int num = (#Bkb == 0) ? 1 : -1;
			int num2 = 2 * #6gb + ((#Bkb == 0) ? 0 : 1);
			if (#lQe)
			{
				return (float)num * (#LF[2] * #RC[11 + num2] + #LF[3] * #RC[16 + num2]);
			}
			return (float)num * (#LF[0] * #RC[1 + num2] + #LF[1] * #RC[6 + num2] + #LF[4] * #RC[21 + num2]);
		}

		// Token: 0x0600A0A6 RID: 41126 RVA: 0x00223714 File Offset: 0x00221914
		public static void #mQe(int #nQe, #Lce[] #Zpe, #38e #jMe)
		{
			for (int i = 0; i <= 1; i++)
			{
				bool flag = (#Zpe[0].EndFlags[#nQe][i] & 16384) == 16384;
				bool flag2 = (#Zpe[1].EndFlags[#nQe][i] & 16384) == 16384;
				if (flag && flag2)
				{
					#LQe.#oQe(#nQe, #Zpe, 0, i, #jMe);
					#LQe.#oQe(#nQe, #Zpe, 1, i, #jMe);
				}
			}
		}

		// Token: 0x0600A0A7 RID: 41127 RVA: 0x00223778 File Offset: 0x00221978
		private static void #oQe(int #nQe, #Lce[] #Zpe, int #pQe, int #qQe, #38e #jMe)
		{
			#Zpe[#pQe].EndFlags[#nQe][#qQe] |= 32768;
			float #ORe = #Zpe[#pQe].Mu[#nQe][#qQe];
			float num = #Zpe[#pQe].Mi[#nQe][#qQe];
			float num2 = #Zpe[#pQe].DeltaB[#nQe] * num;
			#Zpe[#pQe].Mc0[#nQe][#qQe] = num2;
			float num3 = #URe.#JPe(#ORe, num2);
			#Zpe[#pQe].Du0[#nQe][#qQe] = num3;
			#Zpe[#pQe].EndFlags[#nQe][#qQe] |= #jMe.#A7e(num3);
		}

		// Token: 0x0600A0A8 RID: 41128 RVA: 0x00223804 File Offset: 0x00221A04
		public static int #rQe(float #ivb, float #sQe, float #tQe, bool #uQe, float #vQe, InputModel #hMe, RuntimeModel #iMe, #38e #jMe, float #wQe)
		{
			if (#ivb <= 0f)
			{
				return 0;
			}
			float #TRe = #jMe.#QRe(#ivb, #sQe, #tQe, #wQe);
			float num = #jMe.#h8e(#ivb, #iMe.GeometryProperties.Ag, #uQe, #TRe, #hMe);
			if (#vQe > 100f)
			{
				return 32;
			}
			if (#vQe > num)
			{
				return 1;
			}
			return 0;
		}

		// Token: 0x0600A0A9 RID: 41129 RVA: 0x0007E19A File Offset: 0x0007C39A
		public static #L6e #cQe(bool #uQe, float[] #xQe, float #yQe, #38e #jMe)
		{
			if (!#jMe.#y7e(#uQe, #xQe))
			{
				return #L6e.#a;
			}
			if (#yQe > 2.5f || #yQe < 0f)
			{
				return #L6e.#i;
			}
			return #L6e.#a;
		}

		// Token: 0x0600A0AA RID: 41130 RVA: 0x0007E1C4 File Offset: 0x0007C3C4
		public static float #zQe(#D6e #6jb, float #AQe)
		{
			if (#6jb != #D6e.#b)
			{
				return (0.6f + 0.03f * #AQe) / 12f;
			}
			return (15f + 0.03f * #AQe) / 1000f;
		}

		// Token: 0x0600A0AB RID: 41131 RVA: 0x00223858 File Offset: 0x00221A58
		public static bool #fQe(float #Tdb, float #BQe, float #CQe, bool #uQe, float #DQe, float #EQe, float #FQe)
		{
			if (#Tdb >= #BQe * #CQe)
			{
				return false;
			}
			bool flag = #DQe * #Tdb >= #BQe * #EQe * #FQe;
			return #uQe || !flag;
		}

		// Token: 0x0600A0AC RID: 41132 RVA: 0x0022388C File Offset: 0x00221A8C
		public static float #GQe(float #HQe, bool #IQe, float #oNe, #K1e #JQe, InputModel #Od)
		{
			float num = #LQe.#KQe(#IQe, #oNe, #JQe);
			float num2 = (#Od.Options.Unit == #D6e.#b) ? 1000f : 1f;
			return (0.2f * #Od.MaterialProperties.Ec * #HQe + #Od.MaterialProperties.Es * num) / num2;
		}

		// Token: 0x0600A0AD RID: 41133 RVA: 0x002238E4 File Offset: 0x00221AE4
		private static float #KQe(bool #IQe, float #oNe, #K1e #JQe)
		{
			float num = 0f;
			ReinforcementBar[] array = #JQe.Bars;
			for (int i = 0; i < #JQe.NumberOfBars; i++)
			{
				ReinforcementBar reinforcementBar = array[i];
				float num2 = #IQe ? reinforcementBar.Y : reinforcementBar.X;
				float num3 = reinforcementBar.Area;
				float num4 = num2 - #oNe;
				num += num3 * num4 * num4;
			}
			return num;
		}
	}
}
