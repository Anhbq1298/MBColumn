using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;
using #cYd;
using #Fmc;
using #UYd;
using ClipperLib;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace StructurePoint.CoreAssets.Geometry.Helpers
{
	// Token: 0x020007B1 RID: 1969
	public static class BooleanOperationsHelper
	{
		// Token: 0x06003F20 RID: 16160 RVA: 0x00122C8C File Offset: 0x00120E8C
		public static IList<Point> #Rlc(IReadOnlyCollection<Point> #BP, double #sP, double #Slc)
		{
			List<List<IntPoint>> list;
			for (;;)
			{
				if (6 == 0)
				{
					goto IL_72;
				}
				string #R0d = #Phc.#3hc(107358670);
				Component #x6c = Component.Geometry;
				string #Qic = #Phc.#3hc(107372219);
				if (!false)
				{
					#X0d.#V0d(#BP, #R0d, #x6c, #Qic);
				}
				List<IntPoint> path = PointsConverter.#ysc(#BP);
				#sP *= PointsConverter.#a;
				IL_46:
				ClipperOffset clipperOffset = new ClipperOffset(#Slc, 0.25);
				clipperOffset.AddPath(path, JoinType.jtMiter, EndType.etClosedPolygon);
				list = new List<List<IntPoint>>();
				clipperOffset.Execute(ref list, #sP);
				if (false)
				{
					continue;
				}
				if (list == null)
				{
					goto IL_91;
				}
				IL_72:
				if (!false)
				{
					if (list.Count != 1)
					{
						goto IL_91;
					}
					if (-1 != 0)
					{
						break;
					}
					goto IL_46;
				}
			}
			return PointsConverter.#ysc(list[0]);
			IL_91:
			return null;
		}

		// Token: 0x06003F21 RID: 16161 RVA: 0x00035A04 File Offset: 0x00033C04
		public static IList<Point> #Rlc(IReadOnlyCollection<Point> #BP, double #sP)
		{
			return BooleanOperationsHelper.#Rlc(#BP, #sP, 2.0);
		}

		// Token: 0x06003F22 RID: 16162 RVA: 0x00122D74 File Offset: 0x00120F74
		public static IList<Point3D> #Rlc(IReadOnlyCollection<Point3D> #BP, double #sP)
		{
			List<List<IntPoint>> list;
			for (;;)
			{
				if (6 == 0)
				{
					goto IL_7B;
				}
				string #R0d = #Phc.#3hc(107358670);
				Component #x6c = Component.SectionEditor;
				string #Qic = #Phc.#3hc(107372134);
				if (!false)
				{
					#X0d.#V0d(#BP, #R0d, #x6c, #Qic);
				}
				List<IntPoint> path = PointsConverter.#Pb(#BP);
				#sP *= PointsConverter.#a;
				IL_47:
				ClipperOffset clipperOffset = new ClipperOffset(2.0, 0.25);
				clipperOffset.AddPath(path, JoinType.jtMiter, EndType.etClosedPolygon);
				list = new List<List<IntPoint>>();
				clipperOffset.Execute(ref list, #sP);
				if (false)
				{
					continue;
				}
				if (list == null)
				{
					goto IL_9A;
				}
				IL_7B:
				if (!false)
				{
					if (list.Count != 1)
					{
						goto IL_9A;
					}
					if (-1 != 0)
					{
						break;
					}
					goto IL_47;
				}
			}
			return PointsConverter.#Pb(list[0]);
			IL_9A:
			return null;
		}

		// Token: 0x06003F23 RID: 16163 RVA: 0x00122E64 File Offset: 0x00121064
		public static bool #Tlc(IList<ShapeData> #6Y, PolygonData #JP)
		{
			#X0d.#V0d(#6Y, #Phc.#3hc(107372113), Component.Geometry, #Phc.#3hc(107372072));
			for (;;)
			{
				IL_1F:
				#X0d.#V0d(#JP, #Phc.#3hc(107399958), Component.Geometry, #Phc.#3hc(107372051));
				bool flag = #6Y.Any<ShapeData>();
				while (flag)
				{
					if (false)
					{
						goto IL_1F;
					}
					ShapeData shapeData = #6Y[0];
					if (!BooleanOperationsHelper.#Tlc(shapeData, #JP))
					{
						goto Block_3;
					}
					int num;
					if (!false)
					{
						num = 1;
						goto IL_82;
					}
					IL_83:
					int num4;
					for (;;)
					{
						int num3;
						int num2 = num3 = num4;
						int num6;
						int num5 = num6 = #6Y.Count;
						if (!false)
						{
							if (num2 >= num5)
							{
								break;
							}
							if (!BooleanOperationsHelper.#Tlc(shapeData, #6Y[num4]))
							{
								goto Block_6;
							}
							num3 = num4;
							num6 = 1;
						}
						num4 = num3 + num6;
					}
					bool flag2 = flag = true;
					if (flag2)
					{
						return flag2;
					}
					continue;
					Block_6:
					int num7 = num = 0;
					if (num7 == 0)
					{
						return num7 != 0;
					}
					IL_82:
					num4 = num;
					goto IL_83;
				}
				break;
			}
			int num8 = 107372113;
			IL_4F:
			throw new #jYd(#Phc.#3hc(num8), #Phc.#3hc(107372510), Component.Geometry);
			Block_3:
			int num9 = num8 = 0;
			if (num9 == 0)
			{
				return num9 != 0;
			}
			goto IL_4F;
		}

		// Token: 0x06003F24 RID: 16164 RVA: 0x00122F70 File Offset: 0x00121170
		public static bool #Tlc(IList<PolygonData> #yP, bool #Ulc, bool #Vlc)
		{
			#X0d.#V0d(#yP, #Phc.#3hc(107372425), Component.Geometry, #Phc.#3hc(107372444));
			if (!#yP.Any<PolygonData>())
			{
				throw new #jYd(#Phc.#3hc(107372425), #Phc.#3hc(107372359), Component.Geometry);
			}
			List<PolygonData> list = #yP.Take(1).ToList<PolygonData>();
			for (int i = 1; i < #yP.Count; i++)
			{
				if (!BooleanOperationsHelper.#Tlc(#yP[i], list, #Ulc, #Vlc))
				{
					return false;
				}
			}
			#yP.Clear();
			foreach (PolygonData item in list)
			{
				#yP.Add(item);
			}
			return true;
		}

		// Token: 0x06003F25 RID: 16165 RVA: 0x00123090 File Offset: 0x00121290
		public static bool #Tlc(PolygonData #JP, IList<PolygonData> #Wlc, bool #Ulc = true, bool #Vlc = true)
		{
			if (8 != 0)
			{
				#X0d.#V0d(#JP, #Phc.#3hc(107399958), Component.Geometry, #Phc.#3hc(107372338));
				#X0d.#V0d(#Wlc, #Phc.#3hc(107371773), Component.Geometry, #Phc.#3hc(107371720));
			}
			Clipper clipper = BooleanOperationsHelper.#dmc();
			clipper.StrictlySimple = #Ulc;
			clipper.PreserveCollinear = #Vlc;
			#1uc #1uc = ShapeToClipperPolygonsConverter.#Pb(#JP);
			#2uc #2uc = ShapeToClipperPolygonsConverter.#Pb(#Wlc);
			clipper.AddPath(#1uc, PolyType.ptSubject, true);
			clipper.AddPaths(#2uc, PolyType.ptClip, true);
			List<List<IntPoint>> list = new List<List<IntPoint>>();
			int num = clipper.Execute(ClipType.ctUnion, list, PolyFillType.pftEvenOdd, PolyFillType.pftEvenOdd) ? 1 : 0;
			for (;;)
			{
				if (num != 0)
				{
					list = BooleanOperationsHelper.#nmc(list, PolyFillType.pftEvenOdd, #Ulc, #Vlc);
					list.ForEach(new Action<List<IntPoint>>(BooleanOperationsHelper.<>c.<>9.#nxc));
					IList<PolygonData> list2 = ShapeToClipperPolygonsConverter.#Rsc(list);
					if (!false && BooleanOperationsHelper.#3lc(list2))
					{
						for (;;)
						{
							if (ClipperHelper.#Htc(#2uc.ToList<List<IntPoint>>(), list, #1uc.ToList<IntPoint>()))
							{
								list2 = ShapeToClipperPolygonsConverter.#Rsc(list);
							}
							if (6 != 0)
							{
								#Wlc.Clear();
								using (IEnumerator<PolygonData> enumerator = list2.GetEnumerator())
								{
									if (!false)
									{
										goto IL_10D;
									}
									IL_FC:
									PolygonData item = enumerator.Current;
									#Wlc.Add(item);
									IL_10D:
									if (enumerator.MoveNext())
									{
										goto IL_FC;
									}
								}
								if (!false)
								{
									break;
								}
							}
						}
						if (3 != 0)
						{
							break;
						}
					}
				}
				int num2 = num = 0;
				if (num2 == 0)
				{
					return num2 != 0;
				}
			}
			return true;
		}

		// Token: 0x06003F26 RID: 16166 RVA: 0x00123234 File Offset: 0x00121434
		public static bool #Tlc(ShapeData #Xlc, ShapeData #Ylc)
		{
			#X0d.#V0d(#Xlc, #Phc.#3hc(107371699), Component.Geometry, #Phc.#3hc(107371650));
			#X0d.#V0d(#Ylc, #Phc.#3hc(107371597), Component.Geometry, #Phc.#3hc(107371612));
			\u0008\u0002 ~_u0016_u = \u0008\u0002.~\u0016\u0004;
			Clipper clipper = BooleanOperationsHelper.#dmc();
			#2uc #2uc = ShapeToClipperPolygonsConverter.#Pb(#Xlc);
			#2uc #2uc2 = ShapeToClipperPolygonsConverter.#Pb(#Ylc);
			clipper.AddPaths(#2uc, PolyType.ptSubject, true);
			clipper.AddPaths(#2uc2, PolyType.ptClip, true);
			List<List<IntPoint>> list = new List<List<IntPoint>>();
			if (~_u0016_u(clipper, ClipType.ctUnion, list, PolyFillType.pftEvenOdd, PolyFillType.pftEvenOdd))
			{
				list = BooleanOperationsHelper.#nmc(list, PolyFillType.pftEvenOdd, true, true);
				IList<PolygonData> list2 = ShapeToClipperPolygonsConverter.#Rsc(list);
				if (BooleanOperationsHelper.#3lc(list2))
				{
					if (ClipperHelper.#Htc(#2uc.ToList<List<IntPoint>>(), list, #2uc2.ToList<List<IntPoint>>()))
					{
						list2 = ShapeToClipperPolygonsConverter.#Rsc(list);
					}
					#Xlc.#yl();
					#Xlc.#pR(list2);
					return true;
				}
			}
			return false;
		}

		// Token: 0x06003F27 RID: 16167 RVA: 0x00123354 File Offset: 0x00121554
		public static bool #Tlc(ShapeData #rP, PolygonData #JP)
		{
			if (!false)
			{
				#X0d.#V0d(#rP, #Phc.#3hc(107371527), Component.Geometry, #Phc.#3hc(107371550));
				#X0d.#V0d(#JP, #Phc.#3hc(107399958), Component.Geometry, #Phc.#3hc(107371977));
			}
			\u0008\u0002 ~_u0016_u = \u0008\u0002.~\u0016\u0004;
			Clipper clipper = BooleanOperationsHelper.#dmc();
			clipper.PreserveCollinear = true;
			#2uc #2uc = ShapeToClipperPolygonsConverter.#Pb(#rP);
			#1uc #1uc = ShapeToClipperPolygonsConverter.#Pb(#JP);
			clipper.AddPaths(#2uc, PolyType.ptSubject, true);
			clipper.AddPath(#1uc, PolyType.ptClip, true);
			List<List<IntPoint>> list = new List<List<IntPoint>>();
			int result;
			int num;
			bool flag = (num = (result = (~_u0016_u(clipper, ClipType.ctUnion, list, PolyFillType.pftEvenOdd, PolyFillType.pftEvenOdd) ? 1 : 0))) != 0;
			IList<PolygonData> list2;
			if (!false)
			{
				if (!flag)
				{
					goto IL_D4;
				}
				list = BooleanOperationsHelper.#nmc(list, PolyFillType.pftEvenOdd, true, true);
				list2 = ShapeToClipperPolygonsConverter.#Rsc(list);
				result = (num = (BooleanOperationsHelper.#3lc(list2) ? 1 : 0));
			}
			if (false)
			{
				return result != 0;
			}
			if (num != 0)
			{
				do
				{
					if (ClipperHelper.#Htc(#2uc.ToList<List<IntPoint>>(), list, #1uc.ToList<IntPoint>()))
					{
						list2 = ShapeToClipperPolygonsConverter.#Rsc(list);
					}
					if (8 != 0)
					{
						#rP.#yl();
					}
					#rP.#pR(list2);
				}
				while (false);
				return true;
			}
			IL_D4:
			result = 0;
			return result != 0;
		}

		// Token: 0x06003F28 RID: 16168 RVA: 0x00123488 File Offset: 0x00121688
		public static bool #Tlc(ShapeData #XHb, IEnumerable<ShapeData> #Zlc)
		{
			if (!false)
			{
				#X0d.#V0d(#XHb, #Phc.#3hc(107371956), Component.Geometry, #Phc.#3hc(107371931));
			}
			#X0d.#V0d(#Zlc, #Phc.#3hc(107371846), Component.Geometry, #Phc.#3hc(107371861));
			IEnumerator<ShapeData> enumerator = #Zlc.GetEnumerator();
			try
			{
				if (!false)
				{
				}
				while (enumerator.MoveNext())
				{
					ShapeData #Ylc = enumerator.Current;
					if (!BooleanOperationsHelper.#Tlc(#XHb, #Ylc))
					{
						return false;
					}
				}
			}
			finally
			{
				while (-1 != 0 && enumerator != null)
				{
					if (!false)
					{
						enumerator.Dispose();
						break;
					}
				}
			}
			if (!false)
			{
				return true;
			}
			bool result;
			return result;
		}

		// Token: 0x06003F29 RID: 16169 RVA: 0x00123578 File Offset: 0x00121778
		public static bool #0lc(PolygonData #JP)
		{
			int result;
			if (4 != 0 && #JP != null)
			{
				int num;
				result = (num = #JP.Points2D.Distinct<Point>().Count<Point>());
				while (!false)
				{
					int num2 = #JP.Points2DCount;
					int num3;
					do
					{
						num3 = --num2;
					}
					while (6 == 0);
					bool result2 = (num = (result = ((num == num3) ? 1 : 0))) != 0;
					if (!false)
					{
						return result2;
					}
				}
			}
			else
			{
				result = 0;
			}
			return result != 0;
		}

		// Token: 0x06003F2A RID: 16170 RVA: 0x001235CC File Offset: 0x001217CC
		public unsafe static bool #1lc(PolygonData #JP)
		{
			int num = 12;
			int num3;
			void* ptr;
			List<SegmentData> list;
			int num4;
			for (;;)
			{
				int num2 = num3 = num;
				if (num2 == 0)
				{
					goto IL_6F;
				}
				ptr = stackalloc byte[num2];
				if (#JP == null || !BooleanOperationsHelper.#9W(#JP))
				{
					break;
				}
				list = #JP.Segments;
				num4 = (num = list.Count);
				if (3 != 0)
				{
					goto Block_3;
				}
			}
			return false;
			Block_3:
			BoundingBoxData[] array = new BoundingBoxData[num4];
			*(int*)ptr = 0;
			IL_6D:
			num3 = *(int*)ptr;
			IL_6F:
			if (num3 >= list.Count)
			{
				*(int*)((byte*)ptr + 4) = 0;
				while (*(int*)((byte*)ptr + 4) < list.Count)
				{
					SegmentData segmentData = list[*(int*)((byte*)ptr + 4)];
					BoundingBoxData boundingBoxData = array[*(int*)((byte*)ptr + 4)];
					*(int*)((byte*)ptr + 8) = 0;
					while (*(int*)((byte*)ptr + 8) < list.Count)
					{
						if (*(int*)((byte*)ptr + 8) != *(int*)((byte*)ptr + 4))
						{
							SegmentData segmentData2 = list[*(int*)((byte*)ptr + 8)];
							int result;
							for (;;)
							{
								BoundingBoxData #Yvc = array[*(int*)((byte*)ptr + 8)];
								bool flag2;
								bool flag = flag2 = boundingBoxData.#pFb(#Yvc);
								if (8 != 0)
								{
									if (!flag)
									{
										goto IL_10F;
									}
									Point? point = #jsc.#plc(segmentData, segmentData2);
									if (point == null)
									{
										goto IL_10F;
									}
									Point? point2 = segmentData.#Wwc(segmentData2);
									bool flag3 = (result = ((point2 != null) ? 1 : 0)) != 0;
									if (false)
									{
										return result != 0;
									}
									if (!flag3)
									{
										break;
									}
									flag2 = PointsConverter.#uC(point2.Value, point.Value);
								}
								if (flag2)
								{
									goto IL_10F;
								}
								if (3 != 0)
								{
									goto Block_12;
								}
							}
							return false;
							Block_12:
							result = 0;
							return result != 0;
						}
						IL_10F:
						*(int*)((byte*)ptr + 8) = *(int*)((byte*)ptr + 8) + 1;
					}
					*(int*)((byte*)ptr + 4) = *(int*)((byte*)ptr + 4) + 1;
				}
				return true;
			}
			SegmentData segmentData3 = list[*(int*)ptr];
			array[*(int*)ptr] = new BoundingBoxData(segmentData3.StartPoint, segmentData3.EndPoint);
			*(int*)ptr = *(int*)ptr + 1;
			goto IL_6D;
		}

		// Token: 0x06003F2B RID: 16171 RVA: 0x00123760 File Offset: 0x00121960
		public static bool #9W(PolygonData #JP)
		{
			int num2;
			int num = num2 = (BooleanOperationsHelper.#0lc(#JP) ? 1 : 0);
			for (;;)
			{
				if (false)
				{
					goto IL_21;
				}
				bool flag = num != 0;
				int num3;
				num2 = (num3 = (num = ((#JP != null && flag) ? 1 : 0)));
				IL_11:
				if (false)
				{
					continue;
				}
				if (num3 != 0 && 7 != 0)
				{
					break;
				}
				num2 = 0;
				IL_21:
				int num4 = num3 = (num2 = (num = num2));
				if (num4 == 0)
				{
					return num4 != 0;
				}
				goto IL_11;
			}
			return #0uc.#Xuc(#JP.SqlGeometry);
		}

		// Token: 0x06003F2C RID: 16172 RVA: 0x001237B8 File Offset: 0x001219B8
		public static bool #2lc(PolygonData #VHb)
		{
			bool? flag;
			if (true)
			{
				if (!false && #VHb == null)
				{
					if (false)
					{
						goto IL_12;
					}
					if (8 != 0)
					{
						return false;
					}
				}
				flag = #0uc.#2lc(#VHb.SqlGeometry);
			}
			IL_12:
			return flag.GetValueOrDefault();
		}

		// Token: 0x06003F2D RID: 16173 RVA: 0x00123804 File Offset: 0x00121A04
		public static bool #3lc(IList<PolygonData> #4lc)
		{
			int num2;
			int num4;
			int num5;
			if (#4lc == null || !#4lc.Any<PolygonData>())
			{
				if (!false)
				{
					return true;
				}
				goto IL_48;
			}
			else
			{
				int num = num2 = #4lc.Count;
				int num3 = num4 = 1;
				if (num3 == 0)
				{
					goto IL_52;
				}
				num5 = num - num3;
			}
			IL_26:
			goto IL_54;
			IL_48:
			int num7;
			int num6 = num7 = 0;
			if (num6 == 0)
			{
				return num6 != 0;
			}
			goto IL_55;
			IL_52:
			num5 = num2 - num4;
			IL_54:
			num7 = num5;
			IL_55:
			if (num7 >= 0)
			{
				PolygonData polygonData = #4lc[num5];
				if (BooleanOperationsHelper.#2lc(polygonData))
				{
					#4lc.RemoveAt(num5);
				}
				else if (!BooleanOperationsHelper.#9W(polygonData))
				{
					goto IL_48;
				}
				if (6 != 0)
				{
					num2 = num5;
					num4 = 1;
					goto IL_52;
				}
			}
			if (3 != 0)
			{
				return true;
			}
			goto IL_26;
		}

		// Token: 0x06003F2E RID: 16174 RVA: 0x001238AC File Offset: 0x00121AAC
		public static bool #5lc(ShapeData #6lc, PolygonData #JP)
		{
			#X0d.#V0d(#JP, #Phc.#3hc(107399958), Component.Geometry, #Phc.#3hc(107371776));
			return BooleanOperationsHelper.#5lc(#6lc, new PolygonData[]
			{
				#JP
			});
		}

		// Token: 0x06003F2F RID: 16175 RVA: 0x00123900 File Offset: 0x00121B00
		public static bool #5lc(ShapeData #6lc, IEnumerable<PolygonData> #4lc)
		{
			#X0d.#V0d(#6lc, #Phc.#3hc(107371211), Component.Geometry, #Phc.#3hc(107371222));
			#X0d.#V0d(#4lc, #Phc.#3hc(107371137), Component.Geometry, #Phc.#3hc(107371116));
			Clipper clipper = BooleanOperationsHelper.#dmc();
			clipper.AddPaths(ShapeToClipperPolygonsConverter.#Pb(#6lc), PolyType.ptSubject, true);
			clipper.AddPaths(ShapeToClipperPolygonsConverter.#Pb(#4lc), PolyType.ptClip, true);
			PolyFillType clipFillType = PolyFillType.pftEvenOdd;
			List<List<IntPoint>> list = new List<List<IntPoint>>();
			if (clipper.Execute(ClipType.ctDifference, list, PolyFillType.pftEvenOdd, clipFillType))
			{
				list = BooleanOperationsHelper.#nmc(list, PolyFillType.pftEvenOdd, true, true);
				IList<PolygonData> list2 = ShapeToClipperPolygonsConverter.#Rsc(list);
				if (BooleanOperationsHelper.#3lc(list2))
				{
					#6lc.#yl();
					#6lc.#pR(list2);
					return true;
				}
			}
			return false;
		}

		// Token: 0x06003F30 RID: 16176 RVA: 0x001239FC File Offset: 0x00121BFC
		public static bool #7lc(ShapeData #rP, PolygonData #JP)
		{
			#X0d.#V0d(#rP, #Phc.#3hc(107371527), Component.Geometry, #Phc.#3hc(107371095));
			#X0d.#V0d(#JP, #Phc.#3hc(107399958), Component.Geometry, #Phc.#3hc(107371010));
			IEnumerable<PolygonData> enumerable = BooleanOperationsHelper.#CP(#rP, #JP);
			int num;
			if (enumerable == null)
			{
				num = 0;
				goto IL_3D;
			}
			int result;
			num = (result = (enumerable.Any<PolygonData>() ? 1 : 0));
			IL_38:
			if (!false)
			{
				return result != 0;
			}
			IL_3D:
			int num2 = result = (num = num);
			if (num2 != 0)
			{
				goto IL_38;
			}
			num = num2;
			result = num2;
			if (num2 == 0)
			{
				return num2 != 0;
			}
			goto IL_38;
		}

		// Token: 0x06003F31 RID: 16177 RVA: 0x00123A80 File Offset: 0x00121C80
		public static bool #7lc(List<ShapeData> #6Y, PolygonData #JP)
		{
			for (;;)
			{
				string #R0d = #Phc.#3hc(107372113);
				Component #x6c = Component.Geometry;
				string #Qic = #Phc.#3hc(107371469);
				if (!false)
				{
					#X0d.#V0d(#6Y, #R0d, #x6c, #Qic);
				}
				if (!false)
				{
					#X0d.#V0d(#JP, #Phc.#3hc(107399958), Component.Geometry, #Phc.#3hc(107371448));
					for (;;)
					{
						List<ShapeData>.Enumerator enumerator = #6Y.GetEnumerator();
						try
						{
							while (enumerator.MoveNext())
							{
								if (5 != 0)
								{
									IEnumerable<PolygonData> enumerable = BooleanOperationsHelper.#CP(enumerator.Current, #JP);
									if (enumerable != null && enumerable.Any<PolygonData>())
									{
										bool result = true;
										goto IL_91;
									}
								}
							}
						}
						finally
						{
							do
							{
								((IDisposable)enumerator).Dispose();
							}
							while (7 == 0);
						}
						return false;
						IL_91:
						if (false)
						{
							break;
						}
						if (!false)
						{
							bool result;
							return result;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x06003F32 RID: 16178 RVA: 0x00123B88 File Offset: 0x00121D88
		public static IList<PolygonData> #CP(ShapeData #Xlc, ShapeData #Ylc)
		{
			#X0d.#V0d(#Xlc, #Phc.#3hc(107371699), Component.Geometry, #Phc.#3hc(107371363));
			#X0d.#V0d(#Ylc, #Phc.#3hc(107371597), Component.Geometry, #Phc.#3hc(107371310));
			Clipper clipper = BooleanOperationsHelper.#dmc();
			clipper.AddPaths(ShapeToClipperPolygonsConverter.#Pb(#Xlc), PolyType.ptSubject, true);
			clipper.AddPaths(ShapeToClipperPolygonsConverter.#Pb(#Ylc), PolyType.ptClip, true);
			List<List<IntPoint>> list = new List<List<IntPoint>>();
			if (clipper.Execute(ClipType.ctIntersection, list, PolyFillType.pftEvenOdd, PolyFillType.pftEvenOdd))
			{
				list = BooleanOperationsHelper.#nmc(list, PolyFillType.pftEvenOdd, true, true);
				IList<PolygonData> list2 = ShapeToClipperPolygonsConverter.#Rsc(list);
				BooleanOperationsHelper.#3lc(list2);
				return list2;
			}
			return null;
		}

		// Token: 0x06003F33 RID: 16179 RVA: 0x00123C74 File Offset: 0x00121E74
		public static IList<ShapesIntersectionResult> #CP(ShapeData #rP, IEnumerable<ShapeData> #8lc)
		{
			#X0d.#V0d(#rP, #Phc.#3hc(107371527), Component.Geometry, #Phc.#3hc(107371289));
			#X0d.#V0d(#8lc, #Phc.#3hc(107370692), Component.Geometry, #Phc.#3hc(107370671));
			List<ShapesIntersectionResult> list;
			do
			{
				list = new List<ShapesIntersectionResult>();
				if (#rP.PolygonsCount >= 1)
				{
					goto IL_52;
				}
			}
			while (4 == 0);
			return list;
			IL_52:
			BoundingBoxData boundingBoxData = #rP.#cxc(0).BoundingBoxData;
			foreach (ShapeData shapeData in #8lc)
			{
				while (shapeData.PolygonsCount >= 1 && boundingBoxData.#pFb(shapeData.#cxc(0).BoundingBoxData))
				{
					IList<PolygonData> list2 = BooleanOperationsHelper.#CP(shapeData, #rP);
					if (list2 == null)
					{
						break;
					}
					if (5 != 0)
					{
						if (list2.Any<PolygonData>())
						{
							list.Add(new ShapesIntersectionResult(shapeData, list2));
							break;
						}
						break;
					}
				}
			}
			return list;
		}

		// Token: 0x06003F34 RID: 16180 RVA: 0x00123DAC File Offset: 0x00121FAC
		public static IList<ShapesIntersectionResult> #CP(PolygonData #JP, IEnumerable<ShapeData> #8lc)
		{
			#X0d.#V0d(#JP, #Phc.#3hc(107399958), Component.Geometry, #Phc.#3hc(107370650));
			#X0d.#V0d(#8lc, #Phc.#3hc(107370692), Component.Geometry, #Phc.#3hc(107370565));
			List<ShapesIntersectionResult> list = new List<ShapesIntersectionResult>();
			foreach (ShapeData shapeData in #8lc)
			{
				IEnumerable<PolygonData> enumerable = BooleanOperationsHelper.#CP(shapeData, #JP);
				if (enumerable != null)
				{
					List<PolygonData> list2 = enumerable.ToList<PolygonData>();
					if (list2.Any<PolygonData>())
					{
						list.Add(new ShapesIntersectionResult(shapeData, list2));
					}
				}
			}
			return list;
		}

		// Token: 0x06003F35 RID: 16181 RVA: 0x00123EB0 File Offset: 0x001220B0
		public static IEnumerable<PolygonData> #CP(PolygonData #9lc, PolygonData #amc)
		{
			List<List<IntPoint>> list;
			do
			{
				if (8 != 0)
				{
					#X0d.#V0d(#9lc, #Phc.#3hc(107370544), Component.Geometry, #Phc.#3hc(107370499));
				}
				do
				{
					#X0d.#V0d(#amc, #Phc.#3hc(107370958), Component.Geometry, #Phc.#3hc(107370945));
					Clipper clipper = BooleanOperationsHelper.#dmc();
					clipper.AddPath(ShapeToClipperPolygonsConverter.#Pb(#9lc), PolyType.ptSubject, true);
					clipper.AddPath(ShapeToClipperPolygonsConverter.#Pb(#amc), PolyType.ptClip, true);
					list = new List<List<IntPoint>>();
					if (!clipper.Execute(ClipType.ctIntersection, list, PolyFillType.pftEvenOdd, PolyFillType.pftEvenOdd))
					{
						goto IL_92;
					}
					list = BooleanOperationsHelper.#nmc(list, PolyFillType.pftEvenOdd, true, true);
				}
				while (7 == 0);
				if (8 == 0)
				{
					goto IL_92;
				}
			}
			while (-1 == 0);
			return ShapeToClipperPolygonsConverter.#Rsc(list);
			IL_92:
			return null;
		}

		// Token: 0x06003F36 RID: 16182 RVA: 0x00123FA4 File Offset: 0x001221A4
		public static IEnumerable<PolygonData> #CP(ShapeData #6lc, PolygonData #JP)
		{
			#X0d.#V0d(#6lc, #Phc.#3hc(107371211), Component.Geometry, #Phc.#3hc(107370892));
			#X0d.#V0d(#JP, #Phc.#3hc(107399958), Component.Geometry, #Phc.#3hc(107370871));
			if (#6lc.PolygonsCount < 1 || !BooleanOperationsHelper.#emc(#6lc, #JP))
			{
				return null;
			}
			Clipper clipper = BooleanOperationsHelper.#dmc();
			clipper.AddPaths(ShapeToClipperPolygonsConverter.#Pb(#6lc), PolyType.ptSubject, true);
			clipper.AddPath(ShapeToClipperPolygonsConverter.#Pb(#JP), PolyType.ptClip, true);
			List<List<IntPoint>> list = new List<List<IntPoint>>();
			if (clipper.Execute(ClipType.ctIntersection, list, PolyFillType.pftEvenOdd, PolyFillType.pftEvenOdd))
			{
				list = BooleanOperationsHelper.#nmc(list, PolyFillType.pftEvenOdd, true, true);
				return ShapeToClipperPolygonsConverter.#Rsc(list);
			}
			return null;
		}

		// Token: 0x06003F37 RID: 16183 RVA: 0x0012409C File Offset: 0x0012229C
		internal unsafe static void #bmc(IList<IntPoint> #BP, long #cmc = 1L)
		{
			void* ptr = stackalloc byte[5];
			#X0d.#V0d(#BP, #Phc.#3hc(107358670), Component.Geometry, #Phc.#3hc(107370786));
			*(byte*)(ptr + 4) = 1;
			while (*(sbyte*)((byte*)ptr + 4) != 0)
			{
				*(byte*)(ptr + 4) = 0;
				*(int*)ptr = #BP.Count - 1;
				while (*(int*)ptr > 0)
				{
					IntPoint #mcb = #BP[*(int*)ptr];
					IntPoint #ncb = #BP[*(int*)ptr - 1];
					if (BooleanOperationsHelper.#uC(#mcb, #ncb, 1L))
					{
						#BP.RemoveAt(*(int*)ptr);
						((byte*)ptr)[4] = 1;
					}
					*(int*)ptr = *(int*)ptr - 1;
				}
			}
		}

		// Token: 0x06003F38 RID: 16184 RVA: 0x00124178 File Offset: 0x00122378
		internal static bool #uC(IntPoint #mcb, IntPoint #ncb, long #cmc = 1L)
		{
			long num = \u000F\u0002.\u0018\u0004(#mcb.X - #ncb.X);
			long num2 = #cmc;
			bool flag;
			int result;
			while (num <= num2 && !false)
			{
				long num3 = num = \u000F\u0002.\u0018\u0004(#mcb.Y - #ncb.Y);
				num2 = #cmc;
				if (4 != 0 && !false)
				{
					flag = (num3 > #cmc);
					IL_3D:
					result = ((flag = !flag) ? 1 : 0);
					IL_40:
					if (-1 != 0)
					{
						return result != 0;
					}
					goto IL_3D;
				}
			}
			bool flag2 = flag = ((result = 0) != 0);
			if (!flag2)
			{
				return flag2;
			}
			goto IL_40;
		}

		// Token: 0x06003F39 RID: 16185 RVA: 0x001241F0 File Offset: 0x001223F0
		internal unsafe static void #9ob(IList<IntPoint> #BP)
		{
			void* ptr = stackalloc byte[12];
			if (#BP.Count < 3)
			{
				return;
			}
			BooleanOperationsHelper.#bmc(#BP, 1L);
			if (#BP.Count < 3)
			{
				return;
			}
			*(int*)ptr = #BP.Count - 1;
			while (*(int*)ptr >= 0)
			{
				*(int*)((byte*)ptr + 4) = #BP.#f2d(*(int*)ptr);
				*(int*)((byte*)ptr + 8) = #BP.#e2d(*(int*)ptr);
				IntPoint #mcb = #BP[*(int*)((byte*)ptr + 4)];
				IntPoint #ncb = #BP[*(int*)((byte*)ptr + 8)];
				if (BooleanOperationsHelper.#uC(#mcb, #ncb, 1L))
				{
					#BP.RemoveAt(*(int*)((byte*)ptr + 8));
					#BP.RemoveAt(*(int*)ptr);
				}
				if (#BP.Count < 3)
				{
					break;
				}
				*(int*)ptr = *(int*)ptr - 1;
			}
		}

		// Token: 0x06003F3A RID: 16186 RVA: 0x00035A22 File Offset: 0x00033C22
		private static Clipper #dmc()
		{
			return new Clipper(0)
			{
				PreserveCollinear = true
			};
		}

		// Token: 0x06003F3B RID: 16187 RVA: 0x001242E4 File Offset: 0x001224E4
		private static bool #emc(ShapeData #rP, PolygonData #JP)
		{
			if (4 != 0)
			{
				IEnumerator<PolygonData> enumerator = #rP.Polygons.GetEnumerator();
				bool result;
				try
				{
					int num;
					for (;;)
					{
						bool flag = (num = (\u0010\u0002.~\u0019\u0004(enumerator) ? 1 : 0)) != 0;
						if (false)
						{
							goto IL_33;
						}
						if (!flag)
						{
							goto Block_7;
						}
						for (;;)
						{
							PolygonData polygonData = enumerator.Current;
							PolygonData polygonData2;
							if (!false)
							{
								polygonData2 = polygonData;
							}
							if (!#JP.BoundingBoxData.#pFb(polygonData2.BoundingBoxData))
							{
								break;
							}
							if (!false)
							{
								goto Block_5;
							}
						}
					}
					Block_5:
					num = 1;
					IL_33:
					result = (num != 0);
					goto IL_76;
					Block_7:;
				}
				finally
				{
					do
					{
						if (enumerator != null)
						{
							\u0007.~\u000E(enumerator);
						}
					}
					while (!true);
				}
				goto IL_71;
				IL_76:
				return result;
			}
			IL_71:
			int result2;
			int num2 = result2 = 0;
			if (num2 == 0)
			{
				return num2 != 0;
			}
			return result2 != 0;
		}

		// Token: 0x06003F3C RID: 16188 RVA: 0x00124398 File Offset: 0x00122598
		[SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "2#")]
		[SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "3#")]
		public static bool #Tlc(PolygonData #9lc, PolygonData #amc, out PolygonData #fmc, out List<PolygonData> #gmc)
		{
			do
			{
				#X0d.#V0d(#9lc, #Phc.#3hc(107370544), Component.Geometry, #Phc.#3hc(107370221));
			}
			while (false);
			#X0d.#V0d(#amc, #Phc.#3hc(107370958), Component.Geometry, #Phc.#3hc(107370200));
			#fmc = null;
			#gmc = new List<PolygonData>();
			Clipper clipper = BooleanOperationsHelper.#dmc();
			clipper.AddPath(ShapeToClipperPolygonsConverter.#Pb(#9lc), PolyType.ptSubject, true);
			clipper.AddPath(ShapeToClipperPolygonsConverter.#Pb(#amc), PolyType.ptClip, true);
			List<List<IntPoint>> list = new List<List<IntPoint>>();
			if (clipper.Execute(ClipType.ctUnion, list, PolyFillType.pftEvenOdd))
			{
				if (!list.Any<List<IntPoint>>())
				{
					return true;
				}
				if (5 != 0)
				{
					#fmc = ShapeToClipperPolygonsConverter.#Tsc(list.First<List<IntPoint>>());
				}
			}
			else if (!false)
			{
				return false;
			}
			#gmc.AddRange(ShapeToClipperPolygonsConverter.#Rsc(list.Skip(1).ToList<List<IntPoint>>()));
			return true;
		}

		// Token: 0x06003F3D RID: 16189 RVA: 0x001244AC File Offset: 0x001226AC
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public unsafe static bool #Tlc(List<PolygonData> #4lc, List<PolygonData> #hmc, List<PolygonData> #imc)
		{
			void* ptr;
			List<PolygonData> list;
			if (2 != 0)
			{
				ptr = stackalloc byte[2];
				#X0d.#V0d(#4lc, #Phc.#3hc(107371137), Component.Geometry, #Phc.#3hc(107370115));
				#X0d.#V0d(#hmc, #Phc.#3hc(107370062), Component.Geometry, #Phc.#3hc(107370065));
				if (!false)
				{
					#X0d.#V0d(#imc, #Phc.#3hc(107370012), Component.Geometry, #Phc.#3hc(107370495));
					#hmc.Clear();
					#imc.Clear();
					list = new List<PolygonData>(#4lc);
				}
			}
			for (;;)
			{
				while (list.Any<PolygonData>())
				{
					if (!false)
					{
						BooleanOperationsHelper.#yZb #yZb = new BooleanOperationsHelper.#yZb();
						#yZb.#a = list[0];
						if (4 == 0)
						{
							goto IL_181;
						}
						*(byte*)ptr = 0;
						IEnumerable<PolygonData> source = list;
						Func<PolygonData, bool> predicate;
						if ((predicate = #yZb.#b) == null)
						{
							predicate = (#yZb.#b = new Func<PolygonData, bool>(#yZb.#oxc));
						}
						using (List<PolygonData>.Enumerator enumerator = source.Where(predicate).ToList<PolygonData>().GetEnumerator())
						{
							PolygonData polygonData;
							PolygonData polygonData2;
							for (;;)
							{
								while (enumerator.MoveNext())
								{
									polygonData = enumerator.Current;
									if (BooleanOperationsHelper.#7lc(#yZb.#a.IntPoints, polygonData.IntPoints))
									{
										if (7 != 0)
										{
											List<PolygonData> collection;
											if (!BooleanOperationsHelper.#Tlc(#yZb.#a, polygonData, out polygonData2, out collection))
											{
												((byte*)ptr)[1] = 0;
												if (!false)
												{
													goto Block_12;
												}
											}
											for (;;)
											{
												#imc.AddRange(collection);
												*(byte*)ptr = 1;
												if (polygonData2 == null)
												{
													break;
												}
												list.RemoveAt(0);
												if (!false)
												{
													goto Block_14;
												}
											}
										}
									}
								}
								goto Block_15;
							}
							Block_12:
							goto IL_181;
							Block_14:
							list.Remove(polygonData);
							list.Add(polygonData2);
							Block_15:;
						}
						if (*(sbyte*)ptr == 0)
						{
							list.RemoveAt(0);
							#hmc.Add(#yZb.#a);
						}
					}
				}
				break;
			}
			return true;
			IL_181:
			return *(sbyte*)((byte*)ptr + 1) != 0;
		}

		// Token: 0x06003F3E RID: 16190 RVA: 0x0012469C File Offset: 0x0012289C
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		internal static bool #7lc(List<IntPoint> #9lc, List<IntPoint> #amc)
		{
			Clipper clipper = BooleanOperationsHelper.#dmc();
			clipper.AddPath(#9lc, PolyType.ptSubject, true);
			clipper.AddPath(#amc, PolyType.ptClip, true);
			List<List<IntPoint>> list = new List<List<IntPoint>>();
			bool flag;
			int result = (flag = clipper.Execute(ClipType.ctIntersection, list, PolyFillType.pftEvenOdd)) ? 1 : 0;
			while (!false)
			{
				if (flag)
				{
					result = (list.Any<List<IntPoint>>() ? 1 : 0);
					break;
				}
				bool flag2 = flag = ((result = 0) != 0);
				if (!flag2)
				{
					result = (flag2 ? 1 : 0);
					if (!flag2)
					{
						return flag2;
					}
					break;
				}
			}
			return result != 0;
		}

		// Token: 0x06003F3F RID: 16191 RVA: 0x00124704 File Offset: 0x00122904
		[SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		internal static bool #jmc(ShapeData #rP, List<List<IntPoint>> #kmc, List<List<IntPoint>> #lmc)
		{
			#kmc.Clear();
			#lmc.Clear();
			List<PolygonData> list = new List<PolygonData>();
			List<PolygonData> list2 = new List<PolygonData>();
			if (!BooleanOperationsHelper.#Tlc(#rP.Polygons.Skip(1).ToList<PolygonData>(), list, list2))
			{
				return false;
			}
			#kmc.AddRange(ShapeToClipperPolygonsConverter.#Pb(list));
			#lmc.AddRange(ShapeToClipperPolygonsConverter.#Pb(list2));
			return true;
		}

		// Token: 0x06003F40 RID: 16192 RVA: 0x00124784 File Offset: 0x00122984
		public static bool #mmc(ShapeData #rP)
		{
			if (!false)
			{
				#X0d.#V0d(#rP, #Phc.#3hc(107371527), Component.Geometry, #Phc.#3hc(107370410));
				while (#rP.PolygonsCount >= 1)
				{
					Clipper clipper = BooleanOperationsHelper.#dmc();
					if (true)
					{
						\u000E\u0002.~\u0017\u0004(clipper, ShapeToClipperPolygonsConverter.#Pb(#rP.Polygons.First<PolygonData>()), PolyType.ptSubject, true);
						goto IL_62;
					}
					goto IL_7B;
					IL_9C:
					List<List<IntPoint>> list = new List<List<IntPoint>>();
					List<List<IntPoint>> list4;
					if (\u0008\u0002.~\u0016\u0004(clipper, ClipType.ctDifference, list, PolyFillType.pftEvenOdd, PolyFillType.pftEvenOdd))
					{
						list = BooleanOperationsHelper.#nmc(list, PolyFillType.pftEvenOdd, true, true);
						IList<PolygonData> list2 = ShapeToClipperPolygonsConverter.#Rsc(list);
						IList<PolygonData> list3 = ShapeToClipperPolygonsConverter.#Rsc(list4);
						if (BooleanOperationsHelper.#3lc(list2) && BooleanOperationsHelper.#3lc(list3))
						{
							#rP.#yl();
							if (3 != 0)
							{
								#rP.#pR(list2);
								#rP.#pR(list3);
								return true;
							}
							continue;
						}
					}
					return false;
					IL_62:
					list4 = new List<List<IntPoint>>();
					if (#rP.PolygonsCount <= 1)
					{
						goto IL_9C;
					}
					List<List<IntPoint>> list5;
					if (-1 != 0)
					{
						list5 = new List<List<IntPoint>>();
						goto IL_7B;
					}
					IL_8D:
					\u0007\u0002.~\u0015\u0004(clipper, list5, PolyType.ptClip, true);
					goto IL_9C;
					IL_7B:
					if (false)
					{
						return false;
					}
					bool flag = BooleanOperationsHelper.#jmc(#rP, list5, list4);
					if (false)
					{
						goto IL_62;
					}
					if (!flag)
					{
						return false;
					}
					goto IL_8D;
				}
				return false;
			}
			return false;
		}

		// Token: 0x06003F41 RID: 16193 RVA: 0x001248DC File Offset: 0x00122ADC
		[SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		internal static List<List<IntPoint>> #nmc(List<List<IntPoint>> #iub, PolyFillType #omc = PolyFillType.pftEvenOdd, bool #Ulc = true, bool #Vlc = true)
		{
			List<List<IntPoint>> list = new List<List<IntPoint>>();
			List<List<IntPoint>> list2;
			if (!false)
			{
				list2 = list;
			}
			Clipper clipper = new Clipper(0);
			clipper.StrictlySimple = #Ulc;
			clipper.PreserveCollinear = #Vlc;
			clipper.AddPaths(#iub, PolyType.ptSubject, true);
			clipper.Execute(ClipType.ctUnion, list2, #omc, #omc);
			return list2;
		}

		// Token: 0x020007B3 RID: 1971
		[CompilerGenerated]
		private sealed class #yZb
		{
			// Token: 0x06003F46 RID: 16198 RVA: 0x00035A55 File Offset: 0x00033C55
			internal bool #oxc(PolygonData #Rf)
			{
				return #Rf != this.#a;
			}

			// Token: 0x04001CBC RID: 7356
			public PolygonData #a;

			// Token: 0x04001CBD RID: 7357
			public Func<PolygonData, bool> #b;
		}
	}
}
