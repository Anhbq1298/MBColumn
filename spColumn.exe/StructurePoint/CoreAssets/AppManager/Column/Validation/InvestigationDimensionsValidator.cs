using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using #2be;
using #7hc;
using #9pe;
using FluentValidation;

namespace StructurePoint.CoreAssets.AppManager.Column.Validation
{
	// Token: 0x02000FE6 RID: 4070
	public sealed class InvestigationDimensionsValidator : #tce<#aqe>
	{
		// Token: 0x06008D3C RID: 36156 RVA: 0x001E0D80 File Offset: 0x001DEF80
		public InvestigationDimensionsValidator(#ice context)
		{
			InvestigationDimensionsValidator.#GTb #GTb = new InvestigationDimensionsValidator.#GTb();
			#GTb.#a = context;
			base..ctor(#GTb.#a);
			ParameterExpression parameterExpression = Expression.Parameter(typeof(#aqe), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#aqe, float>>(Expression.Property(parameterExpression, methodof(#aqe.get_DimensionA())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Core.InvestigationDimensions).#Vce(#Mce.#Q1(#Oce.#g));
			parameterExpression = Expression.Parameter(typeof(#aqe), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#aqe, float>>(Expression.Property(parameterExpression, methodof(#aqe.get_DimensionB())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Core.InvestigationDimensions).When(new Func<#aqe, bool>(#GTb.#g9e), ApplyConditionTo.AllValidators).#Vce(#Mce.#Q1(#Oce.#h));
		}

		// Token: 0x02000FE8 RID: 4072
		[CompilerGenerated]
		private sealed class #GTb
		{
			// Token: 0x06008D40 RID: 36160 RVA: 0x00072AF3 File Offset: 0x00070CF3
			internal bool #g9e(#aqe #9o)
			{
				return this.#a.#Qbe();
			}

			// Token: 0x04003AAE RID: 15022
			public #ice #a;
		}
	}
}
