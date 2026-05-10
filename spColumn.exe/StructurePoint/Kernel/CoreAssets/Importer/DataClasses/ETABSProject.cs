using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;
using #k2i;
using #w1i;
using #x1i;
using StructurePoint.Kernel.CoreAssets.Importer.Business;
using StructurePoint.Kernel.CoreAssets.Importer.Core;

namespace StructurePoint.Kernel.CoreAssets.Importer.DataClasses
{
	// Token: 0x02000E56 RID: 3670
	public sealed class ETABSProject : IDisposable
	{
		// Token: 0x1700278E RID: 10126
		// (get) Token: 0x0600838D RID: 33677 RVA: 0x0006B4D5 File Offset: 0x000696D5
		// (set) Token: 0x0600838E RID: 33678 RVA: 0x0006B4DD File Offset: 0x000696DD
		internal #B7h Core { get; private set; }

		// Token: 0x0600838F RID: 33679 RVA: 0x001C5078 File Offset: 0x001C3278
		internal ETABSProject(#B7h core)
		{
			this.Core = core;
			Logger.#DSi(#Phc.#3hc(107270384) + this.Core.GetType().Name.Replace(#Phc.#3hc(107270311), #Phc.#3hc(107381628)) + #Phc.#3hc(107270286));
		}

		// Token: 0x1700278F RID: 10127
		// (get) Token: 0x06008390 RID: 33680 RVA: 0x0006B4E6 File Offset: 0x000696E6
		public UnitsSystem UnitsSystem
		{
			get
			{
				return this.Core.UnitsSystem;
			}
		}

		// Token: 0x17002790 RID: 10128
		// (get) Token: 0x06008391 RID: 33681 RVA: 0x0006B4F3 File Offset: 0x000696F3
		public List<ETABSFrame> Columns
		{
			get
			{
				return this.Core.Columns;
			}
		}

		// Token: 0x17002791 RID: 10129
		// (get) Token: 0x06008392 RID: 33682 RVA: 0x0006B500 File Offset: 0x00069700
		public List<ETABSStory> Stories
		{
			get
			{
				return this.Core.Stories;
			}
		}

		// Token: 0x17002792 RID: 10130
		// (get) Token: 0x06008393 RID: 33683 RVA: 0x0006B50D File Offset: 0x0006970D
		public Dictionary<string, ETABSLoadCase> LoadCases
		{
			get
			{
				return this.Core.LoadCases;
			}
		}

		// Token: 0x17002793 RID: 10131
		// (get) Token: 0x06008394 RID: 33684 RVA: 0x001C50DC File Offset: 0x001C32DC
		public Dictionary<string, ETABSLoadCombination> LoadCombinations
		{
			get
			{
				ETABSProject.#rWb #rWb = new ETABSProject.#rWb();
				if (this.#c != null)
				{
					return this.#c;
				}
				#rWb.#a = this.Core.LoadCases;
				#rWb.#b = this.Core.LoadCombinations;
				this.#c = #rWb.#b.Where(new Func<KeyValuePair<string, ETABSLoadCombination>, bool>(#rWb.#j8h)).ToDictionary(new Func<KeyValuePair<string, ETABSLoadCombination>, string>(ETABSProject.<>c.<>9.#k8h), new Func<KeyValuePair<string, ETABSLoadCombination>, ETABSLoadCombination>(ETABSProject.<>c.<>9.#l8h));
				return this.#c;
			}
		}

		// Token: 0x17002794 RID: 10132
		// (get) Token: 0x06008395 RID: 33685 RVA: 0x0006B51A File Offset: 0x0006971A
		public List<ETABSPier> Piers
		{
			get
			{
				return this.Core.Piers;
			}
		}

		// Token: 0x06008396 RID: 33686 RVA: 0x0006B527 File Offset: 0x00069727
		public List<ETABSLoadCaseType> #55h(string #65h)
		{
			return this.Core.LoadCombinations[#65h].#Y5h(this.Core.LoadCases, this.Core.LoadCombinations);
		}

		// Token: 0x06008397 RID: 33687 RVA: 0x001C5188 File Offset: 0x001C3388
		private string #75h(string #oT, string #85h)
		{
			ETABSProject.#uZb #uZb = new ETABSProject.#uZb();
			#uZb.#a = #oT;
			#uZb.#b = #85h;
			return this.Core.Columns.Single(new Func<ETABSFrame, bool>(#uZb.#H8h)).Name;
		}

		// Token: 0x06008398 RID: 33688 RVA: 0x001C51CC File Offset: 0x001C33CC
		private IEnumerable<string> #95h(IEnumerable<string> #a6h, IEnumerable<string> #0E)
		{
			ETABSProject.#wWb #wWb = new ETABSProject.#wWb();
			#wWb.#a = #a6h;
			#wWb.#b = #0E;
			return this.Core.Columns.Where(new Func<ETABSFrame, bool>(#wWb.#I8h)).Select(new Func<ETABSFrame, string>(ETABSProject.<>c.<>9.#m8h));
		}

		// Token: 0x06008399 RID: 33689 RVA: 0x001C5230 File Offset: 0x001C3430
		private IEnumerable<string> #b6h(IEnumerable<string> #c2h, IEnumerable<string> #0E)
		{
			ETABSProject.#XWb #XWb = new ETABSProject.#XWb();
			#XWb.#a = #c2h;
			#XWb.#b = #0E;
			return this.Core.Columns.Where(new Func<ETABSFrame, bool>(#XWb.#J8h)).Select(new Func<ETABSFrame, string>(ETABSProject.<>c.<>9.#n8h));
		}

		// Token: 0x0600839A RID: 33690 RVA: 0x001C5294 File Offset: 0x001C3494
		private string #c6h(string #oT, string #85h)
		{
			ETABSProject.#CTb #CTb = new ETABSProject.#CTb();
			#CTb.#a = #oT;
			#CTb.#b = #85h;
			return this.Core.Piers.Single(new Func<ETABSPier, bool>(#CTb.#K8h)).Name;
		}

		// Token: 0x0600839B RID: 33691 RVA: 0x001C52D8 File Offset: 0x001C34D8
		private IEnumerable<string> #d6h(IEnumerable<string> #a6h, IEnumerable<string> #0E)
		{
			ETABSProject.#ETb #ETb = new ETABSProject.#ETb();
			#ETb.#a = #a6h;
			#ETb.#b = #0E;
			return this.Core.Piers.Where(new Func<ETABSPier, bool>(#ETb.#L8h)).Select(new Func<ETABSPier, string>(ETABSProject.<>c.<>9.#o8h));
		}

		// Token: 0x17002795 RID: 10133
		// (get) Token: 0x0600839C RID: 33692 RVA: 0x0006B555 File Offset: 0x00069755
		public bool SupportsEnvelopes
		{
			get
			{
				return this.Core.SupportsEnvelopes;
			}
		}

		// Token: 0x0600839D RID: 33693 RVA: 0x001C533C File Offset: 0x001C353C
		private static ETABSFactoredLoad[] #e6h(ETABSFactoredLoad #GT, ETABSFactoredLoad #HT)
		{
			string objectName = #GT.ObjectName;
			string objectData = #GT.ObjectData;
			string loadCombination = #GT.LoadCombination;
			double station = #GT.Station;
			string location = #GT.Location;
			string elementName = #GT.ElementName;
			return new ETABSFactoredLoad[]
			{
				new ETABSFactoredLoad(objectName, objectData, loadCombination, station, location, ETABSProject.#a[0], -1.0, EnvelopeType.MinMinMin, elementName, #GT.P, #GT.Mx, #GT.My),
				new ETABSFactoredLoad(objectName, objectData, loadCombination, station, location, ETABSProject.#a[1], -1.0, EnvelopeType.MinMinMax, elementName, #GT.P, #GT.Mx, #HT.My),
				new ETABSFactoredLoad(objectName, objectData, loadCombination, station, location, ETABSProject.#a[2], -1.0, EnvelopeType.MinMaxMin, elementName, #GT.P, #HT.Mx, #GT.My),
				new ETABSFactoredLoad(objectName, objectData, loadCombination, station, location, ETABSProject.#a[3], -1.0, EnvelopeType.MinMaxMax, elementName, #GT.P, #HT.Mx, #HT.My),
				new ETABSFactoredLoad(objectName, objectData, loadCombination, station, location, ETABSProject.#a[4], -1.0, EnvelopeType.MaxMinMin, elementName, #HT.P, #GT.Mx, #GT.My),
				new ETABSFactoredLoad(objectName, objectData, loadCombination, station, location, ETABSProject.#a[5], -1.0, EnvelopeType.MaxMinMax, elementName, #HT.P, #GT.Mx, #HT.My),
				new ETABSFactoredLoad(objectName, objectData, loadCombination, station, location, ETABSProject.#a[6], -1.0, EnvelopeType.MaxMaxMin, elementName, #HT.P, #HT.Mx, #GT.My),
				new ETABSFactoredLoad(objectName, objectData, loadCombination, station, location, ETABSProject.#a[7], -1.0, EnvelopeType.MaxMaxMax, elementName, #HT.P, #HT.Mx, #HT.My)
			};
		}

		// Token: 0x0600839E RID: 33694 RVA: 0x001C5514 File Offset: 0x001C3714
		private List<ETABSFactoredLoad> #f6h(List<ETABSFactoredLoad> #tk, StationTypes #g6h, bool #h6h)
		{
			List<ETABSFactoredLoad> list = #tk;
			if (#g6h != StationTypes.All)
			{
				var inner = list.GroupBy(new Func<ETABSFactoredLoad, string>(ETABSProject.<>c.<>9.#p8h)).Select(new Func<IGrouping<string, ETABSFactoredLoad>, <>f__AnonymousType7<string, double, double>>(ETABSProject.<>c.<>9.#q8h));
				var source = list.Join(inner, new Func<ETABSFactoredLoad, string>(ETABSProject.<>c.<>9.#u8h), new Func<<>f__AnonymousType7<string, double, double>, string>(ETABSProject.<>c.<>9.#v8h), new Func<ETABSFactoredLoad, <>f__AnonymousType7<string, double, double>, <>f__AnonymousType8<ETABSFactoredLoad, <>f__AnonymousType7<string, double, double>>>(ETABSProject.<>c.<>9.#w8h));
				switch (#g6h)
				{
				case StationTypes.OnlyTopAndBottom:
					source = source.Where(new Func<<>f__AnonymousType8<ETABSFactoredLoad, <>f__AnonymousType7<string, double, double>>, bool>(ETABSProject.<>c.<>9.#x8h));
					break;
				case StationTypes.OnlyBottom:
					source = source.Where(new Func<<>f__AnonymousType8<ETABSFactoredLoad, <>f__AnonymousType7<string, double, double>>, bool>(ETABSProject.<>c.<>9.#y8h));
					break;
				case StationTypes.OnlyTop:
					source = source.Where(new Func<<>f__AnonymousType8<ETABSFactoredLoad, <>f__AnonymousType7<string, double, double>>, bool>(ETABSProject.<>c.<>9.#z8h));
					break;
				default:
					throw new NotImplementedException();
				}
				list = source.Select(new Func<<>f__AnonymousType8<ETABSFactoredLoad, <>f__AnonymousType7<string, double, double>>, ETABSFactoredLoad>(ETABSProject.<>c.<>9.#A8h)).ToList<ETABSFactoredLoad>();
			}
			using (var enumerator = list.GroupBy(new Func<ETABSFactoredLoad, <>f__AnonymousType9<string, string, double, string>>(ETABSProject.<>c.<>9.#B8h)).Select(new Func<IGrouping<<>f__AnonymousType9<string, string, double, string>, ETABSFactoredLoad>, <>f__AnonymousType10<string, string, double, string, string>>(ETABSProject.<>c.<>9.#C8h)).Where(new Func<<>f__AnonymousType10<string, string, double, string, string>, bool>(ETABSProject.<>c.<>9.#F8h)).GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ETABSProject.#KTb #KTb = new ETABSProject.#KTb();
					#KTb.#a = enumerator.Current;
					ETABSFactoredLoad etabsfactoredLoad = list.Single(new Func<ETABSFactoredLoad, bool>(#KTb.#M8h));
					ETABSFactoredLoad etabsfactoredLoad2 = list.Single(new Func<ETABSFactoredLoad, bool>(#KTb.#N8h));
					list.Remove(etabsfactoredLoad);
					list.Remove(etabsfactoredLoad2);
					list.AddRange(ETABSProject.#e6h(etabsfactoredLoad, etabsfactoredLoad2));
				}
			}
			return list;
		}

		// Token: 0x0600839F RID: 33695 RVA: 0x0006B562 File Offset: 0x00069762
		private List<string> #i6h(IEnumerable<string> #j6h, List<ETABSFactoredLoad> #k6h)
		{
			return #j6h.Except(#k6h.Select(new Func<ETABSFactoredLoad, string>(ETABSProject.<>c.<>9.#G8h)).Distinct<string>()).ToList<string>();
		}

		// Token: 0x060083A0 RID: 33696 RVA: 0x001C5790 File Offset: 0x001C3990
		public List<ETABSFactoredLoad> #l6h(string #m6h, string #n6h, string[] #o6h, StationTypes #g6h, bool #h6h, out List<string> #oUh)
		{
			Logger.#DSi(#Phc.#3hc(107270277));
			List<ETABSFactoredLoad> result;
			try
			{
				string text = this.#75h(#m6h, #n6h);
				if (string.IsNullOrWhiteSpace(text))
				{
					throw new #C6h(#Ab.SpImporterExceptionNoMatchingMembersFound, #z6h.#o);
				}
				List<ETABSFactoredLoad> #tk = this.Core.#d7h(new string[]
				{
					text
				}, #o6h, #h6h);
				List<ETABSFactoredLoad> list = this.#f6h(#tk, #g6h, #h6h);
				#oUh = this.#i6h(#o6h, list);
				ETABSProject.#y1i(list, #oUh);
				result = list;
			}
			catch (Exception #N1i)
			{
				Logger.#DSi(string.Concat(new string[]
				{
					#Phc.#3hc(107270216),
					#m6h,
					#Phc.#3hc(107270227),
					#n6h,
					#Phc.#3hc(107270206),
					#o6h.#O1i(),
					#Phc.#3hc(107413095),
					string.Format(#Phc.#3hc(107270145), #g6h),
					string.Format(#Phc.#3hc(107270636), #h6h)
				}));
				Logger.#qn(#Phc.#3hc(107270607), #N1i);
				throw;
			}
			return result;
		}

		// Token: 0x060083A1 RID: 33697 RVA: 0x001C58B8 File Offset: 0x001C3AB8
		public List<ETABSFactoredLoad> #l6h(IEnumerable<string> #p6h, IEnumerable<string> #q6h, string[] #o6h, StationTypes #g6h, bool #h6h, out List<string> #oUh)
		{
			Logger.#DSi(#Phc.#3hc(107270586));
			List<ETABSFactoredLoad> result;
			try
			{
				string[] array = this.#95h(#p6h, #q6h).ToArray<string>();
				if (!array.Any<string>())
				{
					throw new #C6h(#Ab.SpImporterExceptionNoMatchingMembersFound, #z6h.#o);
				}
				List<ETABSFactoredLoad> #tk = this.Core.#d7h(array, #o6h, #h6h);
				List<ETABSFactoredLoad> list = this.#f6h(#tk, #g6h, #h6h);
				#oUh = this.#i6h(#o6h, list);
				ETABSProject.#y1i(list, #oUh);
				result = list;
			}
			catch (Exception #N1i)
			{
				Logger.#DSi(string.Concat(new string[]
				{
					#Phc.#3hc(107270521),
					#p6h.#O1i(),
					#Phc.#3hc(107270464),
					#q6h.#O1i(),
					#Phc.#3hc(107270206),
					#o6h.#O1i(),
					#Phc.#3hc(107413095),
					string.Format(#Phc.#3hc(107270145), #g6h),
					string.Format(#Phc.#3hc(107270636), #h6h)
				}));
				Logger.#qn(#Phc.#3hc(107270607), #N1i);
				throw;
			}
			return result;
		}

		// Token: 0x060083A2 RID: 33698 RVA: 0x001C59E8 File Offset: 0x001C3BE8
		public List<ETABSFactoredLoad> #r6h(string #rYg, IEnumerable<string> #q6h, string[] #o6h, StationTypes #g6h, bool #h6h, out List<string> #oUh)
		{
			Logger.#DSi(#Phc.#3hc(107270443));
			List<ETABSFactoredLoad> result;
			try
			{
				string[] array = this.#b6h(new string[]
				{
					#rYg
				}, #q6h).ToArray<string>();
				if (!array.Any<string>())
				{
					throw new #C6h(#Ab.SpImporterExceptionNoMatchingMembersFound, #z6h.#o);
				}
				List<ETABSFactoredLoad> #tk = this.Core.#d7h(array, #o6h, #h6h);
				List<ETABSFactoredLoad> list = this.#f6h(#tk, #g6h, #h6h);
				#oUh = this.#i6h(#o6h, list);
				ETABSProject.#y1i(list, #oUh);
				result = list;
			}
			catch (Exception #N1i)
			{
				Logger.#DSi(string.Concat(new string[]
				{
					#Phc.#3hc(107269870),
					#rYg,
					#Phc.#3hc(107270464),
					#q6h.#O1i(),
					#Phc.#3hc(107270206),
					#o6h.#O1i(),
					#Phc.#3hc(107413095),
					string.Format(#Phc.#3hc(107270145), #g6h),
					string.Format(#Phc.#3hc(107270636), #h6h)
				}));
				Logger.#qn(#Phc.#3hc(107270607), #N1i);
				throw;
			}
			return result;
		}

		// Token: 0x060083A3 RID: 33699 RVA: 0x001C5B1C File Offset: 0x001C3D1C
		public List<ETABSFactoredLoad> #s6h(string #t6h, string #n6h, string[] #o6h, StationTypes #g6h, bool #h6h, out List<string> #oUh)
		{
			Logger.#DSi(#Phc.#3hc(107269881));
			List<ETABSFactoredLoad> result;
			try
			{
				string text = this.#c6h(#t6h, #n6h);
				if (string.IsNullOrWhiteSpace(text))
				{
					throw new #C6h(#Ab.SpImporterExceptionNoMatchingMembersFound, #z6h.#o);
				}
				List<ETABSFactoredLoad> #tk = this.Core.#q7h(new string[]
				{
					text
				}, #o6h, #h6h);
				List<ETABSFactoredLoad> list = this.#f6h(#tk, #g6h, #h6h);
				#oUh = this.#i6h(#o6h, list);
				ETABSProject.#y1i(list, #oUh);
				result = list;
			}
			catch (Exception #N1i)
			{
				Logger.#DSi(string.Concat(new string[]
				{
					#Phc.#3hc(107269792),
					#t6h,
					#Phc.#3hc(107270227),
					#n6h,
					#Phc.#3hc(107270206),
					#o6h.#O1i(),
					#Phc.#3hc(107413095),
					string.Format(#Phc.#3hc(107270145), #g6h),
					string.Format(#Phc.#3hc(107270636), #h6h)
				}));
				Logger.#qn(#Phc.#3hc(107269771), #N1i);
				throw;
			}
			return result;
		}

		// Token: 0x060083A4 RID: 33700 RVA: 0x001C5C44 File Offset: 0x001C3E44
		public List<ETABSFactoredLoad> #s6h(IEnumerable<string> #u6h, IEnumerable<string> #q6h, string[] #o6h, StationTypes #g6h, bool #h6h, out List<string> #oUh)
		{
			Logger.#DSi(#Phc.#3hc(107269750));
			List<ETABSFactoredLoad> result;
			try
			{
				string[] array = this.#d6h(#u6h, #q6h).ToArray<string>();
				if (!array.Any<string>())
				{
					throw new #C6h(#Ab.SpImporterExceptionNoMatchingMembersFound, #z6h.#o);
				}
				List<ETABSFactoredLoad> #tk = this.Core.#q7h(array, #o6h, #h6h);
				List<ETABSFactoredLoad> list = this.#f6h(#tk, #g6h, #h6h);
				#oUh = this.#i6h(#o6h, list);
				ETABSProject.#y1i(list, #oUh);
				result = list;
			}
			catch (Exception #N1i)
			{
				Logger.#DSi(string.Concat(new string[]
				{
					#Phc.#3hc(107269689),
					#u6h.#O1i(),
					#Phc.#3hc(107270464),
					#q6h.#O1i(),
					#Phc.#3hc(107270206),
					#o6h.#O1i(),
					#Phc.#3hc(107413095),
					string.Format(#Phc.#3hc(107270145), #g6h),
					string.Format(#Phc.#3hc(107270636), #h6h)
				}));
				Logger.#qn(#Phc.#3hc(107269771), #N1i);
				throw;
			}
			return result;
		}

		// Token: 0x060083A5 RID: 33701 RVA: 0x001C5D74 File Offset: 0x001C3F74
		private static void #y1i(List<ETABSFactoredLoad> #Rfb, List<string> #oUh)
		{
			if (!#Rfb.Any<ETABSFactoredLoad>())
			{
				Logger.#DSi(#Phc.#3hc(107269636));
				return;
			}
			if (#oUh.Count > 0)
			{
				Logger.#DSi((#Phc.#3hc(107270111) + Environment.NewLine + #oUh.#O1i()).#Q1i(#Phc.#3hc(107464305), 1, true));
			}
			string[] array = new string[5];
			array[0] = #Phc.#3hc(107269998);
			array[1] = Environment.NewLine;
			array[2] = string.Format(#Phc.#3hc(107269933), #Rfb.GroupBy(new Func<ETABSFactoredLoad, string>(ETABSProject.<>c.<>9.#63i)).Count<IGrouping<string, ETABSFactoredLoad>>(), Environment.NewLine);
			array[3] = string.Format(#Phc.#3hc(107269912), #Rfb.GroupBy(new Func<ETABSFactoredLoad, string>(ETABSProject.<>c.<>9.#73i)).Count<IGrouping<string, ETABSFactoredLoad>>(), Environment.NewLine);
			array[4] = string.Format(#Phc.#3hc(107269315), #Rfb.Count<ETABSFactoredLoad>(), Environment.NewLine);
			Logger.#DSi(string.Concat(array).#Q1i(#Phc.#3hc(107464305), 1, true));
		}

		// Token: 0x060083A6 RID: 33702 RVA: 0x0006B599 File Offset: 0x00069799
		public void #v6h(string #4Hc, bool #h6h)
		{
			if (this.Core is EtabsProjectCore_API)
			{
				(this.Core as EtabsProjectCore_API).#v6h(#4Hc, #h6h);
				return;
			}
			throw new #C6h(#Ab.SpImporterExceptionExportXmlFailed_ProjectNotSupported, #z6h.#h);
		}

		// Token: 0x060083A7 RID: 33703 RVA: 0x0006B5C6 File Offset: 0x000697C6
		public void #1()
		{
			this.#1(true);
		}

		// Token: 0x060083A8 RID: 33704 RVA: 0x001C5EB8 File Offset: 0x001C40B8
		protected void #1(bool #POb)
		{
			Logger.#DSi(string.Format(#Phc.#3hc(107269262), #POb, this.#d));
			if (this.#d)
			{
				return;
			}
			try
			{
				if (#POb)
				{
					this.Core.Dispose();
				}
			}
			finally
			{
				this.#d = true;
			}
		}

		// Token: 0x04003617 RID: 13847
		private static readonly string[] #a = new string[]
		{
			#Ab.Envelope_MinMinMin,
			#Ab.Envelope_MinMinMax,
			#Ab.Envelope_MinMaxMin,
			#Ab.Envelope_MinMaxMax,
			#Ab.Envelope_MaxMinMin,
			#Ab.Envelope_MaxMinMax,
			#Ab.Envelope_MaxMaxMin,
			#Ab.Envelope_MaxMaxMax
		};

		// Token: 0x04003618 RID: 13848
		[CompilerGenerated]
		private #B7h #b;

		// Token: 0x04003619 RID: 13849
		private Dictionary<string, ETABSLoadCombination> #c;

		// Token: 0x0400361A RID: 13850
		private bool #d;

		// Token: 0x02000E58 RID: 3672
		[CompilerGenerated]
		private sealed class #rWb
		{
			// Token: 0x060083C5 RID: 33733 RVA: 0x0006B6A8 File Offset: 0x000698A8
			internal bool #j8h(KeyValuePair<string, ETABSLoadCombination> #uYb)
			{
				return #uYb.Value.#Z5h(this.#a, this.#b);
			}

			// Token: 0x04003634 RID: 13876
			public Dictionary<string, ETABSLoadCase> #a;

			// Token: 0x04003635 RID: 13877
			public Dictionary<string, ETABSLoadCombination> #b;
		}

		// Token: 0x02000E59 RID: 3673
		[CompilerGenerated]
		private sealed class #uZb
		{
			// Token: 0x060083C7 RID: 33735 RVA: 0x0006B6C2 File Offset: 0x000698C2
			internal bool #H8h(ETABSFrame #uYb)
			{
				return #uYb.Label == this.#a && #uYb.Story == this.#b;
			}

			// Token: 0x04003636 RID: 13878
			public string #a;

			// Token: 0x04003637 RID: 13879
			public string #b;
		}

		// Token: 0x02000E5A RID: 3674
		[CompilerGenerated]
		private sealed class #wWb
		{
			// Token: 0x060083C9 RID: 33737 RVA: 0x0006B6EA File Offset: 0x000698EA
			internal bool #I8h(ETABSFrame #uYb)
			{
				return this.#a.Contains(#uYb.Label) && this.#b.Contains(#uYb.Story);
			}

			// Token: 0x04003638 RID: 13880
			public IEnumerable<string> #a;

			// Token: 0x04003639 RID: 13881
			public IEnumerable<string> #b;
		}

		// Token: 0x02000E5B RID: 3675
		[CompilerGenerated]
		private sealed class #XWb
		{
			// Token: 0x060083CB RID: 33739 RVA: 0x0006B712 File Offset: 0x00069912
			internal bool #J8h(ETABSFrame #uYb)
			{
				return this.#a.Contains(#uYb.Section) && this.#b.Contains(#uYb.Story);
			}

			// Token: 0x0400363A RID: 13882
			public IEnumerable<string> #a;

			// Token: 0x0400363B RID: 13883
			public IEnumerable<string> #b;
		}

		// Token: 0x02000E5C RID: 3676
		[CompilerGenerated]
		private sealed class #CTb
		{
			// Token: 0x060083CD RID: 33741 RVA: 0x0006B73A File Offset: 0x0006993A
			internal bool #K8h(ETABSPier #uYb)
			{
				return #uYb.Label == this.#a && #uYb.Story == this.#b;
			}

			// Token: 0x0400363C RID: 13884
			public string #a;

			// Token: 0x0400363D RID: 13885
			public string #b;
		}

		// Token: 0x02000E5D RID: 3677
		[CompilerGenerated]
		private sealed class #ETb
		{
			// Token: 0x060083CF RID: 33743 RVA: 0x0006B762 File Offset: 0x00069962
			internal bool #L8h(ETABSPier #gsb)
			{
				return this.#a.Contains(#gsb.Label) && this.#b.Contains(#gsb.Story);
			}

			// Token: 0x0400363E RID: 13886
			public IEnumerable<string> #a;

			// Token: 0x0400363F RID: 13887
			public IEnumerable<string> #b;
		}

		// Token: 0x02000E5E RID: 3678
		[CompilerGenerated]
		private sealed class #KTb
		{
			// Token: 0x060083D1 RID: 33745 RVA: 0x001C60C4 File Offset: 0x001C42C4
			internal bool #M8h(ETABSFactoredLoad #dYb)
			{
				return #dYb.ObjectName == this.#a.ObjectName && #dYb.LoadCombination == this.#a.LoadCombination && #dYb.Station == this.#a.Station && #dYb.ElementName == this.#a.ElementName && #dYb.StepType == #Phc.#3hc(107440316);
			}

			// Token: 0x060083D2 RID: 33746 RVA: 0x001C6144 File Offset: 0x001C4344
			internal bool #N8h(ETABSFactoredLoad #dYb)
			{
				return #dYb.ObjectName == this.#a.ObjectName && #dYb.LoadCombination == this.#a.LoadCombination && #dYb.Station == this.#a.Station && #dYb.ElementName == this.#a.ElementName && #dYb.StepType == #Phc.#3hc(107440311);
			}

			// Token: 0x04003640 RID: 13888
			public <>f__AnonymousType10<string, string, double, string, string> #a;
		}
	}
}
