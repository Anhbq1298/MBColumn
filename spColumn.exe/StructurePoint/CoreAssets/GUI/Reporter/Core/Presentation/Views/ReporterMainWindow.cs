using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using #5Kd;
using #7hc;
using #ezc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.Framework;
using StructurePoint.CoreAssets.GUI.Framework.Services;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.FixedDocumentViewersUI;

namespace StructurePoint.CoreAssets.GUI.Reporter.Core.Presentation.Views
{
	// Token: 0x02000DC7 RID: 3527
	public sealed class ReporterMainWindow : Window, IComponentConnector, #QBc, #WBc, #4Kd
	{
		// Token: 0x06007F67 RID: 32615 RVA: 0x001BE454 File Offset: 0x001BC654
		public ReporterMainWindow()
		{
			this.InitializeComponent();
			base.SnapsToDevicePixels = true;
			base.UseLayoutRounding = true;
			this.explorerPosition = (ExplorerPosition)(-1);
			this.LeftExplorerToggleButton.PreviewMouseLeftButtonDown += this.ExplorerToggleButton_PreviewMouseLeftButtonDown;
			this.LeftExplorerToggleButton.PreviewKeyDown += this.ExplorerToggleButton_PreviewKeyDown;
			this.SetupToggleButton.PreviewMouseLeftButtonDown += this.ExplorerToggleButton_PreviewMouseLeftButtonDown;
			this.SetupToggleButton.PreviewKeyDown += this.ExplorerToggleButton_PreviewKeyDown;
			this.SetupToggleButton.Checked += this.SetupToggleButton_Checked;
			this.LeftExplorerToggleButton.Checked += this.ExplorerToggleButton_Checked;
			this.LeftExplorerToggleButton.Unchecked += this.ExplorerToggleButton_Unchecked;
		}

		// Token: 0x17002634 RID: 9780
		// (get) Token: 0x06007F68 RID: 32616 RVA: 0x00067EA2 File Offset: 0x000660A2
		public static GridLength InitialPanelColumnWidth
		{
			get
			{
				return new GridLength(330.0);
			}
		}

		// Token: 0x17002635 RID: 9781
		// (get) Token: 0x06007F69 RID: 32617 RVA: 0x00067EB6 File Offset: 0x000660B6
		public static double MinPanelColumnWidth
		{
			get
			{
				return 290.0;
			}
		}

		// Token: 0x17002636 RID: 9782
		// (get) Token: 0x06007F6A RID: 32618 RVA: 0x00067EC1 File Offset: 0x000660C1
		// (set) Token: 0x06007F6B RID: 32619 RVA: 0x00067ECD File Offset: 0x000660CD
		public IViewModel ViewModel { get; private set; }

		// Token: 0x17002637 RID: 9783
		// (get) Token: 0x06007F6C RID: 32620 RVA: 0x00067EDE File Offset: 0x000660DE
		// (set) Token: 0x06007F6D RID: 32621 RVA: 0x00067EEA File Offset: 0x000660EA
		public IGenericLoaderWindow AssociatedLoaderWindow { get; set; }

		// Token: 0x17002638 RID: 9784
		// (get) Token: 0x06007F6E RID: 32622 RVA: 0x00067EFB File Offset: 0x000660FB
		public RadPdfViewer WordAndPdfViewer
		{
			get
			{
				return this.WordAndPdfReportPage.Viewer;
			}
		}

		// Token: 0x17002639 RID: 9785
		// (get) Token: 0x06007F6F RID: 32623 RVA: 0x00067F10 File Offset: 0x00066110
		public CustomRadNumericUpDown PageNumberUpDown
		{
			get
			{
				return this.PageNumberBox;
			}
		}

		// Token: 0x1700263A RID: 9786
		// (get) Token: 0x06007F70 RID: 32624 RVA: 0x00067F1C File Offset: 0x0006611C
		public RadPdfViewer TextViewer
		{
			get
			{
				return this.TextReportPage.Viewer;
			}
		}

