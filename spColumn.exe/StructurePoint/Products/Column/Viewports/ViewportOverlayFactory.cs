using System;
using #hg;
using #Xc;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.Viewports.API;

namespace StructurePoint.Products.Column.Viewports
{
	// Token: 0x020000BA RID: 186
	internal sealed class ViewportOverlayFactory : #gg
	{
		// Token: 0x060005DA RID: 1498 RVA: 0x0000A4D4 File Offset: 0x000086D4
		public ViewportOverlayFactory(ICoreServices services)
		{
			this.#a = services;
		}

		// Token: 0x060005DB RID: 1499 RVA: 0x0000A4E3 File Offset: 0x000086E3
		public #ig #Ne()
		{
			return new #2e(new Lazy<IViewportOverlayView>(new Func<IViewportOverlayView>(ViewportOverlayFactory.<>c.<>9.#OTb)), this.#a);
		}

		// Token: 0x0400014B RID: 331
		private readonly ICoreServices #a;
	}
}
