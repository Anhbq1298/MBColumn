using System;
using #0I;
using #9pe;
using #n8;
using #WI;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.ViewModels.API.Core;
using Telerik.Windows.Controls;

namespace #WG
{
	// Token: 0x02000280 RID: 640
	internal interface #5G : #q8<#kqe>, #VI, #5I, IChangesInfo, #I8, #kqe
	{
		// Token: 0x17000766 RID: 1894
		// (get) Token: 0x060014C6 RID: 5318
		ReductionFactors ReductionFactors { get; }

		// Token: 0x17000767 RID: 1895
		// (get) Token: 0x060014C7 RID: 5319
		DelegateCommand ConfinementTypeChangedCommand { get; }

		// Token: 0x17000768 RID: 1896
		// (get) Token: 0x060014C8 RID: 5320
		// (set) Token: 0x060014C9 RID: 5321
		ConfinementType ConfinementType { get; set; }

		// Token: 0x17000769 RID: 1897
		// (get) Token: 0x060014CA RID: 5322
		bool IsVarStringVisibleInUnitBox { get; }

		// Token: 0x1700076A RID: 1898
		// (get) Token: 0x060014CB RID: 5323
		bool IsIrregularSectionVisible { get; }

		// Token: 0x1700076B RID: 1899
		// (get) Token: 0x060014CC RID: 5324
		string FactorsSectionTitle { get; }

		// Token: 0x1700076C RID: 1900
		// (get) Token: 0x060014CD RID: 5325
		string LabelB { get; }

		// Token: 0x1700076D RID: 1901
		// (get) Token: 0x060014CE RID: 5326
		string LabelC { get; }

		// Token: 0x1700076E RID: 1902
		// (get) Token: 0x060014CF RID: 5327
		bool IsCsaCode { get; }

		// Token: 0x060014D0 RID: 5328
		void OnPanelActivated();
	}
}
