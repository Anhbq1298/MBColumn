using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Helpers;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Grid
{
	// Token: 0x020009BF RID: 2495
	public sealed class ComboBoxGridControlColumn : GridViewComboBoxColumn, IGridControlComboBoxColumn, IGridControlColumn
	{
		// Token: 0x1700172D RID: 5933
		// (get) Token: 0x060050DA RID: 20698 RVA: 0x00043723 File Offset: 0x00041923
		// (set) Token: 0x060050DB RID: 20699 RVA: 0x00043733 File Offset: 0x00041933
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

		// Token: 0x1700172E RID: 5934
		// (get) Token: 0x060050DC RID: 20700 RVA: 0x00043748 File Offset: 0x00041948
		// (set) Token: 0x060050DD RID: 20701 RVA: 0x0004376B File Offset: 0x0004196B
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

		// Token: 0x1700172F RID: 5935
		// (get) Token: 0x060050DE RID: 20702 RVA: 0x0004378F File Offset: 0x0004198F
		// (set) Token: 0x060050DF RID: 20703 RVA: 0x000437A8 File Offset: 0x000419A8
		public GridViewLength ColumnWidth
		{
			get
			{
				return GridViewLength.CreateFromProviderValue(base.Width);
			}
			set
			{
				#X0d.#V0d(value, #Phc.#3hc(107386484), Component.DesktopControls, #Phc.#3hc(107465596));
				base.Width = value.ConvertToProviderValue();
			}
		}

		// Token: 0x17001730 RID: 5936
		// (get) Token: 0x060050E0 RID: 20704 RVA: 0x000437DD File Offset: 0x000419DD
		// (set) Token: 0x060050E1 RID: 20705 RVA: 0x000437E9 File Offset: 0x000419E9
		public bool UpdateModelOnValueChange { get; set; }

		// Token: 0x17001731 RID: 5937
		// (get) Token: 0x060050E2 RID: 20706 RVA: 0x000437FA File Offset: 0x000419FA
		// (set) Token: 0x060050E3 RID: 20707 RVA: 0x00043806 File Offset: 0x00041A06
		public bool BindToTextProperty { get; set; }

		// Token: 0x17001732 RID: 5938
		// (get) Token: 0x060050E4 RID: 20708 RVA: 0x00043817 File Offset: 0x00041A17
		// (set) Token: 0x060050E5 RID: 20709 RVA: 0x00043823 File Offset: 0x00041A23
		public Func<object, object> FilteringDisplayValueProvider { get; set; }

		// Token: 0x17001733 RID: 5939
		// (get) Token: 0x060050E6 RID: 20710 RVA: 0x00043834 File Offset: 0x00041A34
		protected override Func<object, object> FilteringDisplayFunc
		{
			get
			{
				Func<object, object> result;
				if ((result = this.FilteringDisplayValueProvider) == null)
				{
					result = base.FilteringDisplayFunc;
				}
				return result;
			}
		}

		// Token: 0x060050E7 RID: 20711 RVA: 0x0015F52C File Offset: 0x0015D72C
		public override FrameworkElement CreateCellEditElement(GridViewCell cell, object dataItem)
		{
			FrameworkElement frameworkElement = base.CreateCellEditElement(cell, dataItem);
			if (frameworkElement != null)
			{
				frameworkElement.SetValue(ContextualHelp.HelpIDProperty, this.HelpId);
				frameworkElement.SetValue(ContextualHelp.ParentElementTypeProperty, ContextualHelp.GetParentElementType(this));
				if (this.UpdateModelOnValueChange)
				{
					Binding binding = BindingOperations.GetBinding(frameworkElement, base.BindingTarget);
					if (binding != null)
					{
						binding = ComboBoxGridControlColumn.MyCloneBinding(binding);
						binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
						BindingOperations.ClearBinding(frameworkElement, base.BindingTarget);
						frameworkElement.SetBinding(base.BindingTarget, binding);
					}
				}
			}
			if (this.BindToTextProperty)
			{
				base.BindingTarget = RadComboBox.TextProperty;
				RadComboBox radComboBox = frameworkElement as RadComboBox;
				if (radComboBox != null)
				{
					radComboBox.Text = (ReflectionHelper.#E(dataItem, this.DataMemberBinding.Path.Path) as string);
					radComboBox.SelectAllTextEvent = SelectAllTextEvents.None;
					radComboBox.TextSearchMode = TextSearchMode.StartsWith;
				}
			}
			return frameworkElement;
		}

		// Token: 0x060050E8 RID: 20712 RVA: 0x0015F614 File Offset: 0x0015D814
		public override FrameworkElement CreateCellElement(GridViewCell cell, object dataItem)
		{
			if (this.BindToTextProperty)
			{
				TextBlock textBlock = new TextBlock();
				textBlock.Padding = new Thickness(4.0, 2.0, 4.0, 2.0);
				textBlock.SetBinding(TextBlock.TextProperty, new Binding(this.DataMemberBinding.Path.Path)
				{
					Source = dataItem,
					Mode = BindingMode.OneTime
				});
				return textBlock;
			}
			return base.CreateCellElement(cell, dataItem);
		}

		// Token: 0x060050E9 RID: 20713 RVA: 0x0015F6A4 File Offset: 0x0015D8A4
		public override object GetNewValueFromEditor(object editor)
		{
			if (this.BindToTextProperty)
			{
				RadComboBox radComboBox = editor as RadComboBox;
				if (radComboBox != null)
				{
					return radComboBox.Text;
				}
			}
			return base.GetNewValueFromEditor(editor);
		}

		// Token: 0x060050EA RID: 20714 RVA: 0x0015F6E0 File Offset: 0x0015D8E0
		public override IList<string> UpdateSourceWithEditorValue(GridViewCell gridViewCell)
		{
			if (this.BindToTextProperty && gridViewCell != null)
			{
				object newValueFromEditor = this.GetNewValueFromEditor(gridViewCell.GetEditingElement());
				ReflectionHelper.#H(gridViewCell.DataContext, this.DataMemberBinding.Path.Path, newValueFromEditor);
				return null;
			}
			return base.UpdateSourceWithEditorValue(gridViewCell);
		}

		// Token: 0x060050EB RID: 20715 RVA: 0x0015F738 File Offset: 0x0015D938
		private static Binding MyCloneBinding(Binding source)
		{
			Binding binding = new Binding();
			if (source != null)
			{
				binding.Converter = source.Converter;
				binding.ConverterCulture = source.ConverterCulture;
				binding.ConverterParameter = source.ConverterParameter;
				binding.Path = source.Path;
				binding.TargetNullValue = source.TargetNullValue;
				binding.FallbackValue = source.FallbackValue;
				foreach (ValidationRule item in source.ValidationRules)
				{
					binding.ValidationRules.Add(item);
				}
				binding.BindingGroupName = source.BindingGroupName;
				binding.Mode = ((binding.Path == null || string.IsNullOrEmpty(binding.Path.Path)) ? BindingMode.OneWay : BindingMode.TwoWay);
				binding.ValidatesOnDataErrors = true;
				binding.ValidatesOnNotifyDataErrors = true;
				binding.NotifyOnValidationError = true;
				binding.ValidatesOnExceptions = true;
				binding.UpdateSourceTrigger = UpdateSourceTrigger.Explicit;
				if (source.ElementName != null)
				{
					binding.ElementName = source.ElementName;
					return binding;
				}
				if (source.RelativeSource != null)
				{
					binding.RelativeSource = source.RelativeSource;
					return binding;
				}
				if (source.Source != null)
				{
					binding.Source = source.Source;
				}
			}
			return binding;
		}

		// Token: 0x060050ED RID: 20717 RVA: 0x0004385A File Offset: 0x00041A5A
		bool IGridControlComboBoxColumn.get_IsComboBoxEditable()
		{
			return base.IsComboBoxEditable;
		}

		// Token: 0x060050EE RID: 20718 RVA: 0x0004386A File Offset: 0x00041A6A
		void IGridControlComboBoxColumn.set_IsComboBoxEditable(bool value)
		{
			base.IsComboBoxEditable = value;
		}

		// Token: 0x060050EF RID: 20719 RVA: 0x0004387F File Offset: 0x00041A7F
		IEnumerable IGridControlComboBoxColumn.get_ItemsSource()
		{
			return base.ItemsSource;
		}

		// Token: 0x060050F0 RID: 20720 RVA: 0x0004388F File Offset: 0x00041A8F
		void IGridControlComboBoxColumn.set_ItemsSource(IEnumerable value)
		{
			base.ItemsSource = value;
		}

		// Token: 0x060050F1 RID: 20721 RVA: 0x000438A4 File Offset: 0x00041AA4
		Binding IGridControlComboBoxColumn.get_ItemsSourceBinding()
		{
			return base.ItemsSourceBinding;
		}

		// Token: 0x060050F2 RID: 20722 RVA: 0x000438B4 File Offset: 0x00041AB4
		void IGridControlComboBoxColumn.set_ItemsSourceBinding(Binding value)
		{
			base.ItemsSourceBinding = value;
		}

		// Token: 0x060050F3 RID: 20723 RVA: 0x000438C9 File Offset: 0x00041AC9
		string IGridControlComboBoxColumn.get_SelectedValueMemberPath()
		{
			return base.SelectedValueMemberPath;
		}

		// Token: 0x060050F4 RID: 20724 RVA: 0x000438D9 File Offset: 0x00041AD9
		void IGridControlComboBoxColumn.set_SelectedValueMemberPath(string value)
		{
			base.SelectedValueMemberPath = value;
		}

		// Token: 0x060050F5 RID: 20725 RVA: 0x000438EE File Offset: 0x00041AEE
		string IGridControlComboBoxColumn.get_DisplayMemberPath()
		{
			return base.DisplayMemberPath;
		}

		// Token: 0x060050F6 RID: 20726 RVA: 0x000438FE File Offset: 0x00041AFE
		void IGridControlComboBoxColumn.set_DisplayMemberPath(string value)
		{
			base.DisplayMemberPath = value;
		}

		// Token: 0x060050F7 RID: 20727 RVA: 0x00043913 File Offset: 0x00041B13
		void IGridControlColumn.set_MinWidth(double value)
		{
			base.MinWidth = value;
		}

		// Token: 0x060050F8 RID: 20728 RVA: 0x00043928 File Offset: 0x00041B28
		void IGridControlColumn.set_MaxWidth(double value)
		{
			base.MaxWidth = value;
		}

		// Token: 0x060050F9 RID: 20729 RVA: 0x0004393D File Offset: 0x00041B3D
		Style IGridControlColumn.get_HeaderCellStyle()
		{
			return base.HeaderCellStyle;
		}

		// Token: 0x060050FA RID: 20730 RVA: 0x0004394D File Offset: 0x00041B4D
		void IGridControlColumn.set_HeaderCellStyle(Style value)
		{
			base.HeaderCellStyle = value;
		}

		// Token: 0x060050FB RID: 20731 RVA: 0x00043962 File Offset: 0x00041B62
		Style IGridControlColumn.get_EditorStyle()
		{
			return base.EditorStyle;
		}

		// Token: 0x060050FC RID: 20732 RVA: 0x00043972 File Offset: 0x00041B72
		void IGridControlColumn.set_EditorStyle(Style value)
		{
			base.EditorStyle = value;
		}

		// Token: 0x060050FD RID: 20733 RVA: 0x00043987 File Offset: 0x00041B87
		Brush IGridControlColumn.get_Background()
		{
			return base.Background;
		}

		// Token: 0x060050FE RID: 20734 RVA: 0x00043997 File Offset: 0x00041B97
		void IGridControlColumn.set_Background(Brush value)
		{
			base.Background = value;
		}

		// Token: 0x060050FF RID: 20735 RVA: 0x000439AC File Offset: 0x00041BAC
		string IGridControlColumn.get_FilterMemberPath()
		{
			return base.FilterMemberPath;
		}

		// Token: 0x06005100 RID: 20736 RVA: 0x000439BC File Offset: 0x00041BBC
		void IGridControlColumn.set_FilterMemberPath(string value)
		{
			base.FilterMemberPath = value;
		}

		// Token: 0x06005101 RID: 20737 RVA: 0x000439D1 File Offset: 0x00041BD1
		Type IGridControlColumn.get_FilterMemberType()
		{
			return base.FilterMemberType;
		}

		// Token: 0x06005102 RID: 20738 RVA: 0x000439E1 File Offset: 0x00041BE1
		void IGridControlColumn.set_FilterMemberType(Type value)
		{
			base.FilterMemberType = value;
		}
	}
}
