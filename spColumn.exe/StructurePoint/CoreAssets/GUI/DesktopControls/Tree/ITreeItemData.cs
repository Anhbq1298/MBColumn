using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows.Media;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Tree
{
	// Token: 0x020008E4 RID: 2276
	public interface ITreeItemData
	{
		// Token: 0x1700151F RID: 5407
		// (get) Token: 0x06004834 RID: 18484
		// (set) Token: 0x06004835 RID: 18485
		string Header { get; set; }

		// Token: 0x17001520 RID: 5408
		// (get) Token: 0x06004836 RID: 18486
		// (set) Token: 0x06004837 RID: 18487
		ICommand Command { get; set; }

		// Token: 0x17001521 RID: 5409
		// (get) Token: 0x06004838 RID: 18488
		// (set) Token: 0x06004839 RID: 18489
		object CommandParameter { get; set; }

		// Token: 0x17001522 RID: 5410
		// (get) Token: 0x0600483A RID: 18490
		// (set) Token: 0x0600483B RID: 18491
		IEnumerable Items { get; set; }

		// Token: 0x17001523 RID: 5411
		// (get) Token: 0x0600483C RID: 18492
		// (set) Token: 0x0600483D RID: 18493
		bool IsExpanded { get; set; }

		// Token: 0x17001524 RID: 5412
		// (get) Token: 0x0600483E RID: 18494
		// (set) Token: 0x0600483F RID: 18495
		bool IsSelected { get; set; }

		// Token: 0x17001525 RID: 5413
		// (get) Token: 0x06004840 RID: 18496
		// (set) Token: 0x06004841 RID: 18497
		bool IsContextMenuEnabled { get; set; }

		// Token: 0x17001526 RID: 5414
		// (get) Token: 0x06004842 RID: 18498
		ICollection<IContextMenuItemData> ContextMenuItemsSource { get; }

		// Token: 0x17001527 RID: 5415
		// (get) Token: 0x06004843 RID: 18499
		// (set) Token: 0x06004844 RID: 18500
		bool IsMarkerEnabled { get; set; }

		// Token: 0x17001528 RID: 5416
		// (get) Token: 0x06004845 RID: 18501
		// (set) Token: 0x06004846 RID: 18502
		Color MarkerColor { get; set; }

		// Token: 0x17001529 RID: 5417
		// (get) Token: 0x06004847 RID: 18503
		// (set) Token: 0x06004848 RID: 18504
		object Tag { get; set; }

		// Token: 0x1700152A RID: 5418
		// (get) Token: 0x06004849 RID: 18505
		// (set) Token: 0x0600484A RID: 18506
		bool ShrinkIconColumn { get; set; }

		// Token: 0x1700152B RID: 5419
		// (get) Token: 0x0600484B RID: 18507
		// (set) Token: 0x0600484C RID: 18508
		object Icon { get; set; }

		// Token: 0x1700152C RID: 5420
		// (get) Token: 0x0600484D RID: 18509
		// (set) Token: 0x0600484E RID: 18510
		bool IsIconVisible { get; set; }

		// Token: 0x1700152D RID: 5421
		// (get) Token: 0x0600484F RID: 18511
		// (set) Token: 0x06004850 RID: 18512
		bool IsCheckable { get; set; }

		// Token: 0x1700152E RID: 5422
		// (get) Token: 0x06004851 RID: 18513
		// (set) Token: 0x06004852 RID: 18514
		bool IsChecked { get; set; }

		// Token: 0x1700152F RID: 5423
		// (get) Token: 0x06004853 RID: 18515
		// (set) Token: 0x06004854 RID: 18516
		bool IsSeparator { get; set; }

		// Token: 0x140000EA RID: 234
		// (add) Token: 0x06004855 RID: 18517
		// (remove) Token: 0x06004856 RID: 18518
		event EventHandler IsCheckedChanged;
	}
}
