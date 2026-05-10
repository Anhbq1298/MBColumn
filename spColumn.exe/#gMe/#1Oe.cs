using System;
using System.Runtime.CompilerServices;
using #g7e;
using #hZe;
using #X7e;
using #y6e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #gMe
{
	// Token: 0x020012B4 RID: 4788
	internal sealed class #1Oe
	{
		// Token: 0x0600A042 RID: 41026 RVA: 0x002214E4 File Offset: 0x0021F6E4
		public #1Oe(InputModel #hMe, RuntimeModel #iMe, #6Re #uye, #fMe #wMe, #nUe #pge, #VPe #SMe, #fNe #xMe, #38e #jMe)
		{
			this.#c = #hMe;
			this.#f = #iMe;
			this.#e = #uye;
			this.#a = #wMe;
			this.#g = #pge;
			this.#d = #SMe;
			this.#b = #xMe;
			this.#h = #jMe;
		}

		// Token: 0x17002E17 RID: 11799
		// (get) Token: 0x0600A043 RID: 41027 RVA: 0x0007DCBF File Offset: 0x0007BEBF
		private float Eyt
		{
			get
			{
				return this.#c.MaterialProperties.Eyt;
			}
		}

		// Token: 0x17002E18 RID: 11800
		// (get) Token: 0x0600A044 RID: 41028 RVA: 0x0007DCD1 File Offset: 0x0007BED1
		private float[] DepthOfReinforcement
		{
			get
			{
				return this.#f.Depth.OfReinforcement;
			}
		}

		// Token: 0x17002E19 RID: 11801
		// (get) Token: 0x0600A045 RID: 41029 RVA: 0x0007DCE3 File Offset: 0x0007BEE3
		private #nW MessageBus
		{
			get
			{
				return this.#f.MessageBus;
			}
		}

		// Token: 0x17002E1A RID: 11802
		// (get) Token: 0x0600A046 RID: 41030 RVA: 0x0007DCF0 File Offset: 0x0007BEF0
		private Options Options
		{
			get
			{
				return this.#c.Options;
			}
		}

		// Token: 0x17002E1B RID: 11803
		// (get) Token: 0x0600A047 RID: 41031 RVA: 0x0007DCFD File Offset: 0x0007BEFD
		private #Fce ReductionFactors
		{
			get
			{
				return this.#f.ReductionFactors;
			}
		}

		// Token: 0x17002E1C RID: 11804
		// (get) Token: 0x0600A048 RID: 41032 RVA: 0x0007DD0A File Offset: 0x0007BF0A
		private #J6e RunFlag
		{
			get
			{
				return this.#f.RunFlag;
			}
		}

		// Token: 0x0600A049 RID: 41033 RVA: 0x0007DD17 File Offset: 0x0007BF17
		internal #y0e #5ai()
		{
			if (this.#f.CachedFactoredInteractionDiagram == null)
			{
				this.#f.CachedFactoredInteractionDiagram = this.#YJe();
			}
			return this.#f.CachedFactoredInteractionDiagram;
		}

		// Token: 0x0600A04A RID: 41034 RVA: 0x00221534 File Offset: 0x0021F734
		public #y0e #YJe()
		{
			#vMe #ZOe = new #vMe(this.#c, this.#f, this.#e, this.#a, this.#b, this.#h);
			if (this.Options.ConsideredAxis != #C6e.#c)
			{
				return this.#0Oe(#ZOe);
			}
			return this.#YOe(#ZOe);
		}

		// Token: 0x0600A04B RID: 41035 RVA: 0x00221588 File Offset: 0x0021F788
		private static int #TOe(int #UOe)
		{
			int num = 35;
			if (#UOe == num)
			{
				return 100;
			}
			return (int)((double)#UOe / (double)num * 100.0);
		}

		// Token: 0x0600A04C RID: 41036 RVA: 0x002215B0 File Offset: 0x0021F7B0
		private static int #VOe(int #WOe, bool #XOe)
		{
			int num = 69;
			if (#XOe && #WOe == num)
			{
				return 100;
			}
			double num2 = (double)#WOe / (double)num / 2.0 * 100.0;
			if (#XOe)
			{
				num2 += 50.0;
			}
			return (int)num2;
		}

		// Token: 0x0600A04D RID: 41037 RVA: 0x002215F8 File Offset: 0x0021F7F8
		private #y0e #YOe(#vMe #ZOe)
		{
			float num = 0f;
			#y0e #y0e = new #y0e
			{
				BiCurve = #ZOe.#nMe()
			};
			float #2je = this.Eyt;
			float #USe = this.ReductionFactors.B;
			float #f8e = this.ReductionFactors.C;
			float[] array = this.DepthOfReinforcement;
			for (int i = 0; i < 36; i++)
			{
				this.#g.#Zub(num);
				this.#d.#bpb(num);
				for (int j = 0; j < 70; j++)
				{
					#1Oe.#9Vb #9Vb = new #1Oe.#9Vb();
					#9Vb.#b = this;
					this.MessageBus.DebugContext.Angle = new float?(num);
					this.MessageBus.DebugContext.CurvePoint = new int?(j);
					BiCurve biCurve = #y0e.BiCurve[j];
					float #ivb = biCurve.AxialLoad;
					#9Vb.#a = num;
					#r1e #r1e = this.#e.#bpb(#ivb, new Func<float, #D2e>(#9Vb.#ohf), 2);
					float num2 = this.#h.#dYe(#r1e.BarUltimateStrainEpsilon, #2je, #USe, #f8e);
					biCurve.BarMaximumStrainEps[i] = #r1e.BarUltimateStrainEpsilon;
					biCurve.PhiFactor[i] = num2;
					biCurve.MomentX[i] = #r1e.ColumnLoad.MomentX;
					biCurve.MomentY[i] = #r1e.ColumnLoad.MomentY;
					biCurve.DepthOfNeutralAxisC[i] = #r1e.DepthOfNeutralAxisC;
					biCurve.AngleOfNeutralAxisC[i] = num;
					biCurve.Dt[i] = array[2];
				}
				num += 10f;
				int #r7e = #1Oe.#TOe(i);
				#q7e #q7e = new #q7e(#q7e.#Mif.#b, #r7e);
				this.MessageBus.#76e(#q7e);
				if (#q7e.Cancel)
				{
					return null;
				}
			}
			num = 0f;
			for (int k = 0; k < 36; k++)
			{
				float num3 = 3.1415927f * num / 180f;
				#y0e.BiCurve[0].MomentX[k] += (float)(9.999999747378752E-05 * Math.Cos((double)num3));
				#y0e.BiCurve[0].MomentY[k] += (float)(9.999999747378752E-05 * Math.Sin((double)num3));
				#y0e.BiCurve[69].MomentX[k] += (float)(9.999999747378752E-05 * Math.Cos((double)num3));
				#y0e.BiCurve[69].MomentY[k] += (float)(9.999999747378752E-05 * Math.Sin((double)num3));
				num += 10f;
			}
			this.MessageBus.DebugContext.#yJ();
			return #y0e;
		}

		// Token: 0x0600A04E RID: 41038 RVA: 0x002218B0 File Offset: 0x0021FAB0
		private #y0e #0Oe(#vMe #ZOe)
		{
			float num = (this.Options.ConsideredAxis == #C6e.#a) ? 0f : 90f;
			this.#g.#Zub(num);
			this.#d.#bpb(num);
			#y0e #y0e = new #y0e
			{
				UniCurve = #ZOe.#oMe()
			};
			for (int i = 0; i < 70; i++)
			{
				float #ivb = #y0e.UniCurve[i].AxialLoad;
				#r1e #r1e = this.#e.#bpb(#ivb, new Func<float, #D2e>(this.#a.#6Le), 2);
				float reductionFactorPhi = this.#h.#dYe(#r1e.BarUltimateStrainEpsilon, this.Eyt, this.ReductionFactors.B, this.ReductionFactors.C);
				#y0e.UniCurve[i].PositiveSide = new UniCurveData(#r1e.ColumnLoad.AbsoluteMomentMagnitudeR, #r1e.DepthOfNeutralAxisC, num, #r1e.BarUltimateStrainEpsilon, reductionFactorPhi);
				#y0e.UniCurve[i].PlotPoint = true;
				int #r7e = #1Oe.#VOe(i, false);
				#q7e #q7e = new #q7e(#q7e.#Mif.#b, #r7e);
				this.MessageBus.#76e(#q7e);
				if (#q7e.Cancel)
				{
					return null;
				}
			}
			#y0e.SpliceLines.PosZeroFy.#mg(this.#f.YieldSteelStrengthFyEqualToZero);
			#y0e.SpliceLines.PosHalfFy.#mg(this.#f.YieldSteelStrengthFyEqualToHalf);
			num = ((this.Options.ConsideredAxis == #C6e.#a) ? 180f : 270f);
			this.#g.#Zub(num);
			this.#d.#bpb(num);
			for (int j = 0; j < 70; j++)
			{
				float #ivb2 = #y0e.UniCurve[j].AxialLoad;
				#r1e #r1e2 = this.#e.#bpb(#ivb2, new Func<float, #D2e>(this.#a.#6Le), 2);
				float reductionFactorPhi2 = this.#h.#dYe(#r1e2.BarUltimateStrainEpsilon, this.Eyt, this.ReductionFactors.B, this.ReductionFactors.C);
				#y0e.UniCurve[j].NegativeSide = new UniCurveData(-#r1e2.ColumnLoad.AbsoluteMomentMagnitudeR, #r1e2.DepthOfNeutralAxisC, num, #r1e2.BarUltimateStrainEpsilon, reductionFactorPhi2);
				int #r7e2 = #1Oe.#VOe(j, true);
				#q7e #q7e2 = new #q7e(#q7e.#Mif.#b, #r7e2);
				this.MessageBus.#76e(#q7e2);
				if (#q7e2.Cancel)
				{
					return null;
				}
			}
			#y0e.SpliceLines.NegZeroFy.#mg(this.#f.YieldSteelStrengthFyEqualToZero);
			#y0e.SpliceLines.NegHalfFy.#mg(this.#f.YieldSteelStrengthFyEqualToHalf);
			num = ((this.Options.ConsideredAxis == #C6e.#a) ? 0f : 90f);
			this.#g.#Zub(num);
			this.#d.#bpb(num);
			return #y0e;
		}

		// Token: 0x04004626 RID: 17958
		private readonly #fMe #a;

		// Token: 0x04004627 RID: 17959
		private readonly #fNe #b;

		// Token: 0x04004628 RID: 17960
		private readonly InputModel #c;

		// Token: 0x04004629 RID: 17961
		private readonly #VPe #d;

		// Token: 0x0400462A RID: 17962
		private readonly #6Re #e;

		// Token: 0x0400462B RID: 17963
		private readonly RuntimeModel #f;

		// Token: 0x0400462C RID: 17964
		private readonly #nUe #g;

		// Token: 0x0400462D RID: 17965
		private readonly #38e #h;

		// Token: 0x020012B5 RID: 4789
		[CompilerGenerated]
		private sealed class #9Vb
		{
			// Token: 0x0600A050 RID: 41040 RVA: 0x0007DD42 File Offset: 0x0007BF42
			internal #D2e #ohf(float #5Gb)
			{
				return this.#b.#a.#8Le(#5Gb, this.#a);
			}

			// Token: 0x0400462E RID: 17966
			public float #a;

			// Token: 0x0400462F RID: 17967
			public #1Oe #b;
		}
	}
}
