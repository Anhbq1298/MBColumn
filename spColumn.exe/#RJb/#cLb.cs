using System;
using #6re;
using #8Cc;
using #eU;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.API;
using StructurePoint.CoreAssets.Logger;
using StructurePoint.Products.Column.Editor.Core.Selection;
using StructurePoint.Products.Column.Services.API;

namespace #RJb
{
	// Token: 0x02000665 RID: 1637
	internal interface #cLb : IDisposable, IEyeshotToolContext
	{
		// Token: 0x17001114 RID: 4372
		// (get) Token: 0x06003712 RID: 14098
		#8Jb RenderOptions { get; }

		// Token: 0x17001115 RID: 4373
		// (get) Token: 0x06003713 RID: 14099
		#aMb ViewportOptions { get; }

		// Token: 0x17001116 RID: 4374
		// (get) Token: 0x06003714 RID: 14100
		ISettingsManager Settings { get; }

		// Token: 0x17001117 RID: 4375
		// (get) Token: 0x06003715 RID: 14101
		#yse ReporterSettings { get; }

		// Token: 0x17001118 RID: 4376
		// (get) Token: 0x06003716 RID: 14102
		#oW ProjectContext { get; }

		// Token: 0x17001119 RID: 4377
		// (get) Token: 0x06003717 RID: 14103
		#bDc UndoManager { get; }

		// Token: 0x1700111A RID: 4378
		// (get) Token: 0x06003718 RID: 14104
		ILogger Logger { get; }

		// Token: 0x1700111B RID: 4379
		// (get) Token: 0x06003719 RID: 14105
		#2Lb Snapping { get; }

		// Token: 0x1700111C RID: 4380
		// (get) Token: 0x0600371A RID: 14106
		#0V SnappingCache { get; }

		// Token: 0x1700111D RID: 4381
		// (get) Token: 0x0600371B RID: 14107
		SelectionManager Selection { get; }
	}
}
