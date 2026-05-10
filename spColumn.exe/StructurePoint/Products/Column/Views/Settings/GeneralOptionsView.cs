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
	// Token: 0x0200005D RID: 93
	internal sealed class GeneralOptionsView : ColumnBaseView, IComponentConnector, IView, #wc
	{
		// Token: 0x060003F7 RID: 1015 RVA: 0x00008F10 File Offset: 0x00007110
		public GeneralOptionsView()
		{
			this.InitializeComponent();
		}

		// Token: 0x060003F8 RID: 1016 RVA: 0x0008712C File Offset: 0x0008532C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107386970), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060003F9 RID: 1017 RVA: 0x00008F1E File Offset: 0x0000711E
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000095 RID: 149
		private bool _contentLoaded;
	}
}
