using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Telerik.Windows;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor
{
	// Token: 0x02000911 RID: 2321
	public interface IFloatingControlsPanel
	{
		// Token: 0x140000F6 RID: 246
		// (add) Token: 0x060049C6 RID: 18886
		// (remove) Token: 0x060049C7 RID: 18887
		event RadRoutedEventHandler CloseMenuItemClicked;

		// Token: 0x140000F7 RID: 247
		// (add) Token: 0x060049C8 RID: 18888
		// (remove) Token: 0x060049C9 RID: 18889
		event RoutedEventHandler ControlsVisibilityChanged;

		// Token: 0x140000F8 RID: 248
		// (add) Token: 0x060049CA RID: 18890
		// (remove) Token: 0x060049CB RID: 18891
		event EventHandler ViewControlsChanged;

		// Token: 0x140000F9 RID: 249
		// (add) Token: 0x060049CC RID: 18892
		// (remove) Token: 0x060049CD RID: 18893
		event MouseEventHandler MouseEnter;

		// Token: 0x17001598 RID: 5528
		// (get) Token: 0x060049CE RID: 18894
		// (set) Token: 0x060049CF RID: 18895
		Visibility Visibility { get; set; }

		// Token: 0x17001599 RID: 5529
		// (get) Token: 0x060049D0 RID: 18896
		// (set) Token: 0x060049D1 RID: 18897
		Visibility Panel2D3DVisibilityItemsVisibility { get; set; }

		// Token: 0x1700159A RID: 5530
		// (get) Token: 0x060049D2 RID: 18898
		// (set) Token: 0x060049D3 RID: 18899
		IEnumerable<IPanelItem> BuiltInTools { get; set; }

		// Token: 0x1700159B RID: 5531
		// (get) Token: 0x060049D4 RID: 18900
		// (set) Token: 0x060049D5 RID: 18901
		IEnumerable<IPanelItem> AdditionalTools { get; set; }

		// Token: 0x1700159C RID: 5532
		// (get) Token: 0x060049D6 RID: 18902
		// (set) Token: 0x060049D7 RID: 18903
		ToolsPanelPosition SelectedPosition { get; set; }

		// Token: 0x1700159D RID: 5533
		// (get) Token: 0x060049D8 RID: 18904
		// (set) Token: 0x060049D9 RID: 18905
		Visibility IsControls2DCollapsed { get; set; }

		// Token: 0x1700159E RID: 5534
		// (get) Token: 0x060049DA RID: 18906
		// (set) Token: 0x060049DB RID: 18907
		Visibility IsControls3DCollapsed { get; set; }

		// Token: 0x1700159F RID: 5535
		// (get) Token: 0x060049DC RID: 18908
		// (set) Token: 0x060049DD RID: 18909
		string Title { get; set; }

		// Token: 0x170015A0 RID: 5536
		// (get) Token: 0x060049DE RID: 18910
		IEnumerable<RadMenuItem> MenuItems { get; }
	}
}
