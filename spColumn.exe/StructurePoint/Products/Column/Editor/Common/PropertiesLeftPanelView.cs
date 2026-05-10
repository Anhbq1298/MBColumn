using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using #7hc;
using #qPb;
using StructurePoint.CoreAssets.Column.Core.Core.App;

namespace StructurePoint.Products.Column.Editor.Common
{
	// Token: 0x020006A6 RID: 1702
	internal sealed class PropertiesLeftPanelView : ColumnBaseView, IComponentConnector, IView, #pPb
	{
		// Token: 0x060038E4 RID: 14564 RVA: 0x000317A8 File Offset: 0x0002F9A8
		public PropertiesLeftPanelView()
		{
			this.InitializeComponent();
		}

		// Token: 0x060038E5 RID: 14565 RVA: 0x0011082C File Offset: 0x0010EA2C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107351548), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060038E6 RID: 14566 RVA: 0x000317B6 File Offset: 0x0002F9B6
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.PropertiesPanel = (Border)target;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x040017DA RID: 6106
		internal Border PropertiesPanel;

		// Token: 0x040017DB RID: 6107
		private bool _contentLoaded;
	}
}
