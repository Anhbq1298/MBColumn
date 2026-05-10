using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using #2ic;

namespace #Vjc
{
	// Token: 0x02000777 RID: 1911
	internal sealed class #ekc : #ijc
	{
		// Token: 0x170012A3 RID: 4771
		// (get) Token: 0x06003D78 RID: 15736 RVA: 0x000349FB File Offset: 0x00032BFB
		public List<#mkc> BoundaryPoints
		{
			get
			{
				return this.#a;
			}
		}

		// Token: 0x170012A4 RID: 4772
		// (get) Token: 0x06003D79 RID: 15737 RVA: 0x00034A03 File Offset: 0x00032C03
		// (set) Token: 0x06003D7A RID: 15738 RVA: 0x00034A0B File Offset: 0x00032C0B
		public #jjc Layer { get; set; }

		// Token: 0x06003D7B RID: 15739 RVA: 0x00034A14 File Offset: 0x00032C14
		public #ekc(List<#mkc> #6jc, #fkc #rR)
		{
			this.#a = #6jc;
			this.Layer = #rR;
		}

		// Token: 0x04001BEA RID: 7146
		private readonly List<#mkc> #a;

		// Token: 0x04001BEB RID: 7147
		[CompilerGenerated]
		private #jjc #b;
	}
}
