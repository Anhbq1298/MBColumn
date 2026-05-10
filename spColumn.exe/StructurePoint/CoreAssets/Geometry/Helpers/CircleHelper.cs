using System;
using System.Collections.Generic;
using System.Linq;
using #7hc;
using #cYd;
using #Fmc;
using #UYd;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.Geometry.Helpers
{
	// Token: 0x020007B4 RID: 1972
	public static class CircleHelper
	{
		// Token: 0x06003F47 RID: 16199 RVA: 0x0012493C File Offset: 0x00122B3C
		public unsafe static CircleData #pmc(Point #mcb, Point #ncb, Point #Ckc)
		{
			void* ptr = stackalloc byte[64];
			*(double*)ptr = \u0011\u0002.\u0088\u0004(#ncb.X, 2.0) + \u0011\u0002.\u0088\u0004(#ncb.Y, 2.0);
			*(double*)(ptr + 8) = (\u0011\u0002.\u0088\u0004(#mcb.X, 2.0) + \u0011\u0002.\u0088\u0004(#mcb.Y, 2.0) - *(double*)ptr) / 2.0;
			*(double*)((byte*)ptr + 16) = (*(double*)ptr - \u0011\u0002.\u0088\u0004(#Ckc.X, 2.0) - \u0011\u0002.\u0088\u0004(#Ckc.Y, 2.0)) / 2.0;
			*(double*)((byte*)ptr + 24) = (#mcb.X - #ncb.X) * (#ncb.Y - #Ckc.Y) - (#ncb.X - #Ckc.X) * (#mcb.Y - #ncb.Y);
			if (#Emc.#U3(*(double*)((byte*)ptr + 24)))
			{
				return null;
			}
			*(double*)((byte*)ptr + 32) = 1.0 / *(double*)((byte*)ptr + 24);
			*(double*)((byte*)ptr + 40) = (*(double*)((byte*)ptr + 8) * (#ncb.Y - #Ckc.Y) - *(double*)((byte*)ptr + 16) * (#mcb.Y - #ncb.Y)) * *(double*)((byte*)ptr + 32);
			*(double*)((byte*)ptr + 48) = (*(double*)((byte*)ptr + 16) * (#mcb.X - #ncb.X) - *(double*)((byte*)ptr + 8) * (#ncb.X - #Ckc.X)) * *(double*)((byte*)ptr + 32);
			*(double*)((byte*)ptr + 56) = \u0006\u0002.\u0007\u0004(\u0011\u0002.\u0088\u0004(#ncb.X - *(double*)((byte*)ptr + 40), 2.0) + \u0011\u0002.\u0088\u0004(#ncb.Y - *(double*)((byte*)ptr + 48), 2.0));
			return new CircleData(new Point(*(double*)((byte*)ptr + 40), *(double*)((byte*)ptr + 48)), *(double*)((byte*)ptr + 56));
		}

		// Token: 0x06003F48 RID: 16200 RVA: 0x00124BA8 File Offset: 0x00122DA8
		public static bool #qmc(#ivc #rmc, Point #wob, Point #Ng, BoundingBoxDataLight #smc)
		{
			double num = GeometryHelper.#lcb(#wob, #Ng);
			double num4;
			double num5;
			if (5 != 0)
			{
				double num3;
				double num2 = num3 = num;
				if (true)
				{
					if (num2 <= PointsConverter.#b)
					{
						if (-1 != 0)
						{
							return false;
						}
					}
					else if (#rmc == #ivc.#a)
					{
						num3 = num;
						goto IL_42;
					}
					num3 = 0.0;
				}
				IL_42:
				num4 = num3;
				num5 = ((#rmc == #ivc.#b) ? num : 0.0);
			}
			do
			{
				Point #doc = new Point(#wob.X - num4, #wob.Y - num5);
				Point #doc2;
				do
				{
					#doc2 = new Point(#wob.X + num4, #wob.Y + num5);
				}
				while (4 == 0);
				int num6 = GeometryHelper.#coc(#smc, #doc) ? 1 : 0;
				while (num6 != 0 && GeometryHelper.#coc(#smc, #doc2))
				{
					int num7 = num6 = 1;
					if (num7 != 0)
					{
						return num7 != 0;
					}
				}
			}
			while (-1 == 0);
			return false;
		}

		// Token: 0x06003F49 RID: 16201 RVA: 0x00035A6B File Offset: 0x00033C6B
		public static bool #qmc(Point #wob, Point #Ng)
		{
			return GeometryHelper.#lcb(#wob, #Ng) > PointsConverter.#b;
		}

		// Token: 0x06003F4A RID: 16202 RVA: 0x00124C9C File Offset: 0x00122E9C
		public unsafe static bool #tmc(IEnumerable<Point> #umc)
		{
			void* ptr = stackalloc byte[28];
			#X0d.#V0d(#umc, #Phc.#3hc(107370389), Component.Geometry, #Phc.#3hc(107370340));
			Point[] array;
			if ((array = (#umc as Point[])) == null)
			{
				array = #umc.ToArray<Point>();
			}
			Point[] array2 = array;
			if (array2.Count<Point>() < 3)
			{
				return false;
			}
			Point #Xrb = array2.OrderBy(new Func<Point, double>(CircleHelper.<>c.<>9.#pxc)).First<Point>();
			Point #Yrb = array2.OrderBy(new Func<Point, double>(CircleHelper.<>c.<>9.#qxc)).Last<Point>();
			Point #mcb = #jsc.#hsc(#Xrb, #Yrb);
			*(double*)ptr = 0.0;
			*(double*)((byte*)ptr + 8) = 0.0;
			Point[] array3 = array2;
			*(int*)((byte*)ptr + 24) = 0;
			while (*(int*)((byte*)ptr + 24) < array3.Length)
			{
				Point #ncb = array3[*(int*)((byte*)ptr + 24)];
				*(double*)((byte*)ptr + 16) = Math.Abs(GeometryHelper.#lcb(#mcb, #ncb));
				*(double*)ptr = *(double*)ptr + *(double*)((byte*)ptr + 16);
				if (*(double*)((byte*)ptr + 8) < *(double*)((byte*)ptr + 16))
				{
					*(double*)((byte*)ptr + 8) = *(double*)((byte*)ptr + 16);
				}
				*(int*)((byte*)ptr + 24) = *(int*)((byte*)ptr + 24) + 1;
			}
			*(double*)ptr = *(double*)ptr / (double)array2.Count<Point>();
			return Math.Abs(*(double*)((byte*)ptr + 8) - *(double*)ptr) < *(double*)ptr * 0.03;
		}

		// Token: 0x06003F4B RID: 16203 RVA: 0x00124E40 File Offset: 0x00123040
		public unsafe static CircleData #vmc(IReadOnlyList<Point> #BP)
		{
			void* ptr = stackalloc byte[24];
			#X0d.#V0d(#BP, #Phc.#3hc(107358670), Component.Geometry, #Phc.#3hc(107370287));
			if (#BP.Count < 3)
			{
				return null;
			}
			*(double*)ptr = 0.0;
			*(double*)(ptr + 8) = 0.0;
			*(int*)((byte*)ptr + 16) = #BP.Count - 1;
			*(int*)((byte*)ptr + 20) = 0;
			while (*(int*)((byte*)ptr + 20) < *(int*)((byte*)ptr + 16))
			{
				Point point = #BP[*(int*)((byte*)ptr + 20)];
				*(double*)ptr = *(double*)ptr + point.X;
				*(double*)((byte*)ptr + 8) = *(double*)((byte*)ptr + 8) + point.Y;
				*(int*)((byte*)ptr + 20) = *(int*)((byte*)ptr + 20) + 1;
			}
			Point point2 = new Point(*(double*)ptr / (double)(*(int*)((byte*)ptr + 16)), *(double*)((byte*)ptr + 8) / (double)(*(int*)((byte*)ptr + 16)));
			return new CircleData(point2, GeometryHelper.#lcb(point2, #BP[0]));
		}

		// Token: 0x06003F4C RID: 16204 RVA: 0x00124F6C File Offset: 0x0012316C
		public static double #wmc(double #wCb)
		{
			for (;;)
			{
				IL_00:
				double num = #wCb;
				while (num > 0.0)
				{
					if (3 == 0)
					{
						goto IL_00;
					}
					double result = num = \u0006\u0002.\u0007\u0004(#wCb / 3.141592653589793);
					if (7 != 0)
					{
						return result;
					}
				}
				break;
			}
			throw new #jYd(#Phc.#3hc(107370266), #Phc.#3hc(107370257), Component.Geometry, #IYd.#c);
		}

		// Token: 0x04001CBE RID: 7358
		private const double #a = 0.03;
	}
}
