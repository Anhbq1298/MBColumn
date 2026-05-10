using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using #0be;
using #2be;
using #7hc;
using FluentValidation;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace StructurePoint.CoreAssets.AppManager.Column.Validation
{
	// Token: 0x02000FE0 RID: 4064
	public sealed class DesignReinforcementDifferentValidator : #tce<IDesignReinforcementSidesDifferent>
	{
		// Token: 0x06008D22 RID: 36130 RVA: 0x001E0224 File Offset: 0x001DE424
		public DesignReinforcementDifferentValidator(#ice context)
		{
			DesignReinforcementDifferentValidator.#GTb #GTb = new DesignReinforcementDifferentValidator.#GTb();
			#GTb.#a = context;
			base..ctor(#GTb.#a);
			ParameterExpression parameterExpression = Expression.Parameter(typeof(IDesignReinforcementSidesDifferent), #Phc.#3hc(107380695));
			this.#Ibe(base.RuleFor<int>(Expression.Lambda<Func<IDesignReinforcementSidesDifferent, int>>(Expression.Property(parameterExpression, methodof(IDesignReinforcementSidesDifferent.get_MinTopBottomNumberOfBars())), new ParameterExpression[]
			{
				parameterExpression
			})), base.Boundaries.Reinforcement.DesignDifferentTopBottomNoOfBars, #Oce.#B);
			parameterExpression = Expression.Parameter(typeof(IDesignReinforcementSidesDifferent), #Phc.#3hc(107380695));
			this.#Fbe(base.RuleFor<int>(Expression.Lambda<Func<IDesignReinforcementSidesDifferent, int>>(Expression.Property(parameterExpression, methodof(IDesignReinforcementSidesDifferent.get_MinTopBottomNumberOfBars())), new ParameterExpression[]
			{
				parameterExpression
			})), #Oce.#B);
			parameterExpression = Expression.Parameter(typeof(IDesignReinforcementSidesDifferent), #Phc.#3hc(107380695));
			base.RuleFor<int>(Expression.Lambda<Func<IDesignReinforcementSidesDifferent, int>>(Expression.Property(parameterExpression, methodof(IDesignReinforcementSidesDifferent.get_MinTopBottomNumberOfBars())), new ParameterExpression[]
			{
				parameterExpression
			})).Must(new Func<IDesignReinforcementSidesDifferent, int, bool>(DesignReinforcementDifferentValidator.<>c.<>9.#b9e)).WithMessage(Strings.StringTheValueShallBeSmallerOrEqualToTheMaxNoOfBars.#z2d()).#Vce(#Mce.#Cce(#Oce.#B));
			parameterExpression = Expression.Parameter(typeof(IDesignReinforcementSidesDifferent), #Phc.#3hc(107380695));
			this.#Ibe(base.RuleFor<int>(Expression.Lambda<Func<IDesignReinforcementSidesDifferent, int>>(Expression.Property(parameterExpression, methodof(IDesignReinforcementSidesDifferent.get_MaxTopBottomNumberOfBars())), new ParameterExpression[]
			{
				parameterExpression
			})), base.Boundaries.Reinforcement.DesignDifferentTopBottomNoOfBars, #Oce.#C);
			parameterExpression = Expression.Parameter(typeof(IDesignReinforcementSidesDifferent), #Phc.#3hc(107380695));
			this.#Fbe(base.RuleFor<int>(Expression.Lambda<Func<IDesignReinforcementSidesDifferent, int>>(Expression.Property(parameterExpression, methodof(IDesignReinforcementSidesDifferent.get_MaxTopBottomNumberOfBars())), new ParameterExpression[]
			{
				parameterExpression
			})), #Oce.#C);
			parameterExpression = Expression.Parameter(typeof(IDesignReinforcementSidesDifferent), #Phc.#3hc(107380695));
			base.RuleFor<int>(Expression.Lambda<Func<IDesignReinforcementSidesDifferent, int>>(Expression.Property(parameterExpression, methodof(IDesignReinforcementSidesDifferent.get_MaxTopBottomNumberOfBars())), new ParameterExpression[]
			{
				parameterExpression
			})).Must(new Func<IDesignReinforcementSidesDifferent, int, bool>(DesignReinforcementDifferentValidator.<>c.<>9.#x9e)).WithMessage(Strings.StringTheValueShallBeGreaterOrEqualToTheMinNoOfBars.#z2d()).#Vce(#Mce.#Cce(#Oce.#C));
			parameterExpression = Expression.Parameter(typeof(IDesignReinforcementSidesDifferent), #Phc.#3hc(107380695));
			this.#Ibe(base.RuleFor<int>(Expression.Lambda<Func<IDesignReinforcementSidesDifferent, int>>(Expression.Property(parameterExpression, methodof(IDesignReinforcementSidesDifferent.get_MinLeftRightNumberOfBars())), new ParameterExpression[]
			{
				parameterExpression
			})), base.Boundaries.Reinforcement.DesignDifferentLeftRightNoOfBars, #Oce.#D);
			parameterExpression = Expression.Parameter(typeof(IDesignReinforcementSidesDifferent), #Phc.#3hc(107380695));
			this.#Fbe(base.RuleFor<int>(Expression.Lambda<Func<IDesignReinforcementSidesDifferent, int>>(Expression.Property(parameterExpression, methodof(IDesignReinforcementSidesDifferent.get_MinLeftRightNumberOfBars())), new ParameterExpression[]
			{
				parameterExpression
			})), #Oce.#D);
			parameterExpression = Expression.Parameter(typeof(IDesignReinforcementSidesDifferent), #Phc.#3hc(107380695));
			base.RuleFor<int>(Expression.Lambda<Func<IDesignReinforcementSidesDifferent, int>>(Expression.Property(parameterExpression, methodof(IDesignReinforcementSidesDifferent.get_MinLeftRightNumberOfBars())), new ParameterExpression[]
			{
				parameterExpression
			})).Must(new Func<IDesignReinforcementSidesDifferent, int, bool>(DesignReinforcementDifferentValidator.<>c.<>9.#y9e)).WithMessage(Strings.StringTheValueShallBeSmallerOrEqualToTheMaxNoOfBars.#z2d()).#Vce(#Mce.#Cce(#Oce.#D));
			parameterExpression = Expression.Parameter(typeof(IDesignReinforcementSidesDifferent), #Phc.#3hc(107380695));
			this.#Ibe(base.RuleFor<int>(Expression.Lambda<Func<IDesignReinforcementSidesDifferent, int>>(Expression.Property(parameterExpression, methodof(IDesignReinforcementSidesDifferent.get_MaxLeftRightNumberOfBars())), new ParameterExpression[]
			{
				parameterExpression
			})), base.Boundaries.Reinforcement.DesignDifferentLeftRightNoOfBars, #Oce.#E);
			parameterExpression = Expression.Parameter(typeof(IDesignReinforcementSidesDifferent), #Phc.#3hc(107380695));
			this.#Fbe(base.RuleFor<int>(Expression.Lambda<Func<IDesignReinforcementSidesDifferent, int>>(Expression.Property(parameterExpression, methodof(IDesignReinforcementSidesDifferent.get_MaxLeftRightNumberOfBars())), new ParameterExpression[]
			{
				parameterExpression
			})), #Oce.#E);
			parameterExpression = Expression.Parameter(typeof(IDesignReinforcementSidesDifferent), #Phc.#3hc(107380695));
			base.RuleFor<int>(Expression.Lambda<Func<IDesignReinforcementSidesDifferent, int>>(Expression.Property(parameterExpression, methodof(IDesignReinforcementSidesDifferent.get_MaxLeftRightNumberOfBars())), new ParameterExpression[]
			{
				parameterExpression
			})).Must(new Func<IDesignReinforcementSidesDifferent, int, bool>(DesignReinforcementDifferentValidator.<>c.<>9.#z9e)).WithMessage(Strings.StringTheValueShallBeGreaterOrEqualToTheMinNoOfBars.#z2d()).#Vce(#Mce.#Cce(#Oce.#E));
			parameterExpression = Expression.Parameter(typeof(IDesignReinforcementSidesDifferent), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<IDesignReinforcementSidesDifferent, float>>(Expression.Property(parameterExpression, methodof(IDesignReinforcementSidesDifferent.get_TopBottomClearCover())), new ParameterExpression[]
			{
				parameterExpression
			})).#IBb(base.Boundaries.Reinforcement.ClearCover, #GTb.#a).#Vce(#Mce.#Cce(#Oce.#J));
			parameterExpression = Expression.Parameter(typeof(IDesignReinforcementSidesDifferent), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<IDesignReinforcementSidesDifferent, float>>(Expression.Property(parameterExpression, methodof(IDesignReinforcementSidesDifferent.get_LeftRightClearCover())), new ParameterExpression[]
			{
				parameterExpression
			})).#IBb(base.Boundaries.Reinforcement.ClearCover, #GTb.#a).#Vce(#Mce.#Cce(#Oce.#K));
			parameterExpression = Expression.Parameter(typeof(IDesignReinforcementSidesDifferent), #Phc.#3hc(107380695));
			base.RuleFor<int>(Expression.Lambda<Func<IDesignReinforcementSidesDifferent, int>>(Expression.Property(parameterExpression, methodof(IDesignReinforcementSidesDifferent.get_MinLeftRightBarSize())), new ParameterExpression[]
			{
				parameterExpression
			})).#Sce(#GTb.#a).#Vce(#Mce.#Cce(#Oce.#H));
			parameterExpression = Expression.Parameter(typeof(IDesignReinforcementSidesDifferent), #Phc.#3hc(107380695));
			base.RuleFor<int>(Expression.Lambda<Func<IDesignReinforcementSidesDifferent, int>>(Expression.Property(parameterExpression, methodof(IDesignReinforcementSidesDifferent.get_MinLeftRightBarSize())), new ParameterExpression[]
			{
				parameterExpression
			})).Must(new Func<IDesignReinforcementSidesDifferent, int, bool>(DesignReinforcementDifferentValidator.<>c.<>9.#A9e)).When(new Func<IDesignReinforcementSidesDifferent, bool>(#GTb.#o9e), ApplyConditionTo.AllValidators).WithMessage(Strings.StringTheValueShallBeSmallerOrEqualToMaxBarSize.#z2d()).#Vce(#Mce.#Cce(#Oce.#H));
			parameterExpression = Expression.Parameter(typeof(IDesignReinforcementSidesDifferent), #Phc.#3hc(107380695));
			base.RuleFor<int>(Expression.Lambda<Func<IDesignReinforcementSidesDifferent, int>>(Expression.Property(parameterExpression, methodof(IDesignReinforcementSidesDifferent.get_MaxLeftRightBarSize())), new ParameterExpression[]
			{
				parameterExpression
			})).#Sce(#GTb.#a).#Vce(#Mce.#Cce(#Oce.#I));
			parameterExpression = Expression.Parameter(typeof(IDesignReinforcementSidesDifferent), #Phc.#3hc(107380695));
			base.RuleFor<int>(Expression.Lambda<Func<IDesignReinforcementSidesDifferent, int>>(Expression.Property(parameterExpression, methodof(IDesignReinforcementSidesDifferent.get_MaxLeftRightBarSize())), new ParameterExpression[]
			{
				parameterExpression
			})).Must(new Func<IDesignReinforcementSidesDifferent, int, bool>(DesignReinforcementDifferentValidator.<>c.<>9.#B9e)).When(new Func<IDesignReinforcementSidesDifferent, bool>(#GTb.#u9e), ApplyConditionTo.AllValidators).WithMessage(Strings.StringTheValueShallBeGreaterOrEqualToMinBarSize.#z2d()).#Vce(#Mce.#Cce(#Oce.#I));
			parameterExpression = Expression.Parameter(typeof(IDesignReinforcementSidesDifferent), #Phc.#3hc(107380695));
			base.RuleFor<int>(Expression.Lambda<Func<IDesignReinforcementSidesDifferent, int>>(Expression.Property(parameterExpression, methodof(IDesignReinforcementSidesDifferent.get_MinTopBottomBarSize())), new ParameterExpression[]
			{
				parameterExpression
			})).#Sce(#GTb.#a).#Vce(#Mce.#Cce(#Oce.#F));
			parameterExpression = Expression.Parameter(typeof(IDesignReinforcementSidesDifferent), #Phc.#3hc(107380695));
			base.RuleFor<int>(Expression.Lambda<Func<IDesignReinforcementSidesDifferent, int>>(Expression.Property(parameterExpression, methodof(IDesignReinforcementSidesDifferent.get_MinTopBottomBarSize())), new ParameterExpression[]
			{
				parameterExpression
			})).Must(new Func<IDesignReinforcementSidesDifferent, int, bool>(DesignReinforcementDifferentValidator.<>c.<>9.#C9e)).When(new Func<IDesignReinforcementSidesDifferent, bool>(#GTb.#v9e), ApplyConditionTo.AllValidators).WithMessage(Strings.StringTheValueShallBeSmallerOrEqualToMaxBarSize.#z2d()).#Vce(#Mce.#Cce(#Oce.#F));
			parameterExpression = Expression.Parameter(typeof(IDesignReinforcementSidesDifferent), #Phc.#3hc(107380695));
			base.RuleFor<int>(Expression.Lambda<Func<IDesignReinforcementSidesDifferent, int>>(Expression.Property(parameterExpression, methodof(IDesignReinforcementSidesDifferent.get_MaxTopBottomBarSize())), new ParameterExpression[]
			{
				parameterExpression
			})).#Sce(#GTb.#a).#Vce(#Mce.#Cce(#Oce.#G));
			parameterExpression = Expression.Parameter(typeof(IDesignReinforcementSidesDifferent), #Phc.#3hc(107380695));
			base.RuleFor<int>(Expression.Lambda<Func<IDesignReinforcementSidesDifferent, int>>(Expression.Property(parameterExpression, methodof(IDesignReinforcementSidesDifferent.get_MaxTopBottomBarSize())), new ParameterExpression[]
			{
				parameterExpression
			})).Must(new Func<IDesignReinforcementSidesDifferent, int, bool>(DesignReinforcementDifferentValidator.<>c.<>9.#D9e)).When(new Func<IDesignReinforcementSidesDifferent, bool>(#GTb.#w9e), ApplyConditionTo.AllValidators).WithMessage(Strings.StringTheValueShallBeGreaterOrEqualToMinBarSize.#z2d()).#Vce(#Mce.#Cce(#Oce.#G));
		}

		// Token: 0x06008D23 RID: 36131 RVA: 0x001E0B9C File Offset: 0x001DED9C
		private void #Fbe(IRuleBuilderInitial<IDesignReinforcementSidesDifferent, int> #Gbe, #Oce #Hbe)
		{
			#Gbe.Must(new Func<int, bool>(DesignReinforcementDifferentValidator.<>c.<>9.#E9e)).WithMessage(new Func<IDesignReinforcementSidesDifferent, string>(DesignReinforcementDifferentValidator.<>c.<>9.#F9e)).#Vce(#Mce.#Cce(#Hbe));
		}

		// Token: 0x06008D24 RID: 36132 RVA: 0x000729AD File Offset: 0x00070BAD
		private void #Ibe(IRuleBuilderInitial<IDesignReinforcementSidesDifferent, int> #Gbe, #6ce #LBb, #Oce #Hbe)
		{
			#Gbe.#Tce(#LBb).#Vce(#Mce.#Cce(#Hbe));
		}

		// Token: 0x02000FE2 RID: 4066
		[CompilerGenerated]
		private sealed class #GTb
		{
			// Token: 0x06008D32 RID: 36146 RVA: 0x00072A4D File Offset: 0x00070C4D
			internal bool #o9e(IDesignReinforcementSidesDifferent #Rf)
			{
				return this.#a.#bce(#Rf.MinLeftRightBarSize) && this.#a.#bce(#Rf.MaxLeftRightBarSize);
			}

			// Token: 0x06008D33 RID: 36147 RVA: 0x00072A4D File Offset: 0x00070C4D
			internal bool #u9e(IDesignReinforcementSidesDifferent #Rf)
			{
				return this.#a.#bce(#Rf.MinLeftRightBarSize) && this.#a.#bce(#Rf.MaxLeftRightBarSize);
			}

			// Token: 0x06008D34 RID: 36148 RVA: 0x00072A75 File Offset: 0x00070C75
			internal bool #v9e(IDesignReinforcementSidesDifferent #Rf)
			{
				return this.#a.#bce(#Rf.MinTopBottomBarSize) && this.#a.#bce(#Rf.MaxTopBottomBarSize);
			}

			// Token: 0x06008D35 RID: 36149 RVA: 0x00072A75 File Offset: 0x00070C75
			internal bool #w9e(IDesignReinforcementSidesDifferent #Rf)
			{
				return this.#a.#bce(#Rf.MinTopBottomBarSize) && this.#a.#bce(#Rf.MaxTopBottomBarSize);
			}

			// Token: 0x04003AAA RID: 15018
			public #ice #a;
		}
	}
}
