using System;
using System.Globalization;
using System.Windows.Data;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Localizer;

namespace StructurePoint.Products.Column.Editor.Section.Common
{
	// Token: 0x02000616 RID: 1558
	internal sealed class ReinforcementLayoutConverter : IValueConverter
	{
		// Token: 0x060034D6 RID: 13526 RVA: 0x00106674 File Offset: 0x00104874
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is ReinforcementLayout)
			{
				ReinforcementLayout reinforcementLayout = (ReinforcementLayout)value;
				if (reinforcementLayout == ReinforcementLayout.Rectangle)
				{
					return Strings.StringRectangular;
				}
				if (reinforcementLayout == ReinforcementLayout.Circle)
				{
					return Strings.StringCircular;
				}
			}
			return string.Empty;
		}

		// Token: 0x060034D7 RID: 13527 RVA: 0x00003909 File Offset: 0x00001B09
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
