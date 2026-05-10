using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using #7hc;
using #wdd;

namespace #jCd
{
	// Token: 0x02000D56 RID: 3414
	internal sealed class #mCd : #jed
	{
		// Token: 0x06007C2B RID: 31787 RVA: 0x00064CF2 File Offset: 0x00062EF2
		protected internal IDictionary<string, string> #lCd()
		{
			return #mCd.#b;
		}

		// Token: 0x06007C2C RID: 31788 RVA: 0x001B54C8 File Offset: 0x001B36C8
		public string #NBd(string #f)
		{
			if (\u0003.\u0004(#f))
			{
				return #f;
			}
			string text = base.#ced(#f);
			IEnumerator<KeyValuePair<string, string>> enumerator = this.#lCd().GetEnumerator();
			try
			{
				while (\u0010\u0002.~\u0019\u0004(enumerator))
				{
					KeyValuePair<string, string> keyValuePair = enumerator.Current;
					text = \u008A\u0002.\u0088\u0005(text, \u009D.\u0098\u0003(keyValuePair.Key), keyValuePair.Value, RegexOptions.IgnoreCase);
				}
			}
			finally
			{
				if (enumerator != null)
				{
					\u0007.~\u000E(enumerator);
				}
			}
			return text;
		}

		// Token: 0x06007C2D RID: 31789 RVA: 0x001B556C File Offset: 0x001B376C
		protected override void #qQb(string #eed, string #hed)
		{
			if (base.#ded(#eed) && !base.#fed(#hed))
			{
				\u0097\u0003.~\u0011\u0008(this.#c, #Phc.#3hc(107252145));
			}
			\u0097\u0003.~\u0011\u0008(this.#c, #hed);
		}

		// Token: 0x06007C2E RID: 31790 RVA: 0x00064CF9 File Offset: 0x00062EF9
		protected override IDictionary<string, string> #ied()
		{
			return #mCd.#a;
		}

		// Token: 0x06007C2F RID: 31791 RVA: 0x00064D00 File Offset: 0x00062F00
		protected override string #nrc()
		{
			return \u007F.~\u0011\u0002(this.#c);
		}

		// Token: 0x040032E6 RID: 13030
		private static readonly Dictionary<string, string> #a = new Dictionary<string, string>
		{
			{
				#Phc.#3hc(107251886),
				#Phc.#3hc(107252108)
			},
			{
				#Phc.#3hc(107251900),
				#Phc.#3hc(107252108)
			},
			{
				#Phc.#3hc(107251850),
				#Phc.#3hc(107252099)
			},
			{
				#Phc.#3hc(107251868),
				#Phc.#3hc(107252122)
			},
			{
				#Phc.#3hc(107252117),
				#Phc.#3hc(107252076)
			},
			{
				#Phc.#3hc(107252067),
				#Phc.#3hc(107252090)
			},
			{
				#Phc.#3hc(107251818),
				#Phc.#3hc(107252081)
			},
			{
				#Phc.#3hc(107251836),
				#Phc.#3hc(107252044)
			},
			{
				#Phc.#3hc(107251790),
				#Phc.#3hc(107252039)
			},
			{
				#Phc.#3hc(107251776),
				#Phc.#3hc(107252081)
			},
			{
				#Phc.#3hc(107251758),
				#Phc.#3hc(107399922)
			}
		};

		// Token: 0x040032E7 RID: 13031
		private static readonly Dictionary<string, string> #b = new Dictionary<string, string>
		{
			{
				#Phc.#3hc(107252081),
				#Phc.#3hc(107252034)
			},
			{
				#Phc.#3hc(107252061),
				#Phc.#3hc(107252052)
			},
			{
				#Phc.#3hc(107252011),
				#Phc.#3hc(107252002)
			},
			{
				#Phc.#3hc(107252025),
				#Phc.#3hc(107252016)
			},
			{
				#Phc.#3hc(107251975),
				#Phc.#3hc(107251998)
			},
			{
				#Phc.#3hc(107251989),
				#Phc.#3hc(107251432)
			},
			{
				#Phc.#3hc(107251451),
				#Phc.#3hc(107251406)
			},
			{
				#Phc.#3hc(107251393),
				#Phc.#3hc(107251432)
			},
			{
				#Phc.#3hc(107251416),
				#Phc.#3hc(107251406)
			},
			{
				#Phc.#3hc(107251375),
				#Phc.#3hc(107251366)
			},
			{
				#Phc.#3hc(107251389),
				#Phc.#3hc(107251380)
			},
			{
				#Phc.#3hc(107251335),
				#Phc.#3hc(107251354)
			},
			{
				#Phc.#3hc(107251305),
				#Phc.#3hc(107251296)
			},
			{
				#Phc.#3hc(107251315),
				#Phc.#3hc(107251274)
			},
			{
				#Phc.#3hc(107251293),
				#Phc.#3hc(107251280)
			}
		};

		// Token: 0x040032E8 RID: 13032
		private readonly StringBuilder #c = new StringBuilder();
	}
}
