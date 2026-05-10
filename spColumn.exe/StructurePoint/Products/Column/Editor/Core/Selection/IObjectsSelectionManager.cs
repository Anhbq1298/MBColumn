using System;

namespace StructurePoint.Products.Column.Editor.Core.Selection
{
	// Token: 0x02000693 RID: 1683
	internal interface IObjectsSelectionManager : IDisposable
	{
		// Token: 0x17001164 RID: 4452
		// (get) Token: 0x06003856 RID: 14422
		// (set) Token: 0x06003857 RID: 14423
		int NoOfSelectedObjects { get; set; }

		// Token: 0x17001165 RID: 4453
		// (get) Token: 0x06003858 RID: 14424
		bool Empty { get; }

		// Token: 0x17001166 RID: 4454
		// (get) Token: 0x06003859 RID: 14425
		bool Any { get; }

		// Token: 0x0600385A RID: 14426
		void #sOb();

		// Token: 0x0600385B RID: 14427
		void #tOb();

		// Token: 0x0600385C RID: 14428
		void #uOb();

		// Token: 0x0600385D RID: 14429
		void #EDb(bool #vOb, bool #wOb);
	}
}
