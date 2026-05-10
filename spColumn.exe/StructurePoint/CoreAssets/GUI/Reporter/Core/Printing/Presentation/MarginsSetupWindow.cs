using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using #7hc;

namespace StructurePoint.CoreAssets.GUI.Reporter.Core.Printing.Presentation
{
	// Token: 0x02000DB0 RID: 3504
	public sealed class MarginsSetupWindow : Window, IComponentConnector
	{
		// Token: 0x06007EA2 RID: 32418 RVA: 0x000673C4 File Offset: 0x000655C4
		public MarginsSetupWindow()
		{
			this.InitializeComponent();
		}

		// Token: 0x06007EA3 RID: 32419 RVA: 0x000673D2 File Offset: 0x000655D2
		protected override void OnKeyUp(KeyEventArgs e)
		{
			if (\u0018\u0005.~\u0007\u000F(e) == Key.Escape)
			{
				\u0007.\u0010(this);
				return;
			}
			\u0019\u0005.\u0008\u000F(this, e);
		}

		// Token: 0x06007EA4 RID: 32420 RVA: 0x00067407 File Offset: 0x00065607
		protected override void OnClosing(CancelEventArgs e)
		{
			\u0095.~\u0019\u0003(e, true);
			\u001A\u0005.\u000E\u000F(this, Visibility.Collapsed);
			\u001B\u0005.\u000F\u000F(this, e);
		}

		// Token: 0x06007EA5 RID: 32421 RVA: 0x001BCB10 File Offset: 0x001BAD10
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri uri = new Uri(#Phc.#3hc(107280467), UriKind.Relative);
			\u0098.\u0091\u0003(this, uri);
		}

		// Token: 0x06007EA6 RID: 32422 RVA: 0x00067439 File Offset: 0x00065639
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040033EA RID: 13290
		private bool _contentLoaded;
	}
}
