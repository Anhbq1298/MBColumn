using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Localizer;

namespace StructurePoint.Products.Column.Views.Core.Converters
{
	// Token: 0x0200006E RID: 110
	internal sealed class BarGroupTypeToStringConverter : IValueConverter
	{
		// Token: 0x06000419 RID: 1049 RVA: 0x0008784C File Offset: 0x00085A4C
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			#X0d.#V0d(value, #Phc.#3hc(107386484), Component.DesktopControls, #Phc.#3hc(107386443));
			if (!Enum.IsDefined(value.GetType(), value))
			{
				return DependencyProperty.UnsetValue;
			}
			switch ((BarGroupType)value)
			{
			case BarGroupType.UserDefined:
				return Strings.StringUserDefined;
			case BarGroupType.ASTM615:
				return Strings.StringASTMA615;
			case BarGroupType.CSA:
				return Strings.StringCSAG3018;
			case BarGroupType.PREN10080:
				return Strings.StringPREN10080;
			case BarGroupType.ASTM615M:
				return Strings.StringASTMA615M;
			default:
				return string.Empty;
			}
		}

		// Token: 0x0600041A RID: 1050 RVA: 0x00008FC0 File Offset: 0x000071C0
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}
