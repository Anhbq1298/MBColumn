using System;
using System.Linq.Expressions;
using #2be;
using #7hc;
using FluentValidation.Internal;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;

namespace StructurePoint.CoreAssets.AppManager.Column.Validation
{
	// Token: 0x02000FC9 RID: 4041
	public sealed class CoreModelValidator : #tce<ColumnStorageModel>
	{
		// Token: 0x06008CA1 RID: 36001 RVA: 0x001DEE24 File Offset: 0x001DD024
		public CoreModelValidator(#ice context) : base(context)
		{
			ParameterExpression parameterExpression = Expression.Parameter(typeof(ColumnStorageModel), #Phc.#3hc(107230552));
			base.RuleFor<Options>(Expression.Lambda<Func<ColumnStorageModel, Options>>(Expression.Property(parameterExpression, methodof(ColumnStorageModel.get_Options())), new ParameterExpression[]
			{
				parameterExpression
			})).SetValidator(new OptionsValidator(context), Array.Empty<string>()).Configure(new Action<PropertyRule>(CoreModelValidator.<>c.<>9.#98e));
		}
	}
}
