using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using #7hc;
using #8Cc;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace #TCc
{
	// Token: 0x02000B66 RID: 2918
	internal static class #2Cc
	{
		// Token: 0x06005F31 RID: 24369 RVA: 0x00178798 File Offset: 0x00176998
		public static #bDc #vZ(Type #C)
		{
			if (!(#C == null))
			{
				#bDc #bDc;
				if (#2Cc.#a.TryGetValue(#C, out #bDc))
				{
					if (false)
					{
						goto IL_09;
					}
					if (#bDc != null)
					{
						return #bDc;
					}
				}
				List<#1Cc> list = #C.GetCustomAttributes(true).OfType<#1Cc>().ToList<#1Cc>();
				List<#1Cc> list2;
				if (5 != 0)
				{
					list2 = list;
				}
				if (list2.Count == 1)
				{
					#1Cc #1Cc = list2.First<#1Cc>();
					#1Cc #1Cc2;
					if (!false)
					{
						#1Cc2 = #1Cc;
					}
					MethodInfo method = #1Cc2.Provider.GetMethod(#1Cc2.Factory, BindingFlags.Static | BindingFlags.Public);
					if (method == null)
					{
						throw new ArgumentException(#Phc.#3hc(107418000).#z2d(), #Phc.#3hc(107383497));
					}
					#bDc #bDc2 = method.Invoke(null, null) as #bDc;
					if (!false)
					{
						#bDc = #bDc2;
					}
					ConcurrentDictionary<Type, #bDc> concurrentDictionary = #2Cc.#a;
					#bDc value = #bDc;
					if (!false)
					{
						concurrentDictionary[#C] = value;
					}
				}
				if (#bDc == null)
				{
					throw new InvalidOperationException(#Phc.#3hc(107417947));
				}
				return #bDc;
			}
			IL_09:
			throw new ArgumentNullException(#Phc.#3hc(107383497));
		}

		// Token: 0x04002754 RID: 10068
		private static readonly ConcurrentDictionary<Type, #bDc> #a = new ConcurrentDictionary<Type, #bDc>();
	}
}
