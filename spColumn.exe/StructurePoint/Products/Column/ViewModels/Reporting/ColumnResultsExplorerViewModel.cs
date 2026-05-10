using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using #5Fd;
using #6re;
using #7hc;
using #8xe;
using #mKd;
using #owe;
using #sUd;
using #Ted;
using #UYd;
using #v1c;
using #wqe;
using #Wse;
using StructurePoint.CoreAssets.AppManager.Column.Reporting;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Documents;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Documents.Tabular;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Presentation.Navigation;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Presentation.ViewModels;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Utils;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.CoreAssets.Logger;

namespace StructurePoint.Products.Column.ViewModels.Reporting
{
	// Token: 0x020001BD RID: 445
	internal sealed class ColumnResultsExplorerViewModel : ResultsExplorerViewModelBase
	{
		// Token: 0x06000F1C RID: 3868 RVA: 0x000A3B64 File Offset: 0x000A1D64
		public ColumnResultsExplorerViewModel(#yse settingsManager, #uUd featuresDescriptor, #v2c fileSystemService, #tUd exceptionHandler) : base(featuresDescriptor, settingsManager, fileSystemService, exceptionHandler)
		{
			base.SettingsManager.PropertyChanged += this.#jz;
			this.#d = base.SettingsManager.ResultsExplorerHideInactiveItems;
			this.#e = new #uwe();
			this.#gA();
			this.#eA();
		}

		// Token: 0x170005C5 RID: 1477
		// (get) Token: 0x06000F1D RID: 3869 RVA: 0x00011A97 File Offset: 0x0000FC97
		public #uwe Options { get; }

		// Token: 0x170005C6 RID: 1478
		// (get) Token: 0x06000F1E RID: 3870 RVA: 0x00011AA3 File Offset: 0x0000FCA3
		public override bool HideInactiveItems
		{
			get
			{
				return this.#d;
			}
		}

		// Token: 0x170005C7 RID: 1479
		// (get) Token: 0x06000F1F RID: 3871 RVA: 0x000A3BBC File Offset: 0x000A1DBC
		protected override ResultsContentOption DefaultOption
		{
			get
			{
				if (this.#b.Input.Options.ActiveLoad != LoadType.Axial && this.#b.Input.Options.ActiveLoad != LoadType.NoLoads)
				{
					return this.LoadsAndMomentsWithCapacityRatios;
				}
				return this.LoadsAndCapacities;
			}
		}

		// Token: 0x170005C8 RID: 1480
		// (get) Token: 0x06000F20 RID: 3872 RVA: 0x00011AAF File Offset: 0x0000FCAF
		// (set) Token: 0x06000F21 RID: 3873 RVA: 0x00011ABB File Offset: 0x0000FCBB
		private ResultsContentOption Input { get; set; }

		// Token: 0x170005C9 RID: 1481
		// (get) Token: 0x06000F22 RID: 3874 RVA: 0x00011ACC File Offset: 0x0000FCCC
		// (set) Token: 0x06000F23 RID: 3875 RVA: 0x00011AD8 File Offset: 0x0000FCD8
		private ResultsContentOption GeneralInformation { get; set; }

		// Token: 0x170005CA RID: 1482
		// (get) Token: 0x06000F24 RID: 3876 RVA: 0x00011AE9 File Offset: 0x0000FCE9
		// (set) Token: 0x06000F25 RID: 3877 RVA: 0x00011AF5 File Offset: 0x0000FCF5
		private ResultsContentOption MaterialProperties { get; set; }

		// Token: 0x170005CB RID: 1483
		// (get) Token: 0x06000F26 RID: 3878 RVA: 0x00011B06 File Offset: 0x0000FD06
		// (set) Token: 0x06000F27 RID: 3879 RVA: 0x00011B12 File Offset: 0x0000FD12
		private ResultsContentOption MaterialPropertiesConcrete { get; set; }

		// Token: 0x170005CC RID: 1484
		// (get) Token: 0x06000F28 RID: 3880 RVA: 0x00011B23 File Offset: 0x0000FD23
		// (set) Token: 0x06000F29 RID: 3881 RVA: 0x00011B2F File Offset: 0x0000FD2F
		private ResultsContentOption MaterialPropertiesSteel { get; set; }

		// Token: 0x170005CD RID: 1485
		// (get) Token: 0x06000F2A RID: 3882 RVA: 0x00011B40 File Offset: 0x0000FD40
		// (set) Token: 0x06000F2B RID: 3883 RVA: 0x00011B4C File Offset: 0x0000FD4C
		private ResultsContentOption Section { get; set; }

		// Token: 0x170005CE RID: 1486
		// (get) Token: 0x06000F2C RID: 3884 RVA: 0x00011B5D File Offset: 0x0000FD5D
		// (set) Token: 0x06000F2D RID: 3885 RVA: 0x00011B69 File Offset: 0x0000FD69
		private ResultsContentOption SectionShapeAndProperties { get; set; }

		// Token: 0x170005CF RID: 1487
		// (get) Token: 0x06000F2E RID: 3886 RVA: 0x00011B7A File Offset: 0x0000FD7A
		// (set) Token: 0x06000F2F RID: 3887 RVA: 0x00011B86 File Offset: 0x0000FD86
		private ResultsContentOption SectionSolids { get; set; }

		// Token: 0x170005D0 RID: 1488
		// (get) Token: 0x06000F30 RID: 3888 RVA: 0x00011B97 File Offset: 0x0000FD97
		// (set) Token: 0x06000F31 RID: 3889 RVA: 0x00011BA3 File Offset: 0x0000FDA3
		private ResultsContentOption SectionOpenings { get; set; }

		// Token: 0x170005D1 RID: 1489
		// (get) Token: 0x06000F32 RID: 3890 RVA: 0x00011BB4 File Offset: 0x0000FDB4
		// (set) Token: 0x06000F33 RID: 3891 RVA: 0x00011BC0 File Offset: 0x0000FDC0
		private ResultsContentOption Reinforcement { get; set; }

		// Token: 0x170005D2 RID: 1490
		// (get) Token: 0x06000F34 RID: 3892 RVA: 0x00011BD1 File Offset: 0x0000FDD1
		// (set) Token: 0x06000F35 RID: 3893 RVA: 0x00011BDD File Offset: 0x0000FDDD
		private ResultsContentOption ReinforcementBarSet { get; set; }

		// Token: 0x170005D3 RID: 1491
		// (get) Token: 0x06000F36 RID: 3894 RVA: 0x00011BEE File Offset: 0x0000FDEE
		// (set) Token: 0x06000F37 RID: 3895 RVA: 0x00011BFA File Offset: 0x0000FDFA
		private ResultsContentOption ReinforcementDesignCriteria { get; set; }

		// Token: 0x170005D4 RID: 1492
		// (get) Token: 0x06000F38 RID: 3896 RVA: 0x00011C0B File Offset: 0x0000FE0B
		// (set) Token: 0x06000F39 RID: 3897 RVA: 0x00011C17 File Offset: 0x0000FE17
		private ResultsContentOption ReinforcementConfinementAndFactors { get; set; }

		// Token: 0x170005D5 RID: 1493
		// (get) Token: 0x06000F3A RID: 3898 RVA: 0x00011C28 File Offset: 0x0000FE28
		// (set) Token: 0x06000F3B RID: 3899 RVA: 0x00011C34 File Offset: 0x0000FE34
		private ResultsContentOption ReinforcementProperties { get; set; }

		// Token: 0x170005D6 RID: 1494
		// (get) Token: 0x06000F3C RID: 3900 RVA: 0x00011C45 File Offset: 0x0000FE45
		// (set) Token: 0x06000F3D RID: 3901 RVA: 0x00011C51 File Offset: 0x0000FE51
		private ResultsContentOption ReinforcementBarsProvided { get; set; }

		// Token: 0x170005D7 RID: 1495
		// (get) Token: 0x06000F3E RID: 3902 RVA: 0x00011C62 File Offset: 0x0000FE62
		// (set) Token: 0x06000F3F RID: 3903 RVA: 0x00011C6E File Offset: 0x0000FE6E
		private ResultsContentOption Loading { get; set; }

		// Token: 0x170005D8 RID: 1496
		// (get) Token: 0x06000F40 RID: 3904 RVA: 0x00011C7F File Offset: 0x0000FE7F
		// (set) Token: 0x06000F41 RID: 3905 RVA: 0x00011C8B File Offset: 0x0000FE8B
		private ResultsContentOption LoadingLoadCases { get; set; }

		// Token: 0x170005D9 RID: 1497
		// (get) Token: 0x06000F42 RID: 3906 RVA: 0x00011C9C File Offset: 0x0000FE9C
		// (set) Token: 0x06000F43 RID: 3907 RVA: 0x00011CA8 File Offset: 0x0000FEA8
		private ResultsContentOption LoadingLoadCombinations { get; set; }

		// Token: 0x170005DA RID: 1498
		// (get) Token: 0x06000F44 RID: 3908 RVA: 0x00011CB9 File Offset: 0x0000FEB9
		// (set) Token: 0x06000F45 RID: 3909 RVA: 0x00011CC5 File Offset: 0x0000FEC5
		private ResultsContentOption LoadingServiceLoads { get; set; }

		// Token: 0x170005DB RID: 1499
		// (get) Token: 0x06000F46 RID: 3910 RVA: 0x00011CD6 File Offset: 0x0000FED6
		// (set) Token: 0x06000F47 RID: 3911 RVA: 0x00011CE2 File Offset: 0x0000FEE2
		private ResultsContentOption Slenderness { get; set; }

		// Token: 0x170005DC RID: 1500
		// (get) Token: 0x06000F48 RID: 3912 RVA: 0x00011CF3 File Offset: 0x0000FEF3
		// (set) Token: 0x06000F49 RID: 3913 RVA: 0x00011CFF File Offset: 0x0000FEFF
		private ResultsContentOption SlendernessSwayCriteria { get; set; }

		// Token: 0x170005DD RID: 1501
		// (get) Token: 0x06000F4A RID: 3914 RVA: 0x00011D10 File Offset: 0x0000FF10
		// (set) Token: 0x06000F4B RID: 3915 RVA: 0x00011D1C File Offset: 0x0000FF1C
		private ResultsContentOption SlendernessColumns { get; set; }

		// Token: 0x170005DE RID: 1502
		// (get) Token: 0x06000F4C RID: 3916 RVA: 0x00011D2D File Offset: 0x0000FF2D
		// (set) Token: 0x06000F4D RID: 3917 RVA: 0x00011D39 File Offset: 0x0000FF39
		private ResultsContentOption SlendernessXBeams { get; set; }

		// Token: 0x170005DF RID: 1503
		// (get) Token: 0x06000F4E RID: 3918 RVA: 0x00011D4A File Offset: 0x0000FF4A
		// (set) Token: 0x06000F4F RID: 3919 RVA: 0x00011D56 File Offset: 0x0000FF56
		private ResultsContentOption SlendernessYBeams { get; set; }

		// Token: 0x170005E0 RID: 1504
		// (get) Token: 0x06000F50 RID: 3920 RVA: 0x00011D67 File Offset: 0x0000FF67
		// (set) Token: 0x06000F51 RID: 3921 RVA: 0x00011D73 File Offset: 0x0000FF73
		private ResultsContentOption Results { get; set; }

		// Token: 0x170005E1 RID: 1505
		// (get) Token: 0x06000F52 RID: 3922 RVA: 0x00011D84 File Offset: 0x0000FF84
		// (set) Token: 0x06000F53 RID: 3923 RVA: 0x00011D90 File Offset: 0x0000FF90
		private ResultsContentOption SolverMessages { get; set; }

		// Token: 0x170005E2 RID: 1506
		// (get) Token: 0x06000F54 RID: 3924 RVA: 0x00011DA1 File Offset: 0x0000FFA1
		// (set) Token: 0x06000F55 RID: 3925 RVA: 0x00011DAD File Offset: 0x0000FFAD
		private ResultsContentOption MomentMagnification { get; set; }

		// Token: 0x170005E3 RID: 1507
		// (get) Token: 0x06000F56 RID: 3926 RVA: 0x00011DBE File Offset: 0x0000FFBE
		// (set) Token: 0x06000F57 RID: 3927 RVA: 0x00011DCA File Offset: 0x0000FFCA
		private ResultsContentOption MomentGeneralParameters { get; set; }

		// Token: 0x170005E4 RID: 1508
		// (get) Token: 0x06000F58 RID: 3928 RVA: 0x00011DDB File Offset: 0x0000FFDB
		// (set) Token: 0x06000F59 RID: 3929 RVA: 0x00011DE7 File Offset: 0x0000FFE7
		private ResultsContentOption MomentEffectiveLengthFactors { get; set; }

		// Token: 0x170005E5 RID: 1509
		// (get) Token: 0x06000F5A RID: 3930 RVA: 0x00011DF8 File Offset: 0x0000FFF8
		// (set) Token: 0x06000F5B RID: 3931 RVA: 0x00011E04 File Offset: 0x00010004
		private ResultsContentOption MomentMagnificationFactorsX { get; set; }

		// Token: 0x170005E6 RID: 1510
		// (get) Token: 0x06000F5C RID: 3932 RVA: 0x00011E15 File Offset: 0x00010015
		// (set) Token: 0x06000F5D RID: 3933 RVA: 0x00011E21 File Offset: 0x00010021
		private ResultsContentOption MomentMagnificationFactorsY { get; set; }

		// Token: 0x170005E7 RID: 1511
		// (get) Token: 0x06000F5E RID: 3934 RVA: 0x00011E32 File Offset: 0x00010032
		// (set) Token: 0x06000F5F RID: 3935 RVA: 0x00011E3E File Offset: 0x0001003E
		private ResultsContentOption FactoredMoments { get; set; }

		// Token: 0x170005E8 RID: 1512
		// (get) Token: 0x06000F60 RID: 3936 RVA: 0x00011E4F File Offset: 0x0001004F
		// (set) Token: 0x06000F61 RID: 3937 RVA: 0x00011E5B File Offset: 0x0001005B
		private ResultsContentOption FactoredMomentsXAxis { get; set; }

		// Token: 0x170005E9 RID: 1513
		// (get) Token: 0x06000F62 RID: 3938 RVA: 0x00011E6C File Offset: 0x0001006C
		// (set) Token: 0x06000F63 RID: 3939 RVA: 0x00011E78 File Offset: 0x00010078
		private ResultsContentOption FactoredMomentsYAxis { get; set; }

		// Token: 0x170005EA RID: 1514
		// (get) Token: 0x06000F64 RID: 3940 RVA: 0x00011E89 File Offset: 0x00010089
		// (set) Token: 0x06000F65 RID: 3941 RVA: 0x00011E95 File Offset: 0x00010095
		private ResultsContentOption ControlPoints { get; set; }

		// Token: 0x170005EB RID: 1515
		// (get) Token: 0x06000F66 RID: 3942 RVA: 0x00011EA6 File Offset: 0x000100A6
		// (set) Token: 0x06000F67 RID: 3943 RVA: 0x00011EB2 File Offset: 0x000100B2
		public ResultsContentOption LoadsAndMomentsWithCapacityRatios { get; set; }

		// Token: 0x170005EC RID: 1516
		// (get) Token: 0x06000F68 RID: 3944 RVA: 0x00011EC3 File Offset: 0x000100C3
		// (set) Token: 0x06000F69 RID: 3945 RVA: 0x00011ECF File Offset: 0x000100CF
		private ResultsContentOption LoadsAndCapacities { get; set; }

		// Token: 0x170005ED RID: 1517
		// (get) Token: 0x06000F6A RID: 3946 RVA: 0x00011EE0 File Offset: 0x000100E0
		// (set) Token: 0x06000F6B RID: 3947 RVA: 0x00011EEC File Offset: 0x000100EC
		public bool IsRefreshing { get; private set; }

		// Token: 0x06000F6C RID: 3948 RVA: 0x00011EFD File Offset: 0x000100FD
		public void #hz(#lte #Od)
		{
			if (#Od == null)
			{
				return;
			}
			this.IsRefreshing = true;
			this.#b = #Od;
			this.#lz(#Od);
			this.#fA(#Od);
			base.#0Od();
			this.#eA();
			this.#vh();
		}

		// Token: 0x06000F6D RID: 3949 RVA: 0x000A3C14 File Offset: 0x000A1E14
		protected override void #7z(ResultsContentOption #8z, bool #nz = false)
		{
			ColumnResultsExplorerViewModel.#jXb #jXb = new ColumnResultsExplorerViewModel.#jXb();
			#jXb.#a = #8z;
			#jXb.#b = #nz;
			#jXb.#c = this;
			ResultsContentOption resultsContentOption = #jXb.#a;
			if (((resultsContentOption != null) ? resultsContentOption.Renderer : null) != null && #jXb.#a.IsEnabled)
			{
				ColumnResultsExplorerViewModel.#lXb #lXb = new ColumnResultsExplorerViewModel.#lXb();
				#lXb.#b = #jXb;
				base.ShownContentOption = #lXb.#b.#a;
				base.SelectedRenderer = #lXb.#b.#a.Renderer;
				base.#1Od(#lXb.#b.#a);
				#lXb.#a = (#lXb.#b.#a == this.FactoredMomentsXAxis || #lXb.#b.#a == this.FactoredMomentsYAxis);
				LayoutHelper.BeginInvokeOnApplicationThread(new Action(#lXb.#kXb));
				return;
			}
			if (#jXb.#a != null)
			{
				try
				{
					#uwe options = (#uwe)#jXb.#a.Options;
					ColumnTabularReportDefinition columnTabularReportDefinition = new ColumnTabularReportDefinition(options, this.#b);
					columnTabularReportDefinition.#ued();
					#JGd #JGd = columnTabularReportDefinition.AllHeaders.FirstOrDefault(new Func<#JGd, bool>(#jXb.#iXb));
					#XKd #XKd = #jXb.#a.Renderer;
					if (#XKd != null)
					{
						#XKd.GridRenderer.#ehd();
					}
					base.ShownContentOption = #jXb.#a;
					base.SelectedRenderer = #jXb.#a.Renderer;
					base.#1Od(#jXb.#a);
					base.TableTitle = (((#JGd != null) ? #JGd.HeaderPath : null) ?? #jXb.#a.Name);
				}
				catch (Exception exception)
				{
					base.ExceptionHandler.Logger.Log(LoggingLevel.Error, exception);
				}
			}
			this.IsRefreshing = false;
		}

		// Token: 0x06000F6E RID: 3950 RVA: 0x00011F3D File Offset: 0x0001013D
		protected override string #9z()
		{
			return this.#a;
		}

		// Token: 0x06000F6F RID: 3951 RVA: 0x000A3DE8 File Offset: 0x000A1FE8
		protected override void #aA(ResultsContentOption #bA, ReportFileFormat #cA, string #So)
		{
			CommandLineReportGeneratorSettings commandLineReportGeneratorSettings = new CommandLineReportGeneratorSettings();
			commandLineReportGeneratorSettings.UseSimpleExcelSheetName = true;
			switch (#cA)
			{
			case ReportFileFormat.Text:
				commandLineReportGeneratorSettings.TxtReportPath = #So;
				break;
			case ReportFileFormat.Excel:
				commandLineReportGeneratorSettings.XlsReportPath = #So;
				break;
			case ReportFileFormat.Csv:
				commandLineReportGeneratorSettings.CsvReportPath = #So;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			#vqe #vqe = new #vqe(null, (#yse)base.SettingsManager, null, null);
			#vqe.#fp(this.#b, commandLineReportGeneratorSettings, (#uwe)#bA.Options);
		}

		// Token: 0x06000F70 RID: 3952 RVA: 0x000A3E80 File Offset: 0x000A2080
		protected override bool #dA(object #Vg)
		{
			return base.IsNavigationEnabled && this.#b != null && base.ShownContentOption != null && base.ShownContentOption.IsEnabled && base.NavigationIndex.Contains(base.ShownContentOption);
		}

		// Token: 0x06000F71 RID: 3953 RVA: 0x000A3ED4 File Offset: 0x000A20D4
		private void #jz(object #Ge, PropertyChangedEventArgs #He)
		{
			bool flag = base.SettingsManager.ResultsExplorerHideInactiveItems;
			if (this.#d != flag)
			{
				this.#d = flag;
				base.RaisePropertyChanged<bool>(Expression.Lambda<Func<bool>>(Expression.Property(Expression.Constant(this, typeof(ColumnResultsExplorerViewModel)), methodof(ResultsExplorerViewModelBase.#zy())), Array.Empty<ParameterExpression>()));
			}
		}

		// Token: 0x06000F72 RID: 3954 RVA: 0x000A3F40 File Offset: 0x000A2140
		private void #lz(#lte #Od)
		{
			ColumnDocumentContentOptionsHelper columnDocumentContentOptionsHelper = new ColumnDocumentContentOptionsHelper(this.Options, this.#b);
			columnDocumentContentOptionsHelper.#iwe();
			this.SectionOpenings.Children.Clear();
			this.SectionSolids.Children.Clear();
			if (#Od.Input.Options.SectionType != SectionType.Irregular && #Od.Input.Options.SectionType != SectionType.IrregularTemplate)
			{
				this.#hA();
				return;
			}
			List<SectionPolygon> list = #Od.BasicProperties.Polygons.Where(new Func<SectionPolygon, bool>(ColumnResultsExplorerViewModel.<>c.<>9.#mXb)).OrderBy(new Func<SectionPolygon, int>(ColumnResultsExplorerViewModel.<>c.<>9.#nXb)).ToList<SectionPolygon>();
			List<SectionPolygon> list2 = #Od.BasicProperties.Polygons.Where(new Func<SectionPolygon, bool>(ColumnResultsExplorerViewModel.<>c.<>9.#oXb)).OrderBy(new Func<SectionPolygon, int>(ColumnResultsExplorerViewModel.<>c.<>9.#pXb)).ToList<SectionPolygon>();
			for (int i = 0; i < this.Options.SectionOpenings.Children.Count; i++)
			{
				Option #bA = this.Options.SectionOpenings.Children[i];
				SectionPolygon sectionPolygon = list2[i];
				#uwe #uwe = new #uwe();
				columnDocumentContentOptionsHelper = new ColumnDocumentContentOptionsHelper(#uwe, this.#b);
				columnDocumentContentOptionsHelper.#iwe();
				this.#lA(#uwe, #bA, sectionPolygon.DisplayId, this.SectionOpenings, false);
			}
			for (int j = 0; j < this.Options.SectionSolids.Children.Count; j++)
			{
				Option #bA2 = this.Options.SectionSolids.Children[j];
				SectionPolygon sectionPolygon2 = list[j];
				#uwe #uwe2 = new #uwe();
				columnDocumentContentOptionsHelper = new ColumnDocumentContentOptionsHelper(#uwe2, this.#b);
				columnDocumentContentOptionsHelper.#iwe();
				this.#lA(#uwe2, #bA2, sectionPolygon2.DisplayId, this.SectionSolids, false);
			}
			this.#hA();
		}

		// Token: 0x06000F73 RID: 3955 RVA: 0x00011F49 File Offset: 0x00010149
		private void #eA()
		{
			if (this.#c)
			{
				return;
			}
			this.#c = true;
			this.Input.#OQd();
			this.Results.#NQd();
		}

		// Token: 0x06000F74 RID: 3956 RVA: 0x000A4178 File Offset: 0x000A2378
		private void #fA(#lte #Od)
		{
			ColumnResultsExplorerViewModel.#wXb #wXb = new ColumnResultsExplorerViewModel.#wXb();
			#wXb.#a = #Od;
			base.IsNavigationEnabled = true;
			if (!string.Equals(this.#a, #wXb.#a.GeneralInfo.FileName))
			{
				base.#9Nd(new Action<ResultsContentOption>(ColumnResultsExplorerViewModel.<>c.<>9.#qXb));
			}
			base.#9Nd(new Action<ResultsContentOption>(#wXb.#vXb));
			ColumnDocumentContentOptionsHelper columnDocumentContentOptionsHelper = new ColumnDocumentContentOptionsHelper(this.Options, #wXb.#a);
			columnDocumentContentOptionsHelper.#jwe();
			base.#9Nd(new Action<ResultsContentOption>(ColumnResultsExplorerViewModel.<>c.<>9.#rXb));
			base.#9Nd(new Action<ResultsContentOption>(ColumnResultsExplorerViewModel.<>c.<>9.#sXb));
			this.#a = #wXb.#a.GeneralInfo.FileName;
		}

		// Token: 0x06000F75 RID: 3957 RVA: 0x000A4284 File Offset: 0x000A2484
		private void #gA()
		{
			this.Input = this.#iA(this.Options.Input, Localization.StringInput, null, true);
			this.GeneralInformation = this.#iA(this.Options.GeneralInformation, Localization.StringGeneralInformation, this.Input, false);
			this.MaterialProperties = this.#iA(this.Options.MaterialProperties, Localization.StringMaterialProperties, this.Input, true);
			this.MaterialPropertiesConcrete = this.#iA(this.Options.MaterialPropertiesConcrete, Localization.StringConcrete, this.MaterialProperties, false);
			this.MaterialPropertiesSteel = this.#iA(this.Options.MaterialPropertiesSteel, Localization.StringSteel, this.MaterialProperties, false);
			this.Section = this.#iA(this.Options.Section, Localization.StringSection, this.Input, true);
			this.SectionShapeAndProperties = this.#iA(this.Options.SectionShapeAndProperties, Localization.StringShapeAndProperties, this.Section, false);
			this.SectionSolids = this.#iA(this.Options.SectionSolids, Strings.StringSolids, this.Section, true);
			this.SectionOpenings = this.#iA(this.Options.SectionOpenings, Strings.StringOpenings, this.Section, true);
			this.Reinforcement = this.#iA(this.Options.Reinforcement, Localization.StringReinforcement, this.Input, true);
			this.ReinforcementBarSet = this.#iA(this.Options.ReinforcementBarSet, Localization.StringBarSet, this.Reinforcement, false);
			this.ReinforcementDesignCriteria = this.#iA(this.Options.ReinforcementDesignCriteria, Localization.StringDesignCriteria, this.Reinforcement, false);
			this.ReinforcementConfinementAndFactors = this.#iA(this.Options.ReinforcementConfinementAndFactors, Localization.StringConfinementAndFactors, this.Reinforcement, false);
			this.ReinforcementProperties = this.#iA(this.Options.ReinforcementProperties, Localization.Arrangement, this.Reinforcement, false);
			this.ReinforcementBarsProvided = this.#iA(this.Options.ReinforcementBarsProvided, Localization.StringBarsProvided, this.Reinforcement, false);
			this.Loading = this.#iA(this.Options.Loading, Localization.StringLoading, this.Input, true);
			this.LoadingLoadCases = this.#iA(this.Options.LoadingLoadCases, Localization.StringLoadCases, this.Loading, false);
			this.LoadingLoadCombinations = this.#iA(this.Options.LoadingLoadCombinations, Localization.StringLoadCombinations, this.Loading, false);
			this.LoadingServiceLoads = this.#iA(this.Options.LoadingServiceLoads, Localization.StringServiceLoads, this.Loading, false);
			this.Slenderness = this.#iA(this.Options.Slenderness, Localization.StringSlenderness, this.Input, true);
			this.SlendernessSwayCriteria = this.#iA(this.Options.SlendernessSwayCriteria, Localization.StringSwayCriteria, this.Slenderness, false);
			this.SlendernessColumns = this.#iA(this.Options.SlendernessColumns, Localization.StringColumns, this.Slenderness, false);
			this.SlendernessXBeams = this.#iA(this.Options.SlendernessXBeams, Localization.StringX_Beams, this.Slenderness, false);
			this.SlendernessYBeams = this.#iA(this.Options.SlendernessYBeams, Localization.StringY_Beams, this.Slenderness, false);
			this.Results = this.#iA(this.Options.Results, Localization.StringResultsOutputs, null, true);
			this.SolverMessages = this.#iA(this.Options.SolverMessages, Strings.StringSolverMessages, this.Results, false);
			this.MomentMagnification = this.#iA(this.Options.MomentMagnification, Localization.StringMomentMagnification, this.Results, true);
			this.MomentGeneralParameters = this.#iA(this.Options.MomentGeneralParameters, Localization.StringGeneralParameters, this.MomentMagnification, false);
			this.MomentEffectiveLengthFactors = this.#iA(this.Options.MomentEffectiveLengthFactors, Localization.StringEffectiveLengthFactors, this.MomentMagnification, false);
			this.MomentMagnificationFactorsX = this.#iA(this.Options.MomentMagnificationFactorsX, Localization.StringMagnificationFactorsXAxis.#D2d(new object[]
			{
				#Phc.#3hc(107408964)
			}), this.MomentMagnification, false);
			this.MomentMagnificationFactorsY = this.#iA(this.Options.MomentMagnificationFactorsY, Localization.StringMagnificationFactorsXAxis.#D2d(new object[]
			{
				#Phc.#3hc(107408991)
			}), this.MomentMagnification, false);
			this.FactoredMoments = this.#iA(this.Options.FactoredMoments, Localization.StringFactoredMoments, this.Results, true);
			this.FactoredMomentsXAxis = this.#iA(this.Options.FactoredMomentsXAxis, Localization.StringXAxis.ToLower(CultureInfo.CurrentCulture).#D2d(new object[]
			{
				#Phc.#3hc(107408964)
			}), this.FactoredMoments, false);
			this.FactoredMomentsYAxis = this.#iA(this.Options.FactoredMomentsYAxis, Localization.StringYAxis, this.FactoredMoments, false);
			this.ControlPoints = this.#iA(this.Options.ControlPoints, Strings.StringControlPoints, this.Results, false);
			this.LoadsAndCapacities = this.#iA(this.Options.LoadsAndCapacities, Localization.StringLoadsAndCapacities, this.Results, false);
			this.LoadsAndMomentsWithCapacityRatios = this.#iA(this.Options.FactoredLoadsAndMomentsWithCorrespondingCapacityRatios, Localization.StringLoadsAndCapacityRatios, this.Results, false);
			base.Items.Add(this.Input);
			base.Items.Add(this.Results);
			this.#hA();
		}

		// Token: 0x06000F76 RID: 3958 RVA: 0x000A4830 File Offset: 0x000A2A30
		private void #hA()
		{
			ColumnResultsExplorerViewModel.#zXb #zXb = new ColumnResultsExplorerViewModel.#zXb();
			#zXb.#a = new HashSet<ResultsContentOption>();
			#hZd.#mbb<ResultsContentOption>(base.Items, new Func<ResultsContentOption, IEnumerable<ResultsContentOption>>(ColumnResultsExplorerViewModel.<>c.<>9.#tXb), new Action<ResultsContentOption>(#zXb.#xXb));
			base.NonHeaderOptions.#71d(new Predicate<ResultsContentOption>(#zXb.#yXb));
			HashSet<ResultsContentOption> hashSet = base.NonHeaderOptions.ToHashSet<ResultsContentOption>();
			foreach (ResultsContentOption item in #zXb.#a)
			{
				if (!hashSet.Contains(item))
				{
					base.NonHeaderOptions.Add(item);
				}
			}
		}

		// Token: 0x06000F77 RID: 3959 RVA: 0x000A491C File Offset: 0x000A2B1C
		private ResultsContentOption #iA(Option #bA, string #wy, ResultsContentOption #jA = null, bool #kA = false)
		{
			ResultsContentOption resultsContentOption = new ResultsContentOption(#bA, new #4Fd(), #wy, #jA, #kA);
			#uwe #5d = new #uwe();
			ReportOptionsHelper.#xdd<#uwe>(#5d, #bA);
			resultsContentOption.Options = #5d;
			return resultsContentOption;
		}

		// Token: 0x06000F78 RID: 3960 RVA: 0x000A495C File Offset: 0x000A2B5C
		private ResultsContentOption #lA(#uwe #mA, Option #bA, string #wy, ResultsContentOption #jA = null, bool #kA = false)
		{
			ResultsContentOption resultsContentOption = new ResultsContentOption(#bA, new #4Fd(), #wy, #jA, #kA);
			ReportOptionsHelper.#xdd<#uwe>(#mA, #bA);
			resultsContentOption.Options = #mA;
			return resultsContentOption;
		}

		// Token: 0x040005D3 RID: 1491
		private string #a;

		// Token: 0x040005D4 RID: 1492
		private #lte #b;

		// Token: 0x040005D5 RID: 1493
		private bool #c;

		// Token: 0x040005D6 RID: 1494
		private bool #d;

		// Token: 0x040005D7 RID: 1495
		[CompilerGenerated]
		private readonly #uwe #e;

		// Token: 0x040005D8 RID: 1496
		[CompilerGenerated]
		private ResultsContentOption #f;

		// Token: 0x040005D9 RID: 1497
		[CompilerGenerated]
		private ResultsContentOption #g;

		// Token: 0x040005DA RID: 1498
		[CompilerGenerated]
		private ResultsContentOption #h;

		// Token: 0x040005DB RID: 1499
		[CompilerGenerated]
		private ResultsContentOption #i;

		// Token: 0x040005DC RID: 1500
		[CompilerGenerated]
		private ResultsContentOption #j;

		// Token: 0x040005DD RID: 1501
		[CompilerGenerated]
		private ResultsContentOption #k;

		// Token: 0x040005DE RID: 1502
		[CompilerGenerated]
		private ResultsContentOption #l;

		// Token: 0x040005DF RID: 1503
		[CompilerGenerated]
		private ResultsContentOption #m;

		// Token: 0x040005E0 RID: 1504
		[CompilerGenerated]
		private ResultsContentOption #n;

		// Token: 0x040005E1 RID: 1505
		[CompilerGenerated]
		private ResultsContentOption #o;

		// Token: 0x040005E2 RID: 1506
		[CompilerGenerated]
		private ResultsContentOption #p;

		// Token: 0x040005E3 RID: 1507
		[CompilerGenerated]
		private ResultsContentOption #q;

		// Token: 0x040005E4 RID: 1508
		[CompilerGenerated]
		private ResultsContentOption #r;

		// Token: 0x040005E5 RID: 1509
		[CompilerGenerated]
		private ResultsContentOption #s;

		// Token: 0x040005E6 RID: 1510
		[CompilerGenerated]
		private ResultsContentOption #t;

		// Token: 0x040005E7 RID: 1511
		[CompilerGenerated]
		private ResultsContentOption #u;

		// Token: 0x040005E8 RID: 1512
		[CompilerGenerated]
		private ResultsContentOption #v;

		// Token: 0x040005E9 RID: 1513
		[CompilerGenerated]
		private ResultsContentOption #w;

		// Token: 0x040005EA RID: 1514
		[CompilerGenerated]
		private ResultsContentOption #x;

		// Token: 0x040005EB RID: 1515
		[CompilerGenerated]
		private ResultsContentOption #y;

		// Token: 0x040005EC RID: 1516
		[CompilerGenerated]
		private ResultsContentOption #z;

		// Token: 0x040005ED RID: 1517
		[CompilerGenerated]
		private ResultsContentOption #A;

		// Token: 0x040005EE RID: 1518
		[CompilerGenerated]
		private ResultsContentOption #B;

		// Token: 0x040005EF RID: 1519
		[CompilerGenerated]
		private ResultsContentOption #C;

		// Token: 0x040005F0 RID: 1520
		[CompilerGenerated]
		private ResultsContentOption #D;

		// Token: 0x040005F1 RID: 1521
		[CompilerGenerated]
		private ResultsContentOption #E;

		// Token: 0x040005F2 RID: 1522
		[CompilerGenerated]
		private ResultsContentOption #F;

		// Token: 0x040005F3 RID: 1523
		[CompilerGenerated]
		private ResultsContentOption #G;

		// Token: 0x040005F4 RID: 1524
		[CompilerGenerated]
		private ResultsContentOption #H;

		// Token: 0x040005F5 RID: 1525
		[CompilerGenerated]
		private ResultsContentOption #I;

		// Token: 0x040005F6 RID: 1526
		[CompilerGenerated]
		private ResultsContentOption #J;

		// Token: 0x040005F7 RID: 1527
		[CompilerGenerated]
		private ResultsContentOption #K;

		// Token: 0x040005F8 RID: 1528
		[CompilerGenerated]
		private ResultsContentOption #L;

		// Token: 0x040005F9 RID: 1529
		[CompilerGenerated]
		private ResultsContentOption #M;

		// Token: 0x040005FA RID: 1530
		[CompilerGenerated]
		private ResultsContentOption #N;

		// Token: 0x040005FB RID: 1531
		[CompilerGenerated]
		private ResultsContentOption #O;

		// Token: 0x040005FC RID: 1532
		[CompilerGenerated]
		private ResultsContentOption #P;

		// Token: 0x040005FD RID: 1533
		[CompilerGenerated]
		private bool #Q;

		// Token: 0x020001BF RID: 447
		[CompilerGenerated]
		private sealed class #jXb
		{
			// Token: 0x06000F84 RID: 3972 RVA: 0x00011FA6 File Offset: 0x000101A6
			internal bool #iXb(#JGd #Ae)
			{
				return string.Equals(#Ae.Option.BookmarkName, this.#a.DocumentOption.BookmarkName, StringComparison.Ordinal);
			}

			// Token: 0x04000607 RID: 1543
			public ResultsContentOption #a;

			// Token: 0x04000608 RID: 1544
			public bool #b;

			// Token: 0x04000609 RID: 1545
			public ColumnResultsExplorerViewModel #c;
		}

		// Token: 0x020001C0 RID: 448
		[CompilerGenerated]
		private sealed class #lXb
		{
			// Token: 0x06000F86 RID: 3974 RVA: 0x000A4998 File Offset: 0x000A2B98
			internal void #kXb()
			{
				try
				{
					this.#b.#a.Renderer.RequiresRefresh = (this.#b.#a.Renderer.RequiresRefresh | this.#b.#b);
					this.#b.#a.Renderer.#RKd(this.#b.#c.#b.GetHashCode());
					ColumnTabularReportDefinition #xS = new ColumnTabularReportDefinition((#uwe)this.#b.#a.Options, this.#b.#c.#b);
					#dye #dye = new #dye(this.#b.#a.Renderer.GridRenderer, #xS);
					#dye.CriticalItemsOptions = new #0ed
					{
						Highlight = (this.#b.#c.SettingsManager.HighlightCriticalItems && !this.#a),
						HighlightColor = this.#b.#c.SettingsManager.CriticalItemsHighlightingColor
					};
					this.#b.#a.Renderer.#ghd(#dye);
					this.#b.#c.TableTitle = this.#b.#a.Renderer.Title;
					if (this.#b.#c.AutoAdjustColumnWidth)
					{
						this.#b.#a.Renderer.#ihd(this.#b.#c.CurrentAvailableWidth);
					}
				}
				catch (Exception exception)
				{
					this.#b.#c.ExceptionHandler.Logger.Log(LoggingLevel.Error, exception);
				}
				finally
				{
					this.#b.#c.IsRefreshing = false;
				}
			}

			// Token: 0x0400060A RID: 1546
			public bool #a;

			// Token: 0x0400060B RID: 1547
			public ColumnResultsExplorerViewModel.#jXb #b;
		}

		// Token: 0x020001C1 RID: 449
		[CompilerGenerated]
		private sealed class #wXb
		{
			// Token: 0x06000F88 RID: 3976 RVA: 0x00011FD5 File Offset: 0x000101D5
			internal void #vXb(ResultsContentOption #Rf)
			{
				bool #f = true;
				if (!false)
				{
					#Rf.IsEnabled = #f;
				}
				#XKd #XKd = #Rf.Renderer;
				if (#XKd == null)
				{
					return;
				}
				#XKd.#RKd(this.#a.GetHashCode());
			}

			// Token: 0x0400060C RID: 1548
			public #lte #a;
		}

		// Token: 0x020001C2 RID: 450
		[CompilerGenerated]
		private sealed class #zXb
		{
			// Token: 0x06000F8A RID: 3978 RVA: 0x00012008 File Offset: 0x00010208
			internal void #xXb(ResultsContentOption #uXb)
			{
				if (!#uXb.IsHeader)
				{
					this.#a.Add(#uXb);
				}
			}

			// Token: 0x06000F8B RID: 3979 RVA: 0x0001202B File Offset: 0x0001022B
			internal bool #yXb(ResultsContentOption #Rf)
			{
				return !this.#a.Contains(#Rf);
			}

			// Token: 0x0400060D RID: 1549
			public HashSet<ResultsContentOption> #a;
		}
	}
}
