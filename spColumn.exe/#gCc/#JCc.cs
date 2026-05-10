using System;
using System.Runtime.CompilerServices;
using #jDc;

namespace #gCc
{
	// Token: 0x02000B5F RID: 2911
	internal sealed class #JCc : EventArgs
	{
		// Token: 0x06005EFB RID: 24315 RVA: 0x0004ED81 File Offset: 0x0004CF81
		public #JCc(#qDc #nd, #JCc.#E8c #C)
		{
			this.Action = #nd;
			this.Type = #C;
		}

		// Token: 0x17001AF1 RID: 6897
		// (get) Token: 0x06005EFC RID: 24316 RVA: 0x0004ED97 File Offset: 0x0004CF97
		public #qDc Action { get; }

		// Token: 0x17001AF2 RID: 6898
		// (get) Token: 0x06005EFD RID: 24317 RVA: 0x0004ED9F File Offset: 0x0004CF9F
		public #JCc.#E8c Type { get; }

		// Token: 0x17001AF3 RID: 6899
		// (get) Token: 0x06005EFE RID: 24318 RVA: 0x0004EDA7 File Offset: 0x0004CFA7
		// (set) Token: 0x06005EFF RID: 24319 RVA: 0x0004EDAF File Offset: 0x0004CFAF
		public bool Discard { get; set; }

		// Token: 0x04002740 RID: 10048
		[CompilerGenerated]
		private readonly #qDc #a;

		// Token: 0x04002741 RID: 10049
		[CompilerGenerated]
		private readonly #JCc.#E8c #b;

		// Token: 0x04002742 RID: 10050
		[CompilerGenerated]
		private bool #c;

		// Token: 0x02000B60 RID: 2912
		public enum #E8c
		{
			// Token: 0x04002744 RID: 10052
			#a,
			// Token: 0x04002745 RID: 10053
			#b,
			// Token: 0x04002746 RID: 10054
			#c
		}
	}
}
