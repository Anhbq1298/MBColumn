using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using #7hc;
using #APb;
using StructurePoint.CoreAssets.Column.Core.Core.App;

namespace StructurePoint.Products.Column.Editor.Section.Design
{
	// Token: 0x020005C9 RID: 1481
	internal sealed class RectangularSectionDesView : ColumnBaseView, IComponentConnector, IView, #HPb
	{
		// Token: 0x06003360 RID: 13152 RVA: 0x0002D6F1 File Offset: 0x0002B8F1
		public RectangularSectionDesView()
		{
			this.InitializeComponent();
		}

		// Token: 0x06003361 RID: 13153 RVA: 0x0010201C File Offset: 0x0010021C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107353889), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06003362 RID: 13154 RVA: 0x00008739 File Offset: 0x00006939
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06003363 RID: 13155 RVA: 0x0002D6FF File Offset: 0x0002B8FF
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040014FD RID: 5373
		private bool _contentLoaded;
	}
}
