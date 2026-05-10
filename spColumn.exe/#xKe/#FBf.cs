using System;
using #9pe;

namespace #xKe
{
	// Token: 0x0200127F RID: 4735
	internal static class #FBf
	{
		// Token: 0x06009EBF RID: 40639 RVA: 0x0021AA7C File Offset: 0x00218C7C
		public static bool #EBf(this #mqe #tEb)
		{
			return #tEb != null && (!double.IsNaN((double)#tEb.X) && !double.IsNaN((double)#tEb.Y) && !double.IsInfinity((double)#tEb.X)) && !double.IsInfinity((double)#tEb.Y);
		}
	}
}
