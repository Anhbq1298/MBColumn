using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace #5Fd
{
	// Token: 0x02000D8B RID: 3467
	internal sealed class #QGd
	{
		// Token: 0x06007D7A RID: 32122 RVA: 0x00066041 File Offset: 0x00064241
		public #QGd()
		{
			this.Lines = new List<string>();
		}

		// Token: 0x170025A4 RID: 9636
		// (get) Token: 0x06007D7B RID: 32123 RVA: 0x00066054 File Offset: 0x00064254
		// (set) Token: 0x06007D7C RID: 32124 RVA: 0x00066060 File Offset: 0x00064260
		public List<string> Lines { get; private set; }

		// Token: 0x06007D7D RID: 32125 RVA: 0x00066071 File Offset: 0x00064271
		public string #PGd(string #C6c = "\r\n")
		{
			return \u0003\u0005.\u0096\u000E(#C6c, this.Lines);
		}

		// Token: 0x04003361 RID: 13153
		[CompilerGenerated]
		private List<string> #a;
	}
}
