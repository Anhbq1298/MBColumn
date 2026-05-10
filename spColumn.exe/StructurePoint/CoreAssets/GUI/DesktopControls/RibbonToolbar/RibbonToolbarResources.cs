using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Markup;
using #7hc;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.RibbonToolbar
{
	// Token: 0x020008F2 RID: 2290
	internal sealed class RibbonToolbarResources : ResourceDictionary, IComponentConnector, IStyleConnector
	{
		// Token: 0x060048E8 RID: 18664 RVA: 0x0003D535 File Offset: 0x0003B735
		public RibbonToolbarResources()
		{
			this.InitializeComponent();
		}

		// Token: 0x140000F3 RID: 243
		// (add) Token: 0x060048E9 RID: 18665 RVA: 0x0014467C File Offset: 0x0014287C
		// (remove) Token: 0x060048EA RID: 18666 RVA: 0x001446C0 File Offset: 0x001428C0
		public event RoutedEventHandler EditionToolSelected;

		// Token: 0x140000F4 RID: 244
		// (add) Token: 0x060048EB RID: 18667 RVA: 0x00144704 File Offset: 0x00142904
		// (remove) Token: 0x060048EC RID: 18668 RVA: 0x00144748 File Offset: 0x00142948
		public event RoutedEventHandler EditionToolDeselected;

		// Token: 0x060048ED RID: 18669 RVA: 0x0014478C File Offset: 0x0014298C
		private void EditionTool_Selected(object sender, RoutedEventArgs e)
		{
			RoutedEventHandler editionToolSelected = this.EditionToolSelected;
			if (editionToolSelected != null)
			{
				editionToolSelected(sender, e);
			}
		}

		// Token: 0x060048EE RID: 18670 RVA: 0x001447B8 File Offset: 0x001429B8
		private void EditionTool_Deselected(object sender, RoutedEventArgs e)
		{
			RoutedEventHandler editionToolDeselected = this.EditionToolDeselected;
			if (editionToolDeselected != null)
			{
				editionToolDeselected(sender, e);
			}
		}

		// Token: 0x060048EF RID: 18671 RVA: 0x001447E4 File Offset: 0x001429E4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107449970), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060048F0 RID: 18672 RVA: 0x00008739 File Offset: 0x00006939
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060048F1 RID: 18673 RVA: 0x0003D543 File Offset: 0x0003B743
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

		// Token: 0x060048F2 RID: 18674 RVA: 0x0003D550 File Offset: 0x0003B750
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
		[SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
		[SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
		void IStyleConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				((RadRadioButton)target).Checked += this.EditionTool_Selected;
				((RadRadioButton)target).Unchecked += this.EditionTool_Deselected;
			}
		}

		// Token: 0x040020C8 RID: 8392
		private bool _contentLoaded;
	}
}
