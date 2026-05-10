using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using #7hc;
using #w1i;
using #x1i;
using StructurePoint.Kernel.CoreAssets.Importer.DataClasses;
using StructurePoint.Kernel.CoreAssets.Operation.Localizator;

namespace StructurePoint.Kernel.CoreAssets.Importer.Business.Xml_Files
{
	// Token: 0x02000E7C RID: 3708
	internal sealed class EtabsProjectCoreXmlImporter
	{
		// Token: 0x060084AA RID: 33962 RVA: 0x0006BE32 File Offset: 0x0006A032
		private EtabsProjectCoreXmlImporter(string filePath, ProjectType projectType, UnitsSystem unitsSystem)
		{
			this.#d = XDocument.Load(filePath);
			this.#a = projectType;
			this.#b = unitsSystem;
		}

		// Token: 0x060084AB RID: 33963 RVA: 0x0006BE54 File Offset: 0x0006A054
		private string #C7h(string #D7h)
		{
			return #D7h.Replace(#Phc.#3hc(107399922), #Phc.#3hc(107230614));
		}

		// Token: 0x060084AC RID: 33964 RVA: 0x001C9A88 File Offset: 0x001C7C88
		private List<XElement> #KZg(string #D7h, bool #a4h)
		{
			string expandedName = this.#C7h(#D7h);
			List<XElement> list = this.#d.Root.Elements(expandedName).ToList<XElement>();
			if (#a4h && (list == null || list.Count<XElement>() == 0))
			{
				throw new #C6h(string.Format(#Ab.SpImporterExceptionTableNotFoundInXML, #D7h), #z6h.#i);
			}
			return list;
		}

		// Token: 0x060084AD RID: 33965 RVA: 0x001C9ADC File Offset: 0x001C7CDC
		private void #ywe(string #E7h)
		{
			Dictionary<string, ForceUnit> dictionary = new Dictionary<string, ForceUnit>(StringComparer.InvariantCultureIgnoreCase)
			{
				{
					#Phc.#3hc(107230569),
					ForceUnit.lbf
				},
				{
					#Phc.#3hc(107230564),
					ForceUnit.kip
				},
				{
					#Phc.#3hc(107230591),
					ForceUnit.N
				},
				{
					#Phc.#3hc(107230586),
					ForceUnit.kN
				},
				{
					#Phc.#3hc(107230581),
					ForceUnit.kG
				},
				{
					#Phc.#3hc(107230576),
					ForceUnit.tonf
				}
			};
			Dictionary<string, LengthUnit> dictionary2 = new Dictionary<string, LengthUnit>(StringComparer.InvariantCultureIgnoreCase)
			{
				{
					#Phc.#3hc(107265223),
					LengthUnit.inch
				},
				{
					#Phc.#3hc(107230535),
					LengthUnit.foot
				},
				{
					#Phc.#3hc(107230530),
					LengthUnit.mm
				},
				{
					#Phc.#3hc(107230557),
					LengthUnit.cm
				},
				{
					#Phc.#3hc(107230552),
					LengthUnit.m
				},
				{
					#Phc.#3hc(107230547),
					LengthUnit.micron
				}
			};
			UnitsSystem unitsSystem = this.#b;
			ForceUnit forceUnitOut;
			LengthUnit lengthUnitOut;
			if (unitsSystem != UnitsSystem.English)
			{
				if (unitsSystem != UnitsSystem.Metric)
				{
					throw new #C6h(string.Format(#Ab.SpImporterExceptionLoadFromXMLFailed_UnknownUnitSys, this.#b.ToString()), #z6h.#j);
				}
				forceUnitOut = ForceUnit.kN;
				lengthUnitOut = LengthUnit.m;
			}
			else
			{
				forceUnitOut = ForceUnit.kip;
				lengthUnitOut = LengthUnit.foot;
			}
			string[] array = #E7h.Split(new char[]
			{
				','
			});
			if (!dictionary.ContainsKey(array[0]))
			{
				throw new #C6h(string.Format(#Ab.SpImporterExceptionLoadFromXMLFailed_UnknownForceUnit, array[0]), #z6h.#j);
			}
			if (!dictionary2.ContainsKey(array[1]))
			{
				throw new #C6h(string.Format(#Ab.SpImporterExceptionLoadFromXMLFailed_UnknownLenUnit, array[1]), #z6h.#j);
			}
			this.#c = new ConsistentUnitsConverter(dictionary[array[0]], dictionary2[array[1]], forceUnitOut, lengthUnitOut);
		}

