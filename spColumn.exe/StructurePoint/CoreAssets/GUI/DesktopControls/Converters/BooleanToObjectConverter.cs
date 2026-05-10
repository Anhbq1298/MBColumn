using System;
using System.Globalization;
using System.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A3A RID: 2618
	public sealed class BooleanToObjectConverter : IValueConverter
	{
		// Token: 0x170018ED RID: 6381
		// (get) Token: 0x060056AD RID: 22189 RVA: 0x00047C9B File Offset: 0x00045E9B
		// (set) Token: 0x060056AE RID: 22190 RVA: 0x00047CA7 File Offset: 0x00045EA7
		public object TrueValue { get; set; }

		// Token: 0x170018EE RID: 6382
		// (get) Token: 0x060056AF RID: 22191 RVA: 0x00047CB8 File Offset: 0x00045EB8
		// (set) Token: 0x060056B0 RID: 22192 RVA: 0x00047CC4 File Offset: 0x00045EC4
		public object FalseValue { get; set; }

		// Token: 0x170018EF RID: 6383
		// (get) Token: 0x060056B1 RID: 22193 RVA: 0x00047CD5 File Offset: 0x00045ED5
		// (set) Token: 0x060056B2 RID: 22194 RVA: 0x00047CE1 File Offset: 0x00045EE1
		public object NullValue { get; set; }

		// Token: 0x060056B3 RID: 22195 RVA: 0x00165E24 File Offset: 0x00164024
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			bool? flag = value as bool?;
			if (flag == null)
			{
				return this.NullValue;
			}
			if (!flag.Value)
			{
				return this.FalseValue;
			}
			return this.TrueValue;
		}

		// Token: 0x060056B4 RID: 22196 RVA: 0x00047C65 File Offset: 0x00045E65
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Binding.DoNothing;
		}
	}
}
