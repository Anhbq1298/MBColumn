using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using #12e;
using #3Rd;
using #6re;
using #7hc;
using #eU;
using #owe;
using #sUd;
using #Wse;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Documents;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Model;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Presentation.Navigation;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Presentation.ViewModels;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace StructurePoint.Products.Column.ViewModels.Reporting
{
	// Token: 0x020001B3 RID: 435
	internal sealed class ColumnReportExplorerViewModel : ReportExplorerViewModelBase
	{
		// Token: 0x06000EB1 RID: 3761 RVA: 0x000A2AD4 File Offset: 0x000A0CD4
		public ColumnReportExplorerViewModel(#uUd featuresDescriptor, #tUd exceptionHandler, #rUd applicationContext, #yse settingsManager, #qW designEngineService) : base(featuresDescriptor, exceptionHandler, applicationContext, settingsManager)
		{
			this.#a = applicationContext;
			this.DesignEngineService = designEngineService;
			this.#e = settingsManager;
			this.#f = new ReportContentVisibilityOption(this.Options.CoverAndContents, #Phc.#3hc(107409021), null, true);
			this.#g = new ReportContentVisibilityOption(this.Options.Cover, Localization.StringCover, this.CoverAndContents, false);
			this.#h = new ReportContentVisibilityOption(this.Options.TableOfContents, Localization.StringContents, this.CoverAndContents, false);
			this.#i = new ReportContentVisibilityOption(this.Options.Input, Localization.StringInput, null, true);
			this.#j = new ReportContentVisibilityOption(this.Options.GeneralInformation, Localization.StringGeneralInformation, this.Input, false);
			this.#k = new ReportContentVisibilityOption(this.Options.MaterialProperties, Localization.StringMaterialProperties, this.Input, true);
			this.#l = new ReportContentVisibilityOption(this.Options.MaterialPropertiesConcrete, Localization.StringConcrete, this.MaterialProperties, false);
			this.#m = new ReportContentVisibilityOption(this.Options.MaterialPropertiesSteel, Localization.StringSteel, this.MaterialProperties, false);
			this.#n = new ReportContentVisibilityOption(this.Options.Section, Localization.StringSection, this.Input, true);
			this.#o = new ReportContentVisibilityOption(this.Options.SectionShapeAndProperties, Localization.StringShapeAndProperties, this.Section, false);
			this.#p = new ReportContentVisibilityOption(this.Options.SectionFigure, Localization.StringSectionFigure, this.Section, false);
			this.#q = new ReportContentVisibilityOption(this.Options.SectionSolids, Strings.StringSolids, this.Section, true);
			this.#r = new ReportContentVisibilityOption(this.Options.SectionOpenings, Strings.StringOpenings, this.Section, true);
			this.#s = new ReportContentVisibilityOption(this.Options.Reinforcement, Localization.StringReinforcement, this.Input, true);
			this.#t = new ReportContentVisibilityOption(this.Options.ReinforcementBarSet, Localization.StringBarSet, this.Reinforcement, false);
			this.#u = new ReportContentVisibilityOption(this.Options.ReinforcementDesignCriteria, Localization.StringDesignCriteria, this.Reinforcement, false);
			this.#v = new ReportContentVisibilityOption(this.Options.ReinforcementConfinementAndFactors, Localization.StringConfinementAndFactors, this.Reinforcement, false);
			this.#w = new ReportContentVisibilityOption(this.Options.ReinforcementProperties, Localization.Arrangement, this.Reinforcement, false);
			this.#x = new ReportContentVisibilityOption(this.Options.ReinforcementBarsProvided, Localization.StringBarsProvided, this.Reinforcement, false);
			this.#y = new ReportContentVisibilityOption(this.Options.Loading, Localization.StringLoading, this.Input, true);
			this.#z = new ReportContentVisibilityOption(this.Options.LoadingLoadCases, Localization.StringLoadCases, this.Loading, false);
			this.#A = new ReportContentVisibilityOption(this.Options.LoadingLoadCombinations, Localization.StringLoadCombinations, this.Loading, false);
			this.#B = new ReportContentVisibilityOption(this.Options.LoadingServiceLoads, Localization.StringServiceLoads, this.Loading, false);
			this.#C = new ReportContentVisibilityOption(this.Options.Slenderness, Localization.StringSlenderness, this.Input, true);
			this.#D = new ReportContentVisibilityOption(this.Options.SlendernessSwayCriteria, Localization.StringSwayCriteria, this.Slenderness, false);
			this.#E = new ReportContentVisibilityOption(this.Options.SlendernessColumns, Localization.StringColumns, this.Slenderness, false);
			this.#F = new ReportContentVisibilityOption(this.Options.SlendernessXBeams, Localization.StringX_Beams, this.Slenderness, false);
			this.#G = new ReportContentVisibilityOption(this.Options.SlendernessYBeams, Localization.StringY_Beams, this.Slenderness, false);
			this.#H = new ReportContentVisibilityOption(this.Options.Results, Localization.StringResultsOutputs, null, true);
			this.#I = new ReportContentVisibilityOption(this.Options.MomentMagnification, Localization.StringMomentMagnification, this.Results, true);
			this.#J = new ReportContentVisibilityOption(this.Options.MomentGeneralParameters, Localization.StringGeneralParameters, this.MomentMagnification, false);
			this.#K = new ReportContentVisibilityOption(this.Options.MomentEffectiveLengthFactors, Localization.StringEffectiveLengthFactors, this.MomentMagnification, false);
			this.#L = new ReportContentVisibilityOption(this.Options.MomentMagnificationFactorsX, Localization.StringMagnificationFactorsXAxis.#D2d(new object[]
			{
				#Phc.#3hc(107408964)
			}), this.MomentMagnification, false);
			this.#M = new ReportContentVisibilityOption(this.Options.MomentMagnificationFactorsY, Localization.StringMagnificationFactorsXAxis.#D2d(new object[]
			{
				#Phc.#3hc(107408991)
			}), this.MomentMagnification, false);
			this.#N = new ReportContentVisibilityOption(this.Options.FactoredMoments, Localization.StringFactoredMoments, this.Results, true);
			this.#O = new ReportContentVisibilityOption(this.Options.FactoredMomentsXAxis, Localization.StringXAxis.ToLower(CultureInfo.CurrentCulture).#D2d(new object[]
			{
				#Phc.#3hc(107408964)
			}), this.FactoredMoments, false);
			this.#P = new ReportContentVisibilityOption(this.Options.FactoredMomentsYAxis, Localization.StringYAxis, this.FactoredMoments, false);
			this.#Q = new ReportContentVisibilityOption(this.Options.ControlPoints, Strings.StringControlPoints, this.Results, false);
			this.#R = new ReportContentVisibilityOption(this.Options.LoadsAndCapacities, Localization.StringLoadsAndCapacities, this.Results, false);
			this.#S = new ReportContentVisibilityOption(this.Options.FactoredLoadsAndMomentsWithCorrespondingCapacityRatios, Localization.StringLoadsAndCapacityRatios, this.Results, false);
			this.#T = new ReportContentVisibilityOption(this.Options.Screenshots, Localization.StringDiagrams, this.Results, true);
			base.Items.Add(this.CoverAndContents);
			base.Items.Add(this.Input);
			base.Items.Add(this.Results);
			base.#Qab();
			this.#qz();
			this.#a.Options.PropertyChanged += this.#kz;
			this.SettingsManager.PropertyChanged += this.#jz;
			this.#d = this.SettingsManager.ReporterExplorerHideInactiveItems;
			this.LoadsAndCapacities.PropertyChanged += this.#iz;
			this.LoadsAndMomentsWithCapacityRatios.PropertyChanged += this.#iz;
		}

		// Token: 0x17000596 RID: 1430
		// (get) Token: 0x06000EB2 RID: 3762 RVA: 0x0001149F File Offset: 0x0000F69F
		public #uwe Options
		{
			get
			{
				return ((#rW)this.#a).DocumentOptions;
			}
		}

		// Token: 0x17000597 RID: 1431
		// (get) Token: 0x06000EB3 RID: 3763 RVA: 0x000114B9 File Offset: 0x0000F6B9
		public #yse SettingsManager { get; }

		// Token: 0x17000598 RID: 1432
		// (get) Token: 0x06000EB4 RID: 3764 RVA: 0x000114C5 File Offset: 0x0000F6C5
		public override bool HideInactiveItems
		{
			get
			{
				return this.#d;
			}
		}

		// Token: 0x17000599 RID: 1433
		// (get) Token: 0x06000EB5 RID: 3765 RVA: 0x000114D1 File Offset: 0x0000F6D1
		// (set) Token: 0x06000EB6 RID: 3766 RVA: 0x000114EA File Offset: 0x0000F6EA
		public override bool SplitLongTables
		{
			get
			{
				return this.Options.SplitLongTables;
			}
			set
			{
				this.Options.SplitLongTables = value;
			}
		}

		// Token: 0x1700059A RID: 1434
		// (get) Token: 0x06000EB7 RID: 3767 RVA: 0x00011504 File Offset: 0x0000F704
		private ReportContentVisibilityOption CoverAndContents { get; }

		// Token: 0x1700059B RID: 1435
		// (get) Token: 0x06000EB8 RID: 3768 RVA: 0x00011510 File Offset: 0x0000F710
		private ReportContentVisibilityOption Cover { get; }

		// Token: 0x1700059C RID: 1436
		// (get) Token: 0x06000EB9 RID: 3769 RVA: 0x0001151C File Offset: 0x0000F71C
		private ReportContentVisibilityOption TableOfContents { get; }

		// Token: 0x1700059D RID: 1437
		// (get) Token: 0x06000EBA RID: 3770 RVA: 0x00011528 File Offset: 0x0000F728
		private ReportContentVisibilityOption Input { get; }

		// Token: 0x1700059E RID: 1438
		// (get) Token: 0x06000EBB RID: 3771 RVA: 0x00011534 File Offset: 0x0000F734
		private ReportContentVisibilityOption GeneralInformation { get; }

		// Token: 0x1700059F RID: 1439
		// (get) Token: 0x06000EBC RID: 3772 RVA: 0x00011540 File Offset: 0x0000F740
		private ReportContentVisibilityOption MaterialProperties { get; }

		// Token: 0x170005A0 RID: 1440
		// (get) Token: 0x06000EBD RID: 3773 RVA: 0x0001154C File Offset: 0x0000F74C
		private ReportContentVisibilityOption MaterialPropertiesConcrete { get; }

		// Token: 0x170005A1 RID: 1441
		// (get) Token: 0x06000EBE RID: 3774 RVA: 0x00011558 File Offset: 0x0000F758
		private ReportContentVisibilityOption MaterialPropertiesSteel { get; }

		// Token: 0x170005A2 RID: 1442
		// (get) Token: 0x06000EBF RID: 3775 RVA: 0x00011564 File Offset: 0x0000F764
		private ReportContentVisibilityOption Section { get; }

		// Token: 0x170005A3 RID: 1443
		// (get) Token: 0x06000EC0 RID: 3776 RVA: 0x00011570 File Offset: 0x0000F770
		private ReportContentVisibilityOption SectionShapeAndProperties { get; }

		// Token: 0x170005A4 RID: 1444
		// (get) Token: 0x06000EC1 RID: 3777 RVA: 0x0001157C File Offset: 0x0000F77C
		private ReportContentVisibilityOption SectionFigure { get; }

		// Token: 0x170005A5 RID: 1445
		// (get) Token: 0x06000EC2 RID: 3778 RVA: 0x00011588 File Offset: 0x0000F788
		private ReportContentVisibilityOption SectionSolids { get; }

		// Token: 0x170005A6 RID: 1446
		// (get) Token: 0x06000EC3 RID: 3779 RVA: 0x00011594 File Offset: 0x0000F794
		private ReportContentVisibilityOption SectionOpenings { get; }

		// Token: 0x170005A7 RID: 1447
		// (get) Token: 0x06000EC4 RID: 3780 RVA: 0x000115A0 File Offset: 0x0000F7A0
		private ReportContentVisibilityOption Reinforcement { get; }

		// Token: 0x170005A8 RID: 1448
		// (get) Token: 0x06000EC5 RID: 3781 RVA: 0x000115AC File Offset: 0x0000F7AC
		private ReportContentVisibilityOption ReinforcementBarSet { get; }

		// Token: 0x170005A9 RID: 1449
		// (get) Token: 0x06000EC6 RID: 3782 RVA: 0x000115B8 File Offset: 0x0000F7B8
		private ReportContentVisibilityOption ReinforcementDesignCriteria { get; }

		// Token: 0x170005AA RID: 1450
		// (get) Token: 0x06000EC7 RID: 3783 RVA: 0x000115C4 File Offset: 0x0000F7C4
		private ReportContentVisibilityOption ReinforcementConfinementAndFactors { get; }

		// Token: 0x170005AB RID: 1451
		// (get) Token: 0x06000EC8 RID: 3784 RVA: 0x000115D0 File Offset: 0x0000F7D0
		private ReportContentVisibilityOption ReinforcementProperties { get; }

		// Token: 0x170005AC RID: 1452
		// (get) Token: 0x06000EC9 RID: 3785 RVA: 0x000115DC File Offset: 0x0000F7DC
		private ReportContentVisibilityOption ReinforcementBarsProvided { get; }

		// Token: 0x170005AD RID: 1453
		// (get) Token: 0x06000ECA RID: 3786 RVA: 0x000115E8 File Offset: 0x0000F7E8
		private ReportContentVisibilityOption Loading { get; }

		// Token: 0x170005AE RID: 1454
		// (get) Token: 0x06000ECB RID: 3787 RVA: 0x000115F4 File Offset: 0x0000F7F4
		private ReportContentVisibilityOption LoadingLoadCases { get; }

		// Token: 0x170005AF RID: 1455
		// (get) Token: 0x06000ECC RID: 3788 RVA: 0x00011600 File Offset: 0x0000F800
		private ReportContentVisibilityOption LoadingLoadCombinations { get; }

		// Token: 0x170005B0 RID: 1456
		// (get) Token: 0x06000ECD RID: 3789 RVA: 0x0001160C File Offset: 0x0000F80C
		private ReportContentVisibilityOption LoadingServiceLoads { get; }

		// Token: 0x170005B1 RID: 1457
		// (get) Token: 0x06000ECE RID: 3790 RVA: 0x00011618 File Offset: 0x0000F818
		private ReportContentVisibilityOption Slenderness { get; }

		// Token: 0x170005B2 RID: 1458
		// (get) Token: 0x06000ECF RID: 3791 RVA: 0x00011624 File Offset: 0x0000F824
		private ReportContentVisibilityOption SlendernessSwayCriteria { get; }

		// Token: 0x170005B3 RID: 1459
		// (get) Token: 0x06000ED0 RID: 3792 RVA: 0x00011630 File Offset: 0x0000F830
		private ReportContentVisibilityOption SlendernessColumns { get; }

		// Token: 0x170005B4 RID: 1460
		// (get) Token: 0x06000ED1 RID: 3793 RVA: 0x0001163C File Offset: 0x0000F83C
		private ReportContentVisibilityOption SlendernessXBeams { get; }

		// Token: 0x170005B5 RID: 1461
		// (get) Token: 0x06000ED2 RID: 3794 RVA: 0x00011648 File Offset: 0x0000F848
		private ReportContentVisibilityOption SlendernessYBeams { get; }

		// Token: 0x170005B6 RID: 1462
		// (get) Token: 0x06000ED3 RID: 3795 RVA: 0x00011654 File Offset: 0x0000F854
		private ReportContentVisibilityOption Results { get; }

		// Token: 0x170005B7 RID: 1463
		// (get) Token: 0x06000ED4 RID: 3796 RVA: 0x00011660 File Offset: 0x0000F860
		private ReportContentVisibilityOption MomentMagnification { get; }

		// Token: 0x170005B8 RID: 1464
		// (get) Token: 0x06000ED5 RID: 3797 RVA: 0x0001166C File Offset: 0x0000F86C
		private ReportContentVisibilityOption MomentGeneralParameters { get; }

		// Token: 0x170005B9 RID: 1465
		// (get) Token: 0x06000ED6 RID: 3798 RVA: 0x00011678 File Offset: 0x0000F878
		private ReportContentVisibilityOption MomentEffectiveLengthFactors { get; }

		// Token: 0x170005BA RID: 1466
		// (get) Token: 0x06000ED7 RID: 3799 RVA: 0x00011684 File Offset: 0x0000F884
		private ReportContentVisibilityOption MomentMagnificationFactorsX { get; }

		// Token: 0x170005BB RID: 1467
		// (get) Token: 0x06000ED8 RID: 3800 RVA: 0x00011690 File Offset: 0x0000F890
		private ReportContentVisibilityOption MomentMagnificationFactorsY { get; }

		// Token: 0x170005BC RID: 1468
		// (get) Token: 0x06000ED9 RID: 3801 RVA: 0x0001169C File Offset: 0x0000F89C
		private ReportContentVisibilityOption FactoredMoments { get; }

		// Token: 0x170005BD RID: 1469
		// (get) Token: 0x06000EDA RID: 3802 RVA: 0x000116A8 File Offset: 0x0000F8A8
		private ReportContentVisibilityOption FactoredMomentsXAxis { get; }

		// Token: 0x170005BE RID: 1470
		// (get) Token: 0x06000EDB RID: 3803 RVA: 0x000116B4 File Offset: 0x0000F8B4
		private ReportContentVisibilityOption FactoredMomentsYAxis { get; }

		// Token: 0x170005BF RID: 1471
		// (get) Token: 0x06000EDC RID: 3804 RVA: 0x000116C0 File Offset: 0x0000F8C0
		public ReportContentVisibilityOption ControlPoints { get; }

		// Token: 0x170005C0 RID: 1472
		// (get) Token: 0x06000EDD RID: 3805 RVA: 0x000116CC File Offset: 0x0000F8CC
		private ReportContentVisibilityOption LoadsAndCapacities { get; }

		// Token: 0x170005C1 RID: 1473
		// (get) Token: 0x06000EDE RID: 3806 RVA: 0x000116D8 File Offset: 0x0000F8D8
		private ReportContentVisibilityOption LoadsAndMomentsWithCapacityRatios { get; }

		// Token: 0x170005C2 RID: 1474
		// (get) Token: 0x06000EDF RID: 3807 RVA: 0x000116E4 File Offset: 0x0000F8E4
		private ReportContentVisibilityOption Screenshots { get; }

		// Token: 0x170005C3 RID: 1475
		// (get) Token: 0x06000EE0 RID: 3808 RVA: 0x000116F0 File Offset: 0x0000F8F0
		// (set) Token: 0x06000EE1 RID: 3809 RVA: 0x000116FC File Offset: 0x0000F8FC
		public #qW DesignEngineService { get; set; }

		// Token: 0x06000EE2 RID: 3810 RVA: 0x000A3170 File Offset: 0x000A1370
		public void #hz(#lte #Od)
		{
			ColumnReportExplorerViewModel.#ZWb #ZWb = new ColumnReportExplorerViewModel.#ZWb();
			#ZWb.#a = this;
			#ZWb.#b = #Od;
			if (#ZWb.#b == null)
			{
				return;
			}
			this.#b = #ZWb.#b;
			base.IsNavigationEnabled = true;
			base.#9Jd(new Action(#ZWb.#YWb));
			this.#c = #ZWb.#b.GeneralInfo.FileName;
		}

		// Token: 0x06000EE3 RID: 3811 RVA: 0x0001170D File Offset: 0x0000F90D
		private void #iz(object #Ge, PropertyChangedEventArgs #He)
		{
			this.#mz(false);
		}

		// Token: 0x06000EE4 RID: 3812 RVA: 0x000A31E4 File Offset: 0x000A13E4
		private void #jz(object #Ge, PropertyChangedEventArgs #He)
		{
			bool flag = this.SettingsManager.ReporterExplorerHideInactiveItems;
			if (this.#d != flag)
			{
				this.#d = flag;
				base.RaisePropertyChanged<bool>(Expression.Lambda<Func<bool>>(Expression.Property(Expression.Constant(this, typeof(ColumnReportExplorerViewModel)), methodof(ReportExplorerViewModelBase.#zy())), Array.Empty<ParameterExpression>()));
			}
		}

		// Token: 0x06000EE5 RID: 3813 RVA: 0x0001171E File Offset: 0x0000F91E
		private void #kz(object #Ge, PropertyChangedEventArgs #He)
		{
			if (!false)
			{
				this.#pz();
			}
			base.#9Nd(new Action<ReportContentVisibilityOption>(ColumnReportExplorerViewModel.<>c.<>9.#2Wb));
		}

		// Token: 0x06000EE6 RID: 3814 RVA: 0x000A3250 File Offset: 0x000A1450
		private void #lz(#lte #Od)
		{
			base.#Rab();
			this.SectionOpenings.Children.Clear();
			this.SectionSolids.Children.Clear();
			if (#Od.Input.Options.SectionType != SectionType.Irregular && #Od.Input.Options.SectionType != SectionType.IrregularTemplate)
			{
				base.#Qab();
				return;
			}
			List<SectionPolygon> list = #Od.BasicProperties.Polygons.Where(new Func<SectionPolygon, bool>(ColumnReportExplorerViewModel.<>c.<>9.#3Wb)).OrderBy(new Func<SectionPolygon, int>(ColumnReportExplorerViewModel.<>c.<>9.#4Wb)).ToList<SectionPolygon>();
			List<SectionPolygon> list2 = #Od.BasicProperties.Polygons.Where(new Func<SectionPolygon, bool>(ColumnReportExplorerViewModel.<>c.<>9.#5Wb)).OrderBy(new Func<SectionPolygon, int>(ColumnReportExplorerViewModel.<>c.<>9.#6Wb)).ToList<SectionPolygon>();
			for (int i = 0; i < this.Options.SectionOpenings.Children.Count; i++)
			{
				Option option = this.Options.SectionOpenings.Children[i];
				SectionPolygon sectionPolygon = list2[i];
				new ReportContentVisibilityOption(option, sectionPolygon.DisplayId, this.SectionOpenings, false);
			}
			for (int j = 0; j < this.Options.SectionSolids.Children.Count; j++)
			{
				Option option2 = this.Options.SectionSolids.Children[j];
				SectionPolygon sectionPolygon2 = list[j];
				new ReportContentVisibilityOption(option2, sectionPolygon2.DisplayId, this.SectionSolids, false);
			}
			base.#Qab();
		}

		// Token: 0x06000EE7 RID: 3815 RVA: 0x000A3438 File Offset: 0x000A1638
		private void #mz(bool #nz)
		{
			if (!#nz && (base.IsLoadingExplorerConfiguration || !base.IsRaisingEvents))
			{
				return;
			}
			bool flag = this.LoadsAndCapacities.DocumentOption.#ISd() || this.LoadsAndMomentsWithCapacityRatios.DocumentOption.#ISd();
			bool flag2 = !flag || !this.#rz();
			this.#a.Options.IsWordFormatEnabled = flag2;
			this.#a.Options.IsPdfFormatEnabled = flag2;
			this.LoadsAndCapacities.#PQd();
			this.LoadsAndMomentsWithCapacityRatios.#PQd();
			if (!flag2 && this.#a.Options.SelectedFileFormat.#OSd())
			{
				this.#a.Options.SelectedFileFormat = ReportFileFormat.Text;
			}
		}

		// Token: 0x06000EE8 RID: 3816 RVA: 0x000A3510 File Offset: 0x000A1710
		private void #oz(#lte #Od)
		{
			base.#Rab();
			this.Screenshots.Children.Clear();
			if (!#Od.#ite())
			{
				base.#Qab();
				return;
			}
			ReportDiagramsHandler reportDiagramsHandler = new ReportDiagramsHandler();
			reportDiagramsHandler.#sAe(this.Options, #Od, this.SettingsManager, this.DesignEngineService.DesignEngine);
			List<ReporterImage> source = this.Options.Screenshots.Children.OfType<ScreenshootOption>().Where(new Func<ScreenshootOption, bool>(ColumnReportExplorerViewModel.<>c.<>9.#7Wb)).Select(new Func<ScreenshootOption, ReporterImage>(ColumnReportExplorerViewModel.<>c.<>9.#8Wb)).Take(10).ToList<ReporterImage>().Concat(this.Options.Screenshots.Children.OfType<ScreenshootOption>().Where(new Func<ScreenshootOption, bool>(ColumnReportExplorerViewModel.<>c.<>9.#9Wb)).Select(new Func<ScreenshootOption, ReporterImage>(ColumnReportExplorerViewModel.<>c.<>9.#aXb)).Take(10).ToList<ReporterImage>()).ToList<ReporterImage>();
			using (IEnumerator<ScreenshootOption> enumerator = this.Options.Screenshots.Children.OfType<ScreenshootOption>().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ColumnReportExplorerViewModel.#hXb #hXb = new ColumnReportExplorerViewModel.#hXb();
					#hXb.#a = enumerator.Current;
					new ReportContentVisibilityOption(#hXb.#a, #hXb.#a.Drawing.Label, this.Screenshots, false).IsChecked = new bool?(#hXb.#a.BookmarkName.Contains(#Phc.#3hc(107408986)) || source.Any(new Func<ReporterImage, bool>(#hXb.#gXb)));
				}
			}
			base.#Qab();
		}

		// Token: 0x06000EE9 RID: 3817 RVA: 0x000A3720 File Offset: 0x000A1920
		private void #pz()
		{
			ReportFileFormat #cA = this.#a.Options.SelectedFileFormat;
			this.Cover.IsEnabled = (#cA.#OSd() || #cA.#Lcd());
			this.TableOfContents.IsEnabled = (#cA.#OSd() || #cA.#Icd());
			this.SectionFigure.IsEnabled = #cA.#OSd();
			this.Screenshots.IsEnabled = (#cA.#OSd() && this.Screenshots.Children.Any<ReportContentVisibilityOption>() && this.#b != null && this.#b.#ite() && this.Screenshots.Children.Any<ReportContentVisibilityOption>());
		}

		// Token: 0x06000EEA RID: 3818 RVA: 0x000A37F4 File Offset: 0x000A19F4
		private void #qz()
		{
			base.#9Nd(new Action<ReportContentVisibilityOption>(ColumnReportExplorerViewModel.<>c.<>9.#bXb));
			base.#9Nd(new Action<ReportContentVisibilityOption>(ColumnReportExplorerViewModel.<>c.<>9.#cXb));
			this.CoverAndContents.IsExpanded = (this.Input.IsExpanded = (this.Results.IsExpanded = (this.Screenshots.IsExpanded = true)));
		}

		// Token: 0x06000EEB RID: 3819 RVA: 0x000A3890 File Offset: 0x000A1A90
		private bool #rz()
		{
			#l4e #l4e = this.#b.Output;
			ColumnStorageModel columnStorageModel = this.#b.Input;
			SectionPolygon sectionPolygon = columnStorageModel.Polygons.FirstOrDefault(new Func<SectionPolygon, bool>(ColumnReportExplorerViewModel.<>c.<>9.#dXb));
			SectionPolygon sectionPolygon2 = columnStorageModel.Polygons.FirstOrDefault(new Func<SectionPolygon, bool>(ColumnReportExplorerViewModel.<>c.<>9.#eXb));
			int num = #l4e.BiaxialFactoredLoads.Count + #l4e.BiaxialServiceLoads.Count + #l4e.UniaxialServiceLoads.Count + #l4e.UniaxialFactoredLoads.Count;
			int num2 = (int)Math.Ceiling((double)columnStorageModel.ReinforcementBars.Count / 3.0);
			int num3 = (int)Math.Ceiling((double)(((sectionPolygon != null) ? sectionPolygon.Points.Count : 0) + ((sectionPolygon2 != null) ? sectionPolygon2.Points.Count : 0)) / 3.0);
			int count = #l4e.FactoredMoments.Count;
			int count2 = #l4e.MomentMagnificationFactors.Count;
			int num4 = this.Screenshots.Children.Count(new Func<ReportContentVisibilityOption, bool>(ColumnReportExplorerViewModel.<>c.<>9.#fXb)) * 50;
			int num5 = num + num2 + num3 + count + count2 + num4;
			return num5 > 2500;
		}

		// Token: 0x06000EEC RID: 3820 RVA: 0x00011759 File Offset: 0x0000F959
		private void #sz()
		{
			this.Options.SolverMessages.IsEnabled = false;
		}

		// Token: 0x0400058B RID: 1419
		private readonly #rUd #a;

		// Token: 0x0400058C RID: 1420
		private #lte #b;

		// Token: 0x0400058D RID: 1421
		private string #c;

		// Token: 0x0400058E RID: 1422
		private bool #d;

		// Token: 0x0400058F RID: 1423
		[CompilerGenerated]
		private readonly #yse #e;

		// Token: 0x04000590 RID: 1424
		[CompilerGenerated]
		private readonly ReportContentVisibilityOption #f;

		// Token: 0x04000591 RID: 1425
		[CompilerGenerated]
		private readonly ReportContentVisibilityOption #g;

		// Token: 0x04000592 RID: 1426
		[CompilerGenerated]
		private readonly ReportContentVisibilityOption #h;

		// Token: 0x04000593 RID: 1427
		[CompilerGenerated]
		private readonly ReportContentVisibilityOption #i;

		// Token: 0x04000594 RID: 1428
		[CompilerGenerated]
		private readonly ReportContentVisibilityOption #j;

		// Token: 0x04000595 RID: 1429
		[CompilerGenerated]
		private readonly ReportContentVisibilityOption #k;

		// Token: 0x04000596 RID: 1430
		[CompilerGenerated]
		private readonly ReportContentVisibilityOption #l;

		// Token: 0x04000597 RID: 1431
		[CompilerGenerated]
		private readonly ReportContentVisibilityOption #m;

		// Token: 0x04000598 RID: 1432
		[CompilerGenerated]
		private readonly ReportContentVisibilityOption #n;

		// Token: 0x04000599 RID: 1433
		[CompilerGenerated]
		private readonly ReportContentVisibilityOption #o;

		// Token: 0x0400059A RID: 1434
		[CompilerGenerated]
		private readonly ReportContentVisibilityOption #p;

		// Token: 0x0400059B RID: 1435
		[CompilerGenerated]
		private readonly ReportContentVisibilityOption #q;

		// Token: 0x0400059C RID: 1436
		[CompilerGenerated]
		private readonly ReportContentVisibilityOption #r;

		// Token: 0x0400059D RID: 1437
		[CompilerGenerated]
		private readonly ReportContentVisibilityOption #s;

		// Token: 0x0400059E RID: 1438
		[CompilerGenerated]
		private readonly ReportContentVisibilityOption #t;

		// Token: 0x0400059F RID: 1439
		[CompilerGenerated]
		private readonly ReportContentVisibilityOption #u;

		// Token: 0x040005A0 RID: 1440
		[CompilerGenerated]
		private readonly ReportContentVisibilityOption #v;

		// Token: 0x040005A1 RID: 1441
		[CompilerGenerated]
		private readonly ReportContentVisibilityOption #w;

		// Token: 0x040005A2 RID: 1442
		[CompilerGenerated]
		private readonly ReportContentVisibilityOption #x;

		// Token: 0x040005A3 RID: 1443
		[CompilerGenerated]
		private readonly ReportContentVisibilityOption #y;

		// Token: 0x040005A4 RID: 1444
		[CompilerGenerated]
		private readonly ReportContentVisibilityOption #z;

		// Token: 0x040005A5 RID: 1445
		[CompilerGenerated]
		private readonly ReportContentVisibilityOption #A;

		// Token: 0x040005A6 RID: 1446
		[CompilerGenerated]
		private readonly ReportContentVisibilityOption #B;

		// Token: 0x040005A7 RID: 1447
		[CompilerGenerated]
		private readonly ReportContentVisibilityOption #C;

		// Token: 0x040005A8 RID: 1448
		[CompilerGenerated]
		private readonly ReportContentVisibilityOption #D;

		// Token: 0x040005A9 RID: 1449
		[CompilerGenerated]
		private readonly ReportContentVisibilityOption #E;

		// Token: 0x040005AA RID: 1450
		[CompilerGenerated]
		private readonly ReportContentVisibilityOption #F;

		// Token: 0x040005AB RID: 1451
		[CompilerGenerated]
		private readonly ReportContentVisibilityOption #G;

		// Token: 0x040005AC RID: 1452
		[CompilerGenerated]
		private readonly ReportContentVisibilityOption #H;

		// Token: 0x040005AD RID: 1453
		[CompilerGenerated]
		private readonly ReportContentVisibilityOption #I;

		// Token: 0x040005AE RID: 1454
		[CompilerGenerated]
		private readonly ReportContentVisibilityOption #J;

		// Token: 0x040005AF RID: 1455
		[CompilerGenerated]
		private readonly ReportContentVisibilityOption #K;

		// Token: 0x040005B0 RID: 1456
		[CompilerGenerated]
		private readonly ReportContentVisibilityOption #L;

		// Token: 0x040005B1 RID: 1457
		[CompilerGenerated]
		private readonly ReportContentVisibilityOption #M;

		// Token: 0x040005B2 RID: 1458
		[CompilerGenerated]
		private readonly ReportContentVisibilityOption #N;

		// Token: 0x040005B3 RID: 1459
		[CompilerGenerated]
		private readonly ReportContentVisibilityOption #O;

		// Token: 0x040005B4 RID: 1460
		[CompilerGenerated]
		private readonly ReportContentVisibilityOption #P;

		// Token: 0x040005B5 RID: 1461
		[CompilerGenerated]
		private readonly ReportContentVisibilityOption #Q;

		// Token: 0x040005B6 RID: 1462
		[CompilerGenerated]
		private readonly ReportContentVisibilityOption #R;

		// Token: 0x040005B7 RID: 1463
		[CompilerGenerated]
		private readonly ReportContentVisibilityOption #S;

		// Token: 0x040005B8 RID: 1464
		[CompilerGenerated]
		private readonly ReportContentVisibilityOption #T;

		// Token: 0x040005B9 RID: 1465
		[CompilerGenerated]
		private #qW #U;

		// Token: 0x020001B5 RID: 437
		[CompilerGenerated]
		private sealed class #ZWb
		{
			// Token: 0x06000F00 RID: 3840 RVA: 0x000A3A40 File Offset: 0x000A1C40
			internal void #YWb()
			{
				this.#a.#oz(this.#b);
				this.#a.#lz(this.#b);
				this.#a.#9Nd(new Action<ReportContentVisibilityOption>(ColumnReportExplorerViewModel.<>c.<>9.#0Wb));
				ColumnDocumentContentOptionsHelper columnDocumentContentOptionsHelper = new ColumnDocumentContentOptionsHelper(this.#a.Options, this.#b);
				columnDocumentContentOptionsHelper.#jwe();
				this.#a.#sz();
				this.#a.#9Nd(new Action<ReportContentVisibilityOption>(ColumnReportExplorerViewModel.<>c.<>9.#1Wb));
				this.#a.#pz();
				this.#a.#mz(true);
				this.#a.#3Nd();
			}

			// Token: 0x040005CB RID: 1483
			public ColumnReportExplorerViewModel #a;

			// Token: 0x040005CC RID: 1484
			public #lte #b;
		}

		// Token: 0x020001B6 RID: 438
		[CompilerGenerated]
		private sealed class #hXb
		{
			// Token: 0x06000F02 RID: 3842 RVA: 0x00011871 File Offset: 0x0000FA71
			internal bool #gXb(ReporterImage #Rf)
			{
				return #Rf.Equals((ReporterImage)this.#a.Tag);
			}

			// Token: 0x040005CD RID: 1485
			public ScreenshootOption #a;
		}
	}
}
