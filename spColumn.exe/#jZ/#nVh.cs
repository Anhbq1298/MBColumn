using System;
using #9pe;
using #EZ;
using FluentValidation.Results;
using StructurePoint.CoreAssets.AppManager.Column.Validation;
using StructurePoint.Products.Column.Services.API;

namespace #jZ
{
	// Token: 0x02000380 RID: 896
	internal sealed class #nVh : #GZ<#Vai>, #FZ<#Vai>, #HZ, #mVh
	{
		// Token: 0x06001D51 RID: 7505 RVA: 0x0001C102 File Offset: 0x0001A302
		public #nVh(ICoreServices #0c)
		{
			this.#a = #0c;
		}

		// Token: 0x06001D52 RID: 7506 RVA: 0x0001C111 File Offset: 0x0001A311
		public override ValidationResult #IH(#Vai #ty)
		{
			return new ReinforcingSteelMaterialValidator(this.#a.Project.Model.#BY()).Validate(#ty);
		}

		// Token: 0x04000BB6 RID: 2998
		private readonly ICoreServices #a;
	}
}
