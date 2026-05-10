using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using #5Kd;
using #7hc;
using #ezc;
using StructurePoint.CoreAssets.GUI.Framework;
using StructurePoint.CoreAssets.GUI.Framework.Services;

namespace StructurePoint.CoreAssets.GUI.Reporter.Core.Presentation.Views
{
	// Token: 0x02000DCA RID: 3530
	public sealed class PrintWindow : Window, IComponentConnector, #QBc, #WBc, #6Kd
	{
		// Token: 0x06007FA4 RID: 32676 RVA: 0x000680C8 File Offset: 0x000662C8
		public PrintWindow()
		{
			this.InitializeComponent();
			base.SnapsToDevicePixels = true;
			base.UseLayoutRounding = true;
		}

		// Token: 0x1700263D RID: 9789
		// (get) Token: 0x06007FA5 RID: 32677 RVA: 0x000680E4 File Offset: 0x000662E4
		// (set) Token: 0x06007FA6 RID: 32678 RVA: 0x000680F0 File Offset: 0x000662F0
		public IViewModel ViewModel { get; private set; }

		// Token: 0x1700263E RID: 9790
		// (get) Token: 0x06007FA7 RID: 32679 RVA: 0x00068101 File Offset: 0x00066301
		// (set) Token: 0x06007FA8 RID: 32680 RVA: 0x0006810D File Offset: 0x0006630D
		public IGenericLoaderWindow AssociatedLoaderWindow { get; set; }

		// Token: 0x06007FA9 RID: 32681 RVA: 0x0006811E File Offset: 0x0006631E
		public void SetViewModel(IViewModel viewModel)
		{
			this.ViewModel = viewModel;
			\u008A.\u008D\u0002(this, viewModel);
		}

		// Token: 0x06007FAA RID: 32682 RVA: 0x00067E1F File Offset: 0x0006601F
		public void SetOwner(object owner)
		{
			\u008A\u0005.\u0082\u000F(this, owner as Window);
		}

		// Token: 0x06007FAB RID: 32683 RVA: 0x00067407 File Offset: 0x00065607
		protected override void OnClosing(CancelEventArgs e)
		{
			\u0095.~\u0019\u0003(e, true);
			\u001A\u0005.\u000E\u000F(this, Visibility.Collapsed);
			\u001B\u0005.\u000F\u000F(this, e);
		}

		// Token: 0x06007FAC RID: 32684 RVA: 0x001BECAC File Offset: 0x001BCEAC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri uri = new Uri(#Phc.#3hc(107279435), UriKind.Relative);
			\u0098.\u0091\u0003(this, uri);
		}

		// Token: 0x06007FAD RID: 32685 RVA: 0x0006813F File Offset: 0x0006633F
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x06007FAE RID: 32686 RVA: 0x00067FDD File Offset: 0x000661DD
		void #6Kd.add_Activated(EventHandler value)
		{
			\u0091\u0005.\u008B\u000F(this, value);
		}

		// Token: 0x06007FAF RID: 32687 RVA: 0x00067FF7 File Offset: 0x000661F7
		void #6Kd.remove_Activated(EventHandler value)
		{
			\u0091\u0005.\u008C\u000F(this, value);
		}

		// Token: 0x06007FB0 RID: 32688 RVA: 0x00067E59 File Offset: 0x00066059
		void #WBc.Show()
		{
			\u0007.\u0080(this);
		}

		// Token: 0x06007FB1 RID: 32689 RVA: 0x00008B22 File Offset: 0x00006D22
		bool? #WBc.ShowDialog()
		{
			return base.ShowDialog();
		}

		// Token: 0x06007FB2 RID: 32690 RVA: 0x000344D3 File Offset: 0x000326D3
		void #WBc.Close()
		{
			\u0007.\u0010(this);
		}

		// Token: 0x06007FB3 RID: 32691 RVA: 0x00008AED File Offset: 0x00006CED
		bool? #WBc.get_DialogResult()
		{
			return base.DialogResult;
		}

		// Token: 0x06007FB4 RID: 32692 RVA: 0x00008AFD File Offset: 0x00006CFD
		void #WBc.set_DialogResult(bool? value)
		{
			base.DialogResult = value;
		}

		// Token: 0x06007FB5 RID: 32693 RVA: 0x0003449F File Offset: 0x0003269F
		void #WBc.add_Closing(CancelEventHandler value)
		{
			\u0099.\u0092\u0003(this, value);
		}

		// Token: 0x06007FB6 RID: 32694 RVA: 0x000344B9 File Offset: 0x000326B9
		void #WBc.remove_Closing(CancelEventHandler value)
		{
			\u0099.\u0093\u0003(this, value);
		}

		// Token: 0x06007FB7 RID: 32695 RVA: 0x00067E6E File Offset: 0x0006606E
		void #WBc.add_Loaded(RoutedEventHandler value)
		{
			\u001F\u0005.\u0016\u000F(this, value);
		}

		// Token: 0x06007FB8 RID: 32696 RVA: 0x00067E88 File Offset: 0x00066088
		void #WBc.remove_Loaded(RoutedEventHandler value)
		{
			\u001F\u0005.\u0017\u000F(this, value);
		}

		// Token: 0x04003461 RID: 13409
		private bool _contentLoaded;
	}
}