		// Token: 0x1700263B RID: 9787
		// (get) Token: 0x06007F71 RID: 32625 RVA: 0x00067F31 File Offset: 0x00066131
		// (set) Token: 0x06007F72 RID: 32626 RVA: 0x00067F3D File Offset: 0x0006613D
		public ExplorerPosition ExplorerPosition
		{
			get
			{
				return this.explorerPosition;
			}
			set
			{
				if (this.explorerPosition != value)
				{
					this.explorerPosition = value;
					this.MyApplyExplorerPosition(value);
				}
			}
		}

		// Token: 0x06007F73 RID: 32627 RVA: 0x00067F62 File Offset: 0x00066162
		public void SetViewModel(IViewModel viewModel)
		{
			this.ViewModel = viewModel;
			\u008A.\u008D\u0002(this, viewModel);
		}

		// Token: 0x06007F74 RID: 32628 RVA: 0x00067E1F File Offset: 0x0006601F
		public void SetOwner(object owner)
		{
			\u008A\u0005.\u0082\u000F(this, owner as Window);
		}

		// Token: 0x06007F75 RID: 32629 RVA: 0x00067407 File Offset: 0x00065607
		protected override void OnClosing(CancelEventArgs e)
		{
			\u0095.~\u0019\u0003(e, true);
			\u001A\u0005.\u000E\u000F(this, Visibility.Collapsed);
			\u001B\u0005.\u000F\u000F(this, e);
		}

		// Token: 0x06007F76 RID: 32630 RVA: 0x00067F83 File Offset: 0x00066183
		public void LoadSpreadsheet(Stream stream)
		{
			this.ExcelPage.LoadSpreadsheet(stream);
		}

		// Token: 0x06007F77 RID: 32631 RVA: 0x00067F9D File Offset: 0x0006619D
		public void NavigateSpreadsheet(string item)
		{
			this.ExcelPage.Navigate(item);
		}

		// Token: 0x06007F78 RID: 32632 RVA: 0x00067FB7 File Offset: 0x000661B7
		public void BringToFront()
		{
			this.ShowEx();
		}

		// Token: 0x06007F79 RID: 32633 RVA: 0x001BE534 File Offset: 0x001BC734
		private void ExplorerToggleButton_Unchecked(object sender, RoutedEventArgs e)
		{
			if (this.ExplorerPosition == ExplorerPosition.Right)
			{
				this.lastColumnWidth = \u001B\u0002.~\u0001\u0005(this.RightColumn);
				\u001A\u0005.~\u000E\u000F(this.ExplorerPanel, Visibility.Collapsed);
				\u001A\u0005.~\u000E\u000F(this.RightSplitter, Visibility.Collapsed);
				\u008D\u0005.~\u0086\u000F(this.RightColumn, \u008C\u0005.\u0084\u000F());
				\u009F\u0002.~\u0093\u0006(this.RightColumn, 0.0);
			}
		}

		// Token: 0x06007F7A RID: 32634 RVA: 0x001BE5C8 File Offset: 0x001BC7C8
		private void ExplorerToggleButton_Checked(object sender, RoutedEventArgs e)
		{
			if (this.ExplorerPosition == ExplorerPosition.Left)
			{
				\u001A\u0005.~\u000E\u000F(this.ExplorerPanel, Visibility.Visible);
				\u001A\u0005.~\u000E\u000F(this.OptionsPanel, Visibility.Collapsed);
				\u008E\u0005.~\u0087\u000F(this.SetupToggleButton, new bool?(false));
				return;
			}
			if (this.ExplorerPosition == ExplorerPosition.Right)
			{
				\u001A\u0005.~\u000E\u000F(this.ExplorerPanel, Visibility.Visible);
				\u001A\u0005.~\u000E\u000F(this.RightSplitter, Visibility.Visible);
				\u008D\u0005.~\u0086\u000F(this.RightColumn, new GridLength(this.lastColumnWidth));
				\u009F\u0002.~\u0093\u0006(this.RightColumn, ReporterMainWindow.MinPanelColumnWidth);
			}
		}

		// Token: 0x06007F7B RID: 32635 RVA: 0x001BE690 File Offset: 0x001BC890
		private void SetupToggleButton_Checked(object sender, RoutedEventArgs e)
		{
			if (this.ExplorerPosition == ExplorerPosition.Left)
			{
				\u001A\u0005.~\u000E\u000F(this.ExplorerPanel, Visibility.Collapsed);
				\u001A\u0005.~\u000E\u000F(this.OptionsPanel, Visibility.Visible);
				\u008E\u0005.~\u0087\u000F(this.LeftExplorerToggleButton, new bool?(false));
			}
		}

