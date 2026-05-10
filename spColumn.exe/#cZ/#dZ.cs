using System;
using #9pe;
using #EZ;
using #QZ;
using FluentValidation.Results;
using StructurePoint.CoreAssets.AppManager.Column.Validation;
using StructurePoint.Products.Column.Services.API;

namespace #cZ
{
	// Token: 0x0200035A RID: 858
	internal sealed class #dZ : #GZ<#dqe>, #FZ<#dqe>, #HZ, #PZ
	{
		// Token: 0x06001D04 RID: 7428 RVA: 0x0001BE42 File Offset: 0x0001A042
		public #dZ(ICoreServices #0c)
		{
			this.#a = #0c;
		}

		// Token: 0x06001D05 RID: 7429 RVA: 0x000C0FE4 File Offset: 0x000BF1E4
		public override ValidationResult #IH(#dqe #ty)
		{
			return new FactoredLoadValidator(this.#a.Project.Model.#BY(), null).Validate(#ty);
		}

		// Token: 0x04000BA2 RID: 2978
		private readonly ICoreServices #a;
	}
}
