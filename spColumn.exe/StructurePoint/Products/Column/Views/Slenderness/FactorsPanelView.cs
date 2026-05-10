using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using #7hc;
using #cc;
using StructurePoint.CoreAssets.Column.Core.Core.App;

namespace StructurePoint.Products.Column.Views.Slenderness
{
	// Token: 0x0200004F RID: 79
	internal sealed class FactorsPanelView : ColumnBaseView, IComponentConnector, IView, #fc, #bc
	{
		// Token: 0x060003E2 RID: 994 RVA: 0x00008E21 File Offset: 0x00007021
		public FactorsPanelView()
		{
			this.InitializeComponent();
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x00086F50 File Offset: 0x00085150
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107387541), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060003E4 RID: 996 RVA: 0x00008E2F File Offset: 0x0000702F
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.LayoutRoot = (Grid)target;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x0400008C RID: 140
		internal Grid LayoutRoot;

		// Token: 0x0400008D RID: 141
		private bool _contentLoaded;
	}
}
