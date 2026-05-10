using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using #7hc;
using #klc;
using #N6c;
using #pXd;
using #xKe;
using devDept.Geometry;
using Microsoft.SqlServer.Types;
using NetTopologySuite.Geometries;
using NetTopologySuite.Geometries.Implementation;
using NetTopologySuite.Geometries.Utilities;
using NetTopologySuite.IO;
using NetTopologySuite.Operation.Overlay.Snap;
using NetTopologySuite.Operation.Polygonize;
using NetTopologySuite.Precision;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.Infrastructure;
using StructurePoint.CoreAssets.Infrastructure.Data;
using TriangleNet;
using TriangleNet.Geometry;
using TriangleNet.Meshing;
using TriangleNet.Topology;

namespace StructurePoint.CoreAssets.AppManager.Column.Helpers
{
	// Token: 0x02000523 RID: 1315
	public class ColumnGeometryHelper
	{
		// Token: 0x06002F61 RID: 12129 RVA: 0x000F4B38 File Offset: 0x000F2D38
		static ColumnGeometryHelper()
		{
			#sLe.#eb();
		}

		// Token: 0x06002F62 RID: 12130 RVA: 0x0002A46E File Offset: 0x0002866E
		public ColumnGeometryHelper(bool overrideCirclesSegments, int overridenCircleSegments) : this()
		{
			this.OverrideCirclesSegments = overrideCirclesSegments;
			this.OverridenCircleSegments = overridenCircleSegments;
		}

		// Token: 0x06002F63 RID: 12131 RVA: 0x0002A484 File Offset: 0x00028684
		public ColumnGeometryHelper()
		{
			this.#f.Add(40);
			this.#f.Add(41);
		}

		// Token: 0x17000F80 RID: 3968
		// (get) Token: 0x06002F64 RID: 12132 RVA: 0x0002A4B3 File Offset: 0x000286B3
		public bool OverrideCirclesSegments { get; }

		// Token: 0x17000F81 RID: 3969
		// (get) Token: 0x06002F65 RID: 12133 RVA: 0x0002A4BB File Offset: 0x000286BB
		public int OverridenCircleSegments { get; }

		// Token: 0x17000F82 RID: 3970
		// (get) Token: 0x06002F66 RID: 12134 RVA: 0x0002A4C3 File Offset: 0x000286C3
		public #Z7c<int> NumberOfPointsForCircle
		{
			get
			{
				return this.#f;
			}
		}

