using System;
using #9pe;
using #EZ;
using #QZ;
using FluentValidation.Results;
using StructurePoint.CoreAssets.AppManager.Column.Validation;
using StructurePoint.Products.Column.Services.API;

namespace #cZ
{
	// Token: 0x0200035C RID: 860
	internal sealed class #eZ : #GZ<#gqe>, #FZ<#gqe>, #HZ, #SZ
	{
		// Token: 0x06001D06 RID: 7430 RVA: 0x0001BE51 File Offset: 0x0001A051
		public #eZ(ICoreServices #0c)
		{
			this.#a = #0c;
		}

		// Token: 0x06001D07 RID: 7431 RVA: 0x000C1028 File Offset: 0x000BF228
		public override ValidationResult #IH(#gqe #ty)
		{
			return new LoadFactorValidator(this.#a.Project.Model.#BY(), null).Validate(#ty);
		}

		// Token: 0x04000BA3 RID: 2979
		private readonly ICoreServices #a;
	}
}
