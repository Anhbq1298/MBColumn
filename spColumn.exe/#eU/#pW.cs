using System;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.AppManager.Column.Engineer;

namespace #eU
{
	// Token: 0x0200031B RID: 795
	internal sealed class #pW : EventArgs
	{
		// Token: 0x06001BB2 RID: 7090 RVA: 0x0001AECA File Offset: 0x000190CA
		public #pW(DesignEngine #rj)
		{
			this.#a = #rj;
		}

		// Token: 0x170009D7 RID: 2519
		// (get) Token: 0x06001BB3 RID: 7091 RVA: 0x0001AED9 File Offset: 0x000190D9
		public DesignEngine DesignEngine { get; }

		// Token: 0x04000AEB RID: 2795
		[CompilerGenerated]
		private readonly DesignEngine #a;
	}
}
