using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.Infrastructure.Extensions
{
	// Token: 0x02000EF5 RID: 3829
	public static class StringExtensions
	{
		// Token: 0x06008780 RID: 34688 RVA: 0x001D1314 File Offset: 0x001CF514
		public static string #l2d(this string #f, int #1f)
		{
			int num2;
			int num3;
			int num4;
			if (#f == null)
			{
				int num = num2 = 107386484;
				if (num == 0)
				{
					goto IL_30;
				}
				num3 = num;
				if (num != 0)
				{
					throw new ArgumentNullException(#Phc.#3hc(num));
				}
				goto IL_3A;
			}
			else
			{
				num4 = 0;
			}
			IL_1A:
			int num5;
			if (5 != 0)
			{
				num5 = num4;
			}
			goto IL_39;
			IL_30:
			int num6 = num4 = num2 + 1;
			if (3 == 0)
			{
				goto IL_1A;
			}
			if (6 != 0)
			{
				num5 = num6;
			}
			IL_39:
			num3 = num5;
			IL_3A:
			if (num3 >= #1f)
			{
				return #f;
			}
			string text = #f + Environment.NewLine;
			if (!false)
			{
				#f = text;
			}
			num2 = num5;
			goto IL_30;
		}

		// Token: 0x06008781 RID: 34689 RVA: 0x0006E1AC File Offset: 0x0006C3AC
		public static string #m2d(this string #f)
		{
			return #f.#m2d(false);
		}

		// Token: 0x06008782 RID: 34690 RVA: 0x0006E1B5 File Offset: 0x0006C3B5
		public static string #m2d(this string #f, bool #n2d)
		{
			return #f.#P2d(#Phc.#3hc(107352984), #n2d);
		}

		// Token: 0x06008783 RID: 34691 RVA: 0x0006E1C8 File Offset: 0x0006C3C8
		public static string #o2d(this string #f)
		{
			return #f.#o2d(false);
		}

		// Token: 0x06008784 RID: 34692 RVA: 0x0006E1D1 File Offset: 0x0006C3D1
		public static string #o2d(this string #f, bool #n2d)
		{
			return #f.#P2d(#Phc.#3hc(107224249), #n2d);
		}

		// Token: 0x06008785 RID: 34693 RVA: 0x0006E1E4 File Offset: 0x0006C3E4
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Hashtag")]
		public static string #p2d(this string #f)
		{
			return #f.#p2d(false);
		}

		// Token: 0x06008786 RID: 34694 RVA: 0x0006E1ED File Offset: 0x0006C3ED
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Hashtag")]
		public static string #p2d(this string #f, bool #n2d)
		{
			return #f.#P2d(#Phc.#3hc(107224244), #n2d);
		}

		// Token: 0x06008787 RID: 34695 RVA: 0x0006E200 File Offset: 0x0006C400
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Hashtag")]
		public static string #q2d(this string #f)
		{
			return #f.#q2d(false);
		}

		// Token: 0x06008788 RID: 34696 RVA: 0x0006E209 File Offset: 0x0006C409
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Hashtag")]
		public static string #q2d(this string #f, bool #n2d)
		{
			return #f.#P2d(#Phc.#3hc(107378801), #n2d);
		}

		// Token: 0x06008789 RID: 34697 RVA: 0x0006E21C File Offset: 0x0006C41C
		public static string #r2d(this string #f)
		{
			return #f.#r2d(false);
		}

		// Token: 0x0600878A RID: 34698 RVA: 0x0006E225 File Offset: 0x0006C425
		public static string #r2d(this string #f, bool #n2d)
		{
			return #f.#P2d(#Phc.#3hc(107224207), #n2d);
		}

		// Token: 0x0600878B RID: 34699 RVA: 0x0006E238 File Offset: 0x0006C438
		public static string #s2d(this string #f)
		{
			return #f.#s2d(false);
		}

		// Token: 0x0600878C RID: 34700 RVA: 0x0006E241 File Offset: 0x0006C441
		public static string #s2d(this string #f, bool #n2d)
		{
			return #f.#P2d(#Phc.#3hc(107382694), #n2d);
		}

		// Token: 0x0600878D RID: 34701 RVA: 0x0006E254 File Offset: 0x0006C454
		public static string #t2d(this string #f)
		{
			return #f.#t2d(false);
		}

		// Token: 0x0600878E RID: 34702 RVA: 0x0006E25D File Offset: 0x0006C45D
		public static string #t2d(this string #f, bool #n2d)
		{
			return #f.#P2d(#Phc.#3hc(107413142), #n2d);
		}

		// Token: 0x0600878F RID: 34703 RVA: 0x0006E270 File Offset: 0x0006C470
		public static string #u2d(this string #f, bool #n2d)
		{
			return #f.#P2d(#Phc.#3hc(107224202), #n2d);
		}

		// Token: 0x06008790 RID: 34704 RVA: 0x0006E283 File Offset: 0x0006C483
		public static string #u2d(this string #f)
		{
			return #f.#u2d(false);
		}

		// Token: 0x06008791 RID: 34705 RVA: 0x0006E28C File Offset: 0x0006C48C
		public static string #v2d(this string #f, bool #n2d)
		{
			return #f.#P2d(#Phc.#3hc(107408397), #n2d);
		}

		// Token: 0x06008792 RID: 34706 RVA: 0x0006E29F File Offset: 0x0006C49F
		public static string #v2d(this string #f)
		{
			return #f.#v2d(false);
		}

		// Token: 0x06008793 RID: 34707 RVA: 0x0006E2A8 File Offset: 0x0006C4A8
		public static bool #7tc(this string #f, string #w2d, StringComparison #x2d)
		{
			if (#f == null)
			{
				return false;
			}
			int num;
			bool result = (num = #f.IndexOf(#w2d, #x2d)) != 0;
			do
			{
				if (!false)
				{
					int num2 = 0;
					int num3;
					int num4;
					do
					{
						num3 = (num = ((num < num2) ? 1 : 0));
						num4 = (num2 = 0);
					}
					while (num4 != 0);
					result = ((num = ((num3 == num4) ? 1 : 0)) != 0);
				}
			}
			while (false);
			return result;
		}

		// Token: 0x06008794 RID: 34708 RVA: 0x001D136C File Offset: 0x001CF56C
		public static string #sic(this string #f, int #y2d)
		{
			int num = string.IsNullOrEmpty(#f) ? 1 : 0;
			IL_06:
			while (num == 0)
			{
				string empty = string.Empty;
				string text;
				if (-1 != 0)
				{
					text = empty;
				}
				int num2 = 0;
				int i;
				if (4 != 0)
				{
					i = num2;
				}
				IL_35:
				while (i < #y2d)
				{
					string text2 = text + #f;
					if (2 != 0)
					{
						text = text2;
					}
					int num3 = num = i;
					while (7 != 0)
					{
						int num4 = num = ++num3;
						if (4 != 0)
						{
							if (false)
							{
								break;
							}
							if (7 == 0)
							{
								goto IL_35;
							}
							i = num4;
							goto IL_35;
						}
					}
					goto IL_06;
				}
				return text;
			}
			return #f;
		}

		// Token: 0x06008795 RID: 34709 RVA: 0x0006E2C6 File Offset: 0x0006C4C6
		public static string #z2d(this string #f, bool #n2d)
		{
			return #f.#P2d(#Phc.#3hc(107356879), #n2d);
		}

		// Token: 0x06008796 RID: 34710 RVA: 0x0006E2D9 File Offset: 0x0006C4D9
		public static string #z2d(this string #f)
		{
			return #f.#z2d(false);
		}

		// Token: 0x06008797 RID: 34711 RVA: 0x0006E2E2 File Offset: 0x0006C4E2
		public static string #A2d(this string #f)
		{
			if (#f.Last<char>() == '.')
			{
				return #f;
			}
			return #f.#z2d();
		}

		// Token: 0x06008798 RID: 34712 RVA: 0x0006E2F6 File Offset: 0x0006C4F6
		public static string #B2d(this string #f, bool #n2d)
		{
			return #f.#P2d(#Phc.#3hc(107408449), #n2d);
		}

		// Token: 0x06008799 RID: 34713 RVA: 0x0006E309 File Offset: 0x0006C509
		public static string #B2d(this string #f)
		{
			return #f.#B2d(false);
		}

		// Token: 0x0600879A RID: 34714 RVA: 0x0006E312 File Offset: 0x0006C512
		public static string #C2d(this string #f)
		{
			return #f.#C2d(false);
		}

		// Token: 0x0600879B RID: 34715 RVA: 0x0006E31B File Offset: 0x0006C51B
		public static string #C2d(this string #f, bool #n2d)
		{
			return #f.#P2d(#Phc.#3hc(107224197), #n2d);
		}

		// Token: 0x0600879C RID: 34716 RVA: 0x0006E32E File Offset: 0x0006C52E
		public static string #D2d(this string #f, params object[] #Qb)
		{
			return #f.#D2d(CultureInfo.InvariantCulture, #Qb);
		}

		// Token: 0x0600879D RID: 34717 RVA: 0x0006E33C File Offset: 0x0006C53C
		public static string #D2d(this string #f, IFormatProvider #E2d, params object[] #Qb)
		{
			if (string.IsNullOrEmpty(#f))
			{
				if (!false)
				{
					return #f;
				}
			}
			else if (#E2d != null)
			{
				return string.Format(#E2d, #f, #Qb);
			}
			return string.Format(CultureInfo.InvariantCulture, #f, #Qb);
		}

		// Token: 0x0600879E RID: 34718 RVA: 0x0006E363 File Offset: 0x0006C563
		public static string #F2d(this string #f)
		{
			if (string.IsNullOrWhiteSpace(#f))
			{
				return #f;
			}
			return #f + #Phc.#3hc(107382888);
		}

		// Token: 0x0600879F RID: 34719 RVA: 0x0006E37F File Offset: 0x0006C57F
		public static string #G2d(this string #f)
		{
			return #f.#G2d(false);
		}

		// Token: 0x060087A0 RID: 34720 RVA: 0x0006E388 File Offset: 0x0006C588
		public static string #G2d(this string #f, bool #n2d)
		{
			return #f.#P2d(#Phc.#3hc(107408434), #n2d);
		}

		// Token: 0x060087A1 RID: 34721 RVA: 0x0006E39B File Offset: 0x0006C59B
		public static string #H2d(this string #f)
		{
			return #f.#H2d(false);
		}

		// Token: 0x060087A2 RID: 34722 RVA: 0x0006E3A4 File Offset: 0x0006C5A4
		public static string #H2d(this string #f, bool #n2d)
		{
			return #f.#P2d(#Phc.#3hc(107361293), #n2d);
		}

		// Token: 0x060087A3 RID: 34723 RVA: 0x001D13C0 File Offset: 0x001CF5C0
		public static string #Al(this string #f, int #I2d)
		{
			string #R0d = #Phc.#3hc(107386484);
			Component #x6c = Component.Infrastructure;
			string #Qic = #Phc.#3hc(107224192);
			if (!false)
			{
				#X0d.#V0d(#f, #R0d, #x6c, #Qic);
			}
			int #Sb = #I2d;
			int num = #I2d;
			int num2 = 107224139;
			int num4;
			for (;;)
			{
				int num3 = num2 = (num4 = num2);
				if (num3 != 0)
				{
					string #R0d2 = #Phc.#3hc(num3);
					Component #x6c2 = Component.Infrastructure;
					string #Qic2 = #Phc.#3hc(107224146);
					if (true)
					{
						#X0d.#U0d(#Sb, #R0d2, #x6c2, #Qic2);
					}
					if (#I2d == 0)
					{
						break;
					}
					#Sb = (num = #f.Length);
					num4 = #I2d;
					num2 = #I2d;
				}
				if (8 != 0)
				{
					goto Block_4;
				}
			}
			if (-1 != 0)
			{
				return string.Empty;
			}
			goto IL_57;
			Block_4:
			if (num <= num4)
			{
				return #f;
			}
			IL_57:
			return #f.Substring(0, #I2d);
		}

		// Token: 0x060087A4 RID: 34724 RVA: 0x0006E3B7 File Offset: 0x0006C5B7
		public static string #J2d(this string #f)
		{
			return #f.#J2d(false);
		}

		// Token: 0x060087A5 RID: 34725 RVA: 0x0006E3C0 File Offset: 0x0006C5C0
		public static string #J2d(this string #f, bool #n2d)
		{
			return #f.#P2d(#Phc.#3hc(107224093), #n2d);
		}

		// Token: 0x060087A6 RID: 34726 RVA: 0x0006E3D3 File Offset: 0x0006C5D3
		public static string #K2d(this string #f)
		{
			return #f.#K2d(false);
		}

		// Token: 0x060087A7 RID: 34727 RVA: 0x0006E3DC File Offset: 0x0006C5DC
		public static string #K2d(this string #f, bool #n2d)
		{
			return #f.#P2d(#Phc.#3hc(107362078), #n2d);
		}

		// Token: 0x060087A8 RID: 34728 RVA: 0x0006E3EF File Offset: 0x0006C5EF
		public static string #L2d(this string #f)
		{
			return #f.#L2d(false);
		}

		// Token: 0x060087A9 RID: 34729 RVA: 0x0006E3F8 File Offset: 0x0006C5F8
		public static string #L2d(this string #f, bool #n2d)
		{
			return #f.#P2d(#Phc.#3hc(107465104), #n2d);
		}

		// Token: 0x060087AA RID: 34730 RVA: 0x0006E40B File Offset: 0x0006C60B
		public static string #M2d(this string #f, bool #n2d)
		{
			return #f.#P2d(#Phc.#3hc(107226735), #n2d);
		}

		// Token: 0x060087AB RID: 34731 RVA: 0x0006E41E File Offset: 0x0006C61E
		public static string #M2d(this string #f)
		{
			return #f.#M2d(false);
		}

		// Token: 0x060087AC RID: 34732 RVA: 0x0006E427 File Offset: 0x0006C627
		public static string #N2d(this string #f)
		{
			return #f.#N2d(false);
		}

		// Token: 0x060087AD RID: 34733 RVA: 0x0006E430 File Offset: 0x0006C630
		public static string #N2d(this string #f, bool #n2d)
		{
			return #f.#P2d(#Phc.#3hc(107224088), #n2d);
		}

		// Token: 0x060087AE RID: 34734 RVA: 0x0006E443 File Offset: 0x0006C643
		public static string #O2d(this string #f)
		{
			return #f.#P2d(null, true);
		}

		// Token: 0x060087AF RID: 34735 RVA: 0x0006E44D File Offset: 0x0006C64D
		public static string #P2d(this string #f, string #Q2d, bool #n2d)
		{
			while (#f == null)
			{
				if (!false)
				{
					return null;
				}
			}
			return #f + (#Q2d ?? string.Empty) + (#n2d ? #Phc.#3hc(107399922) : string.Empty);
		}

		// Token: 0x060087B0 RID: 34736 RVA: 0x0006E47B File Offset: 0x0006C67B
		public static string #R2d(this string #f)
		{
			return #f.#R2d(false);
		}

		// Token: 0x060087B1 RID: 34737 RVA: 0x0006E484 File Offset: 0x0006C684
		public static string #Tm(this string #f)
		{
			if (!string.IsNullOrWhiteSpace(#f))
			{
				return #f + Environment.NewLine;
			}
			return #f;
		}

		// Token: 0x060087B2 RID: 34738 RVA: 0x0006E49B File Offset: 0x0006C69B
		public static string #R2d(this string #f, bool #n2d)
		{
			return #f.#P2d(#Phc.#3hc(107455028), #n2d);
		}

		// Token: 0x060087B3 RID: 34739 RVA: 0x0006E4AE File Offset: 0x0006C6AE
		public static string #S2d(this string #T2d)
		{
			if (string.IsNullOrWhiteSpace(#T2d))
			{
				return #T2d;
			}
			return #Phc.#3hc(107465104) + #T2d + #Phc.#3hc(107362078);
		}

		// Token: 0x060087B4 RID: 34740 RVA: 0x001D143C File Offset: 0x001CF63C
		public static string #U2d(this string #T2d)
		{
			while (!false)
			{
				Match match2;
				if (string.IsNullOrWhiteSpace(#T2d))
				{
					if (7 != 0)
					{
						return #T2d;
					}
				}
				else
				{
					Match match = StringExtensions.#a.Match(#T2d);
					if (!false)
					{
						match2 = match;
					}
					if (!match2.Success)
					{
						break;
					}
				}
				if (!false)
				{
					return match2.Groups[1].Value;
				}
			}
			return #T2d;
		}

		// Token: 0x060087B5 RID: 34741 RVA: 0x0006E4D4 File Offset: 0x0006C6D4
		public static string #V2d(this string #f)
		{
			if (!string.IsNullOrWhiteSpace(#f))
			{
				return #f + #Phc.#3hc(107275915);
			}
			return #f;
		}

		// Token: 0x060087B6 RID: 34742 RVA: 0x001D148C File Offset: 0x001CF68C
		public static string #W2d(this string #f, int #y2d)
		{
			StringBuilder stringBuilder2;
			if (string.IsNullOrEmpty(#f))
			{
				if (-1 != 0)
				{
					return #f;
				}
			}
			else
			{
				StringBuilder stringBuilder = new StringBuilder();
				if (!false)
				{
					stringBuilder2 = stringBuilder;
				}
				int num = 0;
				for (;;)
				{
					int num2;
					if (5 != 0)
					{
						num2 = num;
					}
					for (;;)
					{
						int num4;
						int num3 = num4 = num2;
						int num5 = #y2d;
						if (-1 != 0)
						{
							if (num3 >= #y2d)
							{
								goto IL_36;
							}
							stringBuilder2.Append(#f);
							num = (num4 = num2);
							if (!true)
							{
								break;
							}
							num5 = 1;
						}
						int num6 = num4 + num5;
						if (6 != 0)
						{
							num2 = num6;
						}
					}
				}
			}
			IL_36:
			return stringBuilder2.ToString();
		}

		// Token: 0x060087B7 RID: 34743 RVA: 0x0006E4F0 File Offset: 0x0006C6F0
		public static string #X2d(this string #f, int #Y2d)
		{
			if (!true || #f.Length <= #Y2d)
			{
				return #f;
			}
			return #f.#Al(#Y2d).#B2d();
		}

		// Token: 0x060087B8 RID: 34744 RVA: 0x001D14E0 File Offset: 0x001CF6E0
		public static string #Z2d(this string #f, int #Y2d)
		{
			while (!string.IsNullOrEmpty(#f))
			{
				if (true)
				{
					int i = #f.Length;
					int num = #Y2d;
					while (i > num)
					{
						int num5;
						if (true)
						{
							int num2 = i = #f.Length - #Y2d;
							int num3 = num = 3;
							if (num3 == 0)
							{
								continue;
							}
							int num4 = num2 + num3;
							if (!false)
							{
								num5 = num4;
							}
						}
						int num6 = #f.Length - num5;
						int num7;
						if (!false)
						{
							num7 = num6;
						}
						string str = #f.Substring(0, num7 / 2);
						string text = #f.Substring(num7 / 2 + num5);
						string str2;
						if (true)
						{
							str2 = text;
						}
						return str + #Phc.#3hc(107408449) + str2;
					}
					if (2 != 0)
					{
						return #f;
					}
					break;
				}
			}
			return #f;
		}

		// Token: 0x060087B9 RID: 34745 RVA: 0x001D155C File Offset: 0x001CF75C
		public static string #02d(this string #hvb)
		{
			if (!string.IsNullOrWhiteSpace(#hvb) && #hvb.Contains(#Phc.#3hc(107356879)))
			{
				bool flag2;
				bool flag = flag2 = #hvb.EndsWith(#Phc.#3hc(107426661));
				if (!false)
				{
					if (!flag)
					{
						return #hvb;
					}
					string text = #hvb.TrimEnd(new char[]
					{
						'0'
					});
					if (true)
					{
						#hvb = text;
					}
					flag2 = #hvb.EndsWith(#Phc.#3hc(107356879));
				}
				if (!flag2)
				{
					return #hvb;
				}
				return #hvb.Remove(#hvb.Length - 1);
			}
			return #hvb;
		}

		// Token: 0x060087BA RID: 34746 RVA: 0x001D15D8 File Offset: 0x001CF7D8
		public static string #12d(this string #hvb, int #6Q)
		{
			StringBuilder stringBuilder = new StringBuilder();
			StringBuilder stringBuilder2;
			if (true)
			{
				stringBuilder2 = stringBuilder;
			}
			if (#6Q < 1)
			{
				return #hvb;
			}
			int num2;
			int num = num2 = 0;
			if (num != 0)
			{
				goto IL_BF;
			}
			int i;
			if (6 != 0)
			{
				i = num;
			}
			IL_D2:
			int num4;
			int num6;
			int num8;
			while (i < #hvb.Length)
			{
				int num3 = #hvb.IndexOf(Environment.NewLine, i, StringComparison.OrdinalIgnoreCase);
				if (!false)
				{
					num4 = num3;
				}
				if (num4 == -1)
				{
					if (4 == 0)
					{
						continue;
					}
					int num5 = num4 = #hvb.Length;
					if (true)
					{
						num6 = num5;
					}
				}
				else
				{
					int num7 = num4 + Environment.NewLine.Length;
					if (6 != 0)
					{
						num6 = num7;
					}
				}
				num8 = num4;
				goto IL_68;
			}
			return stringBuilder2.ToString();
			IL_68:
			if (num8 <= i)
			{
				stringBuilder2.Append(Environment.NewLine);
				goto IL_D0;
			}
			IL_6B:
			int num9 = num8 = num4;
			if (-1 == 0)
			{
				goto IL_68;
			}
			int num10 = num9 - i;
			int num11;
			if (7 != 0)
			{
				num11 = num10;
			}
			if (num11 > #6Q)
			{
				num11 = StringExtensions.#72d(#hvb, i, #6Q);
			}
			stringBuilder2.Append(#hvb, i, num11);
			stringBuilder2.Append(Environment.NewLine);
			i += num11;
			for (;;)
			{
				if (i >= num4)
				{
					goto IL_BB;
				}
				IL_AD:
				if (char.IsWhiteSpace(#hvb[i]))
				{
					i++;
					continue;
				}
				IL_BB:
				if (!false)
				{
					break;
				}
				goto IL_AD;
			}
			num2 = num4;
			IL_BF:
			if (num2 > i)
			{
				goto IL_6B;
			}
			IL_D0:
			i = num6;
			goto IL_D2;
		}

		// Token: 0x060087BB RID: 34747 RVA: 0x0006E50C File Offset: 0x0006C70C
		public static string #22d(this string #f)
		{
			if (!string.IsNullOrWhiteSpace(#f))
			{
				if (true)
				{
					return Regex.Replace(#f, #Phc.#3hc(107224083), string.Empty.#O2d());
				}
				goto IL_10;
			}
			IL_08:
			if (#f != null)
			{
				goto IL_10;
			}
			IL_0B:
			if (5 != 0)
			{
				return null;
			}
			goto IL_08;
			IL_10:
			if (-1 != 0)
			{
				return #f.Trim();
			}
			goto IL_0B;
		}

		// Token: 0x060087BC RID: 34748 RVA: 0x001D16F0 File Offset: 0x001CF8F0
		public static string #32d(this string #f)
		{
			if (string.IsNullOrEmpty(#f))
			{
				return #f;
			}
			List<string> list = Regex.Split(#f, #Phc.#3hc(107224546)).SelectMany(new Func<string, IEnumerable<string>>(StringExtensions.<>c.<>9.#N4d)).ToList<string>();
			List<string> source;
			if (-1 != 0)
			{
				source = list;
			}
			return string.Join(#Phc.#3hc(107399922), source.Select(new Func<string, string>(StringExtensions.<>c.<>9.#O4d)));
		}

		// Token: 0x060087BD RID: 34749 RVA: 0x0006E545 File Offset: 0x0006C745
		public static string #Vm(this string #f)
		{
			if (string.IsNullOrEmpty(#f))
			{
				return #f;
			}
			return Regex.Replace(#f, #Phc.#3hc(107224569), Environment.NewLine + Environment.NewLine);
		}

		// Token: 0x060087BE RID: 34750 RVA: 0x001D177C File Offset: 0x001CF97C
		public static IList<int> #42d(this string #f, string #52d, bool #xZd, int #62d = 0)
		{
			List<int> list = new List<int>();
			List<int> list2;
			if (-1 != 0)
			{
				list2 = list;
			}
			if (!string.IsNullOrWhiteSpace(#f))
			{
				int num;
				bool flag = (num = (string.IsNullOrWhiteSpace(#52d) ? 1 : 0)) != 0;
				if (-1 == 0)
				{
					goto IL_62;
				}
				if (flag)
				{
					return list2;
				}
				int length = #52d.Length;
				int num2;
				if (true)
				{
					num2 = length;
				}
				do
				{
					if (#xZd)
					{
						string text = #f.ToUpperInvariant();
						if (7 != 0)
						{
							#f = text;
						}
						string text2 = #52d.ToUpperInvariant();
						if (7 != 0)
						{
							#52d = text2;
						}
					}
				}
				while (7 == 0);
				int num3 = 0;
				int num4;
				if (!false)
				{
					num4 = num3;
				}
				IL_61:
				num = num4;
				IL_62:
				if (num < #f.Length && (num4 = #f.IndexOf(#52d, num4, StringComparison.Ordinal)) != -1 && (#62d <= 0 || list2.Count < #62d))
				{
					List<int> list3 = list2;
					int item = num4;
					if (!false)
					{
						list3.Add(item);
					}
					num4 += num2;
					goto IL_61;
				}
				return list2;
			}
			return list2;
		}

		// Token: 0x060087BF RID: 34751 RVA: 0x001D1820 File Offset: 0x001CFA20
		private static int #72d(string #hvb, int #82d, int #HT)
		{
			int num;
			for (;;)
			{
				IL_00:
				if (6 != 0)
				{
					num = #HT;
				}
				for (;;)
				{
					int num4;
					if (num < 0 || char.IsWhiteSpace(#hvb[#82d + num]))
					{
						int i = num;
						int num2 = 0;
						while (i >= num2)
						{
							for (;;)
							{
								int num3 = num4 = num;
								if (false)
								{
									goto IL_08;
								}
								if (num3 < 0)
								{
									goto IL_4F;
								}
								if (false)
								{
									goto IL_00;
								}
								if (!char.IsWhiteSpace(#hvb[#82d + num]))
								{
									goto IL_4F;
								}
								int num5 = i = num;
								int num6 = num2 = 1;
								if (num6 == 0)
								{
									break;
								}
								int num7 = num5 - num6;
								if (!false)
								{
									num = num7;
								}
							}
						}
						goto Block_1;
					}
					num4 = num;
					IL_08:
					int num8 = num4 - 1;
					if (!false)
					{
						num = num8;
					}
				}
			}
			Block_1:
			if (!false)
			{
				return #HT;
			}
			IL_4F:
			return num + 1;
		}

		// Token: 0x040037FE RID: 14334
		private static readonly Regex #a = new Regex(#Phc.#3hc(107224520), RegexOptions.IgnoreCase | RegexOptions.Singleline);
	}
}
