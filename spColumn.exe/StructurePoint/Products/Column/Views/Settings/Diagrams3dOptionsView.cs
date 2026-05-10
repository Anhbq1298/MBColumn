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
	// Token: 0x0200005B RID: 91
	internal sealed class Diagrams3dOptionsView : ColumnBaseView, IComponentConnector, IView, #tc
	{
		// Token: 0x060003F4 RID: 1012 RVA: 0x00008EF5 File Offset: 0x000070F5
		public Diagrams3dOptionsView()
		{
			this.InitializeComponent();
		}

		// Token: 0x060003F5 RID: 1013 RVA: 0x000870E8 File Offset: 0x000852E8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107387023), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060003F6 RID: 1014 RVA: 0x00008F03 File Offset: 0x00007103
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000094 RID: 148
		private bool _contentLoaded;
	}
}
