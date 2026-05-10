using System;
using System.Windows;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Grid
{
	// Token: 0x020009D0 RID: 2512
	public sealed class GridControlBeginningEditEventArgs : RoutedEventArgs
	{
		// Token: 0x060051DF RID: 20959 RVA: 0x00160AC4 File Offset: 0x0015ECC4
		internal GridControlBeginningEditEventArgs(GridViewBeginningEditRoutedEventArgs gridViewBeginningEditRoutedEventArgs)
		{
			#X0d.#V0d(gridViewBeginningEditRoutedEventArgs, #Phc.#3hc(107464215), Component.DesktopControls, #Phc.#3hc(107464646));
			this.gridViewBeginningEditRoutedEventArgs = gridViewBeginningEditRoutedEventArgs;
			base.RoutedEvent = gridViewBeginningEditRoutedEventArgs.RoutedEvent;
			base.Source = gridViewBeginningEditRoutedEventArgs.Source;
		}

		// Token: 0x17001771 RID: 6001
		// (get) Token: 0x060051E0 RID: 20960 RVA: 0x00043F49 File Offset: 0x00042149
		// (set) Token: 0x060051E1 RID: 20961 RVA: 0x00043F5E File Offset: 0x0004215E
		public GridViewCell Cell
		{
			get
			{
				return this.gridViewBeginningEditRoutedEventArgs.Cell;
			}
			set
			{
				this.gridViewBeginningEditRoutedEventArgs.Cell = value;
			}
		}

		// Token: 0x17001772 RID: 6002
		// (get) Token: 0x060051E2 RID: 20962 RVA: 0x00043F78 File Offset: 0x00042178
		public object CurrentRowItem
		{
			get
			{
				return this.gridViewBeginningEditRoutedEventArgs.Row.Item;
			}
		}

		// Token: 0x040023AD RID: 9133
		private readonly GridViewBeginningEditRoutedEventArgs gridViewBeginningEditRoutedEventArgs;
	}
}
