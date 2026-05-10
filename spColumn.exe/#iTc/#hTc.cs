using System;
using StructurePoint.CoreAssets.GUI.DesktopControls;

namespace #iTc
{
	// Token: 0x0200046C RID: 1132
	internal interface #hTc
	{
		// Token: 0x17000E38 RID: 3640
		// (get) Token: 0x060029AF RID: 10671
		IDelegateCommandProxy UpdateRibbonToolbarCommand { get; }

		// Token: 0x17000E39 RID: 3641
		// (get) Token: 0x060029B0 RID: 10672
		IDelegateCommandProxy IncreaseRibbonToolbarSizeCommand { get; }

		// Token: 0x17000E3A RID: 3642
		// (get) Token: 0x060029B1 RID: 10673
		IDelegateCommandProxy DecreaseRibbonToolbarSizeCommand { get; }
	}
}
