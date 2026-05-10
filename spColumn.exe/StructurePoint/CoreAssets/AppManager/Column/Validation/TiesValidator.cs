using System;
using System.Linq.Expressions;
using #2be;
using #7hc;
using #9pe;

namespace StructurePoint.CoreAssets.AppManager.Column.Validation
{
	// Token: 0x02001032 RID: 4146
	public sealed class TiesValidator : #tce<#tqe>
	{
		// Token: 0x06008E32 RID: 36402 RVA: 0x001E4F74 File Offset: 0x001E3174
		public TiesValidator(#ice context) : base(context)
		{
			ParameterExpression parameterExpression = Expression.Parameter(typeof(#tqe), #Phc.#3hc(107380695));
			base.RuleFor<int>(Expression.Lambda<Func<#tqe, int>>(Expression.Property(parameterExpression, methodof(#tqe.get_LargeTie())), new ParameterExpression[]
			{
				parameterExpression
			})).#Sce(context).#Vce(#Mce.#53(#Oce.#7));
			parameterExpression = Expression.Parameter(typeof(#tqe), #Phc.#3hc(107380695));
			base.RuleFor<int>(Expression.Lambda<Func<#tqe, int>>(Expression.Property(parameterExpression, methodof(#tqe.get_SmallTie())), new ParameterExpression[]
			{
				parameterExpression
			})).#Sce(context).#Vce(#Mce.#53(#Oce.#6));
			parameterExpression = Expression.Parameter(typeof(#tqe), #Phc.#3hc(107380695));
			base.RuleFor<int>(Expression.Lambda<Func<#tqe, int>>(Expression.Property(parameterExpression, methodof(#tqe.get_LongitudinalBar())), new ParameterExpression[]
			{
				parameterExpression
			})).#Sce(context).#Vce(#Mce.#53(#Oce.#8));
		}
	}
}
