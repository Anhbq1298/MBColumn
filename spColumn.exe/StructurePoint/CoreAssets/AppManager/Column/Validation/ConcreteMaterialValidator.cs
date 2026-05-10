using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using #2be;
using #7hc;
using #9pe;

namespace StructurePoint.CoreAssets.AppManager.Column.Validation
{
	// Token: 0x02001003 RID: 4099
	public sealed class ConcreteMaterialValidator : #tce<#Uai>
	{
		// Token: 0x06008DA2 RID: 36258 RVA: 0x001E2540 File Offset: 0x001E0740
		public ConcreteMaterialValidator(#ice context) : base(context)
		{
			base.Include(new ConcreteStrengthValidator(context));
			ParameterExpression parameterExpression = Expression.Parameter(typeof(#Uai), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#Uai, float>>(Expression.Property(parameterExpression, methodof(#Uai.get_Ec())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Materials.Ec).#Vce(#Mce.#K2(#Oce.#P));
			parameterExpression = Expression.Parameter(typeof(#Uai), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#Uai, float>>(Expression.Property(parameterExpression, methodof(#Uai.get_Fc())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(new Func<#Uai, float, #6ce>(this.#Kbe)).#Vce(#Mce.#K2(#Oce.#Q));
			parameterExpression = Expression.Parameter(typeof(#Uai), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#Uai, float>>(Expression.Property(parameterExpression, methodof(#Uai.get_Beta1())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Materials.Beta1).#Vce(#Mce.#K2(#Oce.#R));
			parameterExpression = Expression.Parameter(typeof(#Uai), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#Uai, float>>(Expression.Property(parameterExpression, methodof(#Uai.get_Eps())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Materials.Eps).#Vce(#Mce.#K2(#Oce.#S));
		}

		// Token: 0x06008DA3 RID: 36259 RVA: 0x00072E62 File Offset: 0x00071062
		[CompilerGenerated]
		private #6ce #Kbe(#Uai #Rf, float #Hi)
		{
			return new #6ce(base.Boundaries.Materials.Fc.Min, new double?((double)#Rf.Fcp), true, true, 2).#2ce();
		}
	}
}
