using System;
using #12e;
using #g7e;
using #gMe;
using #hZe;
using #X7e;
using #y6e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #vYe
{
	// Token: 0x02001312 RID: 4882
	internal sealed class #JYe : #EYe
	{
		// Token: 0x0600A32E RID: 41774 RVA: 0x0007F788 File Offset: 0x0007D988
		public #JYe(InputModel #hMe, #l4e #Kwe, RuntimeModel #iMe, #3Qe #IXe, CriticalCapacity #XMe, #fNe #xMe, #38e #jMe) : base(#hMe, #Kwe, #iMe, #IXe, #XMe, #xMe, #jMe)
		{
		}

		// Token: 0x17002ECA RID: 11978
		// (get) Token: 0x0600A32F RID: 41775 RVA: 0x0007F895 File Offset: 0x0007DA95
		public #C6e ConsideredAxis
		{
			get
			{
				return this.#b.Options.ConsideredAxis;
			}
		}

		// Token: 0x0600A330 RID: 41776 RVA: 0x0022DB6C File Offset: 0x0022BD6C
		public override void #sWe()
		{
			float #Tje = 0f;
			float #yMe = 0f;
			float #zMe = 0f;
			#vZe #uZe = this.#a.#bpb();
			this.#f.AxialLoads.#tZe(#uZe);
			#VMe #VMe = new #VMe(this.#c, this.#d);
			#y0e #y0e = null;
			#x6e #TMe = this.#b.Options.CapacityCalculationType;
			LoadsExt[] array = this.#f.FactoredLoads.Loads;
			for (int i = 0; i < this.#f.FactoredLoads.NumberOfLoads; i++)
			{
				if (this.#b.Options.ProblemType == #z6e.#a || !this.#f.RunFlag.HasFlag(#J6e.#a))
				{
					this.#f.MessageBus.#76e(#q7e.#Mif.#c, i + 1, this.#f.FactoredLoads.NumberOfLoads);
				}
				#y0e = (#y0e ?? #VMe.#YJe(#TMe));
				#S0e #S0e = #VMe.#bpb(#y0e, #TMe, array[i], #Tje, #yMe, #zMe);
				#Tje = #S0e.BarMaximumStrain;
				#yMe = #S0e.NeutralAxisDepth;
				#zMe = #S0e.TensionDistance;
				#u3e.#zif #XXe = base.#CYe(#S0e);
				float #FYe = (this.ConsideredAxis == #C6e.#a) ? array[i].MomentX : array[i].MomentY;
				if (#S0e.UltimateSafeFactor >= 0f)
				{
					this.#sYe(#S0e, i, #FYe, #XXe, array[i]);
				}
				else
				{
					this.#rYe(#S0e, i, #FYe, #XXe, array[i]);
				}
			}
			base.#cYe();
			base.#DYe();
		}

		// Token: 0x0600A331 RID: 41777 RVA: 0x0022DD08 File Offset: 0x0022BF08
		private void #rYe(#S0e #WXe, int #4jb, float #FYe, #u3e.#zif #XXe, LoadsExt #ivb)
		{
			if (#WXe.Success)
			{
				float #y8e = this.#HYe(#WXe);
				float #z8e = this.#GYe(#WXe);
				this.#g.#x8e(this.#e, #WXe, #4jb, #FYe, #XXe, #ivb, #y8e, #z8e, base.MaterialPropertiesEyt, base.ReductionFactors);
				return;
			}
			#u3e.#Aif? error = this.#IYe(#ivb.AxialLoad);
			UniaxialFactoredLoad #d4e = new UniaxialFactoredLoad(new int?(#4jb + 1), new float?(#ivb.AxialLoad), new float?(#FYe), new #u3e.#zif?(#XXe), error);
			this.#e.#vzc(#d4e);
		}

		// Token: 0x0600A332 RID: 41778 RVA: 0x0007F8A7 File Offset: 0x0007DAA7
		private float #GYe(#S0e #WXe)
		{
			if (this.ConsideredAxis != #C6e.#a)
			{
				return #WXe.UltimateMaxMomentY;
			}
			return #WXe.UltimateMaxMomentX;
		}

		// Token: 0x0600A333 RID: 41779 RVA: 0x0007F8BE File Offset: 0x0007DABE
		private float #HYe(#S0e #WXe)
		{
			if (this.ConsideredAxis != #C6e.#a)
			{
				return #WXe.UltimateMinMomentY;
			}
			return #WXe.UltimateMinMomentX;
		}

		// Token: 0x0600A334 RID: 41780 RVA: 0x0022DD98 File Offset: 0x0022BF98
		private void #sYe(#S0e #WXe, int #4jb, float #FYe, #u3e.#zif #XXe, LoadsExt #ivb)
		{
			float #lYe = (this.ConsideredAxis == #C6e.#a) ? #WXe.UltimateMomentX : #WXe.UltimateMomentY;
			this.#g.#A8e(#WXe, #4jb, #FYe, #XXe, #ivb, #lYe, this.#e, base.MaterialPropertiesEyt, base.ReductionFactors);
		}

		// Token: 0x0600A335 RID: 41781 RVA: 0x0007F8D5 File Offset: 0x0007DAD5
		private #u3e.#Aif? #IYe(float #wWe)
		{
			if (#wWe >= 0f)
			{
				base.ShouldOutputPmax = true;
				return this.#g.#K8e();
			}
			base.ShouldOutputPmin = true;
			return this.#g.#J8e();
		}
	}
}
