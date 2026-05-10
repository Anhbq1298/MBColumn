using System;
using System.Collections.Generic;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #N6c
{
	// Token: 0x02000CEF RID: 3311
	internal static class #M6c
	{
		// Token: 0x06006C25 RID: 27685 RVA: 0x00054DD5 File Offset: 0x00052FD5
		public static bool #K6c<#Fu>(this IReadOnlyList<#Fu> #Du, int #4jb)
		{
			string #R0d = #Phc.#3hc(107420761);
			Component #x6c = Component.GUIFramework;
			string #Qic = #Phc.#3hc(107264079);
			if (!false)
			{
				#X0d.#V0d(#Du, #R0d, #x6c, #Qic);
			}
			int num = #4jb;
			int num3;
			int num2 = num3 = 0;
			if (num2 != 0)
			{
				goto IL_2F;
			}
			if (#4jb < num2 || !true)
			{
				return false;
			}
			num = #4jb;
			IL_29:
			num3 = #Du.Count;
			IL_2F:
			bool result = (num = ((num < num3) ? 1 : 0)) != 0;
			if (8 != 0)
			{
				return result;
			}
			goto IL_29;
		}

		// Token: 0x06006C26 RID: 27686 RVA: 0x00054DD5 File Offset: 0x00052FD5
		public static bool #K6c<#Fu>(this IReadOnlyCollection<#Fu> #Du, int #4jb)
		{
			string #R0d = #Phc.#3hc(107420761);
			Component #x6c = Component.GUIFramework;
			string #Qic = #Phc.#3hc(107264079);
			if (!false)
			{
				#X0d.#V0d(#Du, #R0d, #x6c, #Qic);
			}
			int num = #4jb;
			int num3;
			int num2 = num3 = 0;
			if (num2 != 0)
			{
				goto IL_2F;
			}
			if (#4jb < num2 || !true)
			{
				return false;
			}
			num = #4jb;
			IL_29:
			num3 = #Du.Count;
			IL_2F:
			bool result = (num = ((num < num3) ? 1 : 0)) != 0;
			if (8 != 0)
			{
				return result;
			}
			goto IL_29;
		}

		// Token: 0x06006C27 RID: 27687 RVA: 0x001A1C90 File Offset: 0x0019FE90
		public static void #L6c<#Zoc>(this ICollection<#Zoc> #Du, IEnumerable<#Zoc> #8f)
		{
			string #R0d = #Phc.#3hc(107420761);
			Component #x6c = Component.Infrastructure;
			string #Qic = #Phc.#3hc(107264058);
			if (8 != 0)
			{
				#X0d.#V0d(#Du, #R0d, #x6c, #Qic);
			}
			if (#8f == null)
			{
				return;
			}
			IEnumerator<#Zoc> enumerator = #8f.GetEnumerator();
			IEnumerator<#Zoc> enumerator2;
			if (4 != 0)
			{
				enumerator2 = enumerator;
			}
			try
			{
				if (!false)
				{
					goto IL_45;
				}
				IL_30:
				#Zoc #Zoc = enumerator2.Current;
				#Zoc item;
				if (8 != 0)
				{
					item = #Zoc;
				}
				bool flag = #Du.Remove(item);
				if (6 == 0)
				{
					goto IL_4B;
				}
				IL_45:
				flag = enumerator2.MoveNext();
				IL_4B:
				if (flag)
				{
					goto IL_30;
				}
				if (6 == 0)
				{
					goto IL_45;
				}
			}
			finally
			{
				if (enumerator2 != null)
				{
					enumerator2.Dispose();
				}
			}
		}
	}
}
