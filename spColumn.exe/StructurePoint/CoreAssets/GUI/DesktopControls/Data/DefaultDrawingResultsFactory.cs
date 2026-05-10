using System;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x02000A1E RID: 2590
	public sealed class DefaultDrawingResultsFactory : IDrawingResultsFactory
	{
		// Token: 0x06005595 RID: 21909 RVA: 0x00046ED5 File Offset: 0x000450D5
		public ICrossIndicatorDrawingResult CreateCrossIndicatorDrawingResult()
		{
			return new CrossIndicatorDrawingResult();
		}

		// Token: 0x06005596 RID: 21910 RVA: 0x00046EE0 File Offset: 0x000450E0
		public IPolygonsDrawingResult CreatePolygonsDrawingResult()
		{
			return new PolygonsDrawingResult();
		}

		// Token: 0x06005597 RID: 21911 RVA: 0x00046EEB File Offset: 0x000450EB
		public IDashedMultilineDrawingResult CreateDashedMultilineDrawingResult()
		{
			return new DashedMultilineDrawingResult();
		}

		// Token: 0x06005598 RID: 21912 RVA: 0x00046EF6 File Offset: 0x000450F6
		public IDashedPlanarRectangleDrawingResult CreateDashedPlanarRectangleDrawingResult(bool drawBoundingPolyline)
		{
			return new DashedPlanarRectangleDrawingResult(drawBoundingPolyline);
		}

		// Token: 0x06005599 RID: 21913 RVA: 0x00046F06 File Offset: 0x00045106
		public IPlanarRectangleDrawingResult CreatePlanarRectangleDrawingResult(bool drawBoundingPolyline)
		{
			return new PlanarRectangleDrawingResult(drawBoundingPolyline);
		}

		// Token: 0x0600559A RID: 21914 RVA: 0x00046F16 File Offset: 0x00045116
		public IPlanarCircleDrawingResult CreatePlanarCircleDrawingResult(bool drawBoundingPolyline)
		{
			return new PlanarCircleDrawingResult(drawBoundingPolyline);
		}

		// Token: 0x0600559B RID: 21915 RVA: 0x00046F26 File Offset: 0x00045126
		public IPlanarRegularPolygonDrawingResult CreatePlanarRegularPolygonDrawingResult(bool drawBoundingPolyline)
		{
			return new PlanarRegularPolygonDrawingResult(drawBoundingPolyline);
		}

		// Token: 0x0600559C RID: 21916 RVA: 0x00046F36 File Offset: 0x00045136
		public IPointsDrawingResult CreatePointsDrawingResult()
		{
			return new PointsDrawingResult();
		}

		// Token: 0x0600559D RID: 21917 RVA: 0x00046F41 File Offset: 0x00045141
		public IPolylineDrawingResult CreatePolylineDrawingResult()
		{
			return new PolylineDrawingResult();
		}

		// Token: 0x0600559E RID: 21918 RVA: 0x00046F4C File Offset: 0x0004514C
		public IMultilineDrawingResult CreateMultilineDrawingResult()
		{
			return new MultilineDrawingResult();
		}

		// Token: 0x0600559F RID: 21919 RVA: 0x00046F57 File Offset: 0x00045157
		public IAnnotationDrawingResult CreateAnnotationDrawingResult()
		{
			return new AnnotationDrawingResult();
		}

		// Token: 0x060055A0 RID: 21920 RVA: 0x00046F62 File Offset: 0x00045162
		public ICirclesDrawingResult CreateCirclesDrawingResult()
		{
			return new CirclesDrawingResult();
		}

		// Token: 0x060055A1 RID: 21921 RVA: 0x00046F6D File Offset: 0x0004516D
		public IMeshDrawingResult CreateMeshDrawingResult()
		{
			return new MeshDrawingResult();
		}

		// Token: 0x060055A2 RID: 21922 RVA: 0x00046F78 File Offset: 0x00045178
		public ITextDrawingResult CreateTextDrawingResult()
		{
			return new TextDrawingResult();
		}

		// Token: 0x060055A3 RID: 21923 RVA: 0x00046F83 File Offset: 0x00045183
		public ISphereDrawingResult CreateSphereDrawingResult()
		{
			return new SphereDrawingResult();
		}

		// Token: 0x060055A4 RID: 21924 RVA: 0x00046F8E File Offset: 0x0004518E
		public IPlaneDrawingResult CreatePlaneDrawingResult()
		{
			return new PlaneDrawingResult();
		}

		// Token: 0x060055A5 RID: 21925 RVA: 0x00046F99 File Offset: 0x00045199
		public IArrowDrawingResult CreateArrowDrawingResult()
		{
			return new ArrowDrawingResult();
		}

		// Token: 0x060055A6 RID: 21926 RVA: 0x00046FA4 File Offset: 0x000451A4
		public IMultiPolyLineDrawingResult CreateMulitPolyLineDrawingResult()
		{
			return new MultiPolyLineDrawingResult();
		}

		// Token: 0x060055A7 RID: 21927 RVA: 0x00046FAF File Offset: 0x000451AF
		public IBoxDrawingResult CreateBoxDrawingResult()
		{
			return new BoxDrawingResult();
		}

		// Token: 0x060055A8 RID: 21928 RVA: 0x00046FBA File Offset: 0x000451BA
		public IPlanarRectanglesDrawingResult CreateRectanglesDrawingResult()
		{
			return new PlanarRectanglesDrawingResult();
		}

		// Token: 0x060055A9 RID: 21929 RVA: 0x00046FC5 File Offset: 0x000451C5
		public IHTypeDrawingResult CreateHTypeDrawingResult()
		{
			return new HTypeDrawingResult();
		}

		// Token: 0x060055AA RID: 21930 RVA: 0x00046FD0 File Offset: 0x000451D0
		public IMultiTextDrawingResult CreateMultiTextDrawingResult()
		{
			return new MultiTextDrawingResult();
		}

		// Token: 0x060055AB RID: 21931 RVA: 0x00046FDB File Offset: 0x000451DB
		public IBillboardTextDrawingResult CreateBillboardTextDrawingResult()
		{
			return new BillboardTextDrawingResult();
		}
	}
}
