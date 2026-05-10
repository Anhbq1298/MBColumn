using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #gfe;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Engine.Helpers;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Engine.Runtime;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Storage;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Units;

namespace StructurePoint.CoreAssets.AppManager.Column.Templates.Engine
{
	// Token: 0x02001081 RID: 4225
	public sealed class TemplateEngineModel : NotifyPropertyChangedObjectBase
	{
		// Token: 0x06009052 RID: 36946 RVA: 0x001E87A0 File Offset: 0x001E69A0
		private TemplateEngineModel(SectionTemplateDefinition definition, UnitSystem unitSystem, DesignCodes designCode, IList<StandardBar> bars)
		{
			this.Definition = definition;
			this.UnitSystem = unitSystem;
			this.DesignCode = designCode;
			this.StandardBars = new StandardBarsProvider(bars);
		}

		// Token: 0x170029FA RID: 10746
		// (get) Token: 0x06009053 RID: 36947 RVA: 0x000749CE File Offset: 0x00072BCE
		public SectionTemplateDefinition Definition { get; }

		// Token: 0x170029FB RID: 10747
		// (get) Token: 0x06009054 RID: 36948 RVA: 0x000749D6 File Offset: 0x00072BD6
		// (set) Token: 0x06009055 RID: 36949 RVA: 0x000749DE File Offset: 0x00072BDE
		public string Name { get; set; }

		// Token: 0x170029FC RID: 10748
		// (get) Token: 0x06009056 RID: 36950 RVA: 0x000749E7 File Offset: 0x00072BE7
		public UnitSystem UnitSystem { get; }

		// Token: 0x170029FD RID: 10749
		// (get) Token: 0x06009057 RID: 36951 RVA: 0x000749EF File Offset: 0x00072BEF
		public DesignCodes DesignCode { get; }

		// Token: 0x170029FE RID: 10750
		// (get) Token: 0x06009058 RID: 36952 RVA: 0x000749F7 File Offset: 0x00072BF7
		public StandardBarsProvider StandardBars { get; }

		// Token: 0x170029FF RID: 10751
		// (get) Token: 0x06009059 RID: 36953 RVA: 0x000749FF File Offset: 0x00072BFF
		// (set) Token: 0x0600905A RID: 36954 RVA: 0x00074A07 File Offset: 0x00072C07
		public string LanguageCode { get; set; }

		// Token: 0x17002A00 RID: 10752
		// (get) Token: 0x0600905B RID: 36955 RVA: 0x00074A10 File Offset: 0x00072C10
		public IReadOnlyList<ParameterRuntime> AllParameters
		{
			get
			{
				return this.#a;
			}
		}

		// Token: 0x17002A01 RID: 10753
		// (get) Token: 0x0600905C RID: 36956 RVA: 0x00074A18 File Offset: 0x00072C18
		public List<ParameterRuntimeGroup> SectionParameterGroups { get; } = new List<ParameterRuntimeGroup>();

		// Token: 0x17002A02 RID: 10754
		// (get) Token: 0x0600905D RID: 36957 RVA: 0x00074A20 File Offset: 0x00072C20
		public List<ParameterRuntimeGroup> ReinforcementParameterGroups { get; } = new List<ParameterRuntimeGroup>();

		// Token: 0x17002A03 RID: 10755
		// (get) Token: 0x0600905E RID: 36958 RVA: 0x00074A28 File Offset: 0x00072C28
		public List<ParameterRuntimeGroup> OptionsParameterGroups { get; } = new List<ParameterRuntimeGroup>();

		// Token: 0x17002A04 RID: 10756
		// (get) Token: 0x0600905F RID: 36959 RVA: 0x00074A30 File Offset: 0x00072C30
		public bool IsOptionsTabVisible
		{
			get
			{
				return this.OptionsParameterGroups.Any<ParameterRuntimeGroup>();
			}
		}

