using System;
using #12e;
using #7hc;
using #hZe;
using #xKe;

namespace #MYe
{
	// Token: 0x02001319 RID: 4889
	internal sealed class #YYe : #2Ye
	{
		// Token: 0x0600A34D RID: 41805 RVA: 0x0007F960 File Offset: 0x0007DB60
		public #YYe(#l4e #Od)
		{
			this.#b = #Od;
		}

		// Token: 0x0600A34E RID: 41806 RVA: 0x0007F96F File Offset: 0x0007DB6F
		public void #KYe(#fLe #Ipb, #y0e #Jte)
		{
			#Ipb.#npb(#YYe.#a);
			#YYe.#WYe(#Ipb, #Jte);
			#YYe.#VYe(#Ipb, #Jte);
		}

		// Token: 0x0600A34F RID: 41807 RVA: 0x0022E73C File Offset: 0x0022C93C
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
						#Jte.UniCurve[i].NegativeSide.BarMaximumStrainEps
					});
				}
			}
		}

		// Token: 0x0600A350 RID: 41808 RVA: 0x0022E7DC File Offset: 0x0022C9DC
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
						#Jte.UniCurve[i].PositiveSide.BarMaximumStrainEps
					});
				}
			}
		}

		// Token: 0x04004785 RID: 18309
		private static readonly string[] #a = new string[]
		{
			#Phc.#3hc(107283372),
			#Phc.#3hc(107283000),
			#Phc.#3hc(107283437),
			#Phc.#3hc(107283452),
			#Phc.#3hc(107251998)
		};

		// Token: 0x04004786 RID: 18310
		private readonly #l4e #b;
	}
}
