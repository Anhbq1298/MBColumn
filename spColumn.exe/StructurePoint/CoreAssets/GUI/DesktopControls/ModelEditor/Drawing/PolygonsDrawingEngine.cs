using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using #7hc;
using #UYd;
using HelixToolkit.Wpf;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.Drawing
{
	// Token: 0x02000986 RID: 2438
	public sealed class PolygonsDrawingEngine : IPolygonsDrawingEngine
	{
		// Token: 0x06004F68 RID: 20328 RVA: 0x0015BADC File Offset: 0x00159CDC
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Triangulator")]
		public PolygonsDrawingEngine(IDrawingResultsFactory drawingResultsFactory, IDrawingTriangulator drawingTriangulator)
		{
			#X0d.#V0d(drawingResultsFactory, #Phc.#3hc(107451628), Component.DesktopControls, #Phc.#3hc(107467681));
			#X0d.#V0d(drawingTriangulator, #Phc.#3hc(107467628), Component.DesktopControls, #Phc.#3hc(107467599));
			this.drawingResultsFactory = drawingResultsFactory;
			this.drawingTriangulator = drawingTriangulator;
		}

		// Token: 0x06004F69 RID: 20329 RVA: 0x0015BB34 File Offset: 0x00159D34
		public IPolygonsDrawingResult DrawPolygons(PolygonsDrawingData polygonsDrawingData, IPolygonsDrawingResult existingDrawingResult)
		{
			#X0d.#V0d(polygonsDrawingData, #Phc.#3hc(107467578), Component.DesktopControls, #Phc.#3hc(107467549));
			IPointsDrawingResult pointsDrawingResult = this.DrawSurfacesAndLinesAndCreatePoints(polygonsDrawingData, ref existingDrawingResult, true);
			if (polygonsDrawingData.PointSize != null && polygonsDrawingData.PointColor != null)
			{
				this.DrawPoints(pointsDrawingResult, polygonsDrawingData.Polygons.SelectMany((PolygonDrawingData item) => item.Points).ToList<StructurePoint.CoreAssets.Infrastructure.Data.Point>(), polygonsDrawingData.PointColor.Value, polygonsDrawingData.PointSize.Value, polygonsDrawingData.VerticalOffsetOfNode.GetValueOrDefault());
			}
			return existingDrawingResult;
		}

		// Token: 0x06004F6A RID: 20330 RVA: 0x0015BC08 File Offset: 0x00159E08
		public IPolygonsDrawingResult DrawPolygons(PolygonsDrawingData polygonsDrawingData, IPolygonsDrawingResult existingDrawingResult, bool isSectionCircular, bool isOpeningCircular)
		{
			#X0d.#V0d(polygonsDrawingData, #Phc.#3hc(107467578), Component.DesktopControls, #Phc.#3hc(107466952));
			IPointsDrawingResult pointsDrawingResult = this.DrawSurfacesAndLinesAndCreatePoints(polygonsDrawingData, ref existingDrawingResult, true);
			if (polygonsDrawingData.PointSize != null && polygonsDrawingData.PointColor != null)
			{
				List<StructurePoint.CoreAssets.Infrastructure.Data.Point> points = PolygonsDrawingEngine.MyCreateListOfPointsWithoutThoseFromCircularShapes(polygonsDrawingData.Polygons, isSectionCircular, isOpeningCircular);
				this.DrawPoints(pointsDrawingResult, points, polygonsDrawingData.PointColor.Value, polygonsDrawingData.PointSize.Value, polygonsDrawingData.VerticalOffsetOfNode.GetValueOrDefault());
			}
			return existingDrawingResult;
		}

		// Token: 0x06004F6B RID: 20331 RVA: 0x000421F5 File Offset: 0x000403F5
		public IPolygonsDrawingResult DrawPolygonsWithoutSurface(PolygonsDrawingData polygonsDrawingData, IPolygonsDrawingResult existingDrawingResult, bool isSectionCircular, bool isOpeningCircular)
		{
			#X0d.#V0d(polygonsDrawingData, #Phc.#3hc(107467578), Component.DesktopControls, #Phc.#3hc(107466931));
			this.DrawSurfacesAndLinesAndCreatePoints(polygonsDrawingData, ref existingDrawingResult, false);
			return existingDrawingResult;
		}

		// Token: 0x06004F6C RID: 20332 RVA: 0x0015BCBC File Offset: 0x00159EBC
		public void DrawPoints(IPointsDrawingResult pointsDrawingResult, IEnumerable<StructurePoint.CoreAssets.Infrastructure.Data.Point> points, Color color, double pointSize, double offset)
		{
			#X0d.#V0d(pointsDrawingResult, #Phc.#3hc(107466878), Component.DesktopControls, #Phc.#3hc(107466817));
			#X0d.#V0d(points, #Phc.#3hc(107358670), Component.DesktopControls, #Phc.#3hc(107466764));
			pointsDrawingResult.PointColor = color;
			pointsDrawingResult.PointSize = pointSize;
			pointsDrawingResult.Points = PointsConverter.#vsc(points.Distinct<StructurePoint.CoreAssets.Infrastructure.Data.Point>(), offset);
		}

		// Token: 0x06004F6D RID: 20333 RVA: 0x0015BD30 File Offset: 0x00159F30
		public void DrawLines(PolygonsDrawingData polygonsDrawingData, IPolygonsDrawingResult polygonsDrawingResult, double offset)
		{
			#X0d.#V0d(polygonsDrawingData, #Phc.#3hc(107467578), Component.DesktopControls, #Phc.#3hc(107467255));
			#X0d.#V0d(polygonsDrawingResult, #Phc.#3hc(107467170), Component.DesktopControls, #Phc.#3hc(107467141));
			foreach (PolygonDrawingData polygonDrawingData in polygonsDrawingData.Polygons)
			{
				List<StructurePoint.CoreAssets.Infrastructure.Data.Point3D> points = PointsConverter.#vsc(polygonDrawingData.Points, offset + 0.002);
				if (!polygonDrawingData.IsOpening && polygonsDrawingData.OuterLinesFormat != null)
				{
					IPolylineDrawingResult polylineDrawingResult = this.drawingResultsFactory.CreatePolylineDrawingResult();
					LinesDrawingEngine.DrawPolyLine(polylineDrawingResult.Cast(), points, polygonsDrawingData.OuterLinesFormat);
					polygonsDrawingResult.AddOuterEdge(polylineDrawingResult);
				}
				else if (polygonDrawingData.IsOpening && polygonsDrawingData.InnerLinesFormat != null)
				{
					IPolylineDrawingResult polylineDrawingResult2 = this.drawingResultsFactory.CreatePolylineDrawingResult();
					LinesDrawingEngine.DrawPolyLine(polylineDrawingResult2.Cast(), points, polygonsDrawingData.InnerLinesFormat);
					polygonsDrawingResult.AddInnerEdge(polylineDrawingResult2);
				}
			}
		}

		// Token: 0x06004F6E RID: 20334 RVA: 0x0015BE58 File Offset: 0x0015A058
		public IPolygonsDrawingResult DrawSurfaces(PolygonsDrawingData polygonsDrawingData, IPolygonsDrawingResult currentPolygonsDrawingResult)
		{
			#X0d.#V0d(polygonsDrawingData, #Phc.#3hc(107467578), Component.DesktopControls, #Phc.#3hc(107467120));
			if (currentPolygonsDrawingResult != null)
			{
				currentPolygonsDrawingResult.Cast().ClearVisualModels();
			}
			else
			{
				currentPolygonsDrawingResult = this.drawingResultsFactory.CreatePolygonsDrawingResult();
			}
			this.MyDrawSurfaces(polygonsDrawingData, currentPolygonsDrawingResult);
			return currentPolygonsDrawingResult;
		}

		// Token: 0x06004F6F RID: 20335 RVA: 0x0015BEB4 File Offset: 0x0015A0B4
		private void MyDrawSurfaces(PolygonsDrawingData polygonsDrawingData, IPolygonsDrawingResult polygonsDrawingResult)
		{
			Color? outerSurfacesFillColor = polygonsDrawingData.OuterSurfacesFillColor;
			if (outerSurfacesFillColor == null)
			{
				return;
			}
			double valueOrDefault = polygonsDrawingData.VerticalOffsetOfShape.GetValueOrDefault();
			IReadOnlyList<SystemTriangleData> triangles = this.drawingTriangulator.Triangulate(polygonsDrawingData.Polygons, valueOrDefault);
			MeshBuilder meshBuilder = new MeshBuilder(false, false);
			PolygonsDrawingEngine.AppendTriangles(meshBuilder, triangles);
			if (polygonsDrawingData.Height != null)
			{
				double valueOrDefault2 = polygonsDrawingData.Height.GetValueOrDefault();
				PolygonsDrawingEngine.AppendTriangles(meshBuilder, triangles, valueOrDefault + valueOrDefault2);
				PolygonsDrawingEngine.AppendVerticalSurfaces(meshBuilder, polygonsDrawingData.Polygons[0].Points, valueOrDefault, valueOrDefault2);
				MeshBuilder meshBuilder2 = new MeshBuilder();
				foreach (PolygonDrawingData polygonDrawingData in polygonsDrawingData.Polygons)
				{
					if (polygonDrawingData.IsOpening)
					{
						if (polygonsDrawingData.InnerSurfacesFillColor != null)
						{
							PolygonsDrawingEngine.AppendVerticalSurfaces(meshBuilder2, polygonDrawingData.Points, valueOrDefault, valueOrDefault2);
						}
					}
					else
					{
						PolygonsDrawingEngine.AppendVerticalSurfaces(meshBuilder, polygonDrawingData.Points, valueOrDefault, valueOrDefault2);
					}
				}
				if (polygonsDrawingData.InnerSurfacesFillColor != null)
				{
					MeshGeometry3D meshGeometry = meshBuilder2.ToMesh(true);
					polygonsDrawingResult.Cast().InnerPolygonModelVisual3D.MeshGeometry = meshGeometry;
					polygonsDrawingResult.Cast().InnerSurfacesFillColor = polygonsDrawingData.InnerSurfacesFillColor.Value;
					polygonsDrawingResult.Cast().InnerPolygonModelVisual3D.Visible = (polygonsDrawingResult.SurfacesVisibility == Visibility.Visible);
				}
			}
			MeshGeometry3D meshGeometry2 = meshBuilder.ToMesh(true);
			polygonsDrawingResult.Cast().OuterPolygonModelVisual3D.MeshGeometry = meshGeometry2;
			polygonsDrawingResult.Cast().OuterSurfacesFillColor = polygonsDrawingData.OuterSurfacesFillColor.Value;
			polygonsDrawingResult.Cast().OuterPolygonModelVisual3D.Visible = (polygonsDrawingResult.SurfacesVisibility == Visibility.Visible);
		}

		// Token: 0x06004F70 RID: 20336 RVA: 0x0015C09C File Offset: 0x0015A29C
		internal static void AppendVerticalSurfaces(MeshBuilder meshBuilder, IReadOnlyList<StructurePoint.CoreAssets.Infrastructure.Data.Point> points, double offset, double thickness)
		{
			List<StructurePoint.CoreAssets.Infrastructure.Data.Point3D> list = PointsConverter.#vsc(points).ToList<StructurePoint.CoreAssets.Infrastructure.Data.Point3D>();
			for (int i = 1; i < list.Count; i++)
			{
				StructurePoint.CoreAssets.Infrastructure.Data.Point3D point3D = PointsConverter.#Bsc(list[i - 1], offset);
				StructurePoint.CoreAssets.Infrastructure.Data.Point3D point3D2 = PointsConverter.#Bsc(list[i], offset);
				StructurePoint.CoreAssets.Infrastructure.Data.Point3D point = PointsConverter.#Bsc(point3D, thickness);
				StructurePoint.CoreAssets.Infrastructure.Data.Point3D point2 = PointsConverter.#Bsc(point3D2, thickness);
				meshBuilder.AddTriangle(point3D.Convert(), point3D2.Convert(), point.Convert());
				meshBuilder.AddTriangle(point3D2.Convert(), point.Convert(), point2.Convert());
			}
		}

		// Token: 0x06004F71 RID: 20337 RVA: 0x0015C148 File Offset: 0x0015A348
		internal static void AppendTriangles(MeshBuilder meshBuilder, IReadOnlyList<SystemTriangleData> triangles, double offset)
		{
			int additionalCapacity = triangles.Count * 3 + 3;
			meshBuilder.Positions.EnsureCapacity(additionalCapacity);
			meshBuilder.TriangleIndices.EnsureCapacity(additionalCapacity);
			foreach (SystemTriangleData systemTriangleData in triangles)
			{
				System.Windows.Media.Media3D.Point3D point = systemTriangleData.Point1;
				System.Windows.Media.Media3D.Point3D point2 = systemTriangleData.Point2;
				System.Windows.Media.Media3D.Point3D point3 = systemTriangleData.Point3;
				point = new System.Windows.Media.Media3D.Point3D(point.X, point.Y, offset);
				point2 = new System.Windows.Media.Media3D.Point3D(point2.X, point2.Y, offset);
				point3 = new System.Windows.Media.Media3D.Point3D(point3.X, point3.Y, offset);
				meshBuilder.AddTriangle(point, point2, point3);
			}
		}

		// Token: 0x06004F72 RID: 20338 RVA: 0x0015C234 File Offset: 0x0015A434
		internal static void AppendTriangles(MeshBuilder meshBuilder, IReadOnlyList<SystemTriangleData> triangles)
		{
			int additionalCapacity = triangles.Count * 3 + 3;
			meshBuilder.Positions.EnsureCapacity(additionalCapacity);
			meshBuilder.TriangleIndices.EnsureCapacity(additionalCapacity);
			foreach (SystemTriangleData systemTriangleData in triangles)
			{
				meshBuilder.AddTriangle(systemTriangleData.Point1, systemTriangleData.Point2, systemTriangleData.Point3);
			}
		}

		// Token: 0x06004F73 RID: 20339 RVA: 0x0004222A File Offset: 0x0004042A
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public static List<StructurePoint.CoreAssets.Infrastructure.Data.Point> CreateListOfPointsWithoutThoseFromCircularShapes(IEnumerable<PolygonData> polygons, bool isSectionCircular, bool isOpeningCircular)
		{
			return PolygonsDrawingEngine.MyCreateListOfPointsWithoutThoseFromCircularShapes((from item in polygons
			select new PolygonDrawingData(item.Points2D, item.IsOpening)).ToList<PolygonDrawingData>(), isSectionCircular, isOpeningCircular);
		}

		// Token: 0x06004F74 RID: 20340 RVA: 0x0015C2C4 File Offset: 0x0015A4C4
		private IPointsDrawingResult DrawSurfacesAndLinesAndCreatePoints(PolygonsDrawingData polygonsDrawingData, ref IPolygonsDrawingResult existingDrawingResult, bool drawSurfaces)
		{
			if (existingDrawingResult != null)
			{
				existingDrawingResult.Cast().ClearVisualModels();
			}
			else
			{
				existingDrawingResult = this.drawingResultsFactory.CreatePolygonsDrawingResult();
			}
			if (drawSurfaces)
			{
				this.MyDrawSurfaces(polygonsDrawingData, existingDrawingResult);
			}
			this.DrawLines(polygonsDrawingData, existingDrawingResult.Cast(), polygonsDrawingData.VerticalOffsetOfEdge.GetValueOrDefault());
			IPointsDrawingResult pointsDrawingResult = existingDrawingResult.PointsModelDrawingResult;
			if (pointsDrawingResult == null)
			{
				pointsDrawingResult = this.drawingResultsFactory.CreatePointsDrawingResult();
			}
			existingDrawingResult.Cast().PointsModelDrawingResult = pointsDrawingResult;
			return pointsDrawingResult;
		}

		// Token: 0x06004F75 RID: 20341 RVA: 0x0015C350 File Offset: 0x0015A550
		private static List<StructurePoint.CoreAssets.Infrastructure.Data.Point> MyCreateListOfPointsWithoutThoseFromCircularShapes(IReadOnlyList<PolygonDrawingData> polygons, bool isSectionCircular, bool isOpeningCircular)
		{
			List<StructurePoint.CoreAssets.Infrastructure.Data.Point> list = new List<StructurePoint.CoreAssets.Infrastructure.Data.Point>();
			if (polygons.Count > 0)
			{
				if (isSectionCircular)
				{
					PolygonsDrawingEngine.MyAddExtremePointsToList(list, polygons[0].Points);
				}
				else
				{
					foreach (StructurePoint.CoreAssets.Infrastructure.Data.Point item in polygons[0].Points)
					{
						list.Add(item);
					}
				}
			}
			if (polygons.Count > 1)
			{
				if (isOpeningCircular)
				{
					PolygonsDrawingEngine.MyAddExtremePointsToList(list, polygons[1].Points);
				}
				else
				{
					foreach (StructurePoint.CoreAssets.Infrastructure.Data.Point item2 in polygons[1].Points)
					{
						list.Add(item2);
					}
				}
			}
			return list;
		}

		// Token: 0x06004F76 RID: 20342 RVA: 0x0015C44C File Offset: 0x0015A64C
		private static void MyAddExtremePointsToList(List<StructurePoint.CoreAssets.Infrastructure.Data.Point> list, IReadOnlyList<StructurePoint.CoreAssets.Infrastructure.Data.Point> points)
		{
			double num = points.Max((StructurePoint.CoreAssets.Infrastructure.Data.Point item) => item.X);
			double num2 = points.Max((StructurePoint.CoreAssets.Infrastructure.Data.Point item) => item.Y);
			double num3 = points.Min((StructurePoint.CoreAssets.Infrastructure.Data.Point item) => item.X);
			double num4 = points.Min((StructurePoint.CoreAssets.Infrastructure.Data.Point item) => item.Y);
			list.Add(new StructurePoint.CoreAssets.Infrastructure.Data.Point(num, (num4 + num2) / 2.0));
			list.Add(new StructurePoint.CoreAssets.Infrastructure.Data.Point((num3 + num) / 2.0, num2));
			list.Add(new StructurePoint.CoreAssets.Infrastructure.Data.Point(num3, (num4 + num2) / 2.0));
			list.Add(new StructurePoint.CoreAssets.Infrastructure.Data.Point((num3 + num) / 2.0, num4));
		}

		// Token: 0x040022BA RID: 8890
		private const double ConstPointsRelativeOffset = 0.001;

		// Token: 0x040022BB RID: 8891
		private const double ConstLinesRelativeOffset = 0.001;

		// Token: 0x040022BC RID: 8892
		private const int ConstSectionPolygonIndex = 0;

		// Token: 0x040022BD RID: 8893
		private const int ConstOpeningPolygonIndex = 1;

		// Token: 0x040022BE RID: 8894
		private readonly IDrawingResultsFactory drawingResultsFactory;

		// Token: 0x040022BF RID: 8895
		private readonly IDrawingTriangulator drawingTriangulator;
	}
}
