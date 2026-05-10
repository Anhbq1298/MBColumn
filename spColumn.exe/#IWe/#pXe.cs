using System;
using #12e;
using #hZe;
using #wUe;
using #X7e;
using #y6e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;

namespace #IWe
{
	// Token: 0x02001301 RID: 4865
	internal sealed class #pXe
	{
		// Token: 0x0600A2A8 RID: 41640 RVA: 0x0007F2E5 File Offset: 0x0007D4E5
		public #pXe(InputModel #hMe, RuntimeModel #iMe, #l4e #Kwe, #38e #jMe)
		{
			this.#a = #hMe;
			this.#c = #iMe;
			this.#b = #Kwe;
			this.#d = #jMe;
		}

		// Token: 0x0600A2A9 RID: 41641 RVA: 0x0007F30A File Offset: 0x0007D50A
		public void #sWe()
		{
			if (this.#lXe(#C6e.#a))
			{
				this.#kXe(#C6e.#a);
			}
			if (this.#lXe(#C6e.#b))
			{
				this.#kXe(#C6e.#b);
			}
		}

		// Token: 0x0600A2AA RID: 41642 RVA: 0x0007F32C File Offset: 0x0007D52C
		private static NaNullableFloat #bXe(bool #cXe, float #eRe)
		{
			if (#cXe)
			{
				return NaNullableFloat.#FSd();
			}
			return new NaNullableFloat(new float?(#eRe));
		}

		// Token: 0x0600A2AB RID: 41643 RVA: 0x0007F32C File Offset: 0x0007D52C
		private static NaNullableFloat #dXe(bool #uQe, float #eXe)
		{
			if (#uQe)
			{
				return NaNullableFloat.#FSd();
			}
			return new NaNullableFloat(new float?(#eXe));
		}

		// Token: 0x0600A2AC RID: 41644 RVA: 0x0007F342 File Offset: 0x0007D542
		private static bool #fXe(int #uRe)
		{
			return #xke.#dke(#uRe & 32768);
		}

		// Token: 0x0600A2AD RID: 41645 RVA: 0x0007F350 File Offset: 0x0007D550
		private static bool #gXe(int #hXe)
		{
			return #xke.#dke(#hXe & 1024);
		}

		// Token: 0x0600A2AE RID: 41646 RVA: 0x0007F35E File Offset: 0x0007D55E
		private static bool #iXe(int #hXe)
		{
			return #xke.#dke(#hXe & 2048);
		}

		// Token: 0x0600A2AF RID: 41647 RVA: 0x0007F36C File Offset: 0x0007D56C
		private static bool #jXe(int #hXe)
		{
			return #xke.#dke(#hXe & 4096);
		}

		// Token: 0x0600A2B0 RID: 41648 RVA: 0x0022BF08 File Offset: 0x0022A108
		private void #kXe(#C6e #6gb)
		{
			for (int i = 0; i < this.#a.Options.NumberOfServiceLoads; i++)
			{
				for (int j = 0; j < this.#a.Options.NumberOfLoadCombinations; j++)
				{
					this.#mXe((int)#6gb, i, j, 0);
					this.#mXe((int)#6gb, i, j, 1);
				}
			}
		}

		// Token: 0x0600A2B1 RID: 41649 RVA: 0x0022BF60 File Offset: 0x0022A160
		private bool #lXe(#C6e #6gb)
		{
			#C6e #C6e = this.#a.Options.ConsideredAxis;
			return #C6e == #C6e.#c || #C6e == #6gb;
		}

		// Token: 0x0600A2B2 RID: 41650 RVA: 0x0022BF88 File Offset: 0x0022A188
		private void #mXe(int #pQe, int #Kpb, int #Lpb, int #nXe)
		{
			#Lce #Lce = this.#c.SlendernessFactors[#Kpb][#pQe];
			FactoredMoment #i4e = this.#oXe(#pQe, #Lce, #Lpb, #nXe, #Kpb);
			this.#b.#vzc(#i4e);
			if (!#pXe.#fXe(#Lce.EndFlags[#Lpb][#nXe]))
			{
				return;
			}
			#i4e = this.#oXe(#Lce, #Kpb, #Lpb, #pQe, #nXe);
			this.#b.#vzc(#i4e);
		}

		// Token: 0x0600A2B3 RID: 41651 RVA: 0x0022BFEC File Offset: 0x0022A1EC
		private FactoredMoment #oXe(int #pQe, #Lce #Zpe, int #Lpb, int #nXe, int #Kpb)
		{
			FactoredMoment.Axis momentAxis = (#pQe == 0) ? FactoredMoment.Axis.X : FactoredMoment.Axis.Y;
			bool flag = (#pQe == 0) ? this.#a.DesignedColumnX.IsBraced : this.#a.DesignedColumnY.IsBraced;
			int #hXe = #Zpe.Flags[#Lpb];
			int #uRe = #Zpe.EndFlags[#Lpb][#nXe];
			bool flag2 = #pXe.#jXe(#hXe);
			float value = #Zpe.UltimateMomentsBraced[#Lpb][#nXe];
			NaNullableFloat ms = #pXe.#dXe(flag, #Zpe.UltimateMomentsSway[#Lpb][#nXe]);
			float? mu = new float?(#Zpe.Mu[#Lpb][#nXe]);
			NaNullableFloat mMin = NaNullableFloat.#FSd();
			NaNullableFloat mi = #pXe.#bXe(flag2, #Zpe.Mi[#Lpb][#nXe]);
			NaNullableFloat mc = NaNullableFloat.#FSd();
			NaNullableFloat ratio = NaNullableFloat.#FSd();
			FactoredMoment.#wif #wif = FactoredMoment.#wif.#a;
			int[] array2;
			if (Math.Abs(#Zpe.Mi[#Lpb][0]) <= Math.Abs(#Zpe.Mi[#Lpb][1]))
			{
				int[] array = new int[2];
				array[0] = 1;
				array2 = array;
				array[1] = 2;
			}
			else
			{
				int[] array3 = new int[2];
				array3[0] = 2;
				array2 = array3;
				array3[1] = 1;
			}
			int[] array4 = array2;
			if (!flag2)
			{
				if (#pXe.#iXe(#hXe))
				{
					float num = #xke.#vke(#Zpe.Mi[#Lpb][#nXe]);
					float num2 = #Zpe.MinMoment[#Lpb];
					mMin = new NaNullableFloat(new float?(num * num2));
				}
				if (flag || #pXe.#gXe(#hXe))
				{
					mc = new NaNullableFloat(new float?(#Zpe.Mc[#Lpb][#nXe]));
				}
				if (#pXe.#fXe(#uRe))
				{
					#wif |= FactoredMoment.#wif.#c;
				}
				ratio = this.#d.#K7e(#Zpe.Du[#Lpb][#nXe], ref #wif);
			}
			int value2 = #Kpb + 1;
			int value3 = #Lpb + 1;
			return new FactoredMoment(momentAxis, new int?(value2), new int?(value3), new float?(value), ms, mu, mMin, mi, mc, ratio, #wif, (FactoredMoment.#vif)#nXe, new int?(array4[#nXe]));
		}

		// Token: 0x0600A2B4 RID: 41652 RVA: 0x0022C1A4 File Offset: 0x0022A3A4
		private FactoredMoment #oXe(#Lce #Zpe, int #Kpb, int #Lpb, int #pQe, int #nXe)
		{
			FactoredMoment.Axis momentAxis = (#pQe == 0) ? FactoredMoment.Axis.X : FactoredMoment.Axis.Y;
			FactoredMoment.#wif flags = FactoredMoment.#wif.#a;
			NaNullableFloat mi = #pXe.#bXe(#pXe.#jXe(#Zpe.Flags[#Lpb]), #Zpe.Mi[#Lpb][#nXe]);
			NaNullableFloat mc = new NaNullableFloat(new float?(#Zpe.Mc0[#Lpb][#nXe]));
			NaNullableFloat ratio = this.#d.#K7e(#Zpe.Du0[#Lpb][#nXe], ref flags);
			int[] array2;
			if (Math.Abs(#Zpe.Mi[#Lpb][0]) <= Math.Abs(#Zpe.Mi[#Lpb][1]))
			{
				int[] array = new int[2];
				array[0] = 1;
				array2 = array;
				array[1] = 2;
			}
			else
			{
				int[] array3 = new int[2];
				array3[0] = 2;
				array2 = array3;
				array3[1] = 1;
			}
			int[] array4 = array2;
			int value = #Kpb + 1;
			int value2 = #Lpb + 1;
			return new FactoredMoment(momentAxis, new int?(value), new int?(value2), new NaNullableFloat(null), mi, mc, ratio, flags, (FactoredMoment.#vif)#nXe, new int?(array4[#nXe]));
		}

		// Token: 0x04004741 RID: 18241
		private readonly InputModel #a;

		// Token: 0x04004742 RID: 18242
		private readonly #l4e #b;

		// Token: 0x04004743 RID: 18243
		private readonly RuntimeModel #c;

		// Token: 0x04004744 RID: 18244
		private readonly #38e #d;
	}
}
