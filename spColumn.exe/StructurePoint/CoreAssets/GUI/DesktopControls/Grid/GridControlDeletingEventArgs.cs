using System;
using System.Collections.Generic;
using System.Windows;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Grid
{
	// Token: 0x020009DC RID: 2524
	public sealed class GridControlDeletingEventArgs : RoutedEventArgs
	{
		// Token: 0x060052C9 RID: 21193 RVA: 0x00162330 File Offset: 0x00160530
		public GridControlDeletingEventArgs(GridViewDeletingEventArgs gridViewDeletingEventArgs)
		{
			#X0d.#V0d(gridViewDeletingEventArgs, #Phc.#3hc(107464007), Component.DesktopControls, #Phc.#3hc(107463970));
			this.gridViewDeletingEventArgs = gridViewDeletingEventArgs;
			base.RoutedEvent = gridViewDeletingEventArgs.RoutedEvent;
			base.Source = gridViewDeletingEventArgs.Source;
		}

		// Token: 0x17001799 RID: 6041
		// (get) Token: 0x060052CA RID: 21194 RVA: 0x00044737 File Offset: 0x00042937
		// (set) Token: 0x060052CB RID: 21195 RVA: 0x0004474C File Offset: 0x0004294C
		public new bool Handled
		{
			get
			{
				return this.gridViewDeletingEventArgs.Handled;
			}
			set
			{
				this.gridViewDeletingEventArgs.Handled = value;
			}
		}

		// Token: 0x1700179A RID: 6042
		// (get) Token: 0x060052CC RID: 21196 RVA: 0x00044766 File Offset: 0x00042966
		public IEnumerable<object> Items
		{
			get
			{
				return this.gridViewDeletingEventArgs.Items;
			}
		}

		// Token: 0x1700179B RID: 6043
		// (get) Token: 0x060052CD RID: 21197 RVA: 0x0004477B File Offset: 0x0004297B
		// (set) Token: 0x060052CE RID: 21198 RVA: 0x00044790 File Offset: 0x00042990
		public bool Cancel
		{
			get
			{
				return this.gridViewDeletingEventArgs.Cancel;
			}
			set
			{
				this.gridViewDeletingEventArgs.Cancel = value;
			}
		}

		// Token: 0x040023DE RID: 9182
		private readonly GridViewDeletingEventArgs gridViewDeletingEventArgs;
	}
}
