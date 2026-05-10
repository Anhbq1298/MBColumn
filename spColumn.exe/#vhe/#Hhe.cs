using System;
using System.Globalization;
using #7hc;
using #Nhe;
using StructurePoint.CoreAssets.AppManager.Column.Templates;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Engine.Helpers;

namespace #vhe
{
	// Token: 0x02001091 RID: 4241
	internal sealed class #Hhe
	{
		// Token: 0x060090D1 RID: 37073 RVA: 0x001EB1C8 File Offset: 0x001E93C8
		public static bool #Fhe(TemplateParameterType #C, string #f, out #0he #Ghe)
		{
			#Ghe = null;
			switch (#C)
			{
			case TemplateParameterType.Integer:
			case TemplateParameterType.IntegerList:
			{
				int #2he;
				if (int.TryParse(#f, NumberStyles.Integer, CultureInfo.InvariantCulture, out #2he))
				{
					#Ghe = new #0he(#2he);
					return true;
				}
				return false;
			}
			case TemplateParameterType.Double:
			case TemplateParameterType.DoubleList:
			{
				double #1he;
				if (double.TryParse(#f, NumberStyles.Float, CultureInfo.InvariantCulture, out #1he))
				{
					#Ghe = new #0he(#1he);
					return true;
				}
				return false;
			}
			case TemplateParameterType.Boolean:
				return true;
			case TemplateParameterType.BarSize:
			{
				int? num = StandardBarsProvider.#vCb(#f);
				if (num == null)
				{
					return false;
				}
				#Ghe = new #0he(num.Value);
				return true;
			}
			case TemplateParameterType.List:
				#Ghe = new #0he(#f);
				return true;
			default:
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107383497), #C, null);
			}
		}
	}
}
