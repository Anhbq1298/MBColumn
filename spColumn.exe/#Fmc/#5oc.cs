using System;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace #Fmc
{
	// Token: 0x020007C7 RID: 1991
	internal static class #5oc
	{
		// Token: 0x06003FDF RID: 16351 RVA: 0x00129C58 File Offset: 0x00127E58
		public static Size #1oc(Size #2oc, Size #3oc)
		{
			double num5;
			double widthField;
			double num6;
			for (;;)
			{
				double num = #3oc.Width;
				double num2 = #2oc.Width;
				for (;;)
				{
					double num3;
					double num4;
					if (num <= num2 && #3oc.Height <= #2oc.Height)
					{
						if (!false)
						{
							num3 = #3oc.Width;
							num4 = #2oc.Width;
							goto IL_31;
						}
						break;
					}
					do
					{
						IL_43:
						num5 = \u0011\u0002.\u008A\u0004(#2oc.Width / #3oc.Width, #2oc.Height / #3oc.Height);
					}
					while (5 == 0);
					widthField = (num = (num3 = #3oc.Width * num5));
					num6 = (num2 = (num4 = #3oc.Height));
					if (false)
					{
						continue;
					}
					if (5 != 0 && !false)
					{
						goto Block_7;
					}
					IL_31:
					if (num3 < num4 && #3oc.Height < #2oc.Height)
					{
						goto IL_43;
					}
					return #3oc;
				}
			}
			Block_7:
			return new Size(widthField, num6 * num5);
		}

		// Token: 0x06003FE0 RID: 16352 RVA: 0x00129D54 File Offset: 0x00127F54
		public static Size #4oc(Size #2oc, Size #3oc)
		{
			if (#3oc.Height > #2oc.Height || #3oc.Width > #2oc.Width)
			{
				return #5oc.#1oc(#2oc, #3oc);
			}
			return #3oc;
		}
	}
}
