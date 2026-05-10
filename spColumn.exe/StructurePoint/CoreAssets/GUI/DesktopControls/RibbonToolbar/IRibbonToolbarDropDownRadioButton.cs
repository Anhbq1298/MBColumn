using System;
using System.Collections.Generic;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.RibbonToolbar
{
	// Token: 0x020008FA RID: 2298
	public interface IRibbonToolbarDropDownRadioButton : IRibbonToolbarButton, IRibbonToolbarRadioButton
	{
		// Token: 0x17001570 RID: 5488
		// (get) Token: 0x0600493A RID: 18746
		IEnumerable<IRibbonToolbarRadioButton> ChildButtons { get; }

		// Token: 0x17001571 RID: 5489
		// (get) Token: 0x0600493B RID: 18747
		// (set) Token: 0x0600493C RID: 18748
		IRibbonToolbarRadioButton SelectedButton { get; set; }
	}
}
