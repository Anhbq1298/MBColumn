using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using #0be;
using #2be;
using #7hc;
using #9pe;
using FluentValidation;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Localizer;

namespace StructurePoint.CoreAssets.AppManager.Column.Validation
{
	// Token: 0x02000FED RID: 4077
	public sealed class InvestigationReinforcementEqualValidator : #tce<#fqe>
	{
		// Token: 0x06008D4B RID: 36171 RVA: 0x001E0F84 File Offset: 0x001DF184
		public InvestigationReinforcementEqualValidator(#ice context)
		{
			InvestigationReinforcementEqualValidator.#GTb #GTb = new InvestigationReinforcementEqualValidator.#GTb();
			#GTb.#a = context;
			base..ctor(#GTb.#a);
			ParameterExpression parameterExpression = Expression.Parameter(typeof(#fqe), #Phc.#3hc(107380695));
			base.RuleFor<int>(Expression.Lambda<Func<#fqe, int>>(Expression.Property(parameterExpression, methodof(#fqe.get_NumberOfBars())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Reinforcement.InvestigationEqualNumberOfBars).#Vce(#Mce.#zce(#Oce.#i));
			parameterExpression = Expression.Parameter(typeof(#fqe), #Phc.#3hc(107380695));
			base.RuleFor<int>(Expression.Lambda<Func<#fqe, int>>(Expression.Property(parameterExpression, methodof(#fqe.get_NumberOfBars())), new ParameterExpression[]
			{
				parameterExpression
			})).Must(new Func<int, bool>(this.#Cbe)).WithMessage(Strings.StringNoOfBarsShouldBeMultipleOf4).When(new Func<#fqe, bool>(#GTb.#g9e), ApplyConditionTo.AllValidators).#Vce(#Mce.#zce(#Oce.#i));
			parameterExpression = Expression.Parameter(typeof(#fqe), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#fqe, float>>(Expression.Property(parameterExpression, methodof(#fqe.get_ClearCover())), new ParameterExpression[]
			{
				parameterExpression
			})).#IBb(base.Boundaries.Reinforcement.ClearCover, #GTb.#a).#Vce(#Mce.#zce(#Oce.#j));
			parameterExpression = Expression.Parameter(typeof(#fqe), #Phc.#3hc(107380695));
			base.RuleFor<int>(Expression.Lambda<Func<#fqe, int>>(Expression.Property(parameterExpression, methodof(#fqe.get_BarSize())), new ParameterExpression[]
			{
				parameterExpression
			})).#Sce(#GTb.#a).#Vce(#Mce.#zce(#Oce.#k));
		}

		// Token: 0x06008D4C RID: 36172 RVA: 0x00072911 File Offset: 0x00070B11
		private bool #Cbe(int #Dbe)
		{
			return #Dbe % 4 == 0;
		}

		// Token: 0x02000FEF RID: 4079
		[CompilerGenerated]
		private sealed class #GTb
		{
			// Token: 0x06008D50 RID: 36176 RVA: 0x00072B47 File Offset: 0x00070D47
			internal bool #g9e(#fqe #Hi)
			{
				return this.#a.ReinforcementLayout == ReinforcementLayout.Rectangle;
			}

			// Token: 0x04003AB2 RID: 15026
			public #ice #a;
		}
	}
}
