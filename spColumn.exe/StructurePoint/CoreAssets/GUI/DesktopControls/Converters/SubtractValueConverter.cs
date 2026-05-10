using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A76 RID: 2678
	public sealed class SubtractValueConverter : IValueConverter
	{
		// Token: 0x06005777 RID: 22391 RVA: 0x00166A48 File Offset: 0x00164C48
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
				result = num - num2;
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06005778 RID: 22392 RVA: 0x00166AA4 File Offset: 0x00164CA4
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
				result = num + num2;
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}
	}
}
