using System;
using System.Runtime.CompilerServices;
using StructurePoint.Products.Column.Viewports.API;

namespace #Xc
{
	// Token: 0x020000A6 RID: 166
	internal sealed class #yd : EventArgs
	{
		// Token: 0x06000570 RID: 1392 RVA: 0x0000A03B File Offset: 0x0000823B
		public #yd(IViewport #zd, IViewport #Ad)
		{
			this.#a = #zd;
			this.#b = #Ad;
		}

		// Token: 0x170002B1 RID: 689
		// (get) Token: 0x06000571 RID: 1393 RVA: 0x0000A051 File Offset: 0x00008251
		public IViewport OldViewport { get; }

		// Token: 0x170002B2 RID: 690
		// (get) Token: 0x06000572 RID: 1394 RVA: 0x0000A05D File Offset: 0x0000825D
		public IViewport NewViewport { get; }

		// Token: 0x04000122 RID: 290
		[CompilerGenerated]
		private readonly IViewport #a;

		// Token: 0x04000123 RID: 291
		[CompilerGenerated]
		private readonly IViewport #b;
	}
}
