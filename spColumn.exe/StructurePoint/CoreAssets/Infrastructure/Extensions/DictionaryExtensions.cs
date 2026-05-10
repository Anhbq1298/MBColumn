using System;
using System.Collections.Generic;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.Infrastructure.Extensions
{
	// Token: 0x02000EE4 RID: 3812
	public static class DictionaryExtensions
	{
		// Token: 0x06008718 RID: 34584 RVA: 0x001CF874 File Offset: 0x001CDA74
		public static #d3c #F1d<#M5c, #d3c>(this IDictionary<#M5c, #d3c> #Hu, #M5c #6cc)
		{
			do
			{
				string #R0d = #Phc.#3hc(107226028);
				Component #x6c = Component.Infrastructure;
				string #Qic = #Phc.#3hc(107226043);
				if (2 != 0)
				{
					#X0d.#V0d(#Hu, #R0d, #x6c, #Qic);
				}
				if (false)
				{
					goto IL_2E;
				}
			}
			while (false);
			#d3c result;
			if (#Hu.TryGetValue(#6cc, out result) && -1 != 0)
			{
				return result;
			}
			IL_2E:
			return default(!!1);
		}

		// Token: 0x06008719 RID: 34585 RVA: 0x001CF8C4 File Offset: 0x001CDAC4
		public static #d3c #F1d<#M5c, #d3c>(this IDictionary<#M5c, #d3c> #Hu, #M5c #6cc, #d3c #7cc)
		{
			string #R0d = #Phc.#3hc(107226028);
			Component #x6c = Component.Infrastructure;
			string #Qic = #Phc.#3hc(107226043);
			if (4 != 0)
			{
				#X0d.#V0d(#Hu, #R0d, #x6c, #Qic);
			}
			#d3c result;
			if (!#Hu.TryGetValue(#6cc, out result))
			{
				return #7cc;
			}
			return result;
		}

		// Token: 0x0600871A RID: 34586 RVA: 0x001CF904 File Offset: 0x001CDB04
		public static void #pR<#M5c, #d3c, #Zoc>(this IDictionary<#M5c, #d3c> #Hu, IEnumerable<#Zoc> #8f, Func<#Zoc, #M5c> #G1d, Func<#Zoc, #d3c> #s1d)
		{
			string #R0d = #Phc.#3hc(107226028);
			Component #x6c = Component.Infrastructure;
			string #Qic = #Phc.#3hc(107225958);
			if (7 != 0)
			{
				#X0d.#V0d(#Hu, #R0d, #x6c, #Qic);
			}
			while (-1 != 0)
			{
				string #R0d2 = #Phc.#3hc(107264273);
				Component #x6c2 = Component.Infrastructure;
				string #Qic2 = #Phc.#3hc(107225937);
				if (7 != 0)
				{
					#X0d.#V0d(#8f, #R0d2, #x6c2, #Qic2);
				}
				string #R0d3 = #Phc.#3hc(107225884);
				Component #x6c3 = Component.Infrastructure;
				string #Qic3 = #Phc.#3hc(107225323);
				if (!false)
				{
					#X0d.#V0d(#G1d, #R0d3, #x6c3, #Qic3);
				}
				if (7 != 0)
				{
					string #R0d4 = #Phc.#3hc(107225696);
					Component #x6c4 = Component.Infrastructure;
					string #Qic4 = #Phc.#3hc(107225302);
					if (!false)
					{
						#X0d.#V0d(#s1d, #R0d4, #x6c4, #Qic4);
					}
					if (!false)
					{
						IEnumerator<#Zoc> enumerator = #8f.GetEnumerator();
						IEnumerator<#Zoc> enumerator2;
						if (!false)
						{
							enumerator2 = enumerator;
						}
						try
						{
							while (enumerator2.MoveNext())
							{
								#Zoc #Zoc = enumerator2.Current;
								#Zoc arg;
								if (!false)
								{
									arg = #Zoc;
								}
								#Hu.Add(#G1d(arg), #s1d(arg));
							}
						}
						finally
						{
							if (enumerator2 != null)
							{
								enumerator2.Dispose();
							}
						}
						break;
					}
					break;
				}
			}
		}

		// Token: 0x0600871B RID: 34587 RVA: 0x001CFA14 File Offset: 0x001CDC14
		public static void #pR<#M5c, #Zoc>(this IDictionary<#M5c, #Zoc> #Hu, IEnumerable<#Zoc> #8f, Func<#Zoc, #M5c> #G1d)
		{
			if (!false && -1 != 0)
			{
				string #R0d = #Phc.#3hc(107226028);
				Component #x6c = Component.Infrastructure;
				string #Qic = #Phc.#3hc(107225217);
				if (!false)
				{
					#X0d.#V0d(#Hu, #R0d, #x6c, #Qic);
				}
			}
			string #R0d2 = #Phc.#3hc(107264273);
			Component #x6c2 = Component.Infrastructure;
			string #Qic2 = #Phc.#3hc(107225164);
			if (7 != 0)
			{
				#X0d.#V0d(#8f, #R0d2, #x6c2, #Qic2);
			}
			string #R0d3 = #Phc.#3hc(107225884);
			Component #x6c3 = Component.Infrastructure;
			string #Qic3 = #Phc.#3hc(107225143);
			if (!false)
			{
				#X0d.#V0d(#G1d, #R0d3, #x6c3, #Qic3);
			}
			Func<#Zoc, #Zoc> #s1d = new Func<!!1, !!1>(DictionaryExtensions.<>c__3<!!0, !!1>.<>9.#v4d);
			if (!false)
			{
				#Hu.#pR(#8f, #G1d, #s1d);
			}
		}
	}
}
