using System;
using System.Collections.Generic;
using System.Windows.Media;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x020009F7 RID: 2551
	public interface IHTypeDrawingResult : IDrawingResult
	{
		// Token: 0x170017FD RID: 6141
		// (get) Token: 0x060053DD RID: 21469
		// (set) Token: 0x060053DE RID: 21470
		IEnumerable<Point3D> CenterPoints { get; set; }

		// Token: 0x170017FE RID: 6142
		// (get) Token: 0x060053DF RID: 21471
		// (set) Token: 0x060053E0 RID: 21472
		Color Color { get; set; }

		// Token: 0x170017FF RID: 6143
		// (get) Token: 0x060053E1 RID: 21473
		// (set) Token: 0x060053E2 RID: 21474
		double RotationAngle { get; set; }

		// Token: 0x17001800 RID: 6144
		// (get) Token: 0x060053E3 RID: 21475
		// (set) Token: 0x060053E4 RID: 21476
		double WebThickness { get; set; }

		// Token: 0x17001801 RID: 6145
		// (get) Token: 0x060053E5 RID: 21477
		// (set) Token: 0x060053E6 RID: 21478
		double WebWeight { get; set; }

		// Token: 0x17001802 RID: 6146
		// (get) Token: 0x060053E7 RID: 21479
		// (set) Token: 0x060053E8 RID: 21480
		double FlangeThickness { get; set; }

		// Token: 0x17001803 RID: 6147
		// (get) Token: 0x060053E9 RID: 21481
		// (set) Token: 0x060053EA RID: 21482
		double FlangeWidth { get; set; }

		// Token: 0x17001804 RID: 6148
		// (get) Token: 0x060053EB RID: 21483
		IEnumerable<PolyLine3D> Polylines { get; }
	}
}
