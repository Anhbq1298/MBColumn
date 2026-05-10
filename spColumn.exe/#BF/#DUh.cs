using System;
using #0I;
using #WI;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.GUI.Framework.Collections;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.ViewModels.API.Core;
using Telerik.Windows.Controls;

namespace #BF
{
	// Token: 0x02000239 RID: 569
	internal interface #DUh : #VI, #5I, IChangesInfo, #ZI
	{
		// Token: 0x170006E5 RID: 1765
		// (get) Token: 0x06001306 RID: 4870
		// (set) Token: 0x06001307 RID: 4871
		BarGroupType BarGroupType { get; set; }

		// Token: 0x170006E6 RID: 1766
		// (get) Token: 0x06001308 RID: 4872
		CustomObservableCollection<StandardBar> Items { get; }

		// Token: 0x170006E7 RID: 1767
		// (get) Token: 0x06001309 RID: 4873
		// (set) Token: 0x0600130A RID: 4874
		StandardBar SelectedItem { get; set; }

		// Token: 0x170006E8 RID: 1768
		// (get) Token: 0x0600130B RID: 4875
		CustomObservableCollection<BarGroupType> BarGroupTypes { get; }

		// Token: 0x170006E9 RID: 1769
		// (get) Token: 0x0600130C RID: 4876
		DelegateCommand ExportFileCommand { get; }

		// Token: 0x170006EA RID: 1770
		// (get) Token: 0x0600130D RID: 4877
		DelegateCommand ImportFileCommand { get; }

		// Token: 0x0600130E RID: 4878
		void #3B();

		// Token: 0x0600130F RID: 4879
		void #2B();
	}
}
