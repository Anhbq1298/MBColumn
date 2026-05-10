using System;
using System.IO;
using System.Runtime.CompilerServices;
using #0q;
using #1b;
using #3wb;
using #3yb;
using #45d;
using #4Th;
using #58e;
using #6re;
using #6s;
using #6yb;
using #7hc;
using #8Cc;
using #9I;
using #aAb;
using #ABb;
using #aHb;
using #APb;
using #AUi;
using #Bc;
using #bCc;
using #BF;
using #bJb;
using #BTd;
using #BZ;
using #cc;
using #coe;
using #cwb;
using #cZ;
using #Eb;
using #eR;
using #eSh;
using #eU;
using #EZ;
using #ezc;
using #FTd;
using #Gb;
using #gCc;
using #hc;
using #hg;
using #HI;
using #ID;
using #IDc;
using #IJb;
using #IW;
using #J6d;
using #jZ;
using #kB;
using #LFb;
using #LQc;
using #Lx;
using #lzb;
using #Mb;
using #Mbb;
using #mKd;
using #Mn;
using #nc;
using #NDb;
using #nib;
using #oKe;
using #OT;
using #Ot;
using #Oze;
using #pc;
using #pQb;
using #Pxb;
using #qJ;
using #qPb;
using #QQ;
using #qr;
using #QZ;
using #qzb;
using #RJb;
using #RY;
using #ryb;
using #S9;
using #sg;
using #sGb;
using #sUd;
using #Swb;
using #tF;
using #tFb;
using #tW;
using #Uwb;
using #v1c;
using #vW;
using #WB;
using #wD;
using #WG;
using #Wl;
using #WQ;
using #wRb;
using #WY;
using #x5d;
using #xBe;
using #Xc;
using #Xx;
using #xZ;
using #yUi;
using #YZ;
using #Z;
using #Zb;
using #ZPb;
using #zW;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams.ImportExport;
using StructurePoint.CoreAssets.AppManager.Column.Storage;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.Column.Core.Core.Diagnostics;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.GUI.Framework.IO;
using StructurePoint.CoreAssets.GUI.Framework.Services;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.Logger;
using StructurePoint.CoreAssets.Storage.File.Settings;
using StructurePoint.Products.Column.BatchExecution;
using StructurePoint.Products.Column.BatchExecution.Execution;
using StructurePoint.Products.Column.CommandLine;
using StructurePoint.Products.Column.Core.API;
using StructurePoint.Products.Column.Editor.Common;
using StructurePoint.Products.Column.Editor.Core;
using StructurePoint.Products.Column.Editor.Diagrams;
using StructurePoint.Products.Column.Editor.Project;
using StructurePoint.Products.Column.Editor.Section;
using StructurePoint.Products.Column.Editor.Section.Common;
using StructurePoint.Products.Column.Editor.Section.Design;
using StructurePoint.Products.Column.Editor.Section.Investigation;
using StructurePoint.Products.Column.Editor.Section.Irregular.Tools.Reinforcement;
using StructurePoint.Products.Column.Editor.Section.Irregular.Tools.Select;
using StructurePoint.Products.Column.Editor.Section.Irregular.Tools.Select.Core;
using StructurePoint.Products.Column.Editor.Section.Irregular.Tools.Shapes;
using StructurePoint.Products.Column.Editor.Section.Irregular.Views;
using StructurePoint.Products.Column.Editor.Section.Templates;
using StructurePoint.Products.Column.Editor.Section.Templates.ViewModels;
using StructurePoint.Products.Column.Editor.Section.Templates.Views;
using StructurePoint.Products.Column.FailureSurface;
using StructurePoint.Products.Column.FailureSurface.ViewModels;
using StructurePoint.Products.Column.FailureSurface.ViewModels.LeftPanel;
using StructurePoint.Products.Column.FailureSurface.Views;
using StructurePoint.Products.Column.Model.Validation.API.Definitions;
using StructurePoint.Products.Column.Model.Validation.API.Slenderness;
using StructurePoint.Products.Column.Model.Validation.Definitions;
using StructurePoint.Products.Column.Model.Validation.Loads;
using StructurePoint.Products.Column.Services;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.Services.API.Section;
using StructurePoint.Products.Column.Services.API.Slenderness;
using StructurePoint.Products.Column.Services.Definitions;
using StructurePoint.Products.Column.Services.Loads;
using StructurePoint.Products.Column.Services.Section;
using StructurePoint.Products.Column.ViewModels;
using StructurePoint.Products.Column.ViewModels.Definitions.Modules;
using StructurePoint.Products.Column.ViewModels.Etabs;
using StructurePoint.Products.Column.ViewModels.Items;
using StructurePoint.Products.Column.ViewModels.Loads;
using StructurePoint.Products.Column.ViewModels.Loads.Modules;
using StructurePoint.Products.Column.ViewModels.Reporting;
using StructurePoint.Products.Column.ViewModels.Settings;
using StructurePoint.Products.Column.ViewModels.Slenderness.Modules;
using StructurePoint.Products.Column.ViewModels.Solver;
using StructurePoint.Products.Column.ViewModels.StatusBar;
using StructurePoint.Products.Column.Viewports;
using StructurePoint.Products.Column.Views;
using StructurePoint.Products.Column.Views.API.Definitions;
using StructurePoint.Products.Column.Views.Definitions;
using StructurePoint.Products.Column.Views.Loads;
using StructurePoint.Products.Column.Views.Settings;
using StructurePoint.Products.Column.Views.Slenderness;
using StructurePoint.Products.Column.Views.Solver;
using StructurePoint.Products.Column.Views.StatusBar;

