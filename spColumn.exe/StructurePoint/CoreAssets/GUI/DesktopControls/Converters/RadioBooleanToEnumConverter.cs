using System;
using System.Globalization;
using System.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A74 RID: 2676
	public sealed class RadioBooleanToEnumConverter : IValueConverter
	{
		// Token: 0x06005771 RID: 22385 RVA: 0x0004817E File Offset: 0x0004637E
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value != null && value.Equals(parameter);
		}

		// Token: 0x06005772 RID: 22386 RVA: 0x0004819E File Offset: 0x0004639E
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null || !value.Equals(true))
			{
				return Binding.DoNothing;
			}
			return parameter;
		}
	}
}
