using System;
using System.ComponentModel;
using System.Windows;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.Products.Column.Viewports.API;

namespace #hg
{
	// Token: 0x020000CB RID: 203
	internal interface #ig : IViewModel<IViewportOverlayView>, INotifyPropertyChanged, IViewModel
	{
		// Token: 0x14000020 RID: 32
		// (add) Token: 0x0600064A RID: 1610
		// (remove) Token: 0x0600064B RID: 1611
		event EventHandler CommandExecuted;

		// Token: 0x170002F2 RID: 754
		// (get) Token: 0x0600064C RID: 1612
		// (set) Token: 0x0600064D RID: 1613
		Visibility ButtonVisibility { get; set; }

		// Token: 0x170002F3 RID: 755
		// (get) Token: 0x0600064E RID: 1614
		// (set) Token: 0x0600064F RID: 1615
		Visibility Visibility { get; set; }

		// Token: 0x170002F4 RID: 756
		// (get) Token: 0x06000650 RID: 1616
		// (set) Token: 0x06000651 RID: 1617
		string Message { get; set; }

		// Token: 0x170002F5 RID: 757
		// (get) Token: 0x06000652 RID: 1618
		// (set) Token: 0x06000653 RID: 1619
		string ButtonText { get; set; }
	}
}
