using System;
using System.Linq.Expressions;
using #2be;
using #7hc;
using FluentValidation;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;

namespace StructurePoint.CoreAssets.AppManager.Column.Validation
{
	// Token: 0x02001022 RID: 4130
	public sealed class SlendernessOfDesignedColumnValidator : #tce<ISlendernessOfDesignedColumn>
	{
		// Token: 0x06008DEF RID: 36335 RVA: 0x001E3A94 File Offset: 0x001E1C94
		public SlendernessOfDesignedColumnValidator(#ice context, #Nce validatedItemType) : base(context)
		{
			ParameterExpression parameterExpression = Expression.Parameter(typeof(ISlendernessOfDesignedColumn), #Phc.#3hc(107246162));
			base.RuleFor<float>(Expression.Lambda<Func<ISlendernessOfDesignedColumn, float>>(Expression.Property(parameterExpression, methodof(ISlendernessOfDesignedColumn.get_Height())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Slenderness.DesignedColumnHeight).#Vce(new #xce(validatedItemType, #Oce.#cb));
			parameterExpression = Expression.Parameter(typeof(ISlendernessOfDesignedColumn), #Phc.#3hc(107246162));
			base.RuleFor<float>(Expression.Lambda<Func<ISlendernessOfDesignedColumn, float>>(Expression.Property(parameterExpression, methodof(ISlendernessOfDesignedColumn.get_SumPc())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Slenderness.DesignedColumnSumPc).#Vce(new #xce(validatedItemType, #Oce.#tb));
			parameterExpression = Expression.Parameter(typeof(ISlendernessOfDesignedColumn), #Phc.#3hc(107246162));
			base.RuleFor<float>(Expression.Lambda<Func<ISlendernessOfDesignedColumn, float>>(Expression.Property(parameterExpression, methodof(ISlendernessOfDesignedColumn.get_SumPu())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Slenderness.DesignedColumnSumPu).#Vce(new #xce(validatedItemType, #Oce.#sb));
			parameterExpression = Expression.Parameter(typeof(ISlendernessOfDesignedColumn), #Phc.#3hc(107246162));
			base.RuleFor<float>(Expression.Lambda<Func<ISlendernessOfDesignedColumn, float>>(Expression.Property(parameterExpression, methodof(ISlendernessOfDesignedColumn.get_Kbraced())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Slenderness.DesignedColumnKBraced).When(new Func<ISlendernessOfDesignedColumn, bool>(SlendernessOfDesignedColumnValidator.<>c.<>9.#s9e), ApplyConditionTo.AllValidators).#Vce(new #xce(validatedItemType, #Oce.#ub));
			parameterExpression = Expression.Parameter(typeof(ISlendernessOfDesignedColumn), #Phc.#3hc(107246162));
			base.RuleFor<float>(Expression.Lambda<Func<ISlendernessOfDesignedColumn, float>>(Expression.Property(parameterExpression, methodof(ISlendernessOfDesignedColumn.get_Ksway())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Slenderness.DesignedColumnKSway).When(new Func<ISlendernessOfDesignedColumn, bool>(SlendernessOfDesignedColumnValidator.<>c.<>9.#d9e), ApplyConditionTo.AllValidators).#Vce(new #xce(validatedItemType, #Oce.#vb));
		}
	}
}
