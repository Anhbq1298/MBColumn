using System;
using #12e;
using #g7e;
using #IWe;
using #KUe;
using #X7e;
using #y6e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Enums;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #gMe
{
	// Token: 0x020012D8 RID: 4824
	internal sealed class #WTe
	{
		// Token: 0x0600A14B RID: 41291 RVA: 0x00226CC4 File Offset: 0x00224EC4
		public #WTe(InputModel #hMe, RuntimeModel #iMe, #l4e #Kwe, #dTe #XTe, #BNe #YTe, #6Re #uye, DepthComputation #ZTe, #ISe #0Te, #nUe #pge, Section #bLb, #8Ue #1Te, #fMe #wMe, #VPe #SMe, #jQe #2Te, #fNe #xMe, #38e #jMe)
		{
			this.#d = #hMe;
			this.#i = #iMe;
			this.#h = #XTe;
			this.#a = #YTe;
			this.#b = #ZTe;
			this.#g = #0Te;
			this.#l = #pge;
			this.#j = #bLb;
			this.#c = #1Te;
			this.#f = #2Te;
			this.#m = #jMe;
			this.#k = this.#m.#J7e(#Kwe, #iMe);
			this.#e = new #1Oe(#hMe, #iMe, #uye, #wMe, #pge, #SMe, #xMe, #jMe);
		}

		// Token: 0x0600A14C RID: 41292 RVA: 0x00226D5C File Offset: 0x00224F5C
		public bool #PTe()
		{
			this.#i.DiagramsCache.#yl();
			#nW #nW = this.#i.MessageBus;
			if (!#nW.#66e())
			{
				return false;
			}
			#nW.#76e(#q7e.#Mif.#a);
			float #Udb = (this.#d.Options.ConsideredAxis == #C6e.#b) ? 90f : 0f;
			this.#i.Fc = this.#m.#p8e(this.#d.MaterialProperties.Fc, this.#i.ReductionFactors.C);
			bool result;
			if (this.#d.Options.ProblemType == #z6e.#b)
			{
				this.#i.Solids.#yl();
				result = this.#STe(#Udb);
			}
			else
			{
				result = this.#QTe(#Udb);
			}
			return result;
		}

		// Token: 0x0600A14D RID: 41293 RVA: 0x00226E24 File Offset: 0x00225024
		public void #tOe()
		{
			if (this.#d.Options.ProblemType == #z6e.#b)
			{
				Options options = this.#d.Options;
				options.ReinforcementType[0] = options.ReinforcementType[1];
				options.ClearCover[0] = options.ClearCover[1];
				float[] array = this.#d.DesignDimensions;
				float[] array2 = this.#d.DesignReinforcement.ClearCover;
				this.#i.SectionDimensionsForInvestigate[0] = array[0];
				this.#i.SectionDimensionsForInvestigate[1] = array[1];
				this.#i.InvestigateReinforcement.ClearCover[0] = array2[0];
				this.#i.InvestigateReinforcement.ClearCover[1] = array2[1];
				this.#i.InvestigateReinforcement.ClearCover[2] = array2[2];
				this.#i.InvestigateReinforcement.ClearCover[3] = array2[3];
				if (this.#d.Options.ReinforcementType[1] != ReinforcementType.Different)
				{
					int num = this.#d.DesignReinforcement.BarNumber[0];
					int num2 = this.#d.DesignReinforcement.AmountOfBars[0];
					this.#i.InvestigateReinforcement.BarNumber[0] = num;
					this.#i.InvestigateReinforcement.AmountOfBars[0] = num2;
				}
				else
				{
					int #HUe = this.#d.DesignReinforcement.AmountOfBars[0];
					int #IUe = this.#d.DesignReinforcement.AmountOfBars[2];
					int num3 = this.#d.DesignReinforcement.BarNumber[0];
					this.#i.InvestigateReinforcement.#oSe(num3);
					this.#i.InvestigateReinforcement.#z0e(#HUe, #IUe);
				}
				this.#a.#bpb();
			}
			this.#g.#tOe();
		}

		// Token: 0x0600A14E RID: 41294 RVA: 0x00226FE4 File Offset: 0x002251E4
		private bool #QTe(float #Udb)
		{
			this.#g.#tOe();
			this.#a.#bpb(this.#d.Options.SectionType);
			this.#h.#bpb(false);
			this.#b.#gOe(#C6e.#a);
			this.#b.#gOe(#C6e.#b);
			if (this.#d.Options.ConsideredAxis != #C6e.#c)
			{
				this.#l.#Zub(#Udb);
			}
			this.#RTe();
			#L6e #PE = this.#f.#1Pe();
			return this.#TTe(#Udb, #PE);
		}

		// Token: 0x0600A14F RID: 41295 RVA: 0x00227074 File Offset: 0x00225274
		private void #RTe()
		{
			#B6e #c = (this.#d.Options.ProblemType == #z6e.#b) ? this.#d.Options.ColumnType : (this.#d.Options.IsColumnConsideredArchitectural ? #B6e.#b : #B6e.#a);
			this.#i.Fc = this.#m.#WSe(this.#d.MaterialProperties.Fc, this.#i.ReductionFactors.C, #c, this.#i.GeometryProperties.Rho);
		}

		// Token: 0x0600A150 RID: 41296 RVA: 0x00227104 File Offset: 0x00225304
		private bool #STe(float #Udb)
		{
			int #PE = this.#c.#TUe(#Udb);
			return this.#TTe(#Udb, (#L6e)#PE);
		}

		// Token: 0x0600A151 RID: 41297 RVA: 0x00227128 File Offset: 0x00225328
		private bool #TTe(float #Udb, #L6e #PE)
		{
			this.#k.#qXe(#PE);
			bool flag = this.#UTe(#PE);
			if (flag)
			{
				this.#i.FactoredInteractionDiagram = (this.#i.FactoredInteractionDiagram ?? this.#e.#YJe());
				if (this.#i.FactoredInteractionDiagram != null && this.#i.RunFlag.HasFlag(#J6e.#b))
				{
					#kSe #kSe = new #kSe(this.#e, this.#i, this.#d);
					this.#i.NominalInteractionDiagram = #kSe.#ul();
				}
			}
			this.#j.#mTe(flag, #Udb);
			return flag;
		}

		// Token: 0x0600A152 RID: 41298 RVA: 0x0007E843 File Offset: 0x0007CA43
		private bool #UTe(#L6e #VTe)
		{
			return (!#VTe.HasFlag(#L6e.#f) || !this.#m.#F7e()) && !#VTe.HasFlag(#L6e.#e);
		}

		// Token: 0x04004691 RID: 18065
		private readonly #BNe #a;

		// Token: 0x04004692 RID: 18066
		private readonly DepthComputation #b;

		// Token: 0x04004693 RID: 18067
		private readonly #8Ue #c;

		// Token: 0x04004694 RID: 18068
		private readonly InputModel #d;

		// Token: 0x04004695 RID: 18069
		private readonly #1Oe #e;

		// Token: 0x04004696 RID: 18070
		private readonly #jQe #f;

		// Token: 0x04004697 RID: 18071
		private readonly #ISe #g;

		// Token: 0x04004698 RID: 18072
		private readonly #dTe #h;

		// Token: 0x04004699 RID: 18073
		private readonly RuntimeModel #i;

		// Token: 0x0400469A RID: 18074
		private readonly Section #j;

		// Token: 0x0400469B RID: 18075
		private readonly #rXe #k;

		// Token: 0x0400469C RID: 18076
		private readonly #nUe #l;

		// Token: 0x0400469D RID: 18077
		private readonly #38e #m;
	}
}
