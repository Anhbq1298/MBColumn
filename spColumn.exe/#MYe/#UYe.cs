using System;
using #12e;
using #7hc;
using #X7e;
using #xKe;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #MYe
{
	// Token: 0x02001317 RID: 4887
	internal sealed class #UYe : #TYe
	{
		// Token: 0x0600A345 RID: 41797 RVA: 0x0007F92C File Offset: 0x0007DB2C
		public #UYe(#l4e #Od, #38e #jMe) : base(#Od, #jMe)
		{
		}

		// Token: 0x0600A346 RID: 41798 RVA: 0x0022E3D8 File Offset: 0x0022C5D8
		protected override void #npb(#fLe #Ipb, float #OYe, int #Ttb, BiCurve[] #PYe, BiCurve #QYe)
		{
			#Ipb.#npb(#UYe.#a);
			for (int i = 0; i < 36; i++)
			{
				base.#RYe(#OYe, #Ttb, i, #PYe, #QYe);
				#Ipb.#npb(new float[]
				{
					#QYe.AxialLoad,
					#QYe.MomentX[i],
					#QYe.MomentY[i],
					#QYe.DepthOfNeutralAxisC[i],
					#QYe.AngleOfNeutralAxisC[i],
					#QYe.Dt[i],
					#QYe.BarMaximumStrainEps[i],
					#QYe.PhiFactor[i]
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
				#QYe.BarMaximumStrainEps[0],
				#QYe.PhiFactor[0]
			});
		}

		// Token: 0x04004782 RID: 18306
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
