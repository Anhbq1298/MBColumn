using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using #7hc;
using #qzb;
using StructurePoint.CoreAssets.Column.Core.Core.App;

namespace StructurePoint.Products.Column.Editor.Section.Irregular.Tools.Shapes
{
	// Token: 0x02000505 RID: 1285
	internal sealed class ShapeParametersView : ColumnBaseView, IComponentConnector, IView, #0zb
	{
		// Token: 0x06002ED1 RID: 11985 RVA: 0x00029E8C File Offset: 0x0002808C
		public ShapeParametersView()
		{
			this.InitializeComponent();
		}

		// Token: 0x06002ED2 RID: 11986 RVA: 0x000F23C0 File Offset: 0x000F05C0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107355857), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06002ED3 RID: 11987 RVA: 0x00029E9A File Offset: 0x0002809A
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040012C9 RID: 4809
		private bool _contentLoaded;
	}
}
