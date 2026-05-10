using System;
using System.Runtime.CompilerServices;
using #hZe;
using #y6e;
using #z5e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #gMe
{
	// Token: 0x020012B9 RID: 4793
	internal sealed class #VPe
	{
		// Token: 0x0600A06E RID: 41070 RVA: 0x0007DEEB File Offset: 0x0007C0EB
		public #VPe(InputModel #hMe, RuntimeModel #iMe, #6Re #uye, #fNe #xMe, #fMe #wMe)
		{
			this.#c = #hMe;
			this.#e = #iMe;
			this.#d = #uye;
			this.#b = #xMe;
			this.#a = #wMe;
		}

		// Token: 0x17002E28 RID: 11816
		// (get) Token: 0x0600A06F RID: 41071 RVA: 0x0007DF18 File Offset: 0x0007C118
		private #vZe AxialLoads
		{
			get
			{
				return this.#e.AxialLoads;
			}
		}

		// Token: 0x17002E29 RID: 11817
		// (get) Token: 0x0600A070 RID: 41072 RVA: 0x0007DF25 File Offset: 0x0007C125
		private #YZe BalancedCondition
		{
			get
			{
				return this.#e.BalancedCondition;
			}
		}

		// Token: 0x17002E2A RID: 11818
		// (get) Token: 0x0600A071 RID: 41073 RVA: 0x0007DF32 File Offset: 0x0007C132
		private #YZe MaxCompression
		{
			get
			{
				return this.#e.MaxCompression;
			}
		}

		// Token: 0x17002E2B RID: 11819
		// (get) Token: 0x0600A072 RID: 41074 RVA: 0x0007DF3F File Offset: 0x0007C13F
		private #YZe MaxTension
		{
			get
			{
				return this.#e.MaxTension;
			}
		}

		// Token: 0x17002E2C RID: 11820
		// (get) Token: 0x0600A073 RID: 41075 RVA: 0x0007DF4C File Offset: 0x0007C14C
		private #YZe YieldSteelStrengthFyEqualToHalf
		{
			get
			{
				return this.#e.YieldSteelStrengthFyEqualToHalf;
			}
		}

		// Token: 0x17002E2D RID: 11821
		// (get) Token: 0x0600A074 RID: 41076 RVA: 0x0007DF59 File Offset: 0x0007C159
		private #YZe YieldSteelStrengthFyEqualToZero
		{
			get
			{
				return this.#e.YieldSteelStrengthFyEqualToZero;
			}
		}

		// Token: 0x17002E2E RID: 11822
		// (get) Token: 0x0600A075 RID: 41077 RVA: 0x0007DF66 File Offset: 0x0007C166
		private #YZe ZeroCompression
		{
			get
			{
				return this.#e.ZeroCompression;
			}
		}

		// Token: 0x17002E2F RID: 11823
		// (get) Token: 0x0600A076 RID: 41078 RVA: 0x0007DF73 File Offset: 0x0007C173
		private #3Ze Depth
		{
			get
			{
				return this.#e.Depth;
			}
		}

		// Token: 0x17002E30 RID: 11824
		// (get) Token: 0x0600A077 RID: 41079 RVA: 0x0007DF80 File Offset: 0x0007C180
		private #K2 MaterialProperties
		{
			get
			{
				return this.#c.MaterialProperties;
			}
		}

		// Token: 0x17002E31 RID: 11825
		// (get) Token: 0x0600A078 RID: 41080 RVA: 0x0007DF8D File Offset: 0x0007C18D
		private Options Options
		{
			get
			{
				return this.#c.Options;
			}
		}

		// Token: 0x0600A079 RID: 41081 RVA: 0x00222B7C File Offset: 0x00220D7C
		public void #bpb(float #Udb)
		{
			#VPe.#ZXb #ZXb = new #VPe.#ZXb();
			#ZXb.#a = this;
			#ZXb.#b = #Udb;
			#vZe #uZe = this.#b.#bpb();
			this.AxialLoads.#tZe(#uZe);
			if (this.Options.ConsideredAxis != #C6e.#c)
			{
				this.#UPe(this.Depth.OfConcrete[2], this.Depth.OfReinforcement[2], new Func<float, #D2e>(this.#a.#6Le));
				return;
			}
			this.#UPe(this.Depth.OfConcrete[2], this.Depth.OfReinforcement[2], new Func<float, #D2e>(#ZXb.#phf));
		}

		// Token: 0x0600A07A RID: 41082 RVA: 0x00222C24 File Offset: 0x00220E24
		private static #YZe #RPe(Func<float, #D2e> #SPe, float #TPe)
		{
			#TZe #TZe = #SPe(#TPe).ColumnLoad;
			return new #YZe(#TPe, #TZe.AxialLoad, #TZe.AbsoluteMomentMagnitudeR);
		}

		// Token: 0x0600A07B RID: 41083 RVA: 0x00222C58 File Offset: 0x00220E58
		private void #UPe(float #5Md, float #2vc, Func<float, #D2e> #SPe)
		{
			float num = this.MaterialProperties.#H2();
			float num2 = #5Md / this.MaterialProperties.Beta1;
			float num3 = 1f - num;
			if (num3 <= 0f)
			{
				num2 *= 100f;
			}
			else
			{
				num3 = #2vc / num3;
				if (num2 < num3)
				{
					num2 = num3;
				}
			}
			#YZe #L = #VPe.#RPe(#SPe, num2);
			this.MaxCompression.#Yfd(#L);
			#L = #VPe.#RPe(#SPe, #2vc);
			this.YieldSteelStrengthFyEqualToZero.#Yfd(#L);
			num2 = #2vc / (1f + 0.5f * num);
			#L = #VPe.#RPe(#SPe, num2);
			this.YieldSteelStrengthFyEqualToHalf.#Yfd(#L);
			num2 = #2vc / (1f + num);
			#L = #VPe.#RPe(#SPe, num2);
			this.BalancedCondition.#Yfd(#L);
			int num4 = 0;
			#TZe #TZe = new #TZe
			{
				AxialLoad = this.BalancedCondition.AxialLoad,
				AbsoluteMomentMagnitudeR = this.BalancedCondition.AbsoluteMomentMagnitude
			};
			float #gSe;
			float #hSe;
			do
			{
				#gSe = num2;
				#hSe = #TZe.AxialLoad;
				num2 /= 2f;
				#TZe = #SPe(num2).ColumnLoad;
				num4++;
			}
			while (#TZe.AxialLoad > 0f && num4 < 1000);
			#fSe #VRe = new #fSe(#gSe, #hSe, num2, #TZe.AxialLoad);
			#r1e #r1e = this.#d.#bpb(0f, #SPe, -2, #VRe);
			this.ZeroCompression.DepthOfNeutralAxis = #r1e.DepthOfNeutralAxisC;
			this.ZeroCompression.AxialLoad = #r1e.ColumnLoad.AxialLoad;
			this.ZeroCompression.AbsoluteMomentMagnitude = #r1e.ColumnLoad.AbsoluteMomentMagnitudeR;
			num2 = 0f;
			#L = #VPe.#RPe(#SPe, num2);
			this.MaxTension.#Yfd(#L);
		}

		// Token: 0x04004639 RID: 17977
		private readonly #fMe #a;

		// Token: 0x0400463A RID: 17978
		private readonly #fNe #b;

		// Token: 0x0400463B RID: 17979
		private readonly InputModel #c;

		// Token: 0x0400463C RID: 17980
		private readonly #6Re #d;

		// Token: 0x0400463D RID: 17981
		private readonly RuntimeModel #e;

		// Token: 0x020012BA RID: 4794
		[CompilerGenerated]
		private sealed class #ZXb
		{
			// Token: 0x0600A07D RID: 41085 RVA: 0x0007DF9A File Offset: 0x0007C19A
			internal #D2e #phf(float #5Gb)
			{
				return this.#a.#a.#8Le(#5Gb, this.#b);
			}

			// Token: 0x0400463E RID: 17982
			public #VPe #a;

			// Token: 0x0400463F RID: 17983
			public float #b;
		}
	}
}
