using System;
using #12e;
using #gMe;
using #hZe;
using #X7e;
using #y6e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #IWe
{
	// Token: 0x020012F9 RID: 4857
	internal sealed class #HWe
	{
		// Token: 0x0600A276 RID: 41590 RVA: 0x0022B0CC File Offset: 0x002292CC
		public #HWe(#l4e #Kwe, float #Udb, InputModel #hMe, RuntimeModel #iMe, #6Re #uye, #nUe #pge, #VPe #SMe, #fMe #wMe, #38e #jMe)
		{
			this.#f = #Kwe;
			this.#a = #Udb;
			this.#c = #hMe;
			this.#g = #iMe;
			this.#e = #uye;
			this.#h = #pge;
			this.#d = #SMe;
			this.#b = #wMe;
			this.#i = #jMe;
		}

		// Token: 0x0600A277 RID: 41591 RVA: 0x0022B124 File Offset: 0x00229324
		public void #sWe()
		{
			this.#d.#bpb(this.#a);
			LoadsExt[] array = this.#g.FactoredLoads.Loads;
			int num = this.#g.FactoredLoads.NumberOfLoads;
			int #Kpb = 0;
			for (int i = 0; i < num; i++)
			{
				float #wWe = array[i].AxialLoad;
				float #xWe = Math.Min(array[i].AxialLoad, array[i].MomentX);
				float #yWe = Math.Max(array[i].AxialLoad, array[i].MomentX);
				#Kpb = this.#zWe(#wWe, #Kpb, #xWe, #yWe, array[i]);
			}
		}

		// Token: 0x0600A278 RID: 41592 RVA: 0x0022B1BC File Offset: 0x002293BC
		private static bool #tWe(float #uWe, #r1e #PE)
		{
			return Math.Abs(#uWe + #PE.ColumnLoad.AbsoluteMomentMagnitudeR) > 0.01f;
		}

		// Token: 0x0600A279 RID: 41593 RVA: 0x0007F14F File Offset: 0x0007D34F
		private static bool #vWe(float #wWe, float #xWe, float #yWe, float #1jb)
		{
			return #1jb != 0f && #wWe >= #xWe && #wWe <= #yWe;
		}

		// Token: 0x0600A27A RID: 41594 RVA: 0x0022B1E8 File Offset: 0x002293E8
		private int #zWe(float #wWe, int #Kpb, float #xWe, float #yWe, LoadsExt #ivb)
		{
			bool flag = false;
			bool flag2 = false;
			for (;;)
			{
				if (#wWe < this.#g.AxialLoads.Maximum)
				{
					goto IL_2C;
				}
				if (!flag)
				{
					flag = true;
					goto IL_2C;
				}
				#wWe += #ivb.MomentY;
				IL_116:
				if (!#HWe.#vWe(#wWe, #xWe, #yWe, #ivb.MomentY))
				{
					break;
				}
				continue;
				IL_2C:
				if (#wWe <= this.#g.AxialLoads.Minimum)
				{
					if (flag2)
					{
						#wWe += #ivb.MomentY;
						goto IL_116;
					}
					flag2 = true;
				}
				#Kpb++;
				#r1e #r1e = this.#AWe(#wWe);
				this.#BWe(new int?(#Kpb), #r1e, #r1e.ColumnLoad.AbsoluteMomentMagnitudeR, new float?(#r1e.ColumnLoad.AxialLoad));
				float #uWe = #r1e.ColumnLoad.AbsoluteMomentMagnitudeR;
				this.#tUe(this.#FWe() ? 270f : 180f);
				#r1e = this.#AWe(#wWe);
				if (#HWe.#tWe(#uWe, #r1e))
				{
					this.#BWe(null, #r1e, -#r1e.ColumnLoad.AbsoluteMomentMagnitudeR, null);
				}
				this.#tUe(this.#FWe() ? 90f : 0f);
				#wWe += #ivb.MomentY;
				goto IL_116;
			}
			return #Kpb;
		}

		// Token: 0x0600A27B RID: 41595 RVA: 0x0007F166 File Offset: 0x0007D366
		private #r1e #AWe(float #wWe)
		{
			return this.#e.#bpb(#wWe, new Func<float, #D2e>(this.#b.#6Le), 2);
		}

		// Token: 0x0600A27C RID: 41596 RVA: 0x0022B324 File Offset: 0x00229524
		private void #BWe(int? #Kpb, #r1e #PE, float #CWe, float? #ivb)
		{
			float #zMe = this.#GWe();
			float? #pye = this.#DWe(#PE);
			float #Tje = #PE.BarUltimateStrainEpsilon;
			#Jce #Tdb = new #Jce(#Kpb, #ivb, #CWe, #PE.DepthOfNeutralAxisC, #zMe, #Tje, #pye);
			this.#f.#vzc(#Tdb);
		}

		// Token: 0x0600A27D RID: 41597 RVA: 0x0022B368 File Offset: 0x00229568
		private float? #DWe(#r1e #PE)
		{
			float #2je = this.#c.MaterialProperties.Eyt;
			#Fce #Fce = this.#g.ReductionFactors;
			return this.#i.#s8e(#PE.BarUltimateStrainEpsilon, #2je, #Fce.B, #Fce.C);
		}

		// Token: 0x0600A27E RID: 41598 RVA: 0x0007F186 File Offset: 0x0007D386
		private void #tUe(float #EWe)
		{
			this.#h.#Zub(#EWe);
			this.#d.#bpb(this.#a);
		}

		// Token: 0x0600A27F RID: 41599 RVA: 0x0007F1A5 File Offset: 0x0007D3A5
		private bool #FWe()
		{
			return this.#c.Options.ConsideredAxis == #C6e.#b;
		}

		// Token: 0x0600A280 RID: 41600 RVA: 0x0022B3B0 File Offset: 0x002295B0
		private float #GWe()
		{
			switch (this.#c.Options.ConsideredAxis)
			{
			case #C6e.#a:
				return this.#g.Depth.OfReinforcement[0];
			case #C6e.#b:
				return this.#g.Depth.OfReinforcement[1];
			case #C6e.#d:
				return this.#g.Depth.OfReinforcement[2];
			}
			return 0f;
		}

		// Token: 0x0400471F RID: 18207
		private readonly float #a;

		// Token: 0x04004720 RID: 18208
		private readonly #fMe #b;

		// Token: 0x04004721 RID: 18209
		private readonly InputModel #c;

		// Token: 0x04004722 RID: 18210
		private readonly #VPe #d;

		// Token: 0x04004723 RID: 18211
		private readonly #6Re #e;

		// Token: 0x04004724 RID: 18212
		private readonly #l4e #f;

		// Token: 0x04004725 RID: 18213
		private readonly RuntimeModel #g;

		// Token: 0x04004726 RID: 18214
		private readonly #nUe #h;

		// Token: 0x04004727 RID: 18215
		private readonly #38e #i;
	}
}
