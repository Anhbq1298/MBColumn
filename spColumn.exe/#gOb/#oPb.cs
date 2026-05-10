using System;
using System.Collections.Generic;
using System.Diagnostics;
using StructurePoint.Products.Column.Editor.Core.Selection;

namespace #gOb
{
	// Token: 0x020006A2 RID: 1698
	[DebuggerDisplay("Any: {AnySelected}, Only: {OnlySelected}, Single: {SingleSelected}, AreaLoads: {AreAreaLoadsSelected}")]
	internal sealed class #oPb : ObjectSelectionState
	{
		// Token: 0x060038D3 RID: 14547 RVA: 0x0003172C File Offset: 0x0002F92C
		public #oPb(SelectionManager #RBb)
		{
			this.#a = #RBb;
		}

		// Token: 0x060038D4 RID: 14548 RVA: 0x00030EE9 File Offset: 0x0002F0E9
		public override void #cg(IObjectsSelectionManager #dOb, IReadOnlyCollection<IObjectsSelectionManager> #eOb)
		{
			base.#cg(#dOb, #eOb);
		}

		// Token: 0x040017D4 RID: 6100
		private readonly SelectionManager #a;
	}
}
