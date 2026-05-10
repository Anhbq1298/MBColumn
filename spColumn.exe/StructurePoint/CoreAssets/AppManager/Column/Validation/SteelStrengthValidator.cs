using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using #2be;
using #7hc;
using #9pe;
using FluentValidation;

namespace StructurePoint.CoreAssets.AppManager.Column.Validation
{
	// Token: 0x0200100C RID: 4108
	public sealed class SteelStrengthValidator : #tce<#hqe>
	{
		// Token: 0x06008DB2 RID: 36274 RVA: 0x001E2914 File Offset: 0x001E0B14
		public SteelStrengthValidator(#ice context)
		{
			SteelStrengthValidator.#GTb #GTb = new SteelStrengthValidator.#GTb();
			#GTb.#a = context;
			base..ctor(#GTb.#a);
			ParameterExpression parameterExpression = Expression.Parameter(typeof(#hqe), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#hqe, float>>(Expression.Property(parameterExpression, methodof(#hqe.get_Fy())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Materials.SteelFyNonCsaNonStandard).When(new Func<#hqe, bool>(#GTb.#P7b), ApplyConditionTo.AllValidators).#Vce(#Mce.#K2(#Oce.#X));
			parameterExpression = Expression.Parameter(typeof(#hqe), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#hqe, float>>(Expression.Property(parameterExpression, methodof(#hqe.get_Fy())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Materials.SteelFyNonCsaStandard).When(new Func<#hqe, bool>(#GTb.#78e), ApplyConditionTo.AllValidators).#Vce(#Mce.#K2(#Oce.#X));
			parameterExpression = Expression.Parameter(typeof(#hqe), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#hqe, float>>(Expression.Property(parameterExpression, methodof(#hqe.get_Fy())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Materials.SteenFyCsaNonStandard).When(new Func<#hqe, bool>(#GTb.#88e), ApplyConditionTo.AllValidators).#Vce(#Mce.#K2(#Oce.#X));
			parameterExpression = Expression.Parameter(typeof(#hqe), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#hqe, float>>(Expression.Property(parameterExpression, methodof(#hqe.get_Fy())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Materials.SteelFyCsaStandard).When(new Func<#hqe, bool>(#GTb.#h9e), ApplyConditionTo.AllValidators).#Vce(#Mce.#K2(#Oce.#X));
		}

		// Token: 0x0200100E RID: 4110
		[CompilerGenerated]
		private sealed class #GTb
		{
			// Token: 0x06008DB6 RID: 36278 RVA: 0x00072F38 File Offset: 0x00071138
			internal bool #P7b(#hqe #9o)
			{
				return !this.#a.IsCsa && !#9o.IsSteelStandard;
			}

			// Token: 0x06008DB7 RID: 36279 RVA: 0x00072F52 File Offset: 0x00071152
			internal bool #78e(#hqe #9o)
			{
				return !this.#a.IsCsa && #9o.IsSteelStandard;
			}

			// Token: 0x06008DB8 RID: 36280 RVA: 0x00072F69 File Offset: 0x00071169
			internal bool #88e(#hqe #9o)
			{
				return this.#a.IsCsa && !#9o.IsSteelStandard;
			}

			// Token: 0x06008DB9 RID: 36281 RVA: 0x00072F83 File Offset: 0x00071183
			internal bool #h9e(#hqe #9o)
			{
				return this.#a.IsCsa && #9o.IsSteelStandard;
			}

			// Token: 0x04003AE3 RID: 15075
			public #ice #a;
		}
	}
}
