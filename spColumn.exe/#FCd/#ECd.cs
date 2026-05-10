using System;
using #7hc;
using Aspose.Words;

namespace #FCd
{
	// Token: 0x02000D5A RID: 3418
	internal static class #ECd
	{
		// Token: 0x06007C3C RID: 31804 RVA: 0x001B5A14 File Offset: 0x001B3C14
		public static void #CCd(this Border #DCd, double #f)
		{
			if (#DCd == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107251254));
			}
			if (#f > 0.0)
			{
				\u009F\u0002.~\u001A\u0006(#DCd, #f);
				return;
			}
			\u0099\u0003.~\u0014\u0008(#DCd, LineStyle.None);
		}
	}
}
