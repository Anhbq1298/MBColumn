using System;
using #12e;
using #hZe;
using #wUe;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;

namespace #IWe
{
	// Token: 0x020012FB RID: 4859
	internal sealed class #TWe
	{
		// Token: 0x0600A289 RID: 41609 RVA: 0x0007F21A File Offset: 0x0007D41A
		public #TWe(InputModel #hMe, RuntimeModel #iMe, #l4e #Kwe)
		{
			this.#a = #hMe;
			this.#c = #iMe;
			this.#b = #Kwe;
		}

		// Token: 0x17002EAB RID: 11947
		// (get) Token: 0x0600A28A RID: 41610 RVA: 0x0007F237 File Offset: 0x0007D437
		private int NumberOfLoadCombinations
		{
			get
			{
				return this.#a.Options.NumberOfLoadCombinations;
			}
		}

		// Token: 0x17002EAC RID: 11948
		// (get) Token: 0x0600A28B RID: 41611 RVA: 0x0007F249 File Offset: 0x0007D449
		private int NumberOfServiceLoads
		{
			get
			{
				return this.#a.Options.NumberOfServiceLoads;
			}
		}

		// Token: 0x0600A28C RID: 41612 RVA: 0x0022B720 File Offset: 0x00229920
		public bool #sWe(int #pQe)
		{
			bool flag = false;
			#Lce[][] #Zpe = this.#c.SlendernessFactors;
			for (int i = 0; i < this.NumberOfServiceLoads; i++)
			{
				for (int j = 0; j < this.NumberOfLoadCombinations; j++)
				{
					flag = this.#RWe(#pQe, #Zpe, i, j, flag);
				}
			}
			return flag;
		}

		// Token: 0x0600A28D RID: 41613 RVA: 0x0022B76C File Offset: 0x0022996C
		private static #TWe.#4hf #QWe(#Lce #jdd, int #Lpb)
		{
			int num = #jdd.Flags[#Lpb];
			if (#xke.#dke(num & 16))
			{
				return new #TWe.#4hf(NaNullableFloat.#FSd(), NaNullableFloat.#FSd(), MomentMagnificationFactor.#wif.#c);
			}
			if (#xke.#dke(num & 4096))
			{
				return new #TWe.#4hf(NaNullableFloat.#FSd(), NaNullableFloat.#FSd(), MomentMagnificationFactor.#wif.#d);
			}
			return new #TWe.#4hf(new NaNullableFloat(new float?(#jdd.FactorCm[#Lpb])), new NaNullableFloat(new float?(#jdd.DeltaB[#Lpb])), MomentMagnificationFactor.#wif.#a);
		}

		// Token: 0x0600A28E RID: 41614 RVA: 0x0022B7E8 File Offset: 0x002299E8
		private bool #RWe(int #pQe, #Lce[][] #Zpe, int #Kpb, int #Lpb, bool #SWe)
		{
			#Lce #Lce = #Zpe[#Kpb][#pQe];
			#TWe.#4hf #4hf = #TWe.#QWe(#Lce, #Lpb);
			int load = #Kpb + 1;
			int combination = #Lpb + 1;
			MomentMagnificationFactor #h4e = new MomentMagnificationFactor((MomentMagnificationFactor.Axis)#pQe, load, combination, #Lce.UltimateAxialLoad[#Lpb], new NaNullableFloat(new float?(#Lce.Pcb[#Lpb]), string.Empty), new NaNullableFloat(new float?(#Lce.Betadb[#Lpb]), string.Empty), #4hf.#a, #4hf.#b, #4hf.#c);
			this.#b.#vzc(#h4e);
			if (#xke.#dke(#Lce.Flags[#Lpb] & 16))
			{
				#SWe = true;
			}
			return #SWe;
		}

		// Token: 0x0400472C RID: 18220
		private readonly InputModel #a;

		// Token: 0x0400472D RID: 18221
		private readonly #l4e #b;

		// Token: 0x0400472E RID: 18222
		private readonly RuntimeModel #c;

		// Token: 0x020012FC RID: 4860
		private struct #4hf
		{
			// Token: 0x0600A28F RID: 41615 RVA: 0x0007F25B File Offset: 0x0007D45B
			public #4hf(NaNullableFloat #5hf, NaNullableFloat #6hf, MomentMagnificationFactor.#wif #ri)
			{
				this.#a = #5hf;
				this.#b = #6hf;
				this.#c = #ri;
			}

			// Token: 0x0400472F RID: 18223
			public readonly NaNullableFloat #a;

			// Token: 0x04004730 RID: 18224
			public readonly NaNullableFloat #b;

			// Token: 0x04004731 RID: 18225
			public readonly MomentMagnificationFactor.#wif #c;
		}
	}
}
