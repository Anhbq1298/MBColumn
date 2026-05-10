using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;
using #k2i;
using #w1i;
using #x1i;
using ETABSv1;
using StructurePoint.Kernel.CoreAssets.Importer.Business.Xml_Files;
using StructurePoint.Kernel.CoreAssets.Importer.Core;
using StructurePoint.Kernel.CoreAssets.Importer.DataClasses;

namespace StructurePoint.Kernel.CoreAssets.Importer.Business
{
	// Token: 0x02000E73 RID: 3699
	internal sealed class EtabsProjectCore_API : IDisposable, #B7h
	{
		// Token: 0x0600843F RID: 33855 RVA: 0x0006BBEF File Offset: 0x00069DEF
		internal EtabsProjectCore_API(EtabsConnection connection)
		{
			Logger.#DSi(#Phc.#3hc(107232628));
			this.#a = connection;
		}

		// Token: 0x170027A4 RID: 10148
		// (get) Token: 0x06008440 RID: 33856 RVA: 0x0006BC28 File Offset: 0x00069E28
		// (set) Token: 0x06008441 RID: 33857 RVA: 0x0006BC30 File Offset: 0x00069E30
		public ProjectType ProjectType { get; private set; }

		// Token: 0x170027A5 RID: 10149
		// (get) Token: 0x06008442 RID: 33858 RVA: 0x0006BC39 File Offset: 0x00069E39
		// (set) Token: 0x06008443 RID: 33859 RVA: 0x0006BC41 File Offset: 0x00069E41
		public UnitsSystem UnitsSystem { get; private set; }

		// Token: 0x170027A6 RID: 10150
		// (get) Token: 0x06008444 RID: 33860 RVA: 0x0006BC4A File Offset: 0x00069E4A
		public Dictionary<string, ETABSLoadCase> LoadCases
		{
			get
			{
				return this.#56h();
			}
		}

