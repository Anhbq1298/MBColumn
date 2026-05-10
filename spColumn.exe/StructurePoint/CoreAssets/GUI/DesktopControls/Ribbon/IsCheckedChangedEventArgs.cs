using System;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Ribbon
{
	// Token: 0x020008A7 RID: 2215
	internal sealed class IsCheckedChangedEventArgs<T> : EventArgs
	{
		// Token: 0x060045DB RID: 17883 RVA: 0x0003A5F8 File Offset: 0x000387F8
		public IsCheckedChangedEventArgs(bool isChecked, object value)
		{
			this.IsChecked = isChecked;
			this.Value = value;
		}

		// Token: 0x1700146B RID: 5227
		// (get) Token: 0x060045DC RID: 17884 RVA: 0x0003A60E File Offset: 0x0003880E
		// (set) Token: 0x060045DD RID: 17885 RVA: 0x0003A61A File Offset: 0x0003881A
		public bool IsChecked { get; private set; }

		// Token: 0x1700146C RID: 5228
		// (get) Token: 0x060045DE RID: 17886 RVA: 0x0003A62B File Offset: 0x0003882B
		// (set) Token: 0x060045DF RID: 17887 RVA: 0x0003A637 File Offset: 0x00038837
		public object Value { get; private set; }
	}
}
