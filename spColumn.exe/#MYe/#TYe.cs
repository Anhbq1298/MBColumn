using System;
using #12e;
using #7hc;
using #hZe;
using #X7e;
using #xKe;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #MYe
{
	// Token: 0x02001316 RID: 4886
	internal class #TYe : #2Ye
	{
		// Token: 0x0600A33F RID: 41791 RVA: 0x0007F916 File Offset: 0x0007DB16
		public #TYe(#l4e #Od, #38e #jMe)
		{
			this.#b = #Od;
			this.#c = #jMe;
		}

		// Token: 0x0600A340 RID: 41792 RVA: 0x0022E030 File Offset: 0x0022C230
		public void #KYe(#fLe #Ipb, #y0e #Jte)
		{
			BiCurve[] array = #Jte.BiCurve;
			if (0f > array[0].AxialLoad || 0f < array[69].AxialLoad)
			{
				return;
			}
			int #Ttb = #TYe.#SYe(#Jte, 0f);
			BiCurve #QYe = new BiCurve
			{
				AxialLoad = 0f
			};
			this.#npb(#Ipb, 0f, #Ttb, array, #QYe);
		}

		// Token: 0x0600A341 RID: 41793 RVA: 0x0022E090 File Offset: 0x0022C290
		protected virtual void #npb(#fLe #Ipb, float #OYe, int #Ttb, BiCurve[] #PYe, BiCurve #QYe)
		{
			#Ipb.#npb(#TYe.#a);
			for (int i = 0; i < 36; i++)
			{
				this.#RYe(#OYe, #Ttb, i, #PYe, #QYe);
				#Ipb.#npb(new float[]
				{
					#QYe.AxialLoad,
					#QYe.MomentX[i],
					#QYe.MomentY[i],
					#QYe.DepthOfNeutralAxisC[i],
					#QYe.AngleOfNeutralAxisC[i],
					#QYe.Dt[i],
					#QYe.BarMaximumStrainEps[i]
				});
			}
			#Ipb.#npb(new float[]
			{
				#QYe.AxialLoad,
				#QYe.MomentX[0],
				#QYe.MomentY[0],
				#QYe.DepthOfNeutralAxisC[0],
				#QYe.AngleOfNeutralAxisC[0],
				#QYe.Dt[0],
				#QYe.BarMaximumStrainEps[0]
			});
		}

		// Token: 0x0600A342 RID: 41794 RVA: 0x0022E180 File Offset: 0x0022C380
		protected void #RYe(float #OYe, int #Ttb, int #Cje, BiCurve[] #PYe, BiCurve #QYe)
		{
			float num = (#OYe - #PYe[#Ttb].AxialLoad) / (#PYe[#Ttb + 1].AxialLoad - #PYe[#Ttb].AxialLoad);
			#QYe.Dt[#Cje] = #PYe[#Ttb].Dt[#Cje] + (#PYe[#Ttb + 1].Dt[#Cje] - #PYe[#Ttb].Dt[#Cje]) * num;
			#QYe.MomentX[#Cje] = #PYe[#Ttb].MomentX[#Cje] + (#PYe[#Ttb + 1].MomentX[#Cje] - #PYe[#Ttb].MomentX[#Cje]) * num;
			#QYe.MomentY[#Cje] = #PYe[#Ttb].MomentY[#Cje] + (#PYe[#Ttb + 1].MomentY[#Cje] - #PYe[#Ttb].MomentY[#Cje]) * num;
			#QYe.DepthOfNeutralAxisC[#Cje] = #PYe[#Ttb].DepthOfNeutralAxisC[#Cje] + (#PYe[#Ttb + 1].DepthOfNeutralAxisC[#Cje] - #PYe[#Ttb].DepthOfNeutralAxisC[#Cje]) * num;
			#QYe.AngleOfNeutralAxisC[#Cje] = #PYe[#Ttb].AngleOfNeutralAxisC[#Cje] + (#PYe[#Ttb + 1].AngleOfNeutralAxisC[#Cje] - #PYe[#Ttb].AngleOfNeutralAxisC[#Cje]) * num;
			#QYe.BarMaximumStrainEps[#Cje] = #PYe[#Ttb].BarMaximumStrainEps[#Cje] + (#PYe[#Ttb + 1].BarMaximumStrainEps[#Cje] - #PYe[#Ttb].BarMaximumStrainEps[#Cje]) * num;
			#QYe.PhiFactor[#Cje] = this.#c.#dYe(#QYe.BarMaximumStrainEps[#Cje], this.#b.MaterialProperties.Eyt, this.#b.ReductionFactors.B, this.#b.ReductionFactors.C);
		}

		// Token: 0x0600A343 RID: 41795 RVA: 0x0022E31C File Offset: 0x0022C51C
		private static int #SYe(#y0e #Jte, float #OYe)
		{
			int num = 0;
			while (num < 69 && (#Jte.BiCurve[num].AxialLoad < #OYe || #Jte.BiCurve[num + 1].AxialLoad > #OYe))
			{
				num++;
			}
			if (num == 69)
			{
				num--;
			}
			return num;
		}

		// Token: 0x0400477F RID: 18303
		private static readonly string[] #a = new string[]
		{
			#Phc.#3hc(107283000),
			#Phc.#3hc(107282951),
			#Phc.#3hc(107282970),
			#Phc.#3hc(107283437),
			#Phc.#3hc(107283452),
			#Phc.#3hc(107283403),
			#Phc.#3hc(107251998)
		};

		// Token: 0x04004780 RID: 18304
		private readonly #l4e #b;

		// Token: 0x04004781 RID: 18305
		private readonly #38e #c;
	}
}