namespace #wQb
{
	// Token: 0x020006BC RID: 1724
	internal sealed class #SQb : DependencyResolverBase
	{
		// Token: 0x06003936 RID: 14646 RVA: 0x00111544 File Offset: 0x0010F744
		public void #eb(bool #xQb = false)
		{
			this.#yQb(#xQb);
			this.#zQb();
			this.#BQb();
			this.#AQb();
			this.#CQb();
			this.#LQb();
			this.#MQb();
			this.#NQb();
			this.#OQb();
			#Llf.#d.#hb(base.Resolve<#rW>());
		}

		// Token: 0x06003937 RID: 14647 RVA: 0x001115A4 File Offset: 0x0010F7A4
		private void #yQb(bool #xQb)
		{
			#55d #55d = this.#PQb(#Phc.#3hc(107350736));
			#pJ #pJ = new #pJ(Logger.Instance, #55d, #55d);
			base.RegisterInstance<#yse>(#pJ);
			#55d = this.#PQb(#Phc.#3hc(107350707));
			base.RegisterInstance<ISettingsManager>(new #3N(Logger.Instance, #55d, #55d, #pJ)
			{
				RuntimeSettings = 
				{
					IsCommandlineMode = #xQb
				}
			});
			base.Register<#48e, #5Pb>();
		}

