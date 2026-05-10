using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;
using #Fmc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace StructurePoint.CoreAssets.Geometry.Helpers
{
	// Token: 0x020007D0 RID: 2000
	public sealed class SnappingProviderHelper
	{
		// Token: 0x17001330 RID: 4912
		// (get) Token: 0x0600400A RID: 16394 RVA: 0x00036204 File Offset: 0x00034404
		// (set) Token: 0x0600400B RID: 16395 RVA: 0x00036210 File Offset: 0x00034410
		public #Wsc SnapDataOriginFilter { get; set; }

		// Token: 0x17001331 RID: 4913
		// (get) Token: 0x0600400C RID: 16396 RVA: 0x00036221 File Offset: 0x00034421
		// (set) Token: 0x0600400D RID: 16397 RVA: 0x0003622D File Offset: 0x0003442D
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public List<SnappingSegmentData> LinearObjectSegments { get; set; }

		// Token: 0x17001332 RID: 4914
		// (get) Token: 0x0600400E RID: 16398 RVA: 0x0003623E File Offset: 0x0003443E
		// (set) Token: 0x0600400F RID: 16399 RVA: 0x0003624A File Offset: 0x0003444A
		[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public List<SnappingSegmentData> ShapePolygonsSegments { get; set; }

		// Token: 0x17001333 RID: 4915
		// (get) Token: 0x06004010 RID: 16400 RVA: 0x0003625B File Offset: 0x0003445B
		// (set) Token: 0x06004011 RID: 16401 RVA: 0x00036267 File Offset: 0x00034467
		[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public List<SnappingSegmentData> GridLineSegments { get; set; }

		// Token: 0x17001334 RID: 4916
		// (get) Token: 0x06004012 RID: 16402 RVA: 0x00036278 File Offset: 0x00034478
		// (set) Token: 0x06004013 RID: 16403 RVA: 0x00036284 File Offset: 0x00034484
		[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public List<SnappingSegmentData> AllShapeSegments { get; set; }

		// Token: 0x17001335 RID: 4917
		// (get) Token: 0x06004014 RID: 16404 RVA: 0x00036295 File Offset: 0x00034495
		// (set) Token: 0x06004015 RID: 16405 RVA: 0x000362A1 File Offset: 0x000344A1
		[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public List<SnappingSegmentData> AdditionalFiguresSegments { get; set; }

		// Token: 0x17001336 RID: 4918
		// (get) Token: 0x06004016 RID: 16406 RVA: 0x000362B2 File Offset: 0x000344B2
		// (set) Token: 0x06004017 RID: 16407 RVA: 0x000362BE File Offset: 0x000344BE
		[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public List<Point> ShapesIntersectionPoints { get; set; }

		// Token: 0x17001337 RID: 4919
		// (get) Token: 0x06004018 RID: 16408 RVA: 0x000362CF File Offset: 0x000344CF
		// (set) Token: 0x06004019 RID: 16409 RVA: 0x000362DB File Offset: 0x000344DB
		[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public List<Point> AdditionalFiguresPoints { get; set; }

		// Token: 0x17001338 RID: 4920
		// (get) Token: 0x0600401A RID: 16410 RVA: 0x000362EC File Offset: 0x000344EC
		// (set) Token: 0x0600401B RID: 16411 RVA: 0x000362F8 File Offset: 0x000344F8
		[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public List<Point> GridLineShapePolygonEdgeIntersectionPoints { get; set; }

		// Token: 0x17001339 RID: 4921
		// (get) Token: 0x0600401C RID: 16412 RVA: 0x00036309 File Offset: 0x00034509
		// (set) Token: 0x0600401D RID: 16413 RVA: 0x00036315 File Offset: 0x00034515
		[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public List<Point> GridLineLinearObjectIntersectionPoints { get; set; }

		// Token: 0x1700133A RID: 4922
		// (get) Token: 0x0600401E RID: 16414 RVA: 0x00036326 File Offset: 0x00034526
		// (set) Token: 0x0600401F RID: 16415 RVA: 0x00036332 File Offset: 0x00034532
		[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public List<Point> GridLineAdditionalFiguresIntersectionPoints { get; set; }

		// Token: 0x1700133B RID: 4923
		// (get) Token: 0x06004020 RID: 16416 RVA: 0x00036343 File Offset: 0x00034543
		// (set) Token: 0x06004021 RID: 16417 RVA: 0x0003634F File Offset: 0x0003454F
		[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public List<Point> ShapeAdditionalFiguresIntersectionPoints { get; set; }

		// Token: 0x1700133C RID: 4924
		// (get) Token: 0x06004022 RID: 16418 RVA: 0x00036360 File Offset: 0x00034560
		// (set) Token: 0x06004023 RID: 16419 RVA: 0x0003636C File Offset: 0x0003456C
		[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public List<Point> AdditionalFiguresIntersectionPoints { get; set; }

		// Token: 0x1700133D RID: 4925
		// (get) Token: 0x06004024 RID: 16420 RVA: 0x0003637D File Offset: 0x0003457D
		// (set) Token: 0x06004025 RID: 16421 RVA: 0x00036389 File Offset: 0x00034589
		[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public List<Point> ShapePolygonEdgesKeyPoints { get; set; }

		// Token: 0x1700133E RID: 4926
		// (get) Token: 0x06004026 RID: 16422 RVA: 0x0003639A File Offset: 0x0003459A
		// (set) Token: 0x06004027 RID: 16423 RVA: 0x000363A6 File Offset: 0x000345A6
		[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public List<Point> AdditionalFigureEdgesKeyPoints { get; set; }

		// Token: 0x1700133F RID: 4927
		// (get) Token: 0x06004028 RID: 16424 RVA: 0x000363B7 File Offset: 0x000345B7
		// (set) Token: 0x06004029 RID: 16425 RVA: 0x000363C3 File Offset: 0x000345C3
		[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public List<Point> LinearObjectsKeyPoints { get; set; }

		// Token: 0x17001340 RID: 4928
		// (get) Token: 0x0600402A RID: 16426 RVA: 0x000363D4 File Offset: 0x000345D4
		// (set) Token: 0x0600402B RID: 16427 RVA: 0x000363E0 File Offset: 0x000345E0
		[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public List<Point> AllShapeSnappingPoints { get; set; }

		// Token: 0x17001341 RID: 4929
		// (get) Token: 0x0600402C RID: 16428 RVA: 0x000363F1 File Offset: 0x000345F1
		// (set) Token: 0x0600402D RID: 16429 RVA: 0x000363FD File Offset: 0x000345FD
		[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public List<Point> GridIntersectionPoints { get; set; }

		// Token: 0x17001342 RID: 4930
		// (get) Token: 0x0600402E RID: 16430 RVA: 0x0003640E File Offset: 0x0003460E
		// (set) Token: 0x0600402F RID: 16431 RVA: 0x0003641A File Offset: 0x0003461A
		[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public Dictionary<Point, SnappingPointData> GridIntersectionSnappingPointDataDictionary { get; set; }

		// Token: 0x17001343 RID: 4931
		// (get) Token: 0x06004030 RID: 16432 RVA: 0x0003642B File Offset: 0x0003462B
		// (set) Token: 0x06004031 RID: 16433 RVA: 0x00036437 File Offset: 0x00034637
		[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public List<Point> LinearObjectPoints { get; set; }

		// Token: 0x17001344 RID: 4932
		// (get) Token: 0x06004032 RID: 16434 RVA: 0x00036448 File Offset: 0x00034648
		// (set) Token: 0x06004033 RID: 16435 RVA: 0x00036454 File Offset: 0x00034654
		[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public List<Point> NodePoints { get; set; }

		// Token: 0x17001345 RID: 4933
		// (get) Token: 0x06004034 RID: 16436 RVA: 0x00036465 File Offset: 0x00034665
		// (set) Token: 0x06004035 RID: 16437 RVA: 0x00036471 File Offset: 0x00034671
		[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public List<Point> ShapePolygonsPoints { get; set; }

		// Token: 0x17001346 RID: 4934
		// (get) Token: 0x06004036 RID: 16438 RVA: 0x00036482 File Offset: 0x00034682
		// (set) Token: 0x06004037 RID: 16439 RVA: 0x0003648E File Offset: 0x0003468E
		[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public List<Point> FreeNodesPoints { get; set; }

		// Token: 0x17001347 RID: 4935
		// (get) Token: 0x06004038 RID: 16440 RVA: 0x0003649F File Offset: 0x0003469F
		// (set) Token: 0x06004039 RID: 16441 RVA: 0x000364AB File Offset: 0x000346AB
		public double MaxDistance { get; set; }

		// Token: 0x0600403A RID: 16442 RVA: 0x0012AF58 File Offset: 0x00129158
		public SnappingProviderHelper(double maxDistance, #Wsc snapDataOriginFilter)
		{
			this.SnapDataOriginFilter = snapDataOriginFilter;
			this.MaxDistance = maxDistance;
			this.LinearObjectSegments = new List<SnappingSegmentData>();
			this.ShapePolygonsSegments = new List<SnappingSegmentData>();
			this.GridLineSegments = new List<SnappingSegmentData>();
			this.AllShapeSegments = new List<SnappingSegmentData>();
			this.AdditionalFiguresSegments = new List<SnappingSegmentData>();
			this.ShapesIntersectionPoints = new List<Point>();
			this.GridLineShapePolygonEdgeIntersectionPoints = new List<Point>();
			this.GridLineLinearObjectIntersectionPoints = new List<Point>();
			this.GridLineAdditionalFiguresIntersectionPoints = new List<Point>();
			this.ShapeAdditionalFiguresIntersectionPoints = new List<Point>();
			this.AdditionalFiguresIntersectionPoints = new List<Point>();
			this.ShapePolygonEdgesKeyPoints = new List<Point>();
			this.AdditionalFigureEdgesKeyPoints = new List<Point>();
			this.LinearObjectsKeyPoints = new List<Point>();
			this.AdditionalFiguresPoints = new List<Point>();
			this.AllShapeSnappingPoints = new List<Point>();
			this.GridIntersectionPoints = new List<Point>();
			this.GridIntersectionSnappingPointDataDictionary = new Dictionary<Point, SnappingPointData>();
			this.LinearObjectPoints = new List<Point>();
			this.NodePoints = new List<Point>();
			this.ShapePolygonsPoints = new List<Point>();
			this.FreeNodesPoints = new List<Point>();
		}

		// Token: 0x0600403B RID: 16443 RVA: 0x0012B06C File Offset: 0x0012926C
		[SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public Point? #bNb(List<Point> #BP, Point #Ng, double #WLb)
		{
			#X0d.#V0d(#BP, #Phc.#3hc(107358670), Component.Geometry, #Phc.#3hc(107367381));
			return SnappingProviderHelper.#6qc(#BP, #Ng, #WLb);
		}

		// Token: 0x0600403C RID: 16444 RVA: 0x0012B0BC File Offset: 0x001292BC
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		[SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
		public Point3D? #bNb(List<Point> #BP, Point3D #HAb, double #WLb)
		{
			#X0d.#V0d(#BP, #Phc.#3hc(107358670), Component.Geometry, #Phc.#3hc(107367296));
			return SnappingProviderHelper.#Uqc(#BP, #HAb, #WLb);
		}

		// Token: 0x0600403D RID: 16445 RVA: 0x0012B10C File Offset: 0x0012930C
		public #fuc #sqc(IList<SnappingSegmentData> #tqc, Point3D #HAb, double #WLb)
		{
			do
			{
				if (4 != 0)
				{
					#X0d.#V0d(#tqc, #Phc.#3hc(107367243), Component.Geometry, #Phc.#3hc(107367234));
				}
			}
			while (false);
			return this.#sqc(#tqc, #HAb, #WLb, #iuc.#f);
		}

		// Token: 0x0600403E RID: 16446 RVA: 0x0012B168 File Offset: 0x00129368
		public unsafe #fuc #sqc(IList<SnappingSegmentData> #tqc, Point3D #HAb, double #WLb, #iuc #uqc)
		{
			void* ptr = stackalloc byte[16];
			Point #Ng;
			SnappingSegmentData snappingSegmentData;
			for (;;)
			{
				#X0d.#V0d(#tqc, #Phc.#3hc(107367243), Component.Geometry, #Phc.#3hc(107367234));
				#Ng = PointsConverter.#vsc(#HAb);
				if (7 == 0)
				{
					goto IL_FA;
				}
				snappingSegmentData = null;
				*(double*)ptr = 0.0;
				using (IEnumerator<SnappingSegmentData> enumerator = #tqc.GetEnumerator())
				{
					for (;;)
					{
						if (false)
						{
							goto IL_9D;
						}
						bool flag3;
						SnappingSegmentData snappingSegmentData2;
						double? num;
						double? num2;
						do
						{
							IL_C9:
							bool flag2;
							bool flag = flag2 = (flag3 = enumerator.MoveNext());
							if (!false)
							{
								if (!flag)
								{
									goto Block_13;
								}
								if (false)
								{
									goto IL_BA;
								}
								snappingSegmentData2 = enumerator.Current;
								num = #jsc.#lcb(snappingSegmentData2, #Ng);
								num2 = num;
								*(double*)((byte*)ptr + 8) = #WLb;
								flag3 = (flag2 = (num2.GetValueOrDefault() > *(double*)((byte*)ptr + 8)));
							}
							if (!false)
							{
								flag3 = ((flag2 ? 1 : 0) == 0);
							}
						}
						while (!(flag3 & num2 != null));
						if (snappingSegmentData != null)
						{
							num2 = num;
							goto IL_9D;
						}
						IL_BA:
						if (!false)
						{
							snappingSegmentData = snappingSegmentData2;
							*(double*)ptr = num.Value;
							goto IL_C9;
						}
						continue;
						IL_9D:
						*(double*)((byte*)ptr + 8) = *(double*)ptr;
						if (num2.GetValueOrDefault() < *(double*)((byte*)ptr + 8) & num2 != null)
						{
							goto IL_BA;
						}
						goto IL_C9;
					}
					Block_13:;
				}
				if (snappingSegmentData != null)
				{
					break;
				}
				if (!false)
				{
					goto Block_5;
				}
			}
			Point? point = #jsc.#gsc(snappingSegmentData, #Ng);
			if (point == null)
			{
				return null;
			}
			IL_FA:
			return new #fuc(snappingSegmentData, point.Value, #uqc, snappingSegmentData.SnapOriginInfo);
			Block_5:
			return null;
		}

		// Token: 0x0600403F RID: 16447 RVA: 0x000364BC File Offset: 0x000346BC
		public Point3D? #vqc(Point3D #HAb)
		{
			return this.#vqc(#HAb, this.MaxDistance);
		}

		// Token: 0x06004040 RID: 16448 RVA: 0x000364DF File Offset: 0x000346DF
		public Point3D? #vqc(Point3D #HAb, double #WLb)
		{
			return SnappingProviderHelper.#Uqc(this.GridIntersectionPoints, #HAb, #WLb);
		}

		// Token: 0x06004041 RID: 16449 RVA: 0x00036502 File Offset: 0x00034702
		public #fuc #wqc(Point3D #HAb)
		{
			return this.#sqc(this.GridLineSegments, #HAb, this.MaxDistance, #iuc.#b);
		}

		// Token: 0x06004042 RID: 16450 RVA: 0x00036534 File Offset: 0x00034734
		public #fuc #wqc(Point3D #HAb, double #WLb)
		{
			return this.#sqc(this.GridLineSegments, #HAb, #WLb, #iuc.#b);
		}

		// Token: 0x06004043 RID: 16451 RVA: 0x0012B2E4 File Offset: 0x001294E4
		public void #xqc(#trc #VLb, Point3D #HAb, bool #yqc, bool #zqc, bool #Aqc, double #WLb)
		{
			#X0d.#V0d(#VLb, #Phc.#3hc(107367181), Component.SectionEditor, #Phc.#3hc(107367168));
			if (#VLb.ShouldCollect && #yqc && this.SnapDataOriginFilter.#Usc(#juc.#e))
			{
				#fuc #lrc = this.#wqc(#HAb, #WLb);
				#VLb.#Qfb(#lrc, #huc.#a);
			}
			if (#VLb.ShouldCollect && #zqc && this.SnapDataOriginFilter.#Usc(#juc.#b))
			{
				#fuc #lrc2 = this.#sqc(this.ShapePolygonsSegments, #HAb, #WLb);
				#VLb.#Qfb(#lrc2, #huc.#e);
			}
			if (#VLb.ShouldCollect && #zqc && this.SnapDataOriginFilter.#Usc(#juc.#d))
			{
				#fuc #lrc3 = this.#sqc(this.LinearObjectSegments, #HAb, #WLb);
				#VLb.#Qfb(#lrc3, #huc.#e);
			}
			if (#VLb.ShouldCollect && #Aqc && this.SnapDataOriginFilter.#Usc(#juc.#h))
			{
				#fuc #lrc4 = this.#sqc(this.AdditionalFiguresSegments, #HAb, #WLb);
				#VLb.#Qfb(#lrc4, #huc.#l);
			}
		}

		// Token: 0x06004044 RID: 16452 RVA: 0x0012B428 File Offset: 0x00129628
		private void #Bqc(#trc #VLb, Point3D #HAb, bool #zqc, double #WLb)
		{
			Point3D? #Ng;
			if (#VLb.ShouldCollect && #zqc && this.SnapDataOriginFilter.#Usc(#juc.#b))
			{
				if (!true)
				{
					goto IL_7A;
				}
				#Ng = this.#bNb(this.ShapePolygonsPoints, #HAb, #WLb);
				#VLb.#Qfb(#Ng, #huc.#b);
			}
			if (#VLb.ShouldCollect && #zqc && this.SnapDataOriginFilter.#Usc(#juc.#c))
			{
				if (8 != 0)
				{
					#Ng = this.#bNb(this.NodePoints, #HAb, #WLb);
				}
				#VLb.#Qfb(#Ng, #huc.#c);
			}
			IL_7A:
			if (#VLb.ShouldCollect && #zqc && this.SnapDataOriginFilter.#Usc(#juc.#d))
			{
				#Ng = this.#bNb(this.LinearObjectPoints, #HAb, #WLb);
				#VLb.#Qfb(#Ng, #huc.#d);
			}
		}

		// Token: 0x06004045 RID: 16453 RVA: 0x0012B528 File Offset: 0x00129728
		private void #Cqc(#trc #VLb, Point3D #HAb, bool #Dqc, double #WLb)
		{
			bool flag2;
			bool flag = flag2 = #VLb.ShouldCollect;
			while (!false)
			{
				bool flag3 = flag2 = (flag = (flag2 && #Dqc));
				if (!false)
				{
					if (flag3)
					{
						if (7 != 0)
						{
							flag = this.SnapDataOriginFilter.#Usc(#juc.#f);
							break;
						}
						IL_2D:
						if (!false)
						{
							Point3D? #Ng;
							#VLb.#Qfb(#Ng, #huc.#j);
						}
					}
					return;
				}
			}
			if (!flag)
			{
				return;
			}
			if (8 != 0)
			{
				Point3D? #Ng = this.#bNb(this.FreeNodesPoints, #HAb, #WLb);
				goto IL_2D;
			}
			goto IL_2D;
		}

		// Token: 0x06004046 RID: 16454 RVA: 0x0012B59C File Offset: 0x0012979C
		private void #Eqc(#trc #VLb, Point3D #HAb, bool #Fqc, double #WLb)
		{
			if (#VLb.ShouldCollect && #Fqc && this.SnapDataOriginFilter.#Usc(#juc.#j))
			{
				List<Point> list = new List<Point>();
				Point item = SnappingProviderHelper.#c;
				if (!false)
				{
					list.Add(item);
				}
				Point3D? #Ng = this.#bNb(list, #HAb, #WLb);
				#VLb.#Qfb(#Ng, #huc.#n);
			}
		}

		// Token: 0x06004047 RID: 16455 RVA: 0x0012B60C File Offset: 0x0012980C
		private void #Gqc(#trc #VLb, Point3D #HAb, bool #Hqc, double #WLb)
		{
			Point3D? #Ng;
			if (#VLb.ShouldCollect && #Hqc && this.SnapDataOriginFilter.#Usc(#juc.#b))
			{
				if (!true)
				{
					goto IL_7A;
				}
				#Ng = this.#bNb(this.ShapePolygonsPoints, #HAb, #WLb);
				#VLb.#Qfb(#Ng, #huc.#g);
			}
			if (#VLb.ShouldCollect && #Hqc && this.SnapDataOriginFilter.#Usc(#juc.#b))
			{
				if (8 != 0)
				{
					#Ng = this.#bNb(this.ShapePolygonEdgesKeyPoints, #HAb, #WLb);
				}
				#VLb.#Qfb(#Ng, #huc.#g);
			}
			IL_7A:
			if (#VLb.ShouldCollect && #Hqc && this.SnapDataOriginFilter.#Usc(#juc.#d))
			{
				#Ng = this.#bNb(this.LinearObjectsKeyPoints, #HAb, #WLb);
				#VLb.#Qfb(#Ng, #huc.#g);
			}
		}

		// Token: 0x06004048 RID: 16456 RVA: 0x0012B70C File Offset: 0x0012990C
		private void #Iqc(#trc #VLb, Point3D #HAb, bool #Jqc, double #WLb)
		{
			bool flag2;
			bool flag = flag2 = #VLb.ShouldCollect;
			while (!false)
			{
				bool flag3 = flag2 = (flag = (flag2 && #Jqc));
				if (!false)
				{
					if (flag3)
					{
						if (7 != 0)
						{
							flag = this.SnapDataOriginFilter.#Usc(#juc.#g);
							break;
						}
						IL_2D:
						if (!false)
						{
							Point3D? #Ng;
							#VLb.#Qfb(#Ng, #huc.#k);
						}
					}
					return;
				}
			}
			if (!flag)
			{
				return;
			}
			if (8 != 0)
			{
				Point3D? #Ng = this.#bNb(this.ShapesIntersectionPoints, #HAb, #WLb);
				goto IL_2D;
			}
			goto IL_2D;
		}

		// Token: 0x06004049 RID: 16457 RVA: 0x0012B780 File Offset: 0x00129980
		private void #Kqc(#trc #VLb, Point3D #HAb, bool #Jqc, double #WLb)
		{
			bool flag2;
			bool flag = flag2 = (#VLb.ShouldCollect && #Jqc);
			if (!false)
			{
				if (flag && this.SnapDataOriginFilter.#Usc(#juc.#e) && this.SnapDataOriginFilter.#Usc(#juc.#h))
				{
					Point3D? #Ng = this.#bNb(this.GridLineAdditionalFiguresIntersectionPoints, #HAb, #WLb);
					#VLb.#Qfb(#Ng, #huc.#l);
				}
				bool flag3 = flag2 = #VLb.ShouldCollect;
				if (!false)
				{
					if (!flag3 || !#Jqc)
					{
						goto IL_94;
					}
					flag2 = this.SnapDataOriginFilter.#Usc(#juc.#b);
				}
			}
			if (flag2 && this.SnapDataOriginFilter.#Usc(#juc.#h))
			{
				Point3D? #Ng = this.#bNb(this.ShapeAdditionalFiguresIntersectionPoints, #HAb, #WLb);
				#VLb.#Qfb(#Ng, #huc.#l);
			}
			IL_94:
			if (#VLb.ShouldCollect && #Jqc && this.SnapDataOriginFilter.#Usc(#juc.#h))
			{
				Point3D? #Ng = this.#bNb(this.AdditionalFiguresIntersectionPoints, #HAb, #WLb);
				#VLb.#Qfb(#Ng, #huc.#l);
			}
		}

		// Token: 0x0600404A RID: 16458 RVA: 0x0012B89C File Offset: 0x00129A9C
		private void #Lqc(#trc #VLb, Point3D #HAb, bool #Jqc, double #WLb)
		{
			bool flag2;
			bool flag = flag2 = #VLb.ShouldCollect;
			while (!false)
			{
				bool flag3 = flag2 = (flag = (flag2 && #Jqc));
				if (!false)
				{
					if (flag3)
					{
						if (7 != 0)
						{
							flag = this.SnapDataOriginFilter.#Usc(#juc.#h);
							break;
						}
						IL_2D:
						if (!false)
						{
							Point3D? #Ng;
							#VLb.#Qfb(#Ng, #huc.#l);
						}
					}
					return;
				}
			}
			if (!flag)
			{
				return;
			}
			if (8 != 0)
			{
				Point3D? #Ng = this.#bNb(this.AdditionalFiguresPoints, #HAb, #WLb);
				goto IL_2D;
			}
			goto IL_2D;
		}

		// Token: 0x0600404B RID: 16459 RVA: 0x0012B910 File Offset: 0x00129B10
		private void #Mqc(#trc #VLb, Point3D #HAb, bool #Nqc, double #WLb)
		{
			bool flag2;
			bool flag = flag2 = #VLb.ShouldCollect;
			while (!false)
			{
				bool flag3 = flag2 = (flag = (flag2 && #Nqc));
				if (!false)
				{
					if (flag3)
					{
						if (7 != 0)
						{
							flag = this.SnapDataOriginFilter.#Usc(#juc.#h);
							break;
						}
						IL_2D:
						if (!false)
						{
							Point3D? #Ng;
							#VLb.#Qfb(#Ng, #huc.#m);
						}
					}
					return;
				}
			}
			if (!flag)
			{
				return;
			}
			if (8 != 0)
			{
				Point3D? #Ng = this.#bNb(this.AdditionalFigureEdgesKeyPoints, #HAb, #WLb);
				goto IL_2D;
			}
			goto IL_2D;
		}

		// Token: 0x0600404C RID: 16460 RVA: 0x0012B984 File Offset: 0x00129B84
		private void #Oqc(#trc #VLb, Point3D #HAb, bool #Pqc, double #WLb)
		{
			if (#VLb.ShouldCollect && #Pqc && this.SnapDataOriginFilter.#Usc(#juc.#e) && this.SnapDataOriginFilter.#Usc(#juc.#b))
			{
				Point3D? #Ng = this.#bNb(this.GridLineShapePolygonEdgeIntersectionPoints, #HAb, #WLb);
				#VLb.#Qfb(#Ng, #huc.#h);
			}
			if (#VLb.ShouldCollect && #Pqc && this.SnapDataOriginFilter.#Usc(#juc.#e) && this.SnapDataOriginFilter.#Usc(#juc.#d))
			{
				Point3D? #Ng = this.#bNb(this.GridLineLinearObjectIntersectionPoints, #HAb, #WLb);
				#VLb.#Qfb(#Ng, #huc.#h);
			}
		}

		// Token: 0x0600404D RID: 16461 RVA: 0x0012BA68 File Offset: 0x00129C68
		public void #Qqc(#trc #VLb, Point3D #HAb, bool #yqc, bool #zqc, bool #Rqc, bool #Aqc, bool #Sqc, bool #Tqc, bool #Jqc, bool #Fqc, double #WLb)
		{
			#X0d.#V0d(#VLb, #Phc.#3hc(107367181), Component.SectionEditor, #Phc.#3hc(107366603));
			if (!#VLb.ShouldCollect)
			{
				goto IL_44;
			}
			IL_2C:
			this.#Cqc(#VLb, #HAb, #Tqc, #WLb);
			IL_44:
			if (4 == 0)
			{
				goto IL_2C;
			}
			bool flag4;
			bool flag3;
			bool flag2;
			bool flag = flag2 = (flag3 = (flag4 = #VLb.ShouldCollect));
			if (false)
			{
				goto IL_11E;
			}
			if (flag)
			{
				this.#Gqc(#VLb, #HAb, #Rqc, #WLb);
			}
			bool flag5 = #VLb.ShouldCollect;
			IL_67:
			bool flag6 = flag5 && #yqc;
			IL_69:
			if (flag6 && this.SnapDataOriginFilter.#Usc(#juc.#e))
			{
				Point3D? #Ng = this.#vqc(#HAb, #WLb);
				if (#Ng != null)
				{
					if (false)
					{
						goto IL_B6;
					}
					string #orc = this.#Vqc(PointsConverter.#vsc(#Ng.Value));
					#VLb.#Qfb(#Ng, #huc.#f, #orc);
				}
			}
			flag3 = (flag2 = #VLb.ShouldCollect);
			IL_B1:
			if (5 == 0)
			{
				goto IL_F0;
			}
			if (!flag2)
			{
				goto IL_C2;
			}
			IL_B6:
			this.#Eqc(#VLb, #HAb, #Fqc, #WLb);
			IL_C2:
			if (#VLb.ShouldCollect)
			{
				this.#Bqc(#VLb, #HAb, #zqc, #WLb);
			}
			if (#VLb.ShouldCollect)
			{
				this.#Iqc(#VLb, #HAb, #Jqc, #WLb);
			}
			flag3 = #VLb.ShouldCollect;
			IL_F0:
			if (flag3)
			{
				this.#Kqc(#VLb, #HAb, #Jqc, #WLb);
			}
			bool flag7 = flag5 = #VLb.ShouldCollect;
			if (6 == 0)
			{
				goto IL_67;
			}
			if (flag7)
			{
				this.#Lqc(#VLb, #HAb, #Aqc, #WLb);
			}
			flag3 = (flag2 = (flag4 = #VLb.ShouldCollect));
			IL_11E:
			if (4 == 0)
			{
				goto IL_B1;
			}
			if (flag4)
			{
				this.#Mqc(#VLb, #HAb, #Sqc, #WLb);
			}
			bool flag8 = flag6 = #VLb.ShouldCollect;
			if (!false)
			{
				if (flag8)
				{
					this.#Oqc(#VLb, #HAb, #Jqc, #WLb);
				}
				return;
			}
			goto IL_69;
		}

		// Token: 0x0600404E RID: 16462 RVA: 0x0012BC08 File Offset: 0x00129E08
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public static Point3D? #Uqc(List<Point> #BP, Point3D #HAb, double #WLb)
		{
			Point #7qc = PointsConverter.#vsc(#HAb);
			Point? point;
			for (;;)
			{
				if (!false)
				{
					point = SnappingProviderHelper.#6qc(#BP, #7qc, #WLb);
				}
				if (6 == 0 || point != null || false || 2 == 0)
				{
					break;
				}
				Point3D? result = null;
				if (-1 != 0)
				{
					return result;
				}
			}
			return new Point3D?(PointsConverter.#vsc(point.Value, #HAb.Z));
		}

		// Token: 0x0600404F RID: 16463 RVA: 0x0012BC84 File Offset: 0x00129E84
		private string #Vqc(Point #Ng)
		{
			SnappingPointData snappingPointData = this.GridIntersectionSnappingPointDataDictionary.#F1d(#Ng);
			if (snappingPointData == null)
			{
				return null;
			}
			return snappingPointData.OriginInfo;
		}

		// Token: 0x06004050 RID: 16464 RVA: 0x0012BCCC File Offset: 0x00129ECC
		private static int #Wqc(Point #Xqc, Point #Ng, double #WLb)
		{
			int result;
			if (!false)
			{
				double num = #Ng.X - #Xqc.X;
				int num3;
				if (\u0006\u0002.\u0006\u0004(num) <= #WLb)
				{
					int num2 = num3 = 0;
					if (num2 == 0)
					{
						return num2;
					}
				}
				else
				{
					if (2 != 0 && num > 0.0)
					{
						goto IL_35;
					}
					num3 = -1;
				}
				int num4 = result = num3;
				if (num4 != 0)
				{
					return num4;
				}
				return result;
			}
			IL_35:
			result = 1;
			return result;
		}

		// Token: 0x06004051 RID: 16465 RVA: 0x0012BD30 File Offset: 0x00129F30
		private static int #Yqc(Point #Xqc, Point #Ng, double #WLb)
		{
			int result;
			if (!false)
			{
				double num = #Ng.Y - #Xqc.Y;
				int num3;
				if (\u0006\u0002.\u0006\u0004(num) <= #WLb)
				{
					int num2 = num3 = 0;
					if (num2 == 0)
					{
						return num2;
					}
				}
				else
				{
					if (2 != 0 && num > 0.0)
					{
						goto IL_35;
					}
					num3 = -1;
				}
				int num4 = result = num3;
				if (num4 != 0)
				{
					return num4;
				}
				return result;
			}
			IL_35:
			result = 1;
			return result;
		}

		// Token: 0x06004052 RID: 16466 RVA: 0x0012BD94 File Offset: 0x00129F94
		private static int #Zqc(Func<IList<Point>, int, bool> #0qc, IList<Point> #BP, int #1qc, int #1f, int #2qc)
		{
			for (;;)
			{
				IL_00:
				int i = #1qc;
				int num = 0;
				while (i >= num)
				{
					int num3;
					for (;;)
					{
						IL_05:
						int j = #1qc;
						for (;;)
						{
							IL_07:
							int num2 = #1f;
							while (j < num2)
							{
								if (false)
								{
									goto IL_05;
								}
								if (#0qc(#BP, #1qc))
								{
									break;
								}
								num3 = (i = (j = #1qc));
								if (false)
								{
									goto IL_07;
								}
								num2 = #2qc;
								if (!false)
								{
									goto Block_4;
								}
							}
							return #1qc;
						}
					}
					Block_4:
					int num4 = num = -#2qc;
					if (!false)
					{
						#1qc = num3 + num4;
						goto IL_00;
					}
				}
				break;
			}
			return #1qc;
		}

		// Token: 0x06004053 RID: 16467 RVA: 0x0012BDF0 File Offset: 0x00129FF0
		private unsafe static int #3qc(Func<IList<Point>, int, bool> #0qc, IList<Point> #BP, int #1f, int #4qc, bool #5qc)
		{
			if (8 == 0)
			{
				goto IL_7F;
			}
			void* ptr = stackalloc byte[8];
			int num = #5qc ? 1 : -1;
			int num2;
			int num4;
			int num6;
			if (!#5qc)
			{
				num2 = num * Math.Min(10, #4qc);
			}
			else
			{
				int num3 = num4 = num;
				int num5 = num6 = Math.Min(10, #1f - #4qc - 1);
				if (7 == 0)
				{
					goto IL_AF;
				}
				num2 = num3 * num5;
			}
			int num7 = num2;
			*(int*)ptr = #4qc + num7;
			*(int*)ptr = SnappingProviderHelper.#Zqc(#0qc, #BP, *(int*)ptr, #1f, num);
			int num9;
			int num8 = num9 = num7;
			if (false)
			{
				goto IL_83;
			}
			if (num8 <= 0)
			{
				goto IL_A3;
			}
			if (false)
			{
				goto IL_BB;
			}
			#4qc = *(int*)ptr;
			IL_71:
			*(int*)((byte*)ptr + 4) = #4qc + num7;
			if (*(int*)((byte*)ptr + 4) < 0)
			{
				goto IL_A3;
			}
			IL_7F:
			num9 = *(int*)((byte*)ptr + 4);
			IL_83:
			if (num9 < #1f && #0qc(#BP, *(int*)((byte*)ptr + 4)))
			{
				#4qc = *(int*)((byte*)ptr + 4);
				if (5 != 0)
				{
					goto IL_71;
				}
				goto IL_B1;
			}
			IL_A3:
			if (false)
			{
				goto IL_71;
			}
			if (#4qc <= 0)
			{
				goto IL_BB;
			}
			if (8 == 0)
			{
				goto IL_7F;
			}
			num4 = #4qc;
			num6 = #1f;
			IL_AF:
			if (num4 >= num6)
			{
				goto IL_BB;
			}
			IL_B1:
			if (#0qc(#BP, #4qc))
			{
				#4qc += num;
				goto IL_A3;
			}
			IL_BB:
			#4qc = Math.Max(0, #4qc);
			#4qc = Math.Min(#1f - 1, #4qc);
			if (!#0qc(#BP, #4qc))
			{
				#4qc += -num;
			}
			return #4qc;
		}

		// Token: 0x06004054 RID: 16468 RVA: 0x0012BF1C File Offset: 0x0012A11C
		[SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed. Suppression is OK here.")]
		private unsafe static Point? #6qc(List<Point> #BP, Point #7qc, double #WLb)
		{
			void* ptr = stackalloc byte[36];
			SnappingProviderHelper.#Uxc #Uxc = new SnappingProviderHelper.#Uxc();
			#Uxc.#a = #7qc;
			#Uxc.#b = #WLb;
			Func<IList<Point>, int, bool> #0qc = new Func<IList<Point>, int, bool>(#Uxc.#Oxc);
			Func<IList<Point>, int, bool> #0qc2 = new Func<IList<Point>, int, bool>(#Uxc.#Rxc);
			*(int*)((byte*)ptr + 16) = #BP.#01d(new Func<Point, int>(#Uxc.#Sxc));
			if (*(int*)((byte*)ptr + 16) < 0)
			{
				return null;
			}
			*(int*)((byte*)ptr + 20) = SnappingProviderHelper.#3qc(#0qc, #BP, #BP.Count, *(int*)((byte*)ptr + 16), false);
			*(int*)((byte*)ptr + 24) = SnappingProviderHelper.#3qc(#0qc, #BP, #BP.Count, *(int*)((byte*)ptr + 16), true);
			Point[] array = new Point[*(int*)((byte*)ptr + 24) - *(int*)((byte*)ptr + 20) + 1];
			#BP.CopyTo(*(int*)((byte*)ptr + 20), array, 0, array.Length);
			array = array.OrderBy(new Func<Point, double>(SnappingProviderHelper.<>c.<>9.#Vxc)).ToArray<Point>();
			*(int*)((byte*)ptr + 16) = array.#01d(new Func<Point, int>(#Uxc.#Txc));
			if (*(int*)((byte*)ptr + 16) < 0)
			{
				return null;
			}
			*(int*)((byte*)ptr + 20) = SnappingProviderHelper.#3qc(#0qc2, array, array.Length, *(int*)((byte*)ptr + 16), false);
			*(int*)((byte*)ptr + 24) = SnappingProviderHelper.#3qc(#0qc2, array, array.Length, *(int*)((byte*)ptr + 16), true);
			*(double*)ptr = double.MaxValue;
			*(int*)((byte*)ptr + 28) = -1;
			*(int*)((byte*)ptr + 24) = Math.Min(*(int*)((byte*)ptr + 24), array.Length - 1);
			*(int*)((byte*)ptr + 20) = Math.Max(0, *(int*)((byte*)ptr + 20));
			*(int*)((byte*)ptr + 32) = *(int*)((byte*)ptr + 20);
			while (*(int*)((byte*)ptr + 32) <= *(int*)((byte*)ptr + 24))
			{
				*(double*)((byte*)ptr + 8) = GeometryHelper.#lcb(array[*(int*)((byte*)ptr + 32)], #Uxc.#a);
				if (*(double*)((byte*)ptr + 8) < *(double*)ptr)
				{
					*(double*)ptr = *(double*)((byte*)ptr + 8);
					*(int*)((byte*)ptr + 28) = *(int*)((byte*)ptr + 32);
				}
				*(int*)((byte*)ptr + 32) = *(int*)((byte*)ptr + 32) + 1;
			}
			if (*(int*)((byte*)ptr + 28) < 0)
			{
				return null;
			}
			return new Point?(array[*(int*)((byte*)ptr + 28)]);
		}

		// Token: 0x06004055 RID: 16469 RVA: 0x0012C170 File Offset: 0x0012A370
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		[SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
		public void #8qc(List<Point> #9qc, SnappingSegmentData #arc, SnappingSegmentData #brc, bool #yqc)
		{
			#X0d.#V0d(#9qc, #Phc.#3hc(107366582), Component.SectionEditor, #Phc.#3hc(107366529));
			#X0d.#V0d(#arc, #Phc.#3hc(107366476), Component.SectionEditor, #Phc.#3hc(107366487));
			#X0d.#V0d(#brc, #Phc.#3hc(107366402), Component.SectionEditor, #Phc.#3hc(107366893));
			while (#yqc && this.SnapDataOriginFilter.#Usc(#juc.#e))
			{
				if (!false)
				{
					foreach (SnappingSegmentData #Urc in this.GridLineSegments)
					{
						Point? point = #jsc.#plc(#Urc, #arc);
						if (point != null)
						{
							#9qc.Add(point.Value);
						}
						Point? point2 = #jsc.#plc(#Urc, #brc);
						if (point2 != null)
						{
							#9qc.Add(point2.Value);
						}
					}
					break;
				}
			}
		}

		// Token: 0x06004056 RID: 16470 RVA: 0x0012C2BC File Offset: 0x0012A4BC
		[SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public void #crc(List<Point> #9qc, SnappingSegmentData #arc, SnappingSegmentData #brc, bool #zqc)
		{
			#X0d.#V0d(#9qc, #Phc.#3hc(107366582), Component.SectionEditor, #Phc.#3hc(107366872));
			#X0d.#V0d(#arc, #Phc.#3hc(107366476), Component.SectionEditor, #Phc.#3hc(107366787));
			#X0d.#V0d(#brc, #Phc.#3hc(107366402), Component.SectionEditor, #Phc.#3hc(107366734));
			while (#zqc && this.SnapDataOriginFilter.#Usc(#juc.#b))
			{
				if (!false)
				{
					foreach (SnappingSegmentData #Urc in this.ShapePolygonsSegments)
					{
						Point? point = #jsc.#plc(#Urc, #arc);
						if (point != null)
						{
							#9qc.Add(point.Value);
						}
						Point? point2 = #jsc.#plc(#Urc, #brc);
						if (point2 != null)
						{
							#9qc.Add(point2.Value);
						}
					}
					break;
				}
			}
		}

		// Token: 0x06004057 RID: 16471 RVA: 0x0012C408 File Offset: 0x0012A608
		[SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public void #drc(List<Point> #9qc, SnappingSegmentData #arc, SnappingSegmentData #brc, bool #Aqc)
		{
			#X0d.#V0d(#9qc, #Phc.#3hc(107366582), Component.SectionEditor, #Phc.#3hc(107366713));
			#X0d.#V0d(#arc, #Phc.#3hc(107366476), Component.SectionEditor, #Phc.#3hc(107366116));
			#X0d.#V0d(#brc, #Phc.#3hc(107366402), Component.SectionEditor, #Phc.#3hc(107366063));
			while (#Aqc && this.SnapDataOriginFilter.#Usc(#juc.#h))
			{
				if (!false)
				{
					foreach (SnappingSegmentData #Urc in this.AdditionalFiguresSegments)
					{
						Point? point = #jsc.#plc(#Urc, #arc);
						if (point != null)
						{
							#9qc.Add(point.Value);
						}
						Point? point2 = #jsc.#plc(#Urc, #brc);
						if (point2 != null)
						{
							#9qc.Add(point2.Value);
						}
					}
					break;
				}
			}
		}

		// Token: 0x06004058 RID: 16472 RVA: 0x0012C554 File Offset: 0x0012A754
		[SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public void #erc(List<Point> #9qc, SnappingSegmentData #arc, SnappingSegmentData #brc, bool #Tqc)
		{
			#X0d.#V0d(#9qc, #Phc.#3hc(107366582), Component.SectionEditor, #Phc.#3hc(107366042));
			#X0d.#V0d(#arc, #Phc.#3hc(107366476), Component.SectionEditor, #Phc.#3hc(107365957));
			#X0d.#V0d(#brc, #Phc.#3hc(107366402), Component.SectionEditor, #Phc.#3hc(107365936));
			if (#Tqc)
			{
				using (List<Point>.Enumerator enumerator = this.FreeNodesPoints.GetEnumerator())
				{
					for (;;)
					{
						IL_9C:
						bool flag2;
						bool flag = flag2 = enumerator.MoveNext();
						Point point;
						for (;;)
						{
							if (-1 != 0)
							{
								if (!flag)
								{
									goto Block_9;
								}
								point = enumerator.Current;
								goto IL_7A;
							}
							IL_81:
							while (!false)
							{
								if (!flag2)
								{
									bool flag3 = flag2 = (flag = #jsc.#Src(#brc, point));
									if (false)
									{
										continue;
									}
									if (!flag3)
									{
										goto IL_9C;
									}
								}
								if (!false)
								{
									goto Block_7;
								}
								goto IL_7A;
							}
							continue;
							IL_7A:
							flag = (flag2 = #jsc.#Src(#arc, point));
							goto IL_81;
						}
						Block_7:
						#9qc.Add(point);
					}
					Block_9:;
				}
			}
		}

		// Token: 0x06004059 RID: 16473 RVA: 0x0012C678 File Offset: 0x0012A878
		[SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public void #frc(List<Point> #9qc, SnappingSegmentData #arc, SnappingSegmentData #brc, bool #Rqc)
		{
			#X0d.#V0d(#9qc, #Phc.#3hc(107366582), Component.SectionEditor, #Phc.#3hc(107366395));
			#X0d.#V0d(#arc, #Phc.#3hc(107366476), Component.SectionEditor, #Phc.#3hc(107366310));
			#X0d.#V0d(#brc, #Phc.#3hc(107366402), Component.SectionEditor, #Phc.#3hc(107366289));
			if (#Rqc)
			{
				using (List<Point>.Enumerator enumerator = this.ShapePolygonEdgesKeyPoints.GetEnumerator())
				{
					for (;;)
					{
						IL_9C:
						bool flag2;
						bool flag = flag2 = enumerator.MoveNext();
						Point point;
						for (;;)
						{
							if (-1 != 0)
							{
								if (!flag)
								{
									goto Block_9;
								}
								point = enumerator.Current;
								goto IL_7A;
							}
							IL_81:
							while (!false)
							{
								if (!flag2)
								{
									bool flag3 = flag2 = (flag = #jsc.#Src(#brc, point));
									if (false)
									{
										continue;
									}
									if (!flag3)
									{
										goto IL_9C;
									}
								}
								if (!false)
								{
									goto Block_7;
								}
								goto IL_7A;
							}
							continue;
							IL_7A:
							flag = (flag2 = #jsc.#Src(#arc, point));
							goto IL_81;
						}
						Block_7:
						#9qc.Add(point);
					}
					Block_9:;
				}
			}
		}

		// Token: 0x0600405A RID: 16474 RVA: 0x0012C79C File Offset: 0x0012A99C
		[SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public void #grc(List<Point> #9qc, SnappingSegmentData #arc, SnappingSegmentData #brc, bool #Sqc)
		{
			#X0d.#V0d(#9qc, #Phc.#3hc(107366582), Component.SectionEditor, #Phc.#3hc(107366236));
			#X0d.#V0d(#arc, #Phc.#3hc(107366476), Component.SectionEditor, #Phc.#3hc(107366151));
			#X0d.#V0d(#brc, #Phc.#3hc(107366402), Component.SectionEditor, #Phc.#3hc(107365618));
			if (#Sqc)
			{
				using (List<Point>.Enumerator enumerator = this.AdditionalFigureEdgesKeyPoints.GetEnumerator())
				{
					for (;;)
					{
						IL_9C:
						bool flag2;
						bool flag = flag2 = enumerator.MoveNext();
						Point point;
						for (;;)
						{
							if (-1 != 0)
							{
								if (!flag)
								{
									goto Block_9;
								}
								point = enumerator.Current;
								goto IL_7A;
							}
							IL_81:
							while (!false)
							{
								if (!flag2)
								{
									bool flag3 = flag2 = (flag = #jsc.#Src(#brc, point));
									if (false)
									{
										continue;
									}
									if (!flag3)
									{
										goto IL_9C;
									}
								}
								if (!false)
								{
									goto Block_7;
								}
								goto IL_7A;
							}
							continue;
							IL_7A:
							flag = (flag2 = #jsc.#Src(#arc, point));
							goto IL_81;
						}
						Block_7:
						#9qc.Add(point);
					}
					Block_9:;
				}
			}
		}

		// Token: 0x0600405B RID: 16475 RVA: 0x0012C8C0 File Offset: 0x0012AAC0
		[SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public void #hrc(List<Point> #9qc, SnappingSegmentData #arc, SnappingSegmentData #brc, bool #Jqc, bool #yqc)
		{
			#X0d.#V0d(#9qc, #Phc.#3hc(107366582), Component.SectionEditor, #Phc.#3hc(107365565));
			#X0d.#V0d(#arc, #Phc.#3hc(107366476), Component.SectionEditor, #Phc.#3hc(107365480));
			#X0d.#V0d(#brc, #Phc.#3hc(107366402), Component.SectionEditor, #Phc.#3hc(107365459));
			if (#Jqc)
			{
				using (List<Point>.Enumerator enumerator = this.ShapesIntersectionPoints.GetEnumerator())
				{
					for (;;)
					{
						IL_9C:
						bool flag = enumerator.MoveNext();
						while (flag)
						{
							Point point = enumerator.Current;
							if (!false)
							{
								if (!#jsc.#Src(#arc, point))
								{
									bool flag2 = flag = #jsc.#Src(#brc, point);
									if (false)
									{
										continue;
									}
									if (!flag2)
									{
										goto IL_9C;
									}
								}
								#9qc.Add(point);
								goto IL_9C;
							}
							break;
						}
						break;
					}
				}
				List<Point>.Enumerator enumerator = this.AdditionalFiguresIntersectionPoints.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						Point point2 = enumerator.Current;
						bool flag4;
						bool flag3 = flag4 = #jsc.#Src(#arc, point2);
						do
						{
							if (!false)
							{
								if (flag4)
								{
									goto IL_E3;
								}
								flag3 = (flag4 = #jsc.#Src(#brc, point2));
							}
						}
						while (!true);
						if (!flag3)
						{
							continue;
						}
						IL_E3:
						#9qc.Add(point2);
					}
				}
				finally
				{
					if (true)
					{
						((IDisposable)enumerator).Dispose();
					}
				}
				using (List<Point>.Enumerator enumerator = this.ShapeAdditionalFiguresIntersectionPoints.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						Point point3;
						if (3 != 0)
						{
							point3 = enumerator.Current;
						}
						if (#jsc.#Src(#arc, point3) || #jsc.#Src(#brc, point3))
						{
							#9qc.Add(point3);
						}
					}
				}
				if (#yqc && this.SnapDataOriginFilter.#Usc(#juc.#e))
				{
					using (List<Point>.Enumerator enumerator = this.GridLineShapePolygonEdgeIntersectionPoints.GetEnumerator())
					{
						for (;;)
						{
							while (-1 != 0)
							{
								if (!enumerator.MoveNext())
								{
									goto Block_27;
								}
								Point point4 = enumerator.Current;
								if (#jsc.#Src(#arc, point4) || #jsc.#Src(#brc, point4))
								{
									#9qc.Add(point4);
								}
							}
						}
						Block_27:;
					}
				}
			}
		}

		// Token: 0x0600405C RID: 16476 RVA: 0x0012CB04 File Offset: 0x0012AD04
		[SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public static void #irc(List<Point> #9qc, SnappingSegmentData #arc, SnappingSegmentData #brc, bool #Fqc)
		{
			if (!false)
			{
				if (-1 == 0)
				{
					goto IL_46;
				}
				#X0d.#V0d(#9qc, #Phc.#3hc(107366582), Component.SectionEditor, #Phc.#3hc(107365406));
			}
			#X0d.#V0d(#arc, #Phc.#3hc(107366476), Component.SectionEditor, #Phc.#3hc(107365833));
			IL_46:
			#X0d.#V0d(#brc, #Phc.#3hc(107366402), Component.SectionEditor, #Phc.#3hc(107365812));
			bool flag = #Fqc;
			IL_67:
			while (flag)
			{
				do
				{
					if (!#jsc.#Src(#arc, SnappingProviderHelper.#c))
					{
						if (4 == 0)
						{
							continue;
						}
						bool flag2 = flag = #jsc.#Src(#brc, SnappingProviderHelper.#c);
						if (false)
						{
							goto IL_67;
						}
						if (!flag2)
						{
							return;
						}
					}
				}
				while (5 == 0);
				#9qc.Add(SnappingProviderHelper.#c);
				break;
			}
		}

		// Token: 0x04001CFF RID: 7423
		private const int #a = 10;

		// Token: 0x04001D00 RID: 7424
		private const double #b = 0.0001;

		// Token: 0x04001D01 RID: 7425
		private static readonly Point #c = new Point(0.0, 0.0);

		// Token: 0x04001D02 RID: 7426
		[CompilerGenerated]
		private #Wsc #d;

		// Token: 0x04001D03 RID: 7427
		[CompilerGenerated]
		private List<SnappingSegmentData> #e;

		// Token: 0x04001D04 RID: 7428
		[CompilerGenerated]
		private List<SnappingSegmentData> #f;

		// Token: 0x04001D05 RID: 7429
		[CompilerGenerated]
		private List<SnappingSegmentData> #g;

		// Token: 0x04001D06 RID: 7430
		[CompilerGenerated]
		private List<SnappingSegmentData> #h;

		// Token: 0x04001D07 RID: 7431
		[CompilerGenerated]
		private List<SnappingSegmentData> #i;

		// Token: 0x04001D08 RID: 7432
		[CompilerGenerated]
		private List<Point> #j;

		// Token: 0x04001D09 RID: 7433
		[CompilerGenerated]
		private List<Point> #k;

		// Token: 0x04001D0A RID: 7434
		[CompilerGenerated]
		private List<Point> #l;

		// Token: 0x04001D0B RID: 7435
		[CompilerGenerated]
		private List<Point> #m;

		// Token: 0x04001D0C RID: 7436
		[CompilerGenerated]
		private List<Point> #n;

		// Token: 0x04001D0D RID: 7437
		[CompilerGenerated]
		private List<Point> #o;

		// Token: 0x04001D0E RID: 7438
		[CompilerGenerated]
		private List<Point> #p;

		// Token: 0x04001D0F RID: 7439
		[CompilerGenerated]
		private List<Point> #q;

		// Token: 0x04001D10 RID: 7440
		[CompilerGenerated]
		private List<Point> #r;

		// Token: 0x04001D11 RID: 7441
		[CompilerGenerated]
		private List<Point> #s;

		// Token: 0x04001D12 RID: 7442
		[CompilerGenerated]
		private List<Point> #t;

		// Token: 0x04001D13 RID: 7443
		[CompilerGenerated]
		private List<Point> #u;

		// Token: 0x04001D14 RID: 7444
		[CompilerGenerated]
		private Dictionary<Point, SnappingPointData> #v;

		// Token: 0x04001D15 RID: 7445
		[CompilerGenerated]
		private List<Point> #w;

		// Token: 0x04001D16 RID: 7446
		[CompilerGenerated]
		private List<Point> #x;

		// Token: 0x04001D17 RID: 7447
		[CompilerGenerated]
		private List<Point> #y;

		// Token: 0x04001D18 RID: 7448
		[CompilerGenerated]
		private List<Point> #z;

		// Token: 0x04001D19 RID: 7449
		[CompilerGenerated]
		private double #A;

		// Token: 0x020007D2 RID: 2002
		[CompilerGenerated]
		private sealed class #Uxc
		{
			// Token: 0x06004062 RID: 16482 RVA: 0x0012CBF8 File Offset: 0x0012ADF8
			internal bool #Oxc(IList<Point> #Pxc, int #Qxc)
			{
				double num2;
				double num = num2 = #Pxc[#Qxc].X;
				double num4;
				double num3 = num4 = this.#a.X;
				if (2 != 0)
				{
					double value = num2 = num - num3;
					if (true)
					{
						num2 = Math.Abs(value);
					}
					num4 = this.#b;
				}
				bool result;
				bool flag = result = (num2 > num4);
				if (8 != 0 && !false)
				{
					result = !flag;
				}
				return result;
			}

			// Token: 0x06004063 RID: 16483 RVA: 0x0012CC60 File Offset: 0x0012AE60
			internal bool #Rxc(IList<Point> #Pxc, int #Qxc)
			{
				double num2;
				double num = num2 = #Pxc[#Qxc].Y;
				double num4;
				double num3 = num4 = this.#a.Y;
				if (2 != 0)
				{
					double value = num2 = num - num3;
					if (true)
					{
						num2 = Math.Abs(value);
					}
					num4 = this.#b;
				}
				bool result;
				bool flag = result = (num2 > num4);
				if (8 != 0 && !false)
				{
					result = !flag;
				}
				return result;
			}

			// Token: 0x06004064 RID: 16484 RVA: 0x0003658F File Offset: 0x0003478F
			internal int #Sxc(Point #Rf)
			{
				return SnappingProviderHelper.#Wqc(this.#a, #Rf, this.#b);
			}

			// Token: 0x06004065 RID: 16485 RVA: 0x000365B3 File Offset: 0x000347B3
			internal int #Txc(Point #Rf)
			{
				return SnappingProviderHelper.#Yqc(this.#a, #Rf, this.#b);
			}

			// Token: 0x04001D1C RID: 7452
			public Point #a;

			// Token: 0x04001D1D RID: 7453
			public double #b;
		}
	}
}
