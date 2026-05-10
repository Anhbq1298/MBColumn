using System;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.Units;

namespace #xKe
{
	// Token: 0x0200126B RID: 4715
	internal static class #4ai
	{
		// Token: 0x06009E4B RID: 40523 RVA: 0x00219240 File Offset: 0x00217440
		public static int #2ai(UnitSystem #Qg, double #HS, int #LWi = 40)
		{
			if (#LWi <= 0)
			{
				#LWi = 40;
			}
			double num = (#Qg == UnitSystem.SIMetric) ? 5.0 : 0.2;
			double num2 = GeometryHelper.#Pmc(2.0 * Math.Acos((#HS - num) / #HS));
			int val = (int)Math.Ceiling(360.0 / num2);
			return Math.Max(#LWi, val);
		}

		// Token: 0x06009E4C RID: 40524 RVA: 0x002192A4 File Offset: 0x002174A4
		public static int #3ai(UnitSystem #Qg, double #HS, int #LWi = 40)
		{
			int num = #4ai.#2ai(#Qg, #HS, #LWi);
			if (num % 4 != 0)
			{
				num = num / 4 * 4 + 4;
			}
			return num;
		}

		// Token: 0x04004469 RID: 17513
		private const int #a = 40;
	}
}
