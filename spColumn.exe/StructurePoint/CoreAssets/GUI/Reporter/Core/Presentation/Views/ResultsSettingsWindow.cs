using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using #5Kd;
using #7hc;
using #ezc;
using StructurePoint.CoreAssets.GUI.Framework;

namespace StructurePoint.CoreAssets.GUI.Reporter.Core.Presentation.Views
{
	// Token: 0x02000DD1 RID: 3537
	public sealed class ResultsSettingsWindow : Window, IComponentConnector, #QBc, #WBc, #7Kd
	{
		// Token: 0x06008000 RID: 32768 RVA: 0x00068360 File Offset: 0x00066560
		public ResultsSettingsWindow()
		{
			this.InitializeComponent();
		}

		// Token: 0x17002646 RID: 9798
		// (get) Token: 0x06008001 RID: 32769 RVA: 0x0006836E File Offset: 0x0006656E
		// (set) Token: 0x06008002 RID: 32770 RVA: 0x0006837A File Offset: 0x0006657A
		public IViewModel ViewModel { get; private set; }

		// Token: 0x06008003 RID: 32771 RVA: 0x0006838B File Offset: 0x0006658B
		public void SetViewModel(IViewModel viewModel)
		{
			\u008A.\u008D\u0002(this, viewModel);
			this.ViewModel = viewModel;
		}

		// Token: 0x06008004 RID: 32772 RVA: 0x00067E1F File Offset: 0x0006601F
		public void SetOwner(object owner)
		{
			\u008A\u0005.\u0082\u000F(this, owner as Window);
		}

		// Token: 0x06008005 RID: 32773 RVA: 0x000673D2 File Offset: 0x000655D2
		protected override void OnKeyUp(KeyEventArgs e)
		{
			if (\u0018\u0005.~\u0007\u000F(e) == Key.Escape)
			{
				\u0007.\u0010(this);
				return;
			}
			\u0019\u0005.\u0008\u000F(this, e);
		}

		// Token: 0x06008006 RID: 32774 RVA: 0x00067407 File Offset: 0x00065607
		protected override void OnClosing(CancelEventArgs e)
		{
			\u0095.~\u0019\u0003(e, true);
			\u001A\u0005.\u000E\u000F(this, Visibility.Collapsed);
			\u001B\u0005.\u000F\u000F(this, e);
		}

		// Token: 0x06008007 RID: 32775 RVA: 0x001BF784 File Offset: 0x001BD984
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri uri = new Uri(#Phc.#3hc(107278985), UriKind.Relative);
			\u0098.\u0091\u0003(this, uri);
		}

		// Token: 0x06008008 RID: 32776 RVA: 0x000683AC File Offset: 0x000665AC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x06008009 RID: 32777 RVA: 0x00067E59 File Offset: 0x00066059
		void #WBc.Show()
		{
			\u0007.\u0080(this);
		}

		// Token: 0x0600800A RID: 32778 RVA: 0x00008B22 File Offset: 0x00006D22
		bool? #WBc.ShowDialog()
		{
			return base.ShowDialog();
		}

		// Token: 0x0600800B RID: 32779 RVA: 0x000344D3 File Offset: 0x000326D3
		void #WBc.Close()
		{
			\u0007.\u0010(this);
		}

		// Token: 0x0600800C RID: 32780 RVA: 0x00008AED File Offset: 0x00006CED
		bool? #WBc.get_DialogResult()
		{
			return base.DialogResult;
		}

		// Token: 0x0600800D RID: 32781 RVA: 0x00008AFD File Offset: 0x00006CFD
		void #WBc.set_DialogResult(bool? value)
		{
			base.DialogResult = value;
		}

		// Token: 0x0600800E RID: 32782 RVA: 0x0003449F File Offset: 0x0003269F
		void #WBc.add_Closing(CancelEventHandler value)
		{
			\u0099.\u0092\u0003(this, value);
		}

		// Token: 0x0600800F RID: 32783 RVA: 0x000344B9 File Offset: 0x000326B9
		void #WBc.remove_Closing(CancelEventHandler value)
		{
			\u0099.\u0093\u0003(this, value);
		}

		// Token: 0x06008010 RID: 32784 RVA: 0x00067E6E File Offset: 0x0006606E
		void #WBc.add_Loaded(RoutedEventHandler value)
		{
			\u001F\u0005.\u0016\u000F(this, value);
		}

		// Token: 0x06008011 RID: 32785 RVA: 0x00067E88 File Offset: 0x00066088
		void #WBc.remove_Loaded(RoutedEventHandler value)
		{
			\u001F\u0005.\u0017\u000F(this, value);
		}

		// Token: 0x0400347E RID: 13438
		private bool _contentLoaded;
	}
}
