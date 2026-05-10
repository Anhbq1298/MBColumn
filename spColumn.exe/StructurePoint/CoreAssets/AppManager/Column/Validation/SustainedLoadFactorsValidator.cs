using System;
using System.Linq.Expressions;
using #2be;
using #7hc;
using #9pe;

namespace StructurePoint.CoreAssets.AppManager.Column.Validation
{
	// Token: 0x02001030 RID: 4144
	public sealed class SustainedLoadFactorsValidator : #tce<#sqe>
	{
		// Token: 0x06008E2F RID: 36399 RVA: 0x001E4D60 File Offset: 0x001E2F60
		public SustainedLoadFactorsValidator(#ice context) : base(context)
		{
			ParameterExpression parameterExpression = Expression.Parameter(typeof(#sqe), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#sqe, float>>(Expression.Property(parameterExpression, methodof(#sqe.get_Dead())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Loads.SustainedLoadFactor).#Vce(#Mce.#Y3(#Oce.#kb));
			parameterExpression = Expression.Parameter(typeof(#sqe), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#sqe, float>>(Expression.Property(parameterExpression, methodof(#sqe.get_Live())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Loads.SustainedLoadFactor).#Vce(#Mce.#Y3(#Oce.#lb));
			parameterExpression = Expression.Parameter(typeof(#sqe), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#sqe, float>>(Expression.Property(parameterExpression, methodof(#sqe.get_Earthquake())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Loads.SustainedLoadFactor).#Vce(#Mce.#Y3(#Oce.#nb));
			parameterExpression = Expression.Parameter(typeof(#sqe), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#sqe, float>>(Expression.Property(parameterExpression, methodof(#sqe.get_Wind())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Loads.SustainedLoadFactor).#Vce(#Mce.#Y3(#Oce.#mb));
			parameterExpression = Expression.Parameter(typeof(#sqe), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#sqe, float>>(Expression.Property(parameterExpression, methodof(#sqe.get_Snow())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Loads.SustainedLoadFactor).#Vce(#Mce.#Y3(#Oce.#ob));
		}
	}
}
