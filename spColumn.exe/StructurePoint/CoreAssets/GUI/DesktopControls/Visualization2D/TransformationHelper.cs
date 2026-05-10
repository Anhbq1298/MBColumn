using System;
using System.Collections.Generic;
using System.Linq;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Visualization2D
{
	// Token: 0x020008CE RID: 2254
	internal static class TransformationHelper
	{
		// Token: 0x06004787 RID: 18311 RVA: 0x00141B98 File Offset: 0x0013FD98
		public static IList<IList<Point>> TransformToScreenCoordinates(IList<IList<Point>> points, Size targetSize)
		{
			return (from item in points
			select TransformationHelper.TransformToScreenCoordinates(item, targetSize)).ToList<IList<Point>>();
		}

		// Token: 0x06004788 RID: 18312 RVA: 0x00141BD8 File Offset: 0x0013FDD8
		public static IList<Point> TransformToScreenCoordinates(IList<Point> cartesianCoordinates, Size targetSize)
		{
			double num = targetSize.Width / 2.0;
			double num2 = targetSize.Height / 2.0;
			List<Point> list = new List<Point>();
			foreach (Point point in cartesianCoordinates)
			{
				list.Add(new Point(num + point.X, num2 - point.Y));
			}
			return list;
		}

		// Token: 0x06004789 RID: 18313 RVA: 0x00141C74 File Offset: 0x0013FE74
		public static IList<Point> Translate(IList<Point> points, Vector translationVector)
		{
			return (from item in points
			select new Point(item.X + translationVector.X, item.Y + translationVector.Y)).ToList<Point>();
		}

		// Token: 0x0600478A RID: 18314 RVA: 0x00141CB4 File Offset: 0x0013FEB4
		public static IList<IList<Point>> Translate(IList<IList<Point>> polygons, Vector translationVector)
		{
			return (from item in polygons
			select TransformationHelper.Translate(item, translationVector)).ToList<IList<Point>>();
		}

		// Token: 0x0600478B RID: 18315 RVA: 0x00141CF4 File Offset: 0x0013FEF4
		public static IList<Point> Scale(IList<Point> points, double scale)
		{
			return (from item in points
			select new Point(item.X * scale, item.Y * scale)).ToList<Point>();
		}

		// Token: 0x0600478C RID: 18316 RVA: 0x00141D34 File Offset: 0x0013FF34
		public static IList<IList<Point>> Scale(IList<IList<Point>> polygons, double scale)
		{
			return (from item in polygons
			select TransformationHelper.Scale(item, scale)).ToList<IList<Point>>();
		}

		// Token: 0x0600478D RID: 18317 RVA: 0x0003C5C3 File Offset: 0x0003A7C3
		public static Vector CalculateModelCenterVector(IList<Point> modelPoints)
		{
			return TransformationHelper.CalculateModelCenterVector(new BoundingBoxData(modelPoints));
		}

		// Token: 0x0600478E RID: 18318 RVA: 0x00141D74 File Offset: 0x0013FF74
		public static Vector CalculateModelCenterVector(BoundingBoxData boundingBox)
		{
			Point point = boundingBox.#SBb();
			return Vector.#23d(new Vector(point.X, point.Y));
		}

		// Token: 0x0600478F RID: 18319 RVA: 0x00141DAC File Offset: 0x0013FFAC
		public static double CalculateViewScale(IList<Point> modelPoints, Size targetSize)
		{
			BoundingBoxData boundingBox = new BoundingBoxData(modelPoints);
			return TransformationHelper.CalculateViewScale(targetSize, boundingBox);
		}

		// Token: 0x06004790 RID: 18320 RVA: 0x00141DD4 File Offset: 0x0013FFD4
		public static double CalculateViewScale(Size targetSize, BoundingBoxData boundingBox)
		{
			double num = boundingBox.Width;
			double num2 = boundingBox.Height;
			double val = targetSize.Width / num;
			double val2 = targetSize.Height / num2;
			return Math.Min(val, val2);
		}

		// Token: 0x06004791 RID: 18321 RVA: 0x00141E14 File Offset: 0x00140014
		public static IList<IList<Point>> TranslateAndScale(IList<IList<Point>> polygons, double scale, Vector translationVector)
		{
			return (from item in polygons
			select TransformationHelper.TranslateAndScale(item, scale, translationVector)).ToList<IList<Point>>();
		}

		// Token: 0x06004792 RID: 18322 RVA: 0x0003C5DC File Offset: 0x0003A7DC
		public static IList<Point> TranslateAndScale(IList<Point> points, double scale, Vector translationVector)
		{
			return TransformationHelper.Scale(TransformationHelper.Translate(points, translationVector), scale).ToList<Point>();
		}
	}
}
