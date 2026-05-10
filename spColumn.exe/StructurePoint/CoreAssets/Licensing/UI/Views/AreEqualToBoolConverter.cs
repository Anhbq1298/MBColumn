using System;
using System.Globalization;
using System.Windows.Data;

namespace StructurePoint.CoreAssets.Licensing.UI.Views
{
	// Token: 0x02000726 RID: 1830
	internal sealed class AreEqualToBoolConverter : IValueConverter
	{
		// Token: 0x06003C4F RID: 15439 RVA: 0x000341BC File Offset: 0x000323BC
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return \u0091.\u0012\u0003(value, parameter);
		}

		// Token: 0x06003C50 RID: 15440 RVA: 0x00003909 File Offset: 0x00001B09
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
