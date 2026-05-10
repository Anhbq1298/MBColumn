using System;
using StructurePoint.CoreAssets.Column.Core.Core.App;

namespace StructurePoint.Products.Column.FailureSurface.Views
{
	// Token: 0x020003EB RID: 1003
	internal interface ILoadPointDetailsWindow : IColumnWindow, IView
	{
		// Token: 0x17000C08 RID: 3080
		// (get) Token: 0x060022C2 RID: 8898
		// (set) Token: 0x060022C3 RID: 8899
		double Width { get; set; }

		// Token: 0x17000C09 RID: 3081
		// (get) Token: 0x060022C4 RID: 8900
		// (set) Token: 0x060022C5 RID: 8901
		double Height { get; set; }
	}
}
