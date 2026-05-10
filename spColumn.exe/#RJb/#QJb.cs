using System;
using System.Runtime.CompilerServices;

namespace #RJb
{
	// Token: 0x02000648 RID: 1608
	internal sealed class #QJb : EventArgs
	{
		// Token: 0x06003603 RID: 13827 RVA: 0x0002F536 File Offset: 0x0002D736
		public #QJb(#zLb #SJb, #zLb #TJb)
		{
			this.#a = #SJb;
			this.NewScope = #TJb;
		}

		// Token: 0x170010D9 RID: 4313
		// (get) Token: 0x06003604 RID: 13828 RVA: 0x0002F54C File Offset: 0x0002D74C
		public #zLb OldScope { get; }

		// Token: 0x170010DA RID: 4314
		// (get) Token: 0x06003605 RID: 13829 RVA: 0x0002F558 File Offset: 0x0002D758
		// (set) Token: 0x06003606 RID: 13830 RVA: 0x0002F564 File Offset: 0x0002D764
		public #zLb NewScope { get; set; }

		// Token: 0x0400167D RID: 5757
		[CompilerGenerated]
		private readonly #zLb #a;

		// Token: 0x0400167E RID: 5758
		[CompilerGenerated]
		private #zLb #b;
	}
}
