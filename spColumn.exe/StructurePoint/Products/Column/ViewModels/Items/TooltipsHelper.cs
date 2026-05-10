using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using #7hc;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using Telerik.Windows.Controls;

namespace StructurePoint.Products.Column.ViewModels.Items
{
	// Token: 0x020000FB RID: 251
	internal static class TooltipsHelper
	{
		// Token: 0x17000354 RID: 852
		// (get) Token: 0x060007F4 RID: 2036 RVA: 0x0000C126 File Offset: 0x0000A326
		public static TooltipContent RibbonProject { get; } = new TooltipContent(Strings.StringProject, Strings.StringSpecifyVariousProjectParameters.#z2d());

		// Token: 0x17000355 RID: 853
		// (get) Token: 0x060007F5 RID: 2037 RVA: 0x0000C12D File Offset: 0x0000A32D
		public static TooltipContent RibbonDefine { get; } = new TooltipContent(Strings.StringDefine, Strings.StringAddDefinitionsUsedInTheProject.#z2d());

		// Token: 0x17000356 RID: 854
		// (get) Token: 0x060007F6 RID: 2038 RVA: 0x0000C134 File Offset: 0x0000A334
		public static TooltipContent RibbonSection { get; } = new TooltipContent(Strings.StringSection, Strings.StringCreateModifyRegularAndIrregularSectionsAndReinforcements.#z2d());

		// Token: 0x17000357 RID: 855
		// (get) Token: 0x060007F7 RID: 2039 RVA: 0x0000C13B File Offset: 0x0000A33B
		public static TooltipContent RibbonDiagrams { get; } = new TooltipContent(Strings.StringDiagrams, #Phc.#3hc(107381644).#z2d());

		// Token: 0x17000358 RID: 856
		// (get) Token: 0x060007F8 RID: 2040 RVA: 0x0000C142 File Offset: 0x0000A342
		public static TooltipContent RibbonLoads { get; } = new TooltipContent(Strings.StringLoad, Strings.StringSelectLoadTypeAndAssignLoadsToBeUsedInTheModel.#z2d());

		// Token: 0x17000359 RID: 857
		// (get) Token: 0x060007F9 RID: 2041 RVA: 0x0000C149 File Offset: 0x0000A349
		public static TooltipContent RibbonSlenderness { get; } = new TooltipContent(Strings.StringSlenderness, Strings.StringSpecifyVariousPropertiesRelatedToSlenderness.#z2d());

		// Token: 0x1700035A RID: 858
		// (get) Token: 0x060007FA RID: 2042 RVA: 0x0000C150 File Offset: 0x0000A350
		public static TooltipContent RibbonSolve { get; } = new TooltipContent(Strings.StringSolve.#O2d() + #Phc.#3hc(107381655), Strings.StringRunTheSolver.#z2d());

		// Token: 0x1700035B RID: 859
		// (get) Token: 0x060007FB RID: 2043 RVA: 0x0000C157 File Offset: 0x0000A357
		public static TooltipContent RibbonTables { get; } = new TooltipContent(Strings.StringTables.#O2d() + #Phc.#3hc(107381614), Strings.StringOpenTablesToEvaluateInputAndOutputData.#z2d());

		// Token: 0x1700035C RID: 860
		// (get) Token: 0x060007FC RID: 2044 RVA: 0x0000C15E File Offset: 0x0000A35E
		public static TooltipContent RibbonReporter { get; } = new TooltipContent(Strings.StringReporter.#O2d() + #Phc.#3hc(107381605), Strings.StringOpenReporterToCustomizeAndPrintReports.#z2d());

		// Token: 0x1700035D RID: 861
		// (get) Token: 0x060007FD RID: 2045 RVA: 0x0000C165 File Offset: 0x0000A365
		public static TooltipContent RibbonSettings { get; } = new TooltipContent(Strings.StringSettings, Strings.StringModifyVariousProgramSettings.#z2d());

		// Token: 0x1700035E RID: 862
		// (get) Token: 0x060007FE RID: 2046 RVA: 0x0000C16C File Offset: 0x0000A36C
		public static TooltipContent RibbonViewports { get; } = new TooltipContent(Strings.StringViewports, Strings.StringSelectFromASetOfPredefinedViewportConfigurations.#z2d());

		// Token: 0x1700035F RID: 863
		// (get) Token: 0x060007FF RID: 2047 RVA: 0x0000C173 File Offset: 0x0000A373
		public static TooltipContent RibbonTools { get; } = new TooltipContent(Strings.StringTools, Strings.StringSelectFromAvailableProgramTools.#z2d());

		// Token: 0x17000360 RID: 864
		// (get) Token: 0x06000800 RID: 2048 RVA: 0x0000C17A File Offset: 0x0000A37A
		public static TooltipContent RibbonDesignTrace { get; } = new TooltipContent(Strings.StringDesignTrace, Strings.StringViewEachStepOfTheDesignProcess.#z2d());

		// Token: 0x17000361 RID: 865
		// (get) Token: 0x06000801 RID: 2049 RVA: 0x0000C181 File Offset: 0x0000A381
		public static TooltipContent ViewportsTwoVertical { get; } = new TooltipContent(Strings.StringTwoVerticals, Strings.StringDisplayTwoVerticalViewports.#z2d());

		// Token: 0x17000362 RID: 866
		// (get) Token: 0x06000802 RID: 2050 RVA: 0x0000C188 File Offset: 0x0000A388
		public static TooltipContent ViewportsTwoHorizontal { get; } = new TooltipContent(Strings.StringTwoHorizontals, Strings.StringDisplayTwoHorizontalViewports.#z2d());

		// Token: 0x17000363 RID: 867
		// (get) Token: 0x06000803 RID: 2051 RVA: 0x0000C18F File Offset: 0x0000A38F
		public static TooltipContent ViewportsFourEquals { get; } = new TooltipContent(Strings.StringFourEquals, Strings.StringDisplayFourEqualViewports.#z2d());

		// Token: 0x17000364 RID: 868
		// (get) Token: 0x06000804 RID: 2052 RVA: 0x0000C196 File Offset: 0x0000A396
		public static TooltipContent ViewportsNewWindow { get; } = new TooltipContent(Strings.StringNewWindow, Strings.StringCreateANewFloatingViewport.#z2d());

		// Token: 0x17000365 RID: 869
		// (get) Token: 0x06000805 RID: 2053 RVA: 0x0000C19D File Offset: 0x0000A39D
		public static TooltipContent SectionRectangular { get; } = new TooltipContent(Strings.StringRectangular, Strings.StringCreateModifyRectangularSections.#z2d());

		// Token: 0x17000366 RID: 870
		// (get) Token: 0x06000806 RID: 2054 RVA: 0x0000C1A4 File Offset: 0x0000A3A4
		public static TooltipContent SectionCircular { get; } = new TooltipContent(Strings.StringCircular, Strings.StringCreateModifyCircularSections.#z2d());

		// Token: 0x17000367 RID: 871
		// (get) Token: 0x06000807 RID: 2055 RVA: 0x0000C1AB File Offset: 0x0000A3AB
		public static TooltipContent SectionIrregular { get; } = new TooltipContent(Strings.StringIrregular, Strings.StringCreateModifyIrregularSections.#z2d());

		// Token: 0x17000368 RID: 872
		// (get) Token: 0x06000808 RID: 2056 RVA: 0x0000C1B2 File Offset: 0x0000A3B2
		public static TooltipContent SectionTemplate { get; } = new TooltipContent(Strings.StringTemplate, Strings.StringCreateModifyTemplateSections.#z2d());

		// Token: 0x17000369 RID: 873
		// (get) Token: 0x06000809 RID: 2057 RVA: 0x0000C1B9 File Offset: 0x0000A3B9
		public static TooltipContent SectionToIrregular { get; } = new TooltipContent(Strings.StringToIrr, Strings.StringModifyActiveRegularSectionAsIrregular.#z2d());

		// Token: 0x1700036A RID: 874
		// (get) Token: 0x0600080A RID: 2058 RVA: 0x0000C1C0 File Offset: 0x0000A3C0
		public static TooltipContent SectionToRegular { get; } = new TooltipContent(Strings.StringRegular, Strings.StringCreateModifyRegularSections.#z2d());

		// Token: 0x1700036B RID: 875
		// (get) Token: 0x0600080B RID: 2059 RVA: 0x0000C1C7 File Offset: 0x0000A3C7
		public static TooltipContent AddToReport { get; } = new TooltipContent(Strings.StringAddToReport, Strings.StringAddActive2DDiagramToReport.#z2d());

		// Token: 0x1700036C RID: 876
		// (get) Token: 0x0600080C RID: 2060 RVA: 0x0000C1CE File Offset: 0x0000A3CE
		public static TooltipContent PrintExport { get; } = new TooltipContent(Strings.StringPrintExport, Strings.StringPrintOrExportTheDiagramInTheActiveViewport);

		// Token: 0x1700036D RID: 877
		// (get) Token: 0x0600080D RID: 2061 RVA: 0x0000C1D5 File Offset: 0x0000A3D5
		public static TooltipContent CleanReport { get; } = new TooltipContent(Strings.StringCleanReport, Strings.StringRemoveAllUserAddedDiagramsFromTheReport);

		// Token: 0x1700036E RID: 878
		// (get) Token: 0x0600080E RID: 2062 RVA: 0x0000C1DC File Offset: 0x0000A3DC
		public static TooltipContent BatchProcessor { get; } = new TooltipContent(Strings.StringBatchProcessor, Strings.StringProcessMultipleFilesAtOnce.#z2d());

		// Token: 0x1700036F RID: 879
		// (get) Token: 0x0600080F RID: 2063 RVA: 0x0000C1E3 File Offset: 0x0000A3E3
		public static TooltipContent Superimpose { get; } = new TooltipContent(Strings.StringSuperImpose, Strings.StringSuperimposePMAndMMDiagramsForComparison.#z2d());

		// Token: 0x17000370 RID: 880
		// (get) Token: 0x06000810 RID: 2064 RVA: 0x0000C1EA File Offset: 0x0000A3EA
		public static TooltipContent ReportSettings { get; } = new TooltipContent(Strings.StringReportSettings, Strings.StringModifyVariousReportSettings.#z2d());

		// Token: 0x17000371 RID: 881
		// (get) Token: 0x06000811 RID: 2065 RVA: 0x0000C1F1 File Offset: 0x0000A3F1
		public static TooltipContent Export { get; } = new TooltipContent(Strings.StringExport, Strings.StringExportActiveDiagramInVariousFormats.#z2d());

		// Token: 0x17000372 RID: 882
		// (get) Token: 0x06000812 RID: 2066 RVA: 0x0000C1F8 File Offset: 0x0000A3F8
		public static TooltipContent GraphicalReportToEMFFile { get; } = new TooltipContent(Strings.StringGraphicalReportToEMFFile.#B2d(), Strings.StringExportActive2DDiagramAsAGraphicalReportToAnEMFFile.#z2d());

		// Token: 0x17000373 RID: 883
		// (get) Token: 0x06000813 RID: 2067 RVA: 0x0000C1FF File Offset: 0x0000A3FF
		public static TooltipContent CopyDiagramToClipboard { get; } = new TooltipContent(Strings.StringCopyDiagramToClipboard, Strings.StringCopyActive2DDiagramToClipboard.#z2d());

		// Token: 0x17000374 RID: 884
		// (get) Token: 0x06000814 RID: 2068 RVA: 0x0000C206 File Offset: 0x0000A406
		public static TooltipContent FactoredDiagramToCSVFile { get; } = new TooltipContent(Strings.StringFactoredDiagramToCSVFile.#B2d(), Strings.StringExportActiveFactored2DDiagramOr3DSurfaceToCSVFile.#z2d());

		// Token: 0x17000375 RID: 885
		// (get) Token: 0x06000815 RID: 2069 RVA: 0x0000C20D File Offset: 0x0000A40D
		public static TooltipContent NominalDiagramToCSVFile { get; } = new TooltipContent(Strings.StringNominalDiagramToCSVFile.#B2d(), Strings.StringExportActiveNominal2DDiagramOr3DSurfaceToCSVFile.#z2d());

		// Token: 0x17000376 RID: 886
		// (get) Token: 0x06000816 RID: 2070 RVA: 0x0000C214 File Offset: 0x0000A414
		public static TooltipContent PMDiagram { get; } = new TooltipContent(Strings.StringPMDiagram, Strings.StringDisplayAnInteractionDiagramSlicedAtConstantAngleInTheActiveViewport.#z2d());

		// Token: 0x17000377 RID: 887
		// (get) Token: 0x06000817 RID: 2071 RVA: 0x0000C21B File Offset: 0x0000A41B
		public static TooltipContent PMDiagramFull { get; } = new TooltipContent(Strings.StringPMDiagramFull, Strings.StringDisplayAnInteractionDiagramForBothPositiveAndNegativeMoments.#z2d());

		// Token: 0x17000378 RID: 888
		// (get) Token: 0x06000818 RID: 2072 RVA: 0x0000C222 File Offset: 0x0000A422
		public static TooltipContent PMDiagramPMPositive { get; } = new TooltipContent(Strings.StringPMDiagramMPositive, Strings.StringDisplayAnInteractionDiagramForThePositiveMomentsOnly.#z2d());

		// Token: 0x17000379 RID: 889
		// (get) Token: 0x06000819 RID: 2073 RVA: 0x0000C229 File Offset: 0x0000A429
		public static TooltipContent PMDiagramPMNegative { get; } = new TooltipContent(Strings.StringPMDiagramMNegative, Strings.StringDisplayAnInteractionDiagramForTheNegativeMomentsOnly.#z2d());

		// Token: 0x1700037A RID: 890
		// (get) Token: 0x0600081A RID: 2074 RVA: 0x0000C230 File Offset: 0x0000A430
		public static TooltipContent MMDiagram { get; } = new TooltipContent(Strings.StringMMDiagram, Strings.StringDisplayAContourOfTheFailureSurfaceSlicedAtAConstantAxialLoad.#z2d());

		// Token: 0x1700037B RID: 891
		// (get) Token: 0x0600081B RID: 2075 RVA: 0x0000C237 File Offset: 0x0000A437
		public static TooltipContent Surface3DPM { get; } = new TooltipContent(Strings.String3DPM, Strings.StringDisplayA3DVisualtizationOfFailureSurfaceWithAVerticalPlane.#z2d());

		// Token: 0x1700037C RID: 892
		// (get) Token: 0x0600081C RID: 2076 RVA: 0x0000C23E File Offset: 0x0000A43E
		public static TooltipContent ShowPlaneVertical { get; } = new TooltipContent(Strings.StringShowPlane, Strings.StringToggleVerticalPlaneOnOff.#z2d());

		// Token: 0x1700037D RID: 893
		// (get) Token: 0x0600081D RID: 2077 RVA: 0x0000C245 File Offset: 0x0000A445
		public static TooltipContent ShowPlaneHorizontal { get; } = new TooltipContent(Strings.StringShowPlane, Strings.StringToggleHorizontalPlaneOnOff.#z2d());

		// Token: 0x1700037E RID: 894
		// (get) Token: 0x0600081E RID: 2078 RVA: 0x0000C24C File Offset: 0x0000A44C
		public static TooltipContent CutVertical { get; } = new TooltipContent(Strings.StringCut, Strings.StringCutTheFailureSurfaceAtTheLocationOfTheVerticalPlaneOrRestoreIt.#z2d());

		// Token: 0x1700037F RID: 895
		// (get) Token: 0x0600081F RID: 2079 RVA: 0x0000C253 File Offset: 0x0000A453
		public static TooltipContent CutHorizontal { get; } = new TooltipContent(Strings.StringCut, Strings.StringCutTheFailureSurfaceAtTheLocationOfTheHorizontalPlaneOrRestoreIt.#z2d());

		// Token: 0x17000380 RID: 896
		// (get) Token: 0x06000820 RID: 2080 RVA: 0x0000C25A File Offset: 0x0000A45A
		public static TooltipContent SwapPM { get; } = new TooltipContent(Strings.StringSwap, Strings.StringSwapTheVisiblePartOfThe3DPMSurface.#z2d());

		// Token: 0x17000381 RID: 897
		// (get) Token: 0x06000821 RID: 2081 RVA: 0x0000C261 File Offset: 0x0000A461
		public static TooltipContent SwapMM { get; } = new TooltipContent(Strings.StringSwap, Strings.StringSwapTheVisiblePartOfThe3DMMSurface.#z2d());

		// Token: 0x17000382 RID: 898
		// (get) Token: 0x06000822 RID: 2082 RVA: 0x0000C268 File Offset: 0x0000A468
		public static TooltipContent Surface3DMM { get; } = new TooltipContent(Strings.String3DMM, Strings.StringDisplayA3DVisualizationOfFailureSurfaceWithAHorizontalPlane.#z2d());

		// Token: 0x17000383 RID: 899
		// (get) Token: 0x06000823 RID: 2083 RVA: 0x0000C26F File Offset: 0x0000A46F
		public static TooltipContent Viewports { get; } = new TooltipContent(Strings.StringViewports, Strings.StringSelectFromASetOfPredefinedViewportConfigurations.#z2d());

		// Token: 0x17000384 RID: 900
		// (get) Token: 0x06000824 RID: 2084 RVA: 0x0000C276 File Offset: 0x0000A476
		public static TooltipContent Viewports2DPMMM { get; } = new TooltipContent(Strings.String2DPMMM, Strings.StringDisplayTwoVerticalViewportsPMAndMM.#z2d());

		// Token: 0x17000385 RID: 901
		// (get) Token: 0x06000825 RID: 2085 RVA: 0x0000C27D File Offset: 0x0000A47D
		public static TooltipContent Viewports2D3DPM { get; } = new TooltipContent(Strings.String2D3DPM, Strings.StringDisplayTwoVerticalViewportsPMAnd3DPM.#z2d());

		// Token: 0x17000386 RID: 902
		// (get) Token: 0x06000826 RID: 2086 RVA: 0x0000C284 File Offset: 0x0000A484
		public static TooltipContent Viewports2D3DMM { get; } = new TooltipContent(Strings.String2D3DMM, Strings.StringDisplayTwoVerticalViewportsMMAnd3DMM.#z2d());

		// Token: 0x17000387 RID: 903
		// (get) Token: 0x06000827 RID: 2087 RVA: 0x0000C28B File Offset: 0x0000A48B
		public static TooltipContent Viewports2D3DPMMM { get; } = new TooltipContent(Strings.String2D3DPMMM, Strings.StringDisplayFourEqualViewportsMM3DMMAtTheTopAndPM3DPMAtTheBottom.#z2d());

		// Token: 0x17000388 RID: 904
		// (get) Token: 0x06000828 RID: 2088 RVA: 0x0000C292 File Offset: 0x0000A492
		public static TooltipContent DisplayOptions { get; } = new TooltipContent(Strings.StringDisplayOptions, Strings.StringToggleDisplayOfDifferentItemsInBoth2DDiagramsAnd3DSurfaces.#z2d());

		// Token: 0x17000389 RID: 905
		// (get) Token: 0x06000829 RID: 2089 RVA: 0x0000C299 File Offset: 0x0000A499
		public static TooltipContent StandardConcrete { get; } = new TooltipContent(Strings.StringStandardConcrete);

		// Token: 0x1700038A RID: 906
		// (get) Token: 0x0600082A RID: 2090 RVA: 0x0000C2A0 File Offset: 0x0000A4A0
		public static TooltipContent StandardInertia { get; } = new TooltipContent(Strings.StringStandardInertia);

		// Token: 0x1700038B RID: 907
		// (get) Token: 0x0600082B RID: 2091 RVA: 0x0000C2A7 File Offset: 0x0000A4A7
		public static TooltipContent SelectCopy { get; } = new TooltipContent(#Phc.#3hc(107381628), Strings.StringDuplicate);

		// Token: 0x1700038C RID: 908
		// (get) Token: 0x0600082C RID: 2092 RVA: 0x0000C2AE File Offset: 0x0000A4AE
		public static TooltipContent Select { get; } = new TooltipContent(#Phc.#3hc(107381628), Strings.StringSelect);

		// Token: 0x1700038D RID: 909
		// (get) Token: 0x0600082D RID: 2093 RVA: 0x0000C2B5 File Offset: 0x0000A4B5
		public static TooltipContent SelectMeasure { get; } = new TooltipContent(#Phc.#3hc(107381628), Strings.StringMeasureDistanceBetweenTwoPoints);

		// Token: 0x1700038E RID: 910
		// (get) Token: 0x0600082E RID: 2094 RVA: 0x0000C2BC File Offset: 0x0000A4BC
		public static TooltipContent SelectSlabsMerge { get; } = new TooltipContent(#Phc.#3hc(107381628), Strings.StringShapesMerge);

		// Token: 0x1700038F RID: 911
		// (get) Token: 0x0600082F RID: 2095 RVA: 0x0000C2C3 File Offset: 0x0000A4C3
		public static TooltipContent SelectSlabsSplit { get; } = new TooltipContent(#Phc.#3hc(107381628), Strings.StringShapesSplit);

		// Token: 0x17000390 RID: 912
		// (get) Token: 0x06000830 RID: 2096 RVA: 0x0000C2CA File Offset: 0x0000A4CA
		public static TooltipContent SelectSlabsOffset { get; } = new TooltipContent(#Phc.#3hc(107381628), Strings.StringShapesOffset);

		// Token: 0x17000391 RID: 913
		// (get) Token: 0x06000831 RID: 2097 RVA: 0x0000C2D1 File Offset: 0x0000A4D1
		public static TooltipContent SelectAlignVertical { get; } = new TooltipContent(#Phc.#3hc(107381628), Strings.StringAlignVertical);

		// Token: 0x17000392 RID: 914
		// (get) Token: 0x06000832 RID: 2098 RVA: 0x0000C2D8 File Offset: 0x0000A4D8
		public static TooltipContent SelectAlignHorizontal { get; } = new TooltipContent(#Phc.#3hc(107381628), Strings.StringAlignHorizontal);

		// Token: 0x17000393 RID: 915
		// (get) Token: 0x06000833 RID: 2099 RVA: 0x0000C2DF File Offset: 0x0000A4DF
		public static TooltipContent SelectDelete { get; } = new TooltipContent(#Phc.#3hc(107381628), Strings.StringDelete);

		// Token: 0x17000394 RID: 916
		// (get) Token: 0x06000834 RID: 2100 RVA: 0x0000C2E6 File Offset: 0x0000A4E6
		public static TooltipContent SelectMove { get; } = new TooltipContent(#Phc.#3hc(107381628), Strings.StringMove);

		// Token: 0x17000395 RID: 917
		// (get) Token: 0x06000835 RID: 2101 RVA: 0x0000C2ED File Offset: 0x0000A4ED
		public static TooltipContent SelectRotate { get; } = new TooltipContent(#Phc.#3hc(107381628), Strings.StringRotate);

		// Token: 0x17000396 RID: 918
		// (get) Token: 0x06000836 RID: 2102 RVA: 0x0000C2F4 File Offset: 0x0000A4F4
		public static TooltipContent SelectMirror { get; } = new TooltipContent(#Phc.#3hc(107381628), Strings.StringMirror);

		// Token: 0x17000397 RID: 919
		// (get) Token: 0x06000837 RID: 2103 RVA: 0x0000C2FB File Offset: 0x0000A4FB
		public static TooltipContent EditBarsTable { get; } = new TooltipContent(Strings.StringEditBars, Strings.StringEditBarsInADataGrid.#z2d());

		// Token: 0x17000398 RID: 920
		// (get) Token: 0x06000838 RID: 2104 RVA: 0x0000C302 File Offset: 0x0000A502
		public static TooltipContent SlabsArc { get; } = new TooltipContent(Strings.StringDrawArc, Strings.StringCreateAnArcShape.#z2d());

		// Token: 0x17000399 RID: 921
		// (get) Token: 0x06000839 RID: 2105 RVA: 0x0000C309 File Offset: 0x0000A509
		public static TooltipContent SlabsPolygon { get; } = new TooltipContent(Strings.StringDrawPolygon, Strings.StringCreateAPolygonShapeBySpecifyingItsVertices.#z2d());

		// Token: 0x1700039A RID: 922
		// (get) Token: 0x0600083A RID: 2106 RVA: 0x0000C310 File Offset: 0x0000A510
		public static TooltipContent SlabsCircle { get; } = new TooltipContent(Strings.StringDrawCircleByRadius, Strings.StringCreateACircularShapeBySpecifyingCenterPointAndRadius.#z2d());

		// Token: 0x1700039B RID: 923
		// (get) Token: 0x0600083B RID: 2107 RVA: 0x0000C317 File Offset: 0x0000A517
		public static TooltipContent SlabsCircleByDiameter { get; } = new TooltipContent(Strings.StringDrawCircleByDiameter, Strings.StringCreateACircularShapeBySpecifyingItsDiameter.#z2d());

		// Token: 0x1700039C RID: 924
		// (get) Token: 0x0600083C RID: 2108 RVA: 0x0000C31E File Offset: 0x0000A51E
		public static TooltipContent SlabsCircleByTangentPoints { get; } = new TooltipContent(Strings.StringDrawCircleByTangentPoints, Strings.StringCreateACircularShapeBySpecifyingThreeTangentPoints.#z2d());

		// Token: 0x1700039D RID: 925
		// (get) Token: 0x0600083D RID: 2109 RVA: 0x0000C325 File Offset: 0x0000A525
		public static TooltipContent SlabsRectangle { get; } = new TooltipContent(Strings.StringDrawRectangle, Strings.StringCreateARectangularShape.#z2d());

		// Token: 0x1700039E RID: 926
		// (get) Token: 0x0600083E RID: 2110 RVA: 0x0000C32C File Offset: 0x0000A52C
		public static TooltipContent BarSingle { get; } = new TooltipContent(Strings.StringAddSingleReinforcementBar, Strings.StringCreateASingleBarAtAPoint.#z2d());

		// Token: 0x1700039F RID: 927
		// (get) Token: 0x0600083F RID: 2111 RVA: 0x0000C333 File Offset: 0x0000A533
		public static TooltipContent BarGrid { get; } = new TooltipContent(Strings.StringAddBarsInGridPattern, Strings.StringCreateAGridBarPatternBasedOnSpacingOrNumberOfBars.#z2d());

		// Token: 0x170003A0 RID: 928
		// (get) Token: 0x06000840 RID: 2112 RVA: 0x0000C33A File Offset: 0x0000A53A
		public static TooltipContent BarArc { get; } = new TooltipContent(Strings.StringAddBarsInArcPattern, Strings.StringCreateAnArcBarPatternBasedOnSpacingOrNumberOfBars.#z2d());

		// Token: 0x170003A1 RID: 929
		// (get) Token: 0x06000841 RID: 2113 RVA: 0x0000C341 File Offset: 0x0000A541
		public static TooltipContent BarLine { get; } = new TooltipContent(Strings.StringAddBarsInLinearPattern, Strings.StringCreateALinearBarPatternBasedOnSpacingOrNumberOfBars.#z2d());

		// Token: 0x170003A2 RID: 930
		// (get) Token: 0x06000842 RID: 2114 RVA: 0x0000C348 File Offset: 0x0000A548
		public static TooltipContent BarCircle { get; } = new TooltipContent(Strings.StringAddBarsInCircularPattern, Strings.StringCreateACircularBarPatternBasedOnSpacingOrNumberOfBars.#z2d());

		// Token: 0x170003A3 RID: 931
		// (get) Token: 0x06000843 RID: 2115 RVA: 0x0000C34F File Offset: 0x0000A54F
		public static TooltipContent BarRect { get; } = new TooltipContent(Strings.StringAddBarsInRectangularPattern, Strings.StringCreateARectangularBarPatternBasedOnSpacingOrNumberOfBars.#z2d());

		// Token: 0x170003A4 RID: 932
		// (get) Token: 0x06000844 RID: 2116 RVA: 0x0000C356 File Offset: 0x0000A556
		public static TooltipContent ApplicationNewProject { get; } = new TooltipContent(#Phc.#3hc(107381628), Strings.StringNew);

		// Token: 0x170003A5 RID: 933
		// (get) Token: 0x06000845 RID: 2117 RVA: 0x0000C35D File Offset: 0x0000A55D
		public static TooltipContent ApplicationOpenProject { get; } = new TooltipContent(#Phc.#3hc(107381628), Strings.StringOpen);

		// Token: 0x170003A6 RID: 934
		// (get) Token: 0x06000846 RID: 2118 RVA: 0x0000C364 File Offset: 0x0000A564
		public static TooltipContent ApplicationSaveProject { get; } = new TooltipContent(#Phc.#3hc(107381628), Strings.StringSave);

		// Token: 0x170003A7 RID: 935
		// (get) Token: 0x06000847 RID: 2119 RVA: 0x0000C36B File Offset: 0x0000A56B
		public static TooltipContent ApplicationUndo { get; } = new TooltipContent(#Phc.#3hc(107381628), Strings.StringUndo + #Phc.#3hc(107381627));

		// Token: 0x170003A8 RID: 936
		// (get) Token: 0x06000848 RID: 2120 RVA: 0x0000C372 File Offset: 0x0000A572
		public static TooltipContent ApplicationRedo { get; } = new TooltipContent(#Phc.#3hc(107381628), Strings.StringRedo + #Phc.#3hc(107381582));

		// Token: 0x170003A9 RID: 937
		// (get) Token: 0x06000849 RID: 2121 RVA: 0x0000C379 File Offset: 0x0000A579
		public static TooltipContent BatchProcessorOrganize { get; } = new TooltipContent(Strings.StringOrganize, Strings.StringMoveInputFilesWithoutErrorsOrWarningsAndRelatedOutputsToASeparateFolder.#z2d());

		// Token: 0x170003AA RID: 938
		// (get) Token: 0x0600084A RID: 2122 RVA: 0x0000C380 File Offset: 0x0000A580
		public static TooltipContent TemplateMirrorHorizontal { get; } = new TooltipContent(Strings.StringMirrorHorizontal, Strings.StringMirrorHorizontal);

		// Token: 0x170003AB RID: 939
		// (get) Token: 0x0600084B RID: 2123 RVA: 0x0000C387 File Offset: 0x0000A587
		public static TooltipContent TemplateMirrorVertical { get; } = new TooltipContent(Strings.StringMirrorVertical, Strings.StringMirrorVertical);

		// Token: 0x170003AC RID: 940
		// (get) Token: 0x0600084C RID: 2124 RVA: 0x0000C38E File Offset: 0x0000A58E
		public static TooltipContent TemplateRotateLeft { get; } = new TooltipContent(Strings.StringRotateLeft, Strings.StringRotateLeft);

		// Token: 0x170003AD RID: 941
		// (get) Token: 0x0600084D RID: 2125 RVA: 0x0000C395 File Offset: 0x0000A595
		public static TooltipContent TemplateRotateRight { get; } = new TooltipContent(Strings.StringRotateRight, Strings.StringRotateRight);

		// Token: 0x170003AE RID: 942
		// (get) Token: 0x0600084E RID: 2126 RVA: 0x0000C39C File Offset: 0x0000A59C
		public static TooltipContent TemplateRotate45Deg { get; } = new TooltipContent(Strings.StringRotate45deg, Strings.StringRotate45deg);

		// Token: 0x170003AF RID: 943
		// (get) Token: 0x0600084F RID: 2127 RVA: 0x0000C3A3 File Offset: 0x0000A5A3
		public static TooltipContent TemplateColoredZones { get; } = new TooltipContent(Strings.StringColoredZones, Strings.StringShowHideColoredZones);

		// Token: 0x170003B0 RID: 944
		// (get) Token: 0x06000850 RID: 2128 RVA: 0x0000C3AA File Offset: 0x0000A5AA
		public static TooltipContent TemplateShowParameters { get; } = new TooltipContent(Strings.StringShowParameters, Strings.StringShowHideParameterNames);

		// Token: 0x06000851 RID: 2129 RVA: 0x0000C3B1 File Offset: 0x0000A5B1
		public static void SetSimpleTooltip(DependencyObject element, TooltipContent value)
		{
			element.SetValue(TooltipsHelper.SimpleTooltipProperty, value);
		}

		// Token: 0x06000852 RID: 2130 RVA: 0x0000C3CB File Offset: 0x0000A5CB
		public static TooltipContent GetSimpleTooltip(DependencyObject element)
		{
			return (TooltipContent)element.GetValue(TooltipsHelper.SimpleTooltipProperty);
		}

		// Token: 0x06000853 RID: 2131 RVA: 0x0000C3E5 File Offset: 0x0000A5E5
		public static void SetTooltipContent(DependencyObject element, TooltipContent value)
		{
			element.SetValue(TooltipsHelper.TooltipContentProperty, value);
		}

		// Token: 0x06000854 RID: 2132 RVA: 0x0000C3FF File Offset: 0x0000A5FF
		public static TooltipContent GetTooltipContent(DependencyObject element)
		{
			return (TooltipContent)element.GetValue(TooltipsHelper.TooltipContentProperty);
		}

		// Token: 0x06000855 RID: 2133 RVA: 0x0000C419 File Offset: 0x0000A619
		private static void DefaultContentElement_Loaded(object sender, RoutedEventArgs e)
		{
			TooltipsHelper.ApplyRegularTooltip(sender);
		}

		// Token: 0x06000856 RID: 2134 RVA: 0x0000C429 File Offset: 0x0000A629
		private static void SimpleContentElement_Loaded(object sender, RoutedEventArgs e)
		{
			TooltipsHelper.ApplySimpleTooltip(sender);
		}

		// Token: 0x06000857 RID: 2135 RVA: 0x000922F4 File Offset: 0x000904F4
		private static void ApplyRegularTooltip(object sender)
		{
			FrameworkElement frameworkElement = sender as FrameworkElement;
			if (frameworkElement == null)
			{
				return;
			}
			FrameworkElement frameworkElement2 = frameworkElement;
			RoutedEventHandler value;
			if ((value = TooltipsHelper.<>O.<0>__DefaultContentElement_Loaded) == null)
			{
				value = (TooltipsHelper.<>O.<0>__DefaultContentElement_Loaded = new RoutedEventHandler(TooltipsHelper.DefaultContentElement_Loaded));
			}
			frameworkElement2.Loaded -= value;
			TooltipContent tooltipContent = TooltipsHelper.GetTooltipContent(frameworkElement);
			frameworkElement = TooltipsHelper.ApplyTooltipToDropDownButton(sender);
			TooltipsHelper.ApplyTooltip(frameworkElement, tooltipContent, TooltipsHelper.TooltipTemplateLazy.Value);
		}

		// Token: 0x06000858 RID: 2136 RVA: 0x00092358 File Offset: 0x00090558
		private static void ApplySimpleTooltip(object sender)
		{
			FrameworkElement frameworkElement = sender as FrameworkElement;
			if (frameworkElement == null)
			{
				return;
			}
			FrameworkElement frameworkElement2 = frameworkElement;
			RoutedEventHandler value;
			if ((value = TooltipsHelper.<>O.<1>__SimpleContentElement_Loaded) == null)
			{
				value = (TooltipsHelper.<>O.<1>__SimpleContentElement_Loaded = new RoutedEventHandler(TooltipsHelper.SimpleContentElement_Loaded));
			}
			frameworkElement2.Loaded -= value;
			TooltipContent simpleTooltip = TooltipsHelper.GetSimpleTooltip(frameworkElement);
			frameworkElement = TooltipsHelper.ApplyTooltipToDropDownButton(sender);
			TooltipsHelper.ApplyTooltip(frameworkElement, simpleTooltip, TooltipsHelper.SimpleTooltipTemplateLazy.Value);
		}

		// Token: 0x06000859 RID: 2137 RVA: 0x000923BC File Offset: 0x000905BC
		private static void SimpleTooltipContentPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
		{
			FrameworkElement frameworkElement = dependencyObject as FrameworkElement;
			FrameworkElement frameworkElement2;
			if (2 != 0)
			{
				frameworkElement2 = frameworkElement;
			}
			if (frameworkElement2 == null)
			{
				return;
			}
			FrameworkElement frameworkElement3 = frameworkElement2;
			RoutedEventHandler value;
			if ((value = TooltipsHelper.<>O.<1>__SimpleContentElement_Loaded) == null)
			{
				value = (TooltipsHelper.<>O.<1>__SimpleContentElement_Loaded = new RoutedEventHandler(TooltipsHelper.SimpleContentElement_Loaded));
			}
			frameworkElement3.Loaded -= value;
			if (frameworkElement2.IsLoaded)
			{
				TooltipsHelper.ApplySimpleTooltip(dependencyObject);
				return;
			}
			FrameworkElement frameworkElement4 = frameworkElement2;
			RoutedEventHandler value2;
			if ((value2 = TooltipsHelper.<>O.<1>__SimpleContentElement_Loaded) == null)
			{
				value2 = (TooltipsHelper.<>O.<1>__SimpleContentElement_Loaded = new RoutedEventHandler(TooltipsHelper.SimpleContentElement_Loaded));
			}
			frameworkElement4.Loaded += value2;
		}

		// Token: 0x0600085A RID: 2138 RVA: 0x00092434 File Offset: 0x00090634
		private static FrameworkElement ApplyTooltipToDropDownButton(object sender)
		{
			RadDropDownButton radDropDownButton = sender as RadDropDownButton;
			if (radDropDownButton != null)
			{
				Grid grid = radDropDownButton.GetChildrenOfType<Grid>().FirstOrDefault<Grid>();
				if (grid != null)
				{
					Grid grid2 = grid.ChildrenOfType<Grid>().FirstOrDefault<Grid>();
					if (grid2 != null)
					{
						grid2.Background = new SolidColorBrush
						{
							Color = Color.FromArgb(1, byte.MaxValue, byte.MaxValue, byte.MaxValue)
						};
						return grid2;
					}
				}
			}
			return sender as FrameworkElement;
		}

		// Token: 0x0600085B RID: 2139 RVA: 0x000924A4 File Offset: 0x000906A4
		private static void ApplyTooltip(DependencyObject dependencyObject, TooltipContent tooltip, DataTemplate template)
		{
			if (!false)
			{
				RadToolTipService.SetToolTipContent(dependencyObject, tooltip);
			}
			RadToolTipService.SetToolTipContentTemplate(dependencyObject, template);
			RadToolTipService.SetInitialShowDelay(dependencyObject, 1200);
			RadToolTipService.SetBetweenShowDelay(dependencyObject, 50);
			RadToolTipService.SetVerticalOffset(dependencyObject, 10.0);
		}

		// Token: 0x0600085C RID: 2140 RVA: 0x000924F0 File Offset: 0x000906F0
		private static void TooltipContentPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
		{
			FrameworkElement frameworkElement = dependencyObject as FrameworkElement;
			FrameworkElement frameworkElement2;
			if (2 != 0)
			{
				frameworkElement2 = frameworkElement;
			}
			if (frameworkElement2 == null)
			{
				return;
			}
			FrameworkElement frameworkElement3 = frameworkElement2;
			RoutedEventHandler value;
			if ((value = TooltipsHelper.<>O.<0>__DefaultContentElement_Loaded) == null)
			{
				value = (TooltipsHelper.<>O.<0>__DefaultContentElement_Loaded = new RoutedEventHandler(TooltipsHelper.DefaultContentElement_Loaded));
			}
			frameworkElement3.Loaded -= value;
			if (frameworkElement2.IsLoaded)
			{
				TooltipsHelper.ApplyRegularTooltip(dependencyObject);
				return;
			}
			FrameworkElement frameworkElement4 = frameworkElement2;
			RoutedEventHandler value2;
			if ((value2 = TooltipsHelper.<>O.<0>__DefaultContentElement_Loaded) == null)
			{
				value2 = (TooltipsHelper.<>O.<0>__DefaultContentElement_Loaded = new RoutedEventHandler(TooltipsHelper.DefaultContentElement_Loaded));
			}
			frameworkElement4.Loaded += value2;
		}

		// Token: 0x04000241 RID: 577
		public static readonly DependencyProperty TooltipContentProperty = DependencyProperty.RegisterAttached(#Phc.#3hc(107381718), typeof(TooltipContent), typeof(TooltipsHelper), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.OverridesInheritanceBehavior, new PropertyChangedCallback(TooltipsHelper.TooltipContentPropertyChanged)));

		// Token: 0x04000242 RID: 578
		public static readonly Lazy<DataTemplate> TooltipTemplateLazy = new Lazy<DataTemplate>(() => Application.Current.FindResource(#Phc.#3hc(107380455)) as DataTemplate, LazyThreadSafetyMode.ExecutionAndPublication);

		// Token: 0x04000243 RID: 579
		public static readonly DependencyProperty SimpleTooltipProperty = DependencyProperty.RegisterAttached(#Phc.#3hc(107381665), typeof(TooltipContent), typeof(TooltipsHelper), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.OverridesInheritanceBehavior, new PropertyChangedCallback(TooltipsHelper.SimpleTooltipContentPropertyChanged)));

		// Token: 0x04000244 RID: 580
		public static readonly Lazy<DataTemplate> SimpleTooltipTemplateLazy = new Lazy<DataTemplate>(() => Application.Current.FindResource(#Phc.#3hc(107380438)) as DataTemplate, LazyThreadSafetyMode.ExecutionAndPublication);

		// Token: 0x020000FC RID: 252
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x040002A2 RID: 674
			public static RoutedEventHandler <0>__DefaultContentElement_Loaded;

			// Token: 0x040002A3 RID: 675
			public static RoutedEventHandler <1>__SimpleContentElement_Loaded;
		}
	}
}
