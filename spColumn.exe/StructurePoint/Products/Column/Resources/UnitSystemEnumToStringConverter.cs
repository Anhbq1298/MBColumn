using System;
using System.Globalization;
using System.Windows.Data;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.CoreAssets.Units;

namespace StructurePoint.Products.Column.Resources
{
	// Token: 0x0200001F RID: 31
	internal sealed class UnitSystemEnumToStringConverter : IValueConverter
	{
		// Token: 0x060000B3 RID: 179 RVA: 0x00085A9C File Offset: 0x00083C9C
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			UnitSystem unitSystem = (UnitSystem)value;
			UnitSystem unitSystem2;
			if (!false)
			{
				unitSystem2 = unitSystem;
			}
			if (unitSystem2 == UnitSystem.USCustomary)
			{
				return Strings.StringEnglish;
			}
			if (unitSystem2 == UnitSystem.SIMetric)
			{
				return Strings.StringMetric;
			}
			return Strings.StringNone;
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00003909 File Offset: 0x00001B09
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
