using System;
using System.Globalization;

namespace #u3d
{
	// Token: 0x02000F00 RID: 3840
	internal static class #C3d
	{
		// Token: 0x06008804 RID: 34820 RVA: 0x001D1C84 File Offset: 0x001CFE84
		internal static char #B3d(IFormatProvider #wx)
		{
			char c2;
			if (!false)
			{
				char c = ',';
				if (!false)
				{
					c2 = c;
				}
			}
			do
			{
				NumberFormatInfo instance = NumberFormatInfo.GetInstance(#wx);
				NumberFormatInfo numberFormatInfo;
				if (3 != 0)
				{
					numberFormatInfo = instance;
				}
				int num2;
				int num = num2 = numberFormatInfo.NumberDecimalSeparator.Length;
				int num4;
				int num3 = num4 = 0;
				if (num3 == 0)
				{
					if (num <= num3)
					{
						return c2;
					}
					num2 = (int)c2;
					num4 = (int)numberFormatInfo.NumberDecimalSeparator[0];
				}
				if (num2 != num4)
				{
					return c2;
				}
			}
			while (false);
			char c3 = ';';
			if (-1 != 0)
			{
				c2 = c3;
			}
			return c2;
		}
	}
}
