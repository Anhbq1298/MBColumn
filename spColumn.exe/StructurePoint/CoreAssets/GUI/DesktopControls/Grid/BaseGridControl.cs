using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using #7hc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic.ExtendedColorPicker;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Grid
{
	// Token: 0x020009AC RID: 2476
	public sealed class BaseGridControl : RadGridView
	{
		// Token: 0x0600505C RID: 20572 RVA: 0x0015D9B4 File Offset: 0x0015BBB4
		public BaseGridControl()
		{
			base.KeyboardCommandProvider = new CustomKeyboardCommandProvider(this);
			base.Loaded += this.BaseGridControl_Loaded;
			base.SizeChanged += this.BaseGridControl_SizeChanged;
			base.GroupRenderMode = GroupRenderMode.Flat;
			base.NewRowPosition = GridViewNewRowPosition.None;
			ScrollViewer.SetHorizontalScrollBarVisibility(this, ScrollBarVisibility.Auto);
			base.BeginningEdit += this.BaseGridControl_BeginningEdit;
		}

		// Token: 0x14000134 RID: 308
		// (add) Token: 0x0600505D RID: 20573 RVA: 0x0015DA2C File Offset: 0x0015BC2C
		// (remove) Token: 0x0600505E RID: 20574 RVA: 0x0015DA70 File Offset: 0x0015BC70
		public event EventHandler EditCanceled;

		// Token: 0x1700171D RID: 5917
		// (get) Token: 0x0600505F RID: 20575 RVA: 0x00042F76 File Offset: 0x00041176
		// (set) Token: 0x06005060 RID: 20576 RVA: 0x00042F90 File Offset: 0x00041190
		public Thickness LeftTopBorder
		{
			get
			{
				return (Thickness)base.GetValue(BaseGridControl.LeftTopBorderProperty);
			}
			set
			{
				base.SetValue(BaseGridControl.LeftTopBorderProperty, value);
			}
		}

		// Token: 0x1700171E RID: 5918
		// (get) Token: 0x06005061 RID: 20577 RVA: 0x00042FAF File Offset: 0x000411AF
		// (set) Token: 0x06005062 RID: 20578 RVA: 0x00042FC9 File Offset: 0x000411C9
		public bool PreventLastItemFromDeleting
		{
			get
			{
				return (bool)base.GetValue(BaseGridControl.PreventLastItemFromDeletingProperty);
			}
			set
			{
				base.SetValue(BaseGridControl.PreventLastItemFromDeletingProperty, value);
			}
		}

		// Token: 0x1700171F RID: 5919
		// (get) Token: 0x06005063 RID: 20579 RVA: 0x00042FE8 File Offset: 0x000411E8
		// (set) Token: 0x06005064 RID: 20580 RVA: 0x00043002 File Offset: 0x00041202
		public ColumnsSizeMode ColumnsSizeMode
		{
			get
			{
				return (ColumnsSizeMode)base.GetValue(BaseGridControl.ColumnsSizeModeProperty);
			}
			set
			{
				base.SetValue(BaseGridControl.ColumnsSizeModeProperty, value);
			}
		}

		// Token: 0x17001720 RID: 5920
		// (get) Token: 0x06005065 RID: 20581 RVA: 0x00043021 File Offset: 0x00041221
		// (set) Token: 0x06005066 RID: 20582 RVA: 0x0004303B File Offset: 0x0004123B
		public double ReferenceWidth
		{
			get
			{
				return (double)base.GetValue(BaseGridControl.ReferenceWidthProperty);
			}
			set
			{
				base.SetValue(BaseGridControl.ReferenceWidthProperty, value);
			}
		}

		// Token: 0x17001721 RID: 5921
		// (get) Token: 0x06005067 RID: 20583 RVA: 0x0004305A File Offset: 0x0004125A
		// (set) Token: 0x06005068 RID: 20584 RVA: 0x00043074 File Offset: 0x00041274
		public double MinGridColumnWidth
		{
			get
			{
				return (double)base.GetValue(BaseGridControl.MinGridColumnWidthProperty);
			}
			set
			{
				base.SetValue(BaseGridControl.MinGridColumnWidthProperty, value);
			}
		}

		// Token: 0x06005069 RID: 20585 RVA: 0x0015DAB4 File Offset: 0x0015BCB4
		public void ApplyMaxWidthConstraints()
		{
			for (int i = 0; i < this.baseColumnWidths.Count; i++)
			{
				base.Columns[i].MinWidth = this.MinGridColumnWidth;
				base.Columns[i].MaxWidth = this.GetMaxColumnWidth(i);
			}
		}

		// Token: 0x0600506A RID: 20586 RVA: 0x0015DB14 File Offset: 0x0015BD14
		public void AutoSizeColumns()
		{
			if (this.ColumnsSizeMode != ColumnsSizeMode.AdjustAutomatically)
			{
				return;
			}
			for (int i = 0; i < this.baseColumnWidths.Count; i++)
			{
				double maxColumnWidth = this.GetMaxColumnWidth(i);
				double num = Math.Max(this.GetAutoSizedWidth(i), this.MinGridColumnWidth + 1.0);
				num = Math.Min(maxColumnWidth - 1.0, num);
				base.Columns[i].MinWidth = this.MinGridColumnWidth;
				base.Columns[i].Width = num;
				base.Columns[i].MaxWidth = maxColumnWidth;
			}
			LayoutHelper.BeginInvokeOnApplicationThread(delegate()
			{
				GridViewScrollViewer gridViewScrollViewer = this.ChildrenOfType<GridViewScrollViewer>().FirstOrDefault<GridViewScrollViewer>();
				if (gridViewScrollViewer == null)
				{
					return;
				}
				gridViewScrollViewer.ScrollToHorizontalOffset(1.0);
			});
		}

		// Token: 0x0600506B RID: 20587 RVA: 0x0015DBEC File Offset: 0x0015BDEC
		public void KeepMaxWidthColumns()
		{
			if (this.ColumnsSizeMode != ColumnsSizeMode.MaintainMaxSize)
			{
				return;
			}
			for (int i = 0; i < this.baseColumnWidths.Count; i++)
			{
				base.Columns[i].MinWidth = this.MinGridColumnWidth;
				base.Columns[i].Width = this.GetMaxColumnWidth(i);
				base.Columns[i].MaxWidth = this.GetMaxColumnWidth(i);
			}
		}

		// Token: 0x0600506C RID: 20588 RVA: 0x0015DC74 File Offset: 0x0015BE74
		public bool HasValidationErrors()
		{
			IEnumerable<DependencyObject> source = this.GetChildrenOfType<TextBox>().OfType<DependencyObject>().Union(this.GetChildrenOfType<ComboBox>()).Union(this.GetChildrenOfType<RadComboBox>()).Union(this.GetChildrenOfType<CheckBox>());
			Func<DependencyObject, bool> predicate;
			if ((predicate = BaseGridControl.<>O.<0>__GetHasError) == null)
			{
				predicate = (BaseGridControl.<>O.<0>__GetHasError = new Func<DependencyObject, bool>(Validation.GetHasError));
			}
			return source.Any(predicate);
		}

		// Token: 0x0600506D RID: 20589 RVA: 0x00043093 File Offset: 0x00041293
		public void InvalidateBorders()
		{
			if (this.GetChildrenOfType<ScrollViewer>().First<ScrollViewer>().ComputedVerticalScrollBarVisibility != Visibility.Visible)
			{
				base.BorderThickness = this.LeftTopBorder;
				return;
			}
			base.BorderThickness = BaseGridControl.UniformBorder;
		}

		// Token: 0x0600506E RID: 20590 RVA: 0x0015DCDC File Offset: 0x0015BEDC
		public void RefreshColumnWidths()
		{
			this.baseColumnWidths.Clear();
			this.baseColumnWidths.AddRange(from item in base.Columns.OfType<Telerik.Windows.Controls.GridViewColumn>()
			select item.Width.Value);
		}

		// Token: 0x0600506F RID: 20591 RVA: 0x000430CB File Offset: 0x000412CB
		internal void HandleEditCanceledByUser()
		{
			this.OnEditCanceled();
		}

		// Token: 0x06005070 RID: 20592 RVA: 0x0015DD3C File Offset: 0x0015BF3C
		protected override void OnPreviewKeyDown(KeyEventArgs e)
		{
			GridViewCell currentCell = base.CurrentCell;
			if (currentCell == null)
			{
				return;
			}
			if (e.Key == Key.Tab && !currentCell.IsValid)
			{
				if (currentCell.IsInEditMode)
				{
					base.CommitEdit();
				}
				if (!currentCell.IsValid)
				{
					e.Handled = true;
					return;
				}
			}
			else
			{
				if (e.Key == Key.Space && currentCell.Content is CheckBox && !currentCell.IsInEditMode)
				{
					currentCell.BeginEdit();
					return;
				}
				if (e.Key == Key.Space && currentCell.Content is Border && !currentCell.IsInEditMode)
				{
					currentCell.BeginEdit();
					return;
				}
				RadComboBox radComboBox = e.OriginalSource as RadComboBox;
				if (radComboBox != null && e.Key == Key.Space)
				{
					radComboBox.IsDropDownOpen = true;
					return;
				}
				ExtendedColorPicker extendedColorPicker = e.OriginalSource as ExtendedColorPicker;
				if (extendedColorPicker != null && e.Key == Key.Space)
				{
					if (!extendedColorPicker.IsDropDownOpen)
					{
						extendedColorPicker.SetFocus();
						return;
					}
				}
				else if (e.OriginalSource is CheckBox && e.Key == Key.Escape && currentCell.IsInEditMode)
				{
					if (currentCell.IsInEditMode)
					{
						currentCell.CommitEdit();
						return;
					}
				}
				else
				{
					if (e.OriginalSource is ExtendedColorPicker && e.Key == Key.Escape && currentCell.IsInEditMode)
					{
						currentCell.CommitEdit();
						return;
					}
					base.OnPreviewKeyDown(e);
				}
			}
		}

		// Token: 0x06005071 RID: 20593 RVA: 0x0015DE98 File Offset: 0x0015C098
		protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
		{
			GridViewCell gridViewCell = (e.OriginalSource as FrameworkElement).ParentOfType<GridViewCell>();
			if (gridViewCell == null || base.CurrentCell == null || !base.CurrentCell.IsInEditMode || base.CurrentCell == gridViewCell)
			{
				TextBlock textBlock = e.OriginalSource as TextBlock;
				if (textBlock != null)
				{
					GridViewCell gridViewCell2 = textBlock.ParentOfType<GridViewCell>();
					if (gridViewCell2 != null && gridViewCell2.ParentRow.IsSelected && !(gridViewCell2.Column is GridViewComboBoxColumn))
					{
						gridViewCell2.BeginEdit();
						return;
					}
				}
				else
				{
					GridViewCheckBox gridViewCheckBox = ((gridViewCell != null) ? gridViewCell.Content : null) as GridViewCheckBox;
					if (gridViewCheckBox != null)
					{
						GridViewCell gridViewCell3 = gridViewCheckBox.ParentOfType<GridViewCell>();
						if (gridViewCell3 == null)
						{
							return;
						}
						gridViewCell3.BeginEdit();
						return;
					}
					else
					{
						base.OnPreviewMouseDown(e);
					}
				}
				return;
			}
			CustomCheckBox customCheckBox = gridViewCell.Content as CustomCheckBox;
			RadComboBox radComboBox = gridViewCell.Content as RadComboBox;
			if (base.CurrentCell.ChildrenOfType<TextBox>() != null && customCheckBox != null)
			{
				base.OnPreviewMouseDown(e);
				return;
			}
			if (base.CurrentCell.ChildrenOfType<TextBox>() != null && radComboBox != null)
			{
				if (base.CurrentCell.IsInEditMode)
				{
					base.CurrentCell.CommitEdit();
				}
				if (!base.CurrentCell.IsValid)
				{
					e.Handled = true;
					return;
				}
				if (gridViewCell.ParentRow.IsSelected)
				{
					radComboBox.IsDropDownOpen = true;
					return;
				}
			}
			if (base.CurrentCell.IsInEditMode)
			{
				base.CurrentCell.CommitEdit();
			}
			if (gridViewCell.ChildrenOfType<TextBox>() != null && gridViewCell.ParentRow.IsSelected)
			{
				gridViewCell.BeginEdit();
				return;
			}
			if (((gridViewCell != null) ? gridViewCell.Content : null) is GridViewCheckBox)
			{
				gridViewCell.BeginEdit();
				return;
			}
			base.OnPreviewMouseDown(e);
		}

		// Token: 0x06005072 RID: 20594 RVA: 0x000430DB File Offset: 0x000412DB
		protected void OnEditCanceled()
		{
			EventHandler editCanceled = this.EditCanceled;
			if (editCanceled == null)
			{
				return;
			}
			editCanceled(this, EventArgs.Empty);
		}

		// Token: 0x06005073 RID: 20595 RVA: 0x0015E04C File Offset: 0x0015C24C
		private void BaseGridControl_BeginningEdit(object sender, GridViewBeginningEditRoutedEventArgs e)
		{
			if (base.SelectionMode != SelectionMode.Single && base.SelectedItems.Count > 1)
			{
				List<object> list = base.SelectedItems.ToList<object>();
				list.Remove(e.Row.DataContext);
				base.SelectedItems.#71d(list);
				base.SetValue(DataControl.SelectedItemProperty, e.Row.DataContext);
			}
		}

		// Token: 0x06005074 RID: 20596 RVA: 0x000430FF File Offset: 0x000412FF
		private void BaseGridControl_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			this.AutoSizeColumns();
		}

		// Token: 0x06005075 RID: 20597 RVA: 0x0015E0BC File Offset: 0x0015C2BC
		private void BaseGridControl_Loaded(object sender, RoutedEventArgs e)
		{
			if (this.loaded)
			{
				return;
			}
			this.loaded = true;
			this.RefreshColumnWidths();
			ScrollViewer scrollViewer = this.GetChildrenOfType<ScrollViewer>().FirstOrDefault<ScrollViewer>();
			if (scrollViewer != null)
			{
				scrollViewer.ScrollChanged += this.Viewer_ScrollChanged;
			}
		}

		// Token: 0x06005076 RID: 20598 RVA: 0x0004310F File Offset: 0x0004130F
		private void Viewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
		{
			this.InvalidateBorders();
		}

		// Token: 0x06005077 RID: 20599 RVA: 0x0015E10C File Offset: 0x0015C30C
		private static void ColumnsSizeModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			BaseGridControl baseGridControl = d as BaseGridControl;
			if (baseGridControl != null)
			{
				baseGridControl.OnColumnsSizeModeChanged((ColumnsSizeMode)e.NewValue);
			}
		}

		// Token: 0x06005078 RID: 20600 RVA: 0x0015E144 File Offset: 0x0015C344
		private double GetMaxColumnWidth(int index)
		{
			return Math.Floor(1.0 * this.baseColumnWidths[index] / this.baseColumnWidths.Sum() * (this.ReferenceWidth - 35.0)) - 3.0;
		}

		// Token: 0x06005079 RID: 20601 RVA: 0x0015E1A0 File Offset: 0x0015C3A0
		private double GetAutoSizedWidth(int index)
		{
			double num = 1.0 * this.baseColumnWidths[index] / this.baseColumnWidths.Sum();
			return Math.Floor((base.ActualWidth - 40.0) * num) - 1.0;
		}

		// Token: 0x0600507A RID: 20602 RVA: 0x0015E200 File Offset: 0x0015C400
		private void OnColumnsSizeModeChanged(ColumnsSizeMode newValue)
		{
			switch (newValue)
			{
			case ColumnsSizeMode.None:
				return;
			case ColumnsSizeMode.AdjustAutomatically:
				this.AutoSizeColumns();
				return;
			case ColumnsSizeMode.MaintainMaxSize:
				this.KeepMaxWidthColumns();
				return;
			default:
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107465336), newValue, null);
			}
		}

		// Token: 0x04002369 RID: 9065
		private static readonly Thickness UniformBorder = new Thickness(1.0);

		// Token: 0x0400236A RID: 9066
		public static readonly DependencyProperty ColumnsSizeModeProperty = DependencyProperty.Register(#Phc.#3hc(107465291), typeof(ColumnsSizeMode), typeof(BaseGridControl), new PropertyMetadata(ColumnsSizeMode.None, new PropertyChangedCallback(BaseGridControl.ColumnsSizeModeChanged)));

		// Token: 0x0400236B RID: 9067
		public static readonly DependencyProperty ReferenceWidthProperty = DependencyProperty.Register(#Phc.#3hc(107465302), typeof(double), typeof(BaseGridControl), new PropertyMetadata(700.0));

		// Token: 0x0400236C RID: 9068
		public static readonly DependencyProperty PreventLastItemFromDeletingProperty = DependencyProperty.Register(#Phc.#3hc(107465249), typeof(bool), typeof(BaseGridControl), new PropertyMetadata(true));

		// Token: 0x0400236D RID: 9069
		public static readonly DependencyProperty LeftTopBorderProperty = DependencyProperty.Register(#Phc.#3hc(107465244), typeof(Thickness), typeof(BaseGridControl), new PropertyMetadata(new Thickness(1.0, 1.0, 1.0, 1.0)));

		// Token: 0x0400236E RID: 9070
		public static readonly DependencyProperty MinGridColumnWidthProperty = DependencyProperty.Register(#Phc.#3hc(107465703), typeof(double), typeof(BaseGridControl), new PropertyMetadata(25.0));

		// Token: 0x0400236F RID: 9071
		private readonly List<double> baseColumnWidths = new List<double>();

		// Token: 0x04002370 RID: 9072
		private bool loaded;

		// Token: 0x020009AD RID: 2477
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x04002372 RID: 9074
			public static Func<DependencyObject, bool> <0>__GetHasError;
		}
	}
}
