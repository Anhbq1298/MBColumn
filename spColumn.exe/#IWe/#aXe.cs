using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #12e;
using #7hc;
using #gMe;
using #hZe;
using #X7e;
using #y6e;
using #z5e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #IWe
{
	// Token: 0x020012FD RID: 4861
	internal sealed class #aXe
	{
		// Token: 0x0600A290 RID: 41616 RVA: 0x0022B888 File Offset: 0x00229A88
		public #aXe(#l4e #Kwe, InputModel #hMe, RuntimeModel #iMe, #6Re #uye, #fNe #xMe, #nUe #pge, #VPe #SMe, #fMe #wMe, #38e #jMe)
		{
			this.#f = #Kwe;
			this.#c = #hMe;
			this.#g = #iMe;
			this.#e = #uye;
			this.#b = #xMe;
			this.#h = #pge;
			this.#d = #SMe;
			this.#a = #wMe;
			this.#i = #jMe;
		}

		// Token: 0x17002EAD RID: 11949
		// (get) Token: 0x0600A291 RID: 41617 RVA: 0x0007F272 File Offset: 0x0007D472
		private #K2 MaterialProperties
		{
			get
			{
				return this.#c.MaterialProperties;
			}
		}

		// Token: 0x0600A292 RID: 41618 RVA: 0x0022B8E0 File Offset: 0x00229AE0
		public void #sWe()
		{
			int num = (this.#c.Options.ConsideredAxis != #C6e.#c) ? 2 : 4;
			float num2 = (this.#c.Options.ConsideredAxis == #C6e.#b) ? 90f : 0f;
			ControlPoint.#uif[] #YWe = this.#VWe();
			for (int i = 0; i < num; i++)
			{
				this.#h.#Zub(num2);
				this.#d.#bpb(num2);
				this.#XWe(num2, #YWe);
				num2 += 360f / (float)num;
				if (this.#c.Options.ConsideredAxis != #C6e.#c)
				{
					this.#h.#Zub((this.#c.Options.ConsideredAxis == #C6e.#b) ? 90f : 0f);
					#vZe #uZe = this.#b.#bpb();
					this.#g.AxialLoads.#tZe(#uZe);
				}
			}
		}

		// Token: 0x0600A293 RID: 41619 RVA: 0x0007F27F File Offset: 0x0007D47F
		private static List<ControlPoint.#uif> #UWe()
		{
			return Enum.GetValues(typeof(ControlPoint.#uif)).Cast<ControlPoint.#uif>().ToList<ControlPoint.#uif>();
		}

		// Token: 0x0600A294 RID: 41620 RVA: 0x0022B9C8 File Offset: 0x00229BC8
		private ControlPoint.#uif[] #VWe()
		{
			bool flag = this.#WWe();
			List<ControlPoint.#uif> list = #aXe.#UWe();
			if (!flag)
			{
				list.Remove(ControlPoint.#uif.#f);
			}
			this.#i.#B8e(list);
			return list.ToArray();
		}

		// Token: 0x0600A295 RID: 41621 RVA: 0x0022BA00 File Offset: 0x00229C00
		private bool #WWe()
		{
			#K2 #K = this.MaterialProperties;
			return Math.Abs((#K.Es > 0f) ? (#K.Eyt - #K.Fy / #K.Es) : #K.Eyt) > 1E-06f;
		}

		// Token: 0x0600A296 RID: 41622 RVA: 0x0022BA4C File Offset: 0x00229C4C
		private void #XWe(float #Udb, ControlPoint.#uif[] #YWe)
		{
			float #zMe = this.#g.Depth.OfReinforcement[2];
			foreach (ControlPoint.#uif #C in #YWe)
			{
				ControlPoint #c4e = this.#ZWe(#C, #Udb, #zMe);
				this.#f.#vzc(#c4e);
			}
		}

		// Token: 0x0600A297 RID: 41623 RVA: 0x0022BA94 File Offset: 0x00229C94
		private ControlPoint #ZWe(ControlPoint.#uif #C, float #Udb, float #zMe)
		{
			ControlPoint controlPoint = this.#0We(#C, #Udb, #zMe);
			this.#i.#C8e(controlPoint, this.MaterialProperties.Eyt, this.#g.ReductionFactors);
			return controlPoint;
		}

		// Token: 0x0600A298 RID: 41624 RVA: 0x0022BAD0 File Offset: 0x00229CD0
		private ControlPoint #0We(ControlPoint.#uif #C, float #Udb, float #zMe)
		{
			switch (#C)
			{
			case ControlPoint.#uif.#a:
				return this.#9We(#Udb, #zMe);
			case ControlPoint.#uif.#b:
				return this.#8We(#Udb, #zMe);
			case ControlPoint.#uif.#c:
				return this.#7We(#Udb, #zMe);
			case ControlPoint.#uif.#d:
				return this.#6We(#Udb, #zMe);
			case ControlPoint.#uif.#e:
				return this.#5We(#Udb, #zMe);
			case ControlPoint.#uif.#f:
				return this.#4We(#Udb, #zMe);
			case ControlPoint.#uif.#g:
				return this.#3We(#Udb, #zMe);
			case ControlPoint.#uif.#h:
				return this.#2We(#Udb, #zMe);
			case ControlPoint.#uif.#i:
				return this.#1We(#Udb, #zMe);
			default:
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107383497), #C, null);
			}
		}

		// Token: 0x0600A299 RID: 41625 RVA: 0x0022BB70 File Offset: 0x00229D70
		private ControlPoint #1We(float #Udb, float #zMe)
		{
			#D2e #D2e = this.#a.#8Le(0f, #Udb);
			return new ControlPoint(ControlPoint.#uif.#i, #D2e.ColumnLoad, 0f, #zMe, #D2e.MaxSteelStrain, new float?(#Udb));
		}

		// Token: 0x0600A29A RID: 41626 RVA: 0x0022BBB0 File Offset: 0x00229DB0
		private ControlPoint #2We(float #Udb, float #zMe)
		{
			#aXe.#uZb #uZb = new #aXe.#uZb();
			#uZb.#a = this;
			#uZb.#b = #Udb;
			#r1e #r1e = this.#e.#bpb(0f, new Func<float, #D2e>(#uZb.#7hf), 2);
			return new ControlPoint(ControlPoint.#uif.#h, #r1e.ColumnLoad, #r1e.DepthOfNeutralAxisC, #zMe, #r1e.BarUltimateStrainEpsilon, new float?(#uZb.#b));
		}

		// Token: 0x0600A29B RID: 41627 RVA: 0x0022BC14 File Offset: 0x00229E14
		private ControlPoint #3We(float #Udb, float #zMe)
		{
			float num = this.#g.Depth.OfReinforcement[2] / (1f + this.#i.#G2(this.MaterialProperties));
			#D2e #D2e = this.#a.#8Le(num, #Udb);
			bool flag = this.#i.#Q8e(this.#g, this.#a, this.MaterialProperties, #Udb);
			return new ControlPoint(ControlPoint.#uif.#g, #D2e.ColumnLoad, num, #zMe, #D2e.MaxSteelStrain, new float?(#Udb))
			{
				HasPhiParadox = flag
			};
		}

		// Token: 0x0600A29C RID: 41628 RVA: 0x0022BC9C File Offset: 0x00229E9C
		private ControlPoint #4We(float #Udb, float #zMe)
		{
			float num = this.#g.Depth.OfReinforcement[2] / (1f + this.MaterialProperties.#I2());
			#D2e #D2e = this.#a.#8Le(num, #Udb);
			return new ControlPoint(ControlPoint.#uif.#f, #D2e.ColumnLoad, num, #zMe, #D2e.MaxSteelStrain, new float?(#Udb));
		}

		// Token: 0x0600A29D RID: 41629 RVA: 0x0022BCF8 File Offset: 0x00229EF8
		private ControlPoint #5We(float #Udb, float #zMe)
		{
			float num = #zMe / (1f + this.MaterialProperties.#H2());
			#D2e #D2e = this.#a.#8Le(num, #Udb);
			return new ControlPoint(ControlPoint.#uif.#e, #D2e.ColumnLoad, num, #zMe, #D2e.MaxSteelStrain, new float?(#Udb));
		}

		// Token: 0x0600A29E RID: 41630 RVA: 0x0022BD44 File Offset: 0x00229F44
		private ControlPoint #6We(float #Udb, float #zMe)
		{
			float num = #zMe / (1f + 0.5f * this.MaterialProperties.#H2());
			#D2e #D2e = this.#a.#8Le(num, #Udb);
			return new ControlPoint(ControlPoint.#uif.#d, #D2e.ColumnLoad, num, #zMe, #D2e.MaxSteelStrain, new float?(#Udb));
		}

		// Token: 0x0600A29F RID: 41631 RVA: 0x0022BD98 File Offset: 0x00229F98
		private ControlPoint #7We(float #Udb, float #zMe)
		{
			#D2e #D2e = this.#a.#8Le(#zMe, #Udb);
			return new ControlPoint(ControlPoint.#uif.#c, #D2e.ColumnLoad, #zMe, #zMe, #D2e.MaxSteelStrain, new float?(#Udb));
		}

		// Token: 0x0600A2A0 RID: 41632 RVA: 0x0022BDD4 File Offset: 0x00229FD4
		private ControlPoint #8We(float #Udb, float #zMe)
		{
			#aXe.#ZXb #ZXb = new #aXe.#ZXb();
			#ZXb.#a = this;
			#ZXb.#b = #Udb;
			float num = this.#g.ReductionFactors.#E1e(this.#c, this.#g, this.#i) * this.#g.AxialLoads.Maximum;
			#r1e #r1e = this.#e.#bpb(num, new Func<float, #D2e>(#ZXb.#8hf), 2);
			return new ControlPoint(ControlPoint.#uif.#b, num, #r1e.ColumnLoad.MomentX, #r1e.ColumnLoad.MomentY, #r1e.DepthOfNeutralAxisC, #zMe, #r1e.BarUltimateStrainEpsilon, new float?(#ZXb.#b));
		}

		// Token: 0x0600A2A1 RID: 41633 RVA: 0x0022BE80 File Offset: 0x0022A080
		private ControlPoint #9We(float #Udb, float #zMe)
		{
			#aXe.#NTb #NTb = new #aXe.#NTb();
			#NTb.#a = this;
			#NTb.#b = #Udb;
			float num = this.#g.AxialLoads.Maximum;
			#r1e #r1e = this.#e.#bpb(num, new Func<float, #D2e>(#NTb.#9hf), 2);
			return new ControlPoint(ControlPoint.#uif.#a, num, #r1e.ColumnLoad.MomentX, #r1e.ColumnLoad.MomentY, #r1e.DepthOfNeutralAxisC, #zMe, #r1e.BarUltimateStrainEpsilon, new float?(#NTb.#b));
		}

		// Token: 0x04004732 RID: 18226
		private readonly #fMe #a;

		// Token: 0x04004733 RID: 18227
		private readonly #fNe #b;

		// Token: 0x04004734 RID: 18228
		private readonly InputModel #c;

		// Token: 0x04004735 RID: 18229
		private readonly #VPe #d;

		// Token: 0x04004736 RID: 18230
		private readonly #6Re #e;

		// Token: 0x04004737 RID: 18231
		private readonly #l4e #f;

		// Token: 0x04004738 RID: 18232
		private readonly RuntimeModel #g;

		// Token: 0x04004739 RID: 18233
		private readonly #nUe #h;

		// Token: 0x0400473A RID: 18234
		private readonly #38e #i;

		// Token: 0x020012FE RID: 4862
		[CompilerGenerated]
		private sealed class #uZb
		{
			// Token: 0x0600A2A3 RID: 41635 RVA: 0x0007F29A File Offset: 0x0007D49A
			internal #D2e #7hf(float #5Gb)
			{
				return this.#a.#a.#8Le(#5Gb, this.#b);
			}

			// Token: 0x0400473B RID: 18235
			public #aXe #a;

			// Token: 0x0400473C RID: 18236
			public float #b;
		}

		// Token: 0x020012FF RID: 4863
		[CompilerGenerated]
		private sealed class #ZXb
		{
			// Token: 0x0600A2A5 RID: 41637 RVA: 0x0007F2B3 File Offset: 0x0007D4B3
			internal #D2e #8hf(float #5Gb)
			{
				return this.#a.#a.#8Le(#5Gb, this.#b);
			}

			// Token: 0x0400473D RID: 18237
			public #aXe #a;

			// Token: 0x0400473E RID: 18238
			public float #b;
		}

		// Token: 0x02001300 RID: 4864
		[CompilerGenerated]
		private sealed class #NTb
		{
			// Token: 0x0600A2A7 RID: 41639 RVA: 0x0007F2CC File Offset: 0x0007D4CC
			internal #D2e #9hf(float #5Gb)
			{
				return this.#a.#a.#8Le(#5Gb, this.#b);
			}

			// Token: 0x0400473F RID: 18239
			public #aXe #a;

			// Token: 0x04004740 RID: 18240
			public float #b;
		}
	}
}
