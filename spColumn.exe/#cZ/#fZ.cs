using System;
using #2be;
using #9pe;
using #EZ;
using #QZ;
using FluentValidation.Results;
using StructurePoint.CoreAssets.AppManager.Column.Validation;
using StructurePoint.Products.Column.Services.API;

namespace #cZ
{
	// Token: 0x02000363 RID: 867
	internal sealed class #fZ : #GZ<#qqe>, #FZ<#qqe>, #HZ, #TZ
	{
		// Token: 0x06001D10 RID: 7440 RVA: 0x0001BEE9 File Offset: 0x0001A0E9
		public #fZ(ICoreServices #0c)
		{
			this.#a = #0c;
		}

		// Token: 0x06001D11 RID: 7441 RVA: 0x000C10DC File Offset: 0x000BF2DC
		public override ValidationResult #IH(#qqe #ty)
		{
			return new ServiceLoadCaseDataValidator(this.#a.Project.Model.#BY(), null, #Nce.#o).Validate(#ty);
		}

		// Token: 0x04000BA7 RID: 2983
		private readonly ICoreServices #a;
	}
}
