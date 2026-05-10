using System;
using StructurePoint.CoreAssets.Geometry.Helpers;

namespace #Fmc
{
	// Token: 0x020007B6 RID: 1974
	internal static class #Emc
	{
		// Token: 0x06003F51 RID: 16209 RVA: 0x00035A9A File Offset: 0x00033C9A
		public static double #xmc(double #f)
		{
			return \u0012\u0002.\u008C\u0004(#f, #Emc.#b);
		}

		// Token: 0x06003F52 RID: 16210 RVA: 0x00035AB4 File Offset: 0x00033CB4
		public static double #ymc(double #f)
		{
			return \u0012\u0002.\u008C\u0004(#f, #Emc.#a);
		}

		// Token: 0x06003F53 RID: 16211 RVA: 0x00035ACE File Offset: 0x00033CCE
		public static bool #zmc(double #4gb, double #5gb)
		{
			return \u0006\u0002.\u0006\u0004(#4gb - #5gb) <= #Emc.#c;
		}

		// Token: 0x06003F54 RID: 16212 RVA: 0x00035AF3 File Offset: 0x00033CF3
		public static bool #Amc(double #4gb, double #5gb)
		{
			return \u0006\u0002.\u0006\u0004(#4gb - #5gb) <= #Emc.#d;
		}

		// Token: 0x06003F55 RID: 16213 RVA: 0x00035B18 File Offset: 0x00033D18
		public static bool #U3(double #f)
		{
			return \u0006\u0002.\u0006\u0004(#f) < PointsConverter.#b;
		}

		// Token: 0x06003F56 RID: 16214 RVA: 0x00035B34 File Offset: 0x00033D34
		public static bool #Bmc(double #f)
		{
			return \u0006\u0002.\u0006\u0004(#f) < #Emc.#d;
		}

		// Token: 0x06003F57 RID: 16215 RVA: 0x00124FD8 File Offset: 0x001231D8
		public static bool #Cmc(double #Udb)
		{
			int result;
			if (4 != 0)
			{
				double num;
				double #4gb = num = \u0006\u0002.\u0006\u0004(#Udb);
				do
				{
					if (6 != 0)
					{
						#Udb = num;
						bool flag = (result = (#Emc.#Amc(#Udb, 90.0) ? 1 : 0)) != 0;
						if (false)
						{
							return result != 0;
						}
						if (flag)
						{
							goto IL_34;
						}
						#4gb = (num = #Udb);
					}
				}
				while (3 == 0);
				return #Emc.#Amc(#4gb, 270.0);
			}
			IL_34:
			result = 1;
			return result != 0;
		}

		// Token: 0x06003F58 RID: 16216 RVA: 0x0012503C File Offset: 0x0012323C
		public static bool #Dmc(double #Udb)
		{
			int result;
			if (4 != 0)
			{
				double num;
				double #4gb = num = \u0006\u0002.\u0006\u0004(#Udb);
				do
				{
					if (6 != 0)
					{
						#Udb = num;
						bool flag = (result = (#Emc.#Amc(#Udb, 0.0) ? 1 : 0)) != 0;
						if (false)
						{
							return result != 0;
						}
						if (flag)
						{
							goto IL_34;
						}
						#4gb = (num = #Udb);
					}
				}
				while (3 == 0);
				return #Emc.#Amc(#4gb, 180.0);
			}
			IL_34:
			result = 1;
			return result != 0;
		}

		// Token: 0x06003F59 RID: 16217 RVA: 0x001250A0 File Offset: 0x001232A0
		// Note: this type is marked as 'beforefieldinit'.
		static #Emc()
		{
			if (!true)
			{
				goto IL_2B;
			}
			#Emc.#a = 7;
			IL_09:
			#Emc.#b = 5;
			#Emc.#c = \u0011\u0002.\u0088\u0004(10.0, (double)(-(double)#Emc.#a));
			IL_2B:
			#Emc.#d = \u0011\u0002.\u0088\u0004(10.0, (double)(-(double)#Emc.#b));
			if (!false)
			{
				return;
			}
			goto IL_09;
		}

		// Token: 0x04001CC2 RID: 7362
		public static readonly int #a;

		// Token: 0x04001CC3 RID: 7363
		public static readonly int #b;

		// Token: 0x04001CC4 RID: 7364
		public static readonly double #c;

		// Token: 0x04001CC5 RID: 7365
		public static readonly double #d;
	}
}
