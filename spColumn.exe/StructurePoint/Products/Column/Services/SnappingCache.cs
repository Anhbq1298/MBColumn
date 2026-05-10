using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;
using #eU;
using #Fmc;
using devDept.Geometry;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Tools;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.Drawing;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Logger;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.Services.API;

namespace StructurePoint.Products.Column.Services
{
	// Token: 0x020002BF RID: 703
	internal sealed class SnappingCache : #0V
	{
		// Token: 0x06001879 RID: 6265 RVA: 0x000B64D0 File Offset: 0x000B46D0
		public SnappingCache(ISettingsManager settings, ILogger logger)
		{
			this.#b = settings;
			this.#c = logger;
			this.ShapeToDrawingGridIntersections.EnsureTotalCapacity(2500);
			this.ShapeToShapeIntersections.EnsureTotalCapacity(2500);
		}

		// Token: 0x17000910 RID: 2320
		// (get) Token: 0x0600187A RID: 6266 RVA: 0x00018C7C File Offset: 0x00016E7C
		public List<devDept.Geometry.Point3D> Shapes { get; }

		// Token: 0x17000911 RID: 2321
		// (get) Token: 0x0600187B RID: 6267 RVA: 0x00018C88 File Offset: 0x00016E88
		public List<devDept.Geometry.Point3D> Centroids { get; }

		// Token: 0x17000912 RID: 2322
		// (get) Token: 0x0600187C RID: 6268 RVA: 0x00018C94 File Offset: 0x00016E94
		public List<devDept.Geometry.Point3D> ShapeMidpoints { get; }

		// Token: 0x17000913 RID: 2323
		// (get) Token: 0x0600187D RID: 6269 RVA: 0x00018CA0 File Offset: 0x00016EA0
		public List<List<devDept.Geometry.Point3D>> CoverLines { get; }

		// Token: 0x17000914 RID: 2324
		// (get) Token: 0x0600187E RID: 6270 RVA: 0x00018CAC File Offset: 0x00016EAC
		public List<devDept.Geometry.Point3D> CoverPoints { get; }

		// Token: 0x17000915 RID: 2325
		// (get) Token: 0x0600187F RID: 6271 RVA: 0x00018CB8 File Offset: 0x00016EB8
		public List<devDept.Geometry.Point3D> CoverShapeIntersections { get; }

		// Token: 0x17000916 RID: 2326
		// (get) Token: 0x06001880 RID: 6272 RVA: 0x00018CC4 File Offset: 0x00016EC4
		public List<devDept.Geometry.Point3D> CoverSelfIntersections { get; }

		// Token: 0x17000917 RID: 2327
		// (get) Token: 0x06001881 RID: 6273 RVA: 0x00018CD0 File Offset: 0x00016ED0
		public List<devDept.Geometry.Point3D> CoverMidPoints { get; }

		// Token: 0x17000918 RID: 2328
		// (get) Token: 0x06001882 RID: 6274 RVA: 0x00018CDC File Offset: 0x00016EDC
		public List<devDept.Geometry.Point3D> CoverDrawingGridIntersections { get; }

		// Token: 0x17000919 RID: 2329
		// (get) Token: 0x06001883 RID: 6275 RVA: 0x00018CE8 File Offset: 0x00016EE8
		public List<List<devDept.Geometry.Point3D>> ShapeEdges { get; }

		// Token: 0x1700091A RID: 2330
		// (get) Token: 0x06001884 RID: 6276 RVA: 0x00018CF4 File Offset: 0x00016EF4
		public List<devDept.Geometry.Point3D> ReinforcementBars { get; }

		// Token: 0x1700091B RID: 2331
		// (get) Token: 0x06001885 RID: 6277 RVA: 0x00018D00 File Offset: 0x00016F00
		public List<devDept.Geometry.Point3D> ShapeToShapeIntersections { get; }

		// Token: 0x1700091C RID: 2332
		// (get) Token: 0x06001886 RID: 6278 RVA: 0x00018D0C File Offset: 0x00016F0C
		public List<devDept.Geometry.Point3D> ShapeToDrawingGridIntersections { get; }

		// Token: 0x1700091D RID: 2333
		// (get) Token: 0x06001887 RID: 6279 RVA: 0x00018D18 File Offset: 0x00016F18
		public List<devDept.Geometry.Point3D> TemporaryPoints { get; }

