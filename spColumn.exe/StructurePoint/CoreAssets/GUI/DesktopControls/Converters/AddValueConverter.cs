using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A30 RID: 2608
	public sealed class AddValueConverter : IValueConverter
	{
		// Token: 0x0600568D RID: 22157 RVA: 0x00165BE8 File Offset: 0x00163DE8
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null || parameter == null)
			{
				return null;
			}
			object result;
			try
			{
				double num = (double)value;
				double num2 = double.Parse(parameter.ToString(), CultureInfo.InvariantCulture);
				result = num + num2;
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600568E RID: 22158 RVA: 0x00165C44 File Offset: 0x00163E44
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null || parameter == null)
			{
				return null;
			}
			object result;
			try
			{
				double num = double.Parse(value.ToString(), CultureInfo.InvariantCulture);
				double num2 = double.Parse(parameter.ToString(), CultureInfo.InvariantCulture);
				result = num - num2;
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}
	}
}
