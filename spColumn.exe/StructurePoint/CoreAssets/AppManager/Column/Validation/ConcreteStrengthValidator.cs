using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using #2be;
using #7hc;
using #9pe;

namespace StructurePoint.CoreAssets.AppManager.Column.Validation
{
	// Token: 0x02001009 RID: 4105
	public sealed class ConcreteStrengthValidator : #tce<#iqe>
	{
		// Token: 0x06008DAD RID: 36269 RVA: 0x001E2884 File Offset: 0x001E0A84
		public ConcreteStrengthValidator(#ice context)
		{
			ConcreteStrengthValidator.#GTb #GTb = new ConcreteStrengthValidator.#GTb();
			#GTb.#b = context;
			base..ctor(#GTb.#b);
			#GTb.#a = this;
			ParameterExpression parameterExpression = Expression.Parameter(typeof(#iqe), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#iqe, float>>(Expression.Property(parameterExpression, methodof(#iqe.get_Fcp())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(new Func<#iqe, float, #6ce>(#GTb.#P7b)).#Vce(#Mce.#K2(#Oce.#W));
		}

		// Token: 0x0200100B RID: 4107
		[CompilerGenerated]
		private sealed class #GTb
		{
			// Token: 0x06008DB1 RID: 36273 RVA: 0x00072F09 File Offset: 0x00071109
			internal #6ce #P7b(#iqe #Rf, float #Hi)
			{
				return this.#a.Boundaries.Materials.#1de(this.#b, #Rf.IsConcreteStandard);
			}

			// Token: 0x04003AE0 RID: 15072
			public ConcreteStrengthValidator #a;

			// Token: 0x04003AE1 RID: 15073
			public #ice #b;
		}
	}
}
