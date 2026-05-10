using System;
using System.Runtime.CompilerServices;
using #ede;
using FluentValidation;

namespace #2be
{
	// Token: 0x02000371 RID: 881
	internal class #tce<#Fu> : AbstractValidator<!0>
	{
		// Token: 0x06001D3B RID: 7483 RVA: 0x0001BFC9 File Offset: 0x0001A1C9
		public #tce(#ice #ib)
		{
			this.Context = #ib;
			this.Boundaries = #6de.#ul(#ib);
		}

		// Token: 0x17000A3F RID: 2623
		// (get) Token: 0x06001D3C RID: 7484 RVA: 0x0001BFE4 File Offset: 0x0001A1E4
		protected #ice Context { get; }

		// Token: 0x17000A40 RID: 2624
		// (get) Token: 0x06001D3D RID: 7485 RVA: 0x0001BFEC File Offset: 0x0001A1EC
		public #gee Boundaries { get; }

		// Token: 0x04000BAD RID: 2989
		[CompilerGenerated]
		private readonly #ice #a;

		// Token: 0x04000BAE RID: 2990
		[CompilerGenerated]
		private readonly #gee #b;
	}
}
