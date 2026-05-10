using System;
using #0I;
using #5Z;
using #7hc;
using #9pe;
using #lH;
using #n8;
using #npe;
using #WG;
using #WI;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.Model.Validation.API.Definitions;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.Services.Definitions;
using StructurePoint.Products.Column.ViewModels.API.Core;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;

namespace StructurePoint.Products.Column.ViewModels.Definitions.Modules
{
	// Token: 0x0200027A RID: 634
	internal sealed class ReductionFactorsViewModel : #TH, #q8<#kqe>, #VI, #5I, IChangesInfo, #5G, #I8, #kqe
	{
		// Token: 0x06001499 RID: 5273 RVA: 0x00015BAB File Offset: 0x00013DAB
		public ReductionFactorsViewModel(ICoreServices services, IReductionFactorsViewModelValidator validator, IDefinitionsContext definitionsContext)
		{
			this.services = services;
			this.validator = validator;
			this.definitionsContext = definitionsContext;
			this.<ReductionFactors>k__BackingField = new ReductionFactors();
			this.<ConfinementTypeChangedCommand>k__BackingField = new DelegateCommand(new Action<object>(this.ExecuteConfinementTypeChanged));
		}

		// Token: 0x17000756 RID: 1878
		// (get) Token: 0x0600149A RID: 5274 RVA: 0x00015BEA File Offset: 0x00013DEA
		// (set) Token: 0x0600149B RID: 5275 RVA: 0x00015BF6 File Offset: 0x00013DF6
		public ConfinementType ConfinementType
		{
			get
			{
				return this.confinementType;
			}
			set
			{
				base.#KH<ConfinementType>(ref this.confinementType, value, this.validator, null, #Phc.#3hc(107408323));
				this.ValidateProperties();
			}
		}

		// Token: 0x17000757 RID: 1879
		// (get) Token: 0x0600149C RID: 5276 RVA: 0x00015C29 File Offset: 0x00013E29
		// (set) Token: 0x0600149D RID: 5277 RVA: 0x000B0A40 File Offset: 0x000AEC40
		public float A
		{
			get
			{
				return this.a;
			}
			set
			{
				base.#KH<float>(ref this.a, value, this.validator, delegate()
				{
					this.ReductionFactors.A = value;
				}, #Phc.#3hc(107408119));
			}
		}

		// Token: 0x17000758 RID: 1880
		// (get) Token: 0x0600149E RID: 5278 RVA: 0x00015C35 File Offset: 0x00013E35
		// (set) Token: 0x0600149F RID: 5279 RVA: 0x000B0A9C File Offset: 0x000AEC9C
		public float B
		{
			get
			{
				return this.b;
			}
			set
			{
				base.#KH<float>(ref this.b, value, this.validator, delegate()
				{
					this.ReductionFactors.B = value;
				}, #Phc.#3hc(107408114));
			}
		}

		// Token: 0x17000759 RID: 1881
		// (get) Token: 0x060014A0 RID: 5280 RVA: 0x00015C41 File Offset: 0x00013E41
		// (set) Token: 0x060014A1 RID: 5281 RVA: 0x000B0AF8 File Offset: 0x000AECF8
		public float C
		{
			get
			{
				return this.c;
			}
			set
			{
				base.#KH<float>(ref this.c, value, this.validator, delegate()
				{
					this.ReductionFactors.C = value;
				}, #Phc.#3hc(107408077));
			}
		}

		// Token: 0x1700075A RID: 1882
		// (get) Token: 0x060014A2 RID: 5282 RVA: 0x00015C4D File Offset: 0x00013E4D
		// (set) Token: 0x060014A3 RID: 5283 RVA: 0x000B0B54 File Offset: 0x000AED54
		public float Trans
		{
			get
			{
				return this.trans;
			}
			set
			{
				base.#KH<float>(ref this.trans, value, this.validator, delegate()
				{
					this.ReductionFactors.Trans = value;
				}, #Phc.#3hc(107408302));
			}
		}

