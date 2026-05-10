using System;
using System.Windows;
using StructurePoint.CoreAssets.Column.Core.Core.App;

namespace StructurePoint.Products.Column.FailureSurface.Views
{
	// Token: 0x020003EE RID: 1006
	internal interface ILeftPanelView : IView
	{
		// Token: 0x1400007E RID: 126
		// (add) Token: 0x060022C9 RID: 8905
		// (remove) Token: 0x060022CA RID: 8906
		event SizeChangedEventHandler SizeChanged;
	}
}
