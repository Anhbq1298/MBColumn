using System;
using System.Globalization;
using System.Windows.Data;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Localizer;

namespace StructurePoint.Products.Column.Editor.Section.Common
{
	// Token: 0x020005FF RID: 1535
	internal sealed class ClearCoverTypeConverter : IValueConverter
	{
		// Token: 0x06003485 RID: 13445 RVA: 0x00104F44 File Offset: 0x00103144
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is ClearCoverType)
			{
				ClearCoverType clearCoverType = (ClearCoverType)value;
				if (clearCoverType == ClearCoverType.ToTranverseBar)
				{
					return Strings.StringTransverseBars;
				}
				if (clearCoverType == ClearCoverType.ToLongitudinalBar)
				{
					return Strings.StringLongitudinalBars;
				}
			}
			return Strings.StringUndefined;
		}

		// Token: 0x06003486 RID: 13446 RVA: 0x00003909 File Offset: 0x00001B09
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
