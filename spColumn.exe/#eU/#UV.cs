using System;
using #cMb;
using #RJb;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;

namespace #eU
{
	// Token: 0x02000313 RID: 787
	internal interface #UV
	{
		// Token: 0x14000040 RID: 64
		// (add) Token: 0x06001B03 RID: 6915
		// (remove) Token: 0x06001B04 RID: 6916
		event EventHandler<#cW> ProjectLoaded;

		// Token: 0x14000041 RID: 65
		// (add) Token: 0x06001B05 RID: 6917
		// (remove) Token: 0x06001B06 RID: 6918
		event EventHandler<#3V> LoadProjectRequested;

		// Token: 0x14000042 RID: 66
		// (add) Token: 0x06001B07 RID: 6919
		// (remove) Token: 0x06001B08 RID: 6920
		event EventHandler UnitSystemChanged;

		// Token: 0x14000043 RID: 67
		// (add) Token: 0x06001B09 RID: 6921
		// (remove) Token: 0x06001B0A RID: 6922
		event EventHandler DesignCodeChanged;

		// Token: 0x14000044 RID: 68
		// (add) Token: 0x06001B0B RID: 6923
		// (remove) Token: 0x06001B0C RID: 6924
		event EventHandler LoadCombinationsChanged;

		// Token: 0x14000045 RID: 69
		// (add) Token: 0x06001B0D RID: 6925
		// (remove) Token: 0x06001B0E RID: 6926
		event EventHandler DefinitionChangesCommitted;

		// Token: 0x14000046 RID: 70
		// (add) Token: 0x06001B0F RID: 6927
		// (remove) Token: 0x06001B10 RID: 6928
		event EventHandler DefinitionActivePanelsChanged;

		// Token: 0x14000047 RID: 71
		// (add) Token: 0x06001B11 RID: 6929
		// (remove) Token: 0x06001B12 RID: 6930
		event EventHandler SettingsChanged;

		// Token: 0x14000048 RID: 72
		// (add) Token: 0x06001B13 RID: 6931
		// (remove) Token: 0x06001B14 RID: 6932
		event EventHandler DisplayOptionsChanged;

		// Token: 0x14000049 RID: 73
		// (add) Token: 0x06001B15 RID: 6933
		// (remove) Token: 0x06001B16 RID: 6934
		event EventHandler SectionPropertiesInvalidated;

		// Token: 0x1400004A RID: 74
		// (add) Token: 0x06001B17 RID: 6935
		// (remove) Token: 0x06001B18 RID: 6936
		event EventHandler<#fW> SolveCompleted;

		// Token: 0x1400004B RID: 75
		// (add) Token: 0x06001B19 RID: 6937
		// (remove) Token: 0x06001B1A RID: 6938
		event EventHandler<#BU> ToggleToolRequested;

		// Token: 0x1400004C RID: 76
		// (add) Token: 0x06001B1B RID: 6939
		// (remove) Token: 0x06001B1C RID: 6940
		event EventHandler SelectionModeRequested;

		// Token: 0x1400004D RID: 77
		// (add) Token: 0x06001B1D RID: 6941
		// (remove) Token: 0x06001B1E RID: 6942
		event EventHandler CancelToolsRequested;

		// Token: 0x1400004E RID: 78
		// (add) Token: 0x06001B1F RID: 6943
		// (remove) Token: 0x06001B20 RID: 6944
		event EventHandler EditorNodesSelectionChanged;

		// Token: 0x1400004F RID: 79
		// (add) Token: 0x06001B21 RID: 6945
		// (remove) Token: 0x06001B22 RID: 6946
		event EventHandler EditorNodeMoved;

		// Token: 0x14000050 RID: 80
		// (add) Token: 0x06001B23 RID: 6947
		// (remove) Token: 0x06001B24 RID: 6948
		event EventHandler EditorSelectionChanged;

