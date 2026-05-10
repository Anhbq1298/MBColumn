using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using #2ic;

namespace #Vjc
{
	// Token: 0x02000774 RID: 1908
	internal sealed class #5jc : #ijc
	{
		// Token: 0x17001296 RID: 4758
		// (get) Token: 0x06003D60 RID: 15712 RVA: 0x000348C4 File Offset: 0x00032AC4
		public List<#mkc> BoundaryPoints
		{
			get
			{
				return this.#a;
			}
		}

		// Token: 0x17001297 RID: 4759
		// (get) Token: 0x06003D61 RID: 15713 RVA: 0x000348CC File Offset: 0x00032ACC
		// (set) Token: 0x06003D62 RID: 15714 RVA: 0x000348D4 File Offset: 0x00032AD4
		public #jjc Layer { get; set; }

		// Token: 0x06003D63 RID: 15715 RVA: 0x000348DD File Offset: 0x00032ADD
		public #5jc(List<#mkc> #6jc, #fkc #rR)
		{
			this.#a = #6jc;
			this.Layer = #rR;
		}

		// Token: 0x04001BDD RID: 7133
		private readonly List<#mkc> #a;

		// Token: 0x04001BDE RID: 7134
		[CompilerGenerated]
		private #jjc #b;
	}
}
