using System;
using System.Windows;
using System.Windows.Input;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using Telerik.Windows.Controls.GridView;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Grid
{
	// Token: 0x020009C5 RID: 2501
	public sealed class GridControlCellDoubleClickEventArgs : RoutedEventArgs
	{
		// Token: 0x0600515B RID: 20827 RVA: 0x0015F964 File Offset: 0x0015DB64
		public GridControlCellDoubleClickEventArgs(MouseButtonEventArgs mouseButtonEventArgs, GridViewCell cell)
		{
			#X0d.#V0d(mouseButtonEventArgs, #Phc.#3hc(107465490), Component.DesktopControls, #Phc.#3hc(107464949));
			#X0d.#V0d(cell, #Phc.#3hc(107464864), Component.DesktopControls, #Phc.#3hc(107464887));
			base.RoutedEvent = mouseButtonEventArgs.RoutedEvent;
			base.Source = mouseButtonEventArgs.Source;
			base.Handled = mouseButtonEventArgs.Handled;
		}
	}
}
