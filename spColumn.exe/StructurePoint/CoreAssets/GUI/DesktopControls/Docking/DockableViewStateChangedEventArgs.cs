using System;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Docking
{
	// Token: 0x0200099A RID: 2458
	public sealed class DockableViewStateChangedEventArgs : EventArgs
	{
		// Token: 0x06004FE7 RID: 20455 RVA: 0x00042B0E File Offset: 0x00040D0E
		public DockableViewStateChangedEventArgs(IDockableViewController dockableViewController, IDockableView dockableView)
		{
			this.DockableView = dockableView;
			this.DockableViewController = dockableViewController;
		}

		// Token: 0x170016FB RID: 5883
		// (get) Token: 0x06004FE8 RID: 20456 RVA: 0x00042B24 File Offset: 0x00040D24
		// (set) Token: 0x06004FE9 RID: 20457 RVA: 0x00042B30 File Offset: 0x00040D30
		public IDockableView DockableView { get; private set; }

		// Token: 0x170016FC RID: 5884
		// (get) Token: 0x06004FEA RID: 20458 RVA: 0x00042B41 File Offset: 0x00040D41
		// (set) Token: 0x06004FEB RID: 20459 RVA: 0x00042B4D File Offset: 0x00040D4D
		public IDockableViewController DockableViewController { get; private set; }
	}
}
