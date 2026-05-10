using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;
using #Fmc;
using #o1d;
using #UYd;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace StructurePoint.CoreAssets.Geometry.Helpers
{
	// Token: 0x020007F1 RID: 2033
	public sealed class SnappingProvider : #Qrc
	{
		// Token: 0x06004115 RID: 16661 RVA: 0x00036B0F File Offset: 0x00034D0F
		public SnappingProvider(double maxDistance, #Wsc snapDataOriginFilter)
		{
			this.#b = new SnappingProviderHelper(maxDistance, snapDataOriginFilter);
			this.MaxDistance = maxDistance;
		}

		// Token: 0x17001352 RID: 4946
		// (get) Token: 0x06004116 RID: 16662 RVA: 0x00036B2B File Offset: 0x00034D2B
		// (set) Token: 0x06004117 RID: 16663 RVA: 0x00036B37 File Offset: 0x00034D37
		public bool IsInOrthogonalMode { get; set; }

		// Token: 0x17001353 RID: 4947
		// (get) Token: 0x06004118 RID: 16664 RVA: 0x00036B48 File Offset: 0x00034D48
		// (set) Token: 0x06004119 RID: 16665 RVA: 0x00036B54 File Offset: 0x00034D54
		public double MaxDistance { get; set; }

		// Token: 0x17001354 RID: 4948
		// (get) Token: 0x0600411A RID: 16666 RVA: 0x00036B65 File Offset: 0x00034D65
		public IEnumerable<Point> GridLinesIntersectionPoints
		{
			get
			{
				return this.#b.GridIntersectionPoints;
			}
		}

		// Token: 0x17001355 RID: 4949
		// (get) Token: 0x0600411B RID: 16667 RVA: 0x00036B7A File Offset: 0x00034D7A
		public IEnumerable<SegmentData> GridLineSegments
		{
			get
			{
				return this.#b.GridLineSegments;
			}
		}

		// Token: 0x17001356 RID: 4950
		// (get) Token: 0x0600411C RID: 16668 RVA: 0x00036B8F File Offset: 0x00034D8F
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		protected List<SnappingSegmentData> AdditionalFiguresSegments
		{
			get
			{
				return this.#b.AdditionalFiguresSegments;
			}
		}

		// Token: 0x17001357 RID: 4951
		// (get) Token: 0x0600411D RID: 16669 RVA: 0x00036BA4 File Offset: 0x00034DA4
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		protected List<Point> AdditionalFiguresPoints
		{
			get
			{
				return this.#b.AdditionalFiguresPoints;
			}
		}

		// Token: 0x17001358 RID: 4952
		// (get) Token: 0x0600411E RID: 16670 RVA: 0x00036BB9 File Offset: 0x00034DB9
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		protected List<Point> AdditionalFiguresKeyPoints
		{
			get
			{
				return this.#b.AdditionalFigureEdgesKeyPoints;
			}
		}

		// Token: 0x17001359 RID: 4953
		// (get) Token: 0x0600411F RID: 16671 RVA: 0x00036BCE File Offset: 0x00034DCE
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		protected List<Point> GridLineAdditionalFiguresIntersectionPoints
		{
			get
			{
				return this.#b.GridLineAdditionalFiguresIntersectionPoints;
			}
		}

		// Token: 0x1700135A RID: 4954
		// (get) Token: 0x06004120 RID: 16672 RVA: 0x00036BE3 File Offset: 0x00034DE3
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		protected List<Point> ShapeAdditionalFiguresIntersectionPoints
		{
			get
			{
				return this.#b.ShapeAdditionalFiguresIntersectionPoints;
			}
		}

		// Token: 0x1700135B RID: 4955
		// (get) Token: 0x06004121 RID: 16673 RVA: 0x00036BF8 File Offset: 0x00034DF8
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		protected List<Point> AdditionalFiguresIntersectionPoints
		{
			get
			{
				return this.#b.AdditionalFiguresIntersectionPoints;
			}
		}

		// Token: 0x06004122 RID: 16674 RVA: 0x00130AA8 File Offset: 0x0012ECA8
		public void #yl(bool #zrc)
		{
			if (!#zrc)
			{
				goto IL_69;
			}
			IL_07:
			this.#b.GridLineSegments.Clear();
			this.#b.GridIntersectionPoints.Clear();
			this.#b.GridIntersectionSnappingPointDataDictionary.Clear();
			if (false)
			{
				goto IL_C5;
			}
			if (false)
			{
				goto IL_AF;
			}
			this.#b.GridLineShapePolygonEdgeIntersectionPoints.Clear();
			this.#b.GridLineLinearObjectIntersectionPoints.Clear();
			IL_69:
			this.#b.LinearObjectSegments.Clear();
			if (false)
			{
				goto IL_105;
			}
			this.#b.ShapePolygonsSegments.Clear();
			this.#b.AllShapeSegments.Clear();
			this.#b.ShapePolygonEdgesKeyPoints.Clear();
			IL_AF:
			if (false)
			{
				goto IL_07;
			}
			this.#b.LinearObjectsKeyPoints.Clear();
			IL_C5:
			this.#b.AllShapeSnappingPoints.Clear();
			this.#b.ShapesIntersectionPoints.Clear();
			this.#b.LinearObjectPoints.Clear();
			this.#b.NodePoints.Clear();
			IL_105:
			this.#b.ShapePolygonsPoints.Clear();
			this.#b.AdditionalFiguresPoints.Clear();
			this.#b.AdditionalFiguresSegments.Clear();
			this.#b.AdditionalFigureEdgesKeyPoints.Clear();
		}

		// Token: 0x06004123 RID: 16675 RVA: 0x00130C44 File Offset: 0x0012EE44
		public void #Arc(IEnumerable<SnappingPointData> #Brc)
		{
			string #R0d = #Phc.#3hc(107461115);
			Component #x6c = Component.Geometry;
			string #Qic = #Phc.#3hc(107461086);
			if (4 != 0)
			{
				#X0d.#V0d(#Brc, #R0d, #x6c, #Qic);
			}
			this.#b.AllShapeSnappingPoints.Clear();
			do
			{
				this.#b.LinearObjectPoints.Clear();
				this.#b.NodePoints.Clear();
				this.#b.ShapePolygonsPoints.Clear();
			}
			while (6 == 0);
			using (List<SnappingPointData>.Enumerator enumerator = #Brc.OrderBy(new Func<SnappingPointData, double>(SnappingProvider.<>c.<>9.#myc)).ThenBy(new Func<SnappingPointData, double>(SnappingProvider.<>c.<>9.#nyc)).ToList<SnappingPointData>().GetEnumerator())
			{
				IL_15C:
				while (8 != 0)
				{
					bool flag = enumerator.MoveNext();
					IL_166:
					while (flag)
					{
						SnappingPointData snappingPointData;
						if (true)
						{
							snappingPointData = enumerator.Current;
							#juc #juc = snappingPointData.SnapDataOrigin;
							for (;;)
							{
								bool flag2 = flag = (#juc - #juc.#b != 0);
								if (7 != 0)
								{
									switch (flag2)
									{
									case 0:
										goto IL_FD;
									case 1:
										if (7 != 0)
										{
											goto Block_10;
										}
										continue;
									case 2:
										goto IL_130;
									case 3:
										goto IL_146;
									}
									break;
								}
								goto IL_166;
							}
							if (-1 != 0)
							{
								goto IL_146;
							}
							goto IL_12E;
							IL_FD:
							this.#b.ShapePolygonsPoints.Add(snappingPointData.Point);
							IL_12E:
							goto IL_146;
							Block_10:
							this.#b.NodePoints.Add(snappingPointData.Point);
							goto IL_12E;
							IL_130:
							this.#b.LinearObjectPoints.Add(snappingPointData.Point);
						}
						IL_146:
						this.#b.AllShapeSnappingPoints.Add(snappingPointData.Point);
						goto IL_15C;
					}
					break;
				}
			}
		}

		// Token: 0x06004124 RID: 16676 RVA: 0x00130E2C File Offset: 0x0012F02C
		public void #Drc(IEnumerable<SnappingSegmentData> #IP)
		{
			#X0d.#V0d(#IP, #Phc.#3hc(107367545), Component.Geometry, #Phc.#3hc(107461001));
			IList<SnappingPointData> list;
			if (!false)
			{
				SnappingSegmentData[] array;
				if ((array = (#IP as SnappingSegmentData[])) == null)
				{
					array = #IP.ToArray<SnappingSegmentData>();
				}
				SnappingSegmentData[] array2 = array;
				if (true)
				{
					this.#b.GridLineSegments.Clear();
				}
				this.#b.GridLineSegments.AddRange(array2);
				list = #roc.#noc(array2);
				this.#b.GridIntersectionPoints.Clear();
				this.#b.GridIntersectionPoints.AddRange(list.Select(new Func<SnappingPointData, Point>(SnappingProvider.<>c.<>9.#oyc)).OrderBy(new Func<Point, double>(SnappingProvider.<>c.<>9.#pyc)).ThenBy(new Func<Point, double>(SnappingProvider.<>c.<>9.#qyc)));
				this.#b.GridIntersectionSnappingPointDataDictionary.Clear();
			}
			this.#b.GridIntersectionSnappingPointDataDictionary.#pR(list, new Func<SnappingPointData, Point>(SnappingProvider.<>c.<>9.#ryc));
			this.#ctc();
		}

		// Token: 0x06004125 RID: 16677 RVA: 0x00130FC4 File Offset: 0x0012F1C4
		public void #Crc(IEnumerable<SnappingSegmentData> #IP)
		{
			do
			{
				#X0d.#V0d(#IP, #Phc.#3hc(107367545), Component.Geometry, #Phc.#3hc(107460980));
				this.#b.AllShapeSegments.Clear();
				this.#b.LinearObjectSegments.Clear();
				this.#b.ShapePolygonsSegments.Clear();
				foreach (SnappingSegmentData snappingSegmentData in #IP)
				{
					this.#b.AllShapeSegments.Add(snappingSegmentData);
					if (!false)
					{
						switch (snappingSegmentData.SnapDataOrigin)
						{
						case #juc.#b:
							break;
						case #juc.#c:
						case #juc.#e:
							continue;
						case #juc.#d:
							this.#b.LinearObjectSegments.Add(snappingSegmentData);
							continue;
						default:
							continue;
						}
					}
					this.#b.ShapePolygonsSegments.Add(snappingSegmentData);
				}
				if (!false)
				{
					this.#6sc();
				}
				this.#7sc();
				this.#ctc();
			}
			while (!true);
		}

		// Token: 0x06004126 RID: 16678 RVA: 0x00131120 File Offset: 0x0012F320
		public void #Erc(IEnumerable<SnappingPointData> #Frc)
		{
			#X0d.#V0d(#Frc, #Phc.#3hc(107460927), Component.Geometry, #Phc.#3hc(107460914));
			List<Point> collection = this.#b.ShapePolygonEdgesKeyPoints.Union(#Frc.Select(new Func<SnappingPointData, Point>(SnappingProvider.<>c.<>9.#syc))).OrderBy(new Func<Point, double>(SnappingProvider.<>c.<>9.#tyc)).ThenBy(new Func<Point, double>(SnappingProvider.<>c.<>9.#uyc)).ToList<Point>();
			this.#b.ShapePolygonEdgesKeyPoints.Clear();
			this.#b.ShapePolygonEdgesKeyPoints.AddRange(collection);
		}

		// Token: 0x06004127 RID: 16679 RVA: 0x00131248 File Offset: 0x0012F448
		public void #Grc(IEnumerable<SnappingPointData> #Hrc)
		{
			#X0d.#V0d(#Hrc, #Phc.#3hc(107460349), Component.Geometry, #Phc.#3hc(107460300));
			this.#b.FreeNodesPoints.Clear();
			IEnumerator<SnappingPointData> enumerator = #Hrc.OrderBy(new Func<SnappingPointData, double>(SnappingProvider.<>c.<>9.#vyc)).ThenBy(new Func<SnappingPointData, double>(SnappingProvider.<>c.<>9.#wyc)).GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					SnappingPointData snappingPointData = enumerator.Current;
					this.#b.FreeNodesPoints.Add(snappingPointData.Point);
				}
			}
			finally
			{
				if (enumerator != null && -1 != 0)
				{
					enumerator.Dispose();
				}
			}
		}

		// Token: 0x06004128 RID: 16680 RVA: 0x00131370 File Offset: 0x0012F570
		public void #3sc(IEnumerable<SnappingPointData> #3sb)
		{
			if (3 != 0)
			{
				#X0d.#V0d(#3sb, #Phc.#3hc(107460279), Component.Geometry, #Phc.#3hc(107460254));
			}
			this.GridLineAdditionalFiguresIntersectionPoints.Clear();
			IEnumerator<SnappingPointData> enumerator = #3sb.OrderBy(new Func<SnappingPointData, double>(SnappingProvider.<>c.<>9.#xyc)).ThenBy(new Func<SnappingPointData, double>(SnappingProvider.<>c.<>9.#yyc)).GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					SnappingPointData snappingPointData = enumerator.Current;
					this.GridLineAdditionalFiguresIntersectionPoints.Add(snappingPointData.Point);
				}
			}
			finally
			{
				if (false || enumerator != null)
				{
					enumerator.Dispose();
				}
			}
		}

		// Token: 0x06004129 RID: 16681 RVA: 0x00036C0D File Offset: 0x00034E0D
		[SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public Point? #bNb(List<Point> #BP, Point #Ng, double #WLb)
		{
			return this.#b.#bNb(#BP, #Ng, #WLb);
		}

		// Token: 0x0600412A RID: 16682 RVA: 0x00036C31 File Offset: 0x00034E31
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		[SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
		public Point3D? #bNb(List<Point> #BP, Point3D #HAb, double #WLb)
		{
			return this.#b.#bNb(#BP, #HAb, #WLb);
		}

		// Token: 0x0600412B RID: 16683 RVA: 0x00036C55 File Offset: 0x00034E55
		public #fuc #sqc(IList<SnappingSegmentData> #tqc, Point3D #HAb, double #WLb)
		{
			return this.#b.#sqc(#tqc, #HAb, #WLb);
		}

		// Token: 0x0600412C RID: 16684 RVA: 0x00036C79 File Offset: 0x00034E79
		public #fuc #sqc(IList<SnappingSegmentData> #tqc, Point3D #HAb, double #WLb, #iuc #uqc)
		{
			return this.#b.#sqc(#tqc, #HAb, #WLb, #uqc);
		}

		// Token: 0x0600412D RID: 16685 RVA: 0x00036CA3 File Offset: 0x00034EA3
		public Point3D? #vqc(Point3D #HAb)
		{
			return this.#b.#vqc(#HAb);
		}

		// Token: 0x0600412E RID: 16686 RVA: 0x00036CBD File Offset: 0x00034EBD
		public Point3D? #vqc(Point3D #HAb, double #WLb)
		{
			return this.#b.#vqc(#HAb, #WLb);
		}

		// Token: 0x0600412F RID: 16687 RVA: 0x00036CDC File Offset: 0x00034EDC
		public #fuc #wqc(Point3D #HAb)
		{
			return this.#wqc(#HAb);
		}

		// Token: 0x06004130 RID: 16688 RVA: 0x00036CF1 File Offset: 0x00034EF1
		public #fuc #wqc(Point3D #HAb, double #WLb)
		{
			return this.#wqc(#HAb, #WLb);
		}

		// Token: 0x06004131 RID: 16689 RVA: 0x00131490 File Offset: 0x0012F690
		public Point3D? #4sc(Point3D #HAb, double #WLb)
		{
			#fuc #fuc;
			if (!false)
			{
				Point3D? result = this.#b.#vqc(#HAb, #WLb);
				if (6 == 0 || result != null)
				{
					goto IL_43;
				}
				IL_1B:
				#fuc = this.#b.#wqc(#HAb, #WLb);
				IL_2C:
				if (!true)
				{
					goto IL_1B;
				}
				if (#fuc != null)
				{
					goto IL_32;
				}
				IL_43:
				if (!false)
				{
					return result;
				}
				goto IL_2C;
			}
			IL_32:
			return new Point3D?(PointsConverter.#vsc(#fuc.Point));
		}

		// Token: 0x06004132 RID: 16690 RVA: 0x00036D0B File Offset: 0x00034F0B
		public Point3D? #4sc(Point3D #HAb)
		{
			return this.#4sc(#HAb, this.MaxDistance);
		}

		// Token: 0x06004133 RID: 16691 RVA: 0x00036D2E File Offset: 0x00034F2E
		public #fuc #Jrc(Point3D #HAb, double #WLb)
		{
			return this.#b.#sqc(this.#b.AllShapeSegments, #HAb, #WLb, #iuc.#c);
		}

		// Token: 0x06004134 RID: 16692 RVA: 0x00036D61 File Offset: 0x00034F61
		public #fuc #Jrc(Point3D #HAb)
		{
			return this.#b.#sqc(this.#b.AllShapeSegments, #HAb, this.MaxDistance, #iuc.#c);
		}

		// Token: 0x06004135 RID: 16693 RVA: 0x00036D9D File Offset: 0x00034F9D
		public Point3D? #Lrc(Point3D #HAb, double #WLb)
		{
			return this.#b.#bNb(this.#b.AllShapeSnappingPoints, #HAb, #WLb);
		}

		// Token: 0x06004136 RID: 16694 RVA: 0x00131508 File Offset: 0x0012F708
		public Point3D? #Krc(Point3D #HAb, double #WLb)
		{
			#fuc #fuc;
			for (;;)
			{
				Point3D? result = this.#Lrc(#HAb, #WLb);
				while (!false)
				{
					if (7 != 0)
					{
						if (result == null)
						{
							#fuc = this.#Jrc(#HAb, #WLb);
							if (6 == 0)
							{
								continue;
							}
							if (#fuc != null)
							{
								goto IL_28;
							}
						}
						if (-1 != 0)
						{
							return result;
						}
						continue;
					}
					IL_28:
					if (!false)
					{
						goto Block_4;
					}
				}
			}
			Block_4:
			return new Point3D?(PointsConverter.#vsc(#fuc.Point));
		}

		// Token: 0x06004137 RID: 16695 RVA: 0x00036DCF File Offset: 0x00034FCF
		public #Atc #bNb(#hvc #Irc, Point3D #HAb)
		{
			return this.#bNb(#Irc, #HAb, this.MaxDistance);
		}

		// Token: 0x06004138 RID: 16696 RVA: 0x00131578 File Offset: 0x0012F778
		[SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "3#")]
		public unsafe #Atc #bNb(#hvc #Irc, Point3D #HAb, double #WLb)
		{
			void* ptr = stackalloc byte[6];
			*(byte*)ptr = (#Irc.#z1d(#hvc.#b) ? 1 : 0);
			*(byte*)(ptr + 1) = (#Irc.#z1d(#hvc.#c) ? 1 : 0);
			bool #Aqc;
			bool flag;
			if (!false)
			{
				*(byte*)(ptr + 2) = (#Irc.#z1d(#hvc.#d) ? 1 : 0);
				#Aqc = (#Irc.#z1d(#hvc.#e) && this.#b.SnapDataOriginFilter.#Usc(#juc.#h));
				if (#Irc.#z1d(#hvc.#f))
				{
					flag = this.#b.SnapDataOriginFilter.#Usc(#juc.#h);
					goto IL_99;
				}
			}
			flag = false;
			IL_99:
			bool #Sqc = flag;
			((byte*)ptr)[3] = (#Irc.#z1d(#hvc.#g) ? 1 : 0);
			((byte*)ptr)[4] = (#Irc.#z1d(#hvc.#h) ? 1 : 0);
			((byte*)ptr)[5] = (#Irc.#z1d(#hvc.#i) ? 1 : 0);
			#trc #trc = new #trc(#HAb, #jrc.#b);
			this.#b.#Qqc(#trc, #HAb, *(sbyte*)ptr != 0, *(sbyte*)((byte*)ptr + 1) != 0, *(sbyte*)((byte*)ptr + 2) != 0, #Aqc, #Sqc, *(sbyte*)((byte*)ptr + 3) != 0, *(sbyte*)((byte*)ptr + 4) != 0, *(sbyte*)((byte*)ptr + 5) != 0, #WLb);
			if (#trc.HasValidResult)
			{
				return #trc.#nrc();
			}
			#trc.#krc();
			this.#b.#xqc(#trc, #HAb, *(sbyte*)ptr != 0, *(sbyte*)((byte*)ptr + 1) != 0, #Aqc, #WLb);
			return #trc.#nrc();
		}

		// Token: 0x06004139 RID: 16697 RVA: 0x001316F4 File Offset: 0x0012F8F4
		public unsafe #Atc #Mrc(#hvc #Irc, Point3D #Nrc, Point3D #Orc, BoundingBoxData #Prc)
		{
			void* ptr = stackalloc byte[14];
			#X0d.#V0d(#Prc, #Phc.#3hc(107460169), Component.Geometry, #Phc.#3hc(107460188));
			SegmentData segmentData = #Dpc.#xpc(#Orc, #Prc);
			SegmentData segmentData2 = #Dpc.#zpc(#Orc, #Prc);
			SnappingSegmentData snappingSegmentData = new SnappingSegmentData(segmentData, #juc.#i);
			SnappingSegmentData snappingSegmentData2 = new SnappingSegmentData(segmentData2, #juc.#i);
			((byte*)ptr)[8] = (#Irc.#z1d(#hvc.#b) ? 1 : 0);
			((byte*)ptr)[9] = (#Irc.#z1d(#hvc.#c) ? 1 : 0);
			((byte*)ptr)[10] = (#Irc.#z1d(#hvc.#d) ? 1 : 0);
			bool #Aqc = #Irc.#z1d(#hvc.#e) && this.#b.SnapDataOriginFilter.#Usc(#juc.#h);
			bool #Sqc = #Irc.#z1d(#hvc.#f) && this.#b.SnapDataOriginFilter.#Usc(#juc.#h);
			((byte*)ptr)[11] = (#Irc.#z1d(#hvc.#g) ? 1 : 0);
			((byte*)ptr)[12] = (#Irc.#z1d(#hvc.#h) ? 1 : 0);
			((byte*)ptr)[13] = (#Irc.#z1d(#hvc.#i) ? 1 : 0);
			List<Point> list = new List<Point>();
			this.#b.#8qc(list, snappingSegmentData, snappingSegmentData2, *(sbyte*)((byte*)ptr + 8) != 0);
			this.#b.#crc(list, snappingSegmentData, snappingSegmentData2, *(sbyte*)((byte*)ptr + 9) != 0);
			this.#b.#drc(list, snappingSegmentData, snappingSegmentData2, #Aqc);
			this.#b.#erc(list, snappingSegmentData, snappingSegmentData2, *(sbyte*)((byte*)ptr + 11) != 0);
			this.#b.#frc(list, snappingSegmentData, snappingSegmentData2, *(sbyte*)((byte*)ptr + 10) != 0);
			this.#b.#grc(list, snappingSegmentData, snappingSegmentData2, #Sqc);
			this.#b.#hrc(list, snappingSegmentData, snappingSegmentData2, *(sbyte*)((byte*)ptr + 12) != 0, *(sbyte*)((byte*)ptr + 8) != 0);
			SnappingProviderHelper.#irc(list, snappingSegmentData, snappingSegmentData2, *(sbyte*)((byte*)ptr + 13) != 0);
			list = list.OrderBy(new Func<Point, double>(SnappingProvider.<>c.<>9.#zyc)).ThenBy(new Func<Point, double>(SnappingProvider.<>c.<>9.#Ayc)).ToList<Point>();
			#trc #trc = new #trc(#Nrc, #jrc.#b);
			Point3D? #Ng = this.#b.#bNb(list, #Nrc, this.MaxDistance);
			#trc.#Qfb(#Ng, #huc.#m);
			if (#trc.HasValidResult)
			{
				return #trc.#nrc();
			}
			#trc.#krc();
			*(double*)ptr = #Dpc.#Apc(segmentData, segmentData2);
			#fuc #lrc = this.#b.#sqc(new List<SnappingSegmentData>
			{
				snappingSegmentData,
				snappingSegmentData2
			}, #Nrc, *(double*)ptr, #iuc.#e);
			#trc.#Qfb(#lrc, #huc.#l);
			return #trc.#nrc();
		}

		// Token: 0x0600413A RID: 16698 RVA: 0x001319D4 File Offset: 0x0012FBD4
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public Point3D? #Mrc(List<Point> #BP, Point3D #HAb, double #WLb, Point3D #Orc, BoundingBoxData #Prc)
		{
			do
			{
				#X0d.#V0d(#BP, #Phc.#3hc(107358670), Component.Geometry, #Phc.#3hc(107460103));
				#X0d.#V0d(#Prc, #Phc.#3hc(107460169), Component.Geometry, #Phc.#3hc(107460594));
			}
			while (false);
			SegmentData segmentData = #Dpc.#xpc(#Orc, #Prc);
			SegmentData segmentData2 = #Dpc.#zpc(#Orc, #Prc);
			SnappingSegmentData #PP = new SnappingSegmentData(segmentData, #juc.#i);
			SnappingSegmentData #PP2 = new SnappingSegmentData(segmentData2, #juc.#i);
			List<Point> list = new List<Point>();
			using (List<Point>.Enumerator enumerator = #BP.GetEnumerator())
			{
				for (;;)
				{
					if (enumerator.MoveNext())
					{
						goto IL_76;
					}
					if (!false)
					{
						break;
					}
					IL_7F:
					Point point;
					if (#jsc.#Src(#PP, point))
					{
						goto IL_96;
					}
					IL_89:
					if (false)
					{
						goto IL_76;
					}
					if (!#jsc.#Src(#PP2, point))
					{
						continue;
					}
					IL_96:
					if (!false)
					{
						list.Add(point);
						continue;
					}
					goto IL_89;
					IL_76:
					point = enumerator.Current;
					goto IL_7F;
				}
			}
			list = list.OrderBy(new Func<Point, double>(SnappingProvider.<>c.<>9.#Byc)).ThenBy(new Func<Point, double>(SnappingProvider.<>c.<>9.#Cyc)).ToList<Point>();
			return SnappingProviderHelper.#Uqc(list, #HAb, #WLb);
		}

		// Token: 0x0600413B RID: 16699 RVA: 0x00131B58 File Offset: 0x0012FD58
		private static IEnumerable<Point> #5sc(IList<SnappingSegmentData> #IP)
		{
			HashSet<Point> hashSet = new HashSet<Point>();
			HashSet<Point> hashSet2;
			if (!false)
			{
				hashSet2 = hashSet;
			}
			IEnumerator<Point> enumerator = #IP.Select(new Func<SnappingSegmentData, Point>(SnappingProvider.<>c.<>9.#Dyc)).GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					Point item = enumerator.Current;
					hashSet2.Add(item);
				}
			}
			finally
			{
				if (6 == 0 || enumerator != null)
				{
					enumerator.Dispose();
				}
			}
			return hashSet2.OrderBy(new Func<Point, double>(SnappingProvider.<>c.<>9.#Eyc)).ThenBy(new Func<Point, double>(SnappingProvider.<>c.<>9.#Fyc));
		}

		// Token: 0x0600413C RID: 16700 RVA: 0x00131C64 File Offset: 0x0012FE64
		private void #6sc()
		{
			this.#b.ShapePolygonEdgesKeyPoints.Clear();
			this.#b.LinearObjectsKeyPoints.Clear();
			this.#b.ShapePolygonEdgesKeyPoints.AddRange(SnappingProvider.#5sc(this.#b.ShapePolygonsSegments));
			this.#b.LinearObjectsKeyPoints.AddRange(SnappingProvider.#5sc(this.#b.LinearObjectSegments));
		}

		// Token: 0x0600413D RID: 16701 RVA: 0x00131CF8 File Offset: 0x0012FEF8
		private unsafe static void #7sc(IList<SnappingSegmentData> #tqc, List<Point> #8sc)
		{
			if (false)
			{
				goto IL_78;
			}
			void* ptr = stackalloc byte[8];
			IL_0C:
			List<Point> list = new List<Point>();
			BoundingBoxDataLight[] array = #tqc.Select(new Func<SnappingSegmentData, BoundingBoxDataLight>(SnappingProvider.<>c.<>9.#Gyc)).ToArray<BoundingBoxDataLight>();
			PolygonData[] array2 = #tqc.Select(new Func<SnappingSegmentData, PolygonData>(SnappingProvider.<>c.<>9.#Hyc)).ToArray<PolygonData>();
			IL_78:
			*(int*)ptr = 0;
			for (;;)
			{
				SnappingSegmentData #Urc;
				BoundingBoxDataLight boundingBoxDataLight;
				PolygonData polygonData;
				if (*(int*)ptr >= #tqc.Count)
				{
					list.Sort();
					list.#31d(new Comparison<Point>(SnappingProvider.<>c.<>9.#Iyc));
					#8sc.AddRange(list.OrderBy(new Func<Point, double>(SnappingProvider.<>c.<>9.#Jyc)).ThenBy(new Func<Point, double>(SnappingProvider.<>c.<>9.#Kyc)));
					if (!false)
					{
						break;
					}
					goto IL_F6;
				}
				else
				{
					#Urc = #tqc[*(int*)ptr];
					boundingBoxDataLight = array[*(int*)ptr];
					polygonData = array2[*(int*)ptr];
					*(int*)((byte*)ptr + 4) = *(int*)ptr + 1;
				}
				IL_100:
				if (*(int*)((byte*)ptr + 4) >= #tqc.Count)
				{
					*(int*)ptr = *(int*)ptr + 1;
					continue;
				}
				Point? point;
				if (6 != 0)
				{
					if (polygonData != null && polygonData == array2[*(int*)((byte*)ptr + 4)])
					{
						goto IL_F6;
					}
					if (false)
					{
						goto IL_0C;
					}
					if (!boundingBoxDataLight.#pFb(array[*(int*)((byte*)ptr + 4)]) || false)
					{
						goto IL_F6;
					}
					SnappingSegmentData #Vrc = #tqc[*(int*)((byte*)ptr + 4)];
					point = #jsc.#6rc(#Urc, #Vrc);
				}
				if (point != null)
				{
					list.Add(point.Value);
				}
				IL_F6:
				*(int*)((byte*)ptr + 4) = *(int*)((byte*)ptr + 4) + 1;
				goto IL_100;
			}
		}

		// Token: 0x0600413E RID: 16702 RVA: 0x00131EF0 File Offset: 0x001300F0
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		protected static void #9sc(IList<SnappingSegmentData> #tqc, IList<SnappingSegmentData> #atc, List<Point> #8sc)
		{
			string #R0d = #Phc.#3hc(107367243);
			Component #x6c = Component.Geometry;
			string #Qic = #Phc.#3hc(107460541);
			if (8 != 0)
			{
				#X0d.#V0d(#tqc, #R0d, #x6c, #Qic);
			}
			#X0d.#V0d(#atc, #Phc.#3hc(107460456), Component.Geometry, #Phc.#3hc(107460475));
			#X0d.#V0d(#8sc, #Phc.#3hc(107460390), Component.Geometry, #Phc.#3hc(107460405));
			#8sc.Clear();
			HashSet<Point> hashSet = new HashSet<Point>();
			using (IEnumerator<SnappingSegmentData> enumerator = #atc.GetEnumerator())
			{
				if (3 != 0)
				{
					goto IL_CA;
				}
				IL_7A:
				SnappingSegmentData #Urc = enumerator.Current;
				using (IEnumerator<SnappingSegmentData> enumerator2 = #tqc.GetEnumerator())
				{
					for (;;)
					{
						bool flag2;
						bool flag = flag2 = enumerator2.MoveNext();
						Point? point;
						if (!false)
						{
							if (!flag)
							{
								break;
							}
							SnappingSegmentData #Vrc = enumerator2.Current;
							point = #jsc.#plc(#Urc, #Vrc);
							flag2 = (point != null);
						}
						if (flag2)
						{
							hashSet.Add(point.Value);
						}
					}
				}
				IL_CA:
				if (enumerator.MoveNext())
				{
					goto IL_7A;
				}
			}
			#8sc.AddRange(hashSet.OrderBy(new Func<Point, double>(SnappingProvider.<>c.<>9.#Lyc)).ThenBy(new Func<Point, double>(SnappingProvider.<>c.<>9.#Myc)));
		}

		// Token: 0x0600413F RID: 16703 RVA: 0x00132094 File Offset: 0x00130294
		protected static void #btc(IList<SnappingSegmentData> #tqc, IList<SnappingSegmentData> #atc, IList<Point> #8sc)
		{
			#X0d.#V0d(#tqc, #Phc.#3hc(107367243), Component.Geometry, #Phc.#3hc(107460541));
			#X0d.#V0d(#atc, #Phc.#3hc(107460456), Component.Geometry, #Phc.#3hc(107460475));
			#X0d.#V0d(#8sc, #Phc.#3hc(107460390), Component.Geometry, #Phc.#3hc(107460405));
			#8sc.Clear();
			HashSet<Point> hashSet = new HashSet<Point>();
			IEnumerator<SnappingSegmentData> enumerator = #atc.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					SnappingSegmentData #Urc = enumerator.Current;
					foreach (SnappingSegmentData #Vrc in #tqc)
					{
						Point? point = #jsc.#6rc(#Urc, #Vrc);
						if (point != null)
						{
							hashSet.Add(point.Value);
						}
					}
				}
			}
			finally
			{
				if (enumerator == null)
				{
					goto IL_D2;
				}
				IL_CC:
				enumerator.Dispose();
				IL_D2:
				if (false)
				{
					goto IL_CC;
				}
			}
			ICollection<Point>[] array = new ICollection<Point>[1];
			array[0] = hashSet.OrderBy(new Func<Point, double>(SnappingProvider.<>c.<>9.#Nyc)).ThenBy(new Func<Point, double>(SnappingProvider.<>c.<>9.#Oyc)).ToList<Point>();
			#8sc.#pR(array);
		}

		// Token: 0x06004140 RID: 16704 RVA: 0x00132240 File Offset: 0x00130440
		private void #7sc()
		{
			do
			{
				if (!false)
				{
					this.#b.ShapesIntersectionPoints.Clear();
				}
				SnappingProvider.#7sc(this.#b.ShapePolygonsSegments, this.#b.ShapesIntersectionPoints);
			}
			while (false);
		}

		// Token: 0x06004141 RID: 16705 RVA: 0x001322A0 File Offset: 0x001304A0
		private void #ctc()
		{
			this.#b.GridLineShapePolygonEdgeIntersectionPoints.Clear();
			this.#b.GridLineLinearObjectIntersectionPoints.Clear();
			SnappingProvider.#9sc(this.#b.LinearObjectSegments, this.#b.GridLineSegments, this.#b.GridLineLinearObjectIntersectionPoints);
			SnappingProvider.#9sc(this.#b.ShapePolygonsSegments, this.#b.GridLineSegments, this.#b.GridLineShapePolygonEdgeIntersectionPoints);
		}

		// Token: 0x04001D4C RID: 7500
		private const double #a = 0.0001;

		// Token: 0x04001D4D RID: 7501
		private readonly SnappingProviderHelper #b;

		// Token: 0x04001D4E RID: 7502
		[CompilerGenerated]
		private bool #c;

		// Token: 0x04001D4F RID: 7503
		[CompilerGenerated]
		private double #d;
	}
}
