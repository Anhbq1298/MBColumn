using System;
using System.Collections.Generic;
using System.Text;
using #7hc;
using #wdd;

namespace #5Fd
{
	// Token: 0x02000D79 RID: 3449
	internal class #WGd : #jed
	{
		// Token: 0x06007D13 RID: 32019 RVA: 0x00065A56 File Offset: 0x00063C56
		public string #NBd(string #f)
		{
			\u009E\u0004.~\u0091\u000E(this.#b);
			return base.#ced(#f);
		}

		// Token: 0x06007D14 RID: 32020 RVA: 0x001B96C4 File Offset: 0x001B78C4
		protected override void #qQb(string #eed, string #hed)
		{
			if (base.#ded(#eed) && !base.#fed(#hed))
			{
				\u0097\u0003.~\u0011\u0008(this.#b, #Phc.#3hc(107252145));
			}
			\u0097\u0003.~\u0011\u0008(this.#b, #hed);
		}

		// Token: 0x06007D15 RID: 32021 RVA: 0x00065A7C File Offset: 0x00063C7C
		protected override IDictionary<string, string> #ied()
		{
			return #WGd.#a;
		}

		// Token: 0x06007D16 RID: 32022 RVA: 0x00065A83 File Offset: 0x00063C83
		protected override string #nrc()
		{
			return \u007F.~\u0011\u0002(this.#b);
		}

		// Token: 0x0400333C RID: 13116
		private static readonly Dictionary<string, string> #a = new Dictionary<string, string>
		{
			{
				#Phc.#3hc(107251886),
				#Phc.#3hc(107251873)
			},
			{
				#Phc.#3hc(107251900),
				#Phc.#3hc(107251855)
			},
			{
				#Phc.#3hc(107251850),
				#Phc.#3hc(107251841)
			},
			{
				#Phc.#3hc(107251868),
				#Phc.#3hc(107251823)
			},
			{
				#Phc.#3hc(107251818),
				#Phc.#3hc(107251809)
			},
			{
				#Phc.#3hc(107251836),
				#Phc.#3hc(107251827)
			},
			{
				#Phc.#3hc(107251790),
				#Phc.#3hc(107251781)
			},
			{
				#Phc.#3hc(107251776),
				#Phc.#3hc(107251795)
			},
			{
				#Phc.#3hc(107251758),
				#Phc.#3hc(107399922)
			}
		};

		// Token: 0x0400333D RID: 13117
		protected readonly StringBuilder #b = new StringBuilder();
	}
}
