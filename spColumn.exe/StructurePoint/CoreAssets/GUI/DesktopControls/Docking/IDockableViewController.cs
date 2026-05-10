using System;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Docking
{
	// Token: 0x020009A8 RID: 2472
	public interface IDockableViewController
	{
		// Token: 0x17001711 RID: 5905
		// (get) Token: 0x06005045 RID: 20549
		IDockableView DockableView { get; }

		// Token: 0x17001712 RID: 5906
		// (get) Token: 0x06005046 RID: 20550
		DockableViewStartOptions DockableViewStartOptions { get; }

		// Token: 0x17001713 RID: 5907
		// (get) Token: 0x06005047 RID: 20551
		// (set) Token: 0x06005048 RID: 20552
		bool IsHidden { get; set; }

		// Token: 0x17001714 RID: 5908
		// (get) Token: 0x06005049 RID: 20553
		// (set) Token: 0x0600504A RID: 20554
		bool IsActive { get; set; }

		// Token: 0x17001715 RID: 5909
		// (get) Token: 0x0600504B RID: 20555
		DateTime LastActiveAt { get; }

		// Token: 0x17001716 RID: 5910
		// (get) Token: 0x0600504C RID: 20556
		bool IsFloating { get; }

		// Token: 0x17001717 RID: 5911
		// (get) Token: 0x0600504D RID: 20557
		// (set) Token: 0x0600504E RID: 20558
		bool CanUserClose { get; set; }

		// Token: 0x17001718 RID: 5912
		// (get) Token: 0x0600504F RID: 20559
		// (set) Token: 0x06005050 RID: 20560
		bool CanUserPin { get; set; }

		// Token: 0x17001719 RID: 5913
		// (get) Token: 0x06005051 RID: 20561
		// (set) Token: 0x06005052 RID: 20562
		string Title { get; set; }

		// Token: 0x1700171A RID: 5914
		// (get) Token: 0x06005053 RID: 20563
		object ViewObject { get; }

		// Token: 0x14000133 RID: 307
		// (add) Token: 0x06005054 RID: 20564
		// (remove) Token: 0x06005055 RID: 20565
		event EventHandler<DockableViewIsActiveChangedEventArgs> IsActiveChanged;

		// Token: 0x06005056 RID: 20566
		void BringToFront();
	}
}
