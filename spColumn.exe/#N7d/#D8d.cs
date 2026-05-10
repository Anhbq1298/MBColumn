using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Threading;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Units;

namespace #N7d
{
	// Token: 0x02000F77 RID: 3959
	internal static class #D8d
	{
		// Token: 0x06008AEB RID: 35563 RVA: 0x000711E2 File Offset: 0x0006F3E2
		public static bool #a8d(string #1Lb)
		{
			return #D8d.#m8d(#1Lb, LengthUnit.Foot);
		}

		// Token: 0x06008AEC RID: 35564 RVA: 0x000711F3 File Offset: 0x0006F3F3
		public static bool #b8d(string #1Lb)
		{
			return #D8d.#m8d(#1Lb, LengthUnit.Inch);
		}

		// Token: 0x06008AED RID: 35565 RVA: 0x00071204 File Offset: 0x0006F404
		public static string #c8d(double #d8d, int #e8d)
		{
			return #D8d.#k8d(#d8d, #e8d, LengthUnit.Foot);
		}

		// Token: 0x06008AEE RID: 35566 RVA: 0x0007121A File Offset: 0x0006F41A
		public static string #f8d(double #g8d, int #e8d)
		{
			return #D8d.#k8d(#g8d, #e8d, LengthUnit.Inch);
		}

		// Token: 0x06008AEF RID: 35567 RVA: 0x00071230 File Offset: 0x0006F430
		public static double #h8d(string #i8d)
		{
			return #D8d.#B8d(#i8d, LengthUnit.Foot);
		}

		// Token: 0x06008AF0 RID: 35568 RVA: 0x00071241 File Offset: 0x0006F441
		public static double #j8d(string #i8d)
		{
			return #D8d.#B8d(#i8d, LengthUnit.Inch);
		}

		// Token: 0x06008AF1 RID: 35569 RVA: 0x001D9C5C File Offset: 0x001D7E5C
		private static string #k8d(double #f, int #e8d, LengthUnit #l8d)
		{
			long #t8d;
			int #p8d;
			int #q8d;
			int #r8d;
			#D8d.#n8d(#f, #e8d, out #t8d, out #p8d, out #q8d, out #r8d, #l8d);
			return #D8d.#s8d(#t8d, #p8d, #q8d, #r8d);
		}

