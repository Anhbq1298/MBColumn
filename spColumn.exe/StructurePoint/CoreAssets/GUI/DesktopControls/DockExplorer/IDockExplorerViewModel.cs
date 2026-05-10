using System;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.DockExplorer
{
	// Token: 0x020008B6 RID: 2230
	public interface IDockExplorerViewModel
	{
		// Token: 0x0600463B RID: 17979
		void Show();

		// Token: 0x0600463C RID: 17980
		void MoveToNext();

		// Token: 0x0600463D RID: 17981
		void Close();

		// Token: 0x17001491 RID: 5265
		// (get) Token: 0x0600463E RID: 17982
		bool IsHidden { get; }
	}
}
