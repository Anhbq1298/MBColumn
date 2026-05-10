using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using #2be;
using #7hc;
using #9pe;
using FluentValidation;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;

namespace StructurePoint.CoreAssets.AppManager.Column.Validation
{
	// Token: 0x02000FD9 RID: 4057
	public sealed class DesignReinforcementValidator : #tce<#lqe>
	{
		// Token: 0x06008D0A RID: 36106 RVA: 0x001DFBD4 File Offset: 0x001DDDD4
		public DesignReinforcementValidator(#ice context)
		{
			DesignReinforcementValidator.#GTb #GTb = new DesignReinforcementValidator.#GTb();
			#GTb.#a = context;
			base..ctor(#GTb.#a);
			ParameterExpression parameterExpression = Expression.Parameter(typeof(#lqe), #Phc.#3hc(107380695));
			base.RuleFor<DesignReinforcementEqual>(Expression.Lambda<Func<#lqe, DesignReinforcementEqual>>(Expression.Property(parameterExpression, methodof(#lqe.get_AllEqual())), new ParameterExpression[]
			{
				parameterExpression
			})).SetValidator(new DesignReinforcementEqualValidator(#GTb.#a), Array.Empty<string>()).When(new Func<#lqe, bool>(#GTb.#P7b), ApplyConditionTo.AllValidators);
			parameterExpression = Expression.Parameter(typeof(#lqe), #Phc.#3hc(107380695));
			base.RuleFor<DesignReinforcementSidesDifferent>(Expression.Lambda<Func<#lqe, DesignReinforcementSidesDifferent>>(Expression.Property(parameterExpression, methodof(#lqe.get_Different())), new ParameterExpression[]
			{
				parameterExpression
			})).SetValidator(new DesignReinforcementDifferentValidator(#GTb.#a), Array.Empty<string>()).When(new Func<#lqe, bool>(#GTb.#78e), ApplyConditionTo.AllValidators);
		}

		// Token: 0x02000FDB RID: 4059
		[CompilerGenerated]
		private sealed class #GTb
		{
			// Token: 0x06008D0E RID: 36110 RVA: 0x000728E2 File Offset: 0x00070AE2
			internal bool #P7b(#lqe #Hi)
			{
				return this.#a.DesignReinforcement == ReinforcementType.AllEqual || this.#a.DesignReinforcement == ReinforcementType.EqualSpace;
			}

			// Token: 0x06008D0F RID: 36111 RVA: 0x00072901 File Offset: 0x00070B01
			internal bool #78e(#lqe #Hi)
			{
				return this.#a.DesignReinforcement == ReinforcementType.Different;
			}

			// Token: 0x04003A97 RID: 14999
			public #ice #a;
		}
	}
}
