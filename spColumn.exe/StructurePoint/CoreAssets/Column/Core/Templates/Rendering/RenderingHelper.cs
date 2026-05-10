using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using devDept.Geometry;
using NetTopologySuite.Geometries;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;

namespace StructurePoint.CoreAssets.Column.Core.Templates.Rendering
{
	// Token: 0x02000853 RID: 2131
	internal static class RenderingHelper
	{
		// Token: 0x060043DF RID: 17375 RVA: 0x00139710 File Offset: 0x00137910
		public static Point3D FindClosestShapePoint(CacheItem cacheItem, IList<Point3D> points, Point3D point, EyeshootGeneralLineEquation equation)
		{
			Point3D result = null;
			double? num = null;
			for (int i = 1; i < points.Count; i++)
			{
				Point3D point2 = points[i];
				EyeshootGeneralLineEquation generalLineEquation = new EyeshootGeneralLineEquation(points[i - 1], point2);
				Point2D point2D = equation.Intersection(generalLineEquation);
				if (!(point2D == null))
				{
					double num2 = point2D.DistanceTo(point);
					double num3 = num2;
					double? num4 = num;
					if (((num3 < num4.GetValueOrDefault() & num4 != null) || num == null) && cacheItem.Geometry.Contains(new NetTopologySuite.Geometries.Point(point2D.X, point2D.Y)))
					{
						result = new Point3D(point2D.X, point2D.Y);
						num = new double?(num2);
					}
				}
			}
			return result;
		}

		// Token: 0x060043E0 RID: 17376 RVA: 0x001397D4 File Offset: 0x001379D4
		public static Point3D FindClosestShapePoint(IList<CacheItem> cacheItems, Point3D point, EyeshootGeneralLineEquation equation)
		{
			List<Point3D> list = new List<Point3D>();
			foreach (CacheItem cacheItem in cacheItems)
			{
				foreach (List<Point3D> points in cacheItem.CoverPoints)
				{
					Point3D point3D = RenderingHelper.FindClosestShapePoint(cacheItem, points, point, equation);
					if (point3D != null)
					{
						list.Add(point3D);
					}
				}
			}
			if (!list.Any<Point3D>())
			{
				return null;
			}
			var <>f__AnonymousType = (from item in list
			select new
			{
				Point = item,
				Distance = item.DistanceTo(point)
			} into item
			orderby item.Distance
			select item).FirstOrDefault();
			if (<>f__AnonymousType == null)
			{
				return null;
			}
			return <>f__AnonymousType.Point;
		}

		// Token: 0x060043E1 RID: 17377 RVA: 0x00038C23 File Offset: 0x00036E23
		public static RotateFlipType GetFlipType(float angleDeg)
		{
			if (angleDeg >= 0f && angleDeg <= 90f)
			{
				return RotateFlipType.Rotate180FlipX;
			}
			if (angleDeg > 90f && angleDeg <= 180f)
			{
				return RotateFlipType.RotateNoneFlipX;
			}
			if (angleDeg >= -180f && angleDeg <= -90f)
			{
				return RotateFlipType.RotateNoneFlipX;
			}
			return RotateFlipType.Rotate180FlipX;
		}
	}
}
