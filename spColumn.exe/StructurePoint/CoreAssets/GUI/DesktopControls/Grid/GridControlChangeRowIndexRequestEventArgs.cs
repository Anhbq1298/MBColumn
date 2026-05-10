using System;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Grid
{
	// Token: 0x020009E0 RID: 2528
	public sealed class GridControlChangeRowIndexRequestEventArgs : EventArgs
	{
		// Token: 0x060052E2 RID: 21218 RVA: 0x000448B7 File Offset: 0x00042AB7
		public GridControlChangeRowIndexRequestEventArgs(object row, int index)
		{
			this.Row = row;
			this.Index = index;
		}

		// Token: 0x170017A1 RID: 6049
		// (get) Token: 0x060052E3 RID: 21219 RVA: 0x000448CD File Offset: 0x00042ACD
		// (set) Token: 0x060052E4 RID: 21220 RVA: 0x000448D9 File Offset: 0x00042AD9
		public object Row { get; private set; }

		// Token: 0x170017A2 RID: 6050
		// (get) Token: 0x060052E5 RID: 21221 RVA: 0x000448EA File Offset: 0x00042AEA
		// (set) Token: 0x060052E6 RID: 21222 RVA: 0x000448F6 File Offset: 0x00042AF6
		public int Index { get; private set; }
	}
}
