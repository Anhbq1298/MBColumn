using System;
using System.Runtime.CompilerServices;

namespace #AUi
{
	// Token: 0x020006F1 RID: 1777
	internal sealed class #TUi : EventArgs
	{
		// Token: 0x06003AEF RID: 15087 RVA: 0x000331AE File Offset: 0x000313AE
		public #TUi(int #NHb, int #a7e)
		{
			this.#a = #NHb;
			this.#b = #a7e;
		}

		// Token: 0x17001205 RID: 4613
		// (get) Token: 0x06003AF0 RID: 15088 RVA: 0x000331C4 File Offset: 0x000313C4
		public int Current { get; }

		// Token: 0x17001206 RID: 4614
		// (get) Token: 0x06003AF1 RID: 15089 RVA: 0x000331D0 File Offset: 0x000313D0
		public int Total { get; }

		// Token: 0x04001920 RID: 6432
		[CompilerGenerated]
		private readonly int #a;

		// Token: 0x04001921 RID: 6433
		[CompilerGenerated]
		private readonly int #b;
	}
}
