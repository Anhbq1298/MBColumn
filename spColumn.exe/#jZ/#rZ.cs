using System;
using #EZ;
using #n8;
using #YZ;
using FluentValidation.Results;
using StructurePoint.CoreAssets.AppManager.Column.Validation;
using StructurePoint.Products.Column.Services.API;

namespace #jZ
{
	// Token: 0x02000385 RID: 901
	internal sealed class #rZ : #GZ<#I8>, #FZ<#I8>, #HZ, #3Z
	{
		// Token: 0x06001D55 RID: 7509 RVA: 0x0001C17C File Offset: 0x0001A37C
		public #rZ(ICoreServices #0c) : this(#0c, true)
		{
		}

		// Token: 0x06001D56 RID: 7510 RVA: 0x0001C186 File Offset: 0x0001A386
		internal #rZ(ICoreServices #0c, bool #sZ)
		{
			this.#a = #0c;
			this.#b = #sZ;
		}

		// Token: 0x06001D57 RID: 7511 RVA: 0x0001C19C File Offset: 0x0001A39C
		public override ValidationResult #IH(#I8 #ty)
		{
			return new ReductionFactorsValidator(this.#a.Project.Model.#BY(), this.#b).Validate(#ty);
		}

		// Token: 0x04000BB8 RID: 3000
		private readonly ICoreServices #a;

		// Token: 0x04000BB9 RID: 3001
		private readonly bool #b;
	}
}
