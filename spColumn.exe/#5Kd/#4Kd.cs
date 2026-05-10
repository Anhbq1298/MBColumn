using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using #ezc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.Framework.Services;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using Telerik.Windows.Controls;

namespace #5Kd
{
	// Token: 0x020001B1 RID: 433
	internal interface #4Kd : #QBc, #WBc
	{
		// Token: 0x1400002C RID: 44
		// (add) Token: 0x06000E96 RID: 3734
		// (remove) Token: 0x06000E97 RID: 3735
		event EventHandler Activated;

		// Token: 0x1700058D RID: 1421
		// (get) Token: 0x06000E98 RID: 3736
		// (set) Token: 0x06000E99 RID: 3737
		double Width { get; set; }

		// Token: 0x1700058E RID: 1422
		// (get) Token: 0x06000E9A RID: 3738
		// (set) Token: 0x06000E9B RID: 3739
		double Height { get; set; }

		// Token: 0x1700058F RID: 1423
		// (get) Token: 0x06000E9C RID: 3740
		// (set) Token: 0x06000E9D RID: 3741
		IGenericLoaderWindow AssociatedLoaderWindow { get; set; }

		// Token: 0x17000590 RID: 1424
		// (get) Token: 0x06000E9E RID: 3742
		RadPdfViewer WordAndPdfViewer { get; }

		// Token: 0x17000591 RID: 1425
		// (get) Token: 0x06000E9F RID: 3743
		CustomRadNumericUpDown PageNumberUpDown { get; }

		// Token: 0x17000592 RID: 1426
		// (get) Token: 0x06000EA0 RID: 3744
		RadPdfViewer TextViewer { get; }

		// Token: 0x17000593 RID: 1427
		// (get) Token: 0x06000EA1 RID: 3745
		// (set) Token: 0x06000EA2 RID: 3746
		ExplorerPosition ExplorerPosition { get; set; }

		// Token: 0x17000594 RID: 1428
		// (get) Token: 0x06000EA3 RID: 3747
		// (set) Token: 0x06000EA4 RID: 3748
		ImageSource Icon { get; set; }

		// Token: 0x17000595 RID: 1429
		// (get) Token: 0x06000EA5 RID: 3749
		// (set) Token: 0x06000EA6 RID: 3750
		Visibility Visibility { get; set; }

		// Token: 0x06000EA7 RID: 3751
		void NavigateSpreadsheet(string item);

		// Token: 0x06000EA8 RID: 3752
		void LoadSpreadsheet(Stream stream);

		// Token: 0x06000EA9 RID: 3753
		void BringToFront();
	}
}
