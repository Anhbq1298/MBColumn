using System;
using #ezc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Grid;

namespace #B5c
{
	// Token: 0x02000CCD RID: 3277
	internal interface #F5c : #QBc
	{
		// Token: 0x17001D6B RID: 7531
		// (get) Token: 0x06006B01 RID: 27393
		IGridControl CurrentGridControl { get; }

		// Token: 0x17001D6C RID: 7532
		// (get) Token: 0x06006B02 RID: 27394
		// (set) Token: 0x06006B03 RID: 27395
		bool IsActive { get; set; }
	}
}
