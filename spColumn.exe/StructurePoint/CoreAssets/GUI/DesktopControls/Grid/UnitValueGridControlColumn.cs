using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Units.Formatters;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Grid
{
	// Token: 0x020009C8 RID: 2504
	public sealed class UnitValueGridControlColumn : GridViewDataColumn, IGridControlColumn, IUnitValueGridControlColumn
	{
		// Token: 0x1700175B RID: 5979
		// (get) Token: 0x06005164 RID: 20836 RVA: 0x00043723 File Offset: 0x00041923
		// (set) Token: 0x06005165 RID: 20837 RVA: 0x00043733 File Offset: 0x00041933
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

		// Token: 0x1700175C RID: 5980
		// (get) Token: 0x06005166 RID: 20838 RVA: 0x00043748 File Offset: 0x00041948
		// (set) Token: 0x06005167 RID: 20839 RVA: 0x0004376B File Offset: 0x0004196B
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

		// Token: 0x1700175D RID: 5981
		// (get) Token: 0x06005168 RID: 20840 RVA: 0x0004378F File Offset: 0x0004198F
		// (set) Token: 0x06005169 RID: 20841 RVA: 0x00043B7E File Offset: 0x00041D7E
		public GridViewLength ColumnWidth
		{
			get
			{
				return GridViewLength.CreateFromProviderValue(base.Width);
			}
			set
			{
				#X0d.#V0d(value, #Phc.#3hc(107386484), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.DesktopControls, #Phc.#3hc(107464728));
				base.Width = value.ConvertToProviderValue();
			}
		}

		// Token: 0x1700175E RID: 5982
		// (get) Token: 0x0600516A RID: 20842 RVA: 0x00043BB3 File Offset: 0x00041DB3
		// (set) Token: 0x0600516B RID: 20843 RVA: 0x00043BCD File Offset: 0x00041DCD
		public IUnitValueFormatter UnitValueFormatter
		{
			get
			{
				return (IUnitValueFormatter)base.GetValue(UnitValueGridControlColumn.UnitValueFormatterProperty);
			}
			set
			{
				base.SetValue(UnitValueGridControlColumn.UnitValueFormatterProperty, value);
			}
		}

		// Token: 0x1700175F RID: 5983
		// (get) Token: 0x0600516C RID: 20844 RVA: 0x00043BE7 File Offset: 0x00041DE7
		// (set) Token: 0x0600516D RID: 20845 RVA: 0x00043BF3 File Offset: 0x00041DF3
		public string CellEnabledPropertyPath { get; set; }

		// Token: 0x17001760 RID: 5984
		// (get) Token: 0x0600516E RID: 20846 RVA: 0x00043C04 File Offset: 0x00041E04
		// (set) Token: 0x0600516F RID: 20847 RVA: 0x00043C10 File Offset: 0x00041E10
		public bool ShowZeroAsEmptyString { get; set; }

		// Token: 0x17001761 RID: 5985
		// (get) Token: 0x06005170 RID: 20848 RVA: 0x00043C21 File Offset: 0x00041E21
		// (set) Token: 0x06005171 RID: 20849 RVA: 0x00043C2D File Offset: 0x00041E2D
		public bool ShowZeroAsEmptyCell { get; set; }

		// Token: 0x17001762 RID: 5986
		// (get) Token: 0x06005172 RID: 20850 RVA: 0x00043C3E File Offset: 0x00041E3E
		// (set) Token: 0x06005173 RID: 20851 RVA: 0x00043C4A File Offset: 0x00041E4A
		public bool DisableValidationErrorsInUI { get; set; }

		// Token: 0x06005174 RID: 20852 RVA: 0x0015FA48 File Offset: 0x0015DC48
		public override FrameworkElement CreateCellEditElement(GridViewCell cell, object dataItem)
		{
			if (cell == null)
			{
				return null;
			}
			UnitValueTextBox unitValueTextBox = (cell.GetEditingElement() as UnitValueTextBox) ?? new UnitValueTextBox();
			if (this.DisableValidationErrorsInUI)
			{
				Validation.SetErrorTemplate(unitValueTextBox, null);
			}
			base.BindingTarget = UnitValueTextBox.UnitValueProperty;
			Binding binding = this.MyCreateValueBinding();
			unitValueTextBox.UnitValueFormatter = this.UnitValueFormatter;
			TextAlignment? textAlignment = this.MyGetAlignment();
			unitValueTextBox.TextAlignment = (textAlignment ?? base.TextAlignment);
			unitValueTextBox.SelectAllTextOnFocus = false;
			unitValueTextBox.SelectAllTextOnMouseClick = false;
			unitValueTextBox.ToolTip = null;
			if (base.EditorStyle != null)
			{
				unitValueTextBox.Style = base.EditorStyle;
			}
			unitValueTextBox.SetBinding(UnitValueTextBox.UnitValueProperty, binding);
			unitValueTextBox.SetValue(ContextualHelp.HelpIDProperty, this.HelpId);
			unitValueTextBox.SetValue(ContextualHelp.ParentElementTypeProperty, ContextualHelp.GetParentElementType(this));
			return unitValueTextBox;
		}

		// Token: 0x06005175 RID: 20853 RVA: 0x0015FB3C File Offset: 0x0015DD3C
		public void SetUnitValueFormatterBinding(string propertyPath, object source)
		{
			base.SetBinding(UnitValueGridControlColumn.UnitValueFormatterProperty, new Binding
			{
				Path = new PropertyPath(propertyPath, new object[0]),
				Source = source,
				Mode = BindingMode.OneWay
			});
		}

		// Token: 0x06005176 RID: 20854 RVA: 0x0015FB88 File Offset: 0x0015DD88
		public override object GetNewValueFromEditor(object editor)
		{
			UnitValueTextBox unitValueTextBox = editor as UnitValueTextBox;
			UnitValueTextBox unitValueTextBox2;
			if (!false)
			{
				unitValueTextBox2 = unitValueTextBox;
			}
			if (unitValueTextBox2 != null)
			{
				unitValueTextBox2.UpdateBoundValue();
				return unitValueTextBox2.UnitValue;
			}
			return base.GetNewValueFromEditor(editor);
		}

		// Token: 0x06005177 RID: 20855 RVA: 0x0015FBC4 File Offset: 0x0015DDC4
		public override FrameworkElement CreateCellElement(GridViewCell cell, object dataItem)
		{
			FrameworkElement frameworkElement = base.CreateCellElement(cell, dataItem);
			IUnitValueFormatter unitValueFormatter = this.UnitValueFormatter;
			if (!string.IsNullOrEmpty(this.CellEnabledPropertyPath))
			{
				Binding binding = new Binding(this.CellEnabledPropertyPath);
				binding.Source = dataItem;
				binding.Mode = BindingMode.OneWay;
				BindingOperations.SetBinding(cell, UIElement.IsEnabledProperty, binding);
			}
			TextBlock textBlock = frameworkElement as TextBlock;
			if (textBlock != null)
			{
				object valueForItem = base.GetValueForItem(dataItem);
				double minValue = double.MinValue;
				bool flag = false;
				if (valueForItem != null)
				{
					flag = double.TryParse(valueForItem.ToString(), out minValue);
				}
				if (this.ShowZeroAsEmptyString && !cell.IsEnabled)
				{
					textBlock.Text = #Phc.#3hc(107465155);
				}
				else if (this.ShowZeroAsEmptyCell && flag && minValue == 0.0)
				{
					textBlock.Text = #Phc.#3hc(107381628);
				}
				else
				{
					string text = (valueForItem != null) ? valueForItem.ToString() : null;
					textBlock.Text = ((unitValueFormatter != null) ? unitValueFormatter.CreateDisplayValue(text) : text);
				}
				TextAlignment? textAlignment = this.MyGetAlignment();
				textBlock.TextAlignment = (textAlignment ?? base.TextAlignment);
			}
			return frameworkElement;
		}

		// Token: 0x06005178 RID: 20856 RVA: 0x0015FD00 File Offset: 0x0015DF00
		protected override object PrepareCellForEdit(FrameworkElement editingElement, RoutedEventArgs editingEventArgs)
		{
			UnitValueTextBox unitValueTextBox = editingElement as UnitValueTextBox;
			if (unitValueTextBox != null)
			{
				IUnitValueFormatter unitValueFormatter = this.UnitValueFormatter;
				if (unitValueFormatter != null)
				{
					unitValueTextBox.Text = unitValueFormatter.CreateDisplayValue(unitValueTextBox.UnitValue);
				}
			}
			return base.PrepareCellForEdit(editingElement, editingEventArgs);
		}

		// Token: 0x06005179 RID: 20857 RVA: 0x0015FD48 File Offset: 0x0015DF48
		private static void MyOnUnitValueFormatterChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			UnitValueGridControlColumn.<>c__DisplayClass34_0 CS$<>8__locals1 = new UnitValueGridControlColumn.<>c__DisplayClass34_0();
			CS$<>8__locals1.column = (UnitValueGridControlColumn)sender;
			INotifyPropertyChanged notifyPropertyChanged = e.OldValue as INotifyPropertyChanged;
			if (notifyPropertyChanged != null)
			{
				notifyPropertyChanged.PropertyChanged -= CS$<>8__locals1.<MyOnUnitValueFormatterChanged>g__FormatterOnPropertyChanged|0;
			}
			INotifyPropertyChanged notifyPropertyChanged2 = e.NewValue as INotifyPropertyChanged;
			if (notifyPropertyChanged2 != null)
			{
				notifyPropertyChanged2.PropertyChanged += CS$<>8__locals1.<MyOnUnitValueFormatterChanged>g__FormatterOnPropertyChanged|0;
			}
			CS$<>8__locals1.column.Refresh();
		}

		// Token: 0x0600517A RID: 20858 RVA: 0x0015FDC4 File Offset: 0x0015DFC4
		private Binding MyCreateValueBinding()
		{
			return new Binding
			{
				Mode = BindingMode.TwoWay,
				NotifyOnValidationError = true,
				UpdateSourceTrigger = UpdateSourceTrigger.LostFocus,
				Path = new PropertyPath(this.DataMemberBinding.Path.Path, new object[0]),
				ValidatesOnDataErrors = true,
				ValidatesOnNotifyDataErrors = true,
				ValidatesOnExceptions = false
			};
		}

		// Token: 0x0600517B RID: 20859 RVA: 0x0015FE30 File Offset: 0x0015E030
		private TextAlignment? MyGetAlignment()
		{
			IUnitValueFormatter unitValueFormatter = this.UnitValueFormatter;
			TextAlignment? result = null;
			if (unitValueFormatter != null)
			{
				switch (unitValueFormatter.GridAlignment)
				{
				case UnitValueAlignment.#a:
					result = new TextAlignment?(TextAlignment.Left);
					break;
				case UnitValueAlignment.#b:
					result = new TextAlignment?(TextAlignment.Right);
					break;
				case UnitValueAlignment.#c:
					result = new TextAlignment?(TextAlignment.Center);
					break;
				case UnitValueAlignment.#d:
					result = new TextAlignment?(TextAlignment.Justify);
					break;
				}
			}
			return result;
		}

		// Token: 0x0600517C RID: 20860 RVA: 0x00043C5B File Offset: 0x00041E5B
		public UnitValueGridControlColumn()
		{
			this.<DisableValidationErrorsInUI>k__BackingField = true;
			base..ctor();
		}

		// Token: 0x0600517E RID: 20862 RVA: 0x00043913 File Offset: 0x00041B13
		void IGridControlColumn.set_MinWidth(double value)
		{
			base.MinWidth = value;
		}

		// Token: 0x0600517F RID: 20863 RVA: 0x00043928 File Offset: 0x00041B28
		void IGridControlColumn.set_MaxWidth(double value)
		{
			base.MaxWidth = value;
		}

		// Token: 0x06005180 RID: 20864 RVA: 0x0004393D File Offset: 0x00041B3D
		Style IGridControlColumn.get_HeaderCellStyle()
		{
			return base.HeaderCellStyle;
		}

		// Token: 0x06005181 RID: 20865 RVA: 0x0004394D File Offset: 0x00041B4D
		void IGridControlColumn.set_HeaderCellStyle(Style value)
		{
			base.HeaderCellStyle = value;
		}

		// Token: 0x06005182 RID: 20866 RVA: 0x00043962 File Offset: 0x00041B62
		Style IGridControlColumn.get_EditorStyle()
		{
			return base.EditorStyle;
		}

		// Token: 0x06005183 RID: 20867 RVA: 0x00043972 File Offset: 0x00041B72
		void IGridControlColumn.set_EditorStyle(Style value)
		{
			base.EditorStyle = value;
		}

		// Token: 0x06005184 RID: 20868 RVA: 0x00043987 File Offset: 0x00041B87
		Brush IGridControlColumn.get_Background()
		{
			return base.Background;
		}

		// Token: 0x06005185 RID: 20869 RVA: 0x00043997 File Offset: 0x00041B97
		void IGridControlColumn.set_Background(Brush value)
		{
			base.Background = value;
		}

		// Token: 0x06005186 RID: 20870 RVA: 0x000439AC File Offset: 0x00041BAC
		string IGridControlColumn.get_FilterMemberPath()
		{
			return base.FilterMemberPath;
		}

		// Token: 0x06005187 RID: 20871 RVA: 0x000439BC File Offset: 0x00041BBC
		void IGridControlColumn.set_FilterMemberPath(string value)
		{
			base.FilterMemberPath = value;
		}

		// Token: 0x06005188 RID: 20872 RVA: 0x000439D1 File Offset: 0x00041BD1
		Type IGridControlColumn.get_FilterMemberType()
		{
			return base.FilterMemberType;
		}

		// Token: 0x06005189 RID: 20873 RVA: 0x000439E1 File Offset: 0x00041BE1
		void IGridControlColumn.set_FilterMemberType(Type value)
		{
			base.FilterMemberType = value;
		}

		// Token: 0x0400239F RID: 9119
		public static readonly DependencyProperty UnitValueFormatterProperty = DependencyProperty.Register(#Phc.#3hc(107456546), typeof(IUnitValueFormatter), typeof(UnitValueGridControlColumn), new PropertyMetadata(null, new PropertyChangedCallback(UnitValueGridControlColumn.MyOnUnitValueFormatterChanged)));
	}
}
