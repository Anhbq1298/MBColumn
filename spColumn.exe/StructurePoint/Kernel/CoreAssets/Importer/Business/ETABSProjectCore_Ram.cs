using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;
using #k2i;
using #w1i;
using #x1i;
using StructurePoint.Kernel.CoreAssets.Importer.Core;
using StructurePoint.Kernel.CoreAssets.Importer.DataClasses;

namespace StructurePoint.Kernel.CoreAssets.Importer.Business
{
	// Token: 0x02000E79 RID: 3705
	internal sealed class ETABSProjectCore_Ram : IDisposable, #B7h
	{
		// Token: 0x170027BC RID: 10172
		// (get) Token: 0x0600848E RID: 33934 RVA: 0x0006BD96 File Offset: 0x00069F96
		// (set) Token: 0x0600848F RID: 33935 RVA: 0x0006BD9E File Offset: 0x00069F9E
		public ProjectType ProjectType { get; private set; }

		// Token: 0x170027BD RID: 10173
		// (get) Token: 0x06008490 RID: 33936 RVA: 0x0006BDA7 File Offset: 0x00069FA7
		public UnitsSystem UnitsSystem { get; }

		// Token: 0x170027BE RID: 10174
		// (get) Token: 0x06008491 RID: 33937 RVA: 0x0006BDAF File Offset: 0x00069FAF
		public Dictionary<string, ETABSLoadCase> LoadCases { get; }

		// Token: 0x170027BF RID: 10175
		// (get) Token: 0x06008492 RID: 33938 RVA: 0x0006BDB7 File Offset: 0x00069FB7
		public Dictionary<string, ETABSLoadCombination> LoadCombinations { get; }

		// Token: 0x170027C0 RID: 10176
		// (get) Token: 0x06008493 RID: 33939 RVA: 0x0006BDBF File Offset: 0x00069FBF
		public List<ETABSStory> Stories { get; }

		// Token: 0x170027C1 RID: 10177
		// (get) Token: 0x06008494 RID: 33940 RVA: 0x0006BDC7 File Offset: 0x00069FC7
		public List<ETABSFrame> Columns { get; }

		// Token: 0x170027C2 RID: 10178
		// (get) Token: 0x06008495 RID: 33941 RVA: 0x0006BDCF File Offset: 0x00069FCF
		public List<ETABSPier> Piers { get; }

		// Token: 0x170027C3 RID: 10179
		// (get) Token: 0x06008496 RID: 33942 RVA: 0x0006BDD7 File Offset: 0x00069FD7
		public bool SupportsEnvelopes
		{
			get
			{
				return this.ColumnForces_Envelopes != null && this.PierForces_Envelopes != null;
			}
		}

