using System;
using System.Diagnostics.CodeAnalysis;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.RibbonToolbar
{
	// Token: 0x020008F5 RID: 2293
	[SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "Toolbar")]
	public interface IRibbonToolbarToggleButton : IRibbonToolbarButton
	{
		// Token: 0x1700155D RID: 5469
		// (get) Token: 0x0600490D RID: 18701
		// (set) Token: 0x0600490E RID: 18702
		bool IsChecked { get; set; }
	}
}
