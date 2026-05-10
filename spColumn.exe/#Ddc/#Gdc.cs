using System;

namespace #Ddc
{
	// Token: 0x02000706 RID: 1798
	internal static class #Gdc
	{
		// Token: 0x06003B53 RID: 15187 RVA: 0x001174B4 File Offset: 0x001156B4
		public static DateTime #Edc(long A_0)
		{
			return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddSeconds((double)A_0);
		}

		// Token: 0x06003B54 RID: 15188 RVA: 0x001174EC File Offset: 0x001156EC
		public static long #Fdc(this DateTime A_0)
		{
			TimeSpan timeSpan;
			if (true)
			{
				DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
				timeSpan = \u0001.\u0001(A_0, dateTime);
			}
			return \u0002.\u0002(timeSpan.TotalSeconds);
		}
	}
}
