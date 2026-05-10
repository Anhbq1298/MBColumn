using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using #7hc;
using #aAb;
using #tFb;
using StructurePoint.CoreAssets.Column.Core.Core.App;

namespace StructurePoint.Products.Column.Editor.Section.Irregular.Tools.Reinforcement
{
	// Token: 0x02000595 RID: 1429
	internal sealed class DefaultBarParametersView : ColumnBaseView, IComponentConnector, IView, #dBb, #IFb, #GFb, #uFb, #yFb, #AFb
	{
		// Token: 0x0600324E RID: 12878 RVA: 0x0002C882 File Offset: 0x0002AA82
		public DefaultBarParametersView()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600324F RID: 12879 RVA: 0x000FF798 File Offset: 0x000FD998
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107354144), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06003250 RID: 12880 RVA: 0x0002C890 File Offset: 0x0002AA90
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04001470 RID: 5232
		private bool _contentLoaded;
	}
}
