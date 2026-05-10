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
	// Token: 0x0200130F RID: 4879
	internal sealed class #uYe : #EYe
	{
		// Token: 0x0600A31C RID: 41756 RVA: 0x0007F788 File Offset: 0x0007D988
		public #uYe(InputModel #hMe, #l4e #Kwe, RuntimeModel #iMe, #3Qe #IXe, CriticalCapacity #XMe, #fNe #xMe, #38e #jMe) : base(#hMe, #Kwe, #iMe, #IXe, #XMe, #xMe, #jMe)
		{
		}

		// Token: 0x0600A31D RID: 41757 RVA: 0x0022D7CC File Offset: 0x0022B9CC
		public override void #sWe()
		{
			float #Tje = 0f;
			float #yMe = 0f;
			float #zMe = 0f;
			#vZe #uZe = this.#a.#bpb();
			this.#f.AxialLoads.#tZe(#uZe);
			#VMe #VMe = new #VMe(this.#c, this.#d);
			LoadsExt[] array = this.#f.FactoredLoads.Loads;
			#y0e #y0e = null;
			#x6e #TMe = this.#b.Options.CapacityCalculationType;
			for (int i = 0; i < this.#f.FactoredLoads.NumberOfLoads; i++)
			{
				if (this.#b.Options.ProblemType == #z6e.#a || !this.#f.RunFlag.HasFlag(#J6e.#a))
				{
					this.#f.MessageBus.#76e(#q7e.#Mif.#c, i + 1, this.#f.FactoredLoads.NumberOfLoads);
				}
				#y0e = (#y0e ?? #VMe.#YJe(#TMe));
				LoadsExt loadsExt = array[i];
				#VMe.#MWi(this.#f.FactoredInteractionDiagram, (double)loadsExt.MomentX, (double)loadsExt.MomentY);
				#S0e #S0e = #VMe.#bpb(#y0e, #TMe, loadsExt, #Tje, #yMe, #zMe);
				#Tje = #S0e.BarMaximumStrain;
				#yMe = #S0e.NeutralAxisDepth;
				#zMe = #S0e.TensionDistance;
				#u3e.#zif #XXe = base.#CYe(#S0e);
				if (#S0e.UltimateSafeFactor >= 0f)
				{
					this.#sYe(#S0e, i, #XXe, loadsExt);
				}
				else
				{
					this.#rYe(#S0e, i, #XXe, loadsExt);
				}
			}
			base.#cYe();
			base.#DYe();
		}

		// Token: 0x0600A31E RID: 41758 RVA: 0x0022D964 File Offset: 0x0022BB64
		private void #rYe(#S0e #Rfb, int #4jb, #u3e.#zif #XXe, LoadsExt #ivb)
		{
			if (#Rfb.Success)
			{
				this.#g.#v8e(this.#e, #Rfb, #4jb, #XXe, #ivb, base.MaterialPropertiesEyt, base.ReductionFactors);
				return;
			}
			#u3e.#yif? error = this.#tYe(#Rfb, #ivb.AxialLoad);
			BiaxialFactoredLoad #e4e = new BiaxialFactoredLoad(new int?(#4jb + 1), new float?(#ivb.AxialLoad), new float?(#ivb.MomentX), new float?(#ivb.MomentY), new #u3e.#zif?(#XXe), error);
			this.#e.#vzc(#e4e);
		}

		// Token: 0x0600A31F RID: 41759 RVA: 0x0007F79B File Offset: 0x0007D99B
		private void #sYe(#S0e #Rfb, int #4jb, #u3e.#zif #XXe, LoadsExt #ivb)
		{
			this.#g.#w8e(this.#e, #Rfb, #4jb, #XXe, #ivb, base.MaterialPropertiesEyt, base.ReductionFactors);
		}

		// Token: 0x0600A320 RID: 41760 RVA: 0x0022D9F0 File Offset: 0x0022BBF0
		private #u3e.#yif? #tYe(#S0e #WXe, float #wWe)
		{
			if (#WXe.UltimateSafeFactor < -0.1001f)
			{
				return this.#g.#I8e();
			}
			if (#wWe >= 0f)
			{
				base.ShouldOutputPmax = true;
				return this.#g.#H8e();
			}
			base.ShouldOutputPmin = true;
			return this.#g.#G8e();
		}
	}
}
