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
	// Token: 0x02000055 RID: 85
	internal sealed class Diagrams2dColorsView : ColumnBaseView, IComponentConnector, IView, #oc
	{
		// Token: 0x060003EB RID: 1003 RVA: 0x00008EA4 File Offset: 0x000070A4
		public Diagrams2dColorsView()
		{
			this.InitializeComponent();
		}

		// Token: 0x060003EC RID: 1004 RVA: 0x0008701C File Offset: 0x0008521C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107387782), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060003ED RID: 1005 RVA: 0x00008EB2 File Offset: 0x000070B2
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000091 RID: 145
		private bool _contentLoaded;
	}
}
