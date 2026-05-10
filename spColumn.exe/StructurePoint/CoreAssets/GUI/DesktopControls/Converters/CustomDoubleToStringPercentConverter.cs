using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Data;
using #7hc;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A41 RID: 2625
	public sealed class CustomDoubleToStringPercentConverter : IValueConverter
	{
		// Token: 0x060056D0 RID: 22224 RVA: 0x00165FD0 File Offset: 0x001641D0
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is double)
			{
				return ((double)value * 100.0).ToString(#Phc.#3hc(107429066), CultureInfo.CurrentCulture) + #Phc.#3hc(107360069);
			}
			throw new ArgumentException(#Phc.#3hc(107429057));
		}

		// Token: 0x060056D1 RID: 22225 RVA: 0x00166038 File Offset: 0x00164238
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			string text = value as string;
			if (text == null)
			{
				return 1;
			}
			double num;
			if (!CustomDoubleToStringPercentConverter.PercentStringToDouble(text, out num))
			{
				return new ValidationResult(false, #Phc.#3hc(107429048));
			}
			return num;
		}

		// Token: 0x060056D2 RID: 22226 RVA: 0x00166084 File Offset: 0x00164284
		public static bool PercentStringToDouble(string percentage, out double result)
		{
			result = 0.0;
			Match match = CustomDoubleToStringPercentConverter.PercentRegex.Match(percentage.Trim());
			if (!match.Success)
			{
				return false;
			}
			if (!double.TryParse(match.Groups[1].Value.Replace(#Phc.#3hc(107408397), #Phc.#3hc(107356879)), NumberStyles.Any, CultureInfo.InvariantCulture, out result))
			{
				return false;
			}
			result /= 100.0;
			result = Math.Max(result, 0.1);
			result = Math.Min(result, 20.0);
			return true;
		}

		// Token: 0x0400249F RID: 9375
		private static readonly Regex PercentRegex = new Regex(#Phc.#3hc(107428963), RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace | RegexOptions.CultureInvariant);
	}
}
