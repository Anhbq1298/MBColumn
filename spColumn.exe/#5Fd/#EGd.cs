using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

namespace #5Fd
{
	// Token: 0x02000D86 RID: 3462
	[DebuggerDisplay("Cells: {Cells.Count}")]
	internal sealed class #EGd
	{
		// Token: 0x06007D60 RID: 32096 RVA: 0x00065EF5 File Offset: 0x000640F5
		public #EGd()
		{
			this.Cells = new List<#BGd>();
		}

		// Token: 0x1700259E RID: 9630
		// (get) Token: 0x06007D61 RID: 32097 RVA: 0x00065F08 File Offset: 0x00064108
		// (set) Token: 0x06007D62 RID: 32098 RVA: 0x00065F14 File Offset: 0x00064114
		public List<#BGd> Cells { get; private set; }

		// Token: 0x06007D63 RID: 32099 RVA: 0x001B9D0C File Offset: 0x001B7F0C
		public #BGd #DGd(int #4jb)
		{
			#EGd.#MZb #MZb = new #EGd.#MZb();
			#MZb.#a = #4jb;
			return this.Cells.FirstOrDefault(new Func<#BGd, bool>(#MZb.#3Ud));
		}

		// Token: 0x04003354 RID: 13140
		[CompilerGenerated]
		private List<#BGd> #a;

		// Token: 0x02000D87 RID: 3463
		[CompilerGenerated]
		private sealed class #MZb
		{
			// Token: 0x06007D65 RID: 32101 RVA: 0x00065F25 File Offset: 0x00064125
			internal bool #3Ud(#BGd #Rf)
			{
				return #Rf.CellIndex == this.#a;
			}

			// Token: 0x04003355 RID: 13141
			public int #a;
		}
	}
}
