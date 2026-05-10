using System;
using System.Globalization;
using System.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A37 RID: 2615
	public sealed class AreNotEqualToBoolConverter : IValueConverter
	{
		// Token: 0x060056A4 RID: 22180 RVA: 0x00047C28 File Offset: 0x00045E28
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return !object.Equals(value, parameter);
		}

		// Token: 0x060056A5 RID: 22181 RVA: 0x00003909 File Offset: 0x00001B09
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
