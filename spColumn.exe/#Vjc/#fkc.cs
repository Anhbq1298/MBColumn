using System;
using System.Runtime.CompilerServices;
using #2ic;

namespace #Vjc
{
	// Token: 0x02000778 RID: 1912
	internal sealed class #fkc : #jjc
	{
		// Token: 0x170012A5 RID: 4773
		// (get) Token: 0x06003D7C RID: 15740 RVA: 0x00034A2A File Offset: 0x00032C2A
		// (set) Token: 0x06003D7D RID: 15741 RVA: 0x00034A32 File Offset: 0x00032C32
		public string Name { get; set; }

		// Token: 0x170012A6 RID: 4774
		// (get) Token: 0x06003D7E RID: 15742 RVA: 0x00034A3B File Offset: 0x00032C3B
		// (set) Token: 0x06003D7F RID: 15743 RVA: 0x00034A43 File Offset: 0x00032C43
		public #1ic Color { get; set; }

		// Token: 0x06003D80 RID: 15744 RVA: 0x00034A4C File Offset: 0x00032C4C
		public #fkc(string #wy)
		{
			this.Name = #wy;
		}

		// Token: 0x06003D81 RID: 15745 RVA: 0x00034A5B File Offset: 0x00032C5B
		public #fkc(string #wy, #1ic #BR)
		{
			this.Name = #wy;
			this.Color = #BR;
		}

		// Token: 0x04001BEC RID: 7148
		[CompilerGenerated]
		private string #a;

		// Token: 0x04001BED RID: 7149
		[CompilerGenerated]
		private #1ic #b;
	}
}
