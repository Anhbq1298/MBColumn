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

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.ViewCubeControl
{
	// Token: 0x02000957 RID: 2391
	public sealed class NewViewCubeHostControl : UserControl, IComponentConnector
	{
		// Token: 0x06004E74 RID: 20084 RVA: 0x00041B3B File Offset: 0x0003FD3B
		public NewViewCubeHostControl()
		{
			this.InitializeComponent();
		}

		// Token: 0x06004E75 RID: 20085 RVA: 0x00153A30 File Offset: 0x00151C30
		private static void MyIsViewCubeCollapsedChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
		{
			UIElement uielement = (NewViewCubeHostControl)dependencyObject;
			Visibility visibility = (Visibility)e.NewValue;
			uielement.Visibility = visibility;
		}

		// Token: 0x170016CE RID: 5838
		// (get) Token: 0x06004E76 RID: 20086 RVA: 0x00041B49 File Offset: 0x0003FD49
		// (set) Token: 0x06004E77 RID: 20087 RVA: 0x00041B63 File Offset: 0x0003FD63
		public IEnumerable<IPanelItem> ViewCubeTools
		{
			get
			{
				return (IEnumerable<IPanelItem>)base.GetValue(NewViewCubeHostControl.ViewCubeToolsProperty);
			}
			set
			{
				base.SetValue(NewViewCubeHostControl.ViewCubeToolsProperty, value);
			}
		}

		// Token: 0x170016CF RID: 5839
		// (get) Token: 0x06004E78 RID: 20088 RVA: 0x00041B7D File Offset: 0x0003FD7D
		// (set) Token: 0x06004E79 RID: 20089 RVA: 0x00041B97 File Offset: 0x0003FD97
		public Visibility IsViewCubeCollapsed
		{
			get
			{
				return (Visibility)base.GetValue(NewViewCubeHostControl.IsViewCubeCollapsedProperty);
			}
			set
			{
				base.SetValue(NewViewCubeHostControl.IsViewCubeCollapsedProperty, value);
			}
		}

		// Token: 0x06004E7A RID: 20090 RVA: 0x00153A64 File Offset: 0x00151C64
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107468546), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06004E7B RID: 20091 RVA: 0x00008739 File Offset: 0x00006939
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06004E7C RID: 20092 RVA: 0x00041BB6 File Offset: 0x0003FDB6
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
				this.MainPanel = (Border)target;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x0400229A RID: 8858
		public static readonly DependencyProperty ViewCubeToolsProperty = DependencyProperty.Register(#Phc.#3hc(107467965), typeof(IEnumerable<IPanelItem>), typeof(NewViewCubeHostControl), null);

		// Token: 0x0400229B RID: 8859
		public static readonly DependencyProperty IsViewCubeCollapsedProperty = DependencyProperty.Register(#Phc.#3hc(107467912), typeof(Visibility), typeof(NewViewCubeHostControl), new PropertyMetadata(Visibility.Visible, new PropertyChangedCallback(NewViewCubeHostControl.MyIsViewCubeCollapsedChanged)));

		// Token: 0x0400229C RID: 8860
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal Border MainPanel;

		// Token: 0x0400229D RID: 8861
		private bool _contentLoaded;
	}
}
