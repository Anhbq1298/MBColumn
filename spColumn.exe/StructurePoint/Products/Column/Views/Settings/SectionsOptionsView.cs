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
	// Token: 0x02000065 RID: 101
	internal sealed class SectionsOptionsView : ColumnBaseView, IComponentConnector, IView, #vc
	{
		// Token: 0x06000403 RID: 1027 RVA: 0x00008F7C File Offset: 0x0000717C
		public SectionsOptionsView()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000404 RID: 1028 RVA: 0x0008723C File Offset: 0x0008543C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107386606), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000405 RID: 1029 RVA: 0x00008F8A File Offset: 0x0000718A
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000099 RID: 153
		private bool _contentLoaded;
	}
}
