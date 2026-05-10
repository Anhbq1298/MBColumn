using System;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Units.Formatters;
using StructurePoint.Products.Column.FailureSurface.Model;

namespace #Zmb
{
	// Token: 0x02000441 RID: 1089
	internal interface #3mb
	{
		// Token: 0x140000BC RID: 188
		// (add) Token: 0x060027EB RID: 10219
		// (remove) Token: 0x060027EC RID: 10220
		event EventHandler FailureSurfaceLoaded;

		// Token: 0x140000BD RID: 189
		// (add) Token: 0x060027ED RID: 10221
		// (remove) Token: 0x060027EE RID: 10222
		event EventHandler ViewportCleaned;

		// Token: 0x140000BE RID: 190
		// (add) Token: 0x060027EF RID: 10223
		// (remove) Token: 0x060027F0 RID: 10224
		event EventHandler ViewportPopulated;

		// Token: 0x140000BF RID: 191
		// (add) Token: 0x060027F1 RID: 10225
		// (remove) Token: 0x060027F2 RID: 10226
		event EventHandler CursorEnteredLoadPoint;

		// Token: 0x140000C0 RID: 192
		// (add) Token: 0x060027F3 RID: 10227
		// (remove) Token: 0x060027F4 RID: 10228
		event EventHandler CursorLeftLoadPoint;

		// Token: 0x140000C1 RID: 193
		// (add) Token: 0x060027F5 RID: 10229
		// (remove) Token: 0x060027F6 RID: 10230
		event EventHandler FailureSurfaceVisibilityChanged;

		// Token: 0x17000D4E RID: 3406
		// (get) Token: 0x060027F7 RID: 10231
		// (set) Token: 0x060027F8 RID: 10232
		FailureSurface FailureSurface { get; set; }

		// Token: 0x17000D4F RID: 3407
		// (get) Token: 0x060027F9 RID: 10233
		// (set) Token: 0x060027FA RID: 10234
		bool IsNominalSurfaceVisible { get; set; }

		// Token: 0x17000D50 RID: 3408
		// (get) Token: 0x060027FB RID: 10235
		// (set) Token: 0x060027FC RID: 10236
		bool IsFactoredSurfaceVisible { get; set; }

		// Token: 0x17000D51 RID: 3409
		// (get) Token: 0x060027FD RID: 10237
		// (set) Token: 0x060027FE RID: 10238
		bool AreLoadPointsVisible { get; set; }

		// Token: 0x17000D52 RID: 3410
		// (get) Token: 0x060027FF RID: 10239
		// (set) Token: 0x06002800 RID: 10240
		IBoxDrawingResult TransparentBox { get; set; }

		// Token: 0x17000D53 RID: 3411
		// (get) Token: 0x06002801 RID: 10241
		IUnitValueFormatter DefaultUnitValueFormatter { get; }

		// Token: 0x17000D54 RID: 3412
		// (get) Token: 0x06002802 RID: 10242
		// (set) Token: 0x06002803 RID: 10243
		bool IsMouseCursorOnForcePoint { get; set; }

		// Token: 0x06002804 RID: 10244
		void #omb(EventArgs #He);

		// Token: 0x06002805 RID: 10245
		void #pmb(EventArgs #He);

		// Token: 0x06002806 RID: 10246
		void #qmb(EventArgs #He);

		// Token: 0x06002807 RID: 10247
		void #rmb(EventArgs #He);

		// Token: 0x06002808 RID: 10248
		void #smb(EventArgs #He);

		// Token: 0x06002809 RID: 10249
		void #tmb(EventArgs #He);
	}
}
