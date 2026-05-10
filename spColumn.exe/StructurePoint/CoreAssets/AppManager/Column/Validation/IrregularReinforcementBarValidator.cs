using System;
using System.Linq.Expressions;
using #2be;
using #7hc;
using #9pe;

namespace StructurePoint.CoreAssets.AppManager.Column.Validation
{
	// Token: 0x02000FF2 RID: 4082
	public sealed class IrregularReinforcementBarValidator : #tce<#nqe>
	{
		// Token: 0x06008D54 RID: 36180 RVA: 0x001E1790 File Offset: 0x001DF990
		public IrregularReinforcementBarValidator(#ice context, int? barIndex = null) : base(context)
		{
			ParameterExpression parameterExpression = Expression.Parameter(typeof(#nqe), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#nqe, float>>(Expression.Property(parameterExpression, methodof(#nqe.get_Area())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Reinforcement.BarArea).#Vce(#Mce.#Dce(#Oce.#L, barIndex));
			parameterExpression = Expression.Parameter(typeof(#nqe), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#nqe, float>>(Expression.Property(parameterExpression, methodof(#mqe.get_X())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Core.ModelCoordinate).#Vce(#Mce.#Dce(#Oce.#M, barIndex));
			parameterExpression = Expression.Parameter(typeof(#nqe), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#nqe, float>>(Expression.Property(parameterExpression, methodof(#mqe.get_Y())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Core.ModelCoordinate).#Vce(#Mce.#Dce(#Oce.#N, barIndex));
			parameterExpression = Expression.Parameter(typeof(#nqe), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#nqe, float>>(Expression.Property(parameterExpression, methodof(#nqe.get_Z())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Core.ModelCoordinate).#Vce(#Mce.#Dce(#Oce.#O, barIndex));
		}
	}
}
