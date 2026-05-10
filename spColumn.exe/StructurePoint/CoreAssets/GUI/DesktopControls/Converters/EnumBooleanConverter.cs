using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A58 RID: 2648
	public sealed class EnumBooleanConverter : IValueConverter
	{
		// Token: 0x0600571B RID: 22299 RVA: 0x001664B0 File Offset: 0x001646B0
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			#X0d.#V0d(value, #Phc.#3hc(107386484), Component.DesktopControls, #Phc.#3hc(107386443));
			string text = parameter.ToString();
			if (text == null)
			{
				return DependencyProperty.UnsetValue;
			}
			if (!Enum.IsDefined(value.GetType(), value))
			{
				return DependencyProperty.UnsetValue;
			}
			return Enum.Parse(value.GetType(), text).Equals(value);
		}

		// Token: 0x0600571C RID: 22300 RVA: 0x00166520 File Offset: 0x00164720
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			string text = parameter.ToString();
			if (text == null)
			{
				return DependencyProperty.UnsetValue;
			}
			return Enum.Parse(targetType, text);
		}
	}
}
