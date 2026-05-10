using System;
using #0I;
using #PI;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.Products.Column.ViewModels.API.Core;
using StructurePoint.Products.Column.ViewModels.Slenderness.Modules;
using Telerik.Windows.Controls;

namespace #6s
{
	// Token: 0x02000152 RID: 338
	internal interface #at : #5I, #OI, IChangesInfo
	{
		// Token: 0x1700045D RID: 1117
		// (get) Token: 0x06000AAC RID: 2732
		TemporaryColumn SlendernessOfColumnAbove { get; }

		// Token: 0x1700045E RID: 1118
		// (get) Token: 0x06000AAD RID: 2733
		TemporaryColumn SlendernessOfColumnBelow { get; }

		// Token: 0x1700045F RID: 1119
		// (get) Token: 0x06000AAE RID: 2734
		DelegateCommand CopyToCommand { get; }

		// Token: 0x17000460 RID: 1120
		// (get) Token: 0x06000AAF RID: 2735
		// (set) Token: 0x06000AB0 RID: 2736
		#ht SlendernessWindow { get; set; }

		// Token: 0x06000AB1 RID: 2737
		void #Gr(EndConditionType #Hr, EndConditionType #Ir);

		// Token: 0x06000AB2 RID: 2738
		void #or();
	}
}
