using System;
using System.ComponentModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using Telerik.Windows.Data;

namespace #qzb
{
	// Token: 0x02000506 RID: 1286
	internal interface #4zb : INotifyPropertyChanged, IViewModel, IViewModel<#0zb>
	{
		// Token: 0x17000F70 RID: 3952
		// (get) Token: 0x06002ED4 RID: 11988
		RadObservableCollection<ComboItem<PolygonApplication>> PolygonApplications { get; }

		// Token: 0x17000F71 RID: 3953
		// (get) Token: 0x06002ED5 RID: 11989
		// (set) Token: 0x06002ED6 RID: 11990
		PolygonApplication PolygonApplication { get; set; }

		// Token: 0x06002ED7 RID: 11991
		void #5b();
	}
}
