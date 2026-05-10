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
using StructurePoint.Products.Column.Views.API.Slenderness;

namespace StructurePoint.Products.Column.Views.Slenderness
{
	// Token: 0x0200004B RID: 75
	internal sealed class DesignColumnPanelView : ColumnBaseView, IComponentConnector, IView, #fc, IDesignColumnPanelView
	{
		// Token: 0x060003DB RID: 987 RVA: 0x00008DC4 File Offset: 0x00006FC4
		public DesignColumnPanelView()
		{
			this.InitializeComponent();
		}

		// Token: 0x060003DC RID: 988 RVA: 0x00086EC8 File Offset: 0x000850C8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107388223), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060003DD RID: 989 RVA: 0x00008DD2 File Offset: 0x00006FD2
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

		// Token: 0x04000089 RID: 137
		internal Grid LayoutRoot;

		// Token: 0x0400008A RID: 138
		private bool _contentLoaded;
	}
}
