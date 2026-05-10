using System;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Ribbon
{
	// Token: 0x020008A6 RID: 2214
	public sealed class ToggleButtonIsCheckedChangedEventArgs : EventArgs
	{
		// Token: 0x060045D6 RID: 17878 RVA: 0x0003A5A8 File Offset: 0x000387A8
		public ToggleButtonIsCheckedChangedEventArgs(object tag, bool isChecked)
		{
			this.IsChecked = isChecked;
			this.Tag = tag;
		}

		// Token: 0x17001469 RID: 5225
		// (get) Token: 0x060045D7 RID: 17879 RVA: 0x0003A5BE File Offset: 0x000387BE
		// (set) Token: 0x060045D8 RID: 17880 RVA: 0x0003A5CA File Offset: 0x000387CA
		public object Tag { get; private set; }

		// Token: 0x1700146A RID: 5226
		// (get) Token: 0x060045D9 RID: 17881 RVA: 0x0003A5DB File Offset: 0x000387DB
		// (set) Token: 0x060045DA RID: 17882 RVA: 0x0003A5E7 File Offset: 0x000387E7
		public bool IsChecked { get; private set; }
	}
}
