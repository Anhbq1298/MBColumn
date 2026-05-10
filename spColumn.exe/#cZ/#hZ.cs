using System;
using #9pe;
using #eU;
using #EZ;
using #QZ;
using FluentValidation.Results;
using StructurePoint.CoreAssets.AppManager.Column.Validation;

namespace #cZ
{
	// Token: 0x02000369 RID: 873
	internal sealed class #hZ : #GZ<#sqe>, #FZ<#sqe>, #HZ, #WZ
	{
		// Token: 0x06001D28 RID: 7464 RVA: 0x0001BF07 File Offset: 0x0001A107
		public #hZ(#oW #xn)
		{
			this.#a = #xn;
		}

		// Token: 0x06001D29 RID: 7465 RVA: 0x0001BF16 File Offset: 0x0001A116
		public override ValidationResult #IH(#sqe #ty)
		{
			return new SustainedLoadFactorsValidator(this.#a.Model.#BY()).Validate(#ty);
		}

		// Token: 0x04000BA9 RID: 2985
		private readonly #oW #a;
	}
}
