using System;
using System.Collections.Generic;
using System.Windows.Media;
using #u3d;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x02000A03 RID: 2563
	public interface IBoxDrawingResult : IDrawingResult
	{
		// Token: 0x17001839 RID: 6201
		// (get) Token: 0x06005466 RID: 21606
		// (set) Token: 0x06005467 RID: 21607
		Point3D Center { get; set; }

		// Token: 0x1700183A RID: 6202
		// (get) Token: 0x06005468 RID: 21608
		// (set) Token: 0x06005469 RID: 21609
		#03d Size { get; set; }

		// Token: 0x1700183B RID: 6203
		// (get) Token: 0x0600546A RID: 21610
		// (set) Token: 0x0600546B RID: 21611
		Color Color { get; set; }

		// Token: 0x1700183C RID: 6204
		// (get) Token: 0x0600546C RID: 21612
		IEnumerable<Point3D> Positions { get; }

		// Token: 0x0600546D RID: 21613
		void UpdateNormal(#c4d normal, #c4d translateVector);
	}
}