		// Token: 0x06003938 RID: 14648 RVA: 0x0011161C File Offset: 0x0010F81C
		private void #zQb()
		{
			base.Register<#R2c, MouseAndKeyboardService>();
			base.Register<#8Sc, DialogService>();
			base.Register<#v2c, FileSystemService>();
			base.Register<#aCc, #eCc>();
			base.Register<#bDc, #NCc>();
			base.RegisterInstance<ILogger>(Logger.Instance);
			base.Register<#oQb, #sQb>();
			base.Register<#oW, #aP>();
			base.Register<#rBc, #pBc>();
			base.Register<#5Ic, #LSc>();
			base.Register<ICommandFactory, DefaultCommandFactory>();
			base.Register<#fTc, #gTc>();
			base.Register<#9V, #RP>();
			base.Register<#zU, GuiController>();
			base.Register<#0V, SnappingCache>();
			base.Register<#1V, #TP>();
			base.Register<#wU, ColumnCommandsManager>();
			base.Register<#nKe, #pKe>();
			base.Register<#UV, #nW>();
			base.Register<#xAc, #UJ>();
			base.Register<#JI, RecentProjectsManager>();
			base.Register<#XV, #HO>();
			base.Register<#vU, #6K>();
			base.Register<#iW, #WP>();
			base.Register<#Ioe, StorageProvider>();
			base.Register<#xU, DefaultProjectProvider>();
			base.Register<IEditorService, #4Pb>();
			base.RegisterInstance<#yU>(new #gO(#Phc.#3hc(107403073)));
			base.Register<#Gd, ViewportsRenderer>();
			base.Register<#jg, ViewportsManager>();
			base.Register<#dLb, EditorContextMenu>();
			base.Register<#hLb, #uLb>();
			base.Register<#sPb, #wPb>();
			base.RegisterView<#pPb, PropertiesLeftPanelView>();
			base.RegisterView<#9Gb, CapacityRatioInfoView>();
			base.Register<#bHb, CapacityRatioInfoViewModel>();
			base.Register<#LJ, ModelValidationService>();
			base.Register<#ud, #Wc>();
			base.Register<#vd, #td>();
			base.Register<#dU, #uU>();
			base.Register<ICoreServices, #AL>();
			base.Register<IExtendedServices, #aL>();
			base.Register<#XWi, #YWi>();
			base.Register<#UUi, ProjectExecutor>();
			base.Register<#0Ui, #1Ui>();
			base.Register<#bUi, CommandlineHandler>();
			base.Register<#xUi, BatchOrganizer>();
		}

		// Token: 0x06003939 RID: 14649 RVA: 0x00111778 File Offset: 0x0010F978
		private void #AQb()
		{
			base.Register<#II, #9i>();
			base.Register<#KI, #qk>();
			base.Register<#LI, #Tk>();
			base.Register<#MI, #jl>();
			base.Register<#NI, #Gj>();
			base.RegisterView<#eLb, EditorLeftPanelView>();
			base.Register<#8I, SolverWindowViewModel>();
			base.Register<#GI, DxfImportWindowViewModel>();
			base.Register<#Ln, BatchProcessorViewModel>();
			base.RegisterView<#Lb, BatchProcessorWindow>();
		}

		// Token: 0x0600393A RID: 14650 RVA: 0x001117D0 File Offset: 0x0010F9D0
		private void #BQb()
		{
			base.RegisterViewResolve<#6b>(new Func<#6b>(this.#RQb));
			base.RegisterView<#8b, RibbonView>();
			base.RegisterView<#9b, StartPageView>();
			base.RegisterView<#ac, StatusBarView>();
			base.RegisterView<#7b, AboutWindow>();
			base.RegisterView<#mc, SolverWindowView>();
			base.Register<#gg, ViewportOverlayFactory>();
			base.RegisterView<#0b, DxfImportWindowView>();
		}

		// Token: 0x0600393B RID: 14651 RVA: 0x00111828 File Offset: 0x0010FA28
		private void #CQb()
		{
			base.Register<#BLb, #9Kb>();
			base.Register<#AWh, #BWh>();
			this.#DQb();
			this.#EQb();
			this.#FQb();
			this.#HQb();
			this.#IQb();
			this.#JQb();
			this.#KQb();
		}

		// Token: 0x0600393C RID: 14652 RVA: 0x00111878 File Offset: 0x0010FA78
		private void #DQb()
		{
			base.Register<#BPb, #HJb>();
			base.RegisterView<#CPb, DiagramsLeftPanelView>();
			base.Register<#DPb, #LJb>();
			base.Register<#yBe, DiagramExporter>();
			base.Register<#zBe, DiagramImporter>();
			base.Register<#vbb, DiagramsManager>();
			base.Register<#tbb, #R9>();
			base.Register<#mib, LeftPanelViewModel>();
			base.RegisterView<ILeftPanelView, LeftPanelView>();
			base.Register<#Xgb, #Igb>();
			base.RegisterView<IFilterOptionsView, FilterOptionsView>();
			base.Register<#0gb, LoadPointDetailsViewModel>();
			base.RegisterView<ILoadPointDetailsWindow, LoadPointDetailsWindow>();
			base.Register<#Vgb, #9eb>();
			base.RegisterView<IDisplayOptionsWindow, DisplayOptionsWindow>();
			base.Register<#zJ, #CJ>();
			base.RegisterView<ILeftPanelToolbarView, LeftPanelToolbarView>();
			base.Register<#mAe, SuperImposeContext>();
			base.Register<#aJ, #vq>();
			base.Register<#sib, #ujb>();
			base.RegisterView<ISuperImposeView, SuperImposeView>();
		}

