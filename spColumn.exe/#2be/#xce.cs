using System;
using System.Runtime.CompilerServices;

namespace #2be
{
	// Token: 0x02001038 RID: 4152
	internal sealed class #xce
	{
		// Token: 0x06008E5F RID: 36447 RVA: 0x0007364F File Offset: 0x0007184F
		public #xce(#Nce #R0, #Oce #z8c)
		{
			this.ItemType = #R0;
			this.Property = #z8c;
		}

		// Token: 0x06008E60 RID: 36448 RVA: 0x00073665 File Offset: 0x00071865
		public #xce(#Nce #R0, #Oce #z8c, int #Jpb)
		{
			this.ItemType = #R0;
			this.Property = #z8c;
			this.ItemIndex = new int?(#Jpb);
		}

		// Token: 0x06008E61 RID: 36449 RVA: 0x00073687 File Offset: 0x00071887
		public #xce(#Nce #R0, #Oce #z8c, int? #Jpb, int? #yce)
		{
			this.ItemType = #R0;
			this.Property = #z8c;
			this.ItemIndex = #Jpb;
			this.ItemSubIndex = #yce;
		}

		// Token: 0x17002960 RID: 10592
		// (get) Token: 0x06008E62 RID: 36450 RVA: 0x000736AC File Offset: 0x000718AC
		public #Nce ItemType { get; }

		// Token: 0x17002961 RID: 10593
		// (get) Token: 0x06008E63 RID: 36451 RVA: 0x000736B4 File Offset: 0x000718B4
		public #Oce Property { get; }

		// Token: 0x17002962 RID: 10594
		// (get) Token: 0x06008E64 RID: 36452 RVA: 0x000736BC File Offset: 0x000718BC
		public int? ItemIndex { get; }

		// Token: 0x17002963 RID: 10595
		// (get) Token: 0x06008E65 RID: 36453 RVA: 0x000736C4 File Offset: 0x000718C4
		public int? ItemSubIndex { get; }

		// Token: 0x04003B29 RID: 15145
		[CompilerGenerated]
		private readonly #Nce #a;

		// Token: 0x04003B2A RID: 15146
		[CompilerGenerated]
		private readonly #Oce #b;

		// Token: 0x04003B2B RID: 15147
		[CompilerGenerated]
		private readonly int? #c;

		// Token: 0x04003B2C RID: 15148
		[CompilerGenerated]
		private readonly int? #d;
	}
}
