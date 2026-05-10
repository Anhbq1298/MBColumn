using System;
using #7hc;
using #eU;
using #LFb;
using #RJb;
using StructurePoint.Products.Column.Editor.Core.Selection;

namespace #ABb
{
	// Token: 0x0200054A RID: 1354
	internal sealed class #zBb : #UFb
	{
		// Token: 0x06003049 RID: 12361 RVA: 0x0002AE40 File Offset: 0x00029040
		public #zBb(#YFb #BBb, #WFb #CBb, #oW #xn)
		{
			this.#a = #BBb;
			this.#b = #CBb;
			this.#c = #xn;
		}

		// Token: 0x0600304A RID: 12362 RVA: 0x000F8394 File Offset: 0x000F6594
		public void #cg(#cLb #FR, bool #nz = false)
		{
			if (#FR == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107400784));
			}
			SelectionManager selectionManager = #FR.Selection;
			this.#b.#kCb(selectionManager.Bars.SelectedObjects);
			this.#a.#kCb(selectionManager.Shapes.SelectedObjects);
		}

		// Token: 0x0400138F RID: 5007
		private readonly #YFb #a;

		// Token: 0x04001390 RID: 5008
		private readonly #WFb #b;

		// Token: 0x04001391 RID: 5009
		private readonly #oW #c;
	}
}
