using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Grid
{
	// Token: 0x020009E4 RID: 2532
	public sealed class GridControlRowValidatingEventArgs : RoutedEventArgs
	{
		// Token: 0x06005311 RID: 21265 RVA: 0x00163578 File Offset: 0x00161778
		internal GridControlRowValidatingEventArgs(GridViewRowValidatingEventArgs gridViewRowValidatingEventArgs)
		{
			#X0d.#V0d(gridViewRowValidatingEventArgs, #Phc.#3hc(107462831), Component.DesktopControls, #Phc.#3hc(107462790));
			this.gridViewRowValidatingEventArgs = gridViewRowValidatingEventArgs;
			base.RoutedEvent = gridViewRowValidatingEventArgs.RoutedEvent;
			base.Source = gridViewRowValidatingEventArgs.Source;
		}

		// Token: 0x170017AA RID: 6058
		// (get) Token: 0x06005312 RID: 21266 RVA: 0x00044B7C File Offset: 0x00042D7C
		// (set) Token: 0x06005313 RID: 21267 RVA: 0x00044B91 File Offset: 0x00042D91
		public new bool Handled
		{
			get
			{
				return this.gridViewRowValidatingEventArgs.Handled;
			}
			set
			{
				this.gridViewRowValidatingEventArgs.Handled = value;
			}
		}

		// Token: 0x170017AB RID: 6059
		// (get) Token: 0x06005314 RID: 21268 RVA: 0x001635C8 File Offset: 0x001617C8
		public IEnumerable<GridControlCellValidationResult> ValidationResults
		{
			get
			{
				return (from item in this.gridViewRowValidatingEventArgs.ValidationResults
				select GridControlRowValidatingEventArgs.MyGetValidationResult(item)).ToList<GridControlCellValidationResult>();
			}
		}

		// Token: 0x170017AC RID: 6060
		// (get) Token: 0x06005315 RID: 21269 RVA: 0x00044BAB File Offset: 0x00042DAB
		// (set) Token: 0x06005316 RID: 21270 RVA: 0x00044BC0 File Offset: 0x00042DC0
		public bool IsValid
		{
			get
			{
				return this.gridViewRowValidatingEventArgs.IsValid;
			}
			set
			{
				this.gridViewRowValidatingEventArgs.IsValid = value;
			}
		}

		// Token: 0x170017AD RID: 6061
		// (get) Token: 0x06005317 RID: 21271 RVA: 0x00044BDA File Offset: 0x00042DDA
		public IDictionary<string, object> OldValues
		{
			get
			{
				return this.gridViewRowValidatingEventArgs.OldValues;
			}
		}

		// Token: 0x170017AE RID: 6062
		// (get) Token: 0x06005318 RID: 21272 RVA: 0x00044BEF File Offset: 0x00042DEF
		public GridControlEditOperationType EditOperationType
		{
			get
			{
				return GridControlRowValidatingEventArgs.MyGetEditOperationType(this.gridViewRowValidatingEventArgs.EditOperationType);
			}
		}

		// Token: 0x170017AF RID: 6063
		// (get) Token: 0x06005319 RID: 21273 RVA: 0x00044C0D File Offset: 0x00042E0D
		public object RowDataContext
		{
			get
			{
				if (this.gridViewRowValidatingEventArgs.Row == null)
				{
					return null;
				}
				return this.gridViewRowValidatingEventArgs.Row.DataContext;
			}
		}

		// Token: 0x170017B0 RID: 6064
		// (get) Token: 0x0600531A RID: 21274 RVA: 0x00044C3A File Offset: 0x00042E3A
		public string CurrentColumnUniqueName
		{
			get
			{
				return ((RadGridView)base.Source).CurrentColumn.UniqueName;
			}
		}

		// Token: 0x0600531B RID: 21275 RVA: 0x00044C5D File Offset: 0x00042E5D
		public void AddValidationResult(string propertyName, string errorMessage)
		{
			this.gridViewRowValidatingEventArgs.ValidationResults.Add(new GridViewCellValidationResult
			{
				ErrorMessage = errorMessage,
				PropertyName = propertyName
			});
		}

		// Token: 0x0600531C RID: 21276 RVA: 0x00044B63 File Offset: 0x00042D63
		private static GridControlEditOperationType MyGetEditOperationType(GridViewEditOperationType gridViewEditOperationType)
		{
			if (gridViewEditOperationType == GridViewEditOperationType.Edit)
			{
				return GridControlEditOperationType.Edit;
			}
			return GridControlEditOperationType.Insert;
		}

		// Token: 0x0600531D RID: 21277 RVA: 0x00044C8E File Offset: 0x00042E8E
		private static GridControlCellValidationResult MyGetValidationResult(GridViewCellValidationResult gridViewCellValidationResult)
		{
			return new GridControlCellValidationResult
			{
				ErrorMessage = gridViewCellValidationResult.ErrorMessage,
				PropertyName = gridViewCellValidationResult.PropertyName
			};
		}

		// Token: 0x040023F9 RID: 9209
		private readonly GridViewRowValidatingEventArgs gridViewRowValidatingEventArgs;
	}
}
