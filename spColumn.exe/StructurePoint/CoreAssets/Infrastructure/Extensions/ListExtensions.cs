using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;
using #o1d;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.Infrastructure.Extensions
{
	// Token: 0x02000EEF RID: 3823
	public static class ListExtensions
	{
		// Token: 0x06008752 RID: 34642 RVA: 0x0006E041 File Offset: 0x0006C241
		public static void #DE<#Fu>(this IList<#Fu> #7p, Comparison<#Fu> #41d)
		{
			ArrayList arrayList = ArrayList.Adapter((IList)#7p);
			IComparer comparer = new #E9h<!!0>(#41d);
			if (7 != 0)
			{
				arrayList.Sort(comparer);
			}
		}

		// Token: 0x06008753 RID: 34643 RVA: 0x001D0420 File Offset: 0x001CE620
		public static void #DE<#Fu>(this IList<#Fu> #7p) where #Fu : IComparable<!!0>
		{
			if (4 != 0)
			{
				Comparison<#Fu> comparison = new Comparison<!!0>(ListExtensions.<>c__1<!!0>.<>9.#L9h);
				Comparison<#Fu> comparison2;
				if (!false)
				{
					comparison2 = comparison;
				}
				Comparison<#Fu> #41d = comparison2;
				if (!false)
				{
					#7p.#DE(#41d);
				}
			}
		}

		// Token: 0x06008754 RID: 34644 RVA: 0x001D0464 File Offset: 0x001CE664
		public static int #01d<#Fu>(this IList<#Fu> #7p, Func<#Fu, int> #AC)
		{
			string #R0d = #Phc.#3hc(107467337);
			Component #x6c = Component.Infrastructure;
			string #Qic = #Phc.#3hc(107225519);
			if (6 != 0)
			{
				#X0d.#V0d(#7p, #R0d, #x6c, #Qic);
			}
			int num2;
			int num4;
			if (!false)
			{
				string #R0d2 = #Phc.#3hc(107225498);
				Component #x6c2 = Component.Infrastructure;
				string #Qic2 = #Phc.#3hc(107225453);
				if (8 != 0)
				{
					#X0d.#V0d(#AC, #R0d2, #x6c2, #Qic2);
				}
				int num = 0;
				if (5 != 0)
				{
					num2 = num;
				}
				int num3 = #7p.Count - 1;
				if (5 != 0)
				{
					num4 = num3;
				}
				goto IL_86;
			}
			IL_78:
			int num6;
			int num5 = num6;
			IL_79:
			int num7;
			if (num5 < 0)
			{
				num2 = num7 + 1;
				goto IL_86;
			}
			IL_82:
			num4 = num7 - 1;
			IL_86:
			if (!true)
			{
				goto IL_82;
			}
			int num9;
			if (num2 > num4)
			{
				int num8 = num9 = num2;
				if (4 != 0)
				{
					return ~num8;
				}
			}
			else
			{
				num9 = num2;
			}
			int num10 = num5 = (num9 + num4) / 2;
			if (4 == 0)
			{
				goto IL_79;
			}
			if (4 != 0)
			{
				num7 = num10;
			}
			int num11 = #AC(#7p[num7]);
			if (3 != 0)
			{
				num6 = num11;
			}
			if (num6 == 0)
			{
				return num7;
			}
			goto IL_78;
		}

		// Token: 0x06008755 RID: 34645 RVA: 0x001D0528 File Offset: 0x001CE728
		public static int #01d<#Fu>(IList<#Fu> #7p, Func<#Fu, int, int> #AC)
		{
			string #R0d = #Phc.#3hc(107467337);
			Component #x6c = Component.Infrastructure;
			string #Qic = #Phc.#3hc(107225432);
			if (true)
			{
				#X0d.#V0d(#7p, #R0d, #x6c, #Qic);
			}
			int num2;
			int num4;
			if (7 != 0)
			{
				string #R0d2 = #Phc.#3hc(107225498);
				Component #x6c2 = Component.Infrastructure;
				string #Qic2 = #Phc.#3hc(107225347);
				if (3 != 0)
				{
					#X0d.#V0d(#AC, #R0d2, #x6c2, #Qic2);
				}
				int num = 0;
				if (!false)
				{
					num2 = num;
				}
				if (7 != 0)
				{
					int num3 = #7p.Count - 1;
					if (!false)
					{
						num4 = num3;
					}
				}
			}
			int num10;
			for (;;)
			{
				int num6;
				int num5 = num6 = num2;
				int num8;
				int num7 = num8 = num4;
				if (!false)
				{
					if (num5 > num7)
					{
						goto Block_6;
					}
					num6 = num2 + num4;
					num8 = 2;
				}
				int num9 = num6 / num8;
				if (8 != 0)
				{
					num10 = num9;
				}
				if (6 == 0)
				{
					break;
				}
				int num11 = #AC(#7p[num10], num10);
				int num12;
				if (2 != 0)
				{
					num12 = num11;
				}
				if (num12 == 0)
				{
					break;
				}
				if (num12 < 0)
				{
					num2 = num10 + 1;
				}
				else
				{
					num4 = num10 - 1;
				}
			}
			return num10;
			Block_6:
			return ~num2;
		}

		// Token: 0x06008756 RID: 34646 RVA: 0x001D05F0 File Offset: 0x001CE7F0
		public static int #11d<#Fu>(this IList<#Fu> #7p, #Fu #21d) where #Fu : IComparable<!!0>
		{
			ListExtensions<!!0>.#lcd #lcd = new ListExtensions<!!0>.#lcd();
			#lcd.#a = #21d;
			#lcd.#c = #7p;
			#X0d.#V0d(#lcd.#c, #Phc.#3hc(107467337), Component.Infrastructure, #Phc.#3hc(107224782));
			#lcd.#b = #lcd.#c.Count - 1;
			Func<#Fu, int, int> func = new Func<!!0, int, int>(#lcd.#J4d);
			Func<#Fu, int, int> #AC;
			if (!false)
			{
				#AC = func;
			}
			return ListExtensions.#01d<#Fu>(#lcd.#c, #AC);
		}

		// Token: 0x06008757 RID: 34647 RVA: 0x001D0664 File Offset: 0x001CE864
		public static void #pR<#Fu>(this IList<#Fu> #7p, params #Fu[] #8f)
		{
			List<#Fu> list2;
			for (;;)
			{
				if (!true)
				{
					goto IL_55;
				}
				string #R0d = #Phc.#3hc(107467337);
				Component #x6c = Component.Infrastructure;
				string #Qic = #Phc.#3hc(107224761);
				if (!false)
				{
					#X0d.#V0d(#7p, #R0d, #x6c, #Qic);
				}
				int num2;
				if (#8f != null)
				{
					List<#Fu> list = #7p as List<!!0>;
					if (5 != 0)
					{
						list2 = list;
					}
					if (list2 != null)
					{
						break;
					}
					if (false)
					{
					}
					if (8 == 0)
					{
						goto IL_5C;
					}
					int num = 0;
					if (4 != 0)
					{
						num2 = num;
					}
					if (!false)
					{
						goto IL_60;
					}
					goto IL_55;
				}
				IL_66:
				if (7 != 0)
				{
					return;
				}
				continue;
				IL_60:
				if (num2 >= #8f.Length)
				{
					goto IL_66;
				}
				#Fu #Fu = #8f[num2];
				if (false)
				{
					goto IL_55;
				}
				#Fu item = #Fu;
				goto IL_55;
				IL_5C:
				num2++;
				goto IL_60;
				IL_55:
				#7p.Add(item);
				goto IL_5C;
			}
			List<!!0> list3 = list2;
			if (!false)
			{
				list3.AddRange(#8f);
			}
		}

		// Token: 0x06008758 RID: 34648 RVA: 0x001D06F8 File Offset: 0x001CE8F8
		public static void #pR<#Fu>(this IList<#Fu> #7p, params ICollection<#Fu>[] #8f)
		{
			string #R0d = #Phc.#3hc(107467337);
			Component #x6c = Component.Infrastructure;
			string #Qic = #Phc.#3hc(107224676);
			if (!false)
			{
				#X0d.#V0d(#7p, #R0d, #x6c, #Qic);
			}
			List<#Fu> list = #7p as List<!!0>;
			List<#Fu> list2;
			if (-1 != 0)
			{
				list2 = list;
			}
			if (list2 != null)
			{
				Action<ICollection<#Fu>> #nd = new Action<ICollection<!!0>>(list2.AddRange);
				if (!false)
				{
					#8f.#I1d(#nd);
				}
				return;
			}
			if (#7p != null)
			{
				IEnumerable<#Fu> #H1d = #8f.SelectMany(new Func<ICollection<!!0>, IEnumerable<!!0>>(ListExtensions.<>c__6<!!0>.<>9.#M9h));
				Action<#Fu> #nd2 = new Action<!!0>(#7p.Add);
				if (!false)
				{
					#H1d.#I1d(#nd2);
				}
			}
		}

		// Token: 0x06008759 RID: 34649 RVA: 0x001D0794 File Offset: 0x001CE994
		public static void #F7c<#Fu>(this IList<#Fu> #7p, IEnumerable<#Fu> #8f)
		{
			if (!false && -1 != 0)
			{
				string #R0d = #Phc.#3hc(107264273);
				Component #x6c = Component.Infrastructure;
				string #Qic = #Phc.#3hc(107224623);
				if (!false)
				{
					#X0d.#V0d(#8f, #R0d, #x6c, #Qic);
				}
			}
			string #R0d2 = #Phc.#3hc(107467337);
			Component #x6c2 = Component.Infrastructure;
			string #Qic2 = #Phc.#3hc(107224602);
			if (8 != 0)
			{
				#X0d.#V0d(#7p, #R0d2, #x6c2, #Qic2);
			}
			IEnumerator<#Fu> enumerator = #8f.GetEnumerator();
			IEnumerator<#Fu> enumerator2;
			if (true)
			{
				enumerator2 = enumerator;
			}
			try
			{
				for (;;)
				{
					bool flag = enumerator2.MoveNext();
					if (4 != 0)
					{
						if (!flag)
						{
							break;
						}
						#Fu #Fu = enumerator2.Current;
						#Fu item;
						if (-1 != 0)
						{
							item = #Fu;
						}
						#7p.Remove(item);
					}
				}
			}
			finally
			{
				if (enumerator2 != null && 5 != 0)
				{
					enumerator2.Dispose();
				}
			}
		}

		// Token: 0x0600875A RID: 34650 RVA: 0x001D0840 File Offset: 0x001CEA40
		public static void #vzc(this IList<Point3D> #BP, double #QHb, double #RHb, double #xsc)
		{
			if (4 != 0)
			{
				string #R0d = #Phc.#3hc(107358670);
				Component #x6c = Component.Infrastructure;
				string #Qic = #Phc.#3hc(107225029);
				if (6 != 0)
				{
					#X0d.#V0d(#BP, #R0d, #x6c, #Qic);
				}
				if (!false)
				{
					Point3D item = new Point3D(#QHb, #RHb, #xsc);
					if (!false)
					{
						#BP.Add(item);
					}
				}
			}
		}

		// Token: 0x0600875B RID: 34651 RVA: 0x0006E060 File Offset: 0x0006C260
		public static bool #K6c<#Fu>(this ICollection<#Fu> #Du, int #4jb)
		{
			string #R0d = #Phc.#3hc(107420761);
			Component #x6c = Component.Infrastructure;
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
				goto IL_2E;
			}
			if (#4jb < num2 || !true)
			{
				return false;
			}
			num = #4jb;
			IL_28:
			num3 = #Du.Count;
			IL_2E:
			bool result = (num = ((num < num3) ? 1 : 0)) != 0;
			if (8 != 0)
			{
				return result;
			}
			goto IL_28;
		}

		// Token: 0x0600875C RID: 34652 RVA: 0x0006E060 File Offset: 0x0006C260
		public static bool #K6c<#Fu>(this IList<#Fu> #Du, int #4jb)
		{
			string #R0d = #Phc.#3hc(107420761);
			Component #x6c = Component.Infrastructure;
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
				goto IL_2E;
			}
			if (#4jb < num2 || !true)
			{
				return false;
			}
			num = #4jb;
			IL_28:
			num3 = #Du.Count;
			IL_2E:
			bool result = (num = ((num < num3) ? 1 : 0)) != 0;
			if (8 != 0)
			{
				return result;
			}
			goto IL_28;
		}

		// Token: 0x0600875D RID: 34653 RVA: 0x001D088C File Offset: 0x001CEA8C
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public static void #31d<#Zoc>(this List<#Zoc> #7p, Comparison<#Zoc> #41d)
		{
			string #R0d = #Phc.#3hc(107467337);
			Component #x6c = Component.Infrastructure;
			string #Qic = #Phc.#3hc(107225008);
			if (!false)
			{
				#X0d.#V0d(#7p, #R0d, #x6c, #Qic);
			}
			string #R0d2 = #Phc.#3hc(107224955);
			Component #x6c2 = Component.Infrastructure;
			string #Qic2 = #Phc.#3hc(107224906);
			if (7 != 0)
			{
				#X0d.#V0d(#41d, #R0d2, #x6c2, #Qic2);
			}
			int num2;
			if (true)
			{
				if (2 != 0)
				{
					int num = 0;
					if (3 != 0)
					{
						num2 = num;
					}
				}
				int num4;
				int num3 = num4 = 0;
				if (num3 != 0)
				{
					goto IL_91;
				}
				int num5;
				if (!false)
				{
					num5 = num3;
				}
				IL_90:
				num4 = num5;
				IL_91:
				if (num4 < #7p.Count)
				{
					if (num5 == 0)
					{
						goto IL_73;
					}
					int num6 = #41d(#7p[num2 - 1], #7p[num5]);
					IL_71:
					if (num6 == 0)
					{
						goto IL_89;
					}
					IL_73:
					int num7 = num2;
					int num8 = num7 + 1;
					if (!false)
					{
						num2 = num8;
					}
					!!0 value = #7p[num5];
					if (!false)
					{
						#7p[num7] = value;
					}
					IL_89:
					int num9 = num6 = num5;
					if (5 != 0)
					{
						num5 = num9 + 1;
						goto IL_90;
					}
					goto IL_71;
				}
			}
			#7p.RemoveRange(num2, #7p.Count - num2);
		}

		// Token: 0x0600875E RID: 34654 RVA: 0x001D096C File Offset: 0x001CEB6C
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public static void #31d<#Zoc>(this List<#Zoc> #7p, Func<#Zoc, #Zoc, bool> #41d)
		{
			string #R0d = #Phc.#3hc(107467337);
			Component #x6c = Component.Infrastructure;
			string #Qic = #Phc.#3hc(107225008);
			if (!false)
			{
				#X0d.#V0d(#7p, #R0d, #x6c, #Qic);
			}
			string #R0d2 = #Phc.#3hc(107224955);
			Component #x6c2 = Component.Infrastructure;
			string #Qic2 = #Phc.#3hc(107224906);
			if (7 != 0)
			{
				#X0d.#V0d(#41d, #R0d2, #x6c2, #Qic2);
			}
			int num2;
			if (true)
			{
				if (2 != 0)
				{
					int num = 0;
					if (3 != 0)
					{
						num2 = num;
					}
				}
				int num4;
				int num3 = num4 = 0;
				if (num3 != 0)
				{
					goto IL_91;
				}
				int num5;
				if (!false)
				{
					num5 = num3;
				}
				IL_90:
				num4 = num5;
				IL_91:
				if (num4 < #7p.Count)
				{
					int num6 = num5;
					int num9;
					do
					{
						if (num6 == 0 || !#41d(#7p[num2 - 1], #7p[num5]))
						{
							int num7 = num2;
							int num8 = num7 + 1;
							if (!false)
							{
								num2 = num8;
							}
							!!0 value = #7p[num5];
							if (!false)
							{
								#7p[num7] = value;
							}
						}
						num9 = (num6 = num5);
					}
					while (5 == 0);
					num5 = num9 + 1;
					goto IL_90;
				}
			}
			#7p.RemoveRange(num2, #7p.Count - num2);
		}

		// Token: 0x0600875F RID: 34655 RVA: 0x001D0A4C File Offset: 0x001CEC4C
		public static void #31d<#Zoc>(this List<#Zoc> #7p) where #Zoc : IComparable<!!0>
		{
			string #R0d = #Phc.#3hc(107467337);
			Component #x6c = Component.Infrastructure;
			string #Qic = #Phc.#3hc(107225008);
			if (7 != 0)
			{
				#X0d.#V0d(#7p, #R0d, #x6c, #Qic);
			}
			int num = 0;
			int num2;
			if (!false)
			{
				num2 = num;
			}
			int num3 = 0;
			int i;
			if (!false)
			{
				i = num3;
			}
			while (i < #7p.Count)
			{
				if (i == 0)
				{
					goto IL_55;
				}
				#Zoc #Zoc = #7p[num2 - 1];
				#Zoc #Zoc2;
				if (7 != 0)
				{
					#Zoc2 = #Zoc;
				}
				if (#Zoc2.CompareTo(#7p[i]) != 0)
				{
					goto IL_55;
				}
				IL_6B:
				i++;
				continue;
				IL_55:
				int num4 = num2;
				int num5 = num4 + 1;
				if (-1 != 0)
				{
					num2 = num5;
				}
				!!0 value = #7p[i];
				if (!true)
				{
					goto IL_6B;
				}
				#7p[num4] = value;
				goto IL_6B;
			}
			#7p.RemoveRange(num2, #7p.Count - num2);
		}

		// Token: 0x06008760 RID: 34656 RVA: 0x001D0B04 File Offset: 0x001CED04
		public static void #mbb<#Fu>(this IList<#Fu> #8f, int #Akb, Action<#Fu> #nd)
		{
			int num = #Akb;
			for (;;)
			{
				IL_01:
				int num2;
				if (!false)
				{
					num2 = num;
				}
				for (;;)
				{
					IL_24:
					int i = num2;
					int num3 = #8f.Count;
					while (i < num3)
					{
						!!0 obj = #8f[num2];
						if (2 != 0)
						{
							#nd(obj);
						}
						if (false)
						{
							break;
						}
						int num4 = i = num2;
						int num5 = num3 = 1;
						if (num5 != 0)
						{
							int num6 = num = num4 + num5;
							if (3 == 0)
							{
								goto IL_01;
							}
							if (false)
							{
								goto IL_24;
							}
							num2 = num6;
							goto IL_24;
						}
					}
					return;
				}
			}
		}

		// Token: 0x06008761 RID: 34657 RVA: 0x001D0B4C File Offset: 0x001CED4C
		public static bool #51d<#Fu>(this IEnumerable<#Fu> #8f, Func<#Fu, bool> #4Xd)
		{
			if (#8f == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107264273));
			}
			if (#4Xd == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107228008));
			}
			bool flag = false;
			bool flag2;
			if (!false)
			{
				flag2 = flag;
			}
			IEnumerator<#Fu> enumerator = #8f.GetEnumerator();
			IEnumerator<#Fu> enumerator2;
			if (!false)
			{
				enumerator2 = enumerator;
				goto IL_35;
			}
			try
			{
				for (;;)
				{
					IL_35:
					while (!false)
					{
						if (!enumerator2.MoveNext())
						{
							goto Block_5;
						}
						#Fu #Fu = enumerator2.Current;
						#Fu arg;
						if (!false)
						{
							arg = #Fu;
						}
						bool flag3 = #4Xd(arg);
						bool flag4;
						if (5 != 0)
						{
							flag4 = flag3;
						}
						bool flag5 = flag2 || flag4;
						if (!false)
						{
							flag2 = flag5;
						}
					}
				}
				Block_5:;
			}
			finally
			{
				if (-1 != 0 && enumerator2 != null)
				{
					enumerator2.Dispose();
				}
			}
			return flag2;
		}

		// Token: 0x06008762 RID: 34658 RVA: 0x0006E09E File Offset: 0x0006C29E
		public static void #61d<#Fu>(this IList<#Fu> #8f)
		{
			int num;
			if (#8f == null)
			{
				num = 107264273;
			}
			else
			{
				int num2 = num = #8f.Count;
				if (!false)
				{
					if (num2 > 0 && true)
					{
						int index = #8f.Count - 1;
						if (!false)
						{
							#8f.RemoveAt(index);
						}
					}
					return;
				}
			}
			throw new ArgumentNullException(#Phc.#3hc(num));
		}

		// Token: 0x06008763 RID: 34659 RVA: 0x001D0BE8 File Offset: 0x001CEDE8
		public static void #71d<#Fu, #Zoc>(this IList<#Fu> #6W, ICollection<#Zoc> #8f) where #Zoc : !!0
		{
			if (#6W == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107416106));
			}
			if (#8f == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107264273));
			}
			if (#8f.Count <= 0)
			{
				return;
			}
			HashSet<#Fu> hashSet = new HashSet<!!0>();
			HashSet<#Fu> hashSet2;
			if (!false)
			{
				hashSet2 = hashSet;
			}
			IEnumerator<#Zoc> enumerator = #8f.GetEnumerator();
			IEnumerator<#Zoc> enumerator2;
			if (8 != 0)
			{
				enumerator2 = enumerator;
			}
			try
			{
				for (;;)
				{
					IL_67:
					bool flag = enumerator2.MoveNext();
					while (flag)
					{
						#Zoc #Zoc = enumerator2.Current;
						#Zoc #Zoc2;
						if (!false)
						{
							#Zoc2 = #Zoc;
						}
						flag = hashSet2.Add((!!0)((object)#Zoc2));
						if (8 != 0)
						{
							goto IL_67;
						}
					}
					break;
				}
			}
			finally
			{
				if (enumerator2 == null)
				{
					goto IL_80;
				}
				IL_77:
				if (!false)
				{
					enumerator2.Dispose();
				}
				IL_80:
				if (8 == 0)
				{
					goto IL_77;
				}
			}
			int num2;
			int num = num2 = #6W.Count;
			if (!false)
			{
				num2 = num - 1;
			}
			int i;
			if (2 != 0)
			{
				i = num2;
			}
			while (i >= 0)
			{
				if (hashSet2.Contains(#6W[i]))
				{
					int index = i;
					if (!false)
					{
						#6W.RemoveAt(index);
					}
				}
				int num3 = i - 1;
				if (-1 != 0)
				{
					i = num3;
				}
			}
		}

		// Token: 0x06008764 RID: 34660 RVA: 0x001D0CD4 File Offset: 0x001CEED4
		public static void #71d<#Fu>(this IList<#Fu> #6W, ISet<#Fu> #8f)
		{
			if (!true)
			{
				goto IL_60;
			}
			if (#6W == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107416106));
			}
			if (#8f == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107264273));
			}
			if (#8f.Count <= 0)
			{
				return;
			}
			int num2;
			int num = num2 = #6W.Count;
			int num4;
			int num3 = num4 = 1;
			if (num3 == 0)
			{
				goto IL_69;
			}
			num4 = num3;
			if (num3 == 0)
			{
				goto IL_69;
			}
			int num5 = num - num3;
			int num6;
			if (8 != 0)
			{
				num6 = num5;
			}
			if (!false)
			{
				goto IL_67;
			}
			IL_59:
			int index = num6;
			if (6 != 0)
			{
				#6W.RemoveAt(index);
			}
			IL_60:
			int num7 = num6 - 1;
			if (!false)
			{
				num6 = num7;
			}
			IL_67:
			num2 = num6;
			num4 = 0;
			IL_69:
			if (num2 < num4)
			{
				return;
			}
			if (#8f.Contains(#6W[num6]))
			{
				goto IL_59;
			}
			goto IL_60;
		}

		// Token: 0x06008765 RID: 34661 RVA: 0x001D0D5C File Offset: 0x001CEF5C
		public static void #81d<#Fu>(this List<#Fu> #6W, ISet<#Fu> #8f)
		{
			int num;
			if (#6W != null)
			{
				if (#8f == null)
				{
					num = 107264273;
					goto IL_1E;
				}
				if (!false)
				{
					Predicate<#Fu> #Q5c = new Predicate<!!0>(#8f.Contains);
					if (6 != 0)
					{
						#6W.#81d(#Q5c);
					}
					if (!false)
					{
						return;
					}
				}
			}
			int num2 = num = 107416106;
			if (num2 != 0)
			{
				throw new ArgumentNullException(#Phc.#3hc(num2));
			}
			IL_1E:
			throw new ArgumentNullException(#Phc.#3hc(num));
		}

		// Token: 0x06008766 RID: 34662 RVA: 0x001D0DB4 File Offset: 0x001CEFB4
		public static void #81d<#Fu, #Zoc>(this List<#Fu> #6W, ICollection<#Zoc> #8f) where #Zoc : !!0
		{
			ListExtensions<#Fu, #Zoc>.#N9h #N9h = new ListExtensions<!!0, !!1>.#N9h();
			ListExtensions<#Fu, #Zoc>.#N9h #N9h2;
			if (!false)
			{
				#N9h2 = #N9h;
			}
			int num;
			if (#6W == null)
			{
				num = 107416106;
			}
			else
			{
				if (#8f != null)
				{
					if (#8f.Count <= 0)
					{
						if (!false)
						{
							return;
						}
					}
					else
					{
						#N9h2.#a = new HashSet<!!0>();
					}
					IEnumerator<#Zoc> enumerator = #8f.GetEnumerator();
					IEnumerator<#Zoc> enumerator2;
					if (5 != 0)
					{
						enumerator2 = enumerator;
					}
					try
					{
						for (;;)
						{
							bool flag = enumerator2.MoveNext();
							if (!false)
							{
								if (!flag)
								{
									break;
								}
								#Zoc #Zoc = enumerator2.Current;
								#Zoc #Zoc2;
								if (-1 != 0)
								{
									#Zoc2 = #Zoc;
								}
								#N9h2.#a.Add((!!0)((object)#Zoc2));
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
						while (-1 == 0);
					}
					Predicate<#Fu> #Q5c = new Predicate<!!0>(#N9h2.#L4d);
					if (!false)
					{
						#6W.#81d(#Q5c);
					}
					return;
				}
				int num2 = num = 107264273;
				if (num2 != 0)
				{
					throw new ArgumentNullException(#Phc.#3hc(num2));
				}
			}
			throw new ArgumentNullException(#Phc.#3hc(num));
		}

		// Token: 0x06008767 RID: 34663 RVA: 0x001D0E8C File Offset: 0x001CF08C
		public static void #81d<#Fu>(this List<#Fu> #8f, Predicate<#Fu> #Q5c)
		{
			while (!false && (-1 == 0 || #8f != null))
			{
				if (6 != 0)
				{
					int num;
					if (#Q5c == null)
					{
						num = 107266010;
					}
					else
					{
						if (#8f.Count <= 0)
						{
							return;
						}
						LinkedList<#Fu> linkedList = new LinkedList<!!0>(#8f);
						LinkedList<#Fu> linkedList2;
						if (!false)
						{
							linkedList2 = linkedList;
						}
						num = linkedList2.#91d(#Q5c);
						if (5 != 0)
						{
							if (linkedList2.Count != #8f.Count)
							{
								if (!false)
								{
									#8f.Clear();
								}
								IEnumerable<!!0> collection = linkedList2;
								if (8 != 0)
								{
									#8f.AddRange(collection);
								}
							}
							return;
						}
					}
					throw new ArgumentNullException(#Phc.#3hc(num));
				}
			}
			throw new ArgumentNullException(#Phc.#3hc(107264273));
		}

		// Token: 0x06008768 RID: 34664 RVA: 0x001D0F14 File Offset: 0x001CF114
		public static int #91d<#Fu>(this LinkedList<#Fu> #7p, Predicate<#Fu> #a2d)
		{
			if (#7p == null)
			{
				if (4 != 0)
				{
					throw new ArgumentNullException(#Phc.#3hc(107467337));
				}
				goto IL_3A;
			}
			else if (#a2d == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107224885));
			}
			IL_29:
			int num = 0;
			int num2;
			if (!false)
			{
				num2 = num;
			}
			LinkedListNode<#Fu> first = #7p.First;
			LinkedListNode<#Fu> linkedListNode;
			if (!false)
			{
				linkedListNode = first;
			}
			goto IL_60;
			IL_3A:
			LinkedListNode<#Fu> next = linkedListNode.Next;
			if (#a2d(linkedListNode.Value))
			{
				LinkedListNode<!!0> node = linkedListNode;
				if (!false)
				{
					#7p.Remove(node);
				}
				int num3 = num2 + 1;
				if (!false)
				{
					num2 = num3;
				}
			}
			if (6 != 0)
			{
				linkedListNode = next;
			}
			IL_60:
			if (!false)
			{
				if (false)
				{
					goto IL_29;
				}
				if (linkedListNode != null)
				{
					goto IL_3A;
				}
			}
			return num2;
		}

		// Token: 0x06008769 RID: 34665 RVA: 0x001D0FA0 File Offset: 0x001CF1A0
		public static bool #71d<#Fu>(this IList<#Fu> #8f, Predicate<#Fu> #Q5c)
		{
			if (#8f != null)
			{
				if (#Q5c == null)
				{
					throw new ArgumentNullException(#Phc.#3hc(107266010));
				}
				bool flag = false;
				bool result;
				if (2 != 0)
				{
					result = flag;
				}
				int num = #8f.Count;
				int num2 = 1;
				for (;;)
				{
					IL_32:
					int num3 = num - num2;
					int num4;
					if (!false)
					{
						num4 = num3;
					}
					for (;;)
					{
						int num5 = num = num4;
						int num6 = 0;
						int num9;
						int num10;
						for (;;)
						{
							int num7 = num2 = num6;
							if (num7 != 0)
							{
								goto IL_32;
							}
							if (num5 < num7)
							{
								return result;
							}
							if (!#Q5c(#8f[num4]))
							{
								goto IL_5A;
							}
							int index = num4;
							if (!false)
							{
								#8f.RemoveAt(index);
							}
							if (false)
							{
								goto IL_03;
							}
							int num8 = num = (num9 = (num5 = 1));
							if (num8 != 0)
							{
								if (false)
								{
									goto IL_5A;
								}
								result = (num8 != 0);
								goto IL_5A;
							}
							IL_5B:
							num10 = (num6 = 1);
							if (num10 != 0)
							{
								break;
							}
							continue;
							IL_5A:
							num9 = (num = (num5 = num4));
							goto IL_5B;
						}
						int num11 = num9 - num10;
						if (5 != 0)
						{
							num4 = num11;
						}
					}
				}
				return result;
			}
			IL_03:
			throw new ArgumentNullException(#Phc.#3hc(107264273));
		}

		// Token: 0x0600876A RID: 34666 RVA: 0x001D102C File Offset: 0x001CF22C
		public static bool #b2d<#Fu>(this IEnumerable<#Fu> #c2d, IEnumerable<#Fu> #d2d)
		{
			HashSet<!!0> hashSet = new HashSet<!!0>(#c2d ?? new !!0[0]);
			HashSet<#Fu> hashSet2 = new HashSet<!!0>(#d2d ?? new !!0[0]);
			HashSet<#Fu> equals;
			if (2 != 0)
			{
				equals = hashSet2;
			}
			return hashSet.SetEquals(equals);
		}

		// Token: 0x0600876B RID: 34667 RVA: 0x0006E0D7 File Offset: 0x0006C2D7
		public static int #e2d(this IList #7p, int #4jb)
		{
			int num = #4jb;
			int num5;
			do
			{
				int num3;
				int num2 = num3 = #7p.Count;
				if (!false)
				{
					num3 = num2 - 1;
				}
				int num4;
				if (num == num3)
				{
					num4 = 0;
				}
				else
				{
					int result = num4 = #4jb + 1;
					if (!false)
					{
						return result;
					}
				}
				num5 = (num = num4);
			}
			while (num5 != 0);
			return num5;
		}

		// Token: 0x0600876C RID: 34668 RVA: 0x0006E0F2 File Offset: 0x0006C2F2
		public static int #f2d(this IList #7p, int #4jb)
		{
			int num = #4jb;
			int num2 = #4jb;
			int num3;
			if (8 != 0)
			{
				if (#4jb != 0)
				{
					num = #4jb;
					num3 = 1;
					goto IL_17;
				}
				num = (num2 = #7p.Count);
			}
			int num4 = num3 = 1;
			if (num4 != 0)
			{
				num3 = num4;
				if (num4 != 0)
				{
					return num2 - num4;
				}
			}
			IL_17:
			return num - num3;
		}

		// Token: 0x0600876D RID: 34669 RVA: 0x0006E10C File Offset: 0x0006C30C
		public static int #e2d<#Fu>(this IList<#Fu> #7p, int #4jb)
		{
			int num = #4jb;
			int num5;
			do
			{
				int num3;
				int num2 = num3 = #7p.Count;
				if (!false)
				{
					num3 = num2 - 1;
				}
				int num4;
				if (num == num3)
				{
					num4 = 0;
				}
				else
				{
					int result = num4 = #4jb + 1;
					if (!false)
					{
						return result;
					}
				}
				num5 = (num = num4);
			}
			while (num5 != 0);
			return num5;
		}

		// Token: 0x0600876E RID: 34670 RVA: 0x0006E127 File Offset: 0x0006C327
		public static int #f2d<#Fu>(this IList<#Fu> #7p, int #4jb)
		{
			int num = #4jb;
			int num2 = #4jb;
			int num3;
			if (8 != 0)
			{
				if (#4jb != 0)
				{
					num = #4jb;
					num3 = 1;
					goto IL_17;
				}
				num = (num2 = #7p.Count);
			}
			int num4 = num3 = 1;
			if (num4 != 0)
			{
				num3 = num4;
				if (num4 != 0)
				{
					return num2 - num4;
				}
			}
			IL_17:
			return num - num3;
		}

		// Token: 0x0600876F RID: 34671 RVA: 0x0006E141 File Offset: 0x0006C341
		public static IList<#Fu> #Mmc<#Fu>(this IList<#Fu> #7p, int #sP)
		{
			return #7p.Skip(#sP).Concat(#7p.Take(#sP)).ToList<#Fu>();
		}

		// Token: 0x06008770 RID: 34672 RVA: 0x001D1068 File Offset: 0x001CF268
		public static void #27c<#Fu>(this IList<#Fu> #7p, #Fu #x3c, #Fu #y3c, bool #g2d = true)
		{
			int num;
			int num3;
			if (#7p != null && !false)
			{
				num = 0;
			}
			else
			{
				if (false)
				{
					goto IL_52;
				}
				int num2 = num3 = 107467337;
				if (num2 != 0)
				{
					throw new ArgumentNullException(#Phc.#3hc(num2));
				}
				goto IL_49;
			}
			IL_1D:
			int num4;
			if (2 != 0)
			{
				num4 = num;
			}
			goto IL_52;
			IL_49:
			if (num3 == 0)
			{
				return;
			}
			IL_4B:
			int num5 = num4 + 1;
			if (!false)
			{
				num4 = num5;
			}
			IL_52:
			if (num4 < #7p.Count)
			{
				bool flag = (num = (object.Equals(#7p[num4], #x3c) ? 1 : 0)) != 0;
				if (false)
				{
					goto IL_1D;
				}
				if (flag)
				{
					int index = num4;
					if (!false)
					{
						#7p[index] = #y3c;
					}
					num3 = (#g2d ? 1 : 0);
					goto IL_49;
				}
				goto IL_4B;
			}
		}

		// Token: 0x06008771 RID: 34673 RVA: 0x001D10E0 File Offset: 0x001CF2E0
		public static IList<#Fu> #h2d<#Fu>(this IList<#Fu> #7p)
		{
			int num;
			for (;;)
			{
				int num2;
				if (#7p == null)
				{
					num = (num2 = 107467337);
					if (num != 0)
					{
						break;
					}
				}
				else
				{
					num2 = #7p.Count;
				}
				if (num2 <= 0)
				{
					goto IL_29;
				}
				if (-1 != 0)
				{
					goto Block_3;
				}
			}
			throw new ArgumentNullException(#Phc.#3hc(num));
			Block_3:
			int index = 0;
			if (5 != 0)
			{
				#7p.RemoveAt(index);
			}
			IL_29:
			if (#7p.Count > 0 && 4 != 0)
			{
				int index2 = #7p.Count - 1;
				if (4 != 0)
				{
					#7p.RemoveAt(index2);
				}
			}
			return #7p;
		}

		// Token: 0x06008772 RID: 34674 RVA: 0x001D1140 File Offset: 0x001CF340
		public static bool #uC<#Fu>(IList<#Fu> #c2d, IList<#Fu> #d2d) where #Fu : IComparable
		{
			if (#c2d != null || #d2d != null)
			{
				int result;
				if (#c2d != null)
				{
					while (#d2d != null)
					{
						if (#c2d.Count == #d2d.Count)
						{
							int num = 0;
							int num2;
							if (!false)
							{
								num2 = num;
							}
							for (;;)
							{
								#Fu #Fu2;
								if (num2 >= #c2d.Count)
								{
									if (4 != 0)
									{
										return true;
									}
								}
								else
								{
									#Fu #Fu = #c2d[num2];
									if (!false)
									{
										#Fu2 = #Fu;
									}
								}
								if (#Fu2.CompareTo(#d2d[num2]) != 0)
								{
									break;
								}
								int num3 = num2 + 1;
								if (8 != 0)
								{
									num2 = num3;
								}
							}
							if (3 != 0)
							{
								return false;
							}
							continue;
						}
						int num4 = result = 0;
						if (num4 == 0)
						{
							return num4 != 0;
						}
						return result != 0;
					}
				}
				if (false)
				{
					return true;
				}
				result = 0;
				return result != 0;
			}
			return true;
		}

		// Token: 0x02000EF2 RID: 3826
		[CompilerGenerated]
		private sealed class #N9h<#Fu, #Zoc> where #Zoc : !0
		{
			// Token: 0x0600877A RID: 34682 RVA: 0x0006E183 File Offset: 0x0006C383
			internal bool #L4d(#Fu #Rf)
			{
				return this.#a.Contains(#Rf);
			}

			// Token: 0x040037FA RID: 14330
			public HashSet<#Fu> #a;
		}

		// Token: 0x02000EF3 RID: 3827
		[CompilerGenerated]
		private sealed class #lcd<#Fu> where #Fu : IComparable<!0>
		{
			// Token: 0x0600877C RID: 34684 RVA: 0x001D11C4 File Offset: 0x001CF3C4
			internal int #J4d(#Fu #Rf, int #4jb)
			{
				int result;
				if (#Rf.CompareTo(this.#a) <= 0)
				{
					int i = #4jb;
					int num = this.#b;
					while (i < num)
					{
						#Fu #Fu = this.#c[#4jb + 1];
						#Fu #Fu2;
						if (3 != 0)
						{
							#Fu2 = #Fu;
						}
						int num2 = i = #Fu2.CompareTo(this.#a);
						int num3 = num = 0;
						if (num3 == 0)
						{
							if (num2 <= num3)
							{
								IL_5A:
								if (false)
								{
									goto IL_62;
								}
								if (!false)
								{
									return -1;
								}
							}
							int num4 = result = 0;
							if (num4 == 0)
							{
								return num4;
							}
							return result;
						}
					}
					if (#4jb == this.#b)
					{
						return 0;
					}
					goto IL_5A;
				}
				IL_62:
				result = 1;
				return result;
			}

			// Token: 0x040037FB RID: 14331
			public #Fu #a;

			// Token: 0x040037FC RID: 14332
			public int #b;

			// Token: 0x040037FD RID: 14333
			public IList<#Fu> #c;
		}
	}
}
