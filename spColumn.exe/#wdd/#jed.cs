using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using #7hc;

namespace #wdd
{
	// Token: 0x02000D17 RID: 3351
	internal abstract class #jed
	{
		// Token: 0x06006E5D RID: 28253 RVA: 0x001A4A00 File Offset: 0x001A2C00
		protected string #ced(string #f)
		{
			if (\u0003.\u0004(#f))
			{
				return #f;
			}
			IEnumerator<KeyValuePair<string, string>> enumerator = this.#ied().GetEnumerator();
			try
			{
				while (\u0010\u0002.~\u0019\u0004(enumerator))
				{
					KeyValuePair<string, string> keyValuePair = enumerator.Current;
					#f = \u0012.~\u0095(#f, keyValuePair.Key, keyValuePair.Value);
				}
			}
			finally
			{
				if (enumerator != null)
				{
					\u0007.~\u000E(enumerator);
				}
			}
			MatchCollection matchCollection = \u0090\u0002.~\u009C\u0005(#jed.#a, #f);
			if (\u008D\u0002.~\u008D\u0005(matchCollection) > 0)
			{
				int num = 0;
				IEnumerator enumerator2 = \u0091\u0002.~\u009D\u0005(matchCollection);
				try
				{
					while (\u0010\u0002.~\u0019\u0004(enumerator2))
					{
						Match match = (Match)\u0092\u0002.~\u009F\u0005(enumerator2);
						int num2 = \u008D\u0002.~\u008E\u0005(match) - num;
						if (num2 > 0)
						{
							this.#qQb(null, \u0018.~\u0001\u0002(#f, num, num2));
						}
						num = \u008D\u0002.~\u008E\u0005(match) + \u008D\u0002.~\u008F\u0005(match);
						string #hed = \u007F.~\u0013\u0002(\u0094\u0002.~\u0005\u0006(\u0093\u0002.~\u0004\u0006(match), #Phc.#3hc(107386484)));
						string #eed = \u007F.~\u0013\u0002(\u0094\u0002.~\u0005\u0006(\u0093\u0002.~\u0004\u0006(match), #Phc.#3hc(107253428)));
						this.#qQb(#eed, #hed);
					}
				}
				finally
				{
					IDisposable disposable = enumerator2 as IDisposable;
					if (disposable != null)
					{
						\u0007.~\u000E(disposable);
					}
				}
				if (num < \u008D\u0002.~\u008C\u0005(#f))
				{
					this.#qQb(null, \u0014.~\u0098(#f, num));
				}
			}
			else
			{
				this.#qQb(null, #f);
			}
			return this.#nrc();
		}

		// Token: 0x06006E5E RID: 28254 RVA: 0x00058D9A File Offset: 0x00056F9A
		protected bool #ded(string #eed)
		{
			return \u0006.\u0008(#eed, #Phc.#3hc(107253391), StringComparison.OrdinalIgnoreCase);
		}

		// Token: 0x06006E5F RID: 28255 RVA: 0x00058DBE File Offset: 0x00056FBE
		protected bool #fed(string #f)
		{
			return \u0006.\u0008(#f, #Phc.#3hc(107253386), StringComparison.OrdinalIgnoreCase) || \u0006.\u0008(#f, #Phc.#3hc(107253381), StringComparison.OrdinalIgnoreCase);
		}

		// Token: 0x06006E60 RID: 28256 RVA: 0x00058DFC File Offset: 0x00056FFC
		protected bool #ged(string #eed)
		{
			return \u0006.\u0008(#eed, #Phc.#3hc(107253376), StringComparison.OrdinalIgnoreCase);
		}

		// Token: 0x06006E61 RID: 28257
		protected abstract void #qQb(string #eed, string #hed);

		// Token: 0x06006E62 RID: 28258
		protected abstract string #nrc();

		// Token: 0x06006E63 RID: 28259 RVA: 0x00058E20 File Offset: 0x00057020
		protected virtual IDictionary<string, string> #ied()
		{
			return new Dictionary<string, string>();
		}

		// Token: 0x04002C62 RID: 11362
		private static readonly Regex #a = new Regex(#Phc.#3hc(107253403), RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);
	}
}
