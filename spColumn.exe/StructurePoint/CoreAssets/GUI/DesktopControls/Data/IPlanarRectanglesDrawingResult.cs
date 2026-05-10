using System;
using System.Collections.Generic;
using System.Windows.Media;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x020009FC RID: 2556
	public interface IPlanarRectanglesDrawingResult : IDrawingResult
	{
		// Token: 0x17001817 RID: 6167
		// (get) Token: 0x06005418 RID: 21528
		// (set) Token: 0x06005419 RID: 21529
		double Width { get; set; }

		// Token: 0x17001818 RID: 6168
		// (get) Token: 0x0600541A RID: 21530
		// (set) Token: 0x0600541B RID: 21531
		double Height { get; set; }

		// Token: 0x17001819 RID: 6169
		// (get) Token: 0x0600541C RID: 21532
		// (set) Token: 0x0600541D RID: 21533
		IEnumerable<Point3D> CenterPoints { get; set; }

		// Token: 0x1700181A RID: 6170
		// (get) Token: 0x0600541E RID: 21534
		// (set) Token: 0x0600541F RID: 21535
		Color Color { get; set; }

		// Token: 0x1700181B RID: 6171
		// (get) Token: 0x06005420 RID: 21536
		IEnumerable<PolyLine3D> Polylines { get; }
	}
}
