using System;
using #7Tc;
using #8Cc;
using #ezc;
using #Fmc;
using #LQc;
using #NWc;
using #T0c;
using #v1c;
using #YKc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using StructurePoint.CoreAssets.GUI.SharedResources;
using StructurePoint.CoreAssets.Logger;

namespace #IDc
{
	// Token: 0x02000B8E RID: 2958
	internal interface #6Ic
	{
		// Token: 0x17001B8C RID: 7052
		// (get) Token: 0x060060F5 RID: 24821
		#5Ic NotificationService { get; }

		// Token: 0x17001B8D RID: 7053
		// (get) Token: 0x060060F6 RID: 24822
		#6Gc SettingsProvider { get; }

		// Token: 0x17001B8E RID: 7054
		// (get) Token: 0x060060F7 RID: 24823
		IModelEditorControl ModelEditorControl { get; }

		// Token: 0x17001B8F RID: 7055
		// (get) Token: 0x060060F8 RID: 24824
		#Qrc SnappingProvider { get; }

		// Token: 0x17001B90 RID: 7056
		// (get) Token: 0x060060F9 RID: 24825
		#oW ProjectContext { get; }

		// Token: 0x17001B91 RID: 7057
		// (get) Token: 0x060060FA RID: 24826
		#jUc PreciseInputProvider { get; }

		// Token: 0x17001B92 RID: 7058
		// (get) Token: 0x060060FB RID: 24827
		IResourcesHelper ResourcesHelper { get; }

		// Token: 0x17001B93 RID: 7059
		// (get) Token: 0x060060FC RID: 24828
		IDrawingResultsFactory DrawingResultsFactory { get; }

		// Token: 0x17001B94 RID: 7060
		// (get) Token: 0x060060FD RID: 24829
		#R2c MouseAndKeyboardService { get; }

		// Token: 0x17001B95 RID: 7061
		// (get) Token: 0x060060FE RID: 24830
		#bDc UndoManager { get; }

		// Token: 0x17001B96 RID: 7062
		// (get) Token: 0x060060FF RID: 24831
		#rBc ErrorsHandlingService { get; }

		// Token: 0x17001B97 RID: 7063
		// (get) Token: 0x06006100 RID: 24832
		ILogger Logger { get; }

		// Token: 0x17001B98 RID: 7064
		// (get) Token: 0x06006101 RID: 24833
		// (set) Token: 0x06006102 RID: 24834
		#hvc SnappingModes { get; set; }

		// Token: 0x17001B99 RID: 7065
		// (get) Token: 0x06006103 RID: 24835
		ISnapPointsMarker SnapPointsMarker { get; }

		// Token: 0x17001B9A RID: 7066
		// (get) Token: 0x06006104 RID: 24836
		#6Kc ToolOperationsHelper { get; }

		// Token: 0x17001B9B RID: 7067
		// (get) Token: 0x06006105 RID: 24837
		#5Kc PostOperationsAssignmentsHandler { get; }

		// Token: 0x17001B9C RID: 7068
		// (get) Token: 0x06006106 RID: 24838
		#PWc SnappingPointsUpdater { get; }

		// Token: 0x17001B9D RID: 7069
		// (get) Token: 0x06006107 RID: 24839
		// (set) Token: 0x06006108 RID: 24840
		object OwnerControl { get; set; }

		// Token: 0x17001B9E RID: 7070
		// (get) Token: 0x06006109 RID: 24841
		#V0c ModelEditorViewModel { get; }

		// Token: 0x17001B9F RID: 7071
		// (get) Token: 0x0600610A RID: 24842
		#OWc MainModelValidator { get; }

		// Token: 0x17001BA0 RID: 7072
		// (get) Token: 0x0600610B RID: 24843
		#8Sc DialogService { get; }

		// Token: 0x17001BA1 RID: 7073
		// (get) Token: 0x0600610C RID: 24844
		#XKc ToolsConfiguration { get; }

		// Token: 0x17001BA2 RID: 7074
		// (get) Token: 0x0600610D RID: 24845
		#xAc ApplicationInfoProvider { get; }
	}
}
