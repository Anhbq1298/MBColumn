using System;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Ribbon
{
	// Token: 0x020008A8 RID: 2216
	public sealed class SelectedValueChangedEventArgs<T> : EventArgs
	{
		// Token: 0x060045E0 RID: 17888 RVA: 0x0003A648 File Offset: 0x00038848
		public SelectedValueChangedEventArgs(T selectedValue)
		{
			this.SelectedValue = selectedValue;
		}

		// Token: 0x1700146D RID: 5229
		// (get) Token: 0x060045E1 RID: 17889 RVA: 0x0003A657 File Offset: 0x00038857
		// (set) Token: 0x060045E2 RID: 17890 RVA: 0x0003A663 File Offset: 0x00038863
		public T SelectedValue { get; private set; }
	}
}
