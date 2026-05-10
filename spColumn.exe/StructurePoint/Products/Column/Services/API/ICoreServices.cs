using System;
using #6re;
using #8Cc;
using #bCc;
using #coe;
using #eU;
using #ezc;
using #IDc;
using #LQc;
using #oKe;
using #sUd;
using #v1c;
using StructurePoint.CoreAssets.Logger;

namespace StructurePoint.Products.Column.Services.API
{
	// Token: 0x020002AD RID: 685
	internal interface ICoreServices
	{
		// Token: 0x1700081E RID: 2078
		// (get) Token: 0x06001687 RID: 5767
		#dU ToolsContext { get; }

		// Token: 0x1700081F RID: 2079
		// (get) Token: 0x06001688 RID: 5768
		#R2c MouseAndKeyboard { get; }

		// Token: 0x17000820 RID: 2080
		// (get) Token: 0x06001689 RID: 5769
		#tUd ExceptionHandler { get; }

		// Token: 0x17000821 RID: 2081
		// (get) Token: 0x0600168A RID: 5770
		#yse ReporterSettings { get; }

		// Token: 0x17000822 RID: 2082
		// (get) Token: 0x0600168B RID: 5771
		#v2c FileSystem { get; }

		// Token: 0x17000823 RID: 2083
		// (get) Token: 0x0600168C RID: 5772
		#bDc UndoManager { get; }

		// Token: 0x17000824 RID: 2084
		// (get) Token: 0x0600168D RID: 5773
		#8Sc DialogService { get; }

		// Token: 0x17000825 RID: 2085
		// (get) Token: 0x0600168E RID: 5774
		ILogger Logger { get; }

		// Token: 0x17000826 RID: 2086
		// (get) Token: 0x0600168F RID: 5775
		#oW Project { get; }

		// Token: 0x17000827 RID: 2087
		// (get) Token: 0x06001690 RID: 5776
		#9V StorageModelConverter { get; }

		// Token: 0x17000828 RID: 2088
		// (get) Token: 0x06001691 RID: 5777
		ISettingsManager Settings { get; }

		// Token: 0x17000829 RID: 2089
		// (get) Token: 0x06001692 RID: 5778
		#0V SnappingCache { get; }

		// Token: 0x1700082A RID: 2090
		// (get) Token: 0x06001693 RID: 5779
		#zU GuiController { get; }

		// Token: 0x1700082B RID: 2091
		// (get) Token: 0x06001694 RID: 5780
		#nKe Localization { get; }

		// Token: 0x1700082C RID: 2092
		// (get) Token: 0x06001695 RID: 5781
		#xAc ApplicationInfo { get; }

		// Token: 0x1700082D RID: 2093
		// (get) Token: 0x06001696 RID: 5782
		#rBc ErrorsHandler { get; }

		// Token: 0x1700082E RID: 2094
		// (get) Token: 0x06001697 RID: 5783
		#UV MessageBus { get; }

		// Token: 0x1700082F RID: 2095
		// (get) Token: 0x06001698 RID: 5784
		#wU Commands { get; }

		// Token: 0x17000830 RID: 2096
		// (get) Token: 0x06001699 RID: 5785
		#iW WindowLocator { get; }

		// Token: 0x17000831 RID: 2097
		// (get) Token: 0x0600169A RID: 5786
		#5Ic Notifications { get; }

		// Token: 0x17000832 RID: 2098
		// (get) Token: 0x0600169B RID: 5787
		#Ioe Storage { get; }

		// Token: 0x17000833 RID: 2099
		// (get) Token: 0x0600169C RID: 5788
		#aCc SystemCommands { get; }
	}
}
