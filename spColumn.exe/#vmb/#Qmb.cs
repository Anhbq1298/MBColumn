using System;
using System.Runtime.CompilerServices;
using #3vb;
using #eU;
using #ezc;
using #LQc;
using #Mbb;
using #Zmb;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.GUI.SharedResources;
using StructurePoint.Products.Column.Services.API;

namespace #vmb
{
	// Token: 0x02000442 RID: 1090
	internal sealed class #Qmb : #5mb
	{
		// Token: 0x0600280A RID: 10250 RVA: 0x000DA5A0 File Offset: 0x000D87A0
		public #Qmb(#Wgb #Rmb, IModelEditorControl #Smb, IDrawingResultsFactory #Tmb, IResourcesHelper #Umb, #3mb #Vmb, #zU #cL, ISettingsManager #iw, #2vb #Wmb, ICommandFactory #iB, #8Sc #ls, #xAc #6x, #iW #ss)
		{
			this.#a = #Rmb;
			this.#b = #Smb;
			this.#c = #Tmb;
			this.#d = #Umb;
			this.#e = #Vmb;
			this.#f = #cL;
			this.#g = #iw;
			this.#h = #Wmb;
			this.#i = #iB;
			this.#j = #ls;
			this.#k = #6x;
			this.#l = #ss;
		}

		// Token: 0x17000D55 RID: 3413
		// (get) Token: 0x0600280B RID: 10251 RVA: 0x00025092 File Offset: 0x00023292
		public #Wgb FailureSurfaceViewModel { get; }

		// Token: 0x17000D56 RID: 3414
		// (get) Token: 0x0600280C RID: 10252 RVA: 0x0002509E File Offset: 0x0002329E
		public IModelEditorControl ModelEditorControl { get; }

		// Token: 0x17000D57 RID: 3415
		// (get) Token: 0x0600280D RID: 10253 RVA: 0x000250AA File Offset: 0x000232AA
		public IDrawingResultsFactory DrawingResultsFactory { get; }

		// Token: 0x17000D58 RID: 3416
		// (get) Token: 0x0600280E RID: 10254 RVA: 0x000250B6 File Offset: 0x000232B6
		public IResourcesHelper ResourcesHelper { get; }

		// Token: 0x17000D59 RID: 3417
		// (get) Token: 0x0600280F RID: 10255 RVA: 0x000250C2 File Offset: 0x000232C2
		public #3mb FailureSurfaceContext { get; }

		// Token: 0x17000D5A RID: 3418
		// (get) Token: 0x06002810 RID: 10256 RVA: 0x000250CE File Offset: 0x000232CE
		public #zU GuiController { get; }

		// Token: 0x17000D5B RID: 3419
		// (get) Token: 0x06002811 RID: 10257 RVA: 0x000250DA File Offset: 0x000232DA
		public ISettingsManager SettingsManager { get; }

		// Token: 0x17000D5C RID: 3420
		// (get) Token: 0x06002812 RID: 10258 RVA: 0x000250E6 File Offset: 0x000232E6
		public #2vb CommandsManager { get; }

		// Token: 0x17000D5D RID: 3421
		// (get) Token: 0x06002813 RID: 10259 RVA: 0x000250F2 File Offset: 0x000232F2
		public ICommandFactory CommandFactory { get; }

		// Token: 0x17000D5E RID: 3422
		// (get) Token: 0x06002814 RID: 10260 RVA: 0x000250FE File Offset: 0x000232FE
		public #8Sc DialogService { get; }

		// Token: 0x17000D5F RID: 3423
		// (get) Token: 0x06002815 RID: 10261 RVA: 0x0002510A File Offset: 0x0002330A
		public #xAc ApplicationInfoProvider { get; }

		// Token: 0x17000D60 RID: 3424
		// (get) Token: 0x06002816 RID: 10262 RVA: 0x00025116 File Offset: 0x00023316
		public #iW WindowLocator { get; }

		// Token: 0x04000FC9 RID: 4041
		[CompilerGenerated]
		private readonly #Wgb #a;

		// Token: 0x04000FCA RID: 4042
		[CompilerGenerated]
		private readonly IModelEditorControl #b;

		// Token: 0x04000FCB RID: 4043
		[CompilerGenerated]
		private readonly IDrawingResultsFactory #c;

		// Token: 0x04000FCC RID: 4044
		[CompilerGenerated]
		private readonly IResourcesHelper #d;

		// Token: 0x04000FCD RID: 4045
		[CompilerGenerated]
		private readonly #3mb #e;

		// Token: 0x04000FCE RID: 4046
		[CompilerGenerated]
		private readonly #zU #f;

		// Token: 0x04000FCF RID: 4047
		[CompilerGenerated]
		private readonly ISettingsManager #g;

		// Token: 0x04000FD0 RID: 4048
		[CompilerGenerated]
		private readonly #2vb #h;

		// Token: 0x04000FD1 RID: 4049
		[CompilerGenerated]
		private readonly ICommandFactory #i;

		// Token: 0x04000FD2 RID: 4050
		[CompilerGenerated]
		private readonly #8Sc #j;

		// Token: 0x04000FD3 RID: 4051
		[CompilerGenerated]
		private readonly #xAc #k;

		// Token: 0x04000FD4 RID: 4052
		[CompilerGenerated]
		private readonly #iW #l;
	}
}
