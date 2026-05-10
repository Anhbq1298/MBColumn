using System;
using StructurePoint.CoreAssets.Localizer;

namespace #lzb
{
	// Token: 0x020004DD RID: 1245
	internal sealed class #ozb
	{
		// Token: 0x06002DE4 RID: 11748 RVA: 0x000EF208 File Offset: 0x000ED408
		public static bool #mzb(double #f, int #8W, out string #nzb)
		{
			bool flag = Math.Abs(#f) < Math.Pow(10.0, (double)(-(double)#8W));
			#nzb = (flag ? Strings.StringDimensionIsTooSmall : null);
			return flag;
		}
	}
}
