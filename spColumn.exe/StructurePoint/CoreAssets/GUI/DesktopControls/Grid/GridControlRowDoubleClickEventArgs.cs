using System;
using System.Windows;
using System.Windows.Input;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Grid
{
	// Token: 0x020009C6 RID: 2502
	public sealed class GridControlRowDoubleClickEventArgs : RoutedEventArgs
	{
		// Token: 0x0600515C RID: 20828 RVA: 0x0015F9D4 File Offset: 0x0015DBD4
		public GridControlRowDoubleClickEventArgs(MouseButtonEventArgs mouseButtonEventArgs, object row)
		{
			#X0d.#V0d(mouseButtonEventArgs, #Phc.#3hc(107465490), Component.DesktopControls, #Phc.#3hc(107464802));
			#X0d.#V0d(row, #Phc.#3hc(107361131), Component.DesktopControls, #Phc.#3hc(107464749));
			base.RoutedEvent = mouseButtonEventArgs.RoutedEvent;
			base.Source = mouseButtonEventArgs.Source;
			base.Handled = mouseButtonEventArgs.Handled;
			this.Row = row;
		}

		// Token: 0x17001758 RID: 5976
		// (get) Token: 0x0600515D RID: 20829 RVA: 0x00043B61 File Offset: 0x00041D61
		// (set) Token: 0x0600515E RID: 20830 RVA: 0x00043B6D File Offset: 0x00041D6D
		public object Row { get; private set; }
	}
}
