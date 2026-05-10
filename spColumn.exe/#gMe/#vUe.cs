using System;
using #hZe;
using #y6e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #gMe
{
	// Token: 0x020012DF RID: 4831
	internal sealed class #vUe
	{
		// Token: 0x0600A173 RID: 41331 RVA: 0x0007E9B6 File Offset: 0x0007CBB6
		public #vUe(InputModel #hMe, RuntimeModel #iMe, #6Re #uye, #nUe #pge, #VPe #SMe, #fMe #wMe)
		{
			this.#c = #hMe;
			this.#f = #iMe;
			this.#e = #uye;
			this.#g = #pge;
			this.#d = #SMe;
			this.#b = #wMe;
		}

		// Token: 0x17002E6C RID: 11884
		// (get) Token: 0x0600A174 RID: 41332 RVA: 0x0007E9EB File Offset: 0x0007CBEB
		private #3Ze Depth
		{
			get
			{
				return this.#f.Depth;
			}
		}

		// Token: 0x0600A175 RID: 41333 RVA: 0x00227A50 File Offset: 0x00225C50
		public #S0e #5W(LoadsExt #ivb, ref float #Tje, ref float #yMe, ref float #zMe, ref float #AMe, ref float #BMe)
		{
			#C6e #C6e = this.#c.Options.ConsideredAxis;
			float #Udb = (#C6e == #C6e.#a) ? 0f : 90f;
			this.#tUe(#Udb);
			#r1e #pUe = this.#e.#bpb(#ivb.AxialLoad, new Func<float, #D2e>(this.#b.#6Le), 2);
			if (#C6e == #C6e.#a)
			{
				return this.#qUe(#ivb, ref #Tje, ref #yMe, ref #zMe, ref #AMe, #pUe);
			}
			if (#C6e != #C6e.#b)
			{
				return null;
			}
			return this.#oUe(#ivb, ref #Tje, ref #yMe, ref #zMe, ref #BMe, #pUe);
		}

		// Token: 0x0600A176 RID: 41334 RVA: 0x00227AD4 File Offset: 0x00225CD4
		private static float #DMe(#r1e #Rfb)
		{
			float num = -#Rfb.ColumnLoad.AbsoluteMomentMagnitudeR;
			if (num < 0.0001f && num > -0.0001f)
			{
				return -0.0001f;
			}
			return num;
		}

		// Token: 0x0600A177 RID: 41335 RVA: 0x00227B08 File Offset: 0x00225D08
		private static float #EMe(#r1e #PE)
		{
			float num = #PE.ColumnLoad.AbsoluteMomentMagnitudeR;
			if (num < 0.0001f && num > -0.0001f)
			{
				return 0.0001f;
			}
			return num;
		}

		// Token: 0x0600A178 RID: 41336 RVA: 0x00227B3C File Offset: 0x00225D3C
		private #S0e #oUe(LoadsExt #ivb, ref float #Tje, ref float #yMe, ref float #zMe, ref float #BMe, #r1e #pUe)
		{
			this.#tUe(270f);
			#r1e #Rfb = this.#e.#bpb(#ivb.AxialLoad, new Func<float, #D2e>(this.#b.#6Le), 2);
			this.#tUe(90f);
			this.#rUe(out #Tje, out #yMe, out #zMe, #pUe, #Rfb, #C6e.#b, #ivb.MomentY);
			float num = #vUe.#DMe(#Rfb);
			float num2 = #vUe.#EMe(#pUe);
			if (num / num2 <= 0f)
			{
				#BMe = ((#ivb.MomentY >= 0f) ? num2 : num);
				return null;
			}
			if (#ivb.MomentY < num - 0.0001f || #ivb.MomentY > num2 + 0.0001f)
			{
				return new #S0e(0f, num, 0f, num2, 0f, 0f, true, #Tje, #yMe, #zMe, -0.5f);
			}
			return new #S0e(0f, num, 0f, num2, 0f, 0f, true, #Tje, #yMe, #zMe, -1f);
		}

		// Token: 0x0600A179 RID: 41337 RVA: 0x00227C38 File Offset: 0x00225E38
		private #S0e #qUe(LoadsExt #ivb, ref float #Tje, ref float #yMe, ref float #zMe, ref float #AMe, #r1e #pUe)
		{
			this.#tUe(180f);
			#r1e #Rfb = this.#e.#bpb(#ivb.AxialLoad, new Func<float, #D2e>(this.#b.#6Le), 2);
			this.#tUe(0f);
			this.#rUe(out #Tje, out #yMe, out #zMe, #pUe, #Rfb, #C6e.#a, #ivb.MomentX);
			float num = #vUe.#DMe(#Rfb);
			float num2 = #vUe.#EMe(#pUe);
			if (num / num2 <= 0f)
			{
				#AMe = ((#ivb.MomentX >= 0f) ? num2 : num);
				return null;
			}
			if (#ivb.MomentX < num - 0.0001f || #ivb.MomentX > num2 + 0.0001f)
			{
				return new #S0e(num, 0f, num2, 0f, 0f, 0f, true, #Tje, #yMe, #zMe, -0.5f);
			}
			return new #S0e(num, 0f, num2, 0f, 0f, 0f, true, #Tje, #yMe, #zMe, -1f);
		}

		// Token: 0x0600A17A RID: 41338 RVA: 0x00227D34 File Offset: 0x00225F34
		private void #rUe(out float #Tje, out float #yMe, out float #zMe, #r1e #sUe, #r1e #Rfb, #C6e #6gb, float #cpb)
		{
			if (#cpb >= 0f)
			{
				#yMe = #sUe.DepthOfNeutralAxisC;
				#Tje = #sUe.BarUltimateStrainEpsilon;
				#zMe = this.#uUe();
				return;
			}
			#yMe = #Rfb.DepthOfNeutralAxisC;
			#Tje = #Rfb.BarUltimateStrainEpsilon;
			#zMe = this.Depth.OfReinforcement[(int)#6gb];
		}

		// Token: 0x0600A17B RID: 41339 RVA: 0x0007E9F8 File Offset: 0x0007CBF8
		private void #tUe(float #Udb)
		{
			this.#g.#Zub(#Udb);
			this.#d.#bpb(#Udb);
		}

		// Token: 0x0600A17C RID: 41340 RVA: 0x0007EA12 File Offset: 0x0007CC12
		private float #uUe()
		{
			if (this.#c.Options.ConsideredAxis != #C6e.#a)
			{
				return this.Depth.OfReinforcement[1];
			}
			return this.Depth.OfReinforcement[0];
		}

		// Token: 0x040046AD RID: 18093
		private const float #a = 0.0001f;

		// Token: 0x040046AE RID: 18094
		private readonly #fMe #b;

		// Token: 0x040046AF RID: 18095
		private readonly InputModel #c;

		// Token: 0x040046B0 RID: 18096
		private readonly #VPe #d;

		// Token: 0x040046B1 RID: 18097
		private readonly #6Re #e;

		// Token: 0x040046B2 RID: 18098
		private readonly RuntimeModel #f;

		// Token: 0x040046B3 RID: 18099
		private readonly #nUe #g;
	}
}
