using System;
using System.Runtime.CompilerServices;

namespace #eU
{
	// Token: 0x02000317 RID: 791
	internal sealed class #fW : EventArgs
	{
		// Token: 0x06001B5C RID: 7004 RVA: 0x0001AAC4 File Offset: 0x00018CC4
		public #fW(bool #gW, bool #hW)
		{
			this.#a = #gW;
			this.#b = #hW;
		}

		// Token: 0x170009D3 RID: 2515
		// (get) Token: 0x06001B5D RID: 7005 RVA: 0x0001AADA File Offset: 0x00018CDA
		public bool SilentNotification { get; }

		// Token: 0x170009D4 RID: 2516
		// (get) Token: 0x06001B5E RID: 7006 RVA: 0x0001AAE6 File Offset: 0x00018CE6
		public bool Success { get; }

		// Token: 0x04000ACD RID: 2765
		[CompilerGenerated]
		private readonly bool #a;

		// Token: 0x04000ACE RID: 2766
		[CompilerGenerated]
		private readonly bool #b;
	}
}
