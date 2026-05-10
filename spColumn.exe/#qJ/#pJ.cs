using System;
using System.ComponentModel;
using #45d;
using #6re;
using #7hc;
using #sUd;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Settings;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Application;
using StructurePoint.CoreAssets.Logger;

namespace #qJ
{
	// Token: 0x0200028F RID: 655
	internal sealed class #pJ : ReporterSettingsManagerCore, INotifyPropertyChanged, #wUd, #yse
	{
		// Token: 0x0600150A RID: 5386 RVA: 0x0001627E File Offset: 0x0001447E
		public #pJ(ILogger #3x, #55d #rJ, #55d #sJ) : base(#3x, #rJ, #sJ)
		{
		}

		// Token: 0x17000787 RID: 1927
		// (get) Token: 0x0600150B RID: 5387 RVA: 0x00016289 File Offset: 0x00014489
		// (set) Token: 0x0600150C RID: 5388 RVA: 0x000162A8 File Offset: 0x000144A8
		public bool ShowNominal
		{
			get
			{
				return base.#1Ac(true, #Phc.#3hc(107407825));
			}
			set
			{
				base.#0Ac(value, #Phc.#3hc(107407825));
			}
		}

		// Token: 0x17000788 RID: 1928
		// (get) Token: 0x0600150D RID: 5389 RVA: 0x000162C7 File Offset: 0x000144C7
		// (set) Token: 0x0600150E RID: 5390 RVA: 0x000162E6 File Offset: 0x000144E6
		public bool ShowFactored
		{
			get
			{
				return base.#1Ac(true, #Phc.#3hc(107407776));
			}
			set
			{
				base.#0Ac(value, #Phc.#3hc(107407776));
			}
		}

