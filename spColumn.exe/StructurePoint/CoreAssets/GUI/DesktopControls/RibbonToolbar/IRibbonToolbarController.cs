using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.RibbonToolbar
{
	// Token: 0x020008F1 RID: 2289
	public interface IRibbonToolbarController
	{
		// Token: 0x17001546 RID: 5446
		// (get) Token: 0x060048D2 RID: 18642
		IList<RibbonToolbarGroup> Groups { get; }

		// Token: 0x17001547 RID: 5447
		// (get) Token: 0x060048D3 RID: 18643
		// (set) Token: 0x060048D4 RID: 18644
		Orientation Orientation { get; set; }

		// Token: 0x17001548 RID: 5448
		// (get) Token: 0x060048D5 RID: 18645
		// (set) Token: 0x060048D6 RID: 18646
		Visibility Visibility { get; set; }

		// Token: 0x17001549 RID: 5449
		// (get) Token: 0x060048D7 RID: 18647
		// (set) Token: 0x060048D8 RID: 18648
		Visibility SeparatorsVisibility { get; set; }

		// Token: 0x1700154A RID: 5450
		// (get) Token: 0x060048D9 RID: 18649
		// (set) Token: 0x060048DA RID: 18650
		Thickness ButtonsBorderThickness { get; set; }

		// Token: 0x1700154B RID: 5451
		// (get) Token: 0x060048DB RID: 18651
		// (set) Token: 0x060048DC RID: 18652
		Brush ButtonsBorderBrush { get; set; }

		// Token: 0x1700154C RID: 5452
		// (get) Token: 0x060048DD RID: 18653
		// (set) Token: 0x060048DE RID: 18654
		Brush ButtonsBackground { get; set; }

		// Token: 0x1700154D RID: 5453
		// (get) Token: 0x060048DF RID: 18655
		// (set) Token: 0x060048E0 RID: 18656
		IEditionToolData SelectedToolData { get; set; }

		// Token: 0x1700154E RID: 5454
		// (get) Token: 0x060048E1 RID: 18657
		// (set) Token: 0x060048E2 RID: 18658
		IRibbonToolbarButton IncreaseToolbarButton { get; set; }

		// Token: 0x1700154F RID: 5455
		// (get) Token: 0x060048E3 RID: 18659
		// (set) Token: 0x060048E4 RID: 18660
		IRibbonToolbarButton DecreaseToolbarButton { get; set; }

		// Token: 0x140000F2 RID: 242
		// (add) Token: 0x060048E5 RID: 18661
		// (remove) Token: 0x060048E6 RID: 18662
		event EventHandler<SelectedItemChangedEventArgs<IEditionToolData>> SelectedToolChanged;

		// Token: 0x060048E7 RID: 18663
		void ActivateTool(IEditionToolData tool);
	}
}
