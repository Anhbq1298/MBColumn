using System;
using #hZe;
using #wUe;
using #X7e;
using #z5e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #gMe
{
	// Token: 0x02001296 RID: 4758
	internal sealed class #vMe
	{
		// Token: 0x06009F66 RID: 40806 RVA: 0x0007D412 File Offset: 0x0007B612
		public #vMe(InputModel #hMe, RuntimeModel #iMe, #6Re #uye, #fMe #wMe, #fNe #xMe, #38e #jMe)
		{
			this.#f = #hMe;
			this.#h = #iMe;
			this.#g = #uye;
			this.#c = #wMe;
			this.#d = #xMe;
			this.#e = #jMe;
		}

		// Token: 0x17002DDA RID: 11738
		// (get) Token: 0x06009F67 RID: 40807 RVA: 0x0007D447 File Offset: 0x0007B647
		private #K2 MaterialProperties
		{
			get
			{
				return this.#f.MaterialProperties;
			}
		}

		// Token: 0x17002DDB RID: 11739
		// (get) Token: 0x06009F68 RID: 40808 RVA: 0x0007D454 File Offset: 0x0007B654
		private Options Options
		{
			get
			{
				return this.#f.Options;
			}
		}

		// Token: 0x17002DDC RID: 11740
		// (get) Token: 0x06009F69 RID: 40809 RVA: 0x0007D461 File Offset: 0x0007B661
		private #Fce ReductionFactors
		{
			get
			{
				return this.#h.ReductionFactors;
			}
		}

		// Token: 0x17002DDD RID: 11741
		// (get) Token: 0x06009F6A RID: 40810 RVA: 0x0007D46E File Offset: 0x0007B66E
		private #x0e GeometryProperties
		{
			get
			{
				return this.#h.GeometryProperties;
			}
		}

		// Token: 0x17002DDE RID: 11742
		// (get) Token: 0x06009F6B RID: 40811 RVA: 0x0007D47B File Offset: 0x0007B67B
		private #YZe ZeroCompression
		{
			get
			{
				return this.#h.ZeroCompression;
			}
		}

		// Token: 0x17002DDF RID: 11743
		// (get) Token: 0x06009F6C RID: 40812 RVA: 0x0007D488 File Offset: 0x0007B688
		private #YZe BalancedCondition
		{
			get
			{
				return this.#h.BalancedCondition;
			}
		}

		// Token: 0x06009F6D RID: 40813 RVA: 0x0021D4CC File Offset: 0x0021B6CC
		public BiCurve[] #nMe()
		{
			#vZe #vZe = this.#d.#bpb();
			float #sMe = #vZe.Maximum / 49f;
			float num = this.ReductionFactors.#E1e(this.#f, this.#h, this.#e) * #vZe.Maximum;
			float num2 = this.ReductionFactors.Trans * this.MaterialProperties.Fcp * this.GeometryProperties.Ag / this.Options.#65e();
			BiCurve[] array = #vje.#sje<BiCurve>(70);
			for (int i = 0; i < 50; i++)
			{
				float #rMe = #vMe.#tMe(#vZe, i);
				if (#vMe.#pMe(num, #rMe, #sMe))
				{
					#rMe = num;
					num = -99.9f;
				}
				else if (#vMe.#pMe(num2, #rMe, #sMe))
				{
					#rMe = num2;
					num2 = -99.9f;
				}
				array[i].AxialLoad = #rMe;
			}
			array[0].AxialLoad = #vZe.Maximum;
			for (int j = 0; j < 20; j++)
			{
				array[50 + j].AxialLoad = #vZe.Minimum * (float)(j + 1) / 20f;
			}
			return array;
		}

		// Token: 0x06009F6E RID: 40814 RVA: 0x0021D5E4 File Offset: 0x0021B7E4
		public UniCurve[] #oMe()
		{
			#vZe #vZe = this.#d.#bpb();
			float num = this.#uMe();
			float #sMe = #vZe.Maximum / 49f;
			float num2 = this.ReductionFactors.#E1e(this.#f, this.#h, this.#e) * #vZe.Maximum;
			float num3 = num;
			UniCurve[] array = #vje.#sje<UniCurve>(70);
			for (int i = 0; i < 50; i++)
			{
				float #rMe = #vMe.#tMe(#vZe, i);
				if (#vMe.#pMe(num2, #rMe, #sMe))
				{
					#rMe = num2;
					num2 = -99.9f;
				}
				else if (#vMe.#pMe(num3, #rMe, #sMe))
				{
					#rMe = num3;
					num3 = -99.9f;
				}
				array[i].AxialLoad = #rMe;
			}
			array[0].AxialLoad = #vZe.Maximum;
			for (int j = 0; j < 20; j++)
			{
				array[50 + j].AxialLoad = #vZe.Minimum * (float)(j + 1) / 20f;
			}
			return array;
		}

		// Token: 0x06009F6F RID: 40815 RVA: 0x0007D495 File Offset: 0x0007B695
		private static bool #pMe(float #qMe, float #rMe, float #sMe)
		{
			return #qMe >= 0f && #qMe < #rMe + 0.5f * #sMe && #qMe > #rMe - 0.5f * #sMe;
		}

		// Token: 0x06009F70 RID: 40816 RVA: 0x0007D4B9 File Offset: 0x0007B6B9
		private static float #tMe(#vZe #tk, int #4jb)
		{
			return #tk.Maximum * (float)(49 - #4jb) / 49f;
		}

		// Token: 0x06009F71 RID: 40817 RVA: 0x0021D6D4 File Offset: 0x0021B8D4
		private float #uMe()
		{
			float num = this.#e.#Y7e(this.ReductionFactors.Trans, this.MaterialProperties.Fcp, this.GeometryProperties.Ag, this.Options.#65e(), this.BalancedCondition.AxialLoad);
			if (num <= 0f)
			{
				return this.ZeroCompression.AxialLoad;
			}
			return this.#g.#bpb(num, new Func<float, #D2e>(this.#c.#6Le), 2).ColumnLoad.AxialLoad;
		}

		// Token: 0x04004590 RID: 17808
		private const int #a = 50;

		// Token: 0x04004591 RID: 17809
		private const int #b = 20;

		// Token: 0x04004592 RID: 17810
		private readonly #fMe #c;

		// Token: 0x04004593 RID: 17811
		private readonly #fNe #d;

		// Token: 0x04004594 RID: 17812
		private readonly #38e #e;

		// Token: 0x04004595 RID: 17813
		private readonly InputModel #f;

		// Token: 0x04004596 RID: 17814
		private readonly #6Re #g;

		// Token: 0x04004597 RID: 17815
		private readonly RuntimeModel #h;
	}
}
