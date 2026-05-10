using System;
using System.Linq.Expressions;
using #2be;
using #7hc;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;

namespace StructurePoint.CoreAssets.AppManager.Column.Validation
{
	// Token: 0x0200102B RID: 4139
	public class StandardBarValidator : #tce<IStandardBar>
	{
		// Token: 0x06008E0C RID: 36364 RVA: 0x001E40F8 File Offset: 0x001E22F8
		public StandardBarValidator(#ice context, int? index = null) : base(context)
		{
			ParameterExpression parameterExpression = Expression.Parameter(typeof(IStandardBar), #Phc.#3hc(107398878));
			base.RuleFor<int>(Expression.Lambda<Func<IStandardBar, int>>(Expression.Property(parameterExpression, methodof(IStandardBar.get_Size())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.StandardBars.Size).#Vce(#Mce.#Hce(#Oce.#9, index));
			parameterExpression = Expression.Parameter(typeof(IStandardBar), #Phc.#3hc(107398878));
			base.RuleFor<float>(Expression.Lambda<Func<IStandardBar, float>>(Expression.Property(parameterExpression, methodof(IStandardBar.get_Diameter())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.StandardBars.Diameter).#Vce(#Mce.#Hce(#Oce.#ab, index));
			parameterExpression = Expression.Parameter(typeof(IStandardBar), #Phc.#3hc(107398878));
			base.RuleFor<float>(Expression.Lambda<Func<IStandardBar, float>>(Expression.Property(parameterExpression, methodof(IStandardBar.get_Area())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.StandardBars.Area).#Vce(#Mce.#Hce(#Oce.#L, index));
			parameterExpression = Expression.Parameter(typeof(IStandardBar), #Phc.#3hc(107398878));
			base.RuleFor<float>(Expression.Lambda<Func<IStandardBar, float>>(Expression.Property(parameterExpression, methodof(IStandardBar.get_Weight())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.StandardBars.Weight).#Vce(#Mce.#Hce(#Oce.#bb, index));
		}
	}
}
