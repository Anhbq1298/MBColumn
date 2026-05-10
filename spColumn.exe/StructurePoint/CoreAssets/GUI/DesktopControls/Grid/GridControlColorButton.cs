using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Markup;
using #7hc;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Grid
{
	// Token: 0x020009DB RID: 2523
	internal sealed class GridControlColorButton : RadButton, IComponentConnector
	{
		// Token: 0x060052C6 RID: 21190 RVA: 0x0004471C File Offset: 0x0004291C
		public GridControlColorButton()
		{
			this.InitializeComponent();
		}

		// Token: 0x060052C7 RID: 21191 RVA: 0x001622EC File Offset: 0x001604EC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107464124), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060052C8 RID: 21192 RVA: 0x0004472A File Offset: 0x0004292A
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

		// Token: 0x040023DD RID: 9181
		private bool _contentLoaded;
	}
}