		// Token: 0x06007F7C RID: 32636 RVA: 0x00067FC7 File Offset: 0x000661C7
		private void ExplorerToggleButton_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			\u0095.~\u008E\u0003(e, true);
		}

		// Token: 0x06007F7D RID: 32637 RVA: 0x001BE6EC File Offset: 0x001BC8EC
		private void ExplorerToggleButton_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			RadToggleButton radToggleButton = (RadToggleButton)sender;
			if (radToggleButton == this.LeftExplorerToggleButton && this.ExplorerPosition == ExplorerPosition.Right)
			{
				return;
			}
			if (\u008B.~\u0095\u0002(radToggleButton).GetValueOrDefault())
			{
				\u0095.~\u008E\u0003(e, true);
			}
		}

		// Token: 0x06007F7E RID: 32638 RVA: 0x001BE740 File Offset: 0x001BC940
		private void CurrentPage_KeyDown(object sender, KeyEventArgs e)
		{
			TextBox textBox = sender as TextBox;
			if (textBox != null && \u0018\u0005.~\u0007\u000F(e) == Key.Return)
			{
				BindingExpression bindingExpression = \u001D\u0005.~\u0011\u000F(textBox, TextBox.TextProperty);
				if (bindingExpression == null)
				{
					return;
				}
				bindingExpression.UpdateSource();
			}
		}

		// Token: 0x06007F7F RID: 32639 RVA: 0x001BE78C File Offset: 0x001BC98C
		private void MyApplyExplorerPosition(ExplorerPosition position)
		{
			this.ExplorerView.ExplorerPosition = position;
			if (position == ExplorerPosition.Right)
			{
				\u001A\u0005.~\u000E\u000F(this.SetupToggleButton, Visibility.Collapsed);
				\u008E\u0005.~\u0087\u000F(this.SetupToggleButton, new bool?(false));
				\u008E\u0005.~\u0087\u000F(this.LeftExplorerToggleButton, new bool?(true));
				\u008F\u0005.\u0088\u000F(this.LeftExplorerToggleButton, 4);
				\u0090\u0005.~\u0089\u000F(this.LeftExplorerToggleButton, new Thickness(0.0, 0.0, 5.0, 0.0));
				\u001A\u0005.~\u000E\u000F(this.ExplorerPanel, Visibility.Visible);
				\u001A\u0005.~\u000E\u000F(this.RightSplitter, Visibility.Visible);
				\u001A\u0005.~\u000E\u000F(this.OptionsPanel, Visibility.Visible);
				\u009B\u0002.~\u0012\u0006(this.ExplorerPanel, Grid.ColumnProperty, 4);
				\u009F\u0002.~\u0093\u0006(this.RightColumn, ReporterMainWindow.MinPanelColumnWidth);
				this.RightColumn.Width = ((\u0015\u0002.\u0090\u0004(\u001B\u0002.~\u0001\u0005(this.LeftColumn)) || \u001B\u0002.~\u0001\u0005(this.LeftColumn) <= 0.0) ? ((this.lastColumnWidth > 0.0) ? new GridLength(this.lastColumnWidth) : ReporterMainWindow.InitialPanelColumnWidth) : new GridLength(\u001B\u0002.~\u0001\u0005(this.LeftColumn)));
				return;
			}
			\u008D\u0005.~\u0086\u000F(this.RightColumn, \u008C\u0005.\u0084\u000F());
			\u009F\u0002.~\u0093\u0006(this.RightColumn, 0.0);
			\u001A\u0005.~\u000E\u000F(this.SetupToggleButton, Visibility.Visible);
			\u008E\u0005.~\u0087\u000F(this.SetupToggleButton, new bool?(true));
			\u008E\u0005.~\u0087\u000F(this.LeftExplorerToggleButton, new bool?(false));
			\u008F\u0005.\u0088\u000F(this.LeftExplorerToggleButton, 1);
			\u0090\u0005.~\u0089\u000F(this.LeftExplorerToggleButton, new Thickness(5.0, 0.0, 0.0, 0.0));
			\u001A\u0005.~\u000E\u000F(this.ExplorerPanel, Visibility.Collapsed);
			\u001A\u0005.~\u000E\u000F(this.RightSplitter, Visibility.Collapsed);
			\u001A\u0005.~\u000E\u000F(this.OptionsPanel, Visibility.Visible);
			if (!\u0015\u0002.\u0090\u0004(\u001B\u0002.~\u0002\u0005(this.OptionsPanel)))
			{
				\u009F\u0002.~\u0094\u0006(this.ExplorerPanel, \u001B\u0002.~\u0002\u0005(this.OptionsPanel));
			}
			\u009B\u0002.~\u0012\u0006(this.ExplorerPanel, Grid.ColumnProperty, 0);
		}

		// Token: 0x06007F80 RID: 32640 RVA: 0x001BEA74 File Offset: 0x001BCC74
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri uri = new Uri(#Phc.#3hc(107280153), UriKind.Relative);
			\u0098.\u0091\u0003(this, uri);
		}

		// Token: 0x06007F81 RID: 32641 RVA: 0x00067E3E File Offset: 0x0006603E
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return \u008B\u0005.\u0083\u000F(delegateType, this, handler);
		}

		// Token: 0x06007F82 RID: 32642 RVA: 0x001BEABC File Offset: 0x001BCCBC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.LayoutRoot = (Grid)target;
				return;
			case 2:
				this.LeftColumn = (ColumnDefinition)target;
				return;
			case 3:
				this.RightColumn = (ColumnDefinition)target;
				return;
			case 4:
				this.SetupToggleButton = (RadToggleButton)target;
				return;
			case 5:
				this.LeftExplorerToggleButton = (RadToggleButton)target;
				return;
			case 6:
				this.PageNumberBox = (CustomRadNumericUpDown)target;
				\u001E\u0005.~\u0012\u000F(this.PageNumberBox, new KeyEventHandler(this.CurrentPage_KeyDown));
				return;
			case 7:
				this.PercentComboBox = (PercentComboBox)target;
				return;
			case 8:
				\u007F\u0005.~\u0019\u000F((RadToggleButton)target, new MouseButtonEventHandler(this.ExplorerToggleButton_PreviewMouseLeftButtonDown));
				return;
			case 9:
				this.FitToSinglePage = (RadToggleButton)target;
				\u007F\u0005.~\u0019\u000F(this.FitToSinglePage, new MouseButtonEventHandler(this.ExplorerToggleButton_PreviewMouseLeftButtonDown));
				return;
			case 10:
				this.OptionsPanel = (Border)target;
				return;
			case 11:
				this.LeftSplitter = (GridSplitter)target;
				return;
			case 12:
				this.WordAndPdfReportPage = (WordAndPdfReportPage)target;
				return;
			case 13:
				this.ExcelPage = (ExcelReportPage)target;
				return;
			case 14:
				this.TextReportPage = (WordAndPdfReportPage)target;
				return;
			case 15:
				this.RightSplitter = (GridSplitter)target;
				return;
			case 16:
				this.ExplorerPanel = (Border)target;
				return;
			case 17:
				this.ExplorerView = (ReportExplorerView)target;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x06007F83 RID: 32643 RVA: 0x00067FDD File Offset: 0x000661DD
		void #4Kd.add_Activated(EventHandler value)
		{
			\u0091\u0005.\u008B\u000F(this, value);
		}

		// Token: 0x06007F84 RID: 32644 RVA: 0x00067FF7 File Offset: 0x000661F7
		void #4Kd.remove_Activated(EventHandler value)
		{
			\u0091\u0005.\u008C\u000F(this, value);
		}

		// Token: 0x06007F85 RID: 32645 RVA: 0x00068011 File Offset: 0x00066211
		ImageSource #4Kd.get_Icon()
		{
			return \u0092\u0005.\u008E\u000F(this);
		}

		// Token: 0x06007F86 RID: 32646 RVA: 0x00068026 File Offset: 0x00066226
		void #4Kd.set_Icon(ImageSource value)
		{
			\u0093\u0005.\u008F\u000F(this, value);
		}

		// Token: 0x06007F87 RID: 32647 RVA: 0x00068040 File Offset: 0x00066240
		Visibility #4Kd.get_Visibility()
		{
			return \u0094\u0005.\u0090\u000F(this);
		}

		// Token: 0x06007F88 RID: 32648 RVA: 0x00068055 File Offset: 0x00066255
		void #4Kd.set_Visibility(Visibility value)
		{
			\u001A\u0005.\u000E\u000F(this, value);
		}

		// Token: 0x06007F89 RID: 32649 RVA: 0x00067E59 File Offset: 0x00066059
		void #WBc.Show()
		{
			\u0007.\u0080(this);
		}

		// Token: 0x06007F8A RID: 32650 RVA: 0x00008B22 File Offset: 0x00006D22
		bool? #WBc.ShowDialog()
		{
			return base.ShowDialog();
		}

		// Token: 0x06007F8B RID: 32651 RVA: 0x000344D3 File Offset: 0x000326D3
		void #WBc.Close()
		{
			\u0007.\u0010(this);
		}

		// Token: 0x06007F8C RID: 32652 RVA: 0x00008AED File Offset: 0x00006CED
		bool? #WBc.get_DialogResult()
		{
			return base.DialogResult;
		}

		// Token: 0x06007F8D RID: 32653 RVA: 0x00008AFD File Offset: 0x00006CFD
		void #WBc.set_DialogResult(bool? value)
		{
			base.DialogResult = value;
		}

		// Token: 0x06007F8E RID: 32654 RVA: 0x0003449F File Offset: 0x0003269F
		void #WBc.add_Closing(CancelEventHandler value)
		{
			\u0099.\u0092\u0003(this, value);
		}

		// Token: 0x06007F8F RID: 32655 RVA: 0x000344B9 File Offset: 0x000326B9
		void #WBc.remove_Closing(CancelEventHandler value)
		{
			\u0099.\u0093\u0003(this, value);
		}

		// Token: 0x06007F90 RID: 32656 RVA: 0x00067E6E File Offset: 0x0006606E
		void #WBc.add_Loaded(RoutedEventHandler value)
		{
			\u001F\u0005.\u0016\u000F(this, value);
		}

		// Token: 0x06007F91 RID: 32657 RVA: 0x00067E88 File Offset: 0x00066088
		void #WBc.remove_Loaded(RoutedEventHandler value)
		{
			\u001F\u0005.\u0017\u000F(this, value);
		}

		// Token: 0x04003448 RID: 13384
		private ExplorerPosition explorerPosition;

		// Token: 0x04003449 RID: 13385
		private double lastColumnWidth = 330.0;

		// Token: 0x0400344C RID: 13388
		internal Grid LayoutRoot;

		// Token: 0x0400344D RID: 13389
		internal ColumnDefinition LeftColumn;

		// Token: 0x0400344E RID: 13390
		internal ColumnDefinition RightColumn;

		// Token: 0x0400344F RID: 13391
		internal RadToggleButton SetupToggleButton;

		// Token: 0x04003450 RID: 13392
		internal RadToggleButton LeftExplorerToggleButton;

		// Token: 0x04003451 RID: 13393
		internal CustomRadNumericUpDown PageNumberBox;

		// Token: 0x04003452 RID: 13394
		internal PercentComboBox PercentComboBox;

		// Token: 0x04003453 RID: 13395
		internal RadToggleButton FitToSinglePage;

		// Token: 0x04003454 RID: 13396
		internal Border OptionsPanel;

		// Token: 0x04003455 RID: 13397
		internal GridSplitter LeftSplitter;

		// Token: 0x04003456 RID: 13398
		internal WordAndPdfReportPage WordAndPdfReportPage;

		// Token: 0x04003457 RID: 13399
		internal ExcelReportPage ExcelPage;

		// Token: 0x04003458 RID: 13400
		internal WordAndPdfReportPage TextReportPage;

		// Token: 0x04003459 RID: 13401
		internal GridSplitter RightSplitter;

		// Token: 0x0400345A RID: 13402
		internal Border ExplorerPanel;

		// Token: 0x0400345B RID: 13403
		internal ReportExplorerView ExplorerView;

		// Token: 0x0400345C RID: 13404
		private bool _contentLoaded;
	}
}
