using System;
using #FCd;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Paged.WordPdf;

namespace #VEd
{
	// Token: 0x02000D6F RID: 3439
	internal class #qFd : #6Dd
	{
		// Token: 0x06007CD7 RID: 31959 RVA: 0x00065752 File Offset: 0x00063952
		public #qFd(#4Ed #ib)
		{
			this.#a = #ib;
		}

		// Token: 0x06007CD8 RID: 31960 RVA: 0x00065761 File Offset: 0x00063961
		public virtual #5Dd #ul(int #Jhd, params double[] #Zpb)
		{
			return new AsposeTableWriter(this.#a, #Jhd, #Zpb);
		}

		// Token: 0x04003327 RID: 13095
		private readonly #4Ed #a;
	}
}
