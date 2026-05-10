using System;
using System.Linq.Expressions;
using #2be;
using #7hc;
using #9pe;

namespace StructurePoint.CoreAssets.AppManager.Column.Validation
{
	// Token: 0x02000FBF RID: 4031
	public sealed class AxialLoadValidator : #tce<#8pe>
	{
		// Token: 0x06008C15 RID: 35861 RVA: 0x001DDC6C File Offset: 0x001DBE6C
		public AxialLoadValidator(#ice context, int? index = null) : base(context)
		{
			ParameterExpression parameterExpression = Expression.Parameter(typeof(#8pe), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#8pe, float>>(Expression.Property(parameterExpression, methodof(#8pe.get_InitialLoad())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Loads.AxialLoad).#Vce(#Mce.#Jce(#Oce.#Kb, index));
			parameterExpression = Expression.Parameter(typeof(#8pe), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#8pe, float>>(Expression.Property(parameterExpression, methodof(#8pe.get_FinalLoad())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Loads.AxialLoad).#Vce(#Mce.#Jce(#Oce.#Lb, index));
			parameterExpression = Expression.Parameter(typeof(#8pe), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#8pe, float>>(Expression.Property(parameterExpression, methodof(#8pe.get_Increment())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Loads.AxialLoad).#Vce(#Mce.#Jce(#Oce.#Mb, index));
		}
	}
}
