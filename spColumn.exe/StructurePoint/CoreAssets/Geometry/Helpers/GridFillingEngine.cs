using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;
using #Fmc;
using #UYd;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using TriangleNet;
using TriangleNet.Geometry;
using TriangleNet.Meshing;
using TriangleNet.Topology;

namespace StructurePoint.CoreAssets.Geometry.Helpers
{
	// Token: 0x020007C9 RID: 1993
	public sealed class GridFillingEngine
	{
		// Token: 0x06003FE8 RID: 16360 RVA: 0x00129DAC File Offset: 0x00127FAC
		public GridFillingEngine(BoundingBoxData workspaceSize, IList<SegmentData> segments)
		{
			#X0d.#V0d(segments, #Phc.#3hc(107367545), Component.Geometry, #Phc.#3hc(107367500));
			this.#b = workspaceSize;
			segments = this.#qpc(segments);
			this.#a = segments.Select(new Func<SegmentData, TempSegmentRayData>(GridFillingEngine.<>c.<>9.#DXb)).ToList<TempSegmentRayData>();
			this.#c = GridFillingEngine.#cpc(this.#b.Width, this.#b.Height);
		}

		// Token: 0x06003FE9 RID: 16361 RVA: 0x00036077 File Offset: 0x00034277
		public static double #cpc(double #6Q, double #YW)
		{
			double num = \u0006\u0002.\u0007\u0004(#6Q * #6Q + #YW * #YW);
			double result;
			do
			{
				result = (num += 10.0);
			}
			while (false);
			return result;
		}

		// Token: 0x06003FEA RID: 16362 RVA: 0x00129E3C File Offset: 0x0012803C
		public static IList<PolygonData> #dpc(IList<StructurePoint.CoreAssets.Infrastructure.Data.Point> #epc)
		{
			#X0d.#V0d(#epc, #Phc.#3hc(107367479), Component.Geometry, #Phc.#3hc(107367430));
			List<PolygonData> list = new List<PolygonData>();
			foreach (Triangle triangle in GridFillingEngine.#kpc(#epc))
			{
				StructurePoint.CoreAssets.Infrastructure.Data.Point point = GridFillingEngine.#lpc(triangle.GetVertex(0));
				StructurePoint.CoreAssets.Infrastructure.Data.Point point2 = GridFillingEngine.#lpc(triangle.GetVertex(1));
				StructurePoint.CoreAssets.Infrastructure.Data.Point point3 = GridFillingEngine.#lpc(triangle.GetVertex(2));
				list.Add(new PolygonData(PointsConverter.#vsc(new StructurePoint.CoreAssets.Infrastructure.Data.Point[]
				{
					point,
					point2,
					point3
				})));
			}
			return list.ToList<PolygonData>();
		}

		// Token: 0x06003FEB RID: 16363 RVA: 0x00129F58 File Offset: 0x00128158
		public static IList<StructurePoint.CoreAssets.Infrastructure.Data.Point> #fpc(IList<StructurePoint.CoreAssets.Infrastructure.Data.Point> #epc)
		{
			#X0d.#V0d(#epc, #Phc.#3hc(107367479), Component.Geometry, #Phc.#3hc(107367430));
			IEnumerable<Triangle> enumerable = GridFillingEngine.#kpc(#epc);
			HashSet<StructurePoint.CoreAssets.Infrastructure.Data.Point> hashSet = new HashSet<StructurePoint.CoreAssets.Infrastructure.Data.Point>();
			foreach (Triangle triangle in enumerable)
			{
				StructurePoint.CoreAssets.Infrastructure.Data.Point point = GridFillingEngine.#lpc(triangle.GetVertex(0));
				StructurePoint.CoreAssets.Infrastructure.Data.Point point2 = GridFillingEngine.#lpc(triangle.GetVertex(1));
				StructurePoint.CoreAssets.Infrastructure.Data.Point point3 = GridFillingEngine.#lpc(triangle.GetVertex(2));
				if (6 == 0)
				{
					goto IL_98;
				}
				StructurePoint.CoreAssets.Infrastructure.Data.Point? point4 = #jsc.#fsc(point, point2, point3);
				StructurePoint.CoreAssets.Infrastructure.Data.Point? point5 = #jsc.#fsc(point, point3, point2);
				StructurePoint.CoreAssets.Infrastructure.Data.Point? point6 = #jsc.#fsc(point2, point3, point);
				if (point4 != null)
				{
					goto IL_98;
				}
				IL_B6:
				if (point5 != null)
				{
					hashSet.Add(GeometryHelper.#fnc(point5.Value, point2, 0.3));
				}
				if (point6 != null)
				{
					hashSet.Add(GeometryHelper.#fnc(point6.Value, point, 0.3));
				}
				hashSet.Add(new StructurePoint.CoreAssets.Infrastructure.Data.Point((point.X + point2.X + point3.X) / 3.0, (point.Y + point2.Y + point3.Y) / 3.0));
				continue;
				IL_98:
				hashSet.Add(GeometryHelper.#fnc(point4.Value, point3, 0.3));
				goto IL_B6;
			}
			return hashSet.ToList<StructurePoint.CoreAssets.Infrastructure.Data.Point>();
		}

		// Token: 0x06003FEC RID: 16364 RVA: 0x0012A13C File Offset: 0x0012833C
		public unsafe IList<PolygonData> #gpc(IEnumerable<StructurePoint.CoreAssets.Infrastructure.Data.Point> #BP, double? #hpc, int #ipc)
		{
			void* ptr = stackalloc byte[8];
			string #R0d = #Phc.#3hc(107358670);
			Component #x6c = Component.Geometry;
			string #Qic = #Phc.#3hc(107367921);
			if (-1 != 0)
			{
				#X0d.#V0d(#BP, #R0d, #x6c, #Qic);
			}
			List<PolygonData> list = new List<PolygonData>();
			#hpc = new double?(#hpc ?? this.#c);
			*(int*)ptr = 0;
			*(int*)((byte*)ptr + 4) = 0;
			HashSet<StructurePoint.CoreAssets.Infrastructure.Data.Point> hashSet = new HashSet<StructurePoint.CoreAssets.Infrastructure.Data.Point>(#BP);
			while (hashSet.Count > 0)
			{
				StructurePoint.CoreAssets.Infrastructure.Data.Point point = hashSet.First<StructurePoint.CoreAssets.Infrastructure.Data.Point>();
				hashSet.Remove(point);
				*(int*)((byte*)ptr + 4) = *(int*)((byte*)ptr + 4) + 1;
				*(int*)ptr = *(int*)ptr + 1;
				PolygonData polygonData = this.#jpc(point, #hpc, #ipc);
				if (polygonData != null)
				{
					list.Add(polygonData);
					hashSet.RemoveWhere(new Predicate<StructurePoint.CoreAssets.Infrastructure.Data.Point>(polygonData.#Lnc));
				}
			}
			return list;
		}

		// Token: 0x06003FED RID: 16365 RVA: 0x0012A258 File Offset: 0x00128458
		public unsafe PolygonData #jpc(StructurePoint.CoreAssets.Infrastructure.Data.Point #Ng, double? #hpc, int #ipc)
		{
			void* ptr = stackalloc byte[8];
			while (GeometryHelper.#coc(this.#b, #Ng) && !false)
			{
				if (!false)
				{
					#hpc = new double?(#hpc ?? this.#c);
					if (false)
					{
						goto IL_DD;
					}
					if (7 == 0)
					{
						goto IL_7D;
					}
					List<SegmentData> list = this.#rpc(#Ng, #ipc, #hpc.Value).Distinct<SegmentData>().ToList<SegmentData>();
					IL_77:
					List<StructurePoint.CoreAssets.Infrastructure.Data.Point> list2 = new List<StructurePoint.CoreAssets.Infrastructure.Data.Point>();
					IL_7D:
					HashSet<StructurePoint.CoreAssets.Infrastructure.Data.Point> hashSet = new HashSet<StructurePoint.CoreAssets.Infrastructure.Data.Point>();
					*(int*)ptr = list.Count;
					*(int*)((byte*)ptr + 4) = 0;
					IL_90:
					goto IL_F7;
					IL_DD:
					if (false)
					{
						goto IL_77;
					}
					StructurePoint.CoreAssets.Infrastructure.Data.Point? point;
					list2.Add(point.Value);
					IL_ED:
					*(int*)((byte*)ptr + 4) = *(int*)((byte*)ptr + 4) + 1;
					IL_F7:
					int num;
					if (*(int*)((byte*)ptr + 4) >= *(int*)ptr)
					{
						num = hashSet.Count;
					}
					else
					{
						point = #jsc.#plc(list[*(int*)((byte*)ptr + 4)], list[(*(int*)((byte*)ptr + 4) + 1) % *(int*)ptr], true);
						if (point == null)
						{
							goto IL_ED;
						}
						bool flag = (num = (hashSet.Add(point.Value) ? 1 : 0)) != 0;
						if (7 != 0)
						{
							if (flag && !PointsConverter.#uC(#Ng, point.Value))
							{
								goto IL_DD;
							}
							goto IL_ED;
						}
					}
					if (num < PolygonData.MinNumberOfPoints || hashSet.Count != list2.Count)
					{
						return null;
					}
					if (8 != 0)
					{
						return new PolygonData(PointsConverter.#vsc(list2));
					}
					goto IL_90;
				}
			}
			return null;
		}

		// Token: 0x06003FEE RID: 16366 RVA: 0x0012A3D8 File Offset: 0x001285D8
		private static ICollection<Triangle> #kpc(IList<StructurePoint.CoreAssets.Infrastructure.Data.Point> #epc)
		{
			IList<StructurePoint.CoreAssets.Infrastructure.Data.Point> list = #epc.Distinct<StructurePoint.CoreAssets.Infrastructure.Data.Point>().ToList<StructurePoint.CoreAssets.Infrastructure.Data.Point>();
			if (4 != 0)
			{
				#epc = list;
			}
			if (#epc.Count < 3)
			{
				return new List<Triangle>();
			}
			Polygon polygon = new Polygon();
			IList<StructurePoint.CoreAssets.Infrastructure.Data.Point> list2 = GeometryHelper.#Inc(#epc);
			#epc = #epc.Except(list2).ToList<StructurePoint.CoreAssets.Infrastructure.Data.Point>();
			GridFillingEngine.#opc(polygon, GridFillingEngine.#npc(list2), false);
			using (IEnumerator<StructurePoint.CoreAssets.Infrastructure.Data.Point> enumerator = #epc.GetEnumerator())
			{
				do
				{
					while (enumerator.MoveNext())
					{
						StructurePoint.CoreAssets.Infrastructure.Data.Point point = enumerator.Current;
						polygon.Add(new Vertex(point.X, point.Y));
					}
				}
				while (false);
			}
			GenericMesher genericMesher = new GenericMesher();
			QualityOptions quality = new QualityOptions
			{
				MaximumAngle = 30.0,
				MaximumArea = 4.0,
				VariableArea = true
			};
			ConstraintOptions options = new ConstraintOptions
			{
				ConformingDelaunay = true,
				Convex = true
			};
			return ((Mesh)genericMesher.Triangulate(polygon, options, quality)).Triangles;
		}

		// Token: 0x06003FEF RID: 16367 RVA: 0x000360AB File Offset: 0x000342AB
		private static StructurePoint.CoreAssets.Infrastructure.Data.Point #lpc(Vertex #mpc)
		{
			return new StructurePoint.CoreAssets.Infrastructure.Data.Point(\u001B\u0002.~\u0097\u0004(#mpc), \u001B\u0002.~\u0098\u0004(#mpc));
		}

		// Token: 0x06003FF0 RID: 16368 RVA: 0x000360DC File Offset: 0x000342DC
		private static IList<Vertex> #npc(IEnumerable<StructurePoint.CoreAssets.Infrastructure.Data.Point> #uzb)
		{
			return #uzb.Select(new Func<StructurePoint.CoreAssets.Infrastructure.Data.Point, Vertex>(GridFillingEngine.<>c.<>9.#Kxc)).ToList<Vertex>();
		}

		// Token: 0x06003FF1 RID: 16369 RVA: 0x0012A534 File Offset: 0x00128734
		private static void #opc(Polygon #JP, IList<Vertex> #AHb, bool #ppc)
		{
			Contour contour = new Contour(#AHb);
			#JP.Add(contour, #ppc);
		}

		// Token: 0x06003FF2 RID: 16370 RVA: 0x0012A56C File Offset: 0x0012876C
		private IList<SegmentData> #qpc(IList<SegmentData> #IP)
		{
			List<SegmentData> list;
			for (;;)
			{
				list = GeometryHelper.#Cnc(this.#b);
				int num = list.Count - 1;
				for (;;)
				{
					if (7 != 0)
					{
						goto IL_6A;
					}
					goto IL_59;
					IL_6B:
					int num2;
					if (num2 < 0)
					{
						list.AddRange(#IP);
						if (3 != 0)
						{
							return list;
						}
					}
					if (false)
					{
						continue;
					}
					GridFillingEngine.#BUb #BUb = new GridFillingEngine.#BUb();
					#BUb.#a = list[num];
					if (#IP.Any(new Func<SegmentData, bool>(#BUb.#Lxc)))
					{
						goto IL_59;
					}
					IL_60:
					if (!true)
					{
						break;
					}
					int num3 = num2 = num - 1;
					if (6 == 0)
					{
						goto IL_6B;
					}
					num = num3;
					IL_6A:
					num2 = num;
					goto IL_6B;
					IL_59:
					list.RemoveAt(num);
					goto IL_60;
				}
			}
			return list;
		}

		// Token: 0x06003FF3 RID: 16371 RVA: 0x0012A634 File Offset: 0x00128834
		private unsafe IList<SegmentData> #rpc(StructurePoint.CoreAssets.Infrastructure.Data.Point #Ng, int #1f, double #hpc)
		{
			void* ptr = stackalloc byte[32];
			void* ptr2;
			if (!false)
			{
				ptr2 = ptr;
			}
			GridFillingEngine.#61b #61b = new GridFillingEngine.#61b();
			#61b.#a = #Ng;
			#61b.#b = #hpc;
			*(double*)ptr2 = 360.0 / (double)#1f;
			*(double*)((byte*)ptr2 + 8) = *(double*)ptr2 * 7.0;
			*(double*)((byte*)ptr2 + 16) = *(double*)((byte*)ptr2 + 8) - *(double*)ptr2;
			List<SegmentData> list = new List<SegmentData>();
			SegmentData segmentData = null;
			List<TempSegmentRayData> #tpc = this.#a.Where(new Func<TempSegmentRayData, bool>(#61b.#Mxc)).ToList<TempSegmentRayData>();
			*(double*)((byte*)ptr2 + 24) = 0.0;
			while (*(double*)((byte*)ptr2 + 24) < 360.0)
			{
				double #HS2;
				double #HS = #HS2 = #61b.#b;
				if (false)
				{
					goto IL_DF;
				}
				#wpc #upc = GridFillingEngine.#vpc(#HS, #61b.#a, *(double*)((byte*)ptr2 + 24));
				SegmentData segmentData2 = GridFillingEngine.#spc(#tpc, #upc);
				if (segmentData2 != null)
				{
					if (segmentData2 != segmentData)
					{
						segmentData = segmentData2;
						list.Add(segmentData2);
					}
					#HS2 = #61b.#b;
					goto IL_DF;
				}
				IL_11A:
				*(double*)((byte*)ptr2 + 24) = *(double*)((byte*)ptr2 + 24) + *(double*)ptr2;
				continue;
				IL_DF:
				#upc = GridFillingEngine.#vpc(#HS2, #61b.#a, *(double*)((byte*)ptr2 + 24) + *(double*)((byte*)ptr2 + 8));
				segmentData2 = GridFillingEngine.#spc(#tpc, #upc);
				if (segmentData2 != null && segmentData2 == segmentData)
				{
					*(double*)((byte*)ptr2 + 24) = *(double*)((byte*)ptr2 + 24) + *(double*)((byte*)ptr2 + 16);
					goto IL_11A;
				}
				goto IL_11A;
			}
			return list;
		}

		// Token: 0x06003FF4 RID: 16372 RVA: 0x0012A7B8 File Offset: 0x001289B8
		private unsafe static SegmentData #spc(IList<TempSegmentRayData> #tpc, #wpc #upc)
		{
			void* ptr;
			SegmentData result;
			StructurePoint.CoreAssets.Infrastructure.Data.Point? point;
			for (;;)
			{
				ptr = stackalloc byte[20];
				*(double*)ptr = double.MaxValue;
				result = null;
				point = null;
				if (false)
				{
					goto IL_C2;
				}
				StructurePoint.CoreAssets.Infrastructure.Data.Point #ncb = #upc.Point;
				SegmentData #Vrc = #upc.Segment;
				*(int*)((byte*)ptr + 16) = 0;
				IL_DC:
				if (*(int*)((byte*)ptr + 16) >= #tpc.Count)
				{
					break;
				}
				TempSegmentRayData tempSegmentRayData = #tpc[*(int*)((byte*)ptr + 16)];
				StructurePoint.CoreAssets.Infrastructure.Data.Point? point2;
				if (#upc.BoundingRect.IntersectsWith(tempSegmentRayData.BoundingRect))
				{
					point2 = #jsc.#plc(tempSegmentRayData.Segment, #Vrc, true);
					if (point2 != null)
					{
						*(double*)((byte*)ptr + 8) = GeometryHelper.#lcb(point2.Value, #ncb);
						if (4 == 0)
						{
							continue;
						}
						if (*(double*)((byte*)ptr + 8) < *(double*)ptr)
						{
							result = tempSegmentRayData.Segment;
							*(double*)ptr = *(double*)((byte*)ptr + 8);
							goto IL_C2;
						}
					}
				}
				IL_D0:
				*(int*)((byte*)ptr + 16) = *(int*)((byte*)ptr + 16) + 1;
				goto IL_DC;
				IL_C2:
				point = new StructurePoint.CoreAssets.Infrastructure.Data.Point?(point2.Value);
				goto IL_D0;
			}
			if (*(double*)ptr != 1.7976931348623157E+308 && point != null)
			{
				return result;
			}
			return null;
		}

		// Token: 0x06003FF5 RID: 16373 RVA: 0x0012A90C File Offset: 0x00128B0C
		private unsafe static #wpc #vpc(double #HS, StructurePoint.CoreAssets.Infrastructure.Data.Point #Ng, double #Udb)
		{
			void* ptr;
			if (!false)
			{
				if (4 == 0)
				{
					goto IL_27;
				}
				ptr = stackalloc byte[16];
				#Udb = GeometryHelper.#Qmc(#Udb);
			}
			*(double*)ptr = #Ng.X + #HS * \u0006\u0002.\u0008\u0004(#Udb);
			IL_27:
			*(double*)((byte*)ptr + 8) = #Ng.Y + #HS * \u0006\u0002.\u000E\u0004(#Udb);
			StructurePoint.CoreAssets.Infrastructure.Data.Point? point = new StructurePoint.CoreAssets.Infrastructure.Data.Point?(new StructurePoint.CoreAssets.Infrastructure.Data.Point(*(double*)ptr, *(double*)((byte*)ptr + 8)));
			return new #wpc(new SegmentData(#Ng, point.Value), #Ng);
		}

		// Token: 0x04001CF2 RID: 7410
		private readonly List<TempSegmentRayData> #a;

		// Token: 0x04001CF3 RID: 7411
		private readonly BoundingBoxData #b;

		// Token: 0x04001CF4 RID: 7412
		private readonly double #c;

		// Token: 0x020007CB RID: 1995
		[CompilerGenerated]
		private sealed class #BUb
		{
			// Token: 0x06003FFB RID: 16379 RVA: 0x00036134 File Offset: 0x00034334
			internal bool #Lxc(SegmentData #Rf)
			{
				return #Qsc.#Psc(#Rf, this.#a);
			}

			// Token: 0x04001CF8 RID: 7416
			public SegmentData #a;
		}

		// Token: 0x020007CC RID: 1996
		[CompilerGenerated]
		private sealed class #61b
		{
			// Token: 0x06003FFD RID: 16381 RVA: 0x0003614E File Offset: 0x0003434E
			internal bool #Mxc(TempSegmentRayData #Nxc)
			{
				return #Nxc.GeneralLineEquation.#lcb(this.#a) <= this.#b;
			}

			// Token: 0x04001CF9 RID: 7417
			public StructurePoint.CoreAssets.Infrastructure.Data.Point #a;

			// Token: 0x04001CFA RID: 7418
			public double #b;
		}
	}
}
