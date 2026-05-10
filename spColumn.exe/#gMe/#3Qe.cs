using System;
using System.Runtime.CompilerServices;
using #hZe;
using #wUe;
using #X7e;
using #y6e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #gMe
{
	// Token: 0x020012C2 RID: 4802
	internal sealed class #3Qe
	{
		// Token: 0x0600A0CD RID: 41165 RVA: 0x00223BD8 File Offset: 0x00221DD8
		public #3Qe(InputModel #hMe, RuntimeModel #iMe, #6Re #uye, #nUe #pge, #VPe #SMe, #fMe #wMe, #38e #jMe)
		{
			this.#a = #hMe;
			this.#b = #iMe;
			this.#c = #jMe;
			this.UniaxialMomentCapacity = new #vUe(#hMe, #iMe, #uye, #pge, #SMe, #wMe);
			this.BiaxialMomentCapacity = new #RMe(#hMe, #iMe, #uye, #pge, #SMe, #wMe, #jMe);
		}

		// Token: 0x17002E4C RID: 11852
		// (get) Token: 0x0600A0CE RID: 41166 RVA: 0x0007E320 File Offset: 0x0007C520
		private #vZe AxialLoads
		{
			get
			{
				return this.#b.AxialLoads;
			}
		}

		// Token: 0x17002E4D RID: 11853
		// (get) Token: 0x0600A0CF RID: 41167 RVA: 0x0007E32D File Offset: 0x0007C52D
		private Options Options
		{
			get
			{
				return this.#a.Options;
			}
		}

		// Token: 0x17002E4E RID: 11854
		// (get) Token: 0x0600A0D0 RID: 41168 RVA: 0x0007E33A File Offset: 0x0007C53A
		private #Fce ReductionFactors
		{
			get
			{
				return this.#b.ReductionFactors;
			}
		}

		// Token: 0x17002E4F RID: 11855
		// (get) Token: 0x0600A0D1 RID: 41169 RVA: 0x0007E347 File Offset: 0x0007C547
		public #vUe UniaxialMomentCapacity { get; }

		// Token: 0x17002E50 RID: 11856
		// (get) Token: 0x0600A0D2 RID: 41170 RVA: 0x0007E34F File Offset: 0x0007C54F
		public #RMe BiaxialMomentCapacity { get; }

		// Token: 0x0600A0D3 RID: 41171 RVA: 0x00223C2C File Offset: 0x00221E2C
		public #S0e #WQe(LoadsExt #ivb, float #Tje, float #yMe, float #zMe, bool #XQe = false)
		{
			float #AMe = 0f;
			float #BMe = 0f;
			if (this.#1Qe(#ivb, #XQe))
			{
				return new #S0e(0f, 0f, 0f, 0f, 0f, 0f, false, 0f, #yMe, #zMe, -0.1f);
			}
			#3Qe.#0Qe(#ivb, this.Options.ConsideredAxis);
			if (this.Options.ConsideredAxis != #C6e.#c)
			{
				#S0e #S0e = this.UniaxialMomentCapacity.#5W(#ivb, ref #Tje, ref #yMe, ref #zMe, ref #AMe, ref #BMe);
				if (#S0e != null)
				{
					return #S0e;
				}
			}
			else
			{
				#S0e #S0e2 = this.BiaxialMomentCapacity.#5W(#ivb, ref #Tje, ref #yMe, ref #zMe, ref #AMe, ref #BMe);
				if (#S0e2 != null)
				{
					return #S0e2;
				}
			}
			float #lTe = #3Qe.#YQe(#ivb, #AMe, #BMe);
			return new #S0e(0f, 0f, 0f, 0f, #AMe, #BMe, true, #Tje, #yMe, #zMe, #lTe);
		}

		// Token: 0x0600A0D4 RID: 41172 RVA: 0x00223D08 File Offset: 0x00221F08
		private static float #YQe(LoadsExt #ivb, float #AMe, float #BMe)
		{
			float num = 1f / (#xke.#ike(#AMe, #BMe) / #3Qe.#ZQe(#ivb));
			if (num >= 0.001f)
			{
				return num;
			}
			return 0.001f;
		}

		// Token: 0x0600A0D5 RID: 41173 RVA: 0x00223D3C File Offset: 0x00221F3C
		private static float #ZQe(LoadsExt #ivb)
		{
			float num = #xke.#ike(#ivb.MomentX, #ivb.MomentY);
			if (num >= 0.0001f)
			{
				return num;
			}
			return 0.0001f;
		}

		// Token: 0x0600A0D6 RID: 41174 RVA: 0x0007E357 File Offset: 0x0007C557
		private static void #0Qe(LoadsExt #ivb, #C6e #6gb)
		{
			if (#6gb == #C6e.#a)
			{
				#ivb.MomentY = 0f;
				return;
			}
			if (#6gb == #C6e.#b)
			{
				#ivb.MomentX = 0f;
			}
		}

		// Token: 0x0600A0D7 RID: 41175 RVA: 0x00223D6C File Offset: 0x00221F6C
		private bool #1Qe(LoadsExt #ivb, bool #2Qe)
		{
			float num = #2Qe ? 0f : 0.0001f;
			float num2 = this.ReductionFactors.#E1e(this.#a, this.#b, this.#c) * this.AxialLoads.Maximum;
			float num3 = this.AxialLoads.Minimum;
			bool flag = #ivb.AxialLoad > num2 - num && ((#2Qe && #xke.#hke(num2 - #ivb.AxialLoad) < 0.0001f) || !#2Qe);
			bool flag2 = #ivb.AxialLoad < num3 + num && ((#2Qe && #xke.#hke(num3 - #ivb.AxialLoad) < 0.0001f) || !#2Qe);
			return flag || flag2;
		}

		// Token: 0x0400465C RID: 18012
		private readonly InputModel #a;

		// Token: 0x0400465D RID: 18013
		private readonly RuntimeModel #b;

		// Token: 0x0400465E RID: 18014
		private readonly #38e #c;

		// Token: 0x0400465F RID: 18015
		[CompilerGenerated]
		private readonly #vUe #d;

		// Token: 0x04004660 RID: 18016
		[CompilerGenerated]
		private readonly #RMe #e;
	}
}
