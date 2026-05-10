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
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ToolBar
{
	// Token: 0x020008ED RID: 2285
	public sealed class ToolBarControl : UserControl, IComponentConnector
	{
		// Token: 0x060048A0 RID: 18592 RVA: 0x0003D1EA File Offset: 0x0003B3EA
		public ToolBarControl()
		{
			this.InitializeComponent();
		}

		// Token: 0x17001539 RID: 5433
		// (get) Token: 0x060048A1 RID: 18593 RVA: 0x0003D1F8 File Offset: 0x0003B3F8
		// (set) Token: 0x060048A2 RID: 18594 RVA: 0x0003D212 File Offset: 0x0003B412
		public IEnumerable<IToggleButtonData> ToggleButtons
		{
			get
			{
				return (IEnumerable<IToggleButtonData>)base.GetValue(ToolBarControl.ToggleButtonsProperty);
			}
			set
			{
				base.SetValue(ToolBarControl.ToggleButtonsProperty, value);
			}
		}

		// Token: 0x060048A3 RID: 18595 RVA: 0x00143ED4 File Offset: 0x001420D4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107450763), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060048A4 RID: 18596 RVA: 0x0003D22C File Offset: 0x0003B42C
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

		// Token: 0x040020B2 RID: 8370
		public static readonly DependencyProperty ToggleButtonsProperty = DependencyProperty.Register(#Phc.#3hc(107450698), typeof(IEnumerable<IToggleButtonData>), typeof(ToolBarControl), null);

		// Token: 0x040020B3 RID: 8371
		private bool _contentLoaded;
	}
}
