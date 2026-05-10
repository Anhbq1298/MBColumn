using System;
using System.Runtime.CompilerServices;

namespace #RJb
{
	// Token: 0x02000667 RID: 1639
	internal sealed class #8Jb
	{
		// Token: 0x1700111F RID: 4383
		// (get) Token: 0x0600371D RID: 14109 RVA: 0x0003003A File Offset: 0x0002E23A
		// (set) Token: 0x0600371E RID: 14110 RVA: 0x00030046 File Offset: 0x0002E246
		public bool ShowCover { get; set; }

		// Token: 0x17001120 RID: 4384
		// (get) Token: 0x0600371F RID: 14111 RVA: 0x00030057 File Offset: 0x0002E257
		// (set) Token: 0x06003720 RID: 14112 RVA: 0x00030063 File Offset: 0x0002E263
		public bool SelectBars { get; set; }

		// Token: 0x06003721 RID: 14113 RVA: 0x00030074 File Offset: 0x0002E274
		public void #mg(#8Jb #mA)
		{
			this.ShowCover = #mA.ShowCover;
			this.SelectBars = #mA.SelectBars;
		}

		// Token: 0x040016F9 RID: 5881
		[CompilerGenerated]
		private bool #a;

		// Token: 0x040016FA RID: 5882
		[CompilerGenerated]
		private bool #b = true;
	}
}
