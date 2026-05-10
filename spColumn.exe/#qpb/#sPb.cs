using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.Products.Column.FailureSurface.ViewModels.LeftPanel;

namespace #qPb
{
	// Token: 0x020006A7 RID: 1703
	internal interface #sPb : INotifyPropertyChanged, IViewModel, IViewModel<#pPb>
	{
		// Token: 0x17001182 RID: 4482
		// (get) Token: 0x060038E7 RID: 14567
		ObservableCollection<PropertiesTableItemViewModel> PropertiesTableItems { get; }

		// Token: 0x17001183 RID: 4483
		// (get) Token: 0x060038E8 RID: 14568
		// (set) Token: 0x060038E9 RID: 14569
		bool IsVisible { get; set; }

		// Token: 0x060038EA RID: 14570
		void #vBf();
	}
}
