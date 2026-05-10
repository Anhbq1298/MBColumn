using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;
using #7hc;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Grid
{
	// Token: 0x020009B9 RID: 2489
	public sealed class CheckBoxControlColumn : GridViewCheckBoxColumn
	{
		// Token: 0x17001727 RID: 5927
		// (get) Token: 0x060050AF RID: 20655 RVA: 0x00043425 File Offset: 0x00041625
		// (set) Token: 0x060050B0 RID: 20656 RVA: 0x0004343F File Offset: 0x0004163F
		public DelegateCommand Command
		{
			get
			{
				return (DelegateCommand)base.GetValue(CheckBoxControlColumn.CommandProperty);
			}
			set
			{
				base.SetValue(CheckBoxControlColumn.CommandProperty, value);
			}
		}

		// Token: 0x060050B1 RID: 20657 RVA: 0x0015EE30 File Offset: 0x0015D030
		public override FrameworkElement CreateCellElement(GridViewCell cell, object dataItem)
		{
			Control control = base.CreateCellElement(cell, dataItem) as Control;
			this.ApplyStyles(control);
			return control;
		}

		// Token: 0x060050B2 RID: 20658 RVA: 0x0015EE60 File Offset: 0x0015D060
		public override FrameworkElement CreateCellEditElement(GridViewCell cell, object dataItem)
		{
			CheckBox checkBox = new CheckBox();
			Binding binding = new Binding(this.DataMemberBinding.Path.Path)
			{
				Mode = BindingMode.TwoWay
			};
			checkBox.SetBinding(ToggleButton.IsCheckedProperty, binding);
			this.ApplyStyles(checkBox);
			this.AttachCommand(checkBox);
			return checkBox;
		}

		// Token: 0x060050B3 RID: 20659 RVA: 0x0015EEB8 File Offset: 0x0015D0B8
		public override void CopyPropertiesFrom(Telerik.Windows.Controls.GridViewColumn source)
		{
			base.CopyPropertiesFrom(source);
			CheckBoxControlColumn checkBoxControlColumn = source as CheckBoxControlColumn;
			if (checkBoxControlColumn != null)
			{
				this.Command = checkBoxControlColumn.Command;
			}
		}

		// Token: 0x060050B4 RID: 20660 RVA: 0x0015EEF0 File Offset: 0x0015D0F0
		private void AttachCommand(FrameworkElement cellElement)
		{
			CheckBox checkBox = cellElement as CheckBox;
			if (checkBox != null)
			{
				checkBox.Command = this.Command;
			}
		}

		// Token: 0x060050B5 RID: 20661 RVA: 0x0015EF20 File Offset: 0x0015D120
		private void ApplyStyles(Control checkBox)
		{
			checkBox.HorizontalAlignment = HorizontalAlignment.Center;
			checkBox.Margin = new Thickness(0.0);
			checkBox.Padding = new Thickness(0.0);
			checkBox.IsTabStop = false;
			checkBox.Background = Brushes.Transparent;
		}

		// Token: 0x04002384 RID: 9092
		public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(#Phc.#3hc(107350928), typeof(DelegateCommand), typeof(CheckBoxControlColumn), new PropertyMetadata(null));
	}
}
