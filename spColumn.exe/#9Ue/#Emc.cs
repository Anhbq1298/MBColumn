using System;

namespace #9Ue
{
	// Token: 0x020012EC RID: 4844
	internal static class #Emc
	{
		// Token: 0x0600A1D8 RID: 41432 RVA: 0x00228DEC File Offset: 0x00226FEC
		public static bool #Bjb(double? #4gb, double? #5gb)
		{
			return (#4gb == null && #5gb == null) || (#4gb != null && #5gb != null && Math.Abs(#4gb.Value - #5gb.Value) < 0.1);
		}

		// Token: 0x0600A1D9 RID: 41433 RVA: 0x0007EC58 File Offset: 0x0007CE58
		public static double #pVe(double #f)
		{
			return Math.Round(#f);
		}

		// Token: 0x0600A1DA RID: 41434 RVA: 0x0007EC58 File Offset: 0x0007CE58
		public static double #qVe(double #f)
		{
			return Math.Round(#f);
		}
	}
}
