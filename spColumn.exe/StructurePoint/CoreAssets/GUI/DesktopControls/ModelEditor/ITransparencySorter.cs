using System;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor
{
	// Token: 0x02000932 RID: 2354
	public interface ITransparencySorter
	{
		// Token: 0x17001657 RID: 5719
		// (get) Token: 0x06004CBF RID: 19647
		// (set) Token: 0x06004CC0 RID: 19648
		CustomSortingModeType CustomSortingMode { get; set; }

		// Token: 0x17001658 RID: 5720
		// (get) Token: 0x06004CC1 RID: 19649
		// (set) Token: 0x06004CC2 RID: 19650
		bool AreManualOperationsEnabled { get; set; }

		// Token: 0x06004CC3 RID: 19651
		IBulkUpdateScope BeginBulkUpdate();

		// Token: 0x06004CC4 RID: 19652
		void PerformTransparencySort();

		// Token: 0x06004CC5 RID: 19653
		void PerformSimpleTransparencySort();

		// Token: 0x06004CC6 RID: 19654
		void AddExcludedVisual(IDrawingResult drawingResult);

		// Token: 0x06004CC7 RID: 19655
		void AddAlwaysOnTopVisual(IDrawingResult drawingResult);

		// Token: 0x06004CC8 RID: 19656
		void RemoveAlwaysOnTopVisual(IDrawingResult drawingResult);

		// Token: 0x06004CC9 RID: 19657
		void ConfigureTransparencySorting(double angle, CustomSortingModeType customSortingMode);

		// Token: 0x06004CCA RID: 19658
		void StartTransparencySorting();

		// Token: 0x06004CCB RID: 19659
		void RecollectTransparentModels();

		// Token: 0x06004CCC RID: 19660
		void Refresh();
	}
}
