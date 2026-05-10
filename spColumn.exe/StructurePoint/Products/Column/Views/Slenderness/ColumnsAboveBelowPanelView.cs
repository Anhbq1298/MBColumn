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
	// Token: 0x02000048 RID: 72
	internal sealed class ColumnsAboveBelowPanelView : ColumnBaseView, IComponentConnector, IView, #dc, #fc
	{
		// Token: 0x060003D8 RID: 984 RVA: 0x00008D90 File Offset: 0x00006F90
		public ColumnsAboveBelowPanelView()
		{
			this.InitializeComponent();
		}

		// Token: 0x060003D9 RID: 985 RVA: 0x00086E84 File Offset: 0x00085084
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107388316), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060003DA RID: 986 RVA: 0x00008D9E File Offset: 0x00006F9E
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

		// Token: 0x04000087 RID: 135
		internal Grid LayoutRoot;

		// Token: 0x04000088 RID: 136
		private bool _contentLoaded;
	}
}
