using System;
using System.Windows;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Grid
{
	// Token: 0x020009D9 RID: 2521
	public sealed class GridControlCellValidatingEventArgs : RoutedEventArgs
	{
		// Token: 0x060052B6 RID: 21174 RVA: 0x0016229C File Offset: 0x0016049C
		internal GridControlCellValidatingEventArgs(GridViewCellValidatingEventArgs gridViewCellValidatingEventArgs)
		{
			#X0d.#V0d(gridViewCellValidatingEventArgs, #Phc.#3hc(107463710), Component.DesktopControls, #Phc.#3hc(107464177));
			this.gridViewCellValidatingEventArgs = gridViewCellValidatingEventArgs;
			base.RoutedEvent = gridViewCellValidatingEventArgs.RoutedEvent;
			base.Source = gridViewCellValidatingEventArgs.Source;
		}

		// Token: 0x17001790 RID: 6032
		// (get) Token: 0x060052B7 RID: 21175 RVA: 0x000445DB File Offset: 0x000427DB
		// (set) Token: 0x060052B8 RID: 21176 RVA: 0x000445F0 File Offset: 0x000427F0
		public new bool Handled
		{
			get
			{
				return this.gridViewCellValidatingEventArgs.Handled;
			}
			set
			{
				this.gridViewCellValidatingEventArgs.Handled = value;
			}
		}

		// Token: 0x17001791 RID: 6033
		// (get) Token: 0x060052B9 RID: 21177 RVA: 0x0004460A File Offset: 0x0004280A
		// (set) Token: 0x060052BA RID: 21178 RVA: 0x0004461F File Offset: 0x0004281F
		public string ErrorMessage
		{
			get
			{
				return this.gridViewCellValidatingEventArgs.ErrorMessage;
			}
			set
			{
				this.gridViewCellValidatingEventArgs.ErrorMessage = value;
			}
		}

		// Token: 0x17001792 RID: 6034
		// (get) Token: 0x060052BB RID: 21179 RVA: 0x00044639 File Offset: 0x00042839
		public string ColumnUniqueName
		{
			get
			{
				return this.gridViewCellValidatingEventArgs.Cell.Column.UniqueName;
			}
		}

		// Token: 0x17001793 RID: 6035
		// (get) Token: 0x060052BC RID: 21180 RVA: 0x0004465C File Offset: 0x0004285C
		// (set) Token: 0x060052BD RID: 21181 RVA: 0x00044671 File Offset: 0x00042871
		public bool IsValid
		{
			get
			{
				return this.gridViewCellValidatingEventArgs.IsValid;
			}
			set
			{
				this.gridViewCellValidatingEventArgs.IsValid = value;
			}
		}

		// Token: 0x17001794 RID: 6036
		// (get) Token: 0x060052BE RID: 21182 RVA: 0x0004468B File Offset: 0x0004288B
		public object OldValue
		{
			get
			{
				return this.gridViewCellValidatingEventArgs.OldValue;
			}
		}

		// Token: 0x17001795 RID: 6037
		// (get) Token: 0x060052BF RID: 21183 RVA: 0x000446A0 File Offset: 0x000428A0
		public object NewValue
		{
			get
			{
				return this.gridViewCellValidatingEventArgs.NewValue;
			}
		}

		// Token: 0x17001796 RID: 6038
		// (get) Token: 0x060052C0 RID: 21184 RVA: 0x000446B5 File Offset: 0x000428B5
		public object Row
		{
			get
			{
				if (this.gridViewCellValidatingEventArgs.Row != null)
				{
					return this.gridViewCellValidatingEventArgs.Row.DataContext;
				}
				return null;
			}
		}

		// Token: 0x040023DA RID: 9178
		private readonly GridViewCellValidatingEventArgs gridViewCellValidatingEventArgs;
	}
}
