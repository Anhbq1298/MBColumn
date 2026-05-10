using System;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000ACF RID: 2767
	public interface IToggleButtonData : IButtonData
	{
		// Token: 0x1700196E RID: 6510
		// (get) Token: 0x06005A14 RID: 23060
		// (set) Token: 0x06005A15 RID: 23061
		bool IsChecked { get; set; }

		// Token: 0x14000162 RID: 354
		// (add) Token: 0x06005A16 RID: 23062
		// (remove) Token: 0x06005A17 RID: 23063
		event EventHandler IsCheckedChanged;
	}
}
