using System;
using #cMb;

namespace StructurePoint.Products.Column.Editor.Core.Tools
{
	// Token: 0x02000555 RID: 1365
	internal interface IMultiToolChild : #uNb
	{
		// Token: 0x17000FB4 RID: 4020
		// (get) Token: 0x0600308F RID: 12431
		bool IsWorking { get; }

		// Token: 0x06003090 RID: 12432
		void HandleChangedState();

		// Token: 0x06003091 RID: 12433
		void OnActivated();

		// Token: 0x06003092 RID: 12434
		void OnDeactivated();

		// Token: 0x06003093 RID: 12435
		void #XBb();
	}
}
