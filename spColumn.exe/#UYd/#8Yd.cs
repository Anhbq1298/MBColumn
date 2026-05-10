using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using #7hc;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace #UYd
{
	// Token: 0x02000EC9 RID: 3785
	internal static class #8Yd
	{
		// Token: 0x06008664 RID: 34404 RVA: 0x001CCB24 File Offset: 0x001CAD24
		static #8Yd()
		{
			if (true)
			{
				#8Yd.#b = new Regex(#Phc.#3hc(107227611), RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.CultureInvariant);
				Dictionary<string, double> dictionary = new Dictionary<string, double>();
				dictionary.Add(#Phc.#3hc(107408114), 1.0);
				dictionary.Add(#Phc.#3hc(107227506), 1024.0);
				dictionary.Add(#Phc.#3hc(107227469), 1048576.0);
				dictionary.Add(#Phc.#3hc(107227464), 1073741824.0);
				dictionary.Add(#Phc.#3hc(107227459), 1099511627776.0);
				dictionary.Add(#Phc.#3hc(107227486), 1125899906842624.0);
				dictionary.Add(#Phc.#3hc(107227481), 1.152921504606847E+18);
				dictionary.Add(#Phc.#3hc(107227476), 1.1805916207174113E+21);
				string key = #Phc.#3hc(107227439);
				double value = 1.2089258196146292E+24;
				if (2 != 0)
				{
					dictionary.Add(key, value);
				}
				#8Yd.#c = dictionary;
				#8Yd.#d = new string[]
				{
					#Phc.#3hc(107408114),
					#Phc.#3hc(107227506),
					#Phc.#3hc(107227469),
					#Phc.#3hc(107227464),
					#Phc.#3hc(107227459),
					#Phc.#3hc(107227486),
					#Phc.#3hc(107227481),
					#Phc.#3hc(107227476),
					#Phc.#3hc(107227439)
				};
				NumberFormatInfo numberFormat = #8Yd.#a.NumberFormat;
				string numberGroupSeparator = string.Empty.#O2d();
				if (!false)
				{
					numberFormat.NumberGroupSeparator = numberGroupSeparator;
				}
			}
		}

		// Token: 0x06008665 RID: 34405 RVA: 0x001CCD00 File Offset: 0x001CAF00
		public static double #0Yd(string #f)
		{
			if (4 == 0)
			{
				goto IL_2A;
			}
			bool flag2;
			bool flag = flag2 = string.IsNullOrWhiteSpace(#f);
			if (4 == 0)
			{
				goto IL_30;
			}
			double result;
			Match match2;
			if (flag)
			{
				result = 0.0;
			}
			else
			{
				if (6 == 0)
				{
					goto IL_2A;
				}
				Match match = #8Yd.#b.Match(#f);
				if (false)
				{
					goto IL_2A;
				}
				match2 = match;
				goto IL_2A;
			}
			return result;
			IL_2A:
			flag2 = match2.Success;
			IL_30:
			if (flag2)
			{
				double num = double.Parse(match2.Groups[1].Value.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture);
				string text = match2.Groups[5].Value.ToUpperInvariant();
				string key;
				if (!false)
				{
					key = text;
				}
				return num * #8Yd.#c[key];
			}
			double result2 = result = 0.0;
			if (7 != 0)
			{
				return result2;
			}
			return result;
		}

		// Token: 0x06008666 RID: 34406 RVA: 0x0006D65E File Offset: 0x0006B85E
		public static bool #1Yd(string #f)
		{
			return !string.IsNullOrWhiteSpace(#f) && #8Yd.#b.IsMatch(#f);
		}

		// Token: 0x06008667 RID: 34407 RVA: 0x001CCDA4 File Offset: 0x001CAFA4
		public static string #2Yd(long #3Yd)
		{
			bool flag = #3Yd != 0L;
			long num = #3Yd;
			double num2;
			double num4;
			for (;;)
			{
				if (!false)
				{
					if (num < 0L)
					{
						break;
					}
					flag = (#3Yd != 0L);
				}
				if (!flag)
				{
					goto Block_3;
				}
				num2 = (double)#3Yd;
				flag = (#3Yd != 0L);
				num = #3Yd;
				if (!false)
				{
					double num3 = Math.Floor(Math.Log((double)#3Yd) / Math.Log(1024.0));
					if (5 != 0)
					{
						num4 = num3;
					}
					double num5 = Math.Min(num4, (double)(#8Yd.#d.Length - 1));
					if (-1 != 0)
					{
						num4 = num5;
					}
					num2 = (double)#3Yd;
					flag = (#3Yd != 0L);
					num = #3Yd;
				}
				if (7 != 0)
				{
					goto Block_6;
				}
			}
			int num6 = 107227434;
			IL_0D:
			throw new ArgumentOutOfRangeException(#Phc.#3hc(num6));
			Block_3:
			int num7 = num6 = 107426661;
			if (num7 != 0)
			{
				return #Phc.#3hc(num7) + #8Yd.#d[0];
			}
			goto IL_0D;
			Block_6:
			double num8 = num2 / Math.Pow(1024.0, num4);
			double num9;
			if (!false)
			{
				num9 = num8;
			}
			return num9.ToString(#Phc.#3hc(107362056)) + #8Yd.#d[(int)num4];
		}

		// Token: 0x06008668 RID: 34408 RVA: 0x001CCE60 File Offset: 0x001CB060
		public static string #4Yd(double #3Yd)
		{
			double num = #3Yd;
			double num2 = #3Yd;
			double num3 = #3Yd;
			if (!true)
			{
				goto IL_76;
			}
			if (#3Yd < 0.0)
			{
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107227434));
			}
			if (false)
			{
				goto IL_31;
			}
			num2 = #3Yd;
			num3 = #3Yd;
			IL_23:
			double d;
			double num4 = d = 1.0;
			if (5 != 0)
			{
				if (num3 < num4)
				{
					goto IL_31;
				}
				num2 = Math.Log(#3Yd);
				d = 1024.0;
			}
			double num5 = Math.Floor(num2 / Math.Log(d));
			double num6;
			if (!false)
			{
				num6 = num5;
			}
			num2 = (num3 = (num = Math.Min(num6, (double)(#8Yd.#d.Length - 1))));
			goto IL_76;
			IL_31:
			return #Phc.#3hc(107426661) + #8Yd.#d[0];
			IL_76:
			if (!false)
			{
				if (5 != 0)
				{
					num6 = num;
				}
				double num7 = #3Yd / Math.Pow(1024.0, num6);
				double num8;
				if (8 != 0)
				{
					num8 = num7;
				}
				return num8.ToString((Math.Abs(num6) < 0.001) ? #Phc.#3hc(107227404) : #Phc.#3hc(107227449), #8Yd.#a) + #Phc.#3hc(107399922) + #8Yd.#d[(int)num6];
			}
			goto IL_23;
		}

		// Token: 0x06008669 RID: 34409 RVA: 0x001CCF58 File Offset: 0x001CB158
		public static string #5Yd(double #3Yd, int #6Yd = 1)
		{
			if (false)
			{
				goto IL_96;
			}
			double num = #3Yd;
			double num2 = 0.0;
			IL_10:
			if (num < num2)
			{
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107227434));
			}
			double val = #3Yd;
			double num4;
			double num3 = num4 = 1.0;
			double num6;
			if (8 != 0)
			{
				if (#3Yd < num3)
				{
					return #Phc.#3hc(107426661) + #8Yd.#d[0];
				}
				double num5 = Math.Floor(Math.Log(#3Yd) / Math.Log(1024.0));
				if (!false)
				{
					num6 = num5;
				}
				double num7 = Math.Min(num6, (double)(#8Yd.#d.Length - 1));
				if (-1 != 0)
				{
					num6 = num7;
				}
				val = 0.0;
				num4 = num6;
			}
			double num8 = Math.Max(val, num4 - (double)#6Yd);
			if (8 != 0)
			{
				num6 = num8;
			}
			IL_96:
			double num10;
			if (!false)
			{
				num = #3Yd;
				double x = num2 = 1024.0;
				if (false)
				{
					goto IL_10;
				}
				double num9 = #3Yd / Math.Pow(x, num6);
				if (!false)
				{
					num10 = num9;
				}
			}
			return num10.ToString((Math.Abs(num6) < 0.001) ? #Phc.#3hc(107227404) : #Phc.#3hc(107227449), #8Yd.#a) + string.Empty.#O2d() + #8Yd.#d[(int)num6];
		}

		// Token: 0x0600866A RID: 34410 RVA: 0x0006D675 File Offset: 0x0006B875
		public static string #7Yd(long #3Yd)
		{
			if (4 == 0)
			{
				goto IL_13;
			}
			long num = #3Yd;
			IL_04:
			if (num > 0L)
			{
				goto IL_13;
			}
			IL_08:
			return #Phc.#3hc(107408434);
			IL_13:
			if (false)
			{
				goto IL_08;
			}
			num = #3Yd;
			if (!false)
			{
				return #8Yd.#4Yd((double)#3Yd) + #Phc.#3hc(107227395);
			}
			goto IL_04;
		}

		// Token: 0x040037B0 RID: 14256
		private static readonly CultureInfo #a = (CultureInfo)CultureInfo.InvariantCulture.Clone();

		// Token: 0x040037B1 RID: 14257
		private static readonly Regex #b;

		// Token: 0x040037B2 RID: 14258
		private static readonly Dictionary<string, double> #c;

		// Token: 0x040037B3 RID: 14259
		private static readonly string[] #d;
	}
}
