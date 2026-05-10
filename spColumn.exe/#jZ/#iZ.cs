using System;
using #9pe;
using #EZ;
using #YZ;
using FluentValidation.Results;
using StructurePoint.CoreAssets.AppManager.Column.Validation;
using StructurePoint.Products.Column.Services.API;

namespace #jZ
{
	// Token: 0x0200036C RID: 876
	internal sealed class #iZ : #GZ<#iqe>, #FZ<#iqe>, #HZ, #ZZ
	{
		// Token: 0x06001D34 RID: 7476 RVA: 0x0001BF3F File Offset: 0x0001A13F
		public #iZ(ICoreServices #0c)
		{
			this.#a = #0c;
		}

		// Token: 0x06001D35 RID: 7477 RVA: 0x0001BF4E File Offset: 0x0001A14E
		public override ValidationResult #IH(#iqe #ty)
		{
			return new ConcreteStrengthValidator(this.#a.Project.Model.#BY()).Validate(#ty);
		}

		// Token: 0x04000BAA RID: 2986
		private readonly ICoreServices #a;
	}
}
