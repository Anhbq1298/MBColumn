using System;
using #EZ;
using FluentValidation.Results;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.AppManager.Column.Validation;
using StructurePoint.Products.Column.Services.API;

namespace #WY
{
	// Token: 0x0200034E RID: 846
	internal sealed class #3Y : #GZ<IDesignDimensions>, #FZ<IDesignDimensions>, #HZ, #LZ
	{
		// Token: 0x06001CE9 RID: 7401 RVA: 0x0001BD17 File Offset: 0x00019F17
		public #3Y(ICoreServices #0c)
		{
			this.#a = #0c;
		}

		// Token: 0x06001CEA RID: 7402 RVA: 0x0001BD26 File Offset: 0x00019F26
		public override ValidationResult #IH(IDesignDimensions #ty)
		{
			return new DesignDimensionsValidator(this.#a.Project.Model.#BY()).Validate(#ty);
		}

		// Token: 0x04000B9A RID: 2970
		private readonly ICoreServices #a;
	}
}
