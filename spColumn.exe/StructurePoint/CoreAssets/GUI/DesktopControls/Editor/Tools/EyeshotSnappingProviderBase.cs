using System;
using System.Collections.Generic;
using System.Linq;
using devDept.Geometry;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Tools
{
	// Token: 0x0200067C RID: 1660
	public class EyeshotSnappingProviderBase
	{
		// Token: 0x17001149 RID: 4425
		// (get) Token: 0x060037D8 RID: 14296 RVA: 0x000307AE File Offset: 0x0002E9AE
		public static SnappingPointComparer PointComparer { get; } = new SnappingPointComparer();

		// Token: 0x060037D9 RID: 14297 RVA: 0x0010EA08 File Offset: 0x0010CC08
		protected Point3D PerformSnapGridLine(Point2D inputPoint, double spacingX, double spacingY, double maxDistance)
		{
			if (inputPoint == null)
			{
				return null;
			}
			Point3D point3D = new Point3D(spacingX * Math.Round(inputPoint.X / spacingX), spacingY * Math.Round(inputPoint.Y / spacingY));
			double num = Math.Abs(point3D.X - inputPoint.X);
			double num2 = Math.Abs(point3D.Y - inputPoint.Y);
			if (num <= maxDistance && num < num2)
			{
				return new Point3D(point3D.X, inputPoint.Y);
			}
			if (num2 <= maxDistance && num2 < num)
			{
				return new Point3D(inputPoint.X, point3D.Y);
			}
			return null;
		}

		// Token: 0x060037DA RID: 14298 RVA: 0x0010EAA4 File Offset: 0x0010CCA4
		protected Point3D PerformSnap(Point2D inputPoint, double spacingX, double spacingY, double maxDistance)
		{
			if (inputPoint == null)
			{
				return null;
			}
			Point3D point3D = new Point3D(spacingX * Math.Floor(inputPoint.X / spacingX), spacingY * Math.Floor(inputPoint.Y / spacingY));
			List<Point3D> list = new List<Point3D>(4)
			{
				point3D,
				new Point3D(point3D.X, point3D.Y + spacingY),
				new Point3D(point3D.X + spacingX, point3D.Y + spacingY),
				new Point3D(point3D.X + spacingX, point3D.Y)
			};
			list = (from item in list
			orderby item.X, item.Y
			select item).ToList<Point3D>();
			return this.PerformSnap(list, inputPoint, maxDistance);
		}

		// Token: 0x060037DB RID: 14299 RVA: 0x0010EB94 File Offset: 0x0010CD94
		public Point3D PerformSnap(IList<List<Point3D>> lines, Point2D inputPoint, double maxDistance)
		{
			int? num = null;
			List<Point3D> list = null;
			double num2 = 0.0;
			foreach (List<Point3D> list2 in lines)
			{
				for (int i = 1; i < list2.Count; i++)
				{
					Point2D pointA = list2[i - 1];
					Point3D pointB = list2[i];
					double? num3 = EyeshotGeometry.Distance(pointA, pointB, inputPoint);
					double? num4 = num3;
					if (num4.GetValueOrDefault() <= maxDistance & num4 != null)
					{
						if (num != null)
						{
							num4 = num3;
							double num5 = num2;
							if (!(num4.GetValueOrDefault() < num5 & num4 != null))
							{
								goto IL_A4;
							}
						}
						num = new int?(i);
						list = list2;
						num2 = num3.Value;
					}
					IL_A4:;
				}
			}
			if (num == null)
			{
				return null;
			}
			Point3D startPoint = list[num.Value - 1];
			Point3D endPoint = list[num.Value];
			Point2D point2D = EyeshotGeometry.CalculateClosestPointOnSegment(startPoint, endPoint, inputPoint);
			if (!(point2D != null))
			{
				return null;
			}
			return new Point3D(point2D.X, point2D.Y);
		}

		// Token: 0x060037DC RID: 14300 RVA: 0x0010ECD8 File Offset: 0x0010CED8
		public Point3D PerformSnap(IList<SnappingLine> lines, Point2D inputPoint, double maxDistance)
		{
			SnappingLine snappingLine = null;
			double num = 0.0;
			foreach (SnappingLine snappingLine2 in lines)
			{
				double? num2 = EyeshotGeometry.Distance(snappingLine2.StartPoint, snappingLine2.EndPoint, inputPoint);
				double? num3 = num2;
				if (num3.GetValueOrDefault() <= maxDistance & num3 != null)
				{
					if (snappingLine != null)
					{
						num3 = num2;
						double num4 = num;
						if (!(num3.GetValueOrDefault() < num4 & num3 != null))
						{
							continue;
						}
					}
					snappingLine = snappingLine2;
					num = num2.Value;
				}
			}
			if (snappingLine == null)
			{
				return null;
			}
			Point2D point2D = EyeshotGeometry.CalculateClosestPointOnSegment(snappingLine.StartPoint, snappingLine.EndPoint, inputPoint);
			if (!(point2D != null))
			{
				return null;
			}
			return new Point3D(point2D.X, point2D.Y);
		}

		// Token: 0x060037DD RID: 14301 RVA: 0x0010EDBC File Offset: 0x0010CFBC
		public Point3D PerformSnap(List<Point3D> points, Point2D inputPoint, double maxDistance)
		{
			EyeshotSnappingProviderBase.<>c__DisplayClass8_0 CS$<>8__locals1 = new EyeshotSnappingProviderBase.<>c__DisplayClass8_0();
			CS$<>8__locals1.inputPoint = inputPoint;
			CS$<>8__locals1.maxDistance = maxDistance;
			if (CS$<>8__locals1.inputPoint == null)
			{
				return null;
			}
			int num = points.#01d((Point3D item) => EyeshotSnappingProviderBase.MyFindFirstXDistanceMatch(CS$<>8__locals1.inputPoint, item, CS$<>8__locals1.maxDistance));
			if (num < 0)
			{
				return null;
			}
			int num2 = EyeshotSnappingProviderBase.MySpreadSearchFirstNotMatching(new Func<IList<Point3D>, int, bool>(CS$<>8__locals1.<PerformSnap>g__XCoordinateMatch|0), points, points.Count, num, false);
			int num3 = EyeshotSnappingProviderBase.MySpreadSearchFirstNotMatching(new Func<IList<Point3D>, int, bool>(CS$<>8__locals1.<PerformSnap>g__XCoordinateMatch|0), points, points.Count, num, true);
			Point3D[] array = new Point3D[num3 - num2 + 1];
			points.CopyTo(num2, array, 0, array.Length);
			array = (from item in array
			orderby item.Y
			select item).ToArray<Point3D>();
			num = array.#01d((Point3D item) => EyeshotSnappingProviderBase.MyFindFirstYDistanceMatch(CS$<>8__locals1.inputPoint, item, CS$<>8__locals1.maxDistance));
			if (num < 0)
			{
				return null;
			}
			num2 = EyeshotSnappingProviderBase.MySpreadSearchFirstNotMatching(new Func<IList<Point3D>, int, bool>(CS$<>8__locals1.<PerformSnap>g__YCoordinateMatch|1), array, array.Length, num, false);
			num3 = EyeshotSnappingProviderBase.MySpreadSearchFirstNotMatching(new Func<IList<Point3D>, int, bool>(CS$<>8__locals1.<PerformSnap>g__YCoordinateMatch|1), array, array.Length, num, true);
			double num4 = double.MaxValue;
			int num5 = -1;
			num3 = Math.Min(num3, array.Length - 1);
			num2 = Math.Max(0, num2);
			for (int i = num2; i <= num3; i++)
			{
				double num6 = array[i].DistanceTo(CS$<>8__locals1.inputPoint);
				if (num6 < num4)
				{
					num4 = num6;
					num5 = i;
				}
			}
			if (num5 < 0)
			{
				return null;
			}
			return array[num5];
		}

		// Token: 0x060037DE RID: 14302 RVA: 0x0010EF30 File Offset: 0x0010D130
		private static int MyFindFirstXDistanceMatch(Point2D referencePoint, Point3D point, double maxDistance)
		{
			double num = point.X - referencePoint.X;
			if (Math.Abs(num) <= maxDistance)
			{
				return 0;
			}
			if (num <= 0.0)
			{
				return -1;
			}
			return 1;
		}

		// Token: 0x060037DF RID: 14303 RVA: 0x0010EF68 File Offset: 0x0010D168
		private static int MyFindFirstYDistanceMatch(Point2D referencePoint, Point3D point, double maxDistance)
		{
			double num = point.Y - referencePoint.Y;
			if (Math.Abs(num) <= maxDistance)
			{
				return 0;
			}
			if (num <= 0.0)
			{
				return -1;
			}
			return 1;
		}

		// Token: 0x060037E0 RID: 14304 RVA: 0x000307B5 File Offset: 0x0002E9B5
		private static int MyWalkToFirstMatchingPoint(Func<IList<Point3D>, int, bool> matchFunc, IList<Point3D> points, int initialTempIndex, int count, int sign)
		{
			while (initialTempIndex >= 0 && initialTempIndex < count && !matchFunc(points, initialTempIndex))
			{
				initialTempIndex += -sign;
			}
			return initialTempIndex;
		}

		// Token: 0x060037E1 RID: 14305 RVA: 0x0010EFA0 File Offset: 0x0010D1A0
		private static int MySpreadSearchFirstNotMatching(Func<IList<Point3D>, int, bool> matchFunc, IList<Point3D> points, int count, int startIndex, bool ascending)
		{
			int num = ascending ? 1 : -1;
			int num2 = ascending ? (num * Math.Min(10, count - startIndex - 1)) : (num * Math.Min(10, startIndex));
			int num3 = startIndex + num2;
			num3 = EyeshotSnappingProviderBase.MyWalkToFirstMatchingPoint(matchFunc, points, num3, count, num);
			if (num2 > 0)
			{
				startIndex = num3;
				for (;;)
				{
					int num4 = startIndex + num2;
					if (num4 < 0 || num4 >= count || !matchFunc(points, num4))
					{
						break;
					}
					startIndex = num4;
				}
			}
			while (startIndex > 0 && startIndex < count && matchFunc(points, startIndex))
			{
				startIndex += num;
			}
			startIndex = Math.Max(0, startIndex);
			startIndex = Math.Min(count - 1, startIndex);
			if (!matchFunc(points, startIndex))
			{
				startIndex += -num;
			}
			return startIndex;
		}

		// Token: 0x04001768 RID: 5992
		private const int CnstSearchNarrowingStep = 10;
	}
}