		// Token: 0x0600393D RID: 14653 RVA: 0x00031B28 File Offset: 0x0002FD28
		private void #EQb()
		{
			base.Register<#KPb, #aJb>();
			base.RegisterView<#LPb, ProjectLeftPanelView>();
			base.Register<#MPb, ProjectLeftPanelViewModel>();
			base.Register<#VPb, #dJb>();
		}

		// Token: 0x0600393E RID: 14654 RVA: 0x00111924 File Offset: 0x0010FB24
		private void #FQb()
		{
			base.Register<#SPb, #bwb>();
			base.RegisterView<#TPb, SectionLeftPanelView>();
			base.Register<#UPb, #Fwb>();
			base.RegisterView<#JPb, RectangularSectionInvView>();
			base.Register<#QPb, RectangularSectionInvViewModel>();
			base.RegisterView<#EPb, CircularSectionInvView>();
			base.Register<#OPb, CircularSectionInvViewModel>();
			base.Register<#FPb, #rGb>();
			base.Register<#zPb, #9Ib>();
			base.Register<#OZ, #VY>();
			base.Register<#NZ, #5Y>();
			base.Register<#JZ, #1Y>();
			base.Register<#KZ, #2Y>();
			base.Register<IReinforcementBarsService, #dR>();
			base.Register<#AW, SectionImportService>();
			base.Register<#yW, #EW>();
			base.Register<#DW, SendToIrregularSectionService>();
			base.RegisterView<#HPb, RectangularSectionDesView>();
			base.Register<#PPb, RectangularSectionDesViewModel>();
			base.RegisterView<#GPb, CircularSectionDesView>();
			base.Register<#IPb, CircularSectionDesViewModel>();
			base.Register<#MZ, #4Y>();
			base.Register<#LZ, #3Y>();
			base.Register<#IZ, #YY>();
			base.Register<#DZ, #XY>();
			base.Register<#WPb, #5Hb>();
			base.Register<#ZY, #0Y>();
			base.Register<#fIb, BasicPropertiesViewModel>();
			this.#GQb();
		}

