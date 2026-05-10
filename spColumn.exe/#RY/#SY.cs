using System;
using #2be;
using #9pe;
using #eU;
using #EZ;
using FluentValidation.Results;
using StructurePoint.CoreAssets.AppManager.Column.Validation;
using StructurePoint.Products.Column.Model.Validation.API.Slenderness;

namespace #RY
{
	// Token: 0x02000335 RID: 821
	internal sealed class #SY : #GZ<#rqe>, #FZ<#rqe>, #HZ, ISlendernessColumnsAboveBelowValidator
	{
		// Token: 0x06001C8F RID: 7311 RVA: 0x0001BB5A File Offset: 0x00019D5A
		public #SY(#oW #Yc)
		{
			this.#a = #Yc;
		}

		// Token: 0x06001C90 RID: 7312 RVA: 0x0001BB69 File Offset: 0x00019D69
		public override ValidationResult #IH(#rqe #ty)
		{
			return new SlendernessOfColumnAboveBelowValidator(this.#a.Model.#BY(), #Nce.#t).Validate(#ty);
		}

		// Token: 0x04000B91 RID: 2961
		private readonly #oW #a;
	}
}
