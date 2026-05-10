using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using #7hc;
using #hc;
using StructurePoint.CoreAssets.Column.Core.Core.App;

namespace StructurePoint.Products.Column.Views.Loads
{
	// Token: 0x02000075 RID: 117
	internal sealed class LoadsWindowView : ColumnWindow, IComponentConnector, IColumnWindow, IView, #kc
	{
		// Token: 0x06000449 RID: 1097 RVA: 0x0000939C File Offset: 0x0000759C
		public LoadsWindowView()
		{
			this.InitializeComponent();
			base.CloseWithEscape = true;
		}

		// Token: 0x0600044A RID: 1098 RVA: 0x00087C80 File Offset: 0x00085E80
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107386120), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600044B RID: 1099 RVA: 0x00008739 File Offset: 0x00006939
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600044C RID: 1100 RVA: 0x000093B1 File Offset: 0x000075B1
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040000B4 RID: 180
		private bool _contentLoaded;
	}
}
