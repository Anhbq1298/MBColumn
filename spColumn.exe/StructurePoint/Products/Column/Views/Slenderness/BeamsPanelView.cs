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
	// Token: 0x02000051 RID: 81
	internal sealed class BeamsPanelView : ColumnBaseView, IComponentConnector, IView, #fc, IBeamsPanelView
	{
		// Token: 0x060003E5 RID: 997 RVA: 0x00008E55 File Offset: 0x00007055
		public BeamsPanelView()
		{
			this.InitializeComponent();
		}

		// Token: 0x060003E6 RID: 998 RVA: 0x00086F94 File Offset: 0x00085194
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107387428), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060003E7 RID: 999 RVA: 0x00008E63 File Offset: 0x00007063
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

		// Token: 0x0400008E RID: 142
		internal Grid LayoutRoot;

		// Token: 0x0400008F RID: 143
		private bool _contentLoaded;
	}
}