		// Token: 0x0600393F RID: 14655 RVA: 0x00111A00 File Offset: 0x0010FC00
		private void #GQb()
		{
			if (true)
			{
				base.Register<#5yb, #dzb>();
			}
			base.RegisterView<#2yb, IrregularSectionView>();
			base.Register<#qyb, #Dyb>();
			base.RegisterView<#4yb, IrregularToolbarView>();
			base.Register<#Czb, AddRectangleSlabTool>();
			base.RegisterView<#0zb, ShapeParametersView>();
			base.Register<#4zb, #5zb>();
			base.Register<#Uzb, AddSlabCircleByThreePointsTool>();
			base.Register<#Qzb, AddSlabCircleByDiameterTool>();
			base.Register<#NFb, AddSlabCircleByRadiusTool>();
			base.Register<#RFb, AddSlabCircleTool>();
			base.Register<#pzb, AddPolygonSlabTool>();
			base.Register<#Gzb, AddArcSlabTool>();
			base.Register<#XFb, #qDb>();
			base.Register<#3Fb, #NAb>();
			base.Register<#2Fb, MergeSlabsTool>();
			base.Register<#0Fb, #uAb>();
			base.Register<#6Fb, #sBb>();
			base.Register<#4Fb, OffsetSlabsTool>();
			base.Register<#5Fb, SplitSlabsTool>();
			base.Register<#ZFb, #kAb>();
			base.Register<#TFb, RotateModelTool>();
			base.Register<#SFb, MirrorModelTool>();
			base.Register<#1Fb, #xAb>();
			base.Register<#UFb, #zBb>();
			base.Register<#YFb, #LDb>();
			base.Register<#WFb, #lCb>();
			base.Register<#VFb, #WBb>();
			base.Register<#KFb, #kzb>();
			base.Register<#Gm, DraftingSettingsCoordinatesViewModel>();
			base.Register<#Hm, #gm>();
			base.Register<#Im, DraftingSettingsDynamicInputViewModel>();
			base.Register<#Jm, #Dm>();
			base.Register<#Km, #Fm>();
			base.RegisterView<#Fb, DraftingSettingsCoordinatesView>();
			base.RegisterView<#Hb, DraftingSettingsDrawingGridView>();
			base.RegisterView<#Ib, DraftingSettingsDynamicInputView>();
			base.RegisterView<#Jb, DraftingSettingsObjectSnapView>();
			base.RegisterView<#Kb, DraftingSettingsSnapView>();
			base.Register<#oCb, SelectionPropertiesViewModel>();
			base.RegisterView<#mCb, SelectionPropertiesView>();
			base.Register<#FFb, #vEb>();
			base.Register<#xFb, #hEb>();
			base.Register<#sFb, AddArcReinforcementBarTool>();
			base.Register<#CFb, #oEb>();
			base.Register<#wFb, #8Db>();
			base.Register<#DFb, #qEb>();
			base.RegisterView<#GFb, DefaultBarParametersView>();
			base.RegisterView<#yFb, DefaultBarParametersView>();
			base.RegisterView<#AFb, DefaultBarParametersView>();
			base.RegisterView<#uFb, DefaultBarParametersView>();
			base.Register<#EFb, #rEb>();
			base.Register<#zFb, #iEb>();
			base.Register<#BFb, #jEb>();
			base.Register<#vFb, #6Db>();
			base.Register<#nFb, InsertBarsHandler>();
			base.Register<#JFb, BarsParametersContext>();
			base.RegisterView<#MDb, EditIrregularReinforcementBarsView>();
			base.Register<#UDb, EditIrregularReinforcementBarsViewModel>();
			base.Register<#iFb, #lFb>();
			base.RegisterView<#dBb, DefaultBarParametersView>();
			base.Register<#eBb, #fBb>();
		}

		// Token: 0x06003940 RID: 14656 RVA: 0x00111BA4 File Offset: 0x0010FDA4
		private void #HQb()
		{
			base.RegisterView<#Gc, DefinitionsWindow>();
			base.Register<#0G, #sF>();
			base.RegisterView<#gSh, ConcreteMaterialView>();
			base.Register<#OUh, #PUh>();
			base.Register<#MUh, #NUh>();
			base.RegisterView<#dSh, ReinforcingSteelPanelView>();
			base.Register<#HUh, #IUh>();
			base.Register<#JUh, #KUh>();
			base.Register<#sW, #PQ>();
			base.RegisterView<#FTi, ReductionFactorsView>();
			base.Register<#7G, #RG>();
			base.Register<#5G, ReductionFactorsViewModel>();
			base.Register<IReductionFactorsViewModelValidator, #kZ>();
			base.RegisterView<IDesignCriteriaView, DesignCriteriaView>();
			base.Register<#3G, #PG>();
			base.Register<#2G, DesignCriteriaViewModel>();
			base.RegisterView<#fSh, BarSetView>();
			base.Register<#AUh, #BUh>();
			base.Register<#DUh, BarSetViewModel>();
			base.Register<#ZZ, #iZ>();
			base.Register<#0Z, #tZ>();
			base.Register<#XZ, CapacityRatioValidator>();
			base.RegisterView<#Cc, LoadCasesPanelView>();
			base.Register<#YG, #OF>();
			base.Register<#ZG, #NF>();
			base.RegisterView<#Ac, LoadCombinationsPanelView>();
			base.Register<#VG, #AF>();
			base.Register<#XG, LoadCombinationsViewModel>();
			base.Register<#SZ, #eZ>();
			base.Register<IDefinitionsContext, #HRf>();
		}

