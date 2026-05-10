using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using TriangleNet;
using TriangleNet.Geometry;
using TriangleNet.Meshing;
using TriangleNet.Topology;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.Drawing
{
	// Token: 0x02000988 RID: 2440
	[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Triangulator")]
	public static class VisualMeshTriangulator
	{
		// Token: 0x06004F7F RID: 20351 RVA: 0x0015C574 File Offset: 0x0015A774
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
		public static bool CanPerformTriangulation(IReadOnlyCollection<Point3D> points)
		{
			bool result;
			try
			{
				if (points == null)
				{
					bool flag = false;
					if (!false)
					{
						result = flag;
					}
				}
				else if (points.Count < PolygonData.MinNumberOfPoints)
				{
					result = false;
				}
				else
				{
					List<StructurePoint.CoreAssets.Infrastructure.Data.Point> #BP = PointsConverter.#vsc(points);
					Polygon polygon = new Polygon();
					VisualMeshTriangulator.MyAddRing(polygon, VisualMeshTriangulator.MyConvertPoints(PointsConverter.#Asc(#BP)), false);
					result = ((Mesh)new GenericMesher().Triangulate(polygon)).Triangles.Any<Triangle>();
				}
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06004F80 RID: 20352 RVA: 0x0015C5FC File Offset: 0x0015A7FC
		public static IReadOnlyList<SystemTriangleData> Triangulate(IReadOnlyList<PolygonDrawingData> polygonsDrawingData, double offset)
		{
			VisualMeshTriangulator.<>c__DisplayClass1_0 CS$<>8__locals1 = new VisualMeshTriangulator.<>c__DisplayClass1_0();
			VisualMeshTriangulator.<>c__DisplayClass1_0 CS$<>8__locals2;
			if (6 != 0)
			{
				CS$<>8__locals2 = CS$<>8__locals1;
			}
			CS$<>8__locals2.offset = offset;
			#X0d.#V0d(polygonsDrawingData, #Phc.#3hc(107467578), Component.DesktopControls, #Phc.#3hc(107467067));
			Polygon polygon = new Polygon();
			foreach (PolygonDrawingData polygonDrawingData in ((polygonsDrawingData as IList<PolygonDrawingData>) ?? polygonsDrawingData.ToList<PolygonDrawingData>()))
			{
				VisualMeshTriangulator.MyAddRing(polygon, VisualMeshTriangulator.MyConvertPoints(PointsConverter.#Asc(polygonDrawingData.Points.ToList<StructurePoint.CoreAssets.Infrastructure.Data.Point>())), polygonDrawingData.IsOpening);
			}
			return (from loopTriangle in ((Mesh)new GenericMesher().Triangulate(polygon, new ConstraintOptions
			{
				ConformingDelaunay = false
			})).Triangles
			select new SystemTriangleData(loopTriangle.GetVertex(0), loopTriangle.GetVertex(1), loopTriangle.GetVertex(2), CS$<>8__locals2.offset)).ToList<SystemTriangleData>();
		}

		// Token: 0x06004F81 RID: 20353 RVA: 0x0015C6F4 File Offset: 0x0015A8F4
		public static IReadOnlyList<SystemTriangleData> TriangulateRectangularPolygons(IReadOnlyList<PolygonDrawingData> polygonsDrawingData, double offset)
		{
			#X0d.#V0d(polygonsDrawingData, #Phc.#3hc(107467578), Component.DesktopControls, #Phc.#3hc(107467067));
			int count = polygonsDrawingData.Count;
			SystemTriangleData[] array = new SystemTriangleData[count * 2];
			int num = 0;
			for (int i = 0; i < count; i++)
			{
				IReadOnlyList<StructurePoint.CoreAssets.Infrastructure.Data.Point> points = polygonsDrawingData[i].Points;
				if (points.Count != 5)
				{
					throw new InvalidOperationException();
				}
				StructurePoint.CoreAssets.Infrastructure.Data.Point point = points[0];
				StructurePoint.CoreAssets.Infrastructure.Data.Point point2 = points[2];
				array[num++] = new SystemTriangleData(point, points[1], point2, offset);
				array[num++] = new SystemTriangleData(point, point2, points[3], offset);
			}
			return array;
		}

		// Token: 0x06004F82 RID: 20354 RVA: 0x000422A8 File Offset: 0x000404A8
		private static IList<Vertex> MyConvertPoints(IEnumerable<StructurePoint.CoreAssets.Infrastructure.Data.Point> points2D)
		{
			return (from item in points2D
			select new Vertex(Math.Round(item.X, PointsConverter.#c), Math.Round(item.Y, PointsConverter.#c))).ToList<Vertex>();
		}

		// Token: 0x06004F83 RID: 20355 RVA: 0x0015C7C8 File Offset: 0x0015A9C8
		private static void MyAddRing(Polygon polygon, IList<Vertex> vertices, bool isHole)
		{
			Contour contour = new Contour(vertices);
			polygon.Add(contour, isHole);
		}
	}
}
