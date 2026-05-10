using System;
using #7hc;
using #hZe;
using #xKe;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #MYe
{
	// Token: 0x02001313 RID: 4883
	internal sealed class #LYe : #2Ye
	{
		// Token: 0x0600A336 RID: 41782 RVA: 0x0007F904 File Offset: 0x0007DB04
		public void #KYe(#fLe #Ipb, #y0e #Jte)
		{
			#LYe.#npb(#Ipb, #Jte);
		}

		// Token: 0x0600A337 RID: 41783 RVA: 0x0022DDE4 File Offset: 0x0022BFE4
		private static void #npb(#fLe #Ipb, #y0e #Jte)
		{
			#Ipb.#npb(#LYe.#a);
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
						array[i].BarMaximumStrainEps[j],
						array[i].PhiFactor[j]
					});
				}
			}
		}

		// Token: 0x0400477D RID: 18301
		private static readonly string[] #a = new string[]
		{
			#Phc.#3hc(107283000),
			#Phc.#3hc(107282951),
			#Phc.#3hc(107282970),
			#Phc.#3hc(107283437),
			#Phc.#3hc(107283452),
			#Phc.#3hc(107283403),
			#Phc.#3hc(107252016),
			#Phc.#3hc(107283398)
		};
	}
}
