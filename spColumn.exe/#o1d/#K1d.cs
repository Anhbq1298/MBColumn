using System;
using System.Collections.Generic;
using #7hc;

namespace #o1d
{
	// Token: 0x02000EE6 RID: 3814
	internal static class #K1d
	{
		// Token: 0x0600871F RID: 34591 RVA: 0x001CFAC4 File Offset: 0x001CDCC4
		public static void #pR<#Fu>(this ISet<#Fu> #H1d, IEnumerable<#Fu> #8f)
		{
			int num2;
			if (#H1d == null)
			{
				int num = num2 = 107225570;
				if (num != 0)
				{
					throw new ArgumentNullException(#Phc.#3hc(num));
				}
			}
			else
			{
				if (#8f != null)
				{
					IEnumerator<#Fu> enumerator = #8f.GetEnumerator();
					IEnumerator<#Fu> enumerator2;
					if (5 != 0)
					{
						enumerator2 = enumerator;
						goto IL_33;
					}
					try
					{
						for (;;)
						{
							IL_33:
							for (;;)
							{
								IL_4D:
								bool flag = enumerator2.MoveNext();
								while (flag)
								{
									#Fu #Fu = enumerator2.Current;
									#Fu item;
									if (!false)
									{
										item = #Fu;
									}
									if (false)
									{
										goto IL_33;
									}
									flag = #H1d.Add(item);
									if (!false)
									{
										goto IL_4D;
									}
								}
								goto Block_6;
							}
						}
						Block_6:;
					}
					finally
					{
						if (enumerator2 == null)
						{
							goto IL_63;
						}
						IL_5D:
						enumerator2.Dispose();
						IL_63:
						if (5 == 0)
						{
							goto IL_5D;
						}
					}
					return;
				}
				num2 = 107264273;
			}
			throw new ArgumentNullException(#Phc.#3hc(num2));
		}

		// Token: 0x06008720 RID: 34592 RVA: 0x001CFB4C File Offset: 0x001CDD4C
		public static void #I1d<#Zoc>(this IEnumerable<#Zoc> #H1d, Action<#Zoc> #nd)
		{
			int num;
			while (#H1d != null)
			{
				if (!false)
				{
					if (#nd == null)
					{
						num = 107351365;
						IL_24:
						throw new ArgumentNullException(#Phc.#3hc(num));
					}
					IEnumerator<#Zoc> enumerator = #H1d.GetEnumerator();
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
									!!0 obj = #Zoc2;
									if (!false)
									{
										#nd(obj);
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
			int num2 = num = 107225570;
			if (num2 != 0)
			{
				throw new ArgumentNullException(#Phc.#3hc(num2));
			}
			goto IL_24;
		}

		// Token: 0x06008721 RID: 34593 RVA: 0x0006DE3D File Offset: 0x0006C03D
		public static IEnumerable<#j0d> #J1d<#Zoc, #j0d>(this IEnumerable<#Zoc> #8f, Func<#Zoc, #j0d> #b3c)
		{
			#K1d<!!0, !!1>.#y4d #y4d = new #K1d<!!0, !!1>.#y4d(-2);
			#y4d.#e = #8f;
			#y4d.#g = #b3c;
			return #y4d;
		}

		// Token: 0x06008722 RID: 34594 RVA: 0x001CFBDC File Offset: 0x001CDDDC
		public static IList<#j0d> #J1d<#Zoc, #j0d>(this IList<#Zoc> #8f, Func<#Zoc, #j0d> #b3c)
		{
			List<#j0d> list2;
			if (-1 != 0)
			{
				int num2;
				if (#8f == null)
				{
					int num = num2 = 107264273;
					if (num != 0)
					{
						throw new ArgumentNullException(#Phc.#3hc(num));
					}
				}
				else if (#b3c == null)
				{
					num2 = 107430759;
				}
				else
				{
					List<#j0d> list = new List<!!1>(#8f.Count);
					if (2 == 0)
					{
						goto IL_3B;
					}
					list2 = list;
					goto IL_3B;
				}
				throw new ArgumentNullException(#Phc.#3hc(num2));
			}
			IL_3B:
			IEnumerator<#Zoc> enumerator = #8f.GetEnumerator();
			IEnumerator<#Zoc> enumerator2;
			if (6 != 0)
			{
				enumerator2 = enumerator;
			}
			try
			{
				while (enumerator2.MoveNext())
				{
					#Zoc #Zoc = enumerator2.Current;
					#Zoc arg;
					if (8 != 0)
					{
						arg = #Zoc;
					}
					List<!!1> list3 = list2;
					!!1 item = #b3c(arg);
					if (5 != 0)
					{
						list3.Add(item);
					}
				}
			}
			finally
			{
				if (enumerator2 != null && 3 != 0)
				{
					enumerator2.Dispose();
				}
			}
			return list2;
		}

		// Token: 0x06008723 RID: 34595 RVA: 0x001CFC80 File Offset: 0x001CDE80
		public static void #I1d<#Zoc>(this IList<#Zoc> #7p, Action<#Zoc> #nd)
		{
			if (#7p == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107467337));
			}
			int num;
			if (#nd == null)
			{
				if (8 == 0)
				{
					goto IL_50;
				}
				num = 107351365;
			}
			else
			{
				int num2 = 0;
				if (false)
				{
					goto IL_2E;
				}
				int num3 = num2;
				goto IL_2E;
			}
			IL_1E:
			throw new ArgumentNullException(#Phc.#3hc(num));
			IL_2E:
			for (;;)
			{
				int num3;
				int num4 = num = num3;
				if (false)
				{
					goto IL_1E;
				}
				if (num4 >= #7p.Count)
				{
					break;
				}
				!!0 obj = #7p[num3];
				if (-1 != 0)
				{
					#nd(obj);
				}
				int num5 = num3 + 1;
				if (!false)
				{
					num3 = num5;
				}
			}
			IL_50:
			if (!false)
			{
				return;
			}
			goto IL_2E;
		}

		// Token: 0x06008724 RID: 34596 RVA: 0x001CFCF0 File Offset: 0x001CDEF0
		public static void #I1d<#Zoc>(this IEnumerable<#Zoc> #H1d, Action<#Zoc, int> #nd)
		{
			int num2;
			if (#H1d == null)
			{
				int num = num2 = 107225570;
				if (num != 0)
				{
					throw new ArgumentNullException(#Phc.#3hc(num));
				}
			}
			else
			{
				if (#nd != null)
				{
					int num3 = 0;
					int num4;
					if (-1 != 0)
					{
						num4 = num3;
					}
					IEnumerator<#Zoc> enumerator = #H1d.GetEnumerator();
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
							#Zoc #Zoc2;
							if (8 != 0)
							{
								#Zoc2 = #Zoc;
							}
							!!0 arg = #Zoc2;
							int num5 = num4;
							int num6 = num5 + 1;
							if (6 != 0)
							{
								num4 = num6;
							}
							if (3 != 0)
							{
								#nd(arg, num5);
							}
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
				num2 = 107351365;
			}
			throw new ArgumentNullException(#Phc.#3hc(num2));
		}
	}
}
