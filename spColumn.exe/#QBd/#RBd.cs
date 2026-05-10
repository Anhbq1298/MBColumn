using System;
using System.Collections.Generic;
using #7hc;
using #wdd;
using ClosedXML.Excel;

namespace #QBd
{
	// Token: 0x02000D4C RID: 3404
	internal sealed class #RBd : #jed
	{
		// Token: 0x06007BF3 RID: 31731 RVA: 0x000649E5 File Offset: 0x00062BE5
		public #RBd(IXLRichText #OBd)
		{
			this.#b = #OBd;
		}

		// Token: 0x06007BF4 RID: 31732 RVA: 0x000649F4 File Offset: 0x00062BF4
		public void #NBd(string #f)
		{
			base.#ced(#f);
		}

		// Token: 0x06007BF5 RID: 31733 RVA: 0x001B44BC File Offset: 0x001B26BC
		protected override void #qQb(string #eed, string #hed)
		{
			IXLRichString ixlrichString = \u0013\u0003.~\u001A\u0007(this.#b, #hed);
			if (base.#ded(#eed))
			{
				\u0014\u0003.~\u001B\u0007(ixlrichString, XLFontVerticalTextAlignmentValues.Superscript);
				return;
			}
			if (base.#ged(#eed))
			{
				\u0014\u0003.~\u001B\u0007(ixlrichString, XLFontVerticalTextAlignmentValues.Subscript);
			}
		}

		// Token: 0x06007BF6 RID: 31734 RVA: 0x00064A0A File Offset: 0x00062C0A
		protected override IDictionary<string, string> #ied()
		{
			return #RBd.#a;
		}

		// Token: 0x06007BF7 RID: 31735 RVA: 0x0001233F File Offset: 0x0001053F
		protected override string #nrc()
		{
			return null;
		}

		// Token: 0x040032D1 RID: 13009
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

		// Token: 0x040032D2 RID: 13010
		private readonly IXLRichText #b;
	}
}
