using System;
using #9pe;
using #EZ;
using #QZ;
using FluentValidation.Results;
using StructurePoint.CoreAssets.AppManager.Column.Validation;
using StructurePoint.Products.Column.Services.API;

namespace #cZ
{
	// Token: 0x02000366 RID: 870
	internal sealed class #gZ : #GZ<#pqe>, #FZ<#pqe>, #HZ, #UZ
	{
		// Token: 0x06001D1C RID: 7452 RVA: 0x0001BEF8 File Offset: 0x0001A0F8
		public #gZ(ICoreServices #0c)
		{
			this.#a = #0c;
		}

		// Token: 0x06001D1D RID: 7453 RVA: 0x000C1120 File Offset: 0x000BF320
		public override ValidationResult #IH(#pqe #ty)
		{
			return new ServiceLoadValidator(this.#a.Project.Model.#BY(), null).Validate(#ty);
		}

		// Token: 0x04000BA8 RID: 2984
		private readonly ICoreServices #a;
	}
}