		// Token: 0x06002F67 RID: 12135 RVA: 0x000F4B90 File Offset: 0x000F2D90
		public static bool #1lc(IList<StructurePoint.CoreAssets.Infrastructure.Data.Point3D> #BP)
		{
			if (#BP == null || #BP.Count < 3)
			{
				return false;
			}
			StructurePoint.CoreAssets.Infrastructure.Data.Point3D point3D = #BP[0];
			StructurePoint.CoreAssets.Infrastructure.Data.Point3D #ncb = #BP[#BP.Count - 1];
			bool flag = false;
			if (StructurePoint.CoreAssets.Infrastructure.Data.Point3D.#F3d(point3D, #ncb))
			{
				#BP.Add(point3D);
				flag = true;
			}
			try
			{
				GeometryFactory geometryFactory = ColumnGeometryHelper.#LKe(ColumnGeometryHelper.#e);
				Coordinate[] coordinates = #BP.Select(new Func<StructurePoint.CoreAssets.Infrastructure.Data.Point3D, Coordinate>(ColumnGeometryHelper.<>c.<>9.#1ff)).ToArray<Coordinate>();
				NetTopologySuite.Geometries.Polygon polygon = geometryFactory.CreatePolygon(coordinates);
				if (polygon.NumGeometries != 1 || !polygon.IsValid || !polygon.IsSimple || polygon.Area < ColumnGeometryHelper.#a)
				{
					return false;
				}
			}
			catch (Exception)
			{
				return false;
			}
			finally
			{
				if (flag)
				{
					#BP.RemoveAt(#BP.Count - 1);
				}
			}
			return true;
		}

		// Token: 0x06002F68 RID: 12136 RVA: 0x000F4C80 File Offset: 0x000F2E80
		public static List<StructurePoint.CoreAssets.Infrastructure.Data.Point3D> #CKe(StructurePoint.CoreAssets.Infrastructure.Data.Point #wob, double #HS, int #Znc)
		{
			ColumnGeometryHelper.#i9b #i9b;
			#i9b.#a = ColumnGeometryHelper.#2nc(new StructurePoint.CoreAssets.Infrastructure.Data.Point3D(#wob), #HS, #Znc);
			if (#Znc == 40)
			{
				ColumnGeometryHelper.#RKe(10, ref #i9b);
				ColumnGeometryHelper.#RKe(30, ref #i9b);
				ColumnGeometryHelper.#UKe(0, ref #i9b);
				ColumnGeometryHelper.#UKe(20, ref #i9b);
			}
			else if (#Znc == 56)
			{
				ColumnGeometryHelper.#RKe(14, ref #i9b);
				ColumnGeometryHelper.#RKe(42, ref #i9b);
				ColumnGeometryHelper.#UKe(0, ref #i9b);
				ColumnGeometryHelper.#UKe(28, ref #i9b);
			}
			return #i9b.#a;
		}

		// Token: 0x06002F69 RID: 12137 RVA: 0x000F4CFC File Offset: 0x000F2EFC
		public static Geometry #m9d(GeometryFactory #opb, Geometry #Xxb)
		{
			if (#Xxb.IsValid)
			{
				return #Xxb;
			}
			SqlGeometry sqlGeometry = SqlGeometry.STGeomFromText(new SqlChars(new SqlString(#Xxb.AsText())), 0);
			sqlGeometry = sqlGeometry.MakeValid();
			return new WKTReader(#opb).Read(sqlGeometry.STAsText().ToSqlString().ToString());
		}

		// Token: 0x06002F6A RID: 12138 RVA: 0x0002A4CB File Offset: 0x000286CB
		public static void #DKe(ref Geometry #EKe, ref Geometry #FKe)
		{
			ColumnGeometryHelper.#DKe(ref #EKe, ref #FKe, ColumnGeometryHelper.#e);
		}

		// Token: 0x06002F6B RID: 12139 RVA: 0x000F4D58 File Offset: 0x000F2F58
		public static void #DKe(ref Geometry #EKe, ref Geometry #FKe, PrecisionModel #GKe)
		{
			if (#EKe == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107313972));
			}
			if (#FKe == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107313927));
			}
			GeometryPrecisionReducer geometryPrecisionReducer = ColumnGeometryHelper.#KKe(#GKe);
			Geometry geometry = #EKe;
			Geometry geometry2 = #FKe;
			Geometry geometry3 = geometryPrecisionReducer.Reduce(#EKe);
			#EKe = (geometry3.IsEmpty ? #EKe : geometry3);
			geometry3 = geometryPrecisionReducer.Reduce(#FKe);
			#FKe = (geometry3.IsEmpty ? #FKe : geometry3);
			Geometry[] array = GeometrySnapper.Snap(#EKe, #FKe, ColumnGeometryHelper.#b);
			#EKe = array[0];
			#FKe = array[1];
			#EKe.UserData = geometry.UserData;
			#FKe.UserData = geometry2.UserData;
		}

		// Token: 0x06002F6C RID: 12140 RVA: 0x000F4E08 File Offset: 0x000F3008
		public #yKe #zuc(PolygonData #JP, StructurePoint.CoreAssets.Infrastructure.Data.Point #Akb, StructurePoint.CoreAssets.Infrastructure.Data.Point #Bkb)
		{
			GeometryFactory geometryFactory = ColumnGeometryHelper.#LKe();
			Geometry #JP2 = this.#aoc(#JP, geometryFactory);
			Geometry #Ztc = new LineString(new CoordinateArraySequence(new Coordinate[]
			{
				new Coordinate(#Akb.X, #Akb.Y),
				new Coordinate(#Bkb.X, #Bkb.Y)
			}), geometryFactory);
			ColumnGeometryHelper.#DKe(ref #JP2, ref #Ztc);
			Geometry #Xxb = ColumnGeometryHelper.#QKe(#JP2, #Ztc);
			IList<ShapeData> collection = ColumnGeometryHelper.#Wxb(#Xxb);
			#yKe #yKe = new #yKe();
			#yKe.Geometry = #Xxb;
			#yKe.Shapes.AddRange(collection);
			return #yKe;
		}

		// Token: 0x06002F6D RID: 12141 RVA: 0x0002A4D9 File Offset: 0x000286D9
		public static StructurePoint.CoreAssets.Infrastructure.Data.Point #OW(StructurePoint.CoreAssets.Infrastructure.Data.Point #Ng)
		{
			return new StructurePoint.CoreAssets.Infrastructure.Data.Point(ColumnGeometryHelper.#OW(#Ng.X), ColumnGeometryHelper.#OW(#Ng.Y));
		}

		// Token: 0x06002F6E RID: 12142 RVA: 0x0002A4F8 File Offset: 0x000286F8
		public static double #OW(double #f)
		{
			return Math.Round(#f, ColumnGeometryHelper.#d);
		}

		// Token: 0x06002F6F RID: 12143 RVA: 0x000F4E94 File Offset: 0x000F3094
		public static bool #HKe(Geometry #Xxb, out List<StructurePoint.CoreAssets.Infrastructure.Data.Point3D> #IKe, out List<IndexTriangle> #JKe)
		{
			#IKe = new List<StructurePoint.CoreAssets.Infrastructure.Data.Point3D>();
			#JKe = new List<IndexTriangle>();
			if (#Xxb == null || #Xxb.IsEmpty)
			{
				return false;
			}
			TriangleNet.Geometry.Polygon polygon = new TriangleNet.Geometry.Polygon();
			GenericMesher genericMesher = new GenericMesher();
			foreach (PolygonData polygonData in ColumnGeometryHelper.#Wxb(#Xxb).SelectMany(new Func<ShapeData, IEnumerable<PolygonData>>(ColumnGeometryHelper.<>c.<>9.#2ff)))
			{
				ColumnGeometryHelper.#opc(polygon, ColumnGeometryHelper.#npc(polygonData.Points2D), polygonData.IsOpening);
			}
			if (polygon.Points.Count < 3)
			{
				return false;
			}
			Mesh mesh = (Mesh)genericMesher.Triangulate(polygon, new ConstraintOptions
			{
				ConformingDelaunay = false
			});
			foreach (Vertex vertex in mesh.Vertices)
			{
				#IKe.Add(new StructurePoint.CoreAssets.Infrastructure.Data.Point3D(vertex.X, vertex.Y));
			}
			foreach (TriangleNet.Topology.Triangle triangle in mesh.Triangles)
			{
				#JKe.Add(new IndexTriangle(triangle.GetVertexID(0), triangle.GetVertexID(1), triangle.GetVertexID(2)));
			}
			return true;
		}

		// Token: 0x06002F70 RID: 12144 RVA: 0x0002A505 File Offset: 0x00028705
		protected static GeometryPrecisionReducer #KKe(PrecisionModel #Od)
		{
			return new GeometryPrecisionReducer(#Od);
		}

		// Token: 0x06002F71 RID: 12145 RVA: 0x0002A50D File Offset: 0x0002870D
		public static GeometryFactory #LKe()
		{
			return new GeometryFactory(ColumnGeometryHelper.#e, 0);
		}

		// Token: 0x06002F72 RID: 12146 RVA: 0x0002A51A File Offset: 0x0002871A
		internal static GeometryFactory #LKe(PrecisionModel #Od)
		{
			return new GeometryFactory(#Od, 0);
		}

		// Token: 0x06002F73 RID: 12147 RVA: 0x000F5024 File Offset: 0x000F3224
		public #yKe #5lc(PolygonData #VHb, List<PolygonData> #MKe, #KXd #GRb)
		{
			ColumnGeometryHelper.#yZb #yZb = new ColumnGeometryHelper.#yZb();
			#yZb.#a = this;
			#yZb.#b = ColumnGeometryHelper.#LKe();
			Geometry geometry = this.#aoc(#VHb, #yZb.#b);
			#yKe #yKe = new #yKe();
			if (#MKe.Any<PolygonData>())
			{
				MultiPolygon item = new MultiPolygon(#MKe.Select(new Func<PolygonData, NetTopologySuite.Geometries.Polygon>(#yZb.#8ff)).ToList<NetTopologySuite.Geometries.Polygon>().ToArray());
				geometry = ColumnGeometryHelper.#5lc(#GRb, new List<Geometry>
				{
					item
				}, geometry);
				#GRb.#GEd();
			}
			if (#MKe.Any<PolygonData>() || this.#tmc(#VHb))
			{
				IList<ShapeData> collection = ColumnGeometryHelper.#Wxb(geometry);
				#yKe.Shapes.AddRange(collection);
			}
			else
			{
				#yKe.Shapes.Add(ShapeData.#6wc(#VHb, #jlc.#b));
			}
			#yKe.Geometry = geometry;
			return #yKe;
		}

		// Token: 0x06002F74 RID: 12148 RVA: 0x000F50E4 File Offset: 0x000F32E4
		public static Geometry #5lc(#KXd #GRb, List<Geometry> #NKe, Geometry #OKe)
		{
			GeometryFactory #opb = ColumnGeometryHelper.#LKe();
			GeometryPrecisionReducer geometryPrecisionReducer = ColumnGeometryHelper.#KKe(ColumnGeometryHelper.#e);
			foreach (Geometry geometry in #NKe)
			{
				#OKe = geometryPrecisionReducer.Reduce(#OKe);
				geometry = geometryPrecisionReducer.Reduce(geometry);
				#GRb.#GEd();
				Geometry[] array = GeometrySnapper.Snap(#OKe, geometry, ColumnGeometryHelper.#b);
				#OKe = array[0];
				geometry = array[1];
				#GRb.#GEd();
				try
				{
					#OKe = #OKe.Difference(geometry);
				}
				catch (Exception)
				{
					#OKe = ColumnGeometryHelper.#m9d(#opb, #OKe);
					geometry = ColumnGeometryHelper.#m9d(#opb, geometry);
					#GRb.#GEd();
					#OKe = #OKe.Difference(geometry);
				}
			}
			return #OKe;
		}

		// Token: 0x06002F75 RID: 12149 RVA: 0x000F51A8 File Offset: 0x000F33A8
		public static Geometry #Tlc(IList<Geometry> #AAb)
		{
			if (#AAb.Count < 2)
			{
				return #AAb.FirstOrDefault<Geometry>();
			}
			GeometryPrecisionReducer geometryPrecisionReducer = ColumnGeometryHelper.#KKe(ColumnGeometryHelper.#e);
			Geometry geometry = #AAb[0];
			for (int i = 1; i < #AAb.Count; i++)
			{
				Geometry geometry2 = #AAb[i];
				geometry = geometryPrecisionReducer.Reduce(geometry);
				geometry2 = geometryPrecisionReducer.Reduce(geometry2);
				Geometry[] array = GeometrySnapper.Snap(geometry, geometry2, ColumnGeometryHelper.#b);
				geometry = array[0];
				geometry2 = array[1];
				geometry = geometry.Union(geometry2);
			}
			return geometry;
		}

		// Token: 0x06002F76 RID: 12150 RVA: 0x000F5220 File Offset: 0x000F3420
		private static List<StructurePoint.CoreAssets.Infrastructure.Data.Point3D> #2nc(StructurePoint.CoreAssets.Infrastructure.Data.Point3D #wob, double #HS, int #Znc)
		{
			List<StructurePoint.CoreAssets.Infrastructure.Data.Point3D> list = new List<StructurePoint.CoreAssets.Infrastructure.Data.Point3D>();
			double num = 6.283185307179586 / (double)#Znc;
			double num2 = #wob.X;
			double num3 = #wob.Y;
			for (int i = 0; i < #Znc; i++)
			{
				double x = num2 + #HS * Math.Cos((double)i * num);
				double y = num3 + #HS * Math.Sin((double)i * num);
				list.Add(new StructurePoint.CoreAssets.Infrastructure.Data.Point3D(x, y, #wob.Z));
			}
			list.Add(list[0]);
			return list;
		}

		// Token: 0x06002F77 RID: 12151 RVA: 0x000F52A4 File Offset: 0x000F34A4
		private static IList<Vertex> #npc(IReadOnlyList<StructurePoint.CoreAssets.Infrastructure.Data.Point> #uzb)
		{
			List<StructurePoint.CoreAssets.Infrastructure.Data.Point> list = #uzb.ToList<StructurePoint.CoreAssets.Infrastructure.Data.Point>();
			list = PointsConverter.#Asc(list);
			list = GeometryHelper.#ioc(list, 0.0001);
			if (!list.Any<StructurePoint.CoreAssets.Infrastructure.Data.Point>())
			{
				list = #uzb.ToList<StructurePoint.CoreAssets.Infrastructure.Data.Point>();
				list = PointsConverter.#Asc(list);
			}
			List<Vertex> list2 = list.Select(new Func<StructurePoint.CoreAssets.Infrastructure.Data.Point, Vertex>(ColumnGeometryHelper.<>c.<>9.#3ff)).ToList<Vertex>();
			if (list2.Count > 1 && list2.First<Vertex>() == list2.Last<Vertex>())
			{
				list2.RemoveAt(list2.Count - 1);
			}
			return list2;
		}

		// Token: 0x06002F78 RID: 12152 RVA: 0x000F533C File Offset: 0x000F353C
		private static void #opc(TriangleNet.Geometry.Polygon #JP, IList<Vertex> #AHb, bool #ppc)
		{
			if (!#AHb.Any<Vertex>())
			{
				return;
			}
			Contour contour = new Contour(#AHb);
			#JP.Add(contour, #ppc);
		}

		// Token: 0x06002F79 RID: 12153 RVA: 0x000F5364 File Offset: 0x000F3564
		private static Geometry #PKe(Geometry #Xxb)
		{
			ReadOnlyCollection<Geometry> lines = LineStringExtracter.GetLines(#Xxb);
			Polygonizer polygonizer = new Polygonizer(false);
			polygonizer.Add(lines);
			Geometry[] geomList = GeometryFactory.ToGeometryArray(new List<Geometry>(polygonizer.GetPolygons()));
			return #Xxb.Factory.BuildGeometry(geomList);
		}

		// Token: 0x06002F7A RID: 12154 RVA: 0x000F53A4 File Offset: 0x000F35A4
		private static Geometry #QKe(Geometry #JP, Geometry #Ztc)
		{
			Geometry geometry = ColumnGeometryHelper.#PKe(#JP.Boundary.Union(#Ztc));
			List<Geometry> list = new List<Geometry>();
			for (int i = 0; i < geometry.NumGeometries; i++)
			{
				NetTopologySuite.Geometries.Polygon polygon = (NetTopologySuite.Geometries.Polygon)geometry.GetGeometryN(i);
				if (#JP.Contains(polygon.InteriorPoint))
				{
					list.Add(polygon);
				}
			}
			return #JP.Factory.BuildGeometry(list);
		}

		// Token: 0x06002F7B RID: 12155 RVA: 0x000F5408 File Offset: 0x000F3608
		private static ShapeData #Yxb(NetTopologySuite.Geometries.Polygon #JP)
		{
			List<PolygonData> list = new List<PolygonData>();
			if (!#JP.ExteriorRing.IsEmpty && #JP.ExteriorRing.IsValid)
			{
				List<StructurePoint.CoreAssets.Infrastructure.Data.Point3D> points3D = #JP.ExteriorRing.Coordinates.Select(new Func<Coordinate, StructurePoint.CoreAssets.Infrastructure.Data.Point3D>(ColumnGeometryHelper.<>c.<>9.#4ff)).ToList<StructurePoint.CoreAssets.Infrastructure.Data.Point3D>();
				list.Add(new PolygonData(points3D, PolygonType.Undefined));
			}
			foreach (LinearRing linearRing in #JP.Holes)
			{
				if (!linearRing.IsEmpty && linearRing.IsValid)
				{
					List<StructurePoint.CoreAssets.Infrastructure.Data.Point3D> points3D2 = linearRing.Coordinates.Select(new Func<Coordinate, StructurePoint.CoreAssets.Infrastructure.Data.Point3D>(ColumnGeometryHelper.<>c.<>9.#5ff)).ToList<StructurePoint.CoreAssets.Infrastructure.Data.Point3D>();
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
			return ShapeData.#6wc(list, #jlc.#b);
		}

		// Token: 0x06002F7C RID: 12156 RVA: 0x000F54FC File Offset: 0x000F36FC
		private static IList<NetTopologySuite.Geometries.Polygon> #Zxb(Geometry #Xxb)
		{
			List<NetTopologySuite.Geometries.Polygon> list = new List<NetTopologySuite.Geometries.Polygon>();
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
						list.AddRange(ColumnGeometryHelper.#Zxb(geometry));
					}
				}
			}
			else
			{
				NetTopologySuite.Geometries.Polygon polygon = #Xxb as NetTopologySuite.Geometries.Polygon;
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
								list.AddRange(ColumnGeometryHelper.#Zxb(geometry2));
							}
						}
					}
				}
			}
			return list;
		}

		// Token: 0x06002F7D RID: 12157 RVA: 0x000F55CC File Offset: 0x000F37CC
		private static IList<ShapeData> #Wxb(Geometry #Xxb)
		{
			List<ShapeData> list = new List<ShapeData>();
			IList<NetTopologySuite.Geometries.Polygon> list2 = ColumnGeometryHelper.#Zxb(#Xxb);
			if (list2.Count == 1)
			{
				list.Add(ColumnGeometryHelper.#Yxb(list2[0]));
			}
			else
			{
				List<ShapeData> list3 = list;
				IEnumerable<NetTopologySuite.Geometries.Polygon> source = list2.Where(new Func<NetTopologySuite.Geometries.Polygon, bool>(ColumnGeometryHelper.<>c.<>9.#6ff));
				Func<NetTopologySuite.Geometries.Polygon, ShapeData> selector;
				if ((selector = ColumnGeometryHelper.#2Ui.#a) == null)
				{
					selector = (ColumnGeometryHelper.#2Ui.#a = new Func<NetTopologySuite.Geometries.Polygon, ShapeData>(ColumnGeometryHelper.#Yxb));
				}
				list3.AddRange(source.Select(selector));
			}
			return list;
		}

		// Token: 0x06002F7E RID: 12158 RVA: 0x000F5650 File Offset: 0x000F3850
		private bool #tmc(PolygonData #VHb)
		{
			IReadOnlyList<StructurePoint.CoreAssets.Infrastructure.Data.Point> readOnlyList = #VHb.Points2D;
			return this.OverrideCirclesSegments && this.OverridenCircleSegments > 0 && this.NumberOfPointsForCircle.Contains(readOnlyList.Count) && CircleHelper.#tmc(readOnlyList);
		}

		// Token: 0x06002F7F RID: 12159 RVA: 0x000F5690 File Offset: 0x000F3890
		private NetTopologySuite.Geometries.Polygon #aoc(PolygonData #VHb, GeometryFactory #opb)
		{
			IReadOnlyList<StructurePoint.CoreAssets.Infrastructure.Data.Point> readOnlyList = #VHb.Points2D;
			if (this.#tmc(#VHb))
			{
				CircleData circleData = CircleHelper.#vmc(readOnlyList);
				if (circleData != null)
				{
					readOnlyList = GeometryHelper.#1nc(circleData.Center, circleData.Radius, this.OverridenCircleSegments, 0.0, true);
				}
			}
			return new NetTopologySuite.Geometries.Polygon(new LinearRing(new CoordinateArraySequence(readOnlyList.Select(new Func<StructurePoint.CoreAssets.Infrastructure.Data.Point, Coordinate>(ColumnGeometryHelper.<>c.<>9.#7ff)).ToArray<Coordinate>()), #opb), #opb);
		}

		// Token: 0x06002F80 RID: 12160 RVA: 0x000F5714 File Offset: 0x000F3914
		[CompilerGenerated]
		internal static void #RKe(int #SKe, ref ColumnGeometryHelper.#i9b A_1)
		{
			StructurePoint.CoreAssets.Infrastructure.Data.Point3D point3D = A_1.#a[#SKe];
			StructurePoint.CoreAssets.Infrastructure.Data.Point3D value = A_1.#a[#SKe - 1];
			value.Y = point3D.Y;
			A_1.#a[#SKe - 1] = value;
			value = A_1.#a[#SKe + 1];
			value.Y = point3D.Y;
			A_1.#a[#SKe + 1] = value;
		}

		// Token: 0x06002F81 RID: 12161 RVA: 0x000F5788 File Offset: 0x000F3988
		[CompilerGenerated]
		internal static void #TKe(int #4jb, double #f, ref ColumnGeometryHelper.#i9b A_2)
		{
			StructurePoint.CoreAssets.Infrastructure.Data.Point3D value = A_2.#a[#4jb];
			value.X = #f;
			A_2.#a[#4jb] = value;
		}

		// Token: 0x06002F82 RID: 12162 RVA: 0x000F57B8 File Offset: 0x000F39B8
		[CompilerGenerated]
		internal static void #UKe(int #SKe, ref ColumnGeometryHelper.#i9b A_1)
		{
			StructurePoint.CoreAssets.Infrastructure.Data.Point3D point3D = A_1.#a[#SKe];
			ColumnGeometryHelper.#TKe(#SKe + 1, point3D.X, ref A_1);
			if (#SKe == 0)
			{
				int count = A_1.#a.Count;
			}
			if (#SKe == 0)
			{
				ColumnGeometryHelper.#TKe(A_1.#a.Count - 2, point3D.X, ref A_1);
				return;
			}
			ColumnGeometryHelper.#TKe(#SKe - 1, point3D.X, ref A_1);
		}

		// Token: 0x0400131A RID: 4890
		public static readonly double #a = 0.03;

		// Token: 0x0400131B RID: 4891
		public static readonly double #b = 0.0015;

		// Token: 0x0400131C RID: 4892
		public static readonly double #c = 0.001;

		// Token: 0x0400131D RID: 4893
		public static readonly int #d = 3;

		// Token: 0x0400131E RID: 4894
		protected internal static readonly PrecisionModel #e = new PrecisionModel(10000.0);

		// Token: 0x0400131F RID: 4895
		private readonly #g8c<int> #f = new #g8c<int>();

		// Token: 0x04001320 RID: 4896
		[CompilerGenerated]
		private readonly bool #g;

		// Token: 0x04001321 RID: 4897
		[CompilerGenerated]
		private readonly int #h;

		// Token: 0x02000524 RID: 1316
		[CompilerGenerated]
		private static class #2Ui
		{
			// Token: 0x04001322 RID: 4898
			public static Func<NetTopologySuite.Geometries.Polygon, ShapeData> #a;
		}

		// Token: 0x02000526 RID: 1318
		[CompilerGenerated]
		[StructLayout(LayoutKind.Auto)]
		private struct #i9b
		{
			// Token: 0x0400132B RID: 4907
			public List<StructurePoint.CoreAssets.Infrastructure.Data.Point3D> #a;
		}

		// Token: 0x02000527 RID: 1319
		[CompilerGenerated]
		private sealed class #yZb
		{
			// Token: 0x06002F8D RID: 12173 RVA: 0x0002A5B5 File Offset: 0x000287B5
			internal NetTopologySuite.Geometries.Polygon #8ff(PolygonData #Rf)
			{
				return this.#a.#aoc(#Rf, this.#b);
			}

			// Token: 0x0400132C RID: 4908
			public ColumnGeometryHelper #a;

			// Token: 0x0400132D RID: 4909
			public GeometryFactory #b;
		}
	}
}
