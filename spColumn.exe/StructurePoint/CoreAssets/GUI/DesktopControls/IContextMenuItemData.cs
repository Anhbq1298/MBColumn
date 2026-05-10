using System;
using System.Windows.Input;

namespace StructurePoint.CoreAssets.GUI.DesktopControls
{
	// Token: 0x02000899 RID: 2201
	public interface IContextMenuItemData : IContextMenuItemBase
	{
		// Token: 0x1700143B RID: 5179
		// (get) Token: 0x06004567 RID: 17767
		// (set) Token: 0x06004568 RID: 17768
		ICommand Command { get; set; }
	}
}
