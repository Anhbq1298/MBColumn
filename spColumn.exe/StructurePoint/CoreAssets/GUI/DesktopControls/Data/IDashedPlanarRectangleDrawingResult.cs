using System;
using System.Collections.Generic;
using System.Windows.Media;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x02000A1D RID: 2589
	public interface IDashedPlanarRectangleDrawingResult : IDrawingResult
	{
		// Token: 0x170018A7 RID: 6311
		// (get) Token: 0x06005587 RID: 21895
		bool DrawBoundingPolyline { get; }

		// Token: 0x170018A8 RID: 6312
		// (get) Token: 0x06005588 RID: 21896
		// (set) Token: 0x06005589 RID: 21897
		Point3D StartPoint { get; set; }

		// Token: 0x170018A9 RID: 6313
		// (get) Token: 0x0600558A RID: 21898
		// (set) Token: 0x0600558B RID: 21899
		Point3D EndPoint { get; set; }

		// Token: 0x170018AA RID: 6314
		// (get) Token: 0x0600558C RID: 21900
		// (set) Token: 0x0600558D RID: 21901
		Color Color { get; set; }

		// Token: 0x170018AB RID: 6315
		// (get) Token: 0x0600558E RID: 21902
		// (set) Token: 0x0600558F RID: 21903
		Color? LineColor { get; set; }

		// Token: 0x170018AC RID: 6316
		// (get) Token: 0x06005590 RID: 21904
		// (set) Token: 0x06005591 RID: 21905
		double LineThickness { get; set; }

		// Token: 0x170018AD RID: 6317
		// (get) Token: 0x06005592 RID: 21906
		// (set) Token: 0x06005593 RID: 21907
		double SegmentLength { get; set; }

		// Token: 0x06005594 RID: 21908
		IEnumerable<Point3D> CalculatePoints();
	}
}
