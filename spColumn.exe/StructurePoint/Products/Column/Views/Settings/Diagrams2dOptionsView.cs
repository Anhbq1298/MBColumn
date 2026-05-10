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
	// Token: 0x02000057 RID: 87
	internal sealed class Diagrams2dOptionsView : ColumnBaseView, IComponentConnector, IView, #rc
	{
		// Token: 0x060003EE RID: 1006 RVA: 0x00008EBF File Offset: 0x000070BF
		public Diagrams2dOptionsView()
		{
			this.InitializeComponent();
		}

		// Token: 0x060003EF RID: 1007 RVA: 0x00087060 File Offset: 0x00085260
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107387733), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060003F0 RID: 1008 RVA: 0x00008ECD File Offset: 0x000070CD
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000092 RID: 146
		private bool _contentLoaded;
	}
}
