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
	// Token: 0x020005C7 RID: 1479
	internal sealed class CircularSectionDesView : ColumnBaseView, IComponentConnector, IView, #GPb
	{
		// Token: 0x0600335C RID: 13148 RVA: 0x0002D6D6 File Offset: 0x0002B8D6
		public CircularSectionDesView()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600335D RID: 13149 RVA: 0x00101FD8 File Offset: 0x001001D8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107354014), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600335E RID: 13150 RVA: 0x00008739 File Offset: 0x00006939
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600335F RID: 13151 RVA: 0x0002D6E4 File Offset: 0x0002B8E4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040014FC RID: 5372
		private bool _contentLoaded;
	}
}
