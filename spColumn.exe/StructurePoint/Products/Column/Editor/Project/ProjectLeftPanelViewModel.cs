using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using #6s;
using #7hc;
using #9pe;
using #aHb;
using #APb;
using #eU;
using #IDc;
using #IW;
using #lH;
using #npe;
using #oKe;
using #Oze;
using #WG;
using #xKe;
using #YZ;
using StructurePoint.CoreAssets.AppManager.Column.Core;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.CoreAssets.Units;
using StructurePoint.Products.Column.Core.API;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.ViewModels.API.Definitions;
using StructurePoint.Products.Column.ViewModels.Definitions.Modules;
using StructurePoint.Products.Column.ViewModels.Slenderness.Helpers;
using StructurePoint.Products.Column.Viewports.API;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;

namespace StructurePoint.Products.Column.Editor.Project
{
	// Token: 0x0200062E RID: 1582
	internal sealed class ProjectLeftPanelViewModel : #HH<#LPb>, INotifyPropertyChanged, IViewModel, IViewModel<#LPb>, #hqe, #iqe, #MPb
	{
		// Token: 0x06003585 RID: 13701 RVA: 0x00108614 File Offset: 0x00106814
		public ProjectLeftPanelViewModel(Lazy<#LPb> view, #nKe localization, #oW projectContext, IEditorService editorService, #1V unitsChangeService, IExtendedServices services, #0G definitionsWindow, #ht slendernessWindow, #UV messageBus, #zU guiController, #ZZ concreteValidator, #0Z steelValidator, #KW loadTypeService, #bHb capacityRatioInfo, #mAe superImposeContext) : base(view, services)
		{
			this.#A = capacityRatioInfo;
			this.#f = definitionsWindow;
			this.#g = slendernessWindow;
			this.#a = projectContext;
			this.#b = unitsChangeService;
			this.#c = services;
			this.#d = guiController;
			this.#e = editorService;
			this.#h = messageBus;
			this.#i = localization;
			this.#j = concreteValidator;
			this.#k = steelValidator;
			this.#l = loadTypeService;
			this.#m = superImposeContext;
			this.#5w();
			projectContext.ModelChanged += this.#wJb;
			messageBus.UnitSystemChanged += this.#EO;
			messageBus.DefinitionChangesCommitted += this.#owb;
			this.#B = new DelegateCommand(new Action<object>(this.#EJb));
		}

		// Token: 0x170010B2 RID: 4274
		// (get) Token: 0x06003586 RID: 13702 RVA: 0x0002EF7A File Offset: 0x0002D17A
		public #bHb CapacityRatioInfo { get; }

		// Token: 0x170010B3 RID: 4275
		// (get) Token: 0x06003587 RID: 13703 RVA: 0x0002EF86 File Offset: 0x0002D186
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x170010B4 RID: 4276
		// (get) Token: 0x06003588 RID: 13704 RVA: 0x0002EF96 File Offset: 0x0002D196
		public DelegateCommand OpenDefinitionsWindowCommand { get; }

		// Token: 0x170010B5 RID: 4277
		// (get) Token: 0x06003589 RID: 13705 RVA: 0x0002EFA2 File Offset: 0x0002D1A2
		public RadObservableCollection<ComboItem<DesignCodes>> DesignCodes { get; }

		// Token: 0x170010B6 RID: 4278
		// (get) Token: 0x0600358A RID: 13706 RVA: 0x0002EFAE File Offset: 0x0002D1AE
		public RadObservableCollection<ComboItem<UnitSystem>> UnitSystems { get; }

		// Token: 0x170010B7 RID: 4279
		// (get) Token: 0x0600358B RID: 13707 RVA: 0x0002EFBA File Offset: 0x0002D1BA
		public RadObservableCollection<ComboItem<BarGroupType>> BarGroupTypes { get; }

		// Token: 0x170010B8 RID: 4280
		// (get) Token: 0x0600358C RID: 13708 RVA: 0x0002EFC6 File Offset: 0x0002D1C6
		public RadObservableCollection<ComboItem<ConfinementType>> ConfinementTypes { get; }

		// Token: 0x170010B9 RID: 4281
		// (get) Token: 0x0600358D RID: 13709 RVA: 0x0002EFD2 File Offset: 0x0002D1D2
		public RadObservableCollection<ComboItem<ProblemType>> ProblemTypes { get; }

		// Token: 0x170010BA RID: 4282
		// (get) Token: 0x0600358E RID: 13710 RVA: 0x0002EFDE File Offset: 0x0002D1DE
		public RadObservableCollection<ComboItem<ConsideredAxis>> ConsideredAxes { get; }

		// Token: 0x170010BB RID: 4283
		// (get) Token: 0x0600358F RID: 13711 RVA: 0x0002EFEA File Offset: 0x0002D1EA
		public RadObservableCollection<ComboItem<bool>> ConsiderSlendernessOptions { get; }

		// Token: 0x170010BC RID: 4284
		// (get) Token: 0x06003590 RID: 13712 RVA: 0x0002EFF6 File Offset: 0x0002D1F6
		public RadObservableCollection<ComboItem<SectionCapacityMethodType>> SectionCapacity { get; }

		// Token: 0x170010BD RID: 4285
		// (get) Token: 0x06003591 RID: 13713 RVA: 0x0002F002 File Offset: 0x0002D202
		// (set) Token: 0x06003592 RID: 13714 RVA: 0x00108748 File Offset: 0x00106948
		public float Fcp
		{
			get
			{
				return this.#q;
			}
			set
			{
				ProjectLeftPanelViewModel.#tWb #tWb = new ProjectLeftPanelViewModel.#tWb();
				#tWb.#a = this;
				#tWb.#b = value;
				base.RaisePropertyChanging(#Phc.#3hc(107412979));
				this.#q = #tWb.#b;
				base.RaisePropertyChanged(#Phc.#3hc(107412979));
				bool flag = base.#JH(this.#j, #Phc.#3hc(107412979));
				if (!flag || (double)Math.Abs(this.#a.Model.MaterialProperties.Fcp - #tWb.#b) <= 0.001)
				{
					return;
				}
				this.#e.#0Pb(new Action(#tWb.#tZb));
				if (!this.#a.Model.MaterialProperties.IsConcreteStandard && base.DialogService.#od(base.DialogService.ActiveWindow, Strings.StringConcreteIsNonStandardVerifyRelatedProperties.#z2d(), ColumnGlobalInfo.ShortName, MessageBoxButton.OKCancel, MessageBoxImage.Exclamation, MessageBoxResult.OK, MessageBoxOptions.None) == MessageBoxResult.OK)
				{
					this.#f.#Mq(DefinitionType.DefineConcreteMaterial);
				}
			}
		}

		// Token: 0x170010BE RID: 4286
		// (get) Token: 0x06003593 RID: 13715 RVA: 0x0002F00E File Offset: 0x0002D20E
		// (set) Token: 0x06003594 RID: 13716 RVA: 0x00108864 File Offset: 0x00106A64
		public float Fy
		{
			get
			{
				return this.#r;
			}
			set
			{
				ProjectLeftPanelViewModel.#O5b #O5b = new ProjectLeftPanelViewModel.#O5b();
				#O5b.#a = this;
				#O5b.#b = value;
				base.RaisePropertyChanging(#Phc.#3hc(107408699));
				this.#r = #O5b.#b;
				base.RaisePropertyChanged(#Phc.#3hc(107408699));
				bool flag = base.#JH(this.#k, #Phc.#3hc(107408699));
				if (!flag || (double)Math.Abs(this.#a.Model.MaterialProperties.Fy - #O5b.#b) <= 0.001)
				{
					return;
				}
				this.#e.#0Pb(new Action(#O5b.#BZb));
				if (!this.#a.Model.MaterialProperties.IsSteelStandard && base.DialogService.#od(base.DialogService.ActiveWindow, Strings.StringReinforcingSteelIsNonStandardVerifyRelatedProperties.#z2d(), ColumnGlobalInfo.ShortName, MessageBoxButton.OKCancel, MessageBoxImage.Exclamation, MessageBoxResult.OK, MessageBoxOptions.None) == MessageBoxResult.OK)
				{
					this.#f.#Mq(DefinitionType.DefineSteelMaterial);
				}
			}
		}

		// Token: 0x170010BF RID: 4287
		// (get) Token: 0x06003595 RID: 13717 RVA: 0x0002F01A File Offset: 0x0002D21A
		// (set) Token: 0x06003596 RID: 13718 RVA: 0x00009E6A File Offset: 0x0000806A
		public bool IsConcreteStandard
		{
			get
			{
				return base.Project.Model.MaterialProperties.IsConcreteStandard;
			}
			set
			{
			}
		}

		// Token: 0x170010C0 RID: 4288
		// (get) Token: 0x06003597 RID: 13719 RVA: 0x0002F03D File Offset: 0x0002D23D
		// (set) Token: 0x06003598 RID: 13720 RVA: 0x00009E6A File Offset: 0x0000806A
		public bool IsSteelStandard
		{
			get
			{
				return base.Project.Model.MaterialProperties.IsSteelStandard;
			}
			set
			{
			}
		}

		// Token: 0x170010C1 RID: 4289
		// (get) Token: 0x06003599 RID: 13721 RVA: 0x0002F060 File Offset: 0x0002D260
		// (set) Token: 0x0600359A RID: 13722 RVA: 0x00108980 File Offset: 0x00106B80
		public ComboItem<DesignCodes> SelectedDesignCode
		{
			get
			{
				return this.#s;
			}
			set
			{
				ProjectLeftPanelViewModel.#QTb #QTb = new ProjectLeftPanelViewModel.#QTb();
				#QTb.#a = this;
				#QTb.#b = value;
				if (this.#s != #QTb.#b)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107409714));
					this.#s = #QTb.#b;
					base.RaisePropertyChanged(#Phc.#3hc(107409714));
					this.#e.#0Pb(new Action(#QTb.#Nbc));
					this.#h.#DV();
					this.#h.#CV();
				}
			}
		}

		// Token: 0x170010C2 RID: 4290
		// (get) Token: 0x0600359B RID: 13723 RVA: 0x0002F06C File Offset: 0x0002D26C
		// (set) Token: 0x0600359C RID: 13724 RVA: 0x00108A28 File Offset: 0x00106C28
		public ComboItem<UnitSystem> SelectedUnitSystem
		{
			get
			{
				return this.#t;
			}
			set
			{
				if (this.#t != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107409689));
					this.#t = value;
					base.RaisePropertyChanged(#Phc.#3hc(107409689));
					this.#BJb(this.#t.Value);
				}
			}
		}

		// Token: 0x170010C3 RID: 4291
		// (get) Token: 0x0600359D RID: 13725 RVA: 0x0002F078 File Offset: 0x0002D278
		// (set) Token: 0x0600359E RID: 13726 RVA: 0x00108A84 File Offset: 0x00106C84
		public ComboItem<BarGroupType> SelectedBarGroupType
		{
			get
			{
				return this.#u;
			}
			set
			{
				ProjectLeftPanelViewModel.#tac #tac = new ProjectLeftPanelViewModel.#tac();
				#tac.#a = this;
				#tac.#b = value;
				if (this.#u != #tac.#b)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107409120));
					this.#u = #tac.#b;
					base.RaisePropertyChanged(#Phc.#3hc(107409120));
					this.#e.#0Pb(new Action(#tac.#Obc));
					base.Services.DialogService.#ZSc(base.DialogService.ActiveWindow, Strings.StringBarSetHasChanged.#z2d() + Environment.NewLine + Strings.StringReviewExistingSectionReinforcement.#z2d());
					this.#c.Renderer.#9f(false, false);
				}
			}
		}

		// Token: 0x170010C4 RID: 4292
		// (get) Token: 0x0600359F RID: 13727 RVA: 0x0002F084 File Offset: 0x0002D284
		// (set) Token: 0x060035A0 RID: 13728 RVA: 0x00108B64 File Offset: 0x00106D64
		public ComboItem<ConfinementType> SelectedConfinementType
		{
			get
			{
				return this.#v;
			}
			set
			{
				if (this.#v != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107352118));
					this.#v = value;
					base.RaisePropertyChanged(#Phc.#3hc(107352118));
					this.#CJb(value.Value);
				}
			}
		}

		// Token: 0x170010C5 RID: 4293
		// (get) Token: 0x060035A1 RID: 13729 RVA: 0x0002F090 File Offset: 0x0002D290
		// (set) Token: 0x060035A2 RID: 13730 RVA: 0x00108BBC File Offset: 0x00106DBC
		public ComboItem<ProblemType> SelectedProblemType
		{
			get
			{
				return this.#w;
			}
			set
			{
				ProjectLeftPanelViewModel.#rAf #rAf = new ProjectLeftPanelViewModel.#rAf();
				#rAf.#a = this;
				#rAf.#b = value;
				if (this.#w != #rAf.#b)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107352085));
					this.#w = #rAf.#b;
					base.RaisePropertyChanged(#Phc.#3hc(107352085));
					this.#e.#0Pb(new Action(#rAf.#Pbc));
					this.#c.Renderer.#9f(false, false);
				}
			}
		}

		// Token: 0x170010C6 RID: 4294
		// (get) Token: 0x060035A3 RID: 13731 RVA: 0x0002F09C File Offset: 0x0002D29C
		// (set) Token: 0x060035A4 RID: 13732 RVA: 0x00108C5C File Offset: 0x00106E5C
		public ComboItem<ConsideredAxis> SelectedConsideredAxis
		{
			get
			{
				return this.#x;
			}
			set
			{
				ProjectLeftPanelViewModel.#sAf #sAf = new ProjectLeftPanelViewModel.#sAf();
				#sAf.#a = this;
				#sAf.#b = value;
				if (this.#x != #sAf.#b)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107352568));
					this.#x = #sAf.#b;
					base.RaisePropertyChanged(#Phc.#3hc(107352568));
					this.#e.#0Pb(new Action(#sAf.#Qbc));
					this.#m.#yl();
				}
			}
		}

		// Token: 0x170010C7 RID: 4295
		// (get) Token: 0x060035A5 RID: 13733 RVA: 0x0002F0A8 File Offset: 0x0002D2A8
		// (set) Token: 0x060035A6 RID: 13734 RVA: 0x00108CF0 File Offset: 0x00106EF0
		public ComboItem<bool> SelectedConsiderSlenderness
		{
			get
			{
				return this.#y;
			}
			set
			{
				ProjectLeftPanelViewModel.#tAf #tAf = new ProjectLeftPanelViewModel.#tAf();
				#tAf.#a = this;
				#tAf.#b = value;
				if (this.#y != #tAf.#b)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107352535));
					this.#y = #tAf.#b;
					base.RaisePropertyChanged(#Phc.#3hc(107352535));
					this.#e.#0Pb(new Action(#tAf.#Sbc));
				}
			}
		}

		// Token: 0x170010C8 RID: 4296
		// (get) Token: 0x060035A7 RID: 13735 RVA: 0x0002F0B4 File Offset: 0x0002D2B4
		// (set) Token: 0x060035A8 RID: 13736 RVA: 0x00108D70 File Offset: 0x00106F70
		public ComboItem<SectionCapacityMethodType> SelectedSectionCapacity
		{
			get
			{
				return this.#z;
			}
			set
			{
				ProjectLeftPanelViewModel.#z9b #z9b = new ProjectLeftPanelViewModel.#z9b();
				#z9b.#a = this;
				#z9b.#b = value;
				if (this.#z != #z9b.#b)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107409091));
					this.#z = #z9b.#b;
					base.RaisePropertyChanged(#Phc.#3hc(107409091));
					this.#e.#0Pb(new Action(#z9b.#Ubc));
				}
			}
		}

		// Token: 0x170010C9 RID: 4297
		// (get) Token: 0x060035A9 RID: 13737 RVA: 0x0002F0C0 File Offset: 0x0002D2C0
		// (set) Token: 0x060035AA RID: 13738 RVA: 0x00108DF0 File Offset: 0x00106FF0
		public string ProjectName
		{
			get
			{
				return this.#n;
			}
			set
			{
				ProjectLeftPanelViewModel.#NUb #NUb = new ProjectLeftPanelViewModel.#NUb();
				#NUb.#a = this;
				#NUb.#b = value;
				if (this.#n != #NUb.#b)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107352498));
					this.#n = #NUb.#b;
					base.RaisePropertyChanged(#Phc.#3hc(107352498));
					this.#e.#0Pb(new Action(#NUb.#Vbc));
				}
			}
		}

		// Token: 0x170010CA RID: 4298
		// (get) Token: 0x060035AB RID: 13739 RVA: 0x0002F0CC File Offset: 0x0002D2CC
		// (set) Token: 0x060035AC RID: 13740 RVA: 0x00108E74 File Offset: 0x00107074
		public string Engineer
		{
			get
			{
				return this.#p;
			}
			set
			{
				ProjectLeftPanelViewModel.#uAf #uAf = new ProjectLeftPanelViewModel.#uAf();
				#uAf.#a = this;
				#uAf.#b = value;
				if (this.#p != #uAf.#b)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107398426));
					this.#p = #uAf.#b;
					base.RaisePropertyChanged(#Phc.#3hc(107398426));
					this.#e.#0Pb(new Action(#uAf.#Wbc));
				}
			}
		}

		// Token: 0x170010CB RID: 4299
		// (get) Token: 0x060035AD RID: 13741 RVA: 0x0002F0D8 File Offset: 0x0002D2D8
		// (set) Token: 0x060035AE RID: 13742 RVA: 0x00108EF8 File Offset: 0x001070F8
		public string ColumnId
		{
			get
			{
				return this.#o;
			}
			set
			{
				ProjectLeftPanelViewModel.#vAf #vAf = new ProjectLeftPanelViewModel.#vAf();
				#vAf.#a = this;
				#vAf.#b = value;
				if (this.#o != #vAf.#b)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107398407));
					this.#o = #vAf.#b;
					base.RaisePropertyChanged(#Phc.#3hc(107398407));
					this.#e.#0Pb(new Action(#vAf.#Xbc));
				}
			}
		}

		// Token: 0x060035AF RID: 13743 RVA: 0x0002F0E4 File Offset: 0x0002D2E4
		public void #0kb()
		{
			this.#c.MouseAndKeyboard.#F2c(base.View, true);
		}

		// Token: 0x060035B0 RID: 13744 RVA: 0x00108F7C File Offset: 0x0010717C
		public void #5b()
		{
			IModelEditorViewport modelEditorViewport = this.#c.ViewportsManager.ActiveViewport as IModelEditorViewport;
			if (modelEditorViewport != null)
			{
				modelEditorViewport.Editor.EmptyTextureCache();
				modelEditorViewport.Renderer.#dg();
			}
		}

		// Token: 0x060035B1 RID: 13745 RVA: 0x0002F109 File Offset: 0x0002D309
		private void #wJb(object #Ge, #7V #He)
		{
			this.#Sgb();
		}

		// Token: 0x060035B2 RID: 13746 RVA: 0x0002F109 File Offset: 0x0002D309
		private void #EO(object #Ge, EventArgs #He)
		{
			this.#Sgb();
		}

		// Token: 0x060035B3 RID: 13747 RVA: 0x0002F109 File Offset: 0x0002D309
		private void #owb(object #Ge, EventArgs #He)
		{
			this.#Sgb();
		}

		// Token: 0x060035B4 RID: 13748 RVA: 0x00108FC4 File Offset: 0x001071C4
		private void #5w()
		{
			IEnumerable<ComboItem<DesignCodes>> items = this.#xJb<DesignCodes>(this.#i.AvailableDesignCodes);
			IEnumerable<ComboItem<UnitSystem>> items2 = this.#xJb<UnitSystem>(this.#i.AvailableUnitSystems);
			IEnumerable<ComboItem<BarGroupType>> items3 = this.#xJb<BarGroupType>(this.#i.AvailableBarGroupTypes);
			IEnumerable<ComboItem<ConfinementType>> items4 = this.#xJb<ConfinementType>(this.#i.AvailableConfinementTypes);
			IEnumerable<ComboItem<ProblemType>> items5 = this.#xJb<ProblemType>(this.#i.AvailableProblemTypes);
			IEnumerable<ComboItem<ConsideredAxis>> items6 = this.#xJb<ConsideredAxis>(this.#i.AvailableConsideredAxes);
			IEnumerable<ComboItem<bool>> items7 = this.#xJb<bool>(this.#i.YesNo);
			IEnumerable<ComboItem<SectionCapacityMethodType>> items8 = this.#xJb<SectionCapacityMethodType>(this.#i.AvailableSectionCapacity);
			this.DesignCodes.AddRange(items);
			this.UnitSystems.AddRange(items2);
			this.BarGroupTypes.AddRange(items3);
			this.ConfinementTypes.AddRange(items4);
			this.ProblemTypes.AddRange(items5);
			this.ConsideredAxes.AddRange(items6);
			this.ConsiderSlendernessOptions.AddRange(items7);
			this.SectionCapacity.AddRange(items8);
		}

		// Token: 0x060035B5 RID: 13749 RVA: 0x0002F119 File Offset: 0x0002D319
		private IEnumerable<ComboItem<#Fu>> #xJb<#Fu>(IDictionary<#Fu, string> #yJb)
		{
			return #yJb.Select(new Func<KeyValuePair<!!0, string>, ComboItem<!!0>>(ProjectLeftPanelViewModel.<>c__110<!!0>.<>9.#W0h));
		}

		// Token: 0x060035B6 RID: 13750 RVA: 0x001090E8 File Offset: 0x001072E8
		private ComboItem<#Fu> #zJb<#Fu>(IEnumerable<ComboItem<#Fu>> #Ic, Func<ColumnModel, #Fu> #AJb)
		{
			ProjectLeftPanelViewModel<#Fu>.#DWb #DWb = new ProjectLeftPanelViewModel<!!0>.#DWb();
			#DWb.#a = #AJb(this.#a.Model);
			return #Ic.FirstOrDefault(new Func<ComboItem<!!0>, bool>(#DWb.#0bc));
		}

		// Token: 0x060035B7 RID: 13751 RVA: 0x00109130 File Offset: 0x00107330
		private void #BJb(UnitSystem #Qg)
		{
			try
			{
				if (this.#b.#SP(#Qg))
				{
					this.#h.#BV();
					this.#d.#sO();
				}
			}
			catch (Exception #ob)
			{
				this.#c.ErrorsHandler.#bzc(Strings.StringCouldNotChangeUnitSystem.#z2d(), #ob, new #3Hc(this.#c.ApplicationInfo.ApplicationName));
			}
		}

		// Token: 0x060035B8 RID: 13752 RVA: 0x001091B4 File Offset: 0x001073B4
		private void #CJb(ConfinementType #DJb)
		{
			ProjectLeftPanelViewModel.#iWd #iWd = new ProjectLeftPanelViewModel.#iWd();
			#iWd.#b = #DJb;
			#iWd.#c = this;
			#iWd.#a = this.#a.Model;
			this.#e.#0Pb(new Action(#iWd.#2bc));
			if (!this.#c.DialogService.#ABf())
			{
				return;
			}
			if (#iWd.#b == ConfinementType.Other)
			{
				LayoutHelper.BeginInvokeOnApplicationThread(new Action(#iWd.#3bc));
			}
		}

		// Token: 0x060035B9 RID: 13753 RVA: 0x0010923C File Offset: 0x0010743C
		private void #Sgb()
		{
			ColumnModel columnModel = this.#a.Model;
			this.#s = this.#zJb<DesignCodes>(this.DesignCodes, new Func<ColumnModel, DesignCodes>(ProjectLeftPanelViewModel.<>c.<>9.#X0h));
			this.#t = this.#zJb<UnitSystem>(this.UnitSystems, new Func<ColumnModel, UnitSystem>(ProjectLeftPanelViewModel.<>c.<>9.#Y0h));
			this.#u = this.#zJb<BarGroupType>(this.BarGroupTypes, new Func<ColumnModel, BarGroupType>(ProjectLeftPanelViewModel.<>c.<>9.#Z0h));
			this.#v = this.#zJb<ConfinementType>(this.ConfinementTypes, new Func<ColumnModel, ConfinementType>(ProjectLeftPanelViewModel.<>c.<>9.#00h));
			this.#w = this.#zJb<ProblemType>(this.ProblemTypes, new Func<ColumnModel, ProblemType>(ProjectLeftPanelViewModel.<>c.<>9.#10h));
			this.#x = this.#zJb<ConsideredAxis>(this.ConsideredAxes, new Func<ColumnModel, ConsideredAxis>(ProjectLeftPanelViewModel.<>c.<>9.#20h));
			this.#y = this.#zJb<bool>(this.ConsiderSlendernessOptions, new Func<ColumnModel, bool>(ProjectLeftPanelViewModel.<>c.<>9.#30h));
			this.#z = this.#zJb<SectionCapacityMethodType>(this.SectionCapacity, new Func<ColumnModel, SectionCapacityMethodType>(ProjectLeftPanelViewModel.<>c.<>9.#40h));
			this.#q = columnModel.MaterialProperties.Fcp;
			this.#r = columnModel.MaterialProperties.Fy;
			base.#NH(this.#j, new string[]
			{
				#Phc.#3hc(107412979)
			});
			base.#NH(this.#k, new string[]
			{
				#Phc.#3hc(107408699)
			});
			this.#n = columnModel.ProjectInfo.Project;
			this.#o = columnModel.ProjectInfo.ColumnId;
			this.#p = columnModel.ProjectInfo.Engineer;
			this.RefreshAllProperties();
		}

		// Token: 0x060035BA RID: 13754 RVA: 0x00109498 File Offset: 0x00107698
		private void #EJb(object #Sb)
		{
			if (!base.DialogService.#ABf())
			{
				return;
			}
			if (#Sb is DefinitionType)
			{
				DefinitionType #kx = (DefinitionType)#Sb;
				this.#f.#Mq(#kx);
				return;
			}
			if (!(#Sb is SlendernessPanelType))
			{
				return;
			}
			this.#g.#Mq();
		}

		// Token: 0x04001629 RID: 5673
		private readonly #oW #a;

		// Token: 0x0400162A RID: 5674
		private readonly #1V #b;

		// Token: 0x0400162B RID: 5675
		private readonly IExtendedServices #c;

		// Token: 0x0400162C RID: 5676
		private readonly #zU #d;

		// Token: 0x0400162D RID: 5677
		private readonly IEditorService #e;

		// Token: 0x0400162E RID: 5678
		private readonly #0G #f;

		// Token: 0x0400162F RID: 5679
		private readonly #ht #g;

		// Token: 0x04001630 RID: 5680
		private readonly #UV #h;

		// Token: 0x04001631 RID: 5681
		private readonly #nKe #i;

		// Token: 0x04001632 RID: 5682
		private readonly #ZZ #j;

		// Token: 0x04001633 RID: 5683
		private readonly #0Z #k;

		// Token: 0x04001634 RID: 5684
		private readonly #KW #l;

		// Token: 0x04001635 RID: 5685
		private readonly #mAe #m;

		// Token: 0x04001636 RID: 5686
		private string #n;

		// Token: 0x04001637 RID: 5687
		private string #o;

		// Token: 0x04001638 RID: 5688
		private string #p;

		// Token: 0x04001639 RID: 5689
		private float #q;

		// Token: 0x0400163A RID: 5690
		private float #r;

		// Token: 0x0400163B RID: 5691
		private ComboItem<DesignCodes> #s;

		// Token: 0x0400163C RID: 5692
		private ComboItem<UnitSystem> #t;

		// Token: 0x0400163D RID: 5693
		private ComboItem<BarGroupType> #u;

		// Token: 0x0400163E RID: 5694
		private ComboItem<ConfinementType> #v;

		// Token: 0x0400163F RID: 5695
		private ComboItem<ProblemType> #w;

		// Token: 0x04001640 RID: 5696
		private ComboItem<ConsideredAxis> #x;

		// Token: 0x04001641 RID: 5697
		private ComboItem<bool> #y;

		// Token: 0x04001642 RID: 5698
		private ComboItem<SectionCapacityMethodType> #z;

		// Token: 0x04001643 RID: 5699
		[CompilerGenerated]
		private readonly #bHb #A;

		// Token: 0x04001644 RID: 5700
		[CompilerGenerated]
		private readonly DelegateCommand #B;

		// Token: 0x04001645 RID: 5701
		[CompilerGenerated]
		private readonly RadObservableCollection<ComboItem<DesignCodes>> #C = new RadObservableCollection<ComboItem<DesignCodes>>();

		// Token: 0x04001646 RID: 5702
		[CompilerGenerated]
		private readonly RadObservableCollection<ComboItem<UnitSystem>> #D = new RadObservableCollection<ComboItem<UnitSystem>>();

		// Token: 0x04001647 RID: 5703
		[CompilerGenerated]
		private readonly RadObservableCollection<ComboItem<BarGroupType>> #E = new RadObservableCollection<ComboItem<BarGroupType>>();

		// Token: 0x04001648 RID: 5704
		[CompilerGenerated]
		private readonly RadObservableCollection<ComboItem<ConfinementType>> #F = new RadObservableCollection<ComboItem<ConfinementType>>();

		// Token: 0x04001649 RID: 5705
		[CompilerGenerated]
		private readonly RadObservableCollection<ComboItem<ProblemType>> #G = new RadObservableCollection<ComboItem<ProblemType>>();

		// Token: 0x0400164A RID: 5706
		[CompilerGenerated]
		private readonly RadObservableCollection<ComboItem<ConsideredAxis>> #H = new RadObservableCollection<ComboItem<ConsideredAxis>>();

		// Token: 0x0400164B RID: 5707
		[CompilerGenerated]
		private readonly RadObservableCollection<ComboItem<bool>> #I = new RadObservableCollection<ComboItem<bool>>();

		// Token: 0x0400164C RID: 5708
		[CompilerGenerated]
		private readonly RadObservableCollection<ComboItem<SectionCapacityMethodType>> #J = new RadObservableCollection<ComboItem<SectionCapacityMethodType>>();

		// Token: 0x02000631 RID: 1585
		[CompilerGenerated]
		private sealed class #uAf
		{
			// Token: 0x060035C9 RID: 13769 RVA: 0x0002F227 File Offset: 0x0002D427
			internal void #Wbc()
			{
				this.#a.#a.Model.ProjectInfo.Engineer = this.#b;
			}

			// Token: 0x04001658 RID: 5720
			public ProjectLeftPanelViewModel #a;

			// Token: 0x04001659 RID: 5721
			public string #b;
		}

		// Token: 0x02000632 RID: 1586
		[CompilerGenerated]
		private sealed class #vAf
		{
			// Token: 0x060035CB RID: 13771 RVA: 0x0002F255 File Offset: 0x0002D455
			internal void #Xbc()
			{
				this.#a.#a.Model.ProjectInfo.ColumnId = this.#b;
			}

			// Token: 0x0400165A RID: 5722
			public ProjectLeftPanelViewModel #a;

			// Token: 0x0400165B RID: 5723
			public string #b;
		}

		// Token: 0x02000633 RID: 1587
		[CompilerGenerated]
		private sealed class #DWb<#Fu>
		{
			// Token: 0x060035CD RID: 13773 RVA: 0x001094F4 File Offset: 0x001076F4
			internal bool #0bc(ComboItem<#Fu> #9o)
			{
				#Fu value = #9o.Value;
				return value.Equals(this.#a);
			}

			// Token: 0x0400165C RID: 5724
			public #Fu #a;
		}

		// Token: 0x02000634 RID: 1588
		[CompilerGenerated]
		private sealed class #iWd
		{
			// Token: 0x060035CF RID: 13775 RVA: 0x0010952C File Offset: 0x0010772C
			internal void #2bc()
			{
				this.#a.Options.ConfinementType = this.#b;
				#1pe.#vpe(this.#a.Options.Unit, this.#a.Options.Code, this.#a.Options.ConfinementType, this.#a.MaterialProperties.Precast, this.#a.ReductionFactors);
			}

			// Token: 0x060035D0 RID: 13776 RVA: 0x0002F283 File Offset: 0x0002D483
			internal void #3bc()
			{
				this.#c.#f.#Mq(DefinitionType.DefineReductionFactors);
			}

			// Token: 0x0400165D RID: 5725
			public ColumnModel #a;

			// Token: 0x0400165E RID: 5726
			public ConfinementType #b;

			// Token: 0x0400165F RID: 5727
			public ProjectLeftPanelViewModel #c;
		}

		// Token: 0x02000635 RID: 1589
		[CompilerGenerated]
		private sealed class #tWb
		{
			// Token: 0x060035D2 RID: 13778 RVA: 0x001095AC File Offset: 0x001077AC
			internal void #tZb()
			{
				this.#a.#a.Model.MaterialProperties.Fcp = this.#b;
				#rLe #rLe = new #rLe();
				#rLe.#5Uh(this.#a.#a.Model.MaterialProperties, this.#a.#a.Model.Options.Unit, this.#a.#a.Model.Options.Code);
			}

			// Token: 0x04001660 RID: 5728
			public ProjectLeftPanelViewModel #a;

			// Token: 0x04001661 RID: 5729
			public float #b;
		}

		// Token: 0x02000636 RID: 1590
		[CompilerGenerated]
		private sealed class #O5b
		{
			// Token: 0x060035D4 RID: 13780 RVA: 0x0010963C File Offset: 0x0010783C
			internal void #BZb()
			{
				this.#a.#a.Model.MaterialProperties.Fy = this.#b;
				#rLe #rLe = new #rLe();
				#rLe.#4Uh(this.#a.#a.Model.MaterialProperties, this.#a.#a.Model.Options.Unit, this.#a.#a.Model.Options.Code);
			}

			// Token: 0x04001662 RID: 5730
			public ProjectLeftPanelViewModel #a;

			// Token: 0x04001663 RID: 5731
			public float #b;
		}

		// Token: 0x02000637 RID: 1591
		[CompilerGenerated]
		private sealed class #QTb
		{
			// Token: 0x060035D6 RID: 13782 RVA: 0x001096CC File Offset: 0x001078CC
			internal void #Nbc()
			{
				this.#a.#a.Model.Options.Code = this.#b.Value;
				ColumnStorageModel columnStorageModel = this.#a.#a.Model.#CY();
				#1pe.#0pe(columnStorageModel);
				this.#a.#a.Model.ReductionFactors.CopyFrom(new ReductionFactors(columnStorageModel.ReductionFactors));
				this.#a.#a.Model.StiffnessReductionFactorPhi = columnStorageModel.StiffnessReductionFactorPhi;
				#rLe #rLe = new #rLe();
				#rLe.#NQ(this.#a.#a.Model.MaterialProperties, this.#a.#a.Model.Options.Unit, this.#a.#a.Model.Options.Code);
			}

			// Token: 0x04001664 RID: 5732
			public ProjectLeftPanelViewModel #a;

			// Token: 0x04001665 RID: 5733
			public ComboItem<DesignCodes> #b;
		}

		// Token: 0x02000638 RID: 1592
		[CompilerGenerated]
		private sealed class #tac
		{
			// Token: 0x060035D8 RID: 13784 RVA: 0x0002F29E File Offset: 0x0002D49E
			internal void #Obc()
			{
				BarGroupChangeHelper.#UF(this.#a.#c.Project.Model, this.#b.Value);
			}

			// Token: 0x04001666 RID: 5734
			public ProjectLeftPanelViewModel #a;

			// Token: 0x04001667 RID: 5735
			public ComboItem<BarGroupType> #b;
		}

		// Token: 0x02000639 RID: 1593
		[CompilerGenerated]
		private sealed class #rAf
		{
			// Token: 0x060035DA RID: 13786 RVA: 0x001097D0 File Offset: 0x001079D0
			internal void #Pbc()
			{
				this.#a.#a.Model.Options.ProblemType = this.#b.Value;
				this.#a.#l.#5T();
			}

			// Token: 0x04001668 RID: 5736
			public ProjectLeftPanelViewModel #a;

			// Token: 0x04001669 RID: 5737
			public ComboItem<ProblemType> #b;
		}

		// Token: 0x0200063A RID: 1594
		[CompilerGenerated]
		private sealed class #sAf
		{
			// Token: 0x060035DC RID: 13788 RVA: 0x00109820 File Offset: 0x00107A20
			internal void #Qbc()
			{
				this.#a.#a.Model.Options.ConsideredAxis = this.#b.Value;
				this.#a.#l.#5T();
			}

			// Token: 0x0400166A RID: 5738
			public ProjectLeftPanelViewModel #a;

			// Token: 0x0400166B RID: 5739
			public ComboItem<ConsideredAxis> #b;
		}

		// Token: 0x0200063B RID: 1595
		[CompilerGenerated]
		private sealed class #tAf
		{
			// Token: 0x060035DE RID: 13790 RVA: 0x00109870 File Offset: 0x00107A70
			internal void #Sbc()
			{
				this.#a.#a.Model.Options.ConsiderSlenderness = this.#b.Value;
				this.#a.#l.#5T();
			}

			// Token: 0x0400166C RID: 5740
			public ProjectLeftPanelViewModel #a;

			// Token: 0x0400166D RID: 5741
			public ComboItem<bool> #b;
		}

		// Token: 0x0200063C RID: 1596
		[CompilerGenerated]
		private sealed class #z9b
		{
			// Token: 0x060035E0 RID: 13792 RVA: 0x0002F2D2 File Offset: 0x0002D4D2
			internal void #Ubc()
			{
				this.#a.#a.Model.Options.SectionCapacityMethod = this.#b.Value;
			}

			// Token: 0x0400166E RID: 5742
			public ProjectLeftPanelViewModel #a;

			// Token: 0x0400166F RID: 5743
			public ComboItem<SectionCapacityMethodType> #b;
		}

		// Token: 0x0200063D RID: 1597
		[CompilerGenerated]
		private sealed class #NUb
		{
			// Token: 0x060035E2 RID: 13794 RVA: 0x0002F305 File Offset: 0x0002D505
			internal void #Vbc()
			{
				this.#a.#a.Model.ProjectInfo.Project = this.#b;
			}

			// Token: 0x04001670 RID: 5744
			public ProjectLeftPanelViewModel #a;

			// Token: 0x04001671 RID: 5745
			public string #b;
		}
	}
}
