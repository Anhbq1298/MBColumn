using System;
using #EZ;
using FluentValidation.Results;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.AppManager.Column.Validation;
using StructurePoint.Products.Column.Services.API;

namespace #WY
{
	// Token: 0x0200033E RID: 830
	internal sealed class #XY : #GZ<IDesignReinforcementSidesDifferent>, #FZ<IDesignReinforcementSidesDifferent>, #HZ, #DZ
	{
		// Token: 0x06001C9B RID: 7323 RVA: 0x0001BC42 File Offset: 0x00019E42
		public #XY(ICoreServices #0c)
		{
			this.#a = #0c;
		}

		// Token: 0x06001C9C RID: 7324 RVA: 0x0001BC51 File Offset: 0x00019E51
		public override ValidationResult #IH(IDesignReinforcementSidesDifferent #ty)
		{
			return new DesignReinforcementDifferentValidator(this.#a.Project.Model.#BY()).Validate(#ty);
		}

		// Token: 0x04000B95 RID: 2965
		private readonly ICoreServices #a;
	}
}