		// Token: 0x06008AF2 RID: 35570 RVA: 0x001D9C90 File Offset: 0x001D7E90
		private static bool #m8d(string #1Lb, LengthUnit #l8d)
		{
			if (string.IsNullOrWhiteSpace(#1Lb))
			{
				return false;
			}
			#1Lb = #1Lb.Trim();
			Regex regex;
			if (#l8d != LengthUnit.Foot)
			{
				if (#l8d != LengthUnit.Inch)
				{
					return false;
				}
				regex = #D8d.#b;
			}
			else
			{
				regex = #D8d.#a;
			}
			Match match = regex.Match(#1Lb);
			return match.Success && match.Value.Equals(#1Lb.Trim(), StringComparison.CurrentCulture);
		}

		// Token: 0x06008AF3 RID: 35571 RVA: 0x001D9CFC File Offset: 0x001D7EFC
		private static void #n8d(double #f, int #e8d, out long #o8d, out int #p8d, out int #q8d, out int #r8d, LengthUnit #l8d)
		{
			#o8d = 0L;
			double num = 0.0;
			if (#l8d == LengthUnit.Inch)
			{
				num = #f;
			}
			else if (#l8d == LengthUnit.Foot)
			{
				int num2 = Math.Sign(#f);
				num2 = ((num2 == 0) ? 1 : num2);
				#o8d = (long)num2 * (long)Math.Floor(Math.Abs(#f));
				double #c = Math.Abs(#f) - (double)Math.Abs(#o8d);
				num = ((#L8d<LengthUnit>)new LengthConverter()).#Pb(LengthUnit.Foot, LengthUnit.Inch, #c);
			}
			#p8d = (int)Math.Floor(num);
			double num3 = num - (double)#p8d;
			#q8d = (int)Math.Round(num3 * (double)#e8d);
			#r8d = #e8d;
			BigInteger value = BigInteger.GreatestCommonDivisor(#q8d, #r8d);
			#q8d /= (int)value;
			#r8d /= (int)value;
			if (#q8d == 1 && #r8d == 1)
			{
				#q8d--;
				#p8d++;
				if (#l8d == LengthUnit.Foot && #p8d == 12)
				{
					#o8d += 1L;
					#p8d = 0;
				}
			}
		}

		// Token: 0x06008AF4 RID: 35572 RVA: 0x00071252 File Offset: 0x0006F452
		private static string #s8d(long #t8d, int #p8d, int #q8d, int #r8d)
		{
			if (#t8d != 0L)
			{
				return #D8d.#u8d(#t8d, #p8d, #q8d, #r8d);
			}
			return #D8d.#v8d(#p8d, #q8d, #r8d);
		}

		// Token: 0x06008AF5 RID: 35573 RVA: 0x001D9E10 File Offset: 0x001D8010
		private static string #u8d(long #t8d, int #p8d, int #q8d, int #r8d)
		{
			IFormatProvider currentCulture = Thread.CurrentThread.CurrentCulture;
			if (#p8d == 0 && #q8d == 0)
			{
				return string.Format(currentCulture, #Phc.#3hc(107218249), new object[]
				{
					#t8d
				});
			}
			if (#p8d != 0 && #q8d == 0)
			{
				return string.Format(currentCulture, #Phc.#3hc(107218240), new object[]
				{
					#t8d,
					#p8d
				});
			}
			if (#p8d == 0 && #q8d != 0)
			{
				return string.Format(currentCulture, #Phc.#3hc(107218259), new object[]
				{
					#t8d,
					#q8d,
					#r8d
				});
			}
			return string.Format(currentCulture, #Phc.#3hc(107218238), new object[]
			{
				#t8d,
				#p8d,
				#q8d,
				#r8d
			});
		}

		// Token: 0x06008AF6 RID: 35574 RVA: 0x001D9F10 File Offset: 0x001D8110
		private static string #v8d(int #p8d, int #q8d, int #r8d)
		{
			IFormatProvider currentCulture = Thread.CurrentThread.CurrentCulture;
			if (#p8d != 0 && #q8d == 0)
			{
				return string.Format(currentCulture, #Phc.#3hc(107218181), new object[]
				{
					#p8d
				});
			}
			if (#p8d == 0 && #q8d != 0)
			{
				return string.Format(currentCulture, #Phc.#3hc(107218204), new object[]
				{
					#q8d,
					#r8d
				});
			}
			if (#p8d != 0 && #q8d != 0)
			{
				return string.Format(currentCulture, #Phc.#3hc(107217647), new object[]
				{
					#p8d,
					#q8d,
					#r8d
				});
			}
			return #Phc.#3hc(107217662);
		}

		// Token: 0x06008AF7 RID: 35575 RVA: 0x001D9FE0 File Offset: 0x001D81E0
		[SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "inchesFractionNumerator")]
		[SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "inchesInteger")]
		[SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "inchesFractionDenominator")]
		[SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "footsInteger")]
		private static void #w8d(Match #a2d, out int #x8d, out int #y8d, out int #z8d, out int #A8d)
		{
			#x8d = 0;
			#y8d = 0;
			#z8d = 0;
			#A8d = 0;
			IFormatProvider currentCulture = Thread.CurrentThread.CurrentCulture;
			if (#a2d.Groups[#Phc.#3hc(107217657)] != null && !string.IsNullOrEmpty(#a2d.Groups[#Phc.#3hc(107217657)].Value))
			{
				#x8d = int.Parse(#a2d.Groups[#Phc.#3hc(107217657)].Value, currentCulture);
			}
			if (#a2d.Groups[#Phc.#3hc(107217648)] != null && !string.IsNullOrEmpty(#a2d.Groups[#Phc.#3hc(107217648)].Value))
			{
				#y8d = int.Parse(#a2d.Groups[#Phc.#3hc(107217648)].Value, currentCulture);
			}
			if (#a2d.Groups[#Phc.#3hc(107217627)] != null && !string.IsNullOrEmpty(#a2d.Groups[#Phc.#3hc(107217627)].Value))
			{
				#z8d = int.Parse(#a2d.Groups[#Phc.#3hc(107217627)].Value, currentCulture);
			}
			if (#a2d.Groups[#Phc.#3hc(107217594)] != null && !string.IsNullOrEmpty(#a2d.Groups[#Phc.#3hc(107217594)].Value))
			{
				#A8d = int.Parse(#a2d.Groups[#Phc.#3hc(107217594)].Value, currentCulture);
			}
		}

		// Token: 0x06008AF8 RID: 35576 RVA: 0x001DA18C File Offset: 0x001D838C
		private static double #B8d(string #i8d, LengthUnit #l8d)
		{
			#X0d.#W0d(#i8d, #Phc.#3hc(107217557), Component.Units, #Phc.#3hc(107217504));
			#i8d = #i8d.Trim();
			int #x8d;
			int #y8d;
			int #z8d;
			int #A8d;
			#D8d.#w8d(#D8d.#a.Match(#i8d), out #x8d, out #y8d, out #z8d, out #A8d);
			return #D8d.#C8d(#x8d, #y8d, #z8d, #A8d, #l8d);
		}

		// Token: 0x06008AF9 RID: 35577 RVA: 0x001DA1EC File Offset: 0x001D83EC
		private static double #C8d(int #x8d, int #y8d, int #z8d, int #A8d, LengthUnit #l8d)
		{
			double num;
			if (#A8d != 0)
			{
				num = (double)#y8d + (double)#z8d / (double)#A8d;
			}
			else
			{
				num = (double)#y8d;
			}
			if (#l8d == LengthUnit.Inch)
			{
				return num;
			}
			if (#l8d == LengthUnit.Foot)
			{
				double value = #D8d.#c.#Pb(LengthUnit.Inch, LengthUnit.Foot, num);
				int num2 = Math.Sign(#x8d);
				return (double)((num2 == 0) ? 1 : num2) * ((double)Math.Abs(#x8d) + Math.Abs(value));
			}
			return 0.0;
		}

		// Token: 0x04003949 RID: 14665
		private static readonly Regex #a = new Regex(#Phc.#3hc(107217451), RegexOptions.IgnoreCase | RegexOptions.Singleline);

		// Token: 0x0400394A RID: 14666
		private static readonly Regex #b = new Regex(#Phc.#3hc(107217305), RegexOptions.IgnoreCase | RegexOptions.Singleline);

		// Token: 0x0400394B RID: 14667
		private static readonly #M8d #c = new LengthConverter();
	}
}
