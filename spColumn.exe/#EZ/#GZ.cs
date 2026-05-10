using System;
using FluentValidation.Results;

namespace #EZ
{
	// Token: 0x02000331 RID: 817
	internal abstract class #GZ<#Fu> : #FZ<!0>, #HZ
	{
		// Token: 0x06001C8A RID: 7306
		public abstract ValidationResult #IH(#Fu #ty);

		// Token: 0x06001C8B RID: 7307 RVA: 0x0001BB40 File Offset: 0x00019D40
		public ValidationResult #IH(object #ty)
		{
			return this.#IH((!0)((object)#ty));
		}
	}
}
