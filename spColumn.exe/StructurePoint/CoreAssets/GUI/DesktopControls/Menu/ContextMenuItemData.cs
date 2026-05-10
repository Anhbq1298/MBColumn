using System;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Menu
{
	// Token: 0x0200098B RID: 2443
	public sealed class ContextMenuItemData : NotifyPropertyChangedObjectBase
	{
		// Token: 0x06004F89 RID: 20361 RVA: 0x00042353 File Offset: 0x00040553
		public ContextMenuItemData(string title, string shortcut)
		{
			this.Title = title;
			this.Shortcut = shortcut;
		}

		// Token: 0x06004F8A RID: 20362 RVA: 0x00042369 File Offset: 0x00040569
		public ContextMenuItemData(string title)
		{
			this.Title = title;
		}

		// Token: 0x170016DE RID: 5854
		// (get) Token: 0x06004F8B RID: 20363 RVA: 0x00042378 File Offset: 0x00040578
		// (set) Token: 0x06004F8C RID: 20364 RVA: 0x00042384 File Offset: 0x00040584
		public string Title { get; set; }

		// Token: 0x170016DF RID: 5855
		// (get) Token: 0x06004F8D RID: 20365 RVA: 0x00042395 File Offset: 0x00040595
		// (set) Token: 0x06004F8E RID: 20366 RVA: 0x000423A1 File Offset: 0x000405A1
		public string Shortcut { get; set; }
	}
}
