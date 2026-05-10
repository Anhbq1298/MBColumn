using System;
using System.Collections.Generic;
using System.IO;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Docking
{
	// Token: 0x020009A5 RID: 2469
	public interface IDockingController
	{
		// Token: 0x17001705 RID: 5893
		// (get) Token: 0x06005021 RID: 20513
		IEnumerable<DockableViewController> DockableViewControllers { get; }

		// Token: 0x06005022 RID: 20514
		IDockableViewController GetOrOpenView(IDockableView dockableView, DockableViewStartOptions dockableViewStartOptions);

		// Token: 0x06005023 RID: 20515
		void SetTitle(IDockableView dockableView, string title);

		// Token: 0x06005024 RID: 20516
		void SaveLayout(Stream layoutData);

		// Token: 0x06005025 RID: 20517
		void LoadLayout(Stream layoutData);

		// Token: 0x06005026 RID: 20518
		void SelectView(IDockableView dockableView);

		// Token: 0x14000130 RID: 304
		// (add) Token: 0x06005027 RID: 20519
		// (remove) Token: 0x06005028 RID: 20520
		event EventHandler<ViewLoadingEventArgs> ViewLoading;

		// Token: 0x14000131 RID: 305
		// (add) Token: 0x06005029 RID: 20521
		// (remove) Token: 0x0600502A RID: 20522
		event EventHandler<DockableViewStateChangedEventArgs> DockableViewStateChanged;
	}
}
