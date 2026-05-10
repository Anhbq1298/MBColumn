using System;
using System.Globalization;
using System.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A5F RID: 2655
	public sealed class IsZeroToBooleanConverter : IValueConverter
	{
		// Token: 0x06005730 RID: 22320 RVA: 0x00166620 File Offset: 0x00164820
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
			{
				return false;
			}
			if (value is double)
			{
				return Math.Abs((double)value) < this.epsilon;
			}
			if (value is int)
			{
				return (int)value == 0;
			}
			if (value is long)
			{
				return (long)value == 0L;
			}
			if (value is short)
			{
				return (short)value == 0;
			}
			if (value is byte)
			{
				return (byte)value == 0;
			}
			if (value is float)
			{
				return (double)Math.Abs((float)value) < this.epsilon;
			}
			return false;
		}

		// Token: 0x06005731 RID: 22321 RVA: 0x00003909 File Offset: 0x00001B09
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		// Token: 0x040024A8 RID: 9384
		private readonly double epsilon = 1E-05;
	}
}
