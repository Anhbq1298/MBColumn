using System;
using #0I;
using #n8;
using #PI;
using #qr;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.Products.Column.ViewModels.API.Core;
using StructurePoint.Products.Column.ViewModels.Slenderness.Helpers;
using StructurePoint.Products.Column.ViewModels.Slenderness.Modules;
using Telerik.Windows.Controls;

namespace #6s
{
	// Token: 0x02000140 RID: 320
	internal interface #9s : #q8<#L8>, #5I, #OI, IChangesInfo
	{
		// Token: 0x1700043C RID: 1084
		// (get) Token: 0x06000A68 RID: 2664
		ModelAxis ModelAxis { get; }

		// Token: 0x1700043D RID: 1085
		// (get) Token: 0x06000A69 RID: 2665
		TemporaryBeam AboveLeft { get; }

		// Token: 0x1700043E RID: 1086
		// (get) Token: 0x06000A6A RID: 2666
		TemporaryBeam AboveRight { get; }

		// Token: 0x1700043F RID: 1087
		// (get) Token: 0x06000A6B RID: 2667
		TemporaryBeam BelowLeft { get; }

		// Token: 0x17000440 RID: 1088
		// (get) Token: 0x06000A6C RID: 2668
		TemporaryBeam BelowRight { get; }

		// Token: 0x17000441 RID: 1089
		// (get) Token: 0x06000A6D RID: 2669
		DelegateCommand CopyToMirroredAxisCommand { get; }

		// Token: 0x17000442 RID: 1090
		// (get) Token: 0x06000A6E RID: 2670
		DelegateCommand CopyToAllCommand { get; }

		// Token: 0x17000443 RID: 1091
		// (get) Token: 0x06000A6F RID: 2671
		DelegateCommand CopyToNextCommand { get; }

		// Token: 0x17000444 RID: 1092
		// (get) Token: 0x06000A70 RID: 2672
		DelegateCommand CopyToPreviousCommand { get; }

		// Token: 0x17000445 RID: 1093
		// (get) Token: 0x06000A71 RID: 2673
		#ht SlendernessWindow { get; }

		// Token: 0x06000A72 RID: 2674
		void #Gr(#yTh #zTh, EndConditionType #6r);

		// Token: 0x06000A73 RID: 2675
		void #vh();

		// Token: 0x06000A74 RID: 2676
		void #or();
	}
}
