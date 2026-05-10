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
	// Token: 0x02000063 RID: 99
	internal sealed class SectionsColorsView : ColumnBaseView, IComponentConnector, IView, #uc
	{
		// Token: 0x06000400 RID: 1024 RVA: 0x00008F61 File Offset: 0x00007161
		public SectionsColorsView()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000401 RID: 1025 RVA: 0x000871F8 File Offset: 0x000853F8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107387231), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000402 RID: 1026 RVA: 0x00008F6F File Offset: 0x0000716F
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000098 RID: 152
		private bool _contentLoaded;
	}
}
