using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Markup;
using #7hc;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.DockExplorer
{
	// Token: 0x020008B7 RID: 2231
	public sealed class DockExplorerWindow : Window, IComponentConnector
	{
		// Token: 0x0600463F RID: 17983 RVA: 0x0003AB96 File Offset: 0x00038D96
		public DockExplorerWindow(IDockExplorerViewModel dockExploreController)
		{
			this.InitializeComponent();
			base.DataContext = dockExploreController;
		}

		// Token: 0x06004640 RID: 17984 RVA: 0x0013DA0C File Offset: 0x0013BC0C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107453761), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06004641 RID: 17985 RVA: 0x0003ABAB File Offset: 0x00038DAB
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
				this.SelectedToolNameTextBlock = (GroupBox)target;
				return;
			}
			if (connectionId != 2)
			{
				this._contentLoaded = true;
				return;
			}
			this.FloatingTabs = (RadListBox)target;
		}

		// Token: 0x04001FDC RID: 8156
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal GroupBox SelectedToolNameTextBlock;

		// Token: 0x04001FDD RID: 8157
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal RadListBox FloatingTabs;

		// Token: 0x04001FDE RID: 8158
		private bool _contentLoaded;
	}
}
