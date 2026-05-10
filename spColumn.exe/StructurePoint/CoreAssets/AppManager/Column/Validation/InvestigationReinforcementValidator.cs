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
	// Token: 0x02000FE9 RID: 4073
	public sealed class InvestigationReinforcementValidator : #tce<#eqe>
	{
		// Token: 0x06008D41 RID: 36161 RVA: 0x001E0E84 File Offset: 0x001DF084
		public InvestigationReinforcementValidator(#ice context)
		{
			InvestigationReinforcementValidator.#GTb #GTb = new InvestigationReinforcementValidator.#GTb();
			#GTb.#a = context;
			base..ctor(#GTb.#a);
			ParameterExpression parameterExpression = Expression.Parameter(typeof(#eqe), #Phc.#3hc(107380695));
			base.RuleFor<InvestigationReinforcementEqual>(Expression.Lambda<Func<#eqe, InvestigationReinforcementEqual>>(Expression.Property(parameterExpression, methodof(#eqe.get_AllEqual())), new ParameterExpression[]
			{
				parameterExpression
			})).SetValidator(new InvestigationReinforcementEqualValidator(#GTb.#a), Array.Empty<string>()).When(new Func<#eqe, bool>(#GTb.#P7b), ApplyConditionTo.AllValidators);
			parameterExpression = Expression.Parameter(typeof(#eqe), #Phc.#3hc(107380695));
			base.RuleFor<InvestigationReinforcementSidesDifferent>(Expression.Lambda<Func<#eqe, InvestigationReinforcementSidesDifferent>>(Expression.Property(parameterExpression, methodof(#eqe.get_Different())), new ParameterExpression[]
			{
				parameterExpression
			})).SetValidator(new InvestigationReinforcementDifferentValidator(#GTb.#a), Array.Empty<string>()).When(new Func<#eqe, bool>(#GTb.#78e), ApplyConditionTo.AllValidators);
		}

		// Token: 0x02000FEB RID: 4075
		[CompilerGenerated]
		private sealed class #GTb
		{
			// Token: 0x06008D45 RID: 36165 RVA: 0x00072B0C File Offset: 0x00070D0C
			internal bool #P7b(#eqe #Hi)
			{
				return this.#a.InvestigationReinforcement == ReinforcementType.AllEqual || this.#a.InvestigationReinforcement == ReinforcementType.EqualSpace;
			}

			// Token: 0x06008D46 RID: 36166 RVA: 0x00072B2B File Offset: 0x00070D2B
			internal bool #78e(#eqe #Hi)
			{
				return this.#a.InvestigationReinforcement == ReinforcementType.Different;
			}

			// Token: 0x04003AB0 RID: 15024
			public #ice #a;
		}
	}
}
