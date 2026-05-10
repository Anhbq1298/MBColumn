using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using #7hc;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.PanelBar
{
	// Token: 0x020008B3 RID: 2227
	public sealed class PanelBarControl : UserControl, IComponentConnector, IPanelBarControl
	{
		// Token: 0x06004627 RID: 17959 RVA: 0x0003AA10 File Offset: 0x00038C10
		public PanelBarControl()
		{
			this.InitializeComponent();
		}

		// Token: 0x1700148C RID: 5260
		// (get) Token: 0x06004628 RID: 17960 RVA: 0x0003AA1E File Offset: 0x00038C1E
		// (set) Token: 0x06004629 RID: 17961 RVA: 0x0003AA38 File Offset: 0x00038C38
		public IEnumerable ItemsSource
		{
			get
			{
				return (IEnumerable)base.GetValue(PanelBarControl.ItemsSourceProperty);
			}
			set
			{
				base.SetValue(PanelBarControl.ItemsSourceProperty, value);
			}
		}

		// Token: 0x1700148D RID: 5261
		// (get) Token: 0x0600462A RID: 17962 RVA: 0x0003AA52 File Offset: 0x00038C52
		// (set) Token: 0x0600462B RID: 17963 RVA: 0x0003AA67 File Offset: 0x00038C67
		public object SelectedItem
		{
			get
			{
				return base.GetValue(PanelBarControl.SelectedItemProperty);
			}
			set
			{
				base.SetValue(PanelBarControl.SelectedItemProperty, value);
			}
		}

		// Token: 0x0600462C RID: 17964 RVA: 0x0013D7B8 File Offset: 0x0013B9B8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107453925), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600462D RID: 17965 RVA: 0x0003AA81 File Offset: 0x00038C81
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
		[SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
		[SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.RadPanelBar = (RadPanelBar)target;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x04001FD1 RID: 8145
		public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register(#Phc.#3hc(107453856), typeof(IEnumerable), typeof(PanelBarControl));

		// Token: 0x04001FD2 RID: 8146
		public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register(#Phc.#3hc(107407441), typeof(object), typeof(PanelBarControl));

		// Token: 0x04001FD3 RID: 8147
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal RadPanelBar RadPanelBar;

		// Token: 0x04001FD4 RID: 8148
		private bool _contentLoaded;
	}
}
