using System;
using #9pe;
using #EZ;
using FluentValidation.Results;
using StructurePoint.CoreAssets.AppManager.Column.Validation;
using StructurePoint.Products.Column.Services.API;

namespace #WY
{
	// Token: 0x0200033B RID: 827
	internal sealed class #VY : #GZ<#aqe>, #FZ<#aqe>, #HZ, #OZ
	{
		// Token: 0x06001C95 RID: 7317 RVA: 0x0001BC05 File Offset: 0x00019E05
		public #VY(IExtendedServices #0c)
		{
			this.#a = #0c;
		}

		// Token: 0x06001C96 RID: 7318 RVA: 0x0001BC14 File Offset: 0x00019E14
		public override ValidationResult #IH(#aqe #ty)
		{
			return new InvestigationDimensionsValidator(this.#a.Project.Model.#BY()).Validate(#ty);
		}

		// Token: 0x04000B94 RID: 2964
		private readonly IExtendedServices #a;
	}
}
