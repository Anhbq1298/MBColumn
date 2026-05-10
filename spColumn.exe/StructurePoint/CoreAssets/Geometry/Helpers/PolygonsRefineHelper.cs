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

namespace StructurePoint.CoreAssets.Geometry.Helpers
{
	// Token: 0x020007E7 RID: 2023
	public static class PolygonsRefineHelper
	{
		// Token: 0x060040F3 RID: 16627 RVA: 0x0013028C File Offset: 0x0012E48C
		public static bool #Fsc(PolygonData #9lc, PolygonData #amc, double #Gsc, double #Hsc)
		{
			string #R0d = #Phc.#3hc(107370544);
			Component #x6c = Component.Geometry;
			string #Qic = #Phc.#3hc(107461139);
			if (4 != 0)
			{
				#X0d.#V0d(#9lc, #R0d, #x6c, #Qic);
			}
			#X0d.#V0d(#amc, #Phc.#3hc(107370958), Component.Geometry, #Phc.#3hc(107461598));
			if (!PolygonsRefineHelper.#Isc(#9lc, #amc))
			{
				return false;
			}
			List<Point> list = #9lc.Points2D.ToList<Point>();
			List<Point> list2 = #amc.Points2D.ToList<Point>();
			bool flag = PolygonsRefineHelper.#Jsc(list, list2, #Gsc, #Hsc);
			if (!false && PolygonsRefineHelper.#Jsc(list2, list, #Gsc, #Hsc))
			{
				flag = true;
			}
			if (flag)
			{
				#9lc.#dwc(list);
				#amc.#dwc(list2);
			}
			return flag;
		}

		// Token: 0x060040F4 RID: 16628 RVA: 0x00130380 File Offset: 0x0012E580
		private static bool #Isc(PolygonData #9lc, PolygonData #amc)
		{
			BoundingBoxDataLight boundingBoxDataLight = #9lc.BoundingBoxData;
			BoundingBoxData #Yvc = #amc.BoundingBoxData;
			return boundingBoxDataLight.#pFb(#Yvc);
		}

		// Token: 0x060040F5 RID: 16629 RVA: 0x001303BC File Offset: 0x0012E5BC
		private unsafe static bool #Jsc(List<Point> #lsc, List<Point> #msc, double #1Mb, double #Hsc)
		{
			void* ptr = stackalloc byte[9];
			*(byte*)(ptr + 8) = 0;
			HashSet<Point> hashSet = new HashSet<Point>(#lsc);
			*(int*)ptr = #lsc.Count - 2;
			while (*(int*)ptr >= 0)
			{
				Point point = #lsc[*(int*)ptr];
				Point point2 = #lsc[*(int*)ptr + 1];
				List<Point> list = new List<Point>();
				*(int*)((byte*)ptr + 4) = 0;
				for (;;)
				{
					if (7 != 0)
					{
						if (*(int*)((byte*)ptr + 4) >= #msc.Count - 1)
						{
							break;
						}
						Point point3 = #msc[*(int*)((byte*)ptr + 4)];
						if (!hashSet.Contains(point3))
						{
							if (GeometryHelper.#lcb(point, point3) < #Hsc)
							{
								point = point3;
								#lsc[*(int*)ptr] = point;
								((byte*)ptr)[8] = 1;
							}
							else if (GeometryHelper.#lcb(point2, point3) < #Hsc)
							{
								point2 = point3;
								#lsc[*(int*)ptr + 1] = point2;
								((byte*)ptr)[8] = 1;
							}
							else
							{
								double? num = #jsc.#lcb(point, point2, point3);
								if (num != null && !double.IsNaN(num.Value) && !double.IsInfinity(num.Value) && num.Value <= #1Mb)
								{
									list.Add(point3);
									((byte*)ptr)[8] = 1;
								}
							}
						}
					}
					*(int*)((byte*)ptr + 4) = *(int*)((byte*)ptr + 4) + 1;
				}
				PolygonsRefineHelper.#Ksc(list, #lsc, point, *(int*)ptr);
				*(int*)ptr = *(int*)ptr - 1;
			}
			return *(sbyte*)((byte*)ptr + 8) != 0;
		}

		// Token: 0x060040F6 RID: 16630 RVA: 0x00130544 File Offset: 0x0012E744
		private static void #Ksc(List<Point> #Lsc, List<Point> #Msc, Point #Hmc, int #4jb)
		{
			PolygonsRefineHelper.#dZb #dZb = new PolygonsRefineHelper.#dZb();
			#dZb.#a = #Hmc;
			#Lsc = #Lsc.Select(new Func<Point, <>f__AnonymousType1<double, Point>>(#dZb.#gyc)).OrderBy(new Func<<>f__AnonymousType1<double, Point>, double>(PolygonsRefineHelper.<>c.<>9.#hyc)).Select(new Func<<>f__AnonymousType1<double, Point>, Point>(PolygonsRefineHelper.<>c.<>9.#iyc)).ToList<Point>();
			#Msc.InsertRange(#4jb + 1, #Lsc);
		}

		// Token: 0x020007E9 RID: 2025
		[CompilerGenerated]
		private sealed class #dZb
		{
			// Token: 0x060040FC RID: 16636 RVA: 0x00036A17 File Offset: 0x00034C17
			internal <>f__AnonymousType1<double, Point> #gyc(Point #Rf)
			{
				return new
				{
					DistanceToA = GeometryHelper.#lcb(this.#a, #Rf),
					Point = #Rf
				};
			}

			// Token: 0x04001D41 RID: 7489
			public Point #a;
		}
	}
}