		// Token: 0x06003941 RID: 14657 RVA: 0x00111C84 File Offset: 0x0010FE84
		private void #IQb()
		{
			base.RegisterView<#ec, SlendernessWindow>();
			base.Register<#ht, #Zq>();
			base.Register<#ft, DesignColumnPanelFactory>();
			base.RegisterView<#dc, ColumnsAboveBelowPanelView>();
			base.Register<#gt, #yr>();
			base.Register<#at, #Pr>();
			base.Register<#7s, TemporaryColumnFactory>();
			base.Register<#et, BeamsPanelFactory>();
			base.Register<IBeamsCalculator, #7Q>();
			base.Register<#5s, TemporaryBeamFactory>();
			base.RegisterView<#bc, FactorsPanelView>();
			base.Register<#it, #zs>();
			base.Register<#dt, #ys>();
			base.Register<#CZ, #UY>();
			base.Register<#wW, #1Q>();
			base.Register<#uW, #VQ>();
		}

		// Token: 0x06003942 RID: 14658 RVA: 0x00111D00 File Offset: 0x0010FF00
		private void #JQb()
		{
			base.RegisterView<#kc, LoadsWindowView>();
			base.Register<#CD, #3Th>();
			base.RegisterView<#ic, FactoredLoadsPanelView>();
			base.Register<#AD, #EC>();
			base.Register<#BD, FactoredLoadsViewModel>();
			base.Register<#PZ, #dZ>();
			base.RegisterView<#gc, AxialLoadsPanelView>();
			base.Register<#xD, #0B>();
			base.Register<#zD, AxialLoadsViewModel>();
			base.Register<#RZ, #bZ>();
			base.RegisterView<#lc, ServiceLoadsPanelView>();
			base.Register<#DD, #WC>();
			base.Register<#ED, ServiceLoadsViewModel>();
			base.Register<#UZ, #gZ>();
			base.Register<#TZ, #fZ>();
			base.Register<#WZ, #hZ>();
			base.Register<#VZ, SustainedFactorValueValidator>();
			base.Register<#vD, ServiceLoadsToFactoredLoadsService>();
			base.Register<#6Th, #7Th>();
			base.Register<#8Th, #9Th>();
			base.RegisterView<#cSh, ControlPointsView>();
			base.Register<#KW, #aU>();
			base.Register<#HW, #NT>();
			base.Register<#JW, ImportLoadsService>();
		}

		// Token: 0x06003943 RID: 14659 RVA: 0x00111DBC File Offset: 0x0010FFBC
		private void #KQb()
		{
			base.RegisterView<#zc, SettingsWindow>();
			base.Register<#Vx, #zx>();
			base.RegisterView<#wc, GeneralOptionsView>();
			base.Register<#Tx, #nw>();
			base.RegisterView<#xc, GeneralReportsView>();
			base.Register<#Sx, #Uw>();
			base.RegisterView<#yc, GeneralStartupDefaultsView>();
			base.Register<#Ux, GeneralStartupDefaultsViewModel>();
			base.RegisterView<#vc, SectionsOptionsView>();
			base.Register<#Rx, #hw>();
			base.RegisterView<#uc, SectionsColorsView>();
			base.Register<#Qx, SectionsColorsViewModel>();
			base.RegisterView<#rc, Diagrams2dOptionsView>();
			base.Register<#Nx, Diagrams2dOptionsViewModel>();
			base.RegisterView<#qc, Diagrams2dAxisView>();
			base.Register<#Mx, Diagrams2dAxisViewModel>();
			base.RegisterView<#oc, Diagrams2dColorsView>();
			base.Register<#Kx, #Nt>();
			base.RegisterView<#tc, Diagrams3dOptionsView>();
			base.Register<#Px, Diagrams3dOptionsViewModel>();
			base.RegisterView<#sc, Diagrams3dColorsView>();
			base.Register<#Ox, Diagrams3dColorsViewModel>();
		}

