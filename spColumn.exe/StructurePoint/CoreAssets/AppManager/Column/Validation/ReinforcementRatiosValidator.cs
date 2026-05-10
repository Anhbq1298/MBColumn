using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using #2be;
using #7hc;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;

namespace StructurePoint.CoreAssets.AppManager.Column.Validation
{
	// Token: 0x02000FD3 RID: 4051
	public sealed class ReinforcementRatiosValidator : #tce<IReinforcementRatios>
	{
		// Token: 0x06008CF4 RID: 36084 RVA: 0x001DF514 File Offset: 0x001DD714
		public ReinforcementRatiosValidator(#ice context, bool valuesInPercentages = false)
		{
			ReinforcementRatiosValidator.#GTb #GTb = new ReinforcementRatiosValidator.#GTb();
			base..ctor(context);
			#GTb.#a = this;
			#GTb.#b = (valuesInPercentages ? 1.0 : 0.01);
			ParameterExpression parameterExpression = Expression.Parameter(typeof(IReinforcementRatios), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<IReinforcementRatios, float>>(Expression.Property(parameterExpression, methodof(IReinforcementRatios.get_MinReinforcementRatio())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.DesignCriteria.MinReinforcementRatio.#83d(#GTb.#b).#4ce(1.0 / #GTb.#b)).#Vce(#Mce.#Gce(#Oce.#2));
			parameterExpression = Expression.Parameter(typeof(IReinforcementRatios), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<IReinforcementRatios, float>>(Expression.Property(parameterExpression, methodof(IReinforcementRatios.get_MaxReinforcementRatio())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(new Func<IReinforcementRatios, float, #6ce>(#GTb.#g9e)).#Vce(#Mce.#Gce(#Oce.#3));
		}

		// Token: 0x02000FD5 RID: 4053
		[CompilerGenerated]
		private sealed class #GTb
		{
			// Token: 0x06008CF8 RID: 36088 RVA: 0x001DF63C File Offset: 0x001DD83C
			internal #6ce #g9e(IReinforcementRatios #Rf, float #Hi)
			{
				return new #6ce(new double?(Math.Min((double)#Rf.MinReinforcementRatio, this.#a.Boundaries.DesignCriteria.MinReinforcementRatio.Max.GetValueOrDefault())), this.#a.Boundaries.DesignCriteria.MaxReinforcementRatio.Max, false, true, 2).#83d(this.#b).#4ce(1.0 / this.#b).#2ce();
			}

			// Token: 0x04003A8C RID: 14988
			public ReinforcementRatiosValidator #a;

			// Token: 0x04003A8D RID: 14989
			public double #b;
		}
	}
}
