using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using #7hc;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.Products.Column.Viewports.API;

namespace StructurePoint.Products.Column.Viewports
{
	// Token: 0x020000BD RID: 189
	internal sealed class ViewportOverlayView : ColumnBaseView, IComponentConnector, IView, IViewportOverlayView
	{
		// Token: 0x060005E0 RID: 1504 RVA: 0x0000A53B File Offset: 0x0000873B
		public ViewportOverlayView()
		{
			this.InitializeComponent();
		}

		// Token: 0x060005E1 RID: 1505 RVA: 0x0008B2E8 File Offset: 0x000894E8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107384610), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060005E2 RID: 1506 RVA: 0x0000A549 File Offset: 0x00008749
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400014E RID: 334
		private bool _contentLoaded;
	}
}
