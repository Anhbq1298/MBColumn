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
	// Token: 0x02000021 RID: 33
	internal sealed class AboutWindow : ColumnWindow, IComponentConnector, IColumnWindow, IView, #7b
	{
		// Token: 0x060002E0 RID: 736 RVA: 0x000084B4 File Offset: 0x000066B4
		public AboutWindow()
		{
			this.InitializeComponent();
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x00085AD8 File Offset: 0x00083CD8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107389115), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x000084C2 File Offset: 0x000066C2
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000041 RID: 65
		private bool _contentLoaded;
	}
}
