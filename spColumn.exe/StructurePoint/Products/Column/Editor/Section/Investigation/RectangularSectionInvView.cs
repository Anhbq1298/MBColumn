using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using #7hc;
using #APb;
using StructurePoint.CoreAssets.Column.Core.Core.App;

namespace StructurePoint.Products.Column.Editor.Section.Investigation
{
	// Token: 0x020005A5 RID: 1445
	internal sealed class RectangularSectionInvView : ColumnBaseView, IComponentConnector, IView, #JPb
	{
		// Token: 0x0600327E RID: 12926 RVA: 0x0002CAB4 File Offset: 0x0002ACB4
		public RectangularSectionInvView()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600327F RID: 12927 RVA: 0x000FFFCC File Offset: 0x000FE1CC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107354453), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06003280 RID: 12928 RVA: 0x00008739 File Offset: 0x00006939
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06003281 RID: 12929 RVA: 0x0002CAC2 File Offset: 0x0002ACC2
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04001487 RID: 5255
		private bool _contentLoaded;
	}
}