		// Token: 0x06008445 RID: 33861 RVA: 0x001C7E7C File Offset: 0x001C607C
		private Dictionary<string, ETABSLoadCase> #56h()
		{
			Logger.#DSi(#Phc.#3hc(107232599));
			if (this.#c != null)
			{
				return this.#c;
			}
			int capacity = 0;
			string[] array = new string[0];
			this.#a.#F6h(this.#a.EtabsModel.LoadCases.GetNameList(ref capacity, ref array, (eLoadCaseType)0), #Ab.SpImporterExceptionEtabsApiFailed_LoadCaseList, #z6h.#g);
			int num = 0;
			string[] first = new string[0];
			bool[] second = new bool[0];
			this.#a.#F6h(this.#a.EtabsModel.Analyze.GetRunCaseFlag(ref num, ref first, ref second), #Ab.SpImporterExceptionEtabsApiFailed_CaseRunFlag, #z6h.#g);
			Dictionary<string, bool> dictionary = first.Zip(second, new Func<string, bool, <>f__AnonymousType0<string, bool>>(EtabsProjectCore_API.<>c.<>9.#O8h)).ToDictionary(new Func<<>f__AnonymousType0<string, bool>, string>(EtabsProjectCore_API.<>c.<>9.#P8h), new Func<<>f__AnonymousType0<string, bool>, bool>(EtabsProjectCore_API.<>c.<>9.#Q8h));
			int num2 = 0;
			eLoadCaseType type = eLoadCaseType.LinearStatic;
			eLoadPatternType eLoadPatternType = eLoadPatternType.Dead;
			int num3 = 0;
			int num4 = 0;
			this.#c = new Dictionary<string, ETABSLoadCase>(capacity);
			foreach (string text in array)
			{
				this.#a.#F6h(this.#a.EtabsModel.LoadCases.GetTypeOAPI_1(text, ref type, ref num2, ref eLoadPatternType, ref num3, ref num4), #Ab.SpImporterExceptionEtabsApiFailed_LoadCaseType, #z6h.#g);
				this.#c.Add(text, new ETABSLoadCase(text, (ETABSLoadCaseType)type, !dictionary.ContainsKey(text) || dictionary[text]));
			}
			return this.#c;
		}

		// Token: 0x170027A7 RID: 10151
		// (get) Token: 0x06008446 RID: 33862 RVA: 0x0006BC52 File Offset: 0x00069E52
		public Dictionary<string, ETABSLoadCombination> LoadCombinations
		{
			get
			{
				return this.#66h();
			}
		}

		// Token: 0x06008447 RID: 33863 RVA: 0x001C8024 File Offset: 0x001C6224
		private Dictionary<string, ETABSLoadCombination> #66h()
		{
			Logger.#DSi(#Phc.#3hc(107232562));
			if (this.#b != null)
			{
				return this.#b;
			}
			int capacity = 0;
			string[] array = new string[0];
			this.#a.#F6h(this.#a.EtabsModel.RespCombo.GetNameList(ref capacity, ref array), #Ab.SpImporterExceptionEtabsApiFailed_ComboList, #z6h.#g);
			int num = 0;
			eCNameType[] first = new eCNameType[0];
			string[] second = new string[0];
			double[] array2 = new double[0];
			this.LoadCases;
			this.#b = new Dictionary<string, ETABSLoadCombination>(capacity);
			foreach (string text in array)
			{
				this.#a.#F6h(this.#a.EtabsModel.RespCombo.GetCaseList(text, ref num, ref first, ref second, ref array2), #Ab.SpImporterExceptionEtabsApiFailed_ComboCases, #z6h.#g);
				if (num > 0)
				{
					var source = first.Zip(second, new Func<eCNameType, string, <>f__AnonymousType1<eCNameType, string>>(EtabsProjectCore_API.<>c.<>9.#R8h));
					this.#b.Add(text, new ETABSLoadCombination(text, source.Where(new Func<<>f__AnonymousType1<eCNameType, string>, bool>(EtabsProjectCore_API.<>c.<>9.#S8h)).Select(new Func<<>f__AnonymousType1<eCNameType, string>, string>(EtabsProjectCore_API.<>c.<>9.#T8h)).ToList<string>(), source.Where(new Func<<>f__AnonymousType1<eCNameType, string>, bool>(EtabsProjectCore_API.<>c.<>9.#U8h)).Select(new Func<<>f__AnonymousType1<eCNameType, string>, string>(EtabsProjectCore_API.<>c.<>9.#V8h)).ToList<string>()));
				}
			}
			return this.#b;
		}

		// Token: 0x170027A8 RID: 10152
		// (get) Token: 0x06008448 RID: 33864 RVA: 0x0006BC5A File Offset: 0x00069E5A
		public List<ETABSFrame> Columns
		{
			get
			{
				return this.#76h();
			}
		}

		// Token: 0x06008449 RID: 33865 RVA: 0x001C81EC File Offset: 0x001C63EC
		private List<ETABSFrame> #76h()
		{
			EtabsProjectCore_API.#CTb #CTb = new EtabsProjectCore_API.#CTb();
			if (this.#d != null)
			{
				return this.#d;
			}
			Logger.#DSi(#Phc.#3hc(107231973));
			int num = 0;
			string[] array = new string[0];
			#CTb.#a = new string[0];
			string[] array2 = new string[0];
			this.#a.#F6h(this.#a.EtabsModel.FrameObj.GetLabelNameList(ref num, ref array, ref #CTb.#a, ref array2), #Ab.SpImporterExceptionEtabsApiFailed_FrameList, #z6h.#g);
			int[] array3 = #CTb.#a.Select(new Func<string, int, int>(EtabsProjectCore_API.<>c.<>9.#W8h)).Where(new Func<int, bool>(#CTb.#88h)).ToArray<int>();
			string section = #Phc.#3hc(107381628);
			string text = #Phc.#3hc(107381628);
			this.#d = new List<ETABSFrame>(array3.Length);
			foreach (int num2 in array3)
			{
				this.#a.#F6h(this.#a.EtabsModel.FrameObj.GetSection(array[num2], ref section, ref text), #Ab.SpImporterExceptionEtabsApiFailed_FrameSection, #z6h.#g);
				this.#d.Add(new ETABSFrame(array[num2], #CTb.#a[num2], array2[num2], section));
			}
			return this.#d;
		}

		// Token: 0x170027A9 RID: 10153
		// (get) Token: 0x0600844A RID: 33866 RVA: 0x0006BC62 File Offset: 0x00069E62
		public List<ETABSStory> Stories
		{
			get
			{
				return this.#86h();
			}
		}

		// Token: 0x0600844B RID: 33867 RVA: 0x001C8348 File Offset: 0x001C6548
		private List<ETABSStory> #l2i(string #m2i)
		{
			EtabsProjectCore_API.#ZXb #ZXb = new EtabsProjectCore_API.#ZXb();
			#ZXb.#a = #m2i;
			Logger.#DSi(#Phc.#3hc(107231940) + #ZXb.#a + #Phc.#3hc(107231907));
			int num = 0;
			string[] first = new string[0];
			double[] second = new double[0];
			double[] array = new double[0];
			bool[] array2 = new bool[0];
			string[] array3 = new string[0];
			bool[] array4 = new bool[0];
			double[] array5 = new double[0];
			this.#a.#F6h(this.#a.EtabsModel.Story.GetStories(ref num, ref first, ref second, ref array, ref array2, ref array3, ref array4, ref array5), #Ab.SpImporterExceptionEtabsApiFailed_StoriesList, #z6h.#g);
			return first.Zip(second, new Func<string, double, ETABSStory>(#ZXb.#u4i)).ToList<ETABSStory>();
		}

		// Token: 0x0600844C RID: 33868 RVA: 0x001C840C File Offset: 0x001C660C
		private List<ETABSStory> #n2i(string #o2i)
		{
			Logger.#DSi(#Phc.#3hc(107231922) + #o2i + #Phc.#3hc(107231897));
			this.#a.#F6h(this.#a.EtabsModel.Tower.SetActiveTower(#o2i), string.Format(#Ab.SpImporterExceptionEtabsApiFailed_ActivateTower, #o2i), #z6h.#g);
			return this.#l2i(#o2i);
		}

		// Token: 0x0600844D RID: 33869 RVA: 0x001C846C File Offset: 0x001C666C
		private List<ETABSStory> #86h()
		{
			Logger.#DSi(#Phc.#3hc(107231856));
			int num = 0;
			string[] array = new string[0];
			this.#a.#F6h(this.#a.EtabsModel.Tower.GetNameList(ref num, ref array), #Ab.SpImporterExceptionEtabsApiFailed_TowersList, #z6h.#g);
			if (array.Length > 1)
			{
				return array.SelectMany(new Func<string, IEnumerable<ETABSStory>>(this.#n2i)).ToList<ETABSStory>();
			}
			return this.#l2i(#Phc.#3hc(107381628));
		}

		// Token: 0x0600844E RID: 33870 RVA: 0x001C84EC File Offset: 0x001C66EC
		private void #96h(string[] #a7h)
		{
			Logger.#DSi(#Phc.#3hc(107231791));
			try
			{
				if (this.#f == null)
				{
					this.#a.#F6h(this.#a.EtabsModel.SelectObj.ClearSelection(), #Ab.SpImporterExceptionEtabsApiFailed_DeselectAllObj, #z6h.#g);
					this.#f = new string[0];
				}
				foreach (string name in #a7h.Except(this.#f))
				{
					this.#a.#F6h(this.#a.EtabsModel.FrameObj.SetSelected(name, true, eItemType.Objects), #Ab.SpImporterExceptionEtabsApiFailed_SelectFrame, #z6h.#g);
				}
				foreach (string name2 in this.#f.Except(#a7h))
				{
					this.#a.#F6h(this.#a.EtabsModel.FrameObj.SetSelected(name2, false, eItemType.Objects), #Ab.SpImporterExceptionEtabsApiFailed_DeselectFrame, #z6h.#g);
				}
				this.#f = (string[])#a7h.Clone();
			}
			catch
			{
				Logger.#DSi((#Phc.#3hc(107231794) + Environment.NewLine + #Phc.#3hc(107231761) + #a7h.#O1i()).#Q1i(#Phc.#3hc(107464305), 1, true));
				throw;
			}
		}

		// Token: 0x0600844F RID: 33871 RVA: 0x001C866C File Offset: 0x001C686C
		private void #b7h(IEnumerable<string> #wkh)
		{
			Logger.#DSi(#Phc.#3hc(107232224));
			try
			{
				this.#a.#F6h(this.#a.EtabsModel.Results.Setup.DeselectAllCasesAndCombosForOutput(), #Ab.SpImporterExceptionEtabsApiFailed_DeselectAllCaseCombo, #z6h.#g);
				foreach (string name in #wkh)
				{
					this.#a.#F6h(this.#a.EtabsModel.Results.Setup.SetComboSelectedForOutput(name, true), #Ab.SpImporterExceptionEtabsApiFailed_SelectCombo, #z6h.#g);
				}
			}
			catch
			{
				Logger.#DSi((#Phc.#3hc(107232211) + Environment.NewLine + #Phc.#3hc(107232130) + #wkh.#O1i()).#Q1i(#Phc.#3hc(107464305), 1, true));
				throw;
			}
		}

		// Token: 0x06008450 RID: 33872 RVA: 0x001C8760 File Offset: 0x001C6960
		private void #c7h(IEnumerable<string> #wkh, bool #h6h)
		{
			Logger.#DSi(#Phc.#3hc(107232145));
			try
			{
				this.#a.#F6h(this.#a.EtabsModel.Results.Setup.SetOptionMultiStepStatic(#h6h ? 1 : 2), #Ab.SpImporterExceptionEtabsApiFailed_CaseOptMultiStat, #z6h.#g);
				this.#a.#F6h(this.#a.EtabsModel.Results.Setup.SetOptionModalHist(#h6h ? 1 : 2), #Ab.SpImporterExceptionEtabsApiFailed_CaseOptModalHist, #z6h.#g);
				this.#a.#F6h(this.#a.EtabsModel.Results.Setup.SetOptionNLStatic(#h6h ? 1 : 2), #Ab.SpImporterExceptionEtabsApiFailed_CaseOptNonLinStat, #z6h.#g);
				this.#a.#F6h(this.#a.EtabsModel.Results.Setup.SetOptionDirectHist(#h6h ? 1 : 2), #Ab.SpImporterExceptionEtabsApiFailed_CaseOptDrctHist, #z6h.#g);
				this.#b7h(#wkh);
			}
			catch
			{
				Logger.#DSi(string.Concat(new string[]
				{
					#Phc.#3hc(107232076),
					Environment.NewLine,
					#Phc.#3hc(107232130),
					#wkh.#O1i(),
					string.Format(#Phc.#3hc(107232035), Environment.NewLine, #h6h)
				}).#Q1i(#Phc.#3hc(107464305), 1, true));
				throw;
			}
		}

		// Token: 0x06008451 RID: 33873 RVA: 0x001C88CC File Offset: 0x001C6ACC
		public List<ETABSFactoredLoad> #d7h(string[] #e7h, string[] #wkh, bool #h6h)
		{
			EtabsProjectCore_API.#AZb #AZb = new EtabsProjectCore_API.#AZb();
			#AZb.#a = #e7h;
			Logger.#DSi(#Phc.#3hc(107232006));
			List<ETABSFactoredLoad> result;
			try
			{
				this.#u7h();
				this.#c7h(#wkh, #h6h);
				int num = 0;
				string[] array = new string[0];
				double[] array2 = new double[0];
				string[] array3 = new string[0];
				double[] array4 = new double[0];
				string[] array5 = new string[0];
				string[] array6 = new string[0];
				double[] array7 = new double[0];
				double[] array8 = new double[0];
				double[] array9 = new double[0];
				double[] array10 = new double[0];
				double[] array11 = new double[0];
				double[] array12 = new double[0];
				double[] array13 = new double[0];
				this.#96h(#AZb.#a);
				Dictionary<string, string> dictionary = this.Columns.Where(new Func<ETABSFrame, bool>(#AZb.#98h)).ToDictionary(new Func<ETABSFrame, string>(EtabsProjectCore_API.<>c.<>9.#k4i), new Func<ETABSFrame, string>(EtabsProjectCore_API.<>c.<>9.#l4i));
				this.#a.#F6h(this.#a.EtabsModel.Results.FrameForce(#Phc.#3hc(107381628), eItemTypeElm.SelectionElm, ref num, ref array, ref array2, ref array3, ref array4, ref array5, ref array6, ref array7, ref array8, ref array9, ref array10, ref array11, ref array12, ref array13), #Ab.SpImporterExceptionEtabsApiFailed_ColumnForce, #z6h.#g);
				List<ETABSFactoredLoad> list = new List<ETABSFactoredLoad>(num);
				for (int i = 0; i < num; i++)
				{
					double p;
					double mx;
					double my;
					ETABSFactoredLoad.#C5h(array8[i], array12[i], array13[i], out p, out mx, out my);
					list.Add(new ETABSFactoredLoad(array[i], dictionary[array[i]], array5[i], array2[i], #Phc.#3hc(107381628), array6[i], array7[i], EnvelopeType.NotAnEnvelope, array3[i], p, mx, my));
				}
				result = list;
			}
			catch
			{
				Logger.#DSi(string.Concat(new string[]
				{
					#Phc.#3hc(107231485),
					Environment.NewLine,
					#Phc.#3hc(107232130),
					#wkh.#O1i(),
					#Phc.#3hc(107231440),
					#AZb.#a.#O1i(),
					string.Format(#Phc.#3hc(107232035), Environment.NewLine, #h6h)
				}).#Q1i(#Phc.#3hc(107464305), 1, true));
				throw;
			}
			return result;
		}

		// Token: 0x170027AA RID: 10154
		// (get) Token: 0x06008452 RID: 33874 RVA: 0x0006BC6A File Offset: 0x00069E6A
		public List<ETABSFactoredLoad> ColumnForces_AllSteps
		{
			get
			{
				return this.#g7h();
			}
		}

		// Token: 0x06008453 RID: 33875 RVA: 0x001C8B44 File Offset: 0x001C6D44
		private List<ETABSFactoredLoad> #g7h()
		{
			Logger.#DSi(#Phc.#3hc(107231423));
			return this.#d7h(this.Columns.Select(new Func<ETABSFrame, string>(EtabsProjectCore_API.<>c.<>9.#m4i)).ToArray<string>(), this.LoadCombinations.Keys.ToArray<string>(), false);
		}

		// Token: 0x170027AB RID: 10155
		// (get) Token: 0x06008454 RID: 33876 RVA: 0x0006BC72 File Offset: 0x00069E72
		public List<ETABSFactoredLoad> ColumnForces_Envelopes
		{
			get
			{
				return this.#p2i();
			}
		}

		// Token: 0x06008455 RID: 33877 RVA: 0x001C8BA8 File Offset: 0x001C6DA8
		private List<ETABSFactoredLoad> #p2i()
		{
			Logger.#DSi(#Phc.#3hc(107231334));
			return this.#d7h(this.Columns.Select(new Func<ETABSFrame, string>(EtabsProjectCore_API.<>c.<>9.#n4i)).ToArray<string>(), this.LoadCombinations.Keys.ToArray<string>(), true);
		}

		// Token: 0x170027AC RID: 10156
		// (get) Token: 0x06008456 RID: 33878 RVA: 0x0006BC7A File Offset: 0x00069E7A
		public List<ETABSPier> Piers
		{
			get
			{
				return this.#i7h();
			}
		}

		// Token: 0x06008457 RID: 33879 RVA: 0x001C8C0C File Offset: 0x001C6E0C
		private List<ETABSPier> #i7h()
		{
			Logger.#DSi(#Phc.#3hc(107231273));
			if (this.#e != null)
			{
				return this.#e;
			}
			this.#a.#F6h(this.#a.EtabsModel.Results.Setup.SetOptionMultiStepStatic(2), #Ab.SpImporterExceptionEtabsApiFailed_CaseOptMultiStat, #z6h.#g);
			this.#a.#F6h(this.#a.EtabsModel.Results.Setup.SetOptionModalHist(2), #Ab.SpImporterExceptionEtabsApiFailed_CaseOptModalHist, #z6h.#g);
			this.#a.#F6h(this.#a.EtabsModel.Results.Setup.SetOptionNLStatic(2), #Ab.SpImporterExceptionEtabsApiFailed_CaseOptNonLinStat, #z6h.#g);
			this.#a.#F6h(this.#a.EtabsModel.Results.Setup.SetOptionDirectHist(2), #Ab.SpImporterExceptionEtabsApiFailed_CaseOptDrctHist, #z6h.#g);
			this.#a.#F6h(this.#a.EtabsModel.Results.Setup.DeselectAllCasesAndCombosForOutput(), #Ab.SpImporterExceptionEtabsApiFailed_DeselectAllCaseCombo, #z6h.#g);
			this.#a.#F6h(this.#a.EtabsModel.Results.Setup.SetCaseSelectedForOutput(this.LoadCases.Values.Where(new Func<ETABSLoadCase, bool>(EtabsProjectCore_API.<>c.<>9.#o4i)).First<ETABSLoadCase>().Name, true), #Ab.SpImporterExceptionEtabsApiFailed_SelectFirstCase, #z6h.#g);
			int num = 0;
			string[] first = new string[0];
			string[] second = new string[0];
			string[] array = new string[0];
			string[] array2 = new string[0];
			new string[0];
			new double[0];
			double[] array3 = new double[0];
			double[] array4 = new double[0];
			double[] array5 = new double[0];
			double[] array6 = new double[0];
			double[] array7 = new double[0];
			double[] array8 = new double[0];
			if (this.#a.EtabsModel.Results.PierForce(ref num, ref second, ref first, ref array2, ref array, ref array3, ref array4, ref array5, ref array6, ref array7, ref array8) != 0)
			{
				this.#e = new List<ETABSPier>();
			}
			else
			{
				this.#e = first.Zip(second, new Func<string, string, <>f__AnonymousType2<string, string>>(EtabsProjectCore_API.<>c.<>9.#p4i)).GroupBy(new Func<<>f__AnonymousType2<string, string>, <>f__AnonymousType2<string, string>>(EtabsProjectCore_API.<>c.<>9.#q4i)).Select(new Func<IGrouping<<>f__AnonymousType2<string, string>, <>f__AnonymousType2<string, string>>, ETABSPier>(EtabsProjectCore_API.<>c.<>9.#r4i)).ToList<ETABSPier>();
			}
			return this.#e;
		}

		// Token: 0x170027AD RID: 10157
		// (get) Token: 0x06008458 RID: 33880 RVA: 0x00003375 File Offset: 0x00001575
		public bool SupportsEnvelopes
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06008459 RID: 33881 RVA: 0x001C8E90 File Offset: 0x001C7090
		private void #j7h(string #k7h, bool #h6h, bool #l7h, Dictionary<string, ETABSLoadCase> #m7h, Dictionary<string, ETABSLoadCombination> #n7h, out bool #o7h, out string #p7h)
		{
			if (#n7h[#k7h].#Y5h(#m7h, #n7h).Contains(ETABSLoadCaseType.ResponseSpectrum))
			{
				#o7h = true;
				#p7h = #Phc.#3hc(107440311);
				return;
			}
			if (!#l7h)
			{
				#o7h = false;
				#p7h = #Phc.#3hc(107381628);
				return;
			}
			if (!#h6h)
			{
				#o7h = false;
				#p7h = #Phc.#3hc(107231244);
				return;
			}
			#o7h = true;
			#p7h = #Phc.#3hc(107440311);
		}

		// Token: 0x0600845A RID: 33882 RVA: 0x001C8F04 File Offset: 0x001C7104
		public List<ETABSFactoredLoad> #q7h(string[] #r7h, string[] #wkh, bool #h6h)
		{
			Logger.#DSi(#Phc.#3hc(107231235));
			List<ETABSFactoredLoad> result;
			try
			{
				this.#u7h();
				this.#c7h(#wkh, #h6h);
				int num = 0;
				string[] array = new string[0];
				string[] array2 = new string[0];
				string[] array3 = new string[0];
				string[] array4 = new string[0];
				double[] array5 = new double[0];
				double[] array6 = new double[0];
				double[] array7 = new double[0];
				double[] array8 = new double[0];
				double[] array9 = new double[0];
				double[] array10 = new double[0];
				if (this.#a.EtabsModel.Results.PierForce(ref num, ref array2, ref array, ref array4, ref array3, ref array5, ref array6, ref array7, ref array8, ref array9, ref array10) != 0)
				{
					result = new List<ETABSFactoredLoad>();
				}
				else
				{
					List<ETABSFactoredLoad> list = new List<ETABSFactoredLoad>(num);
					bool flag = false;
					string stepType = #Phc.#3hc(107381628);
					double num2 = 0.0;
					Dictionary<string, ETABSLoadCase> #m7h = this.LoadCases;
					Dictionary<string, ETABSLoadCombination> #n7h = this.LoadCombinations;
					for (int i = 0; i < num; i++)
					{
						if (#r7h.Contains(array[i] + array2[i]))
						{
							if (list.Count == 0 || array4[i] != array4[i - 1] || array2[i] != array2[i - 1] || array[i] != array[i - 1])
							{
								bool #l7h = i + 2 < num && array2[i] == array2[i + 2] && array[i] == array[i + 2] && array4[i] == array4[i + 2];
								num2 = 0.0;
								this.#j7h(array4[i], #h6h, #l7h, #m7h, #n7h, out flag, out stepType);
							}
							else if (array3[i] == #Phc.#3hc(107280502))
							{
								if (flag)
								{
									stepType = #Phc.#3hc(107440316);
								}
								else
								{
									num2 += 1.0;
								}
							}
							double p;
							double mx;
							double my;
							ETABSFactoredLoad.#J5h(array5[i], array9[i], array10[i], out p, out mx, out my);
							list.Add(new ETABSFactoredLoad(array[i] + array2[i], string.Format(#Ab.ElementNames_Label_Story, array[i], array2[i]), array4[i], (array3[i] == #Phc.#3hc(107280488)) ? 0.0 : 1.0, array3[i], stepType, num2, EnvelopeType.NotAnEnvelope, #Phc.#3hc(107381628), p, mx, my));
						}
					}
					result = list;
				}
			}
			catch
			{
				Logger.#DSi(string.Concat(new string[]
				{
					#Phc.#3hc(107231742),
					Environment.NewLine,
					#Phc.#3hc(107232130),
					#wkh.#O1i(),
					#Phc.#3hc(107231440),
					#r7h.#O1i(),
					string.Format(#Phc.#3hc(107232035), Environment.NewLine, #h6h)
				}).#Q1i(#Phc.#3hc(107464305), 1, true));
				throw;
			}
			return result;
		}

		// Token: 0x170027AE RID: 10158
		// (get) Token: 0x0600845B RID: 33883 RVA: 0x0006BC82 File Offset: 0x00069E82
		public List<ETABSFactoredLoad> PierForces_AllSteps
		{
			get
			{
				return this.#q2i();
			}
		}

		// Token: 0x0600845C RID: 33884 RVA: 0x001C9220 File Offset: 0x001C7420
		private List<ETABSFactoredLoad> #q2i()
		{
			Logger.#DSi(#Phc.#3hc(107231701));
			return this.#q7h(this.Piers.Select(new Func<ETABSPier, string>(EtabsProjectCore_API.<>c.<>9.#s4i)).ToArray<string>(), this.LoadCombinations.Keys.ToArray<string>(), false);
		}

		// Token: 0x170027AF RID: 10159
		// (get) Token: 0x0600845D RID: 33885 RVA: 0x0006BC8A File Offset: 0x00069E8A
		public List<ETABSFactoredLoad> PierForces_Envelopes
		{
			get
			{
				return this.#r2i();
			}
		}

		// Token: 0x0600845E RID: 33886 RVA: 0x001C9284 File Offset: 0x001C7484
		private List<ETABSFactoredLoad> #r2i()
		{
			Logger.#DSi(#Phc.#3hc(107231644));
			return this.#q7h(this.Piers.Select(new Func<ETABSPier, string>(EtabsProjectCore_API.<>c.<>9.#t4i)).ToArray<string>(), this.LoadCombinations.Keys.ToArray<string>(), true);
		}

		// Token: 0x0600845F RID: 33887 RVA: 0x001C92E8 File Offset: 0x001C74E8
		private void #u7h()
		{
			Logger.#DSi(#Phc.#3hc(107231583));
			string path = Path.ChangeExtension(this.#i, #Phc.#3hc(107231538));
			if (!File.Exists(path))
			{
				#z6h #Zfc = #z6h.#d;
				string # = #Ab.SpImporterExceptionProjectNotSolved;
				if (this.#j > DateTime.MinValue)
				{
					#Zfc = #z6h.#e;
					# = #Ab.SpImporterExceptionAnalysisResultsDeleted;
				}
				throw new #C6h(#, #Zfc);
			}
			DateTime lastWriteTime = File.GetLastWriteTime(path);
			if (this.#j > DateTime.MinValue)
			{
				if (lastWriteTime > this.#j)
				{
					throw new #C6h(#Ab.SpImporterExceptionAnalysisResultsChanged, #z6h.#f);
				}
			}
			else
			{
				this.#j = lastWriteTime;
			}
			try
			{
				try
				{
					if (!this.#a.EtabsModel.GetModelIsLocked())
					{
						throw new #C6h(#Ab.SpImporterExceptionProjectNotLocked, #z6h.#d);
					}
				}
				catch (#C6h)
				{
					throw;
				}
				catch (Exception #Uic)
				{
					throw new #C6h(#Ab.SpImporterExceptionEtabsApiFailed_GetIsLocked, #z6h.#n, #Uic);
				}
			}
			catch
			{
				Logger.#DSi(#Phc.#3hc(107231497));
				throw;
			}
		}

		// Token: 0x06008460 RID: 33888 RVA: 0x001C93F4 File Offset: 0x001C75F4
		internal void #v7h(string #Rtf, ProjectType #36h, UnitsSystem #Z6h)
		{
			Logger.#DSi(string.Concat(new string[]
			{
				#Phc.#3hc(107230944),
				#Rtf,
				#Phc.#3hc(107413095),
				string.Format(#Phc.#3hc(107230895), #36h),
				string.Format(#Phc.#3hc(107230902), #Z6h)
			}));
			if (!File.Exists(#Rtf))
			{
				throw new #C6h(string.Format(#Ab.SpImporterExceptionFileNotFound, #Rtf), #z6h.#l);
			}
			if (this.#i != #Phc.#3hc(107381628))
			{
				Logger.#DSi(#Phc.#3hc(107230877));
				this.#w7h();
			}
			try
			{
				this.#i = #Rtf;
				Logger.#DSi(#Phc.#3hc(107230844));
				this.#a.#F6h(this.#a.EtabsModel.File.OpenFile(#Rtf), #Ab.SpImporterExceptionLoadFromEDBFailed, #z6h.#c);
				this.#u7h();
				Logger.#DSi(#Phc.#3hc(107230807));
				this.#a.#F6h(this.#a.EtabsModel.SetPresentUnits((#Z6h == UnitsSystem.Metric) ? eUnits.kN_m_C : eUnits.kip_ft_F), #Ab.SpImporterExceptionLoadFromEDBFailed_SetUnits, #z6h.#c);
				this.ProjectType = #36h;
				this.UnitsSystem = #Z6h;
			}
			catch (#C6h)
			{
				throw;
			}
			catch (Exception #Uic)
			{
				throw new #C6h(#Ab.SpImporterExceptionLoadFromEDBFailed_Unknown, #z6h.#c, #Uic);
			}
			Logger.#DSi(#Phc.#3hc(107230770));
		}

		// Token: 0x06008461 RID: 33889 RVA: 0x0006BC92 File Offset: 0x00069E92
		internal void #v6h(string #4Hc, bool #h6h)
		{
			this.#u7h();
			EtabsProject_API_XmlExporter.#xRb(this.#a, #4Hc, this.LoadCombinations.Keys, #h6h);
		}

		// Token: 0x06008462 RID: 33890 RVA: 0x001C9570 File Offset: 0x001C7770
		private void #w7h()
		{
			if (this.#i != #Phc.#3hc(107381628))
			{
				Logger.#DSi((#Phc.#3hc(107231209) + Environment.NewLine + #Phc.#3hc(107231176) + this.#i).#Q1i(#Phc.#3hc(107464305), 1, true));
				this.#a.#F6h(this.#a.EtabsModel.InitializeNewModel(eUnits.kip_in_F), #Ab.SpImporterExceptionEtabsApiFailed_CloseFile, #z6h.#g);
				this.#i = #Phc.#3hc(107381628);
				this.#j = DateTime.MinValue;
				this.#c = null;
				this.#b = null;
				this.#d = null;
				this.#e = null;
				this.#f = null;
				Logger.#DSi(#Phc.#3hc(107231187));
				return;
			}
			Logger.#DSi(#Phc.#3hc(107231114));
		}

		// Token: 0x06008463 RID: 33891 RVA: 0x0006BCB2 File Offset: 0x00069EB2
		public void #1()
		{
			this.#1(true);
		}

		// Token: 0x06008464 RID: 33892 RVA: 0x001C9650 File Offset: 0x001C7850
		protected void #1(bool #POb)
		{
			Logger.#DSi(string.Format(#Phc.#3hc(107231085), #POb, this.#k));
			if (this.#k)
			{
				Logger.#DSi(#Phc.#3hc(107231068));
				return;
			}
			try
			{
				if (#POb)
				{
					if (this.#a != null && this.#a.Connected)
					{
						this.#w7h();
					}
					else
					{
						Logger.#DSi(#Phc.#3hc(107231027));
					}
				}
			}
			finally
			{
				this.#a = null;
				this.#k = true;
			}
		}

		// Token: 0x0400367E RID: 13950
		private EtabsConnection #a;

		// Token: 0x0400367F RID: 13951
		private Dictionary<string, ETABSLoadCombination> #b;

		// Token: 0x04003680 RID: 13952
		private Dictionary<string, ETABSLoadCase> #c;

		// Token: 0x04003681 RID: 13953
		private List<ETABSFrame> #d;

		// Token: 0x04003682 RID: 13954
		public List<ETABSPier> #e;

		// Token: 0x04003683 RID: 13955
		private string[] #f;

		// Token: 0x04003684 RID: 13956
		[CompilerGenerated]
		private ProjectType #g;

		// Token: 0x04003685 RID: 13957
		[CompilerGenerated]
		private UnitsSystem #h;

		// Token: 0x04003686 RID: 13958
		private string #i = #Phc.#3hc(107381628);

		// Token: 0x04003687 RID: 13959
		private DateTime #j = DateTime.MinValue;

		// Token: 0x04003688 RID: 13960
		private bool #k;

		// Token: 0x02000E75 RID: 3701
		[CompilerGenerated]
		private sealed class #CTb
		{
			// Token: 0x0600847B RID: 33915 RVA: 0x0006BD5B File Offset: 0x00069F5B
			internal bool #88h(int #Ttb)
			{
				return this.#a[#Ttb].StartsWith(#Phc.#3hc(107408077));
			}

			// Token: 0x0400369D RID: 13981
			public string[] #a;
		}

		// Token: 0x02000E76 RID: 3702
		[CompilerGenerated]
		private sealed class #ZXb
		{
			// Token: 0x0600847D RID: 33917 RVA: 0x0006BD74 File Offset: 0x00069F74
			internal ETABSStory #u4i(string #EWd, double #He)
			{
				return new ETABSStory(#EWd, #He, this.#a);
			}

			// Token: 0x0400369E RID: 13982
			public string #a;
		}

		// Token: 0x02000E77 RID: 3703
		[CompilerGenerated]
		private sealed class #AZb
		{
			// Token: 0x0600847F RID: 33919 RVA: 0x0006BD83 File Offset: 0x00069F83
			internal bool #98h(ETABSFrame #uYb)
			{
				return this.#a.Contains(#uYb.Name);
			}

			// Token: 0x0400369F RID: 13983
			public string[] #a;
		}
	}
}