		// Token: 0x1700075B RID: 1883
		// (get) Token: 0x060014A4 RID: 5284 RVA: 0x00015C59 File Offset: 0x00013E59
		// (set) Token: 0x060014A5 RID: 5285 RVA: 0x000B0BB0 File Offset: 0x000AEDB0
		public float MinDimension
		{
			get
			{
				return this.minDimension;
			}
			set
			{
				base.#KH<float>(ref this.minDimension, value, this.validator, delegate()
				{
					this.ReductionFactors.MinDimension = value;
				}, #Phc.#3hc(107408293));
			}
		}

		// Token: 0x1700075C RID: 1884
		// (get) Token: 0x060014A6 RID: 5286 RVA: 0x00015C65 File Offset: 0x00013E65
		public ReductionFactors ReductionFactors { get; }

		// Token: 0x1700075D RID: 1885
		// (get) Token: 0x060014A7 RID: 5287 RVA: 0x00015C71 File Offset: 0x00013E71
		public string FactorsSectionTitle
		{
			get
			{
				if (!this.IsCsaCode)
				{
					return Strings.StringCapacityReductionFactors;
				}
				return Strings.StringMaterialResistanceFactors;
			}
		}

		// Token: 0x1700075E RID: 1886
		// (get) Token: 0x060014A8 RID: 5288 RVA: 0x00015C92 File Offset: 0x00013E92
		public string LabelB
		{
			get
			{
				if (!this.IsCsaCode)
				{
					return Strings.StringTensionControlledB;
				}
				return Strings.StringSteelS;
			}
		}

		// Token: 0x1700075F RID: 1887
		// (get) Token: 0x060014A9 RID: 5289 RVA: 0x00015CB3 File Offset: 0x00013EB3
		public string LabelC
		{
			get
			{
				if (!this.IsCsaCode)
				{
					return Strings.StringCompressionControlled;
				}
				return Strings.StringConcreteC;
			}
		}

		// Token: 0x17000760 RID: 1888
		// (get) Token: 0x060014AA RID: 5290 RVA: 0x00015CD4 File Offset: 0x00013ED4
		public bool IsCsaCode
		{
			get
			{
				return this.services.Project.Model.Options.#h3();
			}
		}

		// Token: 0x17000761 RID: 1889
		// (get) Token: 0x060014AB RID: 5291 RVA: 0x000B0C0C File Offset: 0x000AEE0C
		public bool IsIrregularSectionVisible
		{
			get
			{
				return this.services.Project.Model.Options.#i3() && this.ConfinementType == ConfinementType.Tied && this.services.Project.Model.Options.SectionType == SectionType.Irregular;
			}
		}

		// Token: 0x17000762 RID: 1890
		// (get) Token: 0x060014AC RID: 5292 RVA: 0x00015CFC File Offset: 0x00013EFC
		public bool IsVarStringVisibleInUnitBox
		{
			get
			{
				return this.services.Project.Model.Options.#i3() && this.ConfinementType == ConfinementType.Tied;
			}
		}

		// Token: 0x17000763 RID: 1891
		// (get) Token: 0x060014AD RID: 5293 RVA: 0x00015D31 File Offset: 0x00013F31
		public DelegateCommand ConfinementTypeChangedCommand { get; }

		// Token: 0x17000764 RID: 1892
		// (get) Token: 0x060014AE RID: 5294 RVA: 0x00015D3D File Offset: 0x00013F3D
		public static RadObservableCollection<ComboItem<ConfinementType>> ConfinementCollection { get; } = new RadObservableCollection<ComboItem<ConfinementType>>
		{
			new ComboItem<ConfinementType>(ConfinementType.Tied, Strings.StringTied),
			new ComboItem<ConfinementType>(ConfinementType.Spiral, Strings.StringSpiral),
			new ComboItem<ConfinementType>(ConfinementType.Other, Strings.StringOther)
		};

		// Token: 0x17000765 RID: 1893
		// (get) Token: 0x060014AF RID: 5295 RVA: 0x0000A816 File Offset: 0x00008A16
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x060014B0 RID: 5296 RVA: 0x000B0C68 File Offset: 0x000AEE68
		public bool GetHasChanges()
		{
			return this.ConfinementType != this.services.Project.Model.Options.ConfinementType || !#Oai.#uC(this, this.services.Project.Model.ReductionFactors);
		}

