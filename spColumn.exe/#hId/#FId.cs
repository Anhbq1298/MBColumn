using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using #7hc;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Printing;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace #hId
{
	// Token: 0x02000DA3 RID: 3491
	internal static class #FId
	{
		// Token: 0x06007E43 RID: 32323 RVA: 0x001BC21C File Offset: 0x001BA41C
		public static bool #BId(string #f)
		{
			if (\u0003.\u0004(#f) || !\u0080.~\u007F\u0002(#FId.#a, #f))
			{
				return false;
			}
			foreach (string text in #FId.#EId(#f))
			{
				if (\u008D\u0002.~\u008D\u0005(\u0090\u0002.~\u009C\u0005(#FId.#b, text)) != 1)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06007E44 RID: 32324 RVA: 0x001BC290 File Offset: 0x001BA490
		public static IReadOnlyList<IPageSelection> #1vb(string #f, int #CId, int #DId)
		{
			if (!#FId.#BId(#f))
			{
				return null;
			}
			List<IPageSelection> list = new List<IPageSelection>();
			foreach (string input in #FId.#EId(#f))
			{
				Match match = #FId.#b.Match(input);
				if (match.Success)
				{
					Group group = match.Groups[#Phc.#3hc(107281036)];
					Group group2 = match.Groups[#Phc.#3hc(107281027)];
					if (match.Groups[#Phc.#3hc(107281054)].Success)
					{
						int num = #CId;
						int num2 = #DId;
						if (group.Success)
						{
							num = int.Parse(group.Value);
						}
						if (group2.Success)
						{
							num2 = int.Parse(group2.Value);
						}
						#FId.#KBb(num, #CId, #DId);
						#FId.#KBb(num2, #CId, #DId);
						list.Add(new #zId(num, num2));
					}
					else
					{
						int num3 = int.Parse(group.Value);
						#FId.#KBb(num3, #CId, #DId);
						list.Add(new #zId(num3, num3));
					}
				}
			}
			return list;
		}

		// Token: 0x06007E45 RID: 32325 RVA: 0x00066CF0 File Offset: 0x00064EF0
		private static string[] #EId(string #f)
		{
			return \u0010\u0005.~\u009E\u000E(#f, new char[]
			{
				' ',
				';',
				','
			});
		}

		// Token: 0x06007E46 RID: 32326 RVA: 0x00066D1A File Offset: 0x00064F1A
		private static void #KBb(int #f, int #GT, int #HT)
		{
			if (#f < #GT || #f > #HT)
			{
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107386484), #Phc.#3hc(107281049).#z2d());
			}
		}

		// Token: 0x040033B7 RID: 13239
		private static readonly Regex #a = new Regex(#Phc.#3hc(107280960), RegexOptions.Compiled | RegexOptions.CultureInvariant);

		// Token: 0x040033B8 RID: 13240
		private static readonly Regex #b = new Regex(#Phc.#3hc(107280939), RegexOptions.Compiled | RegexOptions.CultureInvariant);
	}
}
