using System;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;

namespace #gCc
{
	// Token: 0x02000B5E RID: 2910
	internal sealed class #FCc
	{
		// Token: 0x17001AF0 RID: 6896
		// (get) Token: 0x06005EF8 RID: 24312 RVA: 0x0004ED53 File Offset: 0x0004CF53
		public ConcurrentStack<bool> TransactionChanges { get; } = new ConcurrentStack<bool>();

		// Token: 0x06005EF9 RID: 24313 RVA: 0x0004ED5B File Offset: 0x0004CF5B
		public void #yl()
		{
			ConcurrentStack<bool> concurrentStack = this.TransactionChanges;
			if (!false)
			{
				concurrentStack.Clear();
			}
		}

		// Token: 0x0400273F RID: 10047
		[CompilerGenerated]
		private readonly ConcurrentStack<bool> #a;
	}
}
