using System;
using #9pe;
using #eU;
using #EZ;
using #QZ;
using FluentValidation.Results;
using StructurePoint.CoreAssets.AppManager.Column.Validation;

namespace #cZ
{
	// Token: 0x02000358 RID: 856
	internal sealed class #bZ : #GZ<#8pe>, #FZ<#8pe>, #HZ, #RZ
	{
		// Token: 0x06001D02 RID: 7426 RVA: 0x0001BE33 File Offset: 0x0001A033
		public #bZ(#oW #xn)
		{
			this.#a = #xn;
		}

		// Token: 0x06001D03 RID: 7427 RVA: 0x000C0FA4 File Offset: 0x000BF1A4
		public override ValidationResult #IH(#8pe #ty)
		{
			return new AxialLoadValidator(this.#a.Model.#BY(), null).Validate(#ty);
		}

		// Token: 0x04000BA1 RID: 2977
		private readonly #oW #a;
	}
}
