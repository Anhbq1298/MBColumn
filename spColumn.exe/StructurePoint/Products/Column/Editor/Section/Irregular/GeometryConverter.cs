using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using NetTopologySuite.Geometries;
using NetTopologySuite.Geometries.Implementation;
using StructurePoint.CoreAssets.AppManager.Column.Helpers;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Infrastructure;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.Products.Column.Model.Entities;

namespace StructurePoint.Products.Column.Editor.Section.Irregular
{
	// Token: 0x020004C7 RID: 1223
	internal static class GeometryConverter
	{
		// Token: 0x06002CDB RID: 11483 RVA: 0x000283AB File Offset: 0x000265AB
		public static List<Geometry> #Uxb(IList<ShapeModel> #6Y)
		{
			return #6Y.Select(new Func<ShapeModel, Geometry>(GeometryConverter.<>c.<>9.#d8b)).ToList<Geometry>();
		}

		// Token: 0x06002CDC RID: 11484 RVA: 0x000ECDE4 File Offset: 0x000EAFE4
		public static Geometry #Vxb(ShapeModel #rP)
		{
			PolygonData polygonData = #rP.#cxc(0);
			IReadOnlyList<StructurePoint.CoreAssets.Infrastructure.Data.Point> source = polygonData.Points2D;
			Coordinate[] coordinates = source.Select(new Func<StructurePoint.CoreAssets.Infrastructure.Data.Point, Coordinate>(GeometryConverter.<>c.<>9.#e8b)).ToArray<Coordinate>();
			LinearRing shell = new LinearRing(new CoordinateArraySequence(coordinates), GeometryConverter.#a);
			return new Polygon(shell, GeometryConverter.#a)
			{
				UserData = #rP
			};
		}

		// Token: 0x06002CDD RID: 11485 RVA: 0x000ECE5C File Offset: 0x000EB05C
		public static IList<ShapeModel> #Wxb(Geometry #Xxb)
		{
			List<ShapeModel> list = new List<ShapeModel>();
			IList<Polygon> list2 = GeometryConverter.#Zxb(#Xxb);
			if (list2.Count == 1)
			{
				list.Add(GeometryConverter.#Yxb(list2[0]));
			}
			else
			{
				List<ShapeModel> list3 = list;
				IEnumerable<Polygon> source = list2.Where(new Func<Polygon, bool>(GeometryConverter.<>c.<>9.#f8b));
				Func<Polygon, ShapeModel> selector;
				if ((selector = GeometryConverter.#2Ui.#a) == null)
				{
					selector = (GeometryConverter.#2Ui.#a = new Func<Polygon, ShapeModel>(GeometryConverter.#Yxb));
				}
				list3.AddRange(source.Select(selector));
			}
			List<ShapeModel> list4 = new List<ShapeModel>();
			List<PolygonData> source2 = list.SelectMany(new Func<ShapeModel, IEnumerable<PolygonData>>(GeometryConverter.<>c.<>9.#g8b)).ToList<PolygonData>();
			List<PolygonData> source3 = list.SelectMany(new Func<ShapeModel, IEnumerable<PolygonData>>(GeometryConverter.<>c.<>9.#i8b)).ToList<PolygonData>();
			list4.AddRange(source2.Select(new Func<PolygonData, ShapeModel>(GeometryConverter.<>c.<>9.#k8b)));
			list4.AddRange(source3.Select(new Func<PolygonData, ShapeModel>(GeometryConverter.<>c.<>9.#l8b)));
			return list4;
		}

		// Token: 0x06002CDE RID: 11486 RVA: 0x000ECFB4 File Offset: 0x000EB1B4
		private static ShapeModel #Yxb(Polygon #JP)
		{
			List<PolygonData> list = new List<PolygonData>();
			if (!#JP.ExteriorRing.IsEmpty && #JP.ExteriorRing.IsValid)
			{
				List<Point3D> points3D = #JP.ExteriorRing.Coordinates.Select(new Func<Coordinate, Point3D>(GeometryConverter.<>c.<>9.#m8b)).ToList<Point3D>();
				list.Add(new PolygonData(points3D, PolygonType.Undefined));
			}
			foreach (LinearRing linearRing in #JP.Holes)
			{
				if (!linearRing.IsEmpty && linearRing.IsValid)
				{
					List<Point3D> points3D2 = linearRing.Coordinates.Select(new Func<Coordinate, Point3D>(GeometryConverter.<>c.<>9.#n8b)).ToList<Point3D>();
					list.Add(new PolygonData(points3D2, PolygonType.Undefined)
					{
						IsOpening = true
					});
				}
			}
			if (!list.Any<PolygonData>())
			{
				return null;
			}
			return new ShapeModel(list);
		}

		// Token: 0x06002CDF RID: 11487 RVA: 0x000ED0C4 File Offset: 0x000EB2C4
		private static IList<Polygon> #Zxb(Geometry #Xxb)
		{
			List<Polygon> list = new List<Polygon>();
			if (#Xxb.IsEmpty)
			{
				return list;
			}
			MultiPolygon multiPolygon = #Xxb as MultiPolygon;
			if (multiPolygon != null)
			{
				foreach (Geometry geometry in multiPolygon.Geometries)
				{
					if (geometry.IsValid && !geometry.IsEmpty)
					{
						list.AddRange(GeometryConverter.#Zxb(geometry));
					}
				}
			}
			else
			{
				Polygon polygon = #Xxb as Polygon;
				if (polygon != null)
				{
					list.Add(polygon);
				}
				else
				{
					GeometryCollection geometryCollection = #Xxb as GeometryCollection;
					if (geometryCollection != null)
					{
						foreach (Geometry geometry2 in geometryCollection.Geometries)
						{
							if (geometry2.Area > ColumnGeometryHelper.#a && geometry2.IsValid && !geometry2.IsEmpty)
							{
								list.AddRange(GeometryConverter.#Zxb(geometry2));
							}
						}
					}
				}
			}
			return list;
		}

		// Token: 0x040011FB RID: 4603
		private static readonly GeometryFactory #a = ColumnGeometryHelper.#LKe();

		// Token: 0x020004C8 RID: 1224
		[CompilerGenerated]
		private static class #2Ui
		{
			// Token: 0x040011FC RID: 4604
			public static Func<Polygon, ShapeModel> #a;
		}
	}
}
