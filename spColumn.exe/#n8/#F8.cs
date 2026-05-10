using System;
using StructurePoint.CoreAssets.GUI.Framework.Collections;
using StructurePoint.Products.Column.Model.Entities;

namespace #n8
{
	// Token: 0x020003C6 RID: 966
	internal interface #F8
	{
		// Token: 0x17000B82 RID: 2946
		// (get) Token: 0x06002113 RID: 8467
		// (set) Token: 0x06002114 RID: 8468
		int MinNumberOfBars { get; set; }

		// Token: 0x17000B83 RID: 2947
		// (get) Token: 0x06002115 RID: 8469
		// (set) Token: 0x06002116 RID: 8470
		StandardBar MinBar { get; set; }

		// Token: 0x17000B84 RID: 2948
		// (get) Token: 0x06002117 RID: 8471
		// (set) Token: 0x06002118 RID: 8472
		int MaxNumberOfBars { get; set; }

		// Token: 0x17000B85 RID: 2949
		// (get) Token: 0x06002119 RID: 8473
		// (set) Token: 0x0600211A RID: 8474
		StandardBar MaxBar { get; set; }

		// Token: 0x17000B86 RID: 2950
		// (get) Token: 0x0600211B RID: 8475
		// (set) Token: 0x0600211C RID: 8476
		float ClearCover { get; set; }

		// Token: 0x17000B87 RID: 2951
		// (get) Token: 0x0600211D RID: 8477
		CustomObservableCollection<StandardBar> AvailableBars { get; }
	}
}