		// Token: 0x14000051 RID: 81
		// (add) Token: 0x06001B25 RID: 6949
		// (remove) Token: 0x06001B26 RID: 6950
		event EventHandler DeleteSelectedObjectsRequested;

		// Token: 0x14000052 RID: 82
		// (add) Token: 0x06001B27 RID: 6951
		// (remove) Token: 0x06001B28 RID: 6952
		event EventHandler SlabsEditorSelectionChanged;

		// Token: 0x14000053 RID: 83
		// (add) Token: 0x06001B29 RID: 6953
		// (remove) Token: 0x06001B2A RID: 6954
		event EventHandler<#jW> DesignTraceStateChanged;

		// Token: 0x14000054 RID: 84
		// (add) Token: 0x06001B2B RID: 6955
		// (remove) Token: 0x06001B2C RID: 6956
		event EventHandler<#QJb> ActiveScopeChanged;

		// Token: 0x14000055 RID: 85
		// (add) Token: 0x06001B2D RID: 6957
		// (remove) Token: 0x06001B2E RID: 6958
		event EventHandler SectionImportActivateIrregularSectionView;

		// Token: 0x14000056 RID: 86
		// (add) Token: 0x06001B2F RID: 6959
		// (remove) Token: 0x06001B30 RID: 6960
		event EventHandler DiagramImposed;

		// Token: 0x14000057 RID: 87
		// (add) Token: 0x06001B31 RID: 6961
		// (remove) Token: 0x06001B32 RID: 6962
		event EventHandler SectionLeftPanelRefreshRequested;

		// Token: 0x14000058 RID: 88
		// (add) Token: 0x06001B33 RID: 6963
		// (remove) Token: 0x06001B34 RID: 6964
		event EventHandler TemplateLoaded;

		// Token: 0x14000059 RID: 89
		// (add) Token: 0x06001B35 RID: 6965
		// (remove) Token: 0x06001B36 RID: 6966
		event EventHandler TrySelectTemplateRequested;

		// Token: 0x06001B37 RID: 6967
		void #sV();

		// Token: 0x06001B38 RID: 6968
		void #tV();

		// Token: 0x06001B39 RID: 6969
		void #uV(#uNb #Ph);

		// Token: 0x06001B3A RID: 6970
		void #vV();

		// Token: 0x06001B3B RID: 6971
		void #wV(bool #xV, string #So);

		// Token: 0x06001B3C RID: 6972
		void #yV();

		// Token: 0x06001B3D RID: 6973
		void #zV(ColumnStorageModel #Od, bool #ZK, bool #AV = false);

		// Token: 0x06001B3E RID: 6974
		void #BV();

		// Token: 0x06001B3F RID: 6975
		void #CV();

		// Token: 0x06001B40 RID: 6976
		void #DV();

		// Token: 0x06001B41 RID: 6977
		void #EV();

		// Token: 0x06001B42 RID: 6978
		void #FV();

		// Token: 0x06001B43 RID: 6979
		void #GV();

		// Token: 0x06001B44 RID: 6980
		void #HV();

		// Token: 0x06001B45 RID: 6981
		void #IV();

		// Token: 0x06001B46 RID: 6982
		void #JV(#fW #Lg);

		// Token: 0x06001B47 RID: 6983
		void #KV();

		// Token: 0x06001B48 RID: 6984
		void #LV();

		// Token: 0x06001B49 RID: 6985
		void #MV();

		// Token: 0x06001B4A RID: 6986
		void #NV();

		// Token: 0x06001B4B RID: 6987
		void #OV(#jW #He);

		// Token: 0x06001B4C RID: 6988
		void #PV(#QJb #Lg);

		// Token: 0x06001B4D RID: 6989
		void #QV();

		// Token: 0x06001B4E RID: 6990
		void #RV();

		// Token: 0x06001B4F RID: 6991
		void #SV();

		// Token: 0x06001B50 RID: 6992
		void #TV();
	}
}
