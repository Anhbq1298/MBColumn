using System;
using System.Linq.Expressions;
using #2be;
using #7hc;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;

namespace StructurePoint.CoreAssets.AppManager.Column.Validation
{
	// Token: 0x02000FD1 RID: 4049
	public sealed class DesignCriteriaValidator : #tce<ColumnStorageModel>
	{
		// Token: 0x06008CF1 RID: 36081 RVA: 0x001DF3DC File Offset: 0x001DD5DC
		public DesignCriteriaValidator(#ice context) : base(context)
		{
			ParameterExpression parameterExpression = Expression.Parameter(typeof(ColumnStorageModel), #Phc.#3hc(107380695));
			base.RuleFor<ReinforcementRatios>(Expression.Lambda<Func<ColumnStorageModel, ReinforcementRatios>>(Expression.Property(parameterExpression, methodof(ColumnStorageModel.get_ReinforcementRatios())), new ParameterExpression[]
			{
				parameterExpression
			})).SetValidator(new ReinforcementRatiosValidator(context, false), Array.Empty<string>());
			parameterExpression = Expression.Parameter(typeof(ColumnStorageModel), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<ColumnStorageModel, float>>(Expression.Property(parameterExpression, methodof(ColumnStorageModel.get_DesignToRequiredRatio())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.DesignCriteria.CapacityRatio).#Vce(#Mce.#Gce(#Oce.#4));
			parameterExpression = Expression.Parameter(typeof(ColumnStorageModel), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<ColumnStorageModel, float>>(Expression.Property(parameterExpression, methodof(ColumnStorageModel.get_MinRebarClearSpacing())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.DesignCriteria.MinRebarClearSpacing).#Vce(#Mce.#Gce(#Oce.#5));
		}
	}
}