		// Token: 0x06001888 RID: 6280 RVA: 0x00018D24 File Offset: 0x00016F24
		public static List<devDept.Geometry.Point3D> #qP(ShapeModel #rP, double #sP)
		{
			if (#rP.Application == PolygonApplication.Solid)
			{
				return SnappingCache.#qP(#rP, #sP, true);
			}
			return SnappingCache.#qP(#rP, #sP, false);
		}

		// Token: 0x06001889 RID: 6281 RVA: 0x000B65B8 File Offset: 0x000B47B8
		public void #tP()
		{
			this.TemporaryPoints.Sort(EyeshotSnappingProviderBase.PointComparer);
			this.TemporaryPoints.#31d(new Func<devDept.Geometry.Point3D, devDept.Geometry.Point3D, bool>(SnappingCache.<>c.<>9.#e0b));
		}

		// Token: 0x0600188A RID: 6282 RVA: 0x000B660C File Offset: 0x000B480C
		public void #wP(ColumnModel #Od)
		{
			this.CoverLines.Clear();
			this.CoverPoints.Clear();
			double num = this.#b.RuntimeSettings.Cover;
			double num2 = this.#b.RuntimeSettings.BarRadius;
			if (num <= 0.0)
			{
				return;
			}
			if (this.#b.RuntimeSettings.CoverType == #fU.#a)
			{
				num += num2;
			}
			for (int i = 0; i < #Od.Shapes.Count; i++)
			{
				ShapeModel #rP = #Od.Shapes[i];
				try
				{
					List<devDept.Geometry.Point3D> list = SnappingCache.#qP(#rP, num);
					this.CoverLines.Add(list);
					this.CoverPoints.AddRange(list);
				}
				catch (Exception exception)
				{
					SnappingCache.#0Zb #0Zb = new SnappingCache.#0Zb();
					#0Zb.#a = i;
					this.#c.Log(LoggingLevel.Warning, new Func<string>(#0Zb.#k0b), exception);
				}
			}
			this.#AP(this.CoverPoints);
		}

		// Token: 0x0600188B RID: 6283 RVA: 0x000B6724 File Offset: 0x000B4924
		public void #uP(#oW #xn)
		{
			ColumnModel columnModel = #xn.Model;
			this.#zP(#xn);
			this.#wP(columnModel);
			this.#FP(columnModel);
			this.ReinforcementBars.Clear();
			this.ReinforcementBars.AddRange(columnModel.ReinforcementBars.Select(new Func<ReinforcementBar, devDept.Geometry.Point3D>(SnappingCache.<>c.<>9.#8Yh)));
			this.#AP(this.ReinforcementBars);
			this.#CP(this.CoverSelfIntersections, this.CoverLines, this.CoverLines);
			this.#CP(this.CoverShapeIntersections, this.CoverLines, this.ShapeEdges);
			this.#xP(this.ShapeMidpoints, this.ShapeEdges);
			this.#xP(this.CoverMidPoints, this.CoverLines);
			this.#GP(this.CoverDrawingGridIntersections, this.CoverLines, 50000);
			this.#GP(this.ShapeToDrawingGridIntersections, this.ShapeEdges, 50000);
		}

		// Token: 0x0600188C RID: 6284 RVA: 0x000B683C File Offset: 0x000B4A3C
		private static List<devDept.Geometry.Point3D> #qP(ShapeModel #rP, double #sP, bool #vP)
		{
			List<devDept.Geometry.Point3D> list = new List<devDept.Geometry.Point3D>();
			if (#sP <= 0.0 || #rP.PolygonsCount <= 0)
			{
				return list;
			}
			PolygonData polygonData = #rP.#cxc(0);
			if (polygonData == null)
			{
				return list;
			}
			IList<Point> list2 = BooleanOperationsHelper.#Rlc(polygonData.Points2D, (#vP ? -1.0 : 1.0) * #sP);
			if (list2 != null && list2.Count >= 2)
			{
				if (Point.#F3d(list2.First<Point>(), list2.Last<Point>()))
				{
					list2.Add(list2.First<Point>());
				}
				list.AddRange(list2.Select(new Func<Point, devDept.Geometry.Point3D>(SnappingCache.<>c.<>9.#9Yh)));
			}
			return list;
		}

		// Token: 0x0600188D RID: 6285 RVA: 0x000B6910 File Offset: 0x000B4B10
		private void #xP(List<devDept.Geometry.Point3D> #En, List<List<devDept.Geometry.Point3D>> #yP)
		{
			#En.Clear();
			foreach (List<devDept.Geometry.Point3D> list in #yP)
			{
				for (int i = 1; i < list.Count; i++)
				{
					devDept.Geometry.Point3D point3D = list[i - 1];
					devDept.Geometry.Point3D point3D2 = list[i];
					#En.Add(new devDept.Geometry.Point3D((point3D.X + point3D2.X) / 2.0, (point3D.Y + point3D2.Y) / 2.0));
				}
			}
			this.#AP(#En);
		}

		// Token: 0x0600188E RID: 6286 RVA: 0x000B69E4 File Offset: 0x000B4BE4
		private void #zP(#oW #xn)
		{
			this.Centroids.Clear();
			this.Shapes.Clear();
			this.ShapeEdges.Clear();
			if (#xn.Metadata.SectionCentroid != null)
			{
				this.Centroids.Add(#xn.Metadata.SectionCentroid);
			}
			foreach (ShapeModel shapeModel in #xn.Model.Shapes)
			{
				foreach (PolygonData polygonData in shapeModel.Polygons)
				{
					List<devDept.Geometry.Point3D> list = polygonData.Points2D.Select(new Func<Point, devDept.Geometry.Point3D>(SnappingCache.<>c.<>9.#h0b)).ToList<devDept.Geometry.Point3D>();
					this.Shapes.AddRange(list);
					this.ShapeEdges.Add(list);
				}
				Point? point = shapeModel.#gxc();
				if (point != null)
				{
					this.Centroids.Add(point.Value.#TW());
				}
			}
			this.#AP(this.Shapes);
			this.#AP(this.Centroids);
		}

		// Token: 0x0600188F RID: 6287 RVA: 0x00018D4B File Offset: 0x00016F4B
		private void #AP(List<devDept.Geometry.Point3D> #BP)
		{
			#BP.Sort(EyeshotSnappingProviderBase.PointComparer);
			#BP.#31d(new Func<devDept.Geometry.Point3D, devDept.Geometry.Point3D, bool>(SnappingCache.<>c.<>9.#i0b));
		}

		// Token: 0x06001890 RID: 6288 RVA: 0x000B6B64 File Offset: 0x000B4D64
		private void #CP(List<devDept.Geometry.Point3D> #En, List<List<devDept.Geometry.Point3D>> #DP, List<List<devDept.Geometry.Point3D>> #EP)
		{
			#En.Clear();
			foreach (List<devDept.Geometry.Point3D> list in #DP)
			{
				if (list.Count <= 200)
				{
					foreach (List<devDept.Geometry.Point3D> list2 in #EP)
					{
						if (list != list2 && list2.Count <= 200)
						{
							for (int i = 1; i < list.Count; i++)
							{
								for (int j = 1; j < list2.Count; j++)
								{
									devDept.Geometry.Point3D startPoint = list[i - 1];
									devDept.Geometry.Point3D endPoint = list[i];
									devDept.Geometry.Point3D startPoint2 = list2[j - 1];
									devDept.Geometry.Point3D endPoint2 = list2[j];
									Point2D point2D = EyeshotGeometry.Intersection(startPoint, endPoint, startPoint2, endPoint2, true);
									if (point2D != null)
									{
										#En.Add(new devDept.Geometry.Point3D(point2D.X, point2D.Y));
									}
								}
							}
						}
					}
				}
			}
			this.#AP(#En);
		}

		// Token: 0x06001891 RID: 6289 RVA: 0x000B6CCC File Offset: 0x000B4ECC
		private void #FP(ColumnModel #Od)
		{
			List<devDept.Geometry.Point3D> list = this.ShapeToShapeIntersections;
			if (!false)
			{
				list.Clear();
			}
			List<ShapeModel> list2 = #Od.Shapes.Where(new Func<ShapeModel, bool>(SnappingCache.<>c.<>9.#j0b)).ToList<ShapeModel>();
			foreach (ShapeModel shapeModel in list2)
			{
				if (shapeModel.Polygons.Count == 1)
				{
					List<SegmentData> list3 = shapeModel.Polygons[0].Segments;
					BoundingBoxData boundingBoxData = shapeModel.Polygons[0].BoundingBoxData;
					foreach (ShapeModel shapeModel2 in list2)
					{
						SnappingCache.#UZb #UZb = new SnappingCache.#UZb();
						#UZb.#b = this;
						if (shapeModel2 != shapeModel && shapeModel2.Polygons.Count == 1 && boundingBoxData.#7lc(shapeModel2.Polygons[0].BoundingBoxData))
						{
							#UZb.#a = shapeModel2.Polygons[0].Segments;
							list3.ForEach(new Action<SegmentData>(#UZb.#m0b));
						}
					}
				}
			}
			this.#AP(this.ShapeToShapeIntersections);
		}

		// Token: 0x06001892 RID: 6290 RVA: 0x000B6E5C File Offset: 0x000B505C
		private void #GP(List<devDept.Geometry.Point3D> #En, List<List<devDept.Geometry.Point3D>> #yP, int #2Uh)
		{
			if (this.#b.DrawingGrid == null)
			{
				return;
			}
			#En.Clear();
			foreach (List<devDept.Geometry.Point3D> list in #yP)
			{
				SnappingCache.#cVb #cVb = new SnappingCache.#cVb();
				if (list.Count >= 3 && list.Count <= 200)
				{
					EyeshotBoundingBoxDataLight eyeshotBoundingBoxDataLight = new EyeshotBoundingBoxDataLight(list);
					#cVb.#c = eyeshotBoundingBoxDataLight.MinX;
					#cVb.#d = eyeshotBoundingBoxDataLight.MaxX;
					#cVb.#b = eyeshotBoundingBoxDataLight.MaxY;
					#cVb.#a = eyeshotBoundingBoxDataLight.MinY;
					IEnumerable<double> source = this.#KP(#cVb.#c, #cVb.#d, this.#b.DrawingGrid.SpacingX);
					IEnumerable<double> source2 = this.#KP(#cVb.#a, #cVb.#b, this.#b.DrawingGrid.SpacingY);
					IEnumerable<Tuple<Point2D, Point2D>> first = source.Select(new Func<double, Tuple<Point2D, Point2D>>(#cVb.#n0b));
					IEnumerable<Tuple<Point2D, Point2D>> second = source2.Select(new Func<double, Tuple<Point2D, Point2D>>(#cVb.#p0b));
					this.#HP(#En, first.Union(second), list);
					if (#En.Count > #2Uh)
					{
						break;
					}
				}
			}
			this.#AP(#En);
		}

		// Token: 0x06001893 RID: 6291 RVA: 0x000B6FD8 File Offset: 0x000B51D8
		private void #HP(List<devDept.Geometry.Point3D> #En, IEnumerable<Tuple<Point2D, Point2D>> #IP, IList<devDept.Geometry.Point3D> #JP)
		{
			IEnumerator<Tuple<Point2D, Point2D>> enumerator = #IP.GetEnumerator();
			IEnumerator<Tuple<Point2D, Point2D>> enumerator2;
			if (!false)
			{
				enumerator2 = enumerator;
			}
			try
			{
				while (enumerator2.MoveNext())
				{
					Tuple<Point2D, Point2D> tuple = enumerator2.Current;
					for (int i = 1; i < #JP.Count; i++)
					{
						devDept.Geometry.Point3D startPoint = #JP[i - 1];
						devDept.Geometry.Point3D endPoint = #JP[i];
						Point2D point2D = EyeshotGeometry.Intersection(startPoint, endPoint, tuple.Item1, tuple.Item2, true);
						if (point2D != null)
						{
							#En.Add(new devDept.Geometry.Point3D(point2D.X, point2D.Y));
						}
					}
				}
			}
			finally
			{
				if (enumerator2 != null)
				{
					enumerator2.Dispose();
				}
			}
		}

		// Token: 0x06001894 RID: 6292 RVA: 0x000B7098 File Offset: 0x000B5298
		private IEnumerable<double> #KP(double #LP, double #MP, double #NP)
		{
			List<double> list = new List<double>();
			int num = (int)Math.Ceiling((#MP - #LP) / #NP);
			if (num == 0)
			{
				return list;
			}
			double num2 = Math.Floor(#LP / #NP) * #NP;
			double num3 = num2 + (double)num * #NP;
			double num4 = num2;
			int num5 = 0;
			while (num4 <= num3 && num5 < this.#d)
			{
				list.Add(num4);
				num4 += #NP;
				num5++;
			}
			return list;
		}

		// Token: 0x06001895 RID: 6293 RVA: 0x000B7108 File Offset: 0x000B5308
		private void #OP(List<devDept.Geometry.Point3D> #En, SegmentData #PP, IEnumerable<SegmentData> #QP)
		{
			foreach (SegmentData segmentData in #QP)
			{
				if (#PP.#Xwc(segmentData))
				{
					Point? point = #jsc.#plc(#PP, segmentData);
					if (point != null)
					{
						#En.Add(new devDept.Geometry.Point3D(point.Value.X, point.Value.Y));
					}
				}
			}
		}

		// Token: 0x04000958 RID: 2392
		private const int #a = 200;

		// Token: 0x04000959 RID: 2393
		private readonly ISettingsManager #b;

		// Token: 0x0400095A RID: 2394
		private readonly ILogger #c;

		// Token: 0x0400095B RID: 2395
		private readonly int #d = 100000;

		// Token: 0x0400095C RID: 2396
		[CompilerGenerated]
		private readonly List<devDept.Geometry.Point3D> #e = new List<devDept.Geometry.Point3D>();

		// Token: 0x0400095D RID: 2397
		[CompilerGenerated]
		private readonly List<devDept.Geometry.Point3D> #f = new List<devDept.Geometry.Point3D>();

		// Token: 0x0400095E RID: 2398
		[CompilerGenerated]
		private readonly List<devDept.Geometry.Point3D> #g = new List<devDept.Geometry.Point3D>();

		// Token: 0x0400095F RID: 2399
		[CompilerGenerated]
		private readonly List<List<devDept.Geometry.Point3D>> #h = new List<List<devDept.Geometry.Point3D>>();

		// Token: 0x04000960 RID: 2400
		[CompilerGenerated]
		private readonly List<devDept.Geometry.Point3D> #i = new List<devDept.Geometry.Point3D>();

		// Token: 0x04000961 RID: 2401
		[CompilerGenerated]
		private readonly List<devDept.Geometry.Point3D> #j = new List<devDept.Geometry.Point3D>();

		// Token: 0x04000962 RID: 2402
		[CompilerGenerated]
		private readonly List<devDept.Geometry.Point3D> #k = new List<devDept.Geometry.Point3D>();

		// Token: 0x04000963 RID: 2403
		[CompilerGenerated]
		private readonly List<devDept.Geometry.Point3D> #l = new List<devDept.Geometry.Point3D>();

		// Token: 0x04000964 RID: 2404
		[CompilerGenerated]
		private readonly List<devDept.Geometry.Point3D> #m = new List<devDept.Geometry.Point3D>();

		// Token: 0x04000965 RID: 2405
		[CompilerGenerated]
		private readonly List<List<devDept.Geometry.Point3D>> #n = new List<List<devDept.Geometry.Point3D>>();

		// Token: 0x04000966 RID: 2406
		[CompilerGenerated]
		private readonly List<devDept.Geometry.Point3D> #o = new List<devDept.Geometry.Point3D>();

		// Token: 0x04000967 RID: 2407
		[CompilerGenerated]
		private readonly List<devDept.Geometry.Point3D> #p = new List<devDept.Geometry.Point3D>();

		// Token: 0x04000968 RID: 2408
		[CompilerGenerated]
		private readonly List<devDept.Geometry.Point3D> #q = new List<devDept.Geometry.Point3D>();

		// Token: 0x04000969 RID: 2409
		[CompilerGenerated]
		private readonly List<devDept.Geometry.Point3D> #r = new List<devDept.Geometry.Point3D>();

		// Token: 0x020002C1 RID: 705
		[CompilerGenerated]
		private sealed class #0Zb
		{
			// Token: 0x0600189F RID: 6303 RVA: 0x00018E0E File Offset: 0x0001700E
			internal string #k0b()
			{
				return string.Format(#Phc.#3hc(107380716), this.#a);
			}

			// Token: 0x04000971 RID: 2417
			public int #a;
		}

		// Token: 0x020002C2 RID: 706
		[CompilerGenerated]
		private sealed class #UZb
		{
			// Token: 0x060018A1 RID: 6305 RVA: 0x00018E36 File Offset: 0x00017036
			internal void #m0b(SegmentData #PP)
			{
				this.#b.#OP(this.#b.ShapeToShapeIntersections, #PP, this.#a);
			}

			// Token: 0x04000972 RID: 2418
			public List<SegmentData> #a;

			// Token: 0x04000973 RID: 2419
			public SnappingCache #b;
		}

		// Token: 0x020002C3 RID: 707
		[CompilerGenerated]
		private sealed class #cVb
		{
			// Token: 0x060018A3 RID: 6307 RVA: 0x00018E61 File Offset: 0x00017061
			internal Tuple<Point2D, Point2D> #n0b(double #o0b)
			{
				return new Tuple<Point2D, Point2D>(new Point2D(#o0b, this.#a - 1.0), new Point2D(#o0b, this.#b + 1.0));
			}

			// Token: 0x060018A4 RID: 6308 RVA: 0x00018EA0 File Offset: 0x000170A0
			internal Tuple<Point2D, Point2D> #p0b(double #q0b)
			{
				return new Tuple<Point2D, Point2D>(new Point2D(this.#c - 1.0, #q0b), new Point2D(this.#d + 1.0, #q0b));
			}

			// Token: 0x04000974 RID: 2420
			public double #a;

			// Token: 0x04000975 RID: 2421
			public double #b;

			// Token: 0x04000976 RID: 2422
			public double #c;

			// Token: 0x04000977 RID: 2423
			public double #d;
		}
	}
}
