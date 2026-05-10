using System;
using System.Collections.Generic;

namespace #Vjc
{
	// Token: 0x02000775 RID: 1909
	internal sealed class #9jc
	{
		// Token: 0x17001298 RID: 4760
		// (get) Token: 0x06003D64 RID: 15716 RVA: 0x000348F3 File Offset: 0x00032AF3
		public List<#gkc> Lines
		{
			get
			{
				return this.#a;
			}
		}

		// Token: 0x17001299 RID: 4761
		// (get) Token: 0x06003D65 RID: 15717 RVA: 0x000348FB File Offset: 0x00032AFB
		public List<#Bkc> Solids
		{
			get
			{
				return this.#b;
			}
		}

		// Token: 0x1700129A RID: 4762
		// (get) Token: 0x06003D66 RID: 15718 RVA: 0x00034903 File Offset: 0x00032B03
		public List<#lkc> MultiTexts
		{
			get
			{
				return this.#c;
			}
		}

		// Token: 0x1700129B RID: 4763
		// (get) Token: 0x06003D67 RID: 15719 RVA: 0x0003490B File Offset: 0x00032B0B
		public List<#Ujc> Arcs
		{
			get
			{
				return this.#d;
			}
		}

		// Token: 0x06003D68 RID: 15720 RVA: 0x00034913 File Offset: 0x00032B13
		public #9jc()
		{
			this.#a = new List<#gkc>();
			this.#b = new List<#Bkc>();
			this.#d = new List<#Ujc>();
			this.#c = new List<#lkc>();
		}

		// Token: 0x04001BDF RID: 7135
		private readonly List<#gkc> #a;

		// Token: 0x04001BE0 RID: 7136
		private readonly List<#Bkc> #b;

		// Token: 0x04001BE1 RID: 7137
		private readonly List<#lkc> #c;

		// Token: 0x04001BE2 RID: 7138
		private readonly List<#Ujc> #d;
	}
}
