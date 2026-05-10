using System;
using System.Collections.Generic;
using System.Diagnostics;
using StructurePoint.Products.Column.Editor.Core.Selection;

namespace #gOb
{
	// Token: 0x0200068E RID: 1678
	[DebuggerDisplay("Any: {AnySelected}, Only: {OnlySelected}, Single: {SingleSelected}")]
	internal sealed class #fOb : ObjectSelectionState
	{
		// Token: 0x06003843 RID: 14403 RVA: 0x00030EDA File Offset: 0x0002F0DA
		public #fOb(SelectionManager #RBb)
		{
			this.#a = #RBb;
		}

		// Token: 0x06003844 RID: 14404 RVA: 0x00030EE9 File Offset: 0x0002F0E9
		public override void #cg(IObjectsSelectionManager #dOb, IReadOnlyCollection<IObjectsSelectionManager> #eOb)
		{
			base.#cg(#dOb, #eOb);
		}

		// Token: 0x04001799 RID: 6041
		private readonly SelectionManager #a;
	}
}
