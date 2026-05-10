using System;
using #0I;
using #n8;
using #WI;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.ViewModels.API.Core;

namespace #WG
{
	// Token: 0x0200026B RID: 619
	internal interface #2G : #q8<#J8>, #VI, #5I, IChangesInfo, #J8, IReinforcementRatios, #p8
	{
		// Token: 0x17000736 RID: 1846
		// (get) Token: 0x06001443 RID: 5187
		// (set) Token: 0x06001444 RID: 5188
		ColumnType ColumnType { get; set; }

		// Token: 0x17000737 RID: 1847
		// (get) Token: 0x06001445 RID: 5189
		StructurePoint.Products.Column.Model.Entities.ReinforcementRatios ReinforcementRatios { get; }

		// Token: 0x17000738 RID: 1848
		// (get) Token: 0x06001446 RID: 5190
		// (set) Token: 0x06001447 RID: 5191
		DesignTarget DesignTarget { get; set; }

		// Token: 0x17000739 RID: 1849
		// (get) Token: 0x06001448 RID: 5192
		// (set) Token: 0x06001449 RID: 5193
		float MinRebarClearSpacing { get; set; }

		// Token: 0x1700073A RID: 1850
		// (get) Token: 0x0600144A RID: 5194
		// (set) Token: 0x0600144B RID: 5195
		float LastValidClearSpacing { get; set; }

		// Token: 0x1700073B RID: 1851
		// (get) Token: 0x0600144C RID: 5196
		// (set) Token: 0x0600144D RID: 5197
		float LastValidCapacityRatio { get; set; }

		// Token: 0x0600144E RID: 5198
		void OnPanelActivated();
	}
}
