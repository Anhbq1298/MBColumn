using System;
using System.IO;
using #7hc;
using StructurePoint.CoreAssets.AppManager.Column.Storage.ImportExport;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Localizer;

namespace #xKe
{
	// Token: 0x02001274 RID: 4724
	internal sealed class #CSd
	{
		// Token: 0x06009E81 RID: 40577 RVA: 0x0007CC02 File Offset: 0x0007AE02
		public static string #dy(string #9Ke)
		{
			if (!string.IsNullOrWhiteSpace(#9Ke))
			{
				return Path.GetFileNameWithoutExtension(#9Ke);
			}
			return Strings.StringUntitled;
		}

		// Token: 0x06009E82 RID: 40578 RVA: 0x00219B74 File Offset: 0x00217D74
		public static string #dy(string #9Ke, SectionImportExportType #8Q)
		{
			string str = #CSd.#dy(#9Ke);
			string str2;
			switch (#8Q)
			{
			case SectionImportExportType.Section:
				str2 = Strings.StringSection;
				break;
			case SectionImportExportType.OnlyGeometry:
				str2 = Strings.StringGeometry;
				break;
			case SectionImportExportType.OnlyReinforcement:
				str2 = Strings.StringReinforcement;
				break;
			default:
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107313322), #8Q, null);
			}
			return str + #Phc.#3hc(107408434) + str2;
		}

		// Token: 0x06009E83 RID: 40579 RVA: 0x00219BDC File Offset: 0x00217DDC
		public static string #dy(string #9Ke, LoadType #CEe)
		{
			string text = #CSd.#dy(#9Ke);
			string str;
			switch (#CEe)
			{
			case LoadType.Undefined:
			case LoadType.Axial:
			case LoadType.NoLoads:
				return text;
			case LoadType.Factored:
				str = #Phc.#3hc(107313337);
				goto IL_5C;
			case LoadType.Service:
				str = #Phc.#3hc(107409200);
				goto IL_5C;
			}
			throw new ArgumentOutOfRangeException(#Phc.#3hc(107282892), #CEe, null);
			IL_5C:
			return text + #Phc.#3hc(107408434) + str;
		}
	}
}
