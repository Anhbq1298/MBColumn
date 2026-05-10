using System;
using StructurePoint.CoreAssets.GUI.DesktopControls;

namespace #eU
{
	// Token: 0x020002A7 RID: 679
	internal interface #wU
	{
		// Token: 0x170007DE RID: 2014
		// (get) Token: 0x06001619 RID: 5657
		IDelegateCommandProxy Undo { get; }

		// Token: 0x170007DF RID: 2015
		// (get) Token: 0x0600161A RID: 5658
		IDelegateCommandProxy Redo { get; }

		// Token: 0x170007E0 RID: 2016
		// (get) Token: 0x0600161B RID: 5659
		IDelegateCommandProxy Save { get; }

		// Token: 0x170007E1 RID: 2017
		// (get) Token: 0x0600161C RID: 5660
		IDelegateCommandProxy SaveAs { get; }

		// Token: 0x170007E2 RID: 2018
		// (get) Token: 0x0600161D RID: 5661
		IDelegateCommandProxy Open { get; }

		// Token: 0x170007E3 RID: 2019
		// (get) Token: 0x0600161E RID: 5662
		IDelegateCommandProxy OpenExamples { get; }

		// Token: 0x170007E4 RID: 2020
		// (get) Token: 0x0600161F RID: 5663
		IDelegateCommandProxy New { get; }

		// Token: 0x170007E5 RID: 2021
		// (get) Token: 0x06001620 RID: 5664
		IDelegateCommandProxy OpenSolver { get; }

		// Token: 0x170007E6 RID: 2022
		// (get) Token: 0x06001621 RID: 5665
		IDelegateCommandProxy OpenSuperImpose { get; }

		// Token: 0x170007E7 RID: 2023
		// (get) Token: 0x06001622 RID: 5666
		IDelegateCommandProxy OpenReporter { get; }

		// Token: 0x170007E8 RID: 2024
		// (get) Token: 0x06001623 RID: 5667
		IDelegateCommandProxy OpenResults { get; }

		// Token: 0x170007E9 RID: 2025
		// (get) Token: 0x06001624 RID: 5668
		IDelegateCommandProxy OpenSettings { get; }

		// Token: 0x170007EA RID: 2026
		// (get) Token: 0x06001625 RID: 5669
		IDelegateCommandProxy Close { get; }

		// Token: 0x170007EB RID: 2027
		// (get) Token: 0x06001626 RID: 5670
		IDelegateCommandProxy ActivateScopeWithParameters { get; }

		// Token: 0x170007EC RID: 2028
		// (get) Token: 0x06001627 RID: 5671
		IDelegateCommandProxy ActivateDiagramWithParameters { get; }

		// Token: 0x170007ED RID: 2029
		// (get) Token: 0x06001628 RID: 5672
		IDelegateCommandProxy AddToReport { get; }

		// Token: 0x170007EE RID: 2030
		// (get) Token: 0x06001629 RID: 5673
		IDelegateCommandProxy PrintExport { get; }

		// Token: 0x170007EF RID: 2031
		// (get) Token: 0x0600162A RID: 5674
		IDelegateCommandProxy CleanReport { get; }

		// Token: 0x170007F0 RID: 2032
		// (get) Token: 0x0600162B RID: 5675
		IDelegateCommandProxy ExportSection { get; }

		// Token: 0x170007F1 RID: 2033
		// (get) Token: 0x0600162C RID: 5676
		IDelegateCommandProxy ExportLoads { get; }

		// Token: 0x170007F2 RID: 2034
		// (get) Token: 0x0600162D RID: 5677
		IDelegateCommandProxy ExportDiagram2D { get; }

		// Token: 0x170007F3 RID: 2035
		// (get) Token: 0x0600162E RID: 5678
		IDelegateCommandProxy ExportDiagram3D { get; }

		// Token: 0x170007F4 RID: 2036
		// (get) Token: 0x0600162F RID: 5679
		IDelegateCommandProxy ImportSection { get; }

		// Token: 0x170007F5 RID: 2037
		// (get) Token: 0x06001630 RID: 5680
		IDelegateCommandProxy ImportLoads { get; }

		// Token: 0x170007F6 RID: 2038
		// (get) Token: 0x06001631 RID: 5681
		IDelegateCommandProxy ExportDxf { get; }

		// Token: 0x170007F7 RID: 2039
		// (get) Token: 0x06001632 RID: 5682
		IDelegateCommandProxy ImportDxf { get; }

		// Token: 0x170007F8 RID: 2040
		// (get) Token: 0x06001633 RID: 5683
		IDelegateCommandProxy ChangeUnitSystem { get; }

		// Token: 0x170007F9 RID: 2041
		// (get) Token: 0x06001634 RID: 5684
		IDelegateCommandProxy ChangeSectionType { get; }

		// Token: 0x170007FA RID: 2042
		// (get) Token: 0x06001635 RID: 5685
		IDelegateCommandProxy StartDesignTrace { get; }

		// Token: 0x06001636 RID: 5686
		void #cg();
	}
}
