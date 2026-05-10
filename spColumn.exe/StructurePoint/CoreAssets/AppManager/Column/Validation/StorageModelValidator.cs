using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using #0be;
using #2be;
using #7hc;
using #npe;
using FluentValidation;
using FluentValidation.Internal;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;

namespace StructurePoint.CoreAssets.AppManager.Column.Validation
{
	// Token: 0x0200102D RID: 4141
	public sealed class StorageModelValidator : #tce<ColumnStorageModel>
	{
		// Token: 0x06008E0F RID: 36367 RVA: 0x001E42A8 File Offset: 0x001E24A8
		public StorageModelValidator(#ice context)
		{
			StorageModelValidator.#GTb #GTb = new StorageModelValidator.#GTb();
			#GTb.#a = context;
			base..ctor(#GTb.#a);
			#GTb.#b = this;
			ParameterExpression parameterExpression = Expression.Parameter(typeof(ColumnStorageModel), #Phc.#3hc(107230552));
			base.RuleFor<ColumnStorageModel>(Expression.Lambda<Func<ColumnStorageModel, ColumnStorageModel>>(parameterExpression, new ParameterExpression[]
			{
				parameterExpression
			})).SetValidator(new CoreModelValidator(#GTb.#a), Array.Empty<string>()).Configure(new Action<PropertyRule>(StorageModelValidator.<>c.<>9.#98e));
			parameterExpression = Expression.Parameter(typeof(ColumnStorageModel), #Phc.#3hc(107230552));
			base.RuleFor<DesignDimensions>(Expression.Lambda<Func<ColumnStorageModel, DesignDimensions>>(Expression.Property(parameterExpression, methodof(ColumnStorageModel.get_DesignDimensions())), new ParameterExpression[]
			{
				parameterExpression
			})).SetValidator(new DesignDimensionsValidator(#GTb.#a), Array.Empty<string>()).When(new Func<ColumnStorageModel, bool>(#GTb.#78e), ApplyConditionTo.AllValidators);
			parameterExpression = Expression.Parameter(typeof(ColumnStorageModel), #Phc.#3hc(107230552));
			base.RuleFor<DesignReinforcement>(Expression.Lambda<Func<ColumnStorageModel, DesignReinforcement>>(Expression.Property(parameterExpression, methodof(ColumnStorageModel.get_DesignReinforcement())), new ParameterExpression[]
			{
				parameterExpression
			})).SetValidator(new DesignReinforcementValidator(#GTb.#a), Array.Empty<string>()).When(new Func<ColumnStorageModel, bool>(#GTb.#88e), ApplyConditionTo.AllValidators);
			parameterExpression = Expression.Parameter(typeof(ColumnStorageModel), #Phc.#3hc(107230552));
			base.RuleFor<InvestigationDimensions>(Expression.Lambda<Func<ColumnStorageModel, InvestigationDimensions>>(Expression.Property(parameterExpression, methodof(ColumnStorageModel.get_InvestigationDimensions())), new ParameterExpression[]
			{
				parameterExpression
			})).SetValidator(new InvestigationDimensionsValidator(#GTb.#a), Array.Empty<string>()).When(new Func<ColumnStorageModel, bool>(#GTb.#h9e), ApplyConditionTo.AllValidators);
			parameterExpression = Expression.Parameter(typeof(ColumnStorageModel), #Phc.#3hc(107230552));
			base.RuleFor<InvestigationReinforcement>(Expression.Lambda<Func<ColumnStorageModel, InvestigationReinforcement>>(Expression.Property(parameterExpression, methodof(ColumnStorageModel.get_InvestigationReinforcement())), new ParameterExpression[]
			{
				parameterExpression
			})).SetValidator(new InvestigationReinforcementValidator(#GTb.#a), Array.Empty<string>()).When(new Func<ColumnStorageModel, bool>(#GTb.#V9e), ApplyConditionTo.AllValidators);
			parameterExpression = Expression.Parameter(typeof(ColumnStorageModel), #Phc.#3hc(107230552));
			base.RuleForEach<ReinforcementBar>(Expression.Lambda<Func<ColumnStorageModel, IEnumerable<ReinforcementBar>>>(Expression.Property(parameterExpression, methodof(ColumnStorageModel.get_ReinforcementBars())), new ParameterExpression[]
			{
				parameterExpression
			})).SetValidator<IrregularReinforcementBarValidator>(new Func<ColumnStorageModel, ReinforcementBar, IrregularReinforcementBarValidator>(#GTb.#W9e), Array.Empty<string>()).When(new Func<ColumnStorageModel, bool>(#GTb.#X9e), ApplyConditionTo.AllValidators);
			parameterExpression = Expression.Parameter(typeof(ColumnStorageModel), #Phc.#3hc(107230552));
			base.RuleFor<ColumnStorageModel>(Expression.Lambda<Func<ColumnStorageModel, ColumnStorageModel>>(parameterExpression, new ParameterExpression[]
			{
				parameterExpression
			})).SetValidator(new IrregularSectionValidator(#GTb.#a), Array.Empty<string>()).When(new Func<ColumnStorageModel, bool>(#GTb.#r9e), ApplyConditionTo.AllValidators);
			parameterExpression = Expression.Parameter(typeof(ColumnStorageModel), #Phc.#3hc(107230552));
			base.RuleFor<MaterialProperties>(Expression.Lambda<Func<ColumnStorageModel, MaterialProperties>>(Expression.Property(parameterExpression, methodof(ColumnStorageModel.get_MaterialProperties())), new ParameterExpression[]
			{
				parameterExpression
			})).SetValidator(new #qZ(#GTb.#a), Array.Empty<string>());
			parameterExpression = Expression.Parameter(typeof(ColumnStorageModel), #Phc.#3hc(107230552));
			base.RuleFor<ReductionFactors>(Expression.Lambda<Func<ColumnStorageModel, ReductionFactors>>(Expression.Property(parameterExpression, methodof(ColumnStorageModel.get_ReductionFactors())), new ParameterExpression[]
			{
				parameterExpression
			})).SetValidator(new ReductionFactorsValidator(#GTb.#a, true), Array.Empty<string>());
			parameterExpression = Expression.Parameter(typeof(ColumnStorageModel), #Phc.#3hc(107230552));
			base.RuleFor<ColumnStorageModel>(Expression.Lambda<Func<ColumnStorageModel, ColumnStorageModel>>(parameterExpression, new ParameterExpression[]
			{
				parameterExpression
			})).SetValidator(new DesignCriteriaValidator(#GTb.#a), Array.Empty<string>()).When(new Func<ColumnStorageModel, bool>(#GTb.#m9e), ApplyConditionTo.AllValidators);
			parameterExpression = Expression.Parameter(typeof(ColumnStorageModel), #Phc.#3hc(107230552));
			base.RuleFor<Ties>(Expression.Lambda<Func<ColumnStorageModel, Ties>>(Expression.Property(parameterExpression, methodof(ColumnStorageModel.get_Ties())), new ParameterExpression[]
			{
				parameterExpression
			})).SetValidator(new TiesValidator(#GTb.#a), Array.Empty<string>()).When(new Func<ColumnStorageModel, bool>(#GTb.#n9e), ApplyConditionTo.AllValidators);
			parameterExpression = Expression.Parameter(typeof(ColumnStorageModel), #Phc.#3hc(107230552));
			base.RuleFor<IList<IStandardBar>>(Expression.Lambda<Func<ColumnStorageModel, IList<IStandardBar>>>(Expression.Property(parameterExpression, methodof(ColumnStorageModel.get_BarsInternal())), new ParameterExpression[]
			{
				parameterExpression
			})).SetValidator(new StandardBarsValidator(#GTb.#a), Array.Empty<string>());
			parameterExpression = Expression.Parameter(typeof(ColumnStorageModel), #Phc.#3hc(107230552));
			base.RuleForEach<FactoredLoad>(Expression.Lambda<Func<ColumnStorageModel, IEnumerable<FactoredLoad>>>(Expression.Property(parameterExpression, methodof(ColumnStorageModel.get_FactoredLoads())), new ParameterExpression[]
			{
				parameterExpression
			})).SetValidator<FactoredLoadValidator>(new Func<ColumnStorageModel, FactoredLoad, FactoredLoadValidator>(#GTb.#Y9e), Array.Empty<string>()).When(new Func<ColumnStorageModel, bool>(#GTb.#Z9e), ApplyConditionTo.AllValidators);
			parameterExpression = Expression.Parameter(typeof(ColumnStorageModel), #Phc.#3hc(107230552));
			base.RuleForEach<AxialLoad>(Expression.Lambda<Func<ColumnStorageModel, IEnumerable<AxialLoad>>>(Expression.Property(parameterExpression, methodof(ColumnStorageModel.get_AxialLoads())), new ParameterExpression[]
			{
				parameterExpression
			})).SetValidator<AxialLoadValidator>(new Func<ColumnStorageModel, AxialLoad, AxialLoadValidator>(#GTb.#09e), Array.Empty<string>()).When(new Func<ColumnStorageModel, bool>(#GTb.#19e), ApplyConditionTo.AllValidators);
			parameterExpression = Expression.Parameter(typeof(ColumnStorageModel), #Phc.#3hc(107230552));
			base.RuleForEach<ServiceLoad>(Expression.Lambda<Func<ColumnStorageModel, IEnumerable<ServiceLoad>>>(Expression.Property(parameterExpression, methodof(ColumnStorageModel.get_ServiceLoads())), new ParameterExpression[]
			{
				parameterExpression
			})).SetValidator<ServiceLoadValidator>(new Func<ColumnStorageModel, ServiceLoad, ServiceLoadValidator>(#GTb.#v9e), Array.Empty<string>()).When(new Func<ColumnStorageModel, bool>(#GTb.#29e), ApplyConditionTo.AllValidators);
			parameterExpression = Expression.Parameter(typeof(ColumnStorageModel), #Phc.#3hc(107230552));
			base.RuleForEach<LoadFactor>(Expression.Lambda<Func<ColumnStorageModel, IEnumerable<LoadFactor>>>(Expression.Property(parameterExpression, methodof(ColumnStorageModel.get_LoadFactors())), new ParameterExpression[]
			{
				parameterExpression
			})).SetValidator<LoadFactorValidator>(new Func<ColumnStorageModel, LoadFactor, LoadFactorValidator>(#GTb.#39e), Array.Empty<string>()).When(new Func<ColumnStorageModel, bool>(#GTb.#w9e), ApplyConditionTo.AllValidators);
			parameterExpression = Expression.Parameter(typeof(ColumnStorageModel), #Phc.#3hc(107230552));
			base.RuleFor<ColumnStorageModel>(Expression.Lambda<Func<ColumnStorageModel, ColumnStorageModel>>(parameterExpression, new ParameterExpression[]
			{
				parameterExpression
			})).SetValidator(new SlendernessFactorsValidator(#GTb.#a), Array.Empty<string>()).When(new Func<ColumnStorageModel, bool>(#GTb.#49e), ApplyConditionTo.AllValidators);
			parameterExpression = Expression.Parameter(typeof(ColumnStorageModel), #Phc.#3hc(107230552));
			base.RuleFor<SlendernessOfDesignedColumn>(Expression.Lambda<Func<ColumnStorageModel, SlendernessOfDesignedColumn>>(Expression.Property(parameterExpression, methodof(ColumnStorageModel.get_DesignedColumnX())), new ParameterExpression[]
			{
				parameterExpression
			})).SetValidator(new SlendernessOfDesignedColumnValidator(#GTb.#a, #Nce.#g), Array.Empty<string>()).When(new Func<ColumnStorageModel, bool>(#GTb.#59e), ApplyConditionTo.AllValidators);
			parameterExpression = Expression.Parameter(typeof(ColumnStorageModel), #Phc.#3hc(107230552));
			base.RuleFor<SlendernessOfDesignedColumn>(Expression.Lambda<Func<ColumnStorageModel, SlendernessOfDesignedColumn>>(Expression.Property(parameterExpression, methodof(ColumnStorageModel.get_DesignedColumnY())), new ParameterExpression[]
			{
				parameterExpression
			})).SetValidator(new SlendernessOfDesignedColumnValidator(#GTb.#a, #Nce.#h), Array.Empty<string>()).When(new Func<ColumnStorageModel, bool>(#GTb.#69e), ApplyConditionTo.AllValidators);
			parameterExpression = Expression.Parameter(typeof(ColumnStorageModel), #Phc.#3hc(107230552));
			base.RuleFor<SlendernessOfColumn>(Expression.Lambda<Func<ColumnStorageModel, SlendernessOfColumn>>(Expression.Property(parameterExpression, methodof(ColumnStorageModel.get_ColumnAbove())), new ParameterExpression[]
			{
				parameterExpression
			})).SetValidator(new SlendernessOfColumnAboveBelowValidator(#GTb.#a, #Nce.#t), Array.Empty<string>()).When(new Func<ColumnStorageModel, bool>(#GTb.#79e), ApplyConditionTo.AllValidators);
			parameterExpression = Expression.Parameter(typeof(ColumnStorageModel), #Phc.#3hc(107230552));
			base.RuleFor<SlendernessOfColumn>(Expression.Lambda<Func<ColumnStorageModel, SlendernessOfColumn>>(Expression.Property(parameterExpression, methodof(ColumnStorageModel.get_ColumnBelow())), new ParameterExpression[]
			{
				parameterExpression
			})).SetValidator(new SlendernessOfColumnAboveBelowValidator(#GTb.#a, #Nce.#u), Array.Empty<string>()).When(new Func<ColumnStorageModel, bool>(#GTb.#89e), ApplyConditionTo.AllValidators);
			parameterExpression = Expression.Parameter(typeof(ColumnStorageModel), #Phc.#3hc(107230552));
			base.RuleFor<SlendernessOfBeams>(Expression.Lambda<Func<ColumnStorageModel, SlendernessOfBeams>>(Expression.Property(parameterExpression, methodof(ColumnStorageModel.get_BeamX())), new ParameterExpression[]
			{
				parameterExpression
			})).SetValidator(new SlendernessBeamsValidator(#GTb.#a, true), Array.Empty<string>()).When(new Func<ColumnStorageModel, bool>(#GTb.#99e), ApplyConditionTo.AllValidators);
			parameterExpression = Expression.Parameter(typeof(ColumnStorageModel), #Phc.#3hc(107230552));
			base.RuleFor<SlendernessOfBeams>(Expression.Lambda<Func<ColumnStorageModel, SlendernessOfBeams>>(Expression.Property(parameterExpression, methodof(ColumnStorageModel.get_BeamY())), new ParameterExpression[]
			{
				parameterExpression
			})).SetValidator(new SlendernessBeamsValidator(#GTb.#a, false), Array.Empty<string>()).When(new Func<ColumnStorageModel, bool>(#GTb.#aaf), ApplyConditionTo.AllValidators);
			parameterExpression = Expression.Parameter(typeof(ColumnStorageModel), #Phc.#3hc(107230552));
			base.RuleFor<SustainedLoadFactors>(Expression.Lambda<Func<ColumnStorageModel, SustainedLoadFactors>>(Expression.Property(parameterExpression, methodof(ColumnStorageModel.get_SustainedLoadFactors())), new ParameterExpression[]
			{
				parameterExpression
			})).SetValidator(new SustainedLoadFactorsValidator(#GTb.#a), Array.Empty<string>()).When(new Func<ColumnStorageModel, bool>(#GTb.#baf), ApplyConditionTo.AllValidators);
		}

		// Token: 0x06008E10 RID: 36368 RVA: 0x001E4C90 File Offset: 0x001E2E90
		private bool #Xq(ColumnStorageModel #Od)
		{
			switch (#Od.Options.ConsideredAxis)
			{
			case ConsideredAxis.X:
				return #Bpe.#xpe(#Od.DesignedColumnX.EndCondition);
			case ConsideredAxis.Y:
				return #Bpe.#xpe(#Od.DesignedColumnY.EndCondition);
			case ConsideredAxis.Both:
				return #Bpe.#xpe(#Od.DesignedColumnX.EndCondition) && #Bpe.#xpe(#Od.DesignedColumnY.EndCondition);
			default:
				return false;
			}
		}

		// Token: 0x06008E11 RID: 36369 RVA: 0x001E4D08 File Offset: 0x001E2F08
		private bool #Wbe(ColumnStorageModel #Od, #ice #ib)
		{
			if (!#ib.ConsiderSlenderness)
			{
				return false;
			}
			int kmode = (int)#Od.DesignedColumnX.Kmode;
			Kmode kmode2 = #Od.DesignedColumnY.Kmode;
			bool flag = kmode == 0;
			bool flag2 = kmode2 == Kmode.Compute;
			return ((flag && #ib.IsXAxisEnabled) || (flag2 && #ib.IsXAxisEnabled)) && !this.#Xq(#Od);
		}

		// Token: 0x0200102F RID: 4143
		[CompilerGenerated]
		private sealed class #GTb
		{
			// Token: 0x06008E16 RID: 36374 RVA: 0x00073296 File Offset: 0x00071496
			internal bool #78e(ColumnStorageModel #Hi)
			{
				return this.#a.#fce();
			}

			// Token: 0x06008E17 RID: 36375 RVA: 0x00073296 File Offset: 0x00071496
			internal bool #88e(ColumnStorageModel #Hi)
			{
				return this.#a.#fce();
			}

			// Token: 0x06008E18 RID: 36376 RVA: 0x000732A3 File Offset: 0x000714A3
			internal bool #h9e(ColumnStorageModel #Hi)
			{
				return this.#a.#gce() && (this.#a.SectionType == SectionType.Rectangle || this.#a.SectionType == SectionType.Circle);
			}

			// Token: 0x06008E19 RID: 36377 RVA: 0x000732A3 File Offset: 0x000714A3
			internal bool #V9e(ColumnStorageModel #Hi)
			{
				return this.#a.#gce() && (this.#a.SectionType == SectionType.Rectangle || this.#a.SectionType == SectionType.Circle);
			}

			// Token: 0x06008E1A RID: 36378 RVA: 0x000732D1 File Offset: 0x000714D1
			internal IrregularReinforcementBarValidator #W9e(ColumnStorageModel #Od, ReinforcementBar #Rf)
			{
				return new IrregularReinforcementBarValidator(this.#a, new int?(#Od.ReinforcementBars.IndexOf(#Rf)));
			}

			// Token: 0x06008E1B RID: 36379 RVA: 0x000732EF File Offset: 0x000714EF
			internal bool #X9e(ColumnStorageModel #Hi)
			{
				return this.#a.#gce() && this.#a.ConsiderSectionIregular && this.#a.InvestigationReinforcement == ReinforcementType.Irregular;
			}

			// Token: 0x06008E1C RID: 36380 RVA: 0x0007331B File Offset: 0x0007151B
			internal bool #r9e(ColumnStorageModel #Hi)
			{
				return this.#a.ConsiderSectionIregular;
			}

			// Token: 0x06008E1D RID: 36381 RVA: 0x00073296 File Offset: 0x00071496
			internal bool #m9e(ColumnStorageModel #Hi)
			{
				return this.#a.#fce();
			}

			// Token: 0x06008E1E RID: 36382 RVA: 0x00073328 File Offset: 0x00071528
			internal bool #n9e(ColumnStorageModel #Hi)
			{
				return this.#a.SectionType == SectionType.Rectangle || this.#a.SectionType == SectionType.Circle;
			}

			// Token: 0x06008E1F RID: 36383 RVA: 0x00073347 File Offset: 0x00071547
			internal FactoredLoadValidator #Y9e(ColumnStorageModel #Od, FactoredLoad #Rf)
			{
				return new FactoredLoadValidator(this.#a, new int?(#Od.FactoredLoads.IndexOf(#Rf)));
			}

			// Token: 0x06008E20 RID: 36384 RVA: 0x00073365 File Offset: 0x00071565
			internal bool #Z9e(ColumnStorageModel #Hi)
			{
				return this.#a.ActiveLoad == LoadType.Factored;
			}

			// Token: 0x06008E21 RID: 36385 RVA: 0x00073375 File Offset: 0x00071575
			internal AxialLoadValidator #09e(ColumnStorageModel #Od, AxialLoad #Rf)
			{
				return new AxialLoadValidator(this.#a, new int?(#Od.AxialLoads.IndexOf(#Rf)));
			}

			// Token: 0x06008E22 RID: 36386 RVA: 0x00073393 File Offset: 0x00071593
			internal bool #19e(ColumnStorageModel #Hi)
			{
				return this.#a.ActiveLoad == LoadType.Axial;
			}

			// Token: 0x06008E23 RID: 36387 RVA: 0x000733A3 File Offset: 0x000715A3
			internal ServiceLoadValidator #v9e(ColumnStorageModel #Od, ServiceLoad #Rf)
			{
				return new ServiceLoadValidator(this.#a, new int?(#Od.ServiceLoads.IndexOf(#Rf)));
			}

			// Token: 0x06008E24 RID: 36388 RVA: 0x000733C1 File Offset: 0x000715C1
			internal bool #29e(ColumnStorageModel #Hi)
			{
				return this.#a.ActiveLoad == LoadType.Service;
			}

			// Token: 0x06008E25 RID: 36389 RVA: 0x000733D1 File Offset: 0x000715D1
			internal LoadFactorValidator #39e(ColumnStorageModel #Rf, LoadFactor #f)
			{
				return new LoadFactorValidator(this.#a, new int?(#Rf.LoadFactors.IndexOf(#f)));
			}

			// Token: 0x06008E26 RID: 36390 RVA: 0x000733C1 File Offset: 0x000715C1
			internal bool #w9e(ColumnStorageModel #Hi)
			{
				return this.#a.ActiveLoad == LoadType.Service;
			}

			// Token: 0x06008E27 RID: 36391 RVA: 0x000733EF File Offset: 0x000715EF
			internal bool #49e(ColumnStorageModel #Hi)
			{
				return this.#a.ConsiderSlenderness;
			}

			// Token: 0x06008E28 RID: 36392 RVA: 0x000733FC File Offset: 0x000715FC
			internal bool #59e(ColumnStorageModel #Hi)
			{
				return this.#a.ConsiderSlenderness && this.#a.IsXAxisEnabled;
			}

			// Token: 0x06008E29 RID: 36393 RVA: 0x00073418 File Offset: 0x00071618
			internal bool #69e(ColumnStorageModel #Hi)
			{
				return this.#a.ConsiderSlenderness && this.#a.IsYAxisEnabled;
			}

			// Token: 0x06008E2A RID: 36394 RVA: 0x00073434 File Offset: 0x00071634
			internal bool #79e(ColumnStorageModel #dq)
			{
				return this.#b.#Wbe(#dq, this.#a);
			}

			// Token: 0x06008E2B RID: 36395 RVA: 0x00073434 File Offset: 0x00071634
			internal bool #89e(ColumnStorageModel #Od)
			{
				return this.#b.#Wbe(#Od, this.#a);
			}

			// Token: 0x06008E2C RID: 36396 RVA: 0x00073448 File Offset: 0x00071648
			internal bool #99e(ColumnStorageModel #dq)
			{
				return this.#a.ConsiderSlenderness && this.#a.IsXAxisEnabled && #dq.DesignedColumnX.Kmode == Kmode.Compute && !#Bpe.#xpe(#dq.DesignedColumnX.EndCondition);
			}

			// Token: 0x06008E2D RID: 36397 RVA: 0x00073486 File Offset: 0x00071686
			internal bool #aaf(ColumnStorageModel #dq)
			{
				return this.#a.ConsiderSlenderness && this.#a.IsYAxisEnabled && #dq.DesignedColumnY.Kmode == Kmode.Compute && !#Bpe.#xpe(#dq.DesignedColumnY.EndCondition);
			}

			// Token: 0x06008E2E RID: 36398 RVA: 0x000733C1 File Offset: 0x000715C1
			internal bool #baf(ColumnStorageModel #Hi)
			{
				return this.#a.ActiveLoad == LoadType.Service;
			}

			// Token: 0x04003B11 RID: 15121
			public #ice #a;

			// Token: 0x04003B12 RID: 15122
			public StorageModelValidator #b;
		}
	}
}
