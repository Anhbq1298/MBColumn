using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Media;
using #7hc;
using devDept.Geometry;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core
{
	// Token: 0x02000B16 RID: 2838
	public static class EyeshotHelper
	{
		// Token: 0x06005CFB RID: 23803 RVA: 0x0004D894 File Offset: 0x0004BA94
		public static Vector3D ToVector3D(this Vector2D vector)
		{
			return new Vector3D(vector.X, vector.Y);
		}

		// Token: 0x06005CFC RID: 23804 RVA: 0x0004D8A7 File Offset: 0x0004BAA7
		public static Vector2D PerpendicularClockwise(this Vector2D vector2)
		{
			return new Vector2D(vector2.Y, -vector2.X);
		}

		// Token: 0x06005CFD RID: 23805 RVA: 0x0004D8BB File Offset: 0x0004BABB
		public static Vector2D PerpendicularCounterClockwise(this Vector2D vector2)
		{
			return new Vector2D(-vector2.Y, vector2.X);
		}

		// Token: 0x06005CFE RID: 23806 RVA: 0x0004D8CF File Offset: 0x0004BACF
		public static Vector3D PerpendicularClockwise(this Vector3D vector2)
		{
			return new Vector3D(vector2.Y, -vector2.X);
		}

		// Token: 0x06005CFF RID: 23807 RVA: 0x0004D8E3 File Offset: 0x0004BAE3
		public static Vector3D PerpendicularCounterClockwise(this Vector3D vector2)
		{
			return new Vector3D(-vector2.Y, vector2.X);
		}

		// Token: 0x06005D00 RID: 23808 RVA: 0x00174F30 File Offset: 0x00173130
		public static IList<Point3D> Clone(this ICollection<Point3D> collection)
		{
			if (collection == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107420761));
			}
			List<Point3D> list = new List<Point3D>(collection.Count);
			list.AddRange(from item in collection
			select (Point3D)item.Clone());
			return list;
		}

		// Token: 0x06005D01 RID: 23809 RVA: 0x0004D8F7 File Offset: 0x0004BAF7
		public static System.Drawing.Color Convert(this System.Windows.Media.Color color)
		{
			return System.Drawing.Color.FromArgb((int)color.A, (int)color.R, (int)color.G, (int)color.B);
		}

		// Token: 0x06005D02 RID: 23810 RVA: 0x00174F88 File Offset: 0x00173188
		public static Point3D PointInMiddle(Point3D point1, Point3D point2)
		{
			Vector3D b = Vector3D.Subtract(point1, point2) / 2.0;
			return point2 + b;
		}

		// Token: 0x06005D03 RID: 23811 RVA: 0x0004D91A File Offset: 0x0004BB1A
		public static double RadianToDegree(double radians)
		{
			return radians * 180.0 / 3.141592653589793;
		}

		// Token: 0x06005D04 RID: 23812 RVA: 0x0004D931 File Offset: 0x0004BB31
		public static double DegreeToRadian(double degrees)
		{
			return degrees * 3.141592653589793 / 180.0;
		}

		// Token: 0x06005D05 RID: 23813 RVA: 0x00174FB4 File Offset: 0x001731B4
		public static Vector3D Perpendicular(Vector3D vector)
		{
			((Vector3D)vector.Clone()).Normalize();
			if (vector.Z >= vector.X)
			{
				return new Vector3D(0.0, -vector.Z, vector.Y);
			}
			return new Vector3D(vector.Y, -vector.X, 0.0);
		}

		// Token: 0x06005D06 RID: 23814 RVA: 0x00175018 File Offset: 0x00173218
		public static Point3D PointInDirection(Point3D from, Point3D to, double distance)
		{
			Vector3D vector3D = Vector3D.Subtract(to, from);
			vector3D.Normalize();
			vector3D *= distance;
			return to + vector3D;
		}

		// Token: 0x06005D07 RID: 23815 RVA: 0x00175044 File Offset: 0x00173244
		public static Point3D Rotate(Point3D point, Point3D relativePoint, double angleInDegrees)
		{
			double x = point.X;
			double y = point.Y;
			double x2 = relativePoint.X;
			double y2 = relativePoint.Y;
			double num = EyeshotHelper.DegreeToRadian(angleInDegrees);
			point.X = (x - x2) * Math.Cos(num) - (y - y2) * Math.Sin(num) + x2;
			point.Y = (x - x2) * Math.Sin(num) + (y - y2) * Math.Cos(num) + y2;
			point.Z = point.Z;
			return point;
		}

		// Token: 0x06005D08 RID: 23816 RVA: 0x00170DB8 File Offset: 0x0016EFB8
		public static Point3D ConstructPointRadian(Point3D center, double radius, double angle)
		{
			double x = center.X;
			double y = center.Y;
			double x2 = x + radius * Math.Cos(angle);
			double y2 = y + radius * Math.Sin(angle);
			return new Point3D(x2, y2);
		}

		// Token: 0x06005D09 RID: 23817 RVA: 0x0004D948 File Offset: 0x0004BB48
		public static Point3D ConstructPointDegree(Point3D center, double radius, double angle)
		{
			return EyeshotHelper.ConstructPointRadian(center, radius, EyeshotHelper.DegreeToRadian(angle));
		}

		// Token: 0x06005D0A RID: 23818 RVA: 0x001750C0 File Offset: 0x001732C0
		public static List<Point3D> GeneratePointsOnArcAtAngles(Point3D center, float radius, List<float> anglesInDegrees)
		{
			List<Point3D> list = new List<Point3D>();
			foreach (float num in anglesInDegrees)
			{
				Point3D item = EyeshotHelper.ConstructPointDegree(center, (double)radius, (double)num);
				list.Add(item);
			}
			return list;
		}

		// Token: 0x06005D0B RID: 23819 RVA: 0x00175120 File Offset: 0x00173320
		public static List<Point3D> ConstructArc(Point3D center, float radius, float degFrom, float degTo, int fullCircleNumberOfPoints, CircleDirection direction)
		{
			if (direction == CircleDirection.Clockwise)
			{
				float num = degTo;
				degTo = degFrom;
				degFrom = num;
			}
			if (degFrom > degTo)
			{
				degTo += 360f;
			}
			int num2 = (int)((double)Math.Abs(degTo - degFrom) / 360.0 * (double)fullCircleNumberOfPoints);
			num2 = Math.Max(4, num2);
			List<float> list = new List<float>();
			int num3 = num2 - 2;
			float num4 = (degTo - degFrom) / (float)num3;
			for (int i = 0; i <= num3; i++)
			{
				float item = degFrom + (float)i * num4;
				list.Add(item);
			}
			List<Point3D> collection = EyeshotHelper.GeneratePointsOnArcAtAngles(center, radius, list);
			List<Point3D> list2 = new List<Point3D>();
			list2.Add(center);
			list2.AddRange(collection);
			list2.Add(center);
			return list2;
		}

		// Token: 0x06005D0C RID: 23820 RVA: 0x001751C0 File Offset: 0x001733C0
		public static List<Point2D> ConstructRegularPolygon2D(Point2D center, double radius, int numberOfSides, double angleDelta, bool addFirstPointTwice)
		{
			List<Point2D> list = new List<Point2D>();
			double num = 6.283185307179586 / (double)numberOfSides;
			double x = center.X;
			double y = center.Y;
			for (int i = numberOfSides - 1; i >= 0; i--)
			{
				double x2 = x + radius * Math.Cos((double)i * num + angleDelta);
				double y2 = y + radius * Math.Sin((double)i * num + angleDelta);
				list.Add(new Point2D(x2, y2));
			}
			if (addFirstPointTwice)
			{
				list.Add(list[0]);
			}
			return list;
		}

		// Token: 0x06005D0D RID: 23821 RVA: 0x00175248 File Offset: 0x00173448
		public static List<Point3D> ConstructRegularPolygon(Point3D center, double radius, int numberOfSides, double angleDelta, bool addFirstPointTwice)
		{
			List<Point3D> list = new List<Point3D>();
			double num = 6.283185307179586 / (double)numberOfSides;
			double x = center.X;
			double y = center.Y;
			for (int i = numberOfSides - 1; i >= 0; i--)
			{
				double x2 = x + radius * Math.Cos((double)i * num + angleDelta);
				double y2 = y + radius * Math.Sin((double)i * num + angleDelta);
				list.Add(new Point3D(x2, y2, center.Z));
			}
			if (addFirstPointTwice)
			{
				list.Add(new Point3D(list[0].X, list[0].Y));
			}
			return list;
		}

		// Token: 0x06005D0E RID: 23822 RVA: 0x001752EC File Offset: 0x001734EC
		public static bool AreEqual(IList<Point3D> points1, IList<Point3D> points2)
		{
			if (points1 == null && points2 == null)
			{
				return true;
			}
			if (points1 == null || points2 == null)
			{
				return false;
			}
			if (points1.Count != points2.Count)
			{
				return false;
			}
			for (int i = 0; i < points1.Count; i++)
			{
				Point3D point3D = points1[i];
				Point3D point3D2 = points2[i];
				if (point3D.X != point3D2.X || point3D.Y != point3D2.Y || point3D.Z != point3D2.Z)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x040026C0 RID: 9920
		private const int MinimumArcPoints = 4;
	}
}
