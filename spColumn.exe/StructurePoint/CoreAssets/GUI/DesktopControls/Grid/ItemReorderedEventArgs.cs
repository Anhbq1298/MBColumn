using System;
using System.Windows;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Grid
{
	// Token: 0x020009B5 RID: 2485
	public sealed class ItemReorderedEventArgs : RoutedEventArgs
	{
		// Token: 0x06005095 RID: 20629 RVA: 0x00043239 File Offset: 0x00041439
		public ItemReorderedEventArgs(int oldIndex, int newIndex)
		{
			this.OldIndex = oldIndex;
			this.NewIndex = newIndex;
		}

		// Token: 0x06005096 RID: 20630 RVA: 0x0004324F File Offset: 0x0004144F
		public ItemReorderedEventArgs(RoutedEvent routedEvent, int oldIndex, int newIndex) : base(routedEvent)
		{
			this.OldIndex = oldIndex;
			this.NewIndex = newIndex;
		}

		// Token: 0x06005097 RID: 20631 RVA: 0x00043266 File Offset: 0x00041466
		public ItemReorderedEventArgs(RoutedEvent routedEvent, object source, int oldIndex, int newIndex) : base(routedEvent, source)
		{
			this.OldIndex = oldIndex;
			this.NewIndex = newIndex;
		}

		// Token: 0x17001723 RID: 5923
		// (get) Token: 0x06005098 RID: 20632 RVA: 0x0004327F File Offset: 0x0004147F
		// (set) Token: 0x06005099 RID: 20633 RVA: 0x0004328B File Offset: 0x0004148B
		public int OldIndex { get; set; }

		// Token: 0x17001724 RID: 5924
		// (get) Token: 0x0600509A RID: 20634 RVA: 0x0004329C File Offset: 0x0004149C
		// (set) Token: 0x0600509B RID: 20635 RVA: 0x000432A8 File Offset: 0x000414A8
		public int NewIndex { get; set; }
	}
}
