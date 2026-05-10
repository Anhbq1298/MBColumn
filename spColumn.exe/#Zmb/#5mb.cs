using System;
using #3vb;
using #eU;
using #ezc;
using #LQc;
using #Mbb;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.GUI.SharedResources;
using StructurePoint.Products.Column.Services.API;

namespace #Zmb
{
	// Token: 0x02000443 RID: 1091
	internal interface #5mb
	{
		// Token: 0x17000D61 RID: 3425
		// (get) Token: 0x06002817 RID: 10263
		#Wgb FailureSurfaceViewModel { get; }

		// Token: 0x17000D62 RID: 3426
		// (get) Token: 0x06002818 RID: 10264
		IModelEditorControl ModelEditorControl { get; }

		// Token: 0x17000D63 RID: 3427
		// (get) Token: 0x06002819 RID: 10265
		IDrawingResultsFactory DrawingResultsFactory { get; }

		// Token: 0x17000D64 RID: 3428
		// (get) Token: 0x0600281A RID: 10266
		IResourcesHelper ResourcesHelper { get; }

		// Token: 0x17000D65 RID: 3429
		// (get) Token: 0x0600281B RID: 10267
		#3mb FailureSurfaceContext { get; }

		// Token: 0x17000D66 RID: 3430
		// (get) Token: 0x0600281C RID: 10268
		#zU GuiController { get; }

		// Token: 0x17000D67 RID: 3431
		// (get) Token: 0x0600281D RID: 10269
		ISettingsManager SettingsManager { get; }

		// Token: 0x17000D68 RID: 3432
		// (get) Token: 0x0600281E RID: 10270
		#2vb CommandsManager { get; }

		// Token: 0x17000D69 RID: 3433
		// (get) Token: 0x0600281F RID: 10271
		ICommandFactory CommandFactory { get; }

		// Token: 0x17000D6A RID: 3434
		// (get) Token: 0x06002820 RID: 10272
		#8Sc DialogService { get; }

		// Token: 0x17000D6B RID: 3435
		// (get) Token: 0x06002821 RID: 10273
		#xAc ApplicationInfoProvider { get; }

		// Token: 0x17000D6C RID: 3436
		// (get) Token: 0x06002822 RID: 10274
		#iW WindowLocator { get; }
	}
}
