using System;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using #5Z;
using #7hc;
using #wdd;
using StructurePoint.Products.Column.Model.Entities;

namespace StructurePoint.Products.Column.Views.Core.Converters
{
	// Token: 0x0200006C RID: 108
	internal sealed class ServiceLoadToTextConverter : IValueConverter
	{
		// Token: 0x06000410 RID: 1040 RVA: 0x00087600 File Offset: 0x00085800
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			ServiceLoad serviceLoad = value as ServiceLoad;
			if (serviceLoad != null)
			{
				return this.FormatServiceLoad(serviceLoad);
			}
			return string.Empty;
		}

		// Token: 0x06000411 RID: 1041 RVA: 0x00003909 File Offset: 0x00001B09
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000412 RID: 1042 RVA: 0x00087630 File Offset: 0x00085830
		private string FormatServiceLoad(ServiceLoad serviceLoad)
		{
			StringBuilder stringBuilder = new StringBuilder();
			string value = this.FormatLoadCaseData(#Phc.#3hc(107395517), serviceLoad.Dead);
			string value2 = this.FormatLoadCaseData(#Phc.#3hc(107386861), serviceLoad.Live);
			string value3 = this.FormatLoadCaseData(#Phc.#3hc(107386856), serviceLoad.Wind);
			string value4 = this.FormatLoadCaseData(#Phc.#3hc(107386851), serviceLoad.Earthquake);
			string value5 = this.FormatLoadCaseData(#Phc.#3hc(107386878), serviceLoad.Snow);
			stringBuilder.Append(value);
			stringBuilder.Append(value2);
			stringBuilder.Append(value3);
			stringBuilder.Append(value4);
			stringBuilder.Append(value5);
			stringBuilder.Remove(stringBuilder.Length - 2, 2);
			return stringBuilder.ToString();
		}

		// Token: 0x06000413 RID: 1043 RVA: 0x00087718 File Offset: 0x00085918
		private string FormatLoadCaseData(string loadCaseLetter, #V3 loadCaseData)
		{
			string format = #Phc.#3hc(107386873);
			return string.Format(format, new object[]
			{
				loadCaseLetter,
				this.FormatFixed(loadCaseData.AxialLoad),
				this.FormatFixed(loadCaseData.MomentXTop),
				this.FormatFixed(loadCaseData.MomentXBottom),
				this.FormatFixed(loadCaseData.MomentYTop),
				this.FormatFixed(loadCaseData.MomentYBottom)
			});
		}

		// Token: 0x06000414 RID: 1044 RVA: 0x00008FE7 File Offset: 0x000071E7
		private string FormatFixed(float value)
		{
			return #ned.#led(new double?((double)value));
		}
	}
}
