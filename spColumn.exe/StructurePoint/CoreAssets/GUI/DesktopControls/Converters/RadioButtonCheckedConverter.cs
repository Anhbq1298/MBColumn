using System;
using System.Globalization;
using System.Windows.Data;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A75 RID: 2677
	public sealed class RadioButtonCheckedConverter : IValueConverter
	{
		// Token: 0x06005774 RID: 22388 RVA: 0x000481C4 File Offset: 0x000463C4
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			#X0d.#V0d(value, #Phc.#3hc(107386484), Component.GUI, #Phc.#3hc(107428946));
			return value.Equals(parameter);
		}

		// Token: 0x06005775 RID: 22389 RVA: 0x000481F9 File Offset: 0x000463F9
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			#X0d.#V0d(value, #Phc.#3hc(107386484), Component.GUI, #Phc.#3hc(107428893));
			if (!value.Equals(true))
			{
				return Binding.DoNothing;
			}
			return parameter;
		}
	}
}
