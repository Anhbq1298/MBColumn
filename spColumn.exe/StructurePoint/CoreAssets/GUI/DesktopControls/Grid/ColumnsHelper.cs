using System;
using #7hc;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Grid
{
	// Token: 0x020009BD RID: 2493
	internal static class ColumnsHelper
	{
		// Token: 0x060050CC RID: 20684 RVA: 0x0015F368 File Offset: 0x0015D568
		public static IGridControlColumn CreateColumn(GridControlColumnType gridControlColumnType)
		{
			switch (gridControlColumnType)
			{
			case GridControlColumnType.Text:
				return new TextGridControlColumn();
			case GridControlColumnType.Color:
				return new GridControlColorColumn();
			case GridControlColumnType.RadioButton:
				return new RadioButtonGridViewColumn();
			case GridControlColumnType.UnitValueColumn:
				return new UnitValueGridControlColumn();
			case GridControlColumnType.ComboBox:
				return new ComboBoxGridControlColumn();
			default:
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107465625));
			}
		}
	}
}
