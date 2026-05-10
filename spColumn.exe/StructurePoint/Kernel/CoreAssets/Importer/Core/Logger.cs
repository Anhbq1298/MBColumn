using System;
using System.Collections.Generic;
using System.Linq;
using #7hc;
using #H1i;

namespace StructurePoint.Kernel.CoreAssets.Importer.Core
{
	// Token: 0x02000E6A RID: 3690
	public static class Logger
	{
		// Token: 0x060083F7 RID: 33783 RVA: 0x0006B933 File Offset: 0x00069B33
		public static void #QQc(#L1i #wx)
		{
			if (!Logger.Configured)
			{
				Logger.#a = #wx;
				Logger.#pn(#Phc.#3hc(107268096));
				return;
			}
			throw new InvalidOperationException(#Phc.#3hc(107268567));
		}

		// Token: 0x1700279A RID: 10138
		// (get) Token: 0x060083F8 RID: 33784 RVA: 0x0006B961 File Offset: 0x00069B61
		public static bool Configured
		{
			get
			{
				return Logger.#a != null;
			}
		}

		// Token: 0x060083F9 RID: 33785 RVA: 0x0006B96B File Offset: 0x00069B6B
		public static void #qn(string #5)
		{
			#L1i #L1i = Logger.#a;
			if (#L1i == null)
			{
				return;
			}
			#L1i.#nb(#5, null);
		}

		// Token: 0x060083FA RID: 33786 RVA: 0x0006B97E File Offset: 0x00069B7E
		public static void #qn(string #5, Exception #N1i)
		{
			#L1i #L1i = Logger.#a;
			if (#L1i == null)
			{
				return;
			}
			#L1i.#nb(#5, #N1i);
		}

		// Token: 0x060083FB RID: 33787 RVA: 0x0006B991 File Offset: 0x00069B91
		public static void #pn(string #5)
		{
			#L1i #L1i = Logger.#a;
			if (#L1i == null)
			{
				return;
			}
			#L1i.#pb(#5);
		}

		// Token: 0x060083FC RID: 33788 RVA: 0x0006B9A3 File Offset: 0x00069BA3
		public static void #DSi(string #5)
		{
			#L1i #L1i = Logger.#a;
			if (#L1i == null)
			{
				return;
			}
			#L1i.#qb(#5);
		}

		// Token: 0x060083FD RID: 33789 RVA: 0x0006B9B5 File Offset: 0x00069BB5
		public static void #ZSc(string #5)
		{
			#L1i #L1i = Logger.#a;
			if (#L1i == null)
			{
				return;
			}
			#L1i.#Rjc(#5);
		}

		// Token: 0x060083FE RID: 33790 RVA: 0x001C6794 File Offset: 0x001C4994
		public static string #O1i(this IEnumerable<string> #P1i)
		{
			if (#P1i != null)
			{
				return #Phc.#3hc(107413142) + string.Join(#Phc.#3hc(107408397), #P1i.Select(new Func<string, string>(Logger.<>c.<>9.#f4i))) + #Phc.#3hc(107382694);
			}
			return #Phc.#3hc(107268494);
		}

		// Token: 0x060083FF RID: 33791 RVA: 0x001C67FC File Offset: 0x001C49FC
		public static string #Q1i(this string #ioe, string #R1i = "\t", int #S1i = 1, bool #T1i = true)
		{
			string str = string.Concat(Enumerable.Repeat<string>(#R1i, #S1i));
			string[] array = #ioe.Split(new string[]
			{
				#Phc.#3hc(107281469),
				#Phc.#3hc(107413095),
				#Phc.#3hc(107268481)
			}, StringSplitOptions.None);
			for (int i = #T1i ? 1 : 0; i < array.Length; i++)
			{
				array[i] = str + array[i];
			}
			return string.Join(Environment.NewLine, array);
		}

		// Token: 0x04003668 RID: 13928
		private static #L1i #a;
	}
}
