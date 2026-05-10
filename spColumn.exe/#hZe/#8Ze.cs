using System;
using System.Runtime.CompilerServices;

namespace #hZe
{
	// Token: 0x02001327 RID: 4903
	internal sealed class #8Ze : #C2e
	{
		// Token: 0x17002EF2 RID: 12018
		// (get) Token: 0x0600A3B4 RID: 41908 RVA: 0x0007FE24 File Offset: 0x0007E024
		// (set) Token: 0x0600A3B5 RID: 41909 RVA: 0x0007FE2C File Offset: 0x0007E02C
		public int TopBarCount { get; set; }

		// Token: 0x17002EF3 RID: 12019
		// (get) Token: 0x0600A3B6 RID: 41910 RVA: 0x0007FE35 File Offset: 0x0007E035
		// (set) Token: 0x0600A3B7 RID: 41911 RVA: 0x0007FE3D File Offset: 0x0007E03D
		public int SideBarCount { get; set; }

		// Token: 0x0600A3B8 RID: 41912 RVA: 0x0007FE46 File Offset: 0x0007E046
		public void #mg(#8Ze #GUe)
		{
			base.#mg(#GUe);
			this.TopBarCount = #GUe.TopBarCount;
			this.SideBarCount = #GUe.SideBarCount;
		}

		// Token: 0x040047BB RID: 18363
		[CompilerGenerated]
		private int #a;

		// Token: 0x040047BC RID: 18364
		[CompilerGenerated]
		private int #b;
	}
}
