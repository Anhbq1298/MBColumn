using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Threading;
using #7hc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic.ExtendedColorPicker;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Grid
{
	// Token: 0x020009BA RID: 2490
	public sealed class ExtendedColorPickerColumn : GridViewBoundColumnBase
	{
		// Token: 0x17001728 RID: 5928
		// (get) Token: 0x060050B8 RID: 20664 RVA: 0x0004349D File Offset: 0x0004169D
		// (set) Token: 0x060050B9 RID: 20665 RVA: 0x000434B7 File Offset: 0x000416B7
		public DelegateCommand Command
		{
			get
			{
				return (DelegateCommand)base.GetValue(ExtendedColorPickerColumn.CommandProperty);
			}
			set
			{
				base.SetValue(ExtendedColorPickerColumn.CommandProperty, value);
			}
		}

		// Token: 0x060050BA RID: 20666 RVA: 0x0015EF7C File Offset: 0x0015D17C
		public override FrameworkElement CreateCellElement(GridViewCell cell, object dataItem)
		{
			Border border = new Border();
			Binding binding = new Binding(this.DataMemberBinding.Path.Path)
			{
				Mode = BindingMode.OneWay,
				Converter = new ColorToBrushConverter()
			};
			border.SetBinding(Border.BackgroundProperty, binding);
			border.Width = 45.0;
			border.Height = 16.0;
			return border;
		}

		// Token: 0x060050BB RID: 20667 RVA: 0x0015EFF0 File Offset: 0x0015D1F0
		protected override object PrepareCellForEdit(FrameworkElement editingElement, RoutedEventArgs editingEventArgs)
		{
			ExtendedColorPicker picker = editingElement as ExtendedColorPicker;
			if (picker != null)
			{
				GridViewCell cell = picker.ParentOfType<GridViewCell>();
				LayoutHelper.BeginInvokeOnApplicationThread(delegate()
				{
					picker.IsDropDownOpen = (cell != null && cell.ParentRow.IsSelected);
				}, DispatcherPriority.Input);
				return null;
			}
			return base.PrepareCellForEdit(editingElement, editingEventArgs);
		}

		// Token: 0x060050BC RID: 20668 RVA: 0x0015F054 File Offset: 0x0015D254
		public override FrameworkElement CreateCellEditElement(GridViewCell cell, object dataItem)
		{
			ExtendedColorPicker extendedColorPicker = new ExtendedColorPicker
			{
				Width = 45.0,
				Height = 16.0,
				Margin = new Thickness(0.0),
				Padding = new Thickness(0.0),
				HorizontalAlignment = HorizontalAlignment.Stretch,
				VerticalAlignment = VerticalAlignment.Center,
				IsTabStop = false,
				DropDownClosedCommand = this.Command
			};
			Binding dataMemberBinding = this.DataMemberBinding;
			if (dataMemberBinding != null)
			{
				Binding binding = new Binding
				{
					Path = dataMemberBinding.Path,
					Source = dataItem,
					Mode = BindingMode.TwoWay
				};
				BindingOperations.SetBinding(extendedColorPicker, RadColorPicker.SelectedColorProperty, binding);
			}
			return extendedColorPicker;
		}

		// Token: 0x060050BD RID: 20669 RVA: 0x0015F118 File Offset: 0x0015D318
		public override void CopyPropertiesFrom(Telerik.Windows.Controls.GridViewColumn source)
		{
			base.CopyPropertiesFrom(source);
			ExtendedColorPickerColumn extendedColorPickerColumn = source as ExtendedColorPickerColumn;
			if (extendedColorPickerColumn != null)
			{
				this.Command = extendedColorPickerColumn.Command;
			}
		}

		// Token: 0x060050BE RID: 20670 RVA: 0x0015F150 File Offset: 0x0015D350
		public override object GetNewValueFromEditor(object editor)
		{
			ExtendedColorPicker extendedColorPicker = editor as ExtendedColorPicker;
			ExtendedColorPicker extendedColorPicker2;
			if (!false)
			{
				extendedColorPicker2 = extendedColorPicker;
			}
			if (extendedColorPicker2 != null)
			{
				extendedColorPicker2.SetOpen(false);
				return extendedColorPicker2.SelectedColor;
			}
			return null;
		}

		// Token: 0x04002385 RID: 9093
		private const double ColorPickerWidth = 45.0;

		// Token: 0x04002386 RID: 9094
		private const double ColorPickerHeight = 16.0;

		// Token: 0x04002387 RID: 9095
		public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(#Phc.#3hc(107350928), typeof(DelegateCommand), typeof(ExtendedColorPickerColumn), new PropertyMetadata(null));
	}
}
