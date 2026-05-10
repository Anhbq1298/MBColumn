using System;
using System.Runtime.CompilerServices;
using StructurePoint.Kernel.CoreAssets.Importer.DataClasses;

namespace #ID
{
	// Token: 0x02000230 RID: 560
	internal sealed class #iF
	{
		// Token: 0x060012F3 RID: 4851 RVA: 0x00014803 File Offset: 0x00012A03
		public #iF(ETABSProject #xn, bool #m0i)
		{
			this.#a = #xn;
			this.#b = #m0i;
		}

		// Token: 0x170006E1 RID: 1761
		// (get) Token: 0x060012F4 RID: 4852 RVA: 0x00014819 File Offset: 0x00012A19
		public ETABSProject Project { get; }

		// Token: 0x170006E2 RID: 1762
		// (get) Token: 0x060012F5 RID: 4853 RVA: 0x00014825 File Offset: 0x00012A25
		public bool IsNativeProject { get; }

		// Token: 0x040007C2 RID: 1986
		[CompilerGenerated]
		private readonly ETABSProject #a;

		// Token: 0x040007C3 RID: 1987
		[CompilerGenerated]
		private readonly bool #b;
	}
}
