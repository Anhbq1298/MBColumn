using System;
using System.Collections.Generic;
using System.Linq;
using netDxf;
using netDxf.Entities;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace StructurePoint.CoreAssets.DataExchange.DXF
{
	// Token: 0x0200078F RID: 1935
	[CLSCompliant(false)]
	public static class DXFPolylineHelper
	{
		// Token: 0x06003E38 RID: 15928 RVA: 0x0011FF68 File Offset: 0x0011E168
		public static List<StructurePoint.CoreAssets.Infrastructure.Data.Point> #S1h(Polyline2D #tAc, Func<double, int> #T1h)
		{
			List<StructurePoint.CoreAssets.Infrastructure.Data.Point> list = new List<StructurePoint.CoreAssets.Infrastructure.Data.Point>();
			List<StructurePoint.CoreAssets.Infrastructure.Data.Point> list2;
			if (true)
			{
				list2 = list;
			}
			List<EntityObject>.Enumerator enumerator = #tAc.Explode().GetEnumerator();
			List<EntityObject>.Enumerator enumerator2;
			if (!false)
			{
				enumerator2 = enumerator;
			}
			try
			{
				if (true)
				{
					goto IL_1A9;
				}
				goto IL_47;
				IL_41:
				Line line;
				EntityObject entityObject;
				Arc arc;
				if (line == null)
				{
					arc = (entityObject as Arc);
					goto IL_EA;
				}
				IL_47:
				Vector3 startPoint = line.StartPoint;
				Vector3 vector;
				if (8 != 0)
				{
					vector = startPoint;
				}
				double x = vector.X;
				Vector3 startPoint2 = line.StartPoint;
				if (4 != 0)
				{
					vector = startPoint2;
				}
				StructurePoint.CoreAssets.Infrastructure.Data.Point point = new StructurePoint.CoreAssets.Infrastructure.Data.Point(x, vector.Y);
				StructurePoint.CoreAssets.Infrastructure.Data.Point point2;
				do
				{
					vector = line.EndPoint;
					double x2 = vector.X;
					vector = line.EndPoint;
					point2 = new StructurePoint.CoreAssets.Infrastructure.Data.Point(x2, vector.Y);
					if (false)
					{
						goto IL_EA;
					}
					if (!list2.Any<StructurePoint.CoreAssets.Infrastructure.Data.Point>())
					{
						goto IL_CD;
					}
				}
				while (false);
				if (list2.Last<StructurePoint.CoreAssets.Infrastructure.Data.Point>().#rWi(point2) <= 0.001)
				{
					StructurePoint.CoreAssets.Infrastructure.Data.Point point3 = point;
					point = point2;
					point2 = point3;
				}
				IL_CD:
				list2.Add(point);
				list2.Add(point2);
				goto IL_1A9;
				IL_EA:
				if (arc != null)
				{
					double num = (double)#T1h(arc.Radius);
					double num2 = arc.StartAngle;
					double num3;
					double num4;
					do
					{
						num3 = (num *= Math.Abs(num2 - arc.EndAngle));
						num4 = (num2 = 360.0);
					}
					while (4 == 0);
					int precision = (int)Math.Max(num3 / num4, 3.0);
					List<StructurePoint.CoreAssets.Infrastructure.Data.Point> list3 = arc.ToPolyline2D(precision).Vertexes.Select(new Func<Polyline2DVertex, StructurePoint.CoreAssets.Infrastructure.Data.Point>(DXFPolylineHelper.<>c.<>9.#aWi)).ToList<StructurePoint.CoreAssets.Infrastructure.Data.Point>();
					if (list2.Any<StructurePoint.CoreAssets.Infrastructure.Data.Point>())
					{
						if (2 == 0)
						{
							goto IL_41;
						}
						if (list2.Last<StructurePoint.CoreAssets.Infrastructure.Data.Point>().#rWi(list3.Last<StructurePoint.CoreAssets.Infrastructure.Data.Point>()) <= 0.001)
						{
							list3.Reverse();
						}
					}
					list2.AddRange(list3);
				}
				IL_1A9:
				if (enumerator2.MoveNext())
				{
					EntityObject entityObject2 = enumerator2.Current;
					if (7 != 0)
					{
						entityObject = entityObject2;
					}
					Line line2 = entityObject as Line;
					if (false)
					{
						goto IL_41;
					}
					line = line2;
					goto IL_41;
				}
			}
			finally
			{
				((IDisposable)enumerator2).Dispose();
			}
			list2.#31d(new Func<StructurePoint.CoreAssets.Infrastructure.Data.Point, StructurePoint.CoreAssets.Infrastructure.Data.Point, bool>(DXFPolylineHelper.<>c.<>9.#bWi));
			return list2;
		}

		// Token: 0x04001C34 RID: 7220
		private const double #a = 0.001;
	}
}
