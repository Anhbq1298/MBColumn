using System;
using #9pe;
using #EZ;
using #YZ;
using FluentValidation.Results;
using StructurePoint.CoreAssets.AppManager.Column.Validation;
using StructurePoint.Products.Column.Services.API;

namespace #jZ
{
	// Token: 0x02000387 RID: 903
	internal sealed class #tZ : #GZ<#hqe>, #FZ<#hqe>, #HZ, #0Z
	{
		// Token: 0x06001D58 RID: 7512 RVA: 0x0001C1D0 File Offset: 0x0001A3D0
		public #tZ(ICoreServices #0c)
		{
			this.#a = #0c;
		}

		// Token: 0x06001D59 RID: 7513 RVA: 0x0001C1DF File Offset: 0x0001A3DF
		public override ValidationResult #IH(#hqe #ty)
		{
			return new SteelStrengthValidator(this.#a.Project.Model.#BY()).Validate(#ty);
		}

		// Token: 0x04000BBA RID: 3002
		private readonly ICoreServices #a;
	}
}
