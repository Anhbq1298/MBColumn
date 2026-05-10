using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using #2be;
using #7hc;
using #9pe;
using FluentValidation;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;

namespace StructurePoint.CoreAssets.AppManager.Column.Validation
{
	// Token: 0x0200100F RID: 4111
	public sealed class ReductionFactorsValidator : #tce<#kqe>
	{
		// Token: 0x06008DBA RID: 36282 RVA: 0x001E2B1C File Offset: 0x001E0D1C
		public ReductionFactorsValidator(#ice context, bool validateMinDimension)
		{
			ReductionFactorsValidator.#GTb #GTb = new ReductionFactorsValidator.#GTb();
			#GTb.#a = validateMinDimension;
			#GTb.#c = context;
			base..ctor(#GTb.#c);
			#GTb.#b = this;
			ParameterExpression parameterExpression = Expression.Parameter(typeof(#kqe), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#kqe, float>>(Expression.Property(parameterExpression, methodof(#kqe.get_A())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.ReductionFactors.A).#Vce(#Mce.#Fce(#Oce.#Y));
			parameterExpression = Expression.Parameter(typeof(#kqe), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#kqe, float>>(Expression.Property(parameterExpression, methodof(#kqe.get_B())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.ReductionFactors.B).#Vce(#Mce.#Fce(#Oce.#Z));
			parameterExpression = Expression.Parameter(typeof(#kqe), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#kqe, float>>(Expression.Property(parameterExpression, methodof(#kqe.get_C())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.ReductionFactors.C).#Vce(#Mce.#Fce(#Oce.#0));
			parameterExpression = Expression.Parameter(typeof(#kqe), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#kqe, float>>(Expression.Property(parameterExpression, methodof(#kqe.get_MinDimension())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.ReductionFactors.MinDimension).When(new Func<#kqe, bool>(#GTb.#Q9e), ApplyConditionTo.AllValidators).#Vce(#Mce.#Fce(#Oce.#1));
		}

		// Token: 0x06008DBB RID: 36283 RVA: 0x00072F9A File Offset: 0x0007119A
		public bool #Nbe(#ice #ib)
		{
			return #ib.IsCsa14Plus && #ib.Confinement == ConfinementType.Tied && #ib.ConsiderSectionIregular;
		}

		// Token: 0x02001011 RID: 4113
		[CompilerGenerated]
		private sealed class #GTb
		{
			// Token: 0x06008DBF RID: 36287 RVA: 0x00072FC0 File Offset: 0x000711C0
			internal bool #Q9e(#kqe #Hi)
			{
				return this.#a && this.#b.#Nbe(this.#c);
			}

			// Token: 0x04003AE5 RID: 15077
			public bool #a;

			// Token: 0x04003AE6 RID: 15078
			public ReductionFactorsValidator #b;

			// Token: 0x04003AE7 RID: 15079
			public #ice #c;
		}
	}
}
