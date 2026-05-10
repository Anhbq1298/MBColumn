using System;
using System.Runtime.CompilerServices;
using #RJb;

namespace #hg
{
	// Token: 0x020000CE RID: 206
	internal sealed class #og
	{
		// Token: 0x170002F6 RID: 758
		// (get) Token: 0x0600065E RID: 1630 RVA: 0x0000ABA8 File Offset: 0x00008DA8
		// (set) Token: 0x0600065F RID: 1631 RVA: 0x0000ABB4 File Offset: 0x00008DB4
		public #zLb ActiveScope { get; set; }

		// Token: 0x06000660 RID: 1632 RVA: 0x0000ABC5 File Offset: 0x00008DC5
		public void #mg(#og #ng)
		{
			if (#ng == null)
			{
				return;
			}
			this.ActiveScope = #ng.ActiveScope;
		}

		// Token: 0x04000167 RID: 359
		[CompilerGenerated]
		private #zLb #a;
	}
}
