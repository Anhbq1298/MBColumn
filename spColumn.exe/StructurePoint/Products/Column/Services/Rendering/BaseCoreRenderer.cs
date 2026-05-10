using System;
using System.Runtime.CompilerServices;
using #7hc;
using #hR;
using #RJb;
using devDept.Graphics;
using StructurePoint.Products.Column.Editor.Core;

namespace StructurePoint.Products.Column.Services.Rendering
{
	// Token: 0x020002E1 RID: 737
	internal abstract class BaseCoreRenderer
	{
		// Token: 0x06001973 RID: 6515 RVA: 0x00019699 File Offset: 0x00017899
		protected BaseCoreRenderer(#tS coreRendererModel)
		{
			this.#c = coreRendererModel;
		}

		// Token: 0x1700096B RID: 2411
		// (get) Token: 0x06001974 RID: 6516 RVA: 0x000196A8 File Offset: 0x000178A8
		// (set) Token: 0x06001975 RID: 6517 RVA: 0x000196B4 File Offset: 0x000178B4
		private protected #cLb EditorContext { protected get; private set; }

		// Token: 0x1700096C RID: 2412
		// (get) Token: 0x06001976 RID: 6518 RVA: 0x000196C5 File Offset: 0x000178C5
		// (set) Token: 0x06001977 RID: 6519 RVA: 0x000196D1 File Offset: 0x000178D1
		private protected ColumnEditor Editor { protected get; private set; }

		// Token: 0x1700096D RID: 2413
		// (get) Token: 0x06001978 RID: 6520 RVA: 0x000196E2 File Offset: 0x000178E2
		protected RenderContextBase Context
		{
			get
			{
				ColumnEditor columnEditor = this.Editor;
				if (columnEditor == null)
				{
					return null;
				}
				return columnEditor.renderContext;
			}
		}

		// Token: 0x1700096E RID: 2414
		// (get) Token: 0x06001979 RID: 6521 RVA: 0x000196FD File Offset: 0x000178FD
		protected #tS CoreRendererModel { get; }

		// Token: 0x0600197A RID: 6522 RVA: 0x00019709 File Offset: 0x00017909
		public void #nR(#cLb #ib)
		{
			if (#ib == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107400797));
			}
			this.EditorContext = #ib;
			this.Editor = (ColumnEditor)this.EditorContext.Editor;
		}

		// Token: 0x0600197B RID: 6523 RVA: 0x00009E6A File Offset: 0x0000806A
		public virtual void #fR()
		{
		}

		// Token: 0x040009BB RID: 2491
		[CompilerGenerated]
		private #cLb #a;

		// Token: 0x040009BC RID: 2492
		[CompilerGenerated]
		private ColumnEditor #b;

		// Token: 0x040009BD RID: 2493
		[CompilerGenerated]
		private readonly #tS #c;
	}
}
