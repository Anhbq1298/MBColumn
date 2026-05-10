using System;
using System.Globalization;
using System.Text.RegularExpressions;
using #7hc;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;

namespace #wdd
{
	// Token: 0x02000462 RID: 1122
	internal class #ned
	{
		// Token: 0x0600293B RID: 10555 RVA: 0x000DE35C File Offset: 0x000DC55C
		public static string #qp(double? #f, NativeNumberFormat #cA, double #1Mb, NativeNumberFormat #ked)
		{
			double? num = #f;
			return #ned.#qp(#f, (num.GetValueOrDefault() > #1Mb & num != null) ? #ked : #cA);
		}

		// Token: 0x0600293C RID: 10556 RVA: 0x00025CF2 File Offset: 0x00023EF2
		public static string #led(double? #f)
		{
			return #ned.#qp(#f, NativeNumberFormat.G);
		}

		// Token: 0x0600293D RID: 10557 RVA: 0x000DE398 File Offset: 0x000DC598
		public static string #qp(double? #f, NativeNumberFormat #cA)
		{
			if (#f == null)
			{
				return string.Empty;
			}
			double value = #f.Value;
			string text;
			NativeFormatter.Format(#cA, value, out text);
			return #ned.#med(string.IsNullOrWhiteSpace(text) ? value.ToString(#Phc.#3hc(107408811), CultureInfo.CurrentCulture) : text.Trim());
		}

		// Token: 0x0600293E RID: 10558 RVA: 0x000DE400 File Offset: 0x000DC600
		public static string #qp(float? #f, NativeNumberFormat #cA, float #1Mb, NativeNumberFormat #ked)
		{
			float? num = #f;
			return #ned.#qp(#f, (num.GetValueOrDefault() > #1Mb & num != null) ? #ked : #cA, #Phc.#3hc(107381628));
		}

		// Token: 0x0600293F RID: 10559 RVA: 0x000DE448 File Offset: 0x000DC648
		public static string #qp(float? #f, NativeNumberFormat #cA, string #H3h = "")
		{
			if (#f == null)
			{
				return #H3h;
			}
			float value = #f.Value;
			string text;
			NativeFormatter.Format(#cA, (double)value, out text);
			return #ned.#med(string.IsNullOrWhiteSpace(text) ? value.ToString(#Phc.#3hc(107408811), CultureInfo.CurrentCulture) : text.Trim());
		}

		// Token: 0x06002940 RID: 10560 RVA: 0x00025D04 File Offset: 0x00023F04
		public string #qp(NaNullableFloat #f, NativeNumberFormat #cA, float #1Mb, NativeNumberFormat #ked)
		{
			if (#f.IsNa)
			{
				return #Phc.#3hc(107253318);
			}
			return #ned.#qp(#f.Value, #cA, #1Mb, #ked);
		}

		// Token: 0x06002941 RID: 10561 RVA: 0x00025D34 File Offset: 0x00023F34
		public string #qp(NaNullableFloat #f, NativeNumberFormat #cA)
		{
			if (#f.IsNa)
			{
				return #Phc.#3hc(107253318);
			}
			return #ned.#qp(#f.Value, #cA, #Phc.#3hc(107381628));
		}

		// Token: 0x06002942 RID: 10562 RVA: 0x000DE4AC File Offset: 0x000DC6AC
		private static string #med(string #f)
		{
			#f = \u007F.~\u0012\u0002(#f);
			Match match = \u0095\u0002.~\u0006\u0006(#ned.#a, #f);
			if (\u0010\u0002.~\u001A\u0004(match))
			{
				return \u007F.~\u0013\u0002(\u0096\u0002.~\u0007\u0006(\u0093\u0002.~\u0004\u0006(match), 1));
			}
			return #f;
		}

		// Token: 0x0400107D RID: 4221
		private static readonly Regex #a = new Regex(#Phc.#3hc(107253341), RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);
	}
}
