using System;
using System.Runtime.CompilerServices;
using StructurePoint.Products.Column.Viewports.API;

namespace #Xc
{
	// Token: 0x020000B4 RID: 180
	internal abstract class #le : EventArgs
	{
		// Token: 0x060005BF RID: 1471 RVA: 0x0000A37A File Offset: 0x0000857A
		protected #le(IViewport #fe)
		{
			this.#a = #fe;
		}

		// Token: 0x170002CF RID: 719
		// (get) Token: 0x060005C0 RID: 1472 RVA: 0x0000A389 File Offset: 0x00008589
		public IViewport Viewport { get; }

		// Token: 0x170002D0 RID: 720
		// (get) Token: 0x060005C1 RID: 1473 RVA: 0x0000A395 File Offset: 0x00008595
		public IModelEditorViewport EditorViewport
		{
			get
			{
				return this.Viewport as IModelEditorViewport;
			}
		}

		// Token: 0x0400013B RID: 315
		[CompilerGenerated]
		private readonly IViewport #a;
	}
}
