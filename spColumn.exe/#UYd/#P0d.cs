using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using #7hc;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace #UYd
{
	// Token: 0x02000ED6 RID: 3798
	internal static class #P0d
	{
		// Token: 0x060086D6 RID: 34518 RVA: 0x001CED54 File Offset: 0x001CCF54
		public static string #G0d(IList<string> #H0d, string #I0d, string #vWc)
		{
			#P0d.#v0b #v0b = new #P0d.#v0b();
			#P0d.#v0b #v0b2;
			if (!false)
			{
				#v0b2 = #v0b;
			}
			string #R0d = #Phc.#3hc(107226168);
			Component #x6c = Component.Infrastructure;
			string #Qic = #Phc.#3hc(107226115);
			if (!false)
			{
				#X0d.#V0d(#H0d, #R0d, #x6c, #Qic);
			}
			bool flag = false;
			bool flag2;
			if (7 != 0)
			{
				flag2 = flag;
			}
			if (string.IsNullOrWhiteSpace(#I0d))
			{
				bool flag3 = true;
				if (!false)
				{
					flag2 = flag3;
				}
				if (!false)
				{
					#I0d = #vWc;
				}
			}
			int num = 1;
			int num2;
			if (6 != 0)
			{
				num2 = num;
			}
			#v0b2.#a = (flag2 ? (#I0d + num2.ToString()) : #I0d);
			int num3;
			bool flag4 = (num3 = (flag2 ? 1 : 0)) != 0;
			string text;
			if (4 != 0)
			{
				if (!flag4)
				{
					text = #Phc.#3hc(107226574);
					goto IL_89;
				}
				num3 = 107226561;
			}
			text = #Phc.#3hc(num3);
			IL_89:
			string #f = text;
			while (#H0d.Any(new Func<string, bool>(#v0b2.#p4d)))
			{
				#v0b2.#a = #f.#D2d(new object[]
				{
					#I0d,
					num2
				});
				num2++;
			}
			return #v0b2.#a;
		}

		// Token: 0x060086D7 RID: 34519 RVA: 0x0006DA3F File Offset: 0x0006BC3F
		public static bool #J0d(string #rD)
		{
			int result;
			for (;;)
			{
				bool flag = (result = (string.IsNullOrEmpty(#rD) ? 1 : 0)) != 0;
				if (false)
				{
					return result != 0;
				}
				if (flag && 4 != 0)
				{
					break;
				}
				if (4 != 0)
				{
					goto Block_3;
				}
			}
			result = 0;
			return result != 0;
			Block_3:
			IEnumerable<char> source = #rD.ToCharArray();
			Func<char, bool> predicate;
			if ((predicate = #P0d.#2Ui.#a) == null)
			{
				predicate = (#P0d.#2Ui.#a = new Func<char, bool>(char.IsUpper));
			}
			return source.All(predicate);
		}

		// Token: 0x060086D8 RID: 34520 RVA: 0x001CEE54 File Offset: 0x001CD054
		public static string #K0d(IList<string> #H0d, string #vWc)
		{
			string #R0d = #Phc.#3hc(107226168);
			Component #x6c = Component.Infrastructure;
			string #Qic = #Phc.#3hc(107226584);
			if (!false)
			{
				#X0d.#V0d(#H0d, #R0d, #x6c, #Qic);
			}
			string #R0d2 = #Phc.#3hc(107226499);
			Component #x6c2 = Component.GUI;
			string #Qic2 = #Phc.#3hc(107226522);
			if (5 != 0)
			{
				#X0d.#V0d(#vWc, #R0d2, #x6c2, #Qic2);
			}
			List<int> list = new List<int>();
			List<int> list2;
			if (!false)
			{
				list2 = list;
			}
			IEnumerator<string> enumerator = #H0d.GetEnumerator();
			IEnumerator<string> enumerator2;
			if (3 != 0)
			{
				enumerator2 = enumerator;
			}
			try
			{
				while (enumerator2.MoveNext())
				{
					string input = enumerator2.Current;
					string text = #Phc.#3hc(107252145) + #vWc + #Phc.#3hc(107226437);
					string pattern;
					if (!false)
					{
						pattern = text;
					}
					MatchCollection matchCollection = Regex.Matches(input, pattern, RegexOptions.IgnoreCase);
					MatchCollection matchCollection2;
					if (-1 != 0)
					{
						matchCollection2 = matchCollection;
					}
					int item;
					if (!false)
					{
						if (matchCollection2.Count != 1)
						{
							continue;
						}
						Match match = matchCollection2[0];
						string s;
						if (match == null)
						{
							s = null;
						}
						else
						{
							Group group = match.Groups[1];
							s = ((group != null) ? group.Value : null);
						}
						if (!int.TryParse(s, out item))
						{
							continue;
						}
					}
					list2.Add(item);
				}
			}
			finally
			{
				if (enumerator2 != null)
				{
					enumerator2.Dispose();
				}
			}
			int num = 1;
			if (list2.Any<int>())
			{
				num = list2.Max() + 1;
			}
			return string.Format(CultureInfo.InvariantCulture, #Phc.#3hc(107226561), new object[]
			{
				#vWc,
				num
			});
		}

		// Token: 0x060086D9 RID: 34521 RVA: 0x001CEFB8 File Offset: 0x001CD1B8
		public static int #L0d(string #oT)
		{
			string #R0d = #Phc.#3hc(107226460);
			Component #x6c = Component.Infrastructure;
			string #Qic = #Phc.#3hc(107226451);
			if (!false)
			{
				#X0d.#V0d(#oT, #R0d, #x6c, #Qic);
			}
			if (4 == 0)
			{
				goto IL_2D;
			}
			if (false)
			{
				goto IL_5D;
			}
			int num = 0;
			int num2;
			if (!false)
			{
				num2 = num;
			}
			int num3 = 1;
			IL_29:
			int num4;
			if (true)
			{
				num4 = num3;
			}
			IL_2D:
			int num5 = #oT.Length - 1;
			int num6;
			if (6 != 0)
			{
				num6 = num5;
			}
			goto IL_61;
			IL_5D:
			num6--;
			IL_61:
			if (num6 < 0)
			{
				return num2;
			}
			int num7 = num2;
			int num9;
			int num8 = num9 = (int)#oT[num6];
			if (!false)
			{
				num9 = num8 - 65 + 1;
			}
			int num10 = num3 = num7 + num9 * num4;
			if (false)
			{
				goto IL_29;
			}
			if (!false)
			{
				num2 = num10;
			}
			int num11 = num4 * 26;
			if (6 == 0)
			{
				goto IL_5D;
			}
			num4 = num11;
			goto IL_5D;
		}

		// Token: 0x060086DA RID: 34522 RVA: 0x001CF044 File Offset: 0x001CD244
		public static string #M0d(IList<string> #N0d)
		{
			string #R0d = #Phc.#3hc(107226398);
			Component #x6c = Component.Infrastructure;
			string #Qic = #Phc.#3hc(107225833);
			if (7 != 0)
			{
				#X0d.#V0d(#N0d, #R0d, #x6c, #Qic);
			}
			List<int> list2;
			if (4 != 0)
			{
				if (false)
				{
					goto IL_88;
				}
				List<int> list = new List<int>();
				if (!false)
				{
					list2 = list;
				}
			}
			IEnumerator<string> enumerator = #N0d.GetEnumerator();
			IEnumerator<string> enumerator2;
			if (-1 != 0)
			{
				enumerator2 = enumerator;
			}
			try
			{
				while (enumerator2.MoveNext())
				{
					string #oT;
					if (!false)
					{
						string text = enumerator2.Current;
						if (!false)
						{
							#oT = text;
						}
					}
					List<int> list3 = list2;
					int item = #P0d.#L0d(#oT);
					if (!false)
					{
						list3.Add(item);
					}
				}
			}
			finally
			{
				do
				{
					if (enumerator2 != null)
					{
						enumerator2.Dispose();
					}
				}
				while (false);
			}
			int num = 1;
			int #AWc;
			if (!false)
			{
				#AWc = num;
			}
			if (!list2.Any<int>())
			{
				goto IL_91;
			}
			IL_88:
			#AWc = list2.Max() + 1;
			IL_91:
			return #P0d.#O0d(#AWc);
		}

		// Token: 0x060086DB RID: 34523 RVA: 0x001CF114 File Offset: 0x001CD314
		public static string #O0d(int #AWc)
		{
			int num = #AWc;
			string text;
			for (;;)
			{
				IL_01:
				int i;
				if (7 != 0)
				{
					i = num;
				}
				for (;;)
				{
					IL_05:
					if (!false)
					{
						string empty = string.Empty;
						if (!false)
						{
							text = empty;
						}
					}
					while (i > 0)
					{
						int num2 = i - 1;
						int num4;
						int value;
						do
						{
							int num3 = num2 % 26;
							if (6 != 0)
							{
								num4 = num3;
							}
							int num5 = num = 65;
							if (num5 == 0)
							{
								goto IL_01;
							}
							value = (num2 = num5 + num4);
						}
						while (false);
						char c = Convert.ToChar(value);
						char c2;
						if (true)
						{
							c2 = c;
						}
						if (false)
						{
							goto IL_05;
						}
						string text2 = c2.ToString() + text;
						if (!false)
						{
							text = text2;
						}
						int num6 = (i - num4) / 26;
						if (4 != 0)
						{
							i = num6;
						}
					}
					return text;
				}
			}
			return text;
		}

		// Token: 0x040037B8 RID: 14264
		private const int #a = 26;

		// Token: 0x02000ED7 RID: 3799
		[CompilerGenerated]
		private static class #2Ui
		{
			// Token: 0x040037B9 RID: 14265
			public static Func<char, bool> #a;
		}

		// Token: 0x02000ED8 RID: 3800
		[CompilerGenerated]
		private sealed class #v0b
		{
			// Token: 0x060086DD RID: 34525 RVA: 0x0006DA7A File Offset: 0x0006BC7A
			internal bool #p4d(string #Rf)
			{
				return string.Equals(#Rf, this.#a, StringComparison.OrdinalIgnoreCase);
			}

			// Token: 0x040037BA RID: 14266
			public string #a;
		}
	}
}
