using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Visualization2D
{
	// Token: 0x020008CC RID: 2252
	internal static class PathGeometryHelper
	{
		// Token: 0x06004780 RID: 18304 RVA: 0x0014188C File Offset: 0x0013FA8C
		public static PathGeometry CreateGeometry(IList<IList<Point>> polygonsPoints)
		{
			#X0d.#V0d(polygonsPoints, #Phc.#3hc(107452758), Component.DesktopControls, #Phc.#3hc(107452705));
			PathGeometry pathGeometry = new PathGeometry();
			pathGeometry.Figures.Add(PathGeometryHelper.CreatePolygonFigure(polygonsPoints[0]));
			for (int i = 1; i < polygonsPoints.Count; i++)
			{
				pathGeometry.Figures.Add(PathGeometryHelper.CreatePolygonFigure(polygonsPoints[i]));
			}
			return pathGeometry;
		}

		// Token: 0x06004781 RID: 18305 RVA: 0x00141908 File Offset: 0x0013FB08
		public static PathFigure CreatePolygonFigure(IList<Point> polygonPoints)
		{
			#X0d.#V0d(polygonPoints, #Phc.#3hc(107452140), Component.DesktopControls, #Phc.#3hc(107452151));
			PathFigure pathFigure = new PathFigure
			{
				StartPoint = polygonPoints[0]
			};
			for (int i = 1; i < polygonPoints.Count; i++)
			{
				LineSegment value = new LineSegment
				{
					Point = polygonPoints[i]
				};
				pathFigure.Segments.Add(value);
			}
			return pathFigure;
		}

		// Token: 0x06004782 RID: 18306 RVA: 0x00141980 File Offset: 0x0013FB80
		internal static void DrawPolyline(DrawingContext context, IList<Point> points, Pen pen)
		{
			#X0d.#V0d(context, #Phc.#3hc(107400797), Component.DesktopControls, #Phc.#3hc(107452066));
			#X0d.#V0d(points, #Phc.#3hc(107358670), Component.DesktopControls, #Phc.#3hc(107452013));
			for (int i = 1; i < points.Count; i++)
			{
				context.DrawLine(pen, points[i - 1], points[i]);
			}
		}
	}
}
