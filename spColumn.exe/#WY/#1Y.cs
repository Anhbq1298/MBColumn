using System;
using #9pe;
using #EZ;
using FluentValidation.Results;
using StructurePoint.CoreAssets.AppManager.Column.Validation;
using StructurePoint.Products.Column.Services.API;

namespace #WY
{
	// Token: 0x02000347 RID: 839
	internal sealed class #1Y : #GZ<#fqe>, #FZ<#fqe>, #HZ, #JZ
	{
		// Token: 0x06001CD7 RID: 7383 RVA: 0x0001BCCB File Offset: 0x00019ECB
		public #1Y(IExtendedServices #0c)
		{
			this.#a = #0c;
		}

		// Token: 0x06001CD8 RID: 7384 RVA: 0x0001BCDA File Offset: 0x00019EDA
		public override ValidationResult #IH(#fqe #ty)
		{
			return new InvestigationReinforcementEqualValidator(this.#a.Project.Model.#BY()).Validate(#ty);
		}

		// Token: 0x04000B98 RID: 2968
		private readonly IExtendedServices #a;
	}
}
