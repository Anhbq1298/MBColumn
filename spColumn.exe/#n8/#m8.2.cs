using System;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.GUI.Framework.Collections;

namespace #n8
{
	// Token: 0x020003C4 RID: 964
	internal interface #m8
	{
		// Token: 0x17000B72 RID: 2930
		// (get) Token: 0x060020F7 RID: 8439
		// (set) Token: 0x060020F8 RID: 8440
		ReinforcementType BarType { get; set; }

		// Token: 0x17000B73 RID: 2931
		// (get) Token: 0x060020F9 RID: 8441
		// (set) Token: 0x060020FA RID: 8442
		ReinforcementLayout BarLayout { get; set; }

		// Token: 0x17000B74 RID: 2932
		// (get) Token: 0x060020FB RID: 8443
		bool IsLayoutAvailable { get; }

		// Token: 0x17000B75 RID: 2933
		// (get) Token: 0x060020FC RID: 8444
		bool IsTypeChangeEnabled { get; }

		// Token: 0x17000B76 RID: 2934
		// (get) Token: 0x060020FD RID: 8445
		CustomObservableCollection<ReinforcementType> AvailableBarTypes { get; }

		// Token: 0x17000B77 RID: 2935
		// (get) Token: 0x060020FE RID: 8446
		CustomObservableCollection<ReinforcementLayout> AvailableBarLayouts { get; }
	}
}
