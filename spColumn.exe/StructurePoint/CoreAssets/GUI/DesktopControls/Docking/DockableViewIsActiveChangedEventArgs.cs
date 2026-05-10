using System;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Docking
{
	// Token: 0x020009A1 RID: 2465
	public sealed class DockableViewIsActiveChangedEventArgs : EventArgs
	{
		// Token: 0x170016FD RID: 5885
		// (get) Token: 0x06004FFC RID: 20476 RVA: 0x00042C0E File Offset: 0x00040E0E
		// (set) Token: 0x06004FFD RID: 20477 RVA: 0x00042C1A File Offset: 0x00040E1A
		public bool IsActive { get; private set; }

		// Token: 0x06004FFE RID: 20478 RVA: 0x00042C2B File Offset: 0x00040E2B
		public DockableViewIsActiveChangedEventArgs(bool isActive)
		{
			this.IsActive = isActive;
		}
	}
}
