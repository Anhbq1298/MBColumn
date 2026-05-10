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

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Menu
{
	// Token: 0x0200098E RID: 2446
	public sealed class MenuControl : UserControl, IComponentConnector
	{
		// Token: 0x06004FBB RID: 20411 RVA: 0x00042898 File Offset: 0x00040A98
		public MenuControl()
		{
			this.InitializeComponent();
		}

		// Token: 0x170016F5 RID: 5877
		// (get) Token: 0x06004FBC RID: 20412 RVA: 0x000428A6 File Offset: 0x00040AA6
		// (set) Token: 0x06004FBD RID: 20413 RVA: 0x000428C0 File Offset: 0x00040AC0
		public IEnumerable<MenuItem> MenuItems
		{
			get
			{
				return (IEnumerable<MenuItem>)base.GetValue(MenuControl.MenuItemsProperty);
			}
			set
			{
				base.SetValue(MenuControl.MenuItemsProperty, value);
			}
		}

		// Token: 0x06004FBE RID: 20414 RVA: 0x0015C8E0 File Offset: 0x0015AAE0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107466405), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06004FBF RID: 20415 RVA: 0x000428DA File Offset: 0x00040ADA
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

		// Token: 0x040022E1 RID: 8929
		public static readonly DependencyProperty MenuItemsProperty = DependencyProperty.Register(#Phc.#3hc(107350918), typeof(IEnumerable<MenuItem>), typeof(MenuControl), null);

		// Token: 0x040022E2 RID: 8930
		private bool _contentLoaded;
	}
}
