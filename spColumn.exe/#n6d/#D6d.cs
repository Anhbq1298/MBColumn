using System;
using #7hc;

namespace #n6d
{
	// Token: 0x02000F3A RID: 3898
	internal static class #D6d
	{
		// Token: 0x06008A0E RID: 35342 RVA: 0x001D6B58 File Offset: 0x001D4D58
		internal static long #C6d(double #f)
		{
			if (#f >= 2958466.0 || #f <= -657435.0)
			{
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107386484));
			}
			long num = (long)(#f * 86400000.0 + ((#f >= 0.0) ? 0.5 : -0.5));
			if (num < 0L)
			{
				num -= num % 86400000L * 2L;
			}
			num += 59926435200000L;
			if (num < 0L || num >= 315537897600000L)
			{
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107386484));
			}
			return num * 10000L;
		}

		// Token: 0x040038C1 RID: 14529
		private const long #a = 10000L;

		// Token: 0x040038C2 RID: 14530
		private const long #b = 10000000L;

		// Token: 0x040038C3 RID: 14531
		private const long #c = 600000000L;

		// Token: 0x040038C4 RID: 14532
		private const long #d = 36000000000L;

		// Token: 0x040038C5 RID: 14533
		private const long #e = 864000000000L;

		// Token: 0x040038C6 RID: 14534
		private const int #f = 1000;

		// Token: 0x040038C7 RID: 14535
		private const int #g = 60000;

		// Token: 0x040038C8 RID: 14536
		private const int #h = 3600000;

		// Token: 0x040038C9 RID: 14537
		private const int #i = 86400000;

		// Token: 0x040038CA RID: 14538
		private const int #j = 365;

		// Token: 0x040038CB RID: 14539
		private const int #k = 1461;

		// Token: 0x040038CC RID: 14540
		private const int #l = 36524;

		// Token: 0x040038CD RID: 14541
		private const int #m = 146097;

		// Token: 0x040038CE RID: 14542
		private const double #n = -657435.0;

		// Token: 0x040038CF RID: 14543
		private const double #o = 2958466.0;

		// Token: 0x040038D0 RID: 14544
		private const long #p = 599264352000000000L;

		// Token: 0x040038D1 RID: 14545
		private const int #q = 693593;

		// Token: 0x040038D2 RID: 14546
		private const int #r = 3652059;

		// Token: 0x040038D3 RID: 14547
		private const long #s = 315537897600000L;
	}
}
