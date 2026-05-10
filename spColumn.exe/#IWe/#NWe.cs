using System;
using #12e;
using #hZe;
using #X7e;
using #z5e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #IWe
{
	// Token: 0x020012FA RID: 4858
	internal sealed class #NWe
	{
		// Token: 0x0600A281 RID: 41601 RVA: 0x0007F1BA File Offset: 0x0007D3BA
		public #NWe(#l4e #Kwe, InputModel #hMe, RuntimeModel #iMe, #38e #jMe)
		{
			this.#b = #Kwe;
			this.#a = #hMe;
			this.#c = #iMe;
			this.#d = #jMe;
		}

		// Token: 0x17002EA8 RID: 11944
		// (get) Token: 0x0600A282 RID: 41602 RVA: 0x0007F1DF File Offset: 0x0007D3DF
		private #i5e OutputVariables
		{
			get
			{
				return this.#b.Variables;
			}
		}

		// Token: 0x17002EA9 RID: 11945
		// (get) Token: 0x0600A283 RID: 41603 RVA: 0x0007F1EC File Offset: 0x0007D3EC
		private #x0e GeometryProperties
		{
			get
			{
				return this.#c.GeometryProperties;
			}
		}

		// Token: 0x17002EAA RID: 11946
		// (get) Token: 0x0600A284 RID: 41604 RVA: 0x0007F1F9 File Offset: 0x0007D3F9
		private #K2 MaterialProperties
		{
			get
			{
				return this.#a.MaterialProperties;
			}
		}

		// Token: 0x0600A285 RID: 41605 RVA: 0x0007F206 File Offset: 0x0007D406
		public void #sWe()
		{
			this.#MWe();
			this.#LWe();
			this.#KWe();
		}

		// Token: 0x0600A286 RID: 41606 RVA: 0x0022B424 File Offset: 0x00229624
		private void #KWe()
		{
			float #f = this.#c.ReductionFactors.#E1e(this.#a, this.#c, this.#d);
			this.OutputVariables.RedFactPhiA = #f;
			this.OutputVariables.RedFactPhiB = this.#c.ReductionFactors.B;
			this.OutputVariables.RedFactPhiC = this.#c.ReductionFactors.C;
			this.#d.#t8e(this.OutputVariables, this.GeometryProperties.Rho, this.#a, this.#c.NominalInteraction);
			this.OutputVariables.SectionPropTotalSteelArea = new float?(this.GeometryProperties.AreaOfSteel);
			this.OutputVariables.SectionPropRho = new float?(this.GeometryProperties.Rho);
			this.OutputVariables.MinSectionDimension = new float?(this.#d.#R8e(this.#a.Options.SectionType, this.#c.SectionDimensionsForInvestigate, this.#c.ReductionFactors.MinDimension));
			this.OutputVariables.IsColumnArchitectural = this.#a.Options.IsColumnConsideredArchitectural;
		}

		// Token: 0x0600A287 RID: 41607 RVA: 0x0022B55C File Offset: 0x0022975C
		private void #LWe()
		{
			this.OutputVariables.SectionPropAg = this.GeometryProperties.Ag;
			this.OutputVariables.SectionPropIx = this.GeometryProperties.SecondMomentOfInertia[0];
			this.OutputVariables.SectionPropIy = this.GeometryProperties.SecondMomentOfInertia[1];
			this.OutputVariables.SectionPropRx = this.GeometryProperties.RadiusOfGyration[0];
			this.OutputVariables.SectionPropRy = this.GeometryProperties.RadiusOfGyration[1];
			this.OutputVariables.SectionPropX0 = this.GeometryProperties.Ybar[0];
			this.OutputVariables.SectionPropY0 = this.GeometryProperties.Ybar[1];
			this.OutputVariables.MinRebarSpacing = this.GeometryProperties.Space;
		}

		// Token: 0x0600A288 RID: 41608 RVA: 0x0022B628 File Offset: 0x00229828
		private void #MWe()
		{
			this.OutputVariables.ConcreteType = (this.MaterialProperties.IsConcreteStandard ? #r4e.#a : #r4e.#b);
			this.OutputVariables.SteelType = (this.MaterialProperties.IsSteelStandard ? #s4e.#a : #s4e.#b);
			this.OutputVariables.ConcreteFcp = this.MaterialProperties.Fcp;
			this.OutputVariables.SteelFy = this.MaterialProperties.Fy;
			this.OutputVariables.ConcreteEc = this.MaterialProperties.Ec;
			this.OutputVariables.SteelEs = this.MaterialProperties.Es;
			this.OutputVariables.ConcreteFc = this.MaterialProperties.Fc;
			this.OutputVariables.SteelEpsYt = this.MaterialProperties.Eyt;
			this.OutputVariables.ConcreteEpsU = this.MaterialProperties.Eps;
			this.OutputVariables.ConcreteBeta1 = this.MaterialProperties.Beta1;
		}

		// Token: 0x04004728 RID: 18216
		private readonly InputModel #a;

		// Token: 0x04004729 RID: 18217
		private readonly #l4e #b;

		// Token: 0x0400472A RID: 18218
		private readonly RuntimeModel #c;

		// Token: 0x0400472B RID: 18219
		private readonly #38e #d;
	}
}