		// Token: 0x06003944 RID: 14660 RVA: 0x00111E6C File Offset: 0x0011006C
		private void #LQb()
		{
			#wZ.Container = base.Container;
			base.Register<#kVh, #lVh>();
			base.Register<#mVh, #nVh>();
			base.Register<IDesignCriteriaViewModelValidator, DesignCriteriaFormValidator>();
			base.Register<#2Z, #qZ>();
			base.Register<#3Z, #rZ>();
			base.Register<IReinforcementRatiosValidator, #lZ>();
			base.Register<#1Z, #pZ>();
			base.Register<#AZ, #TY>();
			base.Register<ISlendernessColumnsAboveBelowValidator, #SY>();
			base.Register<ISlendernessBeamsValidator, #QY>();
		}

		// Token: 0x06003945 RID: 14661 RVA: 0x00111ECC File Offset: 0x001100CC
		private void #MQb()
		{
			base.Register<#nB, #gB>();
			base.Register<#lB, #QA>();
			base.Register<#rW, #MQ>();
			base.Register<#jB, ColumnReportAvailabilityChecker>();
			base.RegisterInstance<#uUd>(#KTd.#ul(true, true));
			base.Register<#vUd, #BKd>();
			base.Register<#qW, #HQ>();
			base.Register<#tUd, #ETd>();
			base.Register<#ATd, ReportFontSizeInfoProvider>();
		}

		// Token: 0x06003946 RID: 14662 RVA: 0x00031B4E File Offset: 0x0002FD4E
		private void #NQb()
		{
			base.RegisterView<#Twb, TemplateLeftPanelView>();
			base.Register<#5wb, #Axb>();
			base.Register<#2wb, SectionTemplateService>();
			base.RegisterView<#Vwb, TemplateSelectorWindow>();
			base.Register<#7wb, TemplateSelectorViewModel>();
			base.RegisterView<#Wwb, TemplatesToolbarView>();
			base.Register<#Oxb, #Txb>();
			base.Register<#Rwb, TemplateChangeService>();
		}

		// Token: 0x06003947 RID: 14663 RVA: 0x00031B8C File Offset: 0x0002FD8C
		private void #OQb()
		{
			base.RegisterView<#Db, EtabsImportWindow>();
			base.Register<#oF, EtabsImportWindowViewModel>();
			base.Register<#pF, EtabsService>();
			base.Register<#nF, #HD>();
		}

		// Token: 0x06003948 RID: 14664 RVA: 0x00111F24 File Offset: 0x00110124
		private #55d #PQb(string #QQb)
		{
			#55d result;
			try
			{
				string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), #Phc.#3hc(107403126), #Phc.#3hc(107405338));
				#35d cacheProvider = new #65d();
				#Z6d.#k2c(text);
				result = new XMLSettingsProvider(Path.Combine(text, #QQb), cacheProvider);
			}
			catch (#w5d exception)
			{
				LastChanceLogger.Instance.Log(LoggingLevel.Error, exception);
				result = new #SQb.#9cc();
			}
			return result;
		}

		// Token: 0x0600394A RID: 14666 RVA: 0x00031BB2 File Offset: 0x0002FDB2
		[CompilerGenerated]
		private #6b #RQb()
		{
			return new MainWindow(base.Resolve<ISettingsManager>());
		}

		// Token: 0x0400180D RID: 6157
		private const string #a = "settings.xml";

		// Token: 0x0400180E RID: 6158
		private const string #b = "reporter.settings.xml";

		// Token: 0x020006BD RID: 1725
		private sealed class #9cc : #55d
		{
			// Token: 0x0600394B RID: 14667 RVA: 0x00031BCB File Offset: 0x0002FDCB
			public bool #5cc(string #6cc, string #7cc, out string #f)
			{
				#f = #7cc;
				return false;
			}

			// Token: 0x0600394C RID: 14668 RVA: 0x00009E6A File Offset: 0x0000806A
			public void #zl(string #6cc, string #8cc)
			{
			}
		}
	}
}
