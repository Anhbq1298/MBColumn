using System;
using System.Collections.Generic;
using System.ComponentModel;
using #0I;
using #Bc;
using #BF;
using #kB;
using #qJ;
using #WG;
using #WI;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Core.API;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.ViewModels.API.Definitions;
using StructurePoint.Products.Column.ViewModels.Core;

namespace #tF
{
	// Token: 0x02000234 RID: 564
	internal sealed class #sF : WindowViewModelBase<DefinitionType, #Gc>, INotifyPropertyChanged, IViewModel<IColumnWindow>, #YI<DefinitionType>, #6I<DefinitionType>, IViewModel, #0G
	{
		// Token: 0x06001301 RID: 4865 RVA: 0x000AD12C File Offset: 0x000AB32C
		public #sF(Lazy<#Gc> #Ee, ICoreServices #0c, #OUh #xUh, #HUh #yUh, #7G #vF, #3G #wF, #AUh #zUh, #YG #yF, #VG #zF, #jB #pl, #zJ #pj, IEditorService #wj) : base(#Ee, #0c, #pl, #pj, #wj)
		{
			this.#a = #xUh;
			this.#b = #yUh;
			this.#c = #vF;
			this.#d = #wF;
			this.#e = #zUh;
			this.#f = #yF;
			this.#g = #zF;
			base.CheckForChangesOnClosing = true;
			base.AskToSaveChangesBeforeClosingMessage = Strings.StringModifiedDefinitionsNotSaved.#z2d().#Tm() + Strings.StringWouldYouLikeToSaveThem.#J2d();
		}

		// Token: 0x170006E3 RID: 1763
		// (get) Token: 0x06001302 RID: 4866 RVA: 0x000148D9 File Offset: 0x00012AD9
		public bool IsDesignCriteriaEnabled
		{
			get
			{
				return base.Services.Project.Model.Options.ProblemType == ProblemType.Design;
			}
		}

		// Token: 0x170006E4 RID: 1764
		// (get) Token: 0x06001303 RID: 4867 RVA: 0x00014904 File Offset: 0x00012B04
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x06001304 RID: 4868 RVA: 0x000AD1AC File Offset: 0x000AB3AC
		public override void #Mq(DefinitionType #kx)
		{
			if (base.ShowLock.#YXd())
			{
				try
				{
					base.#Mq(#kx);
				}
				finally
				{
					base.ShowLock.#ZXd();
				}
			}
		}

		// Token: 0x06001305 RID: 4869 RVA: 0x000AD1F8 File Offset: 0x000AB3F8
		public override IEnumerable<PanelItem> #Lq()
		{
			PanelItem panelItem = new PanelItem(Strings.StringProperties);
			panelItem.Children.Add(new PanelItem(DefinitionType.DefineConcreteMaterial, Strings.StringConcrete, this.#a, true));
			panelItem.Children.Add(new PanelItem(DefinitionType.DefineSteelMaterial, Strings.StringReinforcingSteel, this.#b, true));
			panelItem.Children.Add(new PanelItem(DefinitionType.DefineReductionFactors, Strings.StringReductionFactors, this.#c, true));
			panelItem.Children.Add(new PanelItem(DefinitionType.DefineDesignCriteria, Strings.StringDesignCriteria, this.#d, this.IsDesignCriteriaEnabled));
			panelItem.Children.Add(new PanelItem(DefinitionType.DefineBarSet, Strings.StringBarSet_PASCAL, this.#e, true));
			PanelItem panelItem2 = new PanelItem(Strings.StringLoadCaseCombo);
			panelItem2.Children.Add(new PanelItem(DefinitionType.DefineLoadCases, Strings.StringLoadCases_CAMEL, this.#f, true));
			panelItem2.Children.Add(new PanelItem(DefinitionType.DefineLoadCombinations, Strings.StringLoadCombinations, this.#g, true));
			return new List<PanelItem>
			{
				panelItem,
				panelItem2
			};
		}

		// Token: 0x040007C7 RID: 1991
		private readonly #OUh #a;

		// Token: 0x040007C8 RID: 1992
		private readonly #HUh #b;

		// Token: 0x040007C9 RID: 1993
		private readonly #7G #c;

		// Token: 0x040007CA RID: 1994
		private readonly #3G #d;

		// Token: 0x040007CB RID: 1995
		private readonly #AUh #e;

		// Token: 0x040007CC RID: 1996
		private readonly #YG #f;

		// Token: 0x040007CD RID: 1997
		private readonly #VG #g;
	}
}
