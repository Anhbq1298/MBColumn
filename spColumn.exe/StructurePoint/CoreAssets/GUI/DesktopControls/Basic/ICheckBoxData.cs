using System;
using System.Windows.Input;
using System.Windows.Media;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000A86 RID: 2694
	public interface ICheckBoxData
	{
		// Token: 0x17001913 RID: 6419
		// (get) Token: 0x060057F4 RID: 22516
		// (set) Token: 0x060057F5 RID: 22517
		object Content { get; set; }

		// Token: 0x17001914 RID: 6420
		// (get) Token: 0x060057F6 RID: 22518
		// (set) Token: 0x060057F7 RID: 22519
		bool IsEnabled { get; set; }

		// Token: 0x17001915 RID: 6421
		// (get) Token: 0x060057F8 RID: 22520
		// (set) Token: 0x060057F9 RID: 22521
		bool IsChecked { get; set; }

		// Token: 0x17001916 RID: 6422
		// (get) Token: 0x060057FA RID: 22522
		// (set) Token: 0x060057FB RID: 22523
		ICommand Command { get; set; }

		// Token: 0x17001917 RID: 6423
		// (get) Token: 0x060057FC RID: 22524
		// (set) Token: 0x060057FD RID: 22525
		Color? Color { get; set; }
	}
}
