using System;
using FluentValidation;
using FluentValidation.Internal;
using FluentValidation.Results;
using StructurePoint.Products.Column.Model.Entities;

namespace #aZ
{
	// Token: 0x02000357 RID: 855
	internal static class #9Y
	{
		// Token: 0x06001D01 RID: 7425 RVA: 0x000C0F20 File Offset: 0x000BF120
		public static #sR #IH<#sR>(this #sR #8Y, IValidator #ns) where #sR : ValidatableBaseEntity
		{
			ValidationResult validationResult = #ns.Validate(new ValidationContext<!!0>(#8Y, new PropertyChain(), new DefaultValidatorSelector()));
			foreach (ValidationFailure validationFailure in validationResult.Errors)
			{
				#8Y.AddError(validationFailure.PropertyName, validationFailure.ErrorMessage);
			}
			return #8Y;
		}
	}
}
