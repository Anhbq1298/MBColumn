using System;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x02000A2F RID: 2607
	internal static class DrawingResultsExtensions
	{
		// Token: 0x0600567B RID: 22139 RVA: 0x00047ADC File Offset: 0x00045CDC
		internal static PolygonsDrawingResult Cast(this IPolygonsDrawingResult polygonsDrawingResult)
		{
			return (PolygonsDrawingResult)polygonsDrawingResult;
		}

		// Token: 0x0600567C RID: 22140 RVA: 0x00047AE8 File Offset: 0x00045CE8
		internal static PolylineDrawingResult Cast(this IPolylineDrawingResult polylineDrawingResult)
		{
			return (PolylineDrawingResult)polylineDrawingResult;
		}

		// Token: 0x0600567D RID: 22141 RVA: 0x00047AF4 File Offset: 0x00045CF4
		internal static MultilineDrawingResult Cast(this IMultilineDrawingResult multilineDrawingResult)
		{
			return (MultilineDrawingResult)multilineDrawingResult;
		}

		// Token: 0x0600567E RID: 22142 RVA: 0x00047B00 File Offset: 0x00045D00
		internal static PointsDrawingResult Cast(this IPointsDrawingResult pointsDrawingResult)
		{
			return (PointsDrawingResult)pointsDrawingResult;
		}

		// Token: 0x0600567F RID: 22143 RVA: 0x00047B0C File Offset: 0x00045D0C
		internal static PlanarCircleDrawingResult Cast(this IPlanarCircleDrawingResult planarCircleDrawingResult)
		{
			return (PlanarCircleDrawingResult)planarCircleDrawingResult;
		}

		// Token: 0x06005680 RID: 22144 RVA: 0x00047B18 File Offset: 0x00045D18
		internal static PlanarRectangleDrawingResult Cast(this IPlanarRectangleDrawingResult planarRectangleDrawingResult)
		{
			return (PlanarRectangleDrawingResult)planarRectangleDrawingResult;
		}

		// Token: 0x06005681 RID: 22145 RVA: 0x00047B24 File Offset: 0x00045D24
		internal static DashedMultilineDrawingResult Cast(this IDashedMultilineDrawingResult dashedMultilineDrawingResult)
		{
			return (DashedMultilineDrawingResult)dashedMultilineDrawingResult;
		}

		// Token: 0x06005682 RID: 22146 RVA: 0x00047B30 File Offset: 0x00045D30
		internal static DashedPlanarRectangleDrawingResult Cast(this IDashedPlanarRectangleDrawingResult dashedPlanarRectangleDrawingResult)
		{
			return (DashedPlanarRectangleDrawingResult)dashedPlanarRectangleDrawingResult;
		}

		// Token: 0x06005683 RID: 22147 RVA: 0x00047B3C File Offset: 0x00045D3C
		internal static CrossIndicatorDrawingResult Cast(this ICrossIndicatorDrawingResult crossIndicatorDrawingResult)
		{
			return (CrossIndicatorDrawingResult)crossIndicatorDrawingResult;
		}

		// Token: 0x06005684 RID: 22148 RVA: 0x00047B48 File Offset: 0x00045D48
		internal static AnnotationDrawingResult Cast(this IAnnotationDrawingResult annotationDrawingResult)
		{
			return (AnnotationDrawingResult)annotationDrawingResult;
		}

		// Token: 0x06005685 RID: 22149 RVA: 0x00047B54 File Offset: 0x00045D54
		internal static CirclesDrawingResult Cast(this ICirclesDrawingResult circlesDrawingResult)
		{
			return (CirclesDrawingResult)circlesDrawingResult;
		}

		// Token: 0x06005686 RID: 22150 RVA: 0x00047B60 File Offset: 0x00045D60
		internal static MeshDrawingResult Cast(this IMeshDrawingResult meshDrawingResult)
		{
			return (MeshDrawingResult)meshDrawingResult;
		}

		// Token: 0x06005687 RID: 22151 RVA: 0x00047B6C File Offset: 0x00045D6C
		internal static SphereDrawingResult Cast(this ISphereDrawingResult sphereDrawingResult)
		{
			return (SphereDrawingResult)sphereDrawingResult;
		}

		// Token: 0x06005688 RID: 22152 RVA: 0x00047B78 File Offset: 0x00045D78
		internal static BoxDrawingResult Cast(this IBoxDrawingResult boxDrawingResult)
		{
			return (BoxDrawingResult)boxDrawingResult;
		}

		// Token: 0x06005689 RID: 22153 RVA: 0x00047B84 File Offset: 0x00045D84
		internal static TextDrawingResult Cast(this ITextDrawingResult textDrawingResult)
		{
			return (TextDrawingResult)textDrawingResult;
		}

		// Token: 0x0600568A RID: 22154 RVA: 0x00047B90 File Offset: 0x00045D90
		internal static PlaneDrawingResult Cast(this IPlaneDrawingResult planeDrawingResult)
		{
			return (PlaneDrawingResult)planeDrawingResult;
		}

		// Token: 0x0600568B RID: 22155 RVA: 0x00047B9C File Offset: 0x00045D9C
		internal static ArrowDrawingResult Cast(this IArrowDrawingResult arrowDrawingResult)
		{
			return (ArrowDrawingResult)arrowDrawingResult;
		}

		// Token: 0x0600568C RID: 22156 RVA: 0x00047BA8 File Offset: 0x00045DA8
		internal static MultiPolyLineDrawingResult Cast(this IMultiPolyLineDrawingResult multiPolyLineDrawingResult)
		{
			return (MultiPolyLineDrawingResult)multiPolyLineDrawingResult;
		}
	}
}
