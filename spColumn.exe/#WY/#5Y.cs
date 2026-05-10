using System;
using #9pe;
using #EZ;
using FluentValidation.Results;
using StructurePoint.CoreAssets.AppManager.Column.Validation;
using StructurePoint.Products.Column.Services.API;

namespace #WY
{
	// Token: 0x02000353 RID: 851
	internal sealed class #5Y : #GZ<#aqe>, #FZ<#aqe>, #HZ, #NZ
	{
		// Token: 0x06001CF9 RID: 7417 RVA: 0x0001BD91 File Offset: 0x00019F91
		public #5Y(ICoreServices #0c)
		{
			this.#a = #0c;
		}

		// Token: 0x06001CFA RID: 7418 RVA: 0x0001BDA0 File Offset: 0x00019FA0
		public override ValidationResult #IH(#aqe #ty)
		{
			return new InvestigationDimensionsValidator(this.#a.Project.Model.#BY()).Validate(#ty);
		}

		// Token: 0x04000B9C RID: 2972
		private readonly ICoreServices #a;
	}
}
