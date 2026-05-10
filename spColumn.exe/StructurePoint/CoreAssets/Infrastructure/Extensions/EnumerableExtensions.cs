using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;

namespace StructurePoint.CoreAssets.Infrastructure.Extensions
{
	// Token: 0x02000EDE RID: 3806
	public static class EnumerableExtensions
	{
		// Token: 0x06008701 RID: 34561 RVA: 0x0006DD11 File Offset: 0x0006BF11
		public static #Zoc #p1d<#Zoc, #d3c>(this IEnumerable<#Zoc> #8f, Func<#Zoc, #d3c> #b3c)
		{
			int num;
			if (#8f != null)
			{
				if (#b3c == null && !false)
				{
					num = 107430759;
					goto IL_21;
				}
				if (!false)
				{
					return #8f.OrderBy(#b3c).FirstOrDefault<#Zoc>();
				}
			}
			int num2 = num = 107264273;
			if (num2 != 0)
			{
				throw new ArgumentNullException(#Phc.#3hc(num2));
			}
			IL_21:
			throw new ArgumentNullException(#Phc.#3hc(num));
		}

		// Token: 0x06008702 RID: 34562 RVA: 0x0006DD4E File Offset: 0x0006BF4E
		public static #Zoc #q1d<#Zoc, #d3c>(this IEnumerable<#Zoc> #8f, Func<#Zoc, #d3c> #b3c)
		{
			int num;
			if (#8f != null)
			{
				if (#b3c == null && !false)
				{
					num = 107430759;
					goto IL_21;
				}
				if (!false)
				{
					return #8f.OrderByDescending(#b3c).FirstOrDefault<#Zoc>();
				}
			}
			int num2 = num = 107264273;
			if (num2 != 0)
			{
				throw new ArgumentNullException(#Phc.#3hc(num2));
			}
			IL_21:
			throw new ArgumentNullException(#Phc.#3hc(num));
		}

		// Token: 0x06008703 RID: 34563 RVA: 0x001CF364 File Offset: 0x001CD564
		public static #Fu #r1d<#Fu, #Zoc>(this IEnumerable<#Zoc> #8f, Func<#Zoc, #Fu> #s1d)
		{
			if (#s1d == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107225696));
			}
			#Fu #Fu4;
			while (#8f != null)
			{
				bool flag = false;
				bool flag2;
				if (3 != 0)
				{
					flag2 = flag;
				}
				#Fu #Fu = default(!!0);
				if (7 != 0)
				{
					IEnumerator<#Zoc> enumerator = #8f.GetEnumerator();
					IEnumerator<#Zoc> enumerator2;
					if (7 != 0)
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
							#Fu #Fu2 = #s1d(arg);
							#Fu #Fu3;
							if (true)
							{
								#Fu3 = #Fu2;
							}
							int num;
							bool flag3 = (num = (flag2 ? 1 : 0)) != 0;
							if (6 != 0)
							{
								if (flag3 && !object.Equals(#Fu, #Fu3))
								{
									#Fu4 = default(!!0);
									#Fu #Fu5 = #Fu4;
									if (!false)
									{
										#Fu4 = #Fu5;
									}
									return #Fu4;
								}
								num = 1;
							}
							if (8 != 0)
							{
								flag2 = (num != 0);
							}
							#Fu = #Fu3;
						}
					}
					finally
					{
						if (enumerator2 != null && 3 != 0)
						{
							enumerator2.Dispose();
						}
					}
					if (!false)
					{
						return #Fu;
					}
					break;
				}
			}
			#Fu4 = default(!!0);
			return #Fu4;
		}

		// Token: 0x06008704 RID: 34564 RVA: 0x0006DD8B File Offset: 0x0006BF8B
		public static bool #t1d<#Fu>(this IEnumerable<#Fu> #u1d)
		{
			return #u1d == null || !#u1d.Any<#Fu>();
		}

		// Token: 0x06008705 RID: 34565 RVA: 0x001CF444 File Offset: 0x001CD644
		public static IOrderedEnumerable<#Fu> #A9h<#Fu>(this IEnumerable<#Fu> #8f, IEnumerable<#Fu> #B9h)
		{
			EnumerableExtensions<#Fu>.#lcd #lcd = new EnumerableExtensions<!!0>.#lcd();
			EnumerableExtensions<#Fu>.#lcd #lcd2;
			if (4 != 0)
			{
				#lcd2 = #lcd;
			}
			#lcd2.#a = #B9h.Select(new Func<!!0, int, <>f__AnonymousType0<!!0, int>>(EnumerableExtensions.<>c__4<!!0>.<>9.#I9h)).ToDictionary(new Func<<>f__AnonymousType0<!!0, int>, !!0>(EnumerableExtensions.<>c__4<!!0>.<>9.#J9h), new Func<<>f__AnonymousType0<!!0, int>, int>(EnumerableExtensions.<>c__4<!!0>.<>9.#K9h));
			return #8f.OrderBy(new Func<!!0, int>(#lcd2.#H9h));
		}

		// Token: 0x02000EE0 RID: 3808
		[CompilerGenerated]
		private sealed class #lcd<#Fu>
		{
			// Token: 0x0600870C RID: 34572 RVA: 0x0006DDC0 File Offset: 0x0006BFC0
			internal int #H9h(#Fu #9o)
			{
				return this.#a[#9o];
			}

			// Token: 0x040037C7 RID: 14279
			public Dictionary<#Fu, int> #a;
		}
	}
}
