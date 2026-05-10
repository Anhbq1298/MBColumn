using System;
using #2be;
using #BZ;
using #eU;
using #EZ;
using FluentValidation.Results;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.AppManager.Column.Validation;

namespace #RY
{
	// Token: 0x02000337 RID: 823
	internal sealed class #TY : #GZ<ISlendernessOfDesignedColumn>, #FZ<ISlendernessOfDesignedColumn>, #HZ, #AZ
	{
		// Token: 0x06001C91 RID: 7313 RVA: 0x0001BB94 File Offset: 0x00019D94
		public #TY(#oW #Yc)
		{
			this.#a = #Yc;
		}

		// Token: 0x06001C92 RID: 7314 RVA: 0x0001BBA3 File Offset: 0x00019DA3
		public override ValidationResult #IH(ISlendernessOfDesignedColumn #ty)
		{
			return new SlendernessOfDesignedColumnValidator(this.#a.Model.#BY(), #Nce.#g).Validate(#ty);
		}

		// Token: 0x04000B92 RID: 2962
		private readonly #oW #a;
	}
}
