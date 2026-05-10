using System;
using System.ComponentModel;
using #0I;
using #PI;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.Products.Column.ViewModels.Slenderness.Helpers;

namespace #6s
{
	// Token: 0x0200012F RID: 303
	internal interface #ht : INotifyPropertyChanged, IViewModel<IColumnWindow>, #RI<SlendernessPanelType>, #6I<SlendernessPanelType>, IViewModel
	{
		// Token: 0x1700041C RID: 1052
		// (get) Token: 0x06000A1D RID: 2589
		#bt XDesignColumnPanel { get; }

		// Token: 0x1700041D RID: 1053
		// (get) Token: 0x06000A1E RID: 2590
		#bt YDesignColumnPanel { get; }

		// Token: 0x1700041E RID: 1054
		// (get) Token: 0x06000A1F RID: 2591
		#gt SlenderColumnsAboveBelowPanel { get; }

		// Token: 0x1700041F RID: 1055
		// (get) Token: 0x06000A20 RID: 2592
		#8s XBeamsPanel { get; }

		// Token: 0x17000420 RID: 1056
		// (get) Token: 0x06000A21 RID: 2593
		#8s YBeamsPanel { get; }

		// Token: 0x17000421 RID: 1057
		// (get) Token: 0x06000A22 RID: 2594
		#it SlenderSlendernessFactorsPanel { get; }

		// Token: 0x17000422 RID: 1058
		// (get) Token: 0x06000A23 RID: 2595
		EndConditionType EndConditionX { get; }

		// Token: 0x17000423 RID: 1059
		// (get) Token: 0x06000A24 RID: 2596
		EndConditionType EndConditionY { get; }

		// Token: 0x17000424 RID: 1060
		// (get) Token: 0x06000A25 RID: 2597
		bool IsAboveBelowWithoutBelow { get; }

		// Token: 0x06000A26 RID: 2598
		bool #Pq();

		// Token: 0x06000A27 RID: 2599
		bool #Qq();

		// Token: 0x06000A28 RID: 2600
		bool #Nq();

		// Token: 0x06000A29 RID: 2601
		bool #Oq();

		// Token: 0x06000A2A RID: 2602
		bool #Rq();

		// Token: 0x06000A2B RID: 2603
		bool #Sq();
	}
}
