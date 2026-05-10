using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;
using #eU;
using #f7;
using devDept.Geometry;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Tools;
using StructurePoint.Products.Column.Services.API;

namespace #RJb
{
	// Token: 0x0200067A RID: 1658
	internal sealed class #2Lb : EyeshotSnappingProviderBase
	{
		// Token: 0x060037C7 RID: 14279 RVA: 0x0010E030 File Offset: 0x0010C230
		public #2Lb(#0V #3Lb, ISettingsManager #ng, EyeshotEditor #iBb)
		{
			if (#3Lb == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107351897));
			}
			this.#d = #3Lb;
			if (#ng == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107382678));
			}
			this.#a = #ng;
			if (#iBb == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107351888));
			}
			this.#b = #iBb;
		}

		// Token: 0x17001148 RID: 4424
		// (get) Token: 0x060037C8 RID: 14280 RVA: 0x000306FF File Offset: 0x0002E8FF
		public #0V Cache { get; }

		// Token: 0x060037C9 RID: 14281 RVA: 0x0010E0AC File Offset: 0x0010C2AC
		public double #NLb()
		{
			int num = 10;
			double? num2 = this.#YLb();
			if (num2 == null)
			{
				return (double)num;
			}
			return num2.Value * (double)num * 1.4;
		}

		// Token: 0x060037CA RID: 14282 RVA: 0x0003070B File Offset: 0x0002E90B
		public SnapToPointResult #OLb(#8Jb #mA, Point2D #Ng)
		{
			return this.#fEb(#mA, this.#ZLb(), #Ng);
		}

