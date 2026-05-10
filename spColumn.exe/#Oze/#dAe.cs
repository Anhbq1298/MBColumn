using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace #Oze
{
	// Token: 0x02001201 RID: 4609
	internal sealed class #dAe
	{
		// Token: 0x17002CCE RID: 11470
		// (get) Token: 0x06009A6F RID: 39535 RVA: 0x0007A4B8 File Offset: 0x000786B8
		public Dictionary<string, #aAe> PmCache { get; } = new Dictionary<string, #aAe>();

		// Token: 0x17002CCF RID: 11471
		// (get) Token: 0x06009A70 RID: 39536 RVA: 0x0007A4C0 File Offset: 0x000786C0
		public Dictionary<string, #aAe> MmCache { get; } = new Dictionary<string, #aAe>();

		// Token: 0x06009A71 RID: 39537 RVA: 0x0007A4C8 File Offset: 0x000786C8
		public void #yl()
		{
			this.PmCache.Clear();
			this.MmCache.Clear();
		}

		// Token: 0x04004269 RID: 17001
		[CompilerGenerated]
		private readonly Dictionary<string, #aAe> #a;

		// Token: 0x0400426A RID: 17002
		[CompilerGenerated]
		private readonly Dictionary<string, #aAe> #b;
	}
}
