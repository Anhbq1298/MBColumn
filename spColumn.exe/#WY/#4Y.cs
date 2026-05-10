using System;
using #EZ;
using FluentValidation.Results;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.AppManager.Column.Validation;
using StructurePoint.Products.Column.Services.API;

namespace #WY
{
	// Token: 0x02000351 RID: 849
	internal sealed class #4Y : #GZ<IDesignDimensions>, #FZ<IDesignDimensions>, #HZ, #MZ
	{
		// Token: 0x06001CF7 RID: 7415 RVA: 0x0001BD54 File Offset: 0x00019F54
		public #4Y(ICoreServices #0c)
		{
			this.#a = #0c;
		}

		// Token: 0x06001CF8 RID: 7416 RVA: 0x0001BD63 File Offset: 0x00019F63
		public override ValidationResult #IH(IDesignDimensions #ty)
		{
			return new DesignDimensionsValidator(this.#a.Project.Model.#BY()).Validate(#ty);
		}

		// Token: 0x04000B9B RID: 2971
		private readonly ICoreServices #a;
	}
}
