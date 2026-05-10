using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using #7hc;
using #7Tc;
using #8Cc;
using #ezc;
using #Fmc;
using #LQc;
using #NWc;
using #T0c;
using #UYd;
using #v1c;
using #YKc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using StructurePoint.CoreAssets.GUI.SharedResources;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Logger;

namespace #IDc
{
	// Token: 0x02000B8D RID: 2957
	[SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses")]
	internal sealed class #DHc : #6Ic
	{
		// Token: 0x060060C6 RID: 24774 RVA: 0x0017BF00 File Offset: 0x0017A100
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "IoC")]
		public #DHc(#GBc #2x)
		{
			#X0d.#V0d(#2x, #Phc.#3hc(107417812), Component.GUIFramework, #Phc.#3hc(107416027));
			this.ToolOperationsHelper = #2x.#vy<#6Kc>();
			this.UndoManager = #2x.#vy<#bDc>();
			this.ModelEditorViewModel = #2x.#vy<#V0c>();
			this.ProjectContext = #2x.#vy<#oW>();
			this.NotificationService = #2x.#vy<#5Ic>();
			this.SettingsProvider = #2x.#vy<#6Gc>();
			this.ModelEditorControl = this.ModelEditorViewModel.View.ModelVisualizationControl;
			this.SnappingProvider = #2x.#vy<#Qrc>();
			this.SnappingModes = (#hvc.#b | #hvc.#c);
			this.ErrorsHandlingService = #2x.#vy<#rBc>();
			this.PreciseInputProvider = #2x.#vy<#jUc>();
			this.Logger = #2x.#vy<ILogger>();
			this.ResourcesHelper = #2x.#vy<IResourcesHelper>();
			this.DrawingResultsFactory = #2x.#vy<IDrawingResultsFactory>();
			this.SnapPointsMarker = #2x.#vy<ISnapPointsMarker>();
			this.MouseAndKeyboardService = #2x.#vy<#R2c>();
			this.PostOperationsAssignmentsHandler = #2x.#vy<#5Kc>();
			this.SnappingPointsUpdater = #2x.#vy<#PWc>();
			this.DialogService = #2x.#vy<#8Sc>();
			this.MainModelValidator = #2x.#vy<#OWc>();
			this.ToolsConfiguration = #2x.#vy<#XKc>();
			this.ApplicationInfoProvider = #2x.#vy<#xAc>();
		}

		// Token: 0x17001B75 RID: 7029
		// (get) Token: 0x060060C7 RID: 24775 RVA: 0x0004F87C File Offset: 0x0004DA7C
		// (set) Token: 0x060060C8 RID: 24776 RVA: 0x0004F884 File Offset: 0x0004DA84
		public ILogger Logger { get; private set; }

		// Token: 0x17001B76 RID: 7030
		// (get) Token: 0x060060C9 RID: 24777 RVA: 0x0004F88D File Offset: 0x0004DA8D
		// (set) Token: 0x060060CA RID: 24778 RVA: 0x0004F895 File Offset: 0x0004DA95
		public #PWc SnappingPointsUpdater { get; private set; }

		// Token: 0x17001B77 RID: 7031
		// (get) Token: 0x060060CB RID: 24779 RVA: 0x0004F89E File Offset: 0x0004DA9E
		// (set) Token: 0x060060CC RID: 24780 RVA: 0x0004F8A6 File Offset: 0x0004DAA6
		public object OwnerControl { get; set; }

		// Token: 0x17001B78 RID: 7032
		// (get) Token: 0x060060CD RID: 24781 RVA: 0x0004F8AF File Offset: 0x0004DAAF
		// (set) Token: 0x060060CE RID: 24782 RVA: 0x0004F8B7 File Offset: 0x0004DAB7
		public ISnapPointsMarker SnapPointsMarker { get; private set; }

		// Token: 0x17001B79 RID: 7033
		// (get) Token: 0x060060CF RID: 24783 RVA: 0x0004F8C0 File Offset: 0x0004DAC0
		// (set) Token: 0x060060D0 RID: 24784 RVA: 0x0004F8C8 File Offset: 0x0004DAC8
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		public #5Ic NotificationService { get; private set; }

		// Token: 0x17001B7A RID: 7034
		// (get) Token: 0x060060D1 RID: 24785 RVA: 0x0004F8D1 File Offset: 0x0004DAD1
		// (set) Token: 0x060060D2 RID: 24786 RVA: 0x0004F8D9 File Offset: 0x0004DAD9
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		public #6Gc SettingsProvider { get; private set; }

		// Token: 0x17001B7B RID: 7035
		// (get) Token: 0x060060D3 RID: 24787 RVA: 0x0004F8E2 File Offset: 0x0004DAE2
		// (set) Token: 0x060060D4 RID: 24788 RVA: 0x0004F8EA File Offset: 0x0004DAEA
		public #bDc UndoManager { get; private set; }

		// Token: 0x17001B7C RID: 7036
		// (get) Token: 0x060060D5 RID: 24789 RVA: 0x0004F8F3 File Offset: 0x0004DAF3
		// (set) Token: 0x060060D6 RID: 24790 RVA: 0x0004F8FB File Offset: 0x0004DAFB
		public #rBc ErrorsHandlingService { get; private set; }

		// Token: 0x17001B7D RID: 7037
		// (get) Token: 0x060060D7 RID: 24791 RVA: 0x0004F904 File Offset: 0x0004DB04
		// (set) Token: 0x060060D8 RID: 24792 RVA: 0x0004F90C File Offset: 0x0004DB0C
		public #oW ProjectContext { get; private set; }

		// Token: 0x17001B7E RID: 7038
		// (get) Token: 0x060060D9 RID: 24793 RVA: 0x0004F915 File Offset: 0x0004DB15
		// (set) Token: 0x060060DA RID: 24794 RVA: 0x0004F91D File Offset: 0x0004DB1D
		public #jUc PreciseInputProvider { get; private set; }

		// Token: 0x17001B7F RID: 7039
		// (get) Token: 0x060060DB RID: 24795 RVA: 0x0004F926 File Offset: 0x0004DB26
		// (set) Token: 0x060060DC RID: 24796 RVA: 0x0004F92E File Offset: 0x0004DB2E
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		public IModelEditorControl ModelEditorControl { get; private set; }

		// Token: 0x17001B80 RID: 7040
		// (get) Token: 0x060060DD RID: 24797 RVA: 0x0004F937 File Offset: 0x0004DB37
		// (set) Token: 0x060060DE RID: 24798 RVA: 0x0004F93F File Offset: 0x0004DB3F
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		public #Qrc SnappingProvider { get; private set; }

		// Token: 0x17001B81 RID: 7041
		// (get) Token: 0x060060DF RID: 24799 RVA: 0x0004F948 File Offset: 0x0004DB48
		// (set) Token: 0x060060E0 RID: 24800 RVA: 0x0004F950 File Offset: 0x0004DB50
		public #hvc SnappingModes { get; set; }

		// Token: 0x17001B82 RID: 7042
		// (get) Token: 0x060060E1 RID: 24801 RVA: 0x0004F959 File Offset: 0x0004DB59
		// (set) Token: 0x060060E2 RID: 24802 RVA: 0x0004F961 File Offset: 0x0004DB61
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		public #V0c ModelEditorViewModel { get; private set; }

		// Token: 0x17001B83 RID: 7043
		// (get) Token: 0x060060E3 RID: 24803 RVA: 0x0004F96A File Offset: 0x0004DB6A
		// (set) Token: 0x060060E4 RID: 24804 RVA: 0x0004F972 File Offset: 0x0004DB72
		public #OWc MainModelValidator { get; private set; }

		// Token: 0x17001B84 RID: 7044
		// (get) Token: 0x060060E5 RID: 24805 RVA: 0x0004F97B File Offset: 0x0004DB7B
		// (set) Token: 0x060060E6 RID: 24806 RVA: 0x0004F983 File Offset: 0x0004DB83
		public #8Sc DialogService { get; private set; }

		// Token: 0x17001B85 RID: 7045
		// (get) Token: 0x060060E7 RID: 24807 RVA: 0x0004F98C File Offset: 0x0004DB8C
		// (set) Token: 0x060060E8 RID: 24808 RVA: 0x0004F994 File Offset: 0x0004DB94
		public #XKc ToolsConfiguration { get; private set; }

		// Token: 0x17001B86 RID: 7046
		// (get) Token: 0x060060E9 RID: 24809 RVA: 0x0004F99D File Offset: 0x0004DB9D
		// (set) Token: 0x060060EA RID: 24810 RVA: 0x0004F9A5 File Offset: 0x0004DBA5
		public #xAc ApplicationInfoProvider { get; private set; }

		// Token: 0x17001B87 RID: 7047
		// (get) Token: 0x060060EB RID: 24811 RVA: 0x0004F9AE File Offset: 0x0004DBAE
		// (set) Token: 0x060060EC RID: 24812 RVA: 0x0004F9B6 File Offset: 0x0004DBB6
		public IResourcesHelper ResourcesHelper { get; private set; }

		// Token: 0x17001B88 RID: 7048
		// (get) Token: 0x060060ED RID: 24813 RVA: 0x0004F9BF File Offset: 0x0004DBBF
		// (set) Token: 0x060060EE RID: 24814 RVA: 0x0004F9C7 File Offset: 0x0004DBC7
		public IDrawingResultsFactory DrawingResultsFactory { get; private set; }

		// Token: 0x17001B89 RID: 7049
		// (get) Token: 0x060060EF RID: 24815 RVA: 0x0004F9D0 File Offset: 0x0004DBD0
		// (set) Token: 0x060060F0 RID: 24816 RVA: 0x0004F9D8 File Offset: 0x0004DBD8
		public #R2c MouseAndKeyboardService { get; private set; }

		// Token: 0x17001B8A RID: 7050
		// (get) Token: 0x060060F1 RID: 24817 RVA: 0x0004F9E1 File Offset: 0x0004DBE1
		// (set) Token: 0x060060F2 RID: 24818 RVA: 0x0004F9E9 File Offset: 0x0004DBE9
		public #6Kc ToolOperationsHelper { get; private set; }

		// Token: 0x17001B8B RID: 7051
		// (get) Token: 0x060060F3 RID: 24819 RVA: 0x0004F9F2 File Offset: 0x0004DBF2
		// (set) Token: 0x060060F4 RID: 24820 RVA: 0x0004F9FA File Offset: 0x0004DBFA
		public #5Kc PostOperationsAssignmentsHandler { get; private set; }

		// Token: 0x040027AE RID: 10158
		[CompilerGenerated]
		private ILogger #a;

		// Token: 0x040027AF RID: 10159
		[CompilerGenerated]
		private #PWc #b;

		// Token: 0x040027B0 RID: 10160
		[CompilerGenerated]
		private object #c;

		// Token: 0x040027B1 RID: 10161
		[CompilerGenerated]
		private ISnapPointsMarker #d;

		// Token: 0x040027B2 RID: 10162
		[CompilerGenerated]
		private #5Ic #e;

		// Token: 0x040027B3 RID: 10163
		[CompilerGenerated]
		private #6Gc #f;

		// Token: 0x040027B4 RID: 10164
		[CompilerGenerated]
		private #bDc #g;

		// Token: 0x040027B5 RID: 10165
		[CompilerGenerated]
		private #rBc #h;

		// Token: 0x040027B6 RID: 10166
		[CompilerGenerated]
		private #oW #i;

		// Token: 0x040027B7 RID: 10167
		[CompilerGenerated]
		private #jUc #j;

		// Token: 0x040027B8 RID: 10168
		[CompilerGenerated]
		private IModelEditorControl #k;

		// Token: 0x040027B9 RID: 10169
		[CompilerGenerated]
		private #Qrc #l;

		// Token: 0x040027BA RID: 10170
		[CompilerGenerated]
		private #hvc #m;

		// Token: 0x040027BB RID: 10171
		[CompilerGenerated]
		private #V0c #n;

		// Token: 0x040027BC RID: 10172
		[CompilerGenerated]
		private #OWc #o;

		// Token: 0x040027BD RID: 10173
		[CompilerGenerated]
		private #8Sc #p;

		// Token: 0x040027BE RID: 10174
		[CompilerGenerated]
		private #XKc #q;

		// Token: 0x040027BF RID: 10175
		[CompilerGenerated]
		private #xAc #r;

		// Token: 0x040027C0 RID: 10176
		[CompilerGenerated]
		private IResourcesHelper #s;

		// Token: 0x040027C1 RID: 10177
		[CompilerGenerated]
		private IDrawingResultsFactory #t;

		// Token: 0x040027C2 RID: 10178
		[CompilerGenerated]
		private #R2c #u;

		// Token: 0x040027C3 RID: 10179
		[CompilerGenerated]
		private #6Kc #v;

		// Token: 0x040027C4 RID: 10180
		[CompilerGenerated]
		private #5Kc #w;
	}
}
