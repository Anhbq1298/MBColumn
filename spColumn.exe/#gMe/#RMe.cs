using System;
using System.Runtime.CompilerServices;
using #hZe;
using #wUe;
using #X7e;
using #z5e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #gMe
{
	// Token: 0x02001297 RID: 4759
	internal sealed class #RMe
	{
		// Token: 0x06009F72 RID: 40818 RVA: 0x0007D4CD File Offset: 0x0007B6CD
		public #RMe(InputModel #hMe, RuntimeModel #iMe, #6Re #uye, #nUe #pge, #VPe #SMe, #fMe #wMe, #38e #jMe)
		{
			this.#c = #hMe;
			this.#f = #iMe;
			this.#e = #uye;
			this.#g = #pge;
			this.#d = #SMe;
			this.#b = #wMe;
			this.#h = #jMe;
		}

		// Token: 0x17002DE0 RID: 11744
		// (get) Token: 0x06009F73 RID: 40819 RVA: 0x0007D50A File Offset: 0x0007B70A
		private #K2 MaterialProperties
		{
			get
			{
				return this.#c.MaterialProperties;
			}
		}

		// Token: 0x17002DE1 RID: 11745
		// (get) Token: 0x06009F74 RID: 40820 RVA: 0x0007D517 File Offset: 0x0007B717
		private #vZe AxialLoads
		{
			get
			{
				return this.#f.AxialLoads;
			}
		}

		// Token: 0x17002DE2 RID: 11746
		// (get) Token: 0x06009F75 RID: 40821 RVA: 0x0007D524 File Offset: 0x0007B724
		private #Fce ReductionFactors
		{
			get
			{
				return this.#f.ReductionFactors;
			}
		}

		// Token: 0x17002DE3 RID: 11747
		// (get) Token: 0x06009F76 RID: 40822 RVA: 0x0007D531 File Offset: 0x0007B731
		private #3Ze Depth
		{
			get
			{
				return this.#f.Depth;
			}
		}

		// Token: 0x06009F77 RID: 40823 RVA: 0x0021D764 File Offset: 0x0021B964
		public #S0e #5W(LoadsExt #ivb, ref float #Tje, ref float #yMe, ref float #zMe, ref float #AMe, ref float #BMe)
		{
			float num = #5Qe.#4Qe(#ivb.MomentX, #ivb.MomentY);
			float #Ehe = num * 3.1415927f / 180f;
			#a1e #a1e = this.#GMe(#ivb.AxialLoad, num);
			if (#a1e.ReturnValueI == 0)
			{
				return new #S0e(0f, 0f, 0f, 0f, 0f, 0f, false, 0f, #yMe, #zMe, -0.5f);
			}
			#yMe = #a1e.CVal1;
			#Tje = #a1e.EpsVal1;
			#zMe = #a1e.DtVal1;
			float num2 = #RMe.#EMe(#a1e.MomentMax);
			float num3 = #RMe.#DMe(#a1e.MomentMin);
			if (num3 / num2 <= 0f)
			{
				#AMe = #RMe.#Bpb(num2, #Ehe);
				#BMe = #RMe.#Cpb(num2, #Ehe);
				return null;
			}
			float num4 = #xke.#ike(#ivb.MomentX, #ivb.MomentY);
			if (num4 < num3 - 0.0001f || num4 > num2 + 0.0001f)
			{
				return new #S0e(#RMe.#Bpb(num3, #Ehe), #RMe.#Cpb(num3, #Ehe), #RMe.#Bpb(num2, #Ehe), #RMe.#Cpb(num2, #Ehe), 0f, 0f, true, #Tje, #yMe, #zMe, -0.5f);
			}
			return new #S0e(#RMe.#Bpb(num3, #Ehe), #RMe.#Cpb(num3, #Ehe), #RMe.#Bpb(num2, #Ehe), #RMe.#Cpb(num2, #Ehe), 0f, 0f, true, #Tje, #yMe, #zMe, -1f);
		}

		// Token: 0x06009F78 RID: 40824 RVA: 0x0021D8D8 File Offset: 0x0021BAD8
		public unsafe #a1e #GMe(float #ivb, float #Udb)
		{
			float num = #xke.#fke(10f, 30f);
			float num2 = -#xke.#fke(10f, 30f);
			if (this.#HMe(#ivb))
			{
				return new #a1e(num, num2, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0);
			}
			float #d1e = 0f;
			float #f1e = 0f;
			float #g1e = 0f;
			float #e1e = 0f;
			float #h1e = 0f;
			float #j1e = 0f;
			float #k1e = 0f;
			float #i1e = 0f;
			float* ptr = stackalloc float[(UIntPtr)144];
			float* #LMe = stackalloc float[(UIntPtr)144];
			float* ptr2 = stackalloc float[(UIntPtr)144];
			float* ptr3 = stackalloc float[(UIntPtr)144];
			float* ptr4 = stackalloc float[(UIntPtr)144];
			float* ptr5 = stackalloc float[(UIntPtr)144];
			float* ptr6 = stackalloc float[(UIntPtr)144];
			this.#IMe(#ivb, ptr, #LMe, ptr2, ptr3, ptr4, ptr5, ptr6);
			int num3 = 0;
			float num4 = #Udb * 3.1415927f / 180f;
			for (int i = 0; i < 36; i++)
			{
				int num5 = (i == 35) ? 0 : (i + 1);
				float num6 = ptr2[i];
				float num7 = ptr2[num5];
				float num8 = ptr3[i];
				float num9 = ptr3[num5];
				float num10 = ptr[i];
				float num11 = ptr[num5];
				float num12 = ptr4[i];
				float num13 = ptr4[num5];
				float num14 = ptr5[i];
				float num15 = ptr5[num5];
				float num16 = ptr6[i];
				float num17 = ptr6[num5];
				float num18 = (float)((double)num14 * Math.Cos((double)num4) + (double)num16 * Math.Sin((double)num4));
				float num19 = (float)((double)(-(double)num14) * Math.Sin((double)num4) + (double)num16 * Math.Cos((double)num4));
				float num20 = (float)((double)num15 * Math.Cos((double)num4) + (double)num17 * Math.Sin((double)num4));
				float num21 = (float)((double)(-(double)num15) * Math.Sin((double)num4) + (double)num17 * Math.Cos((double)num4));
				num19 = #RMe.#FMe(num19);
				num21 = #RMe.#FMe(num21);
				if ((num19 > 0f && num21 < 0f) || (num21 > 0f && num19 < 0f))
				{
					float num22 = (num18 * num21 - num20 * num19) / (num21 - num19);
					float num23 = (num6 * num21 - num7 * num19) / (num21 - num19);
					float num24 = (num8 * num21 - num9 * num19) / (num21 - num19);
					float num25 = (num10 * num21 - num11 * num19) / (num21 - num19);
					float num26 = (num12 * num21 - num13 * num19) / (num21 - num19);
					if (num22 > num2)
					{
						num2 = num22;
						#d1e = num23;
						#f1e = num25;
						#g1e = num26;
						#e1e = num24;
					}
					if (num22 < num)
					{
						num = num22;
						#h1e = num23;
						#i1e = num24;
						#j1e = num25;
						#k1e = num26;
					}
					num3++;
				}
			}
			if (num3 == 0)
			{
				num2 = 0f;
				num = 0f;
				#d1e = 0f;
				#f1e = 0f;
			}
			return new #a1e(num, num2, #d1e, #e1e, #f1e, #g1e, #h1e, #i1e, #j1e, #k1e, num3);
		}

		// Token: 0x06009F79 RID: 40825 RVA: 0x0007D53E File Offset: 0x0007B73E
		private static float #Cpb(float #CMe, float #Ehe)
		{
			return (float)((double)#CMe * Math.Sin((double)#Ehe));
		}

		// Token: 0x06009F7A RID: 40826 RVA: 0x0007D54B File Offset: 0x0007B74B
		private static float #Bpb(float #CMe, float #Ehe)
		{
			return (float)((double)#CMe * Math.Cos((double)#Ehe));
		}

		// Token: 0x06009F7B RID: 40827 RVA: 0x0007D558 File Offset: 0x0007B758
		private static float #DMe(float #cpb)
		{
			if (#cpb < 0.0001f && #cpb > -0.0001f)
			{
				return -0.0001f;
			}
			return #cpb;
		}

		// Token: 0x06009F7C RID: 40828 RVA: 0x0007D571 File Offset: 0x0007B771
		private static float #EMe(float #cpb)
		{
			if (#cpb < 0.0001f && #cpb > -0.0001f)
			{
				return 0.0001f;
			}
			return #cpb;
		}

		// Token: 0x06009F7D RID: 40829 RVA: 0x0007D58A File Offset: 0x0007B78A
		private static float #FMe(float #cpb)
		{
			if (#cpb >= 0f && #cpb < 0.0001f)
			{
				return 0.0001f;
			}
			if (#cpb < 0f && #cpb > -0.0001f)
			{
				return -0.0001f;
			}
			return #cpb;
		}

		// Token: 0x06009F7E RID: 40830 RVA: 0x0007D5B9 File Offset: 0x0007B7B9
		private bool #HMe(float #ivb)
		{
			return #xke.#hke(#ivb - this.AxialLoads.Maximum) <= 0.0001f || #xke.#hke(#ivb - this.AxialLoads.Minimum) <= 0.0001f;
		}

		// Token: 0x06009F7F RID: 40831 RVA: 0x0021DBFC File Offset: 0x0021BDFC
		private unsafe void #IMe(float #JMe, float* #KMe, float* #LMe, float* #MMe, float* #NMe, float* #OMe, float* #PMe, float* #QMe)
		{
			#RMe.#9Vb #9Vb = new #RMe.#9Vb();
			#9Vb.#a = this;
			#9Vb.#b = 0f;
			float #2je = this.MaterialProperties.Eyt;
			float #USe = this.ReductionFactors.B;
			float #f8e = this.ReductionFactors.C;
			float num = 10f;
			float[] array = this.Depth.OfReinforcement;
			for (int i = 0; i < 36; i++)
			{
				this.#g.#Zub(#9Vb.#b);
				this.#d.#bpb(#9Vb.#b);
				#6Re #6Re = this.#e;
				Func<float, #D2e> #SPe;
				if ((#SPe = #9Vb.#c) == null)
				{
					#SPe = (#9Vb.#c = new Func<float, #D2e>(#9Vb.#Qgf));
				}
				#r1e #r1e = #6Re.#bpb(#JMe, #SPe, 2);
				float num2 = this.#h.#dYe(#r1e.BarUltimateStrainEpsilon, #2je, #USe, #f8e);
				#KMe[i] = #r1e.BarUltimateStrainEpsilon;
				#LMe[i] = num2;
				#MMe[i] = #r1e.DepthOfNeutralAxisC;
				#NMe[i] = #9Vb.#b;
				#OMe[i] = array[2];
				#PMe[i] = #r1e.ColumnLoad.MomentX;
				#QMe[i] = #r1e.ColumnLoad.MomentY;
				#9Vb.#b += num;
			}
		}

		// Token: 0x04004598 RID: 17816
		private const float #a = 0.0001f;

		// Token: 0x04004599 RID: 17817
		private readonly #fMe #b;

		// Token: 0x0400459A RID: 17818
		private readonly InputModel #c;

		// Token: 0x0400459B RID: 17819
		private readonly #VPe #d;

		// Token: 0x0400459C RID: 17820
		private readonly #6Re #e;

		// Token: 0x0400459D RID: 17821
		private readonly RuntimeModel #f;

		// Token: 0x0400459E RID: 17822
		private readonly #nUe #g;

		// Token: 0x0400459F RID: 17823
		private readonly #38e #h;

		// Token: 0x02001298 RID: 4760
		[CompilerGenerated]
		private sealed class #9Vb
		{
			// Token: 0x06009F81 RID: 40833 RVA: 0x0007D5F2 File Offset: 0x0007B7F2
			internal #D2e #Qgf(float #5Gb)
			{
				return this.#a.#b.#8Le(#5Gb, this.#b);
			}

			// Token: 0x040045A0 RID: 17824
			public #RMe #a;

			// Token: 0x040045A1 RID: 17825
			public float #b;

			// Token: 0x040045A2 RID: 17826
			public Func<float, #D2e> #c;
		}
	}
}