		// Token: 0x060014B1 RID: 5297 RVA: 0x00015D44 File Offset: 0x00013F44
		public override void UpdateFromModel(ColumnModel model)
		{
			this.CopyFrom(model.ReductionFactors);
			this.ConfinementType = model.Options.ConfinementType;
			this.ApplyDefaultFactors(this);
			this.RefreshViewOnlyRelatedProperties();
		}

		// Token: 0x060014B2 RID: 5298 RVA: 0x00015D7C File Offset: 0x00013F7C
		public override void UpdateModel(ColumnModel model)
		{
			model.ReductionFactors.CopyFrom(this);
			model.Options.ConfinementType = this.ConfinementType;
			this.ApplyDefaultFactors(model.ReductionFactors);
			model.#HY(#ope.#b);
		}

		// Token: 0x060014B3 RID: 5299 RVA: 0x000B0CC4 File Offset: 0x000AEEC4
		public void CopyFrom(#kqe other)
		{
			this.A = other.A;
			this.B = other.B;
			this.C = other.C;
			this.Trans = other.Trans;
			this.MinDimension = other.MinDimension;
			this.ValidateProperties();
		}

		// Token: 0x060014B4 RID: 5300 RVA: 0x00015DBA File Offset: 0x00013FBA
		public void OnPanelActivated()
		{
			this.ValidateProperties();
			this.RefreshViewOnlyRelatedProperties();
			this.ApplyDefaultFactors(this);
		}

		// Token: 0x060014B5 RID: 5301 RVA: 0x00015DDB File Offset: 0x00013FDB
		private void ValidateProperties()
		{
			base.#PH<#kqe>(this.validator, null);
		}

		// Token: 0x060014B6 RID: 5302 RVA: 0x000B0D20 File Offset: 0x000AEF20
		private void RefreshViewOnlyRelatedProperties()
		{
			string[] #OH = new string[]
			{
				#Phc.#3hc(107408308),
				#Phc.#3hc(107408279),
				#Phc.#3hc(107408238),
				#Phc.#3hc(107408229),
				#Phc.#3hc(107408192)
			};
			base.#SH(#OH);
		}

		// Token: 0x060014B7 RID: 5303 RVA: 0x00015DF7 File Offset: 0x00013FF7
		private void ExecuteConfinementTypeChanged(object parameter)
		{
			this.ApplyDefaultFactors(this);
			this.RefreshViewOnlyRelatedProperties();
		}

		// Token: 0x060014B8 RID: 5304 RVA: 0x000B0D88 File Offset: 0x000AEF88
		private void ApplyDefaultFactors(#kqe factors)
		{
			#k3 #k = this.services.Project.Model.Options;
			#1pe.#vpe(#k.Unit, #k.Code, this.confinementType, this.definitionsContext.IsPrecast, factors);
		}

		// Token: 0x060014BA RID: 5306 RVA: 0x0000A950 File Offset: 0x00008B50
		void #5I.ClearErrors()
		{
			base.ClearErrors();
		}

		// Token: 0x060014BB RID: 5307 RVA: 0x0000A960 File Offset: 0x00008B60
		void #5I.RemoveError(string propertyName)
		{
			base.RemoveError(propertyName);
		}

		// Token: 0x0400086A RID: 2154
		private readonly ICoreServices services;

		// Token: 0x0400086B RID: 2155
		private readonly IReductionFactorsViewModelValidator validator;

		// Token: 0x0400086C RID: 2156
		private readonly IDefinitionsContext definitionsContext;

		// Token: 0x0400086D RID: 2157
		private ConfinementType confinementType;

		// Token: 0x0400086E RID: 2158
		private float a;

		// Token: 0x0400086F RID: 2159
		private float b;

		// Token: 0x04000870 RID: 2160
		private float c;

		// Token: 0x04000871 RID: 2161
		private float trans;

		// Token: 0x04000872 RID: 2162
		private float minDimension;
	}
}
