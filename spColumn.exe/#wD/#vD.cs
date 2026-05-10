using System;
using System.Collections.Generic;
using StructurePoint.CoreAssets.GUI.Framework.Collections;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.ViewModels.Loads.Modules;

namespace #wD
{
	// Token: 0x020001D8 RID: 472
	internal interface #vD
	{
		// Token: 0x17000631 RID: 1585
		// (get) Token: 0x06001089 RID: 4233
		List<FactoredLoad> FactoredLoads { get; }

		// Token: 0x17000632 RID: 1586
		// (set) Token: 0x0600108A RID: 4234
		CustomObservableCollection<LoadGroup> ServiceLoadsItemsGroup { set; }

		// Token: 0x17000633 RID: 1587
		// (get) Token: 0x0600108B RID: 4235
		// (set) Token: 0x0600108C RID: 4236
		Func<bool> ServiceLoadsChangedFunc { get; set; }

		// Token: 0x0600108D RID: 4237
		bool #uB();

		// Token: 0x0600108E RID: 4238
		bool #vB();
	}
}
