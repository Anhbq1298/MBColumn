using System;
using #0I;
using #WI;
using StructurePoint.CoreAssets.GUI.Framework.Collections;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.ViewModels.API.Core;
using Telerik.Windows.Controls;

namespace #WG
{
	// Token: 0x02000244 RID: 580
	internal interface #XG : #VI, #5I, IChangesInfo, #ZI
	{
		// Token: 0x17000700 RID: 1792
		// (get) Token: 0x0600136C RID: 4972
		CustomObservableCollection<LoadFactor> Items { get; }

		// Token: 0x17000701 RID: 1793
		// (get) Token: 0x0600136D RID: 4973
		// (set) Token: 0x0600136E RID: 4974
		LoadFactor SelectedItem { get; set; }

		// Token: 0x17000702 RID: 1794
		// (get) Token: 0x0600136F RID: 4975
		DelegateCommand ApplyDefaultsCommand { get; }

		// Token: 0x06001370 RID: 4976
		void #3B();

		// Token: 0x06001371 RID: 4977
		void #2B();
	}
}
