using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using #7hc;
using StructurePoint.CoreAssets.Column.Core.Core.App;

namespace StructurePoint.Products.Column.FailureSurface.Views
{
	// Token: 0x020003ED RID: 1005
	internal sealed class LeftPanelToolbarView : ColumnBaseView, IComponentConnector, IView, ILeftPanelToolbarView
	{
		// Token: 0x060022C6 RID: 8902 RVA: 0x000218D5 File Offset: 0x0001FAD5
		public LeftPanelToolbarView()
		{
			this.InitializeComponent();
		}

		// Token: 0x060022C7 RID: 8903 RVA: 0x000CB2E8 File Offset: 0x000C94E8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107362924), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060022C8 RID: 8904 RVA: 0x000218E3 File Offset: 0x0001FAE3
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000DE2 RID: 3554
		private bool _contentLoaded;
	}
}
