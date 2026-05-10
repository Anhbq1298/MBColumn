using System;
using System.Linq.Expressions;
using #2be;
using #5Z;
using #7hc;
using #ede;
using #eU;
using #EZ;
using #QZ;
using FluentValidation;
using FluentValidation.Results;

namespace StructurePoint.Products.Column.Model.Validation.Loads
{
	// Token: 0x0200035E RID: 862
	internal sealed class SustainedFactorValueValidator : #GZ<#v0>, #FZ<#v0>, #HZ, #VZ
	{
		// Token: 0x06001D08 RID: 7432 RVA: 0x0001BE60 File Offset: 0x0001A060
		public SustainedFactorValueValidator(#oW project)
		{
			this.#a = project;
		}

		// Token: 0x06001D09 RID: 7433 RVA: 0x0001BE6F File Offset: 0x0001A06F
		public override ValidationResult #IH(#v0 #ty)
		{
			return new SustainedFactorValueValidator.ValidatorImpl(this.#a.Model.#BY()).Validate(#ty);
		}

		// Token: 0x04000BA4 RID: 2980
		private readonly #oW #a;

		// Token: 0x0200035F RID: 863
		private sealed class ValidatorImpl : AbstractValidator<#v0>
		{
			// Token: 0x06001D0A RID: 7434 RVA: 0x000C106C File Offset: 0x000BF26C
			public ValidatorImpl(#ice context)
			{
				#gee #gee = #6de.#ul(context);
				ParameterExpression parameterExpression = Expression.Parameter(typeof(#v0), #Phc.#3hc(107380695));
				base.RuleFor<float>(Expression.Lambda<Func<#v0, float>>(Expression.Property(parameterExpression, methodof(#v0.#t0())), new ParameterExpression[]
				{
					parameterExpression
				})).#Tce(#gee.Loads.SustainedLoadFactor);
			}
		}
	}
}
