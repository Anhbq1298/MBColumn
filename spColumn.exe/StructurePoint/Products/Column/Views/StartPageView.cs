using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using #1b;
using #7hc;
using StructurePoint.CoreAssets.Column.Core.Core.App;

namespace StructurePoint.Products.Column.Views
{
	// Token: 0x02000030 RID: 48
	internal sealed class StartPageView : ColumnBaseView, IComponentConnector, IView, #9b
	{
		// Token: 0x06000364 RID: 868 RVA: 0x00008849 File Offset: 0x00006A49
		public StartPageView()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000365 RID: 869 RVA: 0x000863D4 File Offset: 0x000845D4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107389305), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000366 RID: 870 RVA: 0x00008739 File Offset: 0x00006939
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000367 RID: 871 RVA: 0x00008857 File Offset: 0x00006A57
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

		// Token: 0x0400005E RID: 94
		internal Grid LayoutRoot;

		// Token: 0x0400005F RID: 95
		private bool _contentLoaded;
	}
}
