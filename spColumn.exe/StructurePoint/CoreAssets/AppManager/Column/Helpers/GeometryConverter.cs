using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using NetTopologySuite.Geometries;
using NetTopologySuite.Geometries.Implementation;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Infrastructure;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.AppManager.Column.Helpers
{
	// Token: 0x02001275 RID: 4725
	public static class GeometryConverter
	{
		// Token: 0x06009E85 RID: 40581 RVA: 0x0007CC18 File Offset: 0x0007AE18
		public static List<Geometry> #Uxb(IList<SectionPolygon> #6Y)
		{
			Func<SectionPolygon, Geometry> selector;
			if ((selector = GeometryConverter.#2Ui.#a) == null)
			{
				selector = (GeometryConverter.#2Ui.#a = new Func<SectionPolygon, Geometry>(GeometryConverter.#Vxb));
			}
			return #6Y.Select(selector).ToList<Geometry>();
		}

		// Token: 0x06009E86 RID: 40582 RVA: 0x00219C58 File Offset: 0x00217E58
		public static Geometry #Vxb(SectionPolygon #rP)
		{
			return new Polygon(new LinearRing(new CoordinateArraySequence(#rP.Points.Select(new Func<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point, Coordinate>(GeometryConverter.<>c.<>9.#e8b)).ToArray<Coordinate>()), GeometryConverter.#a), GeometryConverter.#a)
			{
				UserData = #rP
			};
		}

		// Token: 0x06009E87 RID: 40583 RVA: 0x00219CB4 File Offset: 0x00217EB4
		public static IList<SectionPolygon> #Wxb(Geometry #Xxb)
		{
			List<ShapeData> list = new List<ShapeData>();
			IList<Polygon> list2 = GeometryConverter.#Zxb(#Xxb);
			if (list2.Count == 1)
			{
				list.Add(GeometryConverter.#Yxb(list2[0]));
			}
			else
			{
				List<ShapeData> list3 = list;
				IEnumerable<Polygon> source = list2.Where(new Func<Polygon, bool>(GeometryConverter.<>c.<>9.#f8b));
				Func<Polygon, ShapeData> selector;
				if ((selector = GeometryConverter.#2Ui.#b) == null)
				{
					selector = (GeometryConverter.#2Ui.#b = new Func<Polygon, ShapeData>(GeometryConverter.#Yxb));
				}
				list3.AddRange(source.Select(selector));
			}
			List<SectionPolygon> list4 = new List<SectionPolygon>();
			List<PolygonData> source2 = list.SelectMany(new Func<ShapeData, IEnumerable<PolygonData>>(GeometryConverter.<>c.<>9.#g8b)).ToList<PolygonData>();
			List<PolygonData> source3 = list.SelectMany(new Func<ShapeData, IEnumerable<PolygonData>>(GeometryConverter.<>c.<>9.#i8b)).ToList<PolygonData>();
			list4.AddRange(source2.Select(new Func<PolygonData, SectionPolygon>(GeometryConverter.<>c.<>9.#k8b)));
			list4.AddRange(source3.Select(new Func<PolygonData, SectionPolygon>(GeometryConverter.<>c.<>9.#l8b)));
			return list4;
		}

		// Token: 0x06009E88 RID: 40584 RVA: 0x00219DE8 File Offset: 0x00217FE8
		private static ShapeData #Yxb(Polygon #JP)
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
			return ShapeData.#6wc(list);
		}

		// Token: 0x06009E89 RID: 40585 RVA: 0x00219EDC File Offset: 0x002180DC
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

		// Token: 0x0400448E RID: 17550
		private static readonly GeometryFactory #a = ColumnGeometryHelper.#LKe();

		// Token: 0x02001276 RID: 4726
		[CompilerGenerated]
		private static class #2Ui
		{
			// Token: 0x0400448F RID: 17551
			public static Func<SectionPolygon, Geometry> #a;

			// Token: 0x04004490 RID: 17552
			public static Func<Polygon, ShapeData> #b;
		}
	}
}
