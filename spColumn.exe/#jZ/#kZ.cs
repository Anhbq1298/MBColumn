using System;
using #2be;
using #EZ;
using #WG;
using FluentValidation.Results;
using StructurePoint.CoreAssets.AppManager.Column.Validation;
using StructurePoint.Products.Column.Model.Validation.API.Definitions;
using StructurePoint.Products.Column.Services.API;

namespace #jZ
{
	// Token: 0x02000373 RID: 883
	internal sealed class #kZ : #GZ<#5G>, #FZ<#5G>, #HZ, IReductionFactorsViewModelValidator
	{
		// Token: 0x06001D3E RID: 7486 RVA: 0x0001BFF4 File Offset: 0x0001A1F4
		public #kZ(ICoreServices #0c)
		{
			this.#a = #0c;
		}

		// Token: 0x06001D3F RID: 7487 RVA: 0x000C11D4 File Offset: 0x000BF3D4
		public override ValidationResult #IH(#5G #ty)
		{
			#ice #ice = this.#a.Project.Model.#BY();
			#ice.Confinement = #ty.ConfinementType;
			return new ReductionFactorsValidator(#ice, true).Validate(#ty);
		}

		// Token: 0x04000BAF RID: 2991
		private readonly ICoreServices #a;
	}
}
