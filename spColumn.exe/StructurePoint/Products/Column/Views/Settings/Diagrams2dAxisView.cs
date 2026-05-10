using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using #7hc;
using #pc;
using StructurePoint.CoreAssets.Column.Core.Core.App;

namespace StructurePoint.Products.Column.Views.Settings
{
	// Token: 0x02000053 RID: 83
	internal sealed class Diagrams2dAxisView : ColumnBaseView, IComponentConnector, IView, #qc
	{
		// Token: 0x060003E8 RID: 1000 RVA: 0x00008E89 File Offset: 0x00007089
		public Diagrams2dAxisView()
		{
			this.InitializeComponent();
		}

		// Token: 0x060003E9 RID: 1001 RVA: 0x00086FD8 File Offset: 0x000851D8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107387895), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060003EA RID: 1002 RVA: 0x00008E97 File Offset: 0x00007097
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000090 RID: 144
		private bool _contentLoaded;
	}
}
