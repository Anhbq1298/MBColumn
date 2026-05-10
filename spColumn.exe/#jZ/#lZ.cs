using System;
using #EZ;
using FluentValidation.Results;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.AppManager.Column.Validation;
using StructurePoint.Products.Column.Model.Validation.API.Definitions;
using StructurePoint.Products.Column.Services.API;

namespace #jZ
{
	// Token: 0x02000375 RID: 885
	internal sealed class #lZ : #GZ<IReinforcementRatios>, #FZ<IReinforcementRatios>, #HZ, IReinforcementRatiosValidator
	{
		// Token: 0x06001D40 RID: 7488 RVA: 0x0001C003 File Offset: 0x0001A203
		public #lZ(ICoreServices #0c)
		{
			this.#a = #0c;
		}

		// Token: 0x06001D41 RID: 7489 RVA: 0x0001C012 File Offset: 0x0001A212
		public override ValidationResult #IH(IReinforcementRatios #ty)
		{
			return new ReinforcementRatiosValidator(this.#a.Project.Model.#BY(), true).Validate(#ty);
		}

		// Token: 0x04000BB0 RID: 2992
		private readonly ICoreServices #a;
	}
}
