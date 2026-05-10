using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using #0I;
using #5Z;
using #7hc;
using #lH;
using #M7;
using #n8;
using #npe;
using #WG;
using #WI;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.Model.Validation.API.Definitions;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.ViewModels.API.Core;
using StructurePoint.Products.Column.Views.API.Definitions;
using Telerik.Windows.Data;

namespace StructurePoint.Products.Column.ViewModels.Definitions.Modules
{
	// Token: 0x02000264 RID: 612
	internal sealed class DesignCriteriaViewModel : #TH, #q8<#J8>, #VI, #5I, IChangesInfo, #2G, #J8, IReinforcementRatios, #p8
	{
		// Token: 0x0600141B RID: 5147 RVA: 0x00015624 File Offset: 0x00013824
		public DesignCriteriaViewModel(ICoreServices services, Lazy<IDesignCriteriaView> view, IDesignCriteriaViewModelValidator designCriteriaValidator, IReinforcementRatiosValidator reinforcementRatiosValidator)
		{
			this.services = services;
			this.view = view;
			this.designCriteriaValidator = designCriteriaValidator;
			this.reinforcementRatiosValidator = reinforcementRatiosValidator;
			this.<ReinforcementRatios>k__BackingField = new StructurePoint.Products.Column.Model.Entities.ReinforcementRatios();
		}

		// Token: 0x1700072B RID: 1835
		// (get) Token: 0x0600141C RID: 5148 RVA: 0x00015654 File Offset: 0x00013854
		public StructurePoint.Products.Column.Model.Entities.ReinforcementRatios ReinforcementRatios { get; }

		// Token: 0x1700072C RID: 1836
		// (get) Token: 0x0600141D RID: 5149 RVA: 0x00015660 File Offset: 0x00013860
		// (set) Token: 0x0600141E RID: 5150 RVA: 0x000B00CC File Offset: 0x000AE2CC
		public ColumnType ColumnType
		{
			get
			{
				return this.columnType;
			}
			set
			{
				base.#KH<ColumnType>(ref this.columnType, value, this.designCriteriaValidator, delegate()
				{
					this.OnColumnTypeChanged(value);
				}, #Phc.#3hc(107408072));
			}
		}

		// Token: 0x1700072D RID: 1837
		// (get) Token: 0x0600141F RID: 5151 RVA: 0x0001566C File Offset: 0x0001386C
		// (set) Token: 0x06001420 RID: 5152 RVA: 0x00015678 File Offset: 0x00013878
		public DesignTarget DesignTarget
		{
			get
			{
				return this.barSelection;
			}
			set
			{
				base.#KH<DesignTarget>(ref this.barSelection, value, this.designCriteriaValidator, null, #Phc.#3hc(107408087));
			}
		}

		// Token: 0x1700072E RID: 1838
		// (get) Token: 0x06001421 RID: 5153 RVA: 0x000156A5 File Offset: 0x000138A5
		// (set) Token: 0x06001422 RID: 5154 RVA: 0x000B0128 File Offset: 0x000AE328
		public float MinReinforcementRatio
		{
			get
			{
				return this.minReinforcementRatio;
			}
			set
			{
				base.#KH<float>(ref this.minReinforcementRatio, value, this.reinforcementRatiosValidator, delegate()
				{
					this.ReinforcementRatios.MinReinforcementRatio = value;
				}, #Phc.#3hc(107408038));
				this.RefreshValidationMessages();
			}
		}

		// Token: 0x1700072F RID: 1839
		// (get) Token: 0x06001423 RID: 5155 RVA: 0x000156B1 File Offset: 0x000138B1
		// (set) Token: 0x06001424 RID: 5156 RVA: 0x000B018C File Offset: 0x000AE38C
		public float MaxReinforcementRatio
		{
			get
			{
				return this.maxReinforcementRatio;
			}
			set
			{
				base.#KH<float>(ref this.maxReinforcementRatio, value, this.reinforcementRatiosValidator, delegate()
				{
					this.ReinforcementRatios.MaxReinforcementRatio = value;
				}, #Phc.#3hc(107408009));
				this.RefreshValidationMessages();
			}
		}

