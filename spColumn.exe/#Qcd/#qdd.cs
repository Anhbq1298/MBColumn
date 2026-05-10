using System;
using System.Text.RegularExpressions;
using #5Fd;
using #7hc;

namespace #Qcd
{
	// Token: 0x02000D0B RID: 3339
	internal static class #qdd
	{
		// Token: 0x06006E25 RID: 28197 RVA: 0x001A4274 File Offset: 0x001A2474
		public static string #ndd(#7Fd #odd, string #pdd)
		{
			if (#odd == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107254045));
			}
			if (\u0003.\u0004(#pdd))
			{
				return #pdd;
			}
			#pdd = #odd.#NBd(#pdd);
			return \u007F.~\u0012\u0002(\u008A\u0002.\u0088\u0005(#pdd, #Phc.#3hc(107253484), string.Empty, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant));
		}
	}
}
