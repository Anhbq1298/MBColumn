using System;
using System.Collections.Generic;
using System.Windows;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Grid
{
	// Token: 0x020009E3 RID: 2531
	public sealed class GridControlRowEditEndedEventArgs : RoutedEventArgs
	{
		// Token: 0x06005308 RID: 21256 RVA: 0x00163528 File Offset: 0x00161728
		internal GridControlRowEditEndedEventArgs(GridViewRowEditEndedEventArgs gridViewRowEditEndedEventArgs)
		{
			#X0d.#V0d(gridViewRowEditEndedEventArgs, #Phc.#3hc(107463437), Component.DesktopControls, #Phc.#3hc(107462884));
			this.gridViewRowEditEndedEventArgs = gridViewRowEditEndedEventArgs;
			base.RoutedEvent = gridViewRowEditEndedEventArgs.RoutedEvent;
			base.Source = gridViewRowEditEndedEventArgs.Source;
		}

		// Token: 0x170017A4 RID: 6052
		// (get) Token: 0x06005309 RID: 21257 RVA: 0x00044ABB File Offset: 0x00042CBB
		public object Row
		{
			get
			{
				if (this.gridViewRowEditEndedEventArgs.Row != null)
				{
					return this.gridViewRowEditEndedEventArgs.Row.DataContext;
				}
				return null;
			}
		}

		// Token: 0x170017A5 RID: 6053
		// (get) Token: 0x0600530A RID: 21258 RVA: 0x00044AE8 File Offset: 0x00042CE8
		public object NewData
		{
			get
			{
				return this.gridViewRowEditEndedEventArgs.NewData;
			}
		}

		// Token: 0x170017A6 RID: 6054
		// (get) Token: 0x0600530B RID: 21259 RVA: 0x00044AFD File Offset: 0x00042CFD
		public IDictionary<string, object> OldValues
		{
			get
			{
				return this.gridViewRowEditEndedEventArgs.OldValues;
			}
		}

		// Token: 0x170017A7 RID: 6055
		// (get) Token: 0x0600530C RID: 21260 RVA: 0x00044B12 File Offset: 0x00042D12
		public IList<string> UserDefinedErrors
		{
			get
			{
				return this.gridViewRowEditEndedEventArgs.UserDefinedErrors;
			}
		}

		// Token: 0x170017A8 RID: 6056
		// (get) Token: 0x0600530D RID: 21261 RVA: 0x00044B27 File Offset: 0x00042D27
		public GridControlEditOperationType EditOperationType
		{
			get
			{
				return GridControlRowEditEndedEventArgs.MyGetEditOperationType(this.gridViewRowEditEndedEventArgs.EditOperationType);
			}
		}

		// Token: 0x170017A9 RID: 6057
		// (get) Token: 0x0600530E RID: 21262 RVA: 0x00044B45 File Offset: 0x00042D45
		public GridControlEditAction EditAction
		{
			get
			{
				return GridControlRowEditEndedEventArgs.MyGetEditAction(this.gridViewRowEditEndedEventArgs.EditAction);
			}
		}

		// Token: 0x0600530F RID: 21263 RVA: 0x00044B63 File Offset: 0x00042D63
		private static GridControlEditOperationType MyGetEditOperationType(GridViewEditOperationType gridViewEditOperationType)
		{
			if (gridViewEditOperationType == GridViewEditOperationType.Edit)
			{
				return GridControlEditOperationType.Edit;
			}
			return GridControlEditOperationType.Insert;
		}

		// Token: 0x06005310 RID: 21264 RVA: 0x00044B70 File Offset: 0x00042D70
		private static GridControlEditAction MyGetEditAction(GridViewEditAction gridViewEditAction)
		{
			if (gridViewEditAction == GridViewEditAction.Cancel)
			{
				return GridControlEditAction.Cancel;
			}
			return GridControlEditAction.Commit;
		}

		// Token: 0x040023F8 RID: 9208
		private readonly GridViewRowEditEndedEventArgs gridViewRowEditEndedEventArgs;
	}
}
