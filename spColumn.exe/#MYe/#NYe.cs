using System;
using #7hc;
using #hZe;
using #xKe;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #MYe
{
	// Token: 0x02001315 RID: 4885
	internal sealed class #NYe : #2Ye
	{
		// Token: 0x0600A33B RID: 41787 RVA: 0x0007F90D File Offset: 0x0007DB0D
		public void #KYe(#fLe #Ipb, #y0e #Jte)
		{
			#NYe.#npb(#Ipb, #Jte);
		}

		// Token: 0x0600A33C RID: 41788 RVA: 0x0022DF18 File Offset: 0x0022C118
		private static void #npb(#fLe #Ipb, #y0e #Jte)
		{
			#Ipb.#npb(#NYe.#a);
			BiCurve[] array = #Jte.BiCurve;
			for (int i = 0; i < 70; i++)
			{
				for (int j = 0; j < 36; j++)
				{
					#Ipb.#npb(new float[]
					{
						array[i].AxialLoad,
						array[i].MomentX[j],
						array[i].MomentY[j],
						array[i].DepthOfNeutralAxisC[j],
						array[i].AngleOfNeutralAxisC[j],
						array[i].Dt[j],
						array[i].BarMaximumStrainEps[j]
					});
				}
			}
		}

		// Token: 0x0400477E RID: 18302
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
	}
}
