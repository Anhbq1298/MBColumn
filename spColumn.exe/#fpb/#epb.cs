using System;
using StructurePoint.CoreAssets.Units;

namespace #fpb
{
	// Token: 0x02000456 RID: 1110
	internal static class #epb
	{
		// Token: 0x060028CD RID: 10445 RVA: 0x000DC844 File Offset: 0x000DAA44
		public static bool #bpb(double #cpb, double #Tdb, UnitSystem #Qg, out double #dpb)
		{
			if (Math.Abs(#Tdb) < 1E-05)
			{
				#dpb = double.NaN;
				return false;
			}
			int num = (#Qg == UnitSystem.USCustomary) ? 12 : 1000;
			#dpb = #cpb * (double)num / #Tdb;
			return true;
		}

		// Token: 0x04001033 RID: 4147
		private const double #a = 1E-05;
	}
}
