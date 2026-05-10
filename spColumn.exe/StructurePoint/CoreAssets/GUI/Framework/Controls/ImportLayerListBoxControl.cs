using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Markup;
using #7hc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.Framework.Controls
{
	// Token: 0x02000CE3 RID: 3299
	public sealed class ImportLayerListBoxControl : UserControl, IComponentConnector
	{
		// Token: 0x06006BF2 RID: 27634 RVA: 0x001A11B8 File Offset: 0x0019F3B8
		public ImportLayerListBoxControl()
		{
			this.InitializeComponent();
			BindingHelper.SetBinding<bool?>(new BindingHelperParametersContainer<bool?>
			{
				Target = this.SelectAllCheckBox,
				TargetProperty = ToggleButton.IsCheckedProperty,
				Source = this,
				PropertyExpression = (() => this.SelectAll),
				BindingMode = BindingMode.TwoWay
			}, false);
			BindingHelper.SetBinding<IEnumerable>(new BindingHelperParametersContainer<IEnumerable>
			{
				Target = this.LayerVisibilityListBox,
				TargetProperty = ItemsControl.ItemsSourceProperty,
				Source = this,
				PropertyExpression = (() => this.ListBoxItems),
				BindingMode = BindingMode.TwoWay
			}, false);
		}

		// Token: 0x17001D9B RID: 7579
		// (get) Token: 0x06006BF3 RID: 27635 RVA: 0x00054C1D File Offset: 0x00052E1D
		// (set) Token: 0x06006BF4 RID: 27636 RVA: 0x00054C2F File Offset: 0x00052E2F
		public bool? SelectAll
		{
			get
			{
				return (bool?)base.GetValue(ImportLayerListBoxControl.SelectAllProperty);
			}
			set
			{
				DependencyProperty selectAllProperty = ImportLayerListBoxControl.SelectAllProperty;
				object value2 = value;
				if (!false)
				{
					base.SetValue(selectAllProperty, value2);
				}
			}
		}

		// Token: 0x17001D9C RID: 7580
		// (get) Token: 0x06006BF5 RID: 27637 RVA: 0x00054C4A File Offset: 0x00052E4A
		// (set) Token: 0x06006BF6 RID: 27638 RVA: 0x00054C5C File Offset: 0x00052E5C
		public IEnumerable ListBoxItems
		{
			get
			{
				return (IEnumerable)base.GetValue(ImportLayerListBoxControl.ListBoxItemsProperty);
			}
			set
			{
				DependencyProperty listBoxItemsProperty = ImportLayerListBoxControl.ListBoxItemsProperty;
				if (2 != 0)
				{
					base.SetValue(listBoxItemsProperty, value);
				}
			}
		}

		// Token: 0x17001D9D RID: 7581
		// (get) Token: 0x06006BF7 RID: 27639 RVA: 0x00054C72 File Offset: 0x00052E72
		// (set) Token: 0x06006BF8 RID: 27640 RVA: 0x00054C84 File Offset: 0x00052E84
		public bool IsAssignmentEnabled
		{
			get
			{
				return (bool)base.GetValue(ImportLayerListBoxControl.IsAssignmentEnabledProperty);
			}
			set
			{
				DependencyProperty isAssignmentEnabledProperty = ImportLayerListBoxControl.IsAssignmentEnabledProperty;
				object value2 = value;
				if (!false)
				{
					base.SetValue(isAssignmentEnabledProperty, value2);
				}
			}
		}

		// Token: 0x06006BF9 RID: 27641 RVA: 0x001A12A0 File Offset: 0x0019F4A0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			int num = this._contentLoaded ? 1 : 0;
			IL_06:
			while (num == 0)
			{
				do
				{
					this._contentLoaded = true;
					if (!false)
					{
						int num2 = num = 107265139;
						if (num2 == 0)
						{
							goto IL_06;
						}
						Uri uri = new Uri(#Phc.#3hc(num2), UriKind.Relative);
						Uri uri2;
						if (!false)
						{
							uri2 = uri;
						}
						Uri resourceLocator = uri2;
						if (!false)
						{
							Application.LoadComponent(this, resourceLocator);
						}
					}
				}
				while (-1 == 0);
				return;
			}
		}

		// Token: 0x06006BFA RID: 27642 RVA: 0x001A12EC File Offset: 0x0019F4EC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
		[SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
		[SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.LayerListBoxControl = (ImportLayerListBoxControl)target;
				return;
			case 2:
				break;
			case 3:
				if (true)
				{
					this.LayerVisibilityListBox = (RadListBox)target;
					return;
				}
				break;
			default:
				while (-1 != 0)
				{
					this._contentLoaded = true;
					if (!false)
					{
						return;
					}
				}
				break;
			}
			this.SelectAllCheckBox = (CheckBox)target;
		}

		// Token: 0x04002BF9 RID: 11257
		public static readonly DependencyProperty SelectAllProperty = DependencyProperty.Register(#Phc.#3hc(107265169), typeof(bool?), typeof(ImportLayerListBoxControl), new PropertyMetadata(true));

		// Token: 0x04002BFA RID: 11258
		public static readonly DependencyProperty ListBoxItemsProperty = DependencyProperty.Register(#Phc.#3hc(107265124), typeof(IEnumerable), typeof(ImportLayerListBoxControl), new PropertyMetadata(null));

		// Token: 0x04002BFB RID: 11259
		public static readonly DependencyProperty IsAssignmentEnabledProperty = DependencyProperty.Register(#Phc.#3hc(107265026), typeof(bool), typeof(ImportLayerListBoxControl), null);

		// Token: 0x04002BFC RID: 11260
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal ImportLayerListBoxControl LayerListBoxControl;

		// Token: 0x04002BFD RID: 11261
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal CheckBox SelectAllCheckBox;

		// Token: 0x04002BFE RID: 11262
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal RadListBox LayerVisibilityListBox;

		// Token: 0x04002BFF RID: 11263
		private bool _contentLoaded;
	}
}
