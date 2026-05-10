using System;
using System.Collections;
using System.Collections.Generic;

namespace #o1d
{
	// Token: 0x02000EEE RID: 3822
	internal sealed class #E9h<#Fu> : IComparer, IComparer<!0>
	{
		// Token: 0x0600874F RID: 34639 RVA: 0x0006E00A File Offset: 0x0006C20A
		public #E9h(Comparison<#Fu> #41d)
		{
			this.#a = #41d;
		}

		// Token: 0x06008750 RID: 34640 RVA: 0x0006E019 File Offset: 0x0006C219
		public int #ntb(#Fu #9o, #Fu #7W)
		{
			return this.#a(#9o, #7W);
		}

		// Token: 0x06008751 RID: 34641 RVA: 0x0006E028 File Offset: 0x0006C228
		public int #ntb(object #C9h, object #D9h)
		{
			return this.#a((!0)((object)#C9h), (!0)((object)#D9h));
		}

		// Token: 0x040037F5 RID: 14325
		private readonly Comparison<#Fu> #a;
	}
}