		// Token: 0x060037CB RID: 14283 RVA: 0x0010E0F0 File Offset: 0x0010C2F0
		public IEnumerable<Point3D> #PLb(Point3D #Kzb, #8Jb #mA, #LLb #QLb)
		{
			SnapPointsCollector #VLb = new SnapPointsCollector(#Kzb, SnapPointsCollectorMode.ClosestMatch);
			List<Point3D> list = new List<Point3D>();
			list.AddRange(this.Cache.TemporaryPoints);
			if (this.#0Lb(#VLb, #mA, #QLb, #LLb.#e))
			{
				list.AddRange(this.Cache.ShapeToShapeIntersections);
				if (this.#a.DrawingGrid.GridEnabled)
				{
					list.AddRange(this.Cache.ShapeToDrawingGridIntersections);
				}
			}
			if (this.#0Lb(#VLb, #mA, #QLb, #LLb.#d))
			{
				list.AddRange(this.Cache.Centroids);
			}
			if (this.#0Lb(#VLb, #mA, #QLb, #LLb.#c))
			{
				list.AddRange(this.Cache.ReinforcementBars);
				list.AddRange(this.Cache.ShapeMidpoints);
				list.AddRange(this.Cache.Shapes);
			}
			return list;
		}

		// Token: 0x060037CC RID: 14284 RVA: 0x0010E1DC File Offset: 0x0010C3DC
		public SnapToPointResult #RLb(#8Jb #mA, #LLb #QLb, OrthoController #SLb, Point2D #Ng)
		{
			#2Lb.#oWb #oWb = new #2Lb.#oWb();
			if (!#SLb.IsOrthoActive)
			{
				return this.#fEb(#mA, #QLb, #Ng);
			}
			Point3D point3D = new Point3D(#Ng.X, #Ng.Y);
			#oWb.#b = new Point3D(point3D.X, point3D.Y);
			#SLb.ApplyConstraintsOnPosition(#oWb.#b);
			IEnumerable<Point3D> source = this.#PLb(point3D, #mA, #QLb);
			#oWb.#a = #SLb.GetNearestAxis(point3D);
			IEnumerable<Point3D> source2 = source.Select(new Func<Point3D, Point3D>(#oWb.#icc));
			#oWb.#c = this.#NLb();
			Point3D point3D2 = source2.Where(new Func<Point3D, bool>(#oWb.#kcc)).OrderBy(new Func<Point3D, double>(#oWb.#mcc)).FirstOrDefault<Point3D>();
			return this.#fEb(#mA, #QLb, point3D2 ?? point3D);
		}

		// Token: 0x060037CD RID: 14285 RVA: 0x0010E2C8 File Offset: 0x0010C4C8
		public SnapToPointResult #fEb(#8Jb #mA, #LLb #QLb, Point2D #Ng)
		{
			if (#Ng == null)
			{
				return new SnapToPointResult(null, null);
			}
			SnapPointsCollector snapPointsCollector = new SnapPointsCollector(new Point3D(#Ng.X, #Ng.Y), SnapPointsCollectorMode.ClosestMatch);
			double #WLb = this.#NLb();
			this.#ULb(snapPointsCollector, #mA, #QLb, #Ng, #WLb);
			if (snapPointsCollector.HasValidResult)
			{
				return snapPointsCollector.RetrieveResult();
			}
			snapPointsCollector.ResetResults();
			this.#XLb(snapPointsCollector, #mA, #QLb, #Ng, #WLb);
			return snapPointsCollector.RetrieveResult();
		}

		// Token: 0x060037CE RID: 14286 RVA: 0x00030727 File Offset: 0x0002E927
		public Point3D #TLb(Point2D #Ng)
		{
			if (#Ng == null)
			{
				return null;
			}
			return base.PerformSnap(this.Cache.ReinforcementBars, #Ng, this.#NLb());
		}

		// Token: 0x060037CF RID: 14287 RVA: 0x0010E344 File Offset: 0x0010C544
		private void #ULb(SnapPointsCollector #VLb, #8Jb #mA, #LLb #QLb, Point2D #Ng, double #WLb)
		{
			#VLb.Collect(base.PerformSnap(this.Cache.TemporaryPoints, #Ng, #WLb), #LLb.#g);
			if (this.#0Lb(#VLb, #mA, #QLb, #LLb.#m))
			{
				#VLb.Collect(base.PerformSnap(this.#c, #Ng, #WLb), #LLb.#m);
			}
			if (this.#0Lb(#VLb, #mA, #QLb, #LLb.#j))
			{
				#VLb.Collect(base.PerformSnap(this.Cache.ReinforcementBars, #Ng, #WLb), #LLb.#c);
			}
			if (this.#0Lb(#VLb, #mA, #QLb, #LLb.#e))
			{
				if (this.#a.DrawingGrid.GridEnabled)
				{
					#VLb.Collect(base.PerformSnap(this.Cache.ShapeToDrawingGridIntersections, #Ng, #WLb), #LLb.#e);
				}
				#VLb.Collect(base.PerformSnap(this.Cache.ShapeToShapeIntersections, #Ng, #WLb), #LLb.#e);
				if (#mA.ShowCover)
				{
					#VLb.Collect(base.PerformSnap(this.Cache.CoverShapeIntersections, #Ng, #WLb), #LLb.#e);
					#VLb.Collect(base.PerformSnap(this.Cache.CoverSelfIntersections, #Ng, #WLb), #LLb.#e);
				}
			}
			if (this.#0Lb(#VLb, #mA, #QLb, #LLb.#k))
			{
				#VLb.Collect(base.PerformSnap(this.Cache.CoverMidPoints, #Ng, #WLb), #LLb.#k);
				#VLb.Collect(base.PerformSnap(this.Cache.CoverPoints, #Ng, #WLb), #LLb.#k);
				if (this.#a.DrawingGrid.GridEnabled)
				{
					#VLb.Collect(base.PerformSnap(this.Cache.CoverDrawingGridIntersections, #Ng, #WLb), #LLb.#k);
				}
			}
			if (this.#0Lb(#VLb, #mA, #QLb, #LLb.#d))
			{
				#VLb.Collect(base.PerformSnap(this.Cache.Centroids, #Ng, #WLb), #LLb.#d);
			}
			if (this.#0Lb(#VLb, #mA, #QLb, #LLb.#c))
			{
				#VLb.Collect(base.PerformSnap(this.Cache.ShapeMidpoints, #Ng, #WLb), #LLb.#c);
				#VLb.Collect(base.PerformSnap(this.Cache.Shapes, #Ng, #WLb), #LLb.#c);
			}
			if (this.#0Lb(#VLb, #mA, #QLb, #LLb.#b))
			{
				#VLb.Collect(base.PerformSnap(#Ng, this.#a.SnappingSettings.SnapSpacingX, this.#a.SnappingSettings.SnapSpacingY, #WLb), #LLb.#b);
			}
			if (this.#0Lb(#VLb, #mA, #QLb, #LLb.#f))
			{
				#VLb.Collect(base.PerformSnap(#Ng, this.#a.DrawingGrid.SpacingX, this.#a.DrawingGrid.SpacingY, #WLb), #LLb.#f);
			}
		}

		// Token: 0x060037D0 RID: 14288 RVA: 0x0010E640 File Offset: 0x0010C840
		private void #XLb(SnapPointsCollector #VLb, #8Jb #mA, #LLb #QLb, Point2D #Ng, double #WLb)
		{
			if (this.#0Lb(#VLb, #mA, #QLb, #LLb.#i))
			{
				#VLb.Collect(base.PerformSnap(this.Cache.CoverLines, #Ng, #WLb), #LLb.#i);
			}
			if (this.#0Lb(#VLb, #mA, #QLb, #LLb.#l))
			{
				#VLb.Collect(base.PerformSnap(this.Cache.ShapeEdges, #Ng, #WLb), #LLb.#l);
			}
			if (this.#0Lb(#VLb, #mA, #QLb, #LLb.#f))
			{
				#VLb.Collect(base.PerformSnapGridLine(#Ng, this.#a.DrawingGrid.SpacingX, this.#a.DrawingGrid.SpacingY, #WLb), #LLb.#f);
			}
		}

		// Token: 0x060037D1 RID: 14289 RVA: 0x0010E71C File Offset: 0x0010C91C
		private double? #YLb()
		{
			Point3D lowerLeftWorldCoord = this.#b.LowerLeftWorldCoord;
			Point3D upperRightWorldCoord = this.#b.UpperRightWorldCoord;
			double value = upperRightWorldCoord.X - lowerLeftWorldCoord.X;
			double value2 = upperRightWorldCoord.Y - lowerLeftWorldCoord.Y;
			double val = Math.Abs(value) / this.#b.ActualWidth;
			double val2 = Math.Abs(value2) / this.#b.ActualHeight;
			return new double?(Math.Max(val, val2));
		}

		// Token: 0x060037D2 RID: 14290 RVA: 0x0010E7A0 File Offset: 0x0010C9A0
		private #LLb #ZLb()
		{
			#z7 #z = this.#a.SnappingSettings;
			#LLb #LLb = #LLb.#b;
			if (#z.SnapDrawingGrid)
			{
				#LLb |= #LLb.#f;
			}
			if (#z.SnapIntersection)
			{
				#LLb |= #LLb.#e;
			}
			if (#z.SnapToCover)
			{
				#LLb |= #LLb.#i;
			}
			if (#z.SnapReinforcement)
			{
				#LLb |= #LLb.#j;
			}
			if (#z.SnapObjectsCentroid)
			{
				#LLb |= #LLb.#d;
			}
			return #LLb;
		}

		// Token: 0x060037D3 RID: 14291 RVA: 0x0010E810 File Offset: 0x0010CA10
		private bool #0Lb(SnapPointsCollector #VLb, #8Jb #mA, #LLb #1Lb, #LLb #NHb)
		{
			if (#1Lb.HasFlag(#LLb.#h))
			{
				return true;
			}
			if (!#VLb.ShouldCollect || !#1Lb.HasFlag(#NHb))
			{
				return false;
			}
			#z7 #z = this.#a.SnappingSettings;
			if (#z == null)
			{
				return false;
			}
			if (#NHb > #LLb.#g)
			{
				if (#NHb <= #LLb.#j)
				{
					if (#NHb == #LLb.#h)
					{
						return true;
					}
					if (#NHb != #LLb.#i)
					{
						if (#NHb != #LLb.#j)
						{
							goto IL_1B7;
						}
						return #z.ObjectSnappingEnabled && #z.SnapReinforcement;
					}
				}
				else if (#NHb <= #LLb.#l)
				{
					if (#NHb != #LLb.#k)
					{
						if (#NHb != #LLb.#l)
						{
							goto IL_1B7;
						}
						goto IL_13C;
					}
				}
				else
				{
					if (#NHb == #LLb.#m)
					{
						return this.#a.ShowCoordinateSystemSign;
					}
					if (#NHb != #LLb.#n)
					{
						goto IL_1B7;
					}
					return true;
				}
				return #z.ObjectSnappingEnabled && #z.SnapToCover && #mA.ShowCover;
			}
			if (#NHb <= #LLb.#c)
			{
				if (#NHb == #LLb.#a)
				{
					return true;
				}
				if (#NHb == #LLb.#b)
				{
					return #z.SnappingGridEnabled;
				}
				if (#NHb != #LLb.#c)
				{
					goto IL_1B7;
				}
			}
			else if (#NHb <= #LLb.#e)
			{
				if (#NHb == #LLb.#d)
				{
					return #z.ObjectSnappingEnabled && #z.SnapObjectsCentroid;
				}
				if (#NHb != #LLb.#e)
				{
					goto IL_1B7;
				}
				return #z.ObjectSnappingEnabled && #z.SnapIntersection;
			}
			else
			{
				if (#NHb == #LLb.#f)
				{
					return #z.ObjectSnappingEnabled && #z.SnapDrawingGrid && this.#a.DrawingGrid.GridEnabled;
				}
				if (#NHb != #LLb.#g)
				{
					goto IL_1B7;
				}
				return true;
			}
			IL_13C:
			return #z.ObjectSnappingEnabled && #z.SnapShapes;
			IL_1B7:
			throw new ArgumentOutOfRangeException(#Phc.#3hc(107351847), #NHb, null);
		}

		// Token: 0x04001761 RID: 5985
		private readonly ISettingsManager #a;

		// Token: 0x04001762 RID: 5986
		private readonly EyeshotEditor #b;

		// Token: 0x04001763 RID: 5987
		private readonly List<Point3D> #c = new List<Point3D>
		{
			new Point3D()
		};

		// Token: 0x04001764 RID: 5988
		[CompilerGenerated]
		private readonly #0V #d;

		// Token: 0x0200067B RID: 1659
		[CompilerGenerated]
		private sealed class #oWb
		{
			// Token: 0x060037D5 RID: 14293 RVA: 0x00030758 File Offset: 0x0002E958
			internal Point3D #icc(Point3D #jcc)
			{
				return #jcc.ProjectTo(this.#a);
			}

			// Token: 0x060037D6 RID: 14294 RVA: 0x00030772 File Offset: 0x0002E972
			internal bool #kcc(Point3D #lcc)
			{
				return #lcc.DistanceTo(this.#b) < this.#c;
			}

			// Token: 0x060037D7 RID: 14295 RVA: 0x00030794 File Offset: 0x0002E994
			internal double #mcc(Point3D #lcc)
			{
				return #lcc.DistanceTo(this.#b);
			}

			// Token: 0x04001765 RID: 5989
			public Segment3D #a;

			// Token: 0x04001766 RID: 5990
			public Point3D #b;

			// Token: 0x04001767 RID: 5991
			public double #c;
		}
	}
}
