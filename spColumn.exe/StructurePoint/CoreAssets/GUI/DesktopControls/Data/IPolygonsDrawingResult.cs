using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Media;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x02000A2E RID: 2606
	public interface IPolygonsDrawingResult : IDrawingResult
	{
		// Token: 0x170018E6 RID: 6374
		// (get) Token: 0x0600566B RID: 22123
		// (set) Token: 0x0600566C RID: 22124
		Visibility SurfacesVisibility { get; set; }

		// Token: 0x170018E7 RID: 6375
		// (get) Token: 0x0600566D RID: 22125
		// (set) Token: 0x0600566E RID: 22126
		Visibility PointsVisibility { get; set; }

		// Token: 0x170018E8 RID: 6376
		// (get) Token: 0x0600566F RID: 22127
		// (set) Token: 0x06005670 RID: 22128
		IPointsDrawingResult PointsModelDrawingResult { get; set; }

		// Token: 0x170018E9 RID: 6377
		// (get) Token: 0x06005671 RID: 22129
		// (set) Token: 0x06005672 RID: 22130
		Color OuterSurfacesFillColor { get; set; }

		// Token: 0x170018EA RID: 6378
		// (get) Token: 0x06005673 RID: 22131
		// (set) Token: 0x06005674 RID: 22132
		Color InnerSurfacesFillColor { get; set; }

		// Token: 0x170018EB RID: 6379
		// (get) Token: 0x06005675 RID: 22133
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		IEnumerable<IPolylineDrawingResult> OuterEdgesDrawingResults { get; }

		// Token: 0x170018EC RID: 6380
		// (get) Token: 0x06005676 RID: 22134
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		IEnumerable<IPolylineDrawingResult> InnerEdgesDrawingResults { get; }

		// Token: 0x06005677 RID: 22135
		void AddOuterEdge(IPolylineDrawingResult polylineDrawingResult);

		// Token: 0x06005678 RID: 22136
		void RemoveOuterEdge(IPolylineDrawingResult polylineDrawingResult);

		// Token: 0x06005679 RID: 22137
		void AddInnerEdge(IPolylineDrawingResult polylineDrawingResult);

		// Token: 0x0600567A RID: 22138
		void RemoveInnerEdge(IPolylineDrawingResult polylineDrawingResult);
	}
}
