using System;
using System.Linq.Expressions;
using #2be;
using #7hc;
using #ede;
using #EZ;
using #WG;
using FluentValidation.Results;
using StructurePoint.Products.Column.Model.Validation.API.Definitions;
using StructurePoint.Products.Column.Services.API;

namespace StructurePoint.Products.Column.Model.Validation.Definitions
{
	// Token: 0x02000379 RID: 889
	internal sealed class DesignCriteriaFormValidator : #GZ<#2G>, #FZ<#2G>, #HZ, IDesignCriteriaViewModelValidator
	{
		// Token: 0x06001D4A RID: 7498 RVA: 0x0001C078 File Offset: 0x0001A278
		public DesignCriteriaFormValidator(ICoreServices services)
		{
			this.#a = services;
		}

		// Token: 0x06001D4B RID: 7499 RVA: 0x0001C087 File Offset: 0x0001A287
		public override ValidationResult #IH(#2G #ty)
		{
			return new DesignCriteriaFormValidator.ValidatorImpl(this.#a.Project.Model.#BY()).Validate(#ty);
		}

		// Token: 0x04000BB3 RID: 2995
		private readonly ICoreServices #a;

		// Token: 0x0200037A RID: 890
		private sealed class ValidatorImpl : #tce<#2G>
		{
			// Token: 0x06001D4C RID: 7500 RVA: 0x000C12B8 File Offset: 0x000BF4B8
			public ValidatorImpl(#ice context) : base(context)
			{
				#gee #gee = #6de.#ul(context);
				ParameterExpression parameterExpression = Expression.Parameter(typeof(#2G), #Phc.#3hc(107380690));
				base.RuleFor<float>(Expression.Lambda<Func<#2G, float>>(Expression.Property(parameterExpression, methodof(#2G.get_MinRebarClearSpacing())), new ParameterExpression[]
				{
					parameterExpression
				})).#Tce(#gee.DesignCriteria.MinRebarClearSpacing);
				base.Include(new CapacityRatioValidator.ValidatorImpl(context));
			}
		}
	}
}
