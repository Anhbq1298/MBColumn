using System;
using #7hc;
using #z5e;

namespace #X7e
{
	// Token: 0x02001397 RID: 5015
	internal static class #28e
	{
		// Token: 0x0600A84E RID: 43086 RVA: 0x0008277B File Offset: 0x0008097B
		public static #38e #18e(#N5e #is)
		{
			if (#is.IsCodeAci08Plus)
			{
				return new #W7e(#is);
			}
			if (#is.IsCodeAci)
			{
				return new #W8e(#is);
			}
			if (#is.IsCodeCsa)
			{
				return new #08e(#is);
			}
			throw new ArgumentException(#Phc.#3hc(107309667));
		}
	}
}
