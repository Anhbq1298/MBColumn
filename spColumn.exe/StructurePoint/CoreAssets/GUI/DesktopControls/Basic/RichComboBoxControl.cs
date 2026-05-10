using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using #7hc;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000AC7 RID: 2759
	public sealed class RichComboBoxControl : UserControl, IComponentConnector
	{
		// Token: 0x060059D1 RID: 22993 RVA: 0x0004A944 File Offset: 0x00048B44
		public RichComboBoxControl()
		{
			this.InitializeComponent();
		}

		// Token: 0x1700195E RID: 6494
		// (get) Token: 0x060059D2 RID: 22994 RVA: 0x0004A952 File Offset: 0x00048B52
		// (set) Token: 0x060059D3 RID: 22995 RVA: 0x0004A96C File Offset: 0x00048B6C
		public IEnumerable<IRichComboBoxItemData> RichComboBoxItems
		{
			get
			{
				return (IEnumerable<IRichComboBoxItemData>)base.GetValue(RichComboBoxControl.RichComboBoxItemsProperty);
			}
			set
			{
				base.SetValue(RichComboBoxControl.RichComboBoxItemsProperty, value);
			}
		}

		// Token: 0x1700195F RID: 6495
		// (get) Token: 0x060059D4 RID: 22996 RVA: 0x0004A986 File Offset: 0x00048B86
		// (set) Token: 0x060059D5 RID: 22997 RVA: 0x0004A9A0 File Offset: 0x00048BA0
		public IRichComboBoxItemData SelectedItem
		{
			get
			{
				return (IRichComboBoxItemData)base.GetValue(RichComboBoxControl.SelectedItemProperty);
			}
			set
			{
				base.SetValue(RichComboBoxControl.SelectedItemProperty, value);
			}
		}

		// Token: 0x060059D6 RID: 22998 RVA: 0x0016DD60 File Offset: 0x0016BF60
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107425182), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060059D7 RID: 22999 RVA: 0x0004A9BA File Offset: 0x00048BBA
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

		// Token: 0x0400257E RID: 9598
		public static readonly DependencyProperty RichComboBoxItemsProperty = DependencyProperty.Register(#Phc.#3hc(107425061), typeof(IEnumerable<IRichComboBoxItemData>), typeof(RichComboBoxControl), new PropertyMetadata(null));

		// Token: 0x0400257F RID: 9599
		public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register(#Phc.#3hc(107407441), typeof(IRichComboBoxItemData), typeof(RichComboBoxControl), new PropertyMetadata(null));

		// Token: 0x04002580 RID: 9600
		private bool _contentLoaded;
	}
}
