using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using #3yb;
using #7hc;
using StructurePoint.CoreAssets.Column.Core.Core.App;

namespace StructurePoint.Products.Column.Editor.Section.Irregular.Views
{
	// Token: 0x020004D0 RID: 1232
	internal sealed class IrregularToolbarView : ColumnBaseView, IComponentConnector, IView, #4yb
	{
		// Token: 0x06002D3C RID: 11580 RVA: 0x00028855 File Offset: 0x00026A55
		public IrregularToolbarView()
		{
			this.InitializeComponent();
		}

		// Token: 0x06002D3D RID: 11581 RVA: 0x000EDCE4 File Offset: 0x000EBEE4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107356459), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06002D3E RID: 11582 RVA: 0x00008739 File Offset: 0x00006939
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06002D3F RID: 11583 RVA: 0x00028863 File Offset: 0x00026A63
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04001243 RID: 4675
		private bool _contentLoaded;
	}
}
