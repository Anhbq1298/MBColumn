using System;
using #0I;
using #5Z;
using #n8;
using #PI;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.Products.Column.ViewModels.API.Core;
using StructurePoint.Products.Column.ViewModels.Slenderness.Helpers;
using Telerik.Windows.Controls;

namespace #6s
{
	// Token: 0x0200014A RID: 330
	internal interface #ct : #q8<#N8>, #5I, #OI, IChangesInfo, #N8, ISlendernessOfDesignedColumn
	{
		// Token: 0x1700044D RID: 1101
		// (get) Token: 0x06000A88 RID: 2696
		#X3 SlendernessOfDesignedColumn { get; }

		// Token: 0x1700044E RID: 1102
		// (get) Token: 0x06000A89 RID: 2697
		ModelAxis ModelAxis { get; }

		// Token: 0x1700044F RID: 1103
		// (get) Token: 0x06000A8A RID: 2698
		DelegateCommand CopyValuesToMirrorAxis { get; }

		// Token: 0x17000450 RID: 1104
		// (get) Token: 0x06000A8B RID: 2699
		bool SecondOrderEffectsCheckboxVisible { get; }

		// Token: 0x06000A8C RID: 2700
		void #or();
	}
}
