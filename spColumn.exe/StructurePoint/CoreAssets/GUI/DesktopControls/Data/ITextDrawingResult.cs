using System;
using System.Windows.Media;
using #u3d;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x02000A0B RID: 2571
	public interface ITextDrawingResult : IDrawingResult
	{
		// Token: 0x1700185E RID: 6238
		// (get) Token: 0x060054BB RID: 21691
		// (set) Token: 0x060054BC RID: 21692
		string Text { get; set; }

		// Token: 0x1700185F RID: 6239
		// (get) Token: 0x060054BD RID: 21693
		// (set) Token: 0x060054BE RID: 21694
		Point3D Position { get; set; }

		// Token: 0x17001860 RID: 6240
		// (get) Token: 0x060054BF RID: 21695
		// (set) Token: 0x060054C0 RID: 21696
		Color TextColor { get; set; }

		// Token: 0x17001861 RID: 6241
		// (get) Token: 0x060054C1 RID: 21697
		// (set) Token: 0x060054C2 RID: 21698
		double FontSize { get; set; }

		// Token: 0x17001862 RID: 6242
		// (get) Token: 0x060054C3 RID: 21699
		// (set) Token: 0x060054C4 RID: 21700
		#c4d UpDirection { get; set; }

		// Token: 0x17001863 RID: 6243
		// (get) Token: 0x060054C5 RID: 21701
		// (set) Token: 0x060054C6 RID: 21702
		#c4d TextDirection { get; set; }
	}
}
