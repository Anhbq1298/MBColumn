using System;
using System.Globalization;
using System.Text;
using #7hc;
using #Wse;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Model;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Settings;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace #Oze
{
	// Token: 0x020011FC RID: 4604
	internal static class #Qze
	{
		// Token: 0x06009A52 RID: 39506 RVA: 0x0020D5AC File Offset: 0x0020B7AC
		public static string #Pze(#lte #Od, Diagram2DType #C, double #Sb, #mAe #6c, bool #5bb)
		{
			string text = #Qze.#Pze(#Od, #C, #Sb, #5bb);
			if (!#6c.IsActive)
			{
				return text;
			}
			return string.Format(Strings.StringSuperImposePrefix0, text);
		}

		// Token: 0x06009A53 RID: 39507 RVA: 0x0007A3C5 File Offset: 0x000785C5
		public static string #Pze(#lte #Od, Diagram2DType #C, double #Sb, bool #5bb)
		{
			return #Qze.#Pze(#Od.GeneralInfo, #C, #Sb, #5bb);
		}

		// Token: 0x06009A54 RID: 39508 RVA: 0x0020D5DC File Offset: 0x0020B7DC
		public static string #Pze(GeneralInformation #6h, Diagram2DType #C, double #Sb, bool #5bb)
		{
			StringBuilder stringBuilder = new StringBuilder();
			switch (#C)
			{
			case Diagram2DType.DiagramMM:
				stringBuilder.Append(#Phc.#3hc(107362490));
				break;
			case Diagram2DType.DiagramPM:
				stringBuilder.Append(#Phc.#3hc(107362473));
				break;
			case Diagram2DType.DiagramPMPlus:
				stringBuilder.Append(#Phc.#3hc(107283140));
				break;
			case Diagram2DType.DiagramPMMinus:
				stringBuilder.Append(#Phc.#3hc(107283167));
				break;
			default:
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107383497), #C, null);
			}
			double num = (#C == Diagram2DType.DiagramMM) ? Math.Round(#Sb, 2) : Math.Round(#Sb);
			string format = (#C == Diagram2DType.DiagramMM) ? #Phc.#3hc(107283113) : #Phc.#3hc(107283162);
			stringBuilder.AppendFormat(CultureInfo.CurrentCulture, format, num);
			string arg = (#C == Diagram2DType.DiagramMM) ? #6h.UnitStringF.#S2d() : #Phc.#3hc(107283132);
			stringBuilder.AppendFormat(#Phc.#3hc(107283123), arg);
			if (#5bb)
			{
				stringBuilder.Append(#Phc.#3hc(107382883));
			}
			return stringBuilder.ToString();
		}
	}
}
