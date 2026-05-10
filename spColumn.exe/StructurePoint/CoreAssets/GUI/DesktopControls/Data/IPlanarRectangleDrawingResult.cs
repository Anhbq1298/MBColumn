using System;
using System.Collections.Generic;
using System.Windows.Media;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x02000A21 RID: 2593
	public interface IPlanarRectangleDrawingResult : IDrawingResult
	{
		// Token: 0x170018AE RID: 6318
		// (get) Token: 0x060055C5 RID: 21957
		bool DrawBoundingPolyline { get; }

		// Token: 0x170018AF RID: 6319
		// (get) Token: 0x060055C6 RID: 21958
		// (set) Token: 0x060055C7 RID: 21959
		Point3D StartPoint { get; set; }

		// Token: 0x170018B0 RID: 6320
		// (get) Token: 0x060055C8 RID: 21960
		// (set) Token: 0x060055C9 RID: 21961
		Point3D EndPoint { get; set; }

		// Token: 0x170018B1 RID: 6321
		// (get) Token: 0x060055CA RID: 21962
		// (set) Token: 0x060055CB RID: 21963
		Color Color { get; set; }

		// Token: 0x170018B2 RID: 6322
		// (get) Token: 0x060055CC RID: 21964
		// (set) Token: 0x060055CD RID: 21965
		Color? LineColor { get; set; }

		// Token: 0x170018B3 RID: 6323
		// (get) Token: 0x060055CE RID: 21966
		// (set) Token: 0x060055CF RID: 21967
		double LineThickness { get; set; }

		// Token: 0x060055D0 RID: 21968
		IEnumerable<Point3D> CalculatePoints();
	}
}