		// Token: 0x17000730 RID: 1840
		// (get) Token: 0x06001425 RID: 5157 RVA: 0x000156BD File Offset: 0x000138BD
		// (set) Token: 0x06001426 RID: 5158 RVA: 0x000B01F0 File Offset: 0x000AE3F0
		public float MinRebarClearSpacing
		{
			get
			{
				return this.minRebarClearSpacing;
			}
			set
			{
				base.#KH<float>(ref this.minRebarClearSpacing, value, this.designCriteriaValidator, delegate()
				{
					this.LastValidClearSpacing = value;
				}, #Phc.#3hc(107407980));
			}
		}

		// Token: 0x17000731 RID: 1841
		// (get) Token: 0x06001427 RID: 5159 RVA: 0x000156C9 File Offset: 0x000138C9
		public static RadObservableCollection<ComboItem<DesignTarget>> DesignTargetCollection { get; } = new RadObservableCollection<ComboItem<DesignTarget>>
		{
			new ComboItem<DesignTarget>(DesignTarget.MinNumBars, Strings.StringMinNumberOfBars),
			new ComboItem<DesignTarget>(DesignTarget.MinSteelArea, Strings.StringMinAreaOfSteel)
		};

		// Token: 0x17000732 RID: 1842
		// (get) Token: 0x06001428 RID: 5160 RVA: 0x000156D0 File Offset: 0x000138D0
		// (set) Token: 0x06001429 RID: 5161 RVA: 0x000B024C File Offset: 0x000AE44C
		public float CapacityRatio
		{
			get
			{
				return this.capacityRatio;
			}
			set
			{
				base.#KH<float>(ref this.capacityRatio, value, this.designCriteriaValidator, delegate()
				{
					this.LastValidCapacityRatio = value;
				}, #Phc.#3hc(107407951));
			}
		}