		// Token: 0x06008497 RID: 33943 RVA: 0x0006BDEC File Offset: 0x00069FEC
		private void #x7h(bool #y7h)
		{
			if (#y7h && !this.SupportsEnvelopes)
			{
				throw new #C6h(#Ab.SpImporterExceptionEnvelopesNotSupported, #z6h.#k);
			}
		}

		// Token: 0x170027C4 RID: 10180
		// (get) Token: 0x06008498 RID: 33944 RVA: 0x0006BE06 File Offset: 0x0006A006
		public List<ETABSFactoredLoad> ColumnForces_AllSteps { get; }

		// Token: 0x170027C5 RID: 10181
		// (get) Token: 0x06008499 RID: 33945 RVA: 0x0006BE0E File Offset: 0x0006A00E
		public List<ETABSFactoredLoad> ColumnForces_Envelopes { get; }

		// Token: 0x170027C6 RID: 10182
		// (get) Token: 0x0600849A RID: 33946 RVA: 0x0006BE16 File Offset: 0x0006A016
		public List<ETABSFactoredLoad> PierForces_AllSteps { get; }

		// Token: 0x170027C7 RID: 10183
		// (get) Token: 0x0600849B RID: 33947 RVA: 0x0006BE1E File Offset: 0x0006A01E
		public List<ETABSFactoredLoad> PierForces_Envelopes { get; }

		// Token: 0x0600849C RID: 33948 RVA: 0x001C96EC File Offset: 0x001C78EC
		private List<ETABSFactoredLoad> #z7h(List<ETABSFactoredLoad> #tk, string[] #A7h, string[] #o6h)
		{
			return #tk.Join(#A7h, new Func<ETABSFactoredLoad, string>(ETABSProjectCore_Ram.<>c.<>9.#a9h), new Func<string, string>(ETABSProjectCore_Ram.<>c.<>9.#b9h), new Func<ETABSFactoredLoad, string, ETABSFactoredLoad>(ETABSProjectCore_Ram.<>c.<>9.#c9h)).Join(#o6h, new Func<ETABSFactoredLoad, string>(ETABSProjectCore_Ram.<>c.<>9.#d9h), new Func<string, string>(ETABSProjectCore_Ram.<>c.<>9.#e9h), new Func<ETABSFactoredLoad, string, ETABSFactoredLoad>(ETABSProjectCore_Ram.<>c.<>9.#f9h)).ToList<ETABSFactoredLoad>();
		}

		// Token: 0x0600849D RID: 33949 RVA: 0x001C97C8 File Offset: 0x001C79C8
		public List<ETABSFactoredLoad> #d7h(string[] #e7h, string[] #wkh, bool #h6h)
		{
			this.#x7h(#h6h);
			List<ETABSFactoredLoad> #tk = #h6h ? this.ColumnForces_Envelopes : this.ColumnForces_AllSteps;
			return this.#z7h(#tk, #e7h, #wkh);
		}

		// Token: 0x0600849E RID: 33950 RVA: 0x001C97F8 File Offset: 0x001C79F8
		public List<ETABSFactoredLoad> #q7h(string[] #r7h, string[] #wkh, bool #h6h)
		{
			this.#x7h(#h6h);
			List<ETABSFactoredLoad> #tk = #h6h ? this.PierForces_Envelopes : this.PierForces_AllSteps;
			return this.#z7h(#tk, #r7h, #wkh);
		}

		// Token: 0x0600849F RID: 33951 RVA: 0x00009E6A File Offset: 0x0000806A
		public void #1()
		{
		}

		// Token: 0x060084A0 RID: 33952 RVA: 0x001C9828 File Offset: 0x001C7A28
		internal ETABSProjectCore_Ram(#B7h core) : this(core.ProjectType, core.UnitsSystem, core.LoadCases, core.LoadCombinations, core.Stories, core.Columns, core.Piers, core.ColumnForces_AllSteps, core.ColumnForces_Envelopes, core.PierForces_AllSteps, core.PierForces_Envelopes)
		{
			Logger.#DSi(#Phc.#3hc(107230446));
		}

		// Token: 0x060084A1 RID: 33953 RVA: 0x001C988C File Offset: 0x001C7A8C
		internal ETABSProjectCore_Ram(ProjectType projectType, UnitsSystem unitsSystem, Dictionary<string, ETABSLoadCase> loadCases, Dictionary<string, ETABSLoadCombination> loadCombinations, List<ETABSStory> stories, List<ETABSFrame> columns, List<ETABSPier> piers, List<ETABSFactoredLoad> columnForces_AllSteps, List<ETABSFactoredLoad> columnForces_Envelopes, List<ETABSFactoredLoad> pierForces_AllSteps, List<ETABSFactoredLoad> pierForces_Envelopes)
		{
			Logger.#DSi(#Phc.#3hc(107230429));
			try
			{
				this.ProjectType = projectType;
				this.UnitsSystem = unitsSystem;
				this.Columns = columns;
				this.Stories = stories;
				this.LoadCases = loadCases;
				this.LoadCombinations = loadCombinations;
				this.ColumnForces_AllSteps = columnForces_AllSteps;
				this.ColumnForces_Envelopes = columnForces_Envelopes;
				this.Piers = piers;
				this.PierForces_AllSteps = pierForces_AllSteps;
				this.PierForces_Envelopes = pierForces_Envelopes;
			}
			catch (Exception)
			{
				Logger.#DSi(string.Concat(new string[]
				{
					#Phc.#3hc(107413095),
					string.Format(#Phc.#3hc(107230895), projectType),
					string.Format(#Phc.#3hc(107230368), unitsSystem),
					string.Format(#Phc.#3hc(107230343), loadCases.Count<KeyValuePair<string, ETABSLoadCase>>()),
					string.Format(#Phc.#3hc(107230318), loadCombinations.Count<KeyValuePair<string, ETABSLoadCombination>>()),
					string.Format(#Phc.#3hc(107230285), stories.Count<ETABSStory>()),
					string.Format(#Phc.#3hc(107230296), columns.Count<ETABSFrame>()),
					string.Format(#Phc.#3hc(107230243), piers.Count<ETABSPier>()),
					string.Format(#Phc.#3hc(107230258), columnForces_AllSteps.Count<ETABSFactoredLoad>()),
					string.Format(#Phc.#3hc(107230697), columnForces_Envelopes.Count<ETABSFactoredLoad>()),
					string.Format(#Phc.#3hc(107230656), pierForces_AllSteps.Count<ETABSFactoredLoad>()),
					string.Format(#Phc.#3hc(107230651), pierForces_Envelopes.Count<ETABSFactoredLoad>())
				}));
				throw;
			}
		}

		// Token: 0x040036A0 RID: 13984
		[CompilerGenerated]
		private ProjectType #a;

		// Token: 0x040036A1 RID: 13985
		[CompilerGenerated]
		private readonly UnitsSystem #b;

		// Token: 0x040036A2 RID: 13986
		[CompilerGenerated]
		private readonly Dictionary<string, ETABSLoadCase> #c;

		// Token: 0x040036A3 RID: 13987
		[CompilerGenerated]
		private readonly Dictionary<string, ETABSLoadCombination> #d;

		// Token: 0x040036A4 RID: 13988
		[CompilerGenerated]
		private readonly List<ETABSStory> #e;

		// Token: 0x040036A5 RID: 13989
		[CompilerGenerated]
		private readonly List<ETABSFrame> #f;

		// Token: 0x040036A6 RID: 13990
		[CompilerGenerated]
		private readonly List<ETABSPier> #g;

		// Token: 0x040036A7 RID: 13991
		[CompilerGenerated]
		private readonly List<ETABSFactoredLoad> #h;

		// Token: 0x040036A8 RID: 13992
		[CompilerGenerated]
		private readonly List<ETABSFactoredLoad> #i;

		// Token: 0x040036A9 RID: 13993
		[CompilerGenerated]
		private readonly List<ETABSFactoredLoad> #j;

		// Token: 0x040036AA RID: 13994
		[CompilerGenerated]
		private readonly List<ETABSFactoredLoad> #k;
	}
}
