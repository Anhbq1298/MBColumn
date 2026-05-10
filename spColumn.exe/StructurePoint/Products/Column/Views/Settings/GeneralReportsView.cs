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
	// Token: 0x0200005F RID: 95
	internal sealed class GeneralReportsView : ColumnBaseView, IComponentConnector, IView, #xc
	{
		// Token: 0x060003FA RID: 1018 RVA: 0x00008F2B File Offset: 0x0000712B
		public GeneralReportsView()
		{
			this.InitializeComponent();
		}

		// Token: 0x060003FB RID: 1019 RVA: 0x00087170 File Offset: 0x00085370
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107387369), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060003FC RID: 1020 RVA: 0x00008F39 File Offset: 0x00007139
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000096 RID: 150
		private bool _contentLoaded;
	}
}
