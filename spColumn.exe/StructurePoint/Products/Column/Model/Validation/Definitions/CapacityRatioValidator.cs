using System;
using System.Linq.Expressions;
using #2be;
using #7hc;
using #ede;
using #EZ;
using #n8;
using #YZ;
using FluentValidation.Results;
using StructurePoint.Products.Column.Services.API;

namespace StructurePoint.Products.Column.Model.Validation.Definitions
{
	// Token: 0x0200036E RID: 878
	internal sealed class CapacityRatioValidator : #GZ<#p8>, #FZ<#p8>, #HZ, #XZ
	{
		// Token: 0x06001D36 RID: 7478 RVA: 0x0001BF7C File Offset: 0x0001A17C
		public CapacityRatioValidator(ICoreServices services)
		{
			this.#a = services;
		}

		// Token: 0x06001D37 RID: 7479 RVA: 0x0001BF8B File Offset: 0x0001A18B
		public override ValidationResult #IH(#p8 #ty)
		{
			return new CapacityRatioValidator.ValidatorImpl(this.#a.Project.Model.#BY()).Validate(#ty);
		}

		// Token: 0x04000BAB RID: 2987
		private readonly ICoreServices #a;

		// Token: 0x0200036F RID: 879
		internal sealed class ValidatorImpl : #tce<#p8>
		{
			// Token: 0x06001D38 RID: 7480 RVA: 0x000C1164 File Offset: 0x000BF364
			public ValidatorImpl(#ice context) : base(context)
			{
				#gee #gee = #6de.#ul(context);
				ParameterExpression parameterExpression = Expression.Parameter(typeof(#p8), #Phc.#3hc(107380690));
				base.RuleFor<float>(Expression.Lambda<Func<#p8, float>>(Expression.Property(parameterExpression, methodof(#p8.get_CapacityRatio())), new ParameterExpression[]
				{
					parameterExpression
				})).#Tce(#gee.DesignCriteria.CapacityRatio);
			}
		}
	}
}
