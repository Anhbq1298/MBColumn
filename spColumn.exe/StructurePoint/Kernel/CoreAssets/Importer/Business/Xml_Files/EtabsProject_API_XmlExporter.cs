using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using #7hc;
using #hTb;
using #w1i;
using #x1i;
using ETABSv1;
using StructurePoint.Kernel.CoreAssets.Importer.Core;

namespace StructurePoint.Kernel.CoreAssets.Importer.Business.Xml_Files
{
	// Token: 0x02000E80 RID: 3712
	internal static class EtabsProject_API_XmlExporter
	{
		// Token: 0x060084CF RID: 33999 RVA: 0x001CA918 File Offset: 0x001C8B18
		private static string #U7h(string #rEd, List<string> #V7h, string[] #D7h, bool #a4h)
		{
			int num = #V7h.IndexOf(#rEd.ToLower());
			if (num >= 0)
			{
				return #D7h[num];
			}
			if (#a4h)
			{
				throw new #C6h(string.Format(#Ab.SpImporterExceptionExportXmlFailed_TableNotFound, #rEd), #z6h.#h);
			}
			return #Phc.#3hc(107381628);
		}

		// Token: 0x060084D0 RID: 34000 RVA: 0x001CA95C File Offset: 0x001C8B5C
		private static XDocument #W7h(EtabsConnection #X7h, string #D7h)
		{
			if (#D7h == #Phc.#3hc(107381628))
			{
				return null;
			}
			int num = 0;
			string[] array = new string[0];
			string text = #Phc.#3hc(107381628);
			#X7h.#F6h(#X7h.EtabsModel.DatabaseTables.GetTableForDisplayXMLString(#D7h, ref array, #Phc.#3hc(107381628), false, ref num, ref text), string.Format(#Ab.SpImporterExceptionExportXmlFailed_TableContent, #D7h), #z6h.#h);
			return XDocument.Parse(text);
		}

		// Token: 0x060084D1 RID: 34001 RVA: 0x001CA9CC File Offset: 0x001C8BCC
		private static void #c7h(EtabsConnection #X7h, bool #h6h)
		{
			bool isUserBaseReactionLocation = false;
			double userBaseReactionX = 0.0;
			double userBaseReactionY = 0.0;
			double userBaseReactionZ = 0.0;
			bool isAllModes = false;
			int startMode = 0;
			int endMode = 0;
			bool isAllBucklingModes = false;
			int startBucklingMode = 0;
			int endBucklingMode = 0;
			int multistepStatic = 0;
			int nonlinearStatic = 0;
			int modalHistory = 0;
			int directHistory = 0;
			int combo = 0;
			#X7h.#F6h(#X7h.EtabsModel.DatabaseTables.GetOutputOptionsForDisplay(ref isUserBaseReactionLocation, ref userBaseReactionX, ref userBaseReactionY, ref userBaseReactionZ, ref isAllModes, ref startMode, ref endMode, ref isAllBucklingModes, ref startBucklingMode, ref endBucklingMode, ref multistepStatic, ref nonlinearStatic, ref modalHistory, ref directHistory, ref combo), #Ab.SpImporterExceptionExportXmlFailed_GetExpOpt, #z6h.#h);
			multistepStatic = (#h6h ? 1 : 2);
			nonlinearStatic = (#h6h ? 1 : 2);
			modalHistory = (#h6h ? 1 : 2);
			directHistory = (#h6h ? 1 : 2);
			combo = (#h6h ? 1 : 2);
			#X7h.#F6h(#X7h.EtabsModel.DatabaseTables.SetOutputOptionsForDisplay(isUserBaseReactionLocation, userBaseReactionX, userBaseReactionY, userBaseReactionZ, isAllModes, startMode, endMode, isAllBucklingModes, startBucklingMode, endBucklingMode, multistepStatic, nonlinearStatic, modalHistory, directHistory, combo), #Ab.SpImporterExceptionExportXmlFailed_SetExpOpt, #z6h.#h);
			string[] array = new string[]
			{
				#Phc.#3hc(107381628)
			};
			#X7h.#F6h(#X7h.EtabsModel.DatabaseTables.SetLoadCasesSelectedForDisplay(ref array), #Ab.SpImporterExceptionExportXmlFailed_DeselectCases, #z6h.#h);
			#X7h.#F6h(#X7h.EtabsModel.DatabaseTables.SetLoadPatternsSelectedForDisplay(ref array), #Ab.SpImporterExceptionExportXmlFailed_DeselectPatterns, #z6h.#h);
			#X7h.#F6h(#X7h.EtabsModel.DatabaseTables.SetLoadCombinationsSelectedForDisplay(ref array), #Ab.SpImporterExceptionExportXmlFailed_DeselectCombos, #z6h.#h);
		}

		// Token: 0x060084D2 RID: 34002 RVA: 0x001CAB28 File Offset: 0x001C8D28
		private static void #Y7h(EtabsConnection #X7h, string #Z7h)
		{
			string[] array = new string[]
			{
				#Z7h
			};
			#X7h.#F6h(#X7h.EtabsModel.DatabaseTables.SetLoadCombinationsSelectedForDisplay(ref array), #Ab.SpImporterExceptionExportXmlFailed_SelectCombo, #z6h.#h);
		}

		// Token: 0x060084D3 RID: 34003 RVA: 0x001CAB60 File Offset: 0x001C8D60
		private static void #07h(XDocument #Ukc)
		{
			Dictionary<eForce, string> dictionary = new Dictionary<eForce, string>
			{
				{
					eForce.lb,
					#Phc.#3hc(107230569)
				},
				{
					eForce.kip,
					#Phc.#3hc(107230564)
				},
				{
					eForce.N,
					#Phc.#3hc(107230591)
				},
				{
					eForce.kN,
					#Phc.#3hc(107230586)
				},
				{
					eForce.kgf,
					#Phc.#3hc(107230581)
				}
			};
			Dictionary<eLength, string> dictionary2 = new Dictionary<eLength, string>
			{
				{
					eLength.inch,
					#Phc.#3hc(107265223)
				},
				{
					eLength.ft,
					#Phc.#3hc(107230535)
				},
				{
					eLength.mm,
					#Phc.#3hc(107230530)
				},
				{
					eLength.cm,
					#Phc.#3hc(107230557)
				},
				{
					eLength.m,
					#Phc.#3hc(107230552)
				}
			};
			Dictionary<eTemperature, string> dictionary3 = new Dictionary<eTemperature, string>
			{
				{
					eTemperature.C,
					#Phc.#3hc(107408077)
				},
				{
					eTemperature.F,
					#Phc.#3hc(107455038)
				}
			};
			#Ukc.Root.Element(#Phc.#3hc(107229369)).Element(#Phc.#3hc(107230517)).Value = string.Concat(new string[]
			{
				dictionary[eForce.lb],
				#Phc.#3hc(107376612),
				dictionary2[eLength.inch],
				#Phc.#3hc(107376612),
				dictionary3[eTemperature.F]
			});
		}

		// Token: 0x060084D4 RID: 34004 RVA: 0x001CACC4 File Offset: 0x001C8EC4
		private static void #17h(EtabsConnection #X7h, string #D7h, List<Tuple<string, XDocument>> #27h)
		{
			XDocument xdocument = EtabsProject_API_XmlExporter.#W7h(#X7h, #D7h);
			if (#D7h == #Phc.#3hc(107230506))
			{
				EtabsProject_API_XmlExporter.#07h(xdocument);
			}
			if (xdocument != null)
			{
				#27h.Add(new Tuple<string, XDocument>(#D7h, xdocument));
			}
		}

		// Token: 0x060084D5 RID: 34005 RVA: 0x001CAD04 File Offset: 0x001C8F04
		private static List<Tuple<string, XDocument>> #37h(EtabsConnection #X7h, IEnumerable<string> #wkh, bool #h6h)
		{
			int num = 0;
			string[] #D7h = new string[0];
			string[] source = new string[0];
			int[] array = new int[0];
			eForce forceUnits = eForce.NotApplicable;
			eLength lengthUnits = eLength.NotApplicable;
			eTemperature temperatureUnits = eTemperature.NotApplicable;
			#X7h.#F6h(#X7h.EtabsModel.GetPresentUnits_2(ref forceUnits, ref lengthUnits, ref temperatureUnits), #Ab.SpImporterExceptionExportXmlFailed_GetUnits, #z6h.#h);
			List<Tuple<string, XDocument>> result;
			try
			{
				EtabsProject_API_XmlExporter.#c7h(#X7h, #h6h);
				#X7h.#F6h(#X7h.EtabsModel.SetPresentUnits_2(eForce.lb, eLength.inch, eTemperature.F), #Ab.SpImporterExceptionExportXmlFailed_SetUnits, #z6h.#h);
				#X7h.#F6h(#X7h.EtabsModel.DatabaseTables.GetAvailableTables(ref num, ref #D7h, ref source, ref array), #Ab.SpImporterExceptionExportXmlFailed_TableList, #z6h.#h);
				List<string> #V7h = source.Select(new Func<string, string>(EtabsProject_API_XmlExporter.<>c.<>9.#w9h)).ToList<string>();
				EtabsProject_API_XmlExporter.#U7h(#Phc.#3hc(107230120), #V7h, #D7h, true);
				#63h<string, bool, bool>[] array2 = new #63h<string, bool, bool>[]
				{
					new #63h<string, bool, bool>(#Phc.#3hc(107230506), true, false),
					new #63h<string, bool, bool>(#Phc.#3hc(107229726), true, false),
					new #63h<string, bool, bool>(#Phc.#3hc(107230193), true, false),
					new #63h<string, bool, bool>(#Phc.#3hc(107230120), true, false),
					new #63h<string, bool, bool>(#Phc.#3hc(107230095), false, false),
					new #63h<string, bool, bool>(#Phc.#3hc(107230058), false, true),
					new #63h<string, bool, bool>(#Phc.#3hc(107230025), false, true)
				};
				List<Tuple<string, XDocument>> list = new List<Tuple<string, XDocument>>(array2.Length);
				foreach (#63h<string, bool, bool> #63h in array2)
				{
					string text = EtabsProject_API_XmlExporter.#U7h(#63h.tableName, #V7h, #D7h, #63h.mustExist);
					Logger.#DSi(#Phc.#3hc(107229340) + #63h.tableName + #Phc.#3hc(107229287) + text);
					if (!#63h.loadByLoad)
					{
						EtabsProject_API_XmlExporter.#17h(#X7h, text, list);
					}
					else
					{
						foreach (string text2 in #wkh)
						{
							Logger.#DSi(#Phc.#3hc(107229306) + text2);
							EtabsProject_API_XmlExporter.#Y7h(#X7h, text2);
							EtabsProject_API_XmlExporter.#17h(#X7h, text, list);
						}
					}
				}
				result = list;
			}
			finally
			{
				#X7h.#F6h(#X7h.EtabsModel.SetPresentUnits_2(forceUnits, lengthUnits, temperatureUnits), #Ab.SpImporterExceptionExportXmlFailed_SetUnits, #z6h.#h);
			}
			return result;
		}

		// Token: 0x060084D6 RID: 34006 RVA: 0x001CAF94 File Offset: 0x001C9194
		internal static void #xRb(EtabsConnection #X7h, string #4Hc, IEnumerable<string> #wkh, bool #h6h)
		{
			Logger.#DSi(string.Concat(new string[]
			{
				#Phc.#3hc(107229249),
				Environment.NewLine,
				#Phc.#3hc(107229236),
				#4Hc,
				Environment.NewLine,
				#Phc.#3hc(107229191),
				#wkh.#O1i(),
				Environment.NewLine,
				string.Format(#Phc.#3hc(107229210), #h6h)
			}).#Q1i(#Phc.#3hc(107464305), 1, true));
			XDocument xdocument = XDocument.Parse(#Phc.#3hc(107229665));
			foreach (Tuple<string, XDocument> tuple in EtabsProject_API_XmlExporter.#37h(#X7h, #wkh, #h6h))
			{
				string text = tuple.Item1.Replace(#Phc.#3hc(107399922), #Phc.#3hc(107230614));
				Logger.#DSi(#Phc.#3hc(107229580) + text);
				IEnumerable<XElement> content = tuple.Item2.Root.Elements(text);
				xdocument.Root.Add(content);
			}
			xdocument.Save(#4Hc);
		}

		// Token: 0x040036CA RID: 14026
		private const eLength #a = eLength.inch;

		// Token: 0x040036CB RID: 14027
		private const eForce #b = eForce.lb;

		// Token: 0x040036CC RID: 14028
		private const eTemperature #c = eTemperature.F;
	}
}
