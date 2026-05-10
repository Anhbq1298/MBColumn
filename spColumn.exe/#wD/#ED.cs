using System;
using #0I;
using #TI;
using StructurePoint.CoreAssets.GUI.Framework.Collections;
using StructurePoint.Products.Column.ViewModels.API.Core;
using StructurePoint.Products.Column.ViewModels.Loads.Modules;
using Telerik.Windows.Controls;

namespace #wD
{
	// Token: 0x02000206 RID: 518
	internal interface #ED : #5I, IChangesInfo, #SI, #ZI
	{
		// Token: 0x17000683 RID: 1667
		// (get) Token: 0x06001199 RID: 4505
		CustomObservableCollection<LoadGroup> Items { get; }

		// Token: 0x17000684 RID: 1668
		// (get) Token: 0x0600119A RID: 4506
		CustomObservableCollection<ServiceLoadParameters> Parameters { get; }

		// Token: 0x17000685 RID: 1669
		// (get) Token: 0x0600119B RID: 4507
		DelegateCommand RefreshServiceLoadsCommand { get; }

		// Token: 0x17000686 RID: 1670
		// (get) Token: 0x0600119C RID: 4508
		DelegateCommand ClearServiceLoadsCommand { get; }

		// Token: 0x17000687 RID: 1671
		// (get) Token: 0x0600119D RID: 4509
		DelegateCommand RemoveDuplicatesCommand { get; }

		// Token: 0x17000688 RID: 1672
		// (get) Token: 0x0600119E RID: 4510
		DelegateCommand ImportCommand { get; }

		// Token: 0x17000689 RID: 1673
		// (get) Token: 0x0600119F RID: 4511
		DelegateCommand ExportCommand { get; }

		// Token: 0x1700068A RID: 1674
		// (get) Token: 0x060011A0 RID: 4512
		// (set) Token: 0x060011A1 RID: 4513
		LoadGroup SelectedItem { get; set; }

		// Token: 0x1700068B RID: 1675
		// (get) Token: 0x060011A2 RID: 4514
		bool IsXAxisActive { get; }

		// Token: 0x1700068C RID: 1676
		// (get) Token: 0x060011A3 RID: 4515
		bool IsYAxisActive { get; }

		// Token: 0x060011A4 RID: 4516
		void #2B();

		// Token: 0x060011A5 RID: 4517
		void #3B();
	}
}
