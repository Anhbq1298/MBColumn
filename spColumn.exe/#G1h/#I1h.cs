using System;
using System.Collections.Generic;
using #2ic;
using StructurePoint.CoreAssets.DataExchange.ExternFormat;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace #G1h
{
	// Token: 0x0200078B RID: 1931
	internal static class #I1h
	{
		// Token: 0x06003E0E RID: 15886 RVA: 0x0011D040 File Offset: 0x0011B240
		public static List<Point3D> #H1h(#tjc #uAc, int #Znc)
		{
			double num = #uAc.Radius;
			double num2;
			if (8 != 0)
			{
				num2 = num;
			}
			IPoint point = #uAc.CenterPoint;
			IPoint point2;
			if (6 != 0)
			{
				point2 = point;
			}
			List<Point3D> list = new List<Point3D>();
			List<Point3D> list2;
			if (!false)
			{
				list2 = list;
			}
			int num5;
			if (!false)
			{
				int num3 = Math.Max(#Znc, 3);
				if (!false)
				{
					#Znc = num3;
				}
				int num4 = 0;
				if (7 != 0)
				{
					num5 = num4;
				}
				goto IL_AB;
			}
			IL_73:
			double num6 = num2;
			double num7;
			double a = num7;
			IL_76:
			double value = num6 * Math.Sin(a) + point2.Y;
			int digits = 10;
			IL_85:
			double y = Math.Round(value, digits);
			double x;
			list2.Add(new Point3D(x, y, 0.0));
			int num9;
			int num8 = num9 = num5;
			int num11;
			int num10 = num11 = 1;
			if (num10 == 0)
			{
				goto IL_AD;
			}
			num5 = num8 + num10;
			IL_AB:
			num9 = num5;
			num11 = #Znc;
			IL_AD:
			if (num9 > num11)
			{
				return list2;
			}
			double num12 = value = 6.283185307179586;
			double num13 = (double)(digits = num5);
			if (false)
			{
				goto IL_85;
			}
			double num14 = num12 * num13 / (double)#Znc;
			if (!false)
			{
				num7 = num14;
			}
			double num15 = num6 = num2 * Math.Cos(num7);
			double num16 = a = point2.X;
			if (2 != 0)
			{
				x = Math.Round(num15 + num16, 10);
				goto IL_73;
			}
			goto IL_76;
		}

		// Token: 0x04001C2F RID: 7215
		public const int #a = 3;
	}
}
