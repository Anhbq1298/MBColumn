using System;
using System.Collections.Generic;
using #3Rd;

namespace #Ted
{
	// Token: 0x02000D26 RID: 3366
	internal interface #rgd
	{
		// Token: 0x17001F1D RID: 7965
		// (get) Token: 0x06006EBA RID: 28346
		string Header { get; }

		// Token: 0x17001F1E RID: 7966
		// (get) Token: 0x06006EBB RID: 28347
		IReadOnlyList<string> Notes { get; }

		// Token: 0x17001F1F RID: 7967
		// (get) Token: 0x06006EBC RID: 28348
		#qSd DocumentMap { get; }

		// Token: 0x17001F20 RID: 7968
		// (get) Token: 0x06006EBD RID: 28349
		// (set) Token: 0x06006EBE RID: 28350
		#0ed CriticalItemsOptions { get; set; }

		// Token: 0x06006EBF RID: 28351
		void #pgd();

		// Token: 0x06006EC0 RID: 28352
		void #qgd();
	}
}
