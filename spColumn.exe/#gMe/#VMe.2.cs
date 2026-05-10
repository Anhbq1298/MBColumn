using System;
using #hZe;
using #y6e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #gMe
{
	// Token: 0x02001299 RID: 4761
	internal sealed class #VMe
	{
		// Token: 0x06009F82 RID: 40834 RVA: 0x0007D60B File Offset: 0x0007B80B
		public #VMe(#3Qe #WMe, CriticalCapacity #XMe)
		{
			this.#a = #WMe;
			this.#b = #XMe;
		}

		// Token: 0x06009F83 RID: 40835 RVA: 0x0007D621 File Offset: 0x0007B821
		public #y0e #YJe(#x6e #TMe)
		{
			if (#TMe == #x6e.#b)
			{
				return this.#b.#YJe();
			}
			return null;
		}

		// Token: 0x06009F84 RID: 40836 RVA: 0x0007D634 File Offset: 0x0007B834
		public UniCurve[] #MWi(#y0e #Jte, double #0jb, double #1jb)
		{
			return this.#b.#MWi(#Jte, #0jb, #1jb);
		}

		// Token: 0x06009F85 RID: 40837 RVA: 0x0021DD60 File Offset: 0x0021BF60
		public #S0e #bpb(#y0e #UMe, #x6e #TMe, LoadsExt #ivb, float #Tje, float #yMe, float #zMe)
		{
			#S0e #S0e = this.#a.#WQe(#ivb, #Tje, #yMe, #zMe, false);
			if (#TMe == #x6e.#a)
			{
				return #S0e;
			}
			CapacityRatioCalculation capacityRatioCalculation = this.#b.#KNe(#UMe, (double)#ivb.MomentX, (double)#ivb.MomentY, (double)#ivb.AxialLoad);
			#S0e #S0e2 = new #S0e(0f, 0f, 0f, 0f, capacityRatioCalculation.PhiMnx.GetValueOrDefault(), capacityRatioCalculation.PhiMny.GetValueOrDefault(), !capacityRatioCalculation.IsExceeded, 0f, 0f, 0f, (float)capacityRatioCalculation.NumericValue.GetValueOrDefault());
			LoadsExt loadsExt = #ivb.#EA();
			loadsExt.AxialLoad = capacityRatioCalculation.PhiPn.GetValueOrDefault();
			loadsExt.MomentX = capacityRatioCalculation.PhiMnx.GetValueOrDefault();
			loadsExt.MomentY = capacityRatioCalculation.PhiMny.GetValueOrDefault();
			#S0e = this.#a.#WQe(loadsExt, #Tje, #yMe, #zMe, true);
			#S0e2.BarMaximumStrain = #S0e.BarMaximumStrain;
			#S0e2.NeutralAxisDepth = #S0e.NeutralAxisDepth;
			#S0e2.PhiPn = capacityRatioCalculation.PhiPn.GetValueOrDefault();
			#S0e2.PhiMn = capacityRatioCalculation.PhiMn.GetValueOrDefault();
			return #S0e2;
		}

		// Token: 0x040045A3 RID: 17827
		private readonly #3Qe #a;

		// Token: 0x040045A4 RID: 17828
		private readonly CriticalCapacity #b;
	}
}
