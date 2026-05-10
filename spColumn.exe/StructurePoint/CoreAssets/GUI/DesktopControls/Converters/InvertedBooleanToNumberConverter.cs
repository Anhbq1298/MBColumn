using System;
using System.Globalization;
using System.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A4C RID: 2636
	public sealed class InvertedBooleanToNumberConverter : IValueConverter
	{
		// Token: 0x060056F3 RID: 22259 RVA: 0x001662C0 File Offset: 0x001644C0
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if ((bool)value)
			{
				return 1;
			}
			int num;
			if (parameter == null || !int.TryParse((string)parameter, out num))
			{
				return 0;
			}
			return num;
		}

		// Token: 0x060056F4 RID: 22260 RVA: 0x00003909 File Offset: 0x00001B09
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
