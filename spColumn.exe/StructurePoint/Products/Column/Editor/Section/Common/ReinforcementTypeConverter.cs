using System;
using System.Globalization;
using System.Windows.Data;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Localizer;

namespace StructurePoint.Products.Column.Editor.Section.Common
{
	// Token: 0x02000617 RID: 1559
	internal sealed class ReinforcementTypeConverter : IValueConverter
	{
		// Token: 0x060034D9 RID: 13529 RVA: 0x001066B4 File Offset: 0x001048B4
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is ReinforcementType)
			{
				switch ((ReinforcementType)value)
				{
				case ReinforcementType.AllEqual:
					return Strings.StringAllSidesEqualCapitalized;
				case ReinforcementType.EqualSpace:
					return Strings.StringEqualSpacingCapitalized;
				case ReinforcementType.Different:
					return Strings.StringSidesDifferentCapitalized;
				case ReinforcementType.Irregular:
					return Strings.StringIrregular;
				}
			}
			return string.Empty;
		}

		// Token: 0x060034DA RID: 13530 RVA: 0x00003909 File Offset: 0x00001B09
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
