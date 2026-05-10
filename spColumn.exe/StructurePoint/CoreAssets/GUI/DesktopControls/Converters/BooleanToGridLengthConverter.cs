using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A3B RID: 2619
	public sealed class BooleanToGridLengthConverter : IValueConverter
	{
		// Token: 0x170018F0 RID: 6384
		// (get) Token: 0x060056B6 RID: 22198 RVA: 0x00047CF2 File Offset: 0x00045EF2
		// (set) Token: 0x060056B7 RID: 22199 RVA: 0x00047CFE File Offset: 0x00045EFE
		public GridLength TrueValue { get; set; }

		// Token: 0x170018F1 RID: 6385
		// (get) Token: 0x060056B8 RID: 22200 RVA: 0x00047D0F File Offset: 0x00045F0F
		// (set) Token: 0x060056B9 RID: 22201 RVA: 0x00047D1B File Offset: 0x00045F1B
		public GridLength FalseValue { get; set; }

		// Token: 0x170018F2 RID: 6386
		// (get) Token: 0x060056BA RID: 22202 RVA: 0x00047D2C File Offset: 0x00045F2C
		// (set) Token: 0x060056BB RID: 22203 RVA: 0x00047D38 File Offset: 0x00045F38
		public GridLength NullValue { get; set; }

		// Token: 0x060056BC RID: 22204 RVA: 0x00047D49 File Offset: 0x00045F49
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
			{
				return this.NullValue;
			}
			return (value is bool && (bool)value) ? this.TrueValue : this.FalseValue;
		}

		// Token: 0x060056BD RID: 22205 RVA: 0x00047C65 File Offset: 0x00045E65
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Binding.DoNothing;
		}
	}
}
