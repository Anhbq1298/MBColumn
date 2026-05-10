using System;
using System.Collections.Generic;
using #2ic;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace #G1h
{
	// Token: 0x0200078C RID: 1932
	internal static class #K1h
	{
		// Token: 0x06003E0F RID: 15887 RVA: 0x0011D124 File Offset: 0x0011B324
		public static IList<Point3D> #H1h(#fjc #J1h, int #Znc)
		{
			List<Point3D> list = new List<Point3D>();
			List<Point3D> list2;
			if (!false)
			{
				list2 = list;
			}
			int num = Math.Max(#Znc, 3);
			if (7 != 0)
			{
				#Znc = num;
			}
			double num2 = Math.Abs(#J1h.StartAngle - #J1h.EndAngle);
			double num3;
			if (!false)
			{
				num3 = num2;
			}
			double num4;
			if (num3 > 0.001)
			{
				num4 = num3;
			}
			else
			{
				if (2 == 0)
				{
					goto IL_17A;
				}
				num4 = 360.0;
			}
			if (!false)
			{
				num3 = num4;
			}
			int num5 = Math.Max((int)((double)#Znc * (num3 / 360.0)), 2);
			int num6;
			if (true)
			{
				num6 = num5;
			}
			int num7 = (#J1h.StartAngle < #J1h.EndAngle) ? 1 : -1;
			int num8;
			if (!false)
			{
				num8 = num7;
			}
			double num9 = #J1h.MajorAxisAngle * 3.141592653589793 / 180.0;
			int num10 = 0;
			goto IL_180;
			IL_17A:
			num10++;
			IL_180:
			if (num10 > num6)
			{
				return list2;
			}
			double num12;
			double num11 = num12 = #J1h.StartAngle;
			double num15;
			double num14;
			double num13 = num14 = (num15 = num3);
			int num17;
			double num16 = (double)(num17 = num10);
			if (7 == 0)
			{
				goto IL_C3;
			}
			num15 = (num14 = num13 * num16 / (double)num6);
			IL_C2:
			num17 = num8;
			IL_C3:
			double num19;
			double num18 = num19 = (double)num17;
			double num22;
			double num24;
			if (!false)
			{
				double num20 = (num12 + num14 * num18) * 3.141592653589793 / 180.0;
				double num21 = num12 = (num11 = (num22 = Math.Round(#J1h.MajorAxisLength * Math.Cos(num20), 10)));
				if (3 == 0)
				{
					goto IL_160;
				}
				double num23 = num14 = (num15 = #J1h.MinorAxisLength);
				if (false)
				{
					goto IL_C2;
				}
				num24 = Math.Round(num23 * Math.Sin(num20), 10);
				num11 = num21;
				num15 = num21 * Math.Cos(num9);
				num19 = num24;
			}
			double x = Math.Round(num15 - num19 * Math.Sin(num9) + #J1h.CenterPoint.X, 10);
			num22 = Math.Round(num11 * Math.Sin(num9) + num24 * Math.Cos(num9) + #J1h.CenterPoint.Y, 10);
			IL_160:
			double y = num22;
			list2.Add(new Point3D(x, y, 0.0));
			goto IL_17A;
		}

		// Token: 0x04001C30 RID: 7216
		private const int #a = 3;
	}
}
