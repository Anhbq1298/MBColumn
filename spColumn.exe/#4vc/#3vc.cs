using System;
using System.Collections.Generic;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #4vc
{
	// Token: 0x0200080E RID: 2062
	internal sealed class #3vc
	{
		// Token: 0x0600423C RID: 16956 RVA: 0x00135CC8 File Offset: 0x00133EC8
		public #3vc(Point #Suc, Point #Mzb, double #Udb)
		{
			this.#a = new Point((#Suc.X + #Mzb.X) * 0.5, (#Suc.Y + #Mzb.Y) * 0.5);
			double num = GeometryHelper.#Qmc(#Udb);
			double num2 = Math.Cos(num);
			double num3 = Math.Sin(num);
			double num4 = Math.Abs(#Mzb.X - #Suc.Y) * 0.5;
			double num5 = Math.Abs(#Mzb.Y - #Suc.Y) * 0.5;
			double num6;
			double num7;
			if (num4 >= num5)
			{
				num6 = num4;
				num7 = num5;
			}
			else
			{
				num6 = num5;
				num7 = num4;
			}
			this.#b = #3vc.#1vc(num2 / num6) + #3vc.#1vc(num3 / num7);
			this.#c = 2.0 * num3 * num2 * (1.0 / #3vc.#1vc(num6) - 1.0 / #3vc.#1vc(num7));
			this.#d = #3vc.#1vc(num3 / num6) + #3vc.#1vc(num2 / num7);
		}

		// Token: 0x0600423D RID: 16957 RVA: 0x00135DE4 File Offset: 0x00133FE4
		public unsafe IList<Point> #plc(SegmentData #PP)
		{
			void* ptr = stackalloc byte[112];
			#X0d.#V0d(#PP, #Phc.#3hc(107368915), Component.Geometry, #Phc.#3hc(107458068));
			List<Point> list = new List<Point>();
			*(double*)ptr = this.#a.X;
			Point point = this.#a;
			*(double*)((byte*)ptr + 8) = point.Y;
			point = #PP.StartPoint;
			*(double*)((byte*)ptr + 16) = point.X;
			point = #PP.StartPoint;
			*(double*)((byte*)ptr + 24) = point.Y;
			point = #PP.EndPoint;
			ref double ptr2 = ref *(double*)((byte*)ptr + 40);
			double num = point.X;
			point = #PP.EndPoint;
			*(double*)((byte*)ptr + 32) = point.Y;
			ptr2 = num - *(double*)((byte*)ptr + 16);
			*(double*)((byte*)ptr + 48) = *(double*)((byte*)ptr + 32) - *(double*)((byte*)ptr + 24);
			*(double*)((byte*)ptr + 56) = this.#b * #3vc.#1vc(*(double*)((byte*)ptr + 16) - *(double*)ptr) + this.#c * (*(double*)((byte*)ptr + 16) - *(double*)ptr) * (*(double*)((byte*)ptr + 24) - *(double*)((byte*)ptr + 8)) + this.#d * #3vc.#1vc(*(double*)((byte*)ptr + 24) - *(double*)((byte*)ptr + 8)) - 1.0;
			*(double*)((byte*)ptr + 64) = 2.0 * this.#b * *(double*)((byte*)ptr + 40) * (*(double*)((byte*)ptr + 16) - *(double*)ptr) + this.#c * *(double*)((byte*)ptr + 40) * (*(double*)((byte*)ptr + 24) - *(double*)((byte*)ptr + 8)) + this.#c * *(double*)((byte*)ptr + 48) * (*(double*)((byte*)ptr + 16) - *(double*)ptr) + 2.0 * this.#d * *(double*)((byte*)ptr + 48) * (*(double*)((byte*)ptr + 24) - *(double*)((byte*)ptr + 8));
			*(double*)((byte*)ptr + 72) = this.#b * #3vc.#1vc(*(double*)((byte*)ptr + 40)) + this.#c * *(double*)((byte*)ptr + 40) * *(double*)((byte*)ptr + 48) + this.#d * #3vc.#1vc(*(double*)((byte*)ptr + 48));
			*(double*)((byte*)ptr + 80) = #3vc.#1vc(*(double*)((byte*)ptr + 64)) - 4.0 * *(double*)((byte*)ptr + 56) * *(double*)((byte*)ptr + 72);
			if (*(double*)((byte*)ptr + 80) < 0.0)
			{
				return list;
			}
			if (*(double*)((byte*)ptr + 80) != 0.0)
			{
				*(double*)((byte*)ptr + 96) = Math.Sqrt(*(double*)((byte*)ptr + 80));
				*(double*)((byte*)ptr + 104) = (-(*(double*)((byte*)ptr + 64)) - *(double*)((byte*)ptr + 96)) / (2.0 * *(double*)((byte*)ptr + 72));
				if (0.0 <= *(double*)((byte*)ptr + 104) && *(double*)((byte*)ptr + 104) <= 1.0)
				{
					list.Add(new Point(*(double*)((byte*)ptr + 16) + *(double*)((byte*)ptr + 104) * *(double*)((byte*)ptr + 40), *(double*)((byte*)ptr + 24) + *(double*)((byte*)ptr + 104) * *(double*)((byte*)ptr + 48)));
				}
				*(double*)((byte*)ptr + 104) = (-(*(double*)((byte*)ptr + 64)) + *(double*)((byte*)ptr + 96)) / (2.0 * *(double*)((byte*)ptr + 72));
				if (0.0 <= *(double*)((byte*)ptr + 104) && *(double*)((byte*)ptr + 104) <= 1.0)
				{
					list.Add(new Point(*(double*)((byte*)ptr + 16) + *(double*)((byte*)ptr + 104) * *(double*)((byte*)ptr + 40), *(double*)((byte*)ptr + 24) + *(double*)((byte*)ptr + 104) * *(double*)((byte*)ptr + 48)));
				}
				return list;
			}
			*(double*)((byte*)ptr + 88) = -(*(double*)((byte*)ptr + 64)) / (2.0 * *(double*)((byte*)ptr + 72));
			if (0.0 <= *(double*)((byte*)ptr + 88) && *(double*)((byte*)ptr + 88) <= 1.0)
			{
				list.Add(new Point(*(double*)((byte*)ptr + 16) + *(double*)((byte*)ptr + 88) * *(double*)((byte*)ptr + 40), *(double*)((byte*)ptr + 24) + *(double*)((byte*)ptr + 88) * *(double*)((byte*)ptr + 48)));
				return list;
			}
			return list;
		}

		// Token: 0x0600423E RID: 16958 RVA: 0x00037A39 File Offset: 0x00035C39
		private static double #1vc(double #2vc)
		{
			return #2vc * #2vc;
		}

		// Token: 0x04001DDF RID: 7647
		private readonly Point #a;

		// Token: 0x04001DE0 RID: 7648
		private readonly double #b;

		// Token: 0x04001DE1 RID: 7649
		private readonly double #c;

		// Token: 0x04001DE2 RID: 7650
		private readonly double #d;
	}
}
