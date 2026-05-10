using System;
using System.ComponentModel;
using System.Windows;

namespace #ezc
{
	// Token: 0x02000199 RID: 409
	internal interface #WBc : #QBc
	{
		// Token: 0x06000D58 RID: 3416
		void #od();

		// Token: 0x06000D59 RID: 3417
		bool? #TBc();

		// Token: 0x06000D5A RID: 3418
		void #Fgc();

		// Token: 0x06000D5B RID: 3419
		void SetOwner(object owner);

		// Token: 0x1700054E RID: 1358
		// (get) Token: 0x06000D5C RID: 3420
		// (set) Token: 0x06000D5D RID: 3421
		bool? DialogResult { get; set; }

		// Token: 0x14000026 RID: 38
		// (add) Token: 0x06000D5E RID: 3422
		// (remove) Token: 0x06000D5F RID: 3423
		event CancelEventHandler Closing;

		// Token: 0x14000027 RID: 39
		// (add) Token: 0x06000D60 RID: 3424
		// (remove) Token: 0x06000D61 RID: 3425
		event RoutedEventHandler Loaded;
	}
}
