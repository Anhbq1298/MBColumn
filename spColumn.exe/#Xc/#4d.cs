using System;
using System.Runtime.CompilerServices;
using #7hc;
using StructurePoint.Products.Column.Viewports.API;
using Telerik.Windows.Controls;

namespace #Xc
{
	// Token: 0x020000B1 RID: 177
	internal sealed class #4d
	{
		// Token: 0x060005B9 RID: 1465 RVA: 0x0008AD84 File Offset: 0x00088F84
		public #4d(RadSplitContainer #5d, IViewport #6d, IViewport #7d)
		{
			if (#5d == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107384720));
			}
			this.#a = #5d;
			if (#6d == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107384675));
			}
			this.#b = #6d;
			if (#7d == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107384694));
			}
			this.#c = #7d;
		}

		// Token: 0x170002CC RID: 716
		// (get) Token: 0x060005BA RID: 1466 RVA: 0x0000A346 File Offset: 0x00008546
		public RadSplitContainer Container { get; }

		// Token: 0x170002CD RID: 717
		// (get) Token: 0x060005BB RID: 1467 RVA: 0x0000A352 File Offset: 0x00008552
		public IViewport Viewport1 { get; }

		// Token: 0x170002CE RID: 718
		// (get) Token: 0x060005BC RID: 1468 RVA: 0x0000A35E File Offset: 0x0000855E
		public IViewport Viewport2 { get; }

		// Token: 0x04000137 RID: 311
		[CompilerGenerated]
		private readonly RadSplitContainer #a;

		// Token: 0x04000138 RID: 312
		[CompilerGenerated]
		private readonly IViewport #b;

		// Token: 0x04000139 RID: 313
		[CompilerGenerated]
		private readonly IViewport #c;
	}
}
