using System;
using #EZ;
using FluentValidation.Results;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.AppManager.Column.Validation;
using StructurePoint.Products.Column.Services.API;

namespace #WY
{
	// Token: 0x02000341 RID: 833
	internal sealed class #YY : #GZ<IDesignReinforcementEqual>, #FZ<IDesignReinforcementEqual>, #HZ, #IZ
	{
		// Token: 0x06001CB1 RID: 7345 RVA: 0x0001BC7F File Offset: 0x00019E7F
		public #YY(ICoreServices #0c)
		{
			this.#a = #0c;
		}

		// Token: 0x06001CB2 RID: 7346 RVA: 0x000C0DC0 File Offset: 0x000BEFC0
		public override ValidationResult #IH(IDesignReinforcementEqual #ty)
		{
			DesignReinforcementEqualValidator designReinforcementEqualValidator = new DesignReinforcementEqualValidator(this.#a.Project.Model.#BY());
			return designReinforcementEqualValidator.Validate(#ty);
		}

		// Token: 0x04000B96 RID: 2966
		private readonly ICoreServices #a;
	}
}
