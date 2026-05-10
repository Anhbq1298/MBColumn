using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Grid
{
	// Token: 0x020009D8 RID: 2520
	public interface IGridControl
	{
		// Token: 0x17001784 RID: 6020
		// (get) Token: 0x0600526A RID: 21098
		// (set) Token: 0x0600526B RID: 21099
		HelpID HelpId { get; set; }

		// Token: 0x17001785 RID: 6021
		// (get) Token: 0x0600526C RID: 21100
		// (set) Token: 0x0600526D RID: 21101
		IEnumerable ItemsSource { get; set; }

		// Token: 0x17001786 RID: 6022
		// (get) Token: 0x0600526E RID: 21102
		// (set) Token: 0x0600526F RID: 21103
		IGridControlColumn CurrentColumn { get; set; }

		// Token: 0x17001787 RID: 6023
		// (get) Token: 0x06005270 RID: 21104
		// (set) Token: 0x06005271 RID: 21105
		object SelectedItem { get; set; }

		// Token: 0x17001788 RID: 6024
		// (get) Token: 0x06005272 RID: 21106
		// (set) Token: 0x06005273 RID: 21107
		object CurrentItem { get; set; }

		// Token: 0x17001789 RID: 6025
		// (get) Token: 0x06005274 RID: 21108
		IEnumerable<IGridControlColumn> Columns { get; }

		// Token: 0x1700178A RID: 6026
		// (get) Token: 0x06005275 RID: 21109
		IEnumerable CurrentItemsInView { get; }

		// Token: 0x1700178B RID: 6027
		// (get) Token: 0x06005276 RID: 21110
		bool IsEditing { get; }

		// Token: 0x1700178C RID: 6028
		// (get) Token: 0x06005277 RID: 21111
		IEnumerable<GridControlCellInfo> SelectedCells { get; }

		// Token: 0x1700178D RID: 6029
		// (get) Token: 0x06005278 RID: 21112
		// (set) Token: 0x06005279 RID: 21113
		bool SetFocusOnCollectionChange { get; set; }

		// Token: 0x1700178E RID: 6030
		// (get) Token: 0x0600527A RID: 21114
		// (set) Token: 0x0600527B RID: 21115
		bool BeginEditWhenLeavingComboBoxColumn { get; set; }

		// Token: 0x1700178F RID: 6031
		// (get) Token: 0x0600527C RID: 21116
		// (set) Token: 0x0600527D RID: 21117
		bool IsReadOnly { get; set; }

		// Token: 0x0600527E RID: 21118
		bool SetFocusOnControl();

		// Token: 0x0600527F RID: 21119
		void AddColumn(IGridControlColumn gridControlColumn);

		// Token: 0x06005280 RID: 21120
		void RemoveColumn(IGridControlColumn gridControlColumn);

		// Token: 0x06005281 RID: 21121
		IGridControlColumn CreateColumn(GridControlColumnType gridControlColumnType);

		// Token: 0x06005282 RID: 21122
		void BeginEdit();

		// Token: 0x06005283 RID: 21123
		void SelectItem(object item);

		// Token: 0x06005284 RID: 21124
		void ClearFilters();

		// Token: 0x06005285 RID: 21125
		void HandleCollectionChanged();

		// Token: 0x06005286 RID: 21126
		[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate")]
		void RaiseCancelEdit();

		// Token: 0x06005287 RID: 21127
		bool IsFilterActive(string uniqueColumnName);

		// Token: 0x06005288 RID: 21128
		void CancelEdit();

		// Token: 0x06005289 RID: 21129
		void ScrollIntoView(object dataItem);

		// Token: 0x0600528A RID: 21130
		void ScrollIntoView(object dataItem, object column, Action callback);

		// Token: 0x0600528B RID: 21131
		void BeginEdit(object dataItem, object column);

		// Token: 0x0600528C RID: 21132
		void CommitEdit();

		// Token: 0x0600528D RID: 21133
		void RebindData();

		// Token: 0x14000146 RID: 326
		// (add) Token: 0x0600528E RID: 21134
		// (remove) Token: 0x0600528F RID: 21135
		event EventHandler<GridControlRowValidatingEventArgs> OnRowValidating;

		// Token: 0x14000147 RID: 327
		// (add) Token: 0x06005290 RID: 21136
		// (remove) Token: 0x06005291 RID: 21137
		event EventHandler<GridControlCellValidatingEventArgs> OnCellValidating;

		// Token: 0x14000148 RID: 328
		// (add) Token: 0x06005292 RID: 21138
		// (remove) Token: 0x06005293 RID: 21139
		event EventHandler OnRowValidated;

		// Token: 0x14000149 RID: 329
		// (add) Token: 0x06005294 RID: 21140
		// (remove) Token: 0x06005295 RID: 21141
		event EventHandler OnCellValidated;

		// Token: 0x1400014A RID: 330
		// (add) Token: 0x06005296 RID: 21142
		// (remove) Token: 0x06005297 RID: 21143
		event EventHandler<GridControlDeletingEventArgs> OnDeleting;

		// Token: 0x1400014B RID: 331
		// (add) Token: 0x06005298 RID: 21144
		// (remove) Token: 0x06005299 RID: 21145
		event EventHandler<GridControlBeginningEditEventArgs> OnEditBeginning;

		// Token: 0x1400014C RID: 332
		// (add) Token: 0x0600529A RID: 21146
		// (remove) Token: 0x0600529B RID: 21147
		event EventHandler OnEditCanceled;

		// Token: 0x1400014D RID: 333
		// (add) Token: 0x0600529C RID: 21148
		// (remove) Token: 0x0600529D RID: 21149
		event EventHandler OnCommittingEdit;

		// Token: 0x1400014E RID: 334
		// (add) Token: 0x0600529E RID: 21150
		// (remove) Token: 0x0600529F RID: 21151
		event EventHandler OnCellEditEnded;

		// Token: 0x1400014F RID: 335
		// (add) Token: 0x060052A0 RID: 21152
		// (remove) Token: 0x060052A1 RID: 21153
		event EventHandler<GridControlRowEditEndedEventArgs> OnRowEditEnded;

		// Token: 0x14000150 RID: 336
		// (add) Token: 0x060052A2 RID: 21154
		// (remove) Token: 0x060052A3 RID: 21155
		event EventHandler OnInsertRequested;

		// Token: 0x14000151 RID: 337
		// (add) Token: 0x060052A4 RID: 21156
		// (remove) Token: 0x060052A5 RID: 21157
		event EventHandler OnDeleteRequested;

		// Token: 0x14000152 RID: 338
		// (add) Token: 0x060052A6 RID: 21158
		// (remove) Token: 0x060052A7 RID: 21159
		event EventHandler OnSelectionChanged;

		// Token: 0x14000153 RID: 339
		// (add) Token: 0x060052A8 RID: 21160
		// (remove) Token: 0x060052A9 RID: 21161
		event EventHandler<GridControlChangeRowIndexRequestEventArgs> OnChangeRowIndexRequested;

		// Token: 0x14000154 RID: 340
		// (add) Token: 0x060052AA RID: 21162
		// (remove) Token: 0x060052AB RID: 21163
		event EventHandler<GridControlFiltersStateChangedEventArgs> OnFiltersStateChanged;

		// Token: 0x14000155 RID: 341
		// (add) Token: 0x060052AC RID: 21164
		// (remove) Token: 0x060052AD RID: 21165
		event EventHandler<GridControlRowDoubleClickEventArgs> OnRowDoubleClicked;

		// Token: 0x14000156 RID: 342
		// (add) Token: 0x060052AE RID: 21166
		// (remove) Token: 0x060052AF RID: 21167
		event EventHandler<GridControlCellDoubleClickEventArgs> OnCellDoubleClicked;

		// Token: 0x060052B0 RID: 21168
		object RetrieveCurrentItem();

		// Token: 0x060052B1 RID: 21169
		object RetrieveSelectedItem();

		// Token: 0x060052B2 RID: 21170
		void ScrollIntoViewAsync(object dataItem, Action finishedCallback, Action failedCallback);

		// Token: 0x060052B3 RID: 21171
		void ClearSelection();

		// Token: 0x060052B4 RID: 21172
		void AddColumns(ICollection<IGridControlColumn> columns);

		// Token: 0x060052B5 RID: 21173
		void RemoveColumns(ICollection<IGridControlColumn> columns);
	}
}
