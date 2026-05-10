using System;
using System.Runtime.CompilerServices;

namespace #eU
{
	// Token: 0x02000314 RID: 788
	internal sealed class #3V : EventArgs
	{
		// Token: 0x06001B51 RID: 6993 RVA: 0x0001AA14 File Offset: 0x00018C14
		public #3V(bool #xV, string #So)
		{
			this.#a = #xV;
			this.#b = #So;
		}

		// Token: 0x170009CB RID: 2507
		// (get) Token: 0x06001B52 RID: 6994 RVA: 0x0001AA2A File Offset: 0x00018C2A
		public bool IsFilePath { get; }

		// Token: 0x170009CC RID: 2508
		// (get) Token: 0x06001B53 RID: 6995 RVA: 0x0001AA36 File Offset: 0x00018C36
		public string Path { get; }

		// Token: 0x04000AC5 RID: 2757
		[CompilerGenerated]
		private readonly bool #a;

		// Token: 0x04000AC6 RID: 2758
		[CompilerGenerated]
		private readonly string #b;
	}
}