		// Token: 0x17000733 RID: 1843
		// (get) Token: 0x0600142A RID: 5162 RVA: 0x000156DC File Offset: 0x000138DC
		// (set) Token: 0x0600142B RID: 5163 RVA: 0x000156E8 File Offset: 0x000138E8
		public float LastValidClearSpacing
		{
			get
			{
				return this.lastValidClearSpacing;
			}
			set
			{
				this.SetProperty<float>(ref this.lastValidClearSpacing, value, #Phc.#3hc(107407962));
			}
		}

		// Token: 0x17000734 RID: 1844
		// (get) Token: 0x0600142C RID: 5164 RVA: 0x0001570E File Offset: 0x0001390E
		// (set) Token: 0x0600142D RID: 5165 RVA: 0x0001571A File Offset: 0x0001391A
		public float LastValidCapacityRatio
		{
			get
			{
				return this.lastValidCapacityRatio;
			}
			set
			{
				this.SetProperty<float>(ref this.lastValidCapacityRatio, value, #Phc.#3hc(107407933));
			}
		}

		// Token: 0x17000735 RID: 1845
		// (get) Token: 0x0600142E RID: 5166 RVA: 0x0000A816 File Offset: 0x00008A16
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x0600142F RID: 5167 RVA: 0x000B02A8 File Offset: 0x000AE4A8
		public bool GetHasChanges()
		{
			#k3 #k = this.services.Project.Model.Options;
			float obj = this.services.Project.Model.MinRebarClearSpacing;
			float obj2 = this.services.Project.Model.DesignToRequiredRatio;
			Func<IReinforcementRatios, IReinforcementRatios, bool> <0>__AreEqual;
			if ((<0>__AreEqual = DesignCriteriaViewModel.<>O.<0>__AreEqual) == null)
			{
				DesignCriteriaViewModel.<>O.<0>__AreEqual = new Func<IReinforcementRatios, IReinforcementRatios, bool>(#Oai.#uC);
			}
			return this.ColumnType != #k.ColumnType || this.DesignTarget != #k.DesignTarget || !this.MinRebarClearSpacing.Equals(obj) || !this.CapacityRatio.Equals(obj2) || !#Oai.#uC(this, this.services.Project.Model.ReinforcementRatios);
		}

		// Token: 0x06001430 RID: 5168 RVA: 0x000B0394 File Offset: 0x000AE594
		public override void UpdateFromModel(ColumnModel model)
		{
			this.ColumnType = model.Options.ColumnType;
			this.DesignTarget = model.Options.DesignTarget;
			this.MinRebarClearSpacing = model.MinRebarClearSpacing;
			this.CapacityRatio = model.DesignToRequiredRatio;
			this.CopyFrom(model.ReinforcementRatios);
			base.#PH<#2G>(this.designCriteriaValidator, null);
			base.#PH<IReinforcementRatios>(this.reinforcementRatiosValidator, null);
			this.currentModel = model;
		}

		// Token: 0x06001431 RID: 5169 RVA: 0x000B0418 File Offset: 0x000AE618
		public override void UpdateModel(ColumnModel model)
		{
			model.ReinforcementRatios.MinReinforcementRatio = this.MinReinforcementRatio / 100f;
			model.ReinforcementRatios.MaxReinforcementRatio = this.MaxReinforcementRatio / 100f;
			model.Options.ColumnType = this.ColumnType;
			model.Options.DesignTarget = this.DesignTarget;
			model.MinRebarClearSpacing = this.MinRebarClearSpacing;
			model.DesignToRequiredRatio = this.CapacityRatio;
		}

		// Token: 0x06001432 RID: 5170 RVA: 0x00015740 File Offset: 0x00013940
		public void CopyFrom(#J8 other)
		{
			this.MinReinforcementRatio = other.MinReinforcementRatio * 100f;
			this.MaxReinforcementRatio = other.MaxReinforcementRatio * 100f;
		}

		// Token: 0x06001433 RID: 5171 RVA: 0x000B049C File Offset: 0x000AE69C
		public void OnPanelActivated()
		{
			base.#PH<#2G, IDesignCriteriaView>(this.designCriteriaValidator, this.view, this.services.MouseAndKeyboard);
			base.#PH<IReinforcementRatios, IDesignCriteriaView>(this.reinforcementRatiosValidator, this.view, this.services.MouseAndKeyboard);
		}

		// Token: 0x06001434 RID: 5172 RVA: 0x000B04F4 File Offset: 0x000AE6F4
		private void OnColumnTypeChanged(ColumnType columnType)
		{
			if (columnType == ColumnType.Other)
			{
				if (this.currentModel != null)
				{
					this.CopyFrom(this.currentModel.ReinforcementRatios);
				}
				return;
			}
			Dictionary<ColumnType, StructurePoint.Products.Column.Model.Entities.ReinforcementRatios> dictionary = #L7.ReinforcementRatioDefaults;
			StructurePoint.Products.Column.Model.Entities.ReinforcementRatios other;
			if (dictionary.TryGetValue(columnType, out other))
			{
				this.CopyFrom(other);
			}
		}

		// Token: 0x06001435 RID: 5173 RVA: 0x00015772 File Offset: 0x00013972
		private void RefreshValidationMessages()
		{
			base.#NH(this.reinforcementRatiosValidator, new string[]
			{
				#Phc.#3hc(107408038),
				#Phc.#3hc(107408009)
			});
		}

		// Token: 0x06001437 RID: 5175 RVA: 0x0000A950 File Offset: 0x00008B50
		void #5I.ClearErrors()
		{
			base.ClearErrors();
		}

		// Token: 0x06001438 RID: 5176 RVA: 0x0000A960 File Offset: 0x00008B60
		void #5I.RemoveError(string propertyName)
		{
			base.RemoveError(propertyName);
		}

		// Token: 0x04000832 RID: 2098
		private ColumnModel currentModel;

		// Token: 0x04000833 RID: 2099
		private readonly ICoreServices services;

		// Token: 0x04000834 RID: 2100
		private readonly Lazy<IDesignCriteriaView> view;

		// Token: 0x04000835 RID: 2101
		private readonly IDesignCriteriaViewModelValidator designCriteriaValidator;

		// Token: 0x04000836 RID: 2102
		private readonly IReinforcementRatiosValidator reinforcementRatiosValidator;

		// Token: 0x04000837 RID: 2103
		private float minReinforcementRatio;

		// Token: 0x04000838 RID: 2104
		private float maxReinforcementRatio;

		// Token: 0x04000839 RID: 2105
		private float minRebarClearSpacing;

		// Token: 0x0400083A RID: 2106
		private ColumnType columnType;

		// Token: 0x0400083B RID: 2107
		private DesignTarget barSelection;

		// Token: 0x0400083C RID: 2108
		private float capacityRatio;

		// Token: 0x0400083D RID: 2109
		private float lastValidClearSpacing;

		// Token: 0x0400083E RID: 2110
		private float lastValidCapacityRatio;

		// Token: 0x02000265 RID: 613
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x04000841 RID: 2113
			public static Func<IReinforcementRatios, IReinforcementRatios, bool> <0>__AreEqual;
		}
	}
}
