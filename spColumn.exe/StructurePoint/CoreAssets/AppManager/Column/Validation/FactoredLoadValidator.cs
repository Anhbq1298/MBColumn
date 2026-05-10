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
	// Token: 0x02000FE3 RID: 4067
	public sealed class FactoredLoadValidator : #tce<#dqe>
	{
		// Token: 0x06008D36 RID: 36150 RVA: 0x001E0C00 File Offset: 0x001DEE00
		public FactoredLoadValidator(#ice context, int? index = null)
		{
			FactoredLoadValidator.#GTb #GTb = new FactoredLoadValidator.#GTb();
			#GTb.#a = context;
			base..ctor(#GTb.#a);
			ParameterExpression parameterExpression = Expression.Parameter(typeof(#dqe), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#dqe, float>>(Expression.Property(parameterExpression, methodof(#dqe.get_MomentX())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Loads.MomentX).When(new Func<#dqe, bool>(#GTb.#P7b), ApplyConditionTo.AllValidators).#Vce(#Mce.#Ice(#Oce.#db, index));
			parameterExpression = Expression.Parameter(typeof(#dqe), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#dqe, float>>(Expression.Property(parameterExpression, methodof(#dqe.get_MomentY())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Loads.MomentY).When(new Func<#dqe, bool>(#GTb.#78e), ApplyConditionTo.AllValidators).#Vce(#Mce.#Ice(#Oce.#eb, index));
			parameterExpression = Expression.Parameter(typeof(#dqe), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#dqe, float>>(Expression.Property(parameterExpression, methodof(#dqe.get_AxialLoad())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Loads.AxialLoad).#Vce(#Mce.#Ice(#Oce.#fb, index));
		}

		// Token: 0x02000FE5 RID: 4069
		[CompilerGenerated]
		private sealed class #GTb
		{
			// Token: 0x06008D3A RID: 36154 RVA: 0x00072AA9 File Offset: 0x00070CA9
			internal bool #P7b(#dqe #Hi)
			{
				return this.#a.IsXAxisEnabled || this.#a.ActiveLoad == LoadType.Axial;
			}

			// Token: 0x06008D3B RID: 36155 RVA: 0x00072AC8 File Offset: 0x00070CC8
			internal bool #78e(#dqe #Hi)
			{
				return this.#a.IsYAxisEnabled || this.#a.ActiveLoad == LoadType.Axial;
			}

			// Token: 0x04003AAC RID: 15020
			public #ice #a;
		}
	}
}
