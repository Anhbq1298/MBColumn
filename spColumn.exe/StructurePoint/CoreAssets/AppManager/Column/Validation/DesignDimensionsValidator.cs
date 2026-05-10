using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using #2be;
using #7hc;
using FluentValidation;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace StructurePoint.CoreAssets.AppManager.Column.Validation
{
	// Token: 0x02000FD6 RID: 4054
	public sealed class DesignDimensionsValidator : #tce<IDesignDimensions>
	{
		// Token: 0x06008CF9 RID: 36089 RVA: 0x001DF6C4 File Offset: 0x001DD8C4
		public DesignDimensionsValidator(#ice context)
		{
			DesignDimensionsValidator.#GTb #GTb = new DesignDimensionsValidator.#GTb();
			#GTb.#b = context;
			base..ctor(#GTb.#b);
			#GTb.#a = this;
			ParameterExpression parameterExpression = Expression.Parameter(typeof(IDesignDimensions), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<IDesignDimensions, float>>(Expression.Property(parameterExpression, methodof(IDesignDimensions.get_MinWidth())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Core.DesignDimension).#Vce(#Mce.#f1(#Oce.#b));
			parameterExpression = Expression.Parameter(typeof(IDesignDimensions), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<IDesignDimensions, float>>(Expression.Property(parameterExpression, methodof(IDesignDimensions.get_MinWidth())), new ParameterExpression[]
			{
				parameterExpression
			})).Must(new Func<IDesignDimensions, float, bool>(DesignDimensionsValidator.<>c.<>9.#Kbe)).WithMessage(Strings.StringTheValueMustBeSmallerOrEqualToTheEndValue.#z2d()).#Vce(#Mce.#f1(#Oce.#b));
			parameterExpression = Expression.Parameter(typeof(IDesignDimensions), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<IDesignDimensions, float>>(Expression.Property(parameterExpression, methodof(IDesignDimensions.get_MaxWidth())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Core.DesignDimension).#Vce(#Mce.#f1(#Oce.#d));
			parameterExpression = Expression.Parameter(typeof(IDesignDimensions), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<IDesignDimensions, float>>(Expression.Property(parameterExpression, methodof(IDesignDimensions.get_MaxWidth())), new ParameterExpression[]
			{
				parameterExpression
			})).Must(new Func<IDesignDimensions, float, bool>(DesignDimensionsValidator.<>c.<>9.#c9e)).WithMessage(Strings.StringTheValueMustBeGreaterOrEqualToTheStartValue.#z2d()).#Vce(#Mce.#f1(#Oce.#d));
			parameterExpression = Expression.Parameter(typeof(IDesignDimensions), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<IDesignDimensions, float>>(Expression.Property(parameterExpression, methodof(IDesignDimensions.get_WidthIncrement())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(new Func<IDesignDimensions, float, #6ce>(#GTb.#h9e)).When(new Func<IDesignDimensions, ValidationContext<IDesignDimensions>, bool>(DesignDimensionsValidator.<>c.<>9.#e9e), ApplyConditionTo.AllValidators).#Vce(#Mce.#f1(#Oce.#f));
			parameterExpression = Expression.Parameter(typeof(IDesignDimensions), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<IDesignDimensions, float>>(Expression.Property(parameterExpression, methodof(IDesignDimensions.get_MinHeight())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Core.DesignDimension).When(new Func<IDesignDimensions, bool>(#GTb.#j9e), ApplyConditionTo.AllValidators).#Vce(#Mce.#f1(#Oce.#a));
			parameterExpression = Expression.Parameter(typeof(IDesignDimensions), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<IDesignDimensions, float>>(Expression.Property(parameterExpression, methodof(IDesignDimensions.get_MinHeight())), new ParameterExpression[]
			{
				parameterExpression
			})).Must(new Func<IDesignDimensions, float, bool>(DesignDimensionsValidator.<>c.<>9.#p9e)).When(new Func<IDesignDimensions, bool>(#GTb.#k9e), ApplyConditionTo.AllValidators).WithMessage(Strings.StringTheValueMustBeSmallerOrEqualToTheEndValue.#z2d()).#Vce(#Mce.#f1(#Oce.#a));
			parameterExpression = Expression.Parameter(typeof(IDesignDimensions), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<IDesignDimensions, float>>(Expression.Property(parameterExpression, methodof(IDesignDimensions.get_MaxHeight())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Core.DesignDimension).When(new Func<IDesignDimensions, bool>(#GTb.#l9e), ApplyConditionTo.AllValidators).#Vce(#Mce.#f1(#Oce.#c));
			parameterExpression = Expression.Parameter(typeof(IDesignDimensions), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<IDesignDimensions, float>>(Expression.Property(parameterExpression, methodof(IDesignDimensions.get_MaxHeight())), new ParameterExpression[]
			{
				parameterExpression
			})).Must(new Func<IDesignDimensions, float, bool>(DesignDimensionsValidator.<>c.<>9.#q9e)).When(new Func<IDesignDimensions, bool>(#GTb.#m9e), ApplyConditionTo.AllValidators).WithMessage(Strings.StringTheValueMustBeGreaterOrEqualToTheStartValue.#z2d()).#Vce(#Mce.#f1(#Oce.#c));
			parameterExpression = Expression.Parameter(typeof(IDesignDimensions), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<IDesignDimensions, float>>(Expression.Property(parameterExpression, methodof(IDesignDimensions.get_HeightIncrement())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(new Func<IDesignDimensions, float, #6ce>(#GTb.#n9e)).When(new Func<IDesignDimensions, bool>(#GTb.#o9e), ApplyConditionTo.AllValidators).#Vce(#Mce.#f1(#Oce.#e));
		}

		// Token: 0x06008CFA RID: 36090 RVA: 0x000727D7 File Offset: 0x000709D7
		private float #Bbe(float #GT, float #HT)
		{
			return #HT - #GT;
		}

		// Token: 0x02000FD8 RID: 4056
		[CompilerGenerated]
		private sealed class #GTb
		{
			// Token: 0x06008D03 RID: 36099 RVA: 0x00072833 File Offset: 0x00070A33
			internal #6ce #h9e(IDesignDimensions #i9e, float #9o)
			{
				return new #6ce(new double?(0.0), new double?((double)this.#a.#Bbe(#i9e.MinWidth, #i9e.MaxWidth)), true, true, 2).#2ce();
			}

			// Token: 0x06008D04 RID: 36100 RVA: 0x0007286D File Offset: 0x00070A6D
			internal bool #j9e(IDesignDimensions #Rf)
			{
				return this.#b.#Qbe();
			}

			// Token: 0x06008D05 RID: 36101 RVA: 0x0007286D File Offset: 0x00070A6D
			internal bool #k9e(IDesignDimensions #Hi)
			{
				return this.#b.#Qbe();
			}

			// Token: 0x06008D06 RID: 36102 RVA: 0x0007286D File Offset: 0x00070A6D
			internal bool #l9e(IDesignDimensions #Rf)
			{
				return this.#b.#Qbe();
			}

			// Token: 0x06008D07 RID: 36103 RVA: 0x0007286D File Offset: 0x00070A6D
			internal bool #m9e(IDesignDimensions #Hi)
			{
				return this.#b.#Qbe();
			}

			// Token: 0x06008D08 RID: 36104 RVA: 0x0007287A File Offset: 0x00070A7A
			internal #6ce #n9e(IDesignDimensions #i9e, float #9o)
			{
				return new #6ce(new double?(0.0), new double?((double)this.#a.#Bbe(#i9e.MinHeight, #i9e.MaxHeight)), true, true, 2).#2ce();
			}

			// Token: 0x06008D09 RID: 36105 RVA: 0x000728B4 File Offset: 0x00070AB4
			internal bool #o9e(IDesignDimensions #Rf)
			{
				return this.#b.#Qbe() && #Rf.MinHeight <= #Rf.MaxHeight;
			}

			// Token: 0x04003A94 RID: 14996
			public DesignDimensionsValidator #a;

			// Token: 0x04003A95 RID: 14997
			public #ice #b;
		}
	}
}
