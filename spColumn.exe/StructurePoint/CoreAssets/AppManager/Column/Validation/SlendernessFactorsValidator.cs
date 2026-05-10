using System;
using System.Linq.Expressions;
using #2be;
using #7hc;
using #npe;

namespace StructurePoint.CoreAssets.AppManager.Column.Validation
{
	// Token: 0x0200101D RID: 4125
	public sealed class SlendernessFactorsValidator : #tce<#Xpe>
	{
		// Token: 0x06008DE3 RID: 36323 RVA: 0x001E36C4 File Offset: 0x001E18C4
		public SlendernessFactorsValidator(#ice context) : base(context)
		{
			ParameterExpression parameterExpression = Expression.Parameter(typeof(#Xpe), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#Xpe, float>>(Expression.Property(parameterExpression, methodof(#Xpe.get_CrackedIBeams())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Slenderness.CrackedIBeams).#Vce(#Mce.#Lce(#Oce.#qb));
			parameterExpression = Expression.Parameter(typeof(#Xpe), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#Xpe, float>>(Expression.Property(parameterExpression, methodof(#Xpe.get_CrackedIColumn())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Slenderness.CrackedIColumns).#Vce(#Mce.#Lce(#Oce.#rb));
			parameterExpression = Expression.Parameter(typeof(#Xpe), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#Xpe, float>>(Expression.Property(parameterExpression, methodof(#Xpe.get_StiffnessReductionFactorPhi())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Slenderness.StiffnessReductionFactorPhi).#Vce(#Mce.#Lce(#Oce.#pb));
		}
	}
}
