using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Markup;
using #00c;
using #7hc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.Framework.Controls
{
	// Token: 0x02000CE2 RID: 3298
	public sealed class ExportLayerListBoxControl : UserControl, IComponentConnector
	{
		// Token: 0x06006BEA RID: 27626 RVA: 0x001A0FB8 File Offset: 0x0019F1B8
		public ExportLayerListBoxControl()
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
			BindingHelper.SetBinding<IEnumerable<#i1c>>(new BindingHelperParametersContainer<IEnumerable<#i1c>>
			{
				Target = this.LayerVisibilityListBox,
				TargetProperty = ItemsControl.ItemsSourceProperty,
				Source = this,
				PropertyExpression = (() => this.ListBoxItems),
				BindingMode = BindingMode.TwoWay
			}, false);
		}

		// Token: 0x17001D99 RID: 7577
		// (get) Token: 0x06006BEB RID: 27627 RVA: 0x00054BC8 File Offset: 0x00052DC8
		// (set) Token: 0x06006BEC RID: 27628 RVA: 0x00054BDA File Offset: 0x00052DDA
		public bool? SelectAll
		{
			get
			{
				return (bool?)base.GetValue(ExportLayerListBoxControl.SelectAllProperty);
			}
			set
			{
				DependencyProperty selectAllProperty = ExportLayerListBoxControl.SelectAllProperty;
				object value2 = value;
				if (!false)
				{
					base.SetValue(selectAllProperty, value2);
				}
			}
		}

		// Token: 0x17001D9A RID: 7578
		// (get) Token: 0x06006BED RID: 27629 RVA: 0x00054BF5 File Offset: 0x00052DF5
		// (set) Token: 0x06006BEE RID: 27630 RVA: 0x00054C07 File Offset: 0x00052E07
		public IEnumerable<#i1c> ListBoxItems
		{
			get
			{
				return (IEnumerable<#i1c>)base.GetValue(ExportLayerListBoxControl.ListBoxItemsProperty);
			}
			set
			{
				DependencyProperty listBoxItemsProperty = ExportLayerListBoxControl.ListBoxItemsProperty;
				if (2 != 0)
				{
					base.SetValue(listBoxItemsProperty, value);
				}
			}
		}

		// Token: 0x06006BEF RID: 27631 RVA: 0x001A10A0 File Offset: 0x0019F2A0
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
						int num2 = num = 107265218;
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

		// Token: 0x06006BF0 RID: 27632 RVA: 0x001A10EC File Offset: 0x0019F2EC
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
				this.LayerListBoxControl = (ExportLayerListBoxControl)target;
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

		// Token: 0x04002BF3 RID: 11251
		public static readonly DependencyProperty SelectAllProperty = DependencyProperty.Register(#Phc.#3hc(107265169), typeof(bool?), typeof(ExportLayerListBoxControl), new PropertyMetadata(true));

		// Token: 0x04002BF4 RID: 11252
		public static readonly DependencyProperty ListBoxItemsProperty = DependencyProperty.Register(#Phc.#3hc(107265124), typeof(IEnumerable<#i1c>), typeof(ExportLayerListBoxControl), new PropertyMetadata(null));

		// Token: 0x04002BF5 RID: 11253
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal ExportLayerListBoxControl LayerListBoxControl;

		// Token: 0x04002BF6 RID: 11254
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal CheckBox SelectAllCheckBox;

		// Token: 0x04002BF7 RID: 11255
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal RadListBox LayerVisibilityListBox;

		// Token: 0x04002BF8 RID: 11256
		private bool _contentLoaded;
	}
}