		// Token: 0x0600150F RID: 5391 RVA: 0x000B0FE8 File Offset: 0x000AF1E8
		public void #gJ(#xse #ng)
		{
			if (#ng == null)
			{
				return;
			}
			base.#0Ac(#ng.Diagram2DMMAutomaticallyIncludeLargestCapacityRatio, #Phc.#3hc(107407759));
			base.#0Ac(#ng.Diagram2DMMAutomaticallyIncludeAtAxialLoads, #Phc.#3hc(107407690));
			base.#0Ac(#ng.Diagram2DMMAutomaticallyIncludeWithCapacityRatioGreaterThan, #Phc.#3hc(107407629));
			base.#5Ac(#ng.Diagram2DMMAutomaticallyIncludeCapacityRatioThreshold, #Phc.#3hc(107407068));
			base.#6Ac(#ng.Diagram2DMMAutomaticallyIncludeAtSpecifiedAxialLoads, #Phc.#3hc(107406995));
			base.#0Ac(#ng.Diagram2DMMIncludeAll, #Phc.#3hc(107406890));
			base.#0Ac(#ng.Diagram2DPMAutomaticallyIncludeLargestCapacityRatio, #Phc.#3hc(107406861));
			base.#0Ac(#ng.Diagram2DPMAutomaticallyIncludeAtAngles, #Phc.#3hc(107407304));
			base.#0Ac(#ng.Diagram2DPMAutomaticallyIncludeWithCapacityRatioGreaterThan, #Phc.#3hc(107407283));
			base.#5Ac(#ng.Diagram2DPMAutomaticallyIncludeCapacityRatioThreshold, #Phc.#3hc(107407170));
			base.#6Ac(#ng.Diagram2DPMAutomaticallyIncludeAtSpecifiedAngles, #Phc.#3hc(107407129));
			base.#0Ac(#ng.Diagram2DPMIncludeAll, #Phc.#3hc(107406552));
		}

		// Token: 0x06001510 RID: 5392 RVA: 0x000B1120 File Offset: 0x000AF320
		public #xse #hJ()
		{
			#xse #xse = #xse.Default;
			#xse #xse2;
			if (!false)
			{
				#xse2 = #xse;
			}
			return new #xse
			{
				Diagram2DMMAutomaticallyIncludeLargestCapacityRatio = base.#1Ac(#xse2.Diagram2DMMAutomaticallyIncludeLargestCapacityRatio, #Phc.#3hc(107407759)),
				Diagram2DMMAutomaticallyIncludeAtAxialLoads = base.#1Ac(#xse2.Diagram2DMMAutomaticallyIncludeAtAxialLoads, #Phc.#3hc(107407690)),
				Diagram2DMMAutomaticallyIncludeWithCapacityRatioGreaterThan = base.#1Ac(#xse2.Diagram2DMMAutomaticallyIncludeWithCapacityRatioGreaterThan, #Phc.#3hc(107407629)),
				Diagram2DMMAutomaticallyIncludeCapacityRatioThreshold = base.#4Ac(#xse2.Diagram2DMMAutomaticallyIncludeCapacityRatioThreshold, #Phc.#3hc(107407068)),
				Diagram2DMMAutomaticallyIncludeAtSpecifiedAxialLoads = base.#9Ac(#xse2.Diagram2DMMAutomaticallyIncludeAtSpecifiedAxialLoads, #Phc.#3hc(107406995)),
				Diagram2DPMAutomaticallyIncludeLargestCapacityRatio = base.#1Ac(#xse2.Diagram2DPMAutomaticallyIncludeLargestCapacityRatio, #Phc.#3hc(107406861)),
				Diagram2DPMAutomaticallyIncludeAtAngles = base.#1Ac(#xse2.Diagram2DPMAutomaticallyIncludeAtAngles, #Phc.#3hc(107407304)),
				Diagram2DPMAutomaticallyIncludeWithCapacityRatioGreaterThan = base.#1Ac(#xse2.Diagram2DPMAutomaticallyIncludeWithCapacityRatioGreaterThan, #Phc.#3hc(107407283)),
				Diagram2DPMAutomaticallyIncludeCapacityRatioThreshold = base.#4Ac(#xse2.Diagram2DPMAutomaticallyIncludeCapacityRatioThreshold, #Phc.#3hc(107407170)),
				Diagram2DPMAutomaticallyIncludeAtSpecifiedAngles = base.#9Ac(#xse2.Diagram2DPMAutomaticallyIncludeAtSpecifiedAngles, #Phc.#3hc(107407129)),
				Diagram2DPMIncludeAll = base.#1Ac(#xse2.Diagram2DPMIncludeAll, #Phc.#3hc(107406552)),
				Diagram2DMMIncludeAll = base.#1Ac(#xse2.Diagram2DMMIncludeAll, #Phc.#3hc(107406890))
			};
		}

		// Token: 0x06001511 RID: 5393 RVA: 0x000B12AC File Offset: 0x000AF4AC
		public void #iJ(#5re #ng)
		{
			base.#3Ac((int)#ng.TextSize, #Phc.#3hc(107406523));
			base.#XAc<Diagram2DAspectRatio>(#ng.AspectRatio, #Phc.#3hc(107406478));
			base.#XAc<Diagram2DLineType>(#ng.NominalDiagramLineType, #Phc.#3hc(107406493));
			base.#XAc<Diagram2DLineThickness>(#ng.NominalDiagramLineThickness, #Phc.#3hc(107406460));
			base.#XAc<Diagram2DLineType>(#ng.FactoredDiagramLineType, #Phc.#3hc(107406423));
			base.#XAc<Diagram2DLineThickness>(#ng.FactoredDiagramLineThickness, #Phc.#3hc(107406390));
			base.#XAc<Diagram2DLineType>(#ng.FactoredDiagramTopLineType, #Phc.#3hc(107406829));
			base.#XAc<Diagram2DLineThickness>(#ng.FactoredDiagramTopLineThickness, #Phc.#3hc(107406792));
			base.#XAc<Diagram2DLineType>(#ng.GridLineLineType, #Phc.#3hc(107406779));
			base.#XAc<ValuesOnAxesType>(#ng.ValuesOnAxes, #Phc.#3hc(107406722));
			base.#0Ac(#ng.UniformScaleForMMDiagrams, #Phc.#3hc(107406737));
			base.#0Ac(#ng.UniformScaleForPMDiagrams, #Phc.#3hc(107406668));
			base.#XAc<Diagram2DMajorGridLinesDivision>(#ng.GridLinesDivision, #Phc.#3hc(107406631));
			base.#bBc(#ng.FactoredDiagramColor, #Phc.#3hc(107406606));
			base.#bBc(#ng.NominalDiagramColor, #Phc.#3hc(107406609));
			base.#bBc(#ng.SpliceLinesColor, #Phc.#3hc(107406068));
			base.#bBc(#ng.InnerLoadPointsColor, #Phc.#3hc(107406043));
			base.#bBc(#ng.OuterLoadPointsColor, #Phc.#3hc(107406014));
			base.#bBc(#ng.SelectedLoadPointsColor, #Phc.#3hc(107412422));
			base.#bBc(#ng.HoverLoadPointsColor, #Phc.#3hc(107405953));
			base.#bBc(#ng.MainGridLinesColor, #Phc.#3hc(107410156));
			base.#bBc(#ng.ScreenBackgroundColor, #Phc.#3hc(107405924));
			base.#0Ac(#ng.ShowLoadPoints, #Phc.#3hc(107405895));
			base.#0Ac(#ng.ShowLoadPointsLabels, #Phc.#3hc(107405906));
			base.#0Ac(#ng.ShowAxialLoadLabels, #Phc.#3hc(107405877));
			base.#0Ac(#ng.ShowSpliceLines, #Phc.#3hc(107405848));
			base.#0Ac(#ng.ShowFactoredDiagramTop, #Phc.#3hc(107406307));
			base.#0Ac(#ng.ShowNominal, #Phc.#3hc(107407825));
			base.#0Ac(#ng.ShowFactored, #Phc.#3hc(107407776));
			base.#XAc<Diagram2DLineThickness>(#ng.GridLineThickness, #Phc.#3hc(107406274));
			base.#XAc<Diagram2DLineType>(#ng.AxesLineType, #Phc.#3hc(107406249));
			base.#XAc<Diagram2DLineThickness>(#ng.AxesLineThickness, #Phc.#3hc(107406264));
			base.#XAc<Diagram2DLineThickness>(#ng.TicksLineThickness, #Phc.#3hc(107406239));
			base.#bBc(#ng.AxesColor, #Phc.#3hc(107406182));
			base.#0Ac(#ng.ShowGrid, #Phc.#3hc(107406201));
			base.#XAc<Diagram2DLoadPointSize>(#ng.LoadPointSize, #Phc.#3hc(107406156));
			base.#0Ac(#ng.ShowCapacityRatioPoints, #Phc.#3hc(107406167));
			base.#3Ac(#ng.MaxDisplayedLoadPoints, #Phc.#3hc(107411835));
		}

		// Token: 0x06001512 RID: 5394 RVA: 0x000B161C File Offset: 0x000AF81C
		public #5re #jJ()
		{
			#5re #5re = #5re.Default;
			return new #5re
			{
				TextSize = (float)base.#2Ac((int)#5re.TextSize, #Phc.#3hc(107406523)),
				AspectRatio = base.#YAc<Diagram2DAspectRatio>(#5re.AspectRatio, #Phc.#3hc(107406478)),
				NominalDiagramLineType = base.#YAc<Diagram2DLineType>(#5re.NominalDiagramLineType, #Phc.#3hc(107406493)),
				NominalDiagramLineThickness = base.#YAc<Diagram2DLineThickness>(#5re.NominalDiagramLineThickness, #Phc.#3hc(107406460)),
				FactoredDiagramLineType = base.#YAc<Diagram2DLineType>(#5re.FactoredDiagramLineType, #Phc.#3hc(107406423)),
				FactoredDiagramLineThickness = base.#YAc<Diagram2DLineThickness>(#5re.FactoredDiagramLineThickness, #Phc.#3hc(107406390)),
				FactoredDiagramTopLineType = base.#YAc<Diagram2DLineType>(#5re.FactoredDiagramTopLineType, #Phc.#3hc(107406829)),
				FactoredDiagramTopLineThickness = base.#YAc<Diagram2DLineThickness>(#5re.FactoredDiagramTopLineThickness, #Phc.#3hc(107406792)),
				GridLineLineType = base.#YAc<Diagram2DLineType>(#5re.GridLineLineType, #Phc.#3hc(107406779)),
				ValuesOnAxes = base.#YAc<ValuesOnAxesType>(#5re.ValuesOnAxes, #Phc.#3hc(107406722)),
				UniformScaleForMMDiagrams = base.#1Ac(#5re.UniformScaleForMMDiagrams, #Phc.#3hc(107406737)),
				UniformScaleForPMDiagrams = base.#1Ac(#5re.UniformScaleForPMDiagrams, #Phc.#3hc(107406668)),
				GridLinesDivision = base.#YAc<Diagram2DMajorGridLinesDivision>(#5re.GridLinesDivision, #Phc.#3hc(107406631)),
				FactoredDiagramColor = base.#aBc(#5re.FactoredDiagramColor, #Phc.#3hc(107406606)),
				NominalDiagramColor = base.#aBc(#5re.NominalDiagramColor, #Phc.#3hc(107406609)),
				SpliceLinesColor = base.#aBc(#5re.SpliceLinesColor, #Phc.#3hc(107406068)),
				InnerLoadPointsColor = base.#aBc(#5re.InnerLoadPointsColor, #Phc.#3hc(107406043)),
				OuterLoadPointsColor = base.#aBc(#5re.OuterLoadPointsColor, #Phc.#3hc(107406014)),
				SelectedLoadPointsColor = base.#aBc(#5re.SelectedLoadPointsColor, #Phc.#3hc(107412422)),
				HoverLoadPointsColor = base.#aBc(#5re.HoverLoadPointsColor, #Phc.#3hc(107405953)),
				MainGridLinesColor = base.#aBc(#5re.MainGridLinesColor, #Phc.#3hc(107410156)),
				ScreenBackgroundColor = base.#aBc(#5re.ScreenBackgroundColor, #Phc.#3hc(107405924)),
				ShowLoadPoints = base.#1Ac(#5re.ShowLoadPoints, #Phc.#3hc(107405895)),
				ShowLoadPointsLabels = base.#1Ac(#5re.ShowLoadPointsLabels, #Phc.#3hc(107405906)),
				ShowAxialLoadLabels = base.#1Ac(#5re.ShowAxialLoadLabels, #Phc.#3hc(107405877)),
				ShowSpliceLines = base.#1Ac(#5re.ShowSpliceLines, #Phc.#3hc(107405848)),
				ShowFactoredDiagramTop = base.#1Ac(#5re.ShowFactoredDiagramTop, #Phc.#3hc(107406307)),
				ShowNominal = base.#1Ac(#5re.ShowNominal, #Phc.#3hc(107407825)),
				ShowFactored = base.#1Ac(#5re.ShowFactored, #Phc.#3hc(107407776)),
				TicksLineThickness = base.#YAc<Diagram2DLineThickness>(#5re.TicksLineThickness, #Phc.#3hc(107406239)),
				GridLineThickness = base.#YAc<Diagram2DLineThickness>(#5re.GridLineThickness, #Phc.#3hc(107406274)),
				AxesLineType = base.#YAc<Diagram2DLineType>(#5re.AxesLineType, #Phc.#3hc(107406249)),
				AxesLineThickness = base.#YAc<Diagram2DLineThickness>(#5re.AxesLineThickness, #Phc.#3hc(107406264)),
				AxesColor = base.#aBc(#5re.AxesColor, #Phc.#3hc(107406182)),
				ShowGrid = base.#1Ac(#5re.ShowGrid, #Phc.#3hc(107406201)),
				LoadPointSize = base.#YAc<Diagram2DLoadPointSize>(#5re.LoadPointSize, #Phc.#3hc(107406156)),
				ShowCapacityRatioPoints = base.#1Ac(#5re.ShowCapacityRatioPoints, #Phc.#3hc(107406167)),
				MaxDisplayedLoadPoints = base.#2Ac(#5re.MaxDisplayedLoadPoints, #Phc.#3hc(107411835))
			};
		}

		// Token: 0x06001513 RID: 5395 RVA: 0x000B1A7C File Offset: 0x000AFC7C
		public #Gse #kJ()
		{
			#8re #8re = #8re.Defaults;
			return new #Gse
			{
				CapacityRatioFilterValue = base.#4Ac(#8re.CapacityRatioFilterValue, #Phc.#3hc(107406134)),
				IsCapacityRatioFilterActive = base.#1Ac(#8re.IsCapacityRatioFilterActive, #Phc.#3hc(107406101)),
				LocationFilter = base.#9Ac(#8re.LocationFilter, #Phc.#3hc(107405552)),
				IsLocationFilterActive = base.#1Ac(#8re.IsLocationFilterActive, #Phc.#3hc(107405531)),
				HighlightCapacityRatioColor = base.#aBc(#Gse.Default.HighlightCapacityRatioColor, #Phc.#3hc(107405498)),
				CapacityRatioCalculationMethod = base.#YAc<SectionCapacityMethodType>(#Gse.Default.CapacityRatioCalculationMethod, #Phc.#3hc(107405461)),
				HighlightCapacityRatioWithThreshold = base.#1Ac(#Gse.Default.HighlightCapacityRatioWithThreshold, #Phc.#3hc(107405388)),
				IsVisibilityFilterActive = base.#1Ac(#Gse.Default.IsVisibilityFilterActive, #Phc.#3hc(107405371))
			};
		}

		// Token: 0x06001514 RID: 5396 RVA: 0x000B1BA4 File Offset: 0x000AFDA4
		public void #lJ(#Gse #mJ)
		{
			base.#5Ac(#mJ.CapacityRatioFilterValue, #Phc.#3hc(107406134));
			base.#0Ac(#mJ.IsCapacityRatioFilterActive, #Phc.#3hc(107406101));
			base.#6Ac(#mJ.LocationFilter, #Phc.#3hc(107405552));
			base.#0Ac(#mJ.IsLocationFilterActive, #Phc.#3hc(107405531));
			base.#bBc(#mJ.HighlightCapacityRatioColor, #Phc.#3hc(107405498));
			base.#0Ac(#mJ.IsVisibilityFilterActive, #Phc.#3hc(107405371));
		}

		// Token: 0x06001515 RID: 5397 RVA: 0x00016305 File Offset: 0x00014505
		#55d #yse.#nJ()
		{
			return base.UserSettingProvider;
		}

		// Token: 0x06001516 RID: 5398 RVA: 0x00016315 File Offset: 0x00014515
		#55d #yse.#oJ()
		{
			return base.ApplicationSettingProvider;
		}
	}
}
