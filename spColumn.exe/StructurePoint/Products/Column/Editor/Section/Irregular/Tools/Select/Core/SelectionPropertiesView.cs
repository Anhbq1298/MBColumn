using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using #7hc;
using #ABb;
using StructurePoint.CoreAssets.Column.Core.Core.App;

namespace StructurePoint.Products.Column.Editor.Section.Irregular.Tools.Select.Core
{
	// Token: 0x0200055D RID: 1373
	internal sealed class SelectionPropertiesView : ColumnBaseView, IComponentConnector, IView, #mCb
	{
		// Token: 0x060030CA RID: 12490 RVA: 0x0002B3BF File Offset: 0x000295BF
		public SelectionPropertiesView()
		{
			this.InitializeComponent();
		}

		// Token: 0x060030CB RID: 12491 RVA: 0x000FA130 File Offset: 0x000F8330
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107355990), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060030CC RID: 12492 RVA: 0x00008739 File Offset: 0x00006939
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060030CD RID: 12493 RVA: 0x0002B3CD File Offset: 0x000295CD
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040013D2 RID: 5074
		private bool _contentLoaded;
	}
}
