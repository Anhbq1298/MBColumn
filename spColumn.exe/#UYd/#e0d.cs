using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using #7hc;

namespace #UYd
{
	// Token: 0x02000ED0 RID: 3792
	internal static class #e0d
	{
		// Token: 0x060086B7 RID: 34487 RVA: 0x001CDE24 File Offset: 0x001CC024
		[SuppressMessage("Microsoft.Design", "CA1045:DoNotPassTypesByReference", MessageId = "0#")]
		[SuppressMessage("Microsoft.Design", "CA1045:DoNotPassTypesByReference", MessageId = "1#")]
		public static void #c0d<#Fu>(ref #Fu #Yxc, ref #Fu #z9c)
		{
			if (!true)
			{
				goto IL_1C;
			}
			#Fu #Fu2;
			if (!false)
			{
				#Fu #Fu = #Yxc;
				if (!false)
				{
					#Fu2 = #Fu;
				}
			}
			IL_10:
			#Yxc = #z9c;
			IL_1C:
			#z9c = #Fu2;
			if (!false)
			{
				return;
			}
			goto IL_10;
		}

		// Token: 0x060086B8 RID: 34488 RVA: 0x001CDE5C File Offset: 0x001CC05C
		public static bool #d0d(this string #f, out List<double> #Qb)
		{
			#Qb = new List<double>();
			int num = string.IsNullOrWhiteSpace(#f) ? 1 : 0;
			while (num != 0)
			{
				if (false)
				{
					return false;
				}
				int num2 = num = 1;
				if (num2 != 0)
				{
					return num2 != 0;
				}
			}
			int num3 = (CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator == #Phc.#3hc(107408397)) ? 1 : 0;
			for (;;)
			{
				string text = (num3 != 0) ? #Phc.#3hc(107226735) : #Phc.#3hc(107408397);
				string text2;
				if (!false)
				{
					text2 = text;
				}
				string[] array = #f.Split(new string[]
				{
					text2
				}, StringSplitOptions.RemoveEmptyEntries);
				string[] array2;
				if (3 != 0)
				{
					array2 = array;
				}
				int num4 = 0;
				int num5;
				if (-1 != 0)
				{
					num5 = num4;
				}
				if (!false)
				{
					goto IL_9D;
				}
				IL_89:
				int num6 = num3 = num5 + 1;
				if (3 == 0)
				{
					continue;
				}
				if (!false)
				{
					num5 = num6;
				}
				IL_9D:
				if (num5 >= array2.Length)
				{
					return true;
				}
				double num7;
				if (!double.TryParse(array2[num5].Trim(), out num7))
				{
					break;
				}
				List<double> list = #Qb;
				double item = num7;
				if (4 == 0)
				{
					goto IL_89;
				}
				list.Add(item);
				goto IL_89;
			}
			#Qb = null;
			return false;
		}
	}
}
