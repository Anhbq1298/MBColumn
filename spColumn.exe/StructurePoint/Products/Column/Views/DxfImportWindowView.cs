using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using #1b;
using #7hc;
using StructurePoint.CoreAssets.Column.Core.Core.App;

namespace StructurePoint.Products.Column.Views
{
	// Token: 0x02000027 RID: 39
	internal sealed class DxfImportWindowView : ColumnWindow, IComponentConnector, IColumnWindow, IView, #0b
	{
		// Token: 0x06000334 RID: 820 RVA: 0x000086E0 File Offset: 0x000068E0
		public DxfImportWindowView()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000335 RID: 821 RVA: 0x00085D9C File Offset: 0x00083F9C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107389026), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000336 RID: 822 RVA: 0x000086EE File Offset: 0x000068EE
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000049 RID: 73
		private bool _contentLoaded;
	}
}
