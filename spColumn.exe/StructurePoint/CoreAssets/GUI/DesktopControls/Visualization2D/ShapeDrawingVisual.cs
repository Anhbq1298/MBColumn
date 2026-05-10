using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using StructurePoint.CoreAssets.Geometry.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Visualization2D
{
	// Token: 0x020008CD RID: 2253
	internal sealed class ShapeDrawingVisual : DrawingVisual
	{
		// Token: 0x06004783 RID: 18307 RVA: 0x001419F8 File Offset: 0x0013FBF8
		public void RenderPolygon(IList<IList<Point>> polygonPoints, Brush borderBrush, double borderThickness, Brush fill)
		{
			if (polygonPoints == null || !polygonPoints.Any<IList<Point>>())
			{
				return;
			}
			Pen pen = new Pen(borderBrush, borderThickness);
			pen.Freeze();
			using (DrawingContext drawingContext = base.RenderOpen())
			{
				for (int i = 0; i < polygonPoints.Count; i++)
				{
					PathGeometryHelper.DrawPolyline(drawingContext, polygonPoints[i], pen);
				}
				drawingContext.DrawGeometry(fill, null, PathGeometryHelper.CreateGeometry(polygonPoints));
			}
		}

		// Token: 0x06004784 RID: 18308 RVA: 0x00141A7C File Offset: 0x0013FC7C
		public void RenderCircles(IList<Point> centerPoints, double radius, Brush fill)
		{
			if (centerPoints == null || !centerPoints.Any<Point>())
			{
				return;
			}
			using (DrawingContext drawingContext = base.RenderOpen())
			{
				foreach (Point center in centerPoints)
				{
					drawingContext.DrawEllipse(fill, null, center, radius, radius);
				}
			}
		}

		// Token: 0x06004785 RID: 18309 RVA: 0x00141B00 File Offset: 0x0013FD00
		public void RenderCircles(IList<CircleData> centerPoints, Brush fill)
		{
			if (centerPoints == null || !centerPoints.Any<CircleData>())
			{
				return;
			}
			using (DrawingContext drawingContext = base.RenderOpen())
			{
				foreach (CircleData circleData in centerPoints)
				{
					drawingContext.DrawEllipse(fill, null, circleData.Center.Convert(), circleData.Radius, circleData.Radius);
				}
			}
		}
	}
}
