using System;
using #9pe;
using #EZ;
using FluentValidation.Results;
using StructurePoint.CoreAssets.AppManager.Column.Validation;
using StructurePoint.Products.Column.Services.API;

namespace #WY
{
	// Token: 0x0200034A RID: 842
	internal sealed class #2Y : #GZ<#nqe>, #FZ<#nqe>, #HZ, #KZ
	{
		// Token: 0x06001CDF RID: 7391 RVA: 0x0001BD08 File Offset: 0x00019F08
		public #2Y(ICoreServices #0c)
		{
			this.#a = #0c;
		}

		// Token: 0x06001CE0 RID: 7392 RVA: 0x000C0DFC File Offset: 0x000BEFFC
		public override ValidationResult #IH(#nqe #ty)
		{
			return new IrregularReinforcementBarValidator(this.#a.Project.Model.#BY(), null).Validate(#ty);
		}

		// Token: 0x04000B99 RID: 2969
		private readonly ICoreServices #a;
	}
}
