using System;
using #0I;
using #TI;
using StructurePoint.CoreAssets.GUI.Framework.Collections;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.ViewModels.API.Core;
using Telerik.Windows.Controls;

namespace #wD
{
	// Token: 0x020001E2 RID: 482
	internal interface #zD : #5I, IChangesInfo, #SI, #ZI
	{
		// Token: 0x17000641 RID: 1601
		// (get) Token: 0x060010AE RID: 4270
		CustomObservableCollection<AxialLoad> Items { get; }

		// Token: 0x17000642 RID: 1602
		// (get) Token: 0x060010AF RID: 4271
		// (set) Token: 0x060010B0 RID: 4272
		AxialLoad SelectedItem { get; set; }

		// Token: 0x17000643 RID: 1603
		// (get) Token: 0x060010B1 RID: 4273
		DelegateCommand RemoveDuplicatesCommand { get; }

		// Token: 0x060010B2 RID: 4274
		void #2B();

		// Token: 0x060010B3 RID: 4275
		void #3B();
	}
}
