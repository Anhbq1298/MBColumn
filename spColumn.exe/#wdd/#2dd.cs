using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using #7hc;
using #FCd;
using #Qcd;
using Aspose.Words;

namespace #wdd
{
	// Token: 0x02000D14 RID: 3348
	internal static class #2dd
	{
		// Token: 0x17001EF3 RID: 7923
		// (get) Token: 0x06006E43 RID: 28227 RVA: 0x00058C6C File Offset: 0x00056E6C
		public static float DefaultPropertiesTableWidth
		{
			get
			{
				return 40f;
			}
		}

		// Token: 0x17001EF4 RID: 7924
		// (get) Token: 0x06006E44 RID: 28228 RVA: 0x00058C73 File Offset: 0x00056E73
		public static double PropertiesFirstColumnWidth
		{
			get
			{
				return 90.0;
			}
		}

		// Token: 0x17001EF5 RID: 7925
		// (get) Token: 0x06006E45 RID: 28229 RVA: 0x00058C7E File Offset: 0x00056E7E
		public static double PropertiesDataColumnWidth
		{
			get
			{
				return 80.0;
			}
		}

		// Token: 0x17001EF6 RID: 7926
		// (get) Token: 0x06006E46 RID: 28230 RVA: 0x00058C89 File Offset: 0x00056E89
		public static double PropertiesUnitColumnWidth
		{
			get
			{
				return 35.0;
			}
		}

		// Token: 0x17001EF7 RID: 7927
		// (get) Token: 0x06006E47 RID: 28231 RVA: 0x00058C94 File Offset: 0x00056E94
		public static double[] DefaultPropertiesTableWidths
		{
			get
			{
				return new double[]
				{
					#2dd.PropertiesFirstColumnWidth,
					#2dd.PropertiesDataColumnWidth,
					#2dd.PropertiesUnitColumnWidth
				};
			}
		}

		// Token: 0x17001EF8 RID: 7928
		// (get) Token: 0x06006E48 RID: 28232 RVA: 0x00058CC0 File Offset: 0x00056EC0
		public static string NoSpacingSmallStyleKey
		{
			get
			{
				return #Phc.#3hc(107253491);
			}
		}

		// Token: 0x17001EF9 RID: 7929
		// (get) Token: 0x06006E49 RID: 28233 RVA: 0x00058CD0 File Offset: 0x00056ED0
		public static int CellAutoFitDigitsThreshold
		{
			get
			{
				return 7;
			}
		}

		// Token: 0x06006E4A RID: 28234 RVA: 0x001A4648 File Offset: 0x001A2848
		public static int? #Tdd(string #f)
		{
			if (#2dd.#Udd(#f))
			{
				int num = 0;
				foreach (char c in #f)
				{
					if (!char.IsDigit(c) && c != '-')
					{
						break;
					}
					num++;
				}
				return new int?(num);
			}
			return null;
		}

		// Token: 0x06006E4B RID: 28235 RVA: 0x00058CD3 File Offset: 0x00056ED3
		public static bool #Udd(string #f)
		{
			return !\u0003.\u0004(#f) && \u0080.~\u007F\u0002(#2dd.#a, #f);
		}

		// Token: 0x06006E4C RID: 28236 RVA: 0x001A46A8 File Offset: 0x001A28A8
		public static void #Vdd(#5Dd #Wdd)
		{
			#Wdd.TableWidthType = #rdd.#b;
			#Wdd.PreferredWidth = (float)\u008B\u0002.\u0089\u0005(#Wdd.ColumnWidths);
			#Wdd.#TDd(1);
			#Wdd.#VDd(ParagraphAlignment.Right, new int[]
			{
				1
			});
			#Wdd.#RDd(true, new int[0]);
			#Wdd.#XDd(#rdd.#b, new int[0]);
		}

		// Token: 0x06006E4D RID: 28237 RVA: 0x00058D00 File Offset: 0x00056F00
		public static #5Dd #Xdd(this #6Dd #opb, double[] #Zpb = null)
		{
			#5Dd #5Dd = #opb.#ul(0, #Zpb ?? #2dd.DefaultPropertiesTableWidths);
			#2dd.#Vdd(#5Dd);
			return #5Dd;
		}

		// Token: 0x06006E4E RID: 28238 RVA: 0x001A4714 File Offset: 0x001A2914
		public static bool #Ydd(string #Zdd)
		{
			if (\u0003.\u0005(#Zdd))
			{
				return false;
			}
			for (int i = 0; i < \u008D\u0002.~\u008C\u0005(#Zdd); i++)
			{
				char c = \u008C\u0002.~\u008A\u0005(#Zdd, i);
				if (c == '<' || c == '&' || c == '\u00a0')
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06006E4F RID: 28239 RVA: 0x001A4774 File Offset: 0x001A2974
		public static string #Cu(this int? #f)
		{
			if (#f == null)
			{
				return string.Empty;
			}
			return #f.Value.ToString(CultureInfo.InvariantCulture);
		}

		// Token: 0x06006E50 RID: 28240 RVA: 0x001A47B0 File Offset: 0x001A29B0
		public static double[] #0dd(int #1f)
		{
			#2dd.#NTb #NTb = new #2dd.#NTb();
			#NTb.#a = 100.0 / (double)#1f;
			return \u008E\u0002.\u009A\u0005(1, #1f).Select(new Func<int, double>(#NTb.#KUd)).ToArray<double>();
		}

		// Token: 0x06006E51 RID: 28241 RVA: 0x001A4804 File Offset: 0x001A2A04
		public static bool #1dd(StyleIdentifier #4cd)
		{
			return #4cd >= StyleIdentifier.Heading1 && #4cd <= StyleIdentifier.Heading9;
		}

		// Token: 0x04002C59 RID: 11353
		private static readonly Regex #a = new Regex(#Phc.#3hc(107253470), RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.CultureInvariant);

		// Token: 0x04002C5A RID: 11354
		public static readonly Color #b = \u008F\u0002.\u009B\u0005(255, 128, 128, 128);

		// Token: 0x04002C5B RID: 11355
		public static readonly Color #c = \u008F\u0002.\u009B\u0005(255, 230, 230, 230);

		// Token: 0x04002C5C RID: 11356
		public static readonly double #d = 0.3;

		// Token: 0x04002C5D RID: 11357
		public static readonly Color #e = \u008F\u0002.\u009B\u0005(255, 166, 166, 166);

		// Token: 0x04002C5E RID: 11358
		public static readonly double #f = 0.3;

		// Token: 0x04002C5F RID: 11359
		public static string #g = #Phc.#3hc(107356910);

		// Token: 0x02000D15 RID: 3349
		[CompilerGenerated]
		private sealed class #NTb
		{
			// Token: 0x06006E54 RID: 28244 RVA: 0x00058D21 File Offset: 0x00056F21
			internal double #KUd(int #Rf)
			{
				return this.#a;
			}

			// Token: 0x04002C60 RID: 11360
			public double #a;
		}
	}
}
