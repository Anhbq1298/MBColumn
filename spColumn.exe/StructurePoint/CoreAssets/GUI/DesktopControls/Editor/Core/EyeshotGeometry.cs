using System;
using System.Collections.Generic;
using #Fmc;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using StructurePoint.CoreAssets.Geometry.Helpers;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core
{
	// Token: 0x02000AFE RID: 2814
	public static class EyeshotGeometry
	{
		// Token: 0x06005BB5 RID: 23477 RVA: 0x0004CC01 File Offset: 0x0004AE01
		public static Point3D CenterPoint(Point3D pointA, Point3D pointB)
		{
			if (pointA == pointB)
			{
				return ((pointA != null) ? pointA.Clone() : null) as Point3D;
			}
			return pointA + (pointB - pointA) * 0.5;
		}

		// Token: 0x06005BB6 RID: 23478 RVA: 0x001702E8 File Offset: 0x0016E4E8
		public static IList<Point3D> GetPointsFromMesh(Mesh mesh)
		{
			List<Point3D> list = new List<Point3D>();
			foreach (IndexTriangle indexTriangle in mesh.Triangles)
			{
				Point3D point3D = mesh.Vertices[indexTriangle.V1];
				list.Add(new Point3D(point3D.X, point3D.Y, point3D.Z));
				Point3D point3D2 = mesh.Vertices[indexTriangle.V2];
				list.Add(new Point3D(point3D2.X, point3D2.Y, point3D2.Z));
				Point3D point3D3 = mesh.Vertices[indexTriangle.V3];
				list.Add(new Point3D(point3D3.X, point3D3.Y, point3D3.Z));
			}
			return list;
		}

		// Token: 0x06005BB7 RID: 23479 RVA: 0x0004CC39 File Offset: 0x0004AE39
		public static bool VerifyPolygonNormal(IList<Point2D> polygonPoints)
		{
			return Math.Sign(EyeshotGeometry.CalculateNormal(polygonPoints).Z) == -1;
		}

		// Token: 0x06005BB8 RID: 23480 RVA: 0x0004CC4E File Offset: 0x0004AE4E
		public static bool VerifyPolygonNormal(IList<Point3D> polygonPoints)
		{
			return Math.Sign(EyeshotGeometry.CalculateNormal(polygonPoints).Z) == -1;
		}

		// Token: 0x06005BB9 RID: 23481 RVA: 0x001703A8 File Offset: 0x0016E5A8
		public static Vector3D CalculateNormal(IList<Point3D> polygonPoints)
		{
			Vector3D vector3D = new Vector3D(0.0, 0.0, 0.0);
			int count = polygonPoints.Count;
			for (int i = 0; i < count; i++)
			{
				Point3D point3D = polygonPoints[i];
				Point3D point3D2 = polygonPoints[(i + 1) % count];
				vector3D.X += (point3D.Y - point3D2.Y) * (point3D.Z + point3D2.Z);
				vector3D.Y += (point3D.Z - point3D2.Z) * (point3D.X + point3D2.X);
				vector3D.Z += (point3D.X - point3D2.X) * (point3D.Y + point3D2.Y);
			}
			vector3D.Normalize();
			return vector3D;
		}

		// Token: 0x06005BBA RID: 23482 RVA: 0x0017048C File Offset: 0x0016E68C
		public static Vector3D CalculateNormal(IList<Point2D> polygonPoints)
		{
			Vector3D vector3D = new Vector3D(0.0, 0.0, 0.0);
			int count = polygonPoints.Count;
			for (int i = 0; i < count; i++)
			{
				Point2D point2D = polygonPoints[i];
				Point2D point2D2 = polygonPoints[(i + 1) % count];
				vector3D.Z += (point2D.X - point2D2.X) * (point2D.Y + point2D2.Y);
			}
			vector3D.Normalize();
			return vector3D;
		}

		// Token: 0x06005BBB RID: 23483 RVA: 0x00170518 File Offset: 0x0016E718
		public static Point2D CalculateClosestPointOnLine(Point2D start, Point2D end, Point2D point)
		{
			EyeshootGeneralLineEquation eyeshootGeneralLineEquation = new EyeshootGeneralLineEquation(start, end);
			EyeshootGeneralLineEquation generalLineEquation = eyeshootGeneralLineEquation.Normal(point);
			return eyeshootGeneralLineEquation.Intersection(generalLineEquation);
		}

		// Token: 0x06005BBC RID: 23484 RVA: 0x0017053C File Offset: 0x0016E73C
		public static Point2D CalculateClosestPointOnSegment(Point3D startPoint, Point3D endPoint, Point2D point)
		{
			double? num = EyeshotGeometry.Distance(startPoint, endPoint, point);
			if (num == null)
			{
				return null;
			}
			Point2D point2D = EyeshotGeometry.CalculateClosestPointOnLine(startPoint, endPoint, point);
			if (point2D == null)
			{
				return null;
			}
			if (#Emc.#Amc(point.DistanceTo(point2D), num.Value))
			{
				return point2D;
			}
			if (!#Emc.#Amc(startPoint.DistanceTo(point), num.Value))
			{
				return endPoint;
			}
			return startPoint;
		}

		// Token: 0x06005BBD RID: 23485 RVA: 0x0004CC63 File Offset: 0x0004AE63
		public static double DotProduct(Point2D pointA, Point2D pointB)
		{
			return pointA.X * pointB.X + pointA.Y * pointB.Y;
		}

		// Token: 0x06005BBE RID: 23486 RVA: 0x0004CC80 File Offset: 0x0004AE80
		public static double CrossProduct(Point2D pointA, Point2D pointB)
		{
			return pointA.X * pointB.Y - pointA.Y * pointB.X;
		}

		// Token: 0x06005BBF RID: 23487 RVA: 0x001705A0 File Offset: 0x0016E7A0
		public static double? Distance(Point2D pointA, Point2D pointB, Point2D pointC)
		{
			double num = Math.Sqrt(EyeshotGeometry.DotProduct(pointB - pointA, pointB - pointA));
			if (double.IsNaN(num) || #Emc.#U3(num))
			{
				return null;
			}
			double value = EyeshotGeometry.CrossProduct(pointB - pointA, pointC - pointA) / num;
			if (EyeshotGeometry.DotProduct(pointC - pointB, pointB - pointA) > 0.0)
			{
				return new double?(Math.Sqrt(EyeshotGeometry.DotProduct(pointB - pointC, pointB - pointC)));
			}
			if (EyeshotGeometry.DotProduct(pointC - pointA, pointA - pointB) > 0.0)
			{
				return new double?(Math.Sqrt(EyeshotGeometry.DotProduct(pointA - pointC, pointA - pointC)));
			}
			return new double?(Math.Abs(value));
		}

		// Token: 0x06005BC0 RID: 23488 RVA: 0x0017067C File Offset: 0x0016E87C
		public static bool IsInsideOrOnEdge(IList<Point3D> convexPolygonPoints, Point2D point)
		{
			if (convexPolygonPoints.Count <= 3)
			{
				return false;
			}
			int? num = null;
			for (int i = 1; i < convexPolygonPoints.Count; i++)
			{
				Point3D point3D = convexPolygonPoints[i - 1];
				Point3D point3D2 = convexPolygonPoints[i];
				double num2 = point3D.X - point.X;
				double num3 = point3D.Y - point.Y;
				double num4 = point3D2.X - point.X;
				double num5 = point3D2.Y - point.Y;
				int num6 = Math.Sign(num2 * num5 - num3 * num4);
				if (num == null && num6 != 0)
				{
					num = new int?(num6);
				}
				else if (num6 != 0)
				{
					int? num7 = num;
					int num8 = num6;
					if (!(num7.GetValueOrDefault() == num8 & num7 != null))
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x06005BC1 RID: 23489 RVA: 0x0017074C File Offset: 0x0016E94C
		public static bool CheckIfPointIsInPolygon(IList<Point3D> points, int pointsCount, Point2D point)
		{
			bool flag = false;
			double x = point.X;
			double y = point.Y;
			int i = 0;
			int index = pointsCount - 1;
			while (i < pointsCount)
			{
				Point3D point3D = points[i];
				Point3D point3D2 = points[index];
				if (point3D.Y > y != point3D2.Y > y && x < (point3D2.X - point3D.X) * (y - point3D.Y) / (point3D2.Y - point3D.Y) + point3D.X)
				{
					flag = !flag;
				}
				index = i++;
			}
			return flag;
		}

		// Token: 0x06005BC2 RID: 23490 RVA: 0x001707E0 File Offset: 0x0016E9E0
		public static bool CheckIfPointIsOnEdge(IList<Point3D> points, Point2D point)
		{
			Point3D startPoint = points[0];
			for (int i = 1; i < points.Count; i++)
			{
				Point3D point3D = points[i];
				if (EyeshotGeometry.DoesLieOnSegment(startPoint, point3D, point, false))
				{
					return true;
				}
				startPoint = point3D;
			}
			return false;
		}

		// Token: 0x06005BC3 RID: 23491 RVA: 0x00170820 File Offset: 0x0016EA20
		public static double Area(double point1X, double point1Y, double point2X, double point2Y, double point3X, double point3Y)
		{
			double num = (point1X - point3X) * (point2Y - point3Y);
			double num2 = (point1Y - point3Y) * (point2X - point3X);
			return (num - num2) / 2.0;
		}

		// Token: 0x06005BC4 RID: 23492 RVA: 0x0017084C File Offset: 0x0016EA4C
		public static bool DoesLieOnSegment(Point2D startPoint, Point2D endPoint, Point2D point, bool roughComparison)
		{
			double x = startPoint.X;
			double y = startPoint.Y;
			double x2 = endPoint.X;
			double y2 = endPoint.Y;
			double x3 = point.X;
			double y3 = point.Y;
			double #f = EyeshotGeometry.Area(x, y, x3, y3, x2, y2);
			if (!(roughComparison ? #Emc.#Bmc(#f) : #Emc.#U3(#f)))
			{
				return false;
			}
			double num = (x3 - x) * (x2 - x) + (y3 - y) * (y2 - y);
			if (num < 0.0 && !#Emc.#Bmc(num))
			{
				return false;
			}
			double num2 = (x2 - x) * (x2 - x) + (y2 - y) * (y2 - y);
			return num <= num2 || #Emc.#Amc(num, num2);
		}

		// Token: 0x06005BC5 RID: 23493 RVA: 0x001708FC File Offset: 0x0016EAFC
		public static bool IsConvexPolygon(IList<Point3D> points)
		{
			if (points.Count < 3)
			{
				return false;
			}
			int? num = null;
			for (int i = 0; i < points.Count - 2; i++)
			{
				double num2 = points[i + 1].X - points[i].X;
				double num3 = points[i + 1].Y - points[i].Y;
				double num4 = points[i + 2].X - points[i].X;
				double num5 = points[i + 2].Y - points[i].Y;
				int num6 = Math.Sign(num2 * num5 - num3 * num4);
				if (num == null)
				{
					num = new int?(num6);
				}
				else if (num6 != 0)
				{
					int? num7 = num;
					int num8 = num6;
					if (!(num7.GetValueOrDefault() == num8 & num7 != null))
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x06005BC6 RID: 23494 RVA: 0x001709EC File Offset: 0x0016EBEC
		public static void Translate(IList<Point2D> points, double x, double y)
		{
			foreach (Point2D point2D in points)
			{
				point2D.X += x;
				point2D.Y += y;
			}
		}

		// Token: 0x06005BC7 RID: 23495 RVA: 0x00170A48 File Offset: 0x0016EC48
		public static void Translate3D(IList<Point3D> points, double x, double y, double z)
		{
			foreach (Point3D point3D in points)
			{
				point3D.X += x;
				point3D.Y += y;
				point3D.Z += z;
			}
		}

		// Token: 0x06005BC8 RID: 23496 RVA: 0x00170AB4 File Offset: 0x0016ECB4
		public static void Rotate(IList<Point3D> points, Vector3D axis, double angleInDegrees)
		{
			angleInDegrees = GeometryHelper.#Qmc(angleInDegrees);
			double num = Math.Cos(angleInDegrees);
			double num2 = Math.Sin(angleInDegrees);
			double x = axis.X;
			double y = axis.Y;
			double z = axis.Z;
			foreach (Point3D point3D in points)
			{
				double x2 = point3D.X;
				double y2 = point3D.Y;
				double z2 = point3D.Z;
				double x3 = x * (x * x2 + y * y2 + z * z2) * (1.0 - num) + x2 * num + (-z * y2 + y * z2) * num2;
				double y3 = y * (x * x2 + y * y2 + z * z2) * (1.0 - num) + y2 * num + (z * x2 - x * z2) * num2;
				double z3 = z * (x * x2 + y * y2 + z * z2) * (1.0 - num) + z2 * num + (-y * x2 + x * y2) * num2;
				point3D.X = x3;
				point3D.Y = y3;
				point3D.Z = z3;
			}
		}

		// Token: 0x06005BC9 RID: 23497 RVA: 0x00170BF0 File Offset: 0x0016EDF0
		public static void RotateZ(IList<Point2D> points, Point3D basePint, double angleInDegrees)
		{
			double x = basePint.X;
			double y = basePint.Y;
			angleInDegrees = GeometryHelper.#Qmc(angleInDegrees);
			foreach (Point2D point2D in points)
			{
				double x2 = point2D.X;
				double y2 = point2D.Y;
				point2D.X = (x2 - x) * Math.Cos(angleInDegrees) - (y2 - y) * Math.Sin(angleInDegrees) + x;
				point2D.Y = (x2 - x) * Math.Sin(angleInDegrees) + (y2 - y) * Math.Cos(angleInDegrees) + y;
			}
		}

		// Token: 0x06005BCA RID: 23498 RVA: 0x00170C90 File Offset: 0x0016EE90
		public static Point2D Intersection(Point2D startPoint1, Point2D endPoint1, Point2D startPoint2, Point2D endPoint2, bool roughComparison)
		{
			double num = startPoint1.Y - startPoint2.Y;
			double num2 = endPoint2.X - startPoint2.X;
			double num3 = startPoint1.X - startPoint2.X;
			double num4 = endPoint2.Y - startPoint2.Y;
			double num5 = endPoint1.X - startPoint1.X;
			double num6 = endPoint1.Y - startPoint1.Y;
			double num7 = num5 * num4 - num6 * num2;
			double num8 = num * num2 - num3 * num4;
			if (#Emc.#Bmc(num7) && #Emc.#Bmc(num8))
			{
				return EyeshotGeometry.IntersectionTouch(startPoint1, startPoint2, endPoint1, endPoint2, roughComparison);
			}
			double num9 = num8 / num7;
			if (num9 < -#Emc.#d || num9 > 1.0 + #Emc.#d)
			{
				return null;
			}
			double num10 = (num * num5 - num3 * num6) / num7;
			if (num10 < -#Emc.#d || num10 > 1.0 + #Emc.#d)
			{
				return null;
			}
			Point2D point2D = new Point2D(startPoint1.X + num9 * num5, startPoint1.Y + num9 * num6);
			if (EyeshotGeometry.DoesLieOnSegment(startPoint1, endPoint1, point2D, roughComparison) && EyeshotGeometry.DoesLieOnSegment(startPoint2, endPoint2, point2D, roughComparison))
			{
				return point2D;
			}
			return null;
		}

		// Token: 0x06005BCB RID: 23499 RVA: 0x0004CC9D File Offset: 0x0004AE9D
		public static Point2D IntersectionTouch(Point2D startPoint1, Point2D endPoint1, Point2D startPoint2, Point2D endPoint2, bool rough)
		{
			if (EyeshotGeometry.DoesLieOnSegment(startPoint1, endPoint1, startPoint2, rough))
			{
				return startPoint2;
			}
			if (EyeshotGeometry.DoesLieOnSegment(startPoint1, endPoint1, endPoint2, rough))
			{
				return endPoint2;
			}
			if (EyeshotGeometry.DoesLieOnSegment(startPoint2, endPoint2, startPoint1, rough))
			{
				return startPoint1;
			}
			if (EyeshotGeometry.DoesLieOnSegment(startPoint2, endPoint2, endPoint1, rough))
			{
				return endPoint1;
			}
			return null;
		}

		// Token: 0x06005BCC RID: 23500 RVA: 0x0004CCD8 File Offset: 0x0004AED8
		public static Point3D ConstructPointDegree(Point2D center, double radius, double angle)
		{
			return EyeshotGeometry.ConstructPointRadian(center, radius, GeometryHelper.#Qmc(angle));
		}

		// Token: 0x06005BCD RID: 23501 RVA: 0x00170DB8 File Offset: 0x0016EFB8
		public static Point3D ConstructPointRadian(Point2D center, double radius, double angle)
		{
			double x = center.X;
			double y = center.Y;
			double x2 = x + radius * Math.Cos(angle);
			double y2 = y + radius * Math.Sin(angle);
			return new Point3D(x2, y2);
		}

		// Token: 0x06005BCE RID: 23502 RVA: 0x00170DEC File Offset: 0x0016EFEC
		public static Point3D PointOnSide(Point3D start, Point3D end, bool left)
		{
			Vector3D vector3D = Vector3D.Subtract(end, start);
			Vector3D vector3D2 = left ? vector3D.PerpendicularCounterClockwise() : vector3D.PerpendicularClockwise();
			vector3D2.Normalize();
			double s = vector3D.Length / 2.0;
			return start + vector3D * 0.5 + vector3D2 * s;
		}
	}
}
