using System;
using System.Collections.Generic;
using System.Linq;
using #7hc;

namespace #yEd
{
	// Token: 0x02000D64 RID: 3428
	internal class #CEd
	{
		// Token: 0x06007C86 RID: 31878 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #BEd()
		{
		}

		// Token: 0x06007C87 RID: 31879 RVA: 0x001B6250 File Offset: 0x001B4450
		protected virtual void #Jed(#AEd #xS)
		{
			if (#xS == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107253735));
			}
			IEnumerator<#xEd> enumerator = #xS.Pages.GetEnumerator();
			try
			{
				while (\u0010\u0002.~\u0019\u0004(enumerator))
				{
					enumerator.Current.#pEd();
				}
			}
			finally
			{
				if (enumerator != null)
				{
					\u0007.~\u000E(enumerator);
				}
			}
			this.#BEd();
			#xEd #xEd = #xS.Pages.FirstOrDefault<#xEd>();
			if (#xEd == null)
			{
				return;
			}
			#xEd.#2cd();
		}
	}
}