		// Token: 0x06009060 RID: 36960 RVA: 0x001E8804 File Offset: 0x001E6A04
		public static TemplateEngineModel #Dge(SectionTemplateDefinition #xS, UnitSystem #Qg, DesignCodes #bO, IList<StandardBar> #Ege, string #pfe = "en-US")
		{
			TemplateEngineModel templateEngineModel = new TemplateEngineModel(#xS, #Qg, #bO, #Ege);
			templateEngineModel.Name = #xS.DisplayName.#ofe(#pfe);
			templateEngineModel.LanguageCode = #pfe;
			templateEngineModel.SectionParameterGroups.AddRange(TemplateEngineModel.#Fge(#xS.SectionParameters, #Qg, #bO, #pfe));
			templateEngineModel.ReinforcementParameterGroups.AddRange(TemplateEngineModel.#Fge(#xS.ReinforcementParameters, #Qg, #bO, #pfe));
			templateEngineModel.OptionsParameterGroups.AddRange(TemplateEngineModel.#Fge(#xS.OptionsParameters, #Qg, #bO, #pfe));
			templateEngineModel.#a.AddRange(templateEngineModel.SectionParameterGroups.Union(templateEngineModel.ReinforcementParameterGroups).Union(templateEngineModel.OptionsParameterGroups).SelectMany(new Func<ParameterRuntimeGroup, IEnumerable<ParameterRuntime>>(TemplateEngineModel.<>c.<>9.#Daf)));
			return templateEngineModel;
		}

		// Token: 0x06009061 RID: 36961 RVA: 0x001E88D0 File Offset: 0x001E6AD0
		private static List<ParameterRuntimeGroup> #Fge(IList<TemplateParameterGroupDefinition> #rk, UnitSystem #Qg, DesignCodes #bO, string #pfe)
		{
			List<ParameterRuntimeGroup> list = new List<ParameterRuntimeGroup>();
			foreach (TemplateParameterGroupDefinition templateParameterGroupDefinition in #rk)
			{
				ParameterRuntimeGroup parameterRuntimeGroup = new ParameterRuntimeGroup();
				parameterRuntimeGroup.Name = templateParameterGroupDefinition.Header.#ofe(#pfe);
				list.Add(parameterRuntimeGroup);
				foreach (TemplateParameterDefinition templateParameterDefinition in templateParameterGroupDefinition.Parameters)
				{
					TemplateParameterValueDefinition value = templateParameterDefinition.Values.#bfe(#Qg, #bO);
					string name = templateParameterDefinition.Text.#ofe(#pfe);
					TemplateSelectOptionsSet templateSelectOptionsSet = templateParameterDefinition.SelectOptions.#bfe(#Qg, #bO);
					ParameterRuntime item = new ParameterRuntime(templateParameterDefinition, value, name, (templateSelectOptionsSet != null) ? templateSelectOptionsSet.Options : null);
					parameterRuntimeGroup.Parameters.Add(item);
				}
			}
			return list;
		}

		// Token: 0x04003C92 RID: 15506
		private readonly List<ParameterRuntime> #a = new List<ParameterRuntime>();

		// Token: 0x04003C93 RID: 15507
		[CompilerGenerated]
		private readonly SectionTemplateDefinition #b;

		// Token: 0x04003C94 RID: 15508
		[CompilerGenerated]
		private string #c;

		// Token: 0x04003C95 RID: 15509
		[CompilerGenerated]
		private readonly UnitSystem #d;

		// Token: 0x04003C96 RID: 15510
		[CompilerGenerated]
		private readonly DesignCodes #e;

		// Token: 0x04003C97 RID: 15511
		[CompilerGenerated]
		private readonly StandardBarsProvider #f;

		// Token: 0x04003C98 RID: 15512
		[CompilerGenerated]
		private string #g;

		// Token: 0x04003C99 RID: 15513
		[CompilerGenerated]
		private readonly List<ParameterRuntimeGroup> #h;

		// Token: 0x04003C9A RID: 15514
		[CompilerGenerated]
		private readonly List<ParameterRuntimeGroup> #i;

		// Token: 0x04003C9B RID: 15515
		[CompilerGenerated]
		private readonly List<ParameterRuntimeGroup> #j;
	}
}
