using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Grid
{
	// Token: 0x020009CB RID: 2507
	internal sealed class RadioButtonGridViewColumn : GridViewDataColumn, IGridControlColumn, IGridControlRadioButtonColumn
	{
		// Token: 0x06005199 RID: 20889 RVA: 0x00160104 File Offset: 0x0015E304
		public RadioButtonGridViewColumn()
		{
			this.RadioGroupName = Guid.NewGuid().ToString();
			base.EditTriggers = GridViewEditTriggers.CellClick;
		}

		// Token: 0x0600519A RID: 20890 RVA: 0x00043DAA File Offset: 0x00041FAA
		public override FrameworkElement CreateCellEditElement(GridViewCell cell, object dataItem)
		{
			return this.MyCreateCellElement(cell, dataItem, true);
		}

		// Token: 0x0600519B RID: 20891 RVA: 0x00043DC1 File Offset: 0x00041FC1
		public override FrameworkElement CreateCellElement(GridViewCell cell, object dataItem)
		{
			return this.MyCreateCellElement(cell, dataItem, false);
		}

		// Token: 0x0600519C RID: 20892 RVA: 0x00160138 File Offset: 0x0015E338
		public override IList<string> UpdateSourceWithEditorValue(GridViewCell gridViewCell)
		{
			List<string> list = new List<string>();
			if (gridViewCell == null)
			{
				return list;
			}
			RadioButton radioButton = gridViewCell.GetEditingElement() as RadioButton;
			if (radioButton == null)
			{
				return list;
			}
			BindingExpression bindingExpression = radioButton.ReadLocalValue(ToggleButton.IsCheckedProperty) as BindingExpression;
			if (bindingExpression == null)
			{
				return list;
			}
			bindingExpression.UpdateSource();
			list.AddRange(from error in Validation.GetErrors(radioButton)
			select error.ErrorContent.ToString());
			return list;
		}

		// Token: 0x17001766 RID: 5990
		// (get) Token: 0x0600519D RID: 20893 RVA: 0x0004378F File Offset: 0x0004198F
		// (set) Token: 0x0600519E RID: 20894 RVA: 0x00043DD8 File Offset: 0x00041FD8
		public GridViewLength ColumnWidth
		{
			get
			{
				return GridViewLength.CreateFromProviderValue(base.Width);
			}
			set
			{
				#X0d.#V0d(value, #Phc.#3hc(107386484), Component.DesktopControls, #Phc.#3hc(107465067));
				base.Width = value.ConvertToProviderValue();
			}
		}

		// Token: 0x17001767 RID: 5991
		// (get) Token: 0x0600519F RID: 20895 RVA: 0x00043723 File Offset: 0x00041923
		// (set) Token: 0x060051A0 RID: 20896 RVA: 0x00043733 File Offset: 0x00041933
		public HelpID HelpId
		{
			get
			{
				return ContextualHelp.GetHelpID(this);
			}
			set
			{
				ContextualHelp.SetHelpID(this, value);
			}
		}

		// Token: 0x17001768 RID: 5992
		// (get) Token: 0x060051A1 RID: 20897 RVA: 0x00043748 File Offset: 0x00041948
		// (set) Token: 0x060051A2 RID: 20898 RVA: 0x0004376B File Offset: 0x0004196B
		public bool UseGridHelpId
		{
			get
			{
				return ContextualHelp.GetParentElementType(this) == typeof(GridControl);
			}
			set
			{
				ContextualHelp.SetParentElementType(this, value ? typeof(GridControl) : null);
			}
		}

		// Token: 0x17001769 RID: 5993
		// (get) Token: 0x060051A3 RID: 20899 RVA: 0x00043E0D File Offset: 0x0004200D
		// (set) Token: 0x060051A4 RID: 20900 RVA: 0x00043E27 File Offset: 0x00042027
		public IDelegateCommand RadioButtonClickCommand
		{
			get
			{
				return (IDelegateCommand)base.GetValue(RadioButtonGridViewColumn.RadioButtonClickCommandProperty);
			}
			set
			{
				base.SetValue(RadioButtonGridViewColumn.RadioButtonClickCommandProperty, value);
			}
		}

		// Token: 0x1700176A RID: 5994
		// (get) Token: 0x060051A5 RID: 20901 RVA: 0x00043E41 File Offset: 0x00042041
		// (set) Token: 0x060051A6 RID: 20902 RVA: 0x00043E5B File Offset: 0x0004205B
		public string RadioGroupName
		{
			get
			{
				return (string)base.GetValue(RadioButtonGridViewColumn.RadioGroupNameProperty);
			}
			set
			{
				base.SetValue(RadioButtonGridViewColumn.RadioGroupNameProperty, value);
			}
		}

		// Token: 0x1700176B RID: 5995
		// (get) Token: 0x060051A7 RID: 20903 RVA: 0x00043E75 File Offset: 0x00042075
		// (set) Token: 0x060051A8 RID: 20904 RVA: 0x00043E8F File Offset: 0x0004208F
		public Style RadioButtonStyle
		{
			get
			{
				return (Style)base.GetValue(RadioButtonGridViewColumn.RadioButtonStyleProperty);
			}
			set
			{
				base.SetValue(RadioButtonGridViewColumn.RadioButtonStyleProperty, value);
			}
		}

		// Token: 0x060051A9 RID: 20905 RVA: 0x001601C4 File Offset: 0x0015E3C4
		private FrameworkElement MyCreateCellElement(GridViewCell cell, object dataItem, bool forEdit)
		{
			if (cell == null)
			{
				return null;
			}
			cell.Margin = new Thickness(0.0);
			cell.Padding = new Thickness(0.0);
			cell.BorderBrush = null;
			cell.BorderThickness = new Thickness(0.0);
			RadioButton radioButton = cell.Content as RadioButton;
			Binding dataMemberBinding = this.DataMemberBinding;
			if (radioButton == null)
			{
				radioButton = new RadioButton
				{
					GroupName = this.RadioGroupName,
					Style = this.RadioButtonStyle,
					IsTabStop = false
				};
			}
			if (dataMemberBinding != null)
			{
				Binding binding = new Binding
				{
					Path = dataMemberBinding.Path,
					Source = dataItem,
					Mode = BindingMode.OneWay
				};
				BindingOperations.SetBinding(radioButton, ToggleButton.IsCheckedProperty, binding);
			}
			radioButton.SetValue(ContextualHelp.HelpIDProperty, this.HelpId);
			radioButton.SetValue(ContextualHelp.ParentElementTypeProperty, ContextualHelp.GetParentElementType(this));
			if (forEdit)
			{
				radioButton.Command = this.RadioButtonClickCommand;
				radioButton.CommandParameter = dataItem;
				radioButton.IsHitTestVisible = true;
			}
			else
			{
				radioButton.IsHitTestVisible = false;
				radioButton.Command = null;
				radioButton.CommandParameter = null;
			}
			return radioButton;
		}

		// Token: 0x060051AB RID: 20907 RVA: 0x00043913 File Offset: 0x00041B13
		void IGridControlColumn.set_MinWidth(double value)
		{
			base.MinWidth = value;
		}

		// Token: 0x060051AC RID: 20908 RVA: 0x00043928 File Offset: 0x00041B28
		void IGridControlColumn.set_MaxWidth(double value)
		{
			base.MaxWidth = value;
		}

		// Token: 0x060051AD RID: 20909 RVA: 0x0004393D File Offset: 0x00041B3D
		Style IGridControlColumn.get_HeaderCellStyle()
		{
			return base.HeaderCellStyle;
		}

		// Token: 0x060051AE RID: 20910 RVA: 0x0004394D File Offset: 0x00041B4D
		void IGridControlColumn.set_HeaderCellStyle(Style value)
		{
			base.HeaderCellStyle = value;
		}

		// Token: 0x060051AF RID: 20911 RVA: 0x00043962 File Offset: 0x00041B62
		Style IGridControlColumn.get_EditorStyle()
		{
			return base.EditorStyle;
		}

		// Token: 0x060051B0 RID: 20912 RVA: 0x00043972 File Offset: 0x00041B72
		void IGridControlColumn.set_EditorStyle(Style value)
		{
			base.EditorStyle = value;
		}

		// Token: 0x060051B1 RID: 20913 RVA: 0x00043987 File Offset: 0x00041B87
		Brush IGridControlColumn.get_Background()
		{
			return base.Background;
		}

		// Token: 0x060051B2 RID: 20914 RVA: 0x00043997 File Offset: 0x00041B97
		void IGridControlColumn.set_Background(Brush value)
		{
			base.Background = value;
		}

		// Token: 0x060051B3 RID: 20915 RVA: 0x000439AC File Offset: 0x00041BAC
		string IGridControlColumn.get_FilterMemberPath()
		{
			return base.FilterMemberPath;
		}

		// Token: 0x060051B4 RID: 20916 RVA: 0x000439BC File Offset: 0x00041BBC
		void IGridControlColumn.set_FilterMemberPath(string value)
		{
			base.FilterMemberPath = value;
		}

		// Token: 0x060051B5 RID: 20917 RVA: 0x000439D1 File Offset: 0x00041BD1
		Type IGridControlColumn.get_FilterMemberType()
		{
			return base.FilterMemberType;
		}

		// Token: 0x060051B6 RID: 20918 RVA: 0x000439E1 File Offset: 0x00041BE1
		void IGridControlColumn.set_FilterMemberType(Type value)
		{
			base.FilterMemberType = value;
		}

		// Token: 0x040023A6 RID: 9126
		public static readonly DependencyProperty RadioButtonClickCommandProperty = DependencyProperty.Register(#Phc.#3hc(107465046), typeof(IDelegateCommand), typeof(RadioButtonGridViewColumn), null);

		// Token: 0x040023A7 RID: 9127
		public static readonly DependencyProperty RadioGroupNameProperty = DependencyProperty.Register(#Phc.#3hc(107465013), typeof(string), typeof(RadioButtonGridViewColumn), null);

		// Token: 0x040023A8 RID: 9128
		public static readonly DependencyProperty RadioButtonStyleProperty = DependencyProperty.Register(#Phc.#3hc(107464960), typeof(Style), typeof(RadioButtonGridViewColumn), null);
	}
}
