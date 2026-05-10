using System;
using System.Windows.Media;
using #Fmc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Utils
{
	// Token: 0x020008DA RID: 2266
	public interface ISnapPointsMarker
	{
		// Token: 0x17001504 RID: 5380
		// (get) Token: 0x060047C7 RID: 18375
		IPointsDrawingResult PointsDrawingResult { get; }

		// Token: 0x17001505 RID: 5381
		// (get) Token: 0x060047C8 RID: 18376
		// (set) Token: 0x060047C9 RID: 18377
		Color DefaultSnapPointsColor { get; set; }

		// Token: 0x17001506 RID: 5382
		// (get) Token: 0x060047CA RID: 18378
		// (set) Token: 0x060047CB RID: 18379
		Color KeyPointSnapPointColor { get; set; }

		// Token: 0x17001507 RID: 5383
		// (get) Token: 0x060047CC RID: 18380
		// (set) Token: 0x060047CD RID: 18381
		double DefaultSnapPointsSize { get; set; }

		// Token: 0x17001508 RID: 5384
		// (get) Token: 0x060047CE RID: 18382
		// (set) Token: 0x060047CF RID: 18383
		double KeyPointSnapPointSize { get; set; }

		// Token: 0x17001509 RID: 5385
		// (get) Token: 0x060047D0 RID: 18384
		// (set) Token: 0x060047D1 RID: 18385
		double SnapPointZOffset { get; set; }

		// Token: 0x060047D2 RID: 18386
		void Mark(Point3D? point);

		// Token: 0x060047D3 RID: 18387
		void Mark(#Atc snapToPointResult);

		// Token: 0x060047D4 RID: 18388
		void Mark(#fuc snapToEdgeResult);
	}
}
