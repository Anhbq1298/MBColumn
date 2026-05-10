using System;
using System.Collections.Generic;
using System.Linq;
using #7hc;

namespace #UYd
{
	// Token: 0x02000ECC RID: 3788
	internal static class #hZd
	{
		// Token: 0x0600866E RID: 34414 RVA: 0x001CD078 File Offset: 0x001CB278
		public static ICollection<#dZd> #bZd<#dZd>(#dZd #uXb, Func<#dZd, #dZd> #cZd)
		{
			int num;
			if (false || (-1 != 0 && #uXb == null))
			{
				num = 107440306;
			}
			else
			{
				if (#cZd != null)
				{
					List<#dZd> list = new List<!!0>();
					List<#dZd> list2;
					if (!false)
					{
						list2 = list;
					}
					for (;;)
					{
						IL_3D:
						List<!!0> list3 = list2;
						if (!false)
						{
							list3.Add(#uXb);
						}
						#dZd #dZd = #cZd(#uXb);
						#dZd #dZd2;
						if (8 != 0)
						{
							#dZd2 = #dZd;
						}
						while (#dZd2 != null)
						{
							if (5 == 0)
							{
								goto IL_3D;
							}
							List<!!0> list4 = list2;
							!!0 item = #dZd2;
							if (true)
							{
								list4.Add(item);
							}
							#dZd #dZd3 = #cZd(#dZd2);
							if (-1 != 0)
							{
								#dZd2 = #dZd3;
							}
						}
						break;
					}
					return list2;
				}
				int num2 = num = 107227422;
				if (num2 != 0)
				{
					throw new ArgumentNullException(#Phc.#3hc(num2));
				}
			}
			throw new ArgumentNullException(#Phc.#3hc(num));
		}

		// Token: 0x0600866F RID: 34415 RVA: 0x001CD10C File Offset: 0x001CB30C
		public static void #mbb<#dZd>(IEnumerable<#dZd> #zPd, Func<#dZd, IEnumerable<#dZd>> #eZd, Action<#dZd> #nd)
		{
			int num2;
			if (#zPd != null)
			{
				while (#eZd != null)
				{
					if (#nd == null)
					{
						int num = num2 = 107351365;
						if (num != 0)
						{
							throw new ArgumentNullException(#Phc.#3hc(num));
						}
						goto IL_08;
					}
					else
					{
						Stack<#dZd> stack = new Stack<!!0>();
						Stack<#dZd> stack2;
						if (2 != 0)
						{
							stack2 = stack;
						}
						if (!false)
						{
							IEnumerator<#dZd> enumerator = #zPd.GetEnumerator();
							IEnumerator<#dZd> enumerator2;
							if (4 != 0)
							{
								enumerator2 = enumerator;
							}
							try
							{
								if (!false)
								{
									goto IL_AF;
								}
								IL_5D:
								#dZd #dZd = enumerator2.Current;
								#dZd #dZd2;
								if (7 != 0)
								{
									#dZd2 = #dZd;
								}
								Stack<!!0> stack3 = stack2;
								!!0 item = #dZd2;
								if (!false)
								{
									stack3.Push(item);
								}
								IL_A6:
								int num3 = stack2.Count;
								IL_AC:
								if (num3 > 0)
								{
									#dZd #dZd3 = stack2.Pop();
									#dZd #dZd4;
									if (2 != 0)
									{
										#dZd4 = #dZd3;
									}
									!!0 obj = #dZd4;
									if (!false)
									{
										#nd(obj);
									}
									IEnumerable<#dZd> enumerable = #eZd(#dZd4);
									if (enumerable != null)
									{
										List<#dZd> list = enumerable.ToList<#dZd>();
										list.Reverse();
										stack2.#fZd(list);
										goto IL_A6;
									}
									goto IL_A6;
								}
								IL_AF:
								bool flag = (num3 = (enumerator2.MoveNext() ? 1 : 0)) != 0;
								if (false)
								{
									goto IL_AC;
								}
								if (flag)
								{
									goto IL_5D;
								}
							}
							finally
							{
								if (enumerator2 != null)
								{
									enumerator2.Dispose();
								}
							}
							return;
						}
					}
				}
				throw new ArgumentNullException(#Phc.#3hc(107226848));
			}
			num2 = 107226857;
			IL_08:
			throw new ArgumentNullException(#Phc.#3hc(num2));
		}

		// Token: 0x06008670 RID: 34416 RVA: 0x001CD210 File Offset: 0x001CB410
		public static void #fZd<#Zoc>(this Stack<#Zoc> #gZd, IEnumerable<#Zoc> #8f)
		{
			int num;
			while (#gZd != null)
			{
				if (!false)
				{
					if (#8f == null)
					{
						num = 107264273;
						IL_24:
						throw new ArgumentNullException(#Phc.#3hc(num));
					}
					IEnumerator<#Zoc> enumerator = #8f.GetEnumerator();
					IEnumerator<#Zoc> enumerator2;
					if (2 != 0)
					{
						enumerator2 = enumerator;
						goto IL_39;
					}
					try
					{
						for (;;)
						{
							IL_39:
							while (enumerator2.MoveNext())
							{
								if (!false)
								{
									#Zoc #Zoc = enumerator2.Current;
									#Zoc #Zoc2;
									if (!false)
									{
										#Zoc2 = #Zoc;
									}
									!!0 item = #Zoc2;
									if (!false)
									{
										#gZd.Push(item);
									}
								}
							}
							break;
						}
					}
					finally
					{
						if (enumerator2 != null)
						{
							enumerator2.Dispose();
						}
					}
					return;
				}
			}
			if (false)
			{
				return;
			}
			int num2 = num = 107226823;
			if (num2 != 0)
			{
				throw new ArgumentNullException(#Phc.#3hc(num2));
			}
			goto IL_24;
		}
	}
}
