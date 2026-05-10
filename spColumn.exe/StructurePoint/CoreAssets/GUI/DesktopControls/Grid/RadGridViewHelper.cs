using System;
using #7hc;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Grid
{
	// Token: 0x020009B7 RID: 2487
	public static class RadGridViewHelper
	{
		// Token: 0x060050A9 RID: 20649 RVA: 0x0015ECC8 File Offset: 0x0015CEC8
		public static TItem GetDataItem<TItem>(this GridViewCellEditEndedEventArgs args)
		{
			if (args == null)
			{
				return default(!!0);
			}
			return (!!0)((object)args.Cell.DataContext);
		}

		// Token: 0x060050AA RID: 20650 RVA: 0x0015ED00 File Offset: 0x0015CF00
		public static void ClearIsCurrent(this RadGridView gridView)
		{
			if (gridView == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107465689));
			}
			GridViewCell currentCell = gridView.CurrentCell;
			if (currentCell != null)
			{
				currentCell.IsCurrent = false;
			}
		}
	}
}
