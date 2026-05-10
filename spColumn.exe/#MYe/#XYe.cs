using System;
using #12e;
using #7hc;
using #hZe;
using #xKe;

namespace #MYe
{
	// Token: 0x02001318 RID: 4888
	internal sealed class #XYe : #2Ye
	{
		// Token: 0x0600A348 RID: 41800 RVA: 0x0007F936 File Offset: 0x0007DB36
		public #XYe(#l4e #Od)
		{
			this.#b = #Od;
		}

		// Token: 0x0600A349 RID: 41801 RVA: 0x0007F945 File Offset: 0x0007DB45
		public void #KYe(#fLe #Ipb, #y0e #Jte)
		{
			#Ipb.#npb(#XYe.#a);
			#XYe.#WYe(#Ipb, #Jte);
			#XYe.#VYe(#Ipb, #Jte);
		}

		// Token: 0x0600A34A RID: 41802 RVA: 0x0022E564 File Offset: 0x0022C764
		private static void #VYe(#fLe #Ipb, #y0e #Jte)
		{
			for (int i = 0; i < 70; i++)
			{
				if (#Jte.UniCurve[i].PlotPoint)
				{
					#Ipb.#npb(new float[]
					{
						#Jte.UniCurve[i].NegativeSide.Moment,
						#Jte.UniCurve[i].AxialLoad,
						#Jte.UniCurve[i].NegativeSide.DepthOfNeutralAxisC,
						#Jte.UniCurve[i].NegativeSide.AngleOfNeutralAxisCAngle,
						#Jte.UniCurve[i].NegativeSide.BarMaximumStrainEps,
						#Jte.UniCurve[i].NegativeSide.ReductionFactorPhi
					});
				}
			}
		}

		// Token: 0x0600A34B RID: 41803 RVA: 0x0022E61C File Offset: 0x0022C81C
		private static void #WYe(#fLe #Ipb, #y0e #Jte)
		{
			for (int i = 0; i < 70; i++)
			{
				if (#Jte.UniCurve[i].PlotPoint)
				{
					#Ipb.#npb(new float[]
					{
						#Jte.UniCurve[i].PositiveSide.Moment,
						#Jte.UniCurve[i].AxialLoad,
						#Jte.UniCurve[i].PositiveSide.DepthOfNeutralAxisC,
						#Jte.UniCurve[i].PositiveSide.AngleOfNeutralAxisCAngle,
						#Jte.UniCurve[i].PositiveSide.BarMaximumStrainEps,
						#Jte.UniCurve[i].PositiveSide.ReductionFactorPhi
					});
				}
			}
		}

		// Token: 0x04004783 RID: 18307
		private static readonly string[] #a = new string[]
		{
			#Phc.#3hc(107283372),
			#Phc.#3hc(107283000),
			#Phc.#3hc(107283437),
			#Phc.#3hc(107283452),
			#Phc.#3hc(107252016),
			#Phc.#3hc(107283398)
		};

		// Token: 0x04004784 RID: 18308
		private readonly #l4e #b;
	}
}
