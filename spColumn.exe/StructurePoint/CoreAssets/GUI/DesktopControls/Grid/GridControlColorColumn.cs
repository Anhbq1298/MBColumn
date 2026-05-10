using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Grid
{
	// Token: 0x020009CF RID: 2511
	internal sealed class GridControlColorColumn : GridViewDataColumn, IComponentConnector, IGridControlColumn
	{
		// Token: 0x060051C2 RID: 20930 RVA: 0x00043EED File Offset: 0x000420ED
		public GridControlColorColumn()
		{
			base.EditTriggers = GridViewEditTriggers.CellClick;
			base.FilteringControl = new GridControlColorFilteringControl();
		}

		// Token: 0x060051C3 RID: 20931 RVA: 0x0016043C File Offset: 0x0015E63C
		public override FrameworkElement CreateCellElement(GridViewCell cell, object dataItem)
		{
			if (cell == null)
			{
				return null;
			}
			cell.Margin = new Thickness(0.0);
			cell.Padding = new Thickness(0.0);
			Border border = new Border();
			border.HorizontalAlignment = HorizontalAlignment.Stretch;
			border.VerticalAlignment = VerticalAlignment.Stretch;
			border.Width = 80.0;
			border.Height = 15.0;
			border.BorderThickness = new Thickness(1.0);
			border.BorderBrush = new SolidColorBrush(Colors.Black);
			border.Margin = new Thickness(3.0, 3.0, 4.0, 4.0);
			border.CornerRadius = new CornerRadius(0.0);
			border.ToolTip = GridControlColorColumn.MyCreateTooltip(this.MyGetColor(dataItem));
			border.Padding = new Thickness(0.0);
			Binding binding = new Binding(this.DataMemberBinding.Path.Path)
			{
				Mode = BindingMode.OneWay,
				Converter = new ColorToBrushConverter()
			};
			border.SetBinding(Border.BackgroundProperty, binding);
			return border;
		}

		// Token: 0x060051C4 RID: 20932 RVA: 0x00160588 File Offset: 0x0015E788
		public override FrameworkElement CreateCellEditElement(GridViewCell cell, object dataItem)
		{
			if (cell == null)
			{
				return null;
			}
			cell.Margin = new Thickness(0.0);
			cell.Padding = new Thickness(0.0);
			base.BindingTarget = RadColorPicker.SelectedColorProperty;
			Binding binding = this.MyCreateValueBinding();
			RadColorPicker radColorPicker = new RadColorPicker();
			radColorPicker.Width = 80.0;
			radColorPicker.Height = 15.0;
			radColorPicker.Style = base.EditorStyle;
			radColorPicker.StandardPaletteVisibility = Visibility.Visible;
			radColorPicker.HeaderPaletteVisibility = Visibility.Visible;
			radColorPicker.BorderBrush = new SolidColorBrush(Colors.Black);
			radColorPicker.BorderThickness = new Thickness(1.0);
			radColorPicker.Margin = new Thickness(3.0, 3.0, 4.0, 4.0);
			radColorPicker.Padding = new Thickness(0.0);
			radColorPicker.ToolTip = GridControlColorColumn.MyCreateTooltip(this.MyGetColor(dataItem));
			radColorPicker.SetValue(ContextualHelp.HelpIDProperty, this.HelpId);
			radColorPicker.SetValue(ContextualHelp.ParentElementTypeProperty, ContextualHelp.GetParentElementType(this));
			radColorPicker.SetBinding(RadColorPicker.SelectedColorProperty, binding);
			binding = new Binding(this.DataMemberBinding.Path.Path)
			{
				Mode = BindingMode.OneWay,
				Converter = new ColorToBrushConverter()
			};
			radColorPicker.SetBinding(Control.BackgroundProperty, binding);
			return radColorPicker;
		}

		// Token: 0x060051C5 RID: 20933 RVA: 0x0016070C File Offset: 0x0015E90C
		public override IList<string> UpdateSourceWithEditorValue(GridViewCell gridViewCell)
		{
			List<string> list = new List<string>();
			if (gridViewCell == null)
			{
				return list;
			}
			RadColorPicker radColorPicker = gridViewCell.GetEditingElement() as RadColorPicker;
			if (radColorPicker == null)
			{
				return list;
			}
			BindingExpression bindingExpression = radColorPicker.ReadLocalValue(RadColorPicker.SelectedColorProperty) as BindingExpression;
			if (bindingExpression == null)
			{
				return list;
			}
			bindingExpression.UpdateSource();
			foreach (ValidationError validationError in Validation.GetErrors(radColorPicker))
			{
				list.Add(validationError.ErrorContent.ToString());
			}
			return list;
		}

		// Token: 0x060051C6 RID: 20934 RVA: 0x001607BC File Offset: 0x0015E9BC
		public override object GetNewValueFromEditor(object editor)
		{
			RadColorPicker radColorPicker = editor as RadColorPicker;
			if (radColorPicker == null)
			{
				return null;
			}
			return radColorPicker.SelectedColor;
		}

		// Token: 0x1700176E RID: 5998
		// (get) Token: 0x060051C7 RID: 20935 RVA: 0x0004378F File Offset: 0x0004198F
		// (set) Token: 0x060051C8 RID: 20936 RVA: 0x00043F07 File Offset: 0x00042107
		public GridViewLength ColumnWidth
		{
			get
			{
				return GridViewLength.CreateFromProviderValue(base.Width);
			}
			set
			{
				#X0d.#V0d(value, #Phc.#3hc(107386484), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.DesktopControls, #Phc.#3hc(107464326));
				base.Width = value.ConvertToProviderValue();
			}
		}

		// Token: 0x1700176F RID: 5999
		// (get) Token: 0x060051C9 RID: 20937 RVA: 0x00043723 File Offset: 0x00041923
		// (set) Token: 0x060051CA RID: 20938 RVA: 0x00043733 File Offset: 0x00041933
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

		// Token: 0x17001770 RID: 6000
		// (get) Token: 0x060051CB RID: 20939 RVA: 0x00043748 File Offset: 0x00041948
		// (set) Token: 0x060051CC RID: 20940 RVA: 0x0004376B File Offset: 0x0004196B
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

		// Token: 0x060051CD RID: 20941 RVA: 0x001607EC File Offset: 0x0015E9EC
		private Color MyGetColor(object dataItem)
		{
			Color result = default(Color);
			if (this.DataMemberBinding != null && this.DataMemberBinding.Path != null && dataItem != null)
			{
				string path = this.DataMemberBinding.Path.Path;
				object value = dataItem.GetType().GetProperty(path).GetValue(dataItem, null);
				if (value is Color)
				{
					result = (Color)value;
				}
			}
			return result;
		}

		// Token: 0x060051CE RID: 20942 RVA: 0x0016085C File Offset: 0x0015EA5C
		private static object MyCreateTooltip(Color color)
		{
			StackPanel stackPanel = new StackPanel();
			TextBlock element = new TextBlock
			{
				Text = Strings.StringColor,
				FontWeight = FontWeights.Bold
			};
			TextBlock element2 = new TextBlock
			{
				TextWrapping = TextWrapping.Wrap,
				Text = GridControlColorColumn.MyFormatColor(color)
			};
			stackPanel.Children.Add(element);
			stackPanel.Children.Add(element2);
			return stackPanel;
		}

		// Token: 0x060051CF RID: 20943 RVA: 0x001608CC File Offset: 0x0015EACC
		private static string MyFormatColor(Color color)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(color.ToString());
			stringBuilder.AppendLine();
			stringBuilder.Append(Strings.StringColorLabelAlpha.#u2d() + #Phc.#3hc(107464305));
			stringBuilder.Append(color.A.ToString(CultureInfo.InvariantCulture));
			stringBuilder.AppendLine();
			stringBuilder.Append(Strings.StringColorLabelRed.#u2d() + #Phc.#3hc(107464305));
			stringBuilder.Append(color.R.ToString(CultureInfo.InvariantCulture));
			stringBuilder.AppendLine();
			stringBuilder.Append(Strings.StringColorLabelGreen.#u2d() + #Phc.#3hc(107464305));
			stringBuilder.Append(color.G.ToString(CultureInfo.InvariantCulture));
			stringBuilder.AppendLine();
			stringBuilder.Append(Strings.StringColorLabelBlue.#u2d() + #Phc.#3hc(107464305));
			stringBuilder.Append(color.B.ToString(CultureInfo.InvariantCulture));
			return stringBuilder.ToString();
		}

		// Token: 0x060051D0 RID: 20944 RVA: 0x00160A20 File Offset: 0x0015EC20
		private Binding MyCreateValueBinding()
		{
			return new Binding
			{
				Mode = BindingMode.TwoWay,
				NotifyOnValidationError = true,
				ValidatesOnExceptions = true,
				UpdateSourceTrigger = UpdateSourceTrigger.Explicit,
				Path = new PropertyPath(this.DataMemberBinding.Path.Path, new object[0])
			};
		}

		// Token: 0x060051D1 RID: 20945 RVA: 0x00160A80 File Offset: 0x0015EC80
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107464268), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060051D2 RID: 20946 RVA: 0x00043F3C File Offset: 0x0004213C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
		[SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
		[SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x060051D3 RID: 20947 RVA: 0x00043913 File Offset: 0x00041B13
		void IGridControlColumn.set_MinWidth(double value)
		{
			base.MinWidth = value;
		}

		// Token: 0x060051D4 RID: 20948 RVA: 0x00043928 File Offset: 0x00041B28
		void IGridControlColumn.set_MaxWidth(double value)
		{
			base.MaxWidth = value;
		}

		// Token: 0x060051D5 RID: 20949 RVA: 0x0004393D File Offset: 0x00041B3D
		Style IGridControlColumn.get_HeaderCellStyle()
		{
			return base.HeaderCellStyle;
		}

		// Token: 0x060051D6 RID: 20950 RVA: 0x0004394D File Offset: 0x00041B4D
		void IGridControlColumn.set_HeaderCellStyle(Style value)
		{
			base.HeaderCellStyle = value;
		}

		// Token: 0x060051D7 RID: 20951 RVA: 0x00043962 File Offset: 0x00041B62
		Style IGridControlColumn.get_EditorStyle()
		{
			return base.EditorStyle;
		}

		// Token: 0x060051D8 RID: 20952 RVA: 0x00043972 File Offset: 0x00041B72
		void IGridControlColumn.set_EditorStyle(Style value)
		{
			base.EditorStyle = value;
		}

		// Token: 0x060051D9 RID: 20953 RVA: 0x00043987 File Offset: 0x00041B87
		Brush IGridControlColumn.get_Background()
		{
			return base.Background;
		}

		// Token: 0x060051DA RID: 20954 RVA: 0x00043997 File Offset: 0x00041B97
		void IGridControlColumn.set_Background(Brush value)
		{
			base.Background = value;
		}

		// Token: 0x060051DB RID: 20955 RVA: 0x000439AC File Offset: 0x00041BAC
		string IGridControlColumn.get_FilterMemberPath()
		{
			return base.FilterMemberPath;
		}

		// Token: 0x060051DC RID: 20956 RVA: 0x000439BC File Offset: 0x00041BBC
		void IGridControlColumn.set_FilterMemberPath(string value)
		{
			base.FilterMemberPath = value;
		}

		// Token: 0x060051DD RID: 20957 RVA: 0x000439D1 File Offset: 0x00041BD1
		Type IGridControlColumn.get_FilterMemberType()
		{
			return base.FilterMemberType;
		}

		// Token: 0x060051DE RID: 20958 RVA: 0x000439E1 File Offset: 0x00041BE1
		void IGridControlColumn.set_FilterMemberType(Type value)
		{
			base.FilterMemberType = value;
		}

		// Token: 0x040023AC RID: 9132
		private bool _contentLoaded;
	}
}
