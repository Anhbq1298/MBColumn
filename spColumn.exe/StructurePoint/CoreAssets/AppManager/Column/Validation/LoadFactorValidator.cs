using System;
using System.Linq.Expressions;
using #2be;
using #7hc;
using #9pe;

namespace StructurePoint.CoreAssets.AppManager.Column.Validation
{
	// Token: 0x02001001 RID: 4097
	public sealed class LoadFactorValidator : #tce<#gqe>
	{
		// Token: 0x06008D9F RID: 36255 RVA: 0x001E2328 File Offset: 0x001E0528
		public LoadFactorValidator(#ice context, int? index = null) : base(context)
		{
			ParameterExpression parameterExpression = Expression.Parameter(typeof(#gqe), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#gqe, float>>(Expression.Property(parameterExpression, methodof(#gqe.get_Dead())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Loads.LoadFactor).#Vce(#Mce.#Kce(#Oce.#kb, index));
			parameterExpression = Expression.Parameter(typeof(#gqe), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#gqe, float>>(Expression.Property(parameterExpression, methodof(#gqe.get_Live())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Loads.LoadFactor).#Vce(#Mce.#Kce(#Oce.#lb, index));
			parameterExpression = Expression.Parameter(typeof(#gqe), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#gqe, float>>(Expression.Property(parameterExpression, methodof(#gqe.get_Wind())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Loads.LoadFactor).#Vce(#Mce.#Kce(#Oce.#mb, index));
			parameterExpression = Expression.Parameter(typeof(#gqe), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#gqe, float>>(Expression.Property(parameterExpression, methodof(#gqe.get_Earthquake())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Loads.LoadFactor).#Vce(#Mce.#Kce(#Oce.#nb, index));
			parameterExpression = Expression.Parameter(typeof(#gqe), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#gqe, float>>(Expression.Property(parameterExpression, methodof(#gqe.get_Snow())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Loads.LoadFactor).#Vce(#Mce.#Kce(#Oce.#ob, index));
		}
	}
}
