using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlTypes;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;
using #cYd;
using #Fmc;
using #u3d;
using #UYd;
using ClipperLib;
using Microsoft.SqlServer.Types;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.Infrastructure;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.Geometry.Data
{
	// Token: 0x02000810 RID: 2064
	[Serializable]
	public sealed class PolygonData
	{
		// Token: 0x06004250 RID: 16976 RVA: 0x00037B53 File Offset: 0x00035D53
		public PolygonData(IEnumerable<Point3D> points3D, PolygonType polygonType) : this(points3D, polygonType, false)
		{
		}

		// Token: 0x06004251 RID: 16977 RVA: 0x001362D8 File Offset: 0x001344D8
		public PolygonData(IEnumerable<Point3D> points3D, PolygonType polygonType, bool optimizeResourcesUsage)
		{
			this.points2D = new List<Point>();
			this.points3D = new List<Point3D>();
			base..ctor();
			#X0d.#V0d(points3D, #Phc.#3hc(107461835), Component.Geometry, #Phc.#3hc(107458457));
			IList<Point3D> list;
			if (optimizeResourcesUsage)
			{
				list = ((points3D as IList<Point3D>) ?? points3D.ToList<Point3D>());
			}
			else
			{
				Func<Point3D, Point3D> selector;
				if ((selector = PolygonData.#2Ui.#a) == null)
				{
					selector = (PolygonData.#2Ui.#a = new Func<Point3D, Point3D>(PointsConverter.#ssc));
				}
				list = points3D.Select(selector).ToList<Point3D>();
			}
			if (list.Count < PolygonData.MinNumberOfPoints)
			{
				throw new #jYd(#Phc.#3hc(107461835), #Phc.#3hc(107458372), Component.Geometry);
			}
			if (Point3D.#F3d(list[0], list[list.Count - 1]))
			{
				list.Add(list[0]);
			}
			List<Point> #BP = PointsConverter.#vsc(list);
			this.#Ovc(#BP, list, optimizeResourcesUsage);
			this.PolygonType = polygonType;
		}

		// Token: 0x06004252 RID: 16978 RVA: 0x00037B5E File Offset: 0x00035D5E
		public PolygonData(IEnumerable<Point3D> points3D) : this(points3D, PolygonType.Undefined)
		{
		}

		// Token: 0x06004253 RID: 16979 RVA: 0x00037B68 File Offset: 0x00035D68
		public PolygonData(IEnumerable<Point3D> points3D, bool isOpening) : this(points3D, PolygonType.Undefined)
		{
			this.IsOpening = isOpening;
		}

		// Token: 0x06004254 RID: 16980 RVA: 0x001363C4 File Offset: 0x001345C4
		public PolygonData(PolygonData polygon)
		{
			this.points2D = new List<Point>();
			this.points3D = new List<Point3D>();
			base..ctor();
			#X0d.#V0d(polygon, #Phc.#3hc(107369083), Component.Geometry, #Phc.#3hc(107458319));
			this.points3D = new List<Point3D>(polygon.Points3D);
			this.points2D = new List<Point>(polygon.Points2D);
			this.SqlGeometry = polygon.SqlGeometry;
			this.ChildPolygons = new List<PolygonData>();
			this.PossibleParentPolygons = new List<PolygonData>();
			this.IntPoints = new List<IntPoint>(polygon.IntPoints);
			this.Segments = new List<SegmentData>(polygon.Segments);
			this.PolygonType = polygon.PolygonType;
		}

		// Token: 0x06004255 RID: 16981 RVA: 0x0013647C File Offset: 0x0013467C
		public bool #e(PolygonData #iwc)
		{
			if (#iwc == null || #iwc.Points3DCount != this.Points3DCount || this.IsOpening || #iwc.IsOpening)
			{
				return false;
			}
			for (int i = 0; i < this.Points3DCount; i++)
			{
				Point3D #mcb = this.points3D[i];
				Point3D #ncb = #iwc.points3D[i];
				if (!PointsConverter.#uC(#mcb, #ncb))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06004256 RID: 16982 RVA: 0x00037B79 File Offset: 0x00035D79
		public Point #jwc(int #4jb)
		{
			return this.points2D[#4jb];
		}

		// Token: 0x06004257 RID: 16983 RVA: 0x00037B93 File Offset: 0x00035D93
		public Point3D #kwc(int #4jb)
		{
			return this.points3D[#4jb];
		}

		// Token: 0x06004258 RID: 16984 RVA: 0x0013652C File Offset: 0x0013472C
		public void #dwc(IEnumerable<Point3D> #BP)
		{
			#X0d.#V0d(#BP, #Phc.#3hc(107358670), Component.Geometry, #Phc.#3hc(107457786));
			Func<Point3D, Point3D> selector;
			if ((selector = PolygonData.#2Ui.#a) == null)
			{
				selector = (PolygonData.#2Ui.#a = new Func<Point3D, Point3D>(PointsConverter.#ssc));
			}
			List<Point3D> list = #BP.Select(selector).ToList<Point3D>();
			if (Point3D.#F3d(list[0], list[list.Count - 1]))
			{
				list.Add(list[0]);
			}
			List<Point> #BP2 = PointsConverter.#vsc(list);
			this.#Ovc(#BP2, list, this.optimizeResourcesUsage);
		}

		// Token: 0x06004259 RID: 16985 RVA: 0x00136610 File Offset: 0x00134810
		public void #dwc(IEnumerable<Point> #BP)
		{
			#X0d.#V0d(#BP, #Phc.#3hc(107358670), Component.Geometry, #Phc.#3hc(107457701));
			List<Point> list = #BP.Select(new Func<Point, Point>(PolygonData.<>c.<>9.#Wyc)).ToList<Point>();
			if (Point.#F3d(list[0], list[list.Count - 1]))
			{
				list.Add(list[0]);
			}
			List<Point3D> #Qwc = PointsConverter.#vsc(list);
			this.#Ovc(list, #Qwc, this.optimizeResourcesUsage);
		}

		// Token: 0x0600425A RID: 16986 RVA: 0x001366F8 File Offset: 0x001348F8
		public bool #lwc(Point #Ng)
		{
			PolygonData.#8Ub #8Ub = new PolygonData.#8Ub();
			#8Ub.#a = #Ng;
			return this.points2D.Any(new Func<Point, bool>(#8Ub.#Xyc));
		}

		// Token: 0x0600425B RID: 16987 RVA: 0x00136748 File Offset: 0x00134948
		public bool #Lnc(Point #Ng)
		{
			int result;
			do
			{
				bool flag = (result = (this.IsConvex ? 1 : 0)) != 0;
				if (false)
				{
					return result != 0;
				}
				if (!flag)
				{
					goto IL_18;
				}
			}
			while (4 == 0);
			return GeometryHelper.#Lnc(this.points2D, #Ng);
			IL_18:
			bool flag2 = (result = (GeometryHelper.#eoc(this.points2D, this.points2D.Count - 1, #Ng) ? 1 : 0)) != 0;
			if (4 != 0)
			{
				if (!flag2)
				{
					return #jsc.#isc(this.points2D, #Ng);
				}
				result = 1;
			}
			return result != 0;
		}

		// Token: 0x0600425C RID: 16988 RVA: 0x001367C0 File Offset: 0x001349C0
		public PolygonData #mwc(Vector #EHb)
		{
			do
			{
			}
			while (false);
			#DUb.#a = new #c4d(#EHb.X, #EHb.Y, 0.0);
			return new PolygonData(this.points3D.Select(new Func<Point3D, Point3D>(#DUb.#Yyc)));
		}

		// Token: 0x0600425D RID: 16989 RVA: 0x00136838 File Offset: 0x00134A38
		public PolygonData #mwc(Point #EHb)
		{
			do
			{
			}
			while (false);
			#i9b.#a = new #c4d(#EHb.X, #EHb.Y, 0.0);
			return new PolygonData(this.points3D.Select(new Func<Point3D, Point3D>(#i9b.#Yyc)));
		}

		// Token: 0x0600425E RID: 16990 RVA: 0x001368B0 File Offset: 0x00134AB0
		public PolygonData #mwc(Point3D #EHb)
		{
			do
			{
			}
			while (false);
			#HUb.#a = new #c4d(#EHb.X, #EHb.Y, 0.0);
			return new PolygonData(this.points3D.Select(new Func<Point3D, Point3D>(#HUb.#Yyc)));
		}

		// Token: 0x0600425F RID: 16991 RVA: 0x00136928 File Offset: 0x00134B28
		public PolygonData #mwc(double #nwc, double #owc)
		{
			for (;;)
			{
				#c4d #a;
				while (5 != 0 && 8 != 0)
				{
					#a = new #c4d(#nwc, #owc, 0.0);
					if (3 != 0)
					{
						if (!false)
						{
							goto Block_3;
						}
						break;
					}
				}
			}
			Block_3:
			return new PolygonData(this.points3D.Select(new Func<Point3D, Point3D>(#uZb.#Yyc)));
		}

		// Token: 0x06004260 RID: 16992 RVA: 0x001369A0 File Offset: 0x00134BA0
		public PolygonData #pwc(double #qwc, double #rwc)
		{
			for (;;)
			{
				if (5 != 0 && 8 != 0)
				{
					double #a = #qwc;
					double #b;
					do
					{
						#b = #rwc;
					}
					while (3 == 0);
					if (!false)
					{
						break;
					}
				}
			}
			return new PolygonData(this.points3D.Select(new Func<Point3D, Point3D>(#wWb.#Zyc)));
		}

		// Token: 0x06004261 RID: 16993 RVA: 0x00037BAD File Offset: 0x00035DAD
		public ReadOnlyCollection<Point> #swc()
		{
			return this.points2D.AsReadOnly();
		}

		// Token: 0x06004262 RID: 16994 RVA: 0x00136A10 File Offset: 0x00134C10
		public Point? #twc()
		{
			SqlGeometry sqlGeometry = this.SqlGeometry.STCentroid();
			SqlDouble sqlDouble;
			if (sqlGeometry == null || sqlGeometry.IsNull)
			{
				Point? result = null;
				if (!false)
				{
					return result;
				}
			}
			else
			{
				sqlDouble = sqlGeometry.STX;
			}
			double value = sqlDouble.Value;
			sqlDouble = sqlGeometry.STY;
			return new Point?(new Point(value, sqlDouble.Value));
		}

		// Token: 0x17001395 RID: 5013
		// (get) Token: 0x06004263 RID: 16995 RVA: 0x00037BC2 File Offset: 0x00035DC2
		// (set) Token: 0x06004264 RID: 16996 RVA: 0x00037BCE File Offset: 0x00035DCE
		public SqlGeometry SqlGeometry { get; private set; }

		// Token: 0x17001396 RID: 5014
		// (get) Token: 0x06004265 RID: 16997 RVA: 0x00037BDF File Offset: 0x00035DDF
		// (set) Token: 0x06004266 RID: 16998 RVA: 0x00037BEB File Offset: 0x00035DEB
		internal List<IntPoint> IntPoints { get; private set; }

		// Token: 0x17001397 RID: 5015
		// (get) Token: 0x06004267 RID: 16999 RVA: 0x00037BFC File Offset: 0x00035DFC
		// (set) Token: 0x06004268 RID: 17000 RVA: 0x00037C08 File Offset: 0x00035E08
		internal List<PolygonData> PossibleParentPolygons { get; private set; }

		// Token: 0x17001398 RID: 5016
		// (get) Token: 0x06004269 RID: 17001 RVA: 0x00037C19 File Offset: 0x00035E19
		// (set) Token: 0x0600426A RID: 17002 RVA: 0x00037C25 File Offset: 0x00035E25
		public PolygonData ParentPolygon { get; set; }

		// Token: 0x17001399 RID: 5017
		// (get) Token: 0x0600426B RID: 17003 RVA: 0x00037C36 File Offset: 0x00035E36
		// (set) Token: 0x0600426C RID: 17004 RVA: 0x00037C42 File Offset: 0x00035E42
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public List<PolygonData> ChildPolygons { get; private set; }

		// Token: 0x1700139A RID: 5018
		// (get) Token: 0x0600426D RID: 17005 RVA: 0x00037C53 File Offset: 0x00035E53
		// (set) Token: 0x0600426E RID: 17006 RVA: 0x00037C5F File Offset: 0x00035E5F
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public List<SegmentData> Segments { get; private set; }

		// Token: 0x1700139B RID: 5019
		// (get) Token: 0x0600426F RID: 17007 RVA: 0x00037C70 File Offset: 0x00035E70
		// (set) Token: 0x06004270 RID: 17008 RVA: 0x00037C7C File Offset: 0x00035E7C
		public bool IsOpening { get; set; }

		// Token: 0x1700139C RID: 5020
		// (get) Token: 0x06004271 RID: 17009 RVA: 0x00037C8D File Offset: 0x00035E8D
		// (set) Token: 0x06004272 RID: 17010 RVA: 0x00037C99 File Offset: 0x00035E99
		public PolygonType PolygonType { get; set; }

		// Token: 0x1700139D RID: 5021
		// (get) Token: 0x06004273 RID: 17011 RVA: 0x00037CAA File Offset: 0x00035EAA
		public IReadOnlyList<Point3D> Points3D
		{
			get
			{
				return this.points3D;
			}
		}

		// Token: 0x1700139E RID: 5022
		// (get) Token: 0x06004274 RID: 17012 RVA: 0x00037CB6 File Offset: 0x00035EB6
		public int Points3DCount
		{
			get
			{
				return this.points3D.Count;
			}
		}

		// Token: 0x1700139F RID: 5023
		// (get) Token: 0x06004275 RID: 17013 RVA: 0x00037CCB File Offset: 0x00035ECB
		public IReadOnlyList<Point> Points2D
		{
			get
			{
				return this.points2D;
			}
		}

		// Token: 0x170013A0 RID: 5024
		// (get) Token: 0x06004276 RID: 17014 RVA: 0x00037CD7 File Offset: 0x00035ED7
		public int Points2DCount
		{
			get
			{
				return this.points2D.Count;
			}
		}

		// Token: 0x170013A1 RID: 5025
		// (get) Token: 0x06004277 RID: 17015 RVA: 0x00037CEC File Offset: 0x00035EEC
		// (set) Token: 0x06004278 RID: 17016 RVA: 0x00037CF8 File Offset: 0x00035EF8
		public BoundingBoxData BoundingBoxData
		{
			get
			{
				return this.boundingBoxData;
			}
			private set
			{
				if (this.boundingBoxData != value)
				{
					this.boundingBoxData = value;
				}
			}
		}

		// Token: 0x170013A2 RID: 5026
		// (get) Token: 0x06004279 RID: 17017 RVA: 0x00033709 File Offset: 0x00031909
		public static int MinNumberOfPoints
		{
			get
			{
				return 3;
			}
		}

		// Token: 0x170013A3 RID: 5027
		// (get) Token: 0x0600427A RID: 17018 RVA: 0x00037D1A File Offset: 0x00035F1A
		// (set) Token: 0x0600427B RID: 17019 RVA: 0x00037D26 File Offset: 0x00035F26
		public bool IsConvex { get; private set; }

		// Token: 0x170013A4 RID: 5028
		// (get) Token: 0x0600427C RID: 17020 RVA: 0x00037D37 File Offset: 0x00035F37
		// (set) Token: 0x0600427D RID: 17021 RVA: 0x00037D43 File Offset: 0x00035F43
		public Rect BoundingRect
		{
			get
			{
				return this.boundingRect;
			}
			set
			{
				this.boundingRect = value;
			}
		}

		// Token: 0x0600427E RID: 17022 RVA: 0x00136A8C File Offset: 0x00134C8C
		private void #Ovc(IList<Point> #BP, IList<Point3D> #Qwc, bool #Rwc)
		{
			if (true)
			{
				this.optimizeResourcesUsage = #Rwc;
				this.points3D.Clear();
			}
			this.points3D.AddRange(#Qwc);
			this.points2D.Clear();
			this.points2D.AddRange(#BP);
			this.IsConvex = GeometryHelper.#Nnc(#BP);
			if (!this.optimizeResourcesUsage)
			{
				this.SqlGeometry = #0uc.#PHb(this.points2D, true);
				this.ChildPolygons = new List<PolygonData>();
				this.PossibleParentPolygons = new List<PolygonData>();
				do
				{
					this.IntPoints = PointsConverter.#Pb(this.points3D).ToList<IntPoint>();
					this.Segments = new List<SegmentData>();
				}
				while (5 == 0);
				this.Segments.AddRange(#jsc.#Rrc(this.points2D));
				this.BoundingBoxData = new BoundingBoxData(this.points2D);
				this.BoundingRect = this.BoundingBoxData.Rect;
			}
		}

		// Token: 0x04001DE8 RID: 7656
		private readonly List<Point> points2D;

		// Token: 0x04001DE9 RID: 7657
		private readonly List<Point3D> points3D;

		// Token: 0x04001DEA RID: 7658
		private bool optimizeResourcesUsage;

		// Token: 0x04001DEB RID: 7659
		private Rect boundingRect;

		// Token: 0x04001DEC RID: 7660
		private BoundingBoxData boundingBoxData;

		// Token: 0x02000811 RID: 2065
		[CompilerGenerated]
		private static class #2Ui
		{
			// Token: 0x04001DF6 RID: 7670
			public static Func<Point3D, Point3D> #a;
		}

		// Token: 0x02000813 RID: 2067
		[CompilerGenerated]
		private sealed class #8Ub
		{
			// Token: 0x06004283 RID: 17027 RVA: 0x00037D74 File Offset: 0x00035F74
			internal bool #Xyc(Point #Rf)
			{
				return PointsConverter.#uC(this.#a, #Rf);
			}

			// Token: 0x04001DF9 RID: 7673
			public Point #a;
		}

		// Token: 0x02000814 RID: 2068
		[CompilerGenerated]
		private sealed class #DUb
		{
			// Token: 0x06004285 RID: 17029 RVA: 0x00037D8E File Offset: 0x00035F8E
			internal Point3D #Yyc(Point3D #Ng)
			{
				return Point3D.#G3d(#Ng, this.#a);
			}

			// Token: 0x04001DFA RID: 7674
			public #c4d #a;
		}

		// Token: 0x02000815 RID: 2069
		[CompilerGenerated]
		private sealed class #i9b
		{
			// Token: 0x06004287 RID: 17031 RVA: 0x00037DA8 File Offset: 0x00035FA8
			internal Point3D #Yyc(Point3D #Ng)
			{
				return Point3D.#G3d(#Ng, this.#a);
			}

			// Token: 0x04001DFB RID: 7675
			public #c4d #a;
		}

		// Token: 0x02000816 RID: 2070
		[CompilerGenerated]
		private sealed class #HUb
		{
			// Token: 0x06004289 RID: 17033 RVA: 0x00037DC2 File Offset: 0x00035FC2
			internal Point3D #Yyc(Point3D #Ng)
			{
				return Point3D.#G3d(#Ng, this.#a);
			}

			// Token: 0x04001DFC RID: 7676
			public #c4d #a;
		}

		// Token: 0x02000817 RID: 2071
		[CompilerGenerated]
		private sealed class #uZb
		{
			// Token: 0x0600428B RID: 17035 RVA: 0x00037DDC File Offset: 0x00035FDC
			internal Point3D #Yyc(Point3D #Ng)
			{
				return Point3D.#G3d(#Ng, this.#a);
			}

			// Token: 0x04001DFD RID: 7677
			public #c4d #a;
		}

		// Token: 0x02000818 RID: 2072
		[CompilerGenerated]
		private sealed class #wWb
		{
			// Token: 0x0600428D RID: 17037 RVA: 0x00136BC8 File Offset: 0x00134DC8
			internal Point3D #Zyc(Point3D #Rf)
			{
				double num;
				double x = num = #Rf.X;
				double y;
				for (;;)
				{
					double num3;
					double num2 = num3 = this.#a;
					for (;;)
					{
						if (!false)
						{
							x = (num *= num3);
							if (!true)
							{
								break;
							}
							num2 = #Rf.Y;
						}
						do
						{
							y = (num3 = (num2 *= this.#b));
						}
						while (3 == 0);
						if (!false)
						{
							goto Block_4;
						}
					}
				}
				Block_4:
				return new Point3D(x, y);
			}

			// Token: 0x04001DFE RID: 7678
			public double #a;

			// Token: 0x04001DFF RID: 7679
			public double #b;
		}
	}
}
