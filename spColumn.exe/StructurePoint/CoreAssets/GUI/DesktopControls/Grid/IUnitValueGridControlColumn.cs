using System;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Grid
{
	// Token: 0x020009C7 RID: 2503
	public interface IUnitValueGridControlColumn : IGridControlColumn
	{
		// Token: 0x0600515F RID: 20831
		void SetUnitValueFormatterBinding(string propertyPath, object source);

		// Token: 0x17001759 RID: 5977
		// (get) Token: 0x06005160 RID: 20832
		// (set) Token: 0x06005161 RID: 20833
		string CellEnabledPropertyPath { get; set; }

		// Token: 0x1700175A RID: 5978
		// (get) Token: 0x06005162 RID: 20834
		// (set) Token: 0x06005163 RID: 20835
		bool ShowZeroAsEmptyString { get; set; }
	}
}
