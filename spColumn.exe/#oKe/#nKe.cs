using System;
using System.Collections.Generic;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Settings;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.Units;

namespace #oKe
{
	// Token: 0x02001268 RID: 4712
	internal interface #nKe
	{
		// Token: 0x17002D93 RID: 11667
		// (get) Token: 0x06009E1C RID: 40476
		IDictionary<DesignCodes, string> AvailableDesignCodes { get; }

		// Token: 0x17002D94 RID: 11668
		// (get) Token: 0x06009E1D RID: 40477
		IDictionary<UnitSystem, string> AvailableUnitSystems { get; }

		// Token: 0x17002D95 RID: 11669
		// (get) Token: 0x06009E1E RID: 40478
		IDictionary<BarGroupType, string> AvailableBarGroupTypes { get; }

		// Token: 0x17002D96 RID: 11670
		// (get) Token: 0x06009E1F RID: 40479
		IDictionary<ConfinementType, string> AvailableConfinementTypes { get; }

		// Token: 0x17002D97 RID: 11671
		// (get) Token: 0x06009E20 RID: 40480
		IDictionary<ProblemType, string> AvailableProblemTypes { get; }

		// Token: 0x17002D98 RID: 11672
		// (get) Token: 0x06009E21 RID: 40481
		IDictionary<ConsideredAxis, string> AvailableConsideredAxes { get; }

		// Token: 0x17002D99 RID: 11673
		// (get) Token: 0x06009E22 RID: 40482
		IDictionary<SectionCapacityMethodType, string> AvailableSectionCapacity { get; }

		// Token: 0x17002D9A RID: 11674
		// (get) Token: 0x06009E23 RID: 40483
		IDictionary<LoadType, string> AvailableLoadTypes { get; }

		// Token: 0x17002D9B RID: 11675
		// (get) Token: 0x06009E24 RID: 40484
		IDictionary<bool, string> YesNo { get; }

		// Token: 0x17002D9C RID: 11676
		// (get) Token: 0x06009E25 RID: 40485
		IEnumerable<int> AvailableLabelSizes { get; }

		// Token: 0x17002D9D RID: 11677
		// (get) Token: 0x06009E26 RID: 40486
		IDictionary<Diagram2DTextSize, string> AvailableDiagram2DTextSize { get; }

		// Token: 0x17002D9E RID: 11678
		// (get) Token: 0x06009E27 RID: 40487
		IDictionary<Diagram2DLoadPointSize, string> AvailableDiagram2DLoadPointSize { get; }

		// Token: 0x17002D9F RID: 11679
		// (get) Token: 0x06009E28 RID: 40488
		IDictionary<Diagram2DAspectRatio, string> AvailableDiagram2DAspectRatio { get; }

		// Token: 0x17002DA0 RID: 11680
		// (get) Token: 0x06009E29 RID: 40489
		IDictionary<Diagram2DLineType, string> AvailableDiagram2DLineType { get; }

		// Token: 0x17002DA1 RID: 11681
		// (get) Token: 0x06009E2A RID: 40490
		IDictionary<Diagram2DLineThickness, string> AvailableDiagram2DLineThickness { get; }

		// Token: 0x17002DA2 RID: 11682
		// (get) Token: 0x06009E2B RID: 40491
		IDictionary<ValuesOnAxesType, string> AvailableDiagram2DValuesOnAxesType { get; }

		// Token: 0x17002DA3 RID: 11683
		// (get) Token: 0x06009E2C RID: 40492
		IDictionary<CameraType, string> AvailableDiagram3DCameraTypes { get; }

		// Token: 0x17002DA4 RID: 11684
		// (get) Token: 0x06009E2D RID: 40493
		IDictionary<double, string> AvailableLinesThickness { get; }

		// Token: 0x17002DA5 RID: 11685
		// (get) Token: 0x06009E2E RID: 40494
		IDictionary<double, string> AvailableLoadPointSize { get; }
	}
}
