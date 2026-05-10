using System;
using System.Windows;
using System.Windows.Input;
using StructurePoint.CoreAssets.Column.Core.Core.App;

namespace StructurePoint.Products.Column.FailureSurface.Views
{
	// Token: 0x020003E4 RID: 996
	internal interface IDiagramPresenterView : IView
	{
		// Token: 0x1400007C RID: 124
		// (add) Token: 0x060022AF RID: 8879
		// (remove) Token: 0x060022B0 RID: 8880
		event SizeChangedEventHandler SizeChanged;

		// Token: 0x1400007D RID: 125
		// (add) Token: 0x060022B1 RID: 8881
		// (remove) Token: 0x060022B2 RID: 8882
		event MouseEventHandler MouseLeave;
	}
}
