using System;
using System.Windows.Input;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000A82 RID: 2690
	public interface IButtonData
	{
		// Token: 0x17001907 RID: 6407
		// (get) Token: 0x060057D3 RID: 22483
		// (set) Token: 0x060057D4 RID: 22484
		object Content { get; set; }

		// Token: 0x17001908 RID: 6408
		// (get) Token: 0x060057D5 RID: 22485
		// (set) Token: 0x060057D6 RID: 22486
		bool IsEnabled { get; set; }

		// Token: 0x17001909 RID: 6409
		// (get) Token: 0x060057D7 RID: 22487
		// (set) Token: 0x060057D8 RID: 22488
		ICommand Command { get; set; }

		// Token: 0x1700190A RID: 6410
		// (get) Token: 0x060057D9 RID: 22489
		// (set) Token: 0x060057DA RID: 22490
		object CommandParameter { get; set; }
	}
}
