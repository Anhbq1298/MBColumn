using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Controls;
using #8Cc;
using #eU;
using #UYd;
using #Xc;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.Viewports.API;
using Telerik.Windows.Controls;

namespace #hg
{
	// Token: 0x020000A2 RID: 162
	internal interface #jg : INotifyPropertyChanged
	{
		// Token: 0x14000017 RID: 23
		// (add) Token: 0x0600052E RID: 1326
		// (remove) Token: 0x0600052F RID: 1327
		event EventHandler<#yd> ActiveViewportChanged;

		// Token: 0x14000018 RID: 24
		// (add) Token: 0x06000530 RID: 1328
		// (remove) Token: 0x06000531 RID: 1329
		event EventHandler<#yd> ActiveViewportChanging;

		// Token: 0x14000019 RID: 25
		// (add) Token: 0x06000532 RID: 1330
		// (remove) Token: 0x06000533 RID: 1331
		event EventHandler<#he> ViewportClosed;

		// Token: 0x1400001A RID: 26
		// (add) Token: 0x06000534 RID: 1332
		// (remove) Token: 0x06000535 RID: 1333
		event EventHandler<#ie> ViewportCreated;

		// Token: 0x1400001B RID: 27
		// (add) Token: 0x06000536 RID: 1334
		// (remove) Token: 0x06000537 RID: 1335
		event EventHandler<#Me> ViewportOverlayCommandExecuted;

		// Token: 0x170002A1 RID: 673
		// (get) Token: 0x06000538 RID: 1336
		IReadOnlyList<IViewport> Viewports { get; }

		// Token: 0x170002A2 RID: 674
		// (get) Token: 0x06000539 RID: 1337
		// (set) Token: 0x0600053A RID: 1338
		RadDocking Docking { get; set; }

		// Token: 0x170002A3 RID: 675
		// (get) Token: 0x0600053B RID: 1339
		IViewport ActiveViewport { get; }

		// Token: 0x170002A4 RID: 676
		// (get) Token: 0x0600053C RID: 1340
		#Gd Renderer { get; }

		// Token: 0x170002A5 RID: 677
		// (get) Token: 0x0600053D RID: 1341
		#bDc UndoManager { get; }

		// Token: 0x170002A6 RID: 678
		// (get) Token: 0x0600053E RID: 1342
		#oW ProjectContext { get; }

		// Token: 0x170002A7 RID: 679
		// (get) Token: 0x0600053F RID: 1343
		ISettingsManager SettingsManager { get; }

		// Token: 0x170002A8 RID: 680
		// (get) Token: 0x06000540 RID: 1344
		// (set) Token: 0x06000541 RID: 1345
		#gg OverlayFactory { get; set; }

		// Token: 0x06000542 RID: 1346
		void #wf();

		// Token: 0x06000543 RID: 1347
		IViewport #xf(Action #yf);

		// Token: 0x06000544 RID: 1348
		void #zf();

		// Token: 0x06000545 RID: 1349
		void #Af(Orientation #De, #qg? #Bf = null);

		// Token: 0x06000546 RID: 1350
		void #Cf();

		// Token: 0x06000547 RID: 1351
		void #Df(#uzc #wzc = null);

		// Token: 0x06000548 RID: 1352
		void #tf(RadPane #Le);

		// Token: 0x06000549 RID: 1353
		void #uf(RadPane #Le);

		// Token: 0x0600054A RID: 1354
		void #vf();

		// Token: 0x0600054B RID: 1355
		void #Ef();

		// Token: 0x0600054C RID: 1356
		bool #Ff();

		// Token: 0x0600054D RID: 1357
		void #Gf();
	}
}
