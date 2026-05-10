using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A45 RID: 2629
	[SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags")]
	public sealed class EnumFlagsToBooleanConverter : IValueConverter
	{
		// Token: 0x060056DE RID: 22238 RVA: 0x00166188 File Offset: 0x00164388
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			Enum @enum = value as Enum;
			if (@enum == null)
			{
				return Binding.DoNothing;
			}
			Enum enum2 = parameter as Enum;
			if (enum2 == null)
			{
				return Binding.DoNothing;
			}
			Type type = @enum.GetType();
			Type type2 = enum2.GetType();
			if (type != type2)
			{
				return Binding.DoNothing;
			}
			return @enum.HasFlag(enum2);
		}

		// Token: 0x060056DF RID: 22239 RVA: 0x00008FC0 File Offset: 0x000071C0
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}
