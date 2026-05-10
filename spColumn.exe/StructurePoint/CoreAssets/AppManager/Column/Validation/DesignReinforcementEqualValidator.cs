using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using #0be;
using #2be;
using #7hc;
using FluentValidation;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace StructurePoint.CoreAssets.AppManager.Column.Validation
{
	// Token: 0x02000FDD RID: 4061
	public sealed class DesignReinforcementEqualValidator : #tce<IDesignReinforcementEqual>
	{
		// Token: 0x06008D14 RID: 36116 RVA: 0x001DFCD4 File Offset: 0x001DDED4
		public DesignReinforcementEqualValidator(#ice context)
		{
			DesignReinforcementEqualValidator.#GTb #GTb = new DesignReinforcementEqualValidator.#GTb();
			#GTb.#b = context;
			base..ctor(#GTb.#b);
			#GTb.#a = this;
			ParameterExpression parameterExpression = Expression.Parameter(typeof(IDesignReinforcementEqual), #Phc.#3hc(107380695));
			base.RuleFor<int>(Expression.Lambda<Func<IDesignReinforcementEqual, int>>(Expression.Property(parameterExpression, methodof(IDesignReinforcementEqual.get_MinNumberOfBars())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Reinforcement.DesignEqualNumberOfBars).#Vce(#Mce.#Bce(#Oce.#x));
			parameterExpression = Expression.Parameter(typeof(IDesignReinforcementEqual), #Phc.#3hc(107380695));
			base.RuleFor<int>(Expression.Lambda<Func<IDesignReinforcementEqual, int>>(Expression.Property(parameterExpression, methodof(IDesignReinforcementEqual.get_MinNumberOfBars())), new ParameterExpression[]
			{
				parameterExpression
			})).Must(new Func<int, bool>(this.#Cbe)).When(new Func<IDesignReinforcementEqual, bool>(#GTb.#g9e), ApplyConditionTo.AllValidators).WithMessage(Strings.StringNoOfBarsShouldBeMultipleOf4).#Vce(#Mce.#Bce(#Oce.#x));
			parameterExpression = Expression.Parameter(typeof(IDesignReinforcementEqual), #Phc.#3hc(107380695));
			base.RuleFor<int>(Expression.Lambda<Func<IDesignReinforcementEqual, int>>(Expression.Property(parameterExpression, methodof(IDesignReinforcementEqual.get_MinNumberOfBars())), new ParameterExpression[]
			{
				parameterExpression
			})).Must(new Func<IDesignReinforcementEqual, int, bool>(DesignReinforcementEqualValidator.<>c.<>9.#s9e)).WithMessage(Strings.StringTheValueShallBeSmallerOrEqualToTheMaxNoOfBars.#z2d()).#Vce(#Mce.#Bce(#Oce.#x));
			parameterExpression = Expression.Parameter(typeof(IDesignReinforcementEqual), #Phc.#3hc(107380695));
			base.RuleFor<int>(Expression.Lambda<Func<IDesignReinforcementEqual, int>>(Expression.Property(parameterExpression, methodof(IDesignReinforcementEqual.get_MaxNumberOfBars())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Reinforcement.DesignEqualNumberOfBars).#Vce(#Mce.#Bce(#Oce.#z));
			parameterExpression = Expression.Parameter(typeof(IDesignReinforcementEqual), #Phc.#3hc(107380695));
			base.RuleFor<int>(Expression.Lambda<Func<IDesignReinforcementEqual, int>>(Expression.Property(parameterExpression, methodof(IDesignReinforcementEqual.get_MaxNumberOfBars())), new ParameterExpression[]
			{
				parameterExpression
			})).Must(new Func<int, bool>(this.#Cbe)).When(new Func<IDesignReinforcementEqual, bool>(#GTb.#h9e), ApplyConditionTo.AllValidators).WithMessage(Strings.StringNoOfBarsShouldBeMultipleOf4).#Vce(#Mce.#Bce(#Oce.#z));
			parameterExpression = Expression.Parameter(typeof(IDesignReinforcementEqual), #Phc.#3hc(107380695));
			base.RuleFor<int>(Expression.Lambda<Func<IDesignReinforcementEqual, int>>(Expression.Property(parameterExpression, methodof(IDesignReinforcementEqual.get_MaxNumberOfBars())), new ParameterExpression[]
			{
				parameterExpression
			})).Must(new Func<IDesignReinforcementEqual, int, bool>(DesignReinforcementEqualValidator.<>c.<>9.#f9e)).WithMessage(Strings.StringTheValueShallBeGreaterOrEqualToTheMinNoOfBars.#z2d()).#Vce(#Mce.#Bce(#Oce.#z));
			parameterExpression = Expression.Parameter(typeof(IDesignReinforcementEqual), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<IDesignReinforcementEqual, float>>(Expression.Property(parameterExpression, methodof(IDesignReinforcementEqual.get_ClearCover())), new ParameterExpression[]
			{
				parameterExpression
			})).#IBb(base.Boundaries.Reinforcement.ClearCover, #GTb.#b).#Vce(#Mce.#Bce(#Oce.#j));
			parameterExpression = Expression.Parameter(typeof(IDesignReinforcementEqual), #Phc.#3hc(107380695));
			base.RuleFor<int>(Expression.Lambda<Func<IDesignReinforcementEqual, int>>(Expression.Property(parameterExpression, methodof(IDesignReinforcementEqual.get_MinBarSize())), new ParameterExpression[]
			{
				parameterExpression
			})).#Sce(#GTb.#b).#Vce(#Mce.#Bce(#Oce.#y));
			parameterExpression = Expression.Parameter(typeof(IDesignReinforcementEqual), #Phc.#3hc(107380695));
			base.RuleFor<int>(Expression.Lambda<Func<IDesignReinforcementEqual, int>>(Expression.Property(parameterExpression, methodof(IDesignReinforcementEqual.get_MinBarSize())), new ParameterExpression[]
			{
				parameterExpression
			})).Must(new Func<IDesignReinforcementEqual, int, bool>(DesignReinforcementEqualValidator.<>c.<>9.#t9e)).When(new Func<IDesignReinforcementEqual, bool>(#GTb.#r9e), ApplyConditionTo.AllValidators).WithMessage(Strings.StringTheValueShallBeSmallerOrEqualToMaxBarSize.#z2d()).#Vce(#Mce.#Bce(#Oce.#y));
			parameterExpression = Expression.Parameter(typeof(IDesignReinforcementEqual), #Phc.#3hc(107380695));
			base.RuleFor<int>(Expression.Lambda<Func<IDesignReinforcementEqual, int>>(Expression.Property(parameterExpression, methodof(IDesignReinforcementEqual.get_MaxBarSize())), new ParameterExpression[]
			{
				parameterExpression
			})).#Sce(#GTb.#b).#Vce(#Mce.#Bce(#Oce.#A));
			parameterExpression = Expression.Parameter(typeof(IDesignReinforcementEqual), #Phc.#3hc(107380695));
			base.RuleFor<int>(Expression.Lambda<Func<IDesignReinforcementEqual, int>>(Expression.Property(parameterExpression, methodof(IDesignReinforcementEqual.get_MaxBarSize())), new ParameterExpression[]
			{
				parameterExpression
			})).Must(new Func<IDesignReinforcementEqual, int, bool>(DesignReinforcementEqualValidator.<>c.<>9.#q9e)).When(new Func<IDesignReinforcementEqual, bool>(#GTb.#m9e), ApplyConditionTo.AllValidators).WithMessage(Strings.StringTheValueShallBeGreaterOrEqualToMinBarSize.#z2d()).#Vce(#Mce.#Bce(#Oce.#A));
		}

		// Token: 0x06008D15 RID: 36117 RVA: 0x00072911 File Offset: 0x00070B11
		private bool #Cbe(int #Dbe)
		{
			return #Dbe % 4 == 0;
		}

		// Token: 0x06008D16 RID: 36118 RVA: 0x00072919 File Offset: 0x00070B19
		private bool #Ebe(#ice #ib)
		{
			return #ib.ReinforcementLayout == ReinforcementLayout.Rectangle || #ib.DesignReinforcement == ReinforcementType.EqualSpace;
		}

		// Token: 0x02000FDF RID: 4063
		[CompilerGenerated]
		private sealed class #GTb
		{
			// Token: 0x06008D1E RID: 36126 RVA: 0x00072972 File Offset: 0x00070B72
			internal bool #g9e(IDesignReinforcementEqual #Hi)
			{
				return this.#a.#Ebe(this.#b);
			}

			// Token: 0x06008D1F RID: 36127 RVA: 0x00072972 File Offset: 0x00070B72
			internal bool #h9e(IDesignReinforcementEqual #Hi)
			{
				return this.#a.#Ebe(this.#b);
			}

			// Token: 0x06008D20 RID: 36128 RVA: 0x00072985 File Offset: 0x00070B85
			internal bool #r9e(IDesignReinforcementEqual #Rf)
			{
				return this.#b.#bce(#Rf.MinBarSize) && this.#b.#bce(#Rf.MaxBarSize);
			}

			// Token: 0x06008D21 RID: 36129 RVA: 0x00072985 File Offset: 0x00070B85
			internal bool #m9e(IDesignReinforcementEqual #Rf)
			{
				return this.#b.#bce(#Rf.MinBarSize) && this.#b.#bce(#Rf.MaxBarSize);
			}

			// Token: 0x04003A9D RID: 15005
			public DesignReinforcementEqualValidator #a;

			// Token: 0x04003A9E RID: 15006
			public #ice #b;
		}
	}
}
