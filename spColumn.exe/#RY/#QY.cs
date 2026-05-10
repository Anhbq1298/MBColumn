using System;
using #2be;
using #eU;
using #EZ;
using FluentValidation.Results;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.AppManager.Column.Validation;
using StructurePoint.Products.Column.Model.Validation.API.Slenderness;

namespace #RY
{
	// Token: 0x02000330 RID: 816
	internal sealed class #QY : #GZ<IBeam>, #FZ<IBeam>, #HZ, ISlendernessBeamsValidator
	{
		// Token: 0x06001C88 RID: 7304 RVA: 0x0001BB06 File Offset: 0x00019D06
		public #QY(#oW #Yc)
		{
			this.#a = #Yc;
		}

		// Token: 0x06001C89 RID: 7305 RVA: 0x0001BB15 File Offset: 0x00019D15
		public override ValidationResult #IH(IBeam #ty)
		{
			return new SlendernessBeamValidator(this.#a.Model.#BY(), #Nce.#I).Validate(#ty);
		}

		// Token: 0x04000B90 RID: 2960
		private readonly #oW #a;
	}
}
