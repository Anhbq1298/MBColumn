using System;

namespace StructurePoint.CoreAssets.GUI.DesktopControls
{
	// Token: 0x02000895 RID: 2197
	public sealed class SelectedItemChangedEventArgs<T> : EventArgs
	{
		// Token: 0x06004556 RID: 17750 RVA: 0x00039D96 File Offset: 0x00037F96
		public SelectedItemChangedEventArgs(T previousItem, T newItem)
		{
			this.PreviousItem = previousItem;
			this.NewItem = newItem;
		}

		// Token: 0x17001436 RID: 5174
		// (get) Token: 0x06004557 RID: 17751 RVA: 0x00039DAC File Offset: 0x00037FAC
		// (set) Token: 0x06004558 RID: 17752 RVA: 0x00039DB8 File Offset: 0x00037FB8
		public T PreviousItem { get; private set; }

		// Token: 0x17001437 RID: 5175
		// (get) Token: 0x06004559 RID: 17753 RVA: 0x00039DC9 File Offset: 0x00037FC9
		// (set) Token: 0x0600455A RID: 17754 RVA: 0x00039DD5 File Offset: 0x00037FD5
		public T NewItem { get; private set; }
	}
}
