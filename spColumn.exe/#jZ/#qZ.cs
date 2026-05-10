using System;
using #0be;
using #EZ;
using #n8;
using #YZ;
using FluentValidation.Results;
using StructurePoint.Products.Column.Services.API;

namespace #jZ
{
	// Token: 0x02000381 RID: 897
	internal sealed class #qZ : #GZ<#H8>, #FZ<#H8>, #HZ, #2Z
	{
		// Token: 0x06001D53 RID: 7507 RVA: 0x0001C13F File Offset: 0x0001A33F
		public #qZ(ICoreServices #0c)
		{
			this.#a = #0c;
		}

		// Token: 0x06001D54 RID: 7508 RVA: 0x0001C14E File Offset: 0x0001A34E
		public override ValidationResult #IH(#H8 #ty)
		{
			return new #qZ(this.#a.Project.Model.#BY()).Validate(#ty);
		}

		// Token: 0x04000BB7 RID: 2999
		private readonly ICoreServices #a;
	}
}
