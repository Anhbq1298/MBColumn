using System;
using #BZ;
using #eU;
using #EZ;
using #npe;
using FluentValidation.Results;
using StructurePoint.CoreAssets.AppManager.Column.Validation;

namespace #RY
{
	// Token: 0x02000339 RID: 825
	internal sealed class #UY : #GZ<#Xpe>, #FZ<#Xpe>, #HZ, #CZ
	{
		// Token: 0x06001C93 RID: 7315 RVA: 0x0001BBCD File Offset: 0x00019DCD
		public #UY(#oW #Yc)
		{
			this.#a = #Yc;
		}

		// Token: 0x06001C94 RID: 7316 RVA: 0x0001BBDC File Offset: 0x00019DDC
		public override ValidationResult #IH(#Xpe #ty)
		{
			return new SlendernessFactorsValidator(this.#a.Model.#BY()).Validate(#ty);
		}

		// Token: 0x04000B93 RID: 2963
		private readonly #oW #a;
	}
}
