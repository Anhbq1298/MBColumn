using System;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.RibbonToolbar
{
	// Token: 0x020008F4 RID: 2292
	public interface IRibbonToolbarRadioButton : IRibbonToolbarButton
	{
		// Token: 0x1700155B RID: 5467
		// (get) Token: 0x06004909 RID: 18697
		// (set) Token: 0x0600490A RID: 18698
		string GroupName { get; set; }

		// Token: 0x1700155C RID: 5468
		// (get) Token: 0x0600490B RID: 18699
		// (set) Token: 0x0600490C RID: 18700
		bool IsChecked { get; set; }
	}
}
