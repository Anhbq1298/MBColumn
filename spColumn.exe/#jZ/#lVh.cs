using System;
using #9pe;
using #EZ;
using FluentValidation.Results;
using StructurePoint.CoreAssets.AppManager.Column.Validation;
using StructurePoint.Products.Column.Services.API;

namespace #jZ
{
	// Token: 0x0200037E RID: 894
	internal sealed class #lVh : #GZ<#Uai>, #FZ<#Uai>, #HZ, #kVh
	{
		// Token: 0x06001D4F RID: 7503 RVA: 0x0001C0C5 File Offset: 0x0001A2C5
		public #lVh(ICoreServices #0c)
		{
			this.#a = #0c;
		}

		// Token: 0x06001D50 RID: 7504 RVA: 0x0001C0D4 File Offset: 0x0001A2D4
		public override ValidationResult #IH(#Uai #ty)
		{
			return new ConcreteMaterialValidator(this.#a.Project.Model.#BY()).Validate(#ty);
		}

		// Token: 0x04000BB5 RID: 2997
		private readonly ICoreServices #a;
	}
}
