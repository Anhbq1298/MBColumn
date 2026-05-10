using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.RibbonToolbar
{
	// Token: 0x020008F3 RID: 2291
	public interface IRibbonToolbarButton
	{
		// Token: 0x17001550 RID: 5456
		// (get) Token: 0x060048F3 RID: 18675
		// (set) Token: 0x060048F4 RID: 18676
		ICommand Command { get; set; }

		// Token: 0x17001551 RID: 5457
		// (get) Token: 0x060048F5 RID: 18677
		// (set) Token: 0x060048F6 RID: 18678
		object CommandParameter { get; set; }

		// Token: 0x17001552 RID: 5458
		// (get) Token: 0x060048F7 RID: 18679
		// (set) Token: 0x060048F8 RID: 18680
		bool IsEnabled { get; set; }

		// Token: 0x17001553 RID: 5459
		// (get) Token: 0x060048F9 RID: 18681
		// (set) Token: 0x060048FA RID: 18682
		Image LargeImage { get; set; }

		// Token: 0x17001554 RID: 5460
		// (get) Token: 0x060048FB RID: 18683
		// (set) Token: 0x060048FC RID: 18684
		Image MediumImage { get; set; }

		// Token: 0x17001555 RID: 5461
		// (get) Token: 0x060048FD RID: 18685
		// (set) Token: 0x060048FE RID: 18686
		ButtonImageSize Size { get; set; }

		// Token: 0x17001556 RID: 5462
		// (get) Token: 0x060048FF RID: 18687
		// (set) Token: 0x06004900 RID: 18688
		string Text { get; set; }

		// Token: 0x17001557 RID: 5463
		// (get) Token: 0x06004901 RID: 18689
		// (set) Token: 0x06004902 RID: 18690
		ButtonTextPosition TextPosition { get; set; }

		// Token: 0x17001558 RID: 5464
		// (get) Token: 0x06004903 RID: 18691
		// (set) Token: 0x06004904 RID: 18692
		Visibility TextVisibility { get; set; }

		// Token: 0x17001559 RID: 5465
		// (get) Token: 0x06004905 RID: 18693
		// (set) Token: 0x06004906 RID: 18694
		RichToolTipContent ToolTipContent { get; set; }

		// Token: 0x1700155A RID: 5466
		// (get) Token: 0x06004907 RID: 18695
		// (set) Token: 0x06004908 RID: 18696
		Visibility Visibility { get; set; }
	}
}
