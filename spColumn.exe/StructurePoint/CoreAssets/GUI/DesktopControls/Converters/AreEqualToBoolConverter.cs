using System;
using System.Globalization;
using System.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A35 RID: 2613
	public sealed class AreEqualToBoolConverter : IValueConverter
	{
		// Token: 0x0600569E RID: 22174 RVA: 0x00047BEE File Offset: 0x00045DEE
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return object.Equals(value, parameter);
		}

		// Token: 0x0600569F RID: 22175 RVA: 0x00003909 File Offset: 0x00001B09
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
