using System;
using System.Collections;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Tree
{
	// Token: 0x020008E6 RID: 2278
	public interface ITreeControl
	{
		// Token: 0x17001531 RID: 5425
		// (get) Token: 0x06004865 RID: 18533
		// (set) Token: 0x06004866 RID: 18534
		IEnumerable ItemsSource { get; set; }

		// Token: 0x140000ED RID: 237
		// (add) Token: 0x06004867 RID: 18535
		// (remove) Token: 0x06004868 RID: 18536
		event EventHandler<SelectionEventArgs> PreviewSelected;

		// Token: 0x140000EE RID: 238
		// (add) Token: 0x06004869 RID: 18537
		// (remove) Token: 0x0600486A RID: 18538
		event EventHandler<SelectionEventArgs> Selected;

		// Token: 0x0600486B RID: 18539
		void RefreshView();
	}
}
