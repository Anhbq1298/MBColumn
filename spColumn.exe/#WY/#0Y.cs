using System;
using #9pe;
using #EZ;
using FluentValidation.Results;
using StructurePoint.CoreAssets.AppManager.Column.Validation;
using StructurePoint.Products.Column.Services.API;

namespace #WY
{
	// Token: 0x02000346 RID: 838
	internal sealed class #0Y : #GZ<#bqe>, #FZ<#bqe>, #HZ, #ZY
	{
		// Token: 0x06001CD5 RID: 7381 RVA: 0x0001BC8E File Offset: 0x00019E8E
		public #0Y(IExtendedServices #0c)
		{
			this.#a = #0c;
		}

		// Token: 0x06001CD6 RID: 7382 RVA: 0x0001BC9D File Offset: 0x00019E9D
		public override ValidationResult #IH(#bqe #ty)
		{
			return new InvestigationReinforcementDifferentValidator(this.#a.Project.Model.#BY()).Validate(#ty);
		}

		// Token: 0x04000B97 RID: 2967
		private readonly IExtendedServices #a;
	}
}
