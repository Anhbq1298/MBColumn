using System;
using System.Windows;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Grid
{
	// Token: 0x020009CD RID: 2509
	public interface IGridControlRadioButtonColumn : IGridControlColumn
	{
		// Token: 0x1700176C RID: 5996
		// (get) Token: 0x060051BA RID: 20922
		// (set) Token: 0x060051BB RID: 20923
		IDelegateCommand RadioButtonClickCommand { get; set; }

		// Token: 0x1700176D RID: 5997
		// (get) Token: 0x060051BC RID: 20924
		// (set) Token: 0x060051BD RID: 20925
		Style RadioButtonStyle { get; set; }
	}
}
