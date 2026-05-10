using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using #0Kd;
using #7hc;
using #ezc;
using StructurePoint.CoreAssets.GUI.Framework;

namespace StructurePoint.CoreAssets.GUI.Reporter.Core.Presentation.Views
{
	// Token: 0x02000DC9 RID: 3529
	public sealed class ReporterSettingsWindow : Window, IComponentConnector, #QBc, #WBc, #1Kd
	{
		// Token: 0x06007F92 RID: 32658 RVA: 0x0006806F File Offset: 0x0006626F
		public ReporterSettingsWindow()
		{
			this.InitializeComponent();
		}

		// Token: 0x1700263C RID: 9788
		// (get) Token: 0x06007F93 RID: 32659 RVA: 0x0006807D File Offset: 0x0006627D
		// (set) Token: 0x06007F94 RID: 32660 RVA: 0x00068089 File Offset: 0x00066289
		public IViewModel ViewModel { get; private set; }

		// Token: 0x06007F95 RID: 32661 RVA: 0x0006809A File Offset: 0x0006629A
		public void SetViewModel(IViewModel viewModel)
		{
			\u008A.\u008D\u0002(this, viewModel);
			this.ViewModel = viewModel;
		}

		// Token: 0x06007F96 RID: 32662 RVA: 0x00067E1F File Offset: 0x0006601F
		public void SetOwner(object owner)
		{
			\u008A\u0005.\u0082\u000F(this, owner as Window);
		}

		// Token: 0x06007F97 RID: 32663 RVA: 0x000673D2 File Offset: 0x000655D2
		protected override void OnKeyUp(KeyEventArgs e)
		{
			if (\u0018\u0005.~\u0007\u000F(e) == Key.Escape)
			{
				\u0007.\u0010(this);
				return;
			}
			\u0019\u0005.\u0008\u000F(this, e);
		}

		// Token: 0x06007F98 RID: 32664 RVA: 0x00067407 File Offset: 0x00065607
		protected override void OnClosing(CancelEventArgs e)
		{
			\u0095.~\u0019\u0003(e, true);
			\u001A\u0005.\u000E\u000F(this, Visibility.Collapsed);
			\u001B\u0005.\u000F\u000F(this, e);
		}

		// Token: 0x06007F99 RID: 32665 RVA: 0x001BEC64 File Offset: 0x001BCE64
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri uri = new Uri(#Phc.#3hc(107279524), UriKind.Relative);
			\u0098.\u0091\u0003(this, uri);
		}

		// Token: 0x06007F9A RID: 32666 RVA: 0x000680BB File Offset: 0x000662BB
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x06007F9B RID: 32667 RVA: 0x00067E59 File Offset: 0x00066059
		void #WBc.Show()
		{
			\u0007.\u0080(this);
		}

		// Token: 0x06007F9C RID: 32668 RVA: 0x00008B22 File Offset: 0x00006D22
		bool? #WBc.ShowDialog()
		{
			return base.ShowDialog();
		}

		// Token: 0x06007F9D RID: 32669 RVA: 0x000344D3 File Offset: 0x000326D3
		void #WBc.Close()
		{
			\u0007.\u0010(this);
		}

		// Token: 0x06007F9E RID: 32670 RVA: 0x00008AED File Offset: 0x00006CED
		bool? #WBc.get_DialogResult()
		{
			return base.DialogResult;
		}

		// Token: 0x06007F9F RID: 32671 RVA: 0x00008AFD File Offset: 0x00006CFD
		void #WBc.set_DialogResult(bool? value)
		{
			base.DialogResult = value;
		}

		// Token: 0x06007FA0 RID: 32672 RVA: 0x0003449F File Offset: 0x0003269F
		void #WBc.add_Closing(CancelEventHandler value)
		{
			\u0099.\u0092\u0003(this, value);
		}

		// Token: 0x06007FA1 RID: 32673 RVA: 0x000344B9 File Offset: 0x000326B9
		void #WBc.remove_Closing(CancelEventHandler value)
		{
			\u0099.\u0093\u0003(this, value);
		}

		// Token: 0x06007FA2 RID: 32674 RVA: 0x00067E6E File Offset: 0x0006606E
		void #WBc.add_Loaded(RoutedEventHandler value)
		{
			\u001F\u0005.\u0016\u000F(this, value);
		}

		// Token: 0x06007FA3 RID: 32675 RVA: 0x00067E88 File Offset: 0x00066088
		void #WBc.remove_Loaded(RoutedEventHandler value)
		{
			\u001F\u0005.\u0017\u000F(this, value);
		}

		// Token: 0x0400345E RID: 13406
		private bool _contentLoaded;
	}
}
