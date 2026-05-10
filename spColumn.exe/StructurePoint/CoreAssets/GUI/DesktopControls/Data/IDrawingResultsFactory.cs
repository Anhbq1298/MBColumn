using System;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x02000A1F RID: 2591
	public interface IDrawingResultsFactory
	{
		// Token: 0x060055AD RID: 21933
		ICrossIndicatorDrawingResult CreateCrossIndicatorDrawingResult();

		// Token: 0x060055AE RID: 21934
		IPolygonsDrawingResult CreatePolygonsDrawingResult();

		// Token: 0x060055AF RID: 21935
		IDashedMultilineDrawingResult CreateDashedMultilineDrawingResult();

		// Token: 0x060055B0 RID: 21936
		IDashedPlanarRectangleDrawingResult CreateDashedPlanarRectangleDrawingResult(bool drawBoundingPolyline);

		// Token: 0x060055B1 RID: 21937
		IPlanarRectangleDrawingResult CreatePlanarRectangleDrawingResult(bool drawBoundingPolyline);

		// Token: 0x060055B2 RID: 21938
		IPlanarCircleDrawingResult CreatePlanarCircleDrawingResult(bool drawBoundingPolyline);

		// Token: 0x060055B3 RID: 21939
		IPlanarRegularPolygonDrawingResult CreatePlanarRegularPolygonDrawingResult(bool drawBoundingPolyline);

		// Token: 0x060055B4 RID: 21940
		IPointsDrawingResult CreatePointsDrawingResult();

		// Token: 0x060055B5 RID: 21941
		IPolylineDrawingResult CreatePolylineDrawingResult();

		// Token: 0x060055B6 RID: 21942
		IMultilineDrawingResult CreateMultilineDrawingResult();

		// Token: 0x060055B7 RID: 21943
		IAnnotationDrawingResult CreateAnnotationDrawingResult();

		// Token: 0x060055B8 RID: 21944
		ICirclesDrawingResult CreateCirclesDrawingResult();

		// Token: 0x060055B9 RID: 21945
		IMeshDrawingResult CreateMeshDrawingResult();

		// Token: 0x060055BA RID: 21946
		ITextDrawingResult CreateTextDrawingResult();

		// Token: 0x060055BB RID: 21947
		ISphereDrawingResult CreateSphereDrawingResult();

		// Token: 0x060055BC RID: 21948
		IPlaneDrawingResult CreatePlaneDrawingResult();

		// Token: 0x060055BD RID: 21949
		IArrowDrawingResult CreateArrowDrawingResult();

		// Token: 0x060055BE RID: 21950
		IMultiPolyLineDrawingResult CreateMulitPolyLineDrawingResult();

		// Token: 0x060055BF RID: 21951
		IBoxDrawingResult CreateBoxDrawingResult();

		// Token: 0x060055C0 RID: 21952
		IPlanarRectanglesDrawingResult CreateRectanglesDrawingResult();

		// Token: 0x060055C1 RID: 21953
		IHTypeDrawingResult CreateHTypeDrawingResult();

		// Token: 0x060055C2 RID: 21954
		IMultiTextDrawingResult CreateMultiTextDrawingResult();

		// Token: 0x060055C3 RID: 21955
		IBillboardTextDrawingResult CreateBillboardTextDrawingResult();
	}
}
