using System;
using System.Runtime.CompilerServices;

namespace #eU
{
	// Token: 0x02000319 RID: 793
	internal sealed class #mW<#Fu> : EventArgs
	{
		// Token: 0x06001B60 RID: 7008 RVA: 0x0001AAFA File Offset: 0x00018CFA
		public #mW(#Fu #Zr, #Fu #0r)
		{
			this.#a = #Zr;
			this.#b = #0r;
		}

		// Token: 0x170009D5 RID: 2517
		// (get) Token: 0x06001B61 RID: 7009 RVA: 0x0001AB10 File Offset: 0x00018D10
		public #Fu OldValue { get; }

		// Token: 0x170009D6 RID: 2518
		// (get) Token: 0x06001B62 RID: 7010 RVA: 0x0001AB1C File Offset: 0x00018D1C
		public #Fu NewValue { get; }

		// Token: 0x04000ACF RID: 2767
		[CompilerGenerated]
		private readonly #Fu #a;

		// Token: 0x04000AD0 RID: 2768
		[CompilerGenerated]
		private readonly #Fu #b;
	}
}
