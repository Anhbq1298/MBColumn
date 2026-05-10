using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using #2be;
using #7hc;
using #9pe;
using FluentValidation;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;

namespace StructurePoint.CoreAssets.AppManager.Column.Validation
{
	// Token: 0x02001005 RID: 4101
	public sealed class ReinforcingSteelMaterialValidator : #tce<#Vai>
	{
		// Token: 0x06008DA6 RID: 36262 RVA: 0x001E26F4 File Offset: 0x001E08F4
		public ReinforcingSteelMaterialValidator(#ice context)
		{
			ReinforcingSteelMaterialValidator.#GTb #GTb = new ReinforcingSteelMaterialValidator.#GTb();
			#GTb.#a = context;
			base..ctor(#GTb.#a);
			base.Include(new SteelStrengthValidator(#GTb.#a));
			ParameterExpression parameterExpression = Expression.Parameter(typeof(#Vai), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#Vai, float>>(Expression.Property(parameterExpression, methodof(#Vai.get_Es())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Materials.Es).#Vce(#Mce.#K2(#Oce.#T));
			parameterExpression = Expression.Parameter(typeof(#Vai), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#Vai, float>>(Expression.Property(parameterExpression, methodof(#Vai.get_Eyt())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Materials.Eyt).When(new Func<#Vai, bool>(#GTb.#g9e), ApplyConditionTo.AllValidators).#Vce(#Mce.#K2(#Oce.#U));
			parameterExpression = Expression.Parameter(typeof(#Vai), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#Vai, float>>(Expression.Property(parameterExpression, methodof(#Vai.get_Eyt())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Materials.EytAci19).When(new Func<#Vai, bool>(#GTb.#Q9e), ApplyConditionTo.AllValidators).#Vce(#Mce.#K2(#Oce.#U));
		}

		// Token: 0x02001007 RID: 4103
		[CompilerGenerated]
		private sealed class #GTb
		{
			// Token: 0x06008DAA RID: 36266 RVA: 0x00072EAA File Offset: 0x000710AA
			internal bool #g9e(#Vai #Hi)
			{
				return !this.#a.IsCsa && this.#a.DesignCode != DesignCodes.ACI19;
			}

			// Token: 0x06008DAB RID: 36267 RVA: 0x00072ECC File Offset: 0x000710CC
			internal bool #Q9e(#Vai #Hi)
			{
				return this.#a.DesignCode == DesignCodes.ACI19;
			}

			// Token: 0x04003ADE RID: 15070
			public #ice #a;
		}
	}
}
