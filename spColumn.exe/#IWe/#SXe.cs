using System;
using #12e;
using #7hc;
using #hZe;
using #wUe;
using #X7e;
using #z5e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;

namespace #IWe
{
	// Token: 0x02001308 RID: 4872
	internal sealed class #SXe
	{
		// Token: 0x0600A2D1 RID: 41681 RVA: 0x0007F4A0 File Offset: 0x0007D6A0
		public #SXe(InputModel #hMe, RuntimeModel #iMe, #l4e #Kwe, #38e #jMe)
		{
			this.#a = #hMe;
			this.#c = #iMe;
			this.#b = #Kwe;
			this.#d = #jMe;
		}

		// Token: 0x17002EB4 RID: 11956
		// (get) Token: 0x0600A2D2 RID: 41682 RVA: 0x0007F4C5 File Offset: 0x0007D6C5
		private int NumberOfLoadCombinations
		{
			get
			{
				return this.#a.Options.NumberOfLoadCombinations;
			}
		}

		// Token: 0x17002EB5 RID: 11957
		// (get) Token: 0x0600A2D3 RID: 41683 RVA: 0x0007F4D7 File Offset: 0x0007D6D7
		private int NumberOfServiceLoads
		{
			get
			{
				return this.#a.Options.NumberOfServiceLoads;
			}
		}

		// Token: 0x0600A2D4 RID: 41684 RVA: 0x0022C7F0 File Offset: 0x0022A9F0
		public bool #sWe(int #pQe)
		{
			bool flag = false;
			#Lce[][] #Zpe = this.#c.SlendernessFactors;
			#X3 #OXe = this.#QXe(#pQe);
			for (int i = 0; i < this.NumberOfServiceLoads; i++)
			{
				for (int j = 0; j < this.NumberOfLoadCombinations; j++)
				{
					flag = this.#RWe(#pQe, #Zpe, i, j, flag, #OXe);
				}
			}
			return flag;
		}

