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
	// Token: 0x0200101F RID: 4127
	public sealed class SlendernessOfColumnAboveBelowValidator : #tce<#rqe>
	{
		// Token: 0x06008DE6 RID: 36326 RVA: 0x001E380C File Offset: 0x001E1A0C
		public SlendernessOfColumnAboveBelowValidator(#ice context, #Nce itemType)
		{
			SlendernessOfColumnAboveBelowValidator.#GTb #GTb = new SlendernessOfColumnAboveBelowValidator.#GTb();
			#GTb.#b = context;
			base..ctor(#GTb.#b);
			#GTb.#a = this;
			ParameterExpression parameterExpression = Expression.Parameter(typeof(#rqe), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#rqe, float>>(Expression.Property(parameterExpression, methodof(#rqe.get_Depth())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Slenderness.ColumnAboveBelowDepth).When(new Func<#rqe, bool>(this.#Rbe), ApplyConditionTo.AllValidators).#Vce(new #xce(itemType, #Oce.#wb));
			parameterExpression = Expression.Parameter(typeof(#rqe), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#rqe, float>>(Expression.Property(parameterExpression, methodof(#rqe.get_Width())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Slenderness.ColumnAboveBelowWidth).When(new Func<#rqe, bool>(this.#Qbe), ApplyConditionTo.AllValidators).#Vce(new #xce(itemType, #Oce.#xb));
			parameterExpression = Expression.Parameter(typeof(#rqe), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#rqe, float>>(Expression.Property(parameterExpression, methodof(#rqe.get_Ec())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Slenderness.ColumnAboveBelowEc).Unless(new Func<#rqe, bool>(this.#Obe), ApplyConditionTo.AllValidators).#Vce(new #xce(itemType, #Oce.#P));
			parameterExpression = Expression.Parameter(typeof(#rqe), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#rqe, float>>(Expression.Property(parameterExpression, methodof(#rqe.get_Fcp())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(new Func<#rqe, float, #6ce>(#GTb.#Q9e)).Unless(new Func<#rqe, bool>(this.#Obe), ApplyConditionTo.AllValidators).#Vce(new #xce(itemType, #Oce.#W));
			parameterExpression = Expression.Parameter(typeof(#rqe), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#rqe, float>>(Expression.Property(parameterExpression, methodof(#rqe.get_Height())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Slenderness.ColumnAboveBelowHeight).Unless(new Func<#rqe, bool>(this.#Obe), ApplyConditionTo.AllValidators).#Vce(new #xce(itemType, #Oce.#cb));
		}

		// Token: 0x06008DE7 RID: 36327 RVA: 0x000730D9 File Offset: 0x000712D9
		private bool #Obe(#rqe #9bd)
		{
			return #9bd.SlendernessColumnType == SlendernessColumnType.None;
		}

		// Token: 0x06008DE8 RID: 36328 RVA: 0x000730E4 File Offset: 0x000712E4
		private bool #Pbe(#rqe #9bd)
		{
			return #9bd.SlendernessColumnType == SlendernessColumnType.Circular;
		}

		// Token: 0x06008DE9 RID: 36329 RVA: 0x000730EF File Offset: 0x000712EF
		private bool #Qbe(#rqe #9bd)
		{
			return #9bd.SlendernessColumnType == SlendernessColumnType.Rectangular;
		}

		// Token: 0x06008DEA RID: 36330 RVA: 0x000730FA File Offset: 0x000712FA
		private bool #Rbe(#rqe #9bd)
		{
			return this.#Pbe(#9bd) || this.#Qbe(#9bd);
		}

		// Token: 0x02001021 RID: 4129
		[CompilerGenerated]
		private sealed class #GTb
		{
			// Token: 0x06008DEE RID: 36334 RVA: 0x0007311A File Offset: 0x0007131A
			internal #6ce #Q9e(#rqe #Rf, float #Hi)
			{
				return this.#a.Boundaries.Materials.#1de(this.#b, #Rf.IsConcreteStandard);
			}

			// Token: 0x04003AFB RID: 15099
			public SlendernessOfColumnAboveBelowValidator #a;

			// Token: 0x04003AFC RID: 15100
			public #ice #b;
		}
	}
}
