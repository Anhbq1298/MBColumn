using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Grid
{
	// Token: 0x020009D2 RID: 2514
	[SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling")]
	public sealed class GridControl : UserControl, IComponentConnector, IGridControl
	{
		// Token: 0x060051E5 RID: 20965 RVA: 0x00160B14 File Offset: 0x0015ED14
		public GridControl()
		{
			this.InitializeComponent();
			this.gridControlKeyboardCommandProvider = new GridControlKeyboardCommandProvider(this.RadGridView, this);
			this.RadGridView.KeyboardCommandProvider = this.gridControlKeyboardCommandProvider;
			this.RadGridView.DataLoaded += this.RadGridView_OnDataLoaded;
			this.RadGridView.RowValidating += this.RadGridView_RowValidating;
			this.RadGridView.CellValidating += this.RadGridView_CellValidating;
			this.RadGridView.Deleting += this.RadGridView_Deleting;
			this.RadGridView.RowValidated += this.RadGridView_OnRowValidated;
			this.RadGridView.CellValidated += this.RadGridView_OnCellValidated;
			this.RadGridView.CellEditEnded += this.RadGridView_CellEditEnded;
			this.RadGridView.RowEditEnded += this.RadGridView_RowEditEnded;
			this.RadGridView.BeginningEdit += this.RadGridView_BeginningEdit;
			this.RadGridView.Filtered += this.RadGridView_OnFiltered;
			this.RadGridView.Grouped += this.RadGridView_OnGrouped;
			this.RadGridView.Sorted += this.RadGridView_OnSorted;
			this.RadGridView.MouseDoubleClick += this.RadGridView_MouseDoubleClick;
			this.RadGridView.SelectedCellsChanged += this.RadGridView_OnSelectedCellsChanged;
			this.RadGridView.SelectedCellsChanging += this.RadGridView_SelectedCellsChanging;
			this.RadGridView.SelectionChanging += this.RadGridView_SelectionChanging;
			this.SetFocusOnCollectionChange = true;
			this.MyConstructBindings();
		}

		// Token: 0x17001774 RID: 6004
		// (get) Token: 0x060051E6 RID: 20966 RVA: 0x00043FB1 File Offset: 0x000421B1
		// (set) Token: 0x060051E7 RID: 20967 RVA: 0x00043FC6 File Offset: 0x000421C6
		public bool BeginEditWhenLeavingComboBoxColumn
		{
			get
			{
				return this.gridControlKeyboardCommandProvider.BeginEditWhenLeavingComboBoxColumn;
			}
			set
			{
				this.gridControlKeyboardCommandProvider.BeginEditWhenLeavingComboBoxColumn = value;
			}
		}

		// Token: 0x17001775 RID: 6005
		// (get) Token: 0x060051E8 RID: 20968 RVA: 0x00043FE0 File Offset: 0x000421E0
		// (set) Token: 0x060051E9 RID: 20969 RVA: 0x00043FEC File Offset: 0x000421EC
		public bool IsEditing { get; private set; }

		// Token: 0x17001776 RID: 6006
		// (get) Token: 0x060051EA RID: 20970 RVA: 0x00043FFD File Offset: 0x000421FD
		// (set) Token: 0x060051EB RID: 20971 RVA: 0x00044009 File Offset: 0x00042209
		internal bool IsValid { get; private set; }

		// Token: 0x17001777 RID: 6007
		// (get) Token: 0x060051EC RID: 20972 RVA: 0x0004401A File Offset: 0x0004221A
		// (set) Token: 0x060051ED RID: 20973 RVA: 0x00044034 File Offset: 0x00042234
		public Thickness GridBorderThickness
		{
			get
			{
				return (Thickness)base.GetValue(GridControl.GridBorderThicknessProperty);
			}
			set
			{
				base.SetValue(GridControl.GridBorderThicknessProperty, value);
			}
		}

		// Token: 0x17001778 RID: 6008
		// (get) Token: 0x060051EE RID: 20974 RVA: 0x00044053 File Offset: 0x00042253
		// (set) Token: 0x060051EF RID: 20975 RVA: 0x0004406D File Offset: 0x0004226D
		public bool IsReadOnly
		{
			get
			{
				return (bool)base.GetValue(GridControl.IsReadOnlyProperty);
			}
			set
			{
				base.SetValue(GridControl.IsReadOnlyProperty, value);
			}
		}

		// Token: 0x17001779 RID: 6009
		// (get) Token: 0x060051F0 RID: 20976 RVA: 0x0004408C File Offset: 0x0004228C
		// (set) Token: 0x060051F1 RID: 20977 RVA: 0x000440A6 File Offset: 0x000422A6
		public HelpID HelpId
		{
			get
			{
				return (HelpID)base.GetValue(GridControl.HelpIdProperty);
			}
			set
			{
				base.SetValue(GridControl.HelpIdProperty, value);
			}
		}

		// Token: 0x060051F2 RID: 20978 RVA: 0x000440C0 File Offset: 0x000422C0
		private static void HelpIdPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
		{
			dependencyObject.SetValue(ContextualHelp.HelpIDProperty, dependencyPropertyChangedEventArgs.NewValue);
		}

		// Token: 0x1700177A RID: 6010
		// (get) Token: 0x060051F3 RID: 20979 RVA: 0x000440E0 File Offset: 0x000422E0
		// (set) Token: 0x060051F4 RID: 20980 RVA: 0x000440FA File Offset: 0x000422FA
		public IEnumerable ItemsSource
		{
			get
			{
				return (IEnumerable)base.GetValue(GridControl.ItemsSourceProperty);
			}
			set
			{
				base.SetValue(GridControl.ItemsSourceProperty, value);
			}
		}

		// Token: 0x1700177B RID: 6011
		// (get) Token: 0x060051F5 RID: 20981 RVA: 0x00044114 File Offset: 0x00042314
		// (set) Token: 0x060051F6 RID: 20982 RVA: 0x0004412E File Offset: 0x0004232E
		public IGridControlColumn CurrentColumn
		{
			get
			{
				return (IGridControlColumn)base.GetValue(GridControl.CurrentColumnProperty);
			}
			set
			{
				base.SetValue(GridControl.CurrentColumnProperty, value);
			}
		}

		// Token: 0x1700177C RID: 6012
		// (get) Token: 0x060051F7 RID: 20983 RVA: 0x00044148 File Offset: 0x00042348
		// (set) Token: 0x060051F8 RID: 20984 RVA: 0x0004415D File Offset: 0x0004235D
		public object CurrentItem
		{
			get
			{
				return base.GetValue(GridControl.CurrentItemProperty);
			}
			set
			{
				base.SetValue(GridControl.CurrentItemProperty, value);
			}
		}

		// Token: 0x1700177D RID: 6013
		// (get) Token: 0x060051F9 RID: 20985 RVA: 0x00044177 File Offset: 0x00042377
		// (set) Token: 0x060051FA RID: 20986 RVA: 0x0004418C File Offset: 0x0004238C
		public object SelectedItem
		{
			get
			{
				return base.GetValue(GridControl.SelectedItemProperty);
			}
			set
			{
				base.SetValue(GridControl.SelectedItemProperty, value);
			}
		}

		// Token: 0x1700177E RID: 6014
		// (get) Token: 0x060051FB RID: 20987 RVA: 0x000441A6 File Offset: 0x000423A6
		// (set) Token: 0x060051FC RID: 20988 RVA: 0x000441C0 File Offset: 0x000423C0
		public IEnumerable SelectedItems
		{
			get
			{
				return (IEnumerable)base.GetValue(GridControl.SelectedItemsProperty);
			}
			set
			{
				base.SetValue(GridControl.SelectedItemsProperty, value);
			}
		}

		// Token: 0x1700177F RID: 6015
		// (get) Token: 0x060051FD RID: 20989 RVA: 0x000441DA File Offset: 0x000423DA
		// (set) Token: 0x060051FE RID: 20990 RVA: 0x000441F4 File Offset: 0x000423F4
		public bool AutoGenerateColumns
		{
			get
			{
				return (bool)base.GetValue(GridControl.AutoGenerateColumnsProperty);
			}
			set
			{
				base.SetValue(GridControl.ItemsSourceProperty, value);
			}
		}

		// Token: 0x17001780 RID: 6016
		// (get) Token: 0x060051FF RID: 20991 RVA: 0x00044213 File Offset: 0x00042413
		public IEnumerable<IGridControlColumn> Columns
		{
			get
			{
				return this.RadGridView.Columns.OfType<IGridControlColumn>();
			}
		}

		// Token: 0x17001781 RID: 6017
		// (get) Token: 0x06005200 RID: 20992 RVA: 0x00044231 File Offset: 0x00042431
		public IEnumerable CurrentItemsInView
		{
			get
			{
				return this.RadGridView.Items;
			}
		}

		// Token: 0x17001782 RID: 6018
		// (get) Token: 0x06005201 RID: 20993 RVA: 0x00160CD4 File Offset: 0x0015EED4
		public IEnumerable<GridControlCellInfo> SelectedCells
		{
			get
			{
				return (from cell in this.RadGridView.SelectedCells
				select new GridControlCellInfo(cell)).ToList<GridControlCellInfo>();
			}
		}

		// Token: 0x17001783 RID: 6019
		// (get) Token: 0x06005202 RID: 20994 RVA: 0x00044246 File Offset: 0x00042446
		// (set) Token: 0x06005203 RID: 20995 RVA: 0x00044252 File Offset: 0x00042452
		public bool SetFocusOnCollectionChange { get; set; }

		// Token: 0x06005204 RID: 20996 RVA: 0x00044263 File Offset: 0x00042463
		public bool SetFocusOnControl()
		{
			return this.RadGridView.Focus();
		}

		// Token: 0x06005205 RID: 20997 RVA: 0x00044278 File Offset: 0x00042478
		public void AddColumn(IGridControlColumn gridControlColumn)
		{
			#X0d.#V0d(gridControlColumn, #Phc.#3hc(107464625), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUI, #Phc.#3hc(107464600));
			this.RadGridView.Columns.Add((Telerik.Windows.Controls.GridViewColumn)gridControlColumn);
		}

		// Token: 0x06005206 RID: 20998 RVA: 0x000442B7 File Offset: 0x000424B7
		public void RemoveColumn(IGridControlColumn gridControlColumn)
		{
			#X0d.#V0d(gridControlColumn, #Phc.#3hc(107464625), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUI, #Phc.#3hc(107464515));
			this.RadGridView.Columns.Remove((Telerik.Windows.Controls.GridViewColumn)gridControlColumn);
		}

		// Token: 0x06005207 RID: 20999 RVA: 0x00160D24 File Offset: 0x0015EF24
		public void AddColumns(ICollection<IGridControlColumn> columns)
		{
			#X0d.#V0d(columns, #Phc.#3hc(107464462), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.DesktopControls, #Phc.#3hc(107464449));
			List<Telerik.Windows.Controls.GridViewColumn> list = columns.OfType<Telerik.Windows.Controls.GridViewColumn>().ToList<Telerik.Windows.Controls.GridViewColumn>();
			if (list.Any<Telerik.Windows.Controls.GridViewColumn>())
			{
				this.RadGridView.Columns.AddRange(list);
			}
		}

		// Token: 0x06005208 RID: 21000 RVA: 0x00160D80 File Offset: 0x0015EF80
		public void RemoveColumns(ICollection<IGridControlColumn> columns)
		{
			#X0d.#V0d(columns, #Phc.#3hc(107464462), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.DesktopControls, #Phc.#3hc(107463884));
			List<Telerik.Windows.Controls.GridViewColumn> list = columns.OfType<Telerik.Windows.Controls.GridViewColumn>().ToList<Telerik.Windows.Controls.GridViewColumn>();
			if (list.Any<Telerik.Windows.Controls.GridViewColumn>())
			{
				this.RadGridView.Columns.RemoveItems(list);
			}
		}

		// Token: 0x06005209 RID: 21001 RVA: 0x000442F7 File Offset: 0x000424F7
		public IGridControlColumn CreateColumn(GridControlColumnType gridControlColumnType)
		{
			return ColumnsHelper.CreateColumn(gridControlColumnType);
		}

		// Token: 0x0600520A RID: 21002 RVA: 0x00044307 File Offset: 0x00042507
		public void BeginEdit()
		{
			if (!this.RadGridView.BeginEdit())
			{
				this.RadGridView.Rebind();
				this.RadGridView.BeginEdit();
			}
			this.IsEditing = true;
		}

		// Token: 0x0600520B RID: 21003 RVA: 0x00044340 File Offset: 0x00042540
		public void SelectItem(object item)
		{
			this.SelectedItem = item;
			this.MyApplySelection();
		}

		// Token: 0x0600520C RID: 21004 RVA: 0x00160DDC File Offset: 0x0015EFDC
		public void ClearFilters()
		{
			foreach (Telerik.Windows.Controls.GridViewColumn gridViewColumn in ((IEnumerable<Telerik.Windows.Controls.GridViewColumn>)this.RadGridView.Columns))
			{
				gridViewColumn.ColumnFilterDescriptor.Clear();
			}
			this.RadGridView.GroupDescriptors.Clear();
			this.RadGridView.FilterDescriptors.Clear();
			this.RadGridView.SortDescriptors.Clear();
			this.MyRaiseFiltersStateChanged();
		}

		// Token: 0x0600520D RID: 21005 RVA: 0x00160E78 File Offset: 0x0015F078
		public bool IsFilterActive(string uniqueColumnName)
		{
			Telerik.Windows.Controls.GridViewColumn gridViewColumn = this.RadGridView.Columns.OfType<Telerik.Windows.Controls.GridViewColumn>().FirstOrDefault((Telerik.Windows.Controls.GridViewColumn item) => string.Equals(item.UniqueName, uniqueColumnName));
			return gridViewColumn != null && GridControl.MyIsFilterActive(gridViewColumn);
		}

		// Token: 0x0600520E RID: 21006 RVA: 0x0004435B File Offset: 0x0004255B
		public void HandleCollectionChanged()
		{
			if (this.SetFocusOnCollectionChange)
			{
				this.RadGridView.Focus();
			}
		}

		// Token: 0x0600520F RID: 21007 RVA: 0x0004437D File Offset: 0x0004257D
		public object RetrieveCurrentItem()
		{
			return this.RadGridView.CurrentItem;
		}

		// Token: 0x06005210 RID: 21008 RVA: 0x00044392 File Offset: 0x00042592
		public object RetrieveSelectedItem()
		{
			return this.RadGridView.SelectedItem;
		}

		// Token: 0x06005211 RID: 21009 RVA: 0x000443A7 File Offset: 0x000425A7
		public void RaiseCancelEdit()
		{
			this.RaiseEditCanceled();
		}

		// Token: 0x06005212 RID: 21010 RVA: 0x00160ECC File Offset: 0x0015F0CC
		public void CancelEdit()
		{
			RoutedUICommand routedUICommand = RadGridViewCommands.CancelRowEdit as RoutedUICommand;
			if (routedUICommand != null && routedUICommand.CanExecute(null, this.RadGridView))
			{
				routedUICommand.Execute(null, this.RadGridView);
			}
			else
			{
				this.RadGridView.CancelEdit();
			}
			this.RadGridView.Rebind();
		}

		// Token: 0x06005213 RID: 21011 RVA: 0x000443B7 File Offset: 0x000425B7
		public void CommitEdit()
		{
			this.RadGridView.CommitEdit();
		}

		// Token: 0x06005214 RID: 21012 RVA: 0x000443CD File Offset: 0x000425CD
		public void RebindData()
		{
			this.RadGridView.Rebind();
		}

		// Token: 0x06005215 RID: 21013 RVA: 0x00160F28 File Offset: 0x0015F128
		public void ScrollIntoViewAsync(object dataItem, Action finishedCallback, Action failedCallback)
		{
			if (dataItem == null)
			{
				return;
			}
			this.RadGridView.ScrollIntoViewAsync(dataItem, delegate(FrameworkElement item)
			{
				if (finishedCallback != null)
				{
					finishedCallback();
				}
			}, delegate()
			{
				if (failedCallback != null)
				{
					failedCallback();
				}
			});
		}

		// Token: 0x06005216 RID: 21014 RVA: 0x000443E2 File Offset: 0x000425E2
		public void ClearSelection()
		{
			this.RadGridView.SelectedCells.Clear();
			this.RadGridView.SelectedItems.Clear();
		}

		// Token: 0x06005217 RID: 21015 RVA: 0x00044410 File Offset: 0x00042610
		public void ScrollIntoView(object dataItem)
		{
			if (dataItem == null)
			{
				return;
			}
			this.RadGridView.ScrollIntoView(dataItem);
		}

		// Token: 0x06005218 RID: 21016 RVA: 0x00160F80 File Offset: 0x0015F180
		public void BeginEdit(object dataItem, object column)
		{
			GridViewRow gridViewRow = (from row in this.RadGridView.ChildrenOfType<GridViewRow>()
			where row.DataContext == dataItem
			select row).FirstOrDefault<GridViewRow>();
			if (gridViewRow != null)
			{
				GridViewCell gridViewCell = gridViewRow.Cells.OfType<GridViewCell>().FirstOrDefault((GridViewCell cell) => cell.Column == column);
				if (gridViewCell != null)
				{
					gridViewCell.BeginEdit();
				}
			}
		}

		// Token: 0x06005219 RID: 21017 RVA: 0x00160FF8 File Offset: 0x0015F1F8
		public void ScrollIntoView(object dataItem, object column, Action callback)
		{
			if (dataItem == null && callback != null)
			{
				callback();
			}
			Telerik.Windows.Controls.GridViewColumn column2 = column as Telerik.Windows.Controls.GridViewColumn;
			this.RadGridView.ScrollIntoViewAsync(dataItem, column2, delegate(FrameworkElement element)
			{
				if (callback != null)
				{
					callback();
				}
			}, delegate()
			{
				if (callback != null)
				{
					callback();
				}
			});
		}

		// Token: 0x0600521A RID: 21018 RVA: 0x00161060 File Offset: 0x0015F260
		internal void RaiseEditCanceled()
		{
			EventHandler onEditCanceled = this.OnEditCanceled;
			if (onEditCanceled != null)
			{
				onEditCanceled(this, new EventArgs());
			}
			this.IsEditing = false;
		}

		// Token: 0x0600521B RID: 21019 RVA: 0x00161098 File Offset: 0x0015F298
		internal void RaiseCommittingEdit()
		{
			EventHandler onCommittingEdit = this.OnCommittingEdit;
			if (onCommittingEdit != null)
			{
				onCommittingEdit(this, new EventArgs());
			}
		}

		// Token: 0x0600521C RID: 21020 RVA: 0x001610C8 File Offset: 0x0015F2C8
		internal void RaiseInsertRequested()
		{
			if (!this.MyHasAnyFilterEnabled())
			{
				EventHandler onInsertRequested = this.OnInsertRequested;
				if (onInsertRequested != null)
				{
					onInsertRequested(this, new EventArgs());
				}
			}
		}

		// Token: 0x0600521D RID: 21021 RVA: 0x00161100 File Offset: 0x0015F300
		internal void RaiseDeleteRequested()
		{
			if (!this.MyHasAnyFilterEnabled())
			{
				EventHandler onDeleteRequested = this.OnDeleteRequested;
				if (onDeleteRequested != null)
				{
					onDeleteRequested(this, new EventArgs());
				}
			}
		}

		// Token: 0x0600521E RID: 21022 RVA: 0x00161138 File Offset: 0x0015F338
		internal void RaiseChangeRowIndexRequested(object row, int index)
		{
			if (!this.MyHasAnyFilterEnabled())
			{
				EventHandler<GridControlChangeRowIndexRequestEventArgs> onChangeRowIndexRequested = this.OnChangeRowIndexRequested;
				if (onChangeRowIndexRequested != null)
				{
					onChangeRowIndexRequested(this, new GridControlChangeRowIndexRequestEventArgs(row, index));
				}
				this.SelectItem(row);
			}
		}

		// Token: 0x0600521F RID: 21023 RVA: 0x0004442E File Offset: 0x0004262E
		protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
		{
			this.SelectItem(null);
			this.RadGridView.SelectedCells.Clear();
			if (this.IsEditing)
			{
				this.CommitEdit();
			}
		}

		// Token: 0x06005220 RID: 21024 RVA: 0x00161178 File Offset: 0x0015F378
		private void RadGridView_RowValidating(object sender, GridViewRowValidatingEventArgs e)
		{
			EventHandler<GridControlRowValidatingEventArgs> onRowValidating = this.OnRowValidating;
			if (onRowValidating != null)
			{
				onRowValidating(this, new GridControlRowValidatingEventArgs(e));
			}
			this.IsValid = e.IsValid;
		}

		// Token: 0x06005221 RID: 21025 RVA: 0x001611B4 File Offset: 0x0015F3B4
		private void RadGridView_CellValidating(object sender, GridViewCellValidatingEventArgs e)
		{
			EventHandler<GridControlCellValidatingEventArgs> onCellValidating = this.OnCellValidating;
			if (onCellValidating != null)
			{
				onCellValidating(this, new GridControlCellValidatingEventArgs(e));
			}
			this.IsValid = e.IsValid;
		}

		// Token: 0x06005222 RID: 21026 RVA: 0x001611F0 File Offset: 0x0015F3F0
		private void RadGridView_OnRowValidated(object sender, GridViewRowValidatedEventArgs e)
		{
			EventHandler onRowValidated = this.OnRowValidated;
			if (onRowValidated != null)
			{
				onRowValidated(this, new EventArgs());
			}
			this.IsValid = true;
		}

		// Token: 0x06005223 RID: 21027 RVA: 0x00161228 File Offset: 0x0015F428
		private void RadGridView_OnCellValidated(object sender, GridViewCellValidatedEventArgs e)
		{
			EventHandler onCellValidated = this.OnCellValidated;
			if (onCellValidated != null)
			{
				onCellValidated(this, new EventArgs());
			}
			this.IsValid = true;
		}

		// Token: 0x06005224 RID: 21028 RVA: 0x00161260 File Offset: 0x0015F460
		private void RadGridView_Deleting(object sender, GridViewDeletingEventArgs e)
		{
			EventHandler<GridControlDeletingEventArgs> onDeleting = this.OnDeleting;
			if (onDeleting != null)
			{
				onDeleting(this, new GridControlDeletingEventArgs(e));
			}
		}

		// Token: 0x06005225 RID: 21029 RVA: 0x00161290 File Offset: 0x0015F490
		private void RadGridView_CellEditEnded(object sender, GridViewCellEditEndedEventArgs e)
		{
			EventHandler onCellEditEnded = this.OnCellEditEnded;
			if (onCellEditEnded != null)
			{
				onCellEditEnded(this, e);
			}
		}

		// Token: 0x06005226 RID: 21030 RVA: 0x001612BC File Offset: 0x0015F4BC
		private void RadGridView_RowEditEnded(object sender, GridViewRowEditEndedEventArgs e)
		{
			EventHandler<GridControlRowEditEndedEventArgs> onRowEditEnded = this.OnRowEditEnded;
			if (onRowEditEnded != null)
			{
				onRowEditEnded(this, new GridControlRowEditEndedEventArgs(e));
			}
			this.IsEditing = false;
			this.MyApplySelection();
			this.RadGridView.IsFilteringAllowed = true;
			this.RadGridView.CanUserSortColumns = true;
		}

		// Token: 0x06005227 RID: 21031 RVA: 0x00161314 File Offset: 0x0015F514
		private static bool MyIsSelectionKeyDown()
		{
			return Keyboard.IsKeyDown(Key.LeftCtrl) || (Keyboard.IsKeyDown(Key.LeftShift) && !Keyboard.IsKeyDown(Key.Tab)) || Keyboard.IsKeyDown(Key.RightCtrl) || (Keyboard.IsKeyDown(Key.RightShift) && !Keyboard.IsKeyDown(Key.Tab));
		}

		// Token: 0x06005228 RID: 21032 RVA: 0x00161368 File Offset: 0x0015F568
		private void RadGridView_BeginningEdit(object sender, GridViewBeginningEditRoutedEventArgs e)
		{
			if (GridControl.MyIsSelectionKeyDown())
			{
				e.Cancel = true;
				return;
			}
			EventHandler<GridControlBeginningEditEventArgs> onEditBeginning = this.OnEditBeginning;
			if (onEditBeginning != null)
			{
				onEditBeginning(this, new GridControlBeginningEditEventArgs(e));
			}
			this.IsEditing = true;
			this.RadGridView.IsFilteringAllowed = false;
			this.RadGridView.CanUserSortColumns = false;
		}

		// Token: 0x06005229 RID: 21033 RVA: 0x001613C8 File Offset: 0x0015F5C8
		private void RadGridView_SelectionChanging(object sender, SelectionChangingEventArgs e)
		{
			if (GridControl.MyIsSelectionKeyDown() && !this.RadGridView.SelectedItems.Any<object>() && this.RadGridView.SelectedCells.Any<GridViewCellInfo>())
			{
				try
				{
					this.allowCellSelectionChangeInExtendedSelectionMode = true;
					this.RadGridView.SelectedCells.Clear();
				}
				finally
				{
					this.allowCellSelectionChangeInExtendedSelectionMode = false;
				}
			}
		}

		// Token: 0x0600522A RID: 21034 RVA: 0x00161440 File Offset: 0x0015F640
		private void RadGridView_SelectedCellsChanging(object sender, GridViewSelectedCellsChangingEventArgs e)
		{
			bool flag = GridControl.MyIsSelectionKeyDown();
			if (this.allowCellSelectionChangeInExtendedSelectionMode && flag)
			{
				return;
			}
			if (flag && e.IsCancelable)
			{
				e.Cancel = true;
			}
		}

		// Token: 0x0600522B RID: 21035 RVA: 0x0016147C File Offset: 0x0015F67C
		private void RadGridView_OnSelectedCellsChanged(object sender, GridViewSelectedCellsChangedEventArgs e)
		{
			if (!this.listenToSelectedCellsChanged)
			{
				return;
			}
			this.listenToSelectedCellsChanged = false;
			try
			{
				if (this.SelectedCells.Count<GridControlCellInfo>() == 1 && this.RadGridView.CurrentCellInfo != null && this.RadGridView.CurrentCellInfo.Item == null)
				{
					this.RadGridView.CurrentCellInfo = this.RadGridView.SelectedCells[0];
				}
				EventHandler onSelectionChanged = this.OnSelectionChanged;
				if (onSelectionChanged != null)
				{
					onSelectionChanged(this, e);
				}
			}
			finally
			{
				this.listenToSelectedCellsChanged = true;
			}
		}

		// Token: 0x0600522C RID: 21036 RVA: 0x00044461 File Offset: 0x00042661
		private void RadGridView_OnDataLoaded(object sender, EventArgs e)
		{
			GridControlRowReorderBehavior.SetIsEnabled(this.RadGridView, true);
			GridControlRowReorderBehavior.SetGridControl(this.RadGridView, this);
		}

		// Token: 0x0600522D RID: 21037 RVA: 0x00044487 File Offset: 0x00042687
		private void RadGridView_OnFiltered(object sender, GridViewFilteredEventArgs e)
		{
			this.MyRaiseFiltersStateChanged();
		}

		// Token: 0x0600522E RID: 21038 RVA: 0x00044487 File Offset: 0x00042687
		private void RadGridView_OnGrouped(object sender, GridViewGroupedEventArgs e)
		{
			this.MyRaiseFiltersStateChanged();
		}

		// Token: 0x0600522F RID: 21039 RVA: 0x00044487 File Offset: 0x00042687
		private void RadGridView_OnSorted(object sender, GridViewSortedEventArgs e)
		{
			this.MyRaiseFiltersStateChanged();
		}

		// Token: 0x06005230 RID: 21040 RVA: 0x0016152C File Offset: 0x0015F72C
		private void RadGridView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			FrameworkElement frameworkElement = e.OriginalSource as FrameworkElement;
			if (frameworkElement != null)
			{
				GridViewCell gridViewCell = frameworkElement.ParentOfType<GridViewCell>();
				if (gridViewCell != null)
				{
					EventHandler<GridControlCellDoubleClickEventArgs> onCellDoubleClicked = this.OnCellDoubleClicked;
					if (onCellDoubleClicked != null)
					{
						onCellDoubleClicked(this, new GridControlCellDoubleClickEventArgs(e, gridViewCell));
						return;
					}
				}
				else
				{
					GridViewRow gridViewRow = frameworkElement.ParentOfType<GridViewRow>();
					if (gridViewRow != null)
					{
						EventHandler<GridControlRowDoubleClickEventArgs> onRowDoubleClicked = this.OnRowDoubleClicked;
						if (onRowDoubleClicked != null)
						{
							onRowDoubleClicked(this, new GridControlRowDoubleClickEventArgs(e, gridViewRow.DataContext));
						}
					}
				}
			}
		}

		// Token: 0x14000135 RID: 309
		// (add) Token: 0x06005231 RID: 21041 RVA: 0x001615A4 File Offset: 0x0015F7A4
		// (remove) Token: 0x06005232 RID: 21042 RVA: 0x001615E8 File Offset: 0x0015F7E8
		public event EventHandler<GridControlRowValidatingEventArgs> OnRowValidating;

		// Token: 0x14000136 RID: 310
		// (add) Token: 0x06005233 RID: 21043 RVA: 0x0016162C File Offset: 0x0015F82C
		// (remove) Token: 0x06005234 RID: 21044 RVA: 0x00161670 File Offset: 0x0015F870
		public event EventHandler<GridControlCellValidatingEventArgs> OnCellValidating;

		// Token: 0x14000137 RID: 311
		// (add) Token: 0x06005235 RID: 21045 RVA: 0x001616B4 File Offset: 0x0015F8B4
		// (remove) Token: 0x06005236 RID: 21046 RVA: 0x001616F8 File Offset: 0x0015F8F8
		public event EventHandler<GridControlDeletingEventArgs> OnDeleting;

		// Token: 0x14000138 RID: 312
		// (add) Token: 0x06005237 RID: 21047 RVA: 0x0016173C File Offset: 0x0015F93C
		// (remove) Token: 0x06005238 RID: 21048 RVA: 0x00161780 File Offset: 0x0015F980
		public event EventHandler<GridControlBeginningEditEventArgs> OnEditBeginning;

		// Token: 0x14000139 RID: 313
		// (add) Token: 0x06005239 RID: 21049 RVA: 0x001617C4 File Offset: 0x0015F9C4
		// (remove) Token: 0x0600523A RID: 21050 RVA: 0x00161808 File Offset: 0x0015FA08
		public event EventHandler OnCommittingEdit;

		// Token: 0x1400013A RID: 314
		// (add) Token: 0x0600523B RID: 21051 RVA: 0x0016184C File Offset: 0x0015FA4C
		// (remove) Token: 0x0600523C RID: 21052 RVA: 0x00161890 File Offset: 0x0015FA90
		public event EventHandler OnEditCanceled;

		// Token: 0x1400013B RID: 315
		// (add) Token: 0x0600523D RID: 21053 RVA: 0x001618D4 File Offset: 0x0015FAD4
		// (remove) Token: 0x0600523E RID: 21054 RVA: 0x00161918 File Offset: 0x0015FB18
		public event EventHandler OnCellEditEnded;

		// Token: 0x1400013C RID: 316
		// (add) Token: 0x0600523F RID: 21055 RVA: 0x0016195C File Offset: 0x0015FB5C
		// (remove) Token: 0x06005240 RID: 21056 RVA: 0x001619A0 File Offset: 0x0015FBA0
		public event EventHandler<GridControlRowEditEndedEventArgs> OnRowEditEnded;

		// Token: 0x1400013D RID: 317
		// (add) Token: 0x06005241 RID: 21057 RVA: 0x001619E4 File Offset: 0x0015FBE4
		// (remove) Token: 0x06005242 RID: 21058 RVA: 0x00161A28 File Offset: 0x0015FC28
		public event EventHandler OnInsertRequested;

		// Token: 0x1400013E RID: 318
		// (add) Token: 0x06005243 RID: 21059 RVA: 0x00161A6C File Offset: 0x0015FC6C
		// (remove) Token: 0x06005244 RID: 21060 RVA: 0x00161AB0 File Offset: 0x0015FCB0
		public event EventHandler OnDeleteRequested;

		// Token: 0x1400013F RID: 319
		// (add) Token: 0x06005245 RID: 21061 RVA: 0x00161AF4 File Offset: 0x0015FCF4
		// (remove) Token: 0x06005246 RID: 21062 RVA: 0x00161B38 File Offset: 0x0015FD38
		public event EventHandler OnSelectionChanged;

		// Token: 0x14000140 RID: 320
		// (add) Token: 0x06005247 RID: 21063 RVA: 0x00161B7C File Offset: 0x0015FD7C
		// (remove) Token: 0x06005248 RID: 21064 RVA: 0x00161BC0 File Offset: 0x0015FDC0
		public event EventHandler OnRowValidated;

		// Token: 0x14000141 RID: 321
		// (add) Token: 0x06005249 RID: 21065 RVA: 0x00161C04 File Offset: 0x0015FE04
		// (remove) Token: 0x0600524A RID: 21066 RVA: 0x00161C48 File Offset: 0x0015FE48
		public event EventHandler OnCellValidated;

		// Token: 0x14000142 RID: 322
		// (add) Token: 0x0600524B RID: 21067 RVA: 0x00161C8C File Offset: 0x0015FE8C
		// (remove) Token: 0x0600524C RID: 21068 RVA: 0x00161CD0 File Offset: 0x0015FED0
		public event EventHandler<GridControlChangeRowIndexRequestEventArgs> OnChangeRowIndexRequested;

		// Token: 0x14000143 RID: 323
		// (add) Token: 0x0600524D RID: 21069 RVA: 0x00161D14 File Offset: 0x0015FF14
		// (remove) Token: 0x0600524E RID: 21070 RVA: 0x00161D58 File Offset: 0x0015FF58
		public event EventHandler<GridControlFiltersStateChangedEventArgs> OnFiltersStateChanged;

		// Token: 0x14000144 RID: 324
		// (add) Token: 0x0600524F RID: 21071 RVA: 0x00161D9C File Offset: 0x0015FF9C
		// (remove) Token: 0x06005250 RID: 21072 RVA: 0x00161DE0 File Offset: 0x0015FFE0
		public event EventHandler<GridControlRowDoubleClickEventArgs> OnRowDoubleClicked;

		// Token: 0x14000145 RID: 325
		// (add) Token: 0x06005251 RID: 21073 RVA: 0x00161E24 File Offset: 0x00160024
		// (remove) Token: 0x06005252 RID: 21074 RVA: 0x00161E68 File Offset: 0x00160068
		public event EventHandler<GridControlCellDoubleClickEventArgs> OnCellDoubleClicked;

		// Token: 0x06005253 RID: 21075 RVA: 0x00161EAC File Offset: 0x001600AC
		private void MyConstructBindings()
		{
			BindingHelper.SetBinding<Thickness>(new BindingHelperParametersContainer<Thickness>
			{
				Target = this.RadGridView,
				TargetProperty = Control.BorderThicknessProperty,
				Source = this,
				PropertyExpression = (() => this.GridBorderThickness),
				BindingMode = BindingMode.OneWay
			}, false);
			BindingHelper.SetBinding<bool>(new BindingHelperParametersContainer<bool>
			{
				Target = this.RadGridView,
				TargetProperty = GridViewDataControl.IsReadOnlyProperty,
				Source = this,
				PropertyExpression = (() => this.IsReadOnly),
				BindingMode = BindingMode.TwoWay
			}, false);
		}

		// Token: 0x06005254 RID: 21076 RVA: 0x00161FA8 File Offset: 0x001601A8
		private void MyRaiseFiltersStateChanged()
		{
			EventHandler<GridControlFiltersStateChangedEventArgs> onFiltersStateChanged = this.OnFiltersStateChanged;
			if (onFiltersStateChanged != null)
			{
				onFiltersStateChanged(this, new GridControlFiltersStateChangedEventArgs(this.MyHasAnyFilterEnabled()));
			}
		}

		// Token: 0x06005255 RID: 21077 RVA: 0x00161FE0 File Offset: 0x001601E0
		private void MyApplySelection()
		{
			object selectedItem = this.SelectedItem;
			object obj;
			if (!false)
			{
				obj = selectedItem;
			}
			this.CurrentItem = null;
			this.SelectedItem = null;
			this.CurrentItem = obj;
			this.SelectedItem = obj;
		}

		// Token: 0x06005256 RID: 21078 RVA: 0x00044497 File Offset: 0x00042697
		private static bool MyIsFilterActive(Telerik.Windows.Controls.GridViewColumn column)
		{
			return (column.ColumnFilterDescriptor != null && column.ColumnFilterDescriptor.IsActive) || column.SortingState != SortingState.None;
		}

		// Token: 0x06005257 RID: 21079 RVA: 0x00162020 File Offset: 0x00160220
		private bool MyHasAnyFilterEnabled()
		{
			ICollection<Telerik.Windows.Controls.GridViewColumn> columns = this.RadGridView.Columns;
			if (columns != null)
			{
				using (IEnumerator<Telerik.Windows.Controls.GridViewColumn> enumerator = columns.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (GridControl.MyIsFilterActive(enumerator.Current))
						{
							return true;
						}
					}
				}
				return false;
			}
			return false;
		}

		// Token: 0x06005258 RID: 21080 RVA: 0x0016208C File Offset: 0x0016028C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107463863), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06005259 RID: 21081 RVA: 0x00008739 File Offset: 0x00006939
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600525A RID: 21082 RVA: 0x000444C8 File Offset: 0x000426C8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
		[SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
		[SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.GridControlCanvas = (Canvas)target;
				return;
			}
			if (connectionId != 2)
			{
				this._contentLoaded = true;
				return;
			}
			this.RadGridView = (RadGridView)target;
		}

		// Token: 0x040023AF RID: 9135
		private bool listenToSelectedCellsChanged = true;

		// Token: 0x040023B0 RID: 9136
		private bool allowCellSelectionChangeInExtendedSelectionMode;

		// Token: 0x040023B1 RID: 9137
		private readonly GridControlKeyboardCommandProvider gridControlKeyboardCommandProvider;

		// Token: 0x040023B4 RID: 9140
		public static readonly DependencyProperty GridBorderThicknessProperty = DependencyProperty.Register(#Phc.#3hc(107463806), typeof(Thickness), typeof(GridControl), new PropertyMetadata(new Thickness(1.0)));

		// Token: 0x040023B5 RID: 9141
		public static readonly DependencyProperty IsReadOnlyProperty = DependencyProperty.Register(#Phc.#3hc(107456521), typeof(bool), typeof(GridControl), new FrameworkPropertyMetadata(false));

		// Token: 0x040023B6 RID: 9142
		public static readonly DependencyProperty HelpIdProperty = DependencyProperty.Register(#Phc.#3hc(107466474), typeof(HelpID), typeof(GridControl), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(GridControl.HelpIdPropertyChanged)));

		// Token: 0x040023B7 RID: 9143
		public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register(#Phc.#3hc(107453856), typeof(IEnumerable), typeof(GridControl));

		// Token: 0x040023B8 RID: 9144
		public static readonly DependencyProperty CurrentColumnProperty = DependencyProperty.Register(#Phc.#3hc(107463745), typeof(IGridControlColumn), typeof(GridControl));

		// Token: 0x040023B9 RID: 9145
		public static readonly DependencyProperty CurrentItemProperty = DependencyProperty.Register(#Phc.#3hc(107463724), typeof(object), typeof(GridControl));

		// Token: 0x040023BA RID: 9146
		public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register(#Phc.#3hc(107407441), typeof(object), typeof(GridControl));

		// Token: 0x040023BB RID: 9147
		public static readonly DependencyProperty SelectedItemsProperty = DependencyProperty.Register(#Phc.#3hc(107465678), typeof(IEnumerable), typeof(GridControl), null);

		// Token: 0x040023BC RID: 9148
		public static readonly DependencyProperty AutoGenerateColumnsProperty = DependencyProperty.Register(#Phc.#3hc(107463739), typeof(bool), typeof(GridControl));

		// Token: 0x040023CF RID: 9167
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal Canvas GridControlCanvas;

		// Token: 0x040023D0 RID: 9168
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal RadGridView RadGridView;

		// Token: 0x040023D1 RID: 9169
		private bool _contentLoaded;
	}
}
