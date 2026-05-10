using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using #7hc;

namespace StructurePoint.Products.Column.Views.Common
{
	// Token: 0x0200008F RID: 143
	internal sealed class PanelContent : UserControl, IComponentConnector
	{
		// Token: 0x06000499 RID: 1177 RVA: 0x00009812 File Offset: 0x00007A12
		public PanelContent()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600049A RID: 1178 RVA: 0x000884C0 File Offset: 0x000866C0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107384545), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600049B RID: 1179 RVA: 0x00009820 File Offset: 0x00007A20
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040000D7 RID: 215
		private bool _contentLoaded;
	}
}
