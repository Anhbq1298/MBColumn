using System;
using System.ComponentModel;
using System.Windows;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.Products.Column.Editor.Section.Common;

namespace #tFb
{
	// Token: 0x02000539 RID: 1337
	internal interface #HFb : INotifyPropertyChanged, IViewModel, IViewModel<#IFb>
	{
		// Token: 0x17000F86 RID: 3974
		// (get) Token: 0x06002FC4 RID: 12228
		// (set) Token: 0x06002FC5 RID: 12229
		double BarSpacingX { get; set; }

		// Token: 0x17000F87 RID: 3975
		// (get) Token: 0x06002FC6 RID: 12230
		// (set) Token: 0x06002FC7 RID: 12231
		double BarSpacingY { get; set; }

		// Token: 0x17000F88 RID: 3976
		// (get) Token: 0x06002FC8 RID: 12232
		// (set) Token: 0x06002FC9 RID: 12233
		int NumberOfBarsX { get; set; }

		// Token: 0x17000F89 RID: 3977
		// (get) Token: 0x06002FCA RID: 12234
		// (set) Token: 0x06002FCB RID: 12235
		int NumberOfBarsY { get; set; }

		// Token: 0x17000F8A RID: 3978
		// (get) Token: 0x06002FCC RID: 12236
		// (set) Token: 0x06002FCD RID: 12237
		BarPlacementType BarPlacementType { get; set; }

		// Token: 0x17000F8B RID: 3979
		// (get) Token: 0x06002FCE RID: 12238
		// (set) Token: 0x06002FCF RID: 12239
		bool KeepEndBars { get; set; }

		// Token: 0x17000F8C RID: 3980
		// (get) Token: 0x06002FD0 RID: 12240
		// (set) Token: 0x06002FD1 RID: 12241
		Visibility IncludeEndBarsVisibility { get; set; }

		// Token: 0x06002FD2 RID: 12242
		double? #3Eb();

		// Token: 0x06002FD3 RID: 12243
		void #5b();
	}
}
