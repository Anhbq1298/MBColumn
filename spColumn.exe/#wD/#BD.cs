using System;
using #0I;
using #TI;
using StructurePoint.CoreAssets.GUI.Framework.Collections;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.ViewModels.API.Core;
using Telerik.Windows.Controls;

namespace #wD
{
	// Token: 0x020001F8 RID: 504
	internal interface #BD : #5I, IChangesInfo, #SI, #ZI
	{
		// Token: 0x17000668 RID: 1640
		// (get) Token: 0x06001142 RID: 4418
		CustomObservableCollection<FactoredLoad> Items { get; }

		// Token: 0x17000669 RID: 1641
		// (get) Token: 0x06001143 RID: 4419
		// (set) Token: 0x06001144 RID: 4420
		FactoredLoad SelectedItem { get; set; }

		// Token: 0x1700066A RID: 1642
		// (get) Token: 0x06001145 RID: 4421
		DelegateCommand RemoveDuplicatesCommand { get; }

		// Token: 0x1700066B RID: 1643
		// (get) Token: 0x06001146 RID: 4422
		DelegateCommand ServiceLoadsToFactoredLoads { get; }

		// Token: 0x1700066C RID: 1644
		// (get) Token: 0x06001147 RID: 4423
		DelegateCommand ImportCommand { get; }

		// Token: 0x1700066D RID: 1645
		// (get) Token: 0x06001148 RID: 4424
		DelegateCommand ExportCommand { get; }

		// Token: 0x06001149 RID: 4425
		void #2B();

		// Token: 0x0600114A RID: 4426
		void #3B();
	}
}