		// Token: 0x0600A2D5 RID: 41685 RVA: 0x0022C848 File Offset: 0x0022AA48
		private bool #RWe(int #pQe, #Lce[][] #Zpe, int #Kpb, int #Lpb, bool #SWe, #X3 #OXe)
		{
			#Lce #Lce = #Zpe[#Kpb][#pQe];
			#SXe.#4hf #4hf = this.#PXe(#OXe, #Lce, #Lpb);
			float value = #OXe.SumPc * #Lce.Pcs[#Lpb];
			int load = #Kpb + 1;
			int combination = #Lpb + 1;
			float value2 = #OXe.SumPu * #Lce.UltimateAxialLoad[#Lpb];
			NaNullableFloat kluR = this.#RXe(#Lpb, #Lce);
			MomentMagnificationFactor #h4e = new MomentMagnificationFactor((MomentMagnificationFactor.Axis)#pQe, load, combination, new NaNullableFloat(new float?(value2)), new NaNullableFloat(new float?(#Lce.Pcs[#Lpb])), new NaNullableFloat(new float?(value)), new NaNullableFloat(new float?(#Lce.Betads[#Lpb])), #4hf.#e, #Lce.UltimateAxialLoad[#Lpb], kluR, #4hf.#a, #4hf.#b, #4hf.#c, #4hf.#d, #4hf.#f);
			this.#b.#vzc(#h4e);
			if (#xke.#dke(#Lce.Flags[#Lpb] & 16))
			{
				#SWe = true;
			}
			return #SWe;
		}

		// Token: 0x0600A2D6 RID: 41686 RVA: 0x0022C940 File Offset: 0x0022AB40
		private #SXe.#4hf #PXe(#X3 #OXe, #Lce #jdd, int #Lpb)
		{
			NaNullableFloat #ERe = NaNullableFloat.#FSd();
			NaNullableFloat #aif = NaNullableFloat.#FSd();
			NaNullableFloat #5hf = NaNullableFloat.#FSd();
			NaNullableFloat #6hf = NaNullableFloat.#FSd();
			NaNullableFloat #yQe = new NaNullableFloat(new float?(#jdd.DeltaS[#Lpb]));
			MomentMagnificationFactor.#wif #wif = MomentMagnificationFactor.#wif.#a;
			int num = #jdd.Flags[#Lpb];
			if (this.#d.#G7e(#OXe.CheckSwayAtEndsOnly, num))
			{
				#ERe = new NaNullableFloat(new float?(#jdd.Pcb[#Lpb]), #Phc.#3hc(107408811));
				#aif = new NaNullableFloat(new float?(#jdd.Betadb[#Lpb]), #Phc.#3hc(107383600));
				#5hf = new NaNullableFloat(new float?(#jdd.FactorCm[#Lpb]), #Phc.#3hc(107383600));
				#6hf = new NaNullableFloat(new float?(#jdd.DeltaB[#Lpb]), #Phc.#3hc(107383600));
			}
			if (#xke.#dke(num & 16))
			{
				#wif = MomentMagnificationFactor.#wif.#c;
				#5hf = NaNullableFloat.#FSd();
				#6hf = NaNullableFloat.#FSd();
				#yQe = NaNullableFloat.#FSd();
			}
			else if (#xke.#dke(num & 4096))
			{
				#wif = MomentMagnificationFactor.#wif.#d;
				#5hf = NaNullableFloat.#FSd();
				#6hf = NaNullableFloat.#FSd();
				#yQe = NaNullableFloat.#FSd();
			}
			else if (#xke.#dke(num & 256))
			{
				#wif = MomentMagnificationFactor.#wif.#e;
			}
			if (#xke.#dke(num & 512))
			{
				#wif |= MomentMagnificationFactor.#wif.#b;
			}
			return new #SXe.#4hf(#ERe, #aif, #5hf, #6hf, #yQe, #wif);
		}

		// Token: 0x0600A2D7 RID: 41687 RVA: 0x0007F4E9 File Offset: 0x0007D6E9
		private #X3 #QXe(int #pQe)
		{
			if (#pQe != 0)
			{
				return this.#a.DesignedColumnY;
			}
			return this.#a.DesignedColumnX;
		}

		// Token: 0x0600A2D8 RID: 41688 RVA: 0x0022CA90 File Offset: 0x0022AC90
		private NaNullableFloat #RXe(int #Lpb, #Lce #jdd)
		{
			bool #U7e = #xke.#U3(#jdd.Flags[#Lpb] & 4096);
			return this.#d.#T7e(#Lpb, #jdd, #U7e);
		}

		// Token: 0x04004759 RID: 18265
		private readonly InputModel #a;

		// Token: 0x0400475A RID: 18266
		private readonly #l4e #b;

		// Token: 0x0400475B RID: 18267
		private readonly RuntimeModel #c;

		// Token: 0x0400475C RID: 18268
		private readonly #38e #d;

		// Token: 0x02001309 RID: 4873
		private struct #4hf
		{
			// Token: 0x0600A2D9 RID: 41689 RVA: 0x0007F505 File Offset: 0x0007D705
			public #4hf(NaNullableFloat #ERe, NaNullableFloat #aif, NaNullableFloat #5hf, NaNullableFloat #6hf, NaNullableFloat #yQe, MomentMagnificationFactor.#wif #ri)
			{
				this.#a = #ERe;
				this.#b = #aif;
				this.#c = #5hf;
				this.#d = #6hf;
				this.#e = #yQe;
				this.#f = #ri;
			}

			// Token: 0x0400475D RID: 18269
			public readonly NaNullableFloat #a;

			// Token: 0x0400475E RID: 18270
			public readonly NaNullableFloat #b;

			// Token: 0x0400475F RID: 18271
			public readonly NaNullableFloat #c;

			// Token: 0x04004760 RID: 18272
			public readonly NaNullableFloat #d;

			// Token: 0x04004761 RID: 18273
			public readonly NaNullableFloat #e;

			// Token: 0x04004762 RID: 18274
			public readonly MomentMagnificationFactor.#wif #f;
		}
	}
}