		// Token: 0x060084AE RID: 33966 RVA: 0x001C9C88 File Offset: 0x001C7E88
		private void #F7h()
		{
			string #E7h = this.#KZg(#Phc.#3hc(107230506), true).First<XElement>().Element(#Phc.#3hc(107230517)).Value.Replace(#Phc.#3hc(107399922), #Phc.#3hc(107381628)).ToLower();
			this.#ywe(#E7h);
		}

		// Token: 0x060084AF RID: 33967 RVA: 0x001C9CEC File Offset: 0x001C7EEC
		private ETABSLoadCaseType #szh(string #G7h, string #H7h)
		{
			if (#H7h.StartsWith(#Phc.#3hc(107230472)))
			{
				return ETABSLoadCaseType.Modal;
			}
			if (#H7h.StartsWith(#Phc.#3hc(107230495)))
			{
				return ETABSLoadCaseType.LinearStatic;
			}
			if (#H7h.StartsWith(#Phc.#3hc(107229930)))
			{
				return ETABSLoadCaseType.NonlinearStatic;
			}
			if (#H7h.StartsWith(#Phc.#3hc(107229937)))
			{
				return ETABSLoadCaseType.ResponseSpectrum;
			}
			if (#H7h.StartsWith(#Phc.#3hc(107229912)))
			{
				return ETABSLoadCaseType.LinearHistory;
			}
			if (#H7h.StartsWith(#Phc.#3hc(107229883)))
			{
				return ETABSLoadCaseType.Buckling;
			}
			if (#H7h.StartsWith(#Phc.#3hc(107229838)))
			{
				return ETABSLoadCaseType.HyperStatic;
			}
			if (#H7h.StartsWith(#Phc.#3hc(107229930)))
			{
				return ETABSLoadCaseType.NonlinearStatic;
			}
			if (#H7h.StartsWith(#Phc.#3hc(107229853)))
			{
				return ETABSLoadCaseType.LinearDynamic;
			}
			if (#H7h.StartsWith(#Phc.#3hc(107229808)))
			{
				return ETABSLoadCaseType.NonlinearHistory;
			}
			if (#H7h.StartsWith(#Phc.#3hc(107229743)))
			{
				return ETABSLoadCaseType.NonlinearDynamic;
			}
			throw new #C6h(string.Format(#Ab.SpImporterExceptionLoadFromXMLFailed_UnknownCaseType, #H7h, #G7h), #z6h.#j);
		}

		// Token: 0x060084B0 RID: 33968 RVA: 0x001C9DEC File Offset: 0x001C7FEC
		private Dictionary<string, ETABSLoadCase> #I7h()
		{
			return this.#KZg(#Phc.#3hc(107229726), true).Select(new Func<XElement, ETABSLoadCase>(this.#R7h)).ToDictionary(new Func<ETABSLoadCase, string>(EtabsProjectCoreXmlImporter.<>c.<>9.#g9h), new Func<ETABSLoadCase, ETABSLoadCase>(EtabsProjectCoreXmlImporter.<>c.<>9.#h9h));
		}

		// Token: 0x060084B1 RID: 33969 RVA: 0x001C9E60 File Offset: 0x001C8060
		private Dictionary<string, ETABSLoadCombination> #J7h(IEnumerable<string> #K7h)
		{
			List<XElement> source = this.#KZg(#Phc.#3hc(107230193), true);
			List<string> list = source.Where(new Func<XElement, bool>(EtabsProjectCoreXmlImporter.<>c.<>9.#i9h)).Select(new Func<XElement, string>(EtabsProjectCoreXmlImporter.<>c.<>9.#j9h)).ToList<string>();
			Dictionary<string, ETABSLoadCombination> dictionary = new Dictionary<string, ETABSLoadCombination>(list.Count<string>());
			using (List<string>.Enumerator enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					EtabsProjectCoreXmlImporter.#21b #21b = new EtabsProjectCoreXmlImporter.#21b();
					#21b.#a = enumerator.Current;
					ETABSLoadCombination etabsloadCombination = new ETABSLoadCombination(#21b.#a, null, null);
					foreach (string text in source.Where(new Func<XElement, bool>(#21b.#u9h)).Select(new Func<XElement, string>(EtabsProjectCoreXmlImporter.<>c.<>9.#k9h)))
					{
						if (#K7h.Contains(text))
						{
							etabsloadCombination.LoadCases.Add(text);
						}
						else
						{
							etabsloadCombination.LoadCombinations.Add(text);
						}
					}
					dictionary.Add(#21b.#a, etabsloadCombination);
				}
			}
			return dictionary;
		}

		// Token: 0x060084B2 RID: 33970 RVA: 0x001C9FD4 File Offset: 0x001C81D4
		private List<ETABSStory> #L7h()
		{
			List<XElement> source = this.#KZg(#Phc.#3hc(107230120), true);
			var source2 = source.Select(new Func<XElement, int, <>f__AnonymousType3<int, string, string, double>>(EtabsProjectCoreXmlImporter.<>c.<>9.#l9h));
			List<ETABSStory> list = new List<ETABSStory>(source.Count<XElement>());
			List<string> list2 = source2.Select(new Func<<>f__AnonymousType3<int, string, string, double>, string>(EtabsProjectCoreXmlImporter.<>c.<>9.#m9h)).Distinct<string>().ToList<string>();
			bool flag = list2.Count > 2;
			using (List<string>.Enumerator enumerator = list2.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					EtabsProjectCoreXmlImporter.#iZb #iZb = new EtabsProjectCoreXmlImporter.#iZb();
					#iZb.#a = enumerator.Current;
					var list3 = source2.Where(new Func<<>f__AnonymousType3<int, string, string, double>, bool>(#iZb.#v9h)).OrderByDescending(new Func<<>f__AnonymousType3<int, string, string, double>, int>(EtabsProjectCoreXmlImporter.<>c.<>9.#n9h)).ToList();
					double num = 0.0;
					foreach (var <>f__AnonymousType in list3)
					{
						num += <>f__AnonymousType.Height;
						list.Add(new ETABSStory(<>f__AnonymousType.Name, this.#c.ConvertLength(num), flag ? #iZb.#a : #Phc.#3hc(107381628)));
					}
				}
			}
			return list;
		}

		// Token: 0x060084B3 RID: 33971 RVA: 0x001CA16C File Offset: 0x001C836C
		private List<ETABSFrame> #M7h()
		{
			List<XElement> list = this.#KZg(#Phc.#3hc(107230095), false);
			if (list != null)
			{
				return list.Where(new Func<XElement, bool>(EtabsProjectCoreXmlImporter.<>c.<>9.#o9h)).Select(new Func<XElement, ETABSFrame>(EtabsProjectCoreXmlImporter.<>c.<>9.#p9h)).ToList<ETABSFrame>();
			}
			return new List<ETABSFrame>(0);
		}

		// Token: 0x060084B4 RID: 33972 RVA: 0x001CA1E4 File Offset: 0x001C83E4
		private List<ETABSFactoredLoad> #N7h()
		{
			return this.#KZg(#Phc.#3hc(107230058), true).Where(new Func<XElement, bool>(EtabsProjectCoreXmlImporter.<>c.<>9.#q9h)).Select(new Func<XElement, ETABSFactoredLoad>(this.#S7h)).ToList<ETABSFactoredLoad>();
		}

		// Token: 0x060084B5 RID: 33973 RVA: 0x001CA23C File Offset: 0x001C843C
		private List<ETABSFactoredLoad> #O7h(out List<ETABSPier> #P7h)
		{
			List<XElement> list = this.#KZg(#Phc.#3hc(107230025), false);
			if (list != null)
			{
				#P7h = list.GroupBy(new Func<XElement, <>f__AnonymousType4<string, string>>(EtabsProjectCoreXmlImporter.<>c.<>9.#r9h)).Select(new Func<IGrouping<<>f__AnonymousType4<string, string>, XElement>, ETABSPier>(EtabsProjectCoreXmlImporter.<>c.<>9.#s9h)).ToList<ETABSPier>();
				return list.Where(new Func<XElement, bool>(EtabsProjectCoreXmlImporter.<>c.<>9.#t9h)).Select(new Func<XElement, ETABSFactoredLoad>(this.#T7h)).ToList<ETABSFactoredLoad>();
			}
			#P7h = new List<ETABSPier>();
			return new List<ETABSFactoredLoad>();
		}

		// Token: 0x060084B6 RID: 33974 RVA: 0x001CA2FC File Offset: 0x001C84FC
		private ETABSProjectCore_Ram #Q7h()
		{
			this.#F7h();
			Dictionary<string, ETABSLoadCase> dictionary = this.#I7h();
			Dictionary<string, ETABSLoadCombination> loadCombinations = this.#J7h(dictionary.Keys);
			List<ETABSStory> stories = this.#L7h();
			List<ETABSFrame> list = this.#M7h();
			List<ETABSFactoredLoad> columnForces_AllSteps = (list.Count > 0) ? this.#N7h() : new List<ETABSFactoredLoad>();
			List<ETABSPier> piers;
			List<ETABSFactoredLoad> pierForces_AllSteps = this.#O7h(out piers);
			return new ETABSProjectCore_Ram(this.#a, this.#b, dictionary, loadCombinations, stories, list, piers, columnForces_AllSteps, null, pierForces_AllSteps, null);
		}

		// Token: 0x060084B7 RID: 33975 RVA: 0x0006BE70 File Offset: 0x0006A070
		internal static ETABSProjectCore_Ram #GD(string #4Hc, ProjectType #36h, UnitsSystem #Z6h)
		{
			if (!File.Exists(#4Hc))
			{
				throw new #C6h(string.Format(#Ab.SpImporterExceptionFileNotFound, #4Hc), #z6h.#l);
			}
			return new EtabsProjectCoreXmlImporter(#4Hc, #36h, #Z6h).#Q7h();
		}

		// Token: 0x060084B8 RID: 33976 RVA: 0x001CA370 File Offset: 0x001C8570
		[CompilerGenerated]
		private ETABSLoadCase #R7h(XElement #u1b)
		{
			return new ETABSLoadCase(#u1b.Element(#Phc.#3hc(107409209)).Value, this.#szh(#u1b.Element(#Phc.#3hc(107409209)).Value, #u1b.Element(#Phc.#3hc(107462703)).Value), true);
		}

		// Token: 0x060084B9 RID: 33977 RVA: 0x001CA3D8 File Offset: 0x001C85D8
		[CompilerGenerated]
		private ETABSFactoredLoad #S7h(XElement #u1b)
		{
			XElement xelement = #u1b.Element(#Phc.#3hc(107359852));
			double #D5h = double.Parse((xelement != null) ? xelement.Value : null, CultureInfo.InvariantCulture);
			XElement xelement2 = #u1b.Element(#Phc.#3hc(107230040));
			double #E5h = double.Parse((xelement2 != null) ? xelement2.Value : null, CultureInfo.InvariantCulture);
			XElement xelement3 = #u1b.Element(#Phc.#3hc(107230035));
			double forceIn;
			double momentIn;
			double momentIn2;
			ETABSFactoredLoad.#C5h(#D5h, #E5h, double.Parse((xelement3 != null) ? xelement3.Value : null, CultureInfo.InvariantCulture), out forceIn, out momentIn, out momentIn2);
			string value = #u1b.Element(#Phc.#3hc(107229998)).Value;
			string objectData = string.Format(#Ab.ElementNames_Label_Story, #u1b.Element(#Phc.#3hc(107230005)).Value, #u1b.Element(#Phc.#3hc(107229964)).Value);
			string value2 = #u1b.Element(#Phc.#3hc(107229955)).Value;
			double station = this.#c.ConvertLength(double.Parse(#u1b.Element(#Phc.#3hc(107229418)).Value, CultureInfo.InvariantCulture));
			string location = #Phc.#3hc(107381628);
			XElement xelement4 = #u1b.Element(#Phc.#3hc(107229437));
			string stepType = ((xelement4 != null) ? xelement4.Value : null) ?? #Phc.#3hc(107381628);
			XElement xelement5 = #u1b.Element(#Phc.#3hc(107229384));
			return new ETABSFactoredLoad(value, objectData, value2, station, location, stepType, double.Parse(((xelement5 != null) ? xelement5.Value : null) ?? #Phc.#3hc(107426661)), EnvelopeType.NotAnEnvelope, #u1b.Element(#Phc.#3hc(107229359)).Value, this.#c.ConvertForce(forceIn), this.#c.ConvertMoment(momentIn), this.#c.ConvertMoment(momentIn2));
		}

		// Token: 0x060084BA RID: 33978 RVA: 0x001CA5C4 File Offset: 0x001C87C4
		[CompilerGenerated]
		private ETABSFactoredLoad #T7h(XElement #u1b)
		{
			XElement xelement = #u1b.Element(#Phc.#3hc(107359852));
			double #D5h = double.Parse((xelement != null) ? xelement.Value : null, CultureInfo.InvariantCulture);
			XElement xelement2 = #u1b.Element(#Phc.#3hc(107230040));
			double #E5h = double.Parse((xelement2 != null) ? xelement2.Value : null, CultureInfo.InvariantCulture);
			XElement xelement3 = #u1b.Element(#Phc.#3hc(107230035));
			double forceIn;
			double momentIn;
			double momentIn2;
			ETABSFactoredLoad.#J5h(#D5h, #E5h, double.Parse((xelement3 != null) ? xelement3.Value : null, CultureInfo.InvariantCulture), out forceIn, out momentIn, out momentIn2);
			string objectName = #u1b.Element(#Phc.#3hc(107229346)).Value + #u1b.Element(#Phc.#3hc(107229964)).Value;
			string objectData = string.Format(#Ab.ElementNames_Label_Story, #u1b.Element(#Phc.#3hc(107229346)).Value, #u1b.Element(#Phc.#3hc(107229964)).Value);
			string value = #u1b.Element(#Phc.#3hc(107229955)).Value;
			double station = (#u1b.Element(#Phc.#3hc(107439035)).Value == #Phc.#3hc(107280488)) ? 0.0 : 1.0;
			string value2 = #u1b.Element(#Phc.#3hc(107439035)).Value;
			XElement xelement4 = #u1b.Element(#Phc.#3hc(107229437));
			string stepType = ((xelement4 != null) ? xelement4.Value : null) ?? #Phc.#3hc(107381628);
			XElement xelement5 = #u1b.Element(#Phc.#3hc(107229384));
			return new ETABSFactoredLoad(objectName, objectData, value, station, value2, stepType, double.Parse(((xelement5 != null) ? xelement5.Value : null) ?? #Phc.#3hc(107426661)), EnvelopeType.NotAnEnvelope, #Phc.#3hc(107381628), this.#c.ConvertForce(forceIn), this.#c.ConvertMoment(momentIn), this.#c.ConvertMoment(momentIn2));
		}

		// Token: 0x040036B5 RID: 14005
		private readonly ProjectType #a;

		// Token: 0x040036B6 RID: 14006
		private readonly UnitsSystem #b;

		// Token: 0x040036B7 RID: 14007
		private ConsistentUnitsConverter #c;

		// Token: 0x040036B8 RID: 14008
		private readonly XDocument #d;

		// Token: 0x02000E7E RID: 3710
		[CompilerGenerated]
		private sealed class #21b
		{
			// Token: 0x060084CC RID: 33996 RVA: 0x001CA8C8 File Offset: 0x001C8AC8
			internal bool #u9h(XElement #u1b)
			{
				return #u1b.Element(#Phc.#3hc(107409209)).Value == this.#a && #u1b.Element(#Phc.#3hc(107228454)) != null;
			}

			// Token: 0x040036C8 RID: 14024
			public string #a;
		}

		// Token: 0x02000E7F RID: 3711
		[CompilerGenerated]
		private sealed class #iZb
		{
			// Token: 0x060084CE RID: 33998 RVA: 0x0006BFD7 File Offset: 0x0006A1D7
			internal bool #v9h(<>f__AnonymousType3<int, string, string, double> #u1b)
			{
				return #u1b.Tower == this.#a;
			}

			// Token: 0x040036C9 RID: 14025
			public string #a;
		}
	}
}
