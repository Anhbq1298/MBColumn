using System;
using #eU;
using #RJb;
using StructurePoint.Products.Column.Editor.Core;
using StructurePoint.Products.Column.Viewports.API;

namespace #Xc
{
	// Token: 0x020000A7 RID: 167
	internal interface #Fd : IViewport
	{
		// Token: 0x170002B3 RID: 691
		// (get) Token: 0x06000573 RID: 1395
		ColumnEditor Editor { get; }

		// Token: 0x170002B4 RID: 692
		// (get) Token: 0x06000574 RID: 1396
		#cLb EditorContext { get; }

		// Token: 0x170002B5 RID: 693
		// (get) Token: 0x06000575 RID: 1397
		#WV Renderer { get; }

		// Token: 0x06000576 RID: 1398
		void #Ed();
	}
}
