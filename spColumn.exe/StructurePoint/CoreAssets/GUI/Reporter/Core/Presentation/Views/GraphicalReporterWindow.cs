using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using #0Kd;
using #7hc;
using #ezc;
using StructurePoint.CoreAssets.GUI.Framework;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Printing.Presentation;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.FixedDocumentViewersUI;

namespace StructurePoint.CoreAssets.GUI.Reporter.Core.Presentation.Views
{
	// Token: 0x02000DC6 RID: 3526
	public sealed class GraphicalReporterWindow : Window, IComponentConnector, #QBc, #ZKd, #WBc
	{
		// Token: 0x06007F53 RID: 32595 RVA: 0x00067DC5 File Offset: 0x00065FC5
		public GraphicalReporterWindow()
		{
			this.InitializeComponent();
		}

		// Token: 0x17002631 RID: 9777
		// (get) Token: 0x06007F54 RID: 32596 RVA: 0x00067DD3 File Offset: 0x00065FD3
		public IViewModel ViewModel
		{
			get
			{
				return \u0092\u0002.\u0001\u0006(this) as IViewModel;
			}
		}

		// Token: 0x17002632 RID: 9778
		// (get) Token: 0x06007F55 RID: 32597 RVA: 0x00067DED File Offset: 0x00065FED
		public PrintOptionsControl PrintOptionsControl
		{
			get
			{
				return this.MyPrintOptionsControl;
			}
		}

		// Token: 0x17002633 RID: 9779
		// (get) Token: 0x06007F56 RID: 32598 RVA: 0x00067DF9 File Offset: 0x00065FF9
		public WordAndPdfReportPage WordAndPdfReportPage
		{
			get
			{
				return this.MyWordAndPdfReportPage;
			}
		}

		// Token: 0x06007F57 RID: 32599 RVA: 0x00067E05 File Offset: 0x00066005
		public void SetViewModel(IViewModel viewModel)
		{
			\u008A.\u008D\u0002(this, viewModel);
		}

		// Token: 0x06007F58 RID: 32600 RVA: 0x00067E1F File Offset: 0x0006601F
		public void SetOwner(object owner)
		{
			\u008A\u0005.\u0082\u000F(this, owner as Window);
		}

		// Token: 0x06007F59 RID: 32601 RVA: 0x00067407 File Offset: 0x00065607
		protected override void OnClosing(CancelEventArgs e)
		{
			\u0095.~\u0019\u0003(e, true);
			\u001A\u0005.\u000E\u000F(this, Visibility.Collapsed);
			\u001B\u0005.\u000F\u000F(this, e);
		}

		// Token: 0x06007F5A RID: 32602 RVA: 0x001BE2FC File Offset: 0x001BC4FC
		private void ExplorerToggleButton_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if (\u008B.~\u0095\u0002((RadToggleButton)sender).GetValueOrDefault())
			{
				\u0095.~\u008E\u0003(e, true);
			}
		}

		// Token: 0x06007F5B RID: 32603 RVA: 0x001BE33C File Offset: 0x001BC53C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri uri = new Uri(#Phc.#3hc(107280246), UriKind.Relative);
			\u0098.\u0091\u0003(this, uri);
		}

		// Token: 0x06007F5C RID: 32604 RVA: 0x00067E3E File Offset: 0x0006603E
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return \u008B\u0005.\u0083\u000F(delegateType, this, handler);
		}

		// Token: 0x06007F5D RID: 32605 RVA: 0x001BE384 File Offset: 0x001BC584
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.LeftColumn = (ColumnDefinition)target;
				return;
			case 2:
				this.PercentComboBox = (PercentComboBox)target;
				return;
			case 3:
				this.FitToSinglePage = (RadToggleButton)target;
				\u007F\u0005.~\u0019\u000F(this.FitToSinglePage, new MouseButtonEventHandler(this.ExplorerToggleButton_PreviewMouseLeftButtonDown));
				return;
			case 4:
				this.OptionsPanel = (Border)target;
				return;
			case 5:
				this.MyPrintOptionsControl = (PrintOptionsControl)target;
				return;
			case 6:
				this.LeftSplitter = (GridSplitter)target;
				return;
			case 7:
				this.MyWordAndPdfReportPage = (WordAndPdfReportPage)target;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x06007F5E RID: 32606 RVA: 0x00067E59 File Offset: 0x00066059
		void #WBc.Show()
		{
			\u0007.\u0080(this);
		}

		// Token: 0x06007F5F RID: 32607 RVA: 0x00008B22 File Offset: 0x00006D22
		bool? #WBc.ShowDialog()
		{
			return base.ShowDialog();
		}

		// Token: 0x06007F60 RID: 32608 RVA: 0x000344D3 File Offset: 0x000326D3
		void #WBc.Close()
		{
			\u0007.\u0010(this);
		}

		// Token: 0x06007F61 RID: 32609 RVA: 0x00008AED File Offset: 0x00006CED
		bool? #WBc.get_DialogResult()
		{
			return base.DialogResult;
		}

		// Token: 0x06007F62 RID: 32610 RVA: 0x00008AFD File Offset: 0x00006CFD
		void #WBc.set_DialogResult(bool? value)
		{
			base.DialogResult = value;
		}

		// Token: 0x06007F63 RID: 32611 RVA: 0x0003449F File Offset: 0x0003269F
		void #WBc.add_Closing(CancelEventHandler value)
		{
			\u0099.\u0092\u0003(this, value);
		}

		// Token: 0x06007F64 RID: 32612 RVA: 0x000344B9 File Offset: 0x000326B9
		void #WBc.remove_Closing(CancelEventHandler value)
		{
			\u0099.\u0093\u0003(this, value);
		}

		// Token: 0x06007F65 RID: 32613 RVA: 0x00067E6E File Offset: 0x0006606E
		void #WBc.add_Loaded(RoutedEventHandler value)
		{
			\u001F\u0005.\u0016\u000F(this, value);
		}

		// Token: 0x06007F66 RID: 32614 RVA: 0x00067E88 File Offset: 0x00066088
		void #WBc.remove_Loaded(RoutedEventHandler value)
		{
			\u001F\u0005.\u0017\u000F(this, value);
		}

		// Token: 0x04003440 RID: 13376
		internal ColumnDefinition LeftColumn;

		// Token: 0x04003441 RID: 13377
		internal PercentComboBox PercentComboBox;

		// Token: 0x04003442 RID: 13378
		internal RadToggleButton FitToSinglePage;

		// Token: 0x04003443 RID: 13379
		internal Border OptionsPanel;

		// Token: 0x04003444 RID: 13380
		internal PrintOptionsControl MyPrintOptionsControl;

		// Token: 0x04003445 RID: 13381
		internal GridSplitter LeftSplitter;

		// Token: 0x04003446 RID: 13382
		internal WordAndPdfReportPage MyWordAndPdfReportPage;

		// Token: 0x04003447 RID: 13383
		private bool _contentLoaded;
	}
}
