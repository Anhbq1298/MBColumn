using System;
using System.Linq.Expressions;
using #2be;
using #7hc;
using #9pe;

namespace StructurePoint.CoreAssets.AppManager.Column.Validation
{
	// Token: 0x02001012 RID: 4114
	public sealed class ServiceLoadValidator : #tce<#pqe>
	{
		// Token: 0x06008DC0 RID: 36288 RVA: 0x001E2CFC File Offset: 0x001E0EFC
		public ServiceLoadValidator(#ice context, int? index = null) : base(context)
		{
			ParameterExpression parameterExpression = Expression.Parameter(typeof(#pqe), #Phc.#3hc(107380695));
			base.RuleFor<#qqe>(Expression.Lambda<Func<#pqe, #qqe>>(Expression.Property(parameterExpression, methodof(#pqe.#A3())), new ParameterExpression[]
			{
				parameterExpression
			})).SetValidator(new ServiceLoadCaseDataValidator(context, index, #Nce.#o), Array.Empty<string>());
			parameterExpression = Expression.Parameter(typeof(#pqe), #Phc.#3hc(107380695));
			base.RuleFor<#qqe>(Expression.Lambda<Func<#pqe, #qqe>>(Expression.Property(parameterExpression, methodof(#pqe.#C3())), new ParameterExpression[]
			{
				parameterExpression
			})).SetValidator(new ServiceLoadCaseDataValidator(context, index, #Nce.#p), Array.Empty<string>());
			parameterExpression = Expression.Parameter(typeof(#pqe), #Phc.#3hc(107380695));
			base.RuleFor<#qqe>(Expression.Lambda<Func<#pqe, #qqe>>(Expression.Property(parameterExpression, methodof(#pqe.#E3())), new ParameterExpression[]
			{
				parameterExpression
			})).SetValidator(new ServiceLoadCaseDataValidator(context, index, #Nce.#r), Array.Empty<string>());
			parameterExpression = Expression.Parameter(typeof(#pqe), #Phc.#3hc(107380695));
			base.RuleFor<#qqe>(Expression.Lambda<Func<#pqe, #qqe>>(Expression.Property(parameterExpression, methodof(#pqe.#G3())), new ParameterExpression[]
			{
				parameterExpression
			})).SetValidator(new ServiceLoadCaseDataValidator(context, index, #Nce.#q), Array.Empty<string>());
			parameterExpression = Expression.Parameter(typeof(#pqe), #Phc.#3hc(107380695));
			base.RuleFor<#qqe>(Expression.Lambda<Func<#pqe, #qqe>>(Expression.Property(parameterExpression, methodof(#pqe.#I3())), new ParameterExpression[]
			{
				parameterExpression
			})).SetValidator(new ServiceLoadCaseDataValidator(context, index, #Nce.#s), Array.Empty<string>());
		}
	}
}
