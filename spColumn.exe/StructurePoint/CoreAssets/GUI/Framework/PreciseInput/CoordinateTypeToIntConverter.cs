using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Windows.Data;
using #7Tc;

namespace StructurePoint.CoreAssets.GUI.Framework.PreciseInput
{
	// Token: 0x02000C6E RID: 3182
	[ValueConversion(typeof(#8Tc), typeof(int))]
	[SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Used in xaml as static resource.")]
	public sealed class CoordinateTypeToIntConverter : IValueConverter
	{
		// Token: 0x06006697 RID: 26263 RVA: 0x0005270E File Offset: 0x0005090E
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (int)value;
		}

		// Token: 0x06006698 RID: 26264 RVA: 0x0005271B File Offset: 0x0005091B
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (#8Tc)value;
		}
	}
}
