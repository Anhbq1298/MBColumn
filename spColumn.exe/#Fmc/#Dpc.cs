using System;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #Fmc
{
	// Token: 0x020007CE RID: 1998
	internal static class #Dpc
	{
		// Token: 0x06004005 RID: 16389 RVA: 0x0012AA04 File Offset: 0x00128C04
		public unsafe static SegmentData #xpc(Point3D #ypc, BoundingBoxData #smc)
		{
			void* ptr = stackalloc byte[16];
			#X0d.#V0d(#smc, #Phc.#3hc(107369578), Component.Geometry, #Phc.#3hc(107367868));
			*(double*)ptr = \u0011\u0002.\u008B\u0004(#smc.Width, #smc.Height);
			\u0011\u0002 u008A_u = \u0011\u0002.\u008A\u0004;
			double num = #smc.MinX - *(double*)ptr;
			*(double*)((byte*)ptr + 8) = #smc.MaxX + *(double*)ptr;
			double xField = u008A_u(num, #ypc.X - 100.0);
			*(double*)((byte*)ptr + 8) = \u0011\u0002.\u008B\u0004(*(double*)((byte*)ptr + 8), #ypc.X + 100.0);
			return new SegmentData(new Point(xField, #ypc.Y), new Point(*(double*)((byte*)ptr + 8), #ypc.Y));
		}

		// Token: 0x06004006 RID: 16390 RVA: 0x0012AB1C File Offset: 0x00128D1C
		public unsafe static SegmentData #zpc(Point3D #ypc, BoundingBoxData #smc)
		{
			void* ptr = stackalloc byte[24];
			#X0d.#V0d(#smc, #Phc.#3hc(107369578), Component.Geometry, #Phc.#3hc(107367783));
			*(double*)ptr = \u0011\u0002.\u008B\u0004(#smc.Width, #smc.Height);
			*(double*)((byte*)ptr + 8) = #smc.MinY - *(double*)ptr;
			*(double*)((byte*)ptr + 16) = #smc.MaxY + *(double*)ptr;
			*(double*)((byte*)ptr + 8) = \u0011\u0002.\u008A\u0004(*(double*)((byte*)ptr + 8), #ypc.Y - 100.0);
			*(double*)((byte*)ptr + 16) = \u0011\u0002.\u008B\u0004(*(double*)((byte*)ptr + 16), #ypc.Y + 100.0);
			return new SegmentData(new Point(#ypc.X, *(double*)((byte*)ptr + 8)), new Point(#ypc.X, *(double*)((byte*)ptr + 16)));
		}

		// Token: 0x06004007 RID: 16391 RVA: 0x0012AC48 File Offset: 0x00128E48
		public unsafe static double #Apc(SegmentData #Bpc, SegmentData #Cpc)
		{
			void* ptr;
			while (2 != 0)
			{
				ptr = stackalloc byte[16];
				double num;
				if (!false)
				{
					#X0d.#V0d(#Bpc, #Phc.#3hc(107367762), Component.Geometry, #Phc.#3hc(107367733));
					if (-1 == 0)
					{
						continue;
					}
					#X0d.#V0d(#Cpc, #Phc.#3hc(107367136), Component.Geometry, #Phc.#3hc(107367111));
					if (!false)
					{
						*(double*)ptr = GeometryHelper.#lcb(#Bpc.StartPoint, #Bpc.EndPoint);
						*(double*)((byte*)ptr + 8) = GeometryHelper.#lcb(#Cpc.StartPoint, #Cpc.EndPoint);
						break;
					}
					IL_87:
					num = *(double*)((byte*)ptr + 8);
				}
				else
				{
					IL_8D:
					num = *(double*)ptr;
				}
				return num / 2.0;
			}
			if (*(double*)ptr <= *(double*)((byte*)ptr + 8))
			{
				goto IL_87;
			}
			goto IL_8D;
		}

		// Token: 0x04001CFE RID: 7422
		private const double #a = 100.0;
	}
}
