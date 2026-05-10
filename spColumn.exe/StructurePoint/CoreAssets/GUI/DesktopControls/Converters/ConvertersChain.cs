using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A40 RID: 2624
	public sealed class ConvertersChain : List<object>, IValueConverter, IMultiValueConverter
	{
		// Token: 0x060056CB RID: 22219 RVA: 0x00047DCE File Offset: 0x00045FCE
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return this.Convert(new object[]
			{
				value
			}, targetType, parameter, culture);
		}

		// Token: 0x060056CC RID: 22220 RVA: 0x00165EFC File Offset: 0x001640FC
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			object obj = (values == null || values.Length == 0) ? null : values[0];
			object value = obj;
			object[] values2 = values;
			foreach (object obj2 in this)
			{
				IValueConverter valueConverter = obj2 as IValueConverter;
				if (valueConverter != null)
				{
					obj = valueConverter.Convert(value, targetType, parameter, culture);
					value = obj;
					values2 = new object[]
					{
						obj
					};
				}
				else
				{
					IMultiValueConverter multiValueConverter = obj2 as IMultiValueConverter;
					if (multiValueConverter == null)
					{
						throw new InvalidOperationException();
					}
					obj = multiValueConverter.Convert(values2, targetType, parameter, culture);
					value = obj;
					values2 = new object[]
					{
						obj
					};
				}
			}
			return obj;
		}

		// Token: 0x060056CD RID: 22221 RVA: 0x00008FC0 File Offset: 0x000071C0
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060056CE RID: 22222 RVA: 0x00008FC0 File Offset: 0x000071C0
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}
