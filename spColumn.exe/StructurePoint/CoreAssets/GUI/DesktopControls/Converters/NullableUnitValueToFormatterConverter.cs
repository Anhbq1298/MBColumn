using System;
using System.Globalization;
using System.Windows.Data;
using #Aae;
using StructurePoint.CoreAssets.Units.Formatters;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A60 RID: 2656
	public sealed class NullableUnitValueToFormatterConverter : IValueConverter
	{
		// Token: 0x170018F5 RID: 6389
		// (get) Token: 0x06005733 RID: 22323 RVA: 0x00047FE9 File Offset: 0x000461E9
		// (set) Token: 0x06005734 RID: 22324 RVA: 0x00047FF5 File Offset: 0x000461F5
		public string NullText { get; set; }

		// Token: 0x06005735 RID: 22325 RVA: 0x001666FC File Offset: 0x001648FC
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			IUnitValueFormatter unitValueFormatter = value as IUnitValueFormatter;
			if (unitValueFormatter != null)
			{
				return new #Iae(unitValueFormatter, this.NullText);
			}
			return null;
		}

		// Token: 0x06005736 RID: 22326 RVA: 0x00166730 File Offset: 0x00164930
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			#Iae #Iae = value as #Iae;
			if (#Iae != null)
			{
				return #Iae.Formatter;
			}
			return null;
		}
	}
}
