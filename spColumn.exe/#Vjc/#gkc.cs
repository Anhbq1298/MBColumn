using System;
using System.Runtime.CompilerServices;
using #2ic;
using StructurePoint.CoreAssets.DataExchange.ExternFormat;

namespace #Vjc
{
	// Token: 0x02000779 RID: 1913
	internal sealed class #gkc : #ijc, ILine
	{
		// Token: 0x170012A7 RID: 4775
		// (get) Token: 0x06003D82 RID: 15746 RVA: 0x00034A71 File Offset: 0x00032C71
		// (set) Token: 0x06003D83 RID: 15747 RVA: 0x00034A79 File Offset: 0x00032C79
		public IPoint EndPoint { get; set; }

		// Token: 0x170012A8 RID: 4776
		// (get) Token: 0x06003D84 RID: 15748 RVA: 0x00034A82 File Offset: 0x00032C82
		// (set) Token: 0x06003D85 RID: 15749 RVA: 0x00034A8A File Offset: 0x00032C8A
		public IPoint StartPoint { get; set; }

		// Token: 0x170012A9 RID: 4777
		// (get) Token: 0x06003D86 RID: 15750 RVA: 0x00034A93 File Offset: 0x00032C93
		// (set) Token: 0x06003D87 RID: 15751 RVA: 0x00034A9B File Offset: 0x00032C9B
		public #jjc Layer { get; set; }

		// Token: 0x06003D88 RID: 15752 RVA: 0x00034AA4 File Offset: 0x00032CA4
		public #gkc(#mkc #Xrb, #mkc #Yrb, #fkc #rR)
		{
			this.StartPoint = #Xrb;
			this.EndPoint = #Yrb;
			this.Layer = #rR;
		}

		// Token: 0x04001BEE RID: 7150
		[CompilerGenerated]
		private IPoint #a;

		// Token: 0x04001BEF RID: 7151
		[CompilerGenerated]
		private IPoint #b;

		// Token: 0x04001BF0 RID: 7152
		[CompilerGenerated]
		private #jjc #c;
	}
}
