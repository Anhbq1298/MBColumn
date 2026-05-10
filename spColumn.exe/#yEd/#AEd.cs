using System;
using System.Collections.Generic;

namespace #yEd
{
	// Token: 0x02000D63 RID: 3427
	internal abstract class #AEd
	{
		// Token: 0x1700256E RID: 9582
		// (get) Token: 0x06007C84 RID: 31876 RVA: 0x00065338 File Offset: 0x00063538
		public IReadOnlyCollection<#xEd> Pages
		{
			get
			{
				return this.#a;
			}
		}

		// Token: 0x06007C85 RID: 31877 RVA: 0x00065344 File Offset: 0x00063544
		protected void #vzc(#xEd #oEd)
		{
			this.#a.Add(#oEd);
		}

		// Token: 0x04003306 RID: 13062
		private readonly List<#xEd> #a = new List<#xEd>();
	}
}
