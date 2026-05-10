using System;
using System.Linq;
using #eU;
using #hg;
using #Xc;
using StructurePoint.Products.Column.Viewports.API;

namespace StructurePoint.Products.Column.Viewports
{
	// Token: 0x020000CC RID: 204
	internal sealed class ViewportsRenderer : #Gd, #WV
	{
		// Token: 0x06000654 RID: 1620 RVA: 0x0000AB70 File Offset: 0x00008D70
		public ViewportsRenderer(#jg manager)
		{
			this.#a = manager;
		}

		// Token: 0x06000655 RID: 1621 RVA: 0x0008BDD4 File Offset: 0x00089FD4
		public void #9f(bool #ag = false, bool #Cci = false)
		{
			foreach (IModelEditorViewport modelEditorViewport in this.#a.Viewports.OfType<IModelEditorViewport>())
			{
				modelEditorViewport.Renderer.#9f(#ag, #Cci);
			}
		}

		// Token: 0x06000656 RID: 1622 RVA: 0x0008BE40 File Offset: 0x0008A040
		public void #bg()
		{
			foreach (IModelEditorViewport modelEditorViewport in this.#a.Viewports.OfType<IModelEditorViewport>())
			{
				modelEditorViewport.Renderer.#bg();
			}
		}

		// Token: 0x06000657 RID: 1623 RVA: 0x0008BEA8 File Offset: 0x0008A0A8
		public void #cg()
		{
			foreach (IModelEditorViewport modelEditorViewport in this.#a.Viewports.OfType<IModelEditorViewport>())
			{
				modelEditorViewport.Renderer.#cg();
			}
		}

		// Token: 0x06000658 RID: 1624 RVA: 0x0008BF10 File Offset: 0x0008A110
		public void #dg()
		{
			foreach (IModelEditorViewport modelEditorViewport in this.#a.Viewports.OfType<IModelEditorViewport>())
			{
				modelEditorViewport.Renderer.#dg();
			}
		}

		// Token: 0x06000659 RID: 1625 RVA: 0x0008BF78 File Offset: 0x0008A178
		public void #eg()
		{
			foreach (IModelEditorViewport modelEditorViewport in this.#a.Viewports.OfType<IModelEditorViewport>())
			{
				modelEditorViewport.Renderer.#eg();
			}
		}

		// Token: 0x0600065A RID: 1626 RVA: 0x0008BFE0 File Offset: 0x0008A1E0
		public bool #fg()
		{
			return this.#a.Viewports.OfType<IModelEditorViewport>().Any(new Func<IModelEditorViewport, bool>(ViewportsRenderer.<>c.<>9.#fUb));
		}

		// Token: 0x04000164 RID: 356
		private readonly #jg #a;
	}
}
