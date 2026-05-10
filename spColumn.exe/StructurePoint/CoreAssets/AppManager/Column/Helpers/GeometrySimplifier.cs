using System;
using System.Collections.Generic;
using System.Linq;
using #7hc;
using NetTopologySuite.Algorithm;
using NetTopologySuite.Geometries;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace StructurePoint.CoreAssets.AppManager.Column.Helpers
{
	// Token: 0x02001278 RID: 4728
	public static class GeometrySimplifier
	{
		// Token: 0x06009E99 RID: 40601 RVA: 0x0021A05C File Offset: 0x0021825C
		public static double #Yrc(Coordinate #mcb, Coordinate #ncb, Coordinate #Ckc)
		{
			double num = (#mcb.X - #Ckc.X) * (#ncb.Y - #Ckc.Y);
			double num2 = (#mcb.Y - #Ckc.Y) * (#ncb.X - #Ckc.X);
			return (num - num2) / 2.0;
		}

		// Token: 0x06009E9A RID: 40602 RVA: 0x0007CCBB File Offset: 0x0007AEBB
		public static bool #vlc(Coordinate #mcb, Coordinate #ncb, Coordinate #Ckc)
		{
			return CGAlgorithmsDD.OrientationIndex(#mcb, #ncb, #Ckc) == 0 || Math.Abs(GeometrySimplifier.#Yrc(#mcb, #ncb, #Ckc)) <= 0.003;
		}

		// Token: 0x06009E9B RID: 40603 RVA: 0x0021A0AC File Offset: 0x002182AC
		public static LineString #aLe(LineString #bLe)
		{
			if (#bLe == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107313284));
			}
			Coordinate[] coordinates = #bLe.Coordinates;
			int num = coordinates.Length;
			IList<Coordinate> list;
			GeometrySimplifier.#dLe(coordinates, out list);
			if (list.Count > 3)
			{
				bool flag = false;
				if (list.First<Coordinate>().Equals(list.Last<Coordinate>()))
				{
					flag = true;
					list.RemoveAt(list.Count - 1);
				}
				list = list.#Mmc(2);
				if (flag)
				{
					list.Add(list.First<Coordinate>());
				}
				GeometrySimplifier.#dLe(list, out list);
			}
			if (num == list.Count)
			{
				return #bLe;
			}
			return #bLe.Factory.CreateLineString(((List<Coordinate>)list).ToArray());
		}

		// Token: 0x06009E9C RID: 40604 RVA: 0x0021A154 File Offset: 0x00218354
		public static Polygon #aLe(Polygon #JP)
		{
			if (#JP == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107399958));
			}
			GeometryFactory factory = #JP.Factory;
			LineString lineString = GeometrySimplifier.#aLe(#JP.ExteriorRing);
			if (lineString == null || lineString.IsEmpty)
			{
				return null;
			}
			IList<LineString> list = new List<LineString>();
			int numInteriorRings = #JP.NumInteriorRings;
			for (int i = 0; i < numInteriorRings; i++)
			{
				LineString lineString2 = #JP.InteriorRings[i];
				lineString2 = GeometrySimplifier.#aLe(lineString2);
				if (lineString2 != null && !lineString2.IsEmpty)
				{
					list.Add(lineString2);
				}
			}
			return factory.CreatePolygon(new LinearRing(lineString.Coordinates), list.Select(new Func<LineString, LinearRing>(GeometrySimplifier.<>c.<>9.#ggf)).ToArray<LinearRing>());
		}

		// Token: 0x06009E9D RID: 40605 RVA: 0x0021A228 File Offset: 0x00218428
		public static Geometry #aLe(Geometry #Xxb)
		{
			if (#Xxb == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107313299));
			}
			LineString lineString = #Xxb as LineString;
			if (lineString != null)
			{
				return GeometrySimplifier.#aLe(lineString);
			}
			Polygon polygon = #Xxb as Polygon;
			if (polygon != null)
			{
				return GeometrySimplifier.#aLe(polygon);
			}
			MultiPolygon multiPolygon = #Xxb as MultiPolygon;
			if (multiPolygon != null)
			{
				Polygon[] array = new Polygon[multiPolygon.NumGeometries];
				for (int i = 0; i < multiPolygon.NumGeometries; i++)
				{
					Polygon polygon2 = (Polygon)multiPolygon.Geometries[i];
					polygon2 = GeometrySimplifier.#aLe(polygon2);
					array[i] = polygon2;
				}
				return multiPolygon.Factory.CreateMultiPolygon(array);
			}
			string str = #Phc.#3hc(107313254);
			Type type = #Xxb.GetType();
			throw new ArgumentException(str + ((type != null) ? type.ToString() : null));
		}

		// Token: 0x06009E9E RID: 40606 RVA: 0x0021A2F0 File Offset: 0x002184F0
		public static Geometry #aLe(Geometry #Xxb, int #cLe)
		{
			if (#Xxb == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107313299));
			}
			if (#cLe <= 0 || #Xxb.NumPoints < #cLe)
			{
				return #Xxb;
			}
			LineString lineString = #Xxb as LineString;
			if (lineString != null)
			{
				return GeometrySimplifier.#aLe(lineString);
			}
			Polygon polygon = #Xxb as Polygon;
			if (polygon != null)
			{
				return GeometrySimplifier.#aLe(polygon);
			}
			MultiPolygon multiPolygon = #Xxb as MultiPolygon;
			if (multiPolygon != null)
			{
				Polygon[] array = new Polygon[multiPolygon.NumGeometries];
				for (int i = 0; i < multiPolygon.NumGeometries; i++)
				{
					Polygon polygon2 = (Polygon)multiPolygon.Geometries[i];
					polygon2 = GeometrySimplifier.#aLe(polygon2);
					array[i] = polygon2;
				}
				return multiPolygon.Factory.CreateMultiPolygon(array);
			}
			string str = #Phc.#3hc(107313254);
			Type type = #Xxb.GetType();
			throw new ArgumentException(str + ((type != null) ? type.ToString() : null));
		}

		// Token: 0x06009E9F RID: 40607 RVA: 0x0021A3C4 File Offset: 0x002185C4
		private static void #dLe(IList<Coordinate> #kl, out IList<Coordinate> #eLe)
		{
			int count = #kl.Count;
			#eLe = new List<Coordinate>();
			#eLe.Add(#kl[0]);
			int index = 0;
			int num = 1;
			int i = 2;
			Coordinate #mcb = #kl[index];
			while (i < count)
			{
				Coordinate coordinate = #kl[num];
				Coordinate #Ckc = #kl[i];
				if (!GeometrySimplifier.#vlc(#mcb, coordinate, #Ckc))
				{
					#eLe.Add(coordinate);
					index = num;
					#mcb = #kl[index];
				}
				num++;
				i++;
			}
			#eLe.Add(#kl[count - 1]);
		}
	}
}
